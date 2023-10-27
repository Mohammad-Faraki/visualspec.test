namespace Tests.Smoke.Admin.Website
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
            Utils.LoginAdmin(this, isFirstTime: true);

            //MyUtils.GotoConatctUs(this);
            Utils.ScrollToBottom_Website(this);
            ClickLink("Contact us");
            WaitToSee(What.Contains, "VisualSpec is created by Geeks. For more information please visit");



            Utils.CheckContactUsUI(this);

            // Check mandatory signs
            ExpectXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "Your name")}][{Utils.XPathHasElement($"*[{Utils.XPathTextContains(Casing.Exact, "*")}]")}]");
            ExpectXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "Email")}][{Utils.XPathHasElement($"*[{Utils.XPathTextContains(Casing.Exact, "*")}]")}]");

            // inputs should be filled with user's information
            Utils.ExpectField(this
                , $"//div[{Utils.XPathHasElement($"label[{Utils.XPathTextContains(Casing.Exact, "Your name")}]")}]"
                , Utils.AdminFullname);

            Utils.ExpectField(this
                , $"//div[{Utils.XPathHasElement($"label[{Utils.XPathTextContains(Casing.Exact, "Email")}]")}]"
                , Utils.AdminEmail);


        }



    }
}
