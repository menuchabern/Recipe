--AS Amazing job! 
use RecipeDB
go

delete CookbookRecipe
delete Cookbook 
delete RecipeMealCourse
delete MealCourse
delete Meal
delete RecipeSteps
delete RecipeIngredient
delete Recipe
delete CourseType
delete MeasurementType
delete Ingredient
delete Cuisine
delete UserName

insert UserName (FirstName, LastName, UserName)
select 'Mark', 'Black', 'Mak'
union select 'Jackey', 'Schwartz', 'Jake'
union select 'Ava', 'Smith', 'AS'
union select 'Mary', 'Jones', 'Jam'
union select 'Pat', 'Johnson', 'Pat'

insert Cuisine(CuisineType)
select 'American'
union select 'English'
union select 'French'
union select 'Swiss'
union select 'Israeli'

insert Ingredient (IngredientName)
select  'sugar'
union select 'oil'
union select 'eggs'
union select 'Flour'
union select 'baking powder'
union select 'baking soda'
union select 'chocolate chips'
union select 'granny smith apples'
union select 'vanilla yogurt'
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'club bread'
union select 'butter'
union select 'shredded cheese'
union select 'crushed cloves garlic'
union select 'black pepper' 
union select 'salt'
union select 'vanilla pudding'
union select 'whipped cream cheese'
union select 'sour cream cheese'
union select 'Mayonnaise'
union select 'parsley'
union select 'mustard'
union select 'garlic powder'
union select 'cherry tomatoes'
union select 'avocado'
union select 'lettuce'
union select 'sweet potato'
union select 'olive oil'
union select 'veggie chips'
union select 'chicken breasts'
union select 'breadcrumbs'
union select 'sesame seeds'
union select 'margarine'
union select 'vanilla sugar'
union select 'cocoa'

insert MeasurementType(MeasurementType)
select 'cups'
union select 'cup'
union select 'tsp'
union select 'tbsp'
union select 'pinch'
union select 'oz'
union select 'stick'
union select 'lbs'
union select 'dash'
union select 'bag'

insert CourseType(CourseName, CourseSequence)
select 'appetizer', 1
union select 'main course', 2
union select 'dessert', 3

;with x as (
   select Cuisine = 'American', UserName = 'Jake', RecipeName = 'Chocolate Chip Cookies', Calories = 100, DateDrafted = '7/11/15', DatePublished = '12/8/19', DateArchived = '3/18/24'
   union select 'French', 'Jam', 'Apple Yogurt Smoothie', 75, '3/9/20', null, null
   union select 'English', 'Mak', 'Cheese Bread', 200, '7/20/17', '4/12/19', null
   union select 'American', 'Pat', 'Butter Muffins', 150, '2/9/23', null, null
   union select 'American', 'As', 'Sweet Potato Parsley Salad', 200, '8/12/20', '2/23/21', '7/24/24'
   union select 'Israeli', 'Mak', 'Breaded Chicken Breasts', 215, '2/2/20', null, null
   union select 'Swiss', 'Jam', 'Fudgy Brownies', 300, '8/23/19', null, '8/14/24'
)
insert Recipe (CuisineID, UserNameID, RecipeName, Calories, DateDrafted, DatePublished, DateArchived) 
select c.CuisineID, un.UserNameID, x.RecipeName, x.Calories, x.DateDrafted, x.DatePublished, x.DateArchived
from x 
join Cuisine c 
on x.Cuisine = c.CuisineType
join UserName un 
on un.UserName = x.UserName

