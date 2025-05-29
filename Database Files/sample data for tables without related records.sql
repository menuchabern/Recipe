use RecipeDB
GO
delete recipe
delete Cuisine
delete UserName
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