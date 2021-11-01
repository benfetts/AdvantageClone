Public Class JobForecast_Settings
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobForecastRevisionID As Integer = 0
    Private _JobForecastSettings As Webvantage.cAppVars = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property JobForecastSettings As Webvantage.cAppVars
        Get
            If _JobForecastSettings Is Nothing Then

                _JobForecastSettings = New Webvantage.cAppVars(cAppVars.Application.JOB_FORECAST, _Session.UserCode, _Session.User.EmployeeCode)
                _JobForecastSettings.getAllAppVars()

            End If
            Return _JobForecastSettings
        End Get
    End Property
    Private ReadOnly Property CanUserUpdate As Boolean
        Get
            If ViewState("JF_CanUserUpdate") Is Nothing Then
                ViewState("JF_CanUserUpdate") = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserUpdate")
        End Get
    End Property
    Private Property ShowApprovedEstimateAmount As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowApprovedEstimateAmount", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Me.JobForecastSettings.setAppVarDB("ShowApprovedEstimateAmount", value.ToString, "Boolean")
        End Set
    End Property
    Private Property ShowSalesClass As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowSalesClass", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Me.JobForecastSettings.setAppVarDB("ShowSalesClass", value.ToString, "Boolean")
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub LoadTab(ByRef [Page] As System.Web.UI.Page)

        If [Page] Is Me Then

            'AdvantageFramework.Web.Presentation.SettingPage.LoadTab(PlaceHolderSettings, Session("ConnString").ToString(), Session("UserCode").ToString(), 4, 0)

        End If

    End Sub
    Private Sub LoadSelectedJobForecastSettings()

        'objects
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

        If _JobForecastRevisionID > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, _JobForecastRevisionID)

                If JobForecastRevision IsNot Nothing Then

                    RadComboBoxJobForecastType.SelectedValue = JobForecastRevision.JobForecast.ForecastType.GetValueOrDefault(0)

                End If

            End Using

        Else


        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub JobForecast_Settings_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Request.QueryString("JobForecastRevisionID") IsNot Nothing Then

                _JobForecastRevisionID = CInt(Request.QueryString("JobForecastRevisionID"))

            End If

        Catch ex As Exception
            _JobForecastRevisionID = 0
        End Try

    End Sub
    Private Sub JobForecast_Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)

        AddHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

        LoadTab(Me)

        If Not Me.IsPostBack Then

            CheckBoxShowApprovedEstimateColumn.Checked = Me.ShowApprovedEstimateAmount
            CheckBoxShowSalesClassColumn.Checked = Me.ShowSalesClass

            If _JobForecastRevisionID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobForecast = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, _JobForecastRevisionID).JobForecast

                    RadComboBoxJobForecastType.DataSource = From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.JobForecast.JobForecastTypes))
                                                            Select [Code] = Item.Code,
                                                                   [Description] = Item.Description

                    RadComboBoxJobForecastType.DataBind()

                    RadComboBoxJobForecastType.SelectedValue = JobForecast.ForecastType.GetValueOrDefault(0)

                End Using

            Else



            End If

        End If

        RadComboBoxJobForecastType.Enabled = Me.CanUserUpdate

        If Me.IsPostBack Then

            AdvantageFramework.Web.Presentation.SettingPage.FindControl(Me, PlaceHolderSettings)

        End If

    End Sub
    Private Sub JobForecast_Settings_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Web.Presentation.SettingPage.LoadTabEvent, AddressOf LoadTab

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarJobForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecast.ButtonClick

        Select Case e.Item.Value

            Case "Done"

                Me.CloseThisWindow()

        End Select

    End Sub
    Protected Sub RadComboBoxJobForecastType_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

        'objects
        Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing

        If Me.CanUserUpdate Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobForecast = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, _JobForecastRevisionID).JobForecast

                If Not [String].IsNullOrWhiteSpace(RadComboBoxJobForecastType.SelectedValue) Then

                    JobForecast.ForecastType = CShort(RadComboBoxJobForecastType.SelectedValue)

                Else

                    JobForecast.ForecastType = 0

                End If

                AdvantageFramework.JobForecast.UpdateJobForecast(DbContext, JobForecast)

            End Using

        End If

    End Sub
    Private Sub CheckBoxShowApprovedEstimateColumn_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowApprovedEstimateColumn.CheckedChanged

        Me.ShowApprovedEstimateAmount = CheckBoxShowApprovedEstimateColumn.Checked

    End Sub
    Private Sub CheckBoxShowSalesClassColumn_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowSalesClassColumn.CheckedChanged

        Me.ShowSalesClass = CheckBoxShowSalesClassColumn.Checked

    End Sub

#End Region

#End Region

End Class