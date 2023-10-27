namespace Tests.Smoke.Admin.Plan.DomainExpertise
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    

    [TestClass]
    public class PreconDomainExpertise : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<OpenFeatures>();
            //Thread.Sleep(3000);
            Run<CreateOpenProject>();


            Utils.AddFeature(this, Utils.feature01);
            Thread.Sleep(500);
            Utils.AddFeature(this, Utils.feature02);
            Thread.Sleep(500);



            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Utils.AddUsecase(this, Utils.feature01, Utils.f1Usecase1, Utils.DefaultActors.Admin/*, MyUtils.DefaultApplications.WebApp*/
                , new Tuple<Utils.Estimate, Utils.Estimate>(Utils.Estimate.XS, Utils.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Expect(Utils.f1Usecase1);


            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Utils.AddUsecase(this, Utils.feature01, Utils.f1Usecase2, Utils.DefaultActors.Admin
                , new Tuple<Utils.Estimate, Utils.Estimate>(Utils.Estimate.XS, Utils.Estimate.M), unselectIfSelected: false);
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Expect(Utils.f1Usecase2);


            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Utils.AddUsecase(this, Utils.feature02, Utils.f2Usecase1, Utils.DefaultActors.Admin
                , new Tuple<Utils.Estimate, Utils.Estimate>(Utils.Estimate.XS, Utils.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(Utils.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.Const.scrollable_scopeFeatures_treeView));
            Expect(Utils.f2Usecase1);



            Run<OpenProjectPlan>();
            Thread.Sleep(2000);
            Utils.AddStakeholder(this, Utils.stakeholder1);
            Thread.Sleep(500);
            Utils.AddStakeholder(this, Utils.stakeholder2);
            Thread.Sleep(500);
            Utils.AddStakeholder(this, Utils.stakeholder3);
            Thread.Sleep(500);


            Utils.OpenPlanDomainExpertise(this);
        }
    }
}
