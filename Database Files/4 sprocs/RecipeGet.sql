create or alter procedure dbo.RecipeGet(
	@All bit = 0,
	@RecipeName varchar(40)= '',
	@IncludeBlank int = 0,
	@RecipeID int = 0
)
as 
begin
	select r.recipeid, r.RecipeName, r.RecipeStatus, u.UserName, r.Calories, count(*) as NumIngredients , r.datedrafted, r.datearchived, r.datepublished, c.cuisine, r.usernameid, r.cuisineid
	from recipe r 
	join username u 
	on r.usernameid = u.usernameid 
	join cuisine c 
	on c.cuisineid = r.cuisineid 
	left join RecipeIngredient ri
	on ri.RecipeId = r.RecipeID
	where @All = 1
	or (@recipeName <> '' and r.recipeName like '%' + @recipeName + '%')
	or r.RecipeID = @RecipeID
	group by r.recipeid, r.recipename, r.recipestatus, u.username, r.calories,  r.datedrafted, r.datearchived, r.datepublished, c.cuisine, r.usernameid, r.cuisineid
	union select 0, '', '', '', 0, 0, 0, 0, 0, '', 0, 0
	where @includeblank = 1
	order by recipename 

	select * 
	from recipe
	where @RecipeID = RecipeID

end

/*
exec RecipeGet @All = 1

exec RecipeGet @RecipeName = 'ch'
exec RecipeGet @RecipeName = ''

declare @id int
select top 1 @id = recipeid from Recipe
exec RecipeGet @RecipeID = @id 
*/
