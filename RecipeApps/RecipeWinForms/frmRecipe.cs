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
            string sql = "select r.recipename, u.username, r.calories, r.recipestatus, r.datedrafted, r.datearchived, r.datepublished, c.cuisinetype from recipe r join username u on r.usernameid = u.usernameid join cuisine c on c.cuisineid = r.cuisineid where r.recipeid =" + id.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtUserName.DataBindings.Add("Text", dt, "UserName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtRecipeStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            txtCuisine.DataBindings.Add("Text", dt, "CuisineType");
            txtDateDrafted.DataBindings.Add("Text", dt, "DateDrafted");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            this.Show();
        }
    }
}