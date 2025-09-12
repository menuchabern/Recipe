using RecipeSystem;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmCookbook : Form
    {
        BindingSource bindsource = new();
        int cookbookid = 0;
        DataTable dtcookbook = new();

        public frmCookbook()
        {
            InitializeComponent();
        }

        public void LoadCookbookForm(int cookbookval)
        {
            cookbookid = cookbookval;
            this.Tag = cookbookid;
            dtcookbook = Cookbooks.LoadCookbook(cookbookid);
            bindsource.DataSource = dtcookbook;
            if(cookbookid == 0)
            {
                dtcookbook.Rows.Add();
            }
            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindsource);

            DataTable dtusername = SQLUtility.GetList("UserNameGet", true);
            WindowsFormsUtility.SetListBinding(lstUserName, dtusername, dtcookbook, "UserName");

            WindowsFormsUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormsUtility.SetControlBinding(ckbActiveStatus, bindsource);
            this.Text = GetFormTitle();
        }

        private string GetFormTitle()
        {
            string title = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "cookbookId");
            if (pkvalue > 0)
            {
                title = SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "CookbookName");
            }
            return title;
        }
    }
}
