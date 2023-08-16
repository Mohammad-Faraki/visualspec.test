namespace Admin.Scope.Features.Minor
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;
    using static System.Net.Mime.MediaTypeNames;

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
