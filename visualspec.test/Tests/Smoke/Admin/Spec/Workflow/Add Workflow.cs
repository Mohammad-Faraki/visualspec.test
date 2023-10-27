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
    public class AddWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<PreconWorkflow>();

            ClickXPath(Utils.btnAddWorklowXPath(Utils.feature01));
            WaitToSeeHeader("New Workflow Model");

            Set("Name").To(Const.workflow1);
            Click("Save");

            // To-Be : workflow1
            var WorkflowName_Sidebar = $"To-Be : {Const.workflow1}";
            ExpectLink(WorkflowName_Sidebar);
            ClickLink(WorkflowName_Sidebar);
            AtXPath(Const.workflowTopSectionXPath).ExpectHeader(That.Contains, Const.workflow1);
        }



    }
}
