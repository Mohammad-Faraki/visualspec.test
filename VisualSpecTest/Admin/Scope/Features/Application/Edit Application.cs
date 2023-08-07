namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

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
