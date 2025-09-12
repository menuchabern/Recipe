namespace RecipeWinForms
{
    partial class frmCookbookList
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
            btnNewCookbook = new Button();
            gCookbookList = new DataGridView();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(btnNewCookbook, 0, 0);
            tblMain.Controls.Add(gCookbookList, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4, 4, 4, 4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(1100, 630);
            tblMain.TabIndex = 0;
            // 
            // btnNewCookbook
            // 
            btnNewCookbook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnNewCookbook.AutoSize = true;
            btnNewCookbook.Location = new Point(4, 4);
            btnNewCookbook.Margin = new Padding(4, 4, 4, 4);
            btnNewCookbook.Name = "btnNewCookbook";
            btnNewCookbook.Size = new Size(166, 42);
            btnNewCookbook.TabIndex = 0;
            btnNewCookbook.Text = "New Cookbook";
            btnNewCookbook.UseVisualStyleBackColor = true;
            // 
            // gCookbookList
            // 
            gCookbookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookList.Dock = DockStyle.Fill;
            gCookbookList.Location = new Point(4, 54);
            gCookbookList.Margin = new Padding(4, 4, 4, 4);
            gCookbookList.Name = "gCookbookList";
            gCookbookList.RowHeadersWidth = 51;
            gCookbookList.Size = new Size(1092, 572);
            gCookbookList.TabIndex = 1;
            // 
            // frmCookbookList
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmCookbookList";
            Text = "Cookbook List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnNewCookbook;
        private DataGridView gCookbookList;
    }
}