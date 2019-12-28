using HSAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmokeTests
{
    [TestClass]
    public class PageTests : SmokeTestsBase
    {
        [TestMethod]
        public void CanEditAPage()
        {
            Wordpress.StartApplication();
            
            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Page not in Edit Mode.");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");

        }

    }
}
