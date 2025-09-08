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
            tblDates = new TableLayoutPanel();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            tblSaveandDelete = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblRecipeName = new Label();
            lblUserName = new Label();
            txtRecipeName = new TextBox();
            lstUserName = new ComboBox();
            lblCuisine = new Label();
            lstCuisine = new ComboBox();
            lblStatus = new Label();
            lblCalories = new Label();
            txtRecipeStatus = new TextBox();
            txtCalories = new TextBox();
            lblStatusDates = new Label();
            btnChangeStatus = new Button();
            tbMain = new TabControl();
            tbpIngredients = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnIngredientsSave = new Button();
            gIngredients = new DataGridView();
            tbpSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnStepsSave = new Button();
            gSteps = new DataGridView();
            tblMain.SuspendLayout();
            tblDates.SuspendLayout();
            tblSaveandDelete.SuspendLayout();
            tbMain.SuspendLayout();
            tbpIngredients.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbpSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(tblDates, 1, 6);
            tblMain.Controls.Add(tblSaveandDelete, 0, 0);
            tblMain.Controls.Add(lblRecipeName, 0, 1);
            tblMain.Controls.Add(lblUserName, 0, 2);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(lblCuisine, 0, 3);
            tblMain.Controls.Add(lstCuisine, 1, 3);
            tblMain.Controls.Add(lblStatus, 0, 5);
            tblMain.Controls.Add(lblCalories, 0, 4);
            tblMain.Controls.Add(txtRecipeStatus, 1, 5);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lblStatusDates, 0, 6);
            tblMain.Controls.Add(btnChangeStatus, 1, 0);
            tblMain.Controls.Add(tbMain, 0, 7);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 8;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(612, 622);
            tblMain.TabIndex = 0;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 3;
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblDates.Controls.Add(lblDrafted, 0, 0);
            tblDates.Controls.Add(lblPublished, 1, 0);
            tblDates.Controls.Add(lblArchived, 2, 0);
            tblDates.Controls.Add(txtDateDrafted, 0, 1);
            tblDates.Controls.Add(txtDatePublished, 1, 1);
            tblDates.Controls.Add(txtDateArchived, 2, 1);
            tblDates.Dock = DockStyle.Fill;
            tblDates.Location = new Point(309, 289);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 2;
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.RowStyles.Add(new RowStyle());
            tblDates.Size = new Size(300, 74);
            tblDates.TabIndex = 23;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Font = new Font("Segoe UI", 12F);
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(94, 34);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Font = new Font("Segoe UI", 12F);
            lblPublished.Location = new Point(103, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(94, 34);
            lblPublished.TabIndex = 1;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Font = new Font("Segoe UI", 12F);
            lblArchived.Location = new Point(203, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(94, 34);
            lblArchived.TabIndex = 2;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.BackColor = SystemColors.ActiveBorder;
            txtDateDrafted.Dock = DockStyle.Fill;
            txtDateDrafted.Font = new Font("Segoe UI", 12F);
            txtDateDrafted.Location = new Point(3, 37);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.ReadOnly = true;
            txtDateDrafted.Size = new Size(94, 34);
            txtDateDrafted.TabIndex = 0;
            // 
            // txtDatePublished
            // 
            txtDatePublished.BackColor = SystemColors.ActiveBorder;
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Font = new Font("Segoe UI", 12F);
            txtDatePublished.Location = new Point(103, 37);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.ReadOnly = true;
            txtDatePublished.Size = new Size(94, 34);
            txtDatePublished.TabIndex = 1;
            // 
            // txtDateArchived
            // 
            txtDateArchived.BackColor = SystemColors.ActiveBorder;
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Font = new Font("Segoe UI", 12F);
            txtDateArchived.Location = new Point(203, 37);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.ReadOnly = true;
            txtDateArchived.Size = new Size(94, 34);
            txtDateArchived.TabIndex = 2;
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
            tblSaveandDelete.Location = new Point(3, 3);
            tblSaveandDelete.Name = "tblSaveandDelete";
            tblSaveandDelete.RowCount = 1;
            tblSaveandDelete.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblSaveandDelete.Size = new Size(300, 94);
            tblSaveandDelete.TabIndex = 20;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 88);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(153, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(144, 88);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Font = new Font("Segoe UI", 12F);
            lblRecipeName.Location = new Point(3, 104);
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
            lblUserName.Location = new Point(3, 141);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(108, 28);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "User Name";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Font = new Font("Microsoft Sans Serif", 12F);
            txtRecipeName.Location = new Point(309, 103);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(290, 30);
            txtRecipeName.TabIndex = 0;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Left;
            lstUserName.Font = new Font("Microsoft Sans Serif", 12F);
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(309, 139);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(290, 33);
            lstUserName.TabIndex = 1;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Font = new Font("Segoe UI", 12F);
            lblCuisine.Location = new Point(3, 180);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(74, 28);
            lblCuisine.TabIndex = 8;
            lblCuisine.Text = "Cuisine";
            // 
            // lstCuisine
            // 
            lstCuisine.Anchor = AnchorStyles.Left;
            lstCuisine.Font = new Font("Microsoft Sans Serif", 12F);
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(309, 178);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(290, 33);
            lstCuisine.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(3, 254);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(135, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Current Status";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Font = new Font("Segoe UI", 12F);
            lblCalories.Location = new Point(3, 218);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(81, 28);
            lblCalories.TabIndex = 2;
            lblCalories.Text = "Calories";
            lblCalories.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Anchor = AnchorStyles.Left;
            txtRecipeStatus.BackColor = SystemColors.ActiveBorder;
            txtRecipeStatus.Font = new Font("Microsoft Sans Serif", 12F);
            txtRecipeStatus.Location = new Point(309, 253);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.ReadOnly = true;
            txtRecipeStatus.Size = new Size(239, 30);
            txtRecipeStatus.TabIndex = 4;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left;
            txtCalories.Font = new Font("Microsoft Sans Serif", 12F);
            txtCalories.Location = new Point(309, 217);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(290, 30);
            txtCalories.TabIndex = 3;
            // 
            // lblStatusDates
            // 
            lblStatusDates.Anchor = AnchorStyles.Left;
            lblStatusDates.AutoSize = true;
            lblStatusDates.Font = new Font("Segoe UI", 12F);
            lblStatusDates.Location = new Point(3, 312);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(119, 28);
            lblStatusDates.TabIndex = 10;
            lblStatusDates.Text = "Status Dates";
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Right;
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Font = new Font("Segoe UI", 12F);
            btnChangeStatus.Location = new Point(463, 16);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(146, 67);
            btnChangeStatus.TabIndex = 7;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // tbMain
            // 
            tblMain.SetColumnSpan(tbMain, 2);
            tbMain.Controls.Add(tbpIngredients);
            tbMain.Controls.Add(tbpSteps);
            tbMain.Dock = DockStyle.Fill;
            tbMain.Font = new Font("Segoe UI", 12F);
            tbMain.Location = new Point(3, 369);
            tbMain.Name = "tbMain";
            tbMain.SelectedIndex = 0;
            tbMain.Size = new Size(606, 250);
            tbMain.TabIndex = 6;
            // 
            // tbpIngredients
            // 
            tbpIngredients.Controls.Add(tableLayoutPanel1);
            tbpIngredients.Location = new Point(4, 37);
            tbpIngredients.Name = "tbpIngredients";
            tbpIngredients.Padding = new Padding(3);
            tbpIngredients.Size = new Size(598, 209);
            tbpIngredients.TabIndex = 0;
            tbpIngredients.Text = "Ingredients";
            tbpIngredients.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnIngredientsSave, 0, 0);
            tableLayoutPanel1.Controls.Add(gIngredients, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(592, 203);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnIngredientsSave
            // 
            btnIngredientsSave.AutoSize = true;
            btnIngredientsSave.Location = new Point(3, 3);
            btnIngredientsSave.Name = "btnIngredientsSave";
            btnIngredientsSave.Size = new Size(94, 38);
            btnIngredientsSave.TabIndex = 0;
            btnIngredientsSave.Text = "Save";
            btnIngredientsSave.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 47);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 51;
            gIngredients.Size = new Size(586, 153);
            gIngredients.TabIndex = 1;
            // 
            // tbpSteps
            // 
            tbpSteps.Controls.Add(tblSteps);
            tbpSteps.Location = new Point(4, 37);
            tbpSteps.Name = "tbpSteps";
            tbpSteps.Padding = new Padding(3);
            tbpSteps.Size = new Size(598, 209);
            tbpSteps.TabIndex = 1;
            tbpSteps.Text = "Steps";
            tbpSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSteps.Controls.Add(btnStepsSave, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblSteps.Size = new Size(592, 203);
            tblSteps.TabIndex = 0;
            // 
            // btnStepsSave
            // 
            btnStepsSave.AutoSize = true;
            btnStepsSave.Location = new Point(3, 3);
            btnStepsSave.Name = "btnStepsSave";
            btnStepsSave.Size = new Size(94, 38);
            btnStepsSave.TabIndex = 0;
            btnStepsSave.Text = "Save";
            btnStepsSave.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 47);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 51;
            gSteps.Size = new Size(586, 153);
            gSteps.TabIndex = 1;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 622);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblDates.ResumeLayout(false);
            tblDates.PerformLayout();
            tblSaveandDelete.ResumeLayout(false);
            tblSaveandDelete.PerformLayout();
            tbMain.ResumeLayout(false);
            tbpIngredients.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tbpSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            tblSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
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
        private Label lblStatusDates;
        private Label lblCuisine;
        private ComboBox lstUserName;
        private ComboBox lstCuisine;
        private TableLayoutPanel tblDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TableLayoutPanel tblSaveandDelete;
        private Button btnSave;
        private Button btnDelete;
        private Button btnChangeStatus;
        private TabControl tbMain;
        private TabPage tbpIngredients;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnIngredientsSave;
        private DataGridView gIngredients;
        private TabPage tbpSteps;
        private TableLayoutPanel tblSteps;
        private Button btnStepsSave;
        private DataGridView gSteps;
    }
}