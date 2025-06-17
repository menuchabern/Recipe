using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipe(string recipename)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipeget");
            cmd.Parameters["@RecipeName"].Value = recipename;
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable LoadRecipe(int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipeget");
            cmd.Parameters["@Recipeid"].Value = recipeid;
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return SQLUtility.GetDataTable(cmd);
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
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UserNameGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
    }
}
