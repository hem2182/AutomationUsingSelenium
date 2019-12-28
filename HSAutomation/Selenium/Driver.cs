using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace HSAutomation
{
    public class Driver
    {
        /// <summary>
        /// return type is IWebDriver because it doesn't have to be firefox
        /// </summary>
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver(@"C:\Code\HSAutomation\HSAutomation\bin\Debug\");
            TurnOnWait();
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int) (timeSpan.TotalSeconds * 1000));
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();

        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}