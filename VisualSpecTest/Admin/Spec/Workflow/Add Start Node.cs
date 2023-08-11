namespace Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Admin.Website;

    //[TestClass]
    public class AddStartNode : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddWorkflow>();

            ExpectXPath($"//div[{U.XPathAttributeContains("class", C.cssClass_StartNode)}]//*[text()='start']");
            ClickLink("start");
            Expect("Add Start Node");
            Set("Title").To(C.nodeStart);
            ClickButton("Other");
            NearXPath(C.formStartNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeStart);

            int actorColumnIdx = U.GetActorColumnIdx_Workflow(this, U.DefaultActorsDic[U.DefaultActors.Admin] );
            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_StartNode)}]//*[{U.XPathTextContains(C.nodeStart)}]");
        }



    }
}
