namespace Tests.Minor.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Scope.Features;

    [TestClass]
    public class DeleteUsecasesByPopup : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUsecase>();



            //*********** Edit usecase
            //Click(MyUtils.f1Usecase1);
            ClickXPath(Utils.btnThreeDotsUsecaseXPath(featureIndex: 1, usecaseIdx: 1));
            ClickXPath($"{Utils.usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            WaitToSee(What.Contains, "Edit usecase");

            AtXPath(C.formUsecase).Click("Delete");
            Expect("Deleting this use case will delete all its associated data in other microservices. Are you sure you want to delete this use case?");
            Click("OK");
            Thread.Sleep(4000);
            Utils.ScrollToBottom(this, C.scrollable_scopeFeatures_treeView);
            ExpectNo(Utils.f1Usecase1);
        }
        
    }
}
