﻿namespace Tests.Smoke.Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Shared.Admin.Personas;

    [TestClass]
    public class DeletePersonas : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddPersonas>();

            // Scroll to bottom of Traits textarea 
            // This line doesn't work till devs set "personas-content" for personas content
            U.ScrollToElementXPath(this, C.scorllableElement
                , XPath: $"{C.firstPersonaOfFirstActor}//textarea[@id='Traits']"
                , elementSide: U.HtmlElementProp.Bottom);
            //*********** Delete persona
            //ClickXPath("//div[@id='personasMainCanvas']//div[1]//a[text()='Delete ']");
            ClickXPath($"{C.firstPersonaThreeDotsContainer_XPath}/a");
            ClickXPath($"{C.firstPersonaThreeDotsContainer_XPath}//a[{U.XPathText(Casing.Exact, "Delete")}]");
            WaitToSee("Are your sure to delete this item?");
            ClickButton("OK");
            ExpectNoXPath($"{C.lastPersonaOfFirstActorSidebar}//a[{U.XPathText(Casing.Exact, "Name")}]");
        }



    }
}