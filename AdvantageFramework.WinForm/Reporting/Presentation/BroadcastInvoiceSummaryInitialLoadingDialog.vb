Namespace Reporting.Presentation

    Public Class BroadcastInvoiceSummaryInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim BroadcastInvoiceSummaryInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.BroadcastInvoiceSummaryInitialLoadingDialog = Nothing

            BroadcastInvoiceSummaryInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.BroadcastInvoiceSummaryInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = BroadcastInvoiceSummaryInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = BroadcastInvoiceSummaryInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastInvoiceSummaryInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_MonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
            ComboBoxForm_MonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            NumericInputForm_YearFrom.Properties.MinValue = 1980
            NumericInputForm_YearFrom.Properties.MaxValue = 2078
            NumericInputForm_YearFrom.Properties.MaxLength = 4
            NumericInputForm_YearFrom.SetPropertySettings(DisplayName:="Year From")
            NumericInputForm_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            NumericInputForm_YearTo.Properties.MinValue = 1980
            NumericInputForm_YearTo.Properties.MaxValue = 2078
            NumericInputForm_YearTo.Properties.MaxLength = 4
            NumericInputForm_YearTo.SetPropertySettings(DisplayName:="Year To")
            NumericInputForm_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            ComboBoxForm_MonthFrom.SelectedIndex = Now.Month - 1
            ComboBoxForm_MonthTo.SelectedIndex = Now.Month - 1

            ComboBoxForm_MonthFrom.SetRequired(True)
            ComboBoxForm_MonthTo.SetRequired(True)

            NumericInputForm_YearFrom.Value = Now.Year
            NumericInputForm_YearTo.Value = Now.Year

            NumericInputForm_YearFrom.SetRequired(True)
            NumericInputForm_YearTo.SetRequired(True)

            CheckBoxForm_Radio.Checked = True
            CheckBoxForm_TV.Checked = True

            RadioButtonForm_OpenAndClosedOrders.Checked = True
            RadioButtonForm_OpenOrdersOnly.Checked = False

            'If _ParameterDictionary IsNot Nothing Then

            '    ComboBoxForm_MonthFrom.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartMonth.ToString)
            '    NumericInputForm_YearFrom.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartYear.ToString)
            '    ComboBoxForm_MonthTo.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndMonth.ToString)
            '    NumericInputForm_YearTo.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndYear.ToString)

            '    CheckBoxForm_Radio.Checked = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString)
            '    CheckBoxForm_TV.Checked = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString)

            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartMonth.ToString) = ComboBoxForm_MonthFrom.SelectedValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartYear.ToString) = NumericInputForm_YearFrom.EditValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndMonth.ToString) = ComboBoxForm_MonthTo.SelectedValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndYear.ToString) = NumericInputForm_YearTo.EditValue

            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString) = CheckBoxForm_Radio.Checked
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString) = CheckBoxForm_TV.Checked

            'End If

        End Sub
        Private Sub BroadcastInvoiceSummaryInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If CheckBoxForm_Radio.Checked OrElse CheckBoxForm_TV.Checked Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartPeriod.ToString) = CInt(CStr(NumericInputForm_YearFrom.EditValue) & AdvantageFramework.StringUtilities.PadWithCharacter(CStr(ComboBoxForm_MonthFrom.SelectedValue), 2, "0", True, True))
                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndPeriod.ToString) = CInt(CStr(NumericInputForm_YearTo.EditValue) & AdvantageFramework.StringUtilities.PadWithCharacter(CStr(ComboBoxForm_MonthTo.SelectedValue), 2, "0", True, True))

                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString) = CheckBoxForm_Radio.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString) = CheckBoxForm_TV.Checked

                    If RadioButtonForm_OpenAndClosedOrders.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.OrderStatus.ToString) = 1

                    ElseIf RadioButtonForm_OpenOrdersOnly.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.OrderStatus.ToString) = 2

                    End If

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                        ClientCodeList = Nothing
                        DivisionCodeList = Nothing
                        ProductCodeList = Nothing

                    Else

                        If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                            ClientCodeList = SelectedCodesList
                            DivisionCodeList = Nothing
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = SelectedCodesList
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = Nothing
                            ProductCodeList = SelectedCodesList

                        End If

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedClients.ToString) = ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedDivisions.ToString) = DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedProducts.ToString) = ProductCodeList

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one media type.")

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
        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
