namespace Tests.Smoke.Admin.Checkpoints
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     

    [TestClass]
    public class DeleteCheckpoint : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<AddCheckpoint>();
            Run<EditCheckpoint>();


            ClickXPath("//tr[1]//a[@name='Delete']");
            WaitToSee("Are you sure you want to delete this checkpoint?");
            Click("OK");

            ExpectNo(U.checkpoint2);

        }



    }
}
