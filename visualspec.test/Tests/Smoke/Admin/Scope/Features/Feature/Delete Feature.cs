namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class DeleteFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddFeature>();




            ////*********** Delete features
            Utils.DeleteFeature(this, Utils.feature01);
            Thread.Sleep(2000);
            Utils.DeleteFeature(this, Utils.feature02);

            ExpectNo(Utils.feature01);
            ExpectNo(Utils.feature02);
        }
    }
}
