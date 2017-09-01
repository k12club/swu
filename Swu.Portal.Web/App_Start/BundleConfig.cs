using System.Web.Optimization;

namespace Swu.Portal.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js",
                        "~/Scripts/jquery/jquery.maphilight.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.js",
                      "~/Scripts/bootstrap/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/angular-material.css",
                      "~/Content/material-icons.css",
                      "~/Content/ng-grid.css",
                      "~/Content/site.css",
                      "~/Content/angular-toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/ng-lib")
                    .Include("~/Scripts/angular/angular.js")
                    .Include("~/Scripts/angular/angular-animate.js")
                    .Include("~/Scripts/angular/angular-aria.js")
                    .Include("~/Scripts/angular/angular-route.js")
                    .Include("~/Scripts/angular/angular-sanitize.js")
                    .Include("~/Scripts/angular/angular-resource.js")
                    .Include("~/Scripts/angular/angular-messages.min.js")
                    .Include("~/Scripts/angular/angular-cookies.js")
                    .Include("~/Scripts/angular/ui-bootstrap-tpls-0.14.2.min.js")
                    .Include("~/Scripts/angular/ui-date.js")
                    .Include("~/Scripts/angular/ui-tinymce.js")
                    .Include("~/Scripts/angular/angular-selectize.js")
                    .Include("~/Scripts/angular/ng-file-upload-shim.js")
                    .Include("~/Scripts/angular/ng-file-upload.js")
                    .Include("~/Scripts/angular/angular-ui-router.min.js")
                    .Include("~/Scripts/angular/underscore.js")
                    .Include("~/Scripts/angular/angular-material.min.js")
                    .Include("~/Scripts/angular/angular-toastr.tpls.js")
                    .Include("~/Scripts/angular/toastr.js")
                    .Include("~/Scripts/angular/ngprogress-lite.min.js")
                    .Include("~/Scripts/angular/ng-grid.min.js")
                    .Include("~/Scripts/angular/ngStorage.min.js")
                    //.Include("~/Scripts/angular/angular-translate-handler-log.js")
                    //.Include("~/Scripts/angular/angular-translate-interpolation-messageformat.js")
                    //.Include("~/Scripts/angular/angular-translate-loader-static-files.js")
                    //.Include("~/Scripts/angular/angular-translate-loader-url.js")
                    //.Include("~/Scripts/angular/angular-translate-storage-cookie.js")
                    //.Include("~/Scripts/angular/angular-translate-storage-local.js")
                    .Include("~/Scripts/angular/angular-translate.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/ng-app")
                .Include("~/Scripts/app-bundles.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/utilities-lib")
                .Include(
                "~/Scripts/utilities/moment.min.js",
                "~/Scripts/utilities/moment-with-locales.min.js"));

            bundles.Add(new ScriptBundle("~/theme/js")
                .Include("~/Content/js/jquery.js",
                "~/Content/js/jquery-ui.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/bootsnav.js",
                "~/Content/js/scrollto.js",
                "~/Content/js/jquery-scrolltofixed-min.js",
                "~/Content/js/jquery-SmoothScroll-min.js.js",
                "~/Content/js/jquery.counterup.js",
                "~/Content/js/fancybox.js",
                "~/Content/js/wow.min.js",
                "~/Content/js/jquery.masonry.min.js",
                "~/Content/js/jquery.magnific-popup.min.js",
                "~/Content/js/owl.carousel.min.js",
                "~/Content/js/jquery.fitvids.js",
                "~/Content/js/css3-animate-it.js",
                "~/Content/js/swiper.min.js",
                "~/Content/js/flipclock.min.js",
                "~/Content/js/script.js"));

            bundles.Add(new ScriptBundle("~/ie9/js")
               .Include("~/Content/js/html5shiv.min.js",
               "~/Content/js/respond.min.js"));

           bundles.Add(new StyleBundle("~/theme/css")
                .Include("~/Content/css/bootstrap.min.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css",
                "~/Content/css/translations.css"));
        }
    }
}