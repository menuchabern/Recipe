create or alter procedure dbo.CuisineGet(@Cuisine varchar(30) = '', @All bit = 0, @CuisineId int = 0)
as 
begin
	select CuisineID, Cuisine
	from Cuisine
	where @all = 1
	or (@Cuisine <> '' and cuisine like '%' + @Cuisine + '%')
	or CuisineID = @CuisineId
	order by Cuisine
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