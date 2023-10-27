namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
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
            HoverOver(Const.nodeStart);

            //ClickXPath(U.workflow_iconNodesToolbox(nodeName: C.nodeStart));
            int actorColumnIdx = Utils.GetActorColumnIdx_Workflow(this, Utils.DefaultActorsDic[Utils.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(Utils.workflow_iconNodesToolbox(this, nodeName: Const.nodeStart, nodeType: Utils.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Loop");
            ExpectHeader("Add New Loop");

            BelowLabel("Linked node").ClickButton("---Select---");
            NearXPath(Const.formLoopNodeXPath).BelowLabel("Linked node").ClickLink(Const.nodeStart);

            Click("Save");

            //ExpectLink(C.nodeStart);
            // Check loop node text and design
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_LoopNode)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeLoop1)}]");
            // Check start node text and design
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_StartNode_LoopTarget)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeStart)}]");
        }



    }
}
