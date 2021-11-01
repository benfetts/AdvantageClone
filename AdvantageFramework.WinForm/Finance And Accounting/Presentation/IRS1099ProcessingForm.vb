Namespace FinanceAndAccounting.Presentation

    Public Class IRS1099ProcessingForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _SelectedBanks As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Print.Enabled = DataGridViewForm_1099Data.HasRows

            ButtonItemTransmit_1099MISC.Enabled = DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Where(Function(E) E.Vendor1099Category <> CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)).Any

            ButtonItemTransmit_1099NEC.Enabled = DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Where(Function(E) E.Vendor1099Category = CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)).Any

            If DataGridViewForm_1099Data.HasASelectedRow Then

                ButtonItemVendor_Edit.Enabled = ButtonItemVendor_Edit.Tag

            Else

                ButtonItemVendor_Edit.Enabled = False

            End If
            
        End Sub
        Private Sub LoadGrid(ByVal StartDate As Date, ByVal EndDate As Date, ByVal SelectedBanks As Generic.List(Of String))

            Dim IRS1099VendorBankCheckAmountTotals As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099VendorBankCheckAmountTotal) = Nothing
            Dim IRS1099ProcessingList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing) = Nothing
            Dim IRS1099Vendors As IEnumerable(Of Object) = Nothing
            Dim IRS1099Processing As AdvantageFramework.AccountPayable.Classes.IRS1099Processing = Nothing
            Dim SqlParameterStartDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As SqlClient.SqlParameter = Nothing

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SqlParameterStartDate = New SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime)
                    SqlParameterEndDate = New SqlClient.SqlParameter("@end_date", SqlDbType.SmallDateTime)

                    SqlParameterStartDate.Value = StartDate
                    SqlParameterEndDate.Value = EndDate

                    IRS1099VendorBankCheckAmountTotals = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.IRS1099VendorBankCheckAmountTotal) _
                            ("exec advsp_1099_select_vendors_by_checkdate @start_date, @end_date", SqlParameterStartDate, SqlParameterEndDate).ToList

                    IRS1099ProcessingList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)

                    IRS1099Vendors = (From Entity In IRS1099VendorBankCheckAmountTotals
                                      Where SelectedBanks.Contains(Entity.BankCode)
                                      Group Entity By Entity.VendorPayToCode, Entity.Vendor1099Category Into Group, TotalAmountPaid = Sum(Entity.CheckAmountTotal)).ToList _
                                            .OrderBy(Function(E) E.VendorPayToCode).Select(Function(E) _
                                                    New With {.VendorPayToCode = E.VendorPayToCode,
                                                              .TotalAmountPaid = E.TotalAmountPaid,
                                                              .Vendor1099Category = E.Vendor1099Category}).ToList()

                    For Each IRS1099Vendor In IRS1099Vendors.Where(Function(E) (E.Vendor1099Category = 3 AndAlso E.TotalAmountPaid >= 10) OrElse (E.Vendor1099Category <> 3 AndAlso E.TotalAmountPaid >= 600))

                        IRS1099Processing = New AdvantageFramework.AccountPayable.Classes.IRS1099Processing(DbContext, IRS1099Vendor.VendorPayToCode, IRS1099Vendor.TotalAmountPaid)

                        IRS1099ProcessingList.Add(IRS1099Processing)

                    Next

                End Using

                DataGridViewForm_1099Data.DataSource = IRS1099ProcessingList

                DataGridViewForm_1099Data.CurrentView.BestFitColumns()

                DataGridViewForm_1099Data.ValidateAllRows()

                EnableOrDisableActions()

            End If

        End Sub
        Private Function VendorsComplete(ByRef ErrorText As String) As Boolean

            Dim IRS1099Processings As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing) = Nothing
            Dim IsValid As Boolean = True
            Dim PropertyErrorText As String = Nothing
            Dim FailedOnce As Boolean = False

            IRS1099Processings = DataGridViewForm_1099Data.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)().ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each IRS1099Processing In IRS1099Processings

                    PropertyErrorText = IRS1099Processing.ValidateEntity(IsValid)

                    If IsValid = False Then

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                        FailedOnce = True

                    End If

                Next

            End Using

            IsValid = Not FailedOnce

            VendorsComplete = IsValid

        End Function
        Private Sub Transmit(ByVal Form1099Type As AdvantageFramework.Exporting.Form1099)

            Dim PaymentYear As String = Nothing
            'Dim IsPriorYear As Boolean = False
            Dim IsLastFiling As Boolean = False
            Dim IsTestFile As Boolean = False
            Dim EmployeeCode As String = Nothing
            Dim FederalTaxID As String = Nothing
            Dim IRSTCC As String = Nothing
            Dim CombinedFederalStateFiler As Boolean = False
            Dim IsCorrectionFile As Boolean = False
            Dim OutputPath As String = Nothing
            Dim IRS1099ProcessingList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing) = Nothing
            Dim ErrorMessage As String = Nothing

            If VendorsComplete(Nothing) Then

                If DataGridViewForm_1099Data.HasRows AndAlso AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingTransmitDialog.ShowFormDialog(PaymentYear, IsLastFiling, IsTestFile,
                        EmployeeCode, FederalTaxID, IRSTCC, CombinedFederalStateFiler, IsCorrectionFile, OutputPath, Form1099Type) = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Creating File...")

                    Try

                        If Form1099Type = Exporting.Methods.Form1099.MISC Then

                            IRS1099ProcessingList = DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Where(Function(PL) PL.Vendor1099Category <> CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)).ToList

                        ElseIf Form1099Type = Exporting.Methods.Form1099.NEC Then

                            IRS1099ProcessingList = DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Where(Function(PL) PL.Vendor1099Category = CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)).ToList

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AdvantageFramework.Exporting.CreateIRS1099File(DbContext, PaymentYear, IsLastFiling, IsTestFile, EmployeeCode, FederalTaxID, IRSTCC, CombinedFederalStateFiler, IsCorrectionFile, OutputPath, IRS1099ProcessingList, Form1099Type)

                        End Using

                    Catch ex As Exception

                        ErrorMessage = "Failed trying to create 1099 file.  Please contact software support."
                        ErrorMessage += vbCrLf & ex.Message

                    Finally

                        Me.CloseWaitForm()

                    End Try

                End If

            Else

                ErrorMessage = "Fix errors in grid first."

            End If

            If ErrorMessage IsNot Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim _1099ProcessingForm As AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingForm = Nothing

            _1099ProcessingForm = New AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingForm

            _1099ProcessingForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub IRS1099ProcessingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True

            ButtonItemActions_Settings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
            ButtonItemActions_Search.Image = AdvantageFramework.My.Resources.InvoiceFindImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.InvoicePrintImage
            ButtonItemActions_Transmit.Image = AdvantageFramework.My.Resources.InvoiceTransmitImage

            ButtonItemVendor_Edit.Image = AdvantageFramework.My.Resources.VendorImage
            ButtonItemVendor_Edit.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)
            ButtonItemVendor_Edit.Tag = ButtonItemVendor_Edit.Enabled

            ButtonItemMaintenance_FederalStateCodes.Image = AdvantageFramework.My.Resources.MaintenanceImage

            DataGridViewForm_1099Data.AutoFilterLookupColumns = True

            DataGridViewForm_1099Data.ShowSelectDeselectAllButtons = True

        End Sub
        Private Sub IRS1099ProcessingForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_PrintStandardReport_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintStandardReport.Click

            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim IRS1099ProcessingAllVendors As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing) = Nothing
            'Dim VendorPayToCodes As IEnumerable(Of String) = Nothing
            'Dim Vendors As IEnumerable(Of String) = Nothing

            If DataGridViewForm_1099Data.HasRows Then

                ParameterList = New Generic.Dictionary(Of String, Object)

                IRS1099ProcessingAllVendors = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)

                IRS1099ProcessingAllVendors.AddRange(DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)().ToList)

                'VendorPayToCodes = (From V In IRS1099ProcessingAllVendors
                '                    Select V.VendorCode).ToList

                'Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                '    Vendors = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                '               Where Vendor.Vendor1099Flag = 1 AndAlso
                '                     VendorPayToCodes.Contains(Vendor.PayToCode) = False
                '               Select Vendor.PayToCode).Distinct.ToList

                '    If Vendors IsNot Nothing AndAlso Vendors.Count > 0 Then

                '        IRS1099ProcessingAllVendors.AddRange(From Vendor In Vendors
                '                                             Select New AdvantageFramework.AccountPayable.Classes.IRS1099Processing(DbContext, Vendor, 0))

                '    End If

                'End Using

                ParameterList.Add("DataSource", IRS1099ProcessingAllVendors)
                ParameterList.Add("CheckDateRange", _StartDate.Value.ToShortDateString & " to " & _EndDate.Value.ToShortDateString)

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.Standard1099, ParameterList, Nothing, Nothing, Nothing, Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_PrintStandardForm_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintStandardForm.Click

            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim DistinctCategories As IEnumerable(Of Short) = Nothing

            If VendorsComplete(Nothing) Then

                If DataGridViewForm_1099Data.HasRows Then

                    DistinctCategories = (From Entity In DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)
                                          Select Entity.Vendor1099Category).Distinct.ToArray

                    If DistinctCategories IsNot Nothing AndAlso DistinctCategories.Count > 0 AndAlso
                            ((DistinctCategories.Count = 1 And DistinctCategories.First = CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)) OrElse
                             DistinctCategories.Contains(CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)) = False) Then

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        ParameterList.Add("DataSource", DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)())

                        If DistinctCategories.Count = 1 And DistinctCategories.First = CShort(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation) Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please be sure your printer is loaded with the 1099 Non Employee Compensation form.")

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.Standard1099NECForm, ParameterList, Nothing, Nothing, Nothing, Nothing)

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please be sure your printer is loaded with the 1099 Misc form.")

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.Standard1099Form, ParameterList, Nothing, Nothing, Nothing, Nothing)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select vendors whose income type is only 'Non Employee Compensation' or not 'Non Employee Compensation'.")

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid first.")

            End If

        End Sub
        Private Sub ButtonItemActions_Print1099ReportAllVendorsSummary_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print1099ReportAllVendorsSummary.Click

            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim SelectedVendors As Generic.List(Of String) = Nothing
            Dim IRS1099AllVendorsSummaryReports As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport) = Nothing
            Dim IRS1099AllVendorsSummaryReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport) = Nothing
            Dim SqlParameterStartDate As SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As SqlClient.SqlParameter = Nothing

            SelectedVendors = DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Select(Function(V) V.VendorCode).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SqlParameterStartDate = New SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime)
                SqlParameterEndDate = New SqlClient.SqlParameter("@end_date", SqlDbType.SmallDateTime)

                SqlParameterStartDate.Value = _StartDate
                SqlParameterEndDate.Value = _EndDate

                IRS1099AllVendorsSummaryReports = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.IRS1099AllVendorsSummaryReport) _
                        ("exec advsp_1099_report_all_vendors_summary @start_date, @end_date", SqlParameterStartDate, SqlParameterEndDate).ToList

                IRS1099AllVendorsSummaryReportList = (From Entity In IRS1099AllVendorsSummaryReports
                                                      Where _SelectedBanks.Contains(Entity.BankCode) AndAlso
                                                            SelectedVendors.Contains(Entity.VendorCode)
                                                      Select Entity).ToList

            End Using

            ParameterList = New Generic.Dictionary(Of String, Object)

            ParameterList.Add("DataSource", IRS1099AllVendorsSummaryReportList)
            ParameterList.Add("CheckDateRange", _StartDate.Value.ToShortDateString & " to " & _EndDate.Value.ToShortDateString)

            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.Summary1099AllVendors, ParameterList, Nothing, Nothing, Nothing, Nothing)

        End Sub
        Private Sub ButtonItemActions_Print1099ReportWithAPDisbursement_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print1099ReportWithAPDisbursement.Click

            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing

            If DataGridViewForm_1099Data.HasRows Then

                ParameterList = New Generic.Dictionary(Of String, Object)

                ParameterList.Add("DataSource", DataGridViewForm_1099Data.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing)())
                ParameterList.Add("CheckDateRange", _StartDate.Value.ToShortDateString & " to " & _EndDate.Value.ToShortDateString)
                ParameterList.Add("StartDate", _StartDate.Value.ToShortDateString)
                ParameterList.Add("EndDate", _EndDate.Value.ToShortDateString)

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.Detail1099WithDisbursement, ParameterList, Nothing, Nothing, Nothing, Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_Search_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Search.Click

            If AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSearchDialog.ShowFormDialog(_StartDate, _EndDate, _SelectedBanks) = System.Windows.Forms.DialogResult.OK Then

                LoadGrid(_StartDate, _EndDate, _SelectedBanks)

            End If

        End Sub
        Private Sub ButtonItemActions_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Settings.Click

            'objects
            Dim SettingsFormFound As Boolean = False

            If Me.MdiParent IsNot Nothing Then

                For Each MDIChild In Me.MdiParent.MdiChildren

                    If MDIChild.GetType Is GetType(AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSettingsSetupForm) Then

                        MDIChild.Activate()
                        SettingsFormFound = True
                        Exit For

                    End If

                Next

            End If

            If SettingsFormFound = False Then

                AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSettingsSetupForm.ShowForm()

            End If

        End Sub
        Private Sub ButtonItemMaintenance_FederalStateCodes_Click(sender As Object, e As EventArgs) Handles ButtonItemMaintenance_FederalStateCodes.Click

            AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099CombinedFederalStateFilingEditDialog.ShowFormDialog()

        End Sub
        Private Sub ButtonItemVendor_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemVendor_Edit.Click

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorCode As String = Nothing

            If DataGridViewForm_1099Data.HasASelectedRow Then

                VendorCode = DirectCast(DataGridViewForm_1099Data.GetFirstSelectedRowDataBoundItem, AdvantageFramework.AccountPayable.Classes.IRS1099Processing).VendorCode

                AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog.ShowFormDialog(VendorCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                    DirectCast(DataGridViewForm_1099Data.GetFirstSelectedRowDataBoundItem, AdvantageFramework.AccountPayable.Classes.IRS1099Processing).Vendor = Vendor

                    DirectCast(DataGridViewForm_1099Data.GetFirstSelectedRowDataBoundItem, AdvantageFramework.AccountPayable.Classes.IRS1099Processing).ValidateEntity(True)

                    DataGridViewForm_1099Data.CurrentView.RefreshRow(DataGridViewForm_1099Data.CurrentView.FocusedRowHandle)

                End Using

            End If

        End Sub
        Private Sub ButtonItemTransmit_1099MISC_Click(sender As Object, e As EventArgs) Handles ButtonItemTransmit_1099MISC.Click

            Transmit(Exporting.Methods.Form1099.MISC)

        End Sub
        Private Sub ButtonItemTransmit_1099NEC_Click(sender As Object, e As EventArgs) Handles ButtonItemTransmit_1099NEC.Click

            Transmit(Exporting.Methods.Form1099.NEC)

        End Sub
        Private Sub DataGridViewForm_1099Data_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_1099Data.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace