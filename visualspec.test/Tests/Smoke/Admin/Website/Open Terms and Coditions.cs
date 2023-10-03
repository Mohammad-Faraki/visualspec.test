namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class OpenTermsandCoditions : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            ClickLink("Accept");

            U.ScrollToBottom_Website(this);
            ClickLink("Terms & conditions");

            WaitToSee(What.Contains, "Since these terms and conditions were written the words");
        }



    }
}
