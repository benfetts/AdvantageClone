Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountsPayableForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                _GridViewVendorInvoiceDetailsLevel1Tab1.Dispose()
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_VendorInvoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.AccountsPayableRightSection_AP = New AdvantageFramework.WinForm.Presentation.Controls.AccountsPayableControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Quickbooks = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickbooks_SendToQuickbooks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemQuickbooks_UpdateQuickbooks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_TVDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTVDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTVDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_RadioDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRadioDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRadioDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ExpenseReceipts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemExpenseReceipts_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_TV = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTV_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTV_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTV_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTV_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Radio = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRadio_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRadio_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRadio_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRadio_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOutOfHome_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOutOfHome_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOutOfHome_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOutOfHome_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemNewspaper_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemNewspaper_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemNewspaper_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemNewspaper_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMagazine_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMagazine_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMagazine_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMagazine_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Internet = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInternet_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInternet_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInternet_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemInternet_Approvals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Production = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProduction_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduction_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduction_PODetail = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_NonClient = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemNonClient_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemNonClient_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemNonClient_PODetail = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_Documents = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Flags = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFlags_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ExpenseReports = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemExpenseReports_Approve = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Import = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemImport_AP = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendor_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_RecurAP = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRecurAP_Setup = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRecurAP_Post = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerActions_View = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemActions_View = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AddSearch = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ShowGross = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Alerts = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAlerts_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAlerts_NewAlert = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAlerts_NewAlertAssignment = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Invoices)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_VendorInvoices)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 691)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_Invoices
            '
            Me.DataGridViewLeftSection_Invoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Invoices.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Invoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Invoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Invoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Invoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Invoices.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Invoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Invoices.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Invoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLeftSection_Invoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Invoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Invoices.ItemDescription = "Vendor Invoice(s)"
            Me.DataGridViewLeftSection_Invoices.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Invoices.MultiSelect = True
            Me.DataGridViewLeftSection_Invoices.Name = "DataGridViewLeftSection_Invoices"
            Me.DataGridViewLeftSection_Invoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Invoices.RunStandardValidation = True
            Me.DataGridViewLeftSection_Invoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Invoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Invoices.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_Invoices.TabIndex = 1
            Me.DataGridViewLeftSection_Invoices.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Invoices.ViewCaptionHeight = -1
            Me.DataGridViewLeftSection_Invoices.Visible = False
            '
            'DataGridViewLeftSection_VendorInvoices
            '
            Me.DataGridViewLeftSection_VendorInvoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_VendorInvoices.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_VendorInvoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_VendorInvoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_VendorInvoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_VendorInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_VendorInvoices.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_VendorInvoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_VendorInvoices.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_VendorInvoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLeftSection_VendorInvoices.DataSource = Nothing
            Me.DataGridViewLeftSection_VendorInvoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_VendorInvoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_VendorInvoices.ItemDescription = "Vendor Invoice(s)"
            Me.DataGridViewLeftSection_VendorInvoices.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_VendorInvoices.MultiSelect = True
            Me.DataGridViewLeftSection_VendorInvoices.Name = "DataGridViewLeftSection_VendorInvoices"
            Me.DataGridViewLeftSection_VendorInvoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_VendorInvoices.RunStandardValidation = True
            Me.DataGridViewLeftSection_VendorInvoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_VendorInvoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_VendorInvoices.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_VendorInvoices.TabIndex = 0
            Me.DataGridViewLeftSection_VendorInvoices.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_VendorInvoices.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(197, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 691)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.AccountsPayableRightSection_AP)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(203, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1419, 691)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'AccountsPayableRightSection_AP
            '
            Me.AccountsPayableRightSection_AP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AccountsPayableRightSection_AP.AutoScroll = True
            Me.AccountsPayableRightSection_AP.Location = New System.Drawing.Point(5, 12)
            Me.AccountsPayableRightSection_AP.Name = "AccountsPayableRightSection_AP"
            Me.AccountsPayableRightSection_AP.Size = New System.Drawing.Size(1402, 667)
            Me.AccountsPayableRightSection_AP.TabIndex = 0
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Quickbooks)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TVDetails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_RadioDetails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ExpenseReceipts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_TV)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Radio)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_OutOfHome)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Newspaper)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Magazine)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Internet)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Production)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_NonClient)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Flags)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ExpenseReports)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Import)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Vendor)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_RecurAP)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1600, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Quickbooks
            '
            Me.RibbonBarOptions_Quickbooks.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Quickbooks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Quickbooks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Quickbooks.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Quickbooks.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Quickbooks.DragDropSupport = True
            Me.RibbonBarOptions_Quickbooks.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickbooks_SendToQuickbooks, Me.ButtonItemQuickbooks_UpdateQuickbooks})
            Me.RibbonBarOptions_Quickbooks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Quickbooks.Location = New System.Drawing.Point(1548, 0)
            Me.RibbonBarOptions_Quickbooks.Name = "RibbonBarOptions_Quickbooks"
            Me.RibbonBarOptions_Quickbooks.SecurityEnabled = True
            Me.RibbonBarOptions_Quickbooks.Size = New System.Drawing.Size(86, 98)
            Me.RibbonBarOptions_Quickbooks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Quickbooks.TabIndex = 48
            Me.RibbonBarOptions_Quickbooks.Text = "QuickBooks"
            '
            '
            '
            Me.RibbonBarOptions_Quickbooks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Quickbooks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Quickbooks.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemQuickbooks_SendToQuickbooks
            '
            Me.ButtonItemQuickbooks_SendToQuickbooks.BeginGroup = True
            Me.ButtonItemQuickbooks_SendToQuickbooks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickbooks_SendToQuickbooks.Name = "ButtonItemQuickbooks_SendToQuickbooks"
            Me.ButtonItemQuickbooks_SendToQuickbooks.RibbonWordWrap = False
            Me.ButtonItemQuickbooks_SendToQuickbooks.SecurityEnabled = True
            Me.ButtonItemQuickbooks_SendToQuickbooks.SubItemsExpandWidth = 14
            Me.ButtonItemQuickbooks_SendToQuickbooks.Text = "Send"
            Me.ButtonItemQuickbooks_SendToQuickbooks.Tooltip = "Send to Quickbooks"
            '
            'ButtonItemQuickbooks_UpdateQuickbooks
            '
            Me.ButtonItemQuickbooks_UpdateQuickbooks.BeginGroup = True
            Me.ButtonItemQuickbooks_UpdateQuickbooks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickbooks_UpdateQuickbooks.Name = "ButtonItemQuickbooks_UpdateQuickbooks"
            Me.ButtonItemQuickbooks_UpdateQuickbooks.RibbonWordWrap = False
            Me.ButtonItemQuickbooks_UpdateQuickbooks.SecurityEnabled = True
            Me.ButtonItemQuickbooks_UpdateQuickbooks.SubItemsExpandWidth = 14
            Me.ButtonItemQuickbooks_UpdateQuickbooks.Text = "Update"
            Me.ButtonItemQuickbooks_UpdateQuickbooks.Tooltip = "Update Quickbooks"
            '
            'RibbonBarOptions_TVDetails
            '
            Me.RibbonBarOptions_TVDetails.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_TVDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TVDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TVDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TVDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TVDetails.DragDropSupport = True
            Me.RibbonBarOptions_TVDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTVDetails_Delete, Me.ButtonItemTVDetails_Cancel})
            Me.RibbonBarOptions_TVDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TVDetails.Location = New System.Drawing.Point(1504, 0)
            Me.RibbonBarOptions_TVDetails.Name = "RibbonBarOptions_TVDetails"
            Me.RibbonBarOptions_TVDetails.SecurityEnabled = True
            Me.RibbonBarOptions_TVDetails.Size = New System.Drawing.Size(44, 98)
            Me.RibbonBarOptions_TVDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TVDetails.TabIndex = 47
            Me.RibbonBarOptions_TVDetails.Text = "TV Details"
            '
            '
            '
            Me.RibbonBarOptions_TVDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TVDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TVDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_TVDetails.Visible = False
            '
            'ButtonItemTVDetails_Delete
            '
            Me.ButtonItemTVDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTVDetails_Delete.Name = "ButtonItemTVDetails_Delete"
            Me.ButtonItemTVDetails_Delete.SecurityEnabled = True
            Me.ButtonItemTVDetails_Delete.Text = "Delete"
            '
            'ButtonItemTVDetails_Cancel
            '
            Me.ButtonItemTVDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTVDetails_Cancel.Name = "ButtonItemTVDetails_Cancel"
            Me.ButtonItemTVDetails_Cancel.SecurityEnabled = True
            Me.ButtonItemTVDetails_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_RadioDetails
            '
            Me.RibbonBarOptions_RadioDetails.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_RadioDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RadioDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RadioDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_RadioDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_RadioDetails.DragDropSupport = True
            Me.RibbonBarOptions_RadioDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRadioDetails_Delete, Me.ButtonItemRadioDetails_Cancel})
            Me.RibbonBarOptions_RadioDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_RadioDetails.Location = New System.Drawing.Point(1460, 0)
            Me.RibbonBarOptions_RadioDetails.Name = "RibbonBarOptions_RadioDetails"
            Me.RibbonBarOptions_RadioDetails.SecurityEnabled = True
            Me.RibbonBarOptions_RadioDetails.Size = New System.Drawing.Size(44, 98)
            Me.RibbonBarOptions_RadioDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_RadioDetails.TabIndex = 46
            Me.RibbonBarOptions_RadioDetails.Text = "Radio Details"
            '
            '
            '
            Me.RibbonBarOptions_RadioDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RadioDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RadioDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_RadioDetails.Visible = False
            '
            'ButtonItemRadioDetails_Delete
            '
            Me.ButtonItemRadioDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadioDetails_Delete.Name = "ButtonItemRadioDetails_Delete"
            Me.ButtonItemRadioDetails_Delete.SecurityEnabled = True
            Me.ButtonItemRadioDetails_Delete.Text = "Delete"
            '
            'ButtonItemRadioDetails_Cancel
            '
            Me.ButtonItemRadioDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadioDetails_Cancel.Name = "ButtonItemRadioDetails_Cancel"
            Me.ButtonItemRadioDetails_Cancel.SecurityEnabled = True
            Me.ButtonItemRadioDetails_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_Filter
            '
            Me.RibbonBarOptions_Filter.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Filter.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Filter.DragDropSupport = True
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_All, Me.ButtonItemFilter_SelectedLineItem})
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(1403, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(57, 98)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 36
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Filter.Visible = False
            '
            'ButtonItemFilter_All
            '
            Me.ButtonItemFilter_All.AutoCheckOnClick = True
            Me.ButtonItemFilter_All.BeginGroup = True
            Me.ButtonItemFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_All.Name = "ButtonItemFilter_All"
            Me.ButtonItemFilter_All.RibbonWordWrap = False
            Me.ButtonItemFilter_All.SecurityEnabled = True
            Me.ButtonItemFilter_All.Stretch = True
            Me.ButtonItemFilter_All.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_All.Text = "All"
            '
            'ButtonItemFilter_SelectedLineItem
            '
            Me.ButtonItemFilter_SelectedLineItem.AutoCheckOnClick = True
            Me.ButtonItemFilter_SelectedLineItem.BeginGroup = True
            Me.ButtonItemFilter_SelectedLineItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_SelectedLineItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_SelectedLineItem.Name = "ButtonItemFilter_SelectedLineItem"
            Me.ButtonItemFilter_SelectedLineItem.RibbonWordWrap = False
            Me.ButtonItemFilter_SelectedLineItem.SecurityEnabled = True
            Me.ButtonItemFilter_SelectedLineItem.Stretch = True
            Me.ButtonItemFilter_SelectedLineItem.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_SelectedLineItem.Text = "Selected Line Item(s)"
            '
            'RibbonBarOptions_ExpenseReceipts
            '
            Me.RibbonBarOptions_ExpenseReceipts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReceipts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReceipts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ExpenseReceipts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ExpenseReceipts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ExpenseReceipts.DragDropSupport = True
            Me.RibbonBarOptions_ExpenseReceipts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExpenseReceipts_Download})
            Me.RibbonBarOptions_ExpenseReceipts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ExpenseReceipts.Location = New System.Drawing.Point(1345, 0)
            Me.RibbonBarOptions_ExpenseReceipts.Name = "RibbonBarOptions_ExpenseReceipts"
            Me.RibbonBarOptions_ExpenseReceipts.SecurityEnabled = True
            Me.RibbonBarOptions_ExpenseReceipts.Size = New System.Drawing.Size(58, 98)
            Me.RibbonBarOptions_ExpenseReceipts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ExpenseReceipts.TabIndex = 35
            Me.RibbonBarOptions_ExpenseReceipts.Text = "Receipts"
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReceipts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReceipts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ExpenseReceipts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_ExpenseReceipts.Visible = False
            '
            'ButtonItemExpenseReceipts_Download
            '
            Me.ButtonItemExpenseReceipts_Download.BeginGroup = True
            Me.ButtonItemExpenseReceipts_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemExpenseReceipts_Download.Name = "ButtonItemExpenseReceipts_Download"
            Me.ButtonItemExpenseReceipts_Download.RibbonWordWrap = False
            Me.ButtonItemExpenseReceipts_Download.SecurityEnabled = True
            Me.ButtonItemExpenseReceipts_Download.SubItemsExpandWidth = 14
            Me.ButtonItemExpenseReceipts_Download.Text = "Download"
            '
            'RibbonBarOptions_Documents
            '
            Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Documents.DragDropSupport = True
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(1206, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(139, 98)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 45
            Me.RibbonBarOptions_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Documents.Visible = False
            '
            'ButtonItemDocuments_Upload
            '
            Me.ButtonItemDocuments_Upload.BeginGroup = True
            Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
            Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
            Me.ButtonItemDocuments_Upload.SecurityEnabled = True
            Me.ButtonItemDocuments_Upload.SplitButton = True
            Me.ButtonItemDocuments_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
            Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Upload.Text = "Upload"
            '
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SecurityEnabled = True
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
            '
            'ButtonItemDocuments_OpenURL
            '
            Me.ButtonItemDocuments_OpenURL.BeginGroup = True
            Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
            Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
            Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
            Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
            '
            'ButtonItemDocuments_Delete
            '
            Me.ButtonItemDocuments_Delete.BeginGroup = True
            Me.ButtonItemDocuments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Delete.Name = "ButtonItemDocuments_Delete"
            Me.ButtonItemDocuments_Delete.RibbonWordWrap = False
            Me.ButtonItemDocuments_Delete.SecurityEnabled = True
            Me.ButtonItemDocuments_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Delete.Text = "Delete"
            '
            'RibbonBarOptions_TV
            '
            Me.RibbonBarOptions_TV.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_TV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TV.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_TV.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_TV.DragDropSupport = True
            Me.RibbonBarOptions_TV.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTV_Add, Me.ButtonItemTV_Delete, Me.ButtonItemTV_Cancel, Me.ButtonItemTV_Approvals})
            Me.RibbonBarOptions_TV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_TV.Location = New System.Drawing.Point(1166, 0)
            Me.RibbonBarOptions_TV.Name = "RibbonBarOptions_TV"
            Me.RibbonBarOptions_TV.SecurityEnabled = True
            Me.RibbonBarOptions_TV.Size = New System.Drawing.Size(40, 98)
            Me.RibbonBarOptions_TV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_TV.TabIndex = 42
            Me.RibbonBarOptions_TV.Text = "TV"
            '
            '
            '
            Me.RibbonBarOptions_TV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_TV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_TV.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_TV.Visible = False
            '
            'ButtonItemTV_Add
            '
            Me.ButtonItemTV_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTV_Add.Name = "ButtonItemTV_Add"
            Me.ButtonItemTV_Add.SecurityEnabled = True
            Me.ButtonItemTV_Add.Text = "Add"
            '
            'ButtonItemTV_Delete
            '
            Me.ButtonItemTV_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTV_Delete.Name = "ButtonItemTV_Delete"
            Me.ButtonItemTV_Delete.SecurityEnabled = True
            Me.ButtonItemTV_Delete.Text = "Delete"
            '
            'ButtonItemTV_Cancel
            '
            Me.ButtonItemTV_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTV_Cancel.Name = "ButtonItemTV_Cancel"
            Me.ButtonItemTV_Cancel.SecurityEnabled = True
            Me.ButtonItemTV_Cancel.Text = "Cancel"
            '
            'ButtonItemTV_Approvals
            '
            Me.ButtonItemTV_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTV_Approvals.Name = "ButtonItemTV_Approvals"
            Me.ButtonItemTV_Approvals.SecurityEnabled = True
            Me.ButtonItemTV_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_Radio
            '
            Me.RibbonBarOptions_Radio.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Radio.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Radio.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Radio.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Radio.DragDropSupport = True
            Me.RibbonBarOptions_Radio.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRadio_Add, Me.ButtonItemRadio_Delete, Me.ButtonItemRadio_Cancel, Me.ButtonItemRadio_Approvals})
            Me.RibbonBarOptions_Radio.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Radio.Location = New System.Drawing.Point(1120, 0)
            Me.RibbonBarOptions_Radio.Name = "RibbonBarOptions_Radio"
            Me.RibbonBarOptions_Radio.SecurityEnabled = True
            Me.RibbonBarOptions_Radio.Size = New System.Drawing.Size(46, 98)
            Me.RibbonBarOptions_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Radio.TabIndex = 41
            Me.RibbonBarOptions_Radio.Text = "Radio"
            '
            '
            '
            Me.RibbonBarOptions_Radio.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Radio.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Radio.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Radio.Visible = False
            '
            'ButtonItemRadio_Add
            '
            Me.ButtonItemRadio_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadio_Add.Name = "ButtonItemRadio_Add"
            Me.ButtonItemRadio_Add.SecurityEnabled = True
            Me.ButtonItemRadio_Add.Text = "Add"
            '
            'ButtonItemRadio_Delete
            '
            Me.ButtonItemRadio_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadio_Delete.Name = "ButtonItemRadio_Delete"
            Me.ButtonItemRadio_Delete.SecurityEnabled = True
            Me.ButtonItemRadio_Delete.Text = "Delete"
            '
            'ButtonItemRadio_Cancel
            '
            Me.ButtonItemRadio_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadio_Cancel.Name = "ButtonItemRadio_Cancel"
            Me.ButtonItemRadio_Cancel.SecurityEnabled = True
            Me.ButtonItemRadio_Cancel.Text = "Cancel"
            '
            'ButtonItemRadio_Approvals
            '
            Me.ButtonItemRadio_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRadio_Approvals.Name = "ButtonItemRadio_Approvals"
            Me.ButtonItemRadio_Approvals.SecurityEnabled = True
            Me.ButtonItemRadio_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_OutOfHome
            '
            Me.RibbonBarOptions_OutOfHome.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_OutOfHome.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OutOfHome.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OutOfHome.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OutOfHome.DragDropSupport = True
            Me.RibbonBarOptions_OutOfHome.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOutOfHome_Add, Me.ButtonItemOutOfHome_Delete, Me.ButtonItemOutOfHome_Cancel, Me.ButtonItemOutOfHome_Approvals})
            Me.RibbonBarOptions_OutOfHome.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OutOfHome.Location = New System.Drawing.Point(1074, 0)
            Me.RibbonBarOptions_OutOfHome.Name = "RibbonBarOptions_OutOfHome"
            Me.RibbonBarOptions_OutOfHome.SecurityEnabled = True
            Me.RibbonBarOptions_OutOfHome.Size = New System.Drawing.Size(46, 98)
            Me.RibbonBarOptions_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OutOfHome.TabIndex = 43
            Me.RibbonBarOptions_OutOfHome.Text = "Out of Home"
            '
            '
            '
            Me.RibbonBarOptions_OutOfHome.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OutOfHome.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OutOfHome.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_OutOfHome.Visible = False
            '
            'ButtonItemOutOfHome_Add
            '
            Me.ButtonItemOutOfHome_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOutOfHome_Add.Name = "ButtonItemOutOfHome_Add"
            Me.ButtonItemOutOfHome_Add.SecurityEnabled = True
            Me.ButtonItemOutOfHome_Add.Text = "Add"
            '
            'ButtonItemOutOfHome_Delete
            '
            Me.ButtonItemOutOfHome_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOutOfHome_Delete.Name = "ButtonItemOutOfHome_Delete"
            Me.ButtonItemOutOfHome_Delete.SecurityEnabled = True
            Me.ButtonItemOutOfHome_Delete.Text = "Delete"
            '
            'ButtonItemOutOfHome_Cancel
            '
            Me.ButtonItemOutOfHome_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOutOfHome_Cancel.Name = "ButtonItemOutOfHome_Cancel"
            Me.ButtonItemOutOfHome_Cancel.SecurityEnabled = True
            Me.ButtonItemOutOfHome_Cancel.Text = "Cancel"
            '
            'ButtonItemOutOfHome_Approvals
            '
            Me.ButtonItemOutOfHome_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOutOfHome_Approvals.Name = "ButtonItemOutOfHome_Approvals"
            Me.ButtonItemOutOfHome_Approvals.SecurityEnabled = True
            Me.ButtonItemOutOfHome_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_Newspaper
            '
            Me.RibbonBarOptions_Newspaper.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Newspaper.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Newspaper.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Newspaper.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Newspaper.DragDropSupport = True
            Me.RibbonBarOptions_Newspaper.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNewspaper_Add, Me.ButtonItemNewspaper_Delete, Me.ButtonItemNewspaper_Cancel, Me.ButtonItemNewspaper_Approvals})
            Me.RibbonBarOptions_Newspaper.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Newspaper.Location = New System.Drawing.Point(1016, 0)
            Me.RibbonBarOptions_Newspaper.Name = "RibbonBarOptions_Newspaper"
            Me.RibbonBarOptions_Newspaper.SecurityEnabled = True
            Me.RibbonBarOptions_Newspaper.Size = New System.Drawing.Size(58, 98)
            Me.RibbonBarOptions_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Newspaper.TabIndex = 40
            Me.RibbonBarOptions_Newspaper.Text = "Newspaper"
            '
            '
            '
            Me.RibbonBarOptions_Newspaper.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Newspaper.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Newspaper.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Newspaper.Visible = False
            '
            'ButtonItemNewspaper_Add
            '
            Me.ButtonItemNewspaper_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNewspaper_Add.Name = "ButtonItemNewspaper_Add"
            Me.ButtonItemNewspaper_Add.SecurityEnabled = True
            Me.ButtonItemNewspaper_Add.Text = "Add"
            '
            'ButtonItemNewspaper_Delete
            '
            Me.ButtonItemNewspaper_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNewspaper_Delete.Name = "ButtonItemNewspaper_Delete"
            Me.ButtonItemNewspaper_Delete.SecurityEnabled = True
            Me.ButtonItemNewspaper_Delete.Text = "Delete"
            '
            'ButtonItemNewspaper_Cancel
            '
            Me.ButtonItemNewspaper_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNewspaper_Cancel.Name = "ButtonItemNewspaper_Cancel"
            Me.ButtonItemNewspaper_Cancel.SecurityEnabled = True
            Me.ButtonItemNewspaper_Cancel.Text = "Cancel"
            '
            'ButtonItemNewspaper_Approvals
            '
            Me.ButtonItemNewspaper_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNewspaper_Approvals.Name = "ButtonItemNewspaper_Approvals"
            Me.ButtonItemNewspaper_Approvals.SecurityEnabled = True
            Me.ButtonItemNewspaper_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_Magazine
            '
            Me.RibbonBarOptions_Magazine.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Magazine.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Magazine.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Magazine.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Magazine.DragDropSupport = True
            Me.RibbonBarOptions_Magazine.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMagazine_Add, Me.ButtonItemMagazine_Delete, Me.ButtonItemMagazine_Cancel, Me.ButtonItemMagazine_Approvals})
            Me.RibbonBarOptions_Magazine.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Magazine.Location = New System.Drawing.Point(967, 0)
            Me.RibbonBarOptions_Magazine.Name = "RibbonBarOptions_Magazine"
            Me.RibbonBarOptions_Magazine.SecurityEnabled = True
            Me.RibbonBarOptions_Magazine.Size = New System.Drawing.Size(49, 98)
            Me.RibbonBarOptions_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Magazine.TabIndex = 39
            Me.RibbonBarOptions_Magazine.Text = "Magazine"
            '
            '
            '
            Me.RibbonBarOptions_Magazine.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Magazine.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Magazine.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Magazine.Visible = False
            '
            'ButtonItemMagazine_Add
            '
            Me.ButtonItemMagazine_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMagazine_Add.Name = "ButtonItemMagazine_Add"
            Me.ButtonItemMagazine_Add.SecurityEnabled = True
            Me.ButtonItemMagazine_Add.Text = "Add"
            '
            'ButtonItemMagazine_Delete
            '
            Me.ButtonItemMagazine_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMagazine_Delete.Name = "ButtonItemMagazine_Delete"
            Me.ButtonItemMagazine_Delete.SecurityEnabled = True
            Me.ButtonItemMagazine_Delete.Text = "Delete"
            '
            'ButtonItemMagazine_Cancel
            '
            Me.ButtonItemMagazine_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMagazine_Cancel.Name = "ButtonItemMagazine_Cancel"
            Me.ButtonItemMagazine_Cancel.SecurityEnabled = True
            Me.ButtonItemMagazine_Cancel.Text = "Cancel"
            '
            'ButtonItemMagazine_Approvals
            '
            Me.ButtonItemMagazine_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMagazine_Approvals.Name = "ButtonItemMagazine_Approvals"
            Me.ButtonItemMagazine_Approvals.SecurityEnabled = True
            Me.ButtonItemMagazine_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_Internet
            '
            Me.RibbonBarOptions_Internet.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Internet.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Internet.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Internet.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Internet.DragDropSupport = True
            Me.RibbonBarOptions_Internet.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInternet_Add, Me.ButtonItemInternet_Delete, Me.ButtonItemInternet_Cancel, Me.ButtonItemInternet_Approvals})
            Me.RibbonBarOptions_Internet.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Internet.Location = New System.Drawing.Point(920, 0)
            Me.RibbonBarOptions_Internet.Name = "RibbonBarOptions_Internet"
            Me.RibbonBarOptions_Internet.SecurityEnabled = True
            Me.RibbonBarOptions_Internet.Size = New System.Drawing.Size(47, 98)
            Me.RibbonBarOptions_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Internet.TabIndex = 44
            Me.RibbonBarOptions_Internet.Text = "Internet"
            '
            '
            '
            Me.RibbonBarOptions_Internet.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Internet.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Internet.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Internet.Visible = False
            '
            'ButtonItemInternet_Add
            '
            Me.ButtonItemInternet_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInternet_Add.Name = "ButtonItemInternet_Add"
            Me.ButtonItemInternet_Add.SecurityEnabled = True
            Me.ButtonItemInternet_Add.Text = "Add"
            '
            'ButtonItemInternet_Delete
            '
            Me.ButtonItemInternet_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInternet_Delete.Name = "ButtonItemInternet_Delete"
            Me.ButtonItemInternet_Delete.SecurityEnabled = True
            Me.ButtonItemInternet_Delete.Text = "Delete"
            '
            'ButtonItemInternet_Cancel
            '
            Me.ButtonItemInternet_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInternet_Cancel.Name = "ButtonItemInternet_Cancel"
            Me.ButtonItemInternet_Cancel.SecurityEnabled = True
            Me.ButtonItemInternet_Cancel.Text = "Cancel"
            '
            'ButtonItemInternet_Approvals
            '
            Me.ButtonItemInternet_Approvals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInternet_Approvals.Name = "ButtonItemInternet_Approvals"
            Me.ButtonItemInternet_Approvals.SecurityEnabled = True
            Me.ButtonItemInternet_Approvals.Text = "Approvals"
            '
            'RibbonBarOptions_Production
            '
            Me.RibbonBarOptions_Production.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Production.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Production.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Production.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Production.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Production.DragDropSupport = True
            Me.RibbonBarOptions_Production.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProduction_Delete, Me.ButtonItemProduction_Cancel, Me.ButtonItemProduction_PODetail})
            Me.RibbonBarOptions_Production.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Production.Location = New System.Drawing.Point(863, 0)
            Me.RibbonBarOptions_Production.Name = "RibbonBarOptions_Production"
            Me.RibbonBarOptions_Production.SecurityEnabled = True
            Me.RibbonBarOptions_Production.Size = New System.Drawing.Size(57, 98)
            Me.RibbonBarOptions_Production.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Production.TabIndex = 38
            Me.RibbonBarOptions_Production.Text = "Production"
            '
            '
            '
            Me.RibbonBarOptions_Production.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Production.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Production.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Production.Visible = False
            '
            'ButtonItemProduction_Delete
            '
            Me.ButtonItemProduction_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduction_Delete.Name = "ButtonItemProduction_Delete"
            Me.ButtonItemProduction_Delete.SecurityEnabled = True
            Me.ButtonItemProduction_Delete.Text = "Delete"
            '
            'ButtonItemProduction_Cancel
            '
            Me.ButtonItemProduction_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduction_Cancel.Name = "ButtonItemProduction_Cancel"
            Me.ButtonItemProduction_Cancel.SecurityEnabled = True
            Me.ButtonItemProduction_Cancel.Text = "Cancel"
            '
            'ButtonItemProduction_PODetail
            '
            Me.ButtonItemProduction_PODetail.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduction_PODetail.Name = "ButtonItemProduction_PODetail"
            Me.ButtonItemProduction_PODetail.SecurityEnabled = True
            Me.ButtonItemProduction_PODetail.Text = "PO Detail"
            '
            'RibbonBarOptions_NonClient
            '
            Me.RibbonBarOptions_NonClient.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_NonClient.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_NonClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_NonClient.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_NonClient.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_NonClient.DragDropSupport = True
            Me.RibbonBarOptions_NonClient.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNonClient_Delete, Me.ButtonItemNonClient_Cancel, Me.ButtonItemNonClient_PODetail})
            Me.RibbonBarOptions_NonClient.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_NonClient.Location = New System.Drawing.Point(806, 0)
            Me.RibbonBarOptions_NonClient.Name = "RibbonBarOptions_NonClient"
            Me.RibbonBarOptions_NonClient.SecurityEnabled = True
            Me.RibbonBarOptions_NonClient.Size = New System.Drawing.Size(57, 98)
            Me.RibbonBarOptions_NonClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_NonClient.TabIndex = 37
            Me.RibbonBarOptions_NonClient.Text = "Non-Client"
            '
            '
            '
            Me.RibbonBarOptions_NonClient.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_NonClient.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_NonClient.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_NonClient.Visible = False
            '
            'ButtonItemNonClient_Delete
            '
            Me.ButtonItemNonClient_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNonClient_Delete.Name = "ButtonItemNonClient_Delete"
            Me.ButtonItemNonClient_Delete.SecurityEnabled = True
            Me.ButtonItemNonClient_Delete.Text = "Delete"
            '
            'ButtonItemNonClient_Cancel
            '
            Me.ButtonItemNonClient_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNonClient_Cancel.Name = "ButtonItemNonClient_Cancel"
            Me.ButtonItemNonClient_Cancel.SecurityEnabled = True
            Me.ButtonItemNonClient_Cancel.Text = "Cancel"
            '
            'ButtonItemNonClient_PODetail
            '
            Me.ButtonItemNonClient_PODetail.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemNonClient_PODetail.Name = "ButtonItemNonClient_PODetail"
            Me.ButtonItemNonClient_PODetail.SecurityEnabled = True
            Me.ButtonItemNonClient_PODetail.Text = "PO Detail"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Documents})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(754, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(52, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 34
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_View.Visible = False
            '
            'ButtonItemView_Documents
            '
            Me.ButtonItemView_Documents.AutoCheckOnClick = True
            Me.ButtonItemView_Documents.BeginGroup = True
            Me.ButtonItemView_Documents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Documents.Name = "ButtonItemView_Documents"
            Me.ButtonItemView_Documents.RibbonWordWrap = False
            Me.ButtonItemView_Documents.SecurityEnabled = True
            Me.ButtonItemView_Documents.SubItemsExpandWidth = 14
            Me.ButtonItemView_Documents.Text = "Documents"
            '
            'RibbonBarOptions_Flags
            '
            Me.RibbonBarOptions_Flags.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Flags.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Flags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Flags.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Flags.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Flags.DragDropSupport = True
            Me.RibbonBarOptions_Flags.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFlags_Edit})
            Me.RibbonBarOptions_Flags.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Flags.Location = New System.Drawing.Point(706, 0)
            Me.RibbonBarOptions_Flags.Name = "RibbonBarOptions_Flags"
            Me.RibbonBarOptions_Flags.SecurityEnabled = True
            Me.RibbonBarOptions_Flags.Size = New System.Drawing.Size(48, 98)
            Me.RibbonBarOptions_Flags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Flags.TabIndex = 20
            Me.RibbonBarOptions_Flags.Text = "Flags"
            '
            '
            '
            Me.RibbonBarOptions_Flags.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Flags.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Flags.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Flags.Visible = False
            '
            'ButtonItemFlags_Edit
            '
            Me.ButtonItemFlags_Edit.AutoCheckOnClick = True
            Me.ButtonItemFlags_Edit.BeginGroup = True
            Me.ButtonItemFlags_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFlags_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFlags_Edit.Name = "ButtonItemFlags_Edit"
            Me.ButtonItemFlags_Edit.RibbonWordWrap = False
            Me.ButtonItemFlags_Edit.SecurityEnabled = True
            Me.ButtonItemFlags_Edit.Stretch = True
            Me.ButtonItemFlags_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemFlags_Edit.Text = "Edit"
            '
            'RibbonBarOptions_ExpenseReports
            '
            Me.RibbonBarOptions_ExpenseReports.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReports.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReports.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ExpenseReports.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ExpenseReports.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ExpenseReports.DragDropSupport = True
            Me.RibbonBarOptions_ExpenseReports.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExpenseReports_Approve})
            Me.RibbonBarOptions_ExpenseReports.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ExpenseReports.Location = New System.Drawing.Point(616, 0)
            Me.RibbonBarOptions_ExpenseReports.Name = "RibbonBarOptions_ExpenseReports"
            Me.RibbonBarOptions_ExpenseReports.SecurityEnabled = True
            Me.RibbonBarOptions_ExpenseReports.Size = New System.Drawing.Size(90, 98)
            Me.RibbonBarOptions_ExpenseReports.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ExpenseReports.TabIndex = 33
            Me.RibbonBarOptions_ExpenseReports.Text = "Expense Reports"
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReports.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ExpenseReports.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ExpenseReports.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemExpenseReports_Approve
            '
            Me.ButtonItemExpenseReports_Approve.BeginGroup = True
            Me.ButtonItemExpenseReports_Approve.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemExpenseReports_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemExpenseReports_Approve.Name = "ButtonItemExpenseReports_Approve"
            Me.ButtonItemExpenseReports_Approve.RibbonWordWrap = False
            Me.ButtonItemExpenseReports_Approve.SecurityEnabled = True
            Me.ButtonItemExpenseReports_Approve.Stretch = True
            Me.ButtonItemExpenseReports_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemExpenseReports_Approve.Text = "Approve Expense Reports"
            '
            'RibbonBarOptions_Import
            '
            Me.RibbonBarOptions_Import.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Import.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Import.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Import.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Import.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Import.DragDropSupport = True
            Me.RibbonBarOptions_Import.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemImport_AP})
            Me.RibbonBarOptions_Import.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Import.Location = New System.Drawing.Point(582, 0)
            Me.RibbonBarOptions_Import.Name = "RibbonBarOptions_Import"
            Me.RibbonBarOptions_Import.SecurityEnabled = True
            Me.RibbonBarOptions_Import.Size = New System.Drawing.Size(34, 98)
            Me.RibbonBarOptions_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Import.TabIndex = 32
            Me.RibbonBarOptions_Import.Text = "Import"
            '
            '
            '
            Me.RibbonBarOptions_Import.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Import.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Import.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemImport_AP
            '
            Me.ButtonItemImport_AP.BeginGroup = True
            Me.ButtonItemImport_AP.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemImport_AP.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemImport_AP.Name = "ButtonItemImport_AP"
            Me.ButtonItemImport_AP.RibbonWordWrap = False
            Me.ButtonItemImport_AP.SecurityEnabled = True
            Me.ButtonItemImport_AP.Stretch = True
            Me.ButtonItemImport_AP.SubItemsExpandWidth = 14
            Me.ButtonItemImport_AP.Text = "AP"
            '
            'RibbonBarOptions_Vendor
            '
            Me.RibbonBarOptions_Vendor.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Vendor.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Vendor.DragDropSupport = True
            Me.RibbonBarOptions_Vendor.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendor_Edit})
            Me.RibbonBarOptions_Vendor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Vendor.Location = New System.Drawing.Point(530, 0)
            Me.RibbonBarOptions_Vendor.Name = "RibbonBarOptions_Vendor"
            Me.RibbonBarOptions_Vendor.SecurityEnabled = True
            Me.RibbonBarOptions_Vendor.Size = New System.Drawing.Size(52, 98)
            Me.RibbonBarOptions_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Vendor.TabIndex = 22
            Me.RibbonBarOptions_Vendor.Text = "Vendor"
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendor_Edit
            '
            Me.ButtonItemVendor_Edit.BeginGroup = True
            Me.ButtonItemVendor_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_Edit.Name = "ButtonItemVendor_Edit"
            Me.ButtonItemVendor_Edit.RibbonWordWrap = False
            Me.ButtonItemVendor_Edit.SecurityEnabled = True
            Me.ButtonItemVendor_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_Edit.Text = "Edit"
            '
            'RibbonBarOptions_RecurAP
            '
            Me.RibbonBarOptions_RecurAP.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_RecurAP.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecurAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecurAP.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_RecurAP.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_RecurAP.DragDropSupport = True
            Me.RibbonBarOptions_RecurAP.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRecurAP_Setup, Me.ButtonItemRecurAP_Post})
            Me.RibbonBarOptions_RecurAP.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_RecurAP.Location = New System.Drawing.Point(471, 0)
            Me.RibbonBarOptions_RecurAP.Name = "RibbonBarOptions_RecurAP"
            Me.RibbonBarOptions_RecurAP.SecurityEnabled = True
            Me.RibbonBarOptions_RecurAP.Size = New System.Drawing.Size(59, 98)
            Me.RibbonBarOptions_RecurAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_RecurAP.TabIndex = 21
            Me.RibbonBarOptions_RecurAP.Text = "Recur AP"
            '
            '
            '
            Me.RibbonBarOptions_RecurAP.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecurAP.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecurAP.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemRecurAP_Setup
            '
            Me.ButtonItemRecurAP_Setup.BeginGroup = True
            Me.ButtonItemRecurAP_Setup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRecurAP_Setup.Name = "ButtonItemRecurAP_Setup"
            Me.ButtonItemRecurAP_Setup.RibbonWordWrap = False
            Me.ButtonItemRecurAP_Setup.SecurityEnabled = True
            Me.ButtonItemRecurAP_Setup.SubItemsExpandWidth = 14
            Me.ButtonItemRecurAP_Setup.Text = "Setup"
            '
            'ButtonItemRecurAP_Post
            '
            Me.ButtonItemRecurAP_Post.BeginGroup = True
            Me.ButtonItemRecurAP_Post.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRecurAP_Post.Name = "ButtonItemRecurAP_Post"
            Me.ButtonItemRecurAP_Post.RibbonWordWrap = False
            Me.ButtonItemRecurAP_Post.SecurityEnabled = True
            Me.ButtonItemRecurAP_Post.SubItemsExpandWidth = 14
            Me.ButtonItemRecurAP_Post.Text = "Post"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_View, Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print, Me.ButtonItemActions_ShowGross, Me.ButtonItemActions_Alerts, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(471, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerActions_View
            '
            '
            '
            '
            Me.ItemContainerActions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.FixedSize = New System.Drawing.Size(155, 0)
            Me.ItemContainerActions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_View.Name = "ItemContainerActions_View"
            Me.ItemContainerActions_View.ResizeItemsToFit = False
            Me.ItemContainerActions_View.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemActions_View})
            '
            '
            '
            Me.ItemContainerActions_View.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerActions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemActions_View
            '
            Me.ComboBoxItemActions_View.ComboWidth = 145
            Me.ComboBoxItemActions_View.DropDownHeight = 106
            Me.ComboBoxItemActions_View.Name = "ComboBoxItemActions_View"
            Me.ComboBoxItemActions_View.Text = "ComboBoxItem1"
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlN)
            Me.ButtonItemActions_Add.SplitButton = True
            Me.ButtonItemActions_Add.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AddSearch})
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_AddSearch
            '
            Me.ButtonItemActions_AddSearch.Name = "ButtonItemActions_AddSearch"
            Me.ButtonItemActions_AddSearch.SecurityEnabled = True
            Me.ButtonItemActions_AddSearch.Text = "Search for Order"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_ShowGross
            '
            Me.ButtonItemActions_ShowGross.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowGross.BeginGroup = True
            Me.ButtonItemActions_ShowGross.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowGross.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ShowGross.Name = "ButtonItemActions_ShowGross"
            Me.ButtonItemActions_ShowGross.RibbonWordWrap = False
            Me.ButtonItemActions_ShowGross.SecurityEnabled = True
            Me.ButtonItemActions_ShowGross.Stretch = True
            Me.ButtonItemActions_ShowGross.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowGross.Text = "Show Gross"
            '
            'ButtonItemActions_Alerts
            '
            Me.ButtonItemActions_Alerts.AutoExpandOnClick = True
            Me.ButtonItemActions_Alerts.BeginGroup = True
            Me.ButtonItemActions_Alerts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Alerts.Name = "ButtonItemActions_Alerts"
            Me.ButtonItemActions_Alerts.RibbonWordWrap = False
            Me.ButtonItemActions_Alerts.SecurityEnabled = True
            Me.ButtonItemActions_Alerts.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAlerts_View, Me.ButtonItemAlerts_NewAlert, Me.ButtonItemAlerts_NewAlertAssignment})
            Me.ButtonItemActions_Alerts.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Alerts.Text = "Alerts"
            '
            'ButtonItemAlerts_View
            '
            Me.ButtonItemAlerts_View.Name = "ButtonItemAlerts_View"
            Me.ButtonItemAlerts_View.SecurityEnabled = True
            Me.ButtonItemAlerts_View.Text = "View"
            '
            'ButtonItemAlerts_NewAlert
            '
            Me.ButtonItemAlerts_NewAlert.Name = "ButtonItemAlerts_NewAlert"
            Me.ButtonItemAlerts_NewAlert.SecurityEnabled = True
            Me.ButtonItemAlerts_NewAlert.Text = "New Alert"
            '
            'ButtonItemAlerts_NewAlertAssignment
            '
            Me.ButtonItemAlerts_NewAlertAssignment.Name = "ButtonItemAlerts_NewAlertAssignment"
            Me.ButtonItemAlerts_NewAlertAssignment.SecurityEnabled = True
            Me.ButtonItemAlerts_NewAlertAssignment.Text = "New Alert Assignment"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'AccountsPayableForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1622, 691)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableForm"
            Me.Text = "Accounts Payable"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_VendorInvoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents AccountsPayableRightSection_AP As AdvantageFramework.WinForm.Presentation.Controls.AccountsPayableControl
        Friend WithEvents ItemContainerActions_View As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemActions_View As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents DataGridViewLeftSection_Invoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Flags As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFlags_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_RecurAP As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRecurAP_Setup As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRecurAP_Post As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Vendor As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendor_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ShowGross As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AddSearch As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Alerts As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAlerts_View As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAlerts_NewAlert As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAlerts_NewAlertAssignment As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Import As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemImport_AP As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ExpenseReports As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemExpenseReports_Approve As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_Documents As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ExpenseReceipts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemExpenseReceipts_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Internet As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInternet_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInternet_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInternet_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemInternet_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOutOfHome_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOutOfHome_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOutOfHome_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOutOfHome_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_TV As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTV_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTV_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTV_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTV_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Radio As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRadio_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRadio_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRadio_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRadio_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemNewspaper_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemNewspaper_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemNewspaper_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemNewspaper_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Magazine As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMagazine_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMagazine_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMagazine_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMagazine_Approvals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Production As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProduction_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduction_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduction_PODetail As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_NonClient As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemNonClient_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemNonClient_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemNonClient_PODetail As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_RadioDetails As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRadioDetails_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRadioDetails_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_TVDetails As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemTVDetails_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTVDetails_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Quickbooks As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemQuickbooks_SendToQuickbooks As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemQuickbooks_UpdateQuickbooks As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

