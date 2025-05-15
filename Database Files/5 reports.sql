--AS Great job!
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
                             --Meals     |4
                             --Cookbooks |4
select Type = 'Recipes', Count = count(r.RecipeID)
from recipe r 
union select 'Meal', count(m.MealID)
from meal m 
union select 'Cookbook', count(c.Cookbookid)
from Cookbook c 

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. Archived recipes should appear gray on the website.
	In order for the recipe name to be gray on the website, surround the archived recipe names with: <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
;with x as (
    select r.RecipeID, NumOfIngredients = count(ri.IngredientID)
    from Recipe r 
    join RecipeIngredient ri 
    on r.RecipeID = ri.RecipeId
    group by r.RecipeID
)
select distinct RecipeName = case when r.datearchived is not null then concat('<span style="color:gray">', r.RecipeName, '</span>') else r.RecipeName end,
    r.RecipeStatus,
    DatePublished = isnull(convert(date, r.DatePublished, 101), ' '), 
    DateArchived = isnull(convert(date, r.DateArchived, 101), ' '), 
    r.PictureName, un.UserName, r.Calories, x.NumOfIngredients
from recipe r 
join UserName un 
on un.UserNameID = r.UserNameID
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeID
join x 
on r.RecipeID = x.RecipeID
where r.RecipeStatus <> 'Draft'
order by datearchived 

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
select r.RecipeName, r.Calories, NumberOfIngredients = count( distinct ri.IngredientID), NumOfSteps = count( distinct rs.StepSequence), r.PictureName
from recipe r 
join recipeingredient ri 
on r.RecipeID = ri.recipeid 
join RecipeSteps rs 
on r.RecipeID = rs.RecipeID
where r.recipename = 'Apple Yogurt Smoothie'
group by r.recipeName, r.Calories, r.PictureName

select concat(ri.MeasurementNumber, ' ', mt.MeasurementType, ' ', i.IngredientName)
from Recipe r 
join recipeingredient ri 
on r.RecipeID = ri.RecipeID
join Ingredient i 
on i.IngredientID = ri.ingredientid 
left join MeasurementType mt 
on mt.MeasurementTypeID = ri.measurementtypeid
where r.RecipeName = 'apple yogurt smoothie'
order by ri.ingredientsequence

select rs.StepDirection 
from Recipe r 
join RecipeSteps rs 
on r.RecipeID = rs.RecipeID
where r.RecipeName = 'apple yogurt smoothie'
order by rs.StepSequence

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.mealname, un.UserName, AmntOfCalories = sum(r.Calories), NumOfCourses = count( distinct mc.CourseTypeID), NumOfRecipes = count(distinct r.RecipeID)
from Meal m 
join UserName un 
on un.UserNameID = m.UserNameID
join MealCourse mc 
on m.MealID = mc.MealID
join recipemealcourse rmc 
on mc.MealCourseID = rmc.mealcourseid 
join Recipe r 
on r.RecipeID = rmc.recipeid 
where m.activestatus = 1 
group by m.MealName, un.username
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select m.MealName, un.UserName, m.DateCreated, m.PictureName
from meal m 
join UserName un 
on un.UserNameId = m.UserNameID
where m.MealName = 'Breakfast Bash'

select ListOfRecipes = case when ct.CourseName = 'Main Course' then 
            case when rmc.MainDish = 1 then concat('<b>', 'Main Course: Main Dish- ',  r.RecipeName, '</b>') 
            when rmc.maindish = 0 then concat('Main Course: Side Dish - ', r.RecipeName) end 
        else concat(ct.CourseName, ': ', r.RecipeName) end 
from meal m 
join MealCourse mc 
on m.MealID = mc.MealID
join recipemealcourse rmc 
on mc.MealCourseID = rmc.MealCourseID
join recipe r 
on r.RecipeID = rmc.RecipeID
join CourseType ct 
on ct.CourseTypeID = mc.CourseTypeID
where m.MealName = 'Breakfast Bash'

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, c.PictureName, un.UserName, NumOfRecipes = count(cr.RecipeID)
from Cookbook c 
join cookbookrecipe cr 
on c.CookbookID = cr.CookbookID
join UserName un 
on un.UserNameID = c.UserNameID
where c.ActiveStatus = 1 
group by c.CookbookName, c.PictureName, un.UserName
order by c.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
select c.CookbookName, un.UserName, c.DateCreated, c.Price, c.PictureName, NumOfRecipes = count(cr.RecipeID)
from Cookbook c 
join UserName un 
on un.UserNameID = c.UserNameID
join CookbookRecipe cr 
on cr.CookbookID = c.CookbookID
where c.CookbookName = 'Healthy Habits'
group by c.CookbookName, un.UserName, c.DateCreated, c.Price, c.PictureName

