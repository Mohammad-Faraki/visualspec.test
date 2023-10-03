namespace Tests.Smoke.Admin.Checkpoints
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     

    [TestClass]
    public class EditCheckpoint : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddCheckpoint>();


            ClickXPath("//tr[1]//a[@name='Edit']");
            WaitToSee("Edit checkpoint");

            Set(That.Contains,"Name").To(U.checkpoint2);
            Click(What.Contains,"Save");
            Expect(U.checkpoint2);

        }



    }
}
