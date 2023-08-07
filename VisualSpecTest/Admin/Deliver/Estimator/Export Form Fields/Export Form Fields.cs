namespace Admin.Estimator.ExportFormFields
{
    using Admin.Website;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System.Threading;

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
            U.ScanPages(this);




            ClickXPath("//*[@name='Export']");
            WaitToSeeXPath("//*[@name='ExportFormFields']");
            ClickXPath("//*[@name='ExportFormFields']");

            Expect("ExportFormFields has error I can't continue wrting this test case!");
        }



    }
}
