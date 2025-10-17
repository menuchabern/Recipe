create or alter proc dbo.CookbookAutoCreate(
	@NewCookbookId int  = 0 output,
	@UserNameId int output,
	@Message varchar(500) = '' output
)

as
begin
	declare @return int = 0
	begin try
		begin tran
			insert Cookbook(UserNameId, CookbookName, Price, ActiveStatus, DateCreated)
			select un.usernameid, 
				concat('Recipes by ', un.firstname, ' ', un.lastname),
				COUNT(distinct r.recipeid) * 1.33,
				1,
				CAST(GETDATE() AS DATE)
			from username un
			join recipe r
			on un.usernameid = r.usernameid
			join cookbookrecipe cr 
			on r.recipeid = cr.recipeid
			where un.usernameid = @usernameid
			group by un.firstname, un.lastname, un.usernameid

			select @NewCookbookId = scope_identity()
	
			insert cookbookrecipe(CookbookId, RecipeId, RecipeSequence)
			select @NewCookbookId, r.recipeid, ROW_NUMBER() OVER (ORDER BY r.recipename)
			from recipe r
			where r.UserNameID = @UserNameId
		commit
	end try 
	begin catch
		rollback;
		throw
	end catch

	return @return 
end

--exec cookbookautocreate @usernameid = 189
