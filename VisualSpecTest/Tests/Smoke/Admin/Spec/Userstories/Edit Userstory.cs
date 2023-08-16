namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Shared.Admin.Userstories;

    [TestClass]
    public class EditUserstory : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUserstory>();
            



            //*********** Edit userstory
            //AtRow(newUserstory).AtColumn("Ref").ClickLink();
            ClickXPath("//tr[last()]/td[2]/a");
            WaitToSee(What.Contains, "Acceptance Criteria");

            ClickLink(That.Contains, "Edit");
            WaitToSee("Edit user story");

            Set(That.Contains, "Title").To(C.editedUserstory);

            ClickButton(U.feature01);
            ClickLink(U.feature01);
            ClickLink(U.feature02);
            ClickButton(U.feature02);

            ClickLabel("Designed");

            Click("Save");
            WaitToSee("Edit user story");
            //WaitToSee(What.Contains, "Acceptance Criteria");
            WaitToSeeHeader(That.Contains, C.editedUserstory);
            Expect(What.Contains, U.feature02);

            ClickXPath("//a[@name='UserStoriesList']");
            WaitToSee("User Stories");

            ExpectXPath($"//tr[last()]//strong[text()='{C.editedUserstory}']");
            ExpectXPath($"//tr[last()]//span[@class='user-story-list-status--designed']");
        }
    }
}
