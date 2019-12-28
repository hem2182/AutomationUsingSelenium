using HSAutomation;
using HSAutomation.Applications.Wordpress.WorkflowClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmokeTests
{
    public class SmokeTestsBase
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            PostCreater.Initialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            PostCreater.Cleanup();
            Driver.Close();

        }
    }
}
