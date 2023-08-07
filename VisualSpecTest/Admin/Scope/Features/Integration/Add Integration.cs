namespace Admin.Scope.Features
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class AddIntegration : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<CreateOpenProject>();



            //*********** Add integration
            ClickXPath($"//a[@name='CreateIntegration']");
            WaitToSee("Add integration");
            Set("Name").To(C.addedIntegration);
            ExpectNoButton(That.Contains, "Delete");
            Click("Save");
            Expect(C.addedIntegration);
        }



    }
}
