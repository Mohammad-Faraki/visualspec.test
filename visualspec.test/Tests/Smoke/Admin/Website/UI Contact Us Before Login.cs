namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_ContactUs_BeforeLogin : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.OpenContactUs(this);

            U.CheckContactUsUI(this);
        }



    }
}
