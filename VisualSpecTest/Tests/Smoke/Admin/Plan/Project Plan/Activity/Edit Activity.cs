namespace Tests.Smoke.Admin.Plan.Activity
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class EditActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddActivity>();

            
            AtRow(1).Click("Co-design workshop");
            WaitToSee("All Use Cases / Integrations");
            ClickButton("Co-design workshop");
            Click("Product design");
            Click("Save");
            WaitToSeeButton("Generate Activities");
            AtRow(1).Expect("Product design");
        }



    }
}
