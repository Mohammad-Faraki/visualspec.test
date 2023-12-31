﻿namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;

    [TestClass]
    public class EditObject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();


            ClickXPath($"//span[{Utils.XPathText(Casing.Exact, Const.O1F1)}]");
            Thread.Sleep(3000);
            //MyUtils.ScrollToBottom(this, "objectmap-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom("objectmap-content"));

            AtXPath(Const.formBottomSectionXPath).ClickButton("Edit");
            Thread.Sleep(3000);

            string inputNameXPath = $"//input[@value='{Const.O1F1}']";
            ExpectXPath(inputNameXPath);
            // Owner feature
            ExpectButton("feature01");

            SetXPath(inputNameXPath).To(Const.O1F1Edited);
            ClickButton("Save");
            Thread.Sleep(3000);
            AtXPath(Const.bottomSectionViewModeXPath).Expect(What.Contains, Const.O1F1Edited);

            AtXPath(Const.formBottomSectionXPath).ClickButton("Edit");
            Thread.Sleep(3000);

            string inputNameEditedXPath = $"//input[@value='{Const.O1F1Edited}']";
            ExpectXPath(inputNameEditedXPath);

            RefreshPage();
            WaitToSeeLink("Object Details");

            //MyUtils.ScrollToBottom(this, "objectmap-content", this.WebDriver);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom("objectmap-content"));

            ExpectXPath(inputNameEditedXPath);
            ClickButton("Save");
            Thread.Sleep(3000);
            AtXPath(Const.bottomSectionViewModeXPath).Expect(What.Contains, Const.O1F1Edited);
        }



    }
}
