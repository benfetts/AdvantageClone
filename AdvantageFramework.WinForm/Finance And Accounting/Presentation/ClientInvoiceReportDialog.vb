Namespace FinanceAndAccounting.Presentation

    Public Class ClientInvoiceReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Protected _ClientCode As String = Nothing
        Protected _From As Date = Nothing
        Protected _To As Date = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property
        Private ReadOnly Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        Private ReadOnly Property [From] As Date
            Get
                [From] = _From
            End Get
        End Property
        Private ReadOnly Property [To] As Date
            Get
                [To] = _To
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ClientCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            _ClientCode = ClientCode

            DateTimePickerForm_From.ByPassUserEntryChanged = True
            DateTimePickerForm_To.ByPassUserEntryChanged = True

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ClientCode As String, ByRef [From] As Date, ByRef [To] As Date) As Windows.Forms.DialogResult

            'objects
            Dim ClientInvoiceReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceReportDialog = Nothing

            ClientInvoiceReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceReportDialog(ClientCode)

            ShowFormDialog = ClientInvoiceReportDialog.ShowDialog()

            ReportType = ClientInvoiceReportDialog.ReportType
            ClientCode = ClientInvoiceReportDialog.ClientCode
            [From] = ClientInvoiceReportDialog.[From].ToShortDateString
            [To] = ClientInvoiceReportDialog.[To].ToShortDateString

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True

            Me.SearchableComboBoxForm_Client.ByPassUserEntryChanged = True
            Me.DateTimePickerForm_From.ByPassUserEntryChanged = True
            Me.DateTimePickerForm_To.ByPassUserEntryChanged = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

            End Using

            SearchableComboBoxForm_Client.SelectedValue = _ClientCode

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _ReportType = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceReport 

                _ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
                _From = DateTimePickerForm_From.Value
                _To = DateTimePickerForm_To.Value

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

#End Region

#End Region

    End Class

End Namespace