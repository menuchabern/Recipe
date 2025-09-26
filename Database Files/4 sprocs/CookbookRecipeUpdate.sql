create or alter proc dbo.CookbookRecipeUpdate(
	@CookbookRecipeId int,
	@CookbookId int,
	@Recipeid int,
	@RecipeSequence int,
	@message varchar(500) = '' output
)
as
begin
	declare @return int = 0
	
	select @CookbookRecipeId = isnull(@CookbookRecipeId, 0), @CookbookId = isnull(@cookbookid, 0), @Recipeid = isnull(@recipeid, 0)

	if @CookbookRecipeID = 0
	begin
		insert CookbookRecipe(RecipeID, Cookbookid, RecipeSequence)
		values(@RecipeID, @CookbookId, @RecipeSequence)

		select @CookbookRecipeID = scope_identity()
	end
	else
	begin
		update CookbookRecipe
		set
			RecipeID = @RecipeID, 
			CookbookID = @CookbookId,
			RecipeSequence = @RecipeSequence
		where CookbookRecipeID = @CookbookRecipeId
	end

	return @return
end