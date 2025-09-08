create or alter proc dbo.RecipeStepsGet(
	@RecipeId int = 0,
	@Message varchar(500) = ''
)
as 
begin
	declare @return int = 0

	select rs.StepDirection, rs.StepSequence, r.RecipeID, rs.RecipeStepsID
	from recipe r 
	join RecipeSteps rs
	on r.RecipeID = rs.RecipeID
	where r.RecipeID = @RecipeId
	order by rs.StepSequence

	return @return
end