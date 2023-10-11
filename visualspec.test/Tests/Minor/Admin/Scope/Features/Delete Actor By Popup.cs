namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Scope.Features;

    [TestClass]
    public class DeleteActorByPopup : UITest
    {

        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddActor>();



            //*********** Edit actor
            // Three dots
            ClickXPath(C.btnThreeDotsActorXPath);
            // Edit
            //var btnEdit= "li:nth-of-type(3) > .treeview-node__actions > a[target='$modal']";
            var btnEdit = $"{C.thirdActorXPath}//a[{Utils.XPathText(Casing.Exact, "Edit")}]";
            WaitToSeeXPath(btnEdit);
            ClickXPath(btnEdit);

            AtXPath(C.formActor).Click("Delete");
            Expect("Deleting this actor will delete all its associated data in other microservices. Are you sure you want to delete this actor?");
            Click("OK");
            ExpectNo(C.addedActor);
        }



    }
}
