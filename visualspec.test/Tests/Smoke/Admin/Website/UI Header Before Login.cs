namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Header_BeforeLogin : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.GoToLandingPage(this);
            U.CheckWebsiteUI_Header_BeforeLogin(this);
        }



    }
}
