namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;

    [TestClass]
    public class AddObject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<PreconObjectMap>();

            ExpectHeader($"A Web App: Everything");

            
            // Add button
            ClickXPath(U.btnAddObjXPath);
            ClickButton(That.Contains, "New Object");
            Expect("First, one of the features must be selected.");

            //ClickLink("feature01");
            //WaitToSeeHeader("feature01");
            C.OpenFeaturePage(this, "feature01");

            ClickXPath(U.btnAddObjXPath);
            ClickLink(That.Contains, "New Object");



            WaitToSeeHeader("Object Details");
            string addObjFormXPath = "//form[@data-module='ObjectCreateForm']";

            //SetXPath($"{addObjFormXPath}//*[{MyUtils.XPathTextContains("Name")}]").To(Constants.O1F1);
            U.SetField(this, labelXPath: $"{addObjFormXPath}//*[{U.XPathTextContains("Name")}]"
                , to: C.O1F1);

            ClickXPath($"{addObjFormXPath}//*[{U.XPathText("Save")}]");
            Thread.Sleep(3000);
            ExpectXPath($"//span[{U.XPathText(C.O1F1)}]");
        }



    }
}
