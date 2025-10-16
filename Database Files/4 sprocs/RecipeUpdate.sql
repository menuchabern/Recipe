create or alter procedure dbo.RecipeUpdate(
	@RecipeID int = 0 output,
	@CuisineID int,
	@UserNameID int,
	@RecipeName varchar (40),
	@Calories int,
	@DateDrafted date null output,
	@DatePublished date null output,
	@DateArchived date null output,
	@RecipeStatus varchar(25) null output,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0

	select @RecipeId = isnull(@recipeid, 0)

	if @recipeid = 0
	begin
		if @datedrafted is null
		begin
			select @datedrafted = CAST(GETDATE() AS DATE);
		end
		insert Recipe(CuisineID, UserNameID, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)
		values (@CuisineID, @UserNameID, @RecipeName, @Calories, @datedrafted, @DatePublished, @DateArchived)

		select @recipeid = scope_identity()
	end

	else
	begin

		update Recipe
		set 
		CuisineID   = @CuisineID, 
		UserNameID  = @UserNameID, 
		RecipeName  = @RecipeName, 
		Calories    = @Calories, 
		DateDrafted = coalesce(@DateDrafted, DateDrafted), 
		DatePublished = coalesce(@DatePublished, DatePublished), 
		DateArchived  = coalesce(@DateArchived, DateArchived)
		where RecipeId = @recipeid;

		select @RecipeStatus recipestatus from Recipe where RecipeID = @RecipeID

	end
	return @return
end
go

