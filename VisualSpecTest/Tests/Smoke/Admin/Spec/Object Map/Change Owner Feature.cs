namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;
    using Tests.Minor.Admin.ObjectMap;

    [TestClass]
    public class ChangeOwnerFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<ViewOwnerFeatures>();


            AtXPath(C.formBottomSectionXPath).ClickLink("feature02");

            AtXPath(C.formBottomSectionXPath).ClickButton("Save");

            Thread.Sleep(4000);
            U.ScrollToTop(this, "objectmap-content");
            ExpectNoXPath($"//span[{U.XPathText(C.O1F1)}]");


            C.OpenFeaturePage(this, "feature02");
            ExpectXPath($"//span[{U.XPathText(C.O1F1)}]");
        }



    }
}
