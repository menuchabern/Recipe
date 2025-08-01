create or alter procedure dbo.RecipeGet(
	@All bit = 0,
	@RecipeName varchar(40)= '',
	@RecipeID int = 0
)
as 
begin
	select r.recipeid, r.cuisineid, r.usernameid, r.recipename, u.username, r.calories, r.recipestatus, r.datedrafted, r.datearchived, r.datepublished, c.cuisine,
		RecipeDesc = dbo.RecipeDesc(r.recipeid)
	from recipe r 
	join username u 
	on r.usernameid = u.usernameid 
	join cuisine c 
	on c.cuisineid = r.cuisineid 
	where @All = 1
	or (@recipeName <> '' and r.recipeName like '%' + @recipeName + '%')
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