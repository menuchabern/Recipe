namespace RecipeWinForms
{
    partial class frmCookbook
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblCookbookName = new Label();
            lblUserName = new Label();
            lblPrice = new Label();
            lblActive = new Label();
            txtCookbookName = new TextBox();
            lstUserName = new ComboBox();
            tblNested = new TableLayoutPanel();
            txtPrice = new TextBox();
            lblDateCreated = new Label();
            txtDateCreated = new TextBox();
            ckbActiveStatus = new CheckBox();
            tblRecipes = new TableLayoutPanel();
            lblLine = new Label();
            btnSaveRecipes = new Button();
            gRecipes = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tblNested.SuspendLayout();
            tblRecipes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.6713848F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.32861F));
            tableLayoutPanel1.Controls.Add(btnSave, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDelete, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCookbookName, 0, 1);
            tableLayoutPanel1.Controls.Add(lblUserName, 0, 2);
            tableLayoutPanel1.Controls.Add(lblPrice, 0, 3);
            tableLayoutPanel1.Controls.Add(lblActive, 0, 4);
            tableLayoutPanel1.Controls.Add(txtCookbookName, 1, 1);
            tableLayoutPanel1.Controls.Add(lstUserName, 1, 2);
            tableLayoutPanel1.Controls.Add(tblNested, 1, 3);
            tableLayoutPanel1.Controls.Add(ckbActiveStatus, 1, 4);
            tableLayoutPanel1.Controls.Add(tblRecipes, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.Size = new Size(773, 621);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.AutoSize = true;
            btnSave.Location = new Point(48, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left;
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(193, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 38);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCookbookName
            // 
            lblCookbookName.AutoSize = true;
            lblCookbookName.Location = new Point(20, 64);
            lblCookbookName.Margin = new Padding(20, 20, 3, 0);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(161, 28);
            lblCookbookName.TabIndex = 2;
            lblCookbookName.Text = "Cookbook Name";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(20, 112);
            lblUserName.Margin = new Padding(20, 20, 3, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(108, 28);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "User Name";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 183);
            lblPrice.Margin = new Padding(20, 20, 3, 5);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 28);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(20, 236);
            lblActive.Margin = new Padding(20, 20, 3, 5);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(66, 28);
            lblActive.TabIndex = 5;
            lblActive.Text = "Active";
            // 
            // txtCookbookName
            // 
            txtCookbookName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtCookbookName.Location = new Point(193, 55);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(481, 34);
            txtCookbookName.TabIndex = 2;
            // 
            // lstUserName
            // 
            lstUserName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(193, 109);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(481, 36);
            lstUserName.TabIndex = 3;
            // 
            // tblNested
            // 
            tblNested.ColumnCount = 2;
            tblNested.ColumnStyles.Add(new ColumnStyle());
            tblNested.ColumnStyles.Add(new ColumnStyle());
            tblNested.Controls.Add(txtPrice, 0, 1);
            tblNested.Controls.Add(lblDateCreated, 1, 0);
            tblNested.Controls.Add(txtDateCreated, 1, 1);
            tblNested.Dock = DockStyle.Fill;
            tblNested.Location = new Point(193, 143);
            tblNested.Name = "tblNested";
            tblNested.RowCount = 2;
            tblNested.RowStyles.Add(new RowStyle());
            tblNested.RowStyles.Add(new RowStyle());
            tblNested.Size = new Size(577, 70);
            tblNested.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtPrice.Location = new Point(3, 31);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(170, 34);
            txtPrice.TabIndex = 1;
            // 
            // lblDateCreated
            // 
            lblDateCreated.Anchor = AnchorStyles.Top;
            lblDateCreated.AutoSize = true;
            lblDateCreated.Location = new Point(313, 0);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(126, 28);
            lblDateCreated.TabIndex = 1;
            lblDateCreated.Text = "Date Created";
            // 
            // txtDateCreated
            // 
            txtDateCreated.Anchor = AnchorStyles.Top;
            txtDateCreated.BackColor = Color.Gray;
            txtDateCreated.Location = new Point(292, 31);
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.ReadOnly = true;
            txtDateCreated.Size = new Size(168, 34);
            txtDateCreated.TabIndex = 2;
            // 
            // ckbActiveStatus
            // 
            ckbActiveStatus.Dock = DockStyle.Fill;
            ckbActiveStatus.Font = new Font("Segoe UI", 20F);
            ckbActiveStatus.Location = new Point(193, 219);
            ckbActiveStatus.Name = "ckbActiveStatus";
            ckbActiveStatus.Size = new Size(577, 47);
            ckbActiveStatus.TabIndex = 5;
            ckbActiveStatus.UseVisualStyleBackColor = true;
            // 
            // tblRecipes
            // 
            tblRecipes.ColumnCount = 1;
            tableLayoutPanel1.SetColumnSpan(tblRecipes, 2);
            tblRecipes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRecipes.Controls.Add(lblLine, 0, 0);
            tblRecipes.Controls.Add(btnSaveRecipes, 0, 1);
            tblRecipes.Controls.Add(gRecipes, 0, 2);
            tblRecipes.Dock = DockStyle.Fill;
            tblRecipes.Location = new Point(3, 272);
            tblRecipes.Name = "tblRecipes";
            tblRecipes.RowCount = 3;
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
            tblRecipes.RowStyles.Add(new RowStyle());
            tblRecipes.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tblRecipes.Size = new Size(767, 346);
            tblRecipes.TabIndex = 10;
            // 
            // lblLine
            // 
            lblLine.AutoSize = true;
            lblLine.BorderStyle = BorderStyle.Fixed3D;
            lblLine.Dock = DockStyle.Fill;
            lblLine.Location = new Point(3, 0);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(761, 2);
            lblLine.TabIndex = 0;
            // 
            // btnSaveRecipes
            // 
            btnSaveRecipes.AutoSize = true;
            btnSaveRecipes.Location = new Point(3, 5);
            btnSaveRecipes.Name = "btnSaveRecipes";
            btnSaveRecipes.Size = new Size(94, 38);
            btnSaveRecipes.TabIndex = 1;
            btnSaveRecipes.Text = "Save";
            btnSaveRecipes.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 49);
            gRecipes.Name = "gRecipes";
            gRecipes.RowHeadersWidth = 51;
            gRecipes.Size = new Size(761, 294);
            gRecipes.TabIndex = 2;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 621);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmCookbook";
            Text = "Cookbook";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tblNested.ResumeLayout(false);
            tblNested.PerformLayout();
            tblRecipes.ResumeLayout(false);
            tblRecipes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbookName;
        private Label lblUserName;
        private Label lblPrice;
        private Label lblActive;
        private TextBox txtCookbookName;
        private ComboBox lstUserName;
        private TableLayoutPanel tblNested;
        private TextBox txtPrice;
        private Label lblDateCreated;
        private TextBox txtDateCreated;
        private CheckBox ckbActiveStatus;
        private TableLayoutPanel tblRecipes;
        private Label lblLine;
        private Button btnSaveRecipes;
        private DataGridView gRecipes;
    }
}