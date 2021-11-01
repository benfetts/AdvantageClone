Imports System.Web
Imports System.Web.Services

Public MustInherit Class BaseSearchLookupHandler
    Implements System.Web.IHttpHandler
    Implements System.Web.SessionState.IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'objects
        Dim LookupDisplayObject As ViewModels.LookupDisplayObject = Nothing
        Dim SearchCriteriaText As String = Nothing
        Dim Json As String = Nothing
        Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)

        SearchCriteriaText = New System.IO.StreamReader(context.Request.InputStream).ReadToEnd()

        LookupDisplayObject = ProcessRequest(Session, SearchCriteriaText)

        Json = Newtonsoft.Json.JsonConvert.SerializeObject(LookupDisplayObject)

        With HttpContext.Current.Response

            .Clear()
            .ContentType = "application/json; charset=utf-8"
            .Write(Json)

        End With

    End Sub
    Protected MustOverride Function ProcessRequest(ByVal Session As AdvantageFramework.Security.Session, ByVal SearchCriteriaText As String) As ViewModels.BaseLookupDisplayObject

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
