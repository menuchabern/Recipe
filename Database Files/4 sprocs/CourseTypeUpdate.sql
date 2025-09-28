create or alter procedure dbo.CourseTypeUpdate(
	@CourseTypeId int  output,
	@CourseName varchar (30),
	@CourseSequence int,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @CourseTypeId = isnull(@CourseTypeId,0)
	
	if @CourseTypeId = 0
	begin
		insert CourseType(CourseName, CourseSequence)
		select @CourseName, @CourseSequence

		select @CourseTypeId= scope_identity()
	end
	else
	begin
		update CourseType
		set
			CourseName = @CourseName,
			CourseSequence = @CourseSequence
		where CourseTypeID = @CourseTypeId
	end
	
	return @return
end
go
