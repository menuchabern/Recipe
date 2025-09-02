create or alter procedure dbo.RecipeGet(
	@All bit = 0,
	@RecipeName varchar(40)= '',
	@RecipeID int = 0
)
as 
begin
	select r.recipeid, r.RecipeName, r.RecipeStatus, u.UserName, r.Calories, count(*) as NumIngredients , r.datedrafted, r.datearchived, r.datepublished, c.cuisine
	from recipe r 
	join username u 
	on r.usernameid = u.usernameid 
	join cuisine c 
	on c.cuisineid = r.cuisineid 
	join RecipeIngredient ri
	on ri.RecipeId = r.RecipeID
	where @All = 1
	or (@recipeName <> '' and r.recipeName like '%' + @recipeName + '%')
	or r.RecipeID = @RecipeID
	group by r.recipeid, r.recipename, r.recipestatus, u.username, r.calories,  r.datedrafted, r.datearchived, r.datepublished, c.cuisine
	order by RecipeStatus desc

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