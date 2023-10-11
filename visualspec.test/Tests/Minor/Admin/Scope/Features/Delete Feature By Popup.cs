namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Scope.Features;

    [TestClass]
    public class DeleteFeatureByPopup : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddFeature>();




            //*********** Edit features
            ClickXPath(Utils.btnThreeDotsFeatureXPath(Utils.feature01));
            Expect(What.Contains, "Add Use case");
            Near(What.Contains, Utils.feature01).Below(What.Contains, "Add Use case").Click(What.Contains, "Edit");

            AtXPath(C.formFeature).Click("Delete");
            WaitToSee("Deleting this feature will delete all its associated data in other microservices. Are you sure you want to delete this feature?");
            Click("OK");
            ExpectNo(Utils.feature01);
        }
    }
}
