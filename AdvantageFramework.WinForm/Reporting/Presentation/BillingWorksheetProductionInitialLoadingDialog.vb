Namespace Reporting.Presentation

    Public Class BillingWorksheetProductionInitialLoadingDialog

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
            Dim BillingWorksheetProductionInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.BillingWorksheetProductionInitialLoadingDialog = Nothing

            BillingWorksheetProductionInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.BillingWorksheetProductionInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = BillingWorksheetProductionInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = BillingWorksheetProductionInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingWorksheetProductionInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            BillingWorksheetProductionControl.LoadControl()
            BillingBatchChooserControl_Production.LoadControl(WinForm.Presentation.Controls.BillingBatchChooserControl.BatchType.Production)
            CDPChooserControl_Production.LoadControl()
            AEChooserControl_Production.LoadControl()

            TabItemProductionCriteria_BillingBatchIDTab.Visible = False

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)) = False Then

                    Try

                        BillingWorksheetProductionControl.DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)

                    Catch ex As Exception
                        BillingWorksheetProductionControl.DateTimePickerProductionCutoffs_EmployeeTimeDate.ValueObject = Nothing
                    End Try

                End If

            End If

        End Sub

        Private Sub BillingWorksheetProductionInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            BillingBatchChooserControl_Production.ForceResize()
            CDPChooserControl_Production.ForceResize()
            AEChooserControl_Production.ForceResize()

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

                _ParameterDictionary = BillingWorksheetProductionControl.ParameterDictionary

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedDivisions.ToString) = CDPChooserControl_Production.DivisionCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedProducts.ToString) = CDPChooserControl_Production.ProductCodeList

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedAccountExecutives.ToString) = AEChooserControl_Production.AccountExecutiveCodeList

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.BillingCommandCenterID.ToString) = BillingBatchChooserControl_Production.BillingCommandCenterID

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

#End Region

#End Region

    End Class

End Namespace