namespace Tests.Smoke.Admin.Hub
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Tests.Smoke.Admin.Website;

    /// <summary>
    /// Checking texts and orders of sidebar menu items
    /// </summary>
    [TestClass]
    public class SidebarTextsMSs : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // "Log off" should be changed to "Log out"

            Run<CreateOpenProject>();

            ClickXPath(U.scopeSidebarIcon_XPath);





            ExpectXPath($"//li[2]//span[{U.XPathTextContains("Scope")}]");
            ExpectXPath($"//li[3]//span[{U.XPathTextContains("Plan")}]");
            ExpectXPath($"//li[4]//span[{U.XPathTextContains("Spec")}]");
            ExpectXPath($"//li[5]//span[{U.XPathTextContains("Test")}]");
            ExpectXPath($"//li[6]//span[{U.XPathTextContains("Deliver")}]");


            // Scope
            ClickXPath($"//li[2]//span[{U.XPathTextContains("Scope")}]");
            ExpectXPath($"//li[2]//ul//li[1]//a[{U.XPathTextContains("Features")}]");
            ExpectXPath($"//li[2]//ul//li[2]//a[{U.XPathTextContains("Estimate")}]");

            // Plan
            ClickXPath($"//li[3]//span[{U.XPathTextContains("Plan")}]");
            ExpectXPath($"//li[3]//ul//li[1]//a[{U.XPathTextContains("Project Plan")}]");
            ExpectXPath($"//li[3]//ul//li[2]//a[{U.XPathTextContains("Northstar")}]");

            // Spec
            ClickXPath($"//li[4]//span[{U.XPathTextContains("Spec")}]");
            ExpectXPath($"//li[4]//ul//li[1]//a[{U.XPathTextContains("Object Map")}]");
            ExpectXPath($"//li[4]//ul//li[2]//a[{U.XPathTextContains("Personas")}]");
            ExpectXPath($"//li[4]//ul//li[3]//a[{U.XPathTextContains("Workflow Models")}]");
            ExpectXPath($"//li[4]//ul//li[4]//a[{U.XPathTextContains("Wireframes")}]");
            ExpectXPath($"//li[4]//ul//li[5]//a[{U.XPathTextContains("User Journeys")}]");


            // Test
            ClickXPath($"//li[5]//span[{U.XPathTextContains("Test")}]");
            ExpectXPath($"//li[5]//ul//li[1]//a[{U.XPathTextContains("Cognitive Walkthroughs")}]");

            // Deliver
            ClickXPath($"//li[6]//span[{U.XPathTextContains("Deliver")}]");
            ExpectXPath($"//li[6]//ul//li[1]//a[{U.XPathTextContains("Estimate")}]");
        }



    }
}
