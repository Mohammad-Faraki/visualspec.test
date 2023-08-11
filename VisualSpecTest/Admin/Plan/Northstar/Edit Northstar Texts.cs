namespace Admin.Northstar
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class EditNorthstarTexts : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<AddNorthstar>();
            Run<OpenNorthstar>();
            Thread.Sleep(2000);


            //*********** Set some texts
            string[] cards = { "SupportingInfoForm",
                "BreadthForm", "MidLongTermImpactsForm",
                "DepthForm", "FrequencyForm",
                "OthersForm" };

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == "OthersForm" || cards[i] == "MidLongTermImpactsForm")
                {
                    U.ScrollToElementXPath(this, "northstar-content", "//form[@data-module='DepthForm']", U.HtmlElementProp.Top);
                }
                

                SetXPath($"//form[@data-module='{cards[i]}']//div[2]//textarea").To($"test text {i}");

                //ClickXPath($"//form[@data-module='{cards[i]}']//a");
                //ClickHeader(That.Contains, "North Star Metric");
                ////ClickXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
                Thread.Sleep(1000);
            }
            SetXPath($"//form[@data-module='MetricForm']//textarea").To($"test text MetricForm");
            //ClickXPath($"//form[@data-module='MetricForm']//a");
            ClickXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
            Thread.Sleep(1000);

            RefreshPage();
            WaitToSeeXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
            Thread.Sleep(1000);
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == "OthersForm" || cards[i] == "MidLongTermImpactsForm")
                {
                    U.ScrollToElementXPath(this, "northstar-content", "//form[@data-module='DepthForm']", U.HtmlElementProp.Top);
                }

                ExpectXPath($"//form[@data-module='{cards[i]}']//div[2]//textarea[text()='test text {i}']");
            }
            ExpectXPath($"//form[@data-module='MetricForm']//textarea[text()='test text MetricForm']");



            //*********** Edit some texts
            U.ScrollToTop(this, "northstar-content");

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == "OthersForm" || cards[i] == "MidLongTermImpactsForm")
                {
                    U.ScrollToElementXPath(this, "northstar-content", "//form[@data-module='DepthForm']", U.HtmlElementProp.Top);
                }
                
                SetXPath($"//form[@data-module='{cards[i]}']//div[2]//textarea").To($"test text {i} edited");
                //ClickXPath($"//form[@data-module='{cards[i]}']//a");
                ////ClickXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
                Thread.Sleep(1000);
            }
            SetXPath($"//form[@data-module='MetricForm']//textarea").To($"test text MetricForm edited");
            //ClickXPath($"//form[@data-module='MetricForm']//a");
            ClickXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
            Thread.Sleep(1000);

            RefreshPage();
            WaitToSeeXPath($"//h3[{U.XPathTextContains("North Star Metric")}]");
            Thread.Sleep(1000);
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == "OthersForm" || cards[i] == "MidLongTermImpactsForm")
                {
                    U.ScrollToElementXPath(this, "northstar-content", "//form[@data-module='DepthForm']", U.HtmlElementProp.Top);
                }

                ExpectXPath($"//form[@data-module='{cards[i]}']//div[2]//textarea[text()='test text {i} edited']");
            }
            ExpectXPath($"//form[@data-module='MetricForm']//textarea[text()='test text MetricForm edited']");


        }



    }
}
