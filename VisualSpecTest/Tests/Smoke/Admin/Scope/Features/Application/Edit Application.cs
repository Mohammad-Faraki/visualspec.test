namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class EditApplication : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddApplication>();



            C.OpenApplicationDetails(this, C.addedApp);

            Set("Name").To(C.editedApp);
            Click("Save");
            Expect(C.editedApp);
        }



    }
}
