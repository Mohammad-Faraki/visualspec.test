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
            AtRow(1).Click(U.feature01);
            WaitToSee("Use cases");

            Expect(U.feature01);
            AtRow(1).Expect(U.f1Usecase1);
            AtRow(2).Expect(U.f1Usecase2);

            AtRow(1).Expect(U.DefaultActorsDic[U.DefaultActors.Admin]);
            AtRow(2).Expect(U.DefaultActorsDic[U.DefaultActors.Admin]);


            ClickRow(1);
            Thread.Sleep(1000);
            Click(What.Contains, "Assign Stakeholders");
            WaitToSee("Add Stakeholder");
            ClickButton("Nothing selected");
            ClickLink(U.stakeholder1);
            ClickLink(U.stakeholder2);
            ClickButton(That.Contains, "Save");

            AtRow(1).WaitToSee(U.stakeholder1);
            AtRow(1).Expect(U.stakeholder2);
            AtRow(1).ExpectNo(U.stakeholder3);

            AtRow(2).ExpectNo(U.stakeholder1);
            AtRow(2).ExpectNo(U.stakeholder2);
            AtRow(2).ExpectNo(U.stakeholder3);
            Thread.Sleep(2000);



            ClickRow(2);
            Thread.Sleep(1000);
            Click(What.Contains, "Assign Stakeholders");
            WaitToSee("Add Stakeholder");
            ClickButton("Nothing selected");
            ClickLink(U.stakeholder3);
            ClickButton(That.Contains, "Save");

            AtRow(1).WaitToSee(U.stakeholder1);
            AtRow(1).Expect(U.stakeholder2);
            AtRow(1).ExpectNo(U.stakeholder3);

            AtRow(2).ExpectNo(U.stakeholder1);
            AtRow(2).ExpectNo(U.stakeholder2);
            AtRow(2).Expect(U.stakeholder3);
            Thread.Sleep(2000);




            U.OpenPlanDomainExpertise(this);
            AtRow(1).Expect($"{U.stakeholder1}: 1");
            AtRow(1).Expect($"{U.stakeholder2}: 1");
            AtRow(1).Expect($"{U.stakeholder3}: 1");
            AtRow(2).ExpectNo($"{U.stakeholder1}: 1");
            AtRow(2).ExpectNo($"{U.stakeholder2}: 1");
            AtRow(2).ExpectNo($"{U.stakeholder3}: 1");




            U.OpenPlanStakeholders(this);

            AtRow(1).Expect($"0h direct");
            AtRow(2).Expect($"0h direct");
            AtRow(3).ExpectNo($"0h direct");

            AtRow(1).ExpectNo($"0h shared");
            AtRow(2).ExpectNo($"0h shared");
            AtRow(3).Expect($"0h shared");

        }
    }
}
