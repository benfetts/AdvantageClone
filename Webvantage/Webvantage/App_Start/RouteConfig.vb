Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports MvcCodeRouting

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("{resource}.png/{*pathInfo}")
        routes.IgnoreRoute("Telerik.Web.UI.DialogHandler.aspx/{*pathInfo}")

        ' THE ORDER OF ROUTES MATTER!

        routes.MapCodeRoutes(GetType(Webvantage.Controllers.HomeController)) ' needed for Namespace Routing!

        'routes.MapRoute(
        '    name:="MediaBuyer",
        '    url:="Maintenance/Media/MediaBuyer",
        '    defaults:=New With {.controller = "MediaBuyer", .action = "Index"}
        ')
        'routes.MapRoute(
        '    name:="GeneralLedgerReport",
        '    url:="GeneralLedgerReport/{action}/{ReportID}/{IsDynamic}",
        '    defaults:=New With {.controller = "GeneralLedgerReport", .action = "Index", .ReportID = GetType(Integer), .IsDynamic = GetType(Integer)}
        ')
        'routes.MapRoute(
        '    name:="ProjectSchedule",
        '    url:="ProjectSchedule/Index/{JobNumber}/{JobComponentNumber}",
        '    defaults:=New With {.controller = "ProjectSchedule", .action = "Index", .JobNumber = GetType(Integer), .JobComponentNumber = GetType(Short)}
        ')
        routes.MapRoute(
            name:="Reporting_SalesAndCostOfSalesByClientCriteria",
            url:="Reporting/{action}/{DynamicReportTemplateID}/{UserDefinedReportID}",
            defaults:=New With {.controller = "Reporting", .action = "SalesAndCostOfSalesByClientCriteria", .DynamicReportTemplateID = GetType(Integer), .UserDefinedReportID = GetType(Integer)}
        )
        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )


    End Sub
End Module