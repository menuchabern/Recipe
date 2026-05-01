create or alter proc dbo.MealGet(
	@All int = 1,
	@IncludeBlank int = 0,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0

	select m.MealID, m.MealName, us.UserName, NumCalories = sum(r.calories), 
		NumCourses = count(mc.mealcourseid), NumRecipes = count(r.recipeid), us.usernameid, dateCreated = CONVERT(date, m.datecreated), m.picturename, m.mealdesc
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
	group by m.MealID, us.UserName, m.MealName, us.usernameid, m.datecreated, m.picturename, m.mealdesc
	union select 0, '','', 0, 0, 0, 0, '00-00-0000', '', ''
	where @includeblank = 1
	order by m.MealName

	return @return
end

-- exec mealget