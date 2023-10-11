namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class CloneProject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            Utils.CreateProject(this);



            Utils.SearchProject(this);
            Utils.OpenProjectDetails(this, 1);
            ClickLabel(That.Contains,"Can be cloned");
            ClickLink("Save");

            Utils.OpenProjectDetails(this, 1);
            ClickLink("Clone");
            string clonedProjName = $"{Utils.TestProjectName}-clone";
            Expect(clonedProjName);
            ClickLink("Clone");

            ExpectXPath($"//tr[1]//*[{Utils.XPathTextContains(Casing.Exact, Utils.TestProjectName)}]");
        }



    }
}
