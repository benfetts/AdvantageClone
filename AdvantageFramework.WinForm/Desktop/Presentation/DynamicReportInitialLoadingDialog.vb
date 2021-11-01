Namespace Desktop.Presentation

    Public Class DynamicReportInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FilterString As String = ""
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime
        Private _Criteria As Integer = Nothing
        Private _From As Date = Nothing
        Private _To As Date = Nothing
        Private _ShowJobsWithNoDetails As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property FilterString As String
            Get
                FilterString = _FilterString
            End Get
        End Property
        Private ReadOnly Property [From] As Date
            Get
                [From] = DateTimePickerForm_From.Value
            End Get
        End Property
        Private ReadOnly Property [To] As Date
            Get
                [To] = DateTimePickerForm_To.Value
            End Get
        End Property
        Private ReadOnly Property ShowJobsWithNoDetails As Boolean
            Get
                ShowJobsWithNoDetails = CheckBoxForm_ShowJobsWithNoDetails.Checked
            End Get
        End Property
        Private ReadOnly Property Criteria As Integer
            Get
                Criteria = _Criteria
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, Criteria As Integer, [From] As Date, [To] As Date, ShowJobsWithNoDetails As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DynamicReport = DynamicReport
            _Criteria = Criteria
            _From = From
            _To = [To]
            _ShowJobsWithNoDetails = ShowJobsWithNoDetails

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef Criteria As Integer, ByRef FilterString As String, ByRef [From] As Date, ByRef [To] As Date, ByRef ShowJobsWithNoDetails As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim DynamicReportInitialLoadingDialog As AdvantageFramework.Desktop.Presentation.DynamicReportInitialLoadingDialog = Nothing

            DynamicReportInitialLoadingDialog = New AdvantageFramework.Desktop.Presentation.DynamicReportInitialLoadingDialog(DynamicReport, Criteria, [From], [To], ShowJobsWithNoDetails)

            ShowFormDialog = DynamicReportInitialLoadingDialog.ShowDialog()

            Criteria = DynamicReportInitialLoadingDialog.Criteria
            FilterString = DynamicReportInitialLoadingDialog.FilterString
            [From] = DynamicReportInitialLoadingDialog.[From]
            [To] = DynamicReportInitialLoadingDialog.[To]
            ShowJobsWithNoDetails = DynamicReportInitialLoadingDialog.ShowJobsWithNoDetails

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DynamicReportInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            If _DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTime Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectIndirectTimeInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectTime Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectTimeInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectIndirectTimeWithEmployeeCost Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectIndirectTimeInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.DirectTimeWithEmployeeCost Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectTimeInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailBillMonthInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailFunctionInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailItemInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobProjectScheduleSummary Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobProjectScheduleSummaryInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobSummary Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobSummaryInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectHoursUsed Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectHoursUsedInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSchedule Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectScheduleInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummary Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectSummaryTask Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryTaskInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMOpportunityDetailInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMOpportunityToInvestmentInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.CRMClientContractsInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobPurchaseOrder Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobPurchaseOrderInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.AuthorizationToBuy Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.AuthorizationToBuyInitialCriteria), False, True)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeApproval Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.EmployeeTimeApprovalCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DigitalResultsCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ServiceFeeContract Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobServiceFeeCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.IncomeOnly Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.IncomeOnlyCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ExpenseCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorContracts Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.VendorContractsInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.TimeReport Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.TimeReportInitialCriteria), False)

            ElseIf _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ProjectScheduleTasksByEmployee Then

                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectScheduleTasksByEmployeeInitialCriteria), False)

            End If

            If _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetail OrElse
                    _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailBillMonth OrElse
                    _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailFunction OrElse
                    _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItem OrElse
                    _DynamicReport = AdvantageFramework.Reporting.DynamicReports.JobDetailItemAccountSplit Then

                CheckBoxForm_ShowJobsWithNoDetails.Visible = True

            Else

                CheckBoxForm_ShowJobsWithNoDetails.Visible = False

            End If

            If _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityDetail OrElse
                _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMOpportunityToInvestment OrElse
                _DynamicReport = AdvantageFramework.Reporting.DynamicReports.CRMClientContracts OrElse
                _DynamicReport = AdvantageFramework.Reporting.DynamicReports.VendorContracts Then

                LabelForm_From.Text = "After:"
                LabelForm_To.Visible = False
                DateTimePickerForm_To.Visible = False
				DateTimePickerForm_From.MaxDate = New Date(2113, 12, 31)
				ButtonForm_1Year.Visible = False
                ButtonForm_2Years.Visible = False
                ButtonForm_MTD.Visible = False
                ButtonForm_YTD.Visible = False

            End If

            If _DynamicReport = AdvantageFramework.Reporting.DynamicReports.ExpenseReportAndApproval Then

                Me.CheckBoxForm_ShowJobsWithNoDetails.Visible = False

            End If

            If _Criteria > 0 Then
                ComboBoxForm_Criteria.SelectedValue = _Criteria
            End If

            If _From.Year <> 1 Then

                DateTimePickerForm_From.ValueObject = _From

            End If

            If _To.Year <> 1 Then

                DateTimePickerForm_To.ValueObject = _To

            End If

            CheckBoxForm_ShowJobsWithNoDetails.Checked = _ShowJobsWithNoDetails

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                _FilterString = AdvantageFramework.Reporting.CreateFilterStringForDynamicReport(_DynamicReport, CInt(ComboBoxForm_Criteria.SelectedValue))
                _Criteria = ComboBoxForm_Criteria.GetSelectedValue

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub

#End Region

#End Region

    End Class

End Namespace