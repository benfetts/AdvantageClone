Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/jquery-{version}.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Content/bootstrap").Include(
            "~/Content/bootstrap.css"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"))

        bundles.Add(New StyleBundle("~/Content/childpage").Include(
            "~/CSS/Material/Bootstrap.Cyan.css",
            "~/CSS/Common.min.css",
            "~/CSS/CardLayout.min.css",
            "~/CSS/CardLayout.Colors.min.css"))

        bundles.Add(New ScriptBundle("~/bundles/childpage").Include(
            "~/Scripts/jquery-3.6.0.min.js",
            "~/Jscripts/ChildPage.min.js",
            "~/Jscripts/common.min.js",
            "~/Jscripts/UIHelper.min.js"))

        bundles.Add(New ScriptBundle("~/bundles/angularjs").Include(
            "~/Scripts/angular.min.js",
            "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"))

        bundles.Add(New ScriptBundle("~/bundles/kendo").Include(
            "~/Scripts/kendo/current/kendo.all.min.js",
            "~/Scripts/kendo/current/kendo.aspnetmvc.min.js"))

        bundles.Add(New StyleBundle("~/Content/kendo/current/css").Include(
            "~/Content/kendo/current/kendo.common-bootstrap.min.css",
            "~/Content/kendo/current/kendo.bootstrap.min.css"))

        bundles.Add(New StyleBundle("~/theme/large").Include(
            "~/Content/bootstrap.css",
            "~/CSS/site-large.css"))

        bundles.Add(New StyleBundle("~/theme/small").Include(
            "~/Content/bootstrap-small.min.css",
            "~/CSS/site.css"))

        bundles.Add(New StyleBundle("~/theme/site").Include(
            "~/Content/bootstrap.css",
            "~/CSS/site-new.css"))

        bundles.Add(New ScriptBundle("~/bundles/ejscripts").Include(
                           "~/Scripts/jsrender.min.js",
                           "~/Scripts/jquery.easing-1.3.min.js",
                           "~/Scripts/ej/ej.web.all.min.js",
                            "~/Scripts/ej/ej.unobtrusive.min.js"))
        bundles.Add(New StyleBundle("~/bundles/ejstyles").Include(
                  "~/ejThemes/flat-saffron/ej.web.all.min.css"))

    End Sub
End Module
