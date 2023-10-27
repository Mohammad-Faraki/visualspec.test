namespace Tests.Smoke.Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    

    //[TestClass]
    public class ManageRouteOld : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // Route won't be saved

            Run<CreateOpenProject>();
            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            Utils.ScanPages(this, true);

            // first row edit has bug that shod be fixed
            int rowIndex = 1;







            // first row is the headers row
            rowIndex += 1;
            string newRouteName = "NewRouteName";



            //ClickCSS($"p#routeName_{rowIndex}");
            //AtRow(rowIndex).AtColumn("Route").ClickText();
            ClickXPath($"//tr[{rowIndex}]//td[5]//p");
            Thread.Sleep(1000);
            SetXPath($"//tr[{rowIndex}]//td[5]//input").To(newRouteName);
            // Click off the route input
            //ClickCSS(".scroll-content > .content");
            Press(Pangolin.Keys.Enter);

            WaitToSee("You have to start estimation first!");
            Click("OK");
            Thread.Sleep(1000);

            ClickButton("Start estimate");
            Thread.Sleep(2000);



            ClickXPath($"//tr[{rowIndex}]//td[5]//p");
            Thread.Sleep(1000);
            SetXPath($"//tr[{rowIndex}]//td[5]//input").To(newRouteName);
            // Click off the route input
            //ClickCSS(".scroll-content > .content");
            Press(Pangolin.Keys.Enter);
            Thread.Sleep(1000);



            ClickButton("Submit estimate");
            Thread.Sleep(1000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");


            //ExpectXPath($"//tbody/tr[{rowIndex}]/td[@class='pages-estimates-list__col-route']/p[{MyUtils.GetXPathTextAtrribute(newRouteName)}]");
            AtRow(rowIndex).Expect(What.Contains, newRouteName);
            // test another row as an example to see if only the target row is
            // updated and no other row is affected or changed
            AtRow(rowIndex+1).ExpectNo(What.Contains, newRouteName);
        }



    }
}
