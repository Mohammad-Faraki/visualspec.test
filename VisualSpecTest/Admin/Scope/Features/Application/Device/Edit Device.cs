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


            AtXPath(C.applicationFormXPath).Click("Devices management");

            AtXPath(C.deviceManagmentFormXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.changeDeviceFormXPath).ClickButton("---Select---");
            NearXPath(C.changeDeviceFormXPath).ClickLink(C.editedDevice);
            AtXPath(C.changeDeviceFormXPath).ClickButton("Save");


            // Checked if changes are applied
            C.OpenApplicationDetails(this, C.addedApp);
            AtXPath(C.applicationFormXPath).Click("Devices management");
            AtXPath(C.applicationFormXPath).ExpectNo(What.Contains, C.addedDevice);
            AtXPath(C.applicationFormXPath).Expect(C.editedDevice);

            AtXPath(C.deviceManagmentFormXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            AtXPath(C.changeDeviceFormXPath).ClickButton("---Select---");
            NearXPath(C.changeDeviceFormXPath).ExpectNoLink(C.editedDevice);
            NearXPath(C.changeDeviceFormXPath).ExpectLink(C.addedDevice);
        }



    }
}
