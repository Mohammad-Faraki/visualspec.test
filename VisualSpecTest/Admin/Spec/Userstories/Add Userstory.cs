namespace Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class AddUserstory : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenFeatures>();
            Thread.Sleep(2000);


            U.AddFeature(this, U.feature01);
            U.AddFeature(this, U.feature02);

            Run<OpenUserstories>();
            Thread.Sleep(2000);


            //*********** Create userstory
            ClickXPath("//a[@name='UserStory']");
            WaitToSee("User story details");

            // Set fields of userstory 
            Set(That.Contains, "Title").To(C.addedUserstory);
            ClickButton("Nothing selected");
            ClickLink(U.feature01);
            ClickHeader("User story details");
            ClickButton(That.Contains, "Save and next");

            ClickXPath("//a[@name='UserStoriesList']");
            WaitToSee("User Stories");

            //*** unsuccessfull scrolling (since scrollbar is custom in visual spec)
            //var loc = this.WebDriver.FindElement(By).Location;
            //this.WebDriver.ExecuteJavaScript($"window.scrollTo(0,{loc.Y})");
            //loc = this.WebDriver.FindElement(By.XPath("//tr[last()]/td[2]/a")).Location;
            ////string cssSelector = ".customer-search.form-group.row > .control-label";
            ////this.WebDriver.ExecuteJavaScript("window.scrollTo(0,document.body.scrollHeight);");
            // 
            // Successfull
            //////var scorllableElement = "scope-content";
            //////this.WebDriver.ExecuteJavaScript($"window[`scrolls.{scorllableElement}`].scrollTo(0,100,0);");

            //Expect(newUserstory);
            ExpectXPath($"//tr[last()]//strong[text()='{C.addedUserstory}']");
        }
    }
}
