using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            this.Activated += FrmRecipeList_Activated;
            WindowsFormsUtility.FormatGridForSearchResult(gRecipeResults, "recipe");
            gRecipeResults.CellDoubleClick += GRecipeResults_CellDoubleClick;
            btnNewRecipe.Click += BtnNew_Click;
        }

        private void BindData()
        {
            DataTable dt = Recipe.SearchRecipe();
            gRecipeResults.DataSource = dt;
            
            string[] columnsToHide = {"datedrafted", "datearchived", "datepublished", "cuisine" };
            foreach (string colName in columnsToHide)
            {
                if (gRecipeResults.Columns.Contains(colName))
                {
                    gRecipeResults.Columns[colName].Visible = false;
                }
            }
            WindowsFormsUtility.FormatGridForSearchResult(gRecipeResults, "recipe");
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

        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            BindData();
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
