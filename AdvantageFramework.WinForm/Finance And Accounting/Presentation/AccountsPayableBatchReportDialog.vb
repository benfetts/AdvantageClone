Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Protected _UserCode As String = Nothing
        Protected _IsBatch As Boolean = False
        Protected _IsRecurReport As Boolean = False
        Protected _DetailPageBreak As Boolean = False
        Protected _IsBatchImport As Boolean = False
        Protected _IsImportExpenseReport As Boolean = False
        Protected _BatchName As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
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
        Private ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Private ReadOnly Property DetailPageBreak As Boolean
            Get
                DetailPageBreak = _DetailPageBreak
            End Get
        End Property
        Private ReadOnly Property BatchName As String
            Get
                BatchName = _BatchName
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal UserCode As String, ByVal IsRecurReport As Boolean, ByVal IsBatchImport As Boolean, ByVal IsImportExpenseReport As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode
            _IsRecurReport = IsRecurReport
            _IsBatchImport = IsBatchImport
            _IsImportExpenseReport = IsImportExpenseReport

            RadioButtonFormat_DetailNoPageBreak.ByPassUserEntryChanged = True
            RadioButtonFormat_DetailPageBreak.ByPassUserEntryChanged = True
            RadioButtonFormat_Summary.ByPassUserEntryChanged = True
            RadioButtonFormat_SummaryDataEntryOrder.ByPassUserEntryChanged = True

            RadioButtonSelection_Batch.ByPassUserEntryChanged = True
            RadioButtonSelection_DateRange.ByPassUserEntryChanged = True
            RadioButtonSelection_Import.ByPassUserEntryChanged = True
            RadioButtonSelection_ImportBatch.ByPassUserEntryChanged = True

            DateTimePickerForm_From.ByPassUserEntryChanged = True
            DateTimePickerForm_To.ByPassUserEntryChanged = True

            ComboBoxForm_User.ByPassUserEntryChanged = True
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonSelection_Batch.Checked OrElse RadioButtonSelection_ImportBatch.Checked Then

                LabelFormDates_From.Visible = False
                LabelFormDates_To.Visible = False
                DateTimePickerForm_From.Visible = False
                DateTimePickerForm_From.SetRequired(False)
                DateTimePickerForm_To.Visible = False
                DateTimePickerForm_To.SetRequired(False)
                ComboBoxForm_Batch.SetRequired(True)

                LabelForm_Batch.Visible = True
                ComboBoxForm_Batch.Visible = True

            Else

                LabelFormDates_From.Visible = True
                LabelFormDates_To.Visible = True
                DateTimePickerForm_From.Visible = True
                DateTimePickerForm_From.SetRequired(True)
                DateTimePickerForm_To.Visible = True
                DateTimePickerForm_To.SetRequired(True)
                ComboBoxForm_Batch.SetRequired(False)

                LabelForm_Batch.Visible = False
                ComboBoxForm_Batch.Visible = False

            End If

        End Sub
        Private Sub LoadBatchesForUser()

            Dim AfterDate As Date = Nothing
            Dim BatchNameList As IEnumerable(Of String) = Nothing
            Dim UserCode As String = Nothing

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading AndAlso ComboBoxForm_User.HasASelectedValue Then

                ComboBoxForm_Batch.DataSource = Nothing
                ComboBoxForm_Batch.ControlType = WinForm.Presentation.Controls.ComboBox.Type.Default

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _IsRecurReport Then

                        ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadRecurBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                    ElseIf _IsImportExpenseReport Then

                        AfterDate = DateAdd(DateInterval.Day, -30, Now)
                        UserCode = ComboBoxForm_User.GetSelectedValue

                        ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadExpenseImportBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue).Union _
                                (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                 Where Entity.ModifiedBy.ToUpper = UserCode.ToUpper AndAlso
                                       Entity.BatchDate IsNot Nothing AndAlso
                                       Entity.BatchDate >= AfterDate
                                 Select Entity.BatchDate.Value).Distinct.OrderByDescending(Function(BatchDate) BatchDate).ToList

                    ElseIf _IsBatchImport Then

                        BatchNameList = AdvantageFramework.Database.Procedures.AccountPayable.LoadBatchNamesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                        If BatchNameList IsNot Nothing AndAlso BatchNameList.Count > 0 Then

                            ComboBoxForm_Batch.DataSource = AdvantageFramework.Importing.GetBatchNamesOrderedByDateDescending(BatchNameList)
                            ComboBoxForm_Batch.ControlType = WinForm.Presentation.Controls.ComboBox.Type.KeyValuePair

                        End If

                    Else

                        ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                    End If

                    If Not _IsBatchImport Then

                        ComboBoxForm_Batch.ControlType = WinForm.Presentation.Controls.ComboBox.Type.Date

                    End If

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef [From] As Date, ByRef [To] As Date, ByRef UserCode As String,
                                              ByRef IsBatch As Boolean, ByRef IsImport As Boolean, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog = Nothing

            AccountsPayableBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog(UserCode, False, False, False)

            ShowFormDialog = AccountsPayableBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ReportType = AccountsPayableBatchReportDialog.ReportType
                [From] = AccountsPayableBatchReportDialog.[From].ToShortDateString
                [To] = AccountsPayableBatchReportDialog.[To].ToShortDateString
                UserCode = AccountsPayableBatchReportDialog.UserCode
                DetailPageBreak = AccountsPayableBatchReportDialog.DetailPageBreak

                If AccountsPayableBatchReportDialog.RadioButtonSelection_Batch.Checked Then

                    IsBatch = True
                    [From] = CDate(AccountsPayableBatchReportDialog.BatchName)

                ElseIf AccountsPayableBatchReportDialog.RadioButtonSelection_Import.Checked Then

                    IsImport = True

                End If

            End If

        End Function
        Public Shared Function ShowFormDialog(ByRef BatchDate As Date, ByRef UserCode As String, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog = Nothing

            AccountsPayableBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog(UserCode, True, False, False)

            ShowFormDialog = AccountsPayableBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                BatchDate = CDate(AccountsPayableBatchReportDialog.BatchName)
                UserCode = AccountsPayableBatchReportDialog.UserCode
                DetailPageBreak = AccountsPayableBatchReportDialog.DetailPageBreak

            End If

        End Function
        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef UserCode As String, ByRef BatchName As String, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog = Nothing

            AccountsPayableBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog(UserCode, False, True, False)

            ShowFormDialog = AccountsPayableBatchReportDialog.ShowDialog()

            ReportType = AccountsPayableBatchReportDialog.ReportType
            BatchName = AccountsPayableBatchReportDialog.BatchName
            UserCode = AccountsPayableBatchReportDialog.UserCode
            DetailPageBreak = AccountsPayableBatchReportDialog.DetailPageBreak

        End Function
        Public Shared Function ShowFormDialog(ByRef UserCode As String, ByRef BatchDate As Date, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog = Nothing

            AccountsPayableBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog(UserCode, False, False, True)

            ShowFormDialog = AccountsPayableBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                BatchDate = CDate(AccountsPayableBatchReportDialog.BatchName)
                UserCode = AccountsPayableBatchReportDialog.UserCode
                DetailPageBreak = AccountsPayableBatchReportDialog.DetailPageBreak

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True

            ComboBoxForm_User.SetRequired(True)

            Using DbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(DbContext).OrderBy(Function(U) U.UserCode)

            End Using

            If Me.Session.UseWindowsAuthentication Then

                ComboBoxForm_User.SelectedValue = Me.Session.UserName

            Else

                ComboBoxForm_User.SelectedValue = Me.Session.UserCode.ToUpper

            End If
            
            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            LoadBatchesForUser()

            If _IsRecurReport OrElse _IsImportExpenseReport Then

                RadioButtonSelection_Batch.Checked = True

                RadioButtonSelection_DateRange.Visible = False
                RadioButtonSelection_DateRange.Enabled = False

                RadioButtonSelection_ImportBatch.Visible = False
                RadioButtonSelection_ImportBatch.Enabled = False

                RadioButtonSelection_Import.Visible = False
                RadioButtonSelection_Import.Enabled = False

                RadioButtonFormat_DetailNoPageBreak.Checked = True

                RadioButtonFormat_Summary.Visible = False
                RadioButtonFormat_Summary.Enabled = False
                RadioButtonFormat_SummaryDataEntryOrder.Visible = False
                RadioButtonFormat_SummaryDataEntryOrder.Enabled = False

                If _IsImportExpenseReport Then

                    RadioButtonFormat_DetailNoPageBreak.Text = "Detail"
                    RadioButtonFormat_DetailPageBreak.Visible = True

                End If

            ElseIf _IsBatchImport Then

                RadioButtonSelection_ImportBatch.Checked = True

                RadioButtonSelection_Batch.Enabled = False
                RadioButtonSelection_DateRange.Enabled = False
                RadioButtonSelection_Import.Enabled = False

            Else

                RadioButtonSelection_ImportBatch.Enabled = False

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If RadioButtonFormat_DetailNoPageBreak.Checked Then

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchDetail
                    _DetailPageBreak = False

                ElseIf RadioButtonFormat_DetailPageBreak.Checked Then

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchDetail
                    _DetailPageBreak = True

                ElseIf RadioButtonFormat_Summary.Checked Then

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummary
                    _DetailPageBreak = False

                ElseIf RadioButtonFormat_SummaryDataEntryOrder.Checked Then

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder
                    _DetailPageBreak = False

                End If

                _UserCode = ComboBoxForm_User.GetSelectedValue

                If ComboBoxForm_Batch.ControlType = WinForm.Presentation.Controls.ComboBox.Type.Date Then

                    _BatchName = ComboBoxForm_Batch.GetSelectedValue

                Else

                    _BatchName = ComboBoxForm_Batch.Text

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub
        Private Sub RadioButtonSelection_Batch_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButtonSelection_Batch.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonSelection_DateRange_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonSelection_DateRange.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxForm_User_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_User.SelectedValueChanged

            LoadBatchesForUser()

        End Sub

#End Region

#End Region

    End Class

End Namespace