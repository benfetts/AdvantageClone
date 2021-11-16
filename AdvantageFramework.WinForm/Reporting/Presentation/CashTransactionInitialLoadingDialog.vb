Namespace Reporting.Presentation

    Public Class CashTransactionInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.CashTransaction
        Private _ShowReportOption As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _ReportType = ReportType
            _DynamicReport = DynamicReport
            _ShowReportOption = ShowReportOption

        End Sub
        Private Sub LoadBanks()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectBanks_Banks.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadWithOfficeLimits(DbContext, Me.Session)
                                                            Select [Code] = Entity.Code,
                                                                   [Name] = Entity.Description).ToList

                DataGridViewSelectBanks_Banks.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim CashTransactionInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.CashTransactionInitialLoadingDialog = Nothing

            CashTransactionInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.CashTransactionInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = CashTransactionInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = CashTransactionInitialLoadingDialog.ParameterDictionary
                ReportType = CashTransactionInitialLoadingDialog.ReportType

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CashTransactionInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DateTimePicker_StatementCutoff.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxMonthly_FromMonth.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxMonthly_ToMonth.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                If _ParameterDictionary IsNot Nothing Then

                    Try
                        DateTimePicker_StatementCutoff.Value = _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.StatementCutoff.ToString)
                    Catch ex As Exception
                        DateTimePicker_StatementCutoff.Value = Now
                    End Try

                    CheckBoxIncludeReceipts.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeReceipts.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeReceipts.ToString) = 1, True, False)
                    CheckBoxIncludeDisbursements.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeDisbursements.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeDisbursements.ToString) = 1, True, False)
                    CheckBoxGLEntries.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeGLEntries.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeGLEntries.ToString) = 1, True, False)
                    RadioButtonInclude_ClearedandUncleared.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString) = 1, True, False)
                    RadioButtonInclude_UnclearedOnly.Checked = Not RadioButtonInclude_ClearedandUncleared.Checked


                Else
                    ComboBoxMonthly_FromMonth.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    ComboBoxMonthly_ToMonth.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                    RadioButtonInclude_ClearedandUncleared.Checked = True
                    RadioButtonInclude_UnclearedOnly.Checked = False
                    CheckBoxIncludeReceipts.Checked = True
                    CheckBoxIncludeDisbursements.Checked = True
                    CheckBoxGLEntries.Checked = True
                    DateTimePicker_StatementCutoff.Value = Now
                End If

                PanelForm_TopSection.Visible = _ShowReportOption

                Me.CheckBoxIncludeReceipts.Checked = True
                Me.CheckBoxIncludeDisbursements.Checked = True
                Me.CheckBoxGLEntries.Checked = True

                If RadioButtonInclude_ClearedandUncleared.Checked = True Then
                    Me.DateTimePicker_StatementCutoff.Enabled = False
                End If

                If _ShowReportOption Then

                    ComboBoxTopSection_Report.SetRequired(True)
                    ComboBoxTopSection_Report.DisplayName = "Report"

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click


            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _ShowReportOption Then

                    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.StartPeriod.ToString) = ComboBoxMonthly_FromMonth.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.EndPeriod.ToString) = ComboBoxMonthly_ToMonth.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.StatementCutoff.ToString) = DateTimePicker_StatementCutoff.Value

                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeReceipts.ToString) = CheckBoxIncludeReceipts.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeDisbursements.ToString) = CheckBoxIncludeDisbursements.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeGLEntries.ToString) = CheckBoxGLEntries.CheckValue

                If RadioButtonInclude_ClearedandUncleared.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString) = 1

                ElseIf RadioButtonInclude_UnclearedOnly.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString) = 2

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString) = Nothing

                End If

                If RadioButtonSelectBanks_AllBanks.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.SelectedBanks.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.SelectedBanks.ToString) = DataGridViewSelectBanks_Banks.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

                If _ShowReportOption Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then



            End If

        End Sub
        Private Sub RadioButtonSelectBanks_ChooseBanks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectBanks_ChooseBanks.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectBanks_ChooseBanks.Checked Then

                    If DataGridViewSelectBanks_Banks.HasRows = False Then

                        LoadBanks()

                    End If

                    DataGridViewSelectBanks_Banks.Enabled = True

                End If

            End If

        End Sub


        Private Sub RadioButtonInclude_UnclearedOnly_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonInclude_UnclearedOnly.CheckedChanged
            If RadioButtonInclude_UnclearedOnly.Checked = True Then
                Me.DateTimePicker_StatementCutoff.Enabled = True
            End If
        End Sub

        Private Sub RadioButtonInclude_ClearedandUncleared_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonInclude_ClearedandUncleared.CheckedChanged
            If RadioButtonInclude_ClearedandUncleared.Checked = True Then
                Me.DateTimePicker_StatementCutoff.Enabled = False
            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace
