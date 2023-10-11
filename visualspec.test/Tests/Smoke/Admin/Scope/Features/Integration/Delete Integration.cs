namespace Tests.Smoke.Admin.Scope.Features
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class DeleteIntegration : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddIntegration>();





            ////*********** Delete integration 
            // Three dots
            ClickXPath(Utils.btnThreeDotsIntegrationXPath(C.addedIntegration));
            // Delete
            var btnDeleteXPath = $"//*[@data-module='TreeIntegrations']//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Delete")}]";
            WaitToSeeXPath(btnDeleteXPath);
            ClickXPath(btnDeleteXPath);
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(C.addedIntegration);
        }



    }
}
