namespace Tests.Smoke.Admin.Plan.Stakeholder
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     

    [TestClass]
    public class DeleteStakeholder : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddStakeholder>();
            
            //*********** Delete stakeloder
            U.DeleteStakeholder(this, -1);
            WaitToSeeNo(U.stakeholder1);


        }



    }
}
