using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HSAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Wordpress.Url);
            //wait to a max of 10 seconds
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");
        }

        public static void LoginAs(string userName, string password)
        {
            LoginAs(userName).WithPassword(password).Login();
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public void Login()
        {
            //Now we need to use the driver instance here. for that we need driver as global or as a singleton instance ao that
            // we can access same instance of our driver.

            //For login to work we need to type the userame and password and the click the login button.

            //https://s1.demo.opensourcecms.com/wordpress/wp-login.php
            //username: opensourcecms
            //password: opensourcecms
            var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
            loginInput.SendKeys(userName);
            var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
            passwordInput.SendKeys(password);
            var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
            loginButton.Click();
        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }
    }
}
