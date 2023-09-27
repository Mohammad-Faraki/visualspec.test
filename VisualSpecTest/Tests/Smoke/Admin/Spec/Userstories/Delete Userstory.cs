﻿namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Shared.Admin.Userstories;

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
            WaitToSee("User Journey Details");

            ClickButton(That.Contains, "Delete");
            ClickButton("OK");
            WaitToSeeXPath($"//form[@data-module='UserStoryList']//*[{U.XPathText(Casing.Exact, "User Journeys")}]");
            U.ScrollToBottom(this, Shared.Admin.Userstories.C.scrollable_mainContent);
            ExpectNoXPath($"//tr[last()]//*[text()='{C.addedUserstory}']");
        }
    }
}
