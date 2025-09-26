create or alter proc dbo.CookbookGet(
	@All int = 0,
	@CookbookId int = 0,
	@IncludeBlank int = 0,
	@UserNameid int = 0,
	@CookbookName varchar(50) = '' output,
	@Message varchar(500)  = '' output
)
as
begin
	declare @return int = 0

	select @All = isnull(@all, 0), @Cookbookid = isnull(@Cookbookid, 0)

	declare @FullUserName varchar(100)
	if @UserNameid > 0
	begin
		select @FullUserName = concat(FirstName,' ', LastName)
		from UserName
	end

	select c.CookbookName, us.UserName, NumRecipes = count(r.recipeid), c.Price, c.cookbookid, c.usernameid, c.datecreated, c.activestatus
	from cookbook c
	join username us
	on us.usernameid = c.usernameid
	left join cookbookrecipe cr 
	on cr.cookbookid = c.cookbookid
	left join recipe r
	on r.recipeid = cr.recipeid
	where @all = 1
	or c.cookbookid = @cookbookid
	or c.CookbookName = @CookbookName
	or c.CookbookName like '%' + @FullUserName
	group by c.cookbookname, us.username, c.price, c.cookbookid, c.usernameid, c.datecreated, c.activestatus
	order by c.cookbookname

	
	return @return
end

