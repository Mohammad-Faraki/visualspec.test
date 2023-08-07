namespace Admin.Plan.Activity
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

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
            Click("---Select---");
            Click("Co-design workshop");
            Click("Save");
            WaitToSee("All Use Cases / Integrations");
            Click("Back");
            WaitToSeeButton("Generate Activities");
            AtRow(1).Expect("Co-design workshop");
        }



    }
}
