create or alter proc dbo.RecipeIngredientsGet(
	@RecipeId int = 0,
	@Message varchar(500) = ''
)
as 
begin
	declare @return int = 0

	select i.ingredientid, mt.measurementtypeid, Quantity = ri.MeasurementNumber, ri.IngredientSequence, r.RecipeID, ri.RecipeIngredientId
	from recipe r
	join RecipeIngredient ri
	on r.RecipeID = ri.RecipeId
	join Ingredient i
	on i.IngredientID = ri.IngredientID
	left join MeasurementType mt 
	on mt.MeasurementTypeID = ri.MeasurementTypeID
	where @RecipeId = r.RecipeID
	order by ri.ingredientsequence

	return @return
end

--exec RecipeIngredientGet @recipeid = 247
