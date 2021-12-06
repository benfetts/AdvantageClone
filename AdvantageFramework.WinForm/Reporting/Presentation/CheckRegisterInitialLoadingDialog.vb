Namespace Reporting.Presentation

    Public Class CheckRegisterInitialLoadingDialog

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
            Dim CheckRegisterInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.CheckRegisterInitialLoadingDialog = Nothing

            CheckRegisterInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.CheckRegisterInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            If DynamicReport = Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

                CheckRegisterInitialLoadingDialog.GroupBoxControl_Cutoffs.Visible = False
                CheckRegisterInitialLoadingDialog.GroupBox1.Visible = False
                CheckRegisterInitialLoadingDialog.TabItemJDA_SelectBanksTab.Visible = False
                CheckRegisterInitialLoadingDialog.TitleText = "Accounts Payable Invoice Detail Payments Criteria"
                CheckRegisterInitialLoadingDialog.Width = 600
                CheckRegisterInitialLoadingDialog.Height = 400

            End If

            ShowFormDialog = CheckRegisterInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = CheckRegisterInitialLoadingDialog.ParameterDictionary
                ReportType = CheckRegisterInitialLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournal Then

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalExpanded Then

                    End If

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

        Private Sub LoadBanks()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectBanks_Banks.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadWithOfficeLimits(DbContext, Me.Session)
                                                            Select [Code] = Entity.Code,
                                                                   [Name] = Entity.Description).ToList

                DataGridViewSelectBanks_Banks.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadVendors()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectVendors_Vendors.DataSource = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                                                Select New With {
                                                        .Code = Vendor.Code,
                                                        .Name = Vendor.Name + " (" + Vendor.Code + ")"
                                                        }).ToList
                'AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext))

                DataGridViewSelectVendors_Vendors.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SalesJournalInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.DateTimePickerForm_From.SetRequired(True)
            Me.DateTimePickerForm_To.SetRequired(True)

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                PostPeriod_FromMonth.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext) Select [Code] = Entity.Code).ToList

                PostPeriod_ToMonth.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext) Select [Code] = Entity.Code).ToList

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                If CurrentPostPeriod Is Nothing Then

                    Try

                        CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).FirstOrDefault()

                    Catch ex As Exception
                        CurrentPostPeriod = Nothing
                    End Try

                End If

            End Using

            If CurrentPostPeriod IsNot Nothing Then

                PostPeriod_FromMonth.Text = CurrentPostPeriod.Code
                PostPeriod_ToMonth.Text = CurrentPostPeriod.Code

            End If

            PanelForm_TopSection.Visible = _ShowReportOption

            Me.CheckBoxComputerGeneratedChecks.Checked = True
            Me.CheckBoxManualChecks.Checked = True

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"

            End If

            ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.SalesJournalReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            End Using

            CDPChooserControlSelectClients_SelectClients.ForceResize()

            RadioButtonDates_PostPeriod.Checked = True

            RadioButtonDates_Standard.Checked = True


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

                'If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _ShowReportOption Then

                    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                End If

                '_ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.StartingDate.ToString) = DateTimePickerForm_From.Value
                '_ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.EndingDate.ToString) = DateTimePickerForm_To.Value
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeComputerChecks.ToString) = CheckBoxComputerGeneratedChecks.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeManualChecks.ToString) = CheckBoxManualChecks.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeComments.ToString) = CheckBoxVoidComments.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitVoidedChecks.ToString) = CheckBoxVoidedChecks.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitOutstandingChecks.ToString) = CheckBoxOutstandingChecks.CheckValue
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitClearedChecks.ToString) = CheckBoxClearedChecks.CheckValue

                '_ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeInvoiceDetails.ToString) = CheckBoxIncludeInvoiceDetails.CheckValue

                If RadioButtonDates_PostPeriod.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodStart.ToString) = PostPeriod_FromMonth.GetSelectedValue().ToString
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodEnd.ToString) = PostPeriod_ToMonth.GetSelectedValue().ToString

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.StartingDate.ToString) = ""
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.EndingDate.ToString) = ""
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.StartingDate.ToString) = DateTimePickerForm_From.Value.ToShortDateString
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.EndingDate.ToString) = DateTimePickerForm_To.Value.ToShortDateString

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodStart.ToString) = ""
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodEnd.ToString) = ""
                End If

                If RadioButtonSelectBanks_AllBanks.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedBanks.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedBanks.ToString) = DataGridViewSelectBanks_Banks.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

                If RadioButtonSelectVendors_AllVendors.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedVendors.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedVendors.ToString) = DataGridViewSelectVendors_Vendors.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

                If CheckBoxSelectByPayToVendor.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.UsePayToVendorCode.ToString) = True

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.UsePayToVendorCode.ToString) = False

                End If

                'If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                '    ClientCodeList = Nothing
                '    DivisionCodeList = Nothing
                '    ProductCodeList = Nothing

                'Else

                '    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                '        ClientCodeList = SelectedCodesList
                '        DivisionCodeList = Nothing
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = SelectedCodesList
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = Nothing
                '        ProductCodeList = SelectedCodesList

                '    End If

                'End If

                '_ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedClients.ToString) = ClientCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedDivisions.ToString) = DivisionCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedProducts.ToString) = ProductCodeList


                If _ShowReportOption Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

                'Else

                '    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

                'End If

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
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

        End Sub

        Private Sub CheckBoxForm_BreakoutCoOpBilling_CheckedChanged(sender As Object, e As EventArgs)

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

        Private Sub RadioButtonSelectBanks_AllBanks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectBanks_AllBanks.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectBanks_AllBanks.Checked Then

                    DataGridViewSelectBanks_Banks.Enabled = False

                End If

            End If

        End Sub

        Private Sub RadioButtonSelectBanks_ChooseBanks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectBanks_ChooseBanks.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectBanks_ChooseBanks.Checked Then

                    If DataGridViewSelectBanks_Banks.HasRows = False Then

                        LoadBanks()

                    End If

                    DataGridViewSelectBanks_Banks.Enabled = True

                End If

            End If

        End Sub

        Private Sub RadioButtonDates_Standard_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_Standard.CheckedChanged
            If RadioButtonDates_Standard.Checked = True Then

                LabelForm_From.Enabled = True
                LabelForm_To.Enabled = True
                DateTimePickerForm_From.Enabled = True
                DateTimePickerForm_To.Enabled = True
                ButtonInvoiceDate_YTD.Enabled = True
                ButtonInvoiceDate_MTD.Enabled = True
                ButtonInvoiceDate_1Year.Enabled = True
                ButtonInvoiceDate_2Year.Enabled = True
                Label1.Enabled = True

                LabelPostPeriod_From.Enabled = False
                LabelPostPeriod_To.Enabled = False
                PostPeriod_FromMonth.Enabled = False
                PostPeriod_ToMonth.Enabled = False
                LabelOptions_PostPeriod.Enabled = False

            End If
        End Sub

        Private Sub RadioButtonDates_Broadcast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_PostPeriod.CheckedChanged
            If RadioButtonDates_PostPeriod.Checked = True Then

                LabelForm_From.Enabled = False
                LabelForm_To.Enabled = False
                DateTimePickerForm_From.Enabled = False
                DateTimePickerForm_To.Enabled = False
                ButtonInvoiceDate_YTD.Enabled = False
                ButtonInvoiceDate_MTD.Enabled = False
                ButtonInvoiceDate_1Year.Enabled = False
                ButtonInvoiceDate_2Year.Enabled = False
                Label1.Enabled = False

                LabelPostPeriod_From.Enabled = True
                LabelPostPeriod_To.Enabled = True
                PostPeriod_FromMonth.Enabled = True
                PostPeriod_ToMonth.Enabled = True
                LabelOptions_PostPeriod.Enabled = True

            End If
        End Sub

        Private Sub RadioButtonSelectVendors_ChooseVendors_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectVendors_ChooseVendors.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    If DataGridViewSelectVendors_Vendors.HasRows = False Then

                        LoadVendors()

                    End If

                    DataGridViewSelectVendors_Vendors.Enabled = True

                End If

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace
