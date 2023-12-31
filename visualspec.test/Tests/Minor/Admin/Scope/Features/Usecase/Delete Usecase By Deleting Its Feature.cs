﻿namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Scope.Features;
    using Tests.Smoke.Admin.Website;

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
            Utils.DeleteFeature(this, Utils.feature01);
            ExpectNo(Utils.feature01);
            ExpectNo(Utils.f1Usecase1);

        }
    }
}
