namespace Tests
{
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Tests.Smoke.Admin;
    using Tests.Smoke.Admin.Plan;
    using Tests.Smoke.Admin.Website;
    using Tests.Smoke.Admin.ObjectMap;
    using OpenQA.Selenium.Support.Extensions;
    using Tests.Smoke.Admin.Estimator;

    using System.Configuration;
    using AngleSharp.Dom;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    public static class U
    {
        #region Test variables

        private static string env = ConfigurationManager.AppSettings.Get("TestEnv");
        public static Environment environment
        {
            get
            {
                var ret = Environment.Prelive;

                switch (env)
                {
                    case "Live":
                        ret = Environment.Live;
                        break;
                    case "Prelive":
                        ret = Environment.Prelive;
                        break;
                    case "UAT":
                        ret = Environment.UAT;
                        break;
                    case "Local":
                        ret = Environment.Local;
                        break;
                }

                return ret;
            }
        }







        public static string moreFiles_FolderPath = ConfigurationManager.AppSettings.Get("MoreFiles"); 
        public const string credintialsFile_FileName = "credintials.txt";
        public static string credintialsFile_FullPath = moreFiles_FolderPath + "/" + credintialsFile_FileName;
        public static string AdminEmail => ReadFile_FirstLine(moreFiles_FolderPath, credintialsFile_FileName, createFileIsNotExist: false);
        public const string AdminFullname = "Mohammad Geraily";


        public const string feature01 = "feature01";
        public const string feature02 = "feature02";
        public const string feature03 = "feature03";
        public const string feature04 = "feature04";

        public const string f1Usecase1 = "feature01 - U1";
        public const string f1Usecase2 = "feature01 - U2";
        public const string f1Usecase3 = "feature01 - U3";

        public const string f2Usecase1 = "feature02 - U1";
        public const string f2Usecase2 = "feature02 - U2";
        public const string f2Usecase3 = "feature02 - U3";

        public const string f3Usecase1 = "feature03 - U1";
        public const string f3Usecase2 = "feature03 - U2";
        public const string f3Usecase3 = "feature03 - U3";



        public const string stakeholder1 = "stakeholder01";
        public const string stakeholder2 = "stakeholder02";
        public const string stakeholder3 = "stakeholder03";


        public const string checkpoint1 = "checkpoint01";
        public const string checkpoint2 = "checkpoint02";
        public const string checkpoint3 = "checkpoint03";


        public const string TitleScopeFeatures = "Features > Application";

        #region XPath variables
        public const string lastElement_XPath = "last()";

        /// <summary>
        /// example:   //a[@name='OpenUseCaseDiagram']/following-sibling::i
        /// </summary>
        public const string following_sibling_XPath = "following-sibling";

        /// <summary>
        /// example:   //a[@name='OpenUseCaseDiagram']/preceding-sibling::i
        /// </summary>
        public const string preceding_sibling_XPath = "preceding-sibling";

        /// <summary>
        /// Direct parent
        /// example:   //*[title="50"]/parent::a
        /// </summary>
        public const string parent_XPath = "parent";


        /// <summary>
        /// Return value will be a xpath, so you can add it to another xpath or before another xpath. return value:  $"//h1[{U.XPathText(Casing.Exact, headerText)}] | //h2[{U.XPathText(Casing.Exact, headerText)}] | //h3[{U.XPathText(Casing.Exact, headerText)}] | //h4[{U.XPathText(Casing.Exact, headerText)}] | //h5[{U.XPathText(Casing.Exact, headerText)}] | //h6[{U.XPathText(Casing.Exact, headerText)}]"
        /// </summary>
        /// <param name="headerText"></param>
        /// <returns></returns>
        public static string header_XPath(string headerText, Casing casing)
            => $"//h1[{U.XPathText(casing, headerText)}] | //h2[{U.XPathText(casing, headerText)}] | //h3[{U.XPathText(casing, headerText)}] | //h4[{U.XPathText(casing, headerText)}] | //h5[{U.XPathText(casing, headerText)}] | //h6[{U.XPathText(casing, headerText)}]";

        /// <summary>
        /// Return value will be a xpath, so you can add it to another xpath or before another xpath. return value: $"//h1[{U.XPathTextContains(Casing.Exact, headerText)}] | //h2[{U.XPathTextContains(Casing.Exact, headerText)}] | //h3[{U.XPathTextContains(Casing.Exact, headerText)}] | //h4[{U.XPathTextContains(Casing.Exact, headerText)}] | //h5[{U.XPathTextContains(Casing.Exact, headerText)}] | //h6[{U.XPathTextContains(Casing.Exact, headerText)}]";
        /// </summary>
        /// <param name="headerText"></param>
        /// <returns></returns>
        public static string headerContains_XPath(string headerText, Casing casing)
            => $"//h1[{U.XPathTextContains(casing, headerText)}] | //h2[{U.XPathTextContains(casing, headerText)} ] | //h3[ {U.XPathTextContains(casing, headerText)}] | //h4[{U.XPathTextContains(casing, headerText)} ] | //h5[ {U.XPathTextContains(casing, headerText)}] | //h6[{U.XPathTextContains(casing, headerText)}]";



        #endregion




        public enum DefaultApplications
        {
            WebApp,
            MobileApp
        }
        public static Dictionary<DefaultApplications, string> DefaultApplicationsDic = new Dictionary<DefaultApplications, string>
        {
            { DefaultApplications.WebApp , "A Web App" },
            { DefaultApplications.MobileApp , "A Mobile App" }
        };
        // You can use below variables instead for convinience
        public const string app_WebApp = "A Web App";
        public const string app_Mobile = "A Mobile App";



        public enum DefaultActors
        {
            Admin,
            Customer
        }
        public static Dictionary<DefaultActors, string> DefaultActorsDic = new Dictionary<DefaultActors, string>
        {
            { DefaultActors.Admin , "Admin" },
            { DefaultActors.Customer , "Customer" }
        };
        // You can use below variables instead for convinience
        public const string Actor_Admin = "Admin";
        public const string Actor_Customer = "Customer";



        public const string Device_NormalScreen = "Normal screen";
        public const string Device_WideScreen = "Wide screen";
        public const string Device_TabletPortrait = "Tablet - Portrait";
        public const string Device_TabletLandscape = "Tablet - Landscape";
        public const string Device_Mobile = "Mobile";




        public enum Environment
        {
            Live,
            Prelive,
            UAT,
            Local
        }
        public enum HtmlElementProp
        {
            Top,
            Bottom,
            Right,
            Left,
            Height,
            Width,
            X,
            Y
        }
        public enum NodeType
        {
            Start,
            Step,
            End,
            Decision,
            Loop,
            Artifact,
            Start_LoopTarget,
            Step_LoopTarget,
            Decision_LoopTarget,
            Artifact_LoopTarget,

        }


        public enum Estimate
        {
            XS,
            S,
            M,
            L,
            XL
        }
        public static double EstimateVal(Estimate estimate)
        {
            double ret = 0;
            switch (estimate)
            {
                case Estimate.XS:
                    ret = 0.25;
                    break;
                case Estimate.S:
                    ret = 0.5;
                    break;
                case Estimate.M:
                    ret = 1;
                    break;
                case Estimate.L:
                    ret = 2;
                    break;
                case Estimate.XL:
                    ret = 4;
                    break;
            }

            return ret;
        }

        #region Commented ProjectName
        //public static string ProjectName
        //{
        //    get
        //    {
        //        string projectName = "";
        //        switch (environment)
        //        {
        //            case Environment.Live:
        //                projectName = $"xTest003";
        //                break;
        //            case Environment.Prelive:
        //                projectName = $"xTest001";
        //                break;
        //            case Environment.UAT:
        //                projectName = $"";
        //                break;
        //            case Environment.Local:
        //                projectName = $"xTest001";
        //                break;
        //        }


        //        return projectName;
        //    }
        //} 
        #endregion

        //private static string TestProjtIdxFile_Folder = @"D:\0MyFiles\VS Testcases\TestProjectNames\";
        private static string TestProjIdxFile_Name
        {
            get
            {
                string testProjIdxFile_Name = "";

                switch (environment)
                {
                    case Environment.Live:
                        testProjIdxFile_Name = "LiveTestProj.txt";
                        break;
                    case Environment.Prelive:
                        testProjIdxFile_Name = "PreliveTestProj.txt";
                        break;
                    case Environment.UAT:
                        testProjIdxFile_Name = "UATTestProj.txt";
                        break;
                    case Environment.Local:
                        testProjIdxFile_Name = "LocalTestProj.txt";
                        break;
                }

                return testProjIdxFile_Name;
            }
        }

        public static string TestProjIdxFile_FullPath = moreFiles_FolderPath + "/" + TestProjIdxFile_Name;
        public static string TestProjIdx => ReadFile_FirstLine(moreFiles_FolderPath, TestProjIdxFile_Name, createFileIsNotExist: true);

        private const string TestProjectNamePrefix = "xTest";
        public static string TestProjectName => $"{TestProjectNamePrefix}{TestProjIdx}";






        public static string WebsiteDomain
        {
            get
            {
                string websiteDomain = "";

                switch (environment)
                {
                    case Environment.Live:
                        websiteDomain = "visualspec.co.uk";
                        break;
                    case Environment.Prelive:
                        websiteDomain = "live-visualspec.on.uat.co";
                        break;
                    case Environment.UAT:
                        websiteDomain = "uat.live-visualspec.on.uat.co";
                        break;
                    case Environment.Local:
                        websiteDomain = "visualspec.local.com";
                        break;
                }

                return websiteDomain;
            }
        }
        public static string AdminPassword
        {
            get
            {
                string adminPassword = "";

                switch (environment)
                {
                    case Environment.Live:
                        adminPassword = ReadFileLine(2, credintialsFile_FullPath);
                        break;
                    case Environment.Prelive:
                        adminPassword = ReadFileLine(4, credintialsFile_FullPath);
                        break;
                    case Environment.UAT:
                        adminPassword = ReadFileLine(6, credintialsFile_FullPath);
                        break;
                    case Environment.Local:
                        adminPassword = ReadFileLine(8, credintialsFile_FullPath);
                        break;
                }

                return adminPassword;
            }
        }







        #endregion



        #region Some shared variables

        public static string btnAddFeatureXPath = $"//a[@name='CreateFeature']";

        //public static string btnThreeDotsFeatureXPath(int featureIndex) => $"//*[@data-module='TreeFeatures']//li[{featureIndex}]//i";
        public static string btnThreeDotsFeatureXPath(string featureName) => $"//*[@data-module='TreeFeatures']//a[{XPathText(Casing.Exact, featureName)}]/following-sibling::i";
        public static string btnThreeDotsIntegrationXPath(string integrationName) => $"//*[@data-module='TreeIntegrations']//a[{XPathTextContains(Casing.Exact, integrationName)}]/following-sibling::i";
        //public static string btnThreeDotsUsecaseXPath(int featureIndex, int usecaseIdx) => $"//*[@data-module='TreeFeatures']/nav/ul/li[{featureIndex}]//ul/li[{usecaseIdx}]//i[2]";
        public static string usecaseXPath(int featureIndex, int usecaseIdx) => $"//*[@data-module='TreeFeatures']//ul/li[{featureIndex}]//ul/li[{usecaseIdx}]";
        public static string btnThreeDotsUsecaseXPath(int featureIndex, int usecaseIdx) => $"{usecaseXPath(featureIndex, usecaseIdx)}//a[@name='OpenUseCaseDiagram']/following-sibling::i";
        //public static string btnDeleteFeatureXPath(int featureIndex) => $"//*[@data-module='TreeFeatures']//li[{featureIndex}]//a[{XPathTextContains(Casing.Exact, "Delete")}]";
        public static string btnDeleteFeatureXPath(string featureName) => $"//*[@data-module='TreeFeatures']//li[{XPathHasElement($"a[{XPathText(Casing.Exact, featureName)}]")}]//a[{XPathTextContains(Casing.Exact, "Delete")}]";


        public static string btnThreeDotsAppXPath(string appName) => $"//*[@data-module='TreeApplications']//a[{XPathText(Casing.Exact, appName)}]/following-sibling::i";
        public static string btnDeleteAppXPath(string appName) => $"//*[@data-module='TreeApplications']//li[{XPathHasElement($"a[{XPathText(Casing.Exact, appName)}]")}]//a[{XPathTextContains(Casing.Exact, "Delete")}]";
        public static string btnEditAppXPath(string appName) => $"//*[@data-module='TreeApplications']//li[{XPathHasElement($"a[{XPathText(Casing.Exact, appName)}]")}]//a[{XPathTextContains(Casing.Exact, "Edit")}]";


        public static string btnAddObjXPath = $"//form[@data-module='ObjectMapDiagram']//div[{U.XPathAttributeContains("class", "dropstart")}]/button";
        public static string btnAddWorklowXPath(string featureName) => $"//button[{U.XPathHasElement($"*[{U.XPathTextContains(Casing.Exact, featureName)}]")}]/following-sibling::a";

        /// <summary>
        /// Plus icon to open nodes toolbox
        /// </summary>
        public static string workflow_iconNodesToolbox(UITest uiTest, int actorColumnIdx, string nodeName, NodeType nodeType)
            => $"//*[@id='menu-{GetNodeId_Workflow(uiTest, actorColumnIdx, nodeName, nodeType)}']//button";
        //public static string workflow_iconNodesToolbox(string nodeName) => $"//*[{XPathTextContains(Casing.Exact, nodeName)}]/{U.following_sibling}::div//button";

        /// <summary>
        /// Use // or / before this function
        /// </summary>
        /// <param name="btnText"></param>
        /// <returns></returns>
        //public static string btnOpenDropdownXPath(string btnText) => $"button[{U.XPathHasElement($"*[{U.XPathText(Casing.Exact, btnText)}]")}]";
        ////public static string btnOpenDropdownXPath(string btnText) => $"*[{U.XPathText(Casing.Exact, btnText)}]";
        public static string btnOpenDropdownXPath(string btnText) => $"div[{U.XPathText(Casing.Exact, btnText)}]";
        public static void OpenDropdown(UITest uiTest, string dropdownBtnText, string atXPath = "")
        {
            if (atXPath != "")
                uiTest.ClickXPath($"{atXPath}//{btnOpenDropdownXPath(dropdownBtnText)}");
            else
                uiTest.ClickXPath($"//{btnOpenDropdownXPath(dropdownBtnText)}");
        }

        #region Website
        public static string frmProjectDetailsXPath = $"//form[{XPathAttributeContains("action", "Edit-project")}]";
        public static string btnEditProjectXPath(int rowIdx) => $"//tr[{rowIdx}]//*[{XPathAttributeContains("name", "btnEdit")}]";
        #endregion

        #endregion


        public static void AddFeature(UITest uiTest, string name)
        {
            uiTest.ClickXPath(btnAddFeatureXPath);
            uiTest.WaitToSee("Add feature");
            uiTest.Set("Name").To(name);
            uiTest.Click("Save");
            Thread.Sleep(3000);
            ScrollToBottom(uiTest, Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView);
            uiTest.Expect(name);
        }
        public static void DeleteFeature(UITest uiTest, string featureName)
        {
            uiTest.ClickXPath(btnThreeDotsFeatureXPath(featureName));
            uiTest.Expect(What.Contains, "Add Use case");
            //Near(What.Contains, feature02).Below(What.Contains, "Add Use case").Click(What.Contains, "Delete");
            uiTest.ClickXPath(btnDeleteFeatureXPath(featureName));
            uiTest.WaitToSee("Deleting this feature will delete all its associated data in other microservices. Are you sure you want to delete this feature?");
            uiTest.Click("OK");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="featureIndex"></param>
        /// <param name="usecaseName"></param>
        /// <param name="actor"></param>
        /// <param name="application"></param>
        /// <param name="estimateFromTo"></param>
        /// <param name="unselectIfSelected">If it's flase, it won't unselect the actor if it's already selected</param>
        public static void AddUsecase(UITest uiTest, string featureName, string usecaseName,
            DefaultActors actor, /*DefaultApplications application,*/ Tuple<Estimate, Estimate> estimateFromTo = null, bool unselectIfSelected = true)
        {
            string actorName = DefaultActorsDic[actor];
            //string applicationName = DefaultApplicationsDic[application];

            string usecaseFormXPath = "//form[@data-module='UseCaseForm']";
            string descriptionXPath = $"{usecaseFormXPath}//textarea[@name='Description']";

            //ScrollToBottom(uiTest, "scope-tree", webDriver);

            uiTest.ClickXPath(btnThreeDotsFeatureXPath(featureName));
            Thread.Sleep(3000);
            uiTest.Expect(What.Contains, "Add Use case");
            //uiTest.Near(What.Contains, FeatureNmae).Click(What.Contains, "Add Use case");
            //uiTest.ClickXPath($"//*[@data-module='TreeFeatures']//ul/li[{featureIndex}]//a[{XPathText(Casing.Exact, "Add use case")}]");
            uiTest.ClickXPath($"//*[@data-module='TreeFeatures']//li[descendant::a[{XPathText(Casing.Exact, featureName)}]]//a[{XPathText(Casing.Exact, "Add use case")}]");
            uiTest.WaitToSee("Add usecase");
            uiTest.Set("Name").To(usecaseName);


            #region Commented select feature
            //uiTest.ClickXPath($"{usecaseFormXPath}//div[2]//button");
            //// +1 is becase there is a default "nothing selected" option
            //uiTest.ClickXPath($"{usecaseFormXPath}//div[2]//li[{featureIndex + 1}]//a");
            //// To close actors popup
            //uiTest.ClickXPath(descriptionXPath); 
            #endregion


            // Actors
            uiTest.ClickXPath($"{usecaseFormXPath}//div[5]//button/div/div/div");
            // select "Customer" actor
            //uiTest.ClickXPath($"{usecaseFormXPath}//div[5]//span[text()='{actorName}']");
            //uiTest.NearXPath($"{usecaseFormXPath}").ClickLink(actorName);
            var actorDropdownXPath = $"{usecaseFormXPath}//div[5]//div[@role='listbox']";
            var actorCheckBoxXPath = $"{actorDropdownXPath}//a[{XPathHasDirectElement($"*[{U.XPathText(Casing.Exact, actorName)}]")}]";
            var attributeName = "aria-selected";
            //var checkBoxElement_Js = JsCodeToGetHTMLElementJS_ByXPath(actorCheckBoxXPath);
            //var selectedAttributeVal = U.ExecuteJS_ReturnValue(uiTest, $"{checkBoxElement_Js}.getAttribute('{attributeName}')");
            var selectedAttributeVal = U.GetHtmlElementAttribute(uiTest, actorCheckBoxXPath, attributeName);
            bool wasSelected = selectedAttributeVal == "true" ? true : false;

            if (!wasSelected || (wasSelected && unselectIfSelected == true))
                uiTest.AtXPath(actorDropdownXPath).ClickLink(actorName);
            // To close actors popup
            uiTest.ClickXPath(descriptionXPath);



            #region Commented application select
            //// Applications
            //uiTest.ClickXPath($"{usecaseFormXPath}//div[6]//button");
            //// select "A Web App" application
            ////uiTest.ClickXPath($"{usecaseFormXPath}//div[6]//span[text()='{applicationName}']");
            //uiTest.NearXPath($"{usecaseFormXPath}//div[6]//button[@data-id='ApplicationItems']").ClickLink(applicationName); 
            #endregion


            if (estimateFromTo != null)
            {
                int from = -1;
                switch (estimateFromTo.Item1)
                {
                    case Estimate.XS:
                        from = 1;
                        break;
                    case Estimate.S:
                        from = 2;
                        break;
                    case Estimate.M:
                        from = 3;
                        break;
                    case Estimate.L:
                        from = 4;
                        break;
                    case Estimate.XL:
                        from = 5;
                        break;
                }

                int to = -1;
                switch (estimateFromTo.Item2)
                {
                    case Estimate.XS:
                        to = 1;
                        break;
                    case Estimate.S:
                        to = 2;
                        break;
                    case Estimate.M:
                        to = 3;
                        break;
                    case Estimate.L:
                        to = 4;
                        break;
                    case Estimate.XL:
                        to = 5;
                        break;
                }



                uiTest.ClickXPath($"{usecaseFormXPath}//label[@data-index='{from}']");
                uiTest.ClickXPath($"{usecaseFormXPath}//label[@data-index='{to}']");
            }


            uiTest.Click("Save");

            Thread.Sleep(5000);
            //ScrollToBottom(uiTest, "scope-tree", webDriver);
            //uiTest.Expect(usecaseName);
        }
        //public static void DeleteUsecase(UITest uiTest, string usecaseName)
        public static void DeleteUsecase(UITest uiTest, string usecaseName, int featureIdx, int usecaseIdx)
        {
            //uiTest.Click(usecaseName);
            uiTest.ClickXPath(btnThreeDotsUsecaseXPath(featureIdx, usecaseIdx));
            uiTest.ClickXPath($"{usecaseXPath(featureIndex: 1, usecaseIdx: 1)}//a[@name='EditUseCase']");
            uiTest.WaitToSee(What.Contains, "Edit usecase");
            uiTest.Near(What.Contains, "Edit usecase").Click("Delete");
            uiTest.WaitToSee("Deleting this use case will delete all its associated data in other microservices. Are you sure you want to delete this use case?");
            uiTest.Click("OK");
            uiTest.ExpectNo(usecaseName);
        }


        /// <summary>
        /// e.g., write a[XPathText(Casing.Exact, "feature01")] instead of a[text()='feature01']
        /// </summary>
        /// <param name="elementText"></param>
        /// <returns></returns>
        public static string XPathText(Casing casing, string elementText)
        {
            string ret = "";
            switch (casing)
            {
                case Casing.Exact:
                    ret = $"text()='{elementText}'";
                    break;
                case Casing.Ignore:
                    //CD[lower-case(@title)='empire burlesque']
                    var lowercasedText = elementText.ToLower();
                    //ret = $"lower-case(text())='{lowercasedText}'";
                    ret = $"{U.XPathFunction_ToLowerCase("text()")}='{lowercasedText}'";
                    break;
            }

            return ret;
        }
        public static string XPathTextContains(Casing casing, string elementText)
        {
            string ret = "";
            switch (casing)
            {
                case Casing.Exact:
                    ret = $"contains(text(), '{elementText}')";
                    break;
                case Casing.Ignore:
                    //CD[lower-case(@title)='empire burlesque']
                    var lowercasedText = elementText.ToLower();
                    ret = $"contains({U.XPathFunction_ToLowerCase("text()")}, '{lowercasedText}')";
                    break;
            }

            return ret;
        }
        //public static string XPathText(Casing.Exact, string elementText)
        //    => $"text()='{elementText}'";

        //public static string XPathTextContains(Casing.Exact, string elementText)
        //    => $"contains(text(), '{elementText}')";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpathTextToTranslate"></param>
        /// <returns>translate({xpathTextToTranslate}, 'ABCDEFGHIJKLMNOPURSTUWXYZ', 'abcdefghijklmnopurstuwxyz')"</returns>
        public static string XPathFunction_ToLowerCase(string xpathTextToTranslate)
        {
            return $"translate({xpathTextToTranslate}, 'ABCDEFGHIJKLMNOPURSTUWXYZ', 'abcdefghijklmnopurstuwxyz')";
        }
        
        



        /// <summary>
        /// Find elements that have "attribute" with value that contains "attributeVal".
        /// Example result: contains(@class, 'measure-tab')
        /// </summary>
        /// <param name="attribute">e.g., class</param>
        /// <param name="attributeVal">e.g., primary</param>
        /// <returns></returns>
        public static string XPathAttributeContains(string attribute, string attributeVal)
            => $"contains(@{attribute}, '{attributeVal}')";

        public static string XPathAttribute(string attribute, string attributeVal)
            => $"@{attribute}= '{attributeVal}'";


        /// <summary>
        /// It searchs in all levels under the element, not just dircet child
        /// </summary>
        /// <param name="xpathElement">don't put // or / before element tag</param>
        /// <returns></returns>
        public static string XPathHasElement(string xpathElement)
            => $"descendant::{xpathElement}";

        /// <summary>
        /// It searchs for dircet child
        /// </summary> 
        /// <param name="xpathElement">don't put // or / before element tag</param>
        /// <returns></returns>
        public static string XPathHasDirectElement(string xpathElement)
            => xpathElement;

        #region Commented PinSidebar() UnpinSidebar()
        //public static void PinSidebar(UITest uiTest)
        //{
        //    //uiTest.ExpectNo(What.Contains, "Deliver");

        //    //HoverOverXPath("//li[@id='menuItem_Scope']/a[@href='#menuItem_Scope']");
        //    // Scope icon
        //    uiTest.ClickXPath("//li[@id='menuItem_Scope']/a[@href='#menuItem_Scope']");
        //    // Pin btn
        //    uiTest.ClickCSS(".sidebar-pin-btn");
        //    //uiTest.WaitToSee(What.Contains, "Scope");
        //    //Thread.Sleep(4000);
        //} 
        //public static void UnpinSidebar(UITest uiTest)
        //{
        //    //uiTest.Expect(What.Contains, "Deliver");

        //    // Pin btn
        //    uiTest.ClickCSS(".sidebar-pin-btn");
        //    //uiTest.WaitToSeeNo(What.Contains, "Scope");
        //    //Thread.Sleep(4000);

        //}
        #endregion



        public static void AddStakeholder(UITest uiTest, string stakeholderName,
            string department = "department01", string role = "role01",
            string email = "email01@yahoo.com", string tel = "tel01",
            string sponsor = "Sponsor")
        {
            uiTest.ClickXPath("//a[@name='Stakeholder']");
            uiTest.WaitToSeeHeader("Add Stakeholder");

            uiTest.Set(That.Contains, "Name").To(stakeholderName);
            uiTest.Set(That.Contains, "Department").To(department);
            uiTest.Set(That.Contains, "Role").To(role);
            uiTest.Set(That.Contains, "Email").To(email);
            uiTest.Set(That.Contains, "Tel").To(tel);
            uiTest.ClickLabel(That.Contains, sponsor);
            uiTest.Click("Save");
            Thread.Sleep(2000);
            uiTest.ExpectXPath($"//tr[last()]//*[{XPathText(Casing.Exact, stakeholderName)}]");
            uiTest.ExpectXPath($"//tr[last()]//*[{XPathText(Casing.Exact, department)}]");
            uiTest.ExpectXPath($"//tr[last()]//*[{XPathText(Casing.Exact, role)}]");
            uiTest.ExpectXPath($"//tr[last()]//*[{XPathText(Casing.Exact, email)}]");
            uiTest.ExpectXPath($"//tr[last()]//*[{XPathText(Casing.Exact, tel)}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="rowIndex"> -1 value means last row</param>
        public static void DeleteStakeholder(UITest uiTest, int rowIndex = -1)
        {
            var idx = rowIndex == -1 ? "last()" : rowIndex.ToString();

            uiTest.ClickXPath($"//tr[{idx}]//a[@name='Edit']");
            uiTest.WaitToSeeHeader(That.Contains, "Stakeholder Details");
            uiTest.Click("Delete");
            uiTest.WaitToSee("Are you sure you want to delete this Stakeholder?");
            uiTest.Click("OK");
        }

        public static void UpdateFile(string fullPath, string[] newText)
        {
            // An array of strings
            //string[] authors = {"Mahesh Chand", "Allen O'Neill", "David McCarter",

            // Write array of strings to a file using WriteAllLines.
            // If the file does not exists, it will create a new file.
            // This method automatically opens the file, writes to it, and closes file
            File.WriteAllLines(fullPath, newText);

            //// Read a file
            //string readText = File.ReadAllText(fullPath);
            //Console.WriteLine(readText);
        }
        //public static string ReadFile_FirstLine(string fullPath)
        public static string ReadFile_FirstLine(string folderPath, string fileName, bool createFileIsNotExist)
        {
            string fullPath = folderPath + "/" + fileName;


            // Create a file if don't exist
            if (createFileIsNotExist)
            {
                if (!File.Exists(fullPath))
                {
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    File.WriteAllLines(fullPath, new string[] { "0" });
                }
            }


            //string readText = File.ReadLines(fullPath).First();
            string readText = ReadFileLine(lineNumber: 0, fullPath);
            return readText;
        }

        public static string ReadFileLine(int lineNumber, string fullPath)
        {
            //string readText = File.ReadAllText(fullPath);
            ////string readText = File.ReadLines(fullPath).First();
            var lines = File.ReadLines(fullPath);

            return lines.ElementAt(lineNumber);
        }

        #region Opens
        #region Open Plan Sections
        public static void OpenPlanStakeholders(UITest uiTest)
        {
            uiTest.ClickXPath($"//li[1]//*[{XPathText(Casing.Exact, "Stakeholders")}]");
            uiTest.WaitToSee("Email");
            uiTest.Expect("Stakeholders");
        }
        public static void OpenPlanDomainExpertise(UITest uiTest)
        {
            uiTest.ClickXPath($"//li[2]//*[{XPathText(Casing.Exact, "Domain Expertise")}]");
            uiTest.WaitToSee("Usecase allocations");
        }
        public static void OpenPlanActivities(UITest uiTest)
        {
            uiTest.ClickXPath($"//li[3]//*[{XPathText(Casing.Exact, "Activities")}]");
            uiTest.WaitToSee("Attendee(s)");
        }
        public static void OpenPlanSchedule(UITest uiTest)
        {
            uiTest.ClickXPath($"//li[4]//*[{XPathText(Casing.Exact, "Schedule")}]");
            uiTest.WaitToSeeHeader("Schedule");
        }
        #endregion

        public const string scopeSidebarIcon_XPath = "//li[@id='menuItem_Scope']/a[@href='#menuItem_Scope']";
        public static string scope_features_Sign_XPath = $"//th[{XPathText(Casing.Exact, "Devices")}]";
        public static void OpenFeatures(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            uiTest.ClickXPath($"//li[2]//span[{XPathTextContains(Casing.Exact, "Scope")}]");
            uiTest.WaitToSeeXPath($"//li[2]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Features")}]");
            uiTest.ClickXPath($"//li[2]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Features")}]");


            //uiTest.WaitToSee(What.Contains, "Applications"); 
            uiTest.WaitToSeeXPath(scope_features_Sign_XPath);
            uiTest.ClickXPath(scope_features_Sign_XPath);
        }

