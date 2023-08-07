namespace Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Login : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            ClickLink("Accept");

            //MyUtils.GotoLoginPage(this);
            Click("Login");
            WaitForNewPage();


            Expect(What.Contains, "Welcome back,", Casing.Exact);
            Expect(What.Contains, "login!", Casing.Exact);
            Expect(What.Contains, "Don't have an account?", Casing.Exact);
            ExpectLink("Click here to register now", Casing.Exact);

            ExpectLink("Continue with Google", Casing.Exact);
            ExpectLabel("Email", Casing.Exact);
            ExpectLabel("Password", Casing.Exact); 
            ExpectLabel("Remember me?", Casing.Exact);
            ExpectLink("Forgot Password?", Casing.Exact);
            ExpectLink("Login", Casing.Exact);
            Expect("OR", Casing.Exact);

            ExpectXPath("//img[@src='/Images/svg/login-img.svg']");

        }



    }
}
