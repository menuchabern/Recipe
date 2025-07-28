create or alter function dbo.CaloriesPerMeal(@MealId int)
returns int
as
begin
	declare @value int
	select @value = sum(r.calories)
	from recipemealcourse rmc
	join recipe r 
	on r.recipeid = rmc.recipeid
	join mealcourse mc
	on mc.mealcourseid = rmc.mealcourseid
	where mc.mealid = @MealId
	group by rmc.mealcourseid
	return @value
end
go

select TotalAmntOfCalories = dbo.caloriespermeal(mealid), *
from meal
