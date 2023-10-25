namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;

    using Tests.Shared.Admin.Userstories;

    [TestClass]
    public class AddStep : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            var addedIntegration = Shared.Admin.Scope.Features.C.addedIntegration;

            Run<AddUserstory>();

            U.OpenFeatures(this);
            Thread.Sleep(5000);
            U.AddIntegration(this, addedIntegration);
            U.OpenUserstories(this);
            Thread.Sleep(2000);


            U.ScrollToBottom(this, C.scrollable_mainContent);
            U.OpenUserstory(this, storyRowIdx: U.lastIdx_XPath);


            U.ScrollToBottom(this, C.scrollable_mainContent);

            ClickXPath(C.btnAddStep_XPath);

            WaitToSeeHeader(C.header_AddStepFirstPopup_Sign);
            
            AtRow(addedIntegration).ClickLink("Select");
            WaitToSeeHeader("Step details");
            Set("Step").To(C.addedStep);
            U.ExpectDropdown(this, addedIntegration);
            Click("Save");
            Thread.Sleep(5000);


            // Checking if step is added to a right place and right order
            ExpectXPath($"//div[1]//a[{U.XPathText(Casing.Ignore, C.addedStep)}]");
            ExpectXPath($"//div[2]{C.btnAddStep_XPath}");

            RefreshPage();
            U.WaitToSee_Userstory_EditPage(this);
            Thread.Sleep(3000);
            U.ScrollToBottom(this, C.scrollable_mainContent);

            // Checking if step is added to a right place and right order
            ExpectXPath($"//div[1]//a[{U.XPathText(Casing.Ignore, C.addedStep)}]");
            ExpectXPath($"//div[2]{C.btnAddStep_XPath}");
        }
    }
}
