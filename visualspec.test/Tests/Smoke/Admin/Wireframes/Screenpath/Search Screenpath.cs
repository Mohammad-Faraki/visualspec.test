namespace Tests.Smoke.Admin.Wireframes.Screenpath
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;

    [TestClass]
    public class SearchScreenpath : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenWireframes>();
            Thread.Sleep(2000);

            ClickLink("ScreenPath");
            WaitToSee(What.Contains, "Screen path ID");

            ClickButton("Rescan");
            // Browser tab title
            WaitToSee(What.Contains, "Results per page:");
            //Set(That.Contains, "Screen path ID").To("26");
            SetXPath("//input[@id='Main_ctl00_SearchScreenPathID']").To("26");
            // To hide dropdown
            ClickXPath("//input[@id='Main_ctl00_SearchScreenPathID']");
            ClickButton("Search");
            Thread.Sleep(2000);
            int rowIdx = 1;
            // table header is first row
            ExpectXPath($"//tr[{rowIdx+1}]//td[4][{Utils.XPathTextContains(Casing.Exact, "26")}]");
        }



    }
}
