Public Class Maintenance_ProductionSettings
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

            Dim TabIndex As Integer = 0

            If Me.RadTabStripProductionSettings.SelectedIndex > -1 Then

                TabIndex = Me.RadTabStripProductionSettings.SelectedIndex

            End If

            AdvantageFramework.Web.Presentation.SettingPage.LoadTab(PlaceHolderSettings, _Session, 2, TabIndex)

        End If

        

    End Sub

    Private Sub LoadAlertAssignmentStates()
        Try
            Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                'Me.RadComboBoxAssignmentStates.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                'If Me.RadComboBoxAssignmentTemplates.SelectedValue <> "0" Then
                '    Dim AlertAssignmentStates As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateState)
                '    AlertAssignmentStates = Nothing
                '    AlertAssignmentStates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, Me.RadComboBoxAssignmentTemplates.SelectedValue).ToList()

                '    If Not AlertAssignmentStates Is Nothing Then

                '        For Each t As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState In AlertAssignmentStates

                '            Me.RadComboBoxAssignmentStates.Items.Add(New Telerik.Web.UI.RadComboBoxItem(t.AlertState.Name, t.AlertStateID))

                '        Next

                '    End If

                '    If Not a.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, "") Is Nothing Then
                '        Me.RadComboBoxAssignmentStates.SelectedValue = a.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, "")
                '    Else
                '        Me.RadComboBoxAssignmentStates.SelectedValue = "0"
                '    End If

                'End If

            End Using

        Catch ex As Exception

        End Try
    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ProductionSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Production Settings"

        AddHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

        ImageButtonLoadDefaults.Attributes.Add("onclick", "return confirm('Are you sure you want to load defaults?  If you do, all current values will be discarded.');")

        LoadTab(Me)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            AdvantageFramework.Web.Presentation.SettingPage.LoadTabs(RadTabStripProductionSettings, _Session, 2)

        End If


        If Me.IsPostBack Then

            AdvantageFramework.Web.Presentation.SettingPage.FindControl(Me, PlaceHolderSettings)

        End If

    End Sub
    Private Sub Maintenance_ProductionSettings_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub radtsForm_ProjectScheduleSettings_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripProductionSettings.TabClick

        LoadTab(Me)

    End Sub
    Private Sub ImageButtonLoadDefaults_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonLoadDefaults.Click

        AdvantageFramework.Web.Presentation.SettingPage.LoadDefaults(Session("ConnString").ToString(), Session("UserCode").ToString(), 2)

        LoadTab(Me)

    End Sub

#End Region

#End Region

End Class