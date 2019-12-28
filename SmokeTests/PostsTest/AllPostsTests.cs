using HSAutomation;
using HSAutomation.Applications.Wordpress.WorkflowClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmokeTests.PostsTest
{
    [TestClass]
    public class AllPostsTests : SmokeTestsBase
    {
        [TestMethod]
        public void AddedPostShowUpInAllPosts()
        {
            Wordpress.StartApplication();
            //Go to posts, get post count and store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StorePostsCount();

            //Add a new post
            PostCreater.CreatePost();

            //Go to posts, get new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not match");

            //Check for added posts
            Assert.IsTrue(ListPostsPage.DoesPostExistsWithTitle(PostCreater.PreviousTitle), "");

            //Trash Post (Clean up)
            ListPostsPage.TrashPost(PostCreater.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void CanSearchPosts()
        {
            Wordpress.StartApplication();
            //Add a new post
            PostCreater.CreatePost();

            //Search for posts
            ListPostsPage.SearchForPost(PostCreater.PreviousTitle);

            //check for post up in the results
            Assert.IsTrue(ListPostsPage.DoesPostExistsWithTitle(PostCreater.PreviousTitle));

            
        }

        [TestMethod]
        public void CreatePostUsingWorkflow()
        {
            Wordpress.StartApplication();
            //Go to posts, get post count and store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StorePostsCount();

            //Add a new post
            PostCreater.CreatePost();

            //Go to posts, get new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not match");

            //Check for added posts
            Assert.IsTrue(ListPostsPage.DoesPostExistsWithTitle(PostCreater.PreviousTitle), "");

            //Trash Post (Clean up)
            ListPostsPage.TrashPost(PostCreater.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }

    }
}
