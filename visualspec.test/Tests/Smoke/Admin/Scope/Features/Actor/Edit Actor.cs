namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class EditActor : UITest
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
            var btnEdit = $"{C.thirdActorXPath}//a[{U.XPathText(Casing.Exact, "Edit")}]";
            WaitToSeeXPath(btnEdit);
            ClickXPath(btnEdit);
            Set("Name").To(C.editedActor);
            Click("Save");
            Expect(C.editedActor);
        }



    }
}
