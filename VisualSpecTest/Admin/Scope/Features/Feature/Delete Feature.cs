namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class DeleteFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddFeature>();




            ////*********** Delete features
            U.DeleteFeature(this, U.feature01);
            Thread.Sleep(2000);
            U.DeleteFeature(this, U.feature02);

            ExpectNo(U.feature01);
            ExpectNo(U.feature02);
        }
    }
}
