create or alter procedure dbo.UserNameUpdate(
	@UserNameId int  output,
	@UserName varchar (30),
	@FirstName varchar(25),
	@LastName varchar (30),
	@Message varchar(500) = ''  output
)
as
begin
	declare @return int = 0

	select @UserNameId = isnull(@UserNameId,0)
	
	if @UserNameId = 0
	begin
		insert UserName(UserName, FirstName, LastName)
		values(@UserName, @FirstName, @LastName)

		select @UserNameId = scope_identity()
	end
	else
	begin
		update UserName
		set
			UserName = @UserName,
			FirstName = @FirstName, 
			LastName = @LastName
		where UserNameID = @UserNameId
	end
	
	return @return
end
go
