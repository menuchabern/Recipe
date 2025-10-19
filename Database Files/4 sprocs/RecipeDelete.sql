create or alter procedure dbo.RecipeDelete(
	@RecipeID int,
	@Message varchar(500)= '' output
)
as 
begin
	declare @return int = 0, @deleteallowed varchar(100) = ''

	select @deleteallowed = isnull(dbo.isrecipedeleteallowed(@recipeid), '')
		if @deleteallowed <> ''
		begin
			select @return = 1, @Message = @deleteallowed
			goto finished
		end

	begin try
		begin tran
			delete CookbookRecipe where RecipeID = @RecipeID
			delete RecipeMealCourse where RecipeID = @RecipeID
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