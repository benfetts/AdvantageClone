Namespace Reporting.Presentation

    Public Class InvoiceBilledBackupInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

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



        End Sub
#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim InvoiceBilledBackupInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.InvoiceBilledBackupInitialLoadingDialog = Nothing

            InvoiceBilledBackupInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.InvoiceBilledBackupInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = InvoiceBilledBackupInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = InvoiceBilledBackupInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobDetailInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Visible = False
            CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Visible = False
            CDPChooserControl_Production.LoadControl(_ParameterDictionary)

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub JobDetailInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim SelectedIDs As Generic.List(Of Integer) = Nothing

            CDPChooserControl_Production.ForceResize()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.InvoiceBilledBackupInitialParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                _ParameterDictionary(AdvantageFramework.Reporting.InvoiceBilledBackupInitialParameters.EndDate.ToString) = DateTimePickerForm_To.Value
                _ParameterDictionary(AdvantageFramework.Reporting.InvoiceBilledBackupInitialParameters.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList

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

        Private Sub ButtonInvoiceDate_YTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_MTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_1Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_2Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_2Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub

#End Region

#End Region

    End Class

End Namespace