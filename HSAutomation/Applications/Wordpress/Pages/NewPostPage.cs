using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace HSAutomation
{
    public class NewPostPage
    {
        public static object Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("editor-post-title__input"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }

        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public class CreatePostCommand
        {
            private readonly string title;
            private string body;

            public CreatePostCommand(string title)
            {
                this.title = title;
            }

            public CreatePostCommand WithBody(string body)
            {
                this.body = body;
                return this;
            }

            public void Publish()
            {
                var tipButton = Driver.Instance.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div/div/div/div[5]/div/div/div/div/button"));
                Driver.Wait(TimeSpan.FromSeconds(1));
                tipButton.Click();

                Driver.Instance.FindElement(By.Id("post-title-0")).SendKeys(title);
                Driver.Wait(TimeSpan.FromSeconds(1));

                var d = Driver.Instance.FindElements(By.ClassName("block-editor-block-list__layout"));
                var buttons = d.First().FindElements(By.TagName("button"));
                buttons.First().Click();
                var openedDiv = Driver.Instance.FindElements(By.ClassName("is-opened"));
                Driver.Wait(TimeSpan.FromSeconds(2));
                var insertParagraphButton = openedDiv.LastOrDefault().FindElements(By.TagName("button"));
                Driver.Wait(TimeSpan.FromSeconds(2));
                var p = insertParagraphButton.Where(x => x.Text == "Paragraph").ToList();
                p.LastOrDefault().Click();
                Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
                Driver.Wait(TimeSpan.FromSeconds(1));

                Driver.Instance.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div/div/div/div[1]/div[2]/button[2]")).Click();
                Driver.Instance.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div/div/div/div[3]/div/div/div[1]/div/button")).Click();
            }
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.Url.Contains("action=edit");
        }

        public static void GoToNewPost()
        {
            Driver.Wait(TimeSpan.FromSeconds(2));
            var message = Driver.Instance.FindElement(By.ClassName("components-notice__content"));
            var newPostLink = message.FindElements(By.TagName("a")).ToList().Where(x => x.Text == "View Post");
            newPostLink.LastOrDefault().Click();

        }
    }
}
