﻿namespace Tests.Smoke.Admin.Website
{
    using ICSharpCode.SharpZipLib.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class Paging : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            Click("My Projects");
            WaitForNewPage();

            Expect("New Project");



            // No "0 users assigned" should be present at the page
            //ExpectNoXPath($"//*[{U.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}][{U.XPathTextContains(Casing.Exact, "0")}]");
            for (int i = 1; i < 11; i++)
                AtXPath($"//tr[{i}]//*[{Utils.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}]").ExpectNo(What.Contains, "0");

            Utils.ScrollToBottom_Website(this);
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//span[{Utils.XPathText(Casing.Exact, "1")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "2")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[3]//a[{Utils.XPathText(Casing.Exact, "3")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[4]//a[{Utils.XPathText(Casing.Exact, "4")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[5]//a[{Utils.XPathText(Casing.Exact, "5")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[6]//a[{Utils.XPathText(Casing.Exact, "6")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[7]//a[{Utils.XPathText(Casing.Exact, "7")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[8]//a[{Utils.XPathText(Casing.Exact, "8")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[9]//a[{Utils.XPathText(Casing.Exact, "9")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[10]//a[{Utils.XPathText(Casing.Exact, "10")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[12]//a[{Utils.XPathText(Casing.Exact, ">>")}]");
            ExpectNoXPath($"//a[{Utils.XPathText(Casing.Exact, "<<")}]");





            ClickXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            WaitToSee("New Project");

            for (int i = 1; i < 11; i++)
                AtXPath($"//tr[{i}]//*[{Utils.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}]").ExpectNo(What.Contains, "0");

            Utils.ScrollToBottom_Website(this);
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//a[{Utils.XPathText(Casing.Exact, "<<")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[3]//span[{Utils.XPathText(Casing.Exact, "11")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[4]//a[{Utils.XPathText(Casing.Exact, "12")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[5]//a[{Utils.XPathText(Casing.Exact, "13")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[6]//a[{Utils.XPathText(Casing.Exact, "14")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[7]//a[{Utils.XPathText(Casing.Exact, "15")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[8]//a[{Utils.XPathText(Casing.Exact, "16")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[9]//a[{Utils.XPathText(Casing.Exact, "17")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[10]//a[{Utils.XPathText(Casing.Exact, "18")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]//a[{Utils.XPathText(Casing.Exact, "19")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[12]//a[{Utils.XPathText(Casing.Exact, "20")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[13]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[14]//a[{Utils.XPathText(Casing.Exact, ">>")}]");




            ClickXPath($"//tr[{Utils.lastIdx_XPath}]//td[14]//a[{Utils.XPathText(Casing.Exact, ">>")}]");
            WaitToSee("New Project");

            // Just check first row(because maybe there are no other rows)
            for (int i = 1; i < 2; i++)
                AtXPath($"//tr[{i}]//*[{Utils.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}]").ExpectNo(What.Contains, "0");

            Utils.ScrollToBottom_Website(this);
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//a[{Utils.XPathText(Casing.Exact, "<<")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[3]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[4]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[5]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[6]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[7]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[8]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[9]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[10]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[12]//span");
            ExpectNoXPath($"//a[{Utils.XPathText(Casing.Exact, ">>")}]");





            ClickXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            WaitToSee("New Project");

            for (int i = 1; i < 11; i++)
                AtXPath($"//tr[{i}]//*[{Utils.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}]").ExpectNo(What.Contains, "0");

            Utils.ScrollToBottom_Website(this);
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//a[{Utils.XPathText(Casing.Exact, "<<")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[3]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[4]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[5]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[6]//a");
            //if (U.environment == U.Environment.Prelive)
            //    ExpectXPath($"//tr[{U.lastElementXPath}]//td[7]//span");
            //else
            //    ExpectXPath($"//tr[{U.lastElementXPath}]//td[7]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[8]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[9]//a");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[10]//a");
            //if (U.environment == U.Environment.Prelive)
            //    ExpectXPath($"//tr[{U.lastElementXPath}]//td[11]//a");
            //else
            //    ExpectXPath($"//tr[{U.lastElementXPath}]//td[11]//span");
            //ExpectXPath($"//tr[{U.lastElementXPath}]//td[12]//a");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[3]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[4]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[5]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[6]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[7]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[8]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[9]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[10]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[12]");

            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[13]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[14]//a[{Utils.XPathText(Casing.Exact, ">>")}]");





            ClickXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//a[{Utils.XPathText(Casing.Exact, "<<")}]");
            WaitToSee("New Project");

            for (int i = 1; i < 11; i++)
                AtXPath($"//tr[{i}]//*[{Utils.XPathHasDirectElement("img[@src='/Images/svg/persongroup.svg']")}]").ExpectNo(What.Contains, "0");

            Utils.ScrollToBottom_Website(this);
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[1]//span[{Utils.XPathText(Casing.Exact, "1")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[2]//a[{Utils.XPathText(Casing.Exact, "2")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[3]//a[{Utils.XPathText(Casing.Exact, "3")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[4]//a[{Utils.XPathText(Casing.Exact, "4")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[5]//a[{Utils.XPathText(Casing.Exact, "5")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[6]//a[{Utils.XPathText(Casing.Exact, "6")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[7]//a[{Utils.XPathText(Casing.Exact, "7")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[8]//a[{Utils.XPathText(Casing.Exact, "8")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[9]//a[{Utils.XPathText(Casing.Exact, "9")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[10]//a[{Utils.XPathText(Casing.Exact, "10")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[11]//a[{Utils.XPathText(Casing.Exact, "...")}]");
            ExpectXPath($"//tr[{Utils.lastIdx_XPath}]//td[12]//a[{Utils.XPathText(Casing.Exact, ">>")}]");
            ExpectNoXPath($"//a[{Utils.XPathText(Casing.Exact, "<<")}]");
        }



    }
}
