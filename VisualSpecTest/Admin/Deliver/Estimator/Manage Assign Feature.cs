﻿namespace Admin.Estimator
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;
    using OpenQA.Selenium;

    [TestClass]
    public class ManageAssignFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<CreateOpenProject>();


            //Run<AddFeature>();
            U.AddFeature(this, U.feature01);
            U.AddFeature(this, U.feature02);

            // Open a new tab
            this.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
            //CloseTab()
            U.ScanPages(this);

            int rowIndex = 1;








            // first row is the headers row
            rowIndex += 1;



            //*********** Assign a features 
            string helpIconCss = $"tr:nth-of-type({rowIndex}) > td:nth-of-type(12) > a";

            U.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //AtRow(2).ClickCSS("[data-toggle]");
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            AtRow(rowIndex).ClickButton("Nothing selected");

            // Select first features
            ClickCSS("li:nth-of-type(1) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{U.XPathText("UI Design Implementation")}]");
            //ClickRow(2);

            WaitToSee("Please press 'Start estimation' button");
            Click("OK");
            Thread.Sleep(1000);
            ClickButton("Start estimate");
            Thread.Sleep(3000);



            //*********** Assign a features 
            U.ScrollToElementCSS(this, helpIconCss);
            // Open featuers popup of second page
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            AtRow(rowIndex).ClickButton("Nothing selected");

            // Select first features
            ClickCSS("li:nth-of-type(1) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{U.XPathText("UI Design Implementation")}]");
            Thread.Sleep(2000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            //// See feature01 below second page
            //BelowCSS("tr:nth-of-type(2) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']  .filter-option-inner")
            //    .Expect("feature01");
            //AtRow(That.Contains, "Working Group").Click("Edit");
            //AtRow(2).Expect(What.Contains, "2 items selected");
            AtRow(rowIndex).ExpectButton(That.Contains, U.feature01);




            //*********** Assign second feature 
            U.ScrollToElementCSS(this, helpIconCss);
            // Open featuers popup of second page
            //AtRow(2).ClickCSS("[data-toggle]");
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            AtRow(rowIndex).ClickButton("feature01");

            // Select second features
            ClickCSS("li:nth-of-type(2) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{U.XPathText("UI Design Implementation")}]");
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
            U.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            AtRow(rowIndex).ClickButton("2 items selected");

            // Select first features
            ClickCSS("li:nth-of-type(1) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{U.XPathText("UI Design Implementation")}]");
            Thread.Sleep(2000);
            //Thread.Sleep(2000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(rowIndex).ExpectButton(That.Contains, U.feature02);





            //*********** Unassign the only remained feature
            U.ScrollToElementCSS(this, helpIconCss);

            // Open featuers popup of second page
            //ClickCSS($"tr:nth-of-type({rowIndex}) > .grid-dropdown-column-multi-select.pages-estimates-list__col-features.pages-estimates-list__col-help > form[role='form'] button[role='combobox']");
            AtRow(rowIndex).ClickButton(U.feature02);

            // Select second features
            ClickCSS("li:nth-of-type(2) > a[role='option']");

            // Click off the features popup
            ClickXPath($"//th[{U.XPathText("UI Design Implementation")}]");
            Thread.Sleep(2000);
            //Thread.Sleep(2000);

            RefreshPage();
            WaitToSee(What.Contains, "Page Estimates");

            AtRow(2).ExpectButton(That.Contains, "Nothing selected");





            ClickButton("Submit estimate");
        }
    }
}
