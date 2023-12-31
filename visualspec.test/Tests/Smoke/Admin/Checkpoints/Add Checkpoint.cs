﻿namespace Tests.Smoke.Admin.Checkpoints
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     

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

            Set(That.Contains,"Name").To(Utils.checkpoint1);
            Click(What.Contains,"Save");
            Thread.Sleep(4000);
            AtXPath("//form[@data-module='CheckpointList']//tr//td[1]").Expect(Utils.checkpoint1);

        }



    }
}
