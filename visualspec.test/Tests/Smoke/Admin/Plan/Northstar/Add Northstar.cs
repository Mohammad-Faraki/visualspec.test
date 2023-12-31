﻿namespace Tests.Smoke.Admin.Northstar
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Shared.Admin.Northstar;

    [TestClass]
    public class AddNorthstar : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // "Productivity Gam" should be changed to "Productivity Game"
            Run<OpenNorthstar>();
            Thread.Sleep(2000);


            //*********** Create northstar
            ClickXPath($"//*[{Utils.XPathHasDirectElement($"*[{Utils.XPathTextContains(Casing.Exact, "North Stars")}]")}]/following-sibling::a");

            var northstarXPath = $"//ul//li[last()]//a[text()='{Const.addedNorthstar}']";
            ExpectXPath(northstarXPath);
            ClickXPath(northstarXPath);
            WaitToSeeXPath($"//input[@value='{Const.addedNorthstar}']");
        }



    }
}
