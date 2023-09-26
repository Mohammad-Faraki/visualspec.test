namespace Tests.Minor.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;
    using Tests.Smoke.Admin.ObjectMap;

    [TestClass]
    public class ViewOwnerFeatures : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();


            ClickXPath($"//span[{U.XPathText(C.O1F1)}]");
            Thread.Sleep(3000);
            //MyUtils.ScrollToBottom(this, "objectmap-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("objectmap-content"));

            AtXPath(C.formBottomSectionXPath).ClickButton("Edit");
            Thread.Sleep(3000);

            // Owner feature
            //AtXPath(C.formBottomSectionXPath).ClickButton( U.feature01);
            U.OpenDropdown(this, U.feature01, C.formBottomSectionXPath);
            NearXPath(C.formBottomSectionXPath).ExpectLink(U.feature01);
            NearXPath(C.formBottomSectionXPath).ExpectLink(U.feature02);
            // it has no usecase
            NearXPath(C.formBottomSectionXPath).ExpectNo(U.feature03);
        }



    }
}
