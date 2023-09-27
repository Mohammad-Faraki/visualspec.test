namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;
    using Tests.Minor.Admin.ObjectMap;
    using OpenQA.Selenium;

    [TestClass]
    public class ChangeOwnerFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<ViewOwnerFeatures>();


            //Near(C.formBottomSectionXPath).ClickLink(U.feature02);
            ////AtXPath("//*[class='right-panel']").ClickLink(U.feature02);
            var x = this.WebDriver.FindElements(By.XPath($"//a[{U.XPathHasElement($"*[{U.XPathText(Casing.Exact, U.feature02)}]")}]"));
            x[0].Click();

            AtXPath(C.formBottomSectionXPath).ClickButton("Save");

            Thread.Sleep(4000);
            U.ScrollToTop(this, "objectmap-content");
            ExpectNoXPath($"//span[{U.XPathText(Casing.Exact, C.O1F1)}]");


            C.OpenFeaturePage(this, U.feature02);
            ExpectXPath($"//span[{U.XPathText(Casing.Exact, C.O1F1)}]");
        }



    }
}
