namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Workflow;

    [TestClass]
    public class AddWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<PreconWorkflow>();

            ClickXPath(U.btnAddWorklowXPath(U.feature01));
            WaitToSeeHeader("New Workflow Model");

            Set("Name").To(C.workflow1);
            Click("Save");

            ExpectLink(C.workflow1);
            ClickLink(C.workflow1);
            AtXPath(C.workflowTopSectionXPath).ExpectHeader(That.Contains, C.workflow1);
        }



    }
}
