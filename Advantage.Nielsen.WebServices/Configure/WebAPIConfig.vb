Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http

Namespace Configuration

    Public NotInheritable Class WebAPIConfig

        Private Sub New()

        End Sub

        Public Shared Sub Register(config As HttpConfiguration)
            ' Web API routes
            config.MapHttpAttributeRoutes()

            'config.Routes.MapHttpRoute(name:="API Default", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .IDGreaterThan = 0,
            '    Key .Page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenNationalTVAudience", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenNationalTVAudience",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenNationalTVHutput", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenNationalTVHutput",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenNationalTVUniverse", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenNationalTVUniverse",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            config.Routes.MapHttpRoute(name:="NielsenTVAudience", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
                Key .controller = "NielsenTVAudience",
                Key .IDGreaterThan = 0,
                Key .page = RouteParameter.Optional
            })

            'config.Routes.MapHttpRoute(name:="NielsenTVBook", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVBook",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVBook", routeTemplate:="api/{controller}/{clientcode}", defaults:=New With {
            '    Key .controller = "NielsenTVBook",
            '    Key .ClientCode = ""
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVHutput", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVHutput",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVIntab", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVIntab",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVProgram", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVProgram",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVStation", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVStation",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVStationHistory", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVStationHistory",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

            'config.Routes.MapHttpRoute(name:="NielsenTVUniverse", routeTemplate:="api/{controller}/{idgreaterthan}/{page}", defaults:=New With {
            '    Key .controller = "NielsenTVUniverse",
            '    Key .IDGreaterThan = 0,
            '    Key .page = RouteParameter.Optional
            '})

        End Sub

    End Class

End Namespace
