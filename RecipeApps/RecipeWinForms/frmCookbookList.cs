using RecipeSystem;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        public frmCookbookList()
        {
            InitializeComponent();
            BindData();
            btnNewCookbook.Click += BtnNewCookbook_Click;
            gCookbookList.CellDoubleClick += GCookbookList_CellDoubleClick;
            this.Activated += FrmCookbookList_Activated;
            gCookbookList.KeyDown += GCookbookList_KeyDown;
        }


        private void BindData()
        {
            DataTable dtcookbook = Cookbooks.GetCookbookList();
            gCookbookList.DataSource = dtcookbook;
            gCookbookList.Columns["DateCreated"].Visible = false;
            gCookbookList.Columns["ActiveStatus"].Visible = false;
            WindowsFormsUtility.FormatGridForSearchResult(gCookbookList);
        }

        public void ShowCookbookForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gCookbookList, rowindex, "CookbookId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), id);
            }
        }

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook));
            }
        }

        private void GCookbookList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowCookbookForm(e.RowIndex);
        }

        private void GCookbookList_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowCookbookForm(gCookbookList.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}
