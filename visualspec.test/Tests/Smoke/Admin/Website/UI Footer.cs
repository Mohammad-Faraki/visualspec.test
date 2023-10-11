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
            Utils.GoToLandingPage(this);
            ClickLink("Accept");
            Utils.ScrollToBottom_Website(this);
            Utils.CheckWebsiteUI_Footer(this);
        }



    }
}
