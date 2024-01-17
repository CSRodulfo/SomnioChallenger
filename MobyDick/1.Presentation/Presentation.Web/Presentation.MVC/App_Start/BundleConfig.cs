using System.Threading;
using System.Web;
using System.Web.Optimization;

namespace Presentation.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Plugins").Include(
                                         "~/Scripts/Plugins/*.js",
                                         "~/Scripts/Plugins/jquery.fancytree-all.min.js",
                                         "~/Scripts/Select2.min.js",
                                         "~/Scripts/fileinput.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                                         "~/Scripts/jquery.validate.js",
                                         "~/Scripts/jquery.validate.unobtrusive.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                         "~/Scripts/bootstrap.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
                                         "~/Scripts/jquery.jqGrid.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                         "~/Scripts/jquery-{version}.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                                         "~/Scripts/jquery-ui-{version}.js"
                                         ));





            bundles.Add(new ScriptBundle("~/bundles/Site").Include(
                                          "~/Scripts/Site.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                         "~/Scripts/modernizr-*"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/mobydick").Include(
                                         "~/Scripts/mobydick-*"
                                         ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                        "~/Content/css/jquery-ui-1.11.2.css",
                                        "~/Content/mobydick2.css",
                                        "~/Content/jquery.jqGrid/ui.jqgrid.css",
                                        "~/Content/css/fancytree/skin-win8/ui.fancytree.min.css",
                                        "~/Content/select2-bootstrap.css",
                                        "~/Content/bootstrap-fileinput/css/fileinput.css"
                                        ));

            #region smartMenus
            bundles.Add(new StyleBundle("~/Content/smartMenus").Include(
                                        "~/Content/jquery.smartmenus.bootstrap.css"
                                        ));

            bundles.Add(new ScriptBundle("~/bundles/smartMenus").Include(
                                         "~/Scripts/Plugins/smartmenu/jquery.smartmenus.js",
                                         "~/Scripts/Plugins/smartmenu/jquery.smartmenus.bootstrap.js"
                                         ));
            #endregion

            #region plupload
            bundles.Add(new StyleBundle("~/Content/plupload").Include(
                                        "~/Scripts/plupload/jquery.plupload.queue/css/jquery.plupload.queue.css",
                                        "~/Scripts/plupload/jquery.plupload.queue/css/uploadkit.css"
                                        ));

            bundles.Add(new ScriptBundle("~/bundles/plupload").Include(
                                        "~/Scripts/plupload/moxie.js",
                                        "~/Scripts/plupload/jquery.plupload.queue/jquery.plupload.queue.js",
                                        "~/Scripts/plupload/plupload.full.min.js",
                                         "~/Scripts/plupload/uploadkit.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/plupload.es-ar").Include(
                                         "~/Scripts/plupload/i18n/es.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/plupload.en-us").Include(
                                         "~/Scripts/plupload/i18n/en.js"
                                        ));
            #endregion

            #region MobyDickGrid
            bundles.Add(new ScriptBundle("~/bundles/MobyDickGrid").Include("~/Scripts/MobyDickGrid/MobyDickGridConfig.js",
                                        "~/Scripts/MobyDickGrid/MobyDickGrid.js"
                                        ));

            bundles.Add(new StyleBundle("~/Content/MobyDickGrid").Include(
                            "~/Content/MobyDickGrid/MobyDickGrid.css"
                            ));
            #endregion

            #region MobyDickFancyTree
            bundles.Add(new ScriptBundle("~/bundles/MobyDickFancyTree").Include(
                                         "~/Scripts/MobyDickFancyTree/MobyDickFancyTree.js"
                                         ));
            #endregion

            #region MobyDickChart
            bundles.Add(new ScriptBundle("~/bundles/Charts").Include(
                                         "~/Scripts/Chart.js",
                                         "~/Scripts/MobyDickChart/MobyDickChart.js"
                                         ));
            #endregion

            #region MobyDickHub
            bundles.Add(new ScriptBundle("~/bundles/jquerySignalR").Include("~/Scripts/jquery.signalR-{version}.js"
                                         ));

            bundles.Add(new ScriptBundle("~/bundles/MobyDickHubs").Include(
                                         "~/Scripts/MobyDickHubs/MobyDickHubConfig.js",
                                         "~/Scripts/MobyDickHubs/MobyDickHub.js"
                                         ));

            #endregion

            #region Languaje

            bundles.Add(new ScriptBundle("~/bundles/Globalize.en-us").Include(
                                        "~/Scripts/i18n/grid.locale-en.js",
                                        "~/Scripts/Resources_en.js",
                                        "~/Scripts/globalize.culture.en-US.js",
                                        "~/Scripts/fileinput_locale_LANG.js"
                                       ));

            bundles.Add(new ScriptBundle("~/bundles/Globalize.es-ar").Include(
                                         "~/Scripts/i18n/grid.locale-es.js",
                                         "~/Scripts/Resources_es.js",
                                         "~/Scripts/i18n/datepicker-es.js",
                                         "~/Scripts/Select2-locales/select2_locale_es.js",
                                         "~/Scripts/globalize.culture.es-AR.js",
                                         "~/Scripts/fileinput_locale_es.js"
                                       ));

            bundles.Add(new ScriptBundle("~/bundles/globalization").Include(
                                         "~/Scripts/globalize.js",
                                         "~/Scripts/globalize.initialize.js"
                                         ));

            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}