Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanEditForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanEditForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_DataOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerDataOptions_DataOptions1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemDataOptions_RateCPM = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataOptions_ShowDaysOfWeeks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowDaysOfWeek_AsLevel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithMerge = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataOptions_ShowPackageLevel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerDataOptions_DataOptions2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemDataOptions_ShowDateRange = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataOptions_ShowAdSizes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Totals = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTotals_ShowHideColumnTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowHideColumnTotals_GrandTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowHideColumnTotals_Totals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotals_ShowHideRowTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowHideRowTotals_GrandTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowHideRowTotals_GrandTotalsValues = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemShowHideRowTotals_Totals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemShowHideRowTotals_TotalsValues = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTotals_TotalFields = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_GrossPercentageInTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_NetDollars = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_CPP1 = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_CPP2 = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_CPI = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_CTR = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_ConversionRate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_TotalDemo1 = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_TotalDemo2 = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_TotalNet = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemTotalFields_Commission = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaRates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaRates_Gross = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaRates_Net = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_DateSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerDateSettings_DateSettings = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemDateSettings_CalendarMonth = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDateSettings_BroadcastMonth = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDateSettings_SplitWeeks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ShowHideFieldList = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_FreezeLevels = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_EstimateLevelsLines = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetailLevelsLines_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetailLevelsLines_ManageLevelLines = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaMix = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaMix_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaMixUpdate_LevelsLines = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaMixUpdate_BudgetAddMissing = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaMixUpdate_Budget = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaMixUpdate_Rate = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Estimates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemMediaPlanDetails_MediaPlanDetails = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemMediaPlanDetails_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_Approve = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_Unapprove = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaPlanDetails_ChangeLogs = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Approve = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Unapprove = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PivotGridForm_MediaPlanDetail = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl()
            Me.ContextMenuBar = New DevComponents.DotNetBar.ContextMenuBar()
            Me.ButtonItemCMB_DataArea = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ShowHideGrandTotal = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ShowHideTotals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ShowHideValues = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_SetCaption = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_SetPrefix = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ChangeDisplayType = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemChangeDisplayType_WeekNumber = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemChangeDisplayType_WeekStartDate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemChangeDisplayType_WeekStartDay = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_SetClearHiatus = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_AddDataByAllocating = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_SetNote = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_SetClearBlankCell = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_Hide = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ShowFieldList = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ColorPickerDropDownDataArea_RowColor = New DevComponents.DotNetBar.ColorPickerDropDown()
            Me.ButtonItemDataArea_RateCPM = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ViewData = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataArea_ChangeDemo = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Exporting = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarExport_PrintOrder = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrintOrder_Change = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarExporting_HeaderFooterImages = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemHeaderFooterImages_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarExporting_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_ShowHiatusDates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarExporting_Export = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemExport_FlowChart = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemExport_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemExport_AllEstimates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Process = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarProcess_Data = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemData_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemData_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemData_CreateOrders = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemData_GenerateOrders = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemData_OrderStatus = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelForm_GrossBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_GrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Billing = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_BillingAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Variance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_VarianceAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PlanTotals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateIDData = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_CalculateQty = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_EstimateTotals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateVarianceAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateVariance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateBillingAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateBilling = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateGrossBudgetAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EstimateGrossBudget = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PivotGridForm_MediaPlanDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ContextMenuBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Exporting.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Process.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_DataOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Totals)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaRates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_DateSettings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_GridOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_EstimateLevelsLines)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaMix)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Estimates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 90)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1401, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 18
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_DataOptions
            '
            Me.RibbonBarOptions_DataOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DataOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DataOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DataOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DataOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DataOptions.DragDropSupport = True
            Me.RibbonBarOptions_DataOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDataOptions_DataOptions1, Me.ItemContainerDataOptions_DataOptions2})
            Me.RibbonBarOptions_DataOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DataOptions.Location = New System.Drawing.Point(1171, 0)
            Me.RibbonBarOptions_DataOptions.Name = "RibbonBarOptions_DataOptions"
            Me.RibbonBarOptions_DataOptions.SecurityEnabled = True
            Me.RibbonBarOptions_DataOptions.Size = New System.Drawing.Size(229, 98)
            Me.RibbonBarOptions_DataOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DataOptions.TabIndex = 10
            Me.RibbonBarOptions_DataOptions.Text = "Data Options"
            '
            '
            '
            Me.RibbonBarOptions_DataOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DataOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DataOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerDataOptions_DataOptions1
            '
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDataOptions_DataOptions1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDataOptions_DataOptions1.Name = "ItemContainerDataOptions_DataOptions1"
            Me.ItemContainerDataOptions_DataOptions1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDataOptions_RateCPM, Me.ButtonItemDataOptions_ShowDaysOfWeeks, Me.ButtonItemDataOptions_ShowPackageLevel})
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDataOptions_RateCPM
            '
            Me.ButtonItemDataOptions_RateCPM.AutoExpandOnClick = True
            Me.ButtonItemDataOptions_RateCPM.BeginGroup = True
            Me.ButtonItemDataOptions_RateCPM.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataOptions_RateCPM.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataOptions_RateCPM.Name = "ButtonItemDataOptions_RateCPM"
            Me.ButtonItemDataOptions_RateCPM.RibbonWordWrap = False
            Me.ButtonItemDataOptions_RateCPM.SecurityEnabled = True
            Me.ButtonItemDataOptions_RateCPM.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_RateCPM.Text = "Rate CPM"
            '
            'ButtonItemDataOptions_ShowDaysOfWeeks
            '
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.AutoExpandOnClick = True
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.BeginGroup = True
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.Name = "ButtonItemDataOptions_ShowDaysOfWeeks"
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.RibbonWordWrap = False
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.SecurityEnabled = True
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemShowDaysOfWeek_AsLevel, Me.ButtonItemShowDaysOfWeek_OverrideDataWithMerge, Me.ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge})
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_ShowDaysOfWeeks.Text = "Show Days of Week"
            '
            'ButtonItemShowDaysOfWeek_AsLevel
            '
            Me.ButtonItemShowDaysOfWeek_AsLevel.Name = "ButtonItemShowDaysOfWeek_AsLevel"
            Me.ButtonItemShowDaysOfWeek_AsLevel.SecurityEnabled = True
            Me.ButtonItemShowDaysOfWeek_AsLevel.Text = "As Level"
            '
            'ButtonItemShowDaysOfWeek_OverrideDataWithMerge
            '
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Name = "ButtonItemShowDaysOfWeek_OverrideDataWithMerge"
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithMerge.SecurityEnabled = True
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithMerge.Text = "Override Data w/Merge"
            '
            'ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge
            '
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Name = "ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge"
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.SecurityEnabled = True
            Me.ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge.Text = "Override Data w/o Merge"
            '
            'ButtonItemDataOptions_ShowPackageLevel
            '
            Me.ButtonItemDataOptions_ShowPackageLevel.AutoCheckOnClick = True
            Me.ButtonItemDataOptions_ShowPackageLevel.BeginGroup = True
            Me.ButtonItemDataOptions_ShowPackageLevel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataOptions_ShowPackageLevel.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataOptions_ShowPackageLevel.Name = "ButtonItemDataOptions_ShowPackageLevel"
            Me.ButtonItemDataOptions_ShowPackageLevel.RibbonWordWrap = False
            Me.ButtonItemDataOptions_ShowPackageLevel.SecurityEnabled = True
            Me.ButtonItemDataOptions_ShowPackageLevel.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_ShowPackageLevel.Text = "Show Package Name"
            '
            'ItemContainerDataOptions_DataOptions2
            '
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDataOptions_DataOptions2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDataOptions_DataOptions2.Name = "ItemContainerDataOptions_DataOptions2"
            Me.ItemContainerDataOptions_DataOptions2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDataOptions_ShowDateRange, Me.ButtonItemDataOptions_ShowAdSizes})
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDataOptions_DataOptions2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDataOptions_ShowDateRange
            '
            Me.ButtonItemDataOptions_ShowDateRange.AutoCheckOnClick = True
            Me.ButtonItemDataOptions_ShowDateRange.BeginGroup = True
            Me.ButtonItemDataOptions_ShowDateRange.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataOptions_ShowDateRange.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataOptions_ShowDateRange.Name = "ButtonItemDataOptions_ShowDateRange"
            Me.ButtonItemDataOptions_ShowDateRange.RibbonWordWrap = False
            Me.ButtonItemDataOptions_ShowDateRange.SecurityEnabled = True
            Me.ButtonItemDataOptions_ShowDateRange.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_ShowDateRange.Text = "Show Date Range"
            '
            'ButtonItemDataOptions_ShowAdSizes
            '
            Me.ButtonItemDataOptions_ShowAdSizes.AutoCheckOnClick = True
            Me.ButtonItemDataOptions_ShowAdSizes.BeginGroup = True
            Me.ButtonItemDataOptions_ShowAdSizes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDataOptions_ShowAdSizes.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataOptions_ShowAdSizes.Name = "ButtonItemDataOptions_ShowAdSizes"
            Me.ButtonItemDataOptions_ShowAdSizes.RibbonWordWrap = False
            Me.ButtonItemDataOptions_ShowAdSizes.SecurityEnabled = True
            Me.ButtonItemDataOptions_ShowAdSizes.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_ShowAdSizes.Text = "Show Ad Sizes"
            '
            'RibbonBarOptions_Totals
            '
            Me.RibbonBarOptions_Totals.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Totals.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Totals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Totals.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Totals.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Totals.DragDropSupport = True
            Me.RibbonBarOptions_Totals.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTotals_ShowHideColumnTotals, Me.ButtonItemTotals_ShowHideRowTotals, Me.ButtonItemTotals_TotalFields})
            Me.RibbonBarOptions_Totals.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Totals.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Totals.Location = New System.Drawing.Point(1020, 0)
            Me.RibbonBarOptions_Totals.Name = "RibbonBarOptions_Totals"
            Me.RibbonBarOptions_Totals.SecurityEnabled = True
            Me.RibbonBarOptions_Totals.Size = New System.Drawing.Size(151, 98)
            Me.RibbonBarOptions_Totals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Totals.TabIndex = 7
            Me.RibbonBarOptions_Totals.Text = "Totals"
            '
            '
            '
            Me.RibbonBarOptions_Totals.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Totals.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Totals.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTotals_ShowHideColumnTotals
            '
            Me.ButtonItemTotals_ShowHideColumnTotals.AutoExpandOnClick = True
            Me.ButtonItemTotals_ShowHideColumnTotals.BeginGroup = True
            Me.ButtonItemTotals_ShowHideColumnTotals.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTotals_ShowHideColumnTotals.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemTotals_ShowHideColumnTotals.Name = "ButtonItemTotals_ShowHideColumnTotals"
            Me.ButtonItemTotals_ShowHideColumnTotals.RibbonWordWrap = False
            Me.ButtonItemTotals_ShowHideColumnTotals.SecurityEnabled = True
            Me.ButtonItemTotals_ShowHideColumnTotals.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemShowHideColumnTotals_GrandTotals, Me.ButtonItemShowHideColumnTotals_Totals})
            Me.ButtonItemTotals_ShowHideColumnTotals.SubItemsExpandWidth = 14
            Me.ButtonItemTotals_ShowHideColumnTotals.Text = "Show/Hide Column Totals"
            '
            'ButtonItemShowHideColumnTotals_GrandTotals
            '
            Me.ButtonItemShowHideColumnTotals_GrandTotals.AutoCheckOnClick = True
            Me.ButtonItemShowHideColumnTotals_GrandTotals.Name = "ButtonItemShowHideColumnTotals_GrandTotals"
            Me.ButtonItemShowHideColumnTotals_GrandTotals.SecurityEnabled = True
            Me.ButtonItemShowHideColumnTotals_GrandTotals.Text = "Grand Totals"
            '
            'ButtonItemShowHideColumnTotals_Totals
            '
            Me.ButtonItemShowHideColumnTotals_Totals.AutoCheckOnClick = True
            Me.ButtonItemShowHideColumnTotals_Totals.Name = "ButtonItemShowHideColumnTotals_Totals"
            Me.ButtonItemShowHideColumnTotals_Totals.SecurityEnabled = True
            Me.ButtonItemShowHideColumnTotals_Totals.Text = "Totals"
            '
            'ButtonItemTotals_ShowHideRowTotals
            '
            Me.ButtonItemTotals_ShowHideRowTotals.AutoExpandOnClick = True
            Me.ButtonItemTotals_ShowHideRowTotals.BeginGroup = True
            Me.ButtonItemTotals_ShowHideRowTotals.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTotals_ShowHideRowTotals.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemTotals_ShowHideRowTotals.Name = "ButtonItemTotals_ShowHideRowTotals"
            Me.ButtonItemTotals_ShowHideRowTotals.RibbonWordWrap = False
            Me.ButtonItemTotals_ShowHideRowTotals.SecurityEnabled = True
            Me.ButtonItemTotals_ShowHideRowTotals.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemShowHideRowTotals_GrandTotals, Me.ButtonItemShowHideRowTotals_GrandTotalsValues, Me.ButtonItemShowHideRowTotals_Totals, Me.ButtonItemShowHideRowTotals_TotalsValues})
            Me.ButtonItemTotals_ShowHideRowTotals.SubItemsExpandWidth = 14
            Me.ButtonItemTotals_ShowHideRowTotals.Text = "Show/Hide Row Totals"
            '
            'ButtonItemShowHideRowTotals_GrandTotals
            '
            Me.ButtonItemShowHideRowTotals_GrandTotals.AutoCheckOnClick = True
            Me.ButtonItemShowHideRowTotals_GrandTotals.Name = "ButtonItemShowHideRowTotals_GrandTotals"
            Me.ButtonItemShowHideRowTotals_GrandTotals.SecurityEnabled = True
            Me.ButtonItemShowHideRowTotals_GrandTotals.Text = "Grand Totals"
            '
            'ButtonItemShowHideRowTotals_GrandTotalsValues
            '
            Me.ButtonItemShowHideRowTotals_GrandTotalsValues.AutoCheckOnClick = True
            Me.ButtonItemShowHideRowTotals_GrandTotalsValues.Name = "ButtonItemShowHideRowTotals_GrandTotalsValues"
            Me.ButtonItemShowHideRowTotals_GrandTotalsValues.Text = "Grand Totals Values"
            '
            'ButtonItemShowHideRowTotals_Totals
            '
            Me.ButtonItemShowHideRowTotals_Totals.AutoCheckOnClick = True
            Me.ButtonItemShowHideRowTotals_Totals.Name = "ButtonItemShowHideRowTotals_Totals"
            Me.ButtonItemShowHideRowTotals_Totals.SecurityEnabled = True
            Me.ButtonItemShowHideRowTotals_Totals.Text = "Totals"
            '
            'ButtonItemShowHideRowTotals_TotalsValues
            '
            Me.ButtonItemShowHideRowTotals_TotalsValues.AutoCheckOnClick = True
            Me.ButtonItemShowHideRowTotals_TotalsValues.Name = "ButtonItemShowHideRowTotals_TotalsValues"
            Me.ButtonItemShowHideRowTotals_TotalsValues.Text = "Totals Values"
            '
            'ButtonItemTotals_TotalFields
            '
            Me.ButtonItemTotals_TotalFields.AutoExpandOnClick = True
            Me.ButtonItemTotals_TotalFields.BeginGroup = True
            Me.ButtonItemTotals_TotalFields.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTotals_TotalFields.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemTotals_TotalFields.Name = "ButtonItemTotals_TotalFields"
            Me.ButtonItemTotals_TotalFields.RibbonWordWrap = False
            Me.ButtonItemTotals_TotalFields.SecurityEnabled = True
            Me.ButtonItemTotals_TotalFields.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTotalFields_GrossPercentageInTotals, Me.ButtonItemTotalFields_NetDollars, Me.ButtonItemTotalFields_CPP1, Me.ButtonItemTotalFields_CPP2, Me.ButtonItemTotalFields_CPI, Me.ButtonItemTotalFields_CTR, Me.ButtonItemTotalFields_ConversionRate, Me.ButtonItemTotalFields_TotalDemo1, Me.ButtonItemTotalFields_TotalDemo2, Me.ButtonItemTotalFields_TotalNet, Me.ButtonItemTotalFields_Commission})
            Me.ButtonItemTotals_TotalFields.SubItemsExpandWidth = 14
            Me.ButtonItemTotals_TotalFields.Text = "Total Fields"
            Me.ButtonItemTotals_TotalFields.Tooltip = "Show gross amount percentage in the column grand total"
            '
            'ButtonItemTotalFields_GrossPercentageInTotals
            '
            Me.ButtonItemTotalFields_GrossPercentageInTotals.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_GrossPercentageInTotals.BeginGroup = True
            Me.ButtonItemTotalFields_GrossPercentageInTotals.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTotalFields_GrossPercentageInTotals.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemTotalFields_GrossPercentageInTotals.Name = "ButtonItemTotalFields_GrossPercentageInTotals"
            Me.ButtonItemTotalFields_GrossPercentageInTotals.RibbonWordWrap = False
            Me.ButtonItemTotalFields_GrossPercentageInTotals.SecurityEnabled = True
            Me.ButtonItemTotalFields_GrossPercentageInTotals.SplitButton = True
            Me.ButtonItemTotalFields_GrossPercentageInTotals.SubItemsExpandWidth = 14
            Me.ButtonItemTotalFields_GrossPercentageInTotals.Text = "% of Spending"
            Me.ButtonItemTotalFields_GrossPercentageInTotals.Tooltip = "Show gross amount percentage in the column grand total"
            '
            'ButtonItemTotalFields_NetDollars
            '
            Me.ButtonItemTotalFields_NetDollars.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_NetDollars.Name = "ButtonItemTotalFields_NetDollars"
            Me.ButtonItemTotalFields_NetDollars.SecurityEnabled = True
            Me.ButtonItemTotalFields_NetDollars.Text = "Net Dollars"
            '
            'ButtonItemTotalFields_CPP1
            '
            Me.ButtonItemTotalFields_CPP1.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_CPP1.Name = "ButtonItemTotalFields_CPP1"
            Me.ButtonItemTotalFields_CPP1.SecurityEnabled = True
            Me.ButtonItemTotalFields_CPP1.Text = "CPP 1"
            '
            'ButtonItemTotalFields_CPP2
            '
            Me.ButtonItemTotalFields_CPP2.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_CPP2.Name = "ButtonItemTotalFields_CPP2"
            Me.ButtonItemTotalFields_CPP2.SecurityEnabled = True
            Me.ButtonItemTotalFields_CPP2.Text = "CPP 2"
            '
            'ButtonItemTotalFields_CPI
            '
            Me.ButtonItemTotalFields_CPI.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_CPI.Name = "ButtonItemTotalFields_CPI"
            Me.ButtonItemTotalFields_CPI.SecurityEnabled = True
            Me.ButtonItemTotalFields_CPI.Text = "CPI"
            '
            'ButtonItemTotalFields_CTR
            '
            Me.ButtonItemTotalFields_CTR.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_CTR.Name = "ButtonItemTotalFields_CTR"
            Me.ButtonItemTotalFields_CTR.SecurityEnabled = True
            Me.ButtonItemTotalFields_CTR.Text = "CTR %"
            '
            'ButtonItemTotalFields_ConversionRate
            '
            Me.ButtonItemTotalFields_ConversionRate.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_ConversionRate.Name = "ButtonItemTotalFields_ConversionRate"
            Me.ButtonItemTotalFields_ConversionRate.SecurityEnabled = True
            Me.ButtonItemTotalFields_ConversionRate.Text = "Conversion Rate %"
            '
            'ButtonItemTotalFields_TotalDemo1
            '
            Me.ButtonItemTotalFields_TotalDemo1.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_TotalDemo1.Name = "ButtonItemTotalFields_TotalDemo1"
            Me.ButtonItemTotalFields_TotalDemo1.SecurityEnabled = True
            Me.ButtonItemTotalFields_TotalDemo1.Text = "Total Demo 1"
            '
            'ButtonItemTotalFields_TotalDemo2
            '
            Me.ButtonItemTotalFields_TotalDemo2.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_TotalDemo2.Name = "ButtonItemTotalFields_TotalDemo2"
            Me.ButtonItemTotalFields_TotalDemo2.SecurityEnabled = True
            Me.ButtonItemTotalFields_TotalDemo2.Text = "Total Demo 2"
            '
            'ButtonItemTotalFields_TotalNet
            '
            Me.ButtonItemTotalFields_TotalNet.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_TotalNet.Name = "ButtonItemTotalFields_TotalNet"
            Me.ButtonItemTotalFields_TotalNet.SecurityEnabled = True
            Me.ButtonItemTotalFields_TotalNet.Text = "Total Net"
            '
            'ButtonItemTotalFields_Commission
            '
            Me.ButtonItemTotalFields_Commission.AutoCheckOnClick = True
            Me.ButtonItemTotalFields_Commission.Name = "ButtonItemTotalFields_Commission"
            Me.ButtonItemTotalFields_Commission.SecurityEnabled = True
            Me.ButtonItemTotalFields_Commission.Text = "Commission"
            '
            'RibbonBarOptions_MediaRates
            '
            Me.RibbonBarOptions_MediaRates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaRates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaRates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaRates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaRates.DragDropSupport = True
            Me.RibbonBarOptions_MediaRates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaRates_Gross, Me.ButtonItemMediaRates_Net})
            Me.RibbonBarOptions_MediaRates.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_MediaRates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaRates.Location = New System.Drawing.Point(950, 0)
            Me.RibbonBarOptions_MediaRates.Name = "RibbonBarOptions_MediaRates"
            Me.RibbonBarOptions_MediaRates.SecurityEnabled = True
            Me.RibbonBarOptions_MediaRates.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_MediaRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaRates.TabIndex = 6
            Me.RibbonBarOptions_MediaRates.Text = "Media Rates"
            '
            '
            '
            Me.RibbonBarOptions_MediaRates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaRates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemMediaRates_Gross
            '
            Me.ButtonItemMediaRates_Gross.AutoCheckOnClick = True
            Me.ButtonItemMediaRates_Gross.BeginGroup = True
            Me.ButtonItemMediaRates_Gross.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaRates_Gross.Checked = True
            Me.ButtonItemMediaRates_Gross.ImageFixedSize = New System.Drawing.Size(24, 24)
            Me.ButtonItemMediaRates_Gross.Name = "ButtonItemMediaRates_Gross"
            Me.ButtonItemMediaRates_Gross.OptionGroup = "Buys"
            Me.ButtonItemMediaRates_Gross.RibbonWordWrap = False
            Me.ButtonItemMediaRates_Gross.SecurityEnabled = True
            Me.ButtonItemMediaRates_Gross.SubItemsExpandWidth = 14
            Me.ButtonItemMediaRates_Gross.Text = "Gross"
            '
            'ButtonItemMediaRates_Net
            '
            Me.ButtonItemMediaRates_Net.AutoCheckOnClick = True
            Me.ButtonItemMediaRates_Net.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaRates_Net.ImageFixedSize = New System.Drawing.Size(24, 24)
            Me.ButtonItemMediaRates_Net.Name = "ButtonItemMediaRates_Net"
            Me.ButtonItemMediaRates_Net.OptionGroup = "Buys"
            Me.ButtonItemMediaRates_Net.RibbonWordWrap = False
            Me.ButtonItemMediaRates_Net.SecurityEnabled = True
            Me.ButtonItemMediaRates_Net.SubItemsExpandWidth = 14
            Me.ButtonItemMediaRates_Net.Text = "Net"
            '
            'RibbonBarOptions_DateSettings
            '
            Me.RibbonBarOptions_DateSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DateSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DateSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DateSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DateSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DateSettings.DragDropSupport = True
            Me.RibbonBarOptions_DateSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerDateSettings_DateSettings, Me.ButtonItemDateSettings_SplitWeeks, Me.ButtonItemDateSettings_CopyHiatusSettingsFrom})
            Me.RibbonBarOptions_DateSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DateSettings.Location = New System.Drawing.Point(681, 0)
            Me.RibbonBarOptions_DateSettings.Name = "RibbonBarOptions_DateSettings"
            Me.RibbonBarOptions_DateSettings.SecurityEnabled = True
            Me.RibbonBarOptions_DateSettings.Size = New System.Drawing.Size(269, 98)
            Me.RibbonBarOptions_DateSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DateSettings.TabIndex = 5
            Me.RibbonBarOptions_DateSettings.Text = "Date Settings"
            '
            '
            '
            Me.RibbonBarOptions_DateSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DateSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DateSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerDateSettings_DateSettings
            '
            '
            '
            '
            Me.ItemContainerDateSettings_DateSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDateSettings_DateSettings.BeginGroup = True
            Me.ItemContainerDateSettings_DateSettings.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerDateSettings_DateSettings.Name = "ItemContainerDateSettings_DateSettings"
            Me.ItemContainerDateSettings_DateSettings.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDateSettings_CalendarMonth, Me.ButtonItemDateSettings_BroadcastMonth})
            '
            '
            '
            Me.ItemContainerDateSettings_DateSettings.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerDateSettings_DateSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDateSettings_CalendarMonth
            '
            Me.ButtonItemDateSettings_CalendarMonth.AutoCheckOnClick = True
            Me.ButtonItemDateSettings_CalendarMonth.BeginGroup = True
            Me.ButtonItemDateSettings_CalendarMonth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDateSettings_CalendarMonth.Checked = True
            Me.ButtonItemDateSettings_CalendarMonth.ImageFixedSize = New System.Drawing.Size(24, 24)
            Me.ButtonItemDateSettings_CalendarMonth.Name = "ButtonItemDateSettings_CalendarMonth"
            Me.ButtonItemDateSettings_CalendarMonth.OptionGroup = "DateSettings"
            Me.ButtonItemDateSettings_CalendarMonth.RibbonWordWrap = False
            Me.ButtonItemDateSettings_CalendarMonth.SecurityEnabled = True
            Me.ButtonItemDateSettings_CalendarMonth.SubItemsExpandWidth = 14
            Me.ButtonItemDateSettings_CalendarMonth.Text = "Calendar Month"
            '
            'ButtonItemDateSettings_BroadcastMonth
            '
            Me.ButtonItemDateSettings_BroadcastMonth.AutoCheckOnClick = True
            Me.ButtonItemDateSettings_BroadcastMonth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDateSettings_BroadcastMonth.ImageFixedSize = New System.Drawing.Size(24, 24)
            Me.ButtonItemDateSettings_BroadcastMonth.Name = "ButtonItemDateSettings_BroadcastMonth"
            Me.ButtonItemDateSettings_BroadcastMonth.OptionGroup = "DateSettings"
            Me.ButtonItemDateSettings_BroadcastMonth.RibbonWordWrap = False
            Me.ButtonItemDateSettings_BroadcastMonth.SecurityEnabled = True
            Me.ButtonItemDateSettings_BroadcastMonth.SubItemsExpandWidth = 14
            Me.ButtonItemDateSettings_BroadcastMonth.Text = "Broadcast Month"
            '
            'ButtonItemDateSettings_SplitWeeks
            '
            Me.ButtonItemDateSettings_SplitWeeks.AutoCheckOnClick = True
            Me.ButtonItemDateSettings_SplitWeeks.BeginGroup = True
            Me.ButtonItemDateSettings_SplitWeeks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDateSettings_SplitWeeks.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemDateSettings_SplitWeeks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDateSettings_SplitWeeks.Name = "ButtonItemDateSettings_SplitWeeks"
            Me.ButtonItemDateSettings_SplitWeeks.RibbonWordWrap = False
            Me.ButtonItemDateSettings_SplitWeeks.SecurityEnabled = True
            Me.ButtonItemDateSettings_SplitWeeks.SubItemsExpandWidth = 14
            Me.ButtonItemDateSettings_SplitWeeks.Text = "Split Weeks"
            '
            'ButtonItemDateSettings_CopyHiatusSettingsFrom
            '
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.BeginGroup = True
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.Name = "ButtonItemDateSettings_CopyHiatusSettingsFrom"
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.RibbonWordWrap = False
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.SecurityEnabled = True
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.SubItemsExpandWidth = 14
            Me.ButtonItemDateSettings_CopyHiatusSettingsFrom.Text = "<span width=""25""></span>Copy <br></br>Hiatus From"
            '
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptions_ShowHideFieldList, Me.ButtonItemGridOptions_FreezeLevels})
            Me.RibbonBarOptions_GridOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(562, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(119, 98)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 9
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemGridOptions_ShowHideFieldList
            '
            Me.ButtonItemGridOptions_ShowHideFieldList.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_ShowHideFieldList.BeginGroup = True
            Me.ButtonItemGridOptions_ShowHideFieldList.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemGridOptions_ShowHideFieldList.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemGridOptions_ShowHideFieldList.Name = "ButtonItemGridOptions_ShowHideFieldList"
            Me.ButtonItemGridOptions_ShowHideFieldList.RibbonWordWrap = False
            Me.ButtonItemGridOptions_ShowHideFieldList.SecurityEnabled = True
            Me.ButtonItemGridOptions_ShowHideFieldList.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_ShowHideFieldList.Text = "Show/Hide Field List"
            '
            'ButtonItemGridOptions_FreezeLevels
            '
            Me.ButtonItemGridOptions_FreezeLevels.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_FreezeLevels.BeginGroup = True
            Me.ButtonItemGridOptions_FreezeLevels.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemGridOptions_FreezeLevels.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemGridOptions_FreezeLevels.Name = "ButtonItemGridOptions_FreezeLevels"
            Me.ButtonItemGridOptions_FreezeLevels.RibbonWordWrap = False
            Me.ButtonItemGridOptions_FreezeLevels.SecurityEnabled = True
            Me.ButtonItemGridOptions_FreezeLevels.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_FreezeLevels.Text = "Freeze Levels"
            '
            'RibbonBarOptions_EstimateLevelsLines
            '
            Me.RibbonBarOptions_EstimateLevelsLines.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_EstimateLevelsLines.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateLevelsLines.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateLevelsLines.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_EstimateLevelsLines.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_EstimateLevelsLines.DragDropSupport = True
            Me.RibbonBarOptions_EstimateLevelsLines.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetailLevelsLines_CopyFrom, Me.ButtonItemDetailLevelsLines_ManageLevelLines})
            Me.RibbonBarOptions_EstimateLevelsLines.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_EstimateLevelsLines.Location = New System.Drawing.Point(396, 0)
            Me.RibbonBarOptions_EstimateLevelsLines.Name = "RibbonBarOptions_EstimateLevelsLines"
            Me.RibbonBarOptions_EstimateLevelsLines.SecurityEnabled = True
            Me.RibbonBarOptions_EstimateLevelsLines.Size = New System.Drawing.Size(166, 98)
            Me.RibbonBarOptions_EstimateLevelsLines.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_EstimateLevelsLines.TabIndex = 3
            Me.RibbonBarOptions_EstimateLevelsLines.Text = "Estimate Levels/Lines"
            '
            '
            '
            Me.RibbonBarOptions_EstimateLevelsLines.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EstimateLevelsLines.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EstimateLevelsLines.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDetailLevelsLines_CopyFrom
            '
            Me.ButtonItemDetailLevelsLines_CopyFrom.BeginGroup = True
            Me.ButtonItemDetailLevelsLines_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetailLevelsLines_CopyFrom.Name = "ButtonItemDetailLevelsLines_CopyFrom"
            Me.ButtonItemDetailLevelsLines_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemDetailLevelsLines_CopyFrom.SecurityEnabled = True
            Me.ButtonItemDetailLevelsLines_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemDetailLevelsLines_CopyFrom.Text = "Copy From"
            '
            'ButtonItemDetailLevelsLines_ManageLevelLines
            '
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.BeginGroup = True
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.Name = "ButtonItemDetailLevelsLines_ManageLevelLines"
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.RibbonWordWrap = False
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.SecurityEnabled = True
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.SubItemsExpandWidth = 14
            Me.ButtonItemDetailLevelsLines_ManageLevelLines.Text = "Manage Levels/Lines"
            '
            'RibbonBarOptions_MediaMix
            '
            Me.RibbonBarOptions_MediaMix.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaMix.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaMix.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaMix.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaMix.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaMix.DragDropSupport = True
            Me.RibbonBarOptions_MediaMix.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaMix_Update})
            Me.RibbonBarOptions_MediaMix.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaMix.Location = New System.Drawing.Point(326, 0)
            Me.RibbonBarOptions_MediaMix.Name = "RibbonBarOptions_MediaMix"
            Me.RibbonBarOptions_MediaMix.SecurityEnabled = True
            Me.RibbonBarOptions_MediaMix.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_MediaMix.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaMix.TabIndex = 11
            Me.RibbonBarOptions_MediaMix.Text = "Media Mix"
            '
            '
            '
            Me.RibbonBarOptions_MediaMix.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaMix.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaMix.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMediaMix_Update
            '
            Me.ButtonItemMediaMix_Update.AutoExpandOnClick = True
            Me.ButtonItemMediaMix_Update.BeginGroup = True
            Me.ButtonItemMediaMix_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaMix_Update.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemMediaMix_Update.Name = "ButtonItemMediaMix_Update"
            Me.ButtonItemMediaMix_Update.RibbonWordWrap = False
            Me.ButtonItemMediaMix_Update.SecurityEnabled = True
            Me.ButtonItemMediaMix_Update.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaMixUpdate_LevelsLines, Me.ButtonItemMediaMixUpdate_BudgetAddMissing, Me.ButtonItemMediaMixUpdate_Budget, Me.ButtonItemMediaMixUpdate_Rate})
            Me.ButtonItemMediaMix_Update.SubItemsExpandWidth = 14
            Me.ButtonItemMediaMix_Update.Text = "Update"
            '
            'ButtonItemMediaMixUpdate_LevelsLines
            '
            Me.ButtonItemMediaMixUpdate_LevelsLines.Name = "ButtonItemMediaMixUpdate_LevelsLines"
            Me.ButtonItemMediaMixUpdate_LevelsLines.Text = "Levels/Lines"
            '
            'ButtonItemMediaMixUpdate_BudgetAddMissing
            '
            Me.ButtonItemMediaMixUpdate_BudgetAddMissing.Name = "ButtonItemMediaMixUpdate_BudgetAddMissing"
            Me.ButtonItemMediaMixUpdate_BudgetAddMissing.Text = "Budget - Add Missing Dates"
            '
            'ButtonItemMediaMixUpdate_Budget
            '
            Me.ButtonItemMediaMixUpdate_Budget.Name = "ButtonItemMediaMixUpdate_Budget"
            Me.ButtonItemMediaMixUpdate_Budget.Text = "Budget"
            '
            'ButtonItemMediaMixUpdate_Rate
            '
            Me.ButtonItemMediaMixUpdate_Rate.Name = "ButtonItemMediaMixUpdate_Rate"
            Me.ButtonItemMediaMixUpdate_Rate.Text = "Rate"
            '
            'RibbonBarOptions_Estimates
            '
            Me.RibbonBarOptions_Estimates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Estimates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Estimates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Estimates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Estimates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Estimates.DragDropSupport = True
            Me.RibbonBarOptions_Estimates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerMediaPlanDetails_MediaPlanDetails, Me.ButtonItemMediaPlanDetails_Add, Me.ButtonItemMediaPlanDetails_Update, Me.ButtonItemMediaPlanDetails_Delete, Me.ButtonItemMediaPlanDetails_Copy, Me.ButtonItemMediaPlanDetails_ViewOrderDetails, Me.ButtonItemMediaPlanDetails_Approve, Me.ButtonItemMediaPlanDetails_Unapprove, Me.ButtonItemMediaPlanDetails_ChangeLogs})
            Me.RibbonBarOptions_Estimates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Estimates.Location = New System.Drawing.Point(242, 0)
            Me.RibbonBarOptions_Estimates.Name = "RibbonBarOptions_Estimates"
            Me.RibbonBarOptions_Estimates.SecurityEnabled = True
            Me.RibbonBarOptions_Estimates.Size = New System.Drawing.Size(84, 98)
            Me.RibbonBarOptions_Estimates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Estimates.TabIndex = 8
            Me.RibbonBarOptions_Estimates.Text = "Estimates"
            '
            '
            '
            Me.RibbonBarOptions_Estimates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Estimates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Estimates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerMediaPlanDetails_MediaPlanDetails
            '
            '
            '
            '
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.MinimumSize = New System.Drawing.Size(151, 0)
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.Name = "ItemContainerMediaPlanDetails_MediaPlanDetails"
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemMediaPlanDetails_MediaPlanDetails})
            '
            '
            '
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerMediaPlanDetails_MediaPlanDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemMediaPlanDetails_MediaPlanDetails
            '
            Me.ComboBoxItemMediaPlanDetails_MediaPlanDetails.ComboWidth = 150
            Me.ComboBoxItemMediaPlanDetails_MediaPlanDetails.DropDownHeight = 106
            Me.ComboBoxItemMediaPlanDetails_MediaPlanDetails.Name = "ComboBoxItemMediaPlanDetails_MediaPlanDetails"
            '
            'ButtonItemMediaPlanDetails_Add
            '
            Me.ButtonItemMediaPlanDetails_Add.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Add.Name = "ButtonItemMediaPlanDetails_Add"
            Me.ButtonItemMediaPlanDetails_Add.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Add.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Add.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Add.Text = "Add"
            '
            'ButtonItemMediaPlanDetails_Update
            '
            Me.ButtonItemMediaPlanDetails_Update.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Update.Name = "ButtonItemMediaPlanDetails_Update"
            Me.ButtonItemMediaPlanDetails_Update.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Update.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Update.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Update.Text = "Update"
            '
            'ButtonItemMediaPlanDetails_Delete
            '
            Me.ButtonItemMediaPlanDetails_Delete.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Delete.Name = "ButtonItemMediaPlanDetails_Delete"
            Me.ButtonItemMediaPlanDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Delete.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Delete.Text = "Delete"
            '
            'ButtonItemMediaPlanDetails_Copy
            '
            Me.ButtonItemMediaPlanDetails_Copy.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Copy.Name = "ButtonItemMediaPlanDetails_Copy"
            Me.ButtonItemMediaPlanDetails_Copy.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Copy.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Copy.Text = "Copy"
            '
            'ButtonItemMediaPlanDetails_ViewOrderDetails
            '
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.Name = "ButtonItemMediaPlanDetails_ViewOrderDetails"
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_ViewOrderDetails.Text = "View Order Details"
            '
            'ButtonItemMediaPlanDetails_Approve
            '
            Me.ButtonItemMediaPlanDetails_Approve.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Approve.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaPlanDetails_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Approve.Name = "ButtonItemMediaPlanDetails_Approve"
            Me.ButtonItemMediaPlanDetails_Approve.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Approve.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Approve.Text = "Approve"
            Me.ButtonItemMediaPlanDetails_Approve.Visible = False
            '
            'ButtonItemMediaPlanDetails_Unapprove
            '
            Me.ButtonItemMediaPlanDetails_Unapprove.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_Unapprove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaPlanDetails_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_Unapprove.Name = "ButtonItemMediaPlanDetails_Unapprove"
            Me.ButtonItemMediaPlanDetails_Unapprove.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_Unapprove.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_Unapprove.Text = "Unapprove"
            Me.ButtonItemMediaPlanDetails_Unapprove.Visible = False
            '
            'ButtonItemMediaPlanDetails_ChangeLogs
            '
            Me.ButtonItemMediaPlanDetails_ChangeLogs.BeginGroup = True
            Me.ButtonItemMediaPlanDetails_ChangeLogs.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaPlanDetails_ChangeLogs.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlanDetails_ChangeLogs.Name = "ButtonItemMediaPlanDetails_ChangeLogs"
            Me.ButtonItemMediaPlanDetails_ChangeLogs.RibbonWordWrap = False
            Me.ButtonItemMediaPlanDetails_ChangeLogs.SecurityEnabled = True
            Me.ButtonItemMediaPlanDetails_ChangeLogs.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlanDetails_ChangeLogs.Text = "Change Logs"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Update, Me.ButtonItemActions_Approve, Me.ButtonItemActions_Unapprove, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(242, 98)
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
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SecurityEnabled = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
            Me.ButtonItemActions_Update.Visible = False
            '
            'ButtonItemActions_Approve
            '
            Me.ButtonItemActions_Approve.BeginGroup = True
            Me.ButtonItemActions_Approve.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Approve.Name = "ButtonItemActions_Approve"
            Me.ButtonItemActions_Approve.RibbonWordWrap = False
            Me.ButtonItemActions_Approve.SecurityEnabled = True
            Me.ButtonItemActions_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Approve.Text = "Approve"
            Me.ButtonItemActions_Approve.Visible = False
            '
            'ButtonItemActions_Unapprove
            '
            Me.ButtonItemActions_Unapprove.BeginGroup = True
            Me.ButtonItemActions_Unapprove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Unapprove.Name = "ButtonItemActions_Unapprove"
            Me.ButtonItemActions_Unapprove.RibbonWordWrap = False
            Me.ButtonItemActions_Unapprove.SecurityEnabled = True
            Me.ButtonItemActions_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Unapprove.Text = "Unapprove"
            Me.ButtonItemActions_Unapprove.Visible = False
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
            'PivotGridForm_MediaPlanDetail
            '
            Me.PivotGridForm_MediaPlanDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PivotGridForm_MediaPlanDetail.Enabled = False
            Me.PivotGridForm_MediaPlanDetail.Location = New System.Drawing.Point(12, 64)
            Me.PivotGridForm_MediaPlanDetail.Name = "PivotGridForm_MediaPlanDetail"
            Me.PivotGridForm_MediaPlanDetail.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
            Me.PivotGridForm_MediaPlanDetail.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always
            Me.PivotGridForm_MediaPlanDetail.OptionsCustomization.FilterPanelVisible = DevExpress.XtraPivotGrid.FilterPanelVisible.Never
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintColumnAreaOnEveryPage = True
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintUnusedFilterFields = False
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.[True]
            Me.PivotGridForm_MediaPlanDetail.OptionsPrint.UsePrintAppearance = True
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowColumnTotals = False
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowFilterHeaders = False
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowFilterSeparatorBar = False
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowGrandTotalsForSingleValues = True
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowRowGrandTotalHeader = False
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowRowGrandTotals = False
            Me.PivotGridForm_MediaPlanDetail.OptionsView.ShowRowTotals = False
            Me.PivotGridForm_MediaPlanDetail.RetrieveFieldsOnLoadDataSource = True
            Me.PivotGridForm_MediaPlanDetail.Size = New System.Drawing.Size(691, 368)
            Me.PivotGridForm_MediaPlanDetail.TabIndex = 17
            Me.PivotGridForm_MediaPlanDetail.WriteEditValueToAllDataSourceItems = False
            '
            'ContextMenuBar
            '
            Me.ContextMenuBar.AntiAlias = True
            Me.ContextMenuBar.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.ContextMenuBar.IsMaximized = False
            Me.ContextMenuBar.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCMB_DataArea})
            Me.ContextMenuBar.Location = New System.Drawing.Point(38, 194)
            Me.ContextMenuBar.Name = "ContextMenuBar"
            Me.ContextMenuBar.Size = New System.Drawing.Size(75, 25)
            Me.ContextMenuBar.Stretch = True
            Me.ContextMenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ContextMenuBar.TabIndex = 4
            Me.ContextMenuBar.TabStop = False
            Me.ContextMenuBar.Text = "ContextMenuBar1"
            '
            'ButtonItemCMB_DataArea
            '
            Me.ButtonItemCMB_DataArea.AutoExpandOnClick = True
            Me.ButtonItemCMB_DataArea.Name = "ButtonItemCMB_DataArea"
            Me.ButtonItemCMB_DataArea.SecurityEnabled = True
            Me.ButtonItemCMB_DataArea.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDataArea_ShowHideGrandTotal, Me.ButtonItemDataArea_ShowHideTotals, Me.ButtonItemDataArea_ShowHideValues, Me.ButtonItemDataArea_SetCaption, Me.ButtonItemDataArea_SetPrefix, Me.ButtonItemDataArea_ChangeDisplayType, Me.ButtonItemDataArea_SetClearHiatus, Me.ButtonItemDataArea_AddDataByAllocating, Me.ButtonItemDataArea_SetNote, Me.ButtonItemDataArea_SetClearBlankCell, Me.ButtonItemDataArea_Hide, Me.ButtonItemDataArea_ShowFieldList, Me.ColorPickerDropDownDataArea_RowColor, Me.ButtonItemDataArea_RateCPM, Me.ButtonItemDataArea_ViewData, Me.ButtonItemDataArea_ChangeDemo})
            Me.ButtonItemCMB_DataArea.Text = "DataArea"
            '
            'ButtonItemDataArea_ShowHideGrandTotal
            '
            Me.ButtonItemDataArea_ShowHideGrandTotal.Name = "ButtonItemDataArea_ShowHideGrandTotal"
            Me.ButtonItemDataArea_ShowHideGrandTotal.SecurityEnabled = True
            Me.ButtonItemDataArea_ShowHideGrandTotal.Text = "Show Grand Total"
            '
            'ButtonItemDataArea_ShowHideTotals
            '
            Me.ButtonItemDataArea_ShowHideTotals.Name = "ButtonItemDataArea_ShowHideTotals"
            Me.ButtonItemDataArea_ShowHideTotals.SecurityEnabled = True
            Me.ButtonItemDataArea_ShowHideTotals.Text = "Show Totals"
            '
            'ButtonItemDataArea_ShowHideValues
            '
            Me.ButtonItemDataArea_ShowHideValues.Name = "ButtonItemDataArea_ShowHideValues"
            Me.ButtonItemDataArea_ShowHideValues.SecurityEnabled = True
            Me.ButtonItemDataArea_ShowHideValues.Text = "Show Values"
            '
            'ButtonItemDataArea_SetCaption
            '
            Me.ButtonItemDataArea_SetCaption.Name = "ButtonItemDataArea_SetCaption"
            Me.ButtonItemDataArea_SetCaption.SecurityEnabled = True
            Me.ButtonItemDataArea_SetCaption.Text = "Set Caption"
            '
            'ButtonItemDataArea_SetPrefix
            '
            Me.ButtonItemDataArea_SetPrefix.BeginGroup = True
            Me.ButtonItemDataArea_SetPrefix.Name = "ButtonItemDataArea_SetPrefix"
            Me.ButtonItemDataArea_SetPrefix.SecurityEnabled = True
            Me.ButtonItemDataArea_SetPrefix.Text = "Set Prefix"
            '
            'ButtonItemDataArea_ChangeDisplayType
            '
            Me.ButtonItemDataArea_ChangeDisplayType.AutoExpandOnClick = True
            Me.ButtonItemDataArea_ChangeDisplayType.Name = "ButtonItemDataArea_ChangeDisplayType"
            Me.ButtonItemDataArea_ChangeDisplayType.SecurityEnabled = True
            Me.ButtonItemDataArea_ChangeDisplayType.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemChangeDisplayType_WeekNumber, Me.ButtonItemChangeDisplayType_WeekStartDate, Me.ButtonItemChangeDisplayType_WeekStartDay})
            Me.ButtonItemDataArea_ChangeDisplayType.Text = "Change Display Type"
            '
            'ButtonItemChangeDisplayType_WeekNumber
            '
            Me.ButtonItemChangeDisplayType_WeekNumber.Name = "ButtonItemChangeDisplayType_WeekNumber"
            Me.ButtonItemChangeDisplayType_WeekNumber.SecurityEnabled = True
            Me.ButtonItemChangeDisplayType_WeekNumber.Text = "Week Number"
            '
            'ButtonItemChangeDisplayType_WeekStartDate
            '
            Me.ButtonItemChangeDisplayType_WeekStartDate.Name = "ButtonItemChangeDisplayType_WeekStartDate"
            Me.ButtonItemChangeDisplayType_WeekStartDate.SecurityEnabled = True
            Me.ButtonItemChangeDisplayType_WeekStartDate.Text = "Week Start Date - (MM/dd)"
            '
            'ButtonItemChangeDisplayType_WeekStartDay
            '
            Me.ButtonItemChangeDisplayType_WeekStartDay.Name = "ButtonItemChangeDisplayType_WeekStartDay"
            Me.ButtonItemChangeDisplayType_WeekStartDay.SecurityEnabled = True
            Me.ButtonItemChangeDisplayType_WeekStartDay.Text = "Week Start Day"
            '
            'ButtonItemDataArea_SetClearHiatus
            '
            Me.ButtonItemDataArea_SetClearHiatus.BeginGroup = True
            Me.ButtonItemDataArea_SetClearHiatus.Name = "ButtonItemDataArea_SetClearHiatus"
            Me.ButtonItemDataArea_SetClearHiatus.SecurityEnabled = True
            Me.ButtonItemDataArea_SetClearHiatus.Text = "Set Hiatus"
            '
            'ButtonItemDataArea_AddDataByAllocating
            '
            Me.ButtonItemDataArea_AddDataByAllocating.BeginGroup = True
            Me.ButtonItemDataArea_AddDataByAllocating.Name = "ButtonItemDataArea_AddDataByAllocating"
            Me.ButtonItemDataArea_AddDataByAllocating.SecurityEnabled = True
            Me.ButtonItemDataArea_AddDataByAllocating.Text = "Add Data - Allocating"
            '
            'ButtonItemDataArea_SetNote
            '
            Me.ButtonItemDataArea_SetNote.Name = "ButtonItemDataArea_SetNote"
            Me.ButtonItemDataArea_SetNote.SecurityEnabled = True
            Me.ButtonItemDataArea_SetNote.Text = "Set Note"
            '
            'ButtonItemDataArea_SetClearBlankCell
            '
            Me.ButtonItemDataArea_SetClearBlankCell.BeginGroup = True
            Me.ButtonItemDataArea_SetClearBlankCell.Name = "ButtonItemDataArea_SetClearBlankCell"
            Me.ButtonItemDataArea_SetClearBlankCell.SecurityEnabled = True
            Me.ButtonItemDataArea_SetClearBlankCell.Text = "Set Blank Cell"
            '
            'ButtonItemDataArea_Hide
            '
            Me.ButtonItemDataArea_Hide.BeginGroup = True
            Me.ButtonItemDataArea_Hide.Name = "ButtonItemDataArea_Hide"
            Me.ButtonItemDataArea_Hide.SecurityEnabled = True
            Me.ButtonItemDataArea_Hide.Text = "Hide"
            '
            'ButtonItemDataArea_ShowFieldList
            '
            Me.ButtonItemDataArea_ShowFieldList.BeginGroup = True
            Me.ButtonItemDataArea_ShowFieldList.Name = "ButtonItemDataArea_ShowFieldList"
            Me.ButtonItemDataArea_ShowFieldList.SecurityEnabled = True
            Me.ButtonItemDataArea_ShowFieldList.Text = "Show Field List"
            '
            'ColorPickerDropDownDataArea_RowColor
            '
            Me.ColorPickerDropDownDataArea_RowColor.BeginGroup = True
            Me.ColorPickerDropDownDataArea_RowColor.Name = "ColorPickerDropDownDataArea_RowColor"
            Me.ColorPickerDropDownDataArea_RowColor.Text = "Row Color"
            '
            'ButtonItemDataArea_RateCPM
            '
            Me.ButtonItemDataArea_RateCPM.AutoExpandOnClick = True
            Me.ButtonItemDataArea_RateCPM.BeginGroup = True
            Me.ButtonItemDataArea_RateCPM.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemDataArea_RateCPM.Name = "ButtonItemDataArea_RateCPM"
            Me.ButtonItemDataArea_RateCPM.SecurityEnabled = True
            Me.ButtonItemDataArea_RateCPM.Text = "Rate CPM"
            '
            'ButtonItemDataArea_ViewData
            '
            Me.ButtonItemDataArea_ViewData.BeginGroup = True
            Me.ButtonItemDataArea_ViewData.Name = "ButtonItemDataArea_ViewData"
            Me.ButtonItemDataArea_ViewData.SecurityEnabled = True
            Me.ButtonItemDataArea_ViewData.Text = "View Data"
            '
            'ButtonItemDataArea_ChangeDemo
            '
            Me.ButtonItemDataArea_ChangeDemo.BeginGroup = True
            Me.ButtonItemDataArea_ChangeDemo.Name = "ButtonItemDataArea_ChangeDemo"
            Me.ButtonItemDataArea_ChangeDemo.Text = "Change Demo"
            '
            'RibbonBarMergeContainerForm_Exporting
            '
            Me.RibbonBarMergeContainerForm_Exporting.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Exporting.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Exporting.Controls.Add(Me.RibbonBarExport_PrintOrder)
            Me.RibbonBarMergeContainerForm_Exporting.Controls.Add(Me.RibbonBarExporting_HeaderFooterImages)
            Me.RibbonBarMergeContainerForm_Exporting.Controls.Add(Me.RibbonBarExporting_Options)
            Me.RibbonBarMergeContainerForm_Exporting.Controls.Add(Me.RibbonBarExporting_Export)
            Me.RibbonBarMergeContainerForm_Exporting.Location = New System.Drawing.Point(218, 208)
            Me.RibbonBarMergeContainerForm_Exporting.MergeRibbonGroupName = "Report"
            Me.RibbonBarMergeContainerForm_Exporting.Name = "RibbonBarMergeContainerForm_Exporting"
            Me.RibbonBarMergeContainerForm_Exporting.RibbonTabText = "Printing"
            Me.RibbonBarMergeContainerForm_Exporting.Size = New System.Drawing.Size(710, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Exporting.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Exporting.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Exporting.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Exporting.TabIndex = 19
            Me.RibbonBarMergeContainerForm_Exporting.Visible = False
            '
            'RibbonBarExport_PrintOrder
            '
            Me.RibbonBarExport_PrintOrder.AutoOverflowEnabled = False
            Me.RibbonBarExport_PrintOrder.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarExport_PrintOrder.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExport_PrintOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExport_PrintOrder.ContainerControlProcessDialogKey = True
            Me.RibbonBarExport_PrintOrder.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarExport_PrintOrder.DragDropSupport = True
            Me.RibbonBarExport_PrintOrder.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarExport_PrintOrder.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrintOrder_Change})
            Me.RibbonBarExport_PrintOrder.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarExport_PrintOrder.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarExport_PrintOrder.Location = New System.Drawing.Point(534, 0)
            Me.RibbonBarExport_PrintOrder.MinimumSize = New System.Drawing.Size(120, 0)
            Me.RibbonBarExport_PrintOrder.Name = "RibbonBarExport_PrintOrder"
            Me.RibbonBarExport_PrintOrder.SecurityEnabled = True
            Me.RibbonBarExport_PrintOrder.Size = New System.Drawing.Size(120, 98)
            Me.RibbonBarExport_PrintOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarExport_PrintOrder.TabIndex = 7
            Me.RibbonBarExport_PrintOrder.Text = "Print Order"
            '
            '
            '
            Me.RibbonBarExport_PrintOrder.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExport_PrintOrder.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExport_PrintOrder.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemPrintOrder_Change
            '
            Me.ButtonItemPrintOrder_Change.BeginGroup = True
            Me.ButtonItemPrintOrder_Change.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrintOrder_Change.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrintOrder_Change.Name = "ButtonItemPrintOrder_Change"
            Me.ButtonItemPrintOrder_Change.RibbonWordWrap = False
            Me.ButtonItemPrintOrder_Change.SecurityEnabled = True
            Me.ButtonItemPrintOrder_Change.SubItemsExpandWidth = 14
            Me.ButtonItemPrintOrder_Change.Text = "Change"
            '
            'RibbonBarExporting_HeaderFooterImages
            '
            Me.RibbonBarExporting_HeaderFooterImages.AutoOverflowEnabled = False
            Me.RibbonBarExporting_HeaderFooterImages.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarExporting_HeaderFooterImages.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_HeaderFooterImages.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_HeaderFooterImages.ContainerControlProcessDialogKey = True
            Me.RibbonBarExporting_HeaderFooterImages.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarExporting_HeaderFooterImages.DragDropSupport = True
            Me.RibbonBarExporting_HeaderFooterImages.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarExporting_HeaderFooterImages.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemHeaderFooterImages_Manage})
            Me.RibbonBarExporting_HeaderFooterImages.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarExporting_HeaderFooterImages.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarExporting_HeaderFooterImages.Location = New System.Drawing.Point(414, 0)
            Me.RibbonBarExporting_HeaderFooterImages.MinimumSize = New System.Drawing.Size(120, 0)
            Me.RibbonBarExporting_HeaderFooterImages.Name = "RibbonBarExporting_HeaderFooterImages"
            Me.RibbonBarExporting_HeaderFooterImages.SecurityEnabled = True
            Me.RibbonBarExporting_HeaderFooterImages.Size = New System.Drawing.Size(120, 98)
            Me.RibbonBarExporting_HeaderFooterImages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarExporting_HeaderFooterImages.TabIndex = 5
            Me.RibbonBarExporting_HeaderFooterImages.Text = "Header/Footer Images"
            '
            '
            '
            Me.RibbonBarExporting_HeaderFooterImages.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_HeaderFooterImages.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_HeaderFooterImages.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemHeaderFooterImages_Manage
            '
            Me.ButtonItemHeaderFooterImages_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemHeaderFooterImages_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemHeaderFooterImages_Manage.Name = "ButtonItemHeaderFooterImages_Manage"
            Me.ButtonItemHeaderFooterImages_Manage.RibbonWordWrap = False
            Me.ButtonItemHeaderFooterImages_Manage.SecurityEnabled = True
            Me.ButtonItemHeaderFooterImages_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemHeaderFooterImages_Manage.Text = "Manage"
            '
            'RibbonBarExporting_Options
            '
            Me.RibbonBarExporting_Options.AutoOverflowEnabled = False
            Me.RibbonBarExporting_Options.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarExporting_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarExporting_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarExporting_Options.DragDropSupport = True
            Me.RibbonBarExporting_Options.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarExporting_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_ShowHiatusDates, Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates})
            Me.RibbonBarExporting_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarExporting_Options.Location = New System.Drawing.Point(202, 0)
            Me.RibbonBarExporting_Options.MinimumSize = New System.Drawing.Size(120, 0)
            Me.RibbonBarExporting_Options.Name = "RibbonBarExporting_Options"
            Me.RibbonBarExporting_Options.SecurityEnabled = True
            Me.RibbonBarExporting_Options.Size = New System.Drawing.Size(212, 98)
            Me.RibbonBarExporting_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarExporting_Options.TabIndex = 6
            Me.RibbonBarExporting_Options.Text = "Print Estimate Options"
            '
            '
            '
            Me.RibbonBarExporting_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOptions_ShowHiatusDates
            '
            Me.ButtonItemOptions_ShowHiatusDates.AutoCheckOnClick = True
            Me.ButtonItemOptions_ShowHiatusDates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_ShowHiatusDates.Checked = True
            Me.ButtonItemOptions_ShowHiatusDates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_ShowHiatusDates.Name = "ButtonItemOptions_ShowHiatusDates"
            Me.ButtonItemOptions_ShowHiatusDates.RibbonWordWrap = False
            Me.ButtonItemOptions_ShowHiatusDates.SecurityEnabled = True
            Me.ButtonItemOptions_ShowHiatusDates.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_ShowHiatusDates.Text = "<span width=""15""></span>Show<br></br>Hiatus Dates"
            '
            'ButtonItemOptions_AddColumnsHeadersToAllEstimates
            '
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.AutoCheckOnClick = True
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.Checked = True
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.Name = "ButtonItemOptions_AddColumnsHeadersToAllEstimates"
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.RibbonWordWrap = False
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.SecurityEnabled = True
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_AddColumnsHeadersToAllEstimates.Text = "Add Column Headers<br></br><span width=""10""></span>To All Estimates"
            '
            'RibbonBarExporting_Export
            '
            Me.RibbonBarExporting_Export.AutoOverflowEnabled = False
            Me.RibbonBarExporting_Export.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarExporting_Export.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_Export.ContainerControlProcessDialogKey = True
            Me.RibbonBarExporting_Export.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarExporting_Export.DragDropSupport = True
            Me.RibbonBarExporting_Export.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarExporting_Export.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_FlowChart, Me.ButtonItemExport_Estimate, Me.ButtonItemExport_AllEstimates})
            Me.RibbonBarExporting_Export.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarExporting_Export.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarExporting_Export.Name = "RibbonBarExporting_Export"
            Me.RibbonBarExporting_Export.SecurityEnabled = True
            Me.RibbonBarExporting_Export.Size = New System.Drawing.Size(202, 98)
            Me.RibbonBarExporting_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarExporting_Export.TabIndex = 2
            Me.RibbonBarExporting_Export.Text = "Print"
            '
            '
            '
            Me.RibbonBarExporting_Export.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarExporting_Export.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarExporting_Export.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemExport_FlowChart
            '
            Me.ButtonItemExport_FlowChart.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemExport_FlowChart.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemExport_FlowChart.Name = "ButtonItemExport_FlowChart"
            Me.ButtonItemExport_FlowChart.RibbonWordWrap = False
            Me.ButtonItemExport_FlowChart.SecurityEnabled = True
            Me.ButtonItemExport_FlowChart.SubItemsExpandWidth = 14
            Me.ButtonItemExport_FlowChart.Text = "Flow Chart"
            '
            'ButtonItemExport_Estimate
            '
            Me.ButtonItemExport_Estimate.BeginGroup = True
            Me.ButtonItemExport_Estimate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemExport_Estimate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemExport_Estimate.Name = "ButtonItemExport_Estimate"
            Me.ButtonItemExport_Estimate.RibbonWordWrap = False
            Me.ButtonItemExport_Estimate.SecurityEnabled = True
            Me.ButtonItemExport_Estimate.SubItemsExpandWidth = 14
            Me.ButtonItemExport_Estimate.Text = "Estimate"
            '
            'ButtonItemExport_AllEstimates
            '
            Me.ButtonItemExport_AllEstimates.BeginGroup = True
            Me.ButtonItemExport_AllEstimates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemExport_AllEstimates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemExport_AllEstimates.Name = "ButtonItemExport_AllEstimates"
            Me.ButtonItemExport_AllEstimates.RibbonWordWrap = False
            Me.ButtonItemExport_AllEstimates.SecurityEnabled = True
            Me.ButtonItemExport_AllEstimates.SubItemsExpandWidth = 14
            Me.ButtonItemExport_AllEstimates.Text = "All Estimates"
            '
            'RibbonBarMergeContainerForm_Process
            '
            Me.RibbonBarMergeContainerForm_Process.AutoActivateTab = False
            Me.RibbonBarMergeContainerForm_Process.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Process.Controls.Add(Me.RibbonBarProcess_Data)
            Me.RibbonBarMergeContainerForm_Process.Location = New System.Drawing.Point(10, 312)
            Me.RibbonBarMergeContainerForm_Process.MergeRibbonGroupName = "Process"
            Me.RibbonBarMergeContainerForm_Process.Name = "RibbonBarMergeContainerForm_Process"
            Me.RibbonBarMergeContainerForm_Process.RibbonTabText = "Process"
            Me.RibbonBarMergeContainerForm_Process.Size = New System.Drawing.Size(533, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Process.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Process.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Process.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Process.TabIndex = 20
            Me.RibbonBarMergeContainerForm_Process.Visible = False
            '
            'RibbonBarProcess_Data
            '
            Me.RibbonBarProcess_Data.AutoOverflowEnabled = False
            Me.RibbonBarProcess_Data.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarProcess_Data.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarProcess_Data.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarProcess_Data.ContainerControlProcessDialogKey = True
            Me.RibbonBarProcess_Data.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarProcess_Data.DragDropSupport = True
            Me.RibbonBarProcess_Data.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarProcess_Data.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemData_Export, Me.ButtonItemData_Import, Me.ButtonItemData_CreateOrders, Me.ButtonItemData_GenerateOrders, Me.ButtonItemData_OrderStatus})
            Me.RibbonBarProcess_Data.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarProcess_Data.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarProcess_Data.Name = "RibbonBarProcess_Data"
            Me.RibbonBarProcess_Data.SecurityEnabled = True
            Me.RibbonBarProcess_Data.Size = New System.Drawing.Size(390, 98)
            Me.RibbonBarProcess_Data.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarProcess_Data.TabIndex = 2
            Me.RibbonBarProcess_Data.Text = "Data"
            '
            '
            '
            Me.RibbonBarProcess_Data.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarProcess_Data.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarProcess_Data.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemData_Export
            '
            Me.ButtonItemData_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemData_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_Export.Name = "ButtonItemData_Export"
            Me.ButtonItemData_Export.RibbonWordWrap = False
            Me.ButtonItemData_Export.SecurityEnabled = True
            Me.ButtonItemData_Export.SubItemsExpandWidth = 14
            Me.ButtonItemData_Export.Text = "Export"
            '
            'ButtonItemData_Import
            '
            Me.ButtonItemData_Import.BeginGroup = True
            Me.ButtonItemData_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemData_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_Import.Name = "ButtonItemData_Import"
            Me.ButtonItemData_Import.RibbonWordWrap = False
            Me.ButtonItemData_Import.SecurityEnabled = True
            Me.ButtonItemData_Import.SubItemsExpandWidth = 14
            Me.ButtonItemData_Import.Text = "Import"
            Me.ButtonItemData_Import.Visible = False
            '
            'ButtonItemData_CreateOrders
            '
            Me.ButtonItemData_CreateOrders.BeginGroup = True
            Me.ButtonItemData_CreateOrders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemData_CreateOrders.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_CreateOrders.Name = "ButtonItemData_CreateOrders"
            Me.ButtonItemData_CreateOrders.RibbonWordWrap = False
            Me.ButtonItemData_CreateOrders.SecurityEnabled = True
            Me.ButtonItemData_CreateOrders.SubItemsExpandWidth = 14
            Me.ButtonItemData_CreateOrders.Text = "Create Orders"
            '
            'ButtonItemData_GenerateOrders
            '
            Me.ButtonItemData_GenerateOrders.BeginGroup = True
            Me.ButtonItemData_GenerateOrders.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemData_GenerateOrders.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_GenerateOrders.Name = "ButtonItemData_GenerateOrders"
            Me.ButtonItemData_GenerateOrders.RibbonWordWrap = False
            Me.ButtonItemData_GenerateOrders.SecurityEnabled = True
            Me.ButtonItemData_GenerateOrders.SubItemsExpandWidth = 14
            Me.ButtonItemData_GenerateOrders.Text = "Generate Orders"
            '
            'ButtonItemData_OrderStatus
            '
            Me.ButtonItemData_OrderStatus.BeginGroup = True
            Me.ButtonItemData_OrderStatus.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemData_OrderStatus.Name = "ButtonItemData_OrderStatus"
            Me.ButtonItemData_OrderStatus.RibbonWordWrap = False
            Me.ButtonItemData_OrderStatus.SecurityEnabled = True
            Me.ButtonItemData_OrderStatus.SubItemsExpandWidth = 14
            Me.ButtonItemData_OrderStatus.Text = "Order Status"
            '
            'LabelForm_GrossBudget
            '
            Me.LabelForm_GrossBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GrossBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GrossBudget.Location = New System.Drawing.Point(108, 12)
            Me.LabelForm_GrossBudget.Name = "LabelForm_GrossBudget"
            Me.LabelForm_GrossBudget.Size = New System.Drawing.Size(74, 20)
            Me.LabelForm_GrossBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GrossBudget.TabIndex = 1
            Me.LabelForm_GrossBudget.Text = "Budget:"
            '
            'LabelForm_GrossBudgetAmount
            '
            Me.LabelForm_GrossBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GrossBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GrossBudgetAmount.Location = New System.Drawing.Point(188, 12)
            Me.LabelForm_GrossBudgetAmount.Name = "LabelForm_GrossBudgetAmount"
            Me.LabelForm_GrossBudgetAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_GrossBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GrossBudgetAmount.TabIndex = 2
            Me.LabelForm_GrossBudgetAmount.Text = "$0.00"
            '
            'LabelForm_Billing
            '
            Me.LabelForm_Billing.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Billing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Billing.Location = New System.Drawing.Point(344, 12)
            Me.LabelForm_Billing.Name = "LabelForm_Billing"
            Me.LabelForm_Billing.Size = New System.Drawing.Size(76, 20)
            Me.LabelForm_Billing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Billing.TabIndex = 3
            Me.LabelForm_Billing.Text = "Billing Amount:"
            '
            'LabelForm_BillingAmount
            '
            Me.LabelForm_BillingAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_BillingAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_BillingAmount.Location = New System.Drawing.Point(426, 12)
            Me.LabelForm_BillingAmount.Name = "LabelForm_BillingAmount"
            Me.LabelForm_BillingAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_BillingAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_BillingAmount.TabIndex = 4
            Me.LabelForm_BillingAmount.Text = "$0.00"
            '
            'LabelForm_Variance
            '
            Me.LabelForm_Variance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Variance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Variance.Location = New System.Drawing.Point(582, 12)
            Me.LabelForm_Variance.Name = "LabelForm_Variance"
            Me.LabelForm_Variance.Size = New System.Drawing.Size(50, 20)
            Me.LabelForm_Variance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Variance.TabIndex = 5
            Me.LabelForm_Variance.Text = "Variance:"
            '
            'LabelForm_VarianceAmount
            '
            Me.LabelForm_VarianceAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VarianceAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VarianceAmount.Location = New System.Drawing.Point(638, 12)
            Me.LabelForm_VarianceAmount.Name = "LabelForm_VarianceAmount"
            Me.LabelForm_VarianceAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_VarianceAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VarianceAmount.TabIndex = 6
            Me.LabelForm_VarianceAmount.Text = "$0.00"
            '
            'LabelForm_PlanTotals
            '
            Me.LabelForm_PlanTotals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PlanTotals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PlanTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_PlanTotals.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PlanTotals.Name = "LabelForm_PlanTotals"
            Me.LabelForm_PlanTotals.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_PlanTotals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PlanTotals.TabIndex = 0
            Me.LabelForm_PlanTotals.Text = "Plan Totals"
            '
            'LabelForm_EstimateIDData
            '
            Me.LabelForm_EstimateIDData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateIDData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateIDData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateIDData.Location = New System.Drawing.Point(629, 12)
            Me.LabelForm_EstimateIDData.Name = "LabelForm_EstimateIDData"
            Me.LabelForm_EstimateIDData.Size = New System.Drawing.Size(74, 20)
            Me.LabelForm_EstimateIDData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateIDData.TabIndex = 9
            '
            'LabelForm_EstimateID
            '
            Me.LabelForm_EstimateID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EstimateID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateID.Location = New System.Drawing.Point(560, 12)
            Me.LabelForm_EstimateID.Name = "LabelForm_EstimateID"
            Me.LabelForm_EstimateID.Size = New System.Drawing.Size(63, 20)
            Me.LabelForm_EstimateID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateID.TabIndex = 8
            Me.LabelForm_EstimateID.Text = "Estimate ID:"
            '
            'ButtonForm_CalculateQty
            '
            Me.ButtonForm_CalculateQty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_CalculateQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_CalculateQty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_CalculateQty.Location = New System.Drawing.Point(469, 12)
            Me.ButtonForm_CalculateQty.Name = "ButtonForm_CalculateQty"
            Me.ButtonForm_CalculateQty.SecurityEnabled = True
            Me.ButtonForm_CalculateQty.Size = New System.Drawing.Size(85, 20)
            Me.ButtonForm_CalculateQty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_CalculateQty.TabIndex = 7
            Me.ButtonForm_CalculateQty.Text = "Calculate Qty"
            '
            'LabelForm_EstimateTotals
            '
            Me.LabelForm_EstimateTotals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateTotals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_EstimateTotals.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EstimateTotals.Name = "LabelForm_EstimateTotals"
            Me.LabelForm_EstimateTotals.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_EstimateTotals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateTotals.TabIndex = 10
            Me.LabelForm_EstimateTotals.Text = "Estimate Totals"
            '
            'LabelForm_EstimateVarianceAmount
            '
            Me.LabelForm_EstimateVarianceAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateVarianceAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateVarianceAmount.Location = New System.Drawing.Point(638, 38)
            Me.LabelForm_EstimateVarianceAmount.Name = "LabelForm_EstimateVarianceAmount"
            Me.LabelForm_EstimateVarianceAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_EstimateVarianceAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateVarianceAmount.TabIndex = 16
            Me.LabelForm_EstimateVarianceAmount.Text = "$0.00"
            '
            'LabelForm_EstimateVariance
            '
            Me.LabelForm_EstimateVariance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateVariance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateVariance.Location = New System.Drawing.Point(582, 38)
            Me.LabelForm_EstimateVariance.Name = "LabelForm_EstimateVariance"
            Me.LabelForm_EstimateVariance.Size = New System.Drawing.Size(50, 20)
            Me.LabelForm_EstimateVariance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateVariance.TabIndex = 15
            Me.LabelForm_EstimateVariance.Text = "Variance:"
            '
            'LabelForm_EstimateBillingAmount
            '
            Me.LabelForm_EstimateBillingAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateBillingAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateBillingAmount.Location = New System.Drawing.Point(426, 38)
            Me.LabelForm_EstimateBillingAmount.Name = "LabelForm_EstimateBillingAmount"
            Me.LabelForm_EstimateBillingAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_EstimateBillingAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateBillingAmount.TabIndex = 14
            Me.LabelForm_EstimateBillingAmount.Text = "$0.00"
            '
            'LabelForm_EstimateBilling
            '
            Me.LabelForm_EstimateBilling.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateBilling.Location = New System.Drawing.Point(344, 38)
            Me.LabelForm_EstimateBilling.Name = "LabelForm_EstimateBilling"
            Me.LabelForm_EstimateBilling.Size = New System.Drawing.Size(76, 20)
            Me.LabelForm_EstimateBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateBilling.TabIndex = 13
            Me.LabelForm_EstimateBilling.Text = "Billing Amount:"
            '
            'LabelForm_EstimateGrossBudgetAmount
            '
            Me.LabelForm_EstimateGrossBudgetAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateGrossBudgetAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateGrossBudgetAmount.Location = New System.Drawing.Point(188, 38)
            Me.LabelForm_EstimateGrossBudgetAmount.Name = "LabelForm_EstimateGrossBudgetAmount"
            Me.LabelForm_EstimateGrossBudgetAmount.Size = New System.Drawing.Size(150, 20)
            Me.LabelForm_EstimateGrossBudgetAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateGrossBudgetAmount.TabIndex = 12
            Me.LabelForm_EstimateGrossBudgetAmount.Text = "$0.00"
            '
            'LabelForm_EstimateGrossBudget
            '
            Me.LabelForm_EstimateGrossBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateGrossBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateGrossBudget.Location = New System.Drawing.Point(108, 38)
            Me.LabelForm_EstimateGrossBudget.Name = "LabelForm_EstimateGrossBudget"
            Me.LabelForm_EstimateGrossBudget.Size = New System.Drawing.Size(74, 20)
            Me.LabelForm_EstimateGrossBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateGrossBudget.TabIndex = 11
            Me.LabelForm_EstimateGrossBudget.Text = "Budget:"
            '
            'ToolTipController
            '
            '
            'MediaPlanEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(715, 444)
            Me.Controls.Add(Me.LabelForm_EstimateTotals)
            Me.Controls.Add(Me.LabelForm_EstimateVarianceAmount)
            Me.Controls.Add(Me.LabelForm_EstimateVariance)
            Me.Controls.Add(Me.LabelForm_EstimateBillingAmount)
            Me.Controls.Add(Me.LabelForm_EstimateBilling)
            Me.Controls.Add(Me.LabelForm_EstimateGrossBudgetAmount)
            Me.Controls.Add(Me.LabelForm_EstimateGrossBudget)
            Me.Controls.Add(Me.ButtonForm_CalculateQty)
            Me.Controls.Add(Me.LabelForm_EstimateIDData)
            Me.Controls.Add(Me.LabelForm_EstimateID)
            Me.Controls.Add(Me.LabelForm_PlanTotals)
            Me.Controls.Add(Me.LabelForm_VarianceAmount)
            Me.Controls.Add(Me.LabelForm_Variance)
            Me.Controls.Add(Me.LabelForm_BillingAmount)
            Me.Controls.Add(Me.LabelForm_Billing)
            Me.Controls.Add(Me.LabelForm_GrossBudgetAmount)
            Me.Controls.Add(Me.LabelForm_GrossBudget)
            Me.Controls.Add(Me.ContextMenuBar)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Exporting)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Process)
            Me.Controls.Add(Me.PivotGridForm_MediaPlanDetail)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanEditForm"
            Me.Text = "Media Planning"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PivotGridForm_MediaPlanDetail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ContextMenuBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Exporting.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Process.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PivotGridForm_MediaPlanDetail As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_EstimateLevelsLines As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDetailLevelsLines_ManageLevelLines As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_DateSettings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDateSettings_CalendarMonth As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDateSettings_BroadcastMonth As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_MediaRates As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemMediaRates_Gross As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaRates_Net As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Totals As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemTotals_ShowHideColumnTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ContextMenuBar As DevComponents.DotNetBar.ContextMenuBar
        Private WithEvents ButtonItemCMB_DataArea As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_Hide As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ShowFieldList As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Approve As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Unapprove As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ColorPickerDropDownDataArea_RowColor As DevComponents.DotNetBar.ColorPickerDropDown
        Private WithEvents ButtonItemDataArea_SetNote As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ViewData As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_AddDataByAllocating As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_Estimates As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ItemContainerMediaPlanDetails_MediaPlanDetails As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ComboBoxItemMediaPlanDetails_MediaPlanDetails As DevComponents.DotNetBar.ComboBoxItem
        Private WithEvents ButtonItemMediaPlanDetails_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_GridOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemGridOptions_ShowHideFieldList As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarMergeContainerForm_Exporting As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarExporting_Export As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemExport_Estimate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemExport_AllEstimates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_DataOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDataOptions_RateCPM As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_SetPrefix As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotals_TotalFields As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarMergeContainerForm_Process As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarProcess_Data As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemData_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemData_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemData_CreateOrders As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_SetCaption As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ChangeDisplayType As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ShowHideGrandTotal As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ShowHideValues As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotals_ShowHideRowTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarExporting_HeaderFooterImages As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemHeaderFooterImages_Manage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotalFields_GrossPercentageInTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotalFields_NetDollars As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotalFields_CPP1 As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotalFields_CPP2 As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemTotalFields_CPI As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemShowHideColumnTotals_GrandTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemShowHideColumnTotals_Totals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemShowHideRowTotals_GrandTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemShowHideRowTotals_Totals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_ViewOrderDetails As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents LabelForm_GrossBudget As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_GrossBudgetAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_Billing As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_BillingAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_Variance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_VarianceAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_PlanTotals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ButtonItemMediaPlanDetails_Approve As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_Unapprove As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemMediaPlanDetails_ChangeLogs As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents LabelForm_EstimateIDData As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ItemContainerDateSettings_DateSettings As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonItemDataArea_SetClearHiatus As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataOptions_ShowDaysOfWeeks As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarExporting_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemOptions_ShowHiatusDates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemShowDaysOfWeek_AsLevel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemShowDaysOfWeek_OverrideDataWithMerge As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemChangeDisplayType_WeekNumber As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemChangeDisplayType_WeekStartDate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemChangeDisplayType_WeekStartDay As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_AddColumnsHeadersToAllEstimates As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDataArea_SetClearBlankCell As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDateSettings_CopyHiatusSettingsFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemShowDaysOfWeek_OverrideDataWithoutMerge As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_CTR As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_ConversionRate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_TotalDemo1 As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_TotalDemo2 As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_ShowHideTotals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataArea_RateCPM As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonForm_CalculateQty As WinForm.Presentation.Controls.Button
        Private WithEvents ButtonItemDetailLevelsLines_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemGridOptions_FreezeLevels As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents LabelForm_EstimateTotals As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateVarianceAmount As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateVariance As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateBillingAmount As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateBilling As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateGrossBudgetAmount As WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_EstimateGrossBudget As WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataOptions_ShowPackageLevel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemShowHideRowTotals_GrandTotalsValues As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemShowHideRowTotals_TotalsValues As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents ItemContainerDataOptions_DataOptions1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerDataOptions_DataOptions2 As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonItemDataOptions_ShowDateRange As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarExport_PrintOrder As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemExport_FlowChart As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemPrintOrder_Change As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemData_GenerateOrders As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDataOptions_ShowAdSizes As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_TotalNet As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemTotalFields_Commission As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemData_OrderStatus As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDateSettings_SplitWeeks As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDataArea_ChangeDemo As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_MediaMix As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemMediaMix_Update As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaMixUpdate_LevelsLines As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaMixUpdate_BudgetAddMissing As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaMixUpdate_Rate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaMixUpdate_Budget As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
