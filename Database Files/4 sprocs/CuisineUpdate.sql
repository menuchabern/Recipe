create or alter procedure dbo.CuisineUpdate(
	@CuisineId int  output,
	@Cuisine varchar (30),
	@Message varchar(500) = ''  output
	)
as
begin
	declare @return int = 0

	select @CuisineId = isnull(@CuisineId,0)
	
	if @CuisineId = 0
	begin
		insert Cuisine(Cuisine)
		values(@Cuisine)

		select @CuisineId= scope_identity()
	end
	else
	begin
		update Cuisine
		set
			Cuisine = @Cuisine
		where CuisineID = @CuisineId
	end
	
	return @return
end
go
