Public Class Maintenance_IntegrationSettings
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadTab(ByRef [Page] As System.Web.UI.Page)

        Dim TabIndex As Integer = 1

        If [Page] Is Me Then

            If Me.RadTabStripIntegrationSettings.SelectedIndex > -1 Then

                TabIndex = Me.RadTabStripIntegrationSettings.SelectedIndex + 1

            End If

            AdvantageFramework.Web.Presentation.SettingPage.LoadTab(PlaceHolderSettings, _Session, 7, TabIndex)

        End If

    End Sub
    Private Sub CheckBoxChecked(ByRef [Page] As System.Web.UI.Page, ByRef Checked As Boolean)

        If [Page] Is Me Then

            If Checked Then

                AuthorizeDoubleClick()

            Else

                DeauthorizeDoubleClick()

            End If

        End If

    End Sub
    Private Sub DeauthorizeDoubleClick()

        'objects
        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

        Try

            Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, True)

            If Service IsNot Nothing Then

                Service.Deauthorize()

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub AuthorizeDoubleClick()

        Me.OpenWindow("", "Google_Authentication.aspx?ServiceType=DoubleClick&ServiceLevel=Agency", 300, 500, False, True)

    End Sub
    Private Sub UpdatedDCEnabled()

        'objects
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim Token As String = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            Using DataContext As New AdvantageFramework.Database.DataContext(Session("ConnString"), Session("UserCode"))

                Token = DbContext.Database.SqlQuery(Of String)("SELECT AGY_SETTINGS_VALUE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DC_OAUTH2_TOKEN'").FirstOrDefault

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DC_ENABLED.ToString)

                If Setting IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(Token) Then

                        Setting.Value = 0

                    Else

                        Setting.Value = 1

                    End If

                    AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                End If

            End Using

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_IntegrationSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Integration Settings"

        AddHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab
        AddHandler AdvantageFramework.Web.Presentation.SettingPage.CheckBoxCheckedEvent, AddressOf CheckBoxChecked

        ImageButtonLoadDefaults.Attributes.Add("onclick", "return confirm('Are you sure you want to load defaults?  If you do, all current values will be discarded.');")

        If Not Me.IsPostBack And Not Me.IsCallback Then

            AdvantageFramework.Web.Presentation.SettingPage.LoadTabs(RadTabStripIntegrationSettings, _Session, 7)

            If Request.QueryString("RefreshTab") IsNot Nothing Then

                Me.RadTabStripIntegrationSettings.SelectedIndex = Request.QueryString("RefreshTab")

                If Request.QueryString("RefreshTab") = 5 Then

                    UpdatedDCEnabled()

                End If

            End If

        End If

        LoadTab(Me)

        If Not Me.IsPostBack And Not Me.IsCallback Then

        End If

        If Me.IsPostBack Then

            AdvantageFramework.Web.Presentation.SettingPage.FindControl(Me, PlaceHolderSettings)

        End If

    End Sub
    Private Sub Maintenance_IntegrationSettings_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab
        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.CheckBoxCheckedEvent, AddressOf CheckBoxChecked

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadTabStripIntegrationSettings_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripIntegrationSettings.TabClick

        LoadTab(Me)

    End Sub
    Private Sub ImageButtonLoadDefaults_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLoadDefaults.Click

        AdvantageFramework.Web.Presentation.SettingPage.LoadDefaults(Session("ConnString").ToString(), Session("UserCode").ToString(), 7)

        LoadTab(Me)

    End Sub

#End Region

#End Region

End Class
