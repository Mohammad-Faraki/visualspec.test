namespace Tests.Smoke.Admin.Website
{
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System;
    using System.Threading;

    [TestClass]
    public class CreateOpenProject : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            LoginAs<AdminUser>();

            U.CreateProject(this);

            U.OpenProject(this);
        }



    }
}
