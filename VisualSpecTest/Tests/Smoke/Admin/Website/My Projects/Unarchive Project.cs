namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UnarchiveProject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<ArchiveProject>();

            U.OpenProjectDetails(this,1);
            ClickXPath($"{U.frmProjectDetailsXPath}//*[{U.XPathText("Un Archive")}]");
            ExpectNoXPath($"//tr[1]//*[{U.XPathTextContains(U.TestProjectName)}]");


            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains("All")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText("Open")}]");

            ClickXPath($"//*[{U.XPathAttributeContains("id", "lstUserArchived")}]//*[{U.XPathTextContains("Live")}]");
            U.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{U.XPathText("Open")}]");
        }



    }
}
