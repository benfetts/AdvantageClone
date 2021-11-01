Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientInvoiceForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientInvoiceForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Clients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlRightSection_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInvoiceslTab_Invoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInvoices_InvoiceData = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceDetails_InvoicesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlInvoices_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemInvoiceDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonRightSection_Dates = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelRightSection_DateRange = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxRightSection_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ClientContactManagerControlRightSection_ClientContacts = New AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl()
            Me.DateTimePickerRightSection_LastPaymentDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.NumericInputRightSection_AvgDaystoPay = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRightSection_LastPaymentDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_AvgDaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxRightSection_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxRightSection_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRightSection_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxRightSection_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Product = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRightSection_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxRightSection_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Division = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRightSection_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_QuickBooks = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemQuickBooks_Send = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Package = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPackage_Documents = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_DaysToPay = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDaysToPay_ByCheckDate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDaysToPay_ByDepositDate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ZeroInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemZeroInvoices_Exclude = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemZeroInvoices_Include = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ClientInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemClientInvoices_Open = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemClientInvoices_Paid = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemClientInvoices_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemClientInvoices_Voided = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ManualInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Printing = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarPrinting_Printing = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrinting_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrinting_PrintReport = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlRightSection_InvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_InvoiceDetails.SuspendLayout()
            Me.TabControlPanelInvoiceslTab_Invoices.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            CType(Me.SearchableComboBoxRightSection_SalesClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_SalesClass, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerRightSection_LastPaymentDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRightSection_AvgDaystoPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRightSection_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRightSection_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRightSection_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Product, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRightSection_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Division, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Printing.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Clients)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 691)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_Clients
            '
            Me.DataGridViewLeftSection_Clients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Clients.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Clients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Clients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Clients.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Clients.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Clients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Clients.ItemDescription = ""
            Me.DataGridViewLeftSection_Clients.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Clients.MultiSelect = True
            Me.DataGridViewLeftSection_Clients.Name = "DataGridViewLeftSection_Clients"
            Me.DataGridViewLeftSection_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Clients.RunStandardValidation = True
            Me.DataGridViewLeftSection_Clients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Clients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Clients.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_Clients.TabIndex = 0
            Me.DataGridViewLeftSection_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Clients.ViewCaptionHeight = -1
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
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlRightSection_InvoiceDetails)
            Me.PanelForm_RightSection.Controls.Add(Me.ButtonRightSection_Dates)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_DateRange)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_SalesClass)
            Me.PanelForm_RightSection.Controls.Add(Me.SearchableComboBoxRightSection_SalesClass)
            Me.PanelForm_RightSection.Controls.Add(Me.ClientContactManagerControlRightSection_ClientContacts)
            Me.PanelForm_RightSection.Controls.Add(Me.DateTimePickerRightSection_LastPaymentDate)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputRightSection_AvgDaystoPay)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_LastPaymentDate)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_AvgDaysToPay)
            Me.PanelForm_RightSection.Controls.Add(Me.SearchableComboBoxRightSection_Client)
            Me.PanelForm_RightSection.Controls.Add(Me.SearchableComboBoxRightSection_Office)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Office)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Product)
            Me.PanelForm_RightSection.Controls.Add(Me.SearchableComboBoxRightSection_Product)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Division)
            Me.PanelForm_RightSection.Controls.Add(Me.SearchableComboBoxRightSection_Division)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Client)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(203, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1078, 691)
            Me.PanelForm_RightSection.TabIndex = 1
            '
            'TabControlRightSection_InvoiceDetails
            '
            Me.TabControlRightSection_InvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_InvoiceDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlRightSection_InvoiceDetails.CanReorderTabs = False
            Me.TabControlRightSection_InvoiceDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlRightSection_InvoiceDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlRightSection_InvoiceDetails.Controls.Add(Me.TabControlPanelInvoiceslTab_Invoices)
            Me.TabControlRightSection_InvoiceDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlRightSection_InvoiceDetails.Location = New System.Drawing.Point(6, 194)
            Me.TabControlRightSection_InvoiceDetails.Name = "TabControlRightSection_InvoiceDetails"
            Me.TabControlRightSection_InvoiceDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_InvoiceDetails.SelectedTabIndex = 0
            Me.TabControlRightSection_InvoiceDetails.Size = New System.Drawing.Size(1060, 485)
            Me.TabControlRightSection_InvoiceDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_InvoiceDetails.TabIndex = 71
            Me.TabControlRightSection_InvoiceDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_InvoicesTab)
            Me.TabControlRightSection_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_DocumentsTab)
            Me.TabControlRightSection_InvoiceDetails.TabStripTabStop = True
            Me.TabControlRightSection_InvoiceDetails.Text = "TabControl1"
            '
            'TabControlPanelInvoiceslTab_Invoices
            '
            Me.TabControlPanelInvoiceslTab_Invoices.Controls.Add(Me.DataGridViewInvoices_InvoiceData)
            Me.TabControlPanelInvoiceslTab_Invoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoiceslTab_Invoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoiceslTab_Invoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoiceslTab_Invoices.Name = "TabControlPanelInvoiceslTab_Invoices"
            Me.TabControlPanelInvoiceslTab_Invoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoiceslTab_Invoices.Size = New System.Drawing.Size(1060, 458)
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceslTab_Invoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoiceslTab_Invoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoiceslTab_Invoices.Style.GradientAngle = 90
            Me.TabControlPanelInvoiceslTab_Invoices.TabIndex = 0
            Me.TabControlPanelInvoiceslTab_Invoices.TabItem = Me.TabItemInvoiceDetails_InvoicesTab
            '
            'DataGridViewInvoices_InvoiceData
            '
            Me.DataGridViewInvoices_InvoiceData.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoices_InvoiceData.AllowDragAndDrop = False
            Me.DataGridViewInvoices_InvoiceData.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoices_InvoiceData.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoices_InvoiceData.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoices_InvoiceData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoices_InvoiceData.AutoFilterLookupColumns = False
            Me.DataGridViewInvoices_InvoiceData.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoices_InvoiceData.AutoUpdateViewCaption = True
            Me.DataGridViewInvoices_InvoiceData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoices_InvoiceData.DataSource = Nothing
            Me.DataGridViewInvoices_InvoiceData.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoices_InvoiceData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoices_InvoiceData.ItemDescription = ""
            Me.DataGridViewInvoices_InvoiceData.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewInvoices_InvoiceData.MultiSelect = True
            Me.DataGridViewInvoices_InvoiceData.Name = "DataGridViewInvoices_InvoiceData"
            Me.DataGridViewInvoices_InvoiceData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoices_InvoiceData.RunStandardValidation = True
            Me.DataGridViewInvoices_InvoiceData.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoices_InvoiceData.ShowSelectDeselectAllButtons = True
            Me.DataGridViewInvoices_InvoiceData.Size = New System.Drawing.Size(1052, 450)
            Me.DataGridViewInvoices_InvoiceData.TabIndex = 41
            Me.DataGridViewInvoices_InvoiceData.UseEmbeddedNavigator = False
            Me.DataGridViewInvoices_InvoiceData.ViewCaptionHeight = -1
            '
            'TabItemInvoiceDetails_InvoicesTab
            '
            Me.TabItemInvoiceDetails_InvoicesTab.AttachedControl = Me.TabControlPanelInvoiceslTab_Invoices
            Me.TabItemInvoiceDetails_InvoicesTab.Name = "TabItemInvoiceDetails_InvoicesTab"
            Me.TabItemInvoiceDetails_InvoicesTab.Text = "Invoices"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlInvoices_Documents)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(1060, 458)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 2
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemInvoiceDetails_DocumentsTab
            '
            'DocumentManagerControlInvoices_Documents
            '
            Me.DocumentManagerControlInvoices_Documents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlInvoices_Documents.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlInvoices_Documents.Name = "DocumentManagerControlInvoices_Documents"
            Me.DocumentManagerControlInvoices_Documents.Size = New System.Drawing.Size(1052, 450)
            Me.DocumentManagerControlInvoices_Documents.TabIndex = 0
            '
            'TabItemInvoiceDetails_DocumentsTab
            '
            Me.TabItemInvoiceDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemInvoiceDetails_DocumentsTab.Name = "TabItemInvoiceDetails_DocumentsTab"
            Me.TabItemInvoiceDetails_DocumentsTab.Text = "Documents"
            '
            'ButtonRightSection_Dates
            '
            Me.ButtonRightSection_Dates.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_Dates.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_Dates.Location = New System.Drawing.Point(349, 142)
            Me.ButtonRightSection_Dates.Name = "ButtonRightSection_Dates"
            Me.ButtonRightSection_Dates.SecurityEnabled = True
            Me.ButtonRightSection_Dates.Size = New System.Drawing.Size(60, 20)
            Me.ButtonRightSection_Dates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_Dates.TabIndex = 37
            Me.ButtonRightSection_Dates.Text = "Dates..."
            '
            'LabelRightSection_DateRange
            '
            Me.LabelRightSection_DateRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_DateRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_DateRange.Location = New System.Drawing.Point(211, 142)
            Me.LabelRightSection_DateRange.Name = "LabelRightSection_DateRange"
            Me.LabelRightSection_DateRange.Size = New System.Drawing.Size(132, 20)
            Me.LabelRightSection_DateRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_DateRange.TabIndex = 16
            Me.LabelRightSection_DateRange.Text = "12/31/2012 to 12/31/2014"
            '
            'LabelRightSection_SalesClass
            '
            Me.LabelRightSection_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_SalesClass.Location = New System.Drawing.Point(6, 116)
            Me.LabelRightSection_SalesClass.Name = "LabelRightSection_SalesClass"
            Me.LabelRightSection_SalesClass.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_SalesClass.TabIndex = 8
            Me.LabelRightSection_SalesClass.Text = "Sales Class:"
            '
            'SearchableComboBoxRightSection_SalesClass
            '
            Me.SearchableComboBoxRightSection_SalesClass.ActiveFilterString = ""
            Me.SearchableComboBoxRightSection_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRightSection_SalesClass.AutoFillMode = False
            Me.SearchableComboBoxRightSection_SalesClass.BookmarkingEnabled = False
            Me.SearchableComboBoxRightSection_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.SalesClass
            Me.SearchableComboBoxRightSection_SalesClass.DataSource = Nothing
            Me.SearchableComboBoxRightSection_SalesClass.DisableMouseWheel = True
            Me.SearchableComboBoxRightSection_SalesClass.DisplayName = ""
            Me.SearchableComboBoxRightSection_SalesClass.EnterMoveNextControl = True
            Me.SearchableComboBoxRightSection_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxRightSection_SalesClass.Location = New System.Drawing.Point(128, 116)
            Me.SearchableComboBoxRightSection_SalesClass.Name = "SearchableComboBoxRightSection_SalesClass"
            Me.SearchableComboBoxRightSection_SalesClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRightSection_SalesClass.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxRightSection_SalesClass.Properties.NullText = "Select Sales Class"
            Me.SearchableComboBoxRightSection_SalesClass.Properties.PopupView = Me.SearchableComboBoxView_SalesClass
            Me.SearchableComboBoxRightSection_SalesClass.Properties.ShowClearButton = False
            Me.SearchableComboBoxRightSection_SalesClass.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRightSection_SalesClass.SecurityEnabled = True
            Me.SearchableComboBoxRightSection_SalesClass.SelectedValue = Nothing
            Me.SearchableComboBoxRightSection_SalesClass.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxRightSection_SalesClass.TabIndex = 9
            '
            'SearchableComboBoxView_SalesClass
            '
            Me.SearchableComboBoxView_SalesClass.AFActiveFilterString = ""
            Me.SearchableComboBoxView_SalesClass.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_SalesClass.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_SalesClass.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_SalesClass.DataSourceClearing = False
            Me.SearchableComboBoxView_SalesClass.EnableDisabledRows = False
            Me.SearchableComboBoxView_SalesClass.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_SalesClass.Name = "SearchableComboBoxView_SalesClass"
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_SalesClass.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_SalesClass.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_SalesClass.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_SalesClass.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_SalesClass.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_SalesClass.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_SalesClass.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_SalesClass.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_SalesClass.RunStandardValidation = True
            Me.SearchableComboBoxView_SalesClass.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_SalesClass.SkipSettingFontOnModifyColumn = False
            '
            'ClientContactManagerControlRightSection_ClientContacts
            '
            Me.ClientContactManagerControlRightSection_ClientContacts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientContactManagerControlRightSection_ClientContacts.Location = New System.Drawing.Point(415, 12)
            Me.ClientContactManagerControlRightSection_ClientContacts.Name = "ClientContactManagerControlRightSection_ClientContacts"
            Me.ClientContactManagerControlRightSection_ClientContacts.Size = New System.Drawing.Size(651, 176)
            Me.ClientContactManagerControlRightSection_ClientContacts.TabIndex = 14
            '
            'DateTimePickerRightSection_LastPaymentDate
            '
            Me.DateTimePickerRightSection_LastPaymentDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerRightSection_LastPaymentDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerRightSection_LastPaymentDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRightSection_LastPaymentDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerRightSection_LastPaymentDate.ButtonFreeText.Checked = True
            Me.DateTimePickerRightSection_LastPaymentDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerRightSection_LastPaymentDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerRightSection_LastPaymentDate.DisplayName = ""
            Me.DateTimePickerRightSection_LastPaymentDate.Enabled = False
            Me.DateTimePickerRightSection_LastPaymentDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerRightSection_LastPaymentDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerRightSection_LastPaymentDate.FocusHighlightEnabled = True
            Me.DateTimePickerRightSection_LastPaymentDate.FreeTextEntryMode = True
            Me.DateTimePickerRightSection_LastPaymentDate.IsPopupCalendarOpen = False
            Me.DateTimePickerRightSection_LastPaymentDate.Location = New System.Drawing.Point(128, 168)
            Me.DateTimePickerRightSection_LastPaymentDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerRightSection_LastPaymentDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRightSection_LastPaymentDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerRightSection_LastPaymentDate.Name = "DateTimePickerRightSection_LastPaymentDate"
            Me.DateTimePickerRightSection_LastPaymentDate.ReadOnly = True
            Me.DateTimePickerRightSection_LastPaymentDate.Size = New System.Drawing.Size(77, 21)
            Me.DateTimePickerRightSection_LastPaymentDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerRightSection_LastPaymentDate.TabIndex = 13
            Me.DateTimePickerRightSection_LastPaymentDate.TabOnEnter = True
            Me.DateTimePickerRightSection_LastPaymentDate.TabStop = False
            Me.DateTimePickerRightSection_LastPaymentDate.Value = New Date(2014, 1, 21, 14, 42, 16, 811)
            '
            'NumericInputRightSection_AvgDaystoPay
            '
            Me.NumericInputRightSection_AvgDaystoPay.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRightSection_AvgDaystoPay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputRightSection_AvgDaystoPay.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRightSection_AvgDaystoPay.EnterMoveNextControl = True
            Me.NumericInputRightSection_AvgDaystoPay.Location = New System.Drawing.Point(128, 142)
            Me.NumericInputRightSection_AvgDaystoPay.Name = "NumericInputRightSection_AvgDaystoPay"
            Me.NumericInputRightSection_AvgDaystoPay.Properties.AllowMouseWheel = False
            Me.NumericInputRightSection_AvgDaystoPay.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputRightSection_AvgDaystoPay.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRightSection_AvgDaystoPay.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputRightSection_AvgDaystoPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightSection_AvgDaystoPay.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputRightSection_AvgDaystoPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightSection_AvgDaystoPay.Properties.IsFloatValue = False
            Me.NumericInputRightSection_AvgDaystoPay.Properties.Mask.EditMask = "f0"
            Me.NumericInputRightSection_AvgDaystoPay.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRightSection_AvgDaystoPay.Properties.MaxLength = 6
            Me.NumericInputRightSection_AvgDaystoPay.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputRightSection_AvgDaystoPay.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputRightSection_AvgDaystoPay.Properties.ReadOnly = True
            Me.NumericInputRightSection_AvgDaystoPay.SecurityEnabled = True
            Me.NumericInputRightSection_AvgDaystoPay.Size = New System.Drawing.Size(77, 20)
            Me.NumericInputRightSection_AvgDaystoPay.TabIndex = 11
            Me.NumericInputRightSection_AvgDaystoPay.TabStop = False
            '
            'LabelRightSection_LastPaymentDate
            '
            Me.LabelRightSection_LastPaymentDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_LastPaymentDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_LastPaymentDate.Location = New System.Drawing.Point(6, 168)
            Me.LabelRightSection_LastPaymentDate.Name = "LabelRightSection_LastPaymentDate"
            Me.LabelRightSection_LastPaymentDate.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_LastPaymentDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_LastPaymentDate.TabIndex = 12
            Me.LabelRightSection_LastPaymentDate.Text = "Last Payment Date:"
            '
            'LabelRightSection_AvgDaysToPay
            '
            Me.LabelRightSection_AvgDaysToPay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_AvgDaysToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_AvgDaysToPay.Location = New System.Drawing.Point(6, 142)
            Me.LabelRightSection_AvgDaysToPay.Name = "LabelRightSection_AvgDaysToPay"
            Me.LabelRightSection_AvgDaysToPay.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_AvgDaysToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_AvgDaysToPay.TabIndex = 10
            Me.LabelRightSection_AvgDaysToPay.Text = "Average Days to Pay:"
            '
            'SearchableComboBoxRightSection_Client
            '
            Me.SearchableComboBoxRightSection_Client.ActiveFilterString = ""
            Me.SearchableComboBoxRightSection_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRightSection_Client.AutoFillMode = False
            Me.SearchableComboBoxRightSection_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxRightSection_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxRightSection_Client.DataSource = Nothing
            Me.SearchableComboBoxRightSection_Client.DisableMouseWheel = True
            Me.SearchableComboBoxRightSection_Client.DisplayName = ""
            Me.SearchableComboBoxRightSection_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxRightSection_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxRightSection_Client.Location = New System.Drawing.Point(128, 12)
            Me.SearchableComboBoxRightSection_Client.Name = "SearchableComboBoxRightSection_Client"
            Me.SearchableComboBoxRightSection_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRightSection_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRightSection_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxRightSection_Client.Properties.PopupView = Me.SearchableComboBoxView_Client
            Me.SearchableComboBoxRightSection_Client.Properties.ReadOnly = True
            Me.SearchableComboBoxRightSection_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxRightSection_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRightSection_Client.SecurityEnabled = True
            Me.SearchableComboBoxRightSection_Client.SelectedValue = Nothing
            Me.SearchableComboBoxRightSection_Client.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxRightSection_Client.TabIndex = 1
            Me.SearchableComboBoxRightSection_Client.TabStop = False
            '
            'SearchableComboBoxView_Client
            '
            Me.SearchableComboBoxView_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Client.DataSourceClearing = False
            Me.SearchableComboBoxView_Client.EnableDisabledRows = False
            Me.SearchableComboBoxView_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Client.Name = "SearchableComboBoxView_Client"
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Client.RunStandardValidation = True
            Me.SearchableComboBoxView_Client.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_Client.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxRightSection_Office
            '
            Me.SearchableComboBoxRightSection_Office.ActiveFilterString = ""
            Me.SearchableComboBoxRightSection_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRightSection_Office.AutoFillMode = False
            Me.SearchableComboBoxRightSection_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxRightSection_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxRightSection_Office.DataSource = Nothing
            Me.SearchableComboBoxRightSection_Office.DisableMouseWheel = True
            Me.SearchableComboBoxRightSection_Office.DisplayName = ""
            Me.SearchableComboBoxRightSection_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxRightSection_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxRightSection_Office.Location = New System.Drawing.Point(128, 90)
            Me.SearchableComboBoxRightSection_Office.Name = "SearchableComboBoxRightSection_Office"
            Me.SearchableComboBoxRightSection_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRightSection_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRightSection_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxRightSection_Office.Properties.PopupView = Me.SearchableComboBoxView_Office
            Me.SearchableComboBoxRightSection_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxRightSection_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRightSection_Office.SecurityEnabled = True
            Me.SearchableComboBoxRightSection_Office.SelectedValue = Nothing
            Me.SearchableComboBoxRightSection_Office.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxRightSection_Office.TabIndex = 7
            '
            'SearchableComboBoxView_Office
            '
            Me.SearchableComboBoxView_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Office.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Office.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Office.DataSourceClearing = False
            Me.SearchableComboBoxView_Office.EnableDisabledRows = False
            Me.SearchableComboBoxView_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Office.Name = "SearchableComboBoxView_Office"
            Me.SearchableComboBoxView_Office.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Office.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Office.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Office.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Office.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Office.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Office.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Office.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Office.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Office.RunStandardValidation = True
            Me.SearchableComboBoxView_Office.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_Office.SkipSettingFontOnModifyColumn = False
            '
            'LabelRightSection_Office
            '
            Me.LabelRightSection_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Office.Location = New System.Drawing.Point(6, 90)
            Me.LabelRightSection_Office.Name = "LabelRightSection_Office"
            Me.LabelRightSection_Office.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Office.TabIndex = 6
            Me.LabelRightSection_Office.Text = "Office:"
            '
            'LabelRightSection_Product
            '
            Me.LabelRightSection_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Product.Location = New System.Drawing.Point(6, 64)
            Me.LabelRightSection_Product.Name = "LabelRightSection_Product"
            Me.LabelRightSection_Product.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Product.TabIndex = 4
            Me.LabelRightSection_Product.Text = "Product:"
            '
            'SearchableComboBoxRightSection_Product
            '
            Me.SearchableComboBoxRightSection_Product.ActiveFilterString = ""
            Me.SearchableComboBoxRightSection_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRightSection_Product.AutoFillMode = False
            Me.SearchableComboBoxRightSection_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxRightSection_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxRightSection_Product.DataSource = Nothing
            Me.SearchableComboBoxRightSection_Product.DisableMouseWheel = True
            Me.SearchableComboBoxRightSection_Product.DisplayName = ""
            Me.SearchableComboBoxRightSection_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxRightSection_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxRightSection_Product.Location = New System.Drawing.Point(128, 64)
            Me.SearchableComboBoxRightSection_Product.Name = "SearchableComboBoxRightSection_Product"
            Me.SearchableComboBoxRightSection_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRightSection_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRightSection_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxRightSection_Product.Properties.PopupView = Me.SearchableComboBoxView_Product
            Me.SearchableComboBoxRightSection_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxRightSection_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRightSection_Product.SecurityEnabled = True
            Me.SearchableComboBoxRightSection_Product.SelectedValue = Nothing
            Me.SearchableComboBoxRightSection_Product.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxRightSection_Product.TabIndex = 5
            '
            'SearchableComboBoxView_Product
            '
            Me.SearchableComboBoxView_Product.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Product.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Product.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Product.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Product.DataSourceClearing = False
            Me.SearchableComboBoxView_Product.EnableDisabledRows = False
            Me.SearchableComboBoxView_Product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Product.Name = "SearchableComboBoxView_Product"
            Me.SearchableComboBoxView_Product.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Product.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Product.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Product.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Product.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Product.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Product.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Product.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Product.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Product.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Product.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Product.RunStandardValidation = True
            Me.SearchableComboBoxView_Product.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_Product.SkipSettingFontOnModifyColumn = False
            '
            'LabelRightSection_Division
            '
            Me.LabelRightSection_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Division.Location = New System.Drawing.Point(6, 38)
            Me.LabelRightSection_Division.Name = "LabelRightSection_Division"
            Me.LabelRightSection_Division.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Division.TabIndex = 2
            Me.LabelRightSection_Division.Text = "Division:"
            '
            'SearchableComboBoxRightSection_Division
            '
            Me.SearchableComboBoxRightSection_Division.ActiveFilterString = ""
            Me.SearchableComboBoxRightSection_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRightSection_Division.AutoFillMode = False
            Me.SearchableComboBoxRightSection_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxRightSection_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxRightSection_Division.DataSource = Nothing
            Me.SearchableComboBoxRightSection_Division.DisableMouseWheel = True
            Me.SearchableComboBoxRightSection_Division.DisplayName = ""
            Me.SearchableComboBoxRightSection_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxRightSection_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxRightSection_Division.Location = New System.Drawing.Point(128, 38)
            Me.SearchableComboBoxRightSection_Division.Name = "SearchableComboBoxRightSection_Division"
            Me.SearchableComboBoxRightSection_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRightSection_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRightSection_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxRightSection_Division.Properties.PopupView = Me.SearchableComboBoxView_Division
            Me.SearchableComboBoxRightSection_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxRightSection_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRightSection_Division.SecurityEnabled = True
            Me.SearchableComboBoxRightSection_Division.SelectedValue = Nothing
            Me.SearchableComboBoxRightSection_Division.Size = New System.Drawing.Size(281, 20)
            Me.SearchableComboBoxRightSection_Division.TabIndex = 3
            '
            'SearchableComboBoxView_Division
            '
            Me.SearchableComboBoxView_Division.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Division.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Division.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Division.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Division.DataSourceClearing = False
            Me.SearchableComboBoxView_Division.EnableDisabledRows = False
            Me.SearchableComboBoxView_Division.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Division.Name = "SearchableComboBoxView_Division"
            Me.SearchableComboBoxView_Division.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Division.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Division.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Division.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Division.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Division.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Division.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Division.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Division.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Division.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Division.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Division.RunStandardValidation = True
            Me.SearchableComboBoxView_Division.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_Division.SkipSettingFontOnModifyColumn = False
            '
            'LabelRightSection_Client
            '
            Me.LabelRightSection_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Client.Location = New System.Drawing.Point(6, 12)
            Me.LabelRightSection_Client.Name = "LabelRightSection_Client"
            Me.LabelRightSection_Client.Size = New System.Drawing.Size(116, 20)
            Me.LabelRightSection_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Client.TabIndex = 0
            Me.LabelRightSection_Client.Text = "Client:"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_QuickBooks)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Package)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_DaysToPay)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ZeroInvoices)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ClientInvoices)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ManualInvoices)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(274, 64)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(941, 98)
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
            'RibbonBarOptions_QuickBooks
            '
            Me.RibbonBarOptions_QuickBooks.AutoOverflowEnabled = False
            Me.RibbonBarOptions_QuickBooks.AutoSizeIncludesTitle = True
            Me.RibbonBarOptions_QuickBooks.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickBooks.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickBooks.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickBooks.DragDropSupport = True
            Me.RibbonBarOptions_QuickBooks.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_QuickBooks.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickBooks_Send})
            Me.RibbonBarOptions_QuickBooks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickBooks.Location = New System.Drawing.Point(856, 0)
            Me.RibbonBarOptions_QuickBooks.Name = "RibbonBarOptions_QuickBooks"
            Me.RibbonBarOptions_QuickBooks.SecurityEnabled = True
            Me.RibbonBarOptions_QuickBooks.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_QuickBooks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickBooks.TabIndex = 7
            Me.RibbonBarOptions_QuickBooks.Text = "QuickBooks"
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickBooks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickBooks.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemQuickBooks_Send
            '
            Me.ButtonItemQuickBooks_Send.BeginGroup = True
            Me.ButtonItemQuickBooks_Send.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemQuickBooks_Send.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.ButtonItemQuickBooks_Send.Name = "ButtonItemQuickBooks_Send"
            Me.ButtonItemQuickBooks_Send.RibbonWordWrap = False
            Me.ButtonItemQuickBooks_Send.SecurityEnabled = True
            Me.ButtonItemQuickBooks_Send.SubItemsExpandWidth = 14
            Me.ButtonItemQuickBooks_Send.Text = "Send"
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
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(640, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(216, 98)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 6
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
            'RibbonBarOptions_Package
            '
            Me.RibbonBarOptions_Package.AutoOverflowEnabled = False
            Me.RibbonBarOptions_Package.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_Package.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Package.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Package.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Package.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Package.DragDropSupport = True
            Me.RibbonBarOptions_Package.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Package.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPackage_Documents})
            Me.RibbonBarOptions_Package.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Package.Location = New System.Drawing.Point(568, 0)
            Me.RibbonBarOptions_Package.Name = "RibbonBarOptions_Package"
            Me.RibbonBarOptions_Package.SecurityEnabled = True
            Me.RibbonBarOptions_Package.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_Package.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Package.TabIndex = 5
            Me.RibbonBarOptions_Package.Text = "Package"
            '
            '
            '
            Me.RibbonBarOptions_Package.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Package.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Package.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPackage_Documents
            '
            Me.ButtonItemPackage_Documents.BeginGroup = True
            Me.ButtonItemPackage_Documents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPackage_Documents.Name = "ButtonItemPackage_Documents"
            Me.ButtonItemPackage_Documents.RibbonWordWrap = False
            Me.ButtonItemPackage_Documents.SecurityEnabled = True
            Me.ButtonItemPackage_Documents.SubItemsExpandWidth = 14
            Me.ButtonItemPackage_Documents.Text = "Documents"
            '
            'RibbonBarOptions_DaysToPay
            '
            Me.RibbonBarOptions_DaysToPay.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DaysToPay.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DaysToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DaysToPay.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DaysToPay.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DaysToPay.DragDropSupport = True
            Me.RibbonBarOptions_DaysToPay.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDaysToPay_ByCheckDate, Me.ButtonItemDaysToPay_ByDepositDate})
            Me.RibbonBarOptions_DaysToPay.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DaysToPay.Location = New System.Drawing.Point(388, 0)
            Me.RibbonBarOptions_DaysToPay.Name = "RibbonBarOptions_DaysToPay"
            Me.RibbonBarOptions_DaysToPay.SecurityEnabled = True
            Me.RibbonBarOptions_DaysToPay.Size = New System.Drawing.Size(180, 98)
            Me.RibbonBarOptions_DaysToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DaysToPay.TabIndex = 3
            Me.RibbonBarOptions_DaysToPay.Text = "Calculate Days To Pay"
            '
            '
            '
            Me.RibbonBarOptions_DaysToPay.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DaysToPay.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DaysToPay.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDaysToPay_ByCheckDate
            '
            Me.ButtonItemDaysToPay_ByCheckDate.AutoCheckOnClick = True
            Me.ButtonItemDaysToPay_ByCheckDate.BeginGroup = True
            Me.ButtonItemDaysToPay_ByCheckDate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDaysToPay_ByCheckDate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDaysToPay_ByCheckDate.Name = "ButtonItemDaysToPay_ByCheckDate"
            Me.ButtonItemDaysToPay_ByCheckDate.OptionGroup = "AllOpenPaid"
            Me.ButtonItemDaysToPay_ByCheckDate.RibbonWordWrap = False
            Me.ButtonItemDaysToPay_ByCheckDate.SecurityEnabled = True
            Me.ButtonItemDaysToPay_ByCheckDate.Stretch = True
            Me.ButtonItemDaysToPay_ByCheckDate.SubItemsExpandWidth = 14
            Me.ButtonItemDaysToPay_ByCheckDate.Text = "By Check Date"
            '
            'ButtonItemDaysToPay_ByDepositDate
            '
            Me.ButtonItemDaysToPay_ByDepositDate.AutoCheckOnClick = True
            Me.ButtonItemDaysToPay_ByDepositDate.BeginGroup = True
            Me.ButtonItemDaysToPay_ByDepositDate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDaysToPay_ByDepositDate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDaysToPay_ByDepositDate.Name = "ButtonItemDaysToPay_ByDepositDate"
            Me.ButtonItemDaysToPay_ByDepositDate.OptionGroup = "AllOpenPaid"
            Me.ButtonItemDaysToPay_ByDepositDate.RibbonWordWrap = False
            Me.ButtonItemDaysToPay_ByDepositDate.SecurityEnabled = True
            Me.ButtonItemDaysToPay_ByDepositDate.Stretch = True
            Me.ButtonItemDaysToPay_ByDepositDate.SubItemsExpandWidth = 14
            Me.ButtonItemDaysToPay_ByDepositDate.Text = "By Deposit Date"
            '
            'RibbonBarOptions_ZeroInvoices
            '
            Me.RibbonBarOptions_ZeroInvoices.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ZeroInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ZeroInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ZeroInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ZeroInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ZeroInvoices.DragDropSupport = True
            Me.RibbonBarOptions_ZeroInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemZeroInvoices_Exclude, Me.ButtonItemZeroInvoices_Include})
            Me.RibbonBarOptions_ZeroInvoices.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_ZeroInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ZeroInvoices.Location = New System.Drawing.Point(299, 0)
            Me.RibbonBarOptions_ZeroInvoices.Name = "RibbonBarOptions_ZeroInvoices"
            Me.RibbonBarOptions_ZeroInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_ZeroInvoices.Size = New System.Drawing.Size(89, 98)
            Me.RibbonBarOptions_ZeroInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ZeroInvoices.TabIndex = 2
            Me.RibbonBarOptions_ZeroInvoices.Text = "Zero Invoices"
            '
            '
            '
            Me.RibbonBarOptions_ZeroInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ZeroInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ZeroInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemZeroInvoices_Exclude
            '
            Me.ButtonItemZeroInvoices_Exclude.BeginGroup = True
            Me.ButtonItemZeroInvoices_Exclude.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemZeroInvoices_Exclude.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemZeroInvoices_Exclude.Name = "ButtonItemZeroInvoices_Exclude"
            Me.ButtonItemZeroInvoices_Exclude.OptionGroup = "ZeroInvoices"
            Me.ButtonItemZeroInvoices_Exclude.RibbonWordWrap = False
            Me.ButtonItemZeroInvoices_Exclude.SecurityEnabled = True
            Me.ButtonItemZeroInvoices_Exclude.Stretch = True
            Me.ButtonItemZeroInvoices_Exclude.SubItemsExpandWidth = 14
            Me.ButtonItemZeroInvoices_Exclude.Text = "Exclude Invoices"
            '
            'ButtonItemZeroInvoices_Include
            '
            Me.ButtonItemZeroInvoices_Include.BeginGroup = True
            Me.ButtonItemZeroInvoices_Include.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemZeroInvoices_Include.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemZeroInvoices_Include.Name = "ButtonItemZeroInvoices_Include"
            Me.ButtonItemZeroInvoices_Include.OptionGroup = "ZeroInvoices"
            Me.ButtonItemZeroInvoices_Include.RibbonWordWrap = False
            Me.ButtonItemZeroInvoices_Include.SecurityEnabled = True
            Me.ButtonItemZeroInvoices_Include.Stretch = True
            Me.ButtonItemZeroInvoices_Include.SubItemsExpandWidth = 14
            Me.ButtonItemZeroInvoices_Include.Text = "Include Invoices"
            '
            'RibbonBarOptions_ClientInvoices
            '
            Me.RibbonBarOptions_ClientInvoices.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ClientInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClientInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClientInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ClientInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ClientInvoices.DragDropSupport = True
            Me.RibbonBarOptions_ClientInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClientInvoices_Open, Me.ButtonItemClientInvoices_Paid, Me.ButtonItemClientInvoices_All, Me.ButtonItemClientInvoices_Voided})
            Me.RibbonBarOptions_ClientInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ClientInvoices.Location = New System.Drawing.Point(134, 0)
            Me.RibbonBarOptions_ClientInvoices.Name = "RibbonBarOptions_ClientInvoices"
            Me.RibbonBarOptions_ClientInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_ClientInvoices.Size = New System.Drawing.Size(165, 98)
            Me.RibbonBarOptions_ClientInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ClientInvoices.TabIndex = 1
            Me.RibbonBarOptions_ClientInvoices.Text = "Client Invoices"
            '
            '
            '
            Me.RibbonBarOptions_ClientInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClientInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClientInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemClientInvoices_Open
            '
            Me.ButtonItemClientInvoices_Open.AutoCheckOnClick = True
            Me.ButtonItemClientInvoices_Open.BeginGroup = True
            Me.ButtonItemClientInvoices_Open.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClientInvoices_Open.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClientInvoices_Open.Name = "ButtonItemClientInvoices_Open"
            Me.ButtonItemClientInvoices_Open.OptionGroup = "AllOpenPaid"
            Me.ButtonItemClientInvoices_Open.RibbonWordWrap = False
            Me.ButtonItemClientInvoices_Open.SecurityEnabled = True
            Me.ButtonItemClientInvoices_Open.Stretch = True
            Me.ButtonItemClientInvoices_Open.SubItemsExpandWidth = 14
            Me.ButtonItemClientInvoices_Open.Text = "Open"
            '
            'ButtonItemClientInvoices_Paid
            '
            Me.ButtonItemClientInvoices_Paid.AutoCheckOnClick = True
            Me.ButtonItemClientInvoices_Paid.BeginGroup = True
            Me.ButtonItemClientInvoices_Paid.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClientInvoices_Paid.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClientInvoices_Paid.Name = "ButtonItemClientInvoices_Paid"
            Me.ButtonItemClientInvoices_Paid.OptionGroup = "AllOpenPaid"
            Me.ButtonItemClientInvoices_Paid.RibbonWordWrap = False
            Me.ButtonItemClientInvoices_Paid.SecurityEnabled = True
            Me.ButtonItemClientInvoices_Paid.Stretch = True
            Me.ButtonItemClientInvoices_Paid.SubItemsExpandWidth = 14
            Me.ButtonItemClientInvoices_Paid.Text = "Paid"
            '
            'ButtonItemClientInvoices_All
            '
            Me.ButtonItemClientInvoices_All.AutoCheckOnClick = True
            Me.ButtonItemClientInvoices_All.BeginGroup = True
            Me.ButtonItemClientInvoices_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClientInvoices_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClientInvoices_All.Name = "ButtonItemClientInvoices_All"
            Me.ButtonItemClientInvoices_All.OptionGroup = "AllOpenPaid"
            Me.ButtonItemClientInvoices_All.RibbonWordWrap = False
            Me.ButtonItemClientInvoices_All.SecurityEnabled = True
            Me.ButtonItemClientInvoices_All.Stretch = True
            Me.ButtonItemClientInvoices_All.SubItemsExpandWidth = 14
            Me.ButtonItemClientInvoices_All.Text = "All"
            '
            'ButtonItemClientInvoices_Voided
            '
            Me.ButtonItemClientInvoices_Voided.AutoCheckOnClick = True
            Me.ButtonItemClientInvoices_Voided.BeginGroup = True
            Me.ButtonItemClientInvoices_Voided.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemClientInvoices_Voided.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClientInvoices_Voided.Name = "ButtonItemClientInvoices_Voided"
            Me.ButtonItemClientInvoices_Voided.OptionGroup = "AllOpenPaid"
            Me.ButtonItemClientInvoices_Voided.RibbonWordWrap = False
            Me.ButtonItemClientInvoices_Voided.SecurityEnabled = True
            Me.ButtonItemClientInvoices_Voided.Stretch = True
            Me.ButtonItemClientInvoices_Voided.SubItemsExpandWidth = 14
            Me.ButtonItemClientInvoices_Voided.Text = "Voided"
            '
            'RibbonBarOptions_ManualInvoices
            '
            Me.RibbonBarOptions_ManualInvoices.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ManualInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ManualInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ManualInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ManualInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ManualInvoices.DragDropSupport = True
            Me.RibbonBarOptions_ManualInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Import, Me.ButtonItemActions_Add, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_ManualInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ManualInvoices.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_ManualInvoices.Name = "RibbonBarOptions_ManualInvoices"
            Me.RibbonBarOptions_ManualInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_ManualInvoices.Size = New System.Drawing.Size(134, 98)
            Me.RibbonBarOptions_ManualInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ManualInvoices.TabIndex = 0
            Me.RibbonBarOptions_ManualInvoices.Text = "Manual Invoices"
            '
            '
            '
            Me.RibbonBarOptions_ManualInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ManualInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ManualInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.RibbonWordWrap = False
            Me.ButtonItemActions_Import.SecurityEnabled = True
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'RibbonBarMergeContainerForm_Printing
            '
            Me.RibbonBarMergeContainerForm_Printing.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Printing.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Printing)
            Me.RibbonBarMergeContainerForm_Printing.Location = New System.Drawing.Point(274, 296)
            Me.RibbonBarMergeContainerForm_Printing.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Printing.MergeRibbonTabItemIndex = 3
            Me.RibbonBarMergeContainerForm_Printing.Name = "RibbonBarMergeContainerForm_Printing"
            Me.RibbonBarMergeContainerForm_Printing.RibbonTabText = "Printing"
            Me.RibbonBarMergeContainerForm_Printing.Size = New System.Drawing.Size(941, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Printing.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Printing.TabIndex = 8
            Me.RibbonBarMergeContainerForm_Printing.Visible = False
            '
            'RibbonBarPrinting_Printing
            '
            Me.RibbonBarPrinting_Printing.AutoOverflowEnabled = False
            Me.RibbonBarPrinting_Printing.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Printing.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Printing.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Printing.DragDropSupport = True
            Me.RibbonBarPrinting_Printing.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_Printing.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrinting_Export, Me.ButtonItemPrinting_PrintReport})
            Me.RibbonBarPrinting_Printing.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Printing.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarPrinting_Printing.Name = "RibbonBarPrinting_Printing"
            Me.RibbonBarPrinting_Printing.SecurityEnabled = True
            Me.RibbonBarPrinting_Printing.Size = New System.Drawing.Size(157, 98)
            Me.RibbonBarPrinting_Printing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Printing.TabIndex = 2
            Me.RibbonBarPrinting_Printing.Text = "Printing"
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Printing.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Printing.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPrinting_Export
            '
            Me.ButtonItemPrinting_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_Export.Name = "ButtonItemPrinting_Export"
            Me.ButtonItemPrinting_Export.RibbonWordWrap = False
            Me.ButtonItemPrinting_Export.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_Export.Text = "Export"
            '
            'ButtonItemPrinting_PrintReport
            '
            Me.ButtonItemPrinting_PrintReport.BeginGroup = True
            Me.ButtonItemPrinting_PrintReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrinting_PrintReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrinting_PrintReport.Name = "ButtonItemPrinting_PrintReport"
            Me.ButtonItemPrinting_PrintReport.RibbonWordWrap = False
            Me.ButtonItemPrinting_PrintReport.SubItemsExpandWidth = 14
            Me.ButtonItemPrinting_PrintReport.Text = "Print Report"
            '
            'ClientInvoiceForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1281, 691)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Printing)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientInvoiceForm"
            Me.Text = "Client Invoices"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlRightSection_InvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_InvoiceDetails.ResumeLayout(False)
            Me.TabControlPanelInvoiceslTab_Invoices.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            CType(Me.SearchableComboBoxRightSection_SalesClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_SalesClass, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerRightSection_LastPaymentDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRightSection_AvgDaystoPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRightSection_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRightSection_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRightSection_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Product, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRightSection_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Division, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Printing.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Clients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxRightSection_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxRightSection_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxRightSection_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Product As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxRightSection_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Division As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents NumericInputRightSection_AvgDaystoPay As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ClientContactManagerControlRightSection_ClientContacts As AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl
        Friend WithEvents SearchableComboBoxRightSection_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents DocumentManagerControlInvoices_Documents As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents DataGridViewInvoices_InvoiceData As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents LabelRightSection_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_LastPaymentDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_AvgDaysToPay As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents DateTimePickerRightSection_LastPaymentDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Private WithEvents LabelRightSection_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelRightSection_DateRange As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ButtonRightSection_Dates As AdvantageFramework.WinForm.Presentation.Controls.Button
        Private WithEvents TabControlRightSection_InvoiceDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Private WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemInvoiceDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Private WithEvents TabControlPanelInvoiceslTab_Invoices As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents TabItemInvoiceDetails_InvoicesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarMergeContainerForm_Printing As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarPrinting_Printing As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrinting_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrinting_PrintReport As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_ManualInvoices As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_DaysToPay As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDaysToPay_ByCheckDate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDaysToPay_ByDepositDate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_ZeroInvoices As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemZeroInvoices_Exclude As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemZeroInvoices_Include As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_ClientInvoices As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemClientInvoices_Open As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemClientInvoices_Paid As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemClientInvoices_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemClientInvoices_Voided As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Package As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPackage_Documents As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_QuickBooks As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemQuickBooks_Send As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

