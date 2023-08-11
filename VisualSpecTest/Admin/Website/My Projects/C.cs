namespace Admin.Website.MyProjects
{
    using Pangolin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class C
    {
        public static string formProjectDetail = $"//form[{U.XPathAttributeContains("action", "./Edit-project.aspx")}]";
    }
}
