Namespace Reporting.Presentation

    Public Class MonthEndMediaWIPInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.SalesJournal
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

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MonthEndMediaWIPInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog = Nothing

            MonthEndMediaWIPInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = MonthEndMediaWIPInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MonthEndMediaWIPInitialLoadingDialog.ParameterDictionary
                ReportType = MonthEndMediaWIPInitialLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    '    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournal Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = False
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                    '        Me.Label1.Visible = False

                    '    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalExpanded Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = False
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                    '        Me.Label1.Visible = False

                    '    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalSummaryByInvoice Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = True
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = True
                    '        Me.Label1.Visible = True

                    '    End If

                Else


                End If

            End If

        End Sub

        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MonthEndMediaWIPInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxForm_EndPostPeriod.SetRequired(True)

            PanelForm_TopSection.Visible = _ShowReportOption
            Me.RadioButtonControl_OpenandClosed.Checked = True
            Me.RadioButtonControl_Orders.Checked = True

            ComboBoxTopSection_ReportSeries.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportSeries)).OrderBy(Function(EnumObject) EnumObject.Code).ToList

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"
                Me.GroupBox2.Visible = False
                Me.Label2.Visible = False

            Else


            End If

            LabelForm_AgingDate.Visible = False
            LabelForm_AgingOption.Visible = False
            DateTimePickerAgingDate.Visible = False
            RadioButtonForm_Invoice.Visible = False
            RadioButtonForm_InvoiceDueDate.Visible = False
            DateTimePickerAgingDate.ValueObject = Now.ToShortDateString
            CheckBoxForm_IncludeDetail.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_EndPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxForm_EndPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    ComboBoxForm_EndPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)

                Catch ex As Exception

                End Try

            End If

            If _DynamicReport = DynamicReports.MonthEndAccruedLiability Then

                Me.TabItemJDA_SelectClientsTab.Visible = False
                Me.GroupBox1.Visible = False
                Me.GroupBox2.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False
                CheckBoxForm_IncludeDetail.Visible = False

            ElseIf _DynamicReport = DynamicReports.MonthEndAccountsPayable Then

                Me.TabItemJDA_SelectClientsTab.Visible = False
                Me.GroupBox1.Visible = False
                Me.GroupBox2.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False

                LabelForm_AgingDate.Visible = True
                LabelForm_AgingOption.Visible = True
                DateTimePickerAgingDate.Visible = True
                RadioButtonForm_Invoice.Visible = True
                RadioButtonForm_InvoiceDueDate.Visible = True
                DateTimePickerAgingDate.ValueObject = Now.ToShortDateString
                CheckBoxForm_IncludeDetail.Visible = True

            ElseIf _DynamicReport = DynamicReports.MonthEndProductionWIP Then

                LabelForm_AgingDate.Visible = True
                LabelForm_AgingOption.Visible = True
                DateTimePickerAgingDate.Visible = True
                RadioButtonForm_Invoice.Visible = True
                RadioButtonForm_InvoiceDueDate.Visible = True
                DateTimePickerAgingDate.ValueObject = Now.ToShortDateString

            End If



            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _ShowReportOption Then

                    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                Else

                End If

                If _DynamicReport = DynamicReports.MonthEndAccruedLiability Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString) = ComboBoxForm_EndPostPeriod.SelectedValue

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                ElseIf _DynamicReport = DynamicReports.MonthEndAccountsPayable OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableDetailwithDaysAged OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableDisbDetailByInvoiceNumber OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableDisbDetailByInvoiceDate OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableAgedSummary OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableAgedDetail Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString) = ComboBoxForm_EndPostPeriod.SelectedValue

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString) = DateTimePickerAgingDate.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString) = If(RadioButtonForm_Invoice.Checked, 1, 2)

                    If CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableDisbDetailByInvoiceNumber OrElse
                       CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable.AccountsPayableDisbDetailByInvoiceDate Then
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.IncludeDetails.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.IncludeDetails.ToString) = 0
                    End If

                    If _ShowReportOption = False Then
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.IncludeDetails.ToString) = If(CheckBoxForm_IncludeDetail.Checked, 1, 0)
                    End If

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString) = ComboBoxForm_EndPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString) = If(RadioButtonControl_OpenOnly.Checked, 2, 1)

                    If _ShowReportOption = True Then
                        If ComboBoxTopSection_Report.HasASelectedValue Then

                            If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPSummaryByClientBillingAPBalance Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "G"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPDetailByGLAccount Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "G"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPSummaryByVendorBalanceOnly Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPSummaryByClientBalanceOnly Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaOrdersWithZeroBalance Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "Z"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPSummaryByClientPOBalanceOnly Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPAgedSummaryByVendor Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPAgedSummaryByClient Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.MediaWIPAgedSummaryByMediaType Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"

                            ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypes.AccruedAccountsPayableByClientVendorPeriod Then

                                _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "G"

                            End If

                        Else


                        End If
                    Else
                        If RadioButtonControl_Orders.Checked Then
                            _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"
                        ElseIf RadioButtonControl_OpenOrdersGLAccountOrders.Checked Then
                            _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "G"
                        ElseIf RadioButtonControl_OpenOrdersGLAccountLineOrders.Checked Then
                            _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "L"
                        ElseIf RadioButtonControl_ZeroBalanceOrders.Checked Then
                            _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "Z"
                        End If
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

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedClients.ToString) = ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedDivisions.ToString) = DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedProducts.ToString) = ProductCodeList

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString) = DateTimePickerAgingDate.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString) = If(RadioButtonForm_Invoice.Checked, 1, 2)

                    If CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsReceivable.AccountsReceivableAgedwithDisbursementDetail Then
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString) = 0
                    End If

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
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_Report.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

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

        Private Sub RadioButtonControl_OpenOrdersGLAccountLineOrders_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_OpenOrdersGLAccountLineOrders.CheckedChanged

        End Sub

        Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

        End Sub

        Private Sub RadioButtonControl_Orders_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_Orders.CheckedChanged

        End Sub

        Private Sub ComboBoxTopSection_ReportSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_ReportSeries.SelectedIndexChanged
            If ComboBoxTopSection_ReportSeries.SelectedValue = 1 Then
                ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                LabelForm_AgingDate.Visible = False
                LabelForm_AgingOption.Visible = False
                DateTimePickerAgingDate.Visible = False
                RadioButtonForm_Invoice.Visible = False
                RadioButtonForm_InvoiceDueDate.Visible = False

                TabItemJDA_SelectClientsTab.Visible = True
                Label1.Visible = True
                GroupBox1.Visible = True

            End If
            If ComboBoxTopSection_ReportSeries.SelectedValue = 2 Then
                ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndProductionWIPReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                LabelForm_AgingDate.Visible = True
                LabelForm_AgingOption.Visible = True
                DateTimePickerAgingDate.Visible = True
                RadioButtonForm_Invoice.Visible = True
                RadioButtonForm_InvoiceDueDate.Visible = True

                TabItemJDA_SelectClientsTab.Visible = False
                Label1.Visible = False
                GroupBox1.Visible = False

            End If
            If ComboBoxTopSection_ReportSeries.SelectedValue = 3 Then
                ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportTypesAccountsPayable)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                LabelForm_AgingDate.Visible = True
                LabelForm_AgingOption.Visible = True
                DateTimePickerAgingDate.Visible = True
                RadioButtonForm_Invoice.Visible = True
                RadioButtonForm_InvoiceDueDate.Visible = True

                TabItemJDA_SelectClientsTab.Visible = False
                Label1.Visible = False
                GroupBox1.Visible = False

            End If
            If ComboBoxTopSection_ReportSeries.SelectedValue = 4 Then
                ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportTypesAccountsReceivable)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                LabelForm_AgingDate.Visible = True
                LabelForm_AgingOption.Visible = True
                DateTimePickerAgingDate.Visible = True
                RadioButtonForm_Invoice.Visible = True
                RadioButtonForm_InvoiceDueDate.Visible = True

                TabItemJDA_SelectClientsTab.Visible = False
                Label1.Visible = False
                GroupBox1.Visible = False

            End If
            If ComboBoxTopSection_ReportSeries.SelectedValue = 5 Then
                ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndAccruedLiabilityReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

                LabelForm_AgingDate.Visible = False
                LabelForm_AgingOption.Visible = False
                DateTimePickerAgingDate.Visible = False
                RadioButtonForm_Invoice.Visible = False
                RadioButtonForm_InvoiceDueDate.Visible = False

                TabItemJDA_SelectClientsTab.Visible = False
                Label1.Visible = False
                GroupBox1.Visible = False

            End If
        End Sub


#End Region

#End Region

    End Class

End Namespace
