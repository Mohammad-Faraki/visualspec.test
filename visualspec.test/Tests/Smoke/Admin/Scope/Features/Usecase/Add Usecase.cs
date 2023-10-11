namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using OpenQA.Selenium.Support.Extensions;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class AddUsecase : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // deleting a feature that as usecase has error

            Run<CreateOpenProject>();




            //*********** Add feature
            U.AddFeature(this, U.feature01);


            //*********** Add usecase
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(C.scrollable_scopeFeatures_treeView));
            U.AddUsecase(this, U.feature01, U.f1Usecase1, U.DefaultActors.Admin);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(C.scrollable_scopeFeatures_treeView));
            Expect(U.f1Usecase1);


        }
        
    }
}