select r.RecipeName, ci.CuisineType, NumOfIngredients = count( distinct ri.ingredientid), NumOfSteps = count( distinct rs.RecipeStepsID)
from Cookbook c 
join CookbookRecipe cr 
on cr.CookbookID = c.CookbookID
join Recipe r 
on r.RecipeID = cr.recipeid
join Cuisine ci 
on ci.CuisineID = r.CuisineID 
join recipeingredient ri 
on ri.RecipeID = r.RecipeID
join RecipeSteps rs 
on rs.RecipeID = r.RecipeID
where c.CookbookName = 'Healthy Habits'
group by r.RecipeName, ci.CuisineType, cr.recipesequence
order by cr.recipesequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
;with x as(
    select JokeRecipe = concat(upper(SUBSTRING(reverse(r.RecipeName),1 , 1)), 
        lower(substring(reverse(r.RecipeName), 2, len(REVERSE(r.RecipeName))-1)))
    from Recipe r 
)
select x.JokeRecipe, JokePicture = concat('Recipe_', replace(x.JokeRecipe, ' ', '_'), '.jpg')
from x 

;with x as (
    select r.RecipeName, SequenceNumber = max(rs.StepSequence)
    from recipesteps rs 
    join Recipe r 
    on r.RecipeID = rs.RecipeID
    group by r.recipeName
)
select distinct r.RecipeName, rs.StepDirection
from x 
join Recipe r 
on r.RecipeName = x.RecipeName
left join RecipeSteps rs 
on r.RecipeID = rs.RecipeID and x.SequenceNumber = rs.StepSequence

/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
select un.UserName, r.RecipeStatus, NumOfRecipes = count(distinct r.RecipeStatus)
from UserName un 
left join Recipe r 
on un.UserNameID = r.UserNameID
group by un.UserName, r.RecipeStatus
order by un.UserName

select un.UserName, NumOfRecipes = count(r.RecipeID), AvgDaysInDraft= avg(DATEDIFF(day, r.DateDrafted, r.DatePublished))
from Recipe r 
join UserName un 
on un.UserNameID = r.UserNameID
group by un.UserName

select un.UserName, TotalMeals = count(m.MealID), 
    TotalActiveMeals = sum(case when m.ActiveStatus = 1 then 1 else 0 end),
    TotalInactiveMeals = sum(case when m.ActiveStatus = 0 then 1 else 0 end)
from UserName un 
join meal m 
on m.UserNameID = un.UserNameID
group by un.UserName

select un.UserName, TotalCoookbooks = count(c.CookbookID), 
    TotalActivCookbooks = sum(case when c.ActiveStatus = 1 then 1 else 0 end),
    TotalInactiveCookbooks = sum(case when c.ActiveStatus = 0 then 1 else 0 end)
from UserName un 
join cookbook c 
on c.UserNameID = un.UserNameID
group by un.UserName

select r.RecipeName, DaysInDraft = DATEDIFF(day, r.DateDrafted, r.DateArchived) 
from Recipe r 
where r.DatePublished is null and r.DateArchived is not null
/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
    
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
;with x as (
    select UserNameID = un.usernameid, un.username
    from UserName un 
    where un.UserName = 'mak'
)
select UserName = x.UserName, CategoryName = 'Recipe', Count = count(r.RecipeID)
from x 
join Recipe r 
on r.UserNameID = x.UserNameID
group by x.UserName
union select x.username, 'Meal', count(m.MealID)
from x 
join meal m 
on m.UserNameID = x.UserNameID
group by x.UserName
union select x.username, 'Cookbook', count(c.cookbookid)
from x 
join  cookbook c 
on c.UserNameID = x.UserNameID
group by x.UserName

select r.RecipeName, 
    r.RecipeStatus,
    HoursInPreviousStatus = case when r.DateArchived is null then DATEDIFF(hour, r.DateDrafted, r.DatePublished) 
        else DATEDIFF(hour, isnull(r.DatePublished, r.DateDrafted), r.DateArchived) end 
from UserName un 
join Recipe r 
on r.UserNameID = un.UserNameID
where un.UserName = 'Mak' and r.RecipeStatus in ('Published', 'Archived')

