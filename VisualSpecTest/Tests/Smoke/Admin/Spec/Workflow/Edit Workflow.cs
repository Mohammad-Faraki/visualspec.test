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
    public class EditWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddWorkflow>();

            var btnEdit = $"{C.workflowTopSectionXPath}//a[@name='Edit']";
            var editFormXPath = "//form[@data-module='WorkFlowModelForm']";

            ClickXPath(btnEdit);

            ExpectHeader(That.Contains, "Edit Workflow Model");
            Set("Name").To(C.workflow1_Edited);
            ClickLabel("As-Is");
            Click("Save");


            // To-Be : workflow1
            var WorkflowName_Sidebar = $"As-Is : {C.workflow1_Edited}";
            ExpectLink(WorkflowName_Sidebar);
            ExpectHeader(That.Contains, "As-Is:");
            ExpectHeader(That.Contains, C.workflow1_Edited);

            RefreshPage();
            WaitToSeeHeader("Workflow Models");

            ExpectLink(WorkflowName_Sidebar);
            ExpectHeader(That.Contains, "As-Is:");
            ExpectHeader(That.Contains, C.workflow1_Edited);



            ClickLink(WorkflowName_Sidebar);
            ClickXPath(btnEdit);
            ExpectHeader(That.Contains, "Edit Workflow Model");
            U.ExpectField(this, $"//label[{U.XPathTextContains(Casing.Exact, "Name")}]", C.workflow1_Edited);
            ExpectXPath($"{editFormXPath}//label[{U.XPathText(Casing.Exact, "As-Is")}]/preceding-sibling::input[@name='Type'][@checked='checked']");
        }



    }
}
