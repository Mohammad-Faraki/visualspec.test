namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class PreconWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();


            U.AddFeature(this, U.feature01);
            Thread.Sleep(500);



            U.OpenWorkflow(this);
        }



    }
}
