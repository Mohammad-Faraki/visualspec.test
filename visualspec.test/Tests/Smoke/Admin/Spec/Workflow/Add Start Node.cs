namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.Workflow;

    //[TestClass]
    public class AddStartNode : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddWorkflow>();

            ExpectXPath($"//div[{Utils.XPathAttributeContains("class", C.cssClass_StartNode)}]//*[text()='start']");
            ClickLink("start");
            Expect("Add Start Node");
            Set("Title").To(C.nodeStart);
            ClickButton("Other");
            NearXPath(C.formStartNodeXPath).ClickLink($"A: {Utils.DefaultActorsDic[Utils.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeStart);

            int actorColumnIdx = Utils.GetActorColumnIdx_Workflow(this, Utils.DefaultActorsDic[Utils.DefaultActors.Admin] );
            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", C.cssClass_StartNode)}]//*[{Utils.XPathTextContains(Casing.Exact, C.nodeStart)}]");
        }



    }
}
