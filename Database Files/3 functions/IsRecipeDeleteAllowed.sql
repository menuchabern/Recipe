create or alter function dbo.IsRecipeDeleteAllowed(@recipeid int)
returns varchar(100)
as
begin
	declare @value varchar(100) = ''
		if exists(select * from recipe r where (r.recipeid = @Recipeid) and (r.recipestatus <> 'draft' and (r.datearchived is null or DATEDIFF(DAY, r.datearchived, GETDATE()) < 30)))
		begin
			select @value = 'Can only delete a recipe that is archived for over 30 days or is currently drafted'
		end
	return @value
end
go