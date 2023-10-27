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

            for (int i = 0; i < Const.propTypes.Length; i++)
            {
                Utils.AppProperty_ObjectMap(this, Const.O1F1, $"P{i + 1}{Const.O1F1}", Const.propTypes[i], isList: false);
            }

            // Add list types 
            for (int i = 0; i < Const.propTypes.Length; i++)
            {
                Utils.AppProperty_ObjectMap(this, Const.O1F1, $"P{i + 1 + Const.propTypes.Length}{Const.O1F1}", Const.propTypes[i], isList: true);
            }
        }



    }
}
