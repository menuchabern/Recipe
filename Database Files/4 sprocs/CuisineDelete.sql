create or alter procedure dbo.CuisineDelete(
	@CuisineId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @CuisineId = isnull(@CuisineId,0)

	delete cr 
	from CookbookRecipe cr
	join Recipe r
	on r.RecipeID = cr.RecipeID
	where r.CuisineID = @CuisineId

	delete rmc 
	from RecipeMealCourse rmc
	join Recipe r 
	on r.RecipeID = rmc.RecipeID
	where r.CuisineID = @CuisineId

	delete rs
	from RecipeSteps rs
	join Recipe r
	on r.RecipeID = rs.RecipeID
	where r.CuisineID = @CuisineId

	delete ri
	from RecipeIngredient ri
	join Recipe r
	on r.RecipeID = ri.RecipeId
	where r.CuisineID = @CuisineId

	delete Recipe where CuisineID = @CuisineId

	delete Cuisine where CuisineID = @CuisineId

	return @return
end
go
