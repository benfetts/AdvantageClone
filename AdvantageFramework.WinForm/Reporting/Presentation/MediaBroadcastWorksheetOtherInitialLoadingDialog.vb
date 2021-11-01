Namespace Reporting.Presentation

    Public Class MediaBroadcastWorksheetOtherInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetOtherCriteriaViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Reporting.MediaBroadcastWorksheetOtherCriteriaController = Nothing
        Private _MediaBroadcastWorksheetID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID

        End Sub
        Private Sub LoadViewModel()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            ComboBoxTopSection_Report.DataSource = _ViewModel.Reports

            DataGridViewForm_Markets.DataSource = _ViewModel.WorksheetMarkets

            For Each GridColumn In DataGridViewForm_Markets.CurrentView.Columns

                If GridColumn.FieldName = DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketCode.ToString OrElse
                        GridColumn.FieldName = DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MarketDescription.ToString OrElse
                        GridColumn.FieldName = DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.IsCable.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False

                End If

            Next

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

            DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketVendors

            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

            DateEditForm_StartDate.Properties.MinValue = _ViewModel.MediaBroadcastWorksheetStartDate
            DateEditForm_StartDate.Properties.MaxValue = DateAdd(DateInterval.Day, -6, _ViewModel.MediaBroadcastWorksheetEndDate)
            DateEditForm_StartDate.EditValue = _ViewModel.MediaBroadcastWorksheetStartDate

            DateEditForm_EndDate.Properties.MinValue = DateAdd(DateInterval.Day, 6, _ViewModel.MediaBroadcastWorksheetStartDate)
            DateEditForm_EndDate.Properties.MaxValue = _ViewModel.MediaBroadcastWorksheetEndDate
            DateEditForm_EndDate.EditValue = _ViewModel.MediaBroadcastWorksheetEndDate

            DateEditForm_StartDate.Properties.FirstDayOfWeek = DayOfWeek.Monday
            DateEditForm_EndDate.Properties.FirstDayOfWeek = DayOfWeek.Monday

            ReportOptions_CheckBoxShowRatings.Enabled = _ViewModel.HasPrimaryMediaDemographic
            ReportOptions_CheckBoxShowCPP.Enabled = _ViewModel.HasPrimaryMediaDemographic

            ReportOptions_CheckBoxShowImpressions.Enabled = _ViewModel.HasPrimaryMediaDemographic
            ReportOptions_CheckBoxShowCPM.Enabled = _ViewModel.HasPrimaryMediaDemographic

            ReportOptions_CheckBoxShowRatings.Checked = _ViewModel.HasPrimaryMediaDemographic

            ReportOptions_CheckBoxShowRate.Checked = True
            ReportOptions_CheckBoxShowTotalCost.Checked = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetOtherInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetOtherInitialLoadingDialog = Nothing

            MediaBroadcastWorksheetOtherInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetOtherInitialLoadingDialog(MediaBroadcastWorksheetID)

            ShowFormDialog = MediaBroadcastWorksheetOtherInitialLoadingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetOtherInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxTopSection_Report.SetRequired(True)
            ComboBoxTopSection_Report.DisplayName = "Report"

            DataGridViewForm_Markets.CurrentView.OptionsBehavior.Editable = False
            DataGridViewForm_Vendors.CurrentView.OptionsBehavior.Editable = False

            _Controller = New Controller.Reporting.MediaBroadcastWorksheetOtherCriteriaController(Me.Session)

        End Sub
        Private Sub MediaBroadcastWorksheetOtherInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _ViewModel = _Controller.Load(_MediaBroadcastWorksheetID)

            LoadViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = MediaBroadcastWorksheetOtherReportTypes.MarketScheduleWeeklyDetail
            Dim RunReport As Boolean = True

            If Me.Validator Then

                If DataGridViewForm_Markets.HasASelectedRow AndAlso DataGridViewForm_Vendors.HasASelectedRow Then

                    ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                    If ReportType = AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.MarketScheduleWeeklyDetail AndAlso _ViewModel.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Daily Then

                        RunReport = False

                        AdvantageFramework.WinForm.MessageBox.Show("The Market Schedule Weekly Report is not designed for Daily buys.")

                    End If

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    If RunReport AndAlso ReportType = AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.MarketScheduleWeeklyDetail Then

                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.MediaBroadcastWorksheetID.ToString) = _MediaBroadcastWorksheetID
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString) = String.Join(",", DataGridViewForm_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of DTO.Reporting.WorksheetMarketVendor).Select(Function(WMV) WMV.MediaBroadcastWorksheetMarketID & "|" & WMV.VendorCode).ToList)
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.FromDate.ToString) = DateEditForm_StartDate.EditValue.ToShortDateString
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ToDate.ToString) = DateEditForm_EndDate.EditValue.ToShortDateString

                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRatings.ToString) = ReportOptions_CheckBoxShowRatings.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPP.ToString) = ReportOptions_CheckBoxShowCPP.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowImpressions.ToString) = ReportOptions_CheckBoxShowImpressions.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowCPM.ToString) = ReportOptions_CheckBoxShowCPM.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowRates.ToString) = ReportOptions_CheckBoxShowRate.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowTotalCost.ToString) = ReportOptions_CheckBoxShowTotalCost.Checked

                        ParameterDictionary(AdvantageFramework.Reporting.MarketScheduleWeeklyDetailParameters.ShowSecondardDemo.ToString) = ReportOptions_CheckBoxShowSecondaryDemo.Enabled AndAlso ReportOptions_CheckBoxShowSecondaryDemo.Checked

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    ElseIf RunReport AndAlso ReportType = AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.UpdatedRateRequestReport Then

                        ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.MediaBroadcastWorksheetID.ToString) = _MediaBroadcastWorksheetID
                        ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString) = String.Join(",", DataGridViewForm_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of DTO.Reporting.WorksheetMarketVendor).Select(Function(WMV) WMV.MediaBroadcastWorksheetMarketID & "|" & WMV.VendorCode).ToList)

                        ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowRatingsCPP.ToString) = RadioButtonURR_ShowRatingsCPP.Checked
                        ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowImpressionsCPM.ToString) = RadioButtonURR_ShowImpressionsCPM.Checked

                        ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowSecondardDemo.ToString) = CheckBoxURR_ShowSecondaryDemo.Enabled AndAlso CheckBoxURR_ShowSecondaryDemo.Checked

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    ElseIf RunReport AndAlso ReportType = AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.TrafficFlightSummaryReport Then

                        ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.MediaBroadcastWorksheetID.ToString) = _MediaBroadcastWorksheetID
                        ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString) = String.Join(",", DataGridViewForm_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of DTO.Reporting.WorksheetMarketVendor).Select(Function(WMV) WMV.MediaBroadcastWorksheetMarketID & "|" & WMV.VendorCode).ToList)
                        ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.FromDate.ToString) = DateEditForm_StartDate.EditValue.ToShortDateString
                        ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.ToDate.ToString) = DateEditForm_EndDate.EditValue.ToShortDateString

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("At least one market and vendor must be selected.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Markets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Markets.SelectionChangedEvent

            'objects
            Dim MediaBroadcastWorksheetMarketIDs As Generic.List(Of Integer) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_Markets.HasASelectedRow Then

                    MediaBroadcastWorksheetMarketIDs = (From Entity In DataGridViewForm_Markets.GetAllSelectedRowsDataBoundItems.OfType(Of DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
                                                        Select Entity.ID).ToList

                    ReportOptions_CheckBoxShowSecondaryDemo.Enabled = (From Entity In DataGridViewForm_Markets.GetAllSelectedRowsDataBoundItems.OfType(Of DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
                                                                       Where Entity.SecondaryMediaDemographicID IsNot Nothing
                                                                       Select Entity.MarketCode).Any

                    CheckBoxURR_ShowSecondaryDemo.Enabled = ReportOptions_CheckBoxShowSecondaryDemo.Enabled

                Else

                    MediaBroadcastWorksheetMarketIDs = New Generic.List(Of Integer)

                End If

                _Controller.GetVendors(_ViewModel, MediaBroadcastWorksheetMarketIDs)

                DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketVendors

                DataGridViewForm_Vendors.CurrentView.BestFitColumns()

                DataGridViewForm_Vendors.SelectAll()

            End If

        End Sub
        Private Sub ReportOptions_CheckBoxShowRatings_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles ReportOptions_CheckBoxShowRatings.CheckedChangedEx

            ReportOptions_CheckBoxShowCPP.Enabled = e.NewChecked.Checked
            ReportOptions_CheckBoxShowCPP.Checked = e.NewChecked.Checked

        End Sub
        Private Sub ReportOptions_CheckBoxShowImpressions_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles ReportOptions_CheckBoxShowImpressions.CheckedChangedEx

            ReportOptions_CheckBoxShowCPM.Enabled = e.NewChecked.Checked
            ReportOptions_CheckBoxShowCPM.Checked = e.NewChecked.Checked

        End Sub
        Private Sub DateEditForm_StartDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles DateEditForm_StartDate.DisableCalendarDate

            If e.Date = _ViewModel.MediaBroadcastWorksheetStartDate Then

                e.IsDisabled = False

            ElseIf e.Date.DayOfWeek = DayOfWeek.Monday Then

                e.IsDisabled = False

            Else

                e.IsDisabled = True

            End If

        End Sub
        Private Sub DateEditForm_EndDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs) Handles DateEditForm_EndDate.DisableCalendarDate

            If e.Date = _ViewModel.MediaBroadcastWorksheetEndDate Then

                e.IsDisabled = False

            ElseIf e.Date.DayOfWeek = DayOfWeek.Sunday Then

                e.IsDisabled = False

            Else

                e.IsDisabled = True

            End If

        End Sub
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_Report.SelectedValueChanged

            Select Case ComboBoxTopSection_Report.GetSelectedValue()

                Case AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.MarketScheduleWeeklyDetail

                    GroupBoxUpdatedRateRequestOptions.Visible = False
                    ReportOptions_CheckBoxShowSecondaryDemo.Visible = True
                    PanelForm_Options.Visible = True

                    DateEditForm_StartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                    DateEditForm_StartDate.SetRequired(True)

                    DateEditForm_EndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                    DateEditForm_EndDate.SetRequired(True)

                Case AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.UpdatedRateRequestReport

                    GroupBoxUpdatedRateRequestOptions.Visible = True
                    ReportOptions_CheckBoxShowSecondaryDemo.Visible = True
                    PanelForm_Options.Visible = False

                    DateEditForm_StartDate.SetRequired(False)
                    DateEditForm_EndDate.SetRequired(False)

                Case AdvantageFramework.Reporting.MediaBroadcastWorksheetOtherReportTypes.TrafficFlightSummaryReport

                    GroupBoxUpdatedRateRequestOptions.Visible = False
                    ReportOptions_CheckBoxShowSecondaryDemo.Visible = False
                    PanelForm_Options.Visible = False

                    DateEditForm_StartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                    DateEditForm_StartDate.SetRequired(True)

                    DateEditForm_EndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                    DateEditForm_EndDate.SetRequired(True)

            End Select

        End Sub

#End Region

#End Region

    End Class

End Namespace
