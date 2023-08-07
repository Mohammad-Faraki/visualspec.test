namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class AddFeature : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<CreateOpenProject>();



            //*********** Add feature
            U.AddFeature(this, U.feature01);
            U.AddFeature(this, U.feature02);
            // "text()='feature01'" is added to end of xpath by me
            // Check "feature01" is first element in the list and MyUtils.feature02 is second element
            ExpectXPath($"//*[@data-module='TreeFeatures']//ul/li[1]//a[{U.XPathText(U.feature01)}]");
            ExpectXPath($"//*[@data-module='TreeFeatures']//ul/li[2]//a[{U.XPathText(U.feature02)}]");
        }
    }
}
