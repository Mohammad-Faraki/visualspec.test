namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
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
            WaitToSee("Edit User Journey");

            Set(That.Contains, "Description").To(C.editedUserstory);

            ClickButton(U.feature01);
            ClickLink(U.feature01);
            ClickLink(U.feature02);
            ClickButton(U.feature02);

            //ClickLabel("Designed"); doesn't exists anymore

            Click("Save");
            Thread.Sleep(5000);
            //WaitToSee(What.Contains, "Acceptance Criteria");
            ExpectHeader(That.Contains, C.editedUserstory);
            Expect(What.Contains, U.feature02);

            //ClickXPath("//a[@name='UserStoriesList']");
            //WaitToSee("User Stories");
            U.OpenUserstories(this);
            Thread.Sleep(2000);

            U.ScrollToBottom(this, Shared.Admin.Userstories.C.scrollable_mainContent);
            ExpectXPath($"//tr[last()]//*[text()='{C.editedUserstory}']");
            #region Commented checking Status
            //ExpectXPath($"//tr[last()]//span[@class='user-story-list-status--designed']");
            ////ClickXPath("//tr[last()]/td[2]/a");
            ////WaitToSee(What.Contains, "Acceptance Criteria");

            ////ClickLink(That.Contains, "Edit");
            ////WaitToSee("Edit User Journey");
            ////// Check if Designed radio is selected
            ////ExpectXPath($"//label[{U.XPathText("Designed")}]/{U.preceding_sibling}::input[{U.XPathAttribute("checked", "checked")}]"); 
            #endregion
        }
    }
}
