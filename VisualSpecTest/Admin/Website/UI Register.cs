namespace Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Register : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            ClickLink("Accept");

            //MyUtils.GotoRegisterPage(this);
            Click("Register");
            WaitForNewPage();


            Expect(What.Contains, "Didn't", Casing.Exact);
            Expect(What.Contains, "register!", Casing.Exact);
            Expect(What.Contains, "If you are new to Visual Spec, sign up for free to save your wire-frames, share it with clients and colleagues and make use of our full management features.", Casing.Exact);
            Expect(What.Contains, "You won't receive any junk email from us.", Casing.Exact);



            ExpectLabel("First name", Casing.Exact);
            ExpectLabel("Last name", Casing.Exact);
            ExpectLabel("Telephone", Casing.Exact);

            ExpectLabel("Email", Casing.Exact);
            ExpectLabel("Password", Casing.Exact);

            U.ScrollToBottom_Website(this);
            ExpectLabel("Repeat password", Casing.Exact);
            ExpectLink("Register", Casing.Exact);


            ExpectXPath("//img[@src='/Images/svg/register.svg']");

        }



    }
}
