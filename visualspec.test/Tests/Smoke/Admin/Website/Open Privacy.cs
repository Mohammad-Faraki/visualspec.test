namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class OpenPrivacy : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            ClickLink("Accept");

            U.ScrollToBottom_Website(this);
            ClickLink("Privacy policy");

            WaitToSee(What.Contains, "Geeks Ltd is committed to ensuring that your privacy is protected");
        }



    }
}
