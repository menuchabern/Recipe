using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmEditData : Form
    {
        private enum TableTypeEnum { UserName, Cuisine, Ingredient, MeasurementType, CourseType }
        TableTypeEnum currenttabletype = TableTypeEnum.UserName;
        DataTable dtlist = new();

        public frmEditData()
        {
            InitializeComponent();
            this.Shown += FrmDataMaintenance_Shown;
            btnSave.Click += BtnSave_Click;
            SetUpRadioButtons();
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gMain.CellContentClick += GMain_CellContentClick;
            gMain.DataError += GMain_DataError;
        }

        private void GMain_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Please put a proper value into {gMain.Columns[e.ColumnIndex].HeaderText}", Application.ProductName);
        }

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenance.GetDataList(currenttabletype.ToString());
            gMain.Columns.Clear();
            gMain.DataSource = dtlist;
            if (currenttabletype == TableTypeEnum.UserName)
            {
                gMain.Columns["FullName"].Visible = false;
            }
            if (currenttabletype == TableTypeEnum.Ingredient)
            {
                gMain.Columns["PictureName"].Visible = false;
            }
            WindowsFormsUtility.AddDeleteButtonToGrid(gMain, "DeleteCol");
            WindowsFormsUtility.FormatGridForEdit(gMain);
        }

        private void SetUpRadioButtons()
        {
            foreach (Control c in pnlRadioButtons.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            rdbCourses.Tag = TableTypeEnum.CourseType;
            rdbCuisines.Tag = TableTypeEnum.Cuisine;
            rdbIngredients.Tag = TableTypeEnum.Ingredient;
            rdbMeasurements.Tag = TableTypeEnum.MeasurementType;
            rdbUsers.Tag = TableTypeEnum.UserName;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete(int rowindex)
        {
            DialogResult res = new();
            if (currenttabletype == TableTypeEnum.UserName)
            {
                res = MessageBox.Show("Are you sure you want to delete this user and all related recipes, meals, and cookbooks?", Application.ProductName, MessageBoxButtons.YesNo);
            }
            else
            {
                res = MessageBox.Show($"Are you sure you want to delete this {currenttabletype.ToString()}?", Application.ProductName, MessageBoxButtons.YesNo);
            }
            if (res == DialogResult.No)
            {
                return;
            }

            int id = WindowsFormsUtility.GetIdFromGrid(gMain, rowindex, currenttabletype.ToString() + "Id");
            if (id != 0)
            {
                try
                {
                    DataMaintenance.DeleteRow(currenttabletype.ToString(), id);
                    BindData(currenttabletype);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }

            }
            else if (id == 0 && rowindex < gMain.Rows.Count)
            {
                gMain.Rows.Remove(gMain.Rows[rowindex]);
            }
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtlist))
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

        private void GMain_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gMain.Columns[e.ColumnIndex].Name == "DeleteCol")
            {
                Delete(e.RowIndex);
            }
        }

        private void FrmDataMaintenance_Shown(object? sender, EventArgs e)
        {
            BindData(currenttabletype);
        }
    }
}
