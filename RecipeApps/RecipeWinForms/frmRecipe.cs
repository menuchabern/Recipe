using CPUFramework;
using System.Data;
using CPUWindowsFormsFramework;
using System.Diagnostics;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
        }


        public void ShowResultsForm(int recipeid)
        {
            string sql = "select r.recipeid, r.cuisineid, r.usernameid, r.recipename, u.username, r.calories, r.recipestatus, r.datedrafted, r.datearchived, r.datepublished, c.cuisine "
                + "from recipe r join username u on r.usernameid = u.usernameid join cuisine c on c.cuisineid = r.cuisineid where r.recipeid = "
                + recipeid.ToString();
            dtrecipe = SQLUtility.GetDataTable(sql);

            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }

            DataTable dtusername = SQLUtility.GetDataTable("select UserNameID, UserName from UserName");
            WindowsFormsUtility.SetListBinding(lstUserName, dtusername, dtrecipe, "UserName");

            DataTable dtcuisine = SQLUtility.GetDataTable("select CuisineID, Cuisine from Cuisine");
            WindowsFormsUtility.SetListBinding(lstCuisine, dtcuisine, dtrecipe, "Cuisine");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtrecipe);

            Debug.Print(dtrecipe == null ? "dtrecipe is null" : "dtrecipe is initialized");


            this.Show();
        }

        private void Save()
        {
            DataRow r = dtrecipe.Rows[0];
            int recipeid = (int)r["recipeid"];
            string sql;
            if (recipeid > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set ",
                    $"UserNameID = '{r["UserNameID"]}',",
                    $"CuisineID = '{r["CuisineID"]}',",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"Calories = '{r["Calories"]}',",
                    $"DateDrafted = '{r["DateDrafted"]}'",
                    $"where recipeid = {r["recipeid"]}"
                    );
            }
            else
            {
                sql = "insert recipe(UserNameID, CuisineID, RecipeName, Calories, DateDrafted)";
                sql += $"select '{r["usernameid"]}', '{r["cuisineid"]}','{r["recipename"]}','{r["calories"]}','{r["datedrafted"]}'";
                Debug.Print(sql);
            }
            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            DataRow r = dtrecipe.Rows[0];
            string sql = "delete recipe where recipeid = " + r["recipeid"].ToString();
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }
    }
}