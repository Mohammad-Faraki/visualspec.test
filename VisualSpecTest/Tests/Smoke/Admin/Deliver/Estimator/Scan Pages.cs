namespace Tests.Smoke.Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using System;
    using OpenQA.Selenium;

    [TestClass]
    public class ScanPages : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();

            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            U.ScanPages(this);
        }



    }
}
