Public Class Global_asax
    Inherits System.Web.HttpApplication

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    'Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

    '    CorsSupport.HandlePreflightRequest(HttpContext.Current)

    'End Sub
    Private Sub Global_asax_BeginRequest(sender As Object, e As EventArgs) Handles Me.BeginRequest

        'Dim OutputFilterStream As OutputFilterStream = Nothing

        Try

            CorsSupport.HandlePreflightRequest(HttpContext.Current)

        Catch ex As Exception
            ProcessException(ex, "APIService-ApplicationError")
        End Try

        'ProcessRequest()

        'OutputFilterStream = New OutputFilterStream(HttpContext.Current.Response.Filter)
        'HttpContext.Current.Response.Filter = OutputFilterStream
        'HttpContext.Current.Items.Add("OutputFilterStream", OutputFilterStream)

    End Sub
    Private Sub Global_asax_EndRequest(sender As Object, e As EventArgs) Handles Me.EndRequest

        Try

            System.GC.Collect()

        Catch ex As Exception
            ProcessException(ex, "APIService-ApplicationError")
        End Try

        'ProcessResponse()

    End Sub
    Private Sub Global_asax_Error(sender As Object, e As EventArgs) Handles Me.[Error]

        Dim Exception As Exception = Nothing

        If HttpContext.Current.Server.GetLastError() IsNot Nothing Then

            Exception = HttpContext.Current.Server.GetLastError()

            ProcessException(Exception, "APIService-ApplicationError")

        End If

    End Sub

#End Region

End Class