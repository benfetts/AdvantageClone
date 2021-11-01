Public Class Maintenance_ProjectScheduleSettings
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

        If [Page] Is Me Then

            AdvantageFramework.Web.Presentation.SettingPage.LoadTab(PlaceHolderSettings, _Session, 0, RadTabStripProjectScheduleSettings.SelectedIndex + 1)

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ProjectScheduleSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Project Schedule Settings"

        AddHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

        ImageButtonLoadDefaults.Attributes.Add("onclick", "return confirm('Are you sure you want to load defaults?  If you do, all current values will be discarded.');")

        If Not Me.IsPostBack And Not Me.IsCallback Then

            AdvantageFramework.Web.Presentation.SettingPage.LoadTabs(RadTabStripProjectScheduleSettings, _Session, 0)

        End If

        LoadTab(Me)

        If Me.IsPostBack Then

            AdvantageFramework.Web.Presentation.SettingPage.FindControl(Me, PlaceHolderSettings)

        End If

    End Sub
    Private Sub Maintenance_ProjectScheduleSettings_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadTabStripProjectScheduleSettings_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripProjectScheduleSettings.TabClick

        LoadTab(Me)

        If RadTabStripProjectScheduleSettings.SelectedIndex = 1 Then
            Me.LabelNote.Visible = False
        Else
            Me.LabelNote.Visible = True
        End If

    End Sub
    Private Sub ImageButtonLoadDefaults_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLoadDefaults.Click

        AdvantageFramework.Web.Presentation.SettingPage.LoadDefaults(Session("ConnString").ToString(), Session("UserCode").ToString(), 0)

        LoadTab(Me)

    End Sub

#End Region

#End Region

End Class