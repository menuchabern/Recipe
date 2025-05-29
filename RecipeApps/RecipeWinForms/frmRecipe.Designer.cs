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
            lblDateArchived = new Label();
            txtDateArchived = new TextBox();
            lblDatePublished = new Label();
            txtDatePublished = new TextBox();
            lblDateDrafted = new Label();
            txtDateDrafted = new TextBox();
            lblCuisine = new Label();
            lblRecipeName = new Label();
            lblUserName = new Label();
            lblCalories = new Label();
            lblStatus = new Label();
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            txtRecipeStatus = new TextBox();
            lstUserName = new ComboBox();
            lstCuisine = new ComboBox();
            tblSaveandDelete = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            tblMain.SuspendLayout();
            tblSaveandDelete.SuspendLayout();
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
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(lblUserName, 0, 1);
            tblMain.Controls.Add(lblCalories, 0, 2);
            tblMain.Controls.Add(lblStatus, 0, 3);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtCalories, 1, 2);
            tblMain.Controls.Add(txtRecipeStatus, 1, 3);
            tblMain.Controls.Add(lstUserName, 1, 1);
            tblMain.Controls.Add(lstCuisine, 1, 4);
            tblMain.Controls.Add(tblSaveandDelete, 1, 8);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(612, 567);
            tblMain.TabIndex = 0;
            // 
            // lblDateArchived
            // 
            lblDateArchived.Anchor = AnchorStyles.Left;
            lblDateArchived.AutoSize = true;
            lblDateArchived.Font = new Font("Segoe UI", 12F);
            lblDateArchived.Location = new Point(3, 466);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(135, 28);
            lblDateArchived.TabIndex = 14;
            lblDateArchived.Text = "Date Archived";
            // 
            // txtDateArchived
            // 
            txtDateArchived.Anchor = AnchorStyles.Left;
            txtDateArchived.Font = new Font("Microsoft Sans Serif", 12F);
            txtDateArchived.Location = new Point(309, 465);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.ReadOnly = true;
            txtDateArchived.Size = new Size(239, 30);
            txtDateArchived.TabIndex = 7;
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Font = new Font("Segoe UI", 12F);
            lblDatePublished.Location = new Point(3, 402);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(143, 28);
            lblDatePublished.TabIndex = 12;
            lblDatePublished.Text = "Date Published";
            // 
            // txtDatePublished
            // 
            txtDatePublished.Anchor = AnchorStyles.Left;
            txtDatePublished.Font = new Font("Microsoft Sans Serif", 12F);
            txtDatePublished.Location = new Point(309, 401);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.ReadOnly = true;
            txtDatePublished.Size = new Size(239, 30);
            txtDatePublished.TabIndex = 6;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.Anchor = AnchorStyles.Left;
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.Font = new Font("Segoe UI", 12F);
            lblDateDrafted.Location = new Point(3, 338);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(124, 28);
            lblDateDrafted.TabIndex = 10;
            lblDateDrafted.Text = "Date Drafted";
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Anchor = AnchorStyles.Left;
            txtDateDrafted.Font = new Font("Microsoft Sans Serif", 12F);
            txtDateDrafted.Location = new Point(309, 337);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(239, 30);
            txtDateDrafted.TabIndex = 5;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Font = new Font("Segoe UI", 12F);
            lblCuisine.Location = new Point(3, 274);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(74, 28);
            lblCuisine.TabIndex = 8;
            lblCuisine.Text = "Cuisine";
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 12F);
            lblRecipeName.Location = new Point(3, 18);
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
            lblUserName.Location = new Point(3, 82);
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
            lblCalories.Location = new Point(3, 146);
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
            lblStatus.Location = new Point(3, 210);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Font = new Font("Microsoft Sans Serif", 12F);
            txtRecipeName.Location = new Point(309, 17);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(239, 30);
            txtRecipeName.TabIndex = 0;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Font = new Font("Microsoft Sans Serif", 12F);
            txtCalories.Location = new Point(309, 145);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(239, 30);
            txtCalories.TabIndex = 2;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Anchor = AnchorStyles.Left;
            txtRecipeStatus.Font = new Font("Microsoft Sans Serif", 12F);
            txtRecipeStatus.Location = new Point(309, 209);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(239, 30);
            txtRecipeStatus.TabIndex = 3;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left;
            lstUserName.Font = new Font("Microsoft Sans Serif", 12F);
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(309, 79);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(239, 33);
            lstUserName.TabIndex = 1;
            // 
            // lstCuisine
            // 
            lstCuisine.Anchor = AnchorStyles.Left;
            lstCuisine.Font = new Font("Microsoft Sans Serif", 12F);
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(309, 271);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(239, 33);
            lstCuisine.TabIndex = 4;
            // 
            // tblSaveandDelete
            // 
            tblSaveandDelete.AutoSize = true;
            tblSaveandDelete.ColumnCount = 2;
            tblSaveandDelete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSaveandDelete.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSaveandDelete.Controls.Add(btnSave, 0, 0);
            tblSaveandDelete.Controls.Add(btnDelete, 1, 0);
            tblSaveandDelete.Dock = DockStyle.Fill;
            tblSaveandDelete.Location = new Point(309, 515);
            tblSaveandDelete.Name = "tblSaveandDelete";
            tblSaveandDelete.RowCount = 1;
            tblSaveandDelete.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblSaveandDelete.Size = new Size(300, 49);
            tblSaveandDelete.TabIndex = 18;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 43);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(153, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(144, 43);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 567);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSaveandDelete.ResumeLayout(false);
            tblSaveandDelete.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblUserName;
        private Label lblCalories;
        private Label lblStatus;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtRecipeStatus;
        private Label lblDateArchived;
        private TextBox txtDateArchived;
        private Label lblDatePublished;
        private TextBox txtDatePublished;
        private Label lblDateDrafted;
        private TextBox txtDateDrafted;
        private Label lblCuisine;
        private ComboBox lstUserName;
        private ComboBox lstCuisine;
        private TableLayoutPanel tblSaveandDelete;
        private Button btnSave;
        private Button btnDelete;
    }
}