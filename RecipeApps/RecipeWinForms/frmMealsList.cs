using System.Data;

namespace RecipeWinForms
{
    public partial class frmMealsList : Form
    {
        public frmMealsList()
        {
            InitializeComponent();
            this.Activated += FrmMealsList_Activated;
        }


        private void BindData()
        {
            DataTable dt = Meals.MealList();
            gMeals.DataSource = dt;
            WindowsFormsUtility.FormatGridForSearchResult(gMeals);
        }

        private void FrmMealsList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
    }
}
