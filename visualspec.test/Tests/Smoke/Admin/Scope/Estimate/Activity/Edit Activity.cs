namespace Tests.Smoke.Admin.Scope.Estimate
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Shared.Admin.Scope.Estimate;

    [TestClass]
    public class EditActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddActivity>();



            //*********** Edit activity
            C.ScrollToLastActivity(this);
            ClickXPath("//form[@data-module='OtherActivitiesList']//tr[last()]/td[4]/a[@name='Edit']/i");
            WaitToSee(What.Contains, "Edit other activity");
            Set(That.Contains, "Activity").To(C.editedActiviy);
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[3]");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ClickXPath("//div[@class='select-estimate-size-form']/label[3]");

            }
            Near(What.Contains, "Edit other activity").Click("Save");

            //Thread.Sleep(5000);
            //C.ScrollToLastActivity(this);
            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{C.editedActiviy}']");

            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='highlighted']");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[3][@class='highlighted']");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[4][@class='selected']");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }

            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");

            C.ScrollToLastActivity(this);
            ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[text()='{C.editedActiviy}']");

            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                Thread.Sleep(3000);
                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }

            //*********** Edit only activity estimation, on screen
            C.ScrollToLastActivity(this);
            //ClickXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2]");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                //ClickXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                Utils.OpenDropdown(this, "1", $"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                NearXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]").ClickLink("0.5");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                //ClickXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                Utils.OpenDropdown(this, "1", $"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='1']");
                NearXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]").ClickLink("0.25");
            }
            // Save
            ////ClickXPath("//form[@data-module='OtherActivitiesList']//tr[last()]/td[4]//a");
            Thread.Sleep(3000);
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[1][@class='selected']");
            //ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]/div/div[2][@class='selected']");
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='0.5']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='0.25']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }

            RefreshPage();
            WaitToSee(What.Contains, "Solution Design Activities");

            C.ScrollToLastActivity(this);
            if (Utils.environment == Utils.Environment.Prelive)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='0.5']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.75");
            }
            else if (Utils.environment == Utils.Environment.Live)
            {
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[2]//button[@title='0.25']");
                ExpectXPath($"//form[@data-module='OtherActivitiesList']//tr[last()]/td[3]//button[@title='4']");

                C.ScrollToTop(this);
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.75");
            }
        }



    }
}
