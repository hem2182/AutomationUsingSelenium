

namespace HSAutomation
{
    public static class Wordpress
    {
        public static string Url
        {
            get { return "https://s1.demo.opensourcecms.com/wordpress/wp-login.php"; }
        }

        public static void StartApplication()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("opensourcecms", "opensourcecms");
        }

        public static void StartApplication(string userName, string password)
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(userName, password);
        }

    }
}
