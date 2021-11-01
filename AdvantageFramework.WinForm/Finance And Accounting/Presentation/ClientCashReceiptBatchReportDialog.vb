Namespace FinanceAndAccounting.Presentation

    Public Class ClientCashReceiptBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum CashReceiptBatchReportType
            ClientCashReceipt
            OtherCashReceipt
            ClientCashReceiptImport
        End Enum

#End Region

#Region " Variables "

        Protected _ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Protected _UserCode As String = Nothing
        Protected _IsBatch As Boolean = False
        Protected _BatchName As String = Nothing
        Protected _BatchReportType As CashReceiptBatchReportType = CashReceiptBatchReportType.ClientCashReceipt
        Protected _DetailPageBreak As Boolean = False

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
        Private ReadOnly Property BatchName As String
            Get
                BatchName = _BatchName
            End Get
        End Property
        Private ReadOnly Property DetailPageBreak As Boolean
            Get
                DetailPageBreak = _DetailPageBreak
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(UserCode As String, ByVal BatchReportType As CashReceiptBatchReportType)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode
            _BatchReportType = BatchReportType

            RadioButtonSelection_Batch.ByPassUserEntryChanged = True
            RadioButtonSelection_DateRange.ByPassUserEntryChanged = True

            RadioButtonFormat_DetailNoPageBreak.ByPassUserEntryChanged = True
            RadioButtonFormat_DetailPageBreak.ByPassUserEntryChanged = True
            RadioButtonFormat_Summary.ByPassUserEntryChanged = True

            DateTimePickerForm_From.ByPassUserEntryChanged = True
            DateTimePickerForm_To.ByPassUserEntryChanged = True

            ComboBoxForm_User.ByPassUserEntryChanged = True
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

            DateTimePickerForm_From.ValueObject = Now
            DateTimePickerForm_To.ValueObject = Now

            If BatchReportType = CashReceiptBatchReportType.OtherCashReceipt Then

                RadioButtonFormat_DetailNoPageBreak.Checked = True
                RadioButtonFormat_Summary.Enabled = False
                Me.Text = "Other Cash Receipt Batch Report"

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If _BatchReportType <> CashReceiptBatchReportType.ClientCashReceiptImport Then

                If RadioButtonSelection_Batch.Checked Then

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

            Else

                RadioButtonSelection_ImportBatch.Checked = True
                RadioButtonSelection_DateRange.Enabled = False
                RadioButtonSelection_Batch.Enabled = False

                LabelFormDates_From.Visible = False
                LabelFormDates_To.Visible = False
                DateTimePickerForm_From.Visible = False
                DateTimePickerForm_To.Visible = False

                ComboBoxForm_User.Enabled = False

            End If

        End Sub
        Private Sub LoadBatchesForUser()

            Dim BatchNameList As IEnumerable(Of String) = Nothing

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If (_BatchReportType = CashReceiptBatchReportType.ClientCashReceipt OrElse _BatchReportType = CashReceiptBatchReportType.OtherCashReceipt) AndAlso
                            ComboBoxForm_User.HasASelectedValue Then

                        ComboBoxForm_Batch.Text = Nothing

                        If _BatchReportType = CashReceiptBatchReportType.ClientCashReceipt Then

                            ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadCashReceiptBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                        ElseIf _BatchReportType = CashReceiptBatchReportType.OtherCashReceipt Then

                            ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadOtherReceiptBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                        End If

                    Else

                        BatchNameList = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadBatchNames(DbContext)

                        If BatchNameList IsNot Nothing AndAlso BatchNameList.Count > 0 Then

                            ComboBoxForm_Batch.DataSource = AdvantageFramework.Importing.GetBatchNamesOrderedByDateDescending(BatchNameList)
                            ComboBoxForm_Batch.ControlType = WinForm.Presentation.Controls.ComboBox.Type.KeyValuePair
                            ComboBoxForm_Batch.DisplayMember = "Value"
                            ComboBoxForm_Batch.ValueMember = "Value"

                        End If

                    End If

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef [From] As Date, ByRef [To] As Date, ByRef UserCode As String, ByRef IsBatch As Boolean,
                                              ByVal BatchReportType As CashReceiptBatchReportType, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim ClientCashReceiptBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog = Nothing

            ClientCashReceiptBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog(UserCode, BatchReportType)

            ShowFormDialog = ClientCashReceiptBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ReportType = ClientCashReceiptBatchReportDialog.ReportType
                [From] = ClientCashReceiptBatchReportDialog.[From].ToShortDateString
                [To] = ClientCashReceiptBatchReportDialog.[To].ToShortDateString
                UserCode = ClientCashReceiptBatchReportDialog.UserCode
                DetailPageBreak = ClientCashReceiptBatchReportDialog.DetailPageBreak

                If ClientCashReceiptBatchReportDialog.RadioButtonSelection_Batch.Checked Then

                    IsBatch = True
                    [From] = CDate(ClientCashReceiptBatchReportDialog.BatchName)

                End If

            End If

        End Function
        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef BatchName As String, ByRef DetailPageBreak As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim ClientCashReceiptBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog = Nothing

            ClientCashReceiptBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptBatchReportDialog(Nothing, CashReceiptBatchReportType.ClientCashReceiptImport)

            ShowFormDialog = ClientCashReceiptBatchReportDialog.ShowDialog()

            ReportType = ClientCashReceiptBatchReportDialog.ReportType
            BatchName = ClientCashReceiptBatchReportDialog.BatchName
            DetailPageBreak = ClientCashReceiptBatchReportDialog.DetailPageBreak

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True

            Me.RadioButtonSelection_Batch.ByPassUserEntryChanged = True
            Me.RadioButtonSelection_DateRange.ByPassUserEntryChanged = True

            Me.ComboBoxForm_Batch.ByPassUserEntryChanged = True
            Me.ComboBoxForm_User.ByPassUserEntryChanged = True

            Me.DateTimePickerForm_From.ByPassUserEntryChanged = True
            Me.DateTimePickerForm_To.ByPassUserEntryChanged = True

            If _BatchReportType <> CashReceiptBatchReportType.ClientCashReceiptImport Then

                ComboBoxForm_User.SetRequired(True)

                Using DbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(DbContext)

                End Using

                ComboBoxForm_User.Text = Me.Session.UserCode

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            LoadBatchesForUser()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If RadioButtonFormat_DetailNoPageBreak.Checked OrElse RadioButtonFormat_DetailPageBreak.Checked Then

                    If _BatchReportType = CashReceiptBatchReportType.ClientCashReceipt OrElse _BatchReportType = CashReceiptBatchReportType.ClientCashReceiptImport Then

                        _ReportType = AdvantageFramework.Reporting.ReportTypes.ClientCashReceiptBatchReport

                    ElseIf _BatchReportType = CashReceiptBatchReportType.OtherCashReceipt Then

                        _ReportType = AdvantageFramework.Reporting.ReportTypes.OtherCashReceiptBatchReport

                    End If

                    If RadioButtonFormat_DetailNoPageBreak.Checked Then

                        _DetailPageBreak = False

                    ElseIf RadioButtonFormat_DetailPageBreak.Checked Then

                        _DetailPageBreak = True

                    End If

                Else

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.ClientCashReceiptBatchSummaryReport

                End If

                _UserCode = ComboBoxForm_User.GetSelectedValue
                _BatchName = ComboBoxForm_Batch.GetSelectedValue

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

            If Me.FormShown Then

                LoadBatchesForUser()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace