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


            Const.OpenApplicationDetails(this, Const.addedApp);


            AtXPath(Const.formApplicationXPath).Click("Devices management");

            AtXPath(Const.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {Const.addedApp}");
            //AtXPath(C.formChangeDeviceXPath).ClickButton("---Select---");
            string btnChangeDeviceDropdown = "---Select---";
            Utils.OpenDropdown(this, btnChangeDeviceDropdown, Const.formChangeDeviceXPath);
            NearXPath(Const.formChangeDeviceXPath).ClickLink(Const.editedDevice);
            AtXPath(Const.formChangeDeviceXPath).ClickButton("Save");


            // Checked if changes are applied
            Const.OpenApplicationDetails(this, Const.addedApp);
            AtXPath(Const.formApplicationXPath).Click("Devices management");
            AtXPath(Const.formDeviceManagmentXPath).ExpectNo(What.Contains, Const.addedDevice);
            AtXPath(Const.formDeviceManagmentXPath).Expect(Const.editedDevice);

            AtXPath(Const.formDeviceManagmentXPath).ClickXPath("//a[@name='ChangeTo'][1]");
            WaitToSee($"Change device of {Const.addedApp}");
            Utils.OpenDropdown(this, btnChangeDeviceDropdown, Const.formChangeDeviceXPath);
            //NearXPath(C.formChangeDeviceXPath).ExpectNoLink(C.editedDevice);
            //NearXPath(C.formChangeDeviceXPath).ExpectLink(C.addedDevice);
            ////AtXPath(C.formChangeDeviceXPath).BelowButton("---Select---").ExpectNoLink(C.editedDevice);
            ////AtXPath(C.formChangeDeviceXPath).BelowButton("---Select---").ExpectLink(C.addedDevice);
            ExpectNoXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "To device")}]/{Utils.following_sibling_XPath}::div[{Utils.XPathHasElement($"*[{Utils.XPathText(Casing.Exact, Const.editedDevice)}]")}]");
            ExpectXPath($"//label[{Utils.XPathTextContains(Casing.Exact, "To device")}]/{Utils.following_sibling_XPath}::div[{Utils.XPathHasElement($"*[{Utils.XPathText(Casing.Exact, Const.addedDevice)}]")}]");
        }



    }
}
