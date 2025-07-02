select * 
from recipe r 
left join CookbookRecipe cr 
on cr.RecipeID = r.RecipeID
where 
cr.CookbookRecipeID is null
and 
(r.recipestatus = 'draft' or 
DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)

select * from recipe

declare @return int
declare @Message varchar(500)
exec @return = RecipeDelete @recipeid = 132, @Message = @Message output
select @return, @Message

select * from recipe

select * 
from recipe r
left join RecipeMealCourse rmc 
on r.RecipeID = rmc.RecipeID 
left join CookbookRecipe cr 
on cr.RecipeID = r.RecipeID
where rmc.RecipeMealCourseID is null 
	and cr.CookbookRecipeID is null
	and (r.recipestatus = 'draft'
	or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)

select * from recipe r
   left join recipemealcourse rmc
   on rmc.recipeid = r.recipeid
   left join cookbookrecipe cr 
   on cr.recipeid = r.recipeid
   where rmc.recipemealcourseid is null 
       and cr.cookbookrecipeid is null
       and (r.recipestatus = 'draft'
           or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)