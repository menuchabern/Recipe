namespace RecipeWinForms
{
    partial class frmDashboard
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
            gData = new DataGridView();
            lblHeartyHearth = new Label();
            lblWelcometo = new Label();
            tblButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(gData, 0, 2);
            tblMain.Controls.Add(lblHeartyHearth, 0, 0);
            tblMain.Controls.Add(lblWelcometo, 0, 1);
            tblMain.Controls.Add(tblButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(736, 653);
            tblMain.TabIndex = 0;
            // 
            // gData
            // 
            gData.Anchor = AnchorStyles.None;
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Location = new Point(10, 201);
            gData.Margin = new Padding(4);
            gData.Name = "gData";
            gData.RowHeadersWidth = 51;
            gData.Size = new Size(716, 342);
            gData.TabIndex = 2;
            // 
            // lblHeartyHearth
            // 
            lblHeartyHearth.AutoSize = true;
            lblHeartyHearth.Dock = DockStyle.Fill;
            lblHeartyHearth.Font = new Font("Segoe UI", 18F);
            lblHeartyHearth.Location = new Point(3, 40);
            lblHeartyHearth.Margin = new Padding(3, 40, 3, 40);
            lblHeartyHearth.Name = "lblHeartyHearth";
            lblHeartyHearth.Size = new Size(730, 41);
            lblHeartyHearth.TabIndex = 3;
            lblHeartyHearth.Text = "Hearty Hearth Desktop App";
            lblHeartyHearth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcometo
            // 
            lblWelcometo.AutoSize = true;
            lblWelcometo.Dock = DockStyle.Fill;
            lblWelcometo.Location = new Point(30, 121);
            lblWelcometo.Margin = new Padding(30, 0, 30, 20);
            lblWelcometo.Name = "lblWelcometo";
            lblWelcometo.Size = new Size(676, 56);
            lblWelcometo.TabIndex = 4;
            lblWelcometo.Text = "Welcome to the Hearty Hearth desktop app. In this app you can create recipes and cookbooks. You can also...";
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tblButtons.Controls.Add(btnRecipeList, 0, 0);
            tblButtons.Controls.Add(btnMealList, 1, 0);
            tblButtons.Controls.Add(btnCookbookList, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 550);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblButtons.Size = new Size(730, 100);
            tblButtons.TabIndex = 5;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Dock = DockStyle.Fill;
            btnRecipeList.Location = new Point(3, 3);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(237, 94);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.AutoSize = true;
            btnMealList.Dock = DockStyle.Fill;
            btnMealList.Location = new Point(246, 3);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(237, 94);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "MealList";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Dock = DockStyle.Fill;
            btnCookbookList.Location = new Point(489, 3);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(238, 94);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 653);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gData;
        private Label lblHeartyHearth;
        private Label lblWelcometo;
        private TableLayoutPanel tblButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
    }
}