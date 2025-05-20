using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowResultsForm(int id)
        {
            string sql = "select r.recipename, u.username, r.calories, r.recipestatus from recipe r join username u on r.usernameid = u.usernameid where r.recipeid =" + id.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtUserName.DataBindings.Add("Text", dt, "UserName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            this.Show();
        }
    }
}