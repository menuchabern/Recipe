create or alter procedure dbo.MeasurementUpdate(
	@MeasurementId int  output,
	@MeasurementType varchar (30),
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @MeasurementId = isnull(@MeasurementId,0)
	
	if @MeasurementId = 0
	begin
		insert MeasurementType(MeasurementType)
		values(@MeasurementType)

		select @MeasurementId= scope_identity()
	end
	else
	begin
		update MeasurementType
		set
			MeasurementType = @MeasurementType
		where MeasurementTypeID = @MeasurementId
	end
	
	return @return
end
go