;with x as (
   select Recipe = 'Chocolate Chip Cookies', MeasurementNumber = 1, MeasurementType = 'cup', Ingredient = 'sugar', IngredientSequence = 1
   union select 'Chocolate Chip Cookies', 1/2, 'cup', 'oil', 2
   union select 'Chocolate Chip Cookies', 3, null, 'eggs', 3
   union select 'Chocolate chip cookies', 2, 'cups', 'Flour', 4
   union select 'chocolate chip cookies', 1, 'tsp', 'vanilla sugar', 5
   union select 'chocolate chip cookies', 2, 'tsp', 'baking powder', 6
   union select 'chocolate chip cookies', .5, 'tsp', 'baking soda', 7
   union select 'chocolate chip cookies', 1, 'cup', 'chocolate chips', 8
   union select 'Apple Yogurt Smoothie', 3, null, 'granny smith apples', 1
   union select 'apple yogurt smoothie', 2, 'cups', 'vanilla yogurt', 2
   union select 'apple yogurt smoothie', 2, 'tsp', 'sugar', 3
   union select 'apple yogurt smoothie', .5, 'cup', 'orange juice', 4
   union select 'apple yogurt smoothie', 2, 'tbsp', 'honey', 5
   union select 'apple yogurt smoothie', 5.5, null, 'ice cubes', 6
   union select 'Cheese Bread', 1, null, 'club bread', 1
   union select 'cheese bread', 4, 'oz', 'butter', 2
   union select 'cheese bread', 8, 'oz', 'shredded cheese', 3
   union select 'cheese bread', 2, null, 'crushed cloves garlic', 4
   union select 'cheese bread', 1.25, 'tsp', 'black pepper', 5
   union select 'cheese bread', 1, 'pinch', 'salt', 6
   union select 'Butter Muffins', 1, 'stick', 'butter', 1
   union select 'butter muffins', 3, 'cups', 'sugar', 2
   union select 'butter muffins', 2, 'tbsp', 'vanilla pudding', 3
   union select 'butter muffins', 4, null, 'eggs', 4
   union select 'butter muffins', 8, 'oz', 'whipped cream cheese', 5
   union select 'butter muffins', 8, 'oz', 'sour cream cheese', 6
   union select 'butter muffins', 1, 'cups', 'flour', 7
   union select 'butter muffins', 2, 'tsp', 'baking powder', 8
   union select 'fudgy brownies', 1, 'cup',  'margarine', 1
   union select 'fudgy brownies', 1, 'cup', 'sugar', 2
   union select 'fudgy brownies', 2, 'tsp', 'vanilla sugar', 3
   union select 'fudgy brownies', 4, null, 'eggs', 4
   union select 'fudgy brownies', .75, 'cups', 'cocoa', 5
   union select 'fudgy brownies', 1, 'cup', 'flour', 6
   union select 'fudgy brownies', .5, 'tsp', 'baking powder', 7
   union select 'fudgy brownies', 1/4, 'tsp', 'salt', 8
   union select 'breaded chicken breasts', 4, null, 'chicken breasts', 1
   union select 'breaded chicken breasts', 1.75, 'cups', 'Breadcrumbs', 2
   union select 'breaded chicken breasts', .5, 'cup', 'oil', 3
   union select 'breaded chicken breasts', .5, 'cup', 'sesame seeds', 4
   union select 'breaded chicken breasts', .75, 'tsp', 'salt', 5
   union select 'breaded chicken breasts', 1, 'dash', 'black pepper', 6
   union select 'breaded chicken breasts', 4, null, 'crushed cloves garlic', 7
   union select 'sweet potato parsley salad', 1, 'bag', 'lettuce', 1
   union select 'sweet potato parsley salad', 1, 'cup', 'veggie chips', 2
   union select 'sweet potato parsley salad', 1, null, 'avocado', 3
   union select 'sweet potato parsley salad', 1, 'cup', 'cherry tomatoes', 4
   union select 'sweet potato parsley salad', 1, null, 'sweet potato', 5
   union select 'sweet potato parsley salad', 2, 'tbsp', 'mayonnaise', 6
   union select 'sweet potato parsley salad', .75, 'cups', 'oil', 7
   union select 'sweet potato parsley salad', 1, 'tbsp', 'sugar', 8
   union select 'sweet potato parsley salad', 1, 'tbsp', 'parsley', 9
   union select 'sweet potato parsley salad', 1, 'tsp', 'mustard', 10
   union select 'sweet potato parsley salad', 1.5, 'tsp', 'garlic powder', 11
   union select 'sweet potato parsley salad', 1, 'pinch', 'salt', 12
)
insert RecipeIngredient(RecipeId, IngredientID, MeasurementTypeID, MeasurementNumber, IngredientSequence)
select r.RecipeID, i.IngredientID, mt.MeasurementTypeID, x.MeasurementNumber, x.IngredientSequence
from x 
join Recipe r 
on r.RecipeName = x.Recipe
join Ingredient i 
on i.IngredientName = x.Ingredient
left join MeasurementType mt 
on mt.MeasurementType = x.MeasurementType 

