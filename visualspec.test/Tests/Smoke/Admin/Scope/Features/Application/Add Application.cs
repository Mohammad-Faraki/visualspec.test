namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class AddApplication : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<CreateOpenProject>();



            //*********** Add application
            //ClickXPath($"//div[@id='UseCaseTreeMenu']/nav[1]//a[@href='/features/enter-application?{MyUtils.ProjectIdKey}']");
            ClickXPath($"//a[@name='CreateApplication']");
            WaitToSee("Add application");
            Set("Name").To(Const.addedApp);
            // Device
            //ClickCSS("button[role='combobox']");
            //AtXPath("//form[@data-module='ApplicationForm']").ClickButton("Nothing selected");
            Utils.OpenDropdown(this, "Nothing selected", Const.formApplicationXPath);
            // Normal screen
            //AtXPath("//form[@data-module='ApplicationForm']").ClickLink("Normal screen");
            NearXPath("//form[@data-module='ApplicationForm']").ClickLink("Normal screen");
            ExpectNoButton(That.Contains, "Delete");
            Click("Save");
            Expect(Const.addedApp);
        }



    }
}
