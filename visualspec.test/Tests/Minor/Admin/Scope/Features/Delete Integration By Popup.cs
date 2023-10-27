namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Scope.Features;

    [TestClass]
    public class DeleteIntegrationByPopup : UITest
    {

        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddIntegration>();


            //*********** Edit integration
            // Three dots
            ClickXPath(Utils.btnThreeDotsIntegrationXPath(Const.addedIntegration));
            // Edit
            ClickXPath(Const.btnEditIntegrationXPath);

            AtXPath(Const.formIntegration).Click("Delete");
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(Const.addedIntegration);
        }



    }
}
