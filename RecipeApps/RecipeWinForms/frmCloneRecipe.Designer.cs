namespace RecipeWinForms
{
    partial class frmCloneRecipe
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
            lstRecipeName = new ComboBox();
            btnClone = new Button();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lstRecipeName, 0, 0);
            tblMain.Controls.Add(btnClone, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 305F));
            tblMain.Size = new Size(803, 507);
            tblMain.TabIndex = 0;
            // 
            // lstRecipeName
            // 
            lstRecipeName.Anchor = AnchorStyles.Left;
            lstRecipeName.FormattingEnabled = true;
            lstRecipeName.Location = new Point(4, 87);
            lstRecipeName.Margin = new Padding(4);
            lstRecipeName.Name = "lstRecipeName";
            lstRecipeName.Size = new Size(608, 36);
            lstRecipeName.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Anchor = AnchorStyles.None;
            btnClone.AutoSize = true;
            btnClone.Location = new Point(326, 320);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(150, 69);
            btnClone.TabIndex = 1;
            btnClone.Text = "Clone";
            btnClone.UseVisualStyleBackColor = true;
            // 
            // frmCloneRecipe
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 507);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmCloneRecipe";
            Text = "Clone a Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstRecipeName;
        private Button btnClone;
    }
}