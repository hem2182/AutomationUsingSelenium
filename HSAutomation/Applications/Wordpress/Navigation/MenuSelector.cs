using OpenQA.Selenium;

namespace HSAutomation
{
    internal class MenuSelector
    {
        internal static void Select(string topLevelMenuId, string subLevelLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
            Driver.Instance.FindElement(By.LinkText(subLevelLinkText)).Click();
        }
    }
}