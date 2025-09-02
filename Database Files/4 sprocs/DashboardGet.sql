create or alter proc dbo.DashboardGet(
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select 'Type' = 'Recipes', Number = count(*)
	from recipe r
	union select 'Meals', count(*)
	from meal 
	union select 'Cookbooks', count(*)
	from cookbook

	return @return
end

--exec DashboardGet