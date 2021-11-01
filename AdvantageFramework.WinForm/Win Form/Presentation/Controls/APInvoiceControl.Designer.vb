Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class APInvoiceControl
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
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSpotDetailsTab_SpotDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSpotDetails_SpotDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPInvoicesPosted_SpotDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTransactionsTab_Transactions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTransactions_GLTransactions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPInvoicesPosted_TransactionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAPInvoicesTab_APInvoices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAPInvoices_APInvoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPInvoicesPosted_APInvoicesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAPDocuments_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_APInvoiceDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemAPInvoicesPosted_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewChecksWritten_ChecksWritten = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPInvoicesPosted_ChecksWrittenTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlAPInvoicesPosted_ApInvoicesPosted, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.SuspendLayout()
            Me.TabControlPanelSpotDetailsTab_SpotDetails.SuspendLayout()
            Me.TabControlPanelTransactionsTab_Transactions.SuspendLayout()
            Me.TabControlPanelAPInvoicesTab_APInvoices.SuspendLayout()
            Me.TabControlPanelAPDocuments_Documents.SuspendLayout()
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlAPInvoicesPosted_ApInvoicesPosted
            '
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.CanReorderTabs = False
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Controls.Add(Me.TabControlPanelSpotDetailsTab_SpotDetails)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Controls.Add(Me.TabControlPanelAPInvoicesTab_APInvoices)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Controls.Add(Me.TabControlPanelTransactionsTab_Transactions)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Controls.Add(Me.TabControlPanelAPDocuments_Documents)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Controls.Add(Me.TabControlPanelChecksWrittenTab_ChecksWritten)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.ForeColor = System.Drawing.Color.Black
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Location = New System.Drawing.Point(0, 0)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Name = "TabControlAPInvoicesPosted_ApInvoicesPosted"
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.SelectedTabIndex = 0
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Size = New System.Drawing.Size(471, 286)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.TabIndex = 19
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.Add(Me.TabItemAPInvoicesPosted_APInvoicesTab)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.Add(Me.TabItemAPInvoicesPosted_SpotDetailsTab)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.Add(Me.TabItemAPInvoicesPosted_TransactionsTab)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.Add(Me.TabItemAPInvoicesPosted_ChecksWrittenTab)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.Tabs.Add(Me.TabItemAPInvoicesPosted_DocumentsTab)
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.TabStop = False
            '
            'TabControlPanelSpotDetailsTab_SpotDetails
            '
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Controls.Add(Me.DataGridViewSpotDetails_SpotDetails)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Name = "TabControlPanelSpotDetailsTab_SpotDetails"
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Size = New System.Drawing.Size(471, 259)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.Style.GradientAngle = 90
            Me.TabControlPanelSpotDetailsTab_SpotDetails.TabIndex = 21
            Me.TabControlPanelSpotDetailsTab_SpotDetails.TabItem = Me.TabItemAPInvoicesPosted_SpotDetailsTab
            '
            'DataGridViewSpotDetails_SpotDetails
            '
            Me.DataGridViewSpotDetails_SpotDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSpotDetails_SpotDetails.AllowDragAndDrop = False
            Me.DataGridViewSpotDetails_SpotDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSpotDetails_SpotDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotDetails_SpotDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSpotDetails_SpotDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotDetails_SpotDetails.AutoFilterLookupColumns = False
            Me.DataGridViewSpotDetails_SpotDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewSpotDetails_SpotDetails.AutoUpdateViewCaption = True
            Me.DataGridViewSpotDetails_SpotDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSpotDetails_SpotDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSpotDetails_SpotDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotDetails_SpotDetails.ItemDescription = "Item(s)"
            Me.DataGridViewSpotDetails_SpotDetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewSpotDetails_SpotDetails.MultiSelect = True
            Me.DataGridViewSpotDetails_SpotDetails.Name = "DataGridViewSpotDetails_SpotDetails"
            Me.DataGridViewSpotDetails_SpotDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSpotDetails_SpotDetails.RunStandardValidation = True
            Me.DataGridViewSpotDetails_SpotDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSpotDetails_SpotDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotDetails_SpotDetails.Size = New System.Drawing.Size(462, 251)
            Me.DataGridViewSpotDetails_SpotDetails.TabIndex = 2
            Me.DataGridViewSpotDetails_SpotDetails.UseEmbeddedNavigator = False
            Me.DataGridViewSpotDetails_SpotDetails.ViewCaptionHeight = -1
            '
            'TabItemAPInvoicesPosted_SpotDetailsTab
            '
            Me.TabItemAPInvoicesPosted_SpotDetailsTab.AttachedControl = Me.TabControlPanelSpotDetailsTab_SpotDetails
            Me.TabItemAPInvoicesPosted_SpotDetailsTab.Name = "TabItemAPInvoicesPosted_SpotDetailsTab"
            Me.TabItemAPInvoicesPosted_SpotDetailsTab.Text = "Spot Details"
            '
            'TabControlPanelTransactionsTab_Transactions
            '
            Me.TabControlPanelTransactionsTab_Transactions.Controls.Add(Me.DataGridViewTransactions_GLTransactions)
            Me.TabControlPanelTransactionsTab_Transactions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTransactionsTab_Transactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTransactionsTab_Transactions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTransactionsTab_Transactions.Name = "TabControlPanelTransactionsTab_Transactions"
            Me.TabControlPanelTransactionsTab_Transactions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTransactionsTab_Transactions.Size = New System.Drawing.Size(471, 259)
            Me.TabControlPanelTransactionsTab_Transactions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTransactionsTab_Transactions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTransactionsTab_Transactions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTransactionsTab_Transactions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTransactionsTab_Transactions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTransactionsTab_Transactions.Style.GradientAngle = 90
            Me.TabControlPanelTransactionsTab_Transactions.TabIndex = 12
            Me.TabControlPanelTransactionsTab_Transactions.TabItem = Me.TabItemAPInvoicesPosted_TransactionsTab
            '
            'DataGridViewTransactions_GLTransactions
            '
            Me.DataGridViewTransactions_GLTransactions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTransactions_GLTransactions.AllowDragAndDrop = False
            Me.DataGridViewTransactions_GLTransactions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTransactions_GLTransactions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTransactions_GLTransactions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTransactions_GLTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTransactions_GLTransactions.AutoFilterLookupColumns = False
            Me.DataGridViewTransactions_GLTransactions.AutoloadRepositoryDatasource = True
            Me.DataGridViewTransactions_GLTransactions.AutoUpdateViewCaption = True
            Me.DataGridViewTransactions_GLTransactions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewTransactions_GLTransactions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTransactions_GLTransactions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTransactions_GLTransactions.ItemDescription = "GL Transaction(s)"
            Me.DataGridViewTransactions_GLTransactions.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewTransactions_GLTransactions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewTransactions_GLTransactions.MultiSelect = True
            Me.DataGridViewTransactions_GLTransactions.Name = "DataGridViewTransactions_GLTransactions"
            Me.DataGridViewTransactions_GLTransactions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTransactions_GLTransactions.RunStandardValidation = True
            Me.DataGridViewTransactions_GLTransactions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTransactions_GLTransactions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTransactions_GLTransactions.Size = New System.Drawing.Size(462, 251)
            Me.DataGridViewTransactions_GLTransactions.TabIndex = 6
            Me.DataGridViewTransactions_GLTransactions.UseEmbeddedNavigator = False
            Me.DataGridViewTransactions_GLTransactions.ViewCaptionHeight = -1
            '
            'TabItemAPInvoicesPosted_TransactionsTab
            '
            Me.TabItemAPInvoicesPosted_TransactionsTab.AttachedControl = Me.TabControlPanelTransactionsTab_Transactions
            Me.TabItemAPInvoicesPosted_TransactionsTab.Name = "TabItemAPInvoicesPosted_TransactionsTab"
            Me.TabItemAPInvoicesPosted_TransactionsTab.Text = "Transactions"
            '
            'TabControlPanelAPInvoicesTab_APInvoices
            '
            Me.TabControlPanelAPInvoicesTab_APInvoices.Controls.Add(Me.DataGridViewAPInvoices_APInvoices)
            Me.TabControlPanelAPInvoicesTab_APInvoices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAPInvoicesTab_APInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAPInvoicesTab_APInvoices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAPInvoicesTab_APInvoices.Name = "TabControlPanelAPInvoicesTab_APInvoices"
            Me.TabControlPanelAPInvoicesTab_APInvoices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAPInvoicesTab_APInvoices.Size = New System.Drawing.Size(471, 259)
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAPInvoicesTab_APInvoices.Style.GradientAngle = 90
            Me.TabControlPanelAPInvoicesTab_APInvoices.TabIndex = 3
            Me.TabControlPanelAPInvoicesTab_APInvoices.TabItem = Me.TabItemAPInvoicesPosted_APInvoicesTab
            '
            'DataGridViewAPInvoices_APInvoices
            '
            Me.DataGridViewAPInvoices_APInvoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAPInvoices_APInvoices.AllowDragAndDrop = False
            Me.DataGridViewAPInvoices_APInvoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAPInvoices_APInvoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAPInvoices_APInvoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAPInvoices_APInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAPInvoices_APInvoices.AutoFilterLookupColumns = False
            Me.DataGridViewAPInvoices_APInvoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewAPInvoices_APInvoices.AutoUpdateViewCaption = True
            Me.DataGridViewAPInvoices_APInvoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewAPInvoices_APInvoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAPInvoices_APInvoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAPInvoices_APInvoices.ItemDescription = "AP Invoice(s)"
            Me.DataGridViewAPInvoices_APInvoices.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewAPInvoices_APInvoices.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewAPInvoices_APInvoices.MultiSelect = False
            Me.DataGridViewAPInvoices_APInvoices.Name = "DataGridViewAPInvoices_APInvoices"
            Me.DataGridViewAPInvoices_APInvoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAPInvoices_APInvoices.RunStandardValidation = True
            Me.DataGridViewAPInvoices_APInvoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAPInvoices_APInvoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAPInvoices_APInvoices.Size = New System.Drawing.Size(462, 251)
            Me.DataGridViewAPInvoices_APInvoices.TabIndex = 5
            Me.DataGridViewAPInvoices_APInvoices.UseEmbeddedNavigator = False
            Me.DataGridViewAPInvoices_APInvoices.ViewCaptionHeight = -1
            '
            'TabItemAPInvoicesPosted_APInvoicesTab
            '
            Me.TabItemAPInvoicesPosted_APInvoicesTab.AttachedControl = Me.TabControlPanelAPInvoicesTab_APInvoices
            Me.TabItemAPInvoicesPosted_APInvoicesTab.Name = "TabItemAPInvoicesPosted_APInvoicesTab"
            Me.TabItemAPInvoicesPosted_APInvoicesTab.Text = "AP Invoices"
            '
            'TabControlPanelAPDocuments_Documents
            '
            Me.TabControlPanelAPDocuments_Documents.Controls.Add(Me.DocumentManagerControlDocuments_APInvoiceDocuments)
            Me.TabControlPanelAPDocuments_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAPDocuments_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAPDocuments_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAPDocuments_Documents.Name = "TabControlPanelAPDocuments_Documents"
            Me.TabControlPanelAPDocuments_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAPDocuments_Documents.Size = New System.Drawing.Size(471, 259)
            Me.TabControlPanelAPDocuments_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAPDocuments_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAPDocuments_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAPDocuments_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAPDocuments_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAPDocuments_Documents.Style.GradientAngle = 90
            Me.TabControlPanelAPDocuments_Documents.TabIndex = 11
            Me.TabControlPanelAPDocuments_Documents.TabItem = Me.TabItemAPInvoicesPosted_DocumentsTab
            '
            'DocumentManagerControlDocuments_APInvoiceDocuments
            '
            Me.DocumentManagerControlDocuments_APInvoiceDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_APInvoiceDocuments.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_APInvoiceDocuments.Name = "DocumentManagerControlDocuments_APInvoiceDocuments"
            Me.DocumentManagerControlDocuments_APInvoiceDocuments.Size = New System.Drawing.Size(462, 251)
            Me.DocumentManagerControlDocuments_APInvoiceDocuments.TabIndex = 0
            '
            'TabItemAPInvoicesPosted_DocumentsTab
            '
            Me.TabItemAPInvoicesPosted_DocumentsTab.AttachedControl = Me.TabControlPanelAPDocuments_Documents
            Me.TabItemAPInvoicesPosted_DocumentsTab.Name = "TabItemAPInvoicesPosted_DocumentsTab"
            Me.TabItemAPInvoicesPosted_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelChecksWrittenTab_ChecksWritten
            '
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Controls.Add(Me.DataGridViewChecksWritten_ChecksWritten)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Name = "TabControlPanelChecksWrittenTab_ChecksWritten"
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Size = New System.Drawing.Size(471, 259)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.GradientAngle = 90
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.TabIndex = 13
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.TabItem = Me.TabItemAPInvoicesPosted_ChecksWrittenTab
            '
            'DataGridViewChecksWritten_ChecksWritten
            '
            Me.DataGridViewChecksWritten_ChecksWritten.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewChecksWritten_ChecksWritten.AllowDragAndDrop = False
            Me.DataGridViewChecksWritten_ChecksWritten.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewChecksWritten_ChecksWritten.AllowSelectGroupHeaderRow = True
            Me.DataGridViewChecksWritten_ChecksWritten.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewChecksWritten_ChecksWritten.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewChecksWritten_ChecksWritten.AutoFilterLookupColumns = False
            Me.DataGridViewChecksWritten_ChecksWritten.AutoloadRepositoryDatasource = True
            Me.DataGridViewChecksWritten_ChecksWritten.AutoUpdateViewCaption = True
            Me.DataGridViewChecksWritten_ChecksWritten.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewChecksWritten_ChecksWritten.DataSource = Nothing
            Me.DataGridViewChecksWritten_ChecksWritten.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewChecksWritten_ChecksWritten.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewChecksWritten_ChecksWritten.ItemDescription = "Check(s) Written"
            Me.DataGridViewChecksWritten_ChecksWritten.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewChecksWritten_ChecksWritten.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewChecksWritten_ChecksWritten.MultiSelect = True
            Me.DataGridViewChecksWritten_ChecksWritten.Name = "DataGridViewChecksWritten_ChecksWritten"
            Me.DataGridViewChecksWritten_ChecksWritten.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewChecksWritten_ChecksWritten.RunStandardValidation = True
            Me.DataGridViewChecksWritten_ChecksWritten.ShowColumnMenuOnRightClick = False
            Me.DataGridViewChecksWritten_ChecksWritten.ShowSelectDeselectAllButtons = False
            Me.DataGridViewChecksWritten_ChecksWritten.Size = New System.Drawing.Size(462, 251)
            Me.DataGridViewChecksWritten_ChecksWritten.TabIndex = 7
            Me.DataGridViewChecksWritten_ChecksWritten.UseEmbeddedNavigator = False
            Me.DataGridViewChecksWritten_ChecksWritten.ViewCaptionHeight = -1
            '
            'TabItemAPInvoicesPosted_ChecksWrittenTab
            '
            Me.TabItemAPInvoicesPosted_ChecksWrittenTab.AttachedControl = Me.TabControlPanelChecksWrittenTab_ChecksWritten
            Me.TabItemAPInvoicesPosted_ChecksWrittenTab.Name = "TabItemAPInvoicesPosted_ChecksWrittenTab"
            Me.TabItemAPInvoicesPosted_ChecksWrittenTab.Text = "Check(s) Written"
            '
            'APInvoiceControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlAPInvoicesPosted_ApInvoicesPosted)
            Me.Name = "APInvoiceControl"
            Me.Size = New System.Drawing.Size(471, 286)
            CType(Me.TabControlAPInvoicesPosted_ApInvoicesPosted, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlAPInvoicesPosted_ApInvoicesPosted.ResumeLayout(False)
            Me.TabControlPanelSpotDetailsTab_SpotDetails.ResumeLayout(False)
            Me.TabControlPanelTransactionsTab_Transactions.ResumeLayout(False)
            Me.TabControlPanelAPInvoicesTab_APInvoices.ResumeLayout(False)
            Me.TabControlPanelAPDocuments_Documents.ResumeLayout(False)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TabControlAPInvoicesPosted_ApInvoicesPosted As TabControl
        Friend WithEvents TabControlPanelAPInvoicesTab_APInvoices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewAPInvoices_APInvoices As DataGridView
        Friend WithEvents TabItemAPInvoicesPosted_APInvoicesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelChecksWrittenTab_ChecksWritten As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewChecksWritten_ChecksWritten As DataGridView
        Friend WithEvents TabItemAPInvoicesPosted_ChecksWrittenTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAPDocuments_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_APInvoiceDocuments As DocumentManagerControl
        Friend WithEvents TabItemAPInvoicesPosted_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTransactionsTab_Transactions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewTransactions_GLTransactions As DataGridView
        Friend WithEvents TabItemAPInvoicesPosted_TransactionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotDetailsTab_SpotDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPInvoicesPosted_SpotDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewSpotDetails_SpotDetails As DataGridView
    End Class

End Namespace