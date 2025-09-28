create or alter proc dbo.CourseTypeGet(
	@All int = 0,
	@IncludeBlank int = 0,
	@Message varchar(500) = ''
)
as
begin
	declare @return int = 0

	select *
	from CourseType
	where @All = 1
	union select 0, '', 0
	where @IncludeBlank = 1
	order by CourseSequence
	
	return @return
end

--exec courseget @all = 1