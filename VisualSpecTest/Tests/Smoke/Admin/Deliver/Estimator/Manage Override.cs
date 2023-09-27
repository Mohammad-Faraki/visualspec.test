namespace Tests.Smoke.Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    

    [TestClass]
    public class ManageOverride : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();
            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            U.ScanPages(this, true);

            int rowIndex = 1;





            // first row is the headers row
            rowIndex += 1;

            int overrideValueOld = 0;
            int overrideValueNew = 99;

            //ClickButton("Start estimate");

            SetXPath($"//tr[{rowIndex}]//td[10]//input")
                .To($"{overrideValueNew}");

            
            //// this should be commented after implementation of
            //// save with "Submit estimate" button 
            //Press(Keys.Enter);
            Thread.Sleep(2000);

            // Click off the override input
            ClickXPath($"//th[{U.XPathText(Casing.Exact, "UI Design Implementation")}]");

            //ClickButton("Submit estimate");
            U.ScanPages(this, false);
            Thread.Sleep(3000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");


            ExpectXPath($"//tr[{rowIndex}]//td[10]//input[@value='{overrideValueNew}']");
        }



    }
}
