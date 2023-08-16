namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class AddExistingObject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddProperty>();

            U.AddExistingObject_ObjectMap(this, allPropertyTypes: false);
        }



    }
}
