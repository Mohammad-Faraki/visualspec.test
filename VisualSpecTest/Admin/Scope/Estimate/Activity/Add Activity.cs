namespace Admin.Scope.Estimate
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;

    [TestClass]
    public class AddActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenEstimate>();
            Thread.Sleep(2000);




            if (U.environment == U.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
            }
            else if (U.environment == U.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.25");
            }


            //*********** Add activity
            ClickLink(That.Contains, "Activity");
            WaitToSee("Add other activity");
            Set(That.Contains, "Activity").To(C.addedActiviy);
            if (U.environment == U.Environment.Prelive)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[4]");
                ClickXPath("//div[@class='select-estimate-size-form']/label[5]");
            }
            else if (U.environment == U.Environment.Live)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[5]");
            }
            Near("Add other activity").Click("Save");


            // Ativity should be added to the end of the table
            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{C.addedActiviy}']");

            // Both are ok for AND
            //ExpectXPath($"//tr[last()]/td[@class='col-4']/div/div[@data-index='1' and @class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='highlighted']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[3][@class='selected']");
            if (U.environment == U.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='2']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }
            else if (U.environment == U.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='4']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }
            //Expect(What.Contains, "1.75-2.25 days");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//h2/span[{MyUtils.XPathText("1.75-2.25 days")}]");
            //ExpectHeader(That.Contains, "1.75-2.25 days");
            //ExpectXPath($"//*[@id='SolutionDesignActivitiesEstimateDays'][{MyUtils.XPathText("1.75-2.25 days")}]");
            //ExpectXPath("//form[1]/h2[@innertext='Solution Design Activities          ']/span[@id='SolutionDesignActivitiesEstimateDays']");
            if (U.environment == U.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (U.environment == U.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }


            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");

            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{C.addedActiviy}']");

            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='highlighted']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[3][@class='selected']");
            if (U.environment == U.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='2']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }
            else if (U.environment == U.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='4']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }

            //Expect(What.Contains, "1.75-2.25 days");
            if (U.environment == U.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (U.environment == U.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }
        }



    }
}
