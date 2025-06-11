create or alter procedure dbo.UserNameGet(@UserNameId int = 0, @All bit = 0, @UserName varchar(30) = '')
as 
begin
	select @username = nullif(@username, '')
	Select UserNameID, firstname, lastname, username
	from username
	where @All = 1
	or usernameid = @usernameid
	or username like '%' + @UserName + '%'
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