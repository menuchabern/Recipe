namespace RecipeWinForms
{
    partial class frmSearchRecipes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblMain = new TableLayoutPanel();
            tblToobox = new TableLayoutPanel();
            lblRecipe = new Label();
            txtRecipeName = new TextBox();
            btnSearch = new Button();
            btnNew = new Button();
            gRecipeResults = new DataGridView();
            tblMain.SuspendLayout();
            tblToobox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeResults).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblToobox, 0, 0);
            tblMain.Controls.Add(gRecipeResults, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100.000008F));
            tblMain.Size = new Size(679, 535);
            tblMain.TabIndex = 0;
            // 
            // tblToobox
            // 
            tblToobox.AutoSize = true;
            tblToobox.ColumnCount = 4;
            tblToobox.ColumnStyles.Add(new ColumnStyle());
            tblToobox.ColumnStyles.Add(new ColumnStyle());
            tblToobox.ColumnStyles.Add(new ColumnStyle());
            tblToobox.ColumnStyles.Add(new ColumnStyle());
            tblToobox.Controls.Add(lblRecipe, 0, 0);
            tblToobox.Controls.Add(txtRecipeName, 1, 0);
            tblToobox.Controls.Add(btnSearch, 2, 0);
            tblToobox.Controls.Add(btnNew, 3, 0);
            tblToobox.Font = new Font("Segoe UI", 12F);
            tblToobox.Location = new Point(3, 3);
            tblToobox.Name = "tblToobox";
            tblToobox.RowCount = 1;
            tblToobox.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToobox.Size = new Size(373, 44);
            tblToobox.TabIndex = 0;
            // 
            // lblRecipe
            // 
            lblRecipe.AutoSize = true;
            lblRecipe.Dock = DockStyle.Fill;
            lblRecipe.Location = new Point(3, 0);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(69, 44);
            lblRecipe.TabIndex = 0;
            lblRecipe.Text = "Recipe";
            lblRecipe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(78, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(125, 34);
            txtRecipeName.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Location = new Point(209, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 38);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Location = new Point(309, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(61, 38);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // gRecipeResults
            // 
            gRecipeResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipeResults.Dock = DockStyle.Fill;
            gRecipeResults.Location = new Point(3, 53);
            gRecipeResults.Name = "gRecipeResults";
            gRecipeResults.RowHeadersWidth = 51;
            gRecipeResults.Size = new Size(673, 479);
            gRecipeResults.TabIndex = 1;
            // 
            // frmSearchRecipes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 535);
            Controls.Add(tblMain);
            Name = "frmSearchRecipes";
            Text = "Search Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblToobox.ResumeLayout(false);
            tblToobox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblToobox;
        private Label lblRecipe;
        private TextBox txtRecipeName;
        private Button btnSearch;
        private DataGridView gRecipeResults;
        private Button btnNew;
    }
}