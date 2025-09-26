create or alter procedure dbo.CourseUpdate(
	@CourseId int  output,
	@CourseName varchar (30),
	@CourseSequence int,
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @CourseId = isnull(@CourseId,0)
	
	if @CourseId = 0
	begin
		insert CourseType(CourseName, CourseSequence)
		select @CourseName, @CourseSequence
		from CourseType

		select @CourseId= scope_identity()
	end
	else
	begin
		update CourseType
		set
			CourseName = @CourseName,
			CourseSequence = @CourseSequence
		where CourseTypeID = @CourseId
	end
	
	return @return
end
go
