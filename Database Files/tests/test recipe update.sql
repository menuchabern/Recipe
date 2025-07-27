declare @Message varchar(500) = '', @return int, @partyid int, @num int, @RecipeID int,
	@CuisineID int,
	@UserNameID int,
	@RecipeName varchar(40),
	@Calories int,
	@DateDrafted datetime,
	@DatePublished datetime,
	@DateArchived datetime

select top 1 
	@recipeid = recipeid,
	@CuisineID = CuisineID, 
	@UserNameID = UserNameID, 
	@RecipeName = RecipeName, 
	@Calories = Calories, 
	@DateDrafted = DateDrafted, 
	@DatePublished = DatePublished, 
	@DateArchived = DateArchived
from recipe r 

select @recipeName = REVERSE(@recipename)

exec @return = RecipeUpdate
@recipeid = @recipeid output,
@CuisineID = @CuisineID, 
@UserNameID = @UserNameID, 
@RecipeName = @RecipeName, 
@Calories = @Calories, 
@DateDrafted = @DateDrafted, 
@DatePublished = @DatePublished, 
@DateArchived = @DateArchived, 
@Message = @Message output

select @return, @Message, @recipeid

select * from recipe r where recipeid = @recipeid
