namespace Tests.Smoke.Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Shared.Admin.Personas;

    [TestClass]
    public class EditPersonas : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<AddPersonas>();



            //*********** Edit persona (first persona of first actor)
            //string firstPersonaOfFirstActor = $"//*[@id='personasMainCanvas']//div[1]";

            SetXPath($"{C.firstPersonaOfFirstActor}//input[@id='Name']").To("persona01");
            SetXPath($"{C.firstPersonaOfFirstActor}//input[@id='Age']").To("25");
            SetXPath($"{C.firstPersonaOfFirstActor}//input[@id= 'Occupation']").To("test Occupation");
            SetXPath($"{C.firstPersonaOfFirstActor}//input[@id='PrimaryInterface']").To("test Primary Interface");
            SetXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Traits']").To("test Traits");
            SetXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='TasksGoals']").To("test Tasks/Goals");

            // Scroll to bottom of Traits textarea 
            // This line doesn't work till devs set "personas-content" for personas content
            U.ScrollToElementXPath(this, C.scorllableElement
                , XPath: $"{C.firstPersonaOfFirstActor}//textarea[@id='Traits']"
                , elementSide: U.HtmlElementProp.Bottom);

            SetXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Feelings']").To("test Feelings");
            SetXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='PainPoints']").To("test Pain Points");
            SetXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Message']").To("test Message");


            U.ScrollToTop(this, C.scorllableElement);
            // Click somewhere
            ClickXPath($"{C.firstPersonaOfFirstActor}//input[@id='Name']");
            Thread.Sleep(3000);
            // in sidebar
            ExpectXPath($"{C.firstPersonaOfFirstActorSidebar}//a[{U.XPathText("persona01")}]");


            RefreshPage();
            WaitToSeeXPath("//form[@data-module='Personas_MainCanvas_List']");
            Thread.Sleep(2000);



            // in sidebar
            //ExpectXPath("/html/body//div[@class='left-panel']//li[1]//a[1]//div[text()='persona01']");
            ////Expect("persona01");
            ExpectXPath($"{C.firstPersonaOfFirstActorSidebar}//a[{U.XPathText("persona01")}]");

            ExpectXPath($"{C.firstPersonaOfFirstActor}//input[@id='Name'][@value='persona01']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//input[@id='Age'][@value='25']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//input[@id= 'Occupation'][@value='test Occupation']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//input[@id='PrimaryInterface'][@value='test Primary Interface']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Traits'][text()='test Traits']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='TasksGoals'][text()='test Tasks/Goals']");

            // Scroll to bottom of Traits textarea 
            // This line doesn't work till devs set "personas-content" for personas content
            U.ScrollToElementXPath(this, C.scorllableElement
                , XPath: $"{C.firstPersonaOfFirstActor}//textarea[@id='Traits']"
                , elementSide: U.HtmlElementProp.Bottom);

            ExpectXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Feelings'][text()='test Feelings']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='PainPoints'][text()='test Pain Points']");
            ExpectXPath($"{C.firstPersonaOfFirstActor}//textarea[@id='Message'][text()='test Message']");
        }



    }
}
