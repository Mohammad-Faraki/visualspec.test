namespace Tests.Smoke.Admin.Scope.Estimate
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Estimate;

    [TestClass]
    public class ManageIntegrationFromScopeEstimate : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            


            Run<OpenFeatures>();
            Thread.Sleep(2000);

            //*********** Add integration
            ClickXPath($"//a[@name='CreateIntegration']");
            WaitToSee("Add integration");
            Set("Name").To(Const.addedIntegration);
            Click("Save");
            Expect(Const.addedIntegration);




            Utils.OpenEstimate(this);
            Thread.Sleep(2000);

            //*********** Edit integration
            Utils.ScrollToElementXPath(this, scorllableElement: "scope-content"
                , XPath: "//form[@data-module='IntegrationsWithFeatureList']");
            ClickXPath(Const.btnEditIntegraionXPath);
            WaitToSee(What.Contains , "Edit integration");
            //Near($"Edit integration: {addedIntegration}").Set(That.Contains,"Name").To(editedIntegration);
            AtXPath(Const.formIntegrationXPath).Set(That.Contains, "Name").To(Const.editedIntegration);
            ClickXPath($"{Const.formIntegrationXPath}//label[@data-index='1']");
            ClickXPath($"{Const.formIntegrationXPath}//label[@data-index='3']");
            Near(What.Contains, "Edit integration").Click("Save");



            //ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[1]/td[text()='{editedIntegration}']");
            Expect(What.Contains, Const.editedIntegration);
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[3][@class='selected']");
            
            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");
            Thread.Sleep(2000);

            
            
            Utils.ScrollToElementXPath(this, scorllableElement: "scope-content"
                , XPath: "//form[@data-module='IntegrationsWithFeatureList']");

            Expect(What.Contains, Const.editedIntegration);
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[3][@class='selected']");





            //*********** Delete integration
            ClickXPath(Const.btnEditIntegraionXPath);
            WaitToSee(What.Contains, "Edit integration");
            Near(What.Contains, "Edit integration").Click(What.Contains,"Delete");
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(What.Contains, Const.editedIntegration);

            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");
            ExpectNo(What.Contains, Const.editedIntegration);


            Utils.OpenFeatures(this);
            ExpectNo(What.Contains, Const.editedIntegration);
        }



    }
}
