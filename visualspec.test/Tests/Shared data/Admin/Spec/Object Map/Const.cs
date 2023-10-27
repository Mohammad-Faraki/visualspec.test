namespace Tests.Shared.Admin.ObjectMap
{
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Const
    {
        public const string formBottomSectionXPath = "//div[@data-module='FooterForm']";
        public const string bottomSectionViewModeXPath = "//*[@data-module='ObjectView']";


        public const string O1F1 = "O1F1";
        public const string O2F1 = "O2F1";
        public const string O3F1 = "O3F1";
        public const string O4F1 = "O4F1";
        public const string O5F1 = "O5F1";
        public const string O6F1 = "O6F1";

        public const string O1F2 = "O1F2";
        public const string O2F2 = "O2F2";
        public const string O3F2 = "O3F2";
        public const string O4F2 = "O4F2";
        public const string O5F2 = "O5F2";
        public const string O6F2 = "O6F2";

        public const string O1F3 = "O1F3";
        public const string O2F3 = "O2F3";
        public const string O3F3 = "O3F3";
        public const string O4F3 = "O4F3";
        public const string O5F3 = "O5F3";
        public const string O6F3 = "O6F3";




        public const string O1F1Edited = "O1F1 edited";


        public static string P1O1 = $"P1{O1F1}";
        public static string P2O1 = $"P2{O1F1}";
        public static string P3O1 = $"P3{O1F1}";
        public static string P4O1 = $"P4{O1F1}";

        public static string P1O2 = $"P1{O2F1}";
        public static string P2O2 = $"P2{O2F1}";
        public static string P3O2 = $"P3{O2F1}";
        public static string P4O2 = $"P4{O2F1}";

        public static string P1O3 = $"P1{O3F1}";
        public static string P2O3 = $"P2{O3F1}";
        public static string P3O3 = $"P3{O3F1}";
        public static string P4O3 = $"P4{O3F1}";





        //public const string propType_String = "String";
        //public const string propType_String_List = "List<String>";
        //public const string propType_Int = "Integer";
        //public const string propType_Int_List = "List<Integer>";
        //public const string propType_Money = "Money";
        //public const string propType_Money_List = "List<Money>";
        //public const string propType_Datetime = "Date/time";
        //public const string propType_Datetime_List = "List<Date/time>";
        //public const string propType_Double = "Double";
        //public const string propType_Double_List = "List<Double>";
        public static string[] propTypes =
            { "String"
             ,"Integer"
             ,"Money"
             ,"Date/time"
             ,"Double"   };
        public static string[] propTypesList =
            { "List<String>"
             ,"List<Integer>"
             ,"List<Money>"
             ,"List<Date/time>"
             ,"List<Double>"   };






        public static void OpenFeaturePage(UITest uiTest, string featureName)
        {
            uiTest.ClickLink(featureName);
            uiTest.WaitToSeeHeader(featureName);
        }
        
    }
}
