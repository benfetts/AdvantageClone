Namespace FinanceAndAccounting.Presentation

    Public Class ClientInvoiceBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Protected _UserCode As String = Nothing
        Protected _IsBatch As Boolean = False
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
        Private ReadOnly Property BatchName As String
            Get
                BatchName = _BatchName
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(UserCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode

            RadioButtonSelection_Batch.ByPassUserEntryChanged = True
            RadioButtonSelection_DateRange.ByPassUserEntryChanged = True

            DateTimePickerForm_From.ByPassUserEntryChanged = True
            DateTimePickerForm_To.ByPassUserEntryChanged = True

            ComboBoxForm_User.ByPassUserEntryChanged = True
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub EnableOrDisableActions()

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

        End Sub
        Private Sub LoadBatchesForUser()

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading AndAlso ComboBoxForm_User.HasASelectedValue Then

                ComboBoxForm_Batch.Text = Nothing

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_Batch.DataSource = AdvantageFramework.Database.Procedures.GeneralLedger.LoadClientInvoiceBatchDatesByUser(DbContext, ComboBoxForm_User.GetSelectedValue)

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef [From] As Date, ByRef [To] As Date, ByRef UserCode As String, ByRef IsBatch As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim ClientInvoiceBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceBatchReportDialog = Nothing

            ClientInvoiceBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceBatchReportDialog(UserCode)

            ShowFormDialog = ClientInvoiceBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ReportType = ClientInvoiceBatchReportDialog.ReportType
                [From] = ClientInvoiceBatchReportDialog.[From].ToShortDateString
                [To] = ClientInvoiceBatchReportDialog.[To].ToShortDateString
                UserCode = ClientInvoiceBatchReportDialog.UserCode

                If ClientInvoiceBatchReportDialog.RadioButtonSelection_Batch.Checked Then

                    IsBatch = True
                    [From] = CDate(ClientInvoiceBatchReportDialog.BatchName)

                End If

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientInvoiceBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True

            Me.RadioButtonSelection_Batch.ByPassUserEntryChanged = True
            Me.RadioButtonSelection_DateRange.ByPassUserEntryChanged = True

            Me.ComboBoxForm_Batch.ByPassUserEntryChanged = True
            Me.ComboBoxForm_User.ByPassUserEntryChanged = True

            Me.DateTimePickerForm_From.ByPassUserEntryChanged = True
            Me.DateTimePickerForm_To.ByPassUserEntryChanged = True

            ComboBoxForm_User.SetRequired(True)

            Using DbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(DbContext)

            End Using

            ComboBoxForm_User.SelectedValue = Me.Session.UserCode

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

                If RadioButtonFormat_Detail.Checked Then

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchDetailReport

                Else

                    _ReportType = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchSummaryReport

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

            LoadBatchesForUser()

        End Sub

#End Region

#End Region

    End Class

End Namespace