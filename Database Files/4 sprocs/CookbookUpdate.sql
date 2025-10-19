create or alter proc dbo.CookbookUpdate(
	@cookbookid int = 0 output,
	@UserNameID int,
	@CookbookName varchar (30),
	@Price decimal(5,2),
	@ActiveStatus bit = 0,
	@Message varchar(500) = '' output 
)
as
begin
	declare @return int = 0

	select @cookbookid = isnull(@cookbookid, 0), @ActiveStatus = isnull(@activestatus, 0)

	if @cookbookid = 0
	begin
		insert Cookbook(UserNameID, CookbookName, Price, ActiveStatus, DateCreated)
		values(@UserNameID, @CookbookName, @Price, @ActiveStatus, CAST(GETDATE() AS DATE))

		select @cookbookid = SCOPE_IDENTITY()
	end

	else
	begin

	update Cookbook
	set UserNameID = @UserNameID, 
		CookbookName = @CookbookName, 
		Price = @Price, 
		ActiveStatus = @ActiveStatus
		where CookbookID = @cookbookid
	end

	return @return
end