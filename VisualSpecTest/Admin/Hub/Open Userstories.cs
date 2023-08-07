namespace Admin
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class OpenUserstories : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();

            U.OpenUserstories(this);
        }



    }
}
