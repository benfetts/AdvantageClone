Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerVCCDashboardDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerVCCDashboardDialog))
            Me.DataGridViewForm_VCCOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_SummaryResults = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSummaryResults_Far = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_SettledOutOfBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSummaryResults_Splitter1 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerSummaryResults_Center = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_SettledInBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSummaryResults_Splitter2 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerSummaryResults_Near = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSummaryResults_TransactionsDeclined = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_TransactionsInBalance = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerSummaryResults_Splitter3 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_SendNotifications = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_VCCDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVendorInfoTab_VendorInfo = New DevComponents.DotNetBar.TabControlPanel()
            Me.VendorControlVendorInfo_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.VendorControl()
            Me.TabItemVCCDetails_VendorInfoTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOrderInfoTab_OrderInfo = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemVCCDetails_OrderInfoTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVCCDetailsTab_VCCDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVCCDetails_VCCDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVCCDetails_VCCDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterForm_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_Top = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_VCCDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_VCCDetails.SuspendLayout()
            Me.TabControlPanelVendorInfoTab_VendorInfo.SuspendLayout()
            Me.TabControlPanelVCCDetailsTab_VCCDetails.SuspendLayout()
            CType(Me.PanelForm_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Bottom.SuspendLayout()
            CType(Me.PanelForm_Top, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Top.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SummaryResults)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SummaryResults, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_Bottom)
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterForm_TopBottom)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_Top)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'DataGridViewForm_VCCOrders
            '
            Me.DataGridViewForm_VCCOrders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_VCCOrders.AllowDragAndDrop = False
            Me.DataGridViewForm_VCCOrders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_VCCOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_VCCOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_VCCOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_VCCOrders.AutoFilterLookupColumns = False
            Me.DataGridViewForm_VCCOrders.AutoloadRepositoryDatasource = False
            Me.DataGridViewForm_VCCOrders.AutoUpdateViewCaption = True
            Me.DataGridViewForm_VCCOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_VCCOrders.DataSource = Nothing
            Me.DataGridViewForm_VCCOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_VCCOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_VCCOrders.ItemDescription = "VCC(s)"
            Me.DataGridViewForm_VCCOrders.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewForm_VCCOrders.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_VCCOrders.MultiSelect = False
            Me.DataGridViewForm_VCCOrders.Name = "DataGridViewForm_VCCOrders"
            Me.DataGridViewForm_VCCOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_VCCOrders.RunStandardValidation = True
            Me.DataGridViewForm_VCCOrders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_VCCOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_VCCOrders.Size = New System.Drawing.Size(956, 150)
            Me.DataGridViewForm_VCCOrders.TabIndex = 2
            Me.DataGridViewForm_VCCOrders.UseEmbeddedNavigator = False
            Me.DataGridViewForm_VCCOrders.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_SummaryResults
            '
            Me.RibbonBarOptions_SummaryResults.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SummaryResults.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SummaryResults.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SummaryResults.DragDropSupport = True
            Me.RibbonBarOptions_SummaryResults.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSummaryResults_Far, Me.ItemContainerSummaryResults_Splitter1, Me.ItemContainerSummaryResults_Center, Me.ItemContainerSummaryResults_Splitter2, Me.ItemContainerSummaryResults_Near, Me.ItemContainerSummaryResults_Splitter3})
            Me.RibbonBarOptions_SummaryResults.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SummaryResults.Location = New System.Drawing.Point(258, 0)
            Me.RibbonBarOptions_SummaryResults.Name = "RibbonBarOptions_SummaryResults"
            Me.RibbonBarOptions_SummaryResults.SecurityEnabled = True
            Me.RibbonBarOptions_SummaryResults.Size = New System.Drawing.Size(587, 92)
            Me.RibbonBarOptions_SummaryResults.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SummaryResults.TabIndex = 3
            Me.RibbonBarOptions_SummaryResults.Text = "Summary Results"
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SummaryResults.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SummaryResults.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerSummaryResults_Far
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Far.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Far.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Far.Name = "ItemContainerSummaryResults_Far"
            Me.ItemContainerSummaryResults_Far.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSummaryResults_VCCCreditCardsIssued, Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval, Me.ButtonItemSummaryResults_SettledOutOfBalance})
            '
            '
            '
            Me.ItemContainerSummaryResults_Far.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSummaryResults_VCCCreditCardsIssued
            '
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.Name = "ButtonItemSummaryResults_VCCCreditCardsIssued"
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_VCCCreditCardsIssued.Text = "# of Virtual Credit Cards Issued<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_TransactionsDeclinedAfterApporval
            '
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Name = "ButtonItemSummaryResults_TransactionsDeclinedAfterApporval"
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsDeclinedAfterApporval.Text = "Transactions declined after approval<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_SettledOutOfBalance
            '
            Me.ButtonItemSummaryResults_SettledOutOfBalance.Name = "ButtonItemSummaryResults_SettledOutOfBalance"
            Me.ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_SettledOutOfBalance.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_SettledOutOfBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_SettledOutOfBalance.Text = "Settled out of balance<span width=""10""></span>"
            '
            'ItemContainerSummaryResults_Splitter1
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Splitter1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Splitter1.Name = "ItemContainerSummaryResults_Splitter1"
            Me.ItemContainerSummaryResults_Splitter1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1})
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem1
            '
            Me.LabelItem1.Name = "LabelItem1"
            Me.LabelItem1.Text = "<span width=""15"">  </span>"
            '
            'ItemContainerSummaryResults_Center
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Center.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Center.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Center.Name = "ItemContainerSummaryResults_Center"
            Me.ItemContainerSummaryResults_Center.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSummaryResults_VCCIssuedAndUpdated, Me.ButtonItemSummaryResults_TransactionsOutOfBalance, Me.ButtonItemSummaryResults_SettledInBalance})
            '
            '
            '
            Me.ItemContainerSummaryResults_Center.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSummaryResults_VCCIssuedAndUpdated
            '
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.Name = "ButtonItemSummaryResults_VCCIssuedAndUpdated"
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_VCCIssuedAndUpdated.Text = "CC Issued and Limit Updated<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_TransactionsOutOfBalance
            '
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.Name = "ButtonItemSummaryResults_TransactionsOutOfBalance"
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsOutOfBalance.Text = "Transactions out of balance<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_SettledInBalance
            '
            Me.ButtonItemSummaryResults_SettledInBalance.Name = "ButtonItemSummaryResults_SettledInBalance"
            Me.ButtonItemSummaryResults_SettledInBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_SettledInBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_SettledInBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_SettledInBalance.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_SettledInBalance.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_SettledInBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_SettledInBalance.Text = "Settled in balance<span width=""10""></span>"
            '
            'ItemContainerSummaryResults_Splitter2
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Splitter2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Splitter2.Name = "ItemContainerSummaryResults_Splitter2"
            Me.ItemContainerSummaryResults_Splitter2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2})
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem2
            '
            Me.LabelItem2.Name = "LabelItem2"
            Me.LabelItem2.Text = "<span width=""15"">  </span>"
            '
            'ItemContainerSummaryResults_Near
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Near.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Near.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Near.Name = "ItemContainerSummaryResults_Near"
            Me.ItemContainerSummaryResults_Near.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSummaryResults_TransactionsDeclined, Me.ButtonItemSummaryResults_TransactionsInBalance, Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate})
            '
            '
            '
            Me.ItemContainerSummaryResults_Near.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSummaryResults_TransactionsDeclined
            '
            Me.ButtonItemSummaryResults_TransactionsDeclined.Name = "ButtonItemSummaryResults_TransactionsDeclined"
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_TransactionsDeclined.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_TransactionsDeclined.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsDeclined.Text = "Transactions declined<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_TransactionsInBalance
            '
            Me.ButtonItemSummaryResults_TransactionsInBalance.Name = "ButtonItemSummaryResults_TransactionsInBalance"
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_TransactionsInBalance.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_TransactionsInBalance.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_TransactionsInBalance.Text = "Transactions in balance<span width=""10""></span>"
            '
            'ButtonItemSummaryResults_InvalidDataOrExpirationDate
            '
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.Name = "ButtonItemSummaryResults_InvalidDataOrExpirationDate"
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkColor = System.Drawing.Color.LightSkyBlue
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkOffset = New System.Drawing.Point(10, 0)
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.BottomRight
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkSize = 19
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.NotificationMarkText = "0"
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.SubItemsExpandWidth = 14
            Me.ButtonItemSummaryResults_InvalidDataOrExpirationDate.Text = "Invalid data or expiration date<span width=""10""></span>"
            '
            'ItemContainerSummaryResults_Splitter3
            '
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSummaryResults_Splitter3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSummaryResults_Splitter3.Name = "ItemContainerSummaryResults_Splitter3"
            Me.ItemContainerSummaryResults_Splitter3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3})
            '
            '
            '
            Me.ItemContainerSummaryResults_Splitter3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItem3
            '
            Me.LabelItem3.Name = "LabelItem3"
            Me.LabelItem3.Text = "<span width=""20"">  </span>"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_SendNotifications, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(203, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 19
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
            'ButtonItemActions_SendNotifications
            '
            Me.ButtonItemActions_SendNotifications.BeginGroup = True
            Me.ButtonItemActions_SendNotifications.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SendNotifications.Name = "ButtonItemActions_SendNotifications"
            Me.ButtonItemActions_SendNotifications.RibbonWordWrap = False
            Me.ButtonItemActions_SendNotifications.SecurityEnabled = True
            Me.ButtonItemActions_SendNotifications.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SendNotifications.Text = "Send Notifications"
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
            'TabControlForm_VCCDetails
            '
            Me.TabControlForm_VCCDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_VCCDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_VCCDetails.CanReorderTabs = True
            Me.TabControlForm_VCCDetails.Controls.Add(Me.TabControlPanelVCCDetailsTab_VCCDetails)
            Me.TabControlForm_VCCDetails.Controls.Add(Me.TabControlPanelVendorInfoTab_VendorInfo)
            Me.TabControlForm_VCCDetails.Controls.Add(Me.TabControlPanelOrderInfoTab_OrderInfo)
            Me.TabControlForm_VCCDetails.Location = New System.Drawing.Point(12, 6)
            Me.TabControlForm_VCCDetails.Name = "TabControlForm_VCCDetails"
            Me.TabControlForm_VCCDetails.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_VCCDetails.SelectedTabIndex = 0
            Me.TabControlForm_VCCDetails.Size = New System.Drawing.Size(958, 373)
            Me.TabControlForm_VCCDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_VCCDetails.TabIndex = 3
            Me.TabControlForm_VCCDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_VCCDetails.Tabs.Add(Me.TabItemVCCDetails_VCCDetailsTab)
            Me.TabControlForm_VCCDetails.Tabs.Add(Me.TabItemVCCDetails_OrderInfoTab)
            Me.TabControlForm_VCCDetails.Tabs.Add(Me.TabItemVCCDetails_VendorInfoTab)
            '
            'TabControlPanelVendorInfoTab_VendorInfo
            '
            Me.TabControlPanelVendorInfoTab_VendorInfo.Controls.Add(Me.VendorControlVendorInfo_Vendor)
            Me.TabControlPanelVendorInfoTab_VendorInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendorInfoTab_VendorInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendorInfoTab_VendorInfo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendorInfoTab_VendorInfo.Name = "TabControlPanelVendorInfoTab_VendorInfo"
            Me.TabControlPanelVendorInfoTab_VendorInfo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendorInfoTab_VendorInfo.Size = New System.Drawing.Size(958, 346)
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendorInfoTab_VendorInfo.Style.GradientAngle = 90
            Me.TabControlPanelVendorInfoTab_VendorInfo.TabIndex = 3
            Me.TabControlPanelVendorInfoTab_VendorInfo.TabItem = Me.TabItemVCCDetails_VendorInfoTab
            '
            'VendorControlVendorInfo_Vendor
            '
            Me.VendorControlVendorInfo_Vendor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorControlVendorInfo_Vendor.AutoScroll = True
            Me.VendorControlVendorInfo_Vendor.Location = New System.Drawing.Point(4, 4)
            Me.VendorControlVendorInfo_Vendor.Name = "VendorControlVendorInfo_Vendor"
            Me.VendorControlVendorInfo_Vendor.Size = New System.Drawing.Size(950, 338)
            Me.VendorControlVendorInfo_Vendor.TabIndex = 0
            '
            'TabItemVCCDetails_VendorInfoTab
            '
            Me.TabItemVCCDetails_VendorInfoTab.AttachedControl = Me.TabControlPanelVendorInfoTab_VendorInfo
            Me.TabItemVCCDetails_VendorInfoTab.Name = "TabItemVCCDetails_VendorInfoTab"
            Me.TabItemVCCDetails_VendorInfoTab.Text = "Vendor Info"
            '
            'TabControlPanelOrderInfoTab_OrderInfo
            '
            Me.TabControlPanelOrderInfoTab_OrderInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOrderInfoTab_OrderInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOrderInfoTab_OrderInfo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Name = "TabControlPanelOrderInfoTab_OrderInfo"
            Me.TabControlPanelOrderInfoTab_OrderInfo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Size = New System.Drawing.Size(958, 346)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOrderInfoTab_OrderInfo.Style.GradientAngle = 90
            Me.TabControlPanelOrderInfoTab_OrderInfo.TabIndex = 2
            Me.TabControlPanelOrderInfoTab_OrderInfo.TabItem = Me.TabItemVCCDetails_OrderInfoTab
            '
            'TabItemVCCDetails_OrderInfoTab
            '
            Me.TabItemVCCDetails_OrderInfoTab.AttachedControl = Me.TabControlPanelOrderInfoTab_OrderInfo
            Me.TabItemVCCDetails_OrderInfoTab.Name = "TabItemVCCDetails_OrderInfoTab"
            Me.TabItemVCCDetails_OrderInfoTab.Text = "Order Info"
            '
            'TabControlPanelVCCDetailsTab_VCCDetails
            '
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Controls.Add(Me.DataGridViewVCCDetails_VCCDetails)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Name = "TabControlPanelVCCDetailsTab_VCCDetails"
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Size = New System.Drawing.Size(958, 346)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.Style.GradientAngle = 90
            Me.TabControlPanelVCCDetailsTab_VCCDetails.TabIndex = 1
            Me.TabControlPanelVCCDetailsTab_VCCDetails.TabItem = Me.TabItemVCCDetails_VCCDetailsTab
            '
            'DataGridViewVCCDetails_VCCDetails
            '
            Me.DataGridViewVCCDetails_VCCDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewVCCDetails_VCCDetails.AllowDragAndDrop = False
            Me.DataGridViewVCCDetails_VCCDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewVCCDetails_VCCDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVCCDetails_VCCDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewVCCDetails_VCCDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVCCDetails_VCCDetails.AutoFilterLookupColumns = False
            Me.DataGridViewVCCDetails_VCCDetails.AutoloadRepositoryDatasource = False
            Me.DataGridViewVCCDetails_VCCDetails.AutoUpdateViewCaption = True
            Me.DataGridViewVCCDetails_VCCDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewVCCDetails_VCCDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewVCCDetails_VCCDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVCCDetails_VCCDetails.ItemDescription = "VCC Details"
            Me.DataGridViewVCCDetails_VCCDetails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewVCCDetails_VCCDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewVCCDetails_VCCDetails.MultiSelect = True
            Me.DataGridViewVCCDetails_VCCDetails.Name = "DataGridViewVCCDetails_VCCDetails"
            Me.DataGridViewVCCDetails_VCCDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVCCDetails_VCCDetails.RunStandardValidation = True
            Me.DataGridViewVCCDetails_VCCDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewVCCDetails_VCCDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVCCDetails_VCCDetails.Size = New System.Drawing.Size(950, 337)
            Me.DataGridViewVCCDetails_VCCDetails.TabIndex = 3
            Me.DataGridViewVCCDetails_VCCDetails.UseEmbeddedNavigator = False
            Me.DataGridViewVCCDetails_VCCDetails.ViewCaptionHeight = -1
            '
            'TabItemVCCDetails_VCCDetailsTab
            '
            Me.TabItemVCCDetails_VCCDetailsTab.AttachedControl = Me.TabControlPanelVCCDetailsTab_VCCDetails
            Me.TabItemVCCDetails_VCCDetailsTab.Name = "TabItemVCCDetails_VCCDetailsTab"
            Me.TabItemVCCDetails_VCCDetailsTab.Text = "VCC Details"
            '
            'ExpandableSplitterForm_TopBottom
            '
            Me.ExpandableSplitterForm_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterForm_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_TopBottom.Location = New System.Drawing.Point(0, 164)
            Me.ExpandableSplitterForm_TopBottom.Name = "ExpandableSplitterForm_TopBottom"
            Me.ExpandableSplitterForm_TopBottom.Size = New System.Drawing.Size(982, 6)
            Me.ExpandableSplitterForm_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_TopBottom.TabIndex = 4
            Me.ExpandableSplitterForm_TopBottom.TabStop = False
            '
            'PanelForm_Bottom
            '
            Me.PanelForm_Bottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Bottom.Controls.Add(Me.TabControlForm_VCCDetails)
            Me.PanelForm_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_Bottom.Location = New System.Drawing.Point(0, 170)
            Me.PanelForm_Bottom.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelForm_Bottom.Name = "PanelForm_Bottom"
            Me.PanelForm_Bottom.Size = New System.Drawing.Size(982, 385)
            Me.PanelForm_Bottom.TabIndex = 18
            '
            'PanelForm_Top
            '
            Me.PanelForm_Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Top.Controls.Add(Me.DataGridViewForm_VCCOrders)
            Me.PanelForm_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_Top.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_Top.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelForm_Top.Name = "PanelForm_Top"
            Me.PanelForm_Top.Size = New System.Drawing.Size(982, 164)
            Me.PanelForm_Top.TabIndex = 19
            '
            'MediaManagerVCCDashboardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerVCCDashboardDialog"
            Me.Text = "Media Manager VCC Dashboard"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_VCCDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_VCCDetails.ResumeLayout(False)
            Me.TabControlPanelVendorInfoTab_VendorInfo.ResumeLayout(False)
            Me.TabControlPanelVCCDetailsTab_VCCDetails.ResumeLayout(False)
            CType(Me.PanelForm_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Bottom.ResumeLayout(False)
            CType(Me.PanelForm_Top, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Top.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_VCCOrders As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_SummaryResults As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents TabControlForm_VCCDetails As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVCCDetailsTab_VCCDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVCCDetails_VCCDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOrderInfoTab_OrderInfo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVCCDetails_OrderInfoTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVendorInfoTab_VendorInfo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVCCDetails_VendorInfoTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterForm_TopBottom As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents VendorControlVendorInfo_Vendor As WinForm.Presentation.Controls.VendorControl
        Friend WithEvents DataGridViewVCCDetails_VCCDetails As WinForm.Presentation.Controls.DataGridView
        Protected Friend WithEvents PanelForm_Bottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents ItemContainerSummaryResults_Far As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSummaryResults_VCCCreditCardsIssued As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_TransactionsDeclinedAfterApporval As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_SettledOutOfBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSummaryResults_Splitter1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerSummaryResults_Center As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSummaryResults_VCCIssuedAndUpdated As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_TransactionsOutOfBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_SettledInBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSummaryResults_Splitter2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerSummaryResults_Near As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSummaryResults_TransactionsDeclined As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_TransactionsInBalance As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSummaryResults_InvalidDataOrExpirationDate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerSummaryResults_Splitter3 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemActions_SendNotifications As WinForm.Presentation.Controls.ButtonItem
        Protected Friend WithEvents PanelForm_Top As WinForm.Presentation.Controls.Panel
    End Class

End Namespace