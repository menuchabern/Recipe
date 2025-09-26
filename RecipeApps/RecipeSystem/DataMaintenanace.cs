namespace RecipeSystem
{
    public class DataMaintenanace
    {

        public static DataTable GetDataList(string tablename)
        {
            return SQLUtility.GetList(tablename + "Get");
        }

        public static DataTable DashboardGet()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            return SQLUtility.GetDataTable(cmd);
        }

        public static void SaveDataList(DataTable dt, string tablename)
        {
            SQLUtility.SaveDataTable(dt, tablename + "Update");
        }
    }
}
