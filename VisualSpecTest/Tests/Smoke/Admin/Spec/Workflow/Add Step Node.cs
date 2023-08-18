namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
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
            HoverOver(C.nodeStart);

            int actorColumnIdx = U.GetActorColumnIdx_Workflow(this, U.DefaultActorsDic[U.DefaultActors.Admin]);
            // click on plus icon(to open add node toolbox)
            ClickXPath(U.workflow_iconNodesToolbox(this, nodeName: C.nodeStart, nodeType: U.NodeType.Start, actorColumnIdx: actorColumnIdx));

            ClickLink("Add new step");
            ExpectHeader("Add New Step");
            Set("Title").To(C.nodeStep1);
            //ClickButton("Other");
            //NearXPath(C.formStepNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeStep1);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_StepNode)}]//*[{U.XPathTextContains(C.nodeStep1)}]");
        }



    }
}
