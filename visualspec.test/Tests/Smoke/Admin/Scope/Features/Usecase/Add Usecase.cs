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
            Utils.AddFeature(this, Utils.feature01);


            //*********** Add usecase
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Const.scrollable_scopeFeatures_treeView));
            Utils.AddUsecase(this, Utils.feature01, Utils.f1Usecase1, Utils.DefaultActors.Admin);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Const.scrollable_scopeFeatures_treeView));
            Expect(Utils.f1Usecase1);


        }
        
    }
}
