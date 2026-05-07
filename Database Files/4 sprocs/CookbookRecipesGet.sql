create or alter proc dbo.CookbookRecipesGet(
	@CookbookId int output,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select r.recipeid, r.RecipeName, r.RecipeStatus, u.UserName, r.Calories, 
		count(ri.RecipeIngredientId) as NumIngredients , r.datedrafted, r.datearchived, cr.cookbookid, cr.RecipeSequence,
		r.datepublished, c.cuisine, r.usernameid, r.cuisineid, IsDeleteAllowed = dbo.IsRecipeDeleteAllowed(r.recipeid),
		CASE WHEN r.Vegan = 1 THEN 1 ELSE 0 END AS Vegan
	from recipe r 
	join username u 
	on r.usernameid = u.usernameid 
	join cuisine c 
	on c.cuisineid = r.cuisineid 
	left join RecipeIngredient ri
	on ri.RecipeId = r.RecipeID
	left join cookbookrecipe cr
	on r.recipeid = cr.recipeid
	where cr.cookbookid = @CookbookId
	group by r.recipeid, r.recipename, r.recipestatus, u.username, r.calories,  r.datedrafted, r.datearchived, r.datepublished, c.cuisine, r.usernameid, r.cuisineid, r.vegan, cr.cookbookid, cr.RecipeSequence
	order by cr.RecipeSequence

	return @return
end

--exec CookbookRecipesGet @cookbookid = 22
