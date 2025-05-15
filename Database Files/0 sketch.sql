--FB Amazing work! 100% Please see comments, no need to resubmit.

tables:

User
    UserID int not null identity primary key 
    FirstName varchar not null check constraint not blank 
    LastName varchar not null check not blank 
    UserName check constraint cannot be blank unique 

Cuisine 
    CuisineID int not null identity primary key 
    CuisineType varchar not null check constraint not blank unique 

Ingredient
    IngredientID int not null IDENTITY primary key 
    IngredientName varchar not null unique not blank 
    PictureName varchar as concat('ingredient_', replace(' ', ingredientname, '_')) 

MeasurementType
    MeasurementTypeID int not null identity primary key 
    MeasurementType varchar not null check constraint not blank 
    
CoursesType
    CourseTypeID int not null identity primary key
    CourseName varchar(30) not null check constraint not blank unique 
    CourseSequence tinyint not null  check constraint must be greater than 0 unique 

Recipe 
    RecipeID int not null identity primary key 
    CuisineID int not null foreign key references 
    UserID int not null foreign key references 
    RecipeName varchar int not null unique check constraint not blank
    Calories int not null check constraint must be greater than 0 
    PictureName varchar concat('Recipe_', replace(' ', RecipeName, '_'))
    DatePublished
    DateArchived 

--FB naming of the table should be in a singular format if possible
ingredient in recipe 
    IngredientsInRecipeId int not null identity primary key 
    RecipeId int not null foreign key references 
    IndgredientID int not null foreign key REFERENCES
    MeasurementTypeID int not null foreign key references 
    MeasurementNumber decimal (4,2) not null check constraint must be greater than 0  
    
RecipeSteps 
    RecipeStepsID int not null identity primary KEY
    RecipeID int not null foreign key references 
    StepNumber tinyint not null check constraint must be greater than 0
    StepDirection varchar (250) not null check constraint not blank

Meal-
    MealID int not null IDENTITY primary key 
    UserID int not null foreign key references 
    MealName varchar(30) not null check constraint not blank unique 
    DateCreated date not null check constraint date cannot be in the future 
    status bit not null 
    picturename varchar(30) as concat('Meal_', replace(' ', MealName, '_'))


MealCourses 
    MealCourseID int not null identity primary key 
    MealID int not null foreign key REFERENCES
    UserID int not null foreign key references 
    CourseTypeID int not null foreign key REFERENCES
    unique MealID and CourseTypeID 

RecipesInCourse 
    RecipesInCourseID int not null identity primary key 
    MealCourseID int not null foreign key references 
    RecipeID int not null foreign key references 
    MainDish bit not null 
    unique mealcourseid and recipeid 

Cookbook
    CookbookID int not null identity primary key 
    UserID int not null foreign key references
    CookbookName varchar(30) not null check constraint not blank unique 
    price decimal not null check constraint must be greater than 0 
    ActiveStatus bit 
    DateCreated date not null check constraint cannot be in the future
    PictureName varchar as concat('Cookbook_', replace(' ', CookbookName, '_')) 
    
RecipesInCookbook 
    RecipesInCookbookID int not null identity primary key 
    CookbookID int not null foreign key references 
    RecipeID int not null foreign key references 
    SequenceNumber int not null check constraint must be greater than  0  
    unique cookbookid and recipeid 
