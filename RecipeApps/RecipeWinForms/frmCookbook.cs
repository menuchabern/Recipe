using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCookbook : Form
    {
        BindingSource bindsource = new();
        int cookbookid = 0;
        DataTable dtcookbook = new();
        DataTable dtcookbookrecipe = new();

        public frmCookbook()
        {
            InitializeComponent();
            this.Shown += FrmCookbook_Shown;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            gRecipes.CellContentClick += GRecipes_CellContentClick;
            btnSaveRecipes.Click += BtnSaveRecipes_Click;
            this.FormClosing += FrmCookbook_FormClosing;
            gRecipes.DataError += GRecipes_DataError;
        }


        public void LoadCookbookForm(int cookbookval)
        {
            cookbookid = cookbookval;
            this.Tag = cookbookid;
            dtcookbook = Cookbooks.LoadCookbook(cookbookid);
            bindsource.DataSource = dtcookbook;
            if (cookbookid == 0)
            {
                dtcookbook.Rows.Add();
            }
            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindsource);

            DataTable dtusername = SQLUtility.GetList("UserNameGet");
            WindowsFormsUtility.SetListBinding(lstUserName, dtusername, dtcookbook, "UserName");

            WindowsFormsUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormsUtility.SetControlBinding(ckbActiveStatus, bindsource);
            this.Text = GetFormTitle();
            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            if(this.Text == "New Cookbook")
            {
                btnDelete.Enabled = false;
                btnSaveRecipes.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnSaveRecipes.Enabled = true;
            }
        }

        private void LoadCookbookRecipes()
        {
            gRecipes.Columns.Clear();
            dtcookbookrecipe = Cookbooks.LoadCookbookRecipes(cookbookid);
            gRecipes.DataSource = dtcookbookrecipe;
            WindowsFormsUtility.AddDeleteButtonToGrid(gRecipes, "deletecol");
            WindowsFormsUtility.AddComboBoxToGrid(gRecipes, SQLUtility.GetList("RecipeGet"), "Recipe", "RecipeName");
            WindowsFormsUtility.FormatGridForEdit(gRecipes);
        }

        private string GetFormTitle()
        {
            string title = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "cookbookId");
            if (pkvalue > 0)
            {
                title = "Cookbook - " + SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "CookbookName");
            }
            return title;
        }

        private bool Save()
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
                EnableDisableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this Cookbook?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Cookbooks.Delete(dtcookbook);
                this.Close();
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

        private void SaveCookbookRecipe()
        {
            try
            {
                Cookbooks.SaveCookbookRecipe(cookbookid, dtcookbookrecipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void DeleteCookbookRecipe(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gRecipes, rowindex, "CookbookRecipeId");
            if (id > 0)
            {
                try
                {
                    Cookbooks.DeleteCookbookRecipe(id);
                    LoadCookbookRecipes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gRecipes.Rows.Count)
            {
                gRecipes.Rows.RemoveAt(rowindex);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void GRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DeleteCookbookRecipe(e.RowIndex);
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


        private void BtnSaveRecipes_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipe();
        }
        private void GRecipes_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Please put a proper value into {gRecipes.Columns[e.ColumnIndex].HeaderText}", Application.ProductName);
        }

        private void FrmCookbook_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtcookbook))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }

        private void FrmCookbook_Shown(object? sender, EventArgs e)
        {
            LoadCookbookRecipes();
        }
    }
}
