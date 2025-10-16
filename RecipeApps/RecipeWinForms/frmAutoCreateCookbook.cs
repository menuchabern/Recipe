using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmAutoCreateCookbook : Form
    {
        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            this.Activated += FrmAutoCreateCookbook_Activated;
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
        }

        private void BindData()
        {
            WindowsFormsUtility.SetListBinding(lstUserName, SQLUtility.GetList("UserNameGet"), null, "UserName");
        }

        private void FrmAutoCreateCookbook_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            int usernameid = (int)lstUserName.SelectedValue;
            if (usernameid == 0)
            {
                MessageBox.Show("Please choose a username", Application.ProductName);
                return;
            }

            try
            {
               int newcookbookid =  Cookbooks.AutoCreateCookbook((int)lstUserName.SelectedValue);

                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), newcookbookid);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.ToString() == "CookbookName must be unique.")
                {
                    MessageBox.Show("There is already a cookbook for this user. Please choose another user.", Application.ProductName);
                    return;
                }
                MessageBox.Show(ex.Message, Application.ProductName);
            }

        }
    }
}
