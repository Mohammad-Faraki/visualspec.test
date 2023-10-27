namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class EditProjectDetails : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            Utils.CreateProject(this);



            Utils.SearchProject(this);
            Utils.OpenProjectDetails(this, 1);
            ExpectXPath($"{Utils.frmProjectDetailsXPath}//input[{Utils.XPathAttribute("value",Utils.TestProjectName)}]");
            ExpectXPath($"{Utils.frmProjectDetailsXPath}//*[{Utils.XPathText(Casing.Exact, "Description01")}]");

            string editedProjectName = $"{Utils.TestProjectName} edited";
            string editedDescription = "Description01 edited";
            Set(That.Contains,"Name").To(editedProjectName);
            Set(That.Contains, "Description").To(editedDescription);
            ClickLink("Save");

            Expect(What.Contains, editedProjectName);



            RefreshPage();
            WaitToSee("New Project");


            Utils.OpenProjectDetails(this, 1);
            ExpectXPath($"{Utils.frmProjectDetailsXPath}//input[{Utils.XPathAttribute("value", editedProjectName)}]");
            ExpectXPath($"{Utils.frmProjectDetailsXPath}//*[{Utils.XPathText(Casing.Exact, editedDescription)}]");
        }



    }
}
