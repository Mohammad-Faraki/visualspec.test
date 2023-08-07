namespace Admin.Scope.Features
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Pangolin;
    using Admin.Website;

    [TestClass]
    public class EditApplication : UITest
    {
        [PangolinTestMethod]
        public override void RunTest()
        {
            Run<AddApplication>();



            //*********** Edit application
            // Three dots
            ClickXPath(C.btnThreeDotsAppXPath);
            // Edit
            var btnEditXPath = $"{C.thirdAppXPath}//a[{U.XPathText("Edit")}]";
            WaitToSeeXPath(btnEditXPath);
            ClickXPath(btnEditXPath);
            Set("Name").To("application02");
            Click("Save");
            Expect("application02");
        }



    }
}
