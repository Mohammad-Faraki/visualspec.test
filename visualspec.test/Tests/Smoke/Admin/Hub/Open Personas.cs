﻿namespace Tests.Smoke.Admin
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class OpenPersonas : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();

            Utils.OpenPersonas(this);
        }



    }
}
