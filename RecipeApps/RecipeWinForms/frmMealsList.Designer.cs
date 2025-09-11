namespace RecipeWinForms
{
    partial class frmMealsList
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
            gMeals = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gMeals).BeginInit();
            SuspendLayout();
            // 
            // gMeals
            // 
            gMeals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gMeals.Dock = DockStyle.Fill;
            gMeals.Location = new Point(0, 0);
            gMeals.Margin = new Padding(10);
            gMeals.Name = "gMeals";
            gMeals.RowHeadersWidth = 51;
            gMeals.Size = new Size(800, 450);
            gMeals.TabIndex = 0;
            // 
            // frmMealsList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gMeals);
            Name = "frmMealsList";
            Text = "Meal List";
            ((System.ComponentModel.ISupportInitialize)gMeals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gMeals;
    }
}