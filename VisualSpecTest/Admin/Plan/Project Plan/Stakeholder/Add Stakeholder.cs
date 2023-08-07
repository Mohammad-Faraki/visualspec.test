namespace Admin.Plan.Stakeholder
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class AddStakeholder : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<OpenProjectPlan>();
            Thread.Sleep(2000);


            //*********** Create stakeloder
            U.AddStakeholder(this, U.stakeholder1);
        }



    }
}
