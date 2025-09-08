using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipe()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipeget");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable LoadRecipe(int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipeget");
            SQLUtility.SetParamValue(cmd, "@Recipeid", recipeid);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void Save(DataTable dtrecipe)
        {
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Cannot save because there are no rows in the table");
            }

            DataRow r = dtrecipe.Rows[0];
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["Recipeid"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipedelete");
            SQLUtility.SetParamValue(cmd, "@recipeid", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static DataTable GetUserNameList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UserNameGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
    }
}
