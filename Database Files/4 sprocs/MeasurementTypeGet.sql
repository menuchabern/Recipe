create or alter proc dbo.MeasurementTypeGet(
	@All int = 0,
	@IncludeBlank int = 0,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select *
	from measurementtype
	where @All = 1
	union select 0, ''
	where @IncludeBlank = 1
	order by measurementtype
	
	return @return
end

--exec MeasurementGet @all = 1