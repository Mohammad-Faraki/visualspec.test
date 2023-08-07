﻿namespace Admin.Scope.Features
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class DeleteIntegration : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddIntegration>();





            ////*********** Delete integration 
            // Three dots
            ClickXPath(U.btnThreeDotsIntegrationXPath(C.addedIntegration));
            // Delete
            var btnDeleteXPath = $"//*[@data-module='TreeIntegrations']//li[1]//a[{U.XPathTextContains("Delete")}]";
            WaitToSeeXPath(btnDeleteXPath);
            ClickXPath(btnDeleteXPath);
            WaitToSee("Deleting this integration will delete all its associated data in other microservices. Are you sure you want to delete this integration?");
            Click("OK");
            ExpectNo(C.addedIntegration);
        }



    }
}
