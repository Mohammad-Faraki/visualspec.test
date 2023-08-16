namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class EditDevice : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddApplication>();


            C.OpenApplicationDetails(this, C.addedApp);


            AtXPath(C.formApplicationXPath).Click("Devices management");

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            NearXPath(C.formChangeDeviceXPath).ClickLink(C.editedDevice);
            AtXPath(C.formChangeDeviceXPath).ClickButton("Save");


            // Checked if changes are applied
            C.OpenApplicationDetails(this, C.addedApp);
            AtXPath(C.formApplicationXPath).Click("Devices management");
            AtXPath(C.formApplicationXPath).ExpectNo(What.Contains, C.addedDevice);
            AtXPath(C.formApplicationXPath).Expect(C.editedDevice);

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            NearXPath(C.formChangeDeviceXPath).ExpectNoLink(C.editedDevice);
            NearXPath(C.formChangeDeviceXPath).ExpectLink(C.addedDevice);
        }



    }
}
