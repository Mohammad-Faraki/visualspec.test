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
            Set("Name").To(C.addedIntegration);
            Click("Save");
            Expect(C.addedIntegration);

            Run<OpenEstimate>();
            Thread.Sleep(2000);



            U.ScrollToElementXPath(this, C.scrollable_mainContent,
                C.listIntegrationsXPath);

            U.OpenDropdown(this, "Nothing selected", C.listIntegrationsXPath);
            ClickLink(U.feature01);
            
            U.ExpectDropdown(this, "Nothing selected", C.listIntegrationsXPath);

            RefreshPage();
            WaitToSeeXPath(U.scope_Estimate_Sign_XPath);
            ClickXPath(U.scope_Estimate_Sign_XPath);

            U.ScrollToElementXPath(this, C.scrollable_mainContent,
                C.listIntegrationsXPath);
            U.ExpectDropdown(this, "Nothing selected", C.listIntegrationsXPath);
        }
    }
}
