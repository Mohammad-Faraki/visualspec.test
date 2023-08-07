namespace Admin.Scope.Estimate
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Admin.Website;

    [TestClass]
    public class ManageIntegrationFromScopeEstimate : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            string addedIntegration = "integration01";
            string editedIntegration = "integration01 edited";

            string btnEditIntegraionXPath = "//form[@data-module='IntegrationsWithFeatureList']//tr[last()]//a[@name='Edit']";
            string integrationFormXPath = "//form[@data-module='IntegrationForm']";


            Run<OpenFeatures>();
            Thread.Sleep(2000);

            //*********** Add integration
            ClickXPath($"//a[@name='CreateIntegration']");
            WaitToSee("Add integration");
            Set("Name").To(addedIntegration);
            Click("Save");
            Expect(addedIntegration);




            U.OpenEstimate(this);
            Thread.Sleep(2000);

            //*********** Edit integration
            U.ScrollToElementXPath(this, scorllableElement: "scope-content"
                , XPath: "//form[@data-module='IntegrationsWithFeatureList']");
            ClickXPath(btnEditIntegraionXPath);
            WaitToSee(What.Contains , "Edit integration");
            //Near($"Edit integration: {addedIntegration}").Set(That.Contains,"Name").To(editedIntegration);
            AtXPath(integrationFormXPath).Set(That.Contains, "Name").To(editedIntegration);
            ClickXPath($"{integrationFormXPath}//label[@data-index='1']");
            ClickXPath($"{integrationFormXPath}//label[@data-index='3']");
            Near(What.Contains, "Edit integration").Click("Save");



            //ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[1]/td[text()='{editedIntegration}']");
            Expect(What.Contains, editedIntegration);
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[3][@class='selected']");
            
            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");
            Thread.Sleep(2000);

            
            
            U.ScrollToElementXPath(this, scorllableElement: "scope-content"
                , XPath: "//form[@data-module='IntegrationsWithFeatureList']");

            Expect(What.Contains, editedIntegration);
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[1][@class='selected']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[2][@class='highlighted']");
            ExpectXPath($"//form[@data-module='IntegrationsWithFeatureList']//tr[last()]/td[4]//div[3][@class='selected']");





            //*********** Delete integration
            ClickXPath(btnEditIntegraionXPath);
            WaitToSee(What.Contains, "Edit integration");
            Near(What.Contains, "Edit integration").Click(What.Contains,"Delete");
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(What.Contains,editedIntegration);

            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");
            ExpectNo(What.Contains, editedIntegration);


            U.OpenFeatures(this);
            ExpectNo(What.Contains, editedIntegration);
        }



    }
}
