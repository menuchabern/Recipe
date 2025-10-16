using System.Data;

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        public frmCloneRecipe()
        {
            InitializeComponent();
            this.Activated += FrmCloneRecipe_Activated;
            btnClone.Click += BtnClone_Click;
        }


        private void BindData()
        {
            DataTable dtrecipe = SQLUtility.GetList("RecipeGet");
            WindowsFormsUtility.SetListBinding(lstRecipeName, dtrecipe, null, "recipe");
        }

        private void CloneRecipe()
        {
            int recipeid = 0;
            string recipename = lstRecipeName.Text;
            if (recipename == "")
            {
                MessageBox.Show("Please choose a recipe.", Application.ProductName);
                return;
            }
            if (Recipe.CheckIfAlreadyCloneOfThisRecipe(recipename))
            {
                MessageBox.Show("There is already a clone of this recipe. Choose another recipe.", Application.ProductName);
                return;
            }

            try
            {
                if (lstRecipeName.SelectedValue is int)
                {
                    recipeid = (int)lstRecipeName.SelectedValue;
                }

                int newrecipeid = Recipe.CloneRecipe(recipeid);

                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), newrecipeid);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }

        }

        private void FrmCloneRecipe_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CloneRecipe();
        }
    }
}
