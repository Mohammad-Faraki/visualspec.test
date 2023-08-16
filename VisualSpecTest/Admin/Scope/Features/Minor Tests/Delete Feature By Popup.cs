namespace Admin.Scope.Features.Minor
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class DeleteFeatureByPopup : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddFeature>();




            //*********** Edit features
            ClickXPath(U.btnThreeDotsFeatureXPath(U.feature01));
            WaitToSee(What.Contains, "Add Use case");
            Near(What.Contains, U.feature01).Below(What.Contains, "Add Use case").Click(What.Contains, "Edit");

            AtXPath(C.formFeatureDetails).Click("Delete");
            WaitToSee("Deleting this feature will delete all its associated data in other microservices. Are you sure you want to delete this feature?");
            Click("OK");
            ExpectNo(U.feature01);
        }
    }
}
