namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class DeleteApplication : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddApplication>();



            ////*********** Delete application 
            // Three dots
            ClickXPath(C.btnThreeDotsAppXPath);
            // Delete
            var btnDeleteXPath = $"{C.thirdAppXPath}//a[{U.XPathTextContains(Casing.Exact, "Delete")}]";
            WaitToSeeXPath(btnDeleteXPath);
            ClickXPath(btnDeleteXPath);
            WaitToSee("Deleting this application will delete all its associated data in other microservices. Are you sure you want to delete this application?");
            Click("OK");
            ExpectNo(C.addedApp);
        }



    }
}
