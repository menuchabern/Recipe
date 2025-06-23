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
    constraint ck_DateDrafted_must_be_before_DateArchived check(DateDrafted <= DateArchived)
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