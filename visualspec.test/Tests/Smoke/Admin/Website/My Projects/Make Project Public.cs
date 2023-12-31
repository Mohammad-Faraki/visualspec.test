﻿namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class MakeProjectPublic : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //MyUtils.GoToLandingPage(this);
            //MyUtils.GoToWireframes(this);
            //Expect("");

            Run<OpenWireframes>();

            Utils.GoToLandingPage(this);

            ClickLink("Logout");
            WaitToSee("Continue with Google");


            Utils.GoToWireframes(this);
            // Not authorized
            Expect("Continue with Google");


            //Goto($"http://{MyUtils.WebsiteDomain}/My-Account/Projects.aspx");
            Utils.LoginAdmin(this);

            Utils.SearchProject(this);
            Utils.OpenProjectDetails(this, 1);
            ClickLabel(That.Contains, "Is preview public");
            ClickLabel(That.Contains, "Is design public");
            ClickLink("Save");


            //this.WebDriver.SwitchTo().NewWindow(WindowType.Window);
            //MyUtils.GoToLandingPage(this);
            ClickLink("Logout");
            WaitToSee("Continue with Google");


            //Thread.Sleep(4000);
            Utils.GoToWireframes(this);
            // Authorized
            ExpectLink("Outline");
        }



    }
}
