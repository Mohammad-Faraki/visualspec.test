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


            AtXPath(C.formApplicationXPath).Click("Devices management");

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            //AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            string btnChangeDeviceDropdown = "---Select---";
            Utils.OpenDropdown(this, btnChangeDeviceDropdown, C.formChangeDeviceXPath);
            NearXPath(C.formChangeDeviceXPath).ClickLink(C.editedDevice);
            AtXPath(C.formChangeDeviceXPath).ClickButton("Save");


            // Checked if changes are applied
            C.OpenApplicationDetails(this, C.addedApp);
            AtXPath(C.formApplicationXPath).Click("Devices management");
            AtXPath(C.formDeviceManagmentXPath).ExpectNo(What.Contains, C.addedDevice);
            AtXPath(C.formDeviceManagmentXPath).Expect(C.editedDevice);

            AtXPath(C.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {C.addedApp}");
            Utils.OpenDropdown(this, btnChangeDeviceDropdown, C.formChangeDeviceXPath);
            //NearXPath(C.formChangeDeviceXPath).ExpectNoLink(C.editedDevice);
            //NearXPath(C.formChangeDeviceXPath).ExpectLink(C.addedDevice);
            ////AtXPath(C.formChangeDeviceXPath).BelowButton("---Select---").ExpectNoLink(C.editedDevice);
            ////AtXPath(C.formChangeDeviceXPath).BelowButton("---Select---").ExpectLink(C.addedDevice);
            ExpectNoXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "To device")}]/{Utils.following_sibling_XPath}::div[{Utils.XPathHasElement($"*[{Utils.XPathText(Casing.Exact, C.editedDevice)}]")}]");
            ExpectXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "To device")}]/{Utils.following_sibling_XPath}::div[{Utils.XPathHasElement($"*[{Utils.XPathText(Casing.Exact, C.addedDevice)}]")}]");
        }



    }
}
