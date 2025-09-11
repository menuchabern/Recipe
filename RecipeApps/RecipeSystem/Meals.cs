using Microsoft.Data.SqlClient;
using System.Data;

namespace RecipeSystem
{
    public class Meals
    {
        public static DataTable MealList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("MealGet");
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
