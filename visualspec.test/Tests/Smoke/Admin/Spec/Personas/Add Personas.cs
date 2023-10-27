namespace Tests.Smoke.Admin.Personas
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
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
            ClickXPath($"{Const.firstActorSidebar}//a[{Utils.XPathAttributeContains("href", "AddNewItem")}]");
            WaitToSeeXPath($"{Const.lastPersonaOfFirstActorSidebar}//a[{Utils.XPathText(Casing.Exact, "Name")}]");
        }



    }
}
