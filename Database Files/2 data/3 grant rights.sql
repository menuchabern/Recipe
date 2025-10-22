use RecipeDB 
go

--select concat('grant execute on ', r.ROUTINE_NAME, ' to reciperole')
--from INFORMATION_SCHEMA.ROUTINES r

grant execute on RecipeIngredientsUpdate to reciperole
grant execute on RecipeStepsDelete to reciperole
grant execute on RecipeIngredientDelete to reciperole
grant execute on RecipeDatesUpdate to reciperole
grant execute on RecipeClone to reciperole
grant execute on MealGet to reciperole
grant execute on CookbookGet to reciperole
grant execute on CookbookRecipesGet to reciperole
grant execute on CookbookUpdate to reciperole
grant execute on CookbookDelete to reciperole
grant execute on CookbookRecipeDelete to reciperole
grant execute on CookbookRecipeUpdate to reciperole
grant execute on CookbookAutoCreate to reciperole
grant execute on CuisineUpdate to reciperole
grant execute on IngredientUpdate to reciperole
grant execute on UserNameUpdate to reciperole
grant execute on CuisineDelete to reciperole
grant execute on IngredientDelete to reciperole
grant execute on UserNameDelete to reciperole
grant execute on MeasurementTypeGet to reciperole
grant execute on MeasurementTypeDelete to reciperole
grant execute on MeasurementTypeUpdate to reciperole
grant execute on CourseTypeGet to reciperole
grant execute on CourseTypeDelete to reciperole
grant execute on CourseTypeUpdate to reciperole
grant execute on IsRecipeDeleteAllowed to reciperole
grant execute on RecipeDelete to reciperole
grant execute on CuisineGet to reciperole
grant execute on RecipeUpdate to reciperole
grant execute on CaloriesPerMeal to reciperole
grant execute on RecipeDesc to reciperole
grant execute on UserNameGet to reciperole
grant execute on RecipeGet to reciperole
grant execute on DashboardGet to reciperole
grant execute on IngredientGet to reciperole
grant execute on RecipeStepsGet to reciperole
grant execute on RecipeIngredientsGet to reciperole
grant execute on RecipeStepsUpdate to reciperole