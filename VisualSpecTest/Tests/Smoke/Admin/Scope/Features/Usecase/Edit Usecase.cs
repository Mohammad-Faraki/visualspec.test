namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Shared.Admin.Scope.Features;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class EditUsecase : UITest
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
            Set("Name").To(U.f1Usecase2);



            // Actors
            //ClickXPath("//form[@data-module='UseCaseForm']//div[5]//button");
            //AtXPath("//form[@data-module='UseCaseForm']").ClickButton("Admin");
            ////NearXPath("//form[@data-module='UseCaseForm']").ClickButton("Admin");
            U.OpenDropdown(this, "Admin", C.formUsecase);

            // select "Customer" actor
            //ClickXPath($"//form[@data-module='UseCaseForm']//div[5]//span[{MyUtils.XPathText("Customer")}]");
            AtXPath($"{C.formUsecase}//div[@role='listbox']").ClickLink("Customer");
            // To close actors popup
            ClickXPath($"{C.formUsecase}//textarea[@name='Description']");


            #region Commented application select
            //// Applications
            ////ClickXPath("//form[@data-module='UseCaseForm']//div[6]//button");
            //NearXPath("//form[@data-module='UseCaseForm']").ClickButton("A Web App");
            //// select "A Web App" application
            ////ClickXPath($"//form[@data-module='UseCaseForm']//div[6]//span[{MyUtils.XPathText("A Web App")}]");
            ////ClickXPath($"//form[@data-module='UseCaseForm']//div[6]//span[{MyUtils.XPathText("A Mobile App")}]");
            //NearXPath("//form[@data-module='UseCaseForm']//div[6]//button[@data-id='ApplicationItems']").ClickLink("A Web App");
            //NearXPath("//form[@data-module='UseCaseForm']//div[6]//button[@data-id='ApplicationItems']").ClickLink("A Mobile App"); 
            #endregion

            Click("Save");
            Expect(U.f1Usecase2);

            ClickXPath(U.btnThreeDotsUsecaseXPath(featureIndex: 1, usecaseIdx: 1));
            ClickXPath($"{U.usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            WaitToSee(What.Contains, "Edit usecase");
            Expect(What.Contains, "2 items selected");
            //Expect(What.Contains, "A Mobile App");
            Click("Cancel");

        }
        
    }
}
