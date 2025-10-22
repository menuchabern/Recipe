script to create login and user is exluded from this reop.
Create a file called create-login.sql (this file is ignored by git ignore in this repo)
add the following to that file

--IMPORTANT create log in in MASTER
create LOGIN [login name] with PASSWORD = '[password]'

--switch to recipedb 
create user [username] from login [login name]