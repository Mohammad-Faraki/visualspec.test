namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_MyProjects : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            Click("My Projects");
            WaitForNewPage();

            Expect("New Project", Casing.Exact);
            ExpectXPath("//input[@value='Search']");



            ExpectLabel("All", Casing.Exact);
            ExpectXPath("//input[@id='Main_ctl00_lstUserArchived_0']");

            ExpectLabel("Archived", Casing.Exact);
            ExpectXPath("//input[@id='Main_ctl00_lstUserArchived_1']");

            ExpectLabel("Live", Casing.Exact);
            ExpectXPath("//input[@id='Main_ctl00_lstUserArchived_2']");



            ExpectXPath("//input[@placeholder='Enter project name or user name']");
        }



    }
}
