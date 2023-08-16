namespace Admin.Scope.Features.Minor
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class DeleteIntegrationByPopup : UITest
    {

        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddIntegration>();


            //*********** Edit integration
            // Three dots
            ClickXPath(U.btnThreeDotsIntegrationXPath(C.addedIntegration));
            // Edit
            ClickXPath(C.btnEditIntegrationXPath);

            AtXPath(C.formIntegrationDetails).Click("Delete");
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(C.addedIntegration);
        }



    }
}
