Namespace Reporting.Presentation

    Public Class OpenPurchaseOrderDetailLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.PurchaseOrderDetail
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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim OpenPurchaseOrderDetailLoadingDialog As AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog = Nothing

            OpenPurchaseOrderDetailLoadingDialog = New AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = OpenPurchaseOrderDetailLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = OpenPurchaseOrderDetailLoadingDialog.ParameterDictionary
                ReportType = OpenPurchaseOrderDetailLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.PurchaseOrderReportTypes.PurchaseOrderDetail Then

                    End If

                Else


                End If

            End If

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub OpenPurchaseOrderDetailLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DateTimePickerForm_POStartDate.SetRequired(True)
            DateTimePickerForm_POStartDate.ValueObject = Now.ToShortDateString
            CheckBoxForm_IncludeVoidedPOs.Enabled = False
            CheckBoxForm_ClientPOs.Checked = True
            CheckBoxForm_NonClientPOs.Checked = True

            If CheckBoxForm_ClientPOs.Checked = False Then
                CDPChooserControl_Production.Enabled = False
            End If

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString)) = False Then

                    Try

                        DateTimePickerForm_POStartDate.ValueObject = _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString)

                    Catch ex As Exception
                        DateTimePickerForm_POStartDate.ValueObject = Nothing
                    End Try

                End If

            End If

            DateTimePickerForm_POEndDate.SetRequired(True)
            DateTimePickerForm_POEndDate.ValueObject = Now.ToShortDateString

            PanelForm_TopSection.Visible = _ShowReportOption

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"

            End If

            ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString)) = False Then

                    Try

                        DateTimePickerForm_POEndDate.ValueObject = _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString)

                    Catch ex As Exception
                        DateTimePickerForm_POEndDate.ValueObject = Nothing
                    End Try

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing

            If Me.Validator Then

                If DateTimePickerForm_POStartDate.ValueObject <= DateTimePickerForm_POEndDate.ValueObject Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    If _ShowReportOption Then

                        _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString) = DateTimePickerForm_POStartDate.ValueObject
                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString) = DateTimePickerForm_POEndDate.ValueObject
                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeClosedPOs.ToString) = CheckBoxForm_IncludeCompletedPOs.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeVoidedPOs.ToString) = CheckBoxForm_IncludeVoidedPOs.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeClientPOs.ToString) = CheckBoxForm_ClientPOs.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeNonClientPOs.ToString) = CheckBoxForm_NonClientPOs.Checked


                    If CDPChooserControl_Production.RadioButtonControl_AllClients.Checked Then

                        ClientCodeList = Nothing
                        DivisionCodeList = Nothing
                        ProductCodeList = Nothing

                    Else

                        If CDPChooserControl_Production.RadioButtonControl_ChooseClients.Checked Then

                            SelectedCodesList = CDPChooserControl_Production.ClientCodeList

                            ClientCodeList = SelectedCodesList
                            DivisionCodeList = Nothing
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisions.Checked Then

                            SelectedCodesList = CDPChooserControl_Production.DivisionCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = SelectedCodesList
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControl_Production.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                            SelectedCodesList = CDPChooserControl_Production.ProductCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = Nothing
                            ProductCodeList = SelectedCodesList

                        End If

                    End If

                    _ParameterDictionary("OpenPurchaseOrderDetail_SelectedClients") = ClientCodeList
                    _ParameterDictionary("OpenPurchaseOrderDetail_SelectedDivisions") = DivisionCodeList
                    _ParameterDictionary("OpenPurchaseOrderDetail_SelectedProducts") = ProductCodeList

                    If VendorChooserControl1.RadioButtonControl_AllVendors.Checked Then

                        _ParameterDictionary("OpenPurchaseOrderDetail_SelectedVendors") = Nothing

                    Else

                        _ParameterDictionary("OpenPurchaseOrderDetail_SelectedVendors") = VendorChooserControl1.DataGridViewControl_Vendors.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If _ShowReportOption Then

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    Else

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting date and ending date and ensure that the starting date is before the ending date.")

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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

			DateTimePickerForm_POStartDate.Value = New Date(Now.Year, 1, 1)
			DateTimePickerForm_POEndDate.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

			DateTimePickerForm_POStartDate.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerForm_POEndDate.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_POStartDate.Value = Now.AddYears(-1)
            DateTimePickerForm_POEndDate.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_POStartDate.Value = Now.AddYears(-2)
            DateTimePickerForm_POEndDate.Value = Now

        End Sub

        Private Sub CheckBoxForm_IncludeCompletedPOs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_IncludeCompletedPOs.CheckedChanged
            If CheckBoxForm_IncludeCompletedPOs.Checked = True Then
                CheckBoxForm_IncludeVoidedPOs.Enabled = True
            Else
                CheckBoxForm_IncludeVoidedPOs.Enabled = False
                CheckBoxForm_IncludeVoidedPOs.Checked = False
            End If
        End Sub

        Private Sub CheckBoxForm_ClientPOs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_ClientPOs.CheckedChanged
            If CheckBoxForm_ClientPOs.Checked = True Then
                CDPChooserControl_Production.Enabled = True
            Else
                CDPChooserControl_Production.Enabled = False
            End If
        End Sub



#End Region

#End Region

    End Class

End Namespace