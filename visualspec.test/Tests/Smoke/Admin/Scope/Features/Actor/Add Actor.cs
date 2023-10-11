namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;
    using OpenQA.Selenium;

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
            //AtXPath("//form[@data-module='ActorForm']").ClickButton("Nothing selected");
            ////var btnDropdownXPath = $"{C.formActor}//*[{U.XPathText(Casing.Exact, "Nothing selected")}]";
            ////var btnDropdownXPath = $"{C.formActor}//{U.btnOpenDropdownXPath("Nothing selected")}";
            //////this.WebDriver.FindElement(By.XPath(btnDropdownXPath)).Click();
            ////ClickXPath(btnDropdownXPath);
            Utils.OpenDropdown(this, "Nothing selected", C.formActor);



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
