namespace Admin
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
            int nextTestProjNewIdx = Convert.ToInt32(U.TestProjIdx) + 1;
            U.UpdateFile(U.TestProjIdxFile_FullPath, new string[] { $"{nextTestProjNewIdx}" });


            U.LoginAdmin(this, isFirstTime: true);
        }
    }
}
