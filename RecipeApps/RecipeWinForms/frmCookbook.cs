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
            btnSave.Click += BtnSave_Click;
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
            SetCookbookRecipes();
        }

        private void SetCookbookRecipes()
        {
            gRecipes.Columns.Clear();
            gRecipes.DataSource = Cookbooks.CookbookRecipeTab(cookbookid);
            WindowsFormsUtility.AddDeleteButtonToGrid(gRecipes, "deletecol");
            WindowsFormsUtility.AddComboBoxToGrid(gRecipes, SQLUtility.GetDataTableForList("RecipeGet", 1), "Recipe", "RecipeName");
            WindowsFormsUtility.FormatGridForEdit(gRecipes);
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

        private bool Save(DataTable dtcookbook)
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Cookbooks.CookbookSave(dtcookbook);
                b = true;
                bindsource.ResetBindings(false);
                dtcookbook.AcceptChanges();
                cookbookid = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "cookbookid");
                this.Tag = cookbookid;
                this.Text = GetFormTitle();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save(dtcookbook);
        }
    }
}
