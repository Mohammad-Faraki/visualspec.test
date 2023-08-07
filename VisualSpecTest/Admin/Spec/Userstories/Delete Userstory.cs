namespace Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class DeleteUserstory : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUserstory>();





            //*********** Delete userstory
            ClickXPath("//tr[last()]/td[2]/a");
            WaitToSee(What.Contains, "Acceptance Criteria");

            ClickLink(That.Contains, "Edit");
            WaitToSee("Edit user story");

            ClickButton(That.Contains, "Delete");
            ClickButton("OK");
            WaitToSee("User Stories");
            ExpectNoXPath($"//tr[last()]//strong[text()='{C.addedUserstory}']");
        }
    }
}
