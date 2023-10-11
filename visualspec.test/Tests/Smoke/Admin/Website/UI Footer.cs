namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Footer : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            ClickLink("Accept");
            U.ScrollToBottom_Website(this);
            U.CheckWebsiteUI_Footer(this);
        }



    }
}
