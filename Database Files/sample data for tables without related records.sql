use RecipeDB
GO
delete RecipeMealCourse
delete mealcourse
delete meal
delete recipe
delete Cuisine
delete UserName
delete coursetype
go

insert UserName (FirstName, LastName, UserName)
select 'Mark', 'Black', 'Mak'
union select 'Jackey', 'Schwartz', 'Jake'
union select 'Ava', 'Smith', 'AS'
union select 'Mary', 'Jones', 'Jam'
union select 'Pat', 'Johnson', 'Pat'

insert Cuisine(Cuisine)
select 'American'
union select 'English'
union select 'French'
union select 'Swiss'
union select 'Israeli'

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
on x.Cuisine = c.Cuisine
join UserName un 
on un.UserName = x.UserName

;with x as (
   select username = 'As', meal = 'Midday Snack', datecreated = '12/19/22', active = 1 
   union select 'Jam', 'Light Lunch', '8/19/24', 1
)
insert Meal (UserNameID, MealName, DateCreated, ActiveStatus)
select un.UserNameID, x.Meal, x.DateCreated, x.Active
from x 
join UserName un
on un.UserName = x.UserName

insert CourseType(CourseName, CourseSequence)
select 'appetizer', 1
union select 'main course', 2
union select 'dessert', 3

;with x as(
   select meal = 'light lunch', CourseType = 'main course'
   union select 'midday snack', 'main course'
)
insert MealCourse(MealID, CourseTypeID)
select m.MealID, ct.CourseTypeID
from x 
join Meal m 
on m.MealName = x.Meal
join CourseType ct 
on x.CourseType = ct.CourseName
;with x as (
   select meal = 'Midday Snack', course = 'Main Course', recipe = 'Apple Yogurt Smoothie', MainDish = 0
   union select 'Midday Snack', 'Main Course', 'Chocolate Chip Cookies', 1
   union select 'Light Lunch', 'Main Course', 'Butter Muffins', 1
   union select 'Light Lunch', 'Main Course', 'Sweet Potato Parsley Salad', 0
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