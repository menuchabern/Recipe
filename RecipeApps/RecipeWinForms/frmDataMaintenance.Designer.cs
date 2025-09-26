namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            pnlRadioButtons = new FlowLayoutPanel();
            rdbUsers = new RadioButton();
            rdbCuisines = new RadioButton();
            rdbIngredients = new RadioButton();
            rdbMeasurements = new RadioButton();
            rdbCourses = new RadioButton();
            btnSave = new Button();
            gMain = new DataGridView();
            tblMain.SuspendLayout();
            pnlRadioButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gMain).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(pnlRadioButtons, 0, 0);
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Controls.Add(gMain, 1, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4, 4, 4, 4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 88.3858261F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(853, 508);
            tblMain.TabIndex = 0;
            // 
            // pnlRadioButtons
            // 
            pnlRadioButtons.AutoSize = true;
            pnlRadioButtons.Controls.Add(rdbUsers);
            pnlRadioButtons.Controls.Add(rdbCuisines);
            pnlRadioButtons.Controls.Add(rdbIngredients);
            pnlRadioButtons.Controls.Add(rdbMeasurements);
            pnlRadioButtons.Controls.Add(rdbCourses);
            pnlRadioButtons.Dock = DockStyle.Fill;
            pnlRadioButtons.FlowDirection = FlowDirection.TopDown;
            pnlRadioButtons.Location = new Point(4, 4);
            pnlRadioButtons.Margin = new Padding(4, 4, 4, 4);
            pnlRadioButtons.Name = "pnlRadioButtons";
            tblMain.SetRowSpan(pnlRadioButtons, 2);
            pnlRadioButtons.Size = new Size(200, 500);
            pnlRadioButtons.TabIndex = 0;
            // 
            // rdbUsers
            // 
            rdbUsers.AutoSize = true;
            rdbUsers.Checked = true;
            rdbUsers.Location = new Point(20, 4);
            rdbUsers.Margin = new Padding(20, 4, 4, 7);
            rdbUsers.Name = "rdbUsers";
            rdbUsers.Size = new Size(80, 32);
            rdbUsers.TabIndex = 0;
            rdbUsers.TabStop = true;
            rdbUsers.Text = "Users";
            rdbUsers.UseVisualStyleBackColor = true;
            // 
            // rdbCuisines
            // 
            rdbCuisines.AutoSize = true;
            rdbCuisines.Location = new Point(20, 47);
            rdbCuisines.Margin = new Padding(20, 4, 4, 7);
            rdbCuisines.Name = "rdbCuisines";
            rdbCuisines.Size = new Size(103, 32);
            rdbCuisines.TabIndex = 1;
            rdbCuisines.Text = "Cuisines";
            rdbCuisines.UseVisualStyleBackColor = true;
            // 
            // rdbIngredients
            // 
            rdbIngredients.AutoSize = true;
            rdbIngredients.Location = new Point(20, 90);
            rdbIngredients.Margin = new Padding(20, 4, 4, 7);
            rdbIngredients.Name = "rdbIngredients";
            rdbIngredients.Size = new Size(131, 32);
            rdbIngredients.TabIndex = 2;
            rdbIngredients.Text = "Ingredients";
            rdbIngredients.UseVisualStyleBackColor = true;
            // 
            // rdbMeasurements
            // 
            rdbMeasurements.AutoSize = true;
            rdbMeasurements.Location = new Point(20, 133);
            rdbMeasurements.Margin = new Padding(20, 4, 20, 7);
            rdbMeasurements.Name = "rdbMeasurements";
            rdbMeasurements.Size = new Size(160, 32);
            rdbMeasurements.TabIndex = 3;
            rdbMeasurements.Text = "Measurements";
            rdbMeasurements.UseVisualStyleBackColor = true;
            // 
            // rdbCourses
            // 
            rdbCourses.AutoSize = true;
            rdbCourses.Location = new Point(20, 176);
            rdbCourses.Margin = new Padding(20, 4, 4, 7);
            rdbCourses.Name = "rdbCourses";
            rdbCourses.Size = new Size(101, 32);
            rdbCourses.TabIndex = 4;
            rdbCourses.Text = "Courses";
            rdbCourses.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.Location = new Point(721, 451);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 54);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // gMain
            // 
            gMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gMain.Dock = DockStyle.Fill;
            gMain.Location = new Point(211, 3);
            gMain.Name = "gMain";
            gMain.RowHeadersWidth = 51;
            gMain.Size = new Size(639, 442);
            gMain.TabIndex = 2;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 508);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            pnlRadioButtons.ResumeLayout(false);
            pnlRadioButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private FlowLayoutPanel pnlRadioButtons;
        private RadioButton rdbUsers;
        private RadioButton rdbCuisines;
        private RadioButton rdbIngredients;
        private RadioButton rdbMeasurements;
        private RadioButton rdbCourses;
        private Button btnSave;
        private DataGridView gMain;
    }
}