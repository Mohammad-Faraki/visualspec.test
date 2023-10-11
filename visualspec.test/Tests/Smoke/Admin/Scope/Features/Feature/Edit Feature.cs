namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class EditFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddFeature>();




            //*********** Edit features
            ClickXPath(Utils.btnThreeDotsFeatureXPath(Utils.feature01));
            Expect(What.Contains, "Add Use case");
            Near(What.Contains, Utils.feature01).Below(What.Contains, "Add Use case").Click(What.Contains, "Edit");
            Set("Name").To(C.editedFeature01);
            Click("Save");
            Expect(C.editedFeature01);

            ClickXPath(Utils.btnThreeDotsFeatureXPath(Utils.feature02));
            Expect(What.Contains, "Add Use case");
            Near(What.Contains, Utils.feature02).Below(What.Contains, "Add Use case").Click(What.Contains, "Edit");
            Set("Name").To(C.editedFeature02);
            Click("Save");
            Expect(C.editedFeature02);
        }
    }
}
