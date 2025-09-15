create or alter proc dbo.CookbookRecipesGet(
	@CookbookId int output,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select cr.RecipeID, cr.RecipeSequence
	from Cookbook c
	join CookbookRecipe cr
	on c.CookbookID = cr.CookbookID
	where c.CookbookID = @CookbookId
	order by cr.RecipeSequence

	return @return
end