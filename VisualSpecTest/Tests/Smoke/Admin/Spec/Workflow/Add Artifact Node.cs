namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;
    using System.Linq;
    using Tests.Shared.Admin.Workflow;

    //[TestClass]
    public class AddArtifactNode : UITest
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

            ClickLink("Add Artifact");
            ExpectHeader("Add New Artifact");
            Set("Title").To(C.nodeArtifact1);
            //ClickButton("Other");
            //NearXPath(C.formArtifactNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(C.nodeArtifact1);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_ArtifactNode)}]//*[{U.XPathTextContains(C.nodeArtifact1)}]");
            // check if icon exists
            //var artifactIconXPath = $"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_ArtifactNode)}]//*[{U.XPathTextContains(C.nodeArtifact1)}]/{U.preceding_sibling}::i[@class='fas fa-file']";
            //ExpectXPath(artifactIconXPath);
            //ClickXPath(artifactIconXPath);
            var artifactNodeDirectParentXPath = $"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_ArtifactNode)}]//*[{U.XPathTextContains(C.nodeArtifact1)}]/{U.parent}::div";
            string bgImageURL = this.WebDriver.FindElements(By.XPath(artifactNodeDirectParentXPath)).FirstOrDefault().GetCssValue("background-image");
            if (!bgImageURL.Contains("artifact.svg"))
            {
                Expect("Background image is not set to artifact node!");
            }
        }



    }
}
