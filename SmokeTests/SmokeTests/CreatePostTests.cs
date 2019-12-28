using HSAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmokeTests
{
    [TestClass]
    public class CreatePostTests: SmokeTestsBase
    {
        [TestMethod]
        public void CanCreateABasicPost()
        {
            Wordpress.StartApplication();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").WithBody("Hi, this is the body").Publish();
            NewPostPage.GoToNewPost();
            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match");
        }
    }
}
