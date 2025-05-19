namespace RecipeWinForms
{
    partial class frmRecipe
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
            lblRecipeName = new Label();
            lblUserName = new Label();
            lblCalories = new Label();
            lblStatus = new Label();
            txtRecipeName = new TextBox();
            txtUserName = new TextBox();
            txtCalories = new TextBox();
            txtRecipeStatus = new TextBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(lblUserName, 0, 1);
            tblMain.Controls.Add(lblCalories, 0, 2);
            tblMain.Controls.Add(lblStatus, 0, 3);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtUserName, 1, 1);
            tblMain.Controls.Add(txtCalories, 1, 2);
            tblMain.Controls.Add(txtRecipeStatus, 1, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblMain.Size = new Size(547, 355);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 12F);
            lblRecipeName.Location = new Point(3, 30);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(126, 28);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Left;
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 12F);
            lblUserName.Location = new Point(3, 118);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(108, 28);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "User Name";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Font = new Font("Segoe UI", 12F);
            lblCalories.Location = new Point(3, 206);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(81, 28);
            lblCalories.TabIndex = 2;
            lblCalories.Text = "Calories";
            lblCalories.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(3, 295);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Font = new Font("Segoe UI", 12F);
            txtRecipeName.Location = new Point(276, 27);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.ReadOnly = true;
            txtRecipeName.Size = new Size(239, 34);
            txtRecipeName.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Left;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(276, 115);
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserName.Size = new Size(239, 34);
            txtUserName.TabIndex = 5;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Font = new Font("Segoe UI", 12F);
            txtCalories.Location = new Point(276, 203);
            txtCalories.Name = "txtCalories";
            txtCalories.ReadOnly = true;
            txtCalories.Size = new Size(239, 34);
            txtCalories.TabIndex = 6;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Anchor = AnchorStyles.Left;
            txtRecipeStatus.Font = new Font("Segoe UI", 12F);
            txtRecipeStatus.Location = new Point(276, 292);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(239, 34);
            txtRecipeStatus.TabIndex = 7;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 355);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblUserName;
        private Label lblCalories;
        private Label lblStatus;
        private TextBox txtRecipeName;
        private TextBox txtUserName;
        private TextBox txtCalories;
        private TextBox txtRecipeStatus;
    }
}