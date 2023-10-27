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
            ClickXPath(Utils.btnThreeDotsUsecaseXPath(featureIndex: 1, usecaseIdx: 1));
            ClickXPath($"{Utils.usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            WaitToSee(What.Contains, "Edit usecase");
            Set("Name").To(Utils.f1Usecase2);



            // Actors
            //ClickXPath("//form[@data-module='UseCaseForm']//div[5]//button");
            //AtXPath("//form[@data-module='UseCaseForm']").ClickButton("Admin");
            ////NearXPath("//form[@data-module='UseCaseForm']").ClickButton("Admin");
            Utils.OpenDropdown(this, "Admin", Const.formUsecase);

            // select "Customer" actor
            //ClickXPath($"//form[@data-module='UseCaseForm']//div[5]//span[{MyUtils.XPathText(Casing.Exact, "Customer")}]");
            AtXPath($"{Const.formUsecase}//div[@role='listbox']").ClickLink("Customer");
            // To close actors popup
            ClickXPath($"{Const.formUsecase}//textarea[@name='Description']");


            #region Commented application select
            //// Applications
            ////ClickXPath("//form[@data-module='UseCaseForm']//div[6]//button");
            //NearXPath("//form[@data-module='UseCaseForm']").ClickButton("A Web App");
            //// select "A Web App" application
            ////ClickXPath($"//form[@data-module='UseCaseForm']//div[6]//span[{MyUtils.XPathText(Casing.Exact, "A Web App")}]");
            ////ClickXPath($"//form[@data-module='UseCaseForm']//div[6]//span[{MyUtils.XPathText(Casing.Exact, "A Mobile App")}]");
            //NearXPath("//form[@data-module='UseCaseForm']//div[6]//button[@data-id='ApplicationItems']").ClickLink("A Web App");
            //NearXPath("//form[@data-module='UseCaseForm']//div[6]//button[@data-id='ApplicationItems']").ClickLink("A Mobile App"); 
            #endregion

            Click("Save");
            Expect(Utils.f1Usecase2);

            ClickXPath(Utils.btnThreeDotsUsecaseXPath(featureIndex: 1, usecaseIdx: 1));
            ClickXPath($"{Utils.usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            WaitToSee(What.Contains, "Edit usecase");
            Expect(What.Contains, "2 items selected");
            //Expect(What.Contains, "A Mobile App");
            Click("Cancel");

        }
        
    }
}
