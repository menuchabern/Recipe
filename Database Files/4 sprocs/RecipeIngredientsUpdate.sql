create or alter procedure dbo.RecipeIngredientsUpdate(
	@RecipeID int = 0,
	@RecipeIngredientID int = 0 output,
	@IngredientID int = 0,
	@MeasurementTypeID int = 0,
	@MeasurementNumber int = 0,
	@IngredientSequence int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @RecipeIngredientID = isnull(@RecipeIngredientID,0)

	if @RecipeIngredientID = 0
	begin
		insert RecipeIngredient(RecipeID, IngredientID, MeasurementTypeID, MeasurementNumber, IngredientSequence)
		values(@RecipeID, @IngredientID, @MeasurementTypeID, @MeasurementNumber, @IngredientSequence)

		select @RecipeIngredientID = scope_identity()
	end
	else
	begin
		update RecipeIngredient
		set
			RecipeID = @RecipeID, 
			IngredientID = @IngredientID,
			MeasurementTypeId = @MeasurementTypeID,
			MeasurementNumber = @MeasurementNumber,
			IngredientSequence = @IngredientSequence
		where RecipeIngredientId = @RecipeIngredientID
	end

	return @return
end
go


--select * from recipeingredient