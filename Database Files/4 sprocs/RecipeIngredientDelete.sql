create or alter proc dbo.RecipeIngredientDelete(
	@RecipeIngredientID int,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0

	select @RecipeIngredientID = ISNULL(@RecipeIngredientID, 0)

	delete RecipeIngredient
	where RecipeIngredientid = @RecipeIngredientID

	return @return
end