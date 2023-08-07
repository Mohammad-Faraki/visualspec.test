namespace Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class OpenContactUs : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            U.OpenContactUs(this);
        }



    }
}
