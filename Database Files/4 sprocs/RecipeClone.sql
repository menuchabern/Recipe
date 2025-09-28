create or alter proc dbo.RecipeClone(  
 @RecipeId int output,  
 @Message varchar(500) = ''  
)  
as  
begin  
	declare @OldRecipeId int = @Recipeid
	declare @return int 
	 
	insert Recipe(CuisineId, UserNameId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)  
	select CuisineID, UserNameId, concat(RecipeName, ' - clone'), Calories, DateDrafted, DatePublished, DateArchived  
	from recipe  
	where RecipeID = @RecipeId  
	 
	set @RecipeId = scope_identity()  
	
	insert RecipeIngredient (recipeid, IngredientID, MeasurementTypeID, MeasurementNumber, IngredientSequence)
	select @RecipeId, ri.IngredientID, ri.MeasurementTypeID, ri.MeasurementNumber, ri.IngredientSequence
	from RecipeIngredient ri
	where RecipeID = @OldRecipeId

	insert RecipeSteps (RecipeID, StepSequence, StepDirection)
	select @RecipeId, rs.StepSequence, rs.StepDirection
	from RecipeSteps rs
	where rs.RecipeID = @OldRecipeId

	return @return  
end  
  