namespace Tests.Shared.Admin.Scope.Estimate
{
    using OpenQA.Selenium;
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    public static class C
    {
        public const string addedActiviy = "activity01";
        public const string editedActiviy = "activity02";

        public static int IntegrationTable_Y(UITest uiTest) => uiTest.WebDriver.FindElement(By.XPath("//form[@data-module='IntegrationsWithFeatureList']")).Location.Y;
        public static void ScrollToLastActivity(UITest uiTest)
        {
            var vHeight = U.GetViewPortHeight(uiTest);
            U.ScrollTo(uiTest, "scope-content", IntegrationTable_Y(uiTest) - (vHeight/2));
        }
        public static void ScrollToTop(UITest uiTest) => U.ScrollToTop(uiTest, "scope-content");

    }
}
