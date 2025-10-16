using System.Windows.Forms;

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
            gData.DataSource = DataMaintenance.DashboardGet();
            WindowsFormsUtility.FormatGridForSearchResult(gData);
            ResizeDataGridView();
        }

        private void ResizeDataGridView()
        {
            gData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gData.AutoResizeColumns();
            gData.AutoResizeRows();
            int totalWidth = gData.RowHeadersVisible ? gData.RowHeadersWidth : 0;
            foreach (DataGridViewColumn col in gData.Columns)
            {
                totalWidth += col.Width;
            }
            int totalHeight = gData.ColumnHeadersVisible ? gData.ColumnHeadersHeight : 0;
            foreach (DataGridViewRow row in gData.Rows)
            {
                totalHeight += row.Height;
            }
            gData.Width = totalWidth + 2;
            gData.Height = totalHeight + 2;
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
