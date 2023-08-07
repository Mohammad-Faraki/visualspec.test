namespace Admin.Estimator
{
    using Admin.Website;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System.Threading;

    [TestClass]
    public class Search : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<OpenEstimator>();
            //Thread.Sleep(2000);
            Run<CreateOpenProject>();
            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            U.ScanPages(this);



            // Actor filter
            NearLabel(That.Contains, "User types").ClickButton("Nothing selected");
            // Select Admin_A Web App_Wide screen
            NearLabel(That.Contains, "User types").ClickLink("Admin_A Web App_Wide ..");

            // Search btn
            NearLabel(That.Contains, "User types").ClickButton(That.Contains, "Search");
            Thread.Sleep(5000);

            // Not see any item with Customer_A Mobile App_Mobile actor in table
            //BelowCSS(".grid.grid--no-flex.pages-estimates-list").WaitToSeeNo(What.Contains, "Customer_A Mobile App_Mobile");
            ExpectNoRow(That.Contains, "Customer_A Mobile App_Mobile");
        }



    }
}
