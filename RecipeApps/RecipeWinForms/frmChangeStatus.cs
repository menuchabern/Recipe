namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        DataTable dtrecipe;
        BindingSource bindsource = new();
        string frmtitle = "Change Status";

        public frmChangeStatus()
        {
            InitializeComponent();
            btnArchive.Click += BtnArchive_Click;
            btnDraft.Click += BtnDraft_Click;
            btnPublish.Click += BtnPublish_Click;
            this.Shown += FrmChangeStatus_Shown;
        }


        public void LoadForm(int recipeid)
        {
            dtrecipe = Recipe.LoadRecipe(recipeid);
            this.Tag = recipeid;
            bindsource.DataSource = dtrecipe;

            WindowsFormsUtility.SetControlBinding(lblRecipeName, bindsource);
            txtDateArchived.Name = "txtDateArchived";
            txtDateDrafted.Name = "txtDateDrafted";
            txtDatePublished.Name = "txtDatePublished";
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);

            recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "Recipeid");
        }

        private void FrmChangeStatus_Shown(object? sender, EventArgs e)
        {
            EnableDisableDateButtons();
        }
        public void EnableDisableDateButtons()
        {
            btnArchive.Enabled = true;
            btnDraft.Enabled = true;
            btnPublish.Enabled = true;

            switch (lblRecipeStatus.Text)
            {
                case "Draft":
                    btnDraft.Enabled = false;
                    break;
                case "Published":
                    btnPublish.Enabled = false;
                    btnDraft.Enabled = false;
                    break;
                case "Archived":
                    btnPublish.Enabled = false;
                    btnDraft.Enabled = false;
                    btnArchive.Enabled = false;
                    frmtitle = "Status Dates";
                    break;

            }
            this.Text = $"{SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "RecipeName")} - {frmtitle}";
        }

        private void UpdateDates(string datetype)
        {
            var response = MessageBox.Show($"Are you sure want to change the status to {datetype.Substring(4)}?", Application.ProductName, MessageBoxButtons.OKCancel);

            if (response.ToString() == "Cancel")
            {
                return;
            }
            try
            {
                Application.UseWaitCursor = true;
                int recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "Recipeid");
                Recipe.UpdateRecipeStatus(dtrecipe, datetype, recipeid);

                dtrecipe = Recipe.LoadRecipe(recipeid);
                bindsource.DataSource = dtrecipe;
                EnableDisableDateButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            UpdateDates("DatePublished");
        }

        private void BtnDraft_Click(object? sender, EventArgs e)
        {
            UpdateDates("DateDrafted");
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            UpdateDates("DateArchived");
        }
    }
}
