namespace Admin
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class OpenCheckpoints : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();

            U.OpenCheckpoints(this);
        }



    }
}
