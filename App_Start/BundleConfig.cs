using System.Web;
using System.Web.Optimization;
using Unity;

namespace WebApplication1
{
    public class BundleConfig 
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/employee").Include(
                        "~/Scripts/Employee/Employee.js",
                         "~/Scripts/Employee/Form.js",
                          "~/Scripts/Employee/Grid.js"));



            BundleTable.EnableOptimizations = true;
        }
      
    }
}
