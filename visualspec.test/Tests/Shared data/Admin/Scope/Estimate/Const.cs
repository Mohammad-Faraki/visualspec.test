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
    

    public static class Const
    {
        public const string addedActiviy = "activity01";
        public const string editedActiviy = "activity02";

        public const string addedIntegration = "integration01";
        public const string editedIntegration = "integration01 edited";

        public const string btnEditIntegraionXPath = "//form[@data-module='IntegrationsWithFeatureList']//tr[last()]//a[@name='Edit']";
        public const string formIntegrationXPath = "//form[@data-module='IntegrationForm']";

        public const string scrollable_mainContent = "scope-content";

        public const string listIntegrationsXPath = "//*[@data-module='IntegrationsWithFeatureList']";

        public static int IntegrationTable_Y(UITest uiTest) => uiTest.WebDriver.FindElement(By.XPath("//form[@data-module='IntegrationsWithFeatureList']")).Location.Y;
        public static void ScrollToLastActivity(UITest uiTest)
        {
            var vHeight = Utils.GetViewPortHeight(uiTest);
            Utils.ScrollTo(uiTest, "scope-content", IntegrationTable_Y(uiTest) - (vHeight/2));
        }
        public static void ScrollToTop(UITest uiTest) => Utils.ScrollToTop(uiTest, "scope-content");

    }
}
