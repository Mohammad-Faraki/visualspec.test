﻿namespace Tests.Smoke.Admin.Estimator.ExportFormFields
{
    using Tests.Smoke.Admin.Website;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Pangolin;
    using System.Threading;
    using OpenQA.Selenium;

    [TestClass]
    public class ExportFormFields : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<OpenEstimator>();
            //Thread.Sleep(2000);
            //Run<ScanPages>();

            Run<CreateOpenProject>();
            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            Utils.ScanPages(this, true);




            ClickXPath("//*[@name='Export']");
            WaitToSeeXPath("//*[@name='ExportFormFields']");
            ClickXPath("//*[@name='ExportFormFields']");

            Expect("ExportFormFields has error I can't continue wrting this test case!");
        }



    }
}
