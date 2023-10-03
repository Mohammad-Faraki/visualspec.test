﻿namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_ContactUs_AfterLogin : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.LoginAdmin(this, isFirstTime: true);

            //MyUtils.GotoConatctUs(this);
            U.ScrollToBottom_Website(this);
            ClickLink("Contact us");
            WaitToSee(What.Contains, "VisualSpec is created by Geeks. For more information please visit");



            U.CheckContactUsUI(this);

            // Check mandatory signs
            ExpectXPath($"//label[{U.XPathTextContains(Casing.Exact, "Your name")}][{U.XPathHasElement($"*[{U.XPathTextContains(Casing.Exact, "*")}]")}]");
            ExpectXPath($"//label[{U.XPathTextContains(Casing.Exact, "Email")}][{U.XPathHasElement($"*[{U.XPathTextContains(Casing.Exact, "*")}]")}]");

            // inputs should be filled with user's information
            U.ExpectField(this
                , $"//div[{U.XPathHasElement($"label[{U.XPathTextContains(Casing.Exact, "Your name")}]")}]"
                , U.AdminFullname);

            U.ExpectField(this
                , $"//div[{U.XPathHasElement($"label[{U.XPathTextContains(Casing.Exact, "Email")}]")}]"
                , U.AdminEmail);


        }



    }
}
