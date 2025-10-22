using System.Configuration;

namespace RecipeWinForms
{
    public partial class frmLogin : Form
    {
        bool loginsuccess = false;
        public frmLogin()
        {
            InitializeComponent();
            txtUserId.Text = "appadmin";
            txtPassword.Text = "*PASsword123*";
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public bool ShowLogin()
        {
#if DEBUG
            this.Text = this.Text + " - LOCAL";
#endif
            this.ShowDialog();
            return loginsuccess;
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            try
            {
                string connstringkey = "";
#if DEBUG
                connstringkey = "localconn";
#else
                connstringkey = "azureconn";
#endif
                string connstring = ConfigurationManager.ConnectionStrings[connstringkey].ConnectionString;
                DBManager.SetConnectionString(connstring, true, txtUserId.Text, txtPassword.Text);
                loginsuccess = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid login. Try again.");
            }
        }
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
