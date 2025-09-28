create or alter procedure dbo.UserNameDelete(
	@UserNameId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @UserNameId = isnull(@UserNameId,0)

	delete cr 
	from UserName un 
	join Recipe r 
	on r.UserNameID = un.UserNameID
	join CookbookRecipe cr
	on cr.RecipeID = r.RecipeID
	where un.UserNameId = @UserNameId

	delete ri
	from UserName un 
	join Recipe r 
	on r.UserNameID = un.UserNameID
	join RecipeIngredient ri 
	on ri.RecipeID = r.RecipeID
	where un.UserNameId = @UserNameId

	delete rs
	from UserName un 
	join Recipe r 
	on r.UserNameID = un.UserNameID
	join RecipeSteps rs 
	on rs.RecipeID = r.RecipeID
	where un.UserNameId = @UserNameId

	delete rmc
	from UserName un 
	join Recipe r 
	on r.UserNameID = un.UserNameID
	join RecipeMealCourse rmc 
	on rmc.RecipeID = r.RecipeID
	where un.UserNameId = @UserNameId

	delete r 
	from UserName un 
	join Recipe r 
	on r.UserNameID = un.UserNameID
	where un.UserNameId = @UserNameId

	delete rmc 
	from UserName un 
	join Meal m 
	on m.UserNameID = un.UserNameID
	join MealCourse mc 
	on mc.MealID = m.MealID
	join RecipeMealCourse rmc 
	on rmc.MealCourseID = mc.MealCourseID
	where un.UserNameId = @UserNameId

	delete mc
	from UserName un 
	join Meal m 
	on m.UserNameID = un.UserNameID
	join MealCourse mc 
	on mc.MealID = m.MealID
	where un.UserNameId = @UserNameId

	delete m 
	from UserName un 
	join Meal m 
	on m.UserNameID = un.UserNameID
	where un.UserNameId = @UserNameId

	delete cr
	from UserName un
	join Cookbook c 
	on c.UserNameID = un.UserNameID
	join CookbookRecipe cr 
	on cr.CookbookID = c.CookbookID
	where un.UserNameId = @UserNameId

	delete c
	from UserName un
	join Cookbook c 
	on c.UserNameID = un.UserNameID
	where un.UserNameId = @UserNameId

	delete un
	from UserName un 
	where un.UserNameId = @UserNameId

	return @return
end
go