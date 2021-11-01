Namespace Reporting.Presentation

    Public Class BillingWorksheetMediaInitialLoadingDialog

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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim BillingWorksheetMediaInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.BillingWorksheetMediaInitialLoadingDialog = Nothing

            BillingWorksheetMediaInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.BillingWorksheetMediaInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = BillingWorksheetMediaInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = BillingWorksheetMediaInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingWorksheetMediaInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            BillingWorksheetMediaControl.LoadControl()
            BillingBatchChooserControl_Media.LoadControl(WinForm.Presentation.Controls.BillingBatchChooserControl.BatchType.Media)
            CDPChooserControl_Media.LoadControl()
            AEChooserControl_Media.LoadControl()

            TabItemMediaCriteria_BillingBatchIDTab.Visible = False

        End Sub

        Private Sub BillingWorksheetMediaInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            BillingBatchChooserControl_Media.ForceResize()
            CDPChooserControl_Media.ForceResize()
            AEChooserControl_Media.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If BillingWorksheetMediaControl.ValidateControl(ErrorMessage) Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary = BillingWorksheetMediaControl.ParameterDictionary

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedClients.ToString) = CDPChooserControl_Media.ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedDivisions.ToString) = CDPChooserControl_Media.DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedProducts.ToString) = CDPChooserControl_Media.ProductCodeList

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.SelectedAccountExecutives.ToString) = AEChooserControl_Media.AccountExecutiveCodeList

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BillingCommandCenterID.ToString) = BillingBatchChooserControl_Media.BillingCommandCenterID

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

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

#End Region

#End Region

    End Class

End Namespace