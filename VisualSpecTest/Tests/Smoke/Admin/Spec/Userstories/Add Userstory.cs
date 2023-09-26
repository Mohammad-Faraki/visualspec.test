namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Shared.Admin.Userstories;

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

            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            U.AddUsecase(this, U.feature01, U.f1Usecase1, U.DefaultActors.Admin/*, MyUtils.DefaultApplications.WebApp*/
                , new Tuple<U.Estimate, U.Estimate>(U.Estimate.XS, U.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Expect(U.f1Usecase1);

            U.OpenUserstories(this);
            Thread.Sleep(2000);


            //*********** Create userstory
            ClickXPath("//a[@name='NewUserJourney']");
            string pageTitle = "User Journey Details";
            WaitToSee(pageTitle);

            // Set fields of userstory 
            Set(That.Contains, "Description").To(C.addedUserstory);

            //NearLabel("Features").ClickButton("Nothing selected");
            U.OpenDropdown(this, "Nothing selected", $"//label[{U.XPathTextContains("Features")}]/{U.following_sibling}::div");
            ClickLink(U.feature01);
            ClickHeader(pageTitle);

            Thread.Sleep(3000);

            //NearLabel("Use case").ClickButton("Nothing selected");
            U.OpenDropdown(this, "Nothing selected", $"//label[{U.XPathTextContains("Use case")}]/{U.following_sibling}::div");
            ClickLink(U.f1Usecase1);
            ClickHeader(pageTitle);

            ClickButton(That.Contains, "Save and next");
            Thread.Sleep(5000);

            U.OpenUserstories(this);
            Thread.Sleep(2000);

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
            U.ScrollToBottom(this, Shared.Admin.Userstories.C.scrollable_mainContent);
            ExpectXPath($"//tr[last()]//*[text()='{C.addedUserstory}']");
        }
    }
}
