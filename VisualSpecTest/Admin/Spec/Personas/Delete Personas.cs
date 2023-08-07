namespace Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

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
            ClickXPath("//div[@id='personasMainCanvas']//div[1]//a[text()='Delete ']");
            WaitToSee("Are you sure you want to delete it?");
            ClickButton("OK");
            ExpectNoXPath($"{C.lastPersonaOfFirstActorSidebar}//a[{U.XPathText("Name")}]");
        }



    }
}
