create or alter function dbo.RecipeDesc(@Recipeid int)
returns varchar(105)
as
begin
	declare @value varchar(105)
	select @value = concat(r.RecipeName, ' (', c.Cuisine, ') has ', count(distinct ri.IngredientID), ' ingredients and ', count(distinct rs.recipestepsid), ' steps')
	from recipe r
	join cuisine c 
	on c.CuisineID = r.CuisineID
	join RecipeIngredient ri
	on r.recipeid = ri.recipeid
	join RecipeSteps rs
	on r.RecipeID = rs.RecipeID
	where r.RecipeID = @Recipeid
	group by r.Recipename, c.Cuisine
	
	return @value
end
go

select recipedesc = dbo.recipedesc(r.recipeid), *
from recipe r
go