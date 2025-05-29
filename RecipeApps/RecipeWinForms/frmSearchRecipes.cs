using System.Data;
using CPUFramework;
using CPUWindowsFormsFramework;

namespace RecipeWinForms
{
    public partial class frmSearchRecipes : Form
    {
        public frmSearchRecipes()
        {
            SQLUtility.ConnectionString = "Server=tcp:dev-mb.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=devmbadmin;Password=HELlo111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
            string sql = "select r.RecipeID, r.RecipeName, UserName = u.FirstName + ' ' + u.LastName, r.Calories, r.RecipeStatus from Recipe r join UserName u on u.UserNameID = r.UserNameID where r.recipename like '%" + txtRecipeName.Text + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
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
