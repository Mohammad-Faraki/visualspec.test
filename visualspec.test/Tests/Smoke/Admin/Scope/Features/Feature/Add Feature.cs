namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class AddFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();



            //*********** Add feature
            Utils.AddFeature(this, Utils.feature01);
            Utils.AddFeature(this, Utils.feature02);
            // "text()='feature01'" is added to end of xpath by me
            // Check "feature01" is first element in the list and MyUtils.feature02 is second element
            ExpectXPath($"//*[@data-module='TreeFeatures']//ul/li[1]//a[{Utils.XPathText(Casing.Exact, Utils.feature01)}]");
            ExpectXPath($"//*[@data-module='TreeFeatures']//ul/li[2]//a[{Utils.XPathText(Casing.Exact, Utils.feature02)}]");
        }
    }
}
