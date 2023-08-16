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

            U.CreateProject(this);



            U.SearchProject(this);
            U.OpenProjectDetails(this, 1);
            ExpectXPath($"{U.frmProjectDetailsXPath}//input[{U.XPathAttribute("value",U.TestProjectName)}]");
            ExpectXPath($"{U.frmProjectDetailsXPath}//*[{U.XPathText("Description01")}]");

            string editedProjectName = $"{U.TestProjectName} edited";
            string editedDescription = "Description01 edited";
            Set(That.Contains,"Name").To(editedProjectName);
            Set(That.Contains, "Description").To(editedDescription);
            ClickLink("Save");

            Expect(What.Contains, editedProjectName);



            RefreshPage();
            WaitToSee("New Project");


            U.OpenProjectDetails(this, 1);
            ExpectXPath($"{U.frmProjectDetailsXPath}//input[{U.XPathAttribute("value", editedProjectName)}]");
            ExpectXPath($"{U.frmProjectDetailsXPath}//*[{U.XPathText(editedDescription)}]");
        }



    }
}
