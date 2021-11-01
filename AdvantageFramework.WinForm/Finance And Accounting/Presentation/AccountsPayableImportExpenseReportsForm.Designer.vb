Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableImportExpenseReportsForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableImportExpenseReportsForm))
        Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_Search = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_AutoFill = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Approve = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_SetGLAccount = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Receipts = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewInvoices_ExpenseReportData = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Receipts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReceipts_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReceipts_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemReceipts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_OnHold = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOnHold_Check = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOnHold_Uncheck = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_ExpenseReportDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInvoiceslTab_Invoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemExpenseReportDetails_InvoicesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelReceiptsTab_Receipts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlReceipts_Receipts = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemExpenseReportDetails_ReceiptsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonItemActions_Deny = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_ExpenseReportDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ExpenseReportDetails.SuspendLayout()
            Me.TabControlPanelInvoiceslTab_Invoices.SuspendLayout()
            Me.TabControlPanelReceiptsTab_Receipts.SuspendLayout()
            Me.SuspendLayout()
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Search, Me.ButtonItemActions_AutoFill, Me.ButtonItemActions_Approve, Me.ButtonItemActions_Deny, Me.ButtonItemActions_Print, Me.ButtonItemActions_SetGLAccount, Me.ButtonItemActions_Receipts})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(404, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 4
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Search
            '
            Me.ButtonItemActions_Search.BeginGroup = True
            Me.ButtonItemActions_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Search.Name = "ButtonItemActions_Search"
            Me.ButtonItemActions_Search.Stretch = True
            Me.ButtonItemActions_Search.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Search.Text = "Search"
            '
            'ButtonItemActions_AutoFill
            '
            Me.ButtonItemActions_AutoFill.BeginGroup = True
            Me.ButtonItemActions_AutoFill.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_AutoFill.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AutoFill.Name = "ButtonItemActions_AutoFill"
            Me.ButtonItemActions_AutoFill.Stretch = True
            Me.ButtonItemActions_AutoFill.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AutoFill.Text = "Auto Fill"
            Me.ButtonItemActions_AutoFill.Visible = False
            '
            'ButtonItemActions_Approve
            '
            Me.ButtonItemActions_Approve.BeginGroup = True
            Me.ButtonItemActions_Approve.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Approve.Name = "ButtonItemActions_Approve"
            Me.ButtonItemActions_Approve.Stretch = True
            Me.ButtonItemActions_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Approve.Text = "Approve"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_SetGLAccount
            '
            Me.ButtonItemActions_SetGLAccount.BeginGroup = True
            Me.ButtonItemActions_SetGLAccount.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_SetGLAccount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SetGLAccount.Name = "ButtonItemActions_SetGLAccount"
            Me.ButtonItemActions_SetGLAccount.RibbonWordWrap = False
            Me.ButtonItemActions_SetGLAccount.Stretch = True
            Me.ButtonItemActions_SetGLAccount.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SetGLAccount.Text = "Set GL Account"
            '
            'ButtonItemActions_Receipts
            '
            Me.ButtonItemActions_Receipts.BeginGroup = True
            Me.ButtonItemActions_Receipts.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Receipts.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Receipts.Name = "ButtonItemActions_Receipts"
            Me.ButtonItemActions_Receipts.Stretch = True
            Me.ButtonItemActions_Receipts.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Receipts.Text = "Receipts"
            '
            'DataGridViewInvoices_ExpenseReportData
            '
            Me.DataGridViewInvoices_ExpenseReportData.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoices_ExpenseReportData.AllowDragAndDrop = False
            Me.DataGridViewInvoices_ExpenseReportData.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoices_ExpenseReportData.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoices_ExpenseReportData.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoices_ExpenseReportData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoices_ExpenseReportData.AutoFilterLookupColumns = False
            Me.DataGridViewInvoices_ExpenseReportData.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoices_ExpenseReportData.AutoUpdateViewCaption = False
            Me.DataGridViewInvoices_ExpenseReportData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoices_ExpenseReportData.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoices_ExpenseReportData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoices_ExpenseReportData.ItemDescription = "Expense Report(s)"
            Me.DataGridViewInvoices_ExpenseReportData.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewInvoices_ExpenseReportData.MultiSelect = True
            Me.DataGridViewInvoices_ExpenseReportData.Name = "DataGridViewInvoices_ExpenseReportData"
            Me.DataGridViewInvoices_ExpenseReportData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoices_ExpenseReportData.RunStandardValidation = True
            Me.DataGridViewInvoices_ExpenseReportData.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoices_ExpenseReportData.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoices_ExpenseReportData.Size = New System.Drawing.Size(1072, 475)
            Me.DataGridViewInvoices_ExpenseReportData.TabIndex = 41
            Me.DataGridViewInvoices_ExpenseReportData.UseEmbeddedNavigator = False
            Me.DataGridViewInvoices_ExpenseReportData.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Receipts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_OnHold)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(873, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 69
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(634, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(170, 98)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 19
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
            'RibbonBarOptions_Receipts
            '
            Me.RibbonBarOptions_Receipts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Receipts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Receipts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Receipts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Receipts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Receipts.DragDropSupport = True
            Me.RibbonBarOptions_Receipts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReceipts_Upload, Me.ButtonItemReceipts_Download, Me.ButtonItemReceipts_Delete})
            Me.RibbonBarOptions_Receipts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Receipts.Location = New System.Drawing.Point(480, 0)
            Me.RibbonBarOptions_Receipts.Name = "RibbonBarOptions_Receipts"
            Me.RibbonBarOptions_Receipts.SecurityEnabled = True
            Me.RibbonBarOptions_Receipts.Size = New System.Drawing.Size(154, 98)
            Me.RibbonBarOptions_Receipts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Receipts.TabIndex = 18
            Me.RibbonBarOptions_Receipts.Text = "Receipts"
            '
            '
            '
            Me.RibbonBarOptions_Receipts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Receipts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Receipts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemReceipts_Upload
            '
            Me.ButtonItemReceipts_Upload.BeginGroup = True
            Me.ButtonItemReceipts_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReceipts_Upload.Name = "ButtonItemReceipts_Upload"
            Me.ButtonItemReceipts_Upload.RibbonWordWrap = False
            Me.ButtonItemReceipts_Upload.SecurityEnabled = True
            Me.ButtonItemReceipts_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemReceipts_Upload.Text = "Upload"
            Me.ButtonItemReceipts_Upload.Visible = False
            '
            'ButtonItemReceipts_Download
            '
            Me.ButtonItemReceipts_Download.BeginGroup = True
            Me.ButtonItemReceipts_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReceipts_Download.Name = "ButtonItemReceipts_Download"
            Me.ButtonItemReceipts_Download.RibbonWordWrap = False
            Me.ButtonItemReceipts_Download.SecurityEnabled = True
            Me.ButtonItemReceipts_Download.SubItemsExpandWidth = 14
            Me.ButtonItemReceipts_Download.Text = "Download"
            '
            'ButtonItemReceipts_Delete
            '
            Me.ButtonItemReceipts_Delete.BeginGroup = True
            Me.ButtonItemReceipts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReceipts_Delete.Name = "ButtonItemReceipts_Delete"
            Me.ButtonItemReceipts_Delete.RibbonWordWrap = False
            Me.ButtonItemReceipts_Delete.SecurityEnabled = True
            Me.ButtonItemReceipts_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemReceipts_Delete.Text = "Delete"
            Me.ButtonItemReceipts_Delete.Visible = False
            '
            'RibbonBarOptions_OnHold
            '
            Me.RibbonBarOptions_OnHold.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_OnHold.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnHold.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OnHold.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OnHold.DragDropSupport = True
            Me.RibbonBarOptions_OnHold.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOnHold_Check, Me.ButtonItemOnHold_Uncheck})
            Me.RibbonBarOptions_OnHold.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_OnHold.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OnHold.Location = New System.Drawing.Point(404, 0)
            Me.RibbonBarOptions_OnHold.Name = "RibbonBarOptions_OnHold"
            Me.RibbonBarOptions_OnHold.SecurityEnabled = True
            Me.RibbonBarOptions_OnHold.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_OnHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OnHold.TabIndex = 17
            Me.RibbonBarOptions_OnHold.Text = "On Hold"
            '
            '
            '
            Me.RibbonBarOptions_OnHold.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnHold.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnHold.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOnHold_Check
            '
            Me.ButtonItemOnHold_Check.Name = "ButtonItemOnHold_Check"
            Me.ButtonItemOnHold_Check.SecurityEnabled = True
            Me.ButtonItemOnHold_Check.Stretch = True
            Me.ButtonItemOnHold_Check.SubItemsExpandWidth = 14
            Me.ButtonItemOnHold_Check.Text = "Check"
            '
            'ButtonItemOnHold_Uncheck
            '
            Me.ButtonItemOnHold_Uncheck.BeginGroup = True
            Me.ButtonItemOnHold_Uncheck.Name = "ButtonItemOnHold_Uncheck"
            Me.ButtonItemOnHold_Uncheck.SecurityEnabled = True
            Me.ButtonItemOnHold_Uncheck.SubItemsExpandWidth = 14
            Me.ButtonItemOnHold_Uncheck.Text = "Uncheck"
            '
            'TabControlForm_ExpenseReportDetails
            '
            Me.TabControlForm_ExpenseReportDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ExpenseReportDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_ExpenseReportDetails.CanReorderTabs = False
            Me.TabControlForm_ExpenseReportDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_ExpenseReportDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_ExpenseReportDetails.Controls.Add(Me.TabControlPanelInvoiceslTab_Invoices)
            Me.TabControlForm_ExpenseReportDetails.Controls.Add(Me.TabControlPanelReceiptsTab_Receipts)
            Me.TabControlForm_ExpenseReportDetails.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ExpenseReportDetails.Name = "TabControlForm_ExpenseReportDetails"
            Me.TabControlForm_ExpenseReportDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ExpenseReportDetails.SelectedTabIndex = 0
            Me.TabControlForm_ExpenseReportDetails.Size = New System.Drawing.Size(1080, 510)
            Me.TabControlForm_ExpenseReportDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ExpenseReportDetails.TabIndex = 70
            Me.TabControlForm_ExpenseReportDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_InvoicesTab)
            Me.TabControlForm_ExpenseReportDetails.Tabs.Add(Me.TabItemExpenseReportDetails_ReceiptsTab)
            Me.TabControlForm_ExpenseReportDetails.TabStripTabStop = True
            Me.TabControlForm_ExpenseReportDetails.Text = "TabControl1"
            '
            'TabControlPanelInvoiceslTab_Invoices
            '
            Me.TabControlPanelInvoiceslTab_Invoices.Controls.Add(Me.DataGridViewInvoices_ExpenseReportData)
            Me.TabControlPanelInvoiceslTab_Invoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoiceslTab_Invoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoiceslTab_Invoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoiceslTab_Invoices.Name = "TabControlPanelInvoiceslTab_Invoices"
            Me.TabControlPanelInvoiceslTab_Invoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoiceslTab_Invoices.Size = New System.Drawing.Size(1080, 483)
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceslTab_Invoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoiceslTab_Invoices.Style.GradientAngle = 90
            Me.TabControlPanelInvoiceslTab_Invoices.TabIndex = 0
            Me.TabControlPanelInvoiceslTab_Invoices.TabItem = Me.TabItemExpenseReportDetails_InvoicesTab
            '
            'TabItemExpenseReportDetails_InvoicesTab
            '
            Me.TabItemExpenseReportDetails_InvoicesTab.AttachedControl = Me.TabControlPanelInvoiceslTab_Invoices
            Me.TabItemExpenseReportDetails_InvoicesTab.Name = "TabItemExpenseReportDetails_InvoicesTab"
            Me.TabItemExpenseReportDetails_InvoicesTab.Text = "Invoices"
            '
            'TabControlPanelReceiptsTab_Receipts
            '
            Me.TabControlPanelReceiptsTab_Receipts.Controls.Add(Me.DocumentManagerControlReceipts_Receipts)
            Me.TabControlPanelReceiptsTab_Receipts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelReceiptsTab_Receipts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReceiptsTab_Receipts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReceiptsTab_Receipts.Name = "TabControlPanelReceiptsTab_Receipts"
            Me.TabControlPanelReceiptsTab_Receipts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReceiptsTab_Receipts.Size = New System.Drawing.Size(1080, 483)
            Me.TabControlPanelReceiptsTab_Receipts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelReceiptsTab_Receipts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReceiptsTab_Receipts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReceiptsTab_Receipts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReceiptsTab_Receipts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReceiptsTab_Receipts.Style.GradientAngle = 90
            Me.TabControlPanelReceiptsTab_Receipts.TabIndex = 2
            Me.TabControlPanelReceiptsTab_Receipts.TabItem = Me.TabItemExpenseReportDetails_ReceiptsTab
            '
            'DocumentManagerControlReceipts_Receipts
            '
            Me.DocumentManagerControlReceipts_Receipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlReceipts_Receipts.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlReceipts_Receipts.Name = "DocumentManagerControlReceipts_Receipts"
            Me.DocumentManagerControlReceipts_Receipts.Size = New System.Drawing.Size(1072, 475)
            Me.DocumentManagerControlReceipts_Receipts.TabIndex = 0
            '
            'TabItemExpenseReportDetails_ReceiptsTab
            '
            Me.TabItemExpenseReportDetails_ReceiptsTab.AttachedControl = Me.TabControlPanelReceiptsTab_Receipts
            Me.TabItemExpenseReportDetails_ReceiptsTab.Name = "TabItemExpenseReportDetails_ReceiptsTab"
            Me.TabItemExpenseReportDetails_ReceiptsTab.Text = "Receipts"
            '
            'ButtonItemActions_Deny
            '
            Me.ButtonItemActions_Deny.BeginGroup = True
            Me.ButtonItemActions_Deny.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Deny.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Deny.Name = "ButtonItemActions_Deny"
            Me.ButtonItemActions_Deny.Stretch = True
            Me.ButtonItemActions_Deny.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Deny.Text = "Deny"
            '
            'AccountsPayableImportExpenseReportsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1104, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_ExpenseReportDetails)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableImportExpenseReportsForm"
            Me.Text = "AP Approve Expense Reports"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_ExpenseReportDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ExpenseReportDetails.ResumeLayout(False)
            Me.TabControlPanelInvoiceslTab_Invoices.ResumeLayout(False)
            Me.TabControlPanelReceiptsTab_Receipts.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewInvoices_ExpenseReportData As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents ButtonItemActions_AutoFill As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Search As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Approve As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_SetGLAccount As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_ExpenseReportDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelInvoiceslTab_Invoices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemExpenseReportDetails_InvoicesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelReceiptsTab_Receipts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlReceipts_Receipts As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemExpenseReportDetails_ReceiptsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ButtonItemActions_Receipts As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Receipts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReceipts_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReceipts_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemReceipts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_OnHold As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOnHold_Check As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOnHold_Uncheck As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Deny As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace