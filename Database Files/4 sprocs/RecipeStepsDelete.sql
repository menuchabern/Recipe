create or alter proc dbo.RecipeStepsDelete(
	@RecipeStepsID int,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0

	select @RecipeStepsID = ISNULL(@recipestepsid, 0)

	delete RecipeSteps
	where RecipeStepsid = @RecipeStepsID

	return @return
end