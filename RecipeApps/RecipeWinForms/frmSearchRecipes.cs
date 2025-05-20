using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUFramework;

namespace RecipeWinForms
{
    public partial class frmSearchRecipes : Form
    {
        public frmSearchRecipes()
        {
            SQLUtility.ConnectionString = "Server=tcp:dev-mb.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=devmbadmin;Password=HELlo111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            InitializeComponent();
            FormatGrid();
            btnSearch.Click += BtnSearch_Click;
            gRecipeResults.CellDoubleClick += GRecipeResults_CellDoubleClick;
        }


        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string sql = "select r.RecipeID, r.RecipeName, UserName = u.FirstName + ' ' + u.LastName, r.Calories, r.RecipeStatus from Recipe r join UserName u on u.UserNameID = r.UserNameID where r.recipename like '%" + txtRecipeName.Text + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipeResults.DataSource = dt;
            gRecipeResults.Columns["RecipeID"].Visible = false;
        }

        private void GRecipeResults_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            int id = (int)gRecipeResults.Rows[e.RowIndex].Cells["RecipeID"].Value;
            frmRecipe frmrecipe = new frmRecipe();
            frmrecipe.ShowResultsForm(id);
        }

        private void FormatGrid()
        {
            gRecipeResults.AllowUserToAddRows = false;
            gRecipeResults.ReadOnly = true;
            gRecipeResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipeResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
