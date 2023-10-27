﻿namespace Tests.Smoke.Admin.Website
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class UI_Header_AfterLogin : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Utils.LoginAdmin(this, isFirstTime: true);
            Utils.CheckWebsiteUI_Header_AfterLogin(this);
        }



    }
}
