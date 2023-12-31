﻿namespace Tests.Smoke.Admin.Workflow
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using System.Linq;
    using Tests.Shared.Admin.Workflow;
    using OpenQA.Selenium;

    //[TestClass]
    public class AddArtifactNode : UITest
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

            ClickLink("Add Artifact");
            ExpectHeader("Add New Artifact");
            Set("Title").To(Const.nodeArtifact1);
            //ClickButton("Other");
            //NearXPath(C.formArtifactNodeXPath).ClickLink($"A: {U.DefaultActorsDic[U.DefaultActors.Admin]}");
            Click("Save");
            Expect(Const.nodeArtifact1);

            // check design of the node
            ExpectXPath($"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_ArtifactNode)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeArtifact1)}]");
            // check if icon exists
            //var artifactIconXPath = $"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", C.cssClass_ArtifactNode)}]//*[{U.XPathTextContains(Casing.Exact, C.nodeArtifact1)}]/{U.preceding_sibling}::i[@class='fas fa-file']";
            //ExpectXPath(artifactIconXPath);
            //ClickXPath(artifactIconXPath);
            var artifactNodeDirectParentXPath = $"//td[{actorColumnIdx}]//div[{Utils.XPathAttributeContains("class", Const.cssClass_ArtifactNode)}]//*[{Utils.XPathTextContains(Casing.Exact, Const.nodeArtifact1)}]/{Utils.parent_XPath}::div";
            string bgImageURL = this.WebDriver.FindElements(By.XPath(artifactNodeDirectParentXPath)).FirstOrDefault().GetCssValue("background-image");
            if (!bgImageURL.Contains("artifact.svg"))
            {
                Expect("Background image is not set to artifact node!");
            }
        }



    }
}
