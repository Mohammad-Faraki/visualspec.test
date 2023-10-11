namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;

    [TestClass]
    public class DeleteObject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();


            //MyUtils.ScrollToBottom(this, "objectmap-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("objectmap-content"));

            AtXPath(C.formBottomSectionXPath).ClickButton("Edit");
            Thread.Sleep(3000);

            ClickButton("Delete");
            Expect("Are you sure you want to delete this object?");
            Click("OK");
            ExpectNo(C.O1F1);

        }



    }
}
