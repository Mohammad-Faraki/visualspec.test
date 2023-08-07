namespace Admin.Scope.Features
{
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




        public const string addedActor = "actor01";
        public const string editedActor = "actor01 edited";

        public const string addedApp = "app01";
        public const string editedApp = "app01 edited";

        public const string editedFeature01 = "feature01 edited";
        public const string editedFeature02 = "feature02 edited";

        public const string addedIntegration = "integration01";
        public const string editedIntegration = "integration01 edited";
    }
}
