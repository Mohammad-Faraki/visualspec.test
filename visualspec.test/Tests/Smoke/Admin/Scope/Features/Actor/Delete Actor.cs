namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class DeleteActor : UITest
    {

        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddActor>();



            ////*********** Delete actor 
            // Three dots
            ClickXPath(C.btnThreeDotsActorXPath);
            // Delete
            var btnDeleteXPath = $"{C.thirdActorXPath}//a[{Utils.XPathTextContains(Casing.Exact, "Delete")}]";
            WaitToSeeXPath(btnDeleteXPath);
            ClickXPath(btnDeleteXPath);
            WaitToSee("Deleting this actor will delete all its associated data in other microservices. Are you sure you want to delete this actor?");
            Click("OK");
            ExpectNo(C.addedActor);
        }



    }
}
