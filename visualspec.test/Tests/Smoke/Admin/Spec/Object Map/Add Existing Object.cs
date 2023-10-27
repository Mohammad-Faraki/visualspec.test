namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class AddExistingObject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddProperty>();

            Utils.AddExistingObject_ObjectMap(this, allPropertyTypes: false);
        }



    }
}
