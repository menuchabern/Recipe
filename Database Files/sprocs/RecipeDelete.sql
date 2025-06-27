create or alter procedure dbo.RecipeDelete(
	@RecipeID int
)
as 
begin
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
end
go