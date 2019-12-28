using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSAutomation.Applications.Wordpress.WorkflowClasses
{
    public class PostCreater
    {
        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }
        public static bool CreatedAPost
        {
            get
            {
                return !String.IsNullOrEmpty(PreviousTitle);
            }
        }

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void Cleanup()
        {
            if (CreatedAPost)
                TrashPost();
        }

        private static void TrashPost()
        {
            ListPostsPage.TrashPost(PostCreater.PreviousTitle);
            Initialize();
        }

        public static void CreatePost()
        {
            NewPostPage.GoTo();
            //this will generate some dummy title.
            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }

        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }


        /// <summary>
        /// this creates a random string.
        /// </summary>
        /// <returns></returns>
        private static string CreateRandomString()
        {
            var s = new StringBuilder();
            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }
            return s.ToString();
        }

        private static string[] Words = new[] { "boy", "cat", "dog", "rabbit", "baseball", "throw", "find", "scary", "musturd" };

        private static string[] Articles = new[] { "the", "a", "an", "and", "of", "to", "it", "as", "for" };
    }
}
