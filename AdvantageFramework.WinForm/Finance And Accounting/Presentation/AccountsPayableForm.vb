Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum APViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Vendor")>
            ByVendor = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Invoice")>
            ByInvoice = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "By Invoice Detail")>
            ByInvoiceDetail = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "By Alert Status")>
            ByAlertStatus = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "By Vendor Pay To Name")>
            ByVendorPayToName = 4
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _GridViewVendorInvoiceDetailsLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _APControlSetInvoice As Boolean = False
        Private _BatchDate As Date = Nothing
        Private _IsMultiCurrencyEnabled As Boolean = False
        Private _CurrencyCodeHome As String = Nothing
        Private _CanUserCustom1 As Boolean = False
        Private _VendorCategories As IEnumerable(Of String) = {"I", "M", "N", "O", "R", "T"}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_VendorInvoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Entities.Vendor)

                DataGridViewLeftSection_VendorInvoices.DataSource = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Include("Office").Include("Market")
                                                                     Where (Not _CanUserCustom1 OrElse
                                                                           (_CanUserCustom1 AndAlso
                                                                            (_VendorCategories.Contains(Vendor.VendorCategory) OrElse
                                                                             Vendor.InternetCategory = 1 OrElse Vendor.MagazineCategory = 1 OrElse Vendor.NewspaperCategory = 1 OrElse
                                                                             Vendor.OutOfHomeCategory = 1 OrElse Vendor.RadioCategory = 1 OrElse Vendor.TVCategory = 1))) AndAlso
                                                                           Vendor.ActiveFlag = 1 AndAlso
                                                                           ((Session.HasLimitedOfficeCodes AndAlso
                                                                             Session.AccessibleOfficeCodes.Contains(Vendor.OfficeCode)) OrElse
                                                                            (Not Session.HasLimitedOfficeCodes))
                                                                     Select Vendor.Code,
                                                                            Vendor.Name,
                                                                            [Category] = Vendor.VendorCategory,
                                                                            Vendor.OfficeCode,
                                                                            [OfficeName] = If(Vendor.Office Is Nothing, "", Vendor.Office.Name),
                                                                            Vendor.DefaultAPAccount,
                                                                            Vendor.MarketCode,
                                                                            [MarketDescription] = If(Vendor.Market Is Nothing, "", Vendor.Market.Description),
                                                                            [VendorCity] = Vendor.City,
                                                                            [VendorState] = Vendor.State).ToList

                DataGridViewLeftSection_VendorInvoices.CurrentView.BestFitColumns()

                PanelForm_LeftSection.Width = DataGridViewLeftSection_VendorInvoices.CurrentView.Columns(0).Width + DataGridViewLeftSection_VendorInvoices.CurrentView.Columns(1).Width + (PanelForm_LeftSection.Width - DataGridViewLeftSection_VendorInvoices.Width) + 35
                ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(PanelForm_LeftSection.Location.X, 0)

            End Using

        End Sub
        Private Sub ChangeView(ByVal RefreshControl As Boolean)

            Static Value As Object = Nothing
            Static Criteria As Integer = 0
            Static PreviousSelectedIndex As Integer
            Dim VendorCodes As IEnumerable(Of String) = Nothing

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading Then

                If CheckForUnsavedChanges() Then

                    If ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByVendor Then

                        DataGridViewLeftSection_VendorInvoices.Visible = True
                        DataGridViewLeftSection_VendorInvoices.CurrentView.CollapseAllDetails()

                        DataGridViewLeftSection_Invoices.Visible = False

                        AccountsPayableRightSection_AP.ClearControl()

                        If RefreshControl Then

                            AccountsPayableRightSection_AP.RefreshControl()

                            LoadGrid()

                        End If

                        PreviousSelectedIndex = APViewLayout.ByVendor
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    ElseIf ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByInvoice Then

                        If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Refreshing Then

                            Me.ShowWaitForm()

                            DataGridViewLeftSection_VendorInvoices.Visible = False

                            DataGridViewLeftSection_Invoices.Visible = True
                            DataGridViewLeftSection_Invoices.DataSource = Nothing
                            DataGridViewLeftSection_Invoices.ClearGridCustomization()

                            DataGridViewLeftSection_Invoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Views.VendorInvoice)

                            Me.FormAction = WinForm.Presentation.FormActions.Loading

                            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                DataGridViewLeftSection_Invoices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorInvoice.Load(DbContext)
                                                                               Where (Not _CanUserCustom1 OrElse
                                                                                      (_CanUserCustom1 AndAlso
                                                                                      _VendorCategories.Contains(Entity.VendorCategory))) AndAlso
                                                                                     ((Session.HasLimitedOfficeCodes AndAlso
                                                                                       Session.AccessibleOfficeCodes.Contains(Entity.VendorOfficeCode)) OrElse
                                                                                      (Not Session.HasLimitedOfficeCodes))
                                                                               Select Entity).ToList.OrderByDescending(Function(Entity) Entity.EntryDate)

                                If DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorName.ToString) IsNot Nothing Then

                                    DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorName.ToString).Visible = True

                                End If

                                If DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorPayToName.ToString) IsNot Nothing Then

                                    DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorPayToName.ToString).Visible = False

                                End If

                                If DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.QuickBooks.ToString) IsNot Nothing Then

                                    DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.QuickBooks.ToString).Visible = Me.AccountsPayableRightSection_AP.IsQuickbooksEnabled

                                End If

                            End Using

                            Me.FormAction = WinForm.Presentation.FormActions.None

                            AccountsPayableRightSection_AP.ClearControl()

                            If RefreshControl Then

                                AccountsPayableRightSection_AP.RefreshControl()

                            End If

                            DataGridViewLeftSection_Invoices.FocusToFindPanel(True)

                            DataGridViewLeftSection_Invoices.CurrentView.BestFitColumns()

                            Me.CloseWaitForm()

                            PreviousSelectedIndex = APViewLayout.ByInvoice

                        End If

                    ElseIf ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByInvoiceDetail Then

                        If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableInitialLoadingDialog.ShowFormDialog(Value, Criteria) = System.Windows.Forms.DialogResult.OK Then

                            Me.ShowWaitForm()

                            DataGridViewLeftSection_VendorInvoices.Visible = False

                            DataGridViewLeftSection_Invoices.Visible = True
                            DataGridViewLeftSection_Invoices.DataSource = Nothing
                            DataGridViewLeftSection_Invoices.ClearGridCustomization()

                            DataGridViewLeftSection_Invoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Classes.VendorInvoiceDetail)

                            Me.FormAction = WinForm.Presentation.FormActions.Loading

                            Select Case Criteria

                                Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.GLACode

                                    DataGridViewLeftSection_Invoices.DataSource = (From Entity In AdvantageFramework.AccountPayable.GetVendorInvoiceDetail(Session, Criteria, CStr(Value), 0)
                                                                                   Where (Not _CanUserCustom1 OrElse
                                                                                          (_CanUserCustom1 AndAlso
                                                                                           _VendorCategories.Contains(Entity.VendorCategory)))).ToList

                                Case Else

                                    DataGridViewLeftSection_Invoices.DataSource = (From Entity In AdvantageFramework.AccountPayable.GetVendorInvoiceDetail(Session, Criteria, "", CInt(Value))
                                                                                   Where (Not _CanUserCustom1 OrElse
                                                                                          (_CanUserCustom1 AndAlso
                                                                                           _VendorCategories.Contains(Entity.VendorCategory)))).ToList

                            End Select

                            Me.FormAction = WinForm.Presentation.FormActions.None

                            AccountsPayableRightSection_AP.ClearControl()

                            If RefreshControl Then

                                AccountsPayableRightSection_AP.RefreshControl()

                            End If

                            DataGridViewLeftSection_Invoices.FocusToFindPanel(True)

                            DataGridViewLeftSection_Invoices.CurrentView.BestFitColumns()

                            Me.CloseWaitForm()

                            PreviousSelectedIndex = APViewLayout.ByInvoiceDetail

                        Else

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                            ComboBoxItemActions_View.SelectedIndex = PreviousSelectedIndex

                            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        End If

                    ElseIf ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByAlertStatus Then

                        Me.ShowWaitForm()

                        DataGridViewLeftSection_VendorInvoices.Visible = False

                        DataGridViewLeftSection_Invoices.Visible = True
                        DataGridViewLeftSection_Invoices.DataSource = Nothing
                        DataGridViewLeftSection_Invoices.ClearGridCustomization()

                        DataGridViewLeftSection_Invoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Views.VendorInvoiceAlert)

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DataGridViewLeftSection_Invoices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorInvoiceAlert.Load(DbContext)
                                                                           Where (Not _CanUserCustom1 OrElse
                                                                                      (_CanUserCustom1 AndAlso
                                                                                      _VendorCategories.Contains(Entity.VendorCategory))) AndAlso
                                                                                 ((Session.HasLimitedOfficeCodes AndAlso
                                                                                  Session.AccessibleOfficeCodes.Contains(Entity.VendorOfficeCode)) OrElse
                                                                                  (Not Session.HasLimitedOfficeCodes))
                                                                           Select Entity).OrderBy(Function(Entity) Entity.VendorCode).ToList

                        End Using

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        AccountsPayableRightSection_AP.ClearControl()

                        If RefreshControl Then

                            AccountsPayableRightSection_AP.RefreshControl()

                        End If

                        DataGridViewLeftSection_Invoices.FocusToFindPanel(True)

                        DataGridViewLeftSection_Invoices.CurrentView.BestFitColumns()

                        Me.CloseWaitForm()

                        PreviousSelectedIndex = APViewLayout.ByAlertStatus

                    ElseIf ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByVendorPayToName Then

                        Me.ShowWaitForm()

                        DataGridViewLeftSection_VendorInvoices.Visible = False

                        DataGridViewLeftSection_Invoices.Visible = True
                        DataGridViewLeftSection_Invoices.DataSource = Nothing
                        DataGridViewLeftSection_Invoices.ClearGridCustomization()

                        DataGridViewLeftSection_Invoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Views.VendorInvoice)

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            VendorCodes = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Include("Office").Include("Market")
                                           Where (Not _CanUserCustom1 OrElse
                                                    (_CanUserCustom1 AndAlso
                                                    (_VendorCategories.Contains(Vendor.VendorCategory) OrElse
                                                    Vendor.InternetCategory = 1 OrElse Vendor.MagazineCategory = 1 OrElse Vendor.NewspaperCategory = 1 OrElse
                                                    Vendor.OutOfHomeCategory = 1 OrElse Vendor.RadioCategory = 1 OrElse Vendor.TVCategory = 1))) AndAlso
                                                    Vendor.ActiveFlag = 1 AndAlso
                                                    ((Session.HasLimitedOfficeCodes AndAlso
                                                        Session.AccessibleOfficeCodes.Contains(Vendor.OfficeCode)) OrElse
                                                    (Not Session.HasLimitedOfficeCodes))
                                           Select Vendor.Code).Distinct.ToArray

                            DataGridViewLeftSection_Invoices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorInvoice.Load(DbContext)
                                                                           Where VendorCodes.Contains(Entity.VendorCode)
                                                                           Select Entity).ToList

                            If DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorName.ToString) IsNot Nothing Then

                                DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorName.ToString).Visible = False

                            End If

                            If DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorPayToName.ToString) IsNot Nothing Then

                                DataGridViewLeftSection_Invoices.CurrentView.Columns(AdvantageFramework.Database.Views.VendorInvoice.Properties.VendorPayToName.ToString).Visible = True

                            End If

                        End Using

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        AccountsPayableRightSection_AP.ClearControl()

                        If RefreshControl Then

                            AccountsPayableRightSection_AP.RefreshControl()

                        End If

                        DataGridViewLeftSection_Invoices.FocusToFindPanel(True)

                        DataGridViewLeftSection_Invoices.CurrentView.BestFitColumns()

                        Me.CloseWaitForm()

                        PreviousSelectedIndex = APViewLayout.ByVendorPayToName

                    End If

                    ButtonItemFlags_Edit.Checked = False

                    HideOrShowRibbonBarOptions()

                    ToggleEdit(False)

                    EnableOrDisableActions()

                Else

                    ComboBoxItemActions_View.SelectedIndex = PreviousSelectedIndex

                End If

            End If

            Me.ClearValidations()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            CheckForUnsavedChanges = AccountsPayableRightSection_AP.CheckForUnsavedChanges

        End Function
        Private Sub HideOrShowRibbonBarOptions()

            Dim Left As Integer = 3

            Left = RibbonBarOptions_Actions.Width + RibbonBarOptions_RecurAP.Width + RibbonBarOptions_Vendor.Width + RibbonBarOptions_Import.Width + RibbonBarOptions_ExpenseReports.Width + 10

            If ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByVendor Then

                Me.RibbonBarOptions_Flags.Visible = False

            Else

                RibbonBarOptions_Flags.Left = Left + 2
                Left = Left + RibbonBarOptions_Flags.Width + 2
                RibbonBarOptions_Flags.Visible = True

            End If

            If AccountsPayableRightSection_AP.Visible AndAlso AccountsPayableRightSection_AP.HasAccessToDocuments Then

                RibbonBarOptions_View.Left = Left + 2
                Left = Left + RibbonBarOptions_View.Width + 2
                RibbonBarOptions_View.Visible = True

            Else

                RibbonBarOptions_View.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_NonClientTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_NonClient.Left = Left + 2
                RibbonBarOptions_NonClient.Visible = True

            Else

                RibbonBarOptions_NonClient.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_ProductionTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Production.Left = Left + 2
                RibbonBarOptions_Production.Visible = True

            Else

                RibbonBarOptions_Production.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_InternetTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Internet.Left = Left + 2
                RibbonBarOptions_Internet.Visible = True

            Else

                RibbonBarOptions_Internet.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_MagazineTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Magazine.Left = Left + 2
                RibbonBarOptions_Magazine.Visible = True

            Else

                RibbonBarOptions_Magazine.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_NewspaperTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Newspaper.Left = Left + 2
                RibbonBarOptions_Newspaper.Visible = True

            Else

                RibbonBarOptions_Newspaper.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_OutOfHomeTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_OutOfHome.Left = Left + 2
                RibbonBarOptions_OutOfHome.Visible = True

            Else

                RibbonBarOptions_OutOfHome.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_RadioTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Radio.Left = Left + 2
                RibbonBarOptions_Radio.Visible = True

            Else

                RibbonBarOptions_Radio.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_RadioDetailsTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_RadioDetails.Left = Left + 2
                RibbonBarOptions_RadioDetails.Visible = True

            Else

                RibbonBarOptions_RadioDetails.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_TVTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_TV.Left = Left + 2
                RibbonBarOptions_TV.Visible = True

            Else

                RibbonBarOptions_TV.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_TVDetailsTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_TVDetails.Left = Left + 2
                RibbonBarOptions_TVDetails.Visible = True

            Else

                RibbonBarOptions_TVDetails.Visible = False

            End If
            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_DocumentsTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Documents.Left = Left + 2
                RibbonBarOptions_Documents.Visible = True

            Else

                RibbonBarOptions_Documents.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_ExpenseReceiptsTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_ExpenseReceipts.Left = Left + 2
                RibbonBarOptions_ExpenseReceipts.Visible = True

            Else

                RibbonBarOptions_ExpenseReceipts.Visible = False

            End If

            If AccountsPayableRightSection_AP.SelectedTab Is AccountsPayableRightSection_AP.TabItemAPDetails_ExpenseReceiptsTab AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue Then

                RibbonBarOptions_Filter.Left = Left + 2
                RibbonBarOptions_Filter.Visible = True

            Else

                RibbonBarOptions_Filter.Visible = False

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If Not Me.IsFormClosing AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso Not AccountsPayableRightSection_AP.IsLoading AndAlso Not AccountsPayableRightSection_AP.IsClearing Then

                RibbonBarMergeContainerForm_Options.SuspendLayout()

                'ButtonItemActions_ShowHome.Visible = _IsMultiCurrencyEnabled AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_CurrencyCode.GetSelectedValue <> _CurrencyCodeHome

                RibbonBarOptions_Quickbooks.Visible = AccountsPayableRightSection_AP.IsQuickbooksEnabled

                RibbonBarOptions_Vendor.Enabled = AccountsPayableRightSection_AP.Visible

                ButtonItemActions_Add.Enabled = AccountsPayableRightSection_AP.CanAdd
                ButtonItemActions_AddSearch.Enabled = AccountsPayableRightSection_AP.CanAdd

                ButtonItemFlags_Edit.Enabled = AccountsPayableRightSection_AP.CanUpdate

                ButtonItemActions_Print.Enabled = AccountsPayableRightSection_AP.CanPrint

                If DataGridViewLeftSection_VendorInvoices.GridControl.FocusedView IsNot Nothing AndAlso _GridViewVendorInvoiceDetailsLevel1Tab1 IsNot Nothing OrElse
                        AccountsPayableRightSection_AP.Visible = False Then

                    ButtonItemActions_Save.Enabled = False
                    ButtonItemQuickbooks_SendToQuickbooks.Enabled = False
                    ButtonItemQuickbooks_UpdateQuickbooks.Enabled = False

                    'Me.AccountsPayableRightSection_AP.ComboBoxControl_PostPeriodForMod.Enabled = ButtonItemActions_Save.Enabled

                    ButtonItemActions_Delete.Enabled = False

                    ButtonItemActions_Alerts.Enabled = False

                    ButtonItemVendor_Edit.Enabled = False

                    If Not AccountsPayableRightSection_AP.IsDeleted AndAlso AccountsPayableRightSection_AP.Visible Then

                        If DataGridViewLeftSection_VendorInvoices.GridControl.FocusedView.Name = _GridViewVendorInvoiceDetailsLevel1Tab1.Name OrElse
                                (AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.HasASelectedValue AndAlso
                                AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue) Then

                            If AccountsPayableRightSection_AP.CanUpdate Then

                                ButtonItemActions_Save.Enabled = (AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(AccountsPayableRightSection_AP) AndAlso
                                                              AccountsPayableRightSection_AP.NumericInputDistribution_Balance.EditValue = 0)
                                ButtonItemFlags_Edit.Enabled = Not ButtonItemActions_Save.Enabled
                                'Me.AccountsPayableRightSection_AP.ComboBoxControl_PostPeriodForMod.Enabled = ButtonItemActions_Save.Enabled

                                ButtonItemQuickbooks_SendToQuickbooks.Enabled = AccountsPayableRightSection_AP.SendToQuickbooksEnabled AndAlso Not ButtonItemActions_Save.Enabled
                                ButtonItemQuickbooks_UpdateQuickbooks.Enabled = AccountsPayableRightSection_AP.UpdateQuickbooksEnabled AndAlso Not ButtonItemActions_Save.Enabled

                            End If

                            ButtonItemActions_Delete.Enabled = AccountsPayableRightSection_AP.CanUpdate

                            ButtonItemActions_Alerts.Enabled = True
                            ButtonItemAlerts_NewAlertAssignment.Enabled = True
                            ButtonItemAlerts_View.Enabled = True
                            ButtonItemAlerts_NewAlert.Enabled = False

                            If AccountsPayableRightSection_AP.TabControlControl_APDetails.SelectedTab.Equals(AccountsPayableRightSection_AP.TabItemAPDetails_ExpenseReceiptsTab) Then

                                ButtonItemExpenseReceipts_Download.Enabled = AccountsPayableRightSection_AP.DocumentManagerControlExpenseReceipts_Receipts.HasASelectedDocument

                            Else

                                ButtonItemExpenseReceipts_Download.Enabled = False

                            End If

                            ButtonItemNonClient_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewNonClientDistributionDetailIsNewItemRow
                            ButtonItemNonClient_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewNonClientDistributionDetailsHasASelectedRow

                            If AccountsPayableRightSection_AP.DataGridViewNonClientDistributionDetailsHasOnlyOneSelectedRow AndAlso
                                    AccountsPayableRightSection_AP.NonClientPONumber IsNot Nothing AndAlso
                                    AccountsPayableRightSection_AP.NonClientPOLineNumber IsNot Nothing Then

                                ButtonItemNonClient_PODetail.Enabled = True

                            Else

                                ButtonItemNonClient_PODetail.Enabled = False

                            End If

                            ButtonItemProduction_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewProductionDistributionDetailIsNewItemRow
                            ButtonItemProduction_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewProductionDistributionDetailsHasASelectedRow

                            If AccountsPayableRightSection_AP.DataGridViewProductionDistributionDetailsHasOnlyOneSelectedRow AndAlso
                                    AccountsPayableRightSection_AP.ProductionPONumber IsNot Nothing AndAlso
                                    AccountsPayableRightSection_AP.ProductionPOLineNumber IsNot Nothing Then

                                ButtonItemProduction_PODetail.Enabled = True

                            Else

                                ButtonItemProduction_PODetail.Enabled = False

                            End If

                            ButtonItemNewspaper_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewNewspaperDistributionDetailIsNewItemRow
                            ButtonItemNewspaper_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewNewspaperDistributionDetailIsNewItemRow
                            ButtonItemNewspaper_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewNewspaperDistributionDetailsHasASelectedRow
                            ButtonItemNewspaper_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewNewspaperDistributionDetailsHasOnlyOneSelectedRow

                            ButtonItemMagazine_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewMagazineDistributionDetailIsNewItemRow
                            ButtonItemMagazine_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewMagazineDistributionDetailIsNewItemRow
                            ButtonItemMagazine_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewMagazineDistributionDetailsHasASelectedRow
                            ButtonItemMagazine_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewMagazineDistributionDetailsHasOnlyOneSelectedRow

                            ButtonItemInternet_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewInternetDistributionDetailIsNewItemRow
                            ButtonItemInternet_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewInternetDistributionDetailIsNewItemRow
                            ButtonItemInternet_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewInternetDistributionDetailsHasASelectedRow
                            ButtonItemInternet_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewInternetDistributionDetailsHasOnlyOneSelectedRow

                            ButtonItemOutOfHome_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewOutOfHomeDistributionDetailIsNewItemRow
                            ButtonItemOutOfHome_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewOutOfHomeDistributionDetailIsNewItemRow
                            ButtonItemOutOfHome_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewOutOfHomeDistributionDetailsHasASelectedRow
                            ButtonItemOutOfHome_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewOutOfHomeDistributionDetailsHasOnlyOneSelectedRow

                            ButtonItemRadio_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewRadioDistributionDetailIsNewItemRow
                            ButtonItemRadio_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewRadioDistributionDetailIsNewItemRow
                            ButtonItemRadio_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewRadioDistributionDetailsHasASelectedRow
                            ButtonItemRadio_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewRadioDistributionDetailsHasOnlyOneSelectedRow AndAlso
                                AccountsPayableRightSection_AP.DataGridViewRadio_DistributionDetails.CurrentView.GetRowCellValue(AccountsPayableRightSection_AP.DataGridViewRadio_DistributionDetails.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail.Properties.OrderLineNumber.ToString) > 0

                            ButtonItemRadioDetails_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewRadioBroadcastDetailsIsNewItemRow
                            ButtonItemRadioDetails_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewRadioBroadcastDetailsHasASelectedRow

                            ButtonItemTV_Add.Enabled = Not AccountsPayableRightSection_AP.DataGridViewTVDistributionDetailIsNewItemRow
                            ButtonItemTV_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewTVDistributionDetailIsNewItemRow
                            ButtonItemTV_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewTVDistributionDetailsHasASelectedRow
                            ButtonItemTV_Approvals.Enabled = AccountsPayableRightSection_AP.DataGridViewTVDistributionDetailsHasOnlyOneSelectedRow AndAlso
                                AccountsPayableRightSection_AP.DataGridViewTV_DistributionDetails.CurrentView.GetRowCellValue(AccountsPayableRightSection_AP.DataGridViewTV_DistributionDetails.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail.Properties.OrderLineNumber.ToString) > 0

                            ButtonItemTVDetails_Cancel.Enabled = AccountsPayableRightSection_AP.DataGridViewTVBroadcastDetailsIsNewItemRow
                            ButtonItemTVDetails_Delete.Enabled = AccountsPayableRightSection_AP.DataGridViewTVBroadcastDetailsHasASelectedRow

                            If RibbonBarOptions_Documents.Visible Then

                                ButtonItemDocuments_Delete.Enabled = AccountsPayableRightSection_AP.DocumentManager.HasOnlyOneSelectedDocument
                                ButtonItemDocuments_Download.Enabled = If(AccountsPayableRightSection_AP.DocumentManager.HasOnlyOneSelectedDocument, Not AccountsPayableRightSection_AP.DocumentManager.IsSelectedDocumentAURL, AccountsPayableRightSection_AP.DocumentManager.HasASelectedDocument)
                                ButtonItemDocuments_OpenURL.Enabled = If(AccountsPayableRightSection_AP.DocumentManager.HasOnlyOneSelectedDocument, AccountsPayableRightSection_AP.DocumentManager.IsSelectedDocumentAURL, False)
                                ButtonItemDocuments_Upload.Enabled = AccountsPayableRightSection_AP.DocumentManager.CanUpload

                            Else

                                ButtonItemDocuments_Upload.Enabled = False
                                ButtonItemDocuments_Delete.Enabled = False
                                ButtonItemDocuments_Download.Enabled = False
                                ButtonItemDocuments_OpenURL.Enabled = False

                            End If

                        End If

                    End If

                End If

                RibbonBarOptions_Actions.ResetCachedContentSize()
                RibbonBarOptions_Actions.Refresh()
                RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth
                RibbonBarOptions_Actions.Refresh()

                ButtonItemVendor_Edit.Enabled = (AccountsPayableRightSection_AP.Visible AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.HasASelectedValue)

                ButtonItemView_Documents.Enabled = (AccountsPayableRightSection_AP.Visible AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.HasASelectedValue _
                                                    AndAlso AccountsPayableRightSection_AP.SearchableComboBoxControl_InvoiceNumber.HasASelectedValue)

                RibbonBarMergeContainerForm_Options.ResumeLayout()

            End If

        End Sub
        Private Sub LoadSelectedVendorInvoice()

            Dim AccountPayableID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing

            If PanelForm_RightSection.Visible Then

                If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.AccountPayableID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.SequenceNumber.ToString)

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.ID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.SequenceNumber.ToString)

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableSequenceNumber.ToString)

                End If

                LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)

            End If

        End Sub
        Private Sub LoadSelectedVendorInvoice(ByVal AccountPayableID As Integer, ByVal SequenceNumber As Integer)

            Dim VendorCode As String = Nothing

            _APControlSetInvoice = True

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            If AccountPayableID = 0 Then

                AccountsPayableRightSection_AP.ClearControl()
                AccountsPayableRightSection_AP.Enabled = False

            ElseIf (AccountsPayableRightSection_AP.AccountPayableID <> AccountPayableID OrElse AccountsPayableRightSection_AP.SequenceNumber <> SequenceNumber) Then

                If AccountsPayableRightSection_AP.LoadControl(VendorCode, AccountPayableID, SequenceNumber, _BatchDate, ButtonItemActions_ShowGross.Checked, ButtonItemView_Documents.Checked) = False Then ', ButtonItemActions_ShowHome.Visible AndAlso ButtonItemActions_ShowHome.Checked) = False Then

                    AccountsPayableRightSection_AP.ClearControl()
                    AccountsPayableRightSection_AP.Enabled = False

                Else

                    ClearChanged()
                    ClearValidations()
                    AccountsPayableRightSection_AP.Enabled = True

                End If

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

            _APControlSetInvoice = False

        End Sub
        Private Sub LoadDetailViews()

            Dim APViewDeletedInvoices As Boolean = False

            DataGridViewLeftSection_VendorInvoices.CurrentView.BeginUpdate()

            _GridViewVendorInvoiceDetailsLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewLeftSection_VendorInvoices.GridControl.LevelTree.Nodes.Add("VendorInvoiceDetailsLevel1Tab1", _GridViewVendorInvoiceDetailsLevel1Tab1)

            _GridViewVendorInvoiceDetailsLevel1Tab1.LevelIndent = 1

            _GridViewVendorInvoiceDetailsLevel1Tab1.ChildGridLevelName = "VendorInvoiceDetailsLevel1Tab1"
            _GridViewVendorInvoiceDetailsLevel1Tab1.GridControl = DataGridViewLeftSection_VendorInvoices.GridControl
            _GridViewVendorInvoiceDetailsLevel1Tab1.Name = "_GridViewVendorInvoiceDetailsLevel1Tab1"

            _GridViewVendorInvoiceDetailsLevel1Tab1.Session = Me.Session

            _GridViewVendorInvoiceDetailsLevel1Tab1.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewVendorInvoiceDetailsLevel1Tab1.ObjectType = GetType(AdvantageFramework.Database.Classes.VendorInvoice)

            _GridViewVendorInvoiceDetailsLevel1Tab1.OptionsDetail.ShowDetailTabs = False
            _GridViewVendorInvoiceDetailsLevel1Tab1.OptionsSelection.MultiSelect = False
            _GridViewVendorInvoiceDetailsLevel1Tab1.OptionsView.ShowViewCaption = False

            _GridViewVendorInvoiceDetailsLevel1Tab1.CreateColumnsBasedOnObjectType()

            _GridViewVendorInvoiceDetailsLevel1Tab1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            _GridViewVendorInvoiceDetailsLevel1Tab1.OptionsView.ShowFooter = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                APViewDeletedInvoices = AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(DbContext)

            End Using

            For Each GridColumn In _GridViewVendorInvoiceDetailsLevel1Tab1.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.InvoiceNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.InvoiceDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.EntryDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.InvoiceDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.InvoiceAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.ApprovalStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.IsPaymentOnHold.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.Is1099Invoice.ToString Then

                    GridColumn.Visible = True

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.Is1099Invoice.ToString Then

                        GridColumn.Caption = "Is 1099 Invoice"

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.InvoiceAmount.ToString Then

                        GridColumn.Caption = "Invoice Total"

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.IsPaymentOnHold.ToString Then

                        GridColumn.Caption = "Payment Hold"

                    End If

                ElseIf APViewDeletedInvoices AndAlso GridColumn.FieldName = AdvantageFramework.Database.Classes.VendorInvoice.Properties.IsDeleted.ToString Then

                    GridColumn.Visible = True

                Else

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.ShowInExpressionEditor = False

                End If

            Next

            DataGridViewLeftSection_VendorInvoices.CurrentView.EndUpdate()

        End Sub
        Private Sub LaunchBatchReport()

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim AccountPayableBatchReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing
            Dim UserCode As String = Nothing
            Dim IsBatch As Boolean = False
            Dim ContinueReport As Boolean = False
            Dim ReportRange As String = Nothing
            Dim IsImport As Boolean = False
            Dim DetailPageBreak As Boolean = False
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsBatch As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsImport As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserCode = Me.Session.UserCode

                If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableBatchReportDialog.ShowFormDialog(ReportType, [From], [To], UserCode, IsBatch, IsImport, DetailPageBreak) = System.Windows.Forms.DialogResult.OK Then

                    SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
                    SqlParameterFromDate = New SqlClient.SqlParameter("@from_date", SqlDbType.SmallDateTime)
                    SqlParameterToDate = New SqlClient.SqlParameter("@to_date", SqlDbType.SmallDateTime)
                    SqlParameterIsBatch = New SqlClient.SqlParameter("@is_batch", SqlDbType.Int)
                    SqlParameterIsImport = New SqlClient.SqlParameter("@is_import", SqlDbType.Int)

                    SqlParameterUserCode.Value = UserCode
                    SqlParameterFromDate.Value = [From]

                    If IsBatch Then

                        SqlParameterToDate.Value = DBNull.Value
                        SqlParameterIsBatch.Value = 1
                        SqlParameterIsImport.Value = 0
                        ReportRange = "Batch: " & [From].ToString

                    ElseIf IsImport Then

                        SqlParameterToDate.Value = [To]
                        SqlParameterIsBatch.Value = 0
                        SqlParameterIsImport.Value = 1
                        ReportRange = "Import Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    Else

                        SqlParameterToDate.Value = [To]
                        SqlParameterIsBatch.Value = 0
                        SqlParameterIsImport.Value = 0
                        ReportRange = "Date Range: " & [From].ToShortDateString & " - " & [To].ToShortDateString

                    End If

                    AccountPayableBatchReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport)("exec advsp_ap_batch_report @user_code, @from_date, @to_date, @is_batch, @is_import", SqlParameterUserCode, SqlParameterFromDate, SqlParameterToDate, SqlParameterIsBatch, SqlParameterIsImport).ToList

                    ContinueReport = True

                End If

            End Using

            If ContinueReport Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary.Add("DataSource", AccountPayableBatchReportList)
                ParameterDictionary.Add("ForUser", UserCode)
                ParameterDictionary.Add("ReportRange", ReportRange)
                ParameterDictionary.Add("DetailPageBreak", DetailPageBreak)

                If ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummary Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchSummary, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.AccountPayableBatchDetail, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                End If

            End If

        End Sub
        Private Sub SelectVendor()

            Dim VendorCode As String = Nothing

            If Not _APControlSetInvoice AndAlso DataGridViewLeftSection_VendorInvoices.Visible Then

                If DataGridViewLeftSection_VendorInvoices.HasASelectedRow Then

                    VendorCode = DataGridViewLeftSection_VendorInvoices.GetFirstSelectedRowBookmarkValue

                    If AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.SelectedValue <> VendorCode Then

                        Me.ShowWaitForm("Processing...")

                        AccountsPayableRightSection_AP.Enabled = True

                        AccountsPayableRightSection_AP.SetVendor(VendorCode, _BatchDate)

                        Me.ClearValidations()
                        Me.ClearChanged()

                        EnableOrDisableActions()

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ToggleEdit(ByVal Editable As Boolean)

            PanelForm_RightSection.Visible = Not Editable
            ExpandableSplitterControlForm_LeftRight.Visible = Not Editable

            If PanelForm_RightSection.Visible Then

                PanelForm_LeftSection.Dock = Windows.Forms.DockStyle.Left

            Else

                PanelForm_LeftSection.Dock = Windows.Forms.DockStyle.Fill

            End If

            For Each GridColumn In DataGridViewLeftSection_Invoices.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.Database.Views.VendorInvoice.Properties.PaymentHold.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.VendorInvoice.Properties.Is1099Invoice.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = Editable

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

        End Sub
        Private Sub CollapseVendorInvoices(ByVal VendorCode As String)

            _APControlSetInvoice = True

            DataGridViewLeftSection_VendorInvoices.SelectRow(VendorCode)

            DataGridViewLeftSection_VendorInvoices.CurrentView.SetMasterRowExpanded(DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle, False)

            _APControlSetInvoice = False

        End Sub
        Private Sub RefreshLeftSideGrid(AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim VendorInvoiceDetailList As Generic.List(Of AdvantageFramework.Database.Classes.VendorInvoiceDetail) = Nothing
            Dim VendorInvoiceAlertList As Generic.List(Of AdvantageFramework.Database.Views.VendorInvoiceAlert) = Nothing
            Dim VendorInvoiceList As Generic.List(Of AdvantageFramework.Database.Views.VendorInvoice) = Nothing

            If AccountPayable IsNot Nothing Then

                If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                    BindingSource = DataGridViewLeftSection_Invoices.DataSource

                    VendorInvoiceDetailList = BindingSource.OfType(Of AdvantageFramework.Database.Classes.VendorInvoiceDetail)() _
                                                                                      .Where(Function(Entity) Entity.ID = AccountPayable.ID AndAlso
                                                                                                              Entity.SequenceNumber = AccountPayable.SequenceNumber).ToList

                    For Each VendorInvoiceDetail In VendorInvoiceDetailList

                        VendorInvoiceDetail.Is1099Invoice = AccountPayable.Is1099Invoice
                        VendorInvoiceDetail.PaymentHold = AccountPayable.IsOnHold

                    Next

                    DataGridViewLeftSection_Invoices.CurrentView.RefreshData()

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                    BindingSource = DataGridViewLeftSection_Invoices.DataSource

                    VendorInvoiceAlertList = BindingSource.OfType(Of AdvantageFramework.Database.Views.VendorInvoiceAlert)() _
                                                                                      .Where(Function(Entity) Entity.AccountPayableID = AccountPayable.ID AndAlso
                                                                                                              Entity.AccountPayableSequenceNumber = AccountPayable.SequenceNumber).ToList

                    For Each VendorInvoiceAlert In VendorInvoiceAlertList

                        VendorInvoiceAlert.Is1099Invoice = AccountPayable.Is1099Invoice
                        VendorInvoiceAlert.PaymentHold = AccountPayable.IsOnHold

                    Next

                    DataGridViewLeftSection_Invoices.CurrentView.RefreshData()

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                    BindingSource = DataGridViewLeftSection_Invoices.DataSource

                    VendorInvoiceList = BindingSource.OfType(Of AdvantageFramework.Database.Views.VendorInvoice)() _
                                                                                      .Where(Function(Entity) Entity.AccountPayableID = AccountPayable.ID AndAlso
                                                                                                              Entity.SequenceNumber = AccountPayable.SequenceNumber).ToList

                    For Each VendorInvoice In VendorInvoiceList

                        VendorInvoice.Is1099Invoice = AccountPayable.Is1099Invoice
                        VendorInvoice.PaymentHold = AccountPayable.IsOnHold

                    Next

                    DataGridViewLeftSection_Invoices.CurrentView.RefreshData()

                End If

            End If

        End Sub
        'Private Sub GetAPShowHomeChecked()

        '    'objects
        '    Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        Try

        '            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.APShowHomeChecked.ToString)

        '        Catch ex As Exception
        '            UserSetting = Nothing
        '        End Try

        '        If UserSetting IsNot Nothing Then

        '            If UserSetting.StringValue = "Y" Then

        '                ButtonItemActions_ShowHome.Checked = True

        '            End If

        '        End If

        '    End Using

        'End Sub
        'Private Sub SaveAPShowHomeChecked()

        '    'objects
        '    Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        Try

        '            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.APShowHomeChecked.ToString)

        '        Catch ex As Exception
        '            UserSetting = Nothing
        '        End Try

        '        If UserSetting IsNot Nothing Then

        '            UserSetting.StringValue = If(ButtonItemActions_ShowHome.Checked, "Y", "N")

        '            AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

        '        ElseIf UserSetting Is Nothing Then

        '            AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.APShowHomeChecked.ToString, If(ButtonItemActions_ShowHome.Checked, "Y", "N"), Nothing, Nothing, UserSetting)

        '        End If

        '    End Using

        'End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AccountsPayableForm As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableForm = Nothing

            AccountsPayableForm = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableForm()

            AccountsPayableForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            'SaveAPShowHomeChecked()

            If e.CloseReason = Windows.Forms.CloseReason.MdiFormClosing Then

                AccountsPayableRightSection_AP.CancelAddNewNonClient()
                AccountsPayableRightSection_AP.CancelAddNewProduction()

            End If

        End Sub
        Private Sub AccountsPayableForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _BatchDate = Now

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_ShowGross.Image = AdvantageFramework.My.Resources.ColumnEditImage
            'ButtonItemActions_ShowHome.Image = AdvantageFramework.My.Resources.ColumnEditImage
            ButtonItemActions_Alerts.Image = AdvantageFramework.My.Resources.AlertImage
            ButtonItemAlerts_View.Icon = AdvantageFramework.My.Resources.AlertIcon
            ButtonItemAlerts_NewAlert.Icon = AdvantageFramework.My.Resources.NewAlertIcon
            ButtonItemAlerts_NewAlertAssignment.Icon = AdvantageFramework.My.Resources.NewAlertAssignmentIcon
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemImport_AP.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemImport_AP.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

            ButtonItemExpenseReports_Approve.Image = AdvantageFramework.My.Resources.ExpenseReportApproved
            ButtonItemExpenseReports_Approve.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

            ButtonItemFlags_Edit.Image = AdvantageFramework.My.Resources.PreferencesImage

            ButtonItemVendor_Edit.Image = AdvantageFramework.My.Resources.VendorImage
            ButtonItemVendor_Edit.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

            ButtonItemNonClient_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemNonClient_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemNonClient_PODetail.Image = AdvantageFramework.My.Resources.PurchaseOrderImage

            ButtonItemProduction_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemProduction_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemProduction_PODetail.Image = AdvantageFramework.My.Resources.PurchaseOrderImage

            ButtonItemNewspaper_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemNewspaper_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemNewspaper_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemNewspaper_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemMagazine_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemMagazine_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemMagazine_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemMagazine_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemRadio_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemRadio_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemRadio_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemRadio_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemRadioDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemRadioDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemTV_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemTV_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemTV_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemTV_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemTVDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemTVDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemOutOfHome_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemOutOfHome_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemOutOfHome_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemOutOfHome_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemInternet_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemInternet_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemInternet_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemInternet_Approvals.Image = AdvantageFramework.My.Resources.AccountsPayableLineItemDetailsImage

            ButtonItemRecurAP_Setup.Image = AdvantageFramework.My.Resources.AccountsPayableCreateRecurringImage
            ButtonItemRecurAP_Setup.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_CreateRecurringAP)

            ButtonItemRecurAP_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage
            ButtonItemRecurAP_Post.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_PostRecurringAP)

            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemView_Documents.Image = AdvantageFramework.My.Resources.DocumentManagerImage

            ButtonItemExpenseReceipts_Download.Image = AdvantageFramework.My.Resources.DownloadDocument

            ButtonItemFilter_All.Image = AdvantageFramework.My.Resources.TableSelectedAllImage
            ButtonItemFilter_SelectedLineItem.Image = AdvantageFramework.My.Resources.TableSelectedRowImage

            ButtonItemQuickbooks_SendToQuickbooks.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemQuickbooks_UpdateQuickbooks.Image = AdvantageFramework.My.Resources.UpdateImage

            DataGridViewLeftSection_VendorInvoices.MultiSelect = False
            DataGridViewLeftSection_Invoices.ByPassUserEntryChanged = True

            DataGridViewLeftSection_VendorInvoices.OptionsView.ShowDetailButtons = True
            DataGridViewLeftSection_VendorInvoices.OptionsDetail.EnableMasterViewMode = True
            DataGridViewLeftSection_VendorInvoices.OptionsDetail.AllowExpandEmptyDetails = True
            DataGridViewLeftSection_VendorInvoices.OptionsDetail.ShowDetailTabs = True
            DataGridViewLeftSection_VendorInvoices.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Entities.Vendor)
            DataGridViewLeftSection_VendorInvoices.ItemDescription = "Active Vendor(s)"

            DataGridViewLeftSection_Invoices.MultiSelect = False

            ButtonItemFilter_All.Checked = True
            ButtonItemFilter_SelectedLineItem.Checked = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            AccountsPayableRightSection_AP.ClearControl()
            AccountsPayableRightSection_AP.SetBatchDate(_BatchDate)

            ComboBoxItemActions_View.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(APViewLayout))
                                                     Select Entity.Description).ToArray)

            ComboBoxItemActions_View.SelectedIndex = APViewLayout.ByVendor

            LoadGrid()

            LoadDetailViews()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

                If _IsMultiCurrencyEnabled Then

                    _CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                End If

            End Using

            'GetAPShowHomeChecked()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            HideOrShowRibbonBarOptions()

            ToggleEdit(False)

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(True)
            DataGridViewLeftSection_Invoices.FocusToFindPanel(True)

        End Sub
        Private Sub AccountsPayableForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub AccountsPayableRightSection_AP_CollapseVendor(ByVal VendorCode As String) Handles AccountsPayableRightSection_AP.CollapseVendor

            CollapseVendorInvoices(VendorCode)

        End Sub
        Private Sub AccountsPayableRightSection_AP_InternetInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.InternetInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_InternetSelectionChangedEvent(sender As Object, e As System.EventArgs) Handles AccountsPayableRightSection_AP.InternetSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_MagazineInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.MagazineInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_MagazineSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountsPayableRightSection_AP.MagazineSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_NewspaperInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.NewspaperInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_NewspaperSelectionChangedEvent(sender As Object, e As System.EventArgs) Handles AccountsPayableRightSection_AP.NewspaperSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_NonClientInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.NonClientInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_NonClientSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountsPayableRightSection_AP.NonClientSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_OutOfHomeInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.OutOfHomeInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_OutOfHomeSelectionChangedEvent(sender As Object, e As System.EventArgs) Handles AccountsPayableRightSection_AP.OutOfHomeSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_ProductionInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.ProductionInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_ProductionSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountsPayableRightSection_AP.ProductionSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_RadioInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.RadioInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_RadioSelectionChangedEvent(sender As Object, e As EventArgs) Handles AccountsPayableRightSection_AP.RadioSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_Saved(AccountPayable As AdvantageFramework.Database.Entities.AccountPayable) Handles AccountsPayableRightSection_AP.Saved

            If DataGridViewLeftSection_Invoices.Visible Then

                RefreshLeftSideGrid(AccountPayable)

            End If

        End Sub
        Private Sub AccountsPayableRightSection_AP_SelectedDocumentChanged() Handles AccountsPayableRightSection_AP.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_SelectedTabChanged() Handles AccountsPayableRightSection_AP.SelectedTabChanged

            HideOrShowRibbonBarOptions()

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_TotalsChanged(ByVal Balance As Decimal) Handles AccountsPayableRightSection_AP.TotalsChanged

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_TVInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.TVInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_TVSelectionChangedEvent(sender As Object, e As EventArgs) Handles AccountsPayableRightSection_AP.TVSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_VendorInvoiceChanged() Handles AccountsPayableRightSection_AP.VendorInvoiceChanged

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RefreshSelectionSubGrid As Boolean = False
            Dim RowHandle As Integer = 0

            Me.ClearChanged()

            HideOrShowRibbonBarOptions()

            If AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.HasASelectedValue Then

                _APControlSetInvoice = True

                DataGridViewLeftSection_VendorInvoices.SelectRow(AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.SelectedValue)

                If DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle > -1 AndAlso AccountsPayableRightSection_AP.AccountPayableID > 0 Then

                    Try

                        BaseView = DataGridViewLeftSection_VendorInvoices.CurrentView.GetDetailView(DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle, 0)

                    Catch ex As Exception
                        BaseView = Nothing
                    End Try

                    If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                        For RowHandle = 0 To BaseView.RowCount - 1

                            If BaseView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.ID.ToString) = AccountsPayableRightSection_AP.AccountPayableID AndAlso
                                    BaseView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.SequenceNumber.ToString) = AccountsPayableRightSection_AP.SequenceNumber Then

                                If BaseView.FocusedRowHandle = RowHandle Then

                                    RefreshSelectionSubGrid = True

                                End If

                                BaseView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Next

                        If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView AndAlso RefreshSelectionSubGrid Then

                            RowHandle = BaseView.FocusedRowHandle

                            BaseView.FocusedRowHandle = -1

                            BaseView.FocusedRowHandle = RowHandle
                            BaseView.SelectRow(RowHandle)

                        End If

                    End If

                End If

                _APControlSetInvoice = False

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub GridControlFocusedViewChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.ViewFocusEventArgs)

            EnableOrDisableActions()

        End Sub
        Private Function LoadDetailLevel(ByVal RowHandle As Integer,
                                         ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView) As IEnumerable

            Dim AccountPayableDetails As IEnumerable = Nothing
            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing
            Dim VendorCode As String = Nothing

            Try

                VendorCode = GridView.GetRowCellValue(RowHandle, "Code")

            Catch ex As Exception
                VendorCode = Nothing
            End Try

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AccountPayableList = AdvantageFramework.AccountPayable.GetAllAccountPayableListByVendor(DbContext, VendorCode)

                AccountPayableDetails = (From AccountPayable In AccountPayableList
                                         Order By AccountPayable.InvoiceDate Descending, AccountPayable.InvoiceNumber Descending
                                         Select New AdvantageFramework.Database.Classes.VendorInvoice(AccountPayable)).ToList

            End Using

            LoadDetailLevel = AccountPayableDetails

        End Function
        Private Sub _GridViewVendorInvoiceDetailsLevel1Tab1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

            Dim AccountPayableID As Integer = 0
            Dim SequenceNumber As Integer = 0
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            If Not _APControlSetInvoice Then

                Me.ShowWaitForm("Processing...")

                BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                If BaseView IsNot Nothing Then

                    AccountPayableID = BaseView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.ID.ToString)

                    SequenceNumber = BaseView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.SequenceNumber.ToString)

                    LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub _GridViewVendorInvoiceDetailsLevel1Tab1_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

            Dim AccountPayableID As Integer = 0
            Dim SequenceNumber As Integer = 0
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            Me.ShowWaitForm("Processing...")

            BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If BaseView IsNot Nothing Then

                AccountPayableID = BaseView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.ID.ToString)

                SequenceNumber = BaseView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.SequenceNumber.ToString)

                LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub _GridViewVendorInvoiceDetailsLevel1Tab1_BeforeLeaveRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles _GridViewVendorInvoiceDetailsLevel1Tab1.BeforeLeaveRow

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_VendorInvoices.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewLeftSection_VendorInvoices.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "VendorInvoiceDetailsLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            AddHandler BaseView.FocusedRowChanged, AddressOf _GridViewVendorInvoiceDetailsLevel1Tab1_FocusedRowChanged
                            AddHandler BaseView.RowClick, AddressOf _GridViewVendorInvoiceDetailsLevel1Tab1_RowClick
                            AddHandler BaseView.GridControl.FocusedViewChanged, AddressOf GridControlFocusedViewChanged
                            'AddHandler BaseView.SelectionChanged, AddressOf _GridViewVendorInvsoiceDetailsLevel1Tab1_SelectionChanged

                    End Select

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowGetChildListEvent

            e.ChildList = LoadDetailLevel(e.RowHandle, DataGridViewLeftSection_VendorInvoices.CurrentView)

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowGetRelationDisplayCaptionEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewLeftSection_VendorInvoices.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            'DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GridControl.FocusedView = Nothing

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = RowCount & " Invoice(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Invoice(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_VendorInvoices.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "VendorInvoiceDetailsLevel1Tab1"

            End Select

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewLeftSection_VendorInvoices.RowClick

            If e.RowHandle <> DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle Then

                SelectVendor()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_VendorInvoices.RowCountChangedEvent

            Dim RowHandle As Integer = 0

            If DataGridViewLeftSection_VendorInvoices.CurrentView.OptionsFind.AllowFindPanel Then

                If DataGridViewLeftSection_VendorInvoices.HasRows Then

                    RowHandle = DataGridViewLeftSection_VendorInvoices.CurrentView.LocateByValue(AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString, DataGridViewLeftSection_VendorInvoices.CurrentView.FindFilterText)

                    If RowHandle <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

                        DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle = RowHandle

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_VendorInvoices_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_VendorInvoices.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                SelectVendor()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim AccountPayableID As Integer = 0
            Dim SequenceNumber As Integer = 0
            Dim VendorCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            ContinueAdd = CheckForUnsavedChanges()

            If ContinueAdd Then

                VendorCode = AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.GetSelectedValue

                If VendorCode IsNot Nothing Then

                    If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableEditDialog.ShowFormDialog(VendorCode, AccountPayableID, SequenceNumber, _BatchDate, ButtonItemActions_ShowGross.Checked) = Windows.Forms.DialogResult.OK Then ', ButtonItemActions_ShowHome.Visible AndAlso ButtonItemActions_ShowHome.Checked) = System.Windows.Forms.DialogResult.OK Then

                        CollapseVendorInvoices(VendorCode)
                        LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)
                        DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(False)

                    End If

                ElseIf AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.DataSource.Count = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("No active vendors available.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a vendor.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_AddSearch_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AddSearch.Click

            Dim AccountPayableID As Integer = 0
            Dim SequenceNumber As Integer = 0
            Dim VendorCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            ContinueAdd = CheckForUnsavedChanges()

            If ContinueAdd Then

                If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableVendorSearchDialog.ShowFormDialog(VendorCode) = System.Windows.Forms.DialogResult.OK Then

                    If AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableEditDialog.ShowFormDialog(VendorCode, AccountPayableID, SequenceNumber, _BatchDate, ButtonItemActions_ShowGross.Checked) = Windows.Forms.DialogResult.OK Then ', ButtonItemActions_ShowHome.Visible AndAlso ButtonItemActions_ShowHome.Checked) = System.Windows.Forms.DialogResult.OK Then

                        CollapseVendorInvoices(VendorCode)
                        LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)
                        DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(False)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Dim VendorCode As String = Nothing

            Try

                If AccountsPayableRightSection_AP.Delete(VendorCode) Then

                    Me.ClearChanged()

                    AccountsPayableRightSection_AP.ClearControl(False)

                    CollapseVendorInvoices(VendorCode)
                    DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(False)

                    EnableOrDisableActions()

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
            End Try

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            AdvantageFramework.Exporting.Presentation.ExportForm.ShowForm(Exporting.ExportTypes.AccountPayable, False, True, Nothing)

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = ""
            Dim VendorCode As String = Nothing
            Dim Transaction As Integer = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If AccountsPayableRightSection_AP.Save(VendorCode) Then

                        Me.ClearChanged()

                        CollapseVendorInvoices(VendorCode)
                        DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(False)

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                EnableOrDisableActions()

                If ErrorMessage = "" Then

                    DataGridViewLeftSection_VendorInvoices.FocusToFindPanel(False)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_ShowGross_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowGross.CheckedChanged

            AccountsPayableRightSection_AP.ShowGross = ButtonItemActions_ShowGross.Checked

        End Sub
        'Private Sub ButtonItemActions_ShowHome_CheckedChanged(sender As Object, e As EventArgs)

        '    AccountsPayableRightSection_AP.ShowHome = ButtonItemActions_ShowHome.Checked

        'End Sub
        Private Sub ButtonItemNonClient_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemNonClient_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedNonClient()

        End Sub
        Private Sub ButtonItemNonClient_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemNonClient_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewNonClient()

        End Sub
        Private Sub ButtonItemNonClient_PODetail_Click(sender As Object, e As EventArgs) Handles ButtonItemNonClient_PODetail.Click

            AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayablePurchaseOrderDetailDialog.ShowFormDialog(AccountsPayableRightSection_AP.NonClientPONumber, AccountsPayableRightSection_AP.NonClientPOLineNumber)

        End Sub
        Private Sub ButtonItemProduction_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemProduction_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedProduction()

        End Sub
        Private Sub ButtonItemProduction_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProduction_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewProduction()

        End Sub
        Private Sub ButtonItemProduction_PODetail_Click(sender As Object, e As EventArgs) Handles ButtonItemProduction_PODetail.Click

            AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayablePurchaseOrderDetailDialog.ShowFormDialog(AccountsPayableRightSection_AP.ProductionPONumber, AccountsPayableRightSection_AP.ProductionPOLineNumber)

        End Sub
        Private Sub ButtonItemNewspaper_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemNewspaper_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.Newspaper)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemNewspaper_Approvals_Click(sender As Object, e As System.EventArgs) Handles ButtonItemNewspaper_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.Newspaper)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemNewspaper_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNewspaper_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewNewspaper()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemNewspaper_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNewspaper_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedNewspaper()

        End Sub
        Private Sub ButtonItemMagazine_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemMagazine_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.Magazine)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMagazine_Approvals_Click(sender As Object, e As System.EventArgs) Handles ButtonItemMagazine_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.Magazine)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMagazine_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMagazine_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewMagazine()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMagazine_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemMagazine_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedMagazine()

        End Sub
        Private Sub ButtonItemRadio_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemRadio_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.Radio)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRadio_Approvals_Click(sender As Object, e As EventArgs) Handles ButtonItemRadio_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.Radio)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRadio_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRadio_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewRadio()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRadio_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRadio_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedRadio()

        End Sub
        Private Sub ButtonItemTV_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemTV_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.Television)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTV_Approvals_Click(sender As Object, e As EventArgs) Handles ButtonItemTV_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.Television)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTV_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTV_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewTV()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemTV_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTV_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedTV()

        End Sub
        Private Sub ButtonItemOutOfHome_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemOutOfHome_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.OutOfHome)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOutOfHome_Approvals_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemOutOfHome_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.OutOfHome)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOutOfHome_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOutOfHome_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewOutOfHome()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemOutOfHome_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOutOfHome_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedOutOfHome()

        End Sub
        Private Sub ButtonItemFlags_Edit_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFlags_Edit.CheckedChanged

            ToggleEdit(ButtonItemFlags_Edit.Checked)

            EnableOrDisableActions()

            If Not ButtonItemFlags_Edit.Checked Then

                AccountsPayableRightSection_AP.ClearControl()

                LoadSelectedVendorInvoice()

            End If

        End Sub
        Private Sub ButtonItemInternet_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemInternet_Add.Click

            AccountsPayableRightSection_AP.AddMultipleOrders(WinForm.Presentation.Controls.AccountsPayableControl.MultipleOrderTypes.Internet)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInternet_Approvals_Click(sender As Object, e As System.EventArgs) Handles ButtonItemInternet_Approvals.Click

            AccountsPayableRightSection_AP.LaunchMediaApprovalDialog(Database.Entities.MediaOrderType.Internet)
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInternet_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemInternet_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewInternet()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInternet_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemInternet_Delete.Click

            AccountsPayableRightSection_AP.DeleteSelectedInternet()

        End Sub
        Private Sub ButtonItemVendor_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemVendor_Edit.Click

            If Me.AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.HasASelectedValue Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorEditDialog.ShowFormDialog(AccountsPayableRightSection_AP.SearchableComboBoxControl_Vendor.GetSelectedValue) = System.Windows.Forms.DialogResult.OK Then

                    'TODO refresh vendor info

                End If

            End If

        End Sub
        Private Sub ButtonItemRecurAP_Post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRecurAP_Post.Click

            Try

                If Me.MdiParent IsNot Nothing Then

                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_PostRecurringAP)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemRecurAP_Setup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRecurAP_Setup.Click

            Try

                If Me.MdiParent IsNot Nothing Then

                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_CreateRecurringAP)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemActions_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            LaunchBatchReport()

        End Sub
        Private Sub ComboBoxItemActions_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemActions_View.SelectedIndexChanged

            ChangeView(False)

        End Sub
        Private Sub DataGridViewLeftSection_Invoices_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewLeftSection_Invoices.CellValueChangingEvent

            'objects
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim AccountPayableID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing
            Dim ChecksWritten As Boolean = False
            Dim ErrorMessage As String = Nothing

            If ButtonItemFlags_Edit.Checked AndAlso (e.Column.FieldName = AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.PaymentHold.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.Is1099Invoice.ToString) Then

                Me.ShowWaitForm("Processing...")

                Try

                    If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                        AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.AccountPayableID.ToString)
                        SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.SequenceNumber.ToString)

                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                        AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.ID.ToString)
                        SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.SequenceNumber.ToString)

                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                        AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableID.ToString)
                        SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableSequenceNumber.ToString)

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, AccountPayableID, SequenceNumber)

                    End Using

                Catch ex As Exception
                    AccountPayable = Nothing
                End Try

                If AccountPayable IsNot Nothing Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If e.Column.FieldName = AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.PaymentHold.ToString Then

                                ChecksWritten = (From Entity In AdvantageFramework.Database.Procedures.AccountPayablePayment.Load(DbContext).Include("CheckRegister")
                                                 Where Entity.AccountPayableID = AccountPayable.ID AndAlso
                                                       (Entity.CheckRegister.IsVoid Is Nothing OrElse
                                                        Entity.CheckRegister.IsVoid = 0)
                                                 Select Entity).Any

                                If ChecksWritten OrElse AccountPayable.CheckWriting = 1 Then

                                    ErrorMessage = "Invoice has been selected for checkwriting or payment has been applied."

                                ElseIf AdvantageFramework.Database.Procedures.CheckWritingSelection.LoadByVendorCode(DbContext, AccountPayable.VendorCode).Any Then

                                    ErrorMessage = "Vendor is selected for checkwriting."

                                End If

                            End If

                            If ErrorMessage Is Nothing Then

                                If e.Column.FieldName = AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.PaymentHold.ToString Then

                                    Try

                                        AccountPayable.IsOnHold = Convert.ToInt16(e.Value)

                                    Catch ex As Exception
                                        AccountPayable.IsOnHold = AccountPayable.IsOnHold
                                    End Try

                                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.Is1099Invoice.ToString Then

                                    Try

                                        AccountPayable.Is1099Invoice = Convert.ToInt16(e.Value)

                                    Catch ex As Exception
                                        AccountPayable.Is1099Invoice = AccountPayable.Is1099Invoice
                                    End Try

                                End If

                                Saved = AdvantageFramework.Database.Procedures.AccountPayable.Update(DbContext, AccountPayable, True)

                                If Saved Then

                                    If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoice).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoice).PaymentHold = AccountPayable.IsOnHold

                                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.VendorInvoiceDetail).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.VendorInvoiceDetail).PaymentHold = AccountPayable.IsOnHold

                                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoiceAlert).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoiceAlert).PaymentHold = AccountPayable.IsOnHold

                                    End If

                                End If

                                If Saved Then

                                    If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoice).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoice).PaymentHold = AccountPayable.IsOnHold

                                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.VendorInvoiceDetail).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.VendorInvoiceDetail).PaymentHold = AccountPayable.IsOnHold

                                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoiceAlert).Is1099Invoice = AccountPayable.Is1099Invoice
                                        DirectCast(DataGridViewLeftSection_Invoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Views.VendorInvoiceAlert).PaymentHold = AccountPayable.IsOnHold

                                    End If

                                End If

                            Else

                                DataGridViewLeftSection_Invoices.CurrentView.CloseEditorForUpdating()

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Invoices_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Invoices.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso AccountsPayableRightSection_AP.Visible Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Invoices_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Invoices.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedVendorInvoice()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            AccountsPayableRightSection_AP.UploadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            AccountsPayableRightSection_AP.SendASPUploadEmail()

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            AccountsPayableRightSection_AP.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            AccountsPayableRightSection_AP.DownloadDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            AccountsPayableRightSection_AP.DeleteDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAlerts_NewAlertAssignment_Click(sender As Object, e As EventArgs) Handles ButtonItemAlerts_NewAlertAssignment.Click

            AccountsPayableRightSection_AP.NewAlertAssignment()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAlerts_View_Click(sender As Object, e As EventArgs) Handles ButtonItemAlerts_View.Click

            AccountsPayableRightSection_AP.ViewAlerts()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemImport_AP_Click(sender As Object, e As EventArgs) Handles ButtonItemImport_AP.Click

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import)

            End If

        End Sub
        Private Sub ButtonItemExpenseReports_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemExpenseReports_Approve.Click

            Dim FoundWindowAlreadyOpen As Boolean = False

            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In Me.MdiParent.MdiChildren

                    If MdiChildForm.Name = "AccountsPayableImportExpenseReportsForm" Then

                        FoundWindowAlreadyOpen = True
                        MdiChildForm.Activate()
                        Exit For

                    End If

                Next

            End If

            If Not FoundWindowAlreadyOpen Then

                AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableImportExpenseReportsForm.ShowForm()

            End If

        End Sub
        Private Sub ButtonItemView_Documents_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Documents.CheckedChanged

            If Me.FormShown AndAlso ButtonItemView_Documents.Checked Then

                AccountsPayableRightSection_AP.SelectDocumentsTab()

            End If

        End Sub
        Private Sub ButtonItemFilter_All_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_All.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_All.Checked Then

                ButtonItemFilter_SelectedLineItem.Checked = False

                AccountsPayableRightSection_AP.FilterDocuments(AdvantageFramework.Database.Entities.DocumentSubLevel.Default)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemFilter_SelectedLineItem_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_SelectedLineItem.CheckedChanged

            If Me.FormShown AndAlso ButtonItemFilter_SelectedLineItem.Checked Then

                ButtonItemFilter_All.Checked = False

                AccountsPayableRightSection_AP.FilterDocuments(AdvantageFramework.Database.Entities.DocumentSubLevel.ExpenseDetailDocument)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemExpenseReceipts_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemExpenseReceipts_Download.Click

            AccountsPayableRightSection_AP.DocumentManagerControlExpenseReceipts_Receipts.DownloadSelectedDocument()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim VendorCode As String = Nothing
            Dim AccountPayableID As Integer = Nothing
            Dim SequenceNumber As Short = Nothing
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RefreshSelection As Boolean = False
            Dim RefreshSelectionSubGrid As Boolean = False
            Dim RowHandle As Integer = 0

            If DataGridViewLeftSection_VendorInvoices.Visible Then

                VendorCode = DataGridViewLeftSection_VendorInvoices.GetFirstSelectedRowBookmarkValue

                Try

                    BaseView = DataGridViewLeftSection_VendorInvoices.CurrentView.GetDetailView(DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle, 0)

                Catch ex As Exception
                    BaseView = Nothing
                End Try

                If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView AndAlso BaseView.FocusedRowHandle > -1 Then

                    AccountPayableID = BaseView.GetRowCellValue(BaseView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.ID.ToString)
                    SequenceNumber = BaseView.GetRowCellValue(BaseView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.SequenceNumber.ToString)

                End If

            Else

                If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.AccountPayableID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoice.Properties.SequenceNumber.ToString)

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.ID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.SequenceNumber.ToString)

                ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                    AccountPayableID = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableID.ToString)
                    SequenceNumber = DataGridViewLeftSection_Invoices.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableSequenceNumber.ToString)

                End If

            End If

            ChangeView(True)

            If DataGridViewLeftSection_VendorInvoices.Visible Then

                For RowHandle = 0 To DataGridViewLeftSection_VendorInvoices.CurrentView.RowCount - 1

                    If DataGridViewLeftSection_VendorInvoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Vendor.Properties.Code.ToString) = VendorCode Then

                        If DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle = RowHandle Then

                            RefreshSelection = True

                        End If

                        DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle = RowHandle

                        Exit For

                    End If

                Next

                If DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle > -1 Then

                    DataGridViewLeftSection_VendorInvoices.CurrentView.ExpandMasterRow(DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle)

                    Try

                        BaseView = DataGridViewLeftSection_VendorInvoices.CurrentView.GetDetailView(DataGridViewLeftSection_VendorInvoices.CurrentView.FocusedRowHandle, 0)

                    Catch ex As Exception
                        BaseView = Nothing
                    End Try

                    If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                        For RowHandle = 0 To BaseView.RowCount - 1

                            If BaseView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.ID.ToString) = AccountPayableID AndAlso
                                    BaseView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoice.Properties.SequenceNumber.ToString) = SequenceNumber Then

                                If BaseView.FocusedRowHandle = RowHandle Then

                                    RefreshSelectionSubGrid = True

                                End If

                                BaseView.FocusedRowHandle = RowHandle

                                Exit For

                            End If

                        Next

                    End If

                End If

                If RefreshSelection Then

                    DataGridViewLeftSection_VendorInvoices.CurrentView.GridViewSelectionChanged()

                End If

                If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView AndAlso RefreshSelectionSubGrid Then

                    RowHandle = BaseView.FocusedRowHandle

                    BaseView.FocusedRowHandle = -1

                    BaseView.FocusedRowHandle = RowHandle
                    BaseView.SelectRow(RowHandle)

                End If

            Else

                For RowHandle = 0 To DataGridViewLeftSection_Invoices.CurrentView.RowCount - 1

                    If TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoice Then

                        If DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.VendorInvoice.Properties.AccountPayableID.ToString) = AccountPayableID AndAlso
                                DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.VendorInvoice.Properties.SequenceNumber.ToString) = SequenceNumber Then

                            If DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle Then

                                RefreshSelection = True

                            End If

                            DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle

                            Exit For

                        End If

                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Classes.VendorInvoiceDetail Then

                        If DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.ID.ToString) = AccountPayableID AndAlso
                                DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.VendorInvoiceDetail.Properties.SequenceNumber.ToString) = SequenceNumber Then

                            If DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle Then

                                RefreshSelection = True

                            End If

                            DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle

                            Exit For

                        End If

                    ElseIf TypeOf DataGridViewLeftSection_Invoices.CurrentView.GetRow(DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle) Is AdvantageFramework.Database.Views.VendorInvoiceAlert Then

                        If DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableID.ToString) = AccountPayableID AndAlso
                                DataGridViewLeftSection_Invoices.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.VendorInvoiceAlert.Properties.AccountPayableSequenceNumber.ToString) = SequenceNumber Then

                            If DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle Then

                                RefreshSelection = True

                            End If

                            DataGridViewLeftSection_Invoices.CurrentView.FocusedRowHandle = RowHandle

                            Exit For

                        End If

                    End If

                Next

                LoadSelectedVendorInvoice(AccountPayableID, SequenceNumber)

                If RefreshSelection Then

                    DataGridViewLeftSection_Invoices.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub AccountsPayableRightSection_AP_RadioDetailSelectionChangedEvent(sender As Object, e As EventArgs) Handles AccountsPayableRightSection_AP.RadioDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_RadioDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.RadioDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_TVDetailSelectionChangedEvent(sender As Object, e As EventArgs) Handles AccountsPayableRightSection_AP.TVDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub AccountsPayableRightSection_AP_TVDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AccountsPayableRightSection_AP.TVDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRadioDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemRadioDetails_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewRadioDetail()

        End Sub
        Private Sub ButtonItemRadioDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemRadioDetails_Delete.Click

            AccountsPayableRightSection_AP.DeleteRadioDetail()

        End Sub
        Private Sub ButtonItemTVDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemTVDetails_Cancel.Click

            AccountsPayableRightSection_AP.CancelAddNewTVDetail()

        End Sub
        Private Sub ButtonItemTVDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemTVDetails_Delete.Click

            AccountsPayableRightSection_AP.DeleteTVDetail()

        End Sub
        Private Sub ButtonItemQuickbooks_SendToQuickbooks_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickbooks_SendToQuickbooks.Click

            AccountsPayableRightSection_AP.SendBillToQuickbooks()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemQuickbooks_UpdateQuickbooks_Click(sender As Object, e As EventArgs) Handles ButtonItemQuickbooks_UpdateQuickbooks.Click

            'AccountsPayableRightSection_AP.DeleteBillFromQuickbooks()
            AccountsPayableRightSection_AP.UpdateBillQuickbooks()

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
