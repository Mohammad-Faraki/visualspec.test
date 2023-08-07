namespace Admin.Hub
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

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

            ClickXPath(U.scopeSidebarIconXPath);



            
            ExpectXPath($"//a[{U.XPathAttributeContains("id", "dropdownUser")}]"); // Hi <username>

            // Hi <username>
            ClickXPath($"//a[{U.XPathAttributeContains("id", "dropdownUser")}]/img");
            WaitToSeeXPath($"//li[1]//a[{U.XPathTextContains("Account")}]");
            ExpectXPath($"//li[2]//a[{U.XPathTextContains("Checkpoints")}]");
            ExpectXPath($"//li[3]//a[{U.XPathTextContains("Log out")}]");

        }



    }
}
