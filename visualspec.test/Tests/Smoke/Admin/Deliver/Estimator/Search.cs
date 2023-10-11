namespace Tests.Smoke.Admin.Estimator
{
    using Tests.Smoke.Admin.Website;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Pangolin;
    using System.Threading;
    using OpenQA.Selenium;

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
            Utils.ScanPages(this, true);



            // Actor filter
            //NearLabel(That.Contains, "Actor").ClickButton("Nothing selected");
            Utils.OpenDropdown(this, "Nothing selected",
                $"//label[{Utils.XPathTextContains(Casing.Exact, "Actor")}]/{Utils.following_sibling_XPath}::div");
            // Select Admin_A Web App_Wide screen
            NearLabel(That.Contains, "Actor").ClickLink("Customer");

            // Search btn
            NearLabel(That.Contains, "Actor").ClickButton(That.Contains, "Search");
            Thread.Sleep(5000);

            // Not see any item with Customer_A Mobile App_Mobile actor in table
            //BelowCSS(".grid.grid--no-flex.pages-estimates-list").WaitToSeeNo(What.Contains, "Customer_A Mobile App_Mobile");
            ExpectNoRow(That.Contains, "Admin");
            ExpectRow(That.Contains, "Customer");
        }



    }
}
