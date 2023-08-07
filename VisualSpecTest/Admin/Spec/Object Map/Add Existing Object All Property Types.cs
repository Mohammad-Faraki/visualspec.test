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
    public class AddExistingObject_AllPropertyTypes : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddProperty_AllTypes>();

            U.AddExistingObject_ObjectMap(this, allPropertyTypes: true);
        }



    }
}
