namespace Admin.ObjectMap
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
    public class AddProperty : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();

            U.AppProperty_ObjectMap(this, C.O1F1, C.P1O1, C.propTypes[0], isList: false);
        }



    }
}
