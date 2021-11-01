Public Class Google_Authentication
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "



#End Region

#Region " Properties "


#End Region

#Region " Methods "

    Private Function InitializeService() As AdvantageFramework.GoogleServices.Service

        'objects
        Dim ServiceType As AdvantageFramework.GoogleServices.Service.ServiceTypes = AdvantageFramework.GoogleServices.Service.ServiceTypes.Calendar
        Dim ServiceLevel As String = Nothing
        Dim ClientCode As String = Nothing

        If Request.QueryString("AgencyOnly") = "true" Then

            ServiceType = AdvantageFramework.GoogleServices.Service.ServiceTypes.Gmail

            Return AdvantageFramework.GoogleServices.Service.Initialize(ServiceType, _Session, Nothing, True)

        Else

            If Request.QueryString("ServiceType") = "DoubleClick" Then

                ServiceType = AdvantageFramework.GoogleServices.Service.ServiceTypes.DoubleClick

                ServiceLevel = Request.QueryString("ServiceLevel")

                If ServiceLevel = "Client" Then

                    ClientCode = Request.QueryString("ClientCode")

                    Return AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, True, ClientCode)

                Else

                    Return AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, True)

                End If

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.GoogleServices.Service.GetEnabledServices(DbContext, False).Contains(AdvantageFramework.GoogleServices.Service.ServiceTypes.Gmail) Then

                        ServiceType = AdvantageFramework.GoogleServices.Service.ServiceTypes.All

                    End If

                End Using

                Return AdvantageFramework.GoogleServices.Service.Initialize(ServiceType, _Session, _Session.User.EmployeeCode, True)

            End If

        End If


    End Function

#Region "  Form Event Handlers "

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim AuthorizationUri As System.Uri = Nothing
        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

        Me.PageTitle = "Google Authentication"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Service = InitializeService()

            If Service IsNot Nothing Then

                AuthorizationUri = Service.GetAuthorizationUri()

                HiddenFieldLink.Value = AuthorizationUri.ToString

                AddJavascriptToPage("OpenGoogleAuthorization()")

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

        'objects
        Dim ErrorMessage As String = Nothing
        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
        Dim Exchanged As Boolean = False

        If RadTextBoxAuthorizationCode.Text <> "" Then

            Try

                Service = InitializeService()

                If Service IsNot Nothing Then

                    Exchanged = Service.ExchangeCodeForToken(RadTextBoxAuthorizationCode.Text.Trim)

                End If

                If Exchanged Then

                    If Request.QueryString("AgencyOnly") = "true" Then

                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "CloseWindowRefreshEmailSettings", "window.onload = function() { CloseWindowRefreshEmailSettings(); };", True)

                    Else

                        If Request.QueryString("ServiceType") = "DoubleClick" Then

                            If Request.QueryString("ServiceLevel") = "Agency" Then

                                Me.CloseThisWindowAndRefreshCaller("Maintenance_IntegrationSettings.aspx?RefreshTab=5", True)

                            ElseIf Request.QueryString("ServiceLevel") = "Client" Then

                                Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientEdit.aspx?RefreshMediaIntegrationSettings", True)

                            End If

                        ElseIf Request.QueryString("ServiceType") = "Calendar" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_CalendarTime.aspx", True)

                        Else

                            Me.CloseThisWindowAndRefreshCaller("Security_ChangePassword.aspx?SelectedTab=4", True)

                        End If

                    End If


                Else

                    If Request.QueryString("AgencyOnly") = "true" Then

                        ErrorMessage = "There was a problem authorizing Advantage Gmail. Please contact software support."

                    Else

                        If Request.QueryString("ServiceType") = "DoubleClick" Then

                            ErrorMessage = "There was a problem authorizing Advantage DoubleClick. Please contact software support."

                        ElseIf Request.QueryString("ServiceType") = "Calendar" Then

                            ErrorMessage = "There was a problem authorizing Advantage Calendar. Please contact software support."

                        Else

                            ErrorMessage = "There was a problem authorizing Advantage Calendar Sync. Please contact software support."

                        End If

                    End If

                End If

            Catch ex As Exception
                If Request.QueryString("ServiceType") = "DoubleClick" Then
                    ErrorMessage = "There was a problem authorizing Advantage DoubleClick. Please contact software support."
                ElseIf Request.QueryString("ServiceType") = "Calendar" Then
                    ErrorMessage = "There was a problem authorizing Advantage Calendar. Please contact software support."
                Else
                    ErrorMessage = "There was a problem authorizing Advantage Calendar Sync. Please contact software support."
                End If
            End Try

        Else

            ErrorMessage = "Please enter an authorization code."

        End If

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    'Private Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

    '    Me.CloseThisWindow()

    'End Sub

#End Region

#End Region

End Class
