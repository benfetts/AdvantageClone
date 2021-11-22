Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetSetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetSetupForm))
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Markets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarkets_Manage = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_Goals = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_Schedules = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_ViewOrderDetails = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCopy_WithNewCDP = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_SearchByOrderNumber = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ShowMissingTrafficInstructions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_FilterPendingMakegoods = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ReplaceBuyer = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Printing = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarPrinting_Reports = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReports_PreBuy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPreBuy_Detail = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPreBuy_StationSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPreBuy_StationDaypartSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPreBuy_DaypartSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReports_BroadcastSchedule = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReports_PostBuy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPostBuy_Detail = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPostBuy_StationSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPostBuy_StationDaypartSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPostBuy_DaypartSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReports_Other = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarPrinting_Print = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrint_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_Settings = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterForm_LeftRightSections = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DashboardViewerDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.ButtonItemReports_ETAMExport = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Printing.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewLeftSection_MediaBroadcastWorksheets
            '
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ItemDescription = "Worksheet(s)"
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.MultiSelect = False
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.Name = "DataGridViewLeftSection_MediaBroadcastWorksheets"
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.Size = New System.Drawing.Size(307, 518)
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.TabIndex = 1
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_MediaBroadcastWorksheets.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Markets)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(27, 300)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1029, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Dashboard
            '
            Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Dashboard.DragDropSupport = True
            Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
            Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(868, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(81, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 4
            Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDashboard_Edit
            '
            Me.ButtonItemDashboard_Edit.BeginGroup = True
            Me.ButtonItemDashboard_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Markets
            '
            Me.RibbonBarOptions_Markets.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Markets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Markets.DragDropSupport = True
            Me.RibbonBarOptions_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarkets_Manage, Me.ButtonItemMarkets_Goals, Me.ButtonItemMarkets_Schedules, Me.ButtonItemMarkets_ViewOrderDetails})
            Me.RibbonBarOptions_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Markets.Location = New System.Drawing.Point(540, 0)
            Me.RibbonBarOptions_Markets.Name = "RibbonBarOptions_Markets"
            Me.RibbonBarOptions_Markets.SecurityEnabled = True
            Me.RibbonBarOptions_Markets.Size = New System.Drawing.Size(328, 98)
            Me.RibbonBarOptions_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Markets.TabIndex = 1
            Me.RibbonBarOptions_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMarkets_Manage
            '
            Me.ButtonItemMarkets_Manage.BeginGroup = True
            Me.ButtonItemMarkets_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Manage.Name = "ButtonItemMarkets_Manage"
            Me.ButtonItemMarkets_Manage.RibbonWordWrap = False
            Me.ButtonItemMarkets_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Manage.Text = "Manage"
            '
            'ButtonItemMarkets_Goals
            '
            Me.ButtonItemMarkets_Goals.BeginGroup = True
            Me.ButtonItemMarkets_Goals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Goals.Name = "ButtonItemMarkets_Goals"
            Me.ButtonItemMarkets_Goals.RibbonWordWrap = False
            Me.ButtonItemMarkets_Goals.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Goals.Text = "Goals"
            '
            'ButtonItemMarkets_Schedules
            '
            Me.ButtonItemMarkets_Schedules.BeginGroup = True
            Me.ButtonItemMarkets_Schedules.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Schedules.Name = "ButtonItemMarkets_Schedules"
            Me.ButtonItemMarkets_Schedules.RibbonWordWrap = False
            Me.ButtonItemMarkets_Schedules.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Schedules.Text = "Schedules"
            '
            'ButtonItemMarkets_ViewOrderDetails
            '
            Me.ButtonItemMarkets_ViewOrderDetails.BeginGroup = True
            Me.ButtonItemMarkets_ViewOrderDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_ViewOrderDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_ViewOrderDetails.Name = "ButtonItemMarkets_ViewOrderDetails"
            Me.ButtonItemMarkets_ViewOrderDetails.RibbonWordWrap = False
            Me.ButtonItemMarkets_ViewOrderDetails.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_ViewOrderDetails.Text = "View Order Details"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_SearchByOrderNumber, Me.ButtonItemActions_ShowMissingTrafficInstructions, Me.ButtonItemActions_FilterPendingMakegoods, Me.ButtonItemActions_ReplaceBuyer, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(540, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SecurityEnabled = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SplitButton = True
            Me.ButtonItemActions_Copy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCopy_WithNewCDP})
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemCopy_WithNewCDP
            '
            Me.ButtonItemCopy_WithNewCDP.Name = "ButtonItemCopy_WithNewCDP"
            Me.ButtonItemCopy_WithNewCDP.Text = "With New C\D\P"
            '
            'ButtonItemActions_SearchByOrderNumber
            '
            Me.ButtonItemActions_SearchByOrderNumber.BeginGroup = True
            Me.ButtonItemActions_SearchByOrderNumber.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_SearchByOrderNumber.Name = "ButtonItemActions_SearchByOrderNumber"
            Me.ButtonItemActions_SearchByOrderNumber.RibbonWordWrap = False
            Me.ButtonItemActions_SearchByOrderNumber.SubItemsExpandWidth = 14
            Me.ButtonItemActions_SearchByOrderNumber.Text = "Search By " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order Number"
            '
            'ButtonItemActions_ShowMissingTrafficInstructions
            '
            Me.ButtonItemActions_ShowMissingTrafficInstructions.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowMissingTrafficInstructions.BeginGroup = True
            Me.ButtonItemActions_ShowMissingTrafficInstructions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ShowMissingTrafficInstructions.Name = "ButtonItemActions_ShowMissingTrafficInstructions"
            Me.ButtonItemActions_ShowMissingTrafficInstructions.RibbonWordWrap = False
            Me.ButtonItemActions_ShowMissingTrafficInstructions.SecurityEnabled = True
            Me.ButtonItemActions_ShowMissingTrafficInstructions.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowMissingTrafficInstructions.Text = "Show" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Missing Traffic"
            Me.ButtonItemActions_ShowMissingTrafficInstructions.Tooltip = "Show Missing Traffic Instructions"
            '
            'ButtonItemActions_FilterPendingMakegoods
            '
            Me.ButtonItemActions_FilterPendingMakegoods.AutoCheckOnClick = True
            Me.ButtonItemActions_FilterPendingMakegoods.BeginGroup = True
            Me.ButtonItemActions_FilterPendingMakegoods.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_FilterPendingMakegoods.Name = "ButtonItemActions_FilterPendingMakegoods"
            Me.ButtonItemActions_FilterPendingMakegoods.RibbonWordWrap = False
            Me.ButtonItemActions_FilterPendingMakegoods.SecurityEnabled = True
            Me.ButtonItemActions_FilterPendingMakegoods.SubItemsExpandWidth = 14
            Me.ButtonItemActions_FilterPendingMakegoods.Text = "Pending" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Makegoods"
            Me.ButtonItemActions_FilterPendingMakegoods.Tooltip = "Filter for Pending Makegoods"
            '
            'ButtonItemActions_ReplaceBuyer
            '
            Me.ButtonItemActions_ReplaceBuyer.BeginGroup = True
            Me.ButtonItemActions_ReplaceBuyer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ReplaceBuyer.Name = "ButtonItemActions_ReplaceBuyer"
            Me.ButtonItemActions_ReplaceBuyer.RibbonWordWrap = False
            Me.ButtonItemActions_ReplaceBuyer.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ReplaceBuyer.Text = "Replace Buyer"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RibbonBarMergeContainerForm_Printing
            '
            Me.RibbonBarMergeContainerForm_Printing.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Printing.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Reports)
            Me.RibbonBarMergeContainerForm_Printing.Controls.Add(Me.RibbonBarPrinting_Print)
            Me.RibbonBarMergeContainerForm_Printing.Location = New System.Drawing.Point(93, 404)
            Me.RibbonBarMergeContainerForm_Printing.Name = "RibbonBarMergeContainerForm_Printing"
            Me.RibbonBarMergeContainerForm_Printing.RibbonTabText = "Printing"
            Me.RibbonBarMergeContainerForm_Printing.Size = New System.Drawing.Size(691, 98)
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
            Me.RibbonBarMergeContainerForm_Printing.TabIndex = 4
            Me.RibbonBarMergeContainerForm_Printing.Visible = False
            '
            'RibbonBarPrinting_Reports
            '
            Me.RibbonBarPrinting_Reports.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarPrinting_Reports.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Reports.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Reports.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Reports.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Reports.DragDropSupport = True
            Me.RibbonBarPrinting_Reports.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_Reports.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReports_PreBuy, Me.ButtonItemReports_BroadcastSchedule, Me.ButtonItemReports_PostBuy, Me.ButtonItemReports_Other, Me.ButtonItemReports_ETAMExport})
            Me.RibbonBarPrinting_Reports.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Reports.Location = New System.Drawing.Point(156, 0)
            Me.RibbonBarPrinting_Reports.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarPrinting_Reports.Name = "RibbonBarPrinting_Reports"
            Me.RibbonBarPrinting_Reports.SecurityEnabled = True
            Me.RibbonBarPrinting_Reports.Size = New System.Drawing.Size(267, 98)
            Me.RibbonBarPrinting_Reports.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Reports.TabIndex = 6
            Me.RibbonBarPrinting_Reports.Text = "Reports"
            '
            '
            '
            Me.RibbonBarPrinting_Reports.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Reports.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Reports.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemReports_PreBuy
            '
            Me.ButtonItemReports_PreBuy.AutoExpandOnClick = True
            Me.ButtonItemReports_PreBuy.BeginGroup = True
            Me.ButtonItemReports_PreBuy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReports_PreBuy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReports_PreBuy.Name = "ButtonItemReports_PreBuy"
            Me.ButtonItemReports_PreBuy.RibbonWordWrap = False
            Me.ButtonItemReports_PreBuy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPreBuy_Detail, Me.ButtonItemPreBuy_StationSummary, Me.ButtonItemPreBuy_StationDaypartSummary, Me.ButtonItemPreBuy_DaypartSummary})
            Me.ButtonItemReports_PreBuy.SubItemsExpandWidth = 14
            Me.ButtonItemReports_PreBuy.Text = "Pre Buy"
            '
            'ButtonItemPreBuy_Detail
            '
            Me.ButtonItemPreBuy_Detail.Name = "ButtonItemPreBuy_Detail"
            Me.ButtonItemPreBuy_Detail.Text = "Detail"
            '
            'ButtonItemPreBuy_StationSummary
            '
            Me.ButtonItemPreBuy_StationSummary.Name = "ButtonItemPreBuy_StationSummary"
            Me.ButtonItemPreBuy_StationSummary.Text = "Station Summary"
            '
            'ButtonItemPreBuy_StationDaypartSummary
            '
            Me.ButtonItemPreBuy_StationDaypartSummary.Name = "ButtonItemPreBuy_StationDaypartSummary"
            Me.ButtonItemPreBuy_StationDaypartSummary.Text = "Station Daypart Summary"
            '
            'ButtonItemPreBuy_DaypartSummary
            '
            Me.ButtonItemPreBuy_DaypartSummary.Name = "ButtonItemPreBuy_DaypartSummary"
            Me.ButtonItemPreBuy_DaypartSummary.Text = "Daypart Summary"
            '
            'ButtonItemReports_BroadcastSchedule
            '
            Me.ButtonItemReports_BroadcastSchedule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReports_BroadcastSchedule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReports_BroadcastSchedule.Name = "ButtonItemReports_BroadcastSchedule"
            Me.ButtonItemReports_BroadcastSchedule.SubItemsExpandWidth = 14
            Me.ButtonItemReports_BroadcastSchedule.Text = "Broadcast " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Schedule"
            '
            'ButtonItemReports_PostBuy
            '
            Me.ButtonItemReports_PostBuy.AutoExpandOnClick = True
            Me.ButtonItemReports_PostBuy.BeginGroup = True
            Me.ButtonItemReports_PostBuy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReports_PostBuy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReports_PostBuy.Name = "ButtonItemReports_PostBuy"
            Me.ButtonItemReports_PostBuy.RibbonWordWrap = False
            Me.ButtonItemReports_PostBuy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPostBuy_Detail, Me.ButtonItemPostBuy_StationSummary, Me.ButtonItemPostBuy_StationDaypartSummary, Me.ButtonItemPostBuy_DaypartSummary})
            Me.ButtonItemReports_PostBuy.SubItemsExpandWidth = 14
            Me.ButtonItemReports_PostBuy.Text = "Post Buy"
            '
            'ButtonItemPostBuy_Detail
            '
            Me.ButtonItemPostBuy_Detail.Name = "ButtonItemPostBuy_Detail"
            Me.ButtonItemPostBuy_Detail.Text = "Detail"
            '
            'ButtonItemPostBuy_StationSummary
            '
            Me.ButtonItemPostBuy_StationSummary.Name = "ButtonItemPostBuy_StationSummary"
            Me.ButtonItemPostBuy_StationSummary.Text = "Station Summary"
            '
            'ButtonItemPostBuy_StationDaypartSummary
            '
            Me.ButtonItemPostBuy_StationDaypartSummary.Name = "ButtonItemPostBuy_StationDaypartSummary"
            Me.ButtonItemPostBuy_StationDaypartSummary.Text = "Station Daypart Summary"
            '
            'ButtonItemPostBuy_DaypartSummary
            '
            Me.ButtonItemPostBuy_DaypartSummary.Name = "ButtonItemPostBuy_DaypartSummary"
            Me.ButtonItemPostBuy_DaypartSummary.Text = "Daypart Summary"
            '
            'ButtonItemReports_Other
            '
            Me.ButtonItemReports_Other.BeginGroup = True
            Me.ButtonItemReports_Other.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReports_Other.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReports_Other.Name = "ButtonItemReports_Other"
            Me.ButtonItemReports_Other.SubItemsExpandWidth = 14
            Me.ButtonItemReports_Other.Text = "Other"
            '
            'RibbonBarPrinting_Print
            '
            Me.RibbonBarPrinting_Print.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarPrinting_Print.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Print.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Print.ContainerControlProcessDialogKey = True
            Me.RibbonBarPrinting_Print.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPrinting_Print.DragDropSupport = True
            Me.RibbonBarPrinting_Print.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarPrinting_Print.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_Print, Me.ButtonItemPrint_Settings})
            Me.RibbonBarPrinting_Print.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPrinting_Print.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarPrinting_Print.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarPrinting_Print.Name = "RibbonBarPrinting_Print"
            Me.RibbonBarPrinting_Print.SecurityEnabled = True
            Me.RibbonBarPrinting_Print.Size = New System.Drawing.Size(156, 98)
            Me.RibbonBarPrinting_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPrinting_Print.TabIndex = 5
            Me.RibbonBarPrinting_Print.Text = "Print"
            '
            '
            '
            Me.RibbonBarPrinting_Print.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPrinting_Print.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPrinting_Print.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPrint_Print
            '
            Me.ButtonItemPrint_Print.BeginGroup = True
            Me.ButtonItemPrint_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrint_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrint_Print.Name = "ButtonItemPrint_Print"
            Me.ButtonItemPrint_Print.RibbonWordWrap = False
            Me.ButtonItemPrint_Print.SubItemsExpandWidth = 14
            Me.ButtonItemPrint_Print.Text = "Print"
            '
            'ButtonItemPrint_Settings
            '
            Me.ButtonItemPrint_Settings.BeginGroup = True
            Me.ButtonItemPrint_Settings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrint_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrint_Settings.Name = "ButtonItemPrint_Settings"
            Me.ButtonItemPrint_Settings.RibbonWordWrap = False
            Me.ButtonItemPrint_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemPrint_Settings.Text = "Settings"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_MediaBroadcastWorksheets)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(325, 542)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'ExpandableSplitterForm_LeftRightSections
            '
            Me.ExpandableSplitterForm_LeftRightSections.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftRightSections.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.Location = New System.Drawing.Point(325, 0)
            Me.ExpandableSplitterForm_LeftRightSections.Name = "ExpandableSplitterForm_LeftRightSections"
            Me.ExpandableSplitterForm_LeftRightSections.Size = New System.Drawing.Size(6, 542)
            Me.ExpandableSplitterForm_LeftRightSections.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRightSections.TabIndex = 1
            Me.ExpandableSplitterForm_LeftRightSections.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Markets)
            Me.PanelForm_RightSection.Controls.Add(Me.DashboardViewerDashboard_Dashboard)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(331, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(796, 542)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'DataGridViewRightSection_Markets
            '
            Me.DataGridViewRightSection_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Markets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Markets.ItemDescription = "Market Schedule(s)"
            Me.DataGridViewRightSection_Markets.Location = New System.Drawing.Point(6, 12)
            Me.DataGridViewRightSection_Markets.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewRightSection_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRightSection_Markets.ModifyGridRowHeight = False
            Me.DataGridViewRightSection_Markets.MultiSelect = False
            Me.DataGridViewRightSection_Markets.Name = "DataGridViewRightSection_Markets"
            Me.DataGridViewRightSection_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRightSection_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewRightSection_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Markets.Size = New System.Drawing.Size(778, 207)
            Me.DataGridViewRightSection_Markets.TabIndex = 2
            Me.DataGridViewRightSection_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Markets.ViewCaptionHeight = -1
            '
            'DashboardViewerDashboard_Dashboard
            '
            Me.DashboardViewerDashboard_Dashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DashboardViewerDashboard_Dashboard.Location = New System.Drawing.Point(6, 225)
            Me.DashboardViewerDashboard_Dashboard.Name = "DashboardViewerDashboard_Dashboard"
            Me.DashboardViewerDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerDashboard_Dashboard.Size = New System.Drawing.Size(778, 305)
            Me.DashboardViewerDashboard_Dashboard.TabIndex = 1
            '
            'ToolTipController
            '
            '
            'ButtonItemReports_ETAMExport
            '
            Me.ButtonItemReports_ETAMExport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReports_ETAMExport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReports_ETAMExport.Name = "ButtonItemReports_ETAMExport"
            Me.ButtonItemReports_ETAMExport.SubItemsExpandWidth = 14
            Me.ButtonItemReports_ETAMExport.Text = "eTAM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Export"
            '
            'MediaBroadcastWorksheetSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1127, 542)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Printing)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterForm_LeftRightSections)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "MediaBroadcastWorksheetSetupForm"
            Me.Text = "Broadcast Worksheets"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Printing.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.DashboardViewerDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewLeftSection_MediaBroadcastWorksheets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarMergeContainerForm_Printing As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterForm_LeftRightSections As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Markets As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMarkets_Manage As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_Goals As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewRightSection_Markets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DashboardViewerDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_Schedules As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_ViewOrderDetails As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCopy_WithNewCDP As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarPrinting_Print As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrint_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_Settings As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarPrinting_Reports As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReports_PreBuy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReports_PostBuy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPreBuy_Detail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPostBuy_Detail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPreBuy_StationSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPreBuy_StationDaypartSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPreBuy_DaypartSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPostBuy_StationSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPostBuy_StationDaypartSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPostBuy_DaypartSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents ButtonItemReports_BroadcastSchedule As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReports_Other As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_SearchByOrderNumber As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ShowMissingTrafficInstructions As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_FilterPendingMakegoods As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ReplaceBuyer As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReports_ETAMExport As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
