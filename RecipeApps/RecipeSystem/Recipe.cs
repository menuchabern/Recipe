using System.Data;
using System.Diagnostics;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipe(string recipename)
        {
            string sql = "select r.RecipeID, r.RecipeName, UserName = u.FirstName + ' ' + u.LastName, r.Calories, r.RecipeStatus from Recipe r join UserName u on u.UserNameID = r.UserNameID where r.recipename like '%" + recipename + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        public static DataTable LoadRecipe(int recipeid)
        {
            string sql = "select r.recipeid, r.cuisineid, r.usernameid, r.recipename, u.username, r.calories, r.recipestatus, r.datedrafted, r.datearchived, r.datepublished, c.cuisine "
                + "from recipe r join username u on r.usernameid = u.usernameid join cuisine c on c.cuisineid = r.cuisineid where r.recipeid = "
                + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
        }

        public static void Save(DataTable dtrecipe)
        {
            DataRow r = dtrecipe.Rows[0];
            int recipeid = (int)r["recipeid"];
            string sql;
            if (recipeid > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set ",
                    $"UserNameID = '{r["UserNameID"]}',",
                    $"CuisineID = '{r["CuisineID"]}',",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"Calories = '{r["Calories"]}',",
                    $"DateDrafted = '{r["DateDrafted"]}'",
                    $"where recipeid = {r["recipeid"]}"
                    );
            }
            else
            {
                sql = "insert recipe(UserNameID, CuisineID, RecipeName, Calories, DateDrafted)";
                sql += $"select '{r["usernameid"]}', '{r["cuisineid"]}','{r["recipename"]}','{r["calories"]}','{r["datedrafted"]}'";
                Debug.Print(sql);
            }
            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtrecipe)
        {
            DataRow r = dtrecipe.Rows[0];
            string sql = "delete recipe where recipeid = " + r["recipeid"].ToString();
            SQLUtility.ExecuteSQL(sql);
        }

        public static DataTable GetUserNameList()
        {
            return SQLUtility.GetDataTable("select UserNameID, UserName from UserName");
        }

        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select CuisineID, Cuisine from Cuisine");
        }
    }
}
