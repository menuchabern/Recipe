create or alter proc dbo.RecipeClone(  
 @RecipeId int output,  
 @Message varchar(500) = ''  
)  
as  
begin  
 declare @return int  
  
 insert Recipe(CuisineId, UserNameId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)  
 select CuisineID, UserNameId, concat(RecipeName, ' - clone'), Calories, DateDrafted, DatePublished, DateArchived  
 from recipe  
 where RecipeID = @RecipeId  
  
 set @RecipeId = scope_identity()  
  
 return @return  
end  
  