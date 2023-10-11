namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
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
            var x = this.WebDriver.FindElements(By.XPath($"//a[{Utils.XPathHasElement($"*[{Utils.XPathText(Casing.Exact, Utils.feature02)}]")}]"));
            x[0].Click();

            AtXPath(C.formBottomSectionXPath).ClickButton("Save");

            Thread.Sleep(4000);
            Utils.ScrollToTop(this, "objectmap-content");
            ExpectNoXPath($"//span[{Utils.XPathText(Casing.Exact, C.O1F1)}]");


            C.OpenFeaturePage(this, Utils.feature02);
            ExpectXPath($"//span[{Utils.XPathText(Casing.Exact, C.O1F1)}]");
        }



    }
}
