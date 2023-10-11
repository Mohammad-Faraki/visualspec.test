namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class AdminUser : UITest
    {
        public override void RunTest()
        {
            int nextTestProjNewIdx = Convert.ToInt32(Utils.TestProjIdx) + 1;
            Utils.UpdateFile(Utils.TestProjIdxFile_FullPath, new string[] { $"{nextTestProjNewIdx}" });


            Utils.LoginAdmin(this, isFirstTime: true);
        }
    }
}
