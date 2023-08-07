namespace Admin.Scope.Estimate
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class ManageUsecaseFromScopeEstimate : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            string addedIntegration = "integration01";
            string editedIntegration = "integration02";


            Run<OpenFeatures>();
            Thread.Sleep(2000);


            U.AddFeature(this, U.feature01);

            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-tree"));
            //*********** Add usecase
            U.AddUsecase(this, U.feature01, U.f1Usecase1, U.DefaultActors.Customer);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-tree"));
            Expect(U.f1Usecase1);

            Run<OpenEstimate>();
            Thread.Sleep(2000);

            //MyUtils.ScrollToBottom(this, "scope-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-content"));


            ClickXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[1]");
            Thread.Sleep(1000);
            ClickXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[3]");
            Thread.Sleep(1000);
            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[3][@class='selected']");

            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");

            //MyUtils.ScrollToBottom(this, "scope-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-content"));

            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='UseCaseList']//tr[1]/td[4]/div/div[3][@class='selected']");
        }
    }
}
