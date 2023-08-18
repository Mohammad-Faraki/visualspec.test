namespace Tests.Smoke.Admin.Plan.Activity
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class DeleteActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddActivity>();

            ClickXPath("//tr[1]//button[@name='Delete']");
            WaitToSee("Are you sure you want to delete this item?");
            Click("OK");

            WaitToSee(What.Contains, "There are no activities to display.");
        }



    }
}
