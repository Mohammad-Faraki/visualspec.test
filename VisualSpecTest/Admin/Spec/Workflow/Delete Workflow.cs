﻿namespace Admin.Workflow
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
    public class DeleteWorkflow : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddWorkflow>();

            ClickXPath($"{C.workflowTopSectionXPath}//button[@name='Delete']");

            Expect("Are you sure you want to delete this workflow model?");
            Click("OK");
            ExpectNo(C.workflow1);
        }



    }
}