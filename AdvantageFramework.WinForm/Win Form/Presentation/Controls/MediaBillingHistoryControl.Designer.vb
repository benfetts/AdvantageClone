Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBillingHistoryControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.LabelControl_LineNumberJobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_LineNumberJobComponentValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_OrderJobValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_OrderJob = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlControl_BillingHistory = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInvoicesTab_Invoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInvoice_Invoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewControl_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSummary_InvoicesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientPaymentsTab_ClientPayments = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewClientPayments_ClientPayments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSummary_ClientPaymentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJournalEntriesTab_JournalEntries = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewJournalEntries_JournalEntries = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSummary_JournalEntries = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_InvoiceDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemBillingSummary_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.TabControlControl_BillingHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_BillingHistory.SuspendLayout()
            Me.TabControlPanelInvoicesTab_Invoices.SuspendLayout()
            Me.TabControlPanelClientPaymentsTab_ClientPayments.SuspendLayout()
            Me.TabControlPanelJournalEntriesTab_JournalEntries.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.SuspendLayout()
            '
            'LabelControl_LineNumberJobComponent
            '
            Me.LabelControl_LineNumberJobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LineNumberJobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LineNumberJobComponent.Location = New System.Drawing.Point(2, 27)
            Me.LabelControl_LineNumberJobComponent.Name = "LabelControl_LineNumberJobComponent"
            Me.LabelControl_LineNumberJobComponent.Size = New System.Drawing.Size(90, 20)
            Me.LabelControl_LineNumberJobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LineNumberJobComponent.TabIndex = 14
            Me.LabelControl_LineNumberJobComponent.Text = "Line Number(s):"
            '
            'LabelControl_LineNumberJobComponentValue
            '
            Me.LabelControl_LineNumberJobComponentValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelControl_LineNumberJobComponentValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LineNumberJobComponentValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LineNumberJobComponentValue.Location = New System.Drawing.Point(98, 27)
            Me.LabelControl_LineNumberJobComponentValue.Name = "LabelControl_LineNumberJobComponentValue"
            Me.LabelControl_LineNumberJobComponentValue.Size = New System.Drawing.Size(752, 20)
            Me.LabelControl_LineNumberJobComponentValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LineNumberJobComponentValue.TabIndex = 15
            '
            'LabelControl_OrderJobValue
            '
            Me.LabelControl_OrderJobValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelControl_OrderJobValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderJobValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderJobValue.Location = New System.Drawing.Point(98, 1)
            Me.LabelControl_OrderJobValue.Name = "LabelControl_OrderJobValue"
            Me.LabelControl_OrderJobValue.Size = New System.Drawing.Size(752, 20)
            Me.LabelControl_OrderJobValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderJobValue.TabIndex = 13
            '
            'LabelControl_OrderJob
            '
            Me.LabelControl_OrderJob.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_OrderJob.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_OrderJob.Location = New System.Drawing.Point(2, 1)
            Me.LabelControl_OrderJob.Name = "LabelControl_OrderJob"
            Me.LabelControl_OrderJob.Size = New System.Drawing.Size(90, 20)
            Me.LabelControl_OrderJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_OrderJob.TabIndex = 12
            Me.LabelControl_OrderJob.Text = "Order:"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlControl_BillingHistory)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderJob)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_LineNumberJobComponentValue)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_LineNumberJobComponent)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelControl_OrderJobValue)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(852, 532)
            Me.PanelForm_RightSection.TabIndex = 16
            '
            'TabControlControl_BillingHistory
            '
            Me.TabControlControl_BillingHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_BillingHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_BillingHistory.CanReorderTabs = False
            Me.TabControlControl_BillingHistory.Controls.Add(Me.TabControlPanelInvoicesTab_Invoices)
            Me.TabControlControl_BillingHistory.Controls.Add(Me.TabControlPanelClientPaymentsTab_ClientPayments)
            Me.TabControlControl_BillingHistory.Controls.Add(Me.TabControlPanelJournalEntriesTab_JournalEntries)
            Me.TabControlControl_BillingHistory.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_BillingHistory.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_BillingHistory.Location = New System.Drawing.Point(1, 53)
            Me.TabControlControl_BillingHistory.Name = "TabControlControl_BillingHistory"
            Me.TabControlControl_BillingHistory.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_BillingHistory.SelectedTabIndex = 0
            Me.TabControlControl_BillingHistory.Size = New System.Drawing.Size(850, 474)
            Me.TabControlControl_BillingHistory.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_BillingHistory.TabIndex = 17
            Me.TabControlControl_BillingHistory.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_BillingHistory.Tabs.Add(Me.TabItemBillingSummary_InvoicesTab)
            Me.TabControlControl_BillingHistory.Tabs.Add(Me.TabItemBillingSummary_JournalEntries)
            Me.TabControlControl_BillingHistory.Tabs.Add(Me.TabItemBillingSummary_ClientPaymentsTab)
            Me.TabControlControl_BillingHistory.Tabs.Add(Me.TabItemBillingSummary_DocumentsTab)
            Me.TabControlControl_BillingHistory.TabStop = False
            '
            'TabControlPanelInvoicesTab_Invoices
            '
            Me.TabControlPanelInvoicesTab_Invoices.Controls.Add(Me.DataGridViewInvoice_Invoices)
            Me.TabControlPanelInvoicesTab_Invoices.Controls.Add(Me.DataGridViewControl_Export)
            Me.TabControlPanelInvoicesTab_Invoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoicesTab_Invoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoicesTab_Invoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoicesTab_Invoices.Name = "TabControlPanelInvoicesTab_Invoices"
            Me.TabControlPanelInvoicesTab_Invoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoicesTab_Invoices.Size = New System.Drawing.Size(850, 447)
            Me.TabControlPanelInvoicesTab_Invoices.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoicesTab_Invoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoicesTab_Invoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoicesTab_Invoices.Style.GradientAngle = 90
            Me.TabControlPanelInvoicesTab_Invoices.TabIndex = 3
            Me.TabControlPanelInvoicesTab_Invoices.TabItem = Me.TabItemBillingSummary_InvoicesTab
            '
            'DataGridViewInvoice_Invoices
            '
            Me.DataGridViewInvoice_Invoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInvoice_Invoices.AllowDragAndDrop = False
            Me.DataGridViewInvoice_Invoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInvoice_Invoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoice_Invoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoice_Invoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoice_Invoices.AutoFilterLookupColumns = False
            Me.DataGridViewInvoice_Invoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoice_Invoices.AutoUpdateViewCaption = True
            Me.DataGridViewInvoice_Invoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewInvoice_Invoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoice_Invoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoice_Invoices.ItemDescription = "Invoice(s)"
            Me.DataGridViewInvoice_Invoices.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewInvoice_Invoices.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInvoice_Invoices.MultiSelect = True
            Me.DataGridViewInvoice_Invoices.Name = "DataGridViewInvoice_Invoices"
            Me.DataGridViewInvoice_Invoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoice_Invoices.RunStandardValidation = True
            Me.DataGridViewInvoice_Invoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInvoice_Invoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoice_Invoices.Size = New System.Drawing.Size(841, 439)
            Me.DataGridViewInvoice_Invoices.TabIndex = 5
            Me.DataGridViewInvoice_Invoices.UseEmbeddedNavigator = False
            Me.DataGridViewInvoice_Invoices.ViewCaptionHeight = -1
            '
            'DataGridViewControl_Export
            '
            Me.DataGridViewControl_Export.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_Export.AllowDragAndDrop = False
            Me.DataGridViewControl_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_Export.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Export.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Export.ItemDescription = ""
            Me.DataGridViewControl_Export.Location = New System.Drawing.Point(311, 72)
            Me.DataGridViewControl_Export.MultiSelect = True
            Me.DataGridViewControl_Export.Name = "DataGridViewControl_Export"
            Me.DataGridViewControl_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_Export.RunStandardValidation = True
            Me.DataGridViewControl_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Export.Size = New System.Drawing.Size(216, 249)
            Me.DataGridViewControl_Export.TabIndex = 12
            Me.DataGridViewControl_Export.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Export.ViewCaptionHeight = -1
            Me.DataGridViewControl_Export.Visible = False
            '
            'TabItemBillingSummary_InvoicesTab
            '
            Me.TabItemBillingSummary_InvoicesTab.AttachedControl = Me.TabControlPanelInvoicesTab_Invoices
            Me.TabItemBillingSummary_InvoicesTab.Name = "TabItemBillingSummary_InvoicesTab"
            Me.TabItemBillingSummary_InvoicesTab.Text = "Invoices"
            '
            'TabControlPanelClientPaymentsTab_ClientPayments
            '
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Controls.Add(Me.DataGridViewClientPayments_ClientPayments)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Name = "TabControlPanelClientPaymentsTab_ClientPayments"
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Size = New System.Drawing.Size(850, 447)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.Style.GradientAngle = 90
            Me.TabControlPanelClientPaymentsTab_ClientPayments.TabIndex = 13
            Me.TabControlPanelClientPaymentsTab_ClientPayments.TabItem = Me.TabItemBillingSummary_ClientPaymentsTab
            '
            'DataGridViewClientPayments_ClientPayments
            '
            Me.DataGridViewClientPayments_ClientPayments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewClientPayments_ClientPayments.AllowDragAndDrop = False
            Me.DataGridViewClientPayments_ClientPayments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewClientPayments_ClientPayments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewClientPayments_ClientPayments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewClientPayments_ClientPayments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewClientPayments_ClientPayments.AutoFilterLookupColumns = False
            Me.DataGridViewClientPayments_ClientPayments.AutoloadRepositoryDatasource = True
            Me.DataGridViewClientPayments_ClientPayments.AutoUpdateViewCaption = True
            Me.DataGridViewClientPayments_ClientPayments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewClientPayments_ClientPayments.DataSource = Nothing
            Me.DataGridViewClientPayments_ClientPayments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewClientPayments_ClientPayments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewClientPayments_ClientPayments.ItemDescription = "Client Payment(s)"
            Me.DataGridViewClientPayments_ClientPayments.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewClientPayments_ClientPayments.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewClientPayments_ClientPayments.MultiSelect = True
            Me.DataGridViewClientPayments_ClientPayments.Name = "DataGridViewClientPayments_ClientPayments"
            Me.DataGridViewClientPayments_ClientPayments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewClientPayments_ClientPayments.RunStandardValidation = True
            Me.DataGridViewClientPayments_ClientPayments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewClientPayments_ClientPayments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewClientPayments_ClientPayments.Size = New System.Drawing.Size(841, 439)
            Me.DataGridViewClientPayments_ClientPayments.TabIndex = 7
            Me.DataGridViewClientPayments_ClientPayments.UseEmbeddedNavigator = False
            Me.DataGridViewClientPayments_ClientPayments.ViewCaptionHeight = -1
            '
            'TabItemBillingSummary_ClientPaymentsTab
            '
            Me.TabItemBillingSummary_ClientPaymentsTab.AttachedControl = Me.TabControlPanelClientPaymentsTab_ClientPayments
            Me.TabItemBillingSummary_ClientPaymentsTab.Name = "TabItemBillingSummary_ClientPaymentsTab"
            Me.TabItemBillingSummary_ClientPaymentsTab.Text = "Client Payments"
            '
            'TabControlPanelJournalEntriesTab_JournalEntries
            '
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Controls.Add(Me.DataGridViewJournalEntries_JournalEntries)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Name = "TabControlPanelJournalEntriesTab_JournalEntries"
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Size = New System.Drawing.Size(850, 447)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.Style.GradientAngle = 90
            Me.TabControlPanelJournalEntriesTab_JournalEntries.TabIndex = 12
            Me.TabControlPanelJournalEntriesTab_JournalEntries.TabItem = Me.TabItemBillingSummary_JournalEntries
            '
            'DataGridViewJournalEntries_JournalEntries
            '
            Me.DataGridViewJournalEntries_JournalEntries.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJournalEntries_JournalEntries.AllowDragAndDrop = False
            Me.DataGridViewJournalEntries_JournalEntries.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJournalEntries_JournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJournalEntries_JournalEntries.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJournalEntries_JournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJournalEntries_JournalEntries.AutoFilterLookupColumns = False
            Me.DataGridViewJournalEntries_JournalEntries.AutoloadRepositoryDatasource = True
            Me.DataGridViewJournalEntries_JournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewJournalEntries_JournalEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJournalEntries_JournalEntries.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJournalEntries_JournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJournalEntries_JournalEntries.ItemDescription = "Journal Entry(ies)"
            Me.DataGridViewJournalEntries_JournalEntries.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewJournalEntries_JournalEntries.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewJournalEntries_JournalEntries.MultiSelect = True
            Me.DataGridViewJournalEntries_JournalEntries.Name = "DataGridViewJournalEntries_JournalEntries"
            Me.DataGridViewJournalEntries_JournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJournalEntries_JournalEntries.RunStandardValidation = True
            Me.DataGridViewJournalEntries_JournalEntries.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJournalEntries_JournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJournalEntries_JournalEntries.Size = New System.Drawing.Size(841, 439)
            Me.DataGridViewJournalEntries_JournalEntries.TabIndex = 6
            Me.DataGridViewJournalEntries_JournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewJournalEntries_JournalEntries.ViewCaptionHeight = -1
            '
            'TabItemBillingSummary_JournalEntries
            '
            Me.TabItemBillingSummary_JournalEntries.AttachedControl = Me.TabControlPanelJournalEntriesTab_JournalEntries
            Me.TabItemBillingSummary_JournalEntries.Name = "TabItemBillingSummary_JournalEntries"
            Me.TabItemBillingSummary_JournalEntries.Text = "Journal Entries"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_InvoiceDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(850, 447)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 11
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemBillingSummary_DocumentsTab
            '
            'DocumentManagerControlDocuments_InvoiceDocuments
            '
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Name = "DocumentManagerControlDocuments_InvoiceDocuments"
            Me.DocumentManagerControlDocuments_InvoiceDocuments.Size = New System.Drawing.Size(841, 439)
            Me.DocumentManagerControlDocuments_InvoiceDocuments.TabIndex = 0
            '
            'TabItemBillingSummary_DocumentsTab
            '
            Me.TabItemBillingSummary_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemBillingSummary_DocumentsTab.Name = "TabItemBillingSummary_DocumentsTab"
            Me.TabItemBillingSummary_DocumentsTab.Text = "Documents"
            '
            'MediaBillingHistoryControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Name = "MediaBillingHistoryControl"
            Me.Size = New System.Drawing.Size(852, 532)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.TabControlControl_BillingHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_BillingHistory.ResumeLayout(False)
            Me.TabControlPanelInvoicesTab_Invoices.ResumeLayout(False)
            Me.TabControlPanelClientPaymentsTab_ClientPayments.ResumeLayout(False)
            Me.TabControlPanelJournalEntriesTab_JournalEntries.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelControl_LineNumberJobComponent As Label
        Friend WithEvents LabelControl_LineNumberJobComponentValue As Label
        Friend WithEvents LabelControl_OrderJobValue As Label
        Friend WithEvents LabelControl_OrderJob As Label
        Friend WithEvents PanelForm_RightSection As Panel
        Friend WithEvents TabControlControl_BillingHistory As TabControl
        Friend WithEvents TabControlPanelInvoicesTab_Invoices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewInvoice_Invoices As DataGridView
        Friend WithEvents DataGridViewControl_Export As DataGridView
        Friend WithEvents TabItemBillingSummary_InvoicesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelJournalEntriesTab_JournalEntries As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewJournalEntries_JournalEntries As DataGridView
        Friend WithEvents TabItemBillingSummary_JournalEntries As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_InvoiceDocuments As DocumentManagerControl
        Friend WithEvents TabItemBillingSummary_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelClientPaymentsTab_ClientPayments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewClientPayments_ClientPayments As DataGridView
        Friend WithEvents TabItemBillingSummary_ClientPaymentsTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace
