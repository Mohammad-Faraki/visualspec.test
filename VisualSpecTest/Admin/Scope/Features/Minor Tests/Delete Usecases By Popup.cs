namespace Admin.Scope.Features.Minor
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class DeleteUsecasesByPopup : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddUsecase>();



            //*********** Edit usecase
            //Click(MyUtils.f1Usecase1);
            ClickXPath(U.btnThreeDotsUsecaseXPath(featureIndex: 1, usecaseIdx: 1));
            ClickXPath($"{U.usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            WaitToSee(What.Contains, "Edit usecase");

            AtXPath(C.formUsecaseDetails).Click("Delete");
            Expect("Deleting this use case will delete all its associated data in other microservices. Are you sure you want to delete this use case?");
            Click("OK");
            Thread.Sleep(4000);
            U.ScrollToBottom(this, C.scrollable_scopeFeatures_treeView);
            ExpectNo(U.f1Usecase1);
        }
        
    }
}
