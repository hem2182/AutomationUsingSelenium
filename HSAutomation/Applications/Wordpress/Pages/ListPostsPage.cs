using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HSAutomation
{
    public class ListPostsPage
    {
        private static int lastCount;

        public static int PreviousPostCount { get { return lastCount; } }

        public static int CurrentPostCount { get { return GetPostCount(); } }

        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create a generalize IsAt for all pages
                var h2s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Posts";
                return false;
            }
        }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            Driver.Instance.FindElement(By.LinkText("Sample Page")).Click();
        }

        public static void StorePostsCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                //Doing no wait above lets the below code execute without waiting.
                if (links.Count > 0)
                {
                    //this is the part where we need to hover over the row to see the options for the element
                    //once we hover over then only we can see the trash and other actions.
                    //so we hover first and then find the trash action element and then click it. 
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }
        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
                GoTo(PostType.Posts);

            Driver.Instance.FindElement(By.Id("post-search-input")).SendKeys(searchString);
            Driver.Instance.FindElement(By.Id("search-submit")).Click();
        }

        public static bool DoesPostExistsWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
