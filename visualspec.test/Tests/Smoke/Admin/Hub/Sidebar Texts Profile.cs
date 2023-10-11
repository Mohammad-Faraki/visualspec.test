namespace Tests.Smoke.Admin.Hub
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;

    /// <summary>
    /// Checking texts and orders of sidebar menu items
    /// </summary>
    [TestClass]
    public class SidebarTextsProfile : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // "Log off" should be changed to "Log out"

            Run<CreateOpenProject>();

            ClickXPath(U.scopeSidebarIcon_XPath);



            
            ExpectXPath($"//a[{U.XPathAttributeContains("id", "dropdownUser")}]"); // Hi <username>

            // Hi <username>
            ClickXPath($"//a[{U.XPathAttributeContains("id", "dropdownUser")}]/img");
            WaitToSeeXPath($"//li[1]//a[{U.XPathTextContains(Casing.Exact, "Account")}]");
            ExpectXPath($"//li[2]//a[{U.XPathTextContains(Casing.Exact, "Checkpoints")}]");
            ExpectXPath($"//li[3]//a[{U.XPathTextContains(Casing.Exact, "Log out")}]");

        }



    }
}
