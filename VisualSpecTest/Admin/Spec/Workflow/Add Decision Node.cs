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

    [TestClass]
    public class AddDecisionNode : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddStartNode>();

            // plus icon to open nodes toolbox
            HoverOver(C.nodeStart);

            //ClickXPath(U.workflow_iconNodesToolbox(nodeName: C.nodeStart));
            int actorColumnIdx = U.GetActorColumnIdx_Workflow(this, U.DefaultActorsDic[U.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(U.workflow_iconNodesToolbox(this, nodeName: C.nodeStart, nodeType: U.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Add decision point");
            ExpectHeader("Add New Decision Point");
            Set("Title").To(C.nodeDecision1);
            //ClickButton("Other");
            //NearXPath(C.formDecisionNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeDecision1);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_DecisionNode)}]//*[{U.XPathTextContains(C.nodeDecision1)}]");
        }



    }
}
