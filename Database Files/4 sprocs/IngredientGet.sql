create or alter proc dbo.IngredientGet(
	@All int = 0,
	@IngredientName varchar(50) = '',
	@IncludeBlank int = 0,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select *
	from Ingredient i
	where @All = 1
	or (@IngredientName <> '' and i.IngredientName like '%' + @ingredientname + '%')
	union select 0, '', ''
	where @IncludeBlank = 1
	order by i.IngredientName
	
	return @return
end

--exec IngredientGet @All = 1