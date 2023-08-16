namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using static System.Net.Mime.MediaTypeNames;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Scope.Features;

    [TestClass]
    public class DeleteApplicationByPopup : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddApplication>();



            C.OpenApplicationDetails(this, C.addedApp);

            AtXPath(C.formApplicationDetailsXPath).Click("Delete");
            Expect("Deleting this application will delete all its associated data in other microservices. Are you sure you want to delete this application?");
            Click("OK");
            ExpectNo(C.addedApp);
        }



    }
}
