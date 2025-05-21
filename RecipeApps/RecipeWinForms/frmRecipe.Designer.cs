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
            lblCuisine = new Label();
            txtCuisine = new TextBox();
            lblDateDrafted = new Label();
            txtDateDrafted = new TextBox();
            lblDatePublished = new Label();
            txtDatePublished = new TextBox();
            lblDateArchived = new Label();
            txtDateArchived = new TextBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblDateArchived, 0, 7);
            tblMain.Controls.Add(txtDateArchived, 1, 7);
            tblMain.Controls.Add(lblDatePublished, 0, 6);
            tblMain.Controls.Add(txtDatePublished, 1, 6);
            tblMain.Controls.Add(lblDateDrafted, 0, 5);
            tblMain.Controls.Add(txtDateDrafted, 1, 5);
            tblMain.Controls.Add(lblCuisine, 0, 4);
            tblMain.Controls.Add(txtCuisine, 1, 4);
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
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.Size = new Size(612, 503);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 12F);
            lblRecipeName.Location = new Point(3, 17);
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
            lblUserName.Location = new Point(3, 79);
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
            lblCalories.Location = new Point(3, 141);
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
            lblStatus.Location = new Point(3, 203);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Font = new Font("Segoe UI", 12F);
            txtRecipeName.Location = new Point(309, 14);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.ReadOnly = true;
            txtRecipeName.Size = new Size(239, 34);
            txtRecipeName.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Left;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(309, 76);
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserName.Size = new Size(239, 34);
            txtUserName.TabIndex = 5;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Font = new Font("Segoe UI", 12F);
            txtCalories.Location = new Point(309, 138);
            txtCalories.Name = "txtCalories";
            txtCalories.ReadOnly = true;
            txtCalories.Size = new Size(239, 34);
            txtCalories.TabIndex = 6;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Anchor = AnchorStyles.Left;
            txtRecipeStatus.Font = new Font("Segoe UI", 12F);
            txtRecipeStatus.Location = new Point(309, 200);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(239, 34);
            txtRecipeStatus.TabIndex = 7;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Font = new Font("Segoe UI", 12F);
            lblCuisine.Location = new Point(3, 265);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(74, 28);
            lblCuisine.TabIndex = 8;
            lblCuisine.Text = "Cuisine";
            // 
            // txtCuisine
            // 
            txtCuisine.Anchor = AnchorStyles.Left;
            txtCuisine.Font = new Font("Segoe UI", 12F);
            txtCuisine.Location = new Point(309, 262);
            txtCuisine.Name = "txtCuisine";
            txtCuisine.ReadOnly = true;
            txtCuisine.Size = new Size(239, 34);
            txtCuisine.TabIndex = 9;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.Anchor = AnchorStyles.Left;
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Font = new Font("Segoe UI", 12F);
            lblDateDrafted.Location = new Point(3, 327);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(124, 28);
            lblDateDrafted.TabIndex = 10;
            lblDateDrafted.Text = "Date Drafted";
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Anchor = AnchorStyles.Left;
            txtDateDrafted.Font = new Font("Segoe UI", 12F);
            txtDateDrafted.Location = new Point(309, 324);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.ReadOnly = true;
            txtDateDrafted.Size = new Size(239, 34);
            txtDateDrafted.TabIndex = 11;
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Font = new Font("Segoe UI", 12F);
            lblDatePublished.Location = new Point(3, 389);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(143, 28);
            lblDatePublished.TabIndex = 12;
            lblDatePublished.Text = "Date Published";
            // 
            // txtDatePublished
            // 
            txtDatePublished.Anchor = AnchorStyles.Left;
            txtDatePublished.Font = new Font("Segoe UI", 12F);
            txtDatePublished.Location = new Point(309, 386);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.ReadOnly = true;
            txtDatePublished.Size = new Size(239, 34);
            txtDatePublished.TabIndex = 13;
            // 
            // lblDateArchived
            // 
            lblDateArchived.Anchor = AnchorStyles.Left;
            lblDateArchived.AutoSize = true;
            lblDateArchived.Font = new Font("Segoe UI", 12F);
            lblDateArchived.Location = new Point(3, 454);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(135, 28);
            lblDateArchived.TabIndex = 14;
            lblDateArchived.Text = "Date Archived";
            // 
            // txtDateArchived
            // 
            txtDateArchived.Anchor = AnchorStyles.Left;
            txtDateArchived.Font = new Font("Segoe UI", 12F);
            txtDateArchived.Location = new Point(309, 451);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.ReadOnly = true;
            txtDateArchived.Size = new Size(239, 34);
            txtDateArchived.TabIndex = 15;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 503);
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
        private Label lblDateArchived;
        private TextBox txtDateArchived;
        private Label lblDatePublished;
        private TextBox txtDatePublished;
        private Label lblDateDrafted;
        private TextBox txtDateDrafted;
        private Label lblCuisine;
        private TextBox txtCuisine;
    }
}