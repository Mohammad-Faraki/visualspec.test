namespace Tests.Minor.Admin.ObjectMap
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using Tests.Smoke.Admin.Website;
    using Tests.Shared.Admin.ObjectMap;
    using Tests.Smoke.Admin.ObjectMap;

    [TestClass]
    public class AddProperty_AllTypes : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddObject>();

            for (int i = 0; i < C.propTypes.Length; i++)
            {
                U.AppProperty_ObjectMap(this, C.O1F1, $"P{i + 1}{C.O1F1}", C.propTypes[i], isList: false);
            }

            // Add list types 
            for (int i = 0; i < C.propTypes.Length; i++)
            {
                U.AppProperty_ObjectMap(this, C.O1F1, $"P{i + 1 + C.propTypes.Length}{C.O1F1}", C.propTypes[i], isList: true);
            }
        }



    }
}
