--AS Fantastic job! 
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.

--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete cr 
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
join CookbookRecipe cr
on cr.RecipeID = r.RecipeID
where un.UserName = 'AS'

delete ri
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
join RecipeIngredient ri 
on ri.RecipeID = r.RecipeID
where un.UserName = 'AS'

delete rs
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
join RecipeSteps rs 
on rs.RecipeID = r.RecipeID
where un.UserName = 'AS'

delete rmc
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
join RecipeMealCourse rmc 
on rmc.RecipeID = r.RecipeID
where un.UserName = 'AS'

delete r 
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
where un.UserName = 'AS'

delete rmc 
from UserName un 
join Meal m 
on m.UserNameID = un.UserNameID
join MealCourse mc 
on mc.MealID = m.MealID
join RecipeMealCourse rmc 
on rmc.MealCourseID = mc.MealCourseID
where un.UserName = 'AS'

delete mc
from UserName un 
join Meal m 
on m.UserNameID = un.UserNameID
join MealCourse mc 
on mc.MealID = m.MealID
where un.UserName = 'AS'

delete m 
from UserName un 
join Meal m 
on m.UserNameID = un.UserNameID
where un.UserName = 'AS'

delete cr
from UserName un
join Cookbook c 
on c.UserNameID = un.UserNameID
join CookbookRecipe cr 
on cr.CookbookID = c.CookbookID
where un.UserName = 'AS'

delete c
from UserName un
join Cookbook c 
on c.UserNameID = un.UserNameID
where un.UserName = 'AS'

delete un
from UserName un 
where un.UserName = 'AS'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
insert Recipe(CuisineID, UserNameID, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
select r.CuisineID, r.UserNameID, concat(r.recipeName, '- clone'), r.calories, r.DateDrafted, r.DatePublished, r.DateArchived
from recipe r 
where r.recipeName = 'Fudgy Brownies'

;with x as (
	select ri.recipeid, ri.ingredientid, ri.measurementtypeid, ri.measurementnumber, ri.IngredientSequence
	from recipe r 
	join RecipeIngredient ri
	on r.RecipeID = ri.RecipeID
	where r.recipeName = 'Fudgy Brownies'
)
insert RecipeIngredient(RecipeID, IngredientID, MeasurementTypeID, MeasurementNumber, IngredientSequence)
select r.RecipeID, x.ingredientid, x.measurementtypeid, x.measurementnumber, x.ingredientsequence 
from recipe r 
cross join x
where r.RecipeName = 'Fudgy Brownies- clone'

;with x as (
	select rs.RecipeID, rs.StepSequence, rs.StepDirection
	from Recipe r 
	join RecipeSteps rs 
	on r.RecipeID = rs.RecipeID
	where r.RecipeName = 'Fudgy Brownies'
)
insert RecipeSteps (RecipeID, StepSequence, StepDirection)
select r.RecipeID, x.StepSequence, x.StepDirection
from x 
cross join Recipe r 
where r.RecipeName = 'Fudgy Brownies- clone'

/* 
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
;with x as (
	select CookbookPrice = count(r.recipeid) * 1.33, un.UserName
	from recipe r 
	join UserName un 
	on un.UserNameID = r.UserNameID
	where un.UserName = 'Mak'
	group by un.UserName
)
insert Cookbook (UserNameID, CookbookName, Price, ActiveStatus, DateCreated)
select un.UserNameID, concat('Recipes By ', un.FirstName, ' ', un.LastName), x.CookbookPrice, 1, '12/09/21'
from x
join UserName un 
on x.UserName = un.UserName
where un.UserName = 'Mak'

;with x as(
	select r.RecipeID, r.UserNameID, r.RecipeName
	from recipe r 
	join username un 
	on un.UserNameID = r.UserNameID
	where un.UserName = 'Mak'
)
insert CookbookRecipe(CookbookID, RecipeID, RecipeSequence)
select c.CookbookID, x.RecipeID, ROW_NUMBER() over (order by x.recipeName)
from x 
join UserName un 
on un.UserNameID = x.UserNameID
join Cookbook c 
on un.UserNameID = c.UserNameID
where un.UserName = 'Mak' and c.CookbookName = concat('Recipes By ', un.FirstName, ' ', un.LastName)

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
update r
set Calories = case when mt.MeasurementType in('cup', 'cups') then (ri.MeasurementNumber * 3) + r.calories
	when mt.MeasurementType in ('tbsp', 'tsp') then (ri.MeasurementNumber * 2) + r.calories end 
/*
select i.IngredientName, mt.MeasurementType, ri.MeasurementNumber, r.calories,
	NewCalorie = case when mt.MeasurementType in('cup', 'cups') then (ri.MeasurementNumber * 3) + r.calories
	when mt.MeasurementType in ('tbsp', 'tsp') then (ri.MeasurementNumber * 2) + r.calories end 
*/
from RecipeIngredient ri
join Ingredient i
on i.IngredientID = ri.IngredientID
join MeasurementType mt 
on mt.MeasurementTypeID = ri.MeasurementTypeID
join recipe r 
on r.RecipeID = ri.RecipeID
where i.IngredientName = 'sugar'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;with y as (
	select AvgHours = avg(DATEDIFF(hour, r.DateDrafted, r.DatePublished)) 
	from recipe r 
)
select un.FirstName, 
	un.LastName,
	EmailAddress = concat(substring(un.FirstName, 1,1), un.LastName, '@heartyhearth.com'),
	Alert = concat('Your recipe ', r.recipename, ' is sitting in draft for ',
		DATEDIFF(hour, r.DateDrafted, GETDATE()),
		' hours. That is ', DATEDIFF(hour, r.DateDrafted, GETDATE()) - y.AvgHours,
		' hours more than the average ',  y.AvgHours , ' hours all other recipes took to be published.'
	)
from y 
cross join UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
where RecipeStatus = 'Draft'

/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select EmailBody = concat('Order cookbooks from HeartyHearth.com! We have ', count(*), ' books for sale, average price is ', convert(decimal (5,2), avg(c.Price)), '. You can order them all and receive a 25% discount, for a total of ', convert(decimal (5,2), sum(c.Price) * 0.75), '. Click <a href = "www.heartyhearth.com/order/',newid(),'">here</a> to order.')
from Cookbook c 