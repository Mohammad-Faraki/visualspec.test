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
            Utils.GoToLandingPage(this);
            ClickLink("Accept");

            Utils.ScrollToBottom_Website(this);
            ClickLink("Terms & conditions");

            WaitToSee(What.Contains, "Since these terms and conditions were written the words");
        }



    }
}
