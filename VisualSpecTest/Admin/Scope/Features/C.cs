﻿namespace Admin.Scope.Features
{
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class C
    {
        public const string thirdActorXPath = "//*[@data-module='TreeActors']//ul/li[3]";
        public static string btnThreeDotsActorXPath = $"{thirdActorXPath}//i";

        public const string thirdAppXPath = "//*[@data-module='TreeApplications']//ul/li[3]";
        public static string btnThreeDotsAppXPath = $"{thirdAppXPath}//i";

        public const string firstIntegrationXPath = "//*[@data-module='TreeIntegrations']//li[1]";
        public static string btnEditIntegrationXPath = $"{firstIntegrationXPath}//a[{U.XPathText("Edit")}]";


        public static string formApplicationDetailsXPath = $"//form[@data-module='ApplicationForm']";
        public static string formDeviceManagmentXPath = $"//form[@data-module='DeviceManagementForm']";
        public static string formChangeDeviceXPath = $"//form[@data-module='ChangeDeviceForm']";

        public static string formActorDetails = "//form[@data-module='ActorForm']";
        public static string formIntegrationDetails = "//form[@data-module='IntegrationForm']";
        public static string formFeatureDetails = "//form[@data-module='FeatureForm']";
        public static string formUsecaseDetails = "//form[@data-module='UseCaseForm']";



        public const string addedActor = "actor01";
        public const string editedActor = "actor01 edited";

        public const string addedApp = "app01";
        public const string editedApp = "app01 edited";

        public const string editedFeature01 = "feature01 edited";
        public const string editedFeature02 = "feature02 edited";

        public const string addedIntegration = "integration01";
        public const string editedIntegration = "integration01 edited";

        public const string addedDevice = U.Device_NormalScreen;
        public const string editedDevice = U.Device_Mobile;


        public const string scrollable_scopeFeatures_treeView = "scope-tree";

        public static void OpenApplicationDetails(UITest uITest, string appName)
        {
            //*********** Edit application
            // Three dots
            //uITest.ClickXPath(C.btnThreeDotsAppXPath);
            uITest.ClickXPath(U.btnThreeDotsAppXPath(appName));
            // Edit
            //var btnEditXPath = $"{C.thirdAppXPath}//a[{U.XPathText("Edit")}]";
            var btnEditXPath = U.btnEditAppXPath(appName);
            uITest.WaitToSeeXPath(btnEditXPath);
            uITest.ClickXPath(btnEditXPath);
        }
    }
}
