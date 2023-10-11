namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class DeleteUsecase : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUsecase>();


            Clean();
        }

        private void Clean()
        {
            //*********** Delete usecase
            //MyUtils.DeleteUsecase(this, MyUtils.f1Usecase2);
            U.DeleteUsecase(this, U.f1Usecase1, featureIdx: 1, usecaseIdx: 1);
        }
    }
}
