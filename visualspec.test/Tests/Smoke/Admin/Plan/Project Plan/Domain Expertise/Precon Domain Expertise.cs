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


            U.AddFeature(this, U.feature01);
            Thread.Sleep(500);
            U.AddFeature(this, U.feature02);
            Thread.Sleep(500);



            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            U.AddUsecase(this, U.feature01, U.f1Usecase1, U.DefaultActors.Admin/*, MyUtils.DefaultApplications.WebApp*/
                , new Tuple<U.Estimate, U.Estimate>(U.Estimate.XS, U.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Expect(U.f1Usecase1);


            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            U.AddUsecase(this, U.feature01, U.f1Usecase2, U.DefaultActors.Admin
                , new Tuple<U.Estimate, U.Estimate>(U.Estimate.XS, U.Estimate.M), unselectIfSelected: false);
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Expect(U.f1Usecase2);


            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            U.AddUsecase(this, U.feature02, U.f2Usecase1, U.DefaultActors.Admin
                , new Tuple<U.Estimate, U.Estimate>(U.Estimate.XS, U.Estimate.M));
            Thread.Sleep(500);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            Expect(U.f2Usecase1);



            Run<OpenProjectPlan>();
            Thread.Sleep(2000);
            U.AddStakeholder(this, U.stakeholder1);
            Thread.Sleep(500);
            U.AddStakeholder(this, U.stakeholder2);
            Thread.Sleep(500);
            U.AddStakeholder(this, U.stakeholder3);
            Thread.Sleep(500);


            U.OpenPlanDomainExpertise(this);
        }
    }
}
