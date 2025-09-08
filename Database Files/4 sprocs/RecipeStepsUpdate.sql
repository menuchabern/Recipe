create or alter procedure dbo.RecipeStepsUpdate(
	--@RecipeID int = 0,
	@RecipeStepsID int = 0 output,
	@StepSequence int = 0,
	@StepDirection varchar(250) = '',
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @RecipeStepsID = isnull(@RecipeStepsID,0)

	if @RecipeStepsID = 0
	begin
		insert RecipeSteps(RecipeID, StepSequence, StepDirection)
		values(@RecipeID, @StepSequence, @StepDirection)

		select @RecipeStepsID= scope_identity()
	end
	else
	begin
		update RecipeSteps
		set
			RecipeID = @RecipeID, 
			StepSequence = @StepSequence,
			StepDirection = @StepDirection
		where RecipeStepsID = @RecipeStepsID
	end

	return @return
end
go