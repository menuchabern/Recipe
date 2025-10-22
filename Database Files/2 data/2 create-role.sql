use RecipeDB
go
drop role if exists reciperole
go
create role reciperole
go
alter role reciperole add member appadminrecipe_user
go