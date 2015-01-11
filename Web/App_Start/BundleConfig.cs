using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/app").Include(
                      "~/Scripts/Lib/jquery-2.1.3.js",
                      "~/Scripts/Lib/bootstrap.js",
                      "~/Scripts/Lib/angular.js",
                      "~/Scripts/Lib/angular-route.js",
                      "~/Scripts/Lib/ui-bootstrap-tpls.js",
                      "~/Scripts/App/appModule.js",
                      "~/Scripts/App/appRoute.js",
                      "~/Scripts/App/Home/Controllers/homeController.js",
                      "~/Scripts/App/Account/Controllers/registrationController.js",
                      "~/Scripts/App/Account/Controllers/logOnController.js",
                      "~/Scripts/App/Account/Controllers/changePasswordController.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"));
        }
    }
}
