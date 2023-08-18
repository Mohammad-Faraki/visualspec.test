namespace Tests.Smoke.Admin.Northstar
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
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
            ClickXPath($"//*[{U.XPathHasDirectElement($"*[{U.XPathTextContains("North Stars")}]")}]/following-sibling::a");

            var northstarXPath = $"//ul//li[last()]//a[text()='{C.addedNorthstar}']";
            ExpectXPath(northstarXPath);
            ClickXPath(northstarXPath);
            WaitToSeeXPath($"//input[@value='{C.addedNorthstar}']");
        }



    }
}
