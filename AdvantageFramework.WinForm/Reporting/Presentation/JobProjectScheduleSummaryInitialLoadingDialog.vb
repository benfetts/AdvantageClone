Namespace Reporting.Presentation

	Public Class JobProjectScheduleSummaryInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
		Private _FilterString As String = ""
        Private _Criteria As Integer = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

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
		Private ReadOnly Property Criteria As Integer
			Get
				Criteria = _Criteria
			End Get
		End Property
		Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
			Get
				ParameterDictionary = _ParameterDictionary
			End Get
		End Property

#End Region

#Region " Methods "

        Private Sub New(DynamicReport As AdvantageFramework.Reporting.DynamicReports, ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DynamicReport = DynamicReport

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef Criteria As Integer, ByRef FilterString As String, ByRef [From] As Date, ByRef [To] As Date, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim JobProjectScheduleSummaryInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.JobProjectScheduleSummaryInitialLoadingDialog = Nothing

            JobProjectScheduleSummaryInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.JobProjectScheduleSummaryInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = JobProjectScheduleSummaryInitialLoadingDialog.ShowDialog()

            Criteria = JobProjectScheduleSummaryInitialLoadingDialog.Criteria
            FilterString = JobProjectScheduleSummaryInitialLoadingDialog.FilterString
            [From] = JobProjectScheduleSummaryInitialLoadingDialog.[From]
            [To] = JobProjectScheduleSummaryInitialLoadingDialog.[To]
            ParameterDictionary = JobProjectScheduleSummaryInitialLoadingDialog.ParameterDictionary

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobProjectScheduleSummaryInitialLoadingDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            If _DynamicReport = DynamicReports.JobProjectScheduleSummary Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobProjectScheduleSummaryInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = True
            ElseIf _DynamicReport = DynamicReports.JobSummary Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobSummaryInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = True
            ElseIf _DynamicReport = DynamicReports.ProjectHoursUsed Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectHoursUsedInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = True
            ElseIf _DynamicReport = DynamicReports.ProjectSchedule OrElse _DynamicReport = DynamicReports.ProjectScheduleTasksByEmployee Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectScheduleInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = True
            ElseIf _DynamicReport = DynamicReports.ProjectSummary Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = False
            ElseIf _DynamicReport = DynamicReports.ProjectSummaryTask Then
                ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ProjectSummaryTaskInitialCriteria), False)
                CheckBoxForm_IncludeClosedJobs.Visible = False
            End If

            CDPChooserControl_Production.LoadControl()
            AEChooserControl_Production.LoadControl()
            SalesClassChooserControl1.LoadControl()
            JobTypeChooserControl1.LoadControl()

            Me.CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Visible = False
            Me.CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)



                End Using

            End Using



        End Sub
        Private Sub JobProjectScheduleSummaryInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControl_Production.ForceResize()
            AEChooserControl_Production.ForceResize()
            SalesClassChooserControl1.ForceResize()
            JobTypeChooserControl1.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary("IncludeClosedJobs") = CheckBoxForm_IncludeClosedJobs.Checked
                _ParameterDictionary("ClientCodes") = CDPChooserControl_Production.ClientCodeList
                _ParameterDictionary("DivisionCodes") = CDPChooserControl_Production.DivisionCodeList
                _ParameterDictionary("ProductCodes") = CDPChooserControl_Production.ProductCodeList

                _ParameterDictionary("AECodes") = AEChooserControl_Production.AccountExecutiveCodeList
                _ParameterDictionary("SalesClassCodes") = SalesClassChooserControl1.SalesClassCodeList
                _ParameterDictionary("JobTypeCodes") = JobTypeChooserControl1.JobTypeCodeList



                '_ParameterDictionary("ClientCodes") = DataGridViewForm_Clients.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                '_FilterString = AdvantageFramework.Reporting.CreateFilterStringForDynamicReport(_DynamicReport, CInt(ComboBoxForm_Criteria.SelectedValue))
                _FilterString = String.Empty
                _Criteria = ComboBoxForm_Criteria.GetSelectedValue

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_YTD_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub




#End Region

#End Region

    End Class

End Namespace