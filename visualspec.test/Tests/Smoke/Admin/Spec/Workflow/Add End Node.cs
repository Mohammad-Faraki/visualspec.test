﻿namespace Tests.Smoke.Admin.Workflow
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
            HoverOver(Const.nodeStart);

            //ClickXPath(U.workflow_iconNodesToolbox(nodeName: C.nodeStart));
            int actorColumnIdx = Utils.GetActorColumnIdx_Workflow(this, Utils.DefaultActorsDic[Utils.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(Utils.workflow_iconNodesToolbox(this, nodeName: Const.nodeStart, nodeType: Utils.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Add end point");
            ExpectHeader("Add New End Point");
            Set("Title").To(Const.nodeEnd);
            //ClickButton("Other");
            //NearXPath(C.formEndNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(Const.nodeEnd);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_EndNode)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeEnd)}]");
        }



    }
}
