namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class ArchiveProject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            U.CreateProject(this);




            U.SearchProject(this);
            U.OpenProjectDetails(this, 1);
            ClickXPath($"{U.frmProjectDetailsXPath}//*[{U.XPathText("Archive")}]");
            ExpectNoXPath($"//tr[1]//*[{U.XPathTextContains(U.TestProjectName)}]" );


            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains("All")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText("Archived")}]");

            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains("Archived")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText("Archived")}]");
        }



    }
}
