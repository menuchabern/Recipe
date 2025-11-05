namespace RecipeMAUI
{
    public partial class App : Application
    {
        public static bool LoggedIn = false;
        public static string ConnStringSetting = "Server=tcp:dev-mb.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
