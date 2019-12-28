using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSAutomation
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create a generalize IsAt for all pages
                var h2s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Dashboard";
                return false;
            }
        }
    }
}
