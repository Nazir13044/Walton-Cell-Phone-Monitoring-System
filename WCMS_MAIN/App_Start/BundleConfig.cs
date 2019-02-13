using System.Web;
using System.Web.Optimization;


namespace WCMS_MAIN
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //********** STYLE BUNDLE **********//
            //********** STYLE BUNDLE **********//


            bundles.Add(new StyleBundle("~/bundles/BootstrapCss").Include(
                     "~/js/vendor/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/FontPlugins").Include(
                    "~/js/css/fontastic.css"
                   ).Include("~/js/vendor/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            //Easy UI
            bundles.Add(new StyleBundle("~/bundles/EasyUiPlugins").Include(
                    "~/js/vendor/JQueryEasyUI/themes/default/easyui.css"));

            //Jauery Ui
            bundles.Add(new StyleBundle("~/bundles/JqueryUiPlugins").Include(
                    "~/js/vendor/jquery-autocomplete/jquery-ui.css"));


            
            //Custom Css
            bundles.Add(new StyleBundle("~/bundles/CustomCss").Include(
                      "~/css/style.default.css",
                      "~/css/custom.css"
                      
                      ));

            //********** SCRIPTS BUNDLE **********//
            //********** SCRIPTS BUNDLE **********//

            //Jquery Bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/vendor/jquery/jquery-1.9.1.min.js"));

            ////Jquery Easy Ui Bundle
             //Third Party Plugin Bundle 
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                         "~/js/vendor/popper.js/umd/popper.min.js",
                        "~/js/vendor/bootstrap/js/bootstrap.min.js",
                         "~/js/vendor/jquery.cookie/jquery.cookie.js",
                         "~/js/vendor/chart.js/Chart.min.js",
                         "~/js/front.js"));

            //JqueryUI Bundle

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                       "~/js/vendor/jquery-autocomplete/jquery-ui.custom.js"));

            //Jquery Validation Bundle 
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/js/jquery.validate.js",
                        "~/js/jquery.validate.unobtrusive.min.js"));

           
        }
    }
}
