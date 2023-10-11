namespace Tests.Smoke.Admin
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class OpenCheckpoints : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();

            Utils.OpenCheckpoints(this);
        }



    }
}
