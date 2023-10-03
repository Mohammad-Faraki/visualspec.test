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
    public class AddEndNode : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddStartNode>();

            // plus icon to open nodes toolbox
            HoverOver(C.nodeStart);

            //ClickXPath(U.workflow_iconNodesToolbox(nodeName: C.nodeStart));
            int actorColumnIdx = U.GetActorColumnIdx_Workflow(this, U.DefaultActorsDic[U.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(U.workflow_iconNodesToolbox(this, nodeName: C.nodeStart, nodeType: U.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Add end point");
            ExpectHeader("Add New End Point");
            Set("Title").To(C.nodeEnd);
            //ClickButton("Other");
            //NearXPath(C.formEndNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeEnd);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_EndNode)}]//*[{U.XPathTextContains(Casing.Exact, C.nodeEnd)}]");
        }



    }
}
