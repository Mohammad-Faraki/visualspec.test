namespace Tests.Smoke.Admin.Scope.Estimate
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Pangolin;
    using System.Threading;
    using Tests.Shared.Admin.Scope.Estimate;

    [TestClass]
    public class AddActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<OpenEstimate>();
            Thread.Sleep(2000);




            if (Utils.environment == Utils.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.25");
            }


            //*********** Add activity
            ClickLink(That.Contains, "Activity");
            WaitToSee("Add other activity");
            Set(That.Contains, "Activity").To(Const.addedActiviy);
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[4]");
                ClickXPath("//div[@class='select-estimate-size-form']/label[5]");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[5]");
            }
            Near("Add other activity").Click("Save");
            Thread.Sleep(3000);

            //U.ScrollToElementXPath(this, scorllableElement: "scope-content"
            //    , XPath: "//form[@data-module='IntegrationsWithFeatureList']");
            Const.ScrollToLastActivity(this);

            // Ativity should be added to the end of the table
            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{Const.addedActiviy}']");

            // Both are ok for AND
            //ExpectXPath($"//tr[last()]/td[@class='col-4']/div/div[@data-index='1' and @class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='highlighted']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[3][@class='selected']");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='2']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='4']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }

            Utils.ScrollToTop(this, "scope-content");
            
            //Expect(What.Contains, "1.75-2.25 days");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//h2/span[{MyUtils.XPathText(Casing.Exact, "1.75-2.25 days")}]");
            //ExpectHeader(That.Contains, "1.75-2.25 days");
            //ExpectXPath($"//*[@id='SolutionDesignActivitiesEstimateDays'][{MyUtils.XPathText(Casing.Exact, "1.75-2.25 days")}]");
            //ExpectXPath("//form[1]/h2[@innertext='Solution Design Activities          ']/span[@id='SolutionDesignActivitiesEstimateDays']");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }


            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");

            Const.ScrollToLastActivity(this);

            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{Const.addedActiviy}']");

            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='highlighted']");
            ////ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[3][@class='selected']");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='2']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='4']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");
            }

            Utils.ScrollToTop(this, "scope-content");

            //Expect(What.Contains, "1.75-2.25 days");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }
        }



    }
}
