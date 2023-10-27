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
            var addedIntegration = Shared.Admin.Scope.Features.Const.addedIntegration;

            Run<AddUserstory>();

            Utils.OpenFeatures(this);
            Thread.Sleep(5000);
            Utils.AddIntegration(this, addedIntegration);
            Utils.OpenUserstories(this);
            Thread.Sleep(2000);


            Utils.ScrollToBottom(this, Const.scrollable_mainContent);
            Utils.OpenUserstory(this, storyRowIdx: Utils.lastIdx_XPath);


            Utils.ScrollToBottom(this, Const.scrollable_mainContent);

            ClickXPath(Const.btnAddStep_XPath);

            WaitToSeeHeader(Const.header_AddStepFirstPopup_Sign);
            
            AtRow(addedIntegration).ClickLink("Select");
            WaitToSeeHeader("Step details");
            Set("Step").To(Const.addedStep);
            Utils.ExpectDropdown(this, addedIntegration);
            Click("Save");
            Thread.Sleep(5000);


            // Checking if step is added to a right place and right order
            ExpectXPath($"//div[1]//a[{Utils.XPathText(Casing.Ignore, Const.addedStep)}]");
            ExpectXPath($"//div[2]{Const.btnAddStep_XPath}");

            RefreshPage();
            Utils.WaitToSee_Userstory_EditPage(this);
            Thread.Sleep(3000);
            Utils.ScrollToBottom(this, Const.scrollable_mainContent);

            // Checking if step is added to a right place and right order
            ExpectXPath($"//div[1]//a[{Utils.XPathText(Casing.Ignore, Const.addedStep)}]");
            ExpectXPath($"//div[2]{Const.btnAddStep_XPath}");
        }
    }
}
