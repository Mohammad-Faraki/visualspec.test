namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Win32;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class OpenRegisterPage : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);

            ClickLink("Register");

            WaitToSee(What.Contains, "register!");
        }



    }
}
