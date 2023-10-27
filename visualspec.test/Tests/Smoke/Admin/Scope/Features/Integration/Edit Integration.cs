namespace Tests.Smoke.Admin.Scope.Features
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class EditIntegration : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddIntegration>();




            //*********** Edit integration
            // Three dots
            ClickXPath(Utils.btnThreeDotsIntegrationXPath(Const.addedIntegration));
            // Edit
            var btnEditXPath = $"//*[@data-module='TreeIntegrations']//li[1]//a[{Utils.XPathText(Casing.Exact, "Edit")}]";
            WaitToSeeXPath(btnEditXPath);
            ClickXPath(btnEditXPath);
            Set("Name").To(Const.editedIntegration);
            Click("Save");
            Expect(Const.editedIntegration);
        }



    }
}
