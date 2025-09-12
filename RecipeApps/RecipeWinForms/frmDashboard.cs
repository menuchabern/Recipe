namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        private frmMain frmMain = new();
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
            }
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmMealsList));
            }
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            gData.DataSource = DataMaintenanace.DashboardGet();
            WindowsFormsUtility.FormatGridForSearchResult(gData);
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeList));
            }
        }
    }
}
