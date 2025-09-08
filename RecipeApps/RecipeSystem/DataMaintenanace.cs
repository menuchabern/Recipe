using Microsoft.Data.SqlClient;
using System.Data;

namespace RecipeSystem
{
    public class DataMaintenanace
    {

        public static DataTable GetDataList(string tablename, bool includeblank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand(tablename + "Get");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            if (includeblank == true)
            {
                SQLUtility.SetParamValue(cmd, "@includeblank", includeblank);
            }
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable DashboardGet()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
