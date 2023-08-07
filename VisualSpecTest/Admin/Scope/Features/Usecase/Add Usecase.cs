﻿namespace Admin.Scope.Features.Usecase
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;
    using Admin.Website;
    using OpenQA.Selenium.Support.Extensions;

    [TestClass]
    public class AddUsecase : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //** bugs
            // deleting a feature that as usecase has error

            Run<CreateOpenProject>();




            //*********** Add feature
            U.AddFeature(this, U.feature01);


            //*********** Add usecase
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-tree"));
            U.AddUsecase(this, U.feature01, U.f1Usecase1, U.DefaultActors.Admin);
            // Scroll to bottom
            this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("scope-tree"));
            Expect(U.f1Usecase1);


        }
        
    }
}