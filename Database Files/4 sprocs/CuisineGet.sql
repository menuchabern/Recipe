create or alter procedure dbo.CuisineGet(
	@Cuisine varchar(30) = '', 
	@All bit = 0, 
	@CuisineId int = 0,
	@IncludeBlank int = 0,
	@Message varchar(500) = ''
)
as 
begin
	declare @return int = 0

	select @All = isnull(@All,0), @CuisineId = isnull(@CuisineID,0), @IncludeBlank = ISNULL(@IncludeBlank, 0)


	select CuisineID, Cuisine
	from Cuisine
	where @all = 1
	or (@Cuisine <> '' and cuisine like '%' + @Cuisine + '%')
	or CuisineID = @CuisineId
	union select 0, ''
	where @IncludeBlank = 1
	order by Cuisine

	return @return
end
go


/*
exec CuisineGet @All = 1

exec CuisineGet @Cuisine = ''
exec CuisineGet @Cuisine = 'a'

declare @id int
select top 1 @id = cuisineid from cuisine 
exec CuisineGet @cuisineid = @id
*/