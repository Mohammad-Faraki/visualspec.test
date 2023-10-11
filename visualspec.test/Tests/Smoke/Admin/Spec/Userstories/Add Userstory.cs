namespace Tests.Smoke.Admin.Userstories
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Shared.Admin.Userstories;

    [TestClass]
    public class AddUserstory : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenFeatures>();
            Thread.Sleep(2000);


            Utils.AddFeature(this, Utils.feature01);
            Utils.AddFeature(this, Utils.feature02);

            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Utils.AddUsecase(this, Utils.feature01, Utils.f1Usecase1, Utils.DefaultActors.Admin/*, MyUtils.DefaultApplications.WebApp*/
                , new Tuple<Utils.Estimate, Utils.Estimate>(Utils.Estimate.XS, Utils.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Expect(Utils.f1Usecase1);

            Utils.OpenUserstories(this);
            Thread.Sleep(2000);


            //*********** Create userstory
            ClickXPath("//a[@name='NewUserJourney']");
            string pageTitle = "User Journey Details";
            WaitToSee(pageTitle);

            // Set fields of userstory 
            Set(That.Contains, "Description").To(C.addedUserstory);

            //NearLabel("Features").ClickButton("Nothing selected");
            Utils.OpenDropdown(this, "Nothing selected", $"//label[{Utils.XPathTextContains(Casing.Exact, "Features")}]/{Utils.following_sibling_XPath}::div");
            ClickLink(Utils.feature01);
            ClickHeader(pageTitle);

            Thread.Sleep(3000);

            //NearLabel("Use case").ClickButton("Nothing selected");
            Utils.OpenDropdown(this, "Nothing selected", $"//label[{Utils.XPathTextContains(Casing.Exact, "Use case")}]/{Utils.following_sibling_XPath}::div");
            ClickLink(Utils.f1Usecase1);
            ClickHeader(pageTitle);

            ClickButton(That.Contains, "Save and next");
            Thread.Sleep(5000);

            Utils.OpenUserstories(this);
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
            Utils.ScrollToBottom(this, Shared.Admin.Userstories.C.scrollable_mainContent);
            ExpectXPath($"//tr[last()]//*[text()='{C.addedUserstory}']");
        }
    }
}
