namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class AddActor : UITest
    {

        [PangolinTestMethod]
        public override void RunTest()
        {
            
            Run<CreateOpenProject>();




            //*********** Add actor
            ClickXPath($"//a[@name='CreateActor']");
            WaitToSee("Add actor");
            Set("Name").To(C.addedActor);
            // Applications
            //ClickCSS(".bootstrap-select.dropdown.form-check.show-tick > button[role='combobox']");
            AtXPath("//form[@data-module='ActorForm']").ClickButton("Nothing selected");
            // A Web App
            //ClickCSS("li:nth-of-type(1) > a[role='option'] > .text");
            //AtXPath("//form[@data-module='ActorForm']").ClickLink("A Web App");
            NearXPath("//form[@data-module='ActorForm']").ClickLink("A Web App");
            ExpectNoButton(That.Contains, "Delete");
            Click("Save");
            Expect(C.addedActor);
        }



    }
}
