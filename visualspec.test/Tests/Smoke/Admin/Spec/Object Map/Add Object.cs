namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
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
            ClickXPath(Utils.btnAddObjXPath);
            ClickButton(That.Contains, "New Object");
            Expect("First, one of the features must be selected.");

            //ClickLink("feature01");
            //WaitToSeeHeader("feature01");
            Const.OpenFeaturePage(this, "feature01");

            ClickXPath(Utils.btnAddObjXPath);
            ClickLink(That.Contains, "New Object");



            WaitToSeeHeader("Object Details");
            string addObjFormXPath = "//form[@data-module='ObjectCreateForm']";

            //SetXPath($"{addObjFormXPath}//*[{MyUtils.XPathTextContains(Casing.Exact, "Name")}]").To(Constants.O1F1);
            Utils.SetField(this, labelXPath: $"{addObjFormXPath}//*[{Utils.XPathTextContains(Casing.Exact, "Name")}]"
                , to: Const.O1F1);

            ClickXPath($"{addObjFormXPath}//*[{Utils.XPathText(Casing.Exact, "Save")}]");
            Thread.Sleep(3000);
            ExpectXPath($"//span[{Utils.XPathText(Casing.Exact, Const.O1F1)}]");
        }



    }
}
