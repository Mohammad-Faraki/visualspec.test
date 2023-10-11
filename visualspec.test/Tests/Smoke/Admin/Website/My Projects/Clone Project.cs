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

            U.CreateProject(this);



            U.SearchProject(this);
            U.OpenProjectDetails(this, 1);
            ClickLabel(That.Contains,"Can be cloned");
            ClickLink("Save");

            U.OpenProjectDetails(this, 1);
            ClickLink("Clone");
            string clonedProjName = $"{U.TestProjectName}-clone";
            Expect(clonedProjName);
            ClickLink("Clone");

            ExpectXPath($"//tr[1]//*[{U.XPathTextContains(Casing.Exact, U.TestProjectName)}]");
        }



    }
}
