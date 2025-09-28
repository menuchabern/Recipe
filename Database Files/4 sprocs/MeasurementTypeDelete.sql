create or alter procedure dbo.MeasurementTypeDelete(
	@MeasurementTypeId int = 0,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @MeasurementTypeId = isnull(@MeasurementTypeId,0)

	delete RecipeIngredient where MeasurementTypeId = @MeasurementTypeId
	delete MeasurementType where MeasurementTypeId = @MeasurementTypeId

	return @return
end
go

select * from RecipeIngredient