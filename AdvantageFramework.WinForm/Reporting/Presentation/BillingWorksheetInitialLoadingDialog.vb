Namespace Reporting.Presentation

    Public Class BillingWorksheetInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property DynamicReport As AdvantageFramework.Reporting.DynamicReports
            Get
                DynamicReport = _DynamicReport
            End Get
        End Property
        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub
        Private Sub EnableOrDisableActions()

            If TabControlForm_ReportCriteria.SelectedTab.Equals(TabItemReportCriteria_ProductionTab) Then

                If ComboBoxProduction_Report.HasASelectedValue Then

                    Select Case ComboBoxProduction_Report.GetSelectedValue

                        Case AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingWorksheetProductionSummary,
                             AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingWorksheetProductionSummaryV2

                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Checked = False
                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Enabled = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeContingency.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableTimeDetail.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableAPIODetail.Enabled = True

                        Case AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingWorksheetProductionUnbilledDetail,
                             AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingWorksheetProductionUnbilledDetailV2,
                             AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingWorksheetProductionUnbilledDetailWithComments

                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Checked = True
                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Enabled = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeContingency.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableTimeDetail.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableAPIODetail.Enabled = True

                        Case AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes.BillingApprovalBatch

                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Checked = False
                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Enabled = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeContingency.Checked = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeContingency.Enabled = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableTimeDetail.Checked = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableTimeDetail.Enabled = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableAPIODetail.Checked = False
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableAPIODetail.Enabled = False

                        Case Else

                            BillingWorksheetProductionControl.CheckBoxControl_PrintItemDetail.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeContingency.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableTimeDetail.Enabled = True
                            BillingWorksheetProductionControl.CheckBoxControl_IncludeNonBillableAPIODetail.Enabled = True

                    End Select

                End If

            End If

        End Sub
        Private Sub LoadJobs()

            'objects
            Dim ClientCodesList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If RadioButtonSelectJobs_AllJobs.Checked = False Then

                    If CDPChooserControl_Production.RadioButtonControl_AllClients.Checked = True OrElse CDPChooserControl_Production.DataGridViewControl_Clients.HasASelectedRow = False Then

                        DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext)
                                                                  Select [Number] = Entity.Number,
                                                                         [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                    Else

                        SelectedCodeList = CDPChooserControl_Production.ClientCodeList

                        If SelectedCodeList IsNot Nothing Then

                            If CDPChooserControl_Production.RadioButtonControl_ChooseClients.Checked Then

                                DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                          Where SelectedCodeList.Contains(Entity.ClientCode) = True
                                                                          Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                            ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Checked Then

                                DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                          Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True
                                                                          Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                            ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                                DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                          Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True
                                                                          Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                            End If

                        End If

                    End If

                Else

                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Job)
                                                              Select [Number] = Entity.Number,
                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                End If

                DataGridViewSelectJobs_Jobs.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim BillingWorksheetInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.BillingWorksheetInitialLoadingDialog = Nothing

            BillingWorksheetInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.BillingWorksheetInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = BillingWorksheetInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                DynamicReport = BillingWorksheetInitialLoadingDialog.DynamicReport
                ParameterDictionary = BillingWorksheetInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingWorksheetInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxProduction_Report.DisplayName = "Report"
            ComboBoxMedia_Report.DisplayName = "Report"

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ComboBoxProduction_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.BillingWorksheetProductionReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                ComboBoxMedia_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.BillingWorksheetMediaReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            End Using

            BillingWorksheetProductionControl.LoadControl()

            BillingBatchChooserControl_Production.LoadControl(WinForm.Presentation.Controls.BillingBatchChooserControl.BatchType.Production)
            CDPChooserControl_Production.LoadControl()
            AEChooserControl_Production.LoadControl()

            BillingWorksheetMediaControl.LoadControl()
            BillingBatchChooserControl_Media.LoadControl(WinForm.Presentation.Controls.BillingBatchChooserControl.BatchType.Media)
            CDPChooserControl_Media.LoadControl()
            AEChooserControl_Media.LoadControl()

            Me.ShowUnsavedChangesOnFormClosing = False

            EnableOrDisableActions()

        End Sub
        Private Sub BillingWorksheetInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            BillingBatchChooserControl_Production.ForceResize()
            CDPChooserControl_Production.ForceResize()
            AEChooserControl_Production.ForceResize()

            BillingBatchChooserControl_Media.ForceResize()
            CDPChooserControl_Media.ForceResize()
            AEChooserControl_Media.ForceResize()

            BillingWorksheetProductionControl.ForceResize()
        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BillingBatchChooserControl_Media_BatchDeselected() Handles BillingBatchChooserControl_Media.BatchDeselected

            TabItemMediaCriteria_SelectAccountExecutivesTab.Visible = True
            TabItemMediaCriteria_SelectClientsTab.Visible = True

            BillingWorksheetMediaControl.Enabled = True

        End Sub
        Private Sub BillingBatchChooserControl_Media_BatchSelected(BillingCommandCenterID As Integer) Handles BillingBatchChooserControl_Media.BatchSelected

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            TabItemMediaCriteria_SelectAccountExecutivesTab.Visible = False
            TabItemMediaCriteria_SelectClientsTab.Visible = False

            CDPChooserControl_Media.RadioButtonControl_AllClients.Checked = True
            AEChooserControl_Media.RadioButtonControl_AllAccountExecutives.Checked = True

            Using DbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(DbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    BillingWorksheetMediaControl.ComboBoxControl_SelectBy.SelectedValue = BillingCommandCenter.DateCuttoffToUseFlag

                    BillingWorksheetMediaControl.CheckBoxMediaType_Internet.Checked = BillingCommandCenter.IsInternet.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaType_Magazine.Checked = BillingCommandCenter.IsMagazine.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaType_Newspaper.Checked = BillingCommandCenter.IsNewspaper.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaType_OutOfHome.Checked = BillingCommandCenter.IsOutOfHome.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaType_RadioDaily.Checked = BillingCommandCenter.IsRadioDaily.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaType_TelevisionDaily.Checked = BillingCommandCenter.IsTelevisionDaily.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.DateTimePickerMediaType_DateFrom.ValueObject = BillingCommandCenter.MediaStartDate
                    BillingWorksheetMediaControl.DateTimePickerMediaType_DateTo.ValueObject = BillingCommandCenter.MediaEndDate

                    BillingWorksheetMediaControl.CheckBoxMediaBroadcast_Radio.Checked = BillingCommandCenter.IsRadioMonthly.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxMediaBroadcast_Television.Checked = BillingCommandCenter.IsTelevisionMonthly.GetValueOrDefault(False)

                    If BillingCommandCenter.MediaBroadcastMonthStart.HasValue Then

                        BillingWorksheetMediaControl.ComboBoxMediaBroadcast_MonthFrom.SelectedValue = CLng(BillingCommandCenter.MediaBroadcastMonthStart.Value.Month)

                    End If

                    If BillingCommandCenter.MediaBroadcastMonthEnd.HasValue Then

                        BillingWorksheetMediaControl.ComboBoxMediaBroadcast_MonthTo.SelectedValue = CLng(BillingCommandCenter.MediaBroadcastMonthEnd.Value.Month)

                    End If

                    BillingWorksheetMediaControl.NumericInputMediaBroadcast_YearFrom.EditValue = If(BillingCommandCenter.MediaBroadcastMonthStart.HasValue, BillingCommandCenter.MediaBroadcastMonthStart.Value.Year, Nothing)
                    BillingWorksheetMediaControl.NumericInputMediaBroadcast_YearTo.EditValue = If(BillingCommandCenter.MediaBroadcastMonthEnd.HasValue, BillingCommandCenter.MediaBroadcastMonthEnd.Value.Year, Nothing)


                    If BillingCommandCenter.JobMediaBillDateFrom.HasValue Then

                        BillingWorksheetMediaControl.DateTimePickerJobMedia_DateFrom.ValueObject = BillingCommandCenter.JobMediaBillDateFrom.Value

                    End If

                    If BillingCommandCenter.JobMediaBillDateTo.HasValue Then

                        BillingWorksheetMediaControl.DateTimePickerJobMedia_DateTo.ValueObject = BillingCommandCenter.JobMediaBillDateTo.Value

                    End If

                    BillingWorksheetMediaControl.CheckBoxControl_IncludeUnbilledOrdersOnly.Checked = CBool(BillingCommandCenter.IncludeUnbilledOrdersOnly.GetValueOrDefault(0))
                    BillingWorksheetMediaControl.CheckBoxxControl_IncludeSpots.Checked = BillingCommandCenter.IncludeZeroSpots.GetValueOrDefault(False)
                    BillingWorksheetMediaControl.CheckBoxControl_OmitZeroUnbilledAmounts.Checked = False

                    BillingWorksheetMediaControl.Enabled = False

                End If

            End Using

        End Sub
        Private Sub BillingBatchChooserControl_Production_BatchDeselected() Handles BillingBatchChooserControl_Production.BatchDeselected

            TabItemProductionCriteria_SelectAccountExecutivesTab.Visible = True
            TabItemProductionCriteria_SelectClientsTab.Visible = True

            BillingWorksheetProductionControl.GroupBoxControl_Cutoffs.Enabled = True
            BillingWorksheetProductionControl.GroupBoxControl_JobOptions.Enabled = True
            BillingWorksheetProductionControl.GroupBoxControl_JobType.Enabled = True

        End Sub
        Private Sub BillingBatchChooserControl_Production_BatchSelected(BillingCommandCenterID As Integer) Handles BillingBatchChooserControl_Production.BatchSelected

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            TabItemProductionCriteria_SelectAccountExecutivesTab.Visible = False
            TabItemProductionCriteria_SelectClientsTab.Visible = False

            CDPChooserControl_Production.RadioButtonControl_AllClients.Checked = True
            AEChooserControl_Production.RadioButtonControl_AllAccountExecutives.Checked = True

            Using DbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(DbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    BillingWorksheetProductionControl.DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = BillingCommandCenter.EmployeeTimeDateCutoff
                    BillingWorksheetProductionControl.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ValueObject = BillingCommandCenter.IncomeOnlyDateCutoff
                    BillingWorksheetProductionControl.ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = BillingCommandCenter.APPostPeriodCodeCutoff

                    BillingWorksheetProductionControl.GroupBoxControl_Cutoffs.Enabled = False
                    BillingWorksheetProductionControl.GroupBoxControl_JobOptions.Enabled = False
                    BillingWorksheetProductionControl.GroupBoxControl_JobType.Enabled = False

                End If

            End Using

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If TabControlForm_ReportCriteria.SelectedTab.Equals(TabItemReportCriteria_ProductionTab) Then

                    _ParameterDictionary = BillingWorksheetProductionControl.ParameterDictionary
                    _DynamicReport = ComboBoxProduction_Report.GetSelectedValue

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedDivisions.ToString) = CDPChooserControl_Production.DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedProducts.ToString) = CDPChooserControl_Production.ProductCodeList

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedAccountExecutives.ToString) = AEChooserControl_Production.AccountExecutiveCodeList

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.BillingCommandCenterID.ToString) = BillingBatchChooserControl_Production.BillingCommandCenterID

                    If RadioButtonSelectJobs_AllJobs.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedJobs.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedJobs.ToString) = DataGridViewSelectJobs_Jobs.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                    End If

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _DynamicReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                ElseIf TabControlForm_ReportCriteria.SelectedTab.Equals(TabItemReportCriteria_MediaTab) Then

                    If BillingWorksheetMediaControl.ValidateControl(ErrorMessage) Then

                        _ParameterDictionary = BillingWorksheetMediaControl.ParameterDictionary
                        _DynamicReport = ComboBoxMedia_Report.GetSelectedValue

                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedClients.ToString) = CDPChooserControl_Media.ClientCodeList
                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedDivisions.ToString) = CDPChooserControl_Media.DivisionCodeList
                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedProducts.ToString) = CDPChooserControl_Media.ProductCodeList

                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedAccountExecutives.ToString) = AEChooserControl_Media.AccountExecutiveCodeList

                        _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BillingCommandCenterID.ToString) = BillingBatchChooserControl_Media.BillingCommandCenterID

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _DynamicReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

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
        Private Sub ComboBoxProduction_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxProduction_Report.SelectedValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_ReportCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ReportCriteria.SelectedTabChanged

            ComboBoxProduction_Report.SetRequired(e.NewTab.Equals(TabItemReportCriteria_ProductionTab))

            ComboBoxMedia_Report.SetRequired(e.NewTab.Equals(TabItemReportCriteria_MediaTab))

        End Sub

        Private Sub RadioButtonSelectJobs_ChooseJobs_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectJobs_ChooseJobs.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectJobs_ChooseJobs.Checked Then

                    LoadJobs()

                    PanelSelectJobs_JobStatus.Enabled = True
                    DataGridViewSelectJobs_Jobs.Enabled = True

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectJobs_AllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectJobs_AllJobs.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectJobs_AllJobs.Checked Then

                    PanelSelectJobs_JobStatus.Enabled = False
                    DataGridViewSelectJobs_Jobs.Enabled = False

                End If

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace