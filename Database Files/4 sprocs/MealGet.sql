create or alter proc dbo.MealGet(
	@All int = 1,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0

	select m.MealID, m.MealName, us.UserName, NumCalories = sum(r.calories), NumCourses = count(mc.mealcourseid), NumRecipes = count(r.recipeid)
	from meal m
	left join UserName us
	on m.UserNameID = us.UserNameID
	left join MealCourse mc
	on m.MealID = mc.MealID
	left join RecipeMealCourse rmc
	on mc.MealCourseID = rmc.MealCourseID
	left join Recipe r
	on r.RecipeID = rmc.RecipeID
	where @All = 1
	group by m.MealID, us.UserName, m.MealName
	order by m.MealName

	return @return
end