;with x as (
   select Recipe = 'Chocolate Chips cookies', StepSequence = 1, StepDirection = 'combine sugar, oil and eggs in a bowl'
   union select 'chocolate chip cookies', 2, 'mix well'
   union select 'chocolate chip cookies', 3, 'add flour, vanilla sugar, baking powder and baking soda'
   union select 'chocolate chip cookies', 4, 'beat for 5 minutes'
   union select 'chocolate chip cookies', 5, 'add chocolate chips'
   union select 'chocolate chip cookies', 6, 'freeze for 1-2 hours'
   union select 'chocolate chip cookies', 7, 'roll into balls and place spread out on a cookie sheet'
   union select 'chocolate chip cookies', 8, 'bake on 350 for 10 min'
   union select 'apple yogurt smoothie', 1, 'Peel the apples and dice'
   union select 'apple yogurt smoothie', 2, 'Combine all ingredients in bowl except for apples and ice cubes'
   union select 'apple yogurt smoothie', 3, 'mix until smooth'
   union select 'apple yogurt smoothie', 4, 'add apples and ice cubes'
   union select 'apple yogurt smoothie', 5, 'pour into glasses'
   union select 'cheese bread', 1, 'Slit bread every 3/4 inch'
   union select 'cheese bread', 2, 'Combine all ingredients in bowl'
   union select 'cheese bread', 3, 'fill slits with cheese mixture'
   union select 'cheese bread', 4, 'wrap bread into a foil and bake for 30 minutes'
   union select 'butter muffins', 1, 'Cream butter with sugars'
   union select 'butter muffins', 2, 'Add eggs and mix well'
   union select 'butter muffins', 3, 'Slowly add rest of ingredients and mix well'
   union select 'butter muffins', 4, 'fill muffin pans 3/4 full and bake for 30 minutes'
   union select 'sweet potato parsley salad', 1, 'mix together the mayonnaise, oil, sugar, parsley, mustard, garlic powder and salt in a container and shake'
   union select 'sweet potato parsley salad', 2, 'cut the sweet potato into strips and bake it in the olive oil until the edges turn brown'
   union select 'sweet potato parsley salad', 3, 'crush the veggies chips'
   union select 'sweet potato parsley salad', 4, 'dice the avocado'
   union select 'sweet potato parsley salad', 5, 'add the lettuce, crushed chips, avocado, cherry tomatoes and baked sweet potato into a large salad bowl'
   union select 'sweet potato parsley salad', 6, 'drizzle the dressing on top and toss'
   union select 'breaded chicken breasts', 1, 'Preheat oven to 425°F'
   union select 'breaded chicken breasts', 2, 'Combine bread crumbs, oil, sesame seeds, salt, black pepper, and garlic powder'
   union select 'breaded chicken breasts', 3, 'Place chicken pieces in breadcrumbs mixture, coating chicken well with crumbs'
   union select 'breaded chicken breasts', 4, 'Line 2 baking sheets with parchment paper. Place chicken strips on baking sheets, making sure they are not too close to each other'
   union select 'breaded chicken breasts', 5, 'Bake covered for 10 minutes. Uncover for an additional 10-14 minutes, until edges are golden and chicken is cooked through'
   union select 'fudgy brownies', 1, 'mix all the ingredients together'
   union select 'fudgy brownies', 2, 'pour the batter into a 9X13 and bake on 350 for 30 minutes' 
)
insert RecipeSteps (RecipeID, StepSequence, StepDirection)
select r.RecipeID, x.StepSequence, x.StepDirection 
from x 
join recipe r 
on r.RecipeName = x.recipe

;with x as (
   select UserName = 'mak', Meal = 'Breakfast Bash', DateCreated = '9/23/20', Active = 1 
   union select 'Jake', 'Savory Supper', '6/17/16', 0
   union select 'As','Midday Snack', '12/19/22', 1 
   union select 'Jam', 'Light Lunch', '8/19/24', 1
)
insert Meal (UserNameID, MealName, DateCreated, ActiveStatus)
select un.UserNameID, x.Meal, x.DateCreated, x.Active
from x 
join UserName un
on un.UserName = x.UserName

;with x as(
   select Meal = 'Breakfast Bash', CourseType = 'Appetizer'
   union select 'Breakfast Bash', 'Main Course'
   union select 'light lunch', 'main course'
   union select 'midday snack', 'main course'
   union select 'savory supper', 'appetizer'
   union select 'savory supper', 'main course'
   union select 'savory supper', 'dessert'
)
insert MealCourse(MealID, CourseTypeID)
select m.MealID, ct.CourseTypeID
from x 
join Meal m 
on m.MealName = x.Meal
join CourseType ct 
on x.CourseType = ct.CourseName
;with x as (
   select  Meal = 'Savory Supper', Course = 'Appetizer', Recipe = 'Sweet Potato Parsley Salad', MainDish = 0
   union select 'Savory Supper', 'Main Course', 'Breaded Chicken Breasts', 1
   union select 'Savory Supper', 'Dessert', 'Fudgy Brownies', 0
   union select 'Midday Snack', 'Main Course', 'Apple Yogurt Smoothie', 0
   union select 'Midday Snack', 'Main Course', 'Chocolate Chip Cookies', 1
   union select 'Light Lunch', 'Main Course', 'Butter Muffins', 1
   union select 'Light Lunch', 'Main Course', 'Sweet Potato Parsley Salad', 0
   union select 'Breakfast Bash', 'Main Course', 'Cheese Bread', 1
   union select 'Breakfast Bash', 'Main Course', 'Butter Muffins', 0
   union select 'Breakfast Bash', 'Appetizer', 'Apple Yogurt Smoothie', 0
)
insert RecipeMealCourse(MealCourseID, RecipeID, MainDish)
select mc.MealCourseID, r.RecipeID, x.MainDish
from x 
join Meal m 
on m.MealName = x.Meal
join CourseType ct 
on ct.CourseName = x.Course
join MealCourse mc 
on mc.MealID = m.MealID 
   and ct.CourseTypeID = mc.CourseTypeID
join Recipe r 
on r.RecipeName = x.Recipe

;with x as(
   select UserName = 'Mak', CookbookName = 'Treats For Two', Price = 30, Active = 1, DateCreated = '12/07/12'
   union select 'Jake', 'Dairy Delights', 17.99, 1, '7/14/22'
   union select 'Jam', 'Savory Snacks', 25.50, 0, '6/19/23'
   union select 'as', 'Healthy Habits', 40, 1, '9/24/17'
)
insert Cookbook (UserNameID, CookbookName, Price, ActiveStatus, DateCreated)
select un.UserNameID, x.CookbookName, x.Price, x.Active, x.DateCreated
from x 
join UserName un 
on un.UserName = x.UserName

;with x as (
   select Cookbook = 'Treats For Two', Recipe = 'Chocolate Chip Cookies', RecipeSequence = 1
   union select 'treats for two', 'Apple Yogurt Smoothie', 2 
   union select 'treats for two', 'Cheese Bread', 3 
   union select 'treats for two', 'Butter Muffins', 4
   union select 'savory snacks', 'butter muffins', 1
   union select 'savory snacks', 'chocolate chip cookies', 2
   union select 'savory snacks', 'fudgy brownies', 3 
   union select 'dairy delights', 'apple yogurt smoothie', 1
   union select 'dairy delights', 'butter muffins', 2
   union select 'dairy delights', 'cheese bread', 3
   union select 'healthy habits', 'sweet potato parsley salad', 1
   union select 'healthy habits', 'apple yogurt smoothie', 2
   union select 'healthy habits', 'breaded chicken breasts', 3
)
insert CookbookRecipe(CookbookID, RecipeID, RecipeSequence)
select c.CookbookID, r.RecipeID, x.RecipeSequence
from x 
join Recipe r 
on r.RecipeName = x.Recipe
join Cookbook c 
on c.CookbookName = x.Cookbook



