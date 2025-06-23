use RecipeDB
go 
drop table if exists CookbookRecipe
drop table if exists Cookbook
drop table if exists RecipeMealCourse 
drop table if exists MealCourse
drop table if exists Meal
drop table if exists RecipeSteps
drop table if exists RecipeIngredient
drop table if exists Recipe 
drop table if exists CourseType
drop table if exists MeasurementType
drop table if exists Ingredient 
drop table if exists Cuisine
drop table if exists UserName 
go

create table dbo.UserName(
    UserNameID int not null identity primary key,
    FirstName varchar(25) not null constraint ck_FirstName_cannot_be_blank check(firstname <> ''), 
    LastName varchar(30) not null constraint ck_LastName_cannot_be_blank check (LastName <> ''),
    UserName  varchar(30) not null 
        constraint ck_UserName_cannot_be_blank check(UserName <> '') 
        constraint u_UserName unique 
)
go

create table dbo.Cuisine (
    CuisineID int not null identity primary key,
    Cuisine varchar(30) not null 
        constraint ck_Cuisine_cannot_be_blank check(Cuisine <> '') 
        constraint u_Cuisine unique 
)
go

create table dbo.Ingredient(
    IngredientID int not null IDENTITY primary key,
    IngredientName varchar(30) not null 
        constraint ck_IngredientName_cannot_be_blank check(IngredientName <> '') 
        constraint u_IngredientName unique, 
    PictureName as concat('Ingredient_', replace(IngredientName, ' ', '_'), '.jpg' )
)
GO

create table dbo.MeasurementType(
    MeasurementTypeID int not null identity primary key,
    MeasurementType varchar(30) not null 
        constraint ck_MeasurementType_cannot_be_blank check (MeasurementType <> '') 
        constraint u_MeasurementType unique 
)
go

create table dbo.CourseType(
    CourseTypeID int not null identity primary key,
    CourseName varchar(30) not null 
        constraint ck_CourseName_cannot_be_blank check (CourseName <> '') 
        constraint u_CourseName unique, 
    CourseSequence tinyint not null  
        constraint ck_CourseSequence_must_be_greater_than_0 check(CourseSequence > 0) 
        constraint u_CourseSequence unique 
)
go

create table dbo.Recipe( 
    RecipeID int not null identity primary key,
    CuisineID int not null constraint f_Cuisine_Recipe foreign key references Cuisine(CuisineID),
    UserNameID int not null constraint f_UserName_Recipe foreign key references UserName(UserNameID),
    RecipeName varchar(40) not null 
        constraint ck_RecipeName_cannot_be_blank check (RecipeName <> '') 
        constraint u_RecipeName unique,
    Calories int not null constraint ck_Calories_must_be_greater_than_or_equal_to_0 check(Calories >= 0),
    PictureName as concat('Recipe_', replace(RecipeName, ' ', '_'), '.jpg' ),
    DateDrafted datetime not null constraint ck_DateDrafted_cannot_be_in_the_future check (DateDrafted between '1/1/2000' and getdate()),
    DatePublished  datetime null constraint ck_DatePublished_cannot_be_in_the_future check (DatePublished < getdate()),
    DateArchived datetime null constraint ck_Archived_cannot_be_in_the_future check (DateArchived < getdate()),
    RecipeStatus as case when DatePublished is null and DateArchived is null then 'Draft'
        when DatePublished is not null and DateArchived is null then 'Published'
        else 'Archived' end,
    constraint ck_DateDrafted_must_be_before_DatePublished check (DateDrafted < DatePublished),
    constraint ck_DatePublished_must_be_before_DateArchived check(DatePublished <= DateArchived),
--AS Change to less than or equal
    constraint ck_DateDrafted_must_be_before_DateArchived check(DateDrafted < DateArchived)
)
go

