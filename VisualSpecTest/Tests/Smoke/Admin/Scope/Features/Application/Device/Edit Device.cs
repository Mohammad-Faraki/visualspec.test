namespace Tests.Smoke.Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Scope.Features;

    [TestClass]
    public class EditDevice : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddApplication>();


            C.OpenApplicationDetails(this, C.addedApp);


            AtXPath(C.formApplicationDetailsXPath).Click("Devices management");

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            NearXPath(C.formChangeDeviceXPath).ClickLink(C.editedDevice);
            AtXPath(C.formChangeDeviceXPath).ClickButton("Save");


            // Checked if changes are applied
            C.OpenApplicationDetails(this, C.addedApp);
            AtXPath(C.formApplicationDetailsXPath).Click("Devices management");
            AtXPath(C.formApplicationDetailsXPath).ExpectNo(What.Contains, C.addedDevice);
            AtXPath(C.formApplicationDetailsXPath).Expect(C.editedDevice);

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            NearXPath(C.formChangeDeviceXPath).ExpectNoLink(C.editedDevice);
            NearXPath(C.formChangeDeviceXPath).ExpectLink(C.addedDevice);
        }



    }
}
