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

            U.AddIntegration(this, integrationName: C.addedIntegration);
        }



    }
}
