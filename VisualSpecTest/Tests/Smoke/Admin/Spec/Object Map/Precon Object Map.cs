using Tests.Smoke.Admin;

namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using System.Linq;

    [TestClass]
    public class PreconObjectMap : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();



            var features = new string[] { U.feature01, U.feature02, U.feature03, U.feature04 };
            var usecases = new string[]
            { U.f1Usecase1, U.f1Usecase2, U.f1Usecase3,
              U.f2Usecase1, U.f2Usecase2,
              U.f3Usecase1
            };
            U.AddUsecases(this, features, usecases);




            U.OpenObjectmap(this);
        }
    }
}

