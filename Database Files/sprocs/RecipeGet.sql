create or alter procedure dbo.RecipeGet(
	@All bit = 0,
	@RecipeName varchar(40)= '',
	@RecipeID int = 0
)
as 
begin
	select @RecipeName = nullif(@recipename, '') 
	select CuisineID, RecipeID, RecipeName, Calories, PictureName, DateDrafted, DatePublished, DateArchived, RecipeStatus
	from Recipe 
	where @All = 1
	or RecipeName like '%' + @RecipeName + '%'
	or RecipeID = @RecipeID
end
go

/*
exec RecipeGet @All = 1

exec RecipeGet @RecipeName = 'ch'
exec RecipeGet @RecipeName = ''

declare @id int
select top 1 @id = recipeid from Recipe
exec RecipeGet @RecipeID = @id
*/