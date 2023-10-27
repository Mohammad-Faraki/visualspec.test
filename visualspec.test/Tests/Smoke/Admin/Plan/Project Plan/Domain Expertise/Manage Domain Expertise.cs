namespace Tests.Smoke.Admin.Plan.DomainExpertise
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using OpenQA.Selenium.Support.Extensions;
    using Pangolin;
    using System;
    using System.Threading;
     
    using Tests.Smoke.Admin.Website;

    [TestClass]
    public class EditDomainExpertise : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            
            Run<PreconDomainExpertise>();




            

            //*********** Assign Domain Expertise
            AtRow(1).Click(Utils.feature01);
            WaitToSee("Use cases");

            Expect(Utils.feature01);
            AtRow(1).Expect(Utils.f1Usecase1);
            AtRow(2).Expect(Utils.f1Usecase2);

            AtRow(1).Expect(Utils.DefaultActorsDic[Utils.DefaultActors.Admin]);
            AtRow(2).Expect(Utils.DefaultActorsDic[Utils.DefaultActors.Admin]);


            ClickRow(1);
            Thread.Sleep(1000);
            Click(What.Contains, "Assign Stakeholders");
            WaitToSee("Add Stakeholder");
            ClickButton("Nothing selected");
            ClickLink(Utils.stakeholder1);
            ClickLink(Utils.stakeholder2);
            ClickButton(That.Contains, "Save");

            AtRow(1).WaitToSee(Utils.stakeholder1);
            AtRow(1).Expect(Utils.stakeholder2);
            AtRow(1).ExpectNo(Utils.stakeholder3);

            AtRow(2).ExpectNo(Utils.stakeholder1);
            AtRow(2).ExpectNo(Utils.stakeholder2);
            AtRow(2).ExpectNo(Utils.stakeholder3);
            Thread.Sleep(2000);



            ClickRow(2);
            Thread.Sleep(1000);
            Click(What.Contains, "Assign Stakeholders");
            WaitToSee("Add Stakeholder");
            ClickButton("Nothing selected");
            ClickLink(Utils.stakeholder3);
            ClickButton(That.Contains, "Save");

            AtRow(1).WaitToSee(Utils.stakeholder1);
            AtRow(1).Expect(Utils.stakeholder2);
            AtRow(1).ExpectNo(Utils.stakeholder3);

            AtRow(2).ExpectNo(Utils.stakeholder1);
            AtRow(2).ExpectNo(Utils.stakeholder2);
            AtRow(2).Expect(Utils.stakeholder3);
            Thread.Sleep(2000);




            Utils.OpenPlanDomainExpertise(this);
            AtRow(1).Expect($"{Utils.stakeholder1}: 1");
            AtRow(1).Expect($"{Utils.stakeholder2}: 1");
            AtRow(1).Expect($"{Utils.stakeholder3}: 1");
            AtRow(2).ExpectNo($"{Utils.stakeholder1}: 1");
            AtRow(2).ExpectNo($"{Utils.stakeholder2}: 1");
            AtRow(2).ExpectNo($"{Utils.stakeholder3}: 1");




            Utils.OpenPlanStakeholders(this);

            AtRow(1).Expect($"0h direct");
            AtRow(2).Expect($"0h direct");
            AtRow(3).ExpectNo($"0h direct");

            AtRow(1).ExpectNo($"0h shared");
            AtRow(2).ExpectNo($"0h shared");
            AtRow(3).Expect($"0h shared");

        }
    }
}
