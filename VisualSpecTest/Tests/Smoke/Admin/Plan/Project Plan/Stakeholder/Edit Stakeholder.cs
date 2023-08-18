namespace Tests.Smoke.Admin.Plan.Stakeholder
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class EditStakeholder : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddStakeholder>();
            


            //*********** Edit stakeloder
            ClickXPath("//tr[last()]//a[@name='Edit']");
            WaitToSeeHeader(That.Contains,"Stakeholder Details");

            Set(That.Contains, "Name").To("stakeholder01 edited");
            Set(That.Contains, "Department").To("department01 edited");
            Set(That.Contains, "Role").To("role01 edited");
            Set(That.Contains, "Email").To("editedemail01@yahoo.com");
            Set(That.Contains, "Tel").To("tel01 edited");
            ClickLabel(That.Contains, "Senior Responsible Owner");
            Click("Save");
            Thread.Sleep(2000);
            ExpectXPath($"//tr[last()]//*[{U.XPathText("stakeholder01 edited")}]");
            ExpectXPath($"//tr[last()]//*[{U.XPathText("department01 edited")}]");
            ExpectXPath($"//tr[last()]//*[{U.XPathText("role01 edited")}]");
            ExpectXPath($"//tr[last()]//*[{U.XPathText("editedemail01@yahoo.com")}]");
            ExpectXPath($"//tr[last()]//*[{U.XPathText("tel01 edited")}]");

        }



    }
}
