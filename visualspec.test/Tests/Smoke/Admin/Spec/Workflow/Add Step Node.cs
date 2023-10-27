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
    public class AddStepNode : UITest
    {
        //[PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddStartNode>();

            // plus icon to open nodes toolbox
            HoverOver(Const.nodeStart);

            int actorColumnIdx = Utils.GetActorColumnIdx_Workflow(this, Utils.DefaultActorsDic[Utils.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(Utils.workflow_iconNodesToolbox(this, nodeName: Const.nodeStart, nodeType: Utils.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Add new step");
            ExpectHeader("Add New Step");
            Set("Title").To(Const.nodeStep1);
            //ClickButton("Other");
            //NearXPath(C.formStepNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(Const.nodeStep1);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_StepNode)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeStep1)}]");
        }



    }
}
