create or alter procedure dbo.UserNameGet(
	@UserNameId int = 0, 
	@All bit = 0, 
	@IncludeBlank bit = 0,
	@UserName varchar(30) = '',
	@Message varchar(500) = ''
)
as 
begin
	declare @return int = 0

	select @All = isnull(@All,0), @UserNameID = isnull(@UserNameId,0), @IncludeBlank = ISNULL(@IncludeBlank, 0)

	Select UserNameID, firstname, lastname, UserName
	from username
	where @All = 1
	or usernameid = @usernameid
	or (@userName <> '' and UserName like '%' + @UserName + '%')
	union select 0, '', '', ''
	where @IncludeBlank = 1
	order by UserName

	return @return 
end
go

/*
exec UserNameGet @All = 1

exec UserNameGet @username = ''
exec usernameget @username = 'k'

declare @id int
select top 1 @id = usernameid from UserName
exec UserNameGet @usernameid = @id
*/