namespace RecipeWinForms
{
    partial class frmChangeStatus
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
            lblRecipeName = new Label();
            lblCurrentStatus = new Label();
            tblButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            tblDates = new TableLayoutPanel();
            lblStatusDates = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            lblRecipeStatus = new Label();
            tableLayoutPanel1.SuspendLayout();
            tblButtons.SuspendLayout();
            tblDates.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblRecipeName, 0, 0);
            tableLayoutPanel1.Controls.Add(lblCurrentStatus, 0, 1);
            tableLayoutPanel1.Controls.Add(tblButtons, 0, 3);
            tableLayoutPanel1.Controls.Add(tblDates, 0, 2);
            tableLayoutPanel1.Controls.Add(lblRecipeStatus, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.0653458F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.0261383F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 36.9085159F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(751, 705);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblRecipeName, 2);
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Font = new Font("Segoe UI", 20F);
            lblRecipeName.Location = new Point(4, 0);
            lblRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(743, 253);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentStatus.Location = new Point(4, 253);
            lblCurrentStatus.Margin = new Padding(4, 0, 4, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(367, 101);
            lblCurrentStatus.TabIndex = 1;
            lblCurrentStatus.Text = "Current Status -";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tblButtons, 2);
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.Controls.Add(btnDraft, 0, 0);
            tblButtons.Controls.Add(btnPublish, 1, 0);
            tblButtons.Controls.Add(btnArchive, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 564);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tblButtons.Size = new Size(745, 138);
            tblButtons.TabIndex = 2;
            // 
            // btnDraft
            // 
            btnDraft.AutoSize = true;
            btnDraft.Dock = DockStyle.Fill;
            btnDraft.Location = new Point(3, 3);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(242, 132);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.AutoSize = true;
            btnPublish.Dock = DockStyle.Fill;
            btnPublish.Location = new Point(251, 3);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(242, 132);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.AutoSize = true;
            btnArchive.Dock = DockStyle.Fill;
            btnArchive.Location = new Point(499, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(243, 132);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 5;
            tableLayoutPanel1.SetColumnSpan(tblDates, 2);
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tblDates.Controls.Add(lblStatusDates, 0, 1);
            tblDates.Controls.Add(lblDrafted, 1, 0);
            tblDates.Controls.Add(lblPublished, 2, 0);
            tblDates.Controls.Add(lblArchived, 3, 0);
            tblDates.Controls.Add(txtDateDrafted, 1, 1);
            tblDates.Controls.Add(txtDatePublished, 2, 1);
            tblDates.Controls.Add(txtDateArchived, 3, 1);
            tblDates.Dock = DockStyle.Fill;
            tblDates.Location = new Point(3, 357);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 2;
            tblDates.RowStyles.Add(new RowStyle());
            tblDates.RowStyles.Add(new RowStyle());
            tblDates.Size = new Size(745, 201);
            tblDates.TabIndex = 3;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Location = new Point(3, 28);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(206, 173);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(215, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(100, 28);
            lblDrafted.TabIndex = 1;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(321, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(100, 28);
            lblPublished.TabIndex = 2;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(427, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(100, 28);
            lblArchived.TabIndex = 3;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.BottomCenter;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDateDrafted.Location = new Point(215, 31);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.ReadOnly = true;
            txtDateDrafted.Size = new Size(100, 34);
            txtDateDrafted.TabIndex = 4;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDatePublished.Location = new Point(321, 31);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.ReadOnly = true;
            txtDatePublished.Size = new Size(100, 34);
            txtDatePublished.TabIndex = 5;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDateArchived.Location = new Point(427, 31);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.ReadOnly = true;
            txtDateArchived.Size = new Size(100, 34);
            txtDateArchived.TabIndex = 6;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Dock = DockStyle.Fill;
            lblRecipeStatus.Font = new Font("Segoe UI", 15F);
            lblRecipeStatus.Location = new Point(378, 253);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(370, 101);
            lblRecipeStatus.TabIndex = 4;
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmChangeStatus
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 705);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmChangeStatus";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            tblDates.ResumeLayout(false);
            tblDates.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblRecipeName;
        private Label lblCurrentStatus;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
        private TableLayoutPanel tblDates;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private Label lblRecipeStatus;
    }
}