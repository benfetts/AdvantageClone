Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar

Public Class Reporting_InitialLoadingMediaTrafficInstructions
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
    Protected _ViewModel As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel = Nothing
    Protected _Controller As AdvantageFramework.Controller.Reporting.MediaTrafficInstructionsCriteriaController = Nothing


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

    Private Sub RefreshViewModel()

        RadGridMediaBroadcastWorksheets.Rebind()

    End Sub

    Private Sub SaveViewModel()

        _ViewModel.StartDate = RadDatePickerStartDate.SelectedDate
        _ViewModel.EndDate = RadDatePickerEndDate.SelectedDate

        _ViewModel.IncludeInactiveWorksheets = CheckBoxIncludeInactiveWorksheets.Checked
        _ViewModel.IncludeAllMediaTrafficRevisions = CheckBoxIncludeAllMediaTrafficRevisions.Checked

    End Sub

    Private Sub Save()

        'If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

        '    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing)

        SaveViewModel()

        _Controller.RefreshWorksheets(_ViewModel)

        RefreshViewModel()

        '    Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

        'End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingMediaTrafficInstructions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        _Controller = New AdvantageFramework.Controller.Reporting.MediaTrafficInstructionsCriteriaController(_Session)

        _ViewModel = _Controller.Load(Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions)

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                Me.Title = "Media Traffic Missing Instructions Criteria"

                LabelLegend.Text = "Spot Date Range"

                CheckBoxIncludeAllMediaTrafficRevisions.Visible = False

            End If

            RadDatePickerStartDate.SelectedDate = _ViewModel.StartDate
            RadDatePickerEndDate.SelectedDate = _ViewModel.EndDate

            CheckBoxIncludeInactiveWorksheets.Checked = _ViewModel.IncludeInactiveWorksheets
            CheckBoxIncludeAllMediaTrafficRevisions.Checked = _ViewModel.IncludeAllMediaTrafficRevisions

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        'objects
        Dim MediaBroadcastWorksheetMarketIDList As Generic.List(Of Integer) = Nothing

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                MediaBroadcastWorksheetMarketIDList = New Generic.List(Of Integer)
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMediaBroadcastWorksheets.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        MediaBroadcastWorksheetMarketIDList.Add(gridDataItem.GetDataKeyValue("MediaBroadcastWorksheetMarketID"))
                    End If
                Next

                If Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficMissingInstructions Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficMissingInstructionsInitialCriteria.MediaBroadcastWorksheetMarketIDs.ToString) = MediaBroadcastWorksheetMarketIDList

                ElseIf Session("DRPT_Type") = AdvantageFramework.Reporting.DynamicReports.MediaTrafficInstructions Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficInstructionsInitialCriteria.MediaBroadcastWorksheetMarketIDs.ToString) = MediaBroadcastWorksheetMarketIDList
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficInstructionsInitialCriteria.IncludeAllMediaTrafficRevisions.ToString) = _ViewModel.IncludeAllMediaTrafficRevisions

                End If

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

    Private Sub RadGridMediaBroadcastWorksheets_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridMediaBroadcastWorksheets.NeedDataSource

        RadGridMediaBroadcastWorksheets.DataSource = _ViewModel.MediaBroadcastWorksheets

    End Sub

    Private Sub CheckBoxIncludeAllMediaTrafficRevisions_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeAllMediaTrafficRevisions.CheckedChanged
        Save()
    End Sub

    Private Sub CheckBoxIncludeInactiveWorksheets_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeInactiveWorksheets.CheckedChanged
        Save()
    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Save()
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Save()
    End Sub

    Private Sub RadGridMediaBroadcastWorksheets_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridMediaBroadcastWorksheets.ItemDataBound
        Try
            Select Case e.Item.ItemType

                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                    Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)

                    Dim IsCable As Boolean = CurrentRow.GetDataKeyValue("IsCable")
                    Dim IsInactive As Boolean = CurrentRow.GetDataKeyValue("IsInactive")

                    If IsCable = True Then
                        CurrentRow("column7").Text = "Yes"
                    Else
                        CurrentRow("column7").Text = "No"
                    End If

                    If IsInactive = True Then
                        CurrentRow("column10").Text = "Yes"
                    Else
                        CurrentRow("column10").Text = "No"
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
