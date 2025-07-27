create or alter procedure dbo.RecipeUpdate(
	@RecipeID int output,
	@CuisineID int,
	@UserNameID int,
	@RecipeName varchar (40),
	@Calories int,
	@DateDrafted datetime,
	@DatePublished datetime,
	@DateArchived datetime,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0
	select @RecipeId = isnull(@recipeid, 0), @datedrafted = isnull(@datedrafted, 0)

	if @recipeid = 0
	begin
		if @datedrafted = 0
		begin
			select @datedrafted = current_timestamp
		end
		insert Recipe(CuisineID, UserNameID, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
		values (@CuisineID, @UserNameID, @RecipeName, @Calories, @DateDrafted, @DatePublished, @DateArchived)

		select @recipeid = scope_identity()
	end
	else
	begin
		update Recipe
		set 
		CuisineID = @CuisineID, 
		UserNameID = @UserNameID, 
		RecipeName = @RecipeName, 
		Calories = @Calories, 
		DateDrafted = @DateDrafted, 
		DatePublished = @DatePublished, 
		DateArchived = @DateArchived
		where RecipeId = @recipeid
	end
	return @return
end
go

