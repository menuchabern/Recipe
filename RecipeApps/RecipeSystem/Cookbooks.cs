using RecipeSystem;

namespace RecipeSystem
{
    public class Cookbooks
    {
        public static DataTable GetCookbookList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@all", 1);
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable LoadCookbook(int cookbookid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookid);
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable CookbookRecipeTab(int cookbookid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipesGet", false);
            SQLUtility.SetOutputParameter(cmd, "@Cookbookid", cookbookid);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void CookbookSave(DataTable dtcookbook)
        {
            if (dtcookbook.Rows.Count == 0)
            {
                throw new Exception("Cannot save because there are no rows in the table");
            }
            DataRow r = dtcookbook.Rows[0];
            SQLUtility.SaveDataRow(r, "CookbookUpdate");
        }

        public static void Delete(DataTable dtcookbook)
        {
            int id = (int)dtcookbook.Rows[0]["cookbookid"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("cookbookdelete");
            SQLUtility.SetParamValue(cmd, "@cookbookid", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void DeleteCookbookRecipe(int cookbookrecipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookRecipeid", cookbookrecipeid);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void SaveCookbookRecipe(int cookbookid, DataTable dt)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["cookbookid"] = cookbookid;
            }
            SQLUtility.SaveDataTable(dt, "cookbookrecipeUpdate");
        }
    }
}
