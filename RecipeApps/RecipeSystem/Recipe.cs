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
            if (dtrecipe.Rows.Count == 0)
            {
                throw new Exception("Cannot save because there are no rows in the table");
            }
            DataRow r = dtrecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }

        public static void SaveTab(DataTable dt, int recipeid, string sprocname)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["recipeId"] = recipeid;
            }
            SQLUtility.SaveDataTable(dt, sprocname);
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["Recipeid"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("recipedelete");
            SQLUtility.SetParamValue(cmd, "@recipeid", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        

        public static DataTable LoadRecipeTabs(int recipeid, string sprocname)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand(sprocname);
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void DeleteTab(int id, string sprocname, string param)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(sprocname);
            cmd.Parameters[param].Value = id;
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void UpdateRecipeStatus(DataTable dtrecipe, string datetype, int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDatesUpdate");
            SQLUtility.SetParamValue(cmd, "@" + datetype, DateTime.Today);
            SQLUtility.SetParamValue(cmd, "@recipeid", recipeid);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static bool CheckIfAlreadyCloneOfThisRecipe(string recipename)
        {
            bool b = false;
            SqlCommand cmdcheck = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmdcheck, "@RecipeName", recipename + " - clone");
            DataTable dtcheck = SQLUtility.GetDataTable(cmdcheck);
            if (dtcheck.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }

        public static int CloneRecipe(int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeClone", false);
            SqlParameter param = SQLUtility.SetOutputParameter(cmd, "@RecipeId", recipeid);
            SQLUtility.ExecuteSQL(cmd);
            return (int)param.Value;
        }
    }
}
