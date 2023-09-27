namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using HtmlAgilityPack;
    using Tests.Shared.Admin.Workflow;

    //[TestClass]
    public class AddLoopNode : UITest
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

            ClickLink("Loop");
            ExpectHeader("Add New Loop");

            BelowLabel("Linked node").ClickButton("---Select---");
            NearXPath(C.formLoopNodeXPath).BelowLabel("Linked node").ClickLink(C.nodeStart);

            Click("Save");

            //ExpectLink(C.nodeStart);
            // Check loop node text and design
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_LoopNode)}]//*[{U.XPathTextContains(Casing.Exact, C.nodeLoop1)}]");
            // Check start node text and design
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_StartNode_LoopTarget)}]//*[{U.XPathTextContains(Casing.Exact, C.nodeStart)}]");
        }



    }
}
