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

            ClickXPath(Utils.scopeSidebarIcon_XPath);





            ExpectXPath($"//li[2]//span[{Utils.XPathTextContains(Casing.Exact, "Scope")}]");
            ExpectXPath($"//li[3]//span[{Utils.XPathTextContains(Casing.Exact, "Plan")}]");
            ExpectXPath($"//li[4]//span[{Utils.XPathTextContains(Casing.Exact, "Spec")}]");
            ExpectXPath($"//li[5]//span[{Utils.XPathTextContains(Casing.Exact, "Test")}]");
            ExpectXPath($"//li[6]//span[{Utils.XPathTextContains(Casing.Exact, "Deliver")}]");


            // Scope
            ClickXPath($"//li[2]//span[{Utils.XPathTextContains(Casing.Exact, "Scope")}]");
            ExpectXPath($"//li[2]//ul//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Features")}]");
            ExpectXPath($"//li[2]//ul//li[2]//a[{Utils.XPathTextContains(Casing.Exact, "Estimate")}]");

            // Plan
            ClickXPath($"//li[3]//span[{Utils.XPathTextContains(Casing.Exact, "Plan")}]");
            ExpectXPath($"//li[3]//ul//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Project Plan")}]");
            ExpectXPath($"//li[3]//ul//li[2]//a[{Utils.XPathTextContains(Casing.Exact, "Northstar")}]");

            // Spec
            ClickXPath($"//li[4]//span[{Utils.XPathTextContains(Casing.Exact, "Spec")}]");
            ExpectXPath($"//li[4]//ul//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Object Map")}]");
            ExpectXPath($"//li[4]//ul//li[2]//a[{Utils.XPathTextContains(Casing.Exact, "Personas")}]");
            ExpectXPath($"//li[4]//ul//li[3]//a[{Utils.XPathTextContains(Casing.Exact, "Workflow Models")}]");
            ExpectXPath($"//li[4]//ul//li[4]//a[{Utils.XPathTextContains(Casing.Exact, "Wireframes")}]");
            ExpectXPath($"//li[4]//ul//li[6]//a[{Utils.XPathTextContains(Casing.Exact, "User Journeys")}]");


            // Test
            ClickXPath($"//li[5]//span[{Utils.XPathTextContains(Casing.Exact, "Test")}]");
            ExpectXPath($"//li[5]//ul//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Cognitive Walkthroughs")}]");

            // Deliver
            ClickXPath($"//li[6]//span[{Utils.XPathTextContains(Casing.Exact, "Deliver")}]");
            ExpectXPath($"//li[6]//ul//li[1]//a[{Utils.XPathTextContains(Casing.Exact, "Estimate")}]");
        }



    }
}
