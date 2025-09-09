create or alter proc dbo.RecipeDatesUpdate(
	@recipeid int,
	@DateDrafted date = null output,
	@DatePublished date = null output,
	@DateArchived date = null output,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	declare @CurrentDateDrafted date, @CurrentDatePublished date,  @CurrentDateArchived date
	select @CurrentDateDrafted = datedrafted, @CurrentDatePublished = datepublished, @CurrentDateArchived = datearchived 
	from recipe
	where RecipeID = @recipeid

	select @dateDrafted = isnull(@datedrafted, @currentdatedrafted), @DatePublished = isnull(@datepublished, @currentdatepublished), @DateArchived = isnull(@datearchived, @currentdatearchived)

	update recipe
	set datedrafted = @DateDrafted, DatePublished = @DatePublished, DateArchived = @DateArchived
	where recipeid = @recipeid
	
	return @return
end