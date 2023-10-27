namespace Tests.Smoke.Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
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

            SetXPath($"{Const.firstPersonaOfFirstActor}//input[@id='Name']").To(Const.editedPersona);
            SetXPath($"{Const.firstPersonaOfFirstActor}//input[@id='Age']").To("25");
            SetXPath($"{Const.firstPersonaOfFirstActor}//input[@id= 'Occupation']").To("test Occupation");
            SetXPath($"{Const.firstPersonaOfFirstActor}//input[@id='PrimaryInterface']").To("test Primary Interface");
            SetXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Traits']").To("test Traits");
            SetXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='TasksGoals']").To("test Tasks/Goals");

            // Scroll to bottom of Traits textarea 
            // This line doesn't work till devs set "personas-content" for personas content
            Utils.ScrollToElementXPath(this, Const.scorllableElement
                , XPath: $"{Const.firstPersonaOfFirstActor}//textarea[@id='Traits']"
                , elementSide: Utils.HtmlElementProp.Bottom);

            SetXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Feelings']").To("test Feelings");
            SetXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='PainPoints']").To("test Pain Points");
            SetXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Message']").To("test Message");


            Utils.ScrollToTop(this, Const.scorllableElement);
            // Click somewhere
            ClickXPath($"{Const.firstPersonaOfFirstActor}//input[@id='Name']");
            Thread.Sleep(3000);
            // in sidebar
            ExpectXPath($"{Const.firstPersonaOfFirstActorSidebar}//a[{Utils.XPathText(Casing.Exact, Const.editedPersona)}]");


            RefreshPage();
            WaitToSeeXPath("//form[@data-module='Personas_MainCanvas_List']");
            Thread.Sleep(2000);



            // in sidebar
            //ExpectXPath("/html/body//div[@class='left-panel']//li[1]//a[1]//div[text()='persona01']");
            ////Expect(C.editedPersona);
            ExpectXPath($"{Const.firstPersonaOfFirstActorSidebar}//a[{Utils.XPathText(Casing.Exact, Const.editedPersona)}]");

            ExpectXPath($"{Const.firstPersonaOfFirstActor}//input[@id='Name'][@value='{Const.editedPersona}']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//input[@id='Age'][@value='25']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//input[@id= 'Occupation'][@value='test Occupation']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//input[@id='PrimaryInterface'][@value='test Primary Interface']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Traits'][text()='test Traits']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='TasksGoals'][text()='test Tasks/Goals']");

            // Scroll to bottom of Traits textarea 
            // This line doesn't work till devs set "personas-content" for personas content
            Utils.ScrollToElementXPath(this, Const.scorllableElement
                , XPath: $"{Const.firstPersonaOfFirstActor}//textarea[@id='Traits']"
                , elementSide: Utils.HtmlElementProp.Bottom);

            ExpectXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Feelings'][text()='test Feelings']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='PainPoints'][text()='test Pain Points']");
            ExpectXPath($"{Const.firstPersonaOfFirstActor}//textarea[@id='Message'][text()='test Message']");
        }



    }
}
