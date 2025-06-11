create or alter procedure dbo.CuisineGet(@CuisineType varchar(30) = '', @All bit = 0, @CuisineId int = 0)
as 
begin
	select @CuisineType = nullif(@cuisinetype, '')
	select CuisineID, CuisineType
	from Cuisine
	where @all = 1
	or CuisineType like '%' + @cuisinetype + '%'
	or CuisineID = @CuisineId
	order by CuisineType
end
go

/*
exec CuisineGet @All = 1

exec CuisineGet @CuisineType = ''
exec CuisineGet @CuisineType = 'a'

declare @id int
select top 1 @id = cuisineid from cuisine 
exec CuisineGet @cuisineid = @id
*/