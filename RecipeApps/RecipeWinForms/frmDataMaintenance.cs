
namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { UserName, Cuisine, Ingredient, Measurement, Course }
        TableTypeEnum currenttabletype = TableTypeEnum.UserName;
        DataTable dtlist = new();
        public frmDataMaintenance()
        {
            InitializeComponent();
            BindData(currenttabletype);
            btnSave.Click += BtnSave_Click;
        }


        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenanace.GetDataList(currenttabletype.ToString());
            gMain.Columns.Clear();
            gMain.DataSource = dtlist;
            WindowsFormsUtility.AddDeleteButtonToGrid(gMain, "DeleteCol");
            WindowsFormsUtility.FormatGridForEdit(gMain);
        }
        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenanace.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

    }
}
