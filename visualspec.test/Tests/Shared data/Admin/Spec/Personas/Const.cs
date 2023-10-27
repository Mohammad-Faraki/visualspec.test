namespace Tests.Shared.Admin.Personas
{
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Const
    {
        public static string firstActorSidebar = "//div[1][@class = 'left-menu-tree']";
        public static string lastPersonaOfFirstActorSidebar = $"{firstActorSidebar}//li[last()]";
        public static string firstPersonaOfFirstActorSidebar = $"{firstActorSidebar}//li[1]";

        public const string firstPersonaOfFirstActor = "//*[@id='personasMainCanvas']//div[1]";

        public const string scorllableElement = "personas-content";


        public const string addedPersona = "Name";
        public const string editedPersona = "edited persona";

        public static string firstPersonaThreeDotsContainer_XPath = $"{Const.firstPersonaOfFirstActorSidebar}/div/a/{Utils.following_sibling_XPath}::div";
    }
}
