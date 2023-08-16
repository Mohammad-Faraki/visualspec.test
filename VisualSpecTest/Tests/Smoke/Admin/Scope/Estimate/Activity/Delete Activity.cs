namespace Tests.Smoke.Admin.Scope.Estimate
{
   
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using System.Threading;
    using Tests.Shared.Admin.Scope.Estimate;

    [TestClass]
    public class DeleteActivity : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddActivity>();


            //*********** Delete activity
            C.ScrollToLastActivity(this);
            ClickXPath("//form[@data-module='OtherActivitiesList']//tr[last()]/td[5]/a[@name='Edit']/i");
            WaitToSee(What.Contains, "Edit other activity");
            Near(What.Contains, "Edit other activity").Click(What.Contains,"Delete");
            WaitToSee("Are you sure you want to delete this activity?");
            Click("OK");
            ExpectNo(C.addedActiviy);
            Thread.Sleep(3000);

            C.ScrollToTop(this);
            if (U.environment == U.Environment.Prelive)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "0.5");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
            }
            else if (U.environment == U.Environment.Live)
            {
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "1.25");
                AtHeader(That.Contains, "Solution Design Activities").Expect(What.Contains, "2.25");
            }
        }



    }
}