create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_RecipeIngredient foreign key references Recipe(RecipeID),
    IngredientID int not null constraint f_Ingredient_RecipeIngredient foreign key references Ingredient(IngredientID),
    MeasurementTypeID int constraint f_MeasurementType_RecipeIngredient foreign key references MeasurementType(MeasurementTypeID),
    MeasurementNumber decimal (4,2) not null constraint ck_MeasurementNumber_cannot_negative check(MeasurementNumber >= 0),
    IngredientSequence tinyint not null constraint ck_IngredientSequence_must_be_greater_than_0 check(IngredientSequence > 0),
    constraint u_IngredientID_RecipeID unique(IngredientID, RecipeID),
    constraint u_IngredientSequence_RecipeID unique(IngredientSequence, RecipeID)
)
go 

create table dbo.RecipeSteps(
    RecipeStepsID int not null identity primary KEY,
    RecipeID int not null constraint f_Recipe_RecipeSteps foreign key references Recipe(RecipeID),
    StepSequence tinyint not null constraint ck_StepSequence_must_be_greater_than_0 check (StepSequence > 0),
    StepDirection varchar (250) not null constraint ck_StepDirection_cannot_be_blank check(StepDirection <> ''),
    constraint u_StepSequence_RecipeId unique(StepSequence, RecipeID)
)
go

create table dbo.Meal(
    MealID int not null IDENTITY primary key,
    UserNameID int not null constraint f_UserName_Meal foreign key references UserName(UserNameID),
    MealName varchar(30) not null 
        constraint ck_MealName_cannot_be_blank check(MealName <> '') 
        constraint u_MealName unique,
    DateCreated date not null constraint ck_Meal_DateCreated_cannot_be_in_the_future check(DateCreated between '1/1/2000' and getdate()),
    ActiveStatus bit not null,
    PictureName as concat('Meal_', replace(MealName, ' ', '_'), '.jpg' )
)
go

create table dbo.MealCourse(
    MealCourseID int not null identity primary key,
    MealID int not null constraint f_Meal_MealCourse foreign key REFERENCES Meal(MealID),
    CourseTypeID int not null constraint f_CourseType_MealCourse foreign key REFERENCES CourseType(CourseTypeID),
    constraint u_MealID_CourseTypeID unique (MealID, CourseTypeID) 
)
go

create table dbo.RecipeMealCourse(
    RecipesMealCourseID int not null identity primary key,
    MealCourseID int not null constraint f_MealCourse_RecipeMealCourse foreign key references MealCourse(MealCourseID),
    RecipeID int not null constraint f_Recipe_RecipeMealCourse foreign key references Recipe(RecipeID), 
    MainDish bit not null,
    constraint u_MealCourseID_RecipeID unique(MealCourseID, RecipeID)
)
go

create table dbo.Cookbook(
    CookbookID int not null identity primary key,
    UserNameID int not null constraint f_UserName_Cookbook foreign key references UserName(UserNameID),
    CookbookName varchar(30) not null 
        constraint ck_CookbookName_cannot_be_blank check(CookbookName <> ' ') 
        constraint u_CookbookName unique,
    Price decimal (5,2) not null constraint ck_Price_must_be_greater_than_0 check(price > 0),
    ActiveStatus bit not null,
    DateCreated date not null constraint ck_Cookbook_DateCreated_cannot_be_in_the_future check(DateCreated between '1/1/2000' and getdate()),
    PictureName as concat('Cookbook_', replace(cookbookname, ' ', '_'), '.jpg' ) 
)
go

create table dbo.CookbookRecipe(
    CookbookRecipeID int not null identity primary key ,
    CookbookID int not null constraint f_Cookbook_CookbookRecipe foreign key references Cookbook(CookbookID),
    RecipeID int not null constraint f_Recipe_CookbookRecipe foreign key references Recipe(RecipeID),
    RecipeSequence int not null constraint ck_RecipeSequence_must_be_greater_than_0 check (RecipeSequence > 0),
    constraint u_CookbookID_RecipeID unique (cookbookid, recipeid) 
)
go
