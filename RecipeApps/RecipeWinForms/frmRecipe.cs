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

        public void ShowResultForm(int id)
        {
            string sql = "select p.recipename, u.username, p.calories, p.recipestatus from recipe r join username u on p.usernameid = u.usernameid where r.recipe id = " + id;
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtUserName.DataBindings.Add("Text", dt, "UserName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtRecipeStatus.DataBindings.Add("Text", dt, "Calories");
            this.Show();
        }
    }
}