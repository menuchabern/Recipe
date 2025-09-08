create or alter proc dbo.IngredientGet(
	@All int = 0,
	@IncludeBlank int = 0,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select *
	from Ingredient
	where @All = 1
	union select 0, '', ''
	where @IncludeBlank = 1
	order by IngredientName
	
	return @return
end

--exec IngredientGet @All = 1