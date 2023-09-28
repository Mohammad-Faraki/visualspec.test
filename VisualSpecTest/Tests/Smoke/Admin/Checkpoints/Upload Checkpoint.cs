namespace Tests.Smoke.Admin.Checkpoints
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class UploadCheckpoint : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {

            Run<OpenCheckpoints>();
            Thread.Sleep(2000);


            ClickXPath("//a[@name='UploadCheckpoint']");
            WaitToSee("Add checkpoint");

            Set(That.Contains,"Name").To(U.checkpoint1);

            var filePath = $"{U.moreFiles_FolderPath}/18HomePage-Compeleted-checkpoint.zip";
            this.WebDriver.FindElement(By.Id("File_fileInput")).SendKeys(filePath);
            Thread.Sleep(5000);

            Click(What.Contains,"Save");
            Thread.Sleep(4000);
            AtXPath("//form[@data-module='CheckpointList']//tr//td[1]").Expect(U.checkpoint1);

        }



    }
}
