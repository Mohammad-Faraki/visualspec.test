namespace Admin.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class C
    {
        public const string workflow1 = "workflow1";
        public const string workflowTopSectionXPath = "//form[@data-module='WorkFlowDiagramModule']";
        public const string workflow1_Edited = "workflow1 edited";

        public const string nodeStart = "start node";
        public const string nodeStep1 = "step node1";
        public const string nodeDecision1 = "decision node1";
        public const string nodeLoop1 = "loop";
        public const string nodeArtifact1 = "artifact node1";
        public const string nodeEnd = "end node";


        //node forms
        public const string formStartNodeXPath = "//form[@data-module='StartNodeForm']";
        public const string formStepNodeXPath = "//form[@data-module='StepNodeForm']";
        public const string formDecisionNodeXPath = "//form[@data-module='DecisionNodeForm']";
        public const string formEndNodeXPath = "//form[@data-module='EndNodeForm']";
        public const string formLoopNodeXPath = "//form[@data-module='LinkNodeForm']";
        public const string formArtifactNodeXPath = "//form[@data-module='ArtifactNodeForm']";





        public static string cssClass_StartNode      = $"start-node";
        public static string cssClass_StartNode_LoopTarget      = $"start-node {cssClass_LoopNodeTarget}";
                                                       
        public static string cssClass_StepNode       = $"step-node";
        public static string cssClass_StepNode_LoopTarget = $"step-node {cssClass_LoopNodeTarget}";
                                                       
        public static string cssClass_DecisionNode   = $"decision-node";
        public static string cssClass_DecisionNode_LoopTarget = $"decision-node {cssClass_LoopNodeTarget}";
                                                       
        public static string cssClass_EndNode        = $"end-node";
                                                       
        public static string cssClass_ArtifactNode   = $"artifact-node";
        public static string cssClass_ArtifactNode_LoopTarget = $"artifact-node {cssClass_LoopNodeTarget}";


        public const string cssClass_LoopNode       = "step-node link-node";
        public const string cssClass_LoopNodeTarget = "link-node-parent";
    }
}
