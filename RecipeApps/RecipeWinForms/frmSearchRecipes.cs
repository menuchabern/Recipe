using System.Data;
using CPUFramework;
using CPUWindowsFormsFramework;

namespace RecipeWinForms
{
    public partial class frmSearchRecipes : Form
    {
        public frmSearchRecipes()
        {
            InitializeComponent();
            WindowsFormsUtility.FormatGridForSearchResult(gRecipeResults);
            btnSearch.Click += BtnSearch_Click;
            gRecipeResults.CellDoubleClick += GRecipeResults_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
        }

        private void ShowPresidentForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = (int)gRecipeResults.Rows[rowindex].Cells["RecipeID"].Value;
            }
            frmRecipe frmrecipe = new frmRecipe();
            frmrecipe.ShowResultsForm(id);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            DataTable dt = Recipe.SearchRecipe(txtRecipeName.Text);
            gRecipeResults.DataSource = dt;
            gRecipeResults.Columns["RecipeID"].Visible = false;
        }

        private void GRecipeResults_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowPresidentForm(e.RowIndex);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowPresidentForm(-1);
        }
    }
}
