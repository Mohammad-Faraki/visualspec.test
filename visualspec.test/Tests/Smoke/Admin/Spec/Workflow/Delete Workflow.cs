namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Workflow;

    [TestClass]
    public class DeleteWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddWorkflow>();

            ClickXPath($"{C.workflowTopSectionXPath}//button[@name='Delete']");

            Expect("Are you sure you want to delete this workflow model?");
            Click("OK");
            ExpectNo(C.workflow1);
        }



    }
}
