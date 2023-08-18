namespace Tests.Smoke.Admin.Northstar
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class DeleteNorthstar : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddNorthstar>();
            Thread.Sleep(3000);

            //*********** Delete northstar
            ClickXPath("//a[@name='DeleteNorthstar']");
            WaitToSee("Are you sure you want to delete this northstar?");
            ClickButton("OK");
            ExpectNo(What.Contains, "Northstar 2");

        }



    }
}
