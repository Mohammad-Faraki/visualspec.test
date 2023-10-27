namespace Tests.Smoke.Admin.Scope.Estimate
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Shared.Admin.Scope.Estimate;

    [TestClass]
    public class AssignFeaturestoIntegration : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenFeatures>();
            Thread.Sleep(2000);

            //*********** Add integration
            ClickXPath($"//a[@name='CreateIntegration']");
            WaitToSee("Add integration");
            Set("Name").To(Const.addedIntegration);
            Click("Save");
            Expect(Const.addedIntegration);

            Run<OpenEstimate>();
            Thread.Sleep(2000);



            Utils.ScrollToElementXPath(this, Const.scrollable_mainContent,
                Const.listIntegrationsXPath);

            Utils.OpenDropdown(this, "Nothing selected", Const.listIntegrationsXPath);
            ClickLink(Utils.feature01);
            
            Utils.ExpectDropdown(this, "Nothing selected", Const.listIntegrationsXPath);

            RefreshPage();
            WaitToSeeXPath(Utils.scope_Estimate_Sign_XPath);
            ClickXPath(Utils.scope_Estimate_Sign_XPath);

            Utils.ScrollToElementXPath(this, Const.scrollable_mainContent,
                Const.listIntegrationsXPath);
            Utils.ExpectDropdown(this, "Nothing selected", Const.listIntegrationsXPath);
        }
    }
}
