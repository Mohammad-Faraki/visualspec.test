namespace Tests.Smoke.Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Shared.Admin.Personas;

    [TestClass]
    public class AddPersonas : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<OpenPersonas>();
            Thread.Sleep(2000);


            //*********** Create persona
            //ClickXPath("//li[1]/*[@class='treeview-node__title']/a[2]");
            //ClickXPath($"//a[{MyUtils.XPathText(Casing.Exact, "Admin")}]/following-sibling::a"); // using sibling element
            ClickXPath($"{C.firstActorSidebar}//a[{U.XPathAttributeContains("href", "AddNewItem")}]");
            WaitToSeeXPath($"{C.lastPersonaOfFirstActorSidebar}//a[{U.XPathText(Casing.Exact, "Name")}]");
        }



    }
}
