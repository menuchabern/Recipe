using System.Data;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        DataTable dtsteps;
        DataTable dtingredients;
        BindingSource bindsource = new();
        int recipeid = 0;
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnIngredientsSave.Click += BtnIngredientsSave_Click;
            btnStepsSave.Click += BtnStepsSave_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            gIngredients.DataError += TabGrid_DataError;
            gSteps.DataError += TabGrid_DataError;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gSteps.CellContentClick += GSteps_CellContentClick;
            btnChangeStatus.Click += BtnChangeStatus_Click;
        }


        private string GetFormTitle()
        {
            string title = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
            if (pkvalue > 0)
            {
                title = SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "RecipeName");
            }
            return title;
        }

        public void LoadResultsForm(int recipeval)
        {
            recipeid = recipeval;
            this.Tag = recipeid;
            dtrecipe = Recipe.LoadRecipe(recipeid);
            bindsource.DataSource = dtrecipe;
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }

            DataTable dtusername = Recipe.GetList("UserNameGet", true);
            WindowsFormsUtility.SetListBinding(lstUserName, dtusername, dtrecipe, "UserName");

            DataTable dtcuisine = Recipe.GetList("CuisineGet", true);
            WindowsFormsUtility.SetListBinding(lstCuisine, dtcuisine, dtrecipe, "Cuisine");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);
            this.Text = GetFormTitle();

            LoadIngredientsTab();
            LoadStepsTab();

            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            List<Button> btnlist = new() { btnDelete, btnChangeStatus, btnIngredientsSave, btnStepsSave };
            if(this.Text == "New Recipe")  
            {
                foreach (Button btn in btnlist)
                {
                    btn.Enabled = false;
                }

            }
            else if(this.Text != "New Recipe")
            {
                foreach (Button btn in btnlist)
                {
                    btn.Enabled = true;
                }
            }
            if (dtrecipe.Columns.Contains("RecipeStatus"))
            {
                if (dtrecipe.Rows.Count > 0 && dtrecipe.Rows[0]["RecipeStatus"].ToString() == "Archived")
                {
                    btnChangeStatus.Text = "Status Dates";
                }
            }
        }

        private void LoadStepsTab()
        {
            gSteps.Columns.Clear();
            dtsteps = Recipe.LoadRecipeTabs(recipeid, "RecipeStepsGet");
            gSteps.DataSource = dtsteps;
            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, "deleteingredientscol");
            WindowsFormsUtility.FormatGridForEdit(gSteps);
        }

        private void LoadIngredientsTab()
        {
            gIngredients.Columns.Clear();
            dtingredients = Recipe.LoadRecipeTabs(recipeid, "RecipeIngredientsGet");
            gIngredients.DataSource = dtingredients;
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, SQLUtility.GetDataTableForList("measurementget", 1), "measurementtype", "measurementtype");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, SQLUtility.GetDataTableForList("IngredientGet", 1), "Ingredient", "IngredientName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, "deleteingredientscol");
            WindowsFormsUtility.FormatGridForEdit(gIngredients);
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtrecipe);

                DataRowView currentrow = (DataRowView)bindsource.Current;
                currentrow["RecipeStatus"] = "Drafted";
                bindsource.ResetCurrentItem();
                bindsource.ResetBindings(false);

                EnableDisableButtons();
                dtrecipe.AcceptChanges();
                recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "Recipeid");
                this.Tag = recipeid;
                this.Text = GetFormTitle();
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipe");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void SaveTab(DataTable dt, string sprocname)
        {
            try
            {
                Recipe.SaveTab(dt, recipeid, sprocname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this recipe?", "Recipe", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtrecipe);
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


        private void DeleteTab(int rowIndex, DataGridView grid, string idcol, string sprocname)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(grid, rowIndex, idcol);
            if (id > 0)
            {
                try
                {
                    Recipe.DeleteTab(id, sprocname, "@" + idcol);
                    if (grid.Name == "gSteps")
                    {
                        LoadStepsTab();
                    }
                    else if (grid.Name == "gIngredients")
                    {
                        LoadIngredientsTab();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < grid.Rows.Count)
            {
                grid.Rows.RemoveAt(rowIndex);
            }
        }

        private void FrmRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtrecipe))
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

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnStepsSave_Click(object? sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            try
            {
                SaveTab(dtsteps, "RecipeStepsUpdate");
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

        private void BtnIngredientsSave_Click(object? sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            try
            {
                SaveTab(dtingredients, "RecipeIngredientsUpdate");
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

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DeleteTab(e.RowIndex, gSteps, "RecipeStepsID", "RecipeStepsDelete");
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

        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            Application.UseWaitCursor = true;
            try
            {
                DeleteTab(e.RowIndex, gIngredients, "RecipeIngredientID", "RecipeIngredientDelete");
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

        private void TabGrid_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            var grid = sender as DataGridView;
            MessageBox.Show($"Please put a proper value into {grid.Columns[e.ColumnIndex].HeaderText}", Application.ProductName);
        }

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeStatus), recipeid);
            }
        }
    }
}