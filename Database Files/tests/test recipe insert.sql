declare @Message varchar(500) = '', @return int, @usernameid int, @cuisineid int, @recipeid int

select top 1 @usernameid = usernameid from username
select top 1 @cuisineid = cuisineid from cuisine

exec @return = RecipeUpdate
	@RecipeID = @recipeid output,
	@CuisineID = @cuisineid,
	@UserNameID = @usernameid,
	@RecipeName = 'super',
	@Calories = 200,
	@DateDrafted = '12/07/2002',
	@DatePublished = null,
	@DateArchived = null,
	@Message = @message output

select @return, @Message, @recipeid

select * from recipe r where recipeid = @recipeid

delete recipe where recipeid = @recipeid


