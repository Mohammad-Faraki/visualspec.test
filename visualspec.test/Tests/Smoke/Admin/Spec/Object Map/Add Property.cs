namespace Tests.Smoke.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;

    [TestClass]
    public class AddProperty : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();

            Utils.AppProperty_ObjectMap(this, Const.O1F1, Const.P1O1, Const.propTypes[0], isList: false);
        }



    }
}
