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
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            gData.DataSource = DataMaintenanace.DashboardGet();
            WindowsFormsUtility.FormatGridForSearchResult(gData, "dashboard");
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
