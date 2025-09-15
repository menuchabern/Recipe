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
    }
}
