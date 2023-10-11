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

            Utils.OpenProjectDetails(this,1);
            ClickXPath($"{Utils.frmProjectDetailsXPath}//*[{Utils.XPathText(Casing.Exact, "Un Archive")}]");
            ExpectNoXPath($"//tr[1]//*[{Utils.XPathTextContains(Casing.Exact, Utils.TestProjectName)}]");


            ClickXPath($"//*[{Utils.XPathAttributeContains("id", "lstUserArchived")}]//*[{Utils.XPathTextContains(Casing.Exact, "All")}]");
            Utils.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{Utils.XPathText(Casing.Exact, "Open")}]");

            ClickXPath($"//*[{Utils.XPathAttributeContains("id", "lstUserArchived")}]//*[{Utils.XPathTextContains(Casing.Exact, "Live")}]");
            Utils.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{Utils.XPathText(Casing.Exact, "Open")}]");
        }



    }
}
