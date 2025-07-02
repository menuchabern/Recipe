create or alter procedure dbo.RecipeDelete(
	@RecipeID int,
	@Message varchar(500)= '' output
)
as 
begin
	declare @return int = 0
	if exists(select * from recipe r where (r.recipeid = @Recipeid) and not (r.recipestatus = 'draft' or DATEDIFF(DAY, r.datearchived, GETDATE()) < 30))
	begin
		select @return = 1, @Message = 'Can only delete a recipe that is archived for over 30 days or is currently drafted'
		goto finished
	end

	begin try
		begin tran
			delete RecipeSteps where Recipeid = @RecipeID
			delete RecipeIngredient where recipeid = @RecipeID
			delete recipe where recipeid = @RecipeID
		commit
	end try 
	begin catch
		rollback;
		throw
	end catch

	finished:
	return @return
end
go