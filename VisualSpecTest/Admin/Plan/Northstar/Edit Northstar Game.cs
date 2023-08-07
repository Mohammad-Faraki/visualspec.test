namespace Admin.Northstar
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
    using System.Web.UI.WebControls;

    [TestClass]
    public class EditNorthstarGame : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            //Run<AddNorthstar>();
            Run<OpenNorthstar>();
            Thread.Sleep(2000);



            // Manage Select a game
            AtXPath("//form[@data-module='GameTypeForm']").Expect(What.Contains, "Select a game");
            

            ClickXPath("//form[@data-module='GameTypeForm']//a[@name='SelectGameType']");
            WaitToSee("Select the game the product is playing:");
            ClickXPath("//a[@name='TransactionGame']");
            Thread.Sleep(4000);
            AtXPath("//form[@data-module='GameTypeForm']").Expect(What.Contains, "Transaction Game");

            ClickXPath("//form[@data-module='GameTypeForm']//a[@name='SelectGameType']");
            WaitToSee("Select the game the product is playing:");
            ClickXPath("//a[@name='AttentionGame']");
            Thread.Sleep(4000);
            AtXPath("//form[@data-module='GameTypeForm']").Expect(What.Contains, "Attention Game");

            // ************************ app has issue here (uncomment after development)
            // can be commented to continue to edit and delete tests and uncomment after testcase development
            ClickXPath("//form[@data-module='GameTypeForm']//a[@name='SelectGameType']");
            WaitToSee("Select the game the product is playing:");
            ClickXPath("//a[@name='ProductivityGame']");
            Thread.Sleep(4000);
            AtXPath("//form[@data-module='GameTypeForm']").Expect(What.Contains, "Productivity Game");

        }



    }
}
