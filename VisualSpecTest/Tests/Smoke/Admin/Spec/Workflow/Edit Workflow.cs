namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
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



            ExpectLink(C.workflow1_Edited);
            ExpectHeader(That.Contains, "As-Is:");
            ExpectHeader(That.Contains, C.workflow1_Edited);

            RefreshPage();
            WaitToSeeHeader("Workflow Models");

            ExpectLink(C.workflow1_Edited);
            ExpectHeader(That.Contains, "As-Is:");
            ExpectHeader(That.Contains, C.workflow1_Edited);



            ClickLink(C.workflow1_Edited);
            ClickXPath(btnEdit);
            ExpectHeader(That.Contains, "Edit Workflow Model");
            U.ExpectField(this, $"//label[{U.XPathTextContains("Name")}]", C.workflow1_Edited);
            ExpectXPath($"{editFormXPath}//label[{U.XPathText("As-Is")}]/preceding-sibling::input[@name='Type'][@checked='checked']");
        }



    }
}
