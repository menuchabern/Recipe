create or alter proc dbo.CookbookGet(
	@All int = 0,
	@CookbookId int = 0,
	@Message varchar(500)  = '' output
)
as
begin
	declare @return int = 0

	select @All = isnull(@all, 0), @Cookbookid = isnull(@Cookbookid, 0)

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
	group by c.cookbookname, us.username, c.price, c.cookbookid, c.usernameid, c.datecreated, c.activestatus
	order by c.cookbookname


	return @return
end

