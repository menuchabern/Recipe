using Microsoft.Data.SqlClient;
using System.Data;

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
    }
}
