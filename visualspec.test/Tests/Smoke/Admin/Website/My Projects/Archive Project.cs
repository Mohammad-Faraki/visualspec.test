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
            ClickXPath($"{U.frmProjectDetailsXPath}//*[{U.XPathText(Casing.Exact, "Archive")}]");
            ExpectNoXPath($"//tr[1]//*[{U.XPathTextContains(Casing.Exact, U.TestProjectName)}]" );


            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains(Casing.Exact, "All")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText(Casing.Exact, "Archived")}]");

            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains(Casing.Exact, "Archived")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText(Casing.Exact, "Archived")}]");
        }



    }
}
