Imports Telerik.Web.UI

Public Class Reporting_InitialLoadingCampaignProductionMedia
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Protected _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = Session("DRPT_Type")

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub
    Private Sub LoadCampaigns()

        Dim client As String

        client = RadComboBoxClient.SelectedValue

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CheckBoxIncludeClosed.Checked = False Then


                RadComboBoxCampaignFrom.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCodeActive(DbContext, client).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                      Select New With {.ID = Entity.ID,
                                                                         .Name = Entity.Code & " - " & Entity.Name}).ToList

                RadComboBoxCampaignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCodeActive(DbContext, client).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                    Select New With {.ID = Entity.ID,
                                                                         .Name = Entity.Code & " - " & Entity.Name}).ToList

            Else

                RadComboBoxCampaignFrom.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, client).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                      Select New With {.ID = Entity.ID,
                                                                         .Name = Entity.Code & " - " & Entity.Name}).ToList

                RadComboBoxCampaignTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, client).OrderBy(Function(Campaign) Campaign.ID).ToList
                                                    Select New With {.ID = Entity.ID,
                                                                         .Name = Entity.Code & " - " & Entity.Name}).ToList

            End If

            RadComboBoxCampaignFrom.DataBind()
            RadComboBoxCampaignFrom.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            RadComboBoxCampaignTo.DataBind()
            RadComboBoxCampaignTo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

    End Sub
#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingPostPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxClient.DataTextField = "Name"
            RadComboBoxClient.DataValueField = "Code"

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList

                End Using

                RadComboBoxClient.DataBind()

            End Using

            LoadCampaigns()

            If _ParameterDictionary IsNot Nothing Then

                CheckBoxIncludeClosed.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString)), True, _ParameterDictionary(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString))

            Else

                CheckBoxIncludeClosed.Checked = False

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                If Me.RadComboBoxCampaignFrom.SelectedValue = "" Then
                    Me.ShowMessage("From Campaign is required.")
                    Exit Sub
                End If

                If Me.RadComboBoxCampaignTo.SelectedValue = "" Then
                    Me.ShowMessage("To Campaign is required.")
                    Exit Sub
                End If


                Session("DRPT_ParameterDictionary") = Nothing

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.ClientCode.ToString) = RadComboBoxClient.SelectedValue
                If RadComboBoxCampaignFrom.Items.Count > 0 Then
                    _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDFrom.ToString) = RadComboBoxCampaignFrom.SelectedValue
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDFrom.ToString) = 0
                End If
                If RadComboBoxCampaignTo.Items.Count > 0 Then
                    _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDTo.ToString) = RadComboBoxCampaignTo.SelectedValue
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.CampaignIDTo.ToString) = 0
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.IncludeClosed.ToString) = IIf(CheckBoxIncludeClosed.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.CampaignProductionMediaParameters.UseCampaignMasterJobEstimate.ToString) = IIf(CheckBoxCampaignMasterJob.Checked, 1, 0)

                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = _ParameterDictionary


                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub
    Private Sub CheckBoxIncludeClosed_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeClosed.CheckedChanged

        LoadCampaigns()

    End Sub

    Private Sub RadComboBoxClient_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxClient.SelectedIndexChanged

        LoadCampaigns()

    End Sub

#End Region

#End Region

End Class
