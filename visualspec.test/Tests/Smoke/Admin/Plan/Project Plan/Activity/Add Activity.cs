namespace Tests.Smoke.Admin.Plan.Activity
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     

    [TestClass]
    public class AddActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<OpenProjectPlan>();
            Thread.Sleep(2000);


            //MyUtils.AddStakeholder(this,MyUtils.stakeholder1);

            U.OpenPlanActivities(this);

            ClickXPath("//a[@name='Activity']");
            //Click("---Select---");
            U.OpenDropdown(this, "---Select---");
            Click("Co-design workshop");
            Click("Save");
            WaitToSee("All Use Cases / Integrations");
            Click("Back");
            WaitToSeeButton("Generate Activities");
            AtRow(1).Expect("Co-design workshop");
        }



    }
}
