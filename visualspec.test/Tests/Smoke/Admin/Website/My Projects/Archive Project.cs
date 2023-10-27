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

            Utils.CreateProject(this);




            Utils.SearchProject(this);
            Utils.OpenProjectDetails(this, 1);
            ClickXPath($"{Utils.frmProjectDetailsXPath}//*[{Utils.XPathText(Casing.Exact, "Archive")}]");
            ExpectNoXPath($"//tr[1]//*[{Utils.XPathTextContains(Casing.Exact, Utils.TestProjectName)}]" );


            ClickXPath($"//*[{Utils.XPathAttributeContains("id", "lstUserArchived")}]//*[{Utils.XPathTextContains(Casing.Exact, "All")}]");
            Utils.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{Utils.XPathText(Casing.Exact, "Archived")}]");

            ClickXPath($"//*[{Utils.XPathAttributeContains("id", "lstUserArchived")}]//*[{Utils.XPathTextContains(Casing.Exact, "Archived")}]");
            Utils.SearchProject(this);
            ExpectXPath($"//tr[1]//*[{Utils.XPathText(Casing.Exact, "Archived")}]");
        }



    }
}
