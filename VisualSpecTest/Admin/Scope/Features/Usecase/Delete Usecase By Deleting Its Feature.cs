namespace Admin.Scope.Features.Usecase
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class DeleteUsecaseByDeletingItsFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUsecase>();


            Clean();
        }

        private void Clean()
        {
            //*********** Delete usecase by deleteing its feature
            U.DeleteFeature(this, U.feature01);
            ExpectNo(U.feature01);
            ExpectNo(U.f1Usecase1);

        }
    }
}
