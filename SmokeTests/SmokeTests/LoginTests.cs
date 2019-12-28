using HSAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmokeTests
{
    [TestClass]
    public class LoginTests : SmokeTestsBase
    {
        [TestMethod]
        public void TestLogin()
        {
            Wordpress.StartApplication("opensourcecms", "opensourcecms");
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}
