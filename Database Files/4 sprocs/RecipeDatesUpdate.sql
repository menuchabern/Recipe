create or alter proc dbo.RecipeDatesUpdate(
	@recipeid int,
	@RecipeStatus varchar(25) null,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0
	
            if @RecipeStatus = 'Drafted'
            begin
				update recipe 
                set 
					DateDrafted = cast(getdate() as date),
					DatePublished = null,
					DateArchived = null
					where recipeid = @recipeid
            end

            else if @RecipeStatus = 'Published'
            begin
				update recipe 
                set 
					DatePublished = cast(getdate() as date),
					DateArchived = null
					where recipeid = @recipeid
				end

            else if @RecipeStatus = 'Archived'
            begin
				update recipe 
                set DateArchived = cast(getdate() as date)
				where Recipeid = @recipeid
            end

	return @return
end
go