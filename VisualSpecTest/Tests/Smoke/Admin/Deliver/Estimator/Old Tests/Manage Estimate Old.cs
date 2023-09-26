namespace Tests.Smoke.Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    

    //[TestClass]
    public class ManageEstimateOld : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();
            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            U.ScanPages(this);

            int rowIndex = 1;







            // first row is the headers row
            rowIndex += 1;


            // Clicking a star
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(6) a[title='Give 2 points']");
            WaitToSee("Please press 'Start estimation' button");
            Click("OK");
            Thread.Sleep(1000);

            ClickButton("Start estimate");
            Thread.Sleep(2000);


            //*********** Set estimates

            // Row 1
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(6) a[title='Give 2 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(7) a[title='Give 3 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(8) a[title='Give 4 points']");
            Thread.Sleep(500);

            // Row 2
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(6) a[title='Give 4 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(7) a[title='Give 4 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(8) a[title='Give 4 points']");
            Thread.Sleep(500);

            // Row 3
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(6) a[title='Give 4 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(7) a[title='Give 3 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(8) a[title='Give 2 points']");
            Thread.Sleep(500);

            ClickButton("Submit estimate");
            Thread.Sleep(2000);


            AtRow(rowIndex).Expect(What.Contains, "2");
            AtRow(rowIndex + 1).Expect(What.Contains, "4.5");
            AtRow(rowIndex + 2).Expect(What.Contains, "1.75");

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(rowIndex).Expect(What.Contains, "2");
            AtRow(rowIndex + 1).Expect(What.Contains, "4.5");
            AtRow(rowIndex + 2).Expect(What.Contains, "1.75");





            //*********** Edit estimates

            ClickButton("Start estimate");
            Thread.Sleep(2000);

            // Row 1   
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(6) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(7) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(8) a[title='Give 1 point']");
            Thread.Sleep(500);

            // Row 2
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(6) a[title='Give 2 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(7) a[title='Give 2 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(8) a[title='Give 2 points']");
            Thread.Sleep(500);

            // Row 3
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(6) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(7) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(8) a[title='Give 1 point']");
            Thread.Sleep(500);

            ClickButton("Submit estimate");
            Thread.Sleep(2000);


            AtRow(rowIndex).Expect(What.Contains, "0.25");
            AtRow(rowIndex + 1).Expect(What.Contains, "0.5");
            AtRow(rowIndex + 2).Expect(What.Contains, "0.25");

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(rowIndex).Expect(What.Contains, "0.25");
            AtRow(rowIndex + 1).Expect(What.Contains, "0.5");
            AtRow(rowIndex + 2).Expect(What.Contains, "0.25");




            //*********** Clear estimates

            ClickButton("Start estimate");
            Thread.Sleep(2000);

            // Row 1
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(6) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(7) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex}) > td:nth-of-type(8) a[title='Give 1 point']");
            Thread.Sleep(500);

            // Row 2
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(6) a[title='Give 2 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(7) a[title='Give 2 points']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 1}) > td:nth-of-type(8) a[title='Give 2 points']");
            Thread.Sleep(500);

            // Row 3
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(6) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(7) a[title='Give 1 point']");
            Thread.Sleep(500);
            ClickCSS($"tr:nth-of-type({rowIndex + 2}) > td:nth-of-type(8) a[title='Give 1 point']");
            Thread.Sleep(500);

            ClickButton("Submit estimate");
            Thread.Sleep(2000);


            AtRow(rowIndex).Expect(What.Contains, "0");
            AtRow(rowIndex + 1).Expect(What.Contains, "0");
            AtRow(rowIndex + 2).Expect(What.Contains, "0");

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(rowIndex).Expect(What.Contains, "0");
            AtRow(rowIndex + 1).Expect(What.Contains, "0");
            AtRow(rowIndex + 2).Expect(What.Contains, "0");
        }



    }
}
