namespace Tests.Smoke.Admin.Scope.Features
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

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
