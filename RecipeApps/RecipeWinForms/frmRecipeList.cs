namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            this.Activated += FrmRecipeList_Activated;
            gRecipes.CellDoubleClick += GRecipeResults_CellDoubleClick;
            gRecipes.KeyDown += GRecipes_KeyDown;
            btnNewRecipe.Click += BtnNew_Click;
        }


        private void BindData()
        {
            DataTable dt = Recipe.SearchRecipe();
            gRecipes.DataSource = dt;

            string[] columnsToHide = { "datedrafted", "datearchived", "datepublished", "cuisine","IsDeleteAllowed" };
            foreach (string colName in columnsToHide)
            {
                if (gRecipes.Columns.Contains(colName))
                {
                    gRecipes.Columns[colName].Visible = false;
                }
            }
            WindowsFormsUtility.FormatGridForSearchResult(gRecipes);
        }

        public void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipes, rowindex, "RecipeId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
            }
        }

        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void GRecipeResults_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowRecipeForm(e.RowIndex);
            }
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }

        private void GRecipes_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowRecipeForm(gRecipes.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}