        public static string estimator_Sign_XPath = $"//th[{XPathText(Casing.Exact, "UI Design Implementation")}]";
        public static void OpenEstimator(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Deliver
            uiTest.ClickXPath($"//li[6]//span[{XPathTextContains(Casing.Exact, "Deliver")}]");
            uiTest.WaitToSeeXPath($"//li[6]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Estimate")}]");
            uiTest.ClickXPath($"//li[6]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Estimate")}]");

            uiTest.WaitToSeeXPath(estimator_Sign_XPath);
            uiTest.ClickXPath(estimator_Sign_XPath);
            //Thread.Sleep(2000);
        }
        public static string scope_Estimate_Sign_XPath = U.headerContains_XPath("Solution Design Activities",Casing.Exact);
        public static void OpenEstimate(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Scope
            uiTest.ClickXPath($"//li[2]//span[{XPathTextContains(Casing.Exact, "Scope")}]");
            uiTest.WaitToSeeXPath($"//li[2]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Estimate")}]");
            uiTest.ClickXPath($"//li[2]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Estimate")}]");

            uiTest.WaitToSeeXPath(scope_Estimate_Sign_XPath);
            uiTest.ClickXPath(scope_Estimate_Sign_XPath);
            //Thread.Sleep(2000);
        }
        public static string northstar_Sign_XPath = U.headerContains_XPath("Supporting Info", Casing.Exact);
        public static void OpenNorthstar(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Plan
            uiTest.ClickXPath($"//li[3]//span[{XPathTextContains(Casing.Exact, "Plan")}]");
            uiTest.WaitToSeeXPath($"//li[3]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Northstar")}]");
            uiTest.ClickXPath($"//li[3]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Northstar")}]");


            uiTest.WaitToSeeXPath(northstar_Sign_XPath);
            uiTest.ClickXPath(northstar_Sign_XPath);
            //Thread.Sleep(2000);
        }
        public static string personas_Sign_XPath = "//form[@data-module='Personas_MainCanvas_List']";
        public static void OpenPersonas(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Spec
            uiTest.ClickXPath($"//li[4]//span[{XPathTextContains(Casing.Exact, "Spec")}]");
            uiTest.WaitToSeeXPath($"//li[4]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Personas")}]");
            uiTest.ClickXPath($"//li[4]//ul//li[2]//a[{XPathTextContains(Casing.Exact, "Personas")}]");


            //uiTest.WaitToSeeXPath("//div[@class='personas-title'][text()='Personas']");
            uiTest.WaitToSeeXPath(personas_Sign_XPath);
            uiTest.ClickXPath(personas_Sign_XPath);
            //Thread.Sleep(2000);
        }

        public static string plan_Sign_XPath = U.header_XPath("Stakeholders", Casing.Exact);
        public static void OpenPlan(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Plan
            uiTest.ClickXPath($"//li[3]//span[{XPathTextContains(Casing.Exact, "Plan")}]");
            uiTest.WaitToSeeXPath($"//li[3]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Project Plan")}]");
            uiTest.ClickXPath($"//li[3]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Project Plan")}]");


            //uiTest.WaitToSeeHeader("Stakeholders");
            //uiTest.ClickHeader("Stakeholders");
            uiTest.WaitToSeeXPath(plan_Sign_XPath);
            uiTest.ClickXPath(plan_Sign_XPath);

            ////uiTest.Expect("Email");
            //Thread.Sleep(2000);
        }

        public static string userJourneys_Sign_XPath = $"//a[{U.XPathText(Casing.Exact, "User Story")}]";
        public static void OpenUserstories(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            uiTest.ClickXPath($"//li[4]//span[{XPathTextContains(Casing.Exact, "Spec")}]");
            uiTest.WaitToSeeXPath($"//li[4]//ul//li//a[{XPathTextContains(Casing.Exact, "User Journeys")}]");
            uiTest.ClickXPath($"//li[4]//ul//li//a[{XPathTextContains(Casing.Exact, "User Journeys")}]");


            //uiTest.WaitToSeeXPath($"//form[@data-module='UserStoryList']//*[{XPathText(Casing.Exact, "User Journeys")}]");

            uiTest.WaitToSeeXPath(userJourneys_Sign_XPath);
            uiTest.ClickXPath(userJourneys_Sign_XPath);
            //Thread.Sleep(2000);
        }

        public static string workflow_Sign_XPath = U.header_XPath("Workflow Models", Casing.Ignore);
        public static void OpenWorkflow(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            uiTest.ClickXPath($"//li[4]//span[{XPathTextContains(Casing.Exact, "Spec")}]");
            uiTest.WaitToSeeXPath($"//li[4]//ul//li[3]//a[{XPathTextContains(Casing.Exact, "Workflow Models")}]");
            uiTest.ClickXPath($"//li[4]//ul//li[3]//a[{XPathTextContains(Casing.Exact, "Workflow Models")}]");



            uiTest.ClickXPath("//div[@class='right-panel']");
            uiTest.WaitToSeeXPath(workflow_Sign_XPath);
            uiTest.ClickXPath(workflow_Sign_XPath);
            //Thread.Sleep(2000);
        }

        public static string Objectmap_Sign_XPath = U.btnAddObjXPath;
        public static void OpenObjectmap(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            uiTest.ClickXPath($"//li[4]//span[{XPathTextContains(Casing.Exact, "Spec")}]");
            uiTest.WaitToSeeXPath($"//li[4]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Object Map")}]");
            uiTest.ClickXPath($"//li[4]//ul//li[1]//a[{XPathTextContains(Casing.Exact, "Object Map")}]");


            //uiTest.WaitToSeeLink("Object Details");
            //uiTest.ClickLink("Object Details");
            uiTest.WaitToSeeXPath(Objectmap_Sign_XPath);
            uiTest.ClickXPath(Objectmap_Sign_XPath);
            // To close it
            uiTest.ClickXPath(Objectmap_Sign_XPath);
            //Thread.Sleep(2000);

            //WebDriverWait w = new WebDriverWait(uiTest.WebDriver, TimeSpan.FromSeconds(100));
            //w.Until(ExpectedConditions
            //        .PresenceOfAllElementsLocatedBy(By.XPath(U.btnAddObjXPath)));
            //var x = uiTest.WebDriver.FindElements(By.XPath(U.btnAddObjXPath)).ElementAt(0);
            //x.Click();
            //// To close it
            //x.Click();
        }

        public static string checkpoints_Sign_XPath = $"//th[{XPathText(Casing.Exact, "Last Modified Date")}]";
        public static void OpenCheckpoints(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            // Hi <username>
            uiTest.ClickXPath($"//a[{XPathAttributeContains("id", "dropdownUser")}]/img");
            uiTest.WaitToSeeXPath($"//li[2]//a[{XPathTextContains(Casing.Exact, "Checkpoints")}]");
            uiTest.ClickXPath($"//li[2]//a[{XPathTextContains(Casing.Exact, "Checkpoints")}]");


            //uiTest.WaitToSeeHeader("Checkpoints");
            //uiTest.ClickHeader("Checkpoints");
            uiTest.WaitToSeeXPath(checkpoints_Sign_XPath);
            uiTest.ClickXPath(checkpoints_Sign_XPath);
            //Thread.Sleep(2000);
        }

        public static string cognitive_Sign_XPath = U.headerContains_XPath("Cognitive Walkthroughs", Casing.Exact);
        public static void OpenCognitive(UITest uiTest)
        {
            uiTest.ClickXPath(scopeSidebarIcon_XPath);

            uiTest.ClickXPath($"//li[5]//span[{XPathTextContains(Casing.Exact, "Test")}]");
            uiTest.ExpectXPath($"//li[5]//ul/li//a[{XPathTextContains(Casing.Exact, "Cognitive Walkthroughs")}]");
            uiTest.ClickXPath($"//li[5]//ul/li//a[{XPathTextContains(Casing.Exact, "Cognitive Walkthroughs")}]");


            uiTest.ClickXPath("//div[@class='right-panel']");
            uiTest.WaitToSeeXPath(cognitive_Sign_XPath);
            uiTest.ClickXPath(cognitive_Sign_XPath);
            //Thread.Sleep(2000);
        }

        public static void OpenWireframes(UITest uiTest)
        {
            ////uiTest.ClickXPath(scopeSidebarIconXPath);

            ////// Spec
            ////uiTest.ClickXPath($"//li[3]//span[text()='Spec ']");
            ////uiTest.ExpectXPath($"//li[3]//a[4]//span[text()='Wireframes']");
            ////uiTest.ClickXPath($"//li[3]//a[4]//span[text()='Wireframes']");


            ////Thread.Sleep(5000);
            ////uiTest.SwitchToTab($"\r\n\t{TestProjectName} » Admin_A Web App_Wide screen");


            GoToWireframes(uiTest);
            uiTest.WaitToSeeLink("ScreenPath");
            uiTest.ExpectLink("Outline");
        }
        #endregion


        public static void CreateProject(UITest uiTest)
        {
            uiTest.Click("My Projects");
            uiTest.WaitForNewPage();
            //uiTest.WaitToSeeLink("New Project");
            //Thread.Sleep(3000);



            //ScrollToTop_Website(uiTest);
            uiTest.ClickButton("New Project");
            U.WaitToSeePopup_ProjectDetails(uiTest);
            uiTest.Set(That.Contains, "Name").To(TestProjectName);
            uiTest.Set(That.Contains, "Description").To("Description01");

            uiTest.ClickLink("Save");
            uiTest.Expect(What.Contains, TestProjectName);
        }
        public static void WaitToSeePopup_ProjectDetails(UITest uiTest)
        {
            uiTest.AtXPath(Shared.Admin.Website.MyProjects.C.formProjectDetail + "//h2").WaitToSee(What.Contains, "Project");
            uiTest.AtXPath(Shared.Admin.Website.MyProjects.C.formProjectDetail + "//h2").Expect(What.Contains, "Details");
        }

        public static void OpenProject(UITest uiTest)
        {
            SearchProject(uiTest);
            Thread.Sleep(2000);

            // Open btn
            //ClickXPath("//tr[1]/td[1]/span[@class='list-item-wrapper']/div[@class='item item-right launch']/a[@href='javascript:']");
            uiTest.AtXPath("//tr[1]//div[2]").ClickLink("Open");

            //int delay = environment == Environment.Local ? 7000 : 10000;
            int delay = 15000;
            Thread.Sleep(delay);
            uiTest.SwitchToTab(TitleScopeFeatures);
            //uiTest.Expect(What.Contains, "Applications");
            uiTest.WaitToSeeXPath($"//th[{XPathText(Casing.Exact, "Devices")}]");
            uiTest.ClickXPath($"//th[{XPathText(Casing.Exact, "Devices")}]");

            //Run<PinSidebar>();
            //PinSidebar(this);
        }

        public static void SearchProject(UITest uiTest)
        {
            //uiTest.SetXPath("//input[@placeholder='Enter project name or user name']").To(TestProjectName);
            uiTest.SetXPath("//input[@id='Main_ctl00_txtKeywordSearch']").To(TestProjectName);
            uiTest.ClickXPath("//input[@value='Search']");
            //uiTest.ClickLink("Search");
            uiTest.ExpectXPath($"//tr[1]//*[{XPathTextContains(Casing.Exact, TestProjectName)}]");
        }

        public static void OpenProjectDetails(UITest uiTest, int rowIdx)
        {
            uiTest.ClickXPath(btnEditProjectXPath(rowIdx));
            //uiTest.WaitToSee("Project Details");
            U.WaitToSeePopup_ProjectDetails(uiTest);
        }

        public static void GoToLandingPage(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Home.html");
        }

        public static void GoToWireframes(UITest uiTest)
        {
            uiTest.Goto($"http://design.{WebsiteDomain}/?p={TestProjectName}&user=1&S26_2=27");
            //uiTest.Goto($"http://design.{WebsiteDomain}/?p={TestProjectName}&user=1&S26_2=27");
            //$"https://{WebsiteDomain}/DesignerOpenPage.aspx?projectKey={TestProjectName}&projectId=290cc4e4-db73-4637-8f41-143f31876873"
        }

        public static void LoginAdmin(UITest uiTest, bool isFirstTime = false)
        {
            // Open a new brwoser and switch focus on it
            //this.WebDriver.SwitchTo().NewWindow(WindowType.Window);
            //Thread.Sleep(3000);

            GoToLandingPage(uiTest);
            //Thread.Sleep(5000);



            //Logout();
            if (isFirstTime)
                uiTest.ClickLink("Accept");

            //GotoLoginPage(uiTest);
            uiTest.Click("Login");
            uiTest.WaitForNewPage();


            uiTest.Set("Email").To(AdminEmail);
            uiTest.Set("Password").To(AdminPassword);
            //ClickXPath("//a[@id='Main_ctl01_btnLogin']");
            uiTest.Below("Forgot Password?").Click("Login");

            //////WaitToSee("Logout");
            ////WaitForNewPage();
            //////Expect("New Project");
            uiTest.WaitToSee("Logout");
            uiTest.Expect("Admin");

            //Thread.Sleep(3000);

            uiTest.Expect("New Project");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="labelXPath"></param>
        /// <param name="to"></param>
        public static void SetField(UITest uiTest, string labelXPath, string to)
        {
            uiTest.SetXPath($"{labelXPath}/following-sibling::div/input").To(to);
        }
        /// <summary>
        /// Expect an input that has a specific value and is the following sibling of second method parameter
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="labelXPath">should be sibling of input and before input</param>
        /// <param name="value"></param>
        public static void ExpectField(UITest uiTest, string labelXPath, string value)
        {
            uiTest.ExpectXPath($"{labelXPath}/following-sibling::div/input[@value='{value}']");
        }

        public static string GetHtmlElementAttribute(UITest uiTest, string XPath, string attributeName)
        {
            string ret = uiTest.WebDriver.FindElement(By.XPath(XPath)).GetAttribute(attributeName);
            return ret;
        }

        /// <summary>
        /// Scroll to bottom of page
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="scorllableElement">value of data-scrollbar-name attribute</param>
        public static void ScrollToBottom(UITest uiTest, string scorllableElement)
        {
            //this.WebDriver.ExecuteJavaScript($"window[`scrolls.{scorllableElement}`].scrollTo(0,100,0);");
            uiTest.WebDriver.ExecuteJavaScript(GetJS_ScrollToBottom(scorllableElement));
        }
        /// <summary>
        /// Get javascript script to scroll to bottom of page
        /// </summary>
        /// <param name="scorllableElement">value of data-scrollbar-name attribute</param>
        public static string GetJS_ScrollToBottom(string scorllableElement)
        {
            return $"window[`scrolls.{scorllableElement}`].scrollTo(0,document.body.scrollHeight,0);";
        }


        /// <summary>
        /// Scroll to a Y
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="scorllableElement">value of data-scrollbar-name attribute</param>
        public static void ScrollTo(UITest uiTest, string scorllableElement, int Y)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window[`scrolls.{scorllableElement}`].scrollTo(0,{Y},0);");
        }
        /// <param name="scorllableElement">value of data-scrollbar-name attribute</param>
        public static void ScrollToTop(UITest uiTest, string scorllableElement)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window[`scrolls.{scorllableElement}`].scrollTo(0,0,0);");
        }

        public static void ScrollTo_Website(UITest uiTest, int Y)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,{Y});");
        }
        /// <summary>
        /// Scrolls vertically to an HTML element by its XPath
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="Y"></param>
        public static void ScrollToElementXPath_Website(UITest uiTest, string XPath, HtmlElementProp elementSide = HtmlElementProp.Top)
        {
            string elementPosition = GetHTMLElementPropJSVal_ByXPath(XPath, elementSide);
            uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,{elementPosition});");
        }
        /// <summary>
        /// Scrolls vertically to an HTML element by its XPath
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="Y"></param>
        /// <param name="scorllableElement">value of data-scrollbar-name attribute</param>
        public static void ScrollToElementXPath(UITest uiTest, string scorllableElement, string XPath, HtmlElementProp elementSide = HtmlElementProp.Top)
        {
            string elementPosition = GetHTMLElementPropJSVal_ByXPath(XPath, elementSide);
            //uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,{elementPosition});");
            uiTest.WebDriver.ExecuteJavaScript($"window[`scrolls.{scorllableElement}`].scrollTo(0,{elementPosition},0);");

        }

        /// <summary>
        /// Scrolls to the element with given css vertically and horizontally
        /// </summary>
        /// <param name="uITest"></param>
        public static void ScrollToElementCSS(UITest uiTest, string css)
        {
            uiTest.WebDriver.ExecuteJavaScript($"document.querySelector('{css}').scrollIntoView();");
        }

        /// <summary>
        /// Finds HTML element by its XPath, then return one of the properties of getBoundingClientRect() related to the element. 
        /// properties are left, top, right, bottom, x, y, width, height
        /// </summary>
        /// <param name="XPath"></param>
        /// <param name="elementSide"></param>
        /// <returns></returns>
        public static string GetHTMLElementPropJSVal_ByXPath(string XPath, HtmlElementProp elementSide)
        {
            string elementPropJS = "";
            switch (elementSide)
            {
                case HtmlElementProp.Top:
                    elementPropJS = "top";
                    break;
                case HtmlElementProp.Bottom:
                    elementPropJS = "bottom";
                    break;
                case HtmlElementProp.Right:
                    elementPropJS = "right";
                    break;
                case HtmlElementProp.Left:
                    elementPropJS = "left";
                    break;
                case HtmlElementProp.Height:
                    elementPropJS = "height";
                    break;
                case HtmlElementProp.Width:
                    elementPropJS = "width";
                    break;
                case HtmlElementProp.X:
                    elementPropJS = "x";
                    break;
                case HtmlElementProp.Y:
                    elementPropJS = "y";
                    break;
            }
            return $"document.evaluate(\"{XPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.getBoundingClientRect().{elementPropJS}";
        }
        public static void ScrollDownOnePage_Website(UITest uiTest, int Y)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,document.documentElement.clientHeight);");
        }

        public static void ScrollToBottom_Website(UITest uiTest)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,document.body.scrollHeight);");
        }
        public static void ScrollToTop_Website(UITest uiTest, IWebDriver webDriver)
        {
            uiTest.WebDriver.ExecuteJavaScript($"window.scrollTo(0,0);");
        }

        public static void ScanPages(UITest uiTest, bool isFirstProjectLoad)
        {
            if (isFirstProjectLoad)
            {
                //uiTest.WebDriver.SwitchTo().NewWindow(WindowType.Tab);
                //Goto("https://live-visualspec.on.uat.co/Home.html");
                OpenWireframes(uiTest);
                Thread.Sleep(3000);
                //uiTest.CloseTab($"{MyUtils.TestProjectName} » Admin_A Web App_Wide screen");
                uiTest.SwitchToTab(TitleScopeFeatures);



                OpenEstimator(uiTest);
                Thread.Sleep(2000);
            }

            uiTest.Click("Scan pages");
            uiTest.WaitToSee(What.Contains, "pages were scanned, Please press the search button");
            uiTest.ExpectNo(What.Contains, "0 pages were scanned, Please press the search button");
            uiTest.Click("OK");

            if (isFirstProjectLoad)
            {
                uiTest.ExpectRow("Admin");
            }
        }

        /// <summary>
        /// returns valued returned after execution of js code
        /// </summary>
        /// <param name="uiTest"></param>
        /// <param name="js">js script like: window.innerHeight</param>
        /// <returns></returns>
        public static string ExecuteJS_ReturnValue(UITest uiTest, string js)
        {
            var jsExecutor = (IJavaScriptExecutor)uiTest.WebDriver;
            var ret = Convert.ToInt64(jsExecutor.ExecuteScript($"return {js}")).ToString();
            return ret;
        }

        public static int GetViewPortHeight(UITest uiTest)
        {
            var h = U.ExecuteJS_ReturnValue(uiTest, "window.innerHeight");
            return Convert.ToInt32(h);
        }

        public static void CheckWebsiteUI_Header_BeforeLogin(UITest uiTest)
        {
            uiTest.ExpectXPath($"//li[1]//a[{XPathText(Casing.Exact, "Register")}]");
            uiTest.ExpectXPath($"//li[2]//a[{XPathText(Casing.Exact, "Login")}]");
            uiTest.ExpectXPath($"//li[3]//a[{XPathText(Casing.Exact, "Live Demo")}]");
        }
        public static void CheckWebsiteUI_Header_AfterLogin(UITest uiTest)
        {
            uiTest.ExpectXPath($"//li[1]//a[{XPathText(Casing.Exact, "My Projects")}]");
            uiTest.ExpectXPath($"//li[2]//a[{XPathText(Casing.Exact, "Profile")}]");
            uiTest.ExpectXPath($"//li[3]//a[{XPathText(Casing.Exact, "Admin")}]");
            uiTest.ExpectXPath($"//li[4]//a[{XPathText(Casing.Exact, "BA")}]");
            uiTest.ExpectXPath($"//li[5]//a[{XPathText(Casing.Exact, "Logout")}]");
            uiTest.ExpectXPath($"//li[6]//a[{XPathText(Casing.Exact, "Live Demo")}]");
        }
        public static void CheckWebsiteUI_Footer(UITest uiTest)
        {
            uiTest.ExpectXPath($"//li[1]//a[{XPathText(Casing.Exact, "Terms & conditions")}]");
            uiTest.ExpectXPath($"//li[2]//a[{XPathText(Casing.Exact, "Privacy policy")}]");
            uiTest.ExpectXPath($"//li[3]//a[{XPathText(Casing.Exact, "Contact us")}]");


            uiTest.Expect(What.Contains, "Software Development by");
            uiTest.ExpectLink("GEEKS LTD.");
            uiTest.Expect(What.Contains, "- © 2022. All rights reserved.");

            uiTest.ExpectXPath($"//li[1]//img[@src='/Images/clients/digitalexperience.png'][@alt='digital experience']");
            uiTest.ExpectXPath($"//li[2]//img[@src='/Images/clients/nationalbusiness.png'][@alt='national business']");
            uiTest.ExpectXPath($"//li[3]//img[@src='/Images/clients/stevie-winner.png'][@alt='stevie winner']");
            uiTest.ExpectXPath($"//li[4]//img[@src='/Images/clients/amazon.png'][@alt='amazon']");
            uiTest.ExpectXPath($"//li[5]//img[@src='/Images/clients/queensaward.png'][@alt='queen saward']");
            uiTest.ExpectXPath($"//li[6]//img[@src='/Images/clients/londonbusiness.png'][@alt='london business']");
            uiTest.ExpectXPath($"//li[7]//img[@src='/Images/clients/bestbusiness.png'][@alt='best business']");
        }

        public static void CheckContactUsUI(UITest uiTest)
        {
            uiTest.ExpectXPath($"//h1[{U.XPathTextContains(Casing.Exact, "Contact")}]");
            uiTest.Expect("Us", Casing.Exact);
            uiTest.Expect(What.Contains, "VisualSpec is created by Geeks. For more information please visit", Casing.Exact);
            uiTest.ExpectLink("www.geeks.ltd", Casing.Exact);



            uiTest.Expect(What.Contains, "6 Sutton Park Rd", Casing.Exact);
            uiTest.Expect(What.Contains, "Sutton", Casing.Exact);
            uiTest.Expect(What.Contains, "London", Casing.Exact);
            uiTest.Expect(What.Contains, "SM1 2GD", Casing.Exact);



            uiTest.Expect(What.Contains, "Telephone:", Casing.Exact);
            uiTest.Expect(What.Contains, "+44 (0) 203 507 0033", Casing.Exact);

            uiTest.Expect(What.Contains, "Email:", Casing.Exact);
            uiTest.Expect(What.Contains, "visualspec@geeks.ltd.uk", Casing.Exact);

            uiTest.ExpectXPath("//img[@src='/Images/svg/geeks.svg']");


            uiTest.Expect(What.Contains, "Get in", Casing.Exact);
            uiTest.Expect(What.Contains, "touch", Casing.Exact);

            uiTest.ExpectLabel("Subject", Casing.Exact);
            uiTest.ExpectLabel(That.Contains, "Your name", Casing.Exact);
            uiTest.ExpectLabel(That.Contains, "Email", Casing.Exact);
            uiTest.ExpectLabel("Telephone", Casing.Exact);
            uiTest.ExpectLabel("Company", Casing.Exact);

            //MyUtils.ScrollToBottom_Website(this);
            uiTest.ExpectLabel("Note", Casing.Exact);
            uiTest.ExpectButton("Send", Casing.Exact);


            uiTest.ExpectXPath("//option[text()='Select'][@selected='selected']");
        }

        public static void GotoConatctUs(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Contact.html");
            uiTest.WaitToSee(What.Contains, "VisualSpec is created by Geeks. For more information please visit");
        }
        public static void GotoPrivacyPolicy(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Privacy.html");
        }
        public static void GotoTermAndConitions(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Terms.html");
        }
        public static void GotoTermsOfUse(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Terms-of-use.aspx");
        }
        public static void GotoThanksPage(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Join/register/thanks.aspx");
        }
        public static void GotoErrorPage(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Error.aspx");
        }
        public static void GotoLoginPage(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Join.aspx?ReturnUrl=%2fJoin.aspx");
        }
        public static void GotoRegisterPage(UITest uiTest)
        {
            uiTest.Goto($"http://{WebsiteDomain}/Join/Register.aspx?Email=&ReturnUrl=%2fJoin.aspx");
        }

        public static void OpenContactUs(UITest uiTest)
        {
            GoToLandingPage(uiTest);
            uiTest.ClickLink("Accept");

            ScrollToBottom_Website(uiTest);
            uiTest.ClickLink("Contact us");

            uiTest.WaitToSee(What.Contains, "VisualSpec is created by Geeks. For more information please visit");
        }

        public static void AppProperty_ObjectMap(UITest uiTest, string objectName, string propertyName, string propertyType, bool isList)
        {
            uiTest.ClickXPath($"//span[{XPathText(Casing.Exact, objectName)}]");
            Thread.Sleep(3000);
            //MyUtils.ScrollToBottom(this, "objectmap-content", this.WebDriver);
            // Scroll to bottom
            //this.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom("objectmap-content"));
            ScrollToBottom(uiTest, "objectmap-content");

            uiTest.ClickLink("Properties");
            Thread.Sleep(2000);

            uiTest.ClickButton("Property");
            Thread.Sleep(2000);

            uiTest.Set("Name").To(propertyName);
            //uiTest.ClickButton("---Select---");
            U.OpenDropdown(uiTest, "---Select---");
            uiTest.NearButton("---Select---").ClickLink(propertyType);

            uiTest.ClickHeader("Property Details");

            if (isList)
                uiTest.ClickLabel("Is list");

            ScrollToBottom(uiTest, "objectmap-content");
            uiTest.ClickButton("Save");
            Thread.Sleep(3000);
            ScrollToBottom(uiTest, "objectmap-content");
            uiTest.ExpectXPath($"//td[text()='{propertyName}']");


            ScrollToTop(uiTest, "objectmap-content");
            var pType = isList ? $"List<{propertyType}>" : propertyType;
            uiTest.NearXPath($"//span[{XPathText(Casing.Exact, objectName)}]").Expect($"+{pType} {propertyName}");
        }

        public static void AddExistingObject_ObjectMap(UITest uiTest, bool allPropertyTypes)
        {
            uiTest.NearButton("A Web App").ClickLink("Everything");
            uiTest.WaitToSeeHeader($"A Web App: Everything");

            // Add button
            uiTest.ClickXPath(U.btnAddObjXPath);
            uiTest.ClickButton(That.Contains, "Existing Object");
            uiTest.Expect("First, one of the features must be selected.");

            uiTest.ClickLink(U.feature01);
            uiTest.WaitToSeeHeader(U.feature01);

            uiTest.ClickXPath(U.btnAddObjXPath);
            uiTest.ClickLink(That.Contains, "Existing Object");



            uiTest.WaitToSeeHeader("Add Existing Object");
            string addExistingObjFormXPath = "//form[@data-module='ExistingObjectForm']";

            //SetXPath($"{addObjFormXPath}//*[{MyUtils.XPathTextContains(Casing.Exact, "Name")}]").To(Constants.O1F1);
            ////U.SetField(this, labelXPath: $"{addObjFormXPath}//*[{U.XPathTextContains(Casing.Exact, "Name")}]"
            ////    , to: Constants.O1F1);
            //uiTest.AtXPath(addExistingObjFormXPath).ClickButton("---Select---");
            string btnExistingObjDropdown = "---Select---";
            U.OpenDropdown(uiTest, btnExistingObjDropdown, addExistingObjFormXPath);
            uiTest.NearButton(btnExistingObjDropdown).ClickLink(Shared.Admin.ObjectMap.C.O1F1);
            uiTest.ClickHeader("Add Existing Object");

            //uiTest.AtXPath(addExistingObjFormXPath).ClickButton("Nothing selected");
            OpenDropdown(uiTest, "Nothing selected", addExistingObjFormXPath);
            for (int i = 0; i < (allPropertyTypes ? Shared.Admin.ObjectMap.C.propTypes.Length : 1); i++)
            {
                uiTest.NearXPath(addExistingObjFormXPath).ClickLink($"P{i + 1}{Shared.Admin.ObjectMap.C.O1F1}");
            }
            for (int i = 0; i < (allPropertyTypes ? Shared.Admin.ObjectMap.C.propTypesList.Length : 0); i++)
            {
                uiTest.NearXPath(addExistingObjFormXPath).ClickLink($"P{i + 1 + Shared.Admin.ObjectMap.C.propTypes.Length}{Shared.Admin.ObjectMap.C.O1F1}");
            }

            uiTest.ClickHeader("Add Existing Object");
            uiTest.ClickXPath($"{addExistingObjFormXPath}//*[{U.XPathText(Casing.Exact, "Save")}]");
            Thread.Sleep(3000);
            uiTest.ExpectXPath($"//span[{U.XPathText(Casing.Exact, $"{Shared.Admin.ObjectMap.C.O1F1}_Clone")}]");
            for (int i = 0; i < (allPropertyTypes ? Shared.Admin.ObjectMap.C.propTypes.Length : 1); i++)
            {
                uiTest.NearXPath($"//span[{U.XPathText(Casing.Exact, $"{Shared.Admin.ObjectMap.C.O1F1}_Clone")}]")
                    .Expect($"+{Shared.Admin.ObjectMap.C.propTypes[i]} P{i + 1}{Shared.Admin.ObjectMap.C.O1F1}");
            }
            for (int i = 0; i < (allPropertyTypes ? Shared.Admin.ObjectMap.C.propTypesList.Length : 0); i++)
            {
                uiTest.NearXPath($"//span[{U.XPathText(Casing.Exact, $"{Shared.Admin.ObjectMap.C.O1F1}_Clone")}]")
                    .Expect($"+{Shared.Admin.ObjectMap.C.propTypesList[i]} P{i + 1 + Shared.Admin.ObjectMap.C.propTypes.Length}{Shared.Admin.ObjectMap.C.O1F1}");
            }
        }

        public static int GetActorColumnIdx_Workflow(UITest uiTest, string actorName)
        {
            int idx = -1;

            // Search for the actor name in first 10 coulmns
            for (int i = 1; i <= 10; i++)
            {
                bool elementExists = uiTest.WebDriver
                    .FindElements(By.XPath($"//th[{i}][text()='{U.DefaultActorsDic[U.DefaultActors.Admin]}']")).Any();

                if (elementExists)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        public static string GetNodeId_Workflow(UITest uiTest, int actorColumnIdx, string nodeName, NodeType nodeType)
        {
            string id = "-1";

            string nodeCssClass = "";
            switch (nodeType)
            {
                case NodeType.Start:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_StartNode;
                    break;
                case NodeType.Step:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_StepNode;
                    break;
                case NodeType.End:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_EndNode;
                    break;
                case NodeType.Decision:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_DecisionNode;
                    break;
                case NodeType.Loop:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_LoopNode;
                    break;
                case NodeType.Artifact:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_ArtifactNode;
                    break;
                case NodeType.Start_LoopTarget:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_StartNode_LoopTarget;
                    break;
                case NodeType.Step_LoopTarget:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_StepNode_LoopTarget;
                    break;
                case NodeType.Decision_LoopTarget:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_DecisionNode_LoopTarget;
                    break;
                case NodeType.Artifact_LoopTarget:
                    nodeCssClass = Shared.Admin.Workflow.C.cssClass_ArtifactNode_LoopTarget;
                    break;
            }


            string parentNodeXPath =
                $"//td[{actorColumnIdx}]//div[{U.XPathAttributeContains("class", nodeCssClass)}]//*[{U.XPathTextContains(Casing.Exact, nodeName)}]/{U.parent_XPath}::div";

            id = uiTest.WebDriver.FindElements(By.XPath(parentNodeXPath)).FirstOrDefault().GetAttribute("id");
            // remove "node_" 
            id = id.Substring(5);

            return id;
        }

        public static void AddUsecases(UITest uiTest, string[] features, string[] usecases)
        {
            // add features
            foreach (var feature in features)
            {
                U.AddFeature(uiTest, feature);
                Thread.Sleep(500);
            }


            // add usecases
            for (int i = 0; i < features.Length; i++)
            {
                ScrollToFeature(uiTest, i, features);
                Thread.Sleep(3000);

                int usecaseIdx_assignedToThisFeature = 0;
                foreach (var usecase in usecases)
                {
                    // extract feature 
                    var featureNameInUsecaseName = usecase.Split(' ')[0];
                    if (featureNameInUsecaseName == features[i])
                    {
                        usecaseIdx_assignedToThisFeature++;

                        U.AddUsecase(uiTest, features[i], usecase
                            , U.DefaultActors.Admin
                            , new Tuple<U.Estimate, U.Estimate>(U.Estimate.XS, U.Estimate.M)
                            , unselectIfSelected: usecaseIdx_assignedToThisFeature > 1 ? false : true);
                        Thread.Sleep(500);
                        ScrollToFeature(uiTest, i, features);
                        uiTest.Expect(usecase);
                    }
                }
            }
        }

        public static void ScrollToFeature(UITest uiTest, int featureIdx, string[] features)
        {
            // Scroll to bottom
            if (featureIdx == 0)
                uiTest.WebDriver.ExecuteJavaScript(U.GetJS_ScrollToBottom(Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView));
            else
                // Scroll to the feature above the current feature
                U.ScrollToElementXPath(uiTest, Shared.Admin.Scope.Features.C.scrollable_scopeFeatures_treeView, $"//a[{U.XPathText(Casing.Exact, features[featureIdx - 1])}]");
        }
    }
}
