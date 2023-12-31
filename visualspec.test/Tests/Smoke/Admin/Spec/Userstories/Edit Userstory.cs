﻿namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Shared.Admin.Userstories;

    [TestClass]
    public class EditUserstory : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUserstory>();
            



            //*********** Edit userstory
            Utils.OpenUserstory(this, storyRowIdx: "last()");

            ClickLink(That.Contains, "Edit");
            string editPopupTitle = "User Journey Details";
            WaitToSee(editPopupTitle);

            Set(That.Contains, "Description").To(Const.editedUserstory);

            //ClickButton(U.feature01);
            Utils.OpenDropdown(this, Utils.feature01);
            ClickLink(Utils.feature01);
            ClickLink(Utils.feature02);
            //ClickButton(U.feature02);
            ClickHeader(editPopupTitle);


            //ClickLabel("Designed"); doesn't exists anymore

            Click("Save");
            Thread.Sleep(5000);
            //WaitToSee(What.Contains, "Acceptance Criteria");
            ExpectHeader(That.Contains, Const.editedUserstory);
            //Expect(What.Contains, U.feature02);
            ClickLink(That.Contains, "Edit");
            WaitToSee(editPopupTitle);
            ExpectButton(Utils.feature02);
            Click("Cancel");
            Thread.Sleep(3000);

            //ClickXPath("//a[@name='UserStoriesList']");
            //WaitToSee("User Stories");
            Utils.OpenUserstories(this);
            Thread.Sleep(2000);

            Utils.ScrollToBottom(this, Const.scrollable_mainContent);
            ExpectXPath($"//tr[last()]//*[text()='{Const.editedUserstory}']");
            #region Commented checking Status
            //ExpectXPath($"//tr[last()]//span[@class='user-story-list-status--designed']");
            ////ClickXPath("//tr[last()]/td[2]/a");
            ////WaitToSee(What.Contains, "Acceptance Criteria");

            ////ClickLink(That.Contains, "Edit");
            ////WaitToSee("Edit User Journey");
            ////// Check if Designed radio is selected
            ////ExpectXPath($"//label[{U.XPathText(Casing.Exact, "Designed")}]/{U.preceding_sibling}::input[{U.XPathAttribute("checked", "checked")}]"); 
            #endregion
        }
    }
}
