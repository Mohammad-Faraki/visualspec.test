namespace Tests.Smoke.Admin.Checkpoints
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class AddCheckpoint : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<OpenCheckpoints>();
            Thread.Sleep(2000);


            ClickXPath("//a[@name='NewCheckpoint']");
            WaitToSee("Add checkpoint");

            Set(That.Contains,"Name").To(U.checkpoint1);
            Click(What.Contains,"Save");
            Expect(U.checkpoint1);

        }



    }
}
