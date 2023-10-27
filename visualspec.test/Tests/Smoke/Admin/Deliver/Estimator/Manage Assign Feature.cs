namespace Tests.Smoke.Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    

    [TestClass]
    public class ManageAssignFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<CreateOpenProject>();


            //Run<AddFeature>();
            Utils.AddFeature(this, Utils.feature01);
            Utils.AddFeature(this, Utils.feature02);

            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            //CloseTab()
            Utils.ScanPages(this, true);

            int rowIndex = 1;








            // first row is the headers row
            rowIndex += 1;



            //*********** Assign a features 
            string helpIconCss = $"tr:nth-of-type({rowIndex}) > td:nth-of-type(12) > a";

            Utils.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //AtRow(2).ClickCSS("[data-toggle]");
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            ////AtRow(rowIndex).ClickButton("Nothing selected");
            Utils.OpenDropdown(this, "Nothing selected", $"//tr[{rowIndex}]");

            // Select first features
            ClickCSS("li:nth-of-type(1) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{Utils.XPathText(Casing.Exact, "UI Design Implementation")}]");
            Thread.Sleep(2000);
            //ClickRow(2);

            #region Commneted submit estimate button
            ////WaitToSee("Please press 'Start estimation' button");
            ////Click("OK");
            ////Thread.Sleep(1000);
            ////ClickButton("Start estimate");
            ////Thread.Sleep(3000); 
            #endregion



            //*********** Assign a features 
            #region Commneted submit estimate button
            //U.ScrollToElementCSS(this, helpIconCss);
            //// Open featuers popup of second page
            ////ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            //////AtRow(rowIndex).ClickButton("Nothing selected");
            //U.OpenDropdown(this, "Nothing selected", $"//tr[{rowIndex}]");

            //// Select first features
            //ClickCSS("li:nth-of-type(1) > a[role='option']");

            //// Click off the features popup
            //ClickXPath($"//th[{U.XPathText(Casing.Exact, "UI Design Implementation")}]");
            //Thread.Sleep(2000); 
            #endregion

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            //// See feature01 below second page
            //BelowCSS("tr:nth-of-type(2) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']  .filter-option-inner")
            //    .Expect("feature01");
            //AtRow(That.Contains, "Working Group").Click("Edit");
            //AtRow(2).Expect(What.Contains, "2 items selected");
            AtRow(rowIndex).ExpectButton(That.Contains, Utils.feature01);




            //*********** Assign second feature 
            Utils.ScrollToElementCSS(this, helpIconCss);
            // Open featuers popup of second page
            //AtRow(2).ClickCSS("[data-toggle]");
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            ////AtRow(rowIndex).ClickButton("feature01");
            Utils.OpenDropdown(this, Utils.feature01, $"//tr[{rowIndex}]");

            // Select second features
            ClickCSS("li:nth-of-type(2) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{Utils.XPathText(Casing.Exact, "UI Design Implementation")}]");
            Thread.Sleep(2000);
            //ClickRow(2);


            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            //// See feature01 below second page
            //BelowCSS("tr:nth-of-type(2) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']  .filter-option-inner")
            //    .Expect("feature01");
            //AtRow(That.Contains, "Working Group").Click("Edit");
            AtRow(rowIndex).ExpectButton(That.Contains, "2 items selected");






            //*********** Unassign one of features
            Utils.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            ////AtRow(rowIndex).ClickButton("2 items selected");
            Utils.OpenDropdown(this, "2 items selected", $"//tr[{rowIndex}]");

            // Select first features
            ClickCSS("li:nth-of-type(1) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{Utils.XPathText(Casing.Exact, "UI Design Implementation")}]");
            Thread.Sleep(2000);
            //Thread.Sleep(2000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(rowIndex).ExpectButton(That.Contains, Utils.feature02);





            //*********** Unassign the only remained feature
            Utils.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            ////AtRow(rowIndex).ClickButton(U.feature02);
            Utils.OpenDropdown(this, Utils.feature02, $"//tr[{rowIndex}]");

            // Select second features
            ClickCSS("li:nth-of-type(2) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{Utils.XPathText(Casing.Exact, "UI Design Implementation")}]");
            Thread.Sleep(2000);
            //Thread.Sleep(2000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(2).ExpectButton(That.Contains, "Nothing selected");





            #region Commneted submit estimate button
            //ClickButton("Submit estimate"); 
            #endregion
        }
    }
}
