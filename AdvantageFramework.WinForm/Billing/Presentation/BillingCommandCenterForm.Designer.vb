Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterForm))
        Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ProcessInvoices = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProcessInvoices_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_CoopSplits = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Currency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Draft = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Assign = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_Finish = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProcessInvoices_FinishDelete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaTypes_CheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMediaTypes_UncheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_MyBatches = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_OtherUserSelections = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ProductionReview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_MediaReview = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_BillingCommandCenter = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionSelection_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxProduction_JobMediaDateToBillDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxProduction_IncludeJobDateToBill = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelProductionJobMediaDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerProductionJobMedia_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerProductionJobMedia_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelProductionJobMediaDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxProduction_TypeOfJob = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionTypeOfJob_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxProduction_IncludeFinishedBatches = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxProduction_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonProductionInclude_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewProduction_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxProduction_Cutoffs = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxCutoff_LockRecords = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelProductionCutoffs_IncomeOnlyDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelProductionCutoffs_EmployeeDateTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxProduction_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonProductionSelectBy_ClientBiller = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.NumericInputProductionSelectBy_JobNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonProductionSelectBy_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_AllEligibleJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_Job = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionSelectBy_BillingApproval = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelProduction_BillingApprovalBatch = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxProduction_BillingApprovalBatch = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_BIllingApprovalBatch = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TabItemBillingCommandCenter_ProductionSelectionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaSelection_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMedia_JobMediaDateToBillDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelJobMediaDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerJobMedia_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerJobMedia_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelJobMediaDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMedia_IncludeLegacyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMedia_IncludeSpots = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMedia_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonMediaSelectBy_ClientBiller = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.NumericInputMediaSelectBy_OrderNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonMediaSelectBy_AllEligibleOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_LineNumber = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_OrderNumber = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_Market = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_ClientPO = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaSelectBy_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewMedia_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxMedia_BroadcastByMonth = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputMediaBroadcast_YearTo = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputMediaBroadcast_YearFrom = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMediaBroadcast_MonthTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxMediaBroadcast_MonthFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaBroadcast_Range = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMediaBroadcast_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaBroadcast_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMedia_Types = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePickerMediaType_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerMediaType_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelMediaType_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaType_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMediaType_TelevisionDaily = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_RadioDaily = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaType_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxMedia_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemBillingCommandCenter_MediaSelectionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_UserBatches = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SuperTooltip = New DevComponents.DotNetBar.SuperTooltip()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_BillingCommandCenter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_BillingCommandCenter.SuspendLayout()
            Me.TabControlPanelProductionSelection_Details.SuspendLayout()
            CType(Me.GroupBoxProduction_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.SuspendLayout()
            CType(Me.DateTimePickerProductionJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerProductionJobMedia_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_TypeOfJob, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_TypeOfJob.SuspendLayout()
            CType(Me.GroupBoxProduction_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_Include.SuspendLayout()
            CType(Me.GroupBoxProduction_Cutoffs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_Cutoffs.SuspendLayout()
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_SelectBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_SelectBy.SuspendLayout()
            CType(Me.NumericInputProductionSelectBy_JobNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_BIllingApprovalBatch, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelMediaSelection_Details.SuspendLayout()
            CType(Me.GroupBoxMedia_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.SuspendLayout()
            CType(Me.DateTimePickerJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerJobMedia_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMedia_SelectBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMedia_SelectBy.SuspendLayout()
            CType(Me.NumericInputMediaSelectBy_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMedia_BroadcastByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMedia_BroadcastByMonth.SuspendLayout()
            CType(Me.NumericInputMediaBroadcast_YearTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMediaBroadcast_YearFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMedia_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMedia_Types.SuspendLayout()
            CType(Me.DateTimePickerMediaType_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerMediaType_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ProcessInvoices)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1181, 98)
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
            'RibbonBarOptions_ProcessInvoices
            '
            Me.RibbonBarOptions_ProcessInvoices.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessInvoices.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ProcessInvoices.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ProcessInvoices.DragDropSupport = True
            Me.RibbonBarOptions_ProcessInvoices.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProcessInvoices_Process, Me.ButtonItemProcessInvoices_CoopSplits, Me.ButtonItemProcessInvoices_Currency, Me.ButtonItemProcessInvoices_Draft, Me.ButtonItemProcessInvoices_Assign, Me.ButtonItemProcessInvoices_Print, Me.ButtonItemProcessInvoices_Finish, Me.ButtonItemProcessInvoices_FinishDelete})
            Me.RibbonBarOptions_ProcessInvoices.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProcessInvoices.Location = New System.Drawing.Point(702, 0)
            Me.RibbonBarOptions_ProcessInvoices.Name = "RibbonBarOptions_ProcessInvoices"
            Me.RibbonBarOptions_ProcessInvoices.SecurityEnabled = True
            Me.RibbonBarOptions_ProcessInvoices.Size = New System.Drawing.Size(476, 98)
            Me.RibbonBarOptions_ProcessInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ProcessInvoices.TabIndex = 40
            Me.RibbonBarOptions_ProcessInvoices.Text = "Process Invoices"
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProcessInvoices.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProcessInvoices.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemProcessInvoices_Process
            '
            Me.ButtonItemProcessInvoices_Process.BeginGroup = True
            Me.ButtonItemProcessInvoices_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Process.Name = "ButtonItemProcessInvoices_Process"
            Me.ButtonItemProcessInvoices_Process.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Process.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Process.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Process.Text = "Process"
            '
            'ButtonItemProcessInvoices_CoopSplits
            '
            Me.ButtonItemProcessInvoices_CoopSplits.BeginGroup = True
            Me.ButtonItemProcessInvoices_CoopSplits.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_CoopSplits.Name = "ButtonItemProcessInvoices_CoopSplits"
            Me.ButtonItemProcessInvoices_CoopSplits.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_CoopSplits.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_CoopSplits.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_CoopSplits.Text = "Co-op Distribution"
            '
            'ButtonItemProcessInvoices_Currency
            '
            Me.ButtonItemProcessInvoices_Currency.BeginGroup = True
            Me.ButtonItemProcessInvoices_Currency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Currency.Name = "ButtonItemProcessInvoices_Currency"
            Me.ButtonItemProcessInvoices_Currency.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Currency.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Currency.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Currency.Text = "Currency"
            '
            'ButtonItemProcessInvoices_Draft
            '
            Me.ButtonItemProcessInvoices_Draft.BeginGroup = True
            Me.ButtonItemProcessInvoices_Draft.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Draft.Name = "ButtonItemProcessInvoices_Draft"
            Me.ButtonItemProcessInvoices_Draft.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Draft.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Draft.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Draft.Text = "Draft"
            '
            'ButtonItemProcessInvoices_Assign
            '
            Me.ButtonItemProcessInvoices_Assign.BeginGroup = True
            Me.ButtonItemProcessInvoices_Assign.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Assign.Name = "ButtonItemProcessInvoices_Assign"
            Me.ButtonItemProcessInvoices_Assign.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Assign.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Assign.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Assign.Text = "Assign"
            '
            'ButtonItemProcessInvoices_Print
            '
            Me.ButtonItemProcessInvoices_Print.BeginGroup = True
            Me.ButtonItemProcessInvoices_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Print.Name = "ButtonItemProcessInvoices_Print"
            Me.ButtonItemProcessInvoices_Print.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Print.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Print.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Print.Text = "Print"
            '
            'ButtonItemProcessInvoices_Finish
            '
            Me.ButtonItemProcessInvoices_Finish.BeginGroup = True
            Me.ButtonItemProcessInvoices_Finish.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_Finish.Name = "ButtonItemProcessInvoices_Finish"
            Me.ButtonItemProcessInvoices_Finish.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_Finish.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_Finish.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_Finish.Text = "Finish"
            '
            'ButtonItemProcessInvoices_FinishDelete
            '
            Me.ButtonItemProcessInvoices_FinishDelete.BeginGroup = True
            Me.ButtonItemProcessInvoices_FinishDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProcessInvoices_FinishDelete.Name = "ButtonItemProcessInvoices_FinishDelete"
            Me.ButtonItemProcessInvoices_FinishDelete.RibbonWordWrap = False
            Me.ButtonItemProcessInvoices_FinishDelete.SecurityEnabled = True
            Me.ButtonItemProcessInvoices_FinishDelete.SubItemsExpandWidth = 14
            Me.ButtonItemProcessInvoices_FinishDelete.Text = "Finish && Delete"
            '
            'RibbonBarOptions_MediaTypes
            '
            Me.RibbonBarOptions_MediaTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaTypes.DragDropSupport = True
            Me.RibbonBarOptions_MediaTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaTypes_CheckAll, Me.ButtonItemMediaTypes_UncheckAll})
            Me.RibbonBarOptions_MediaTypes.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_MediaTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaTypes.Location = New System.Drawing.Point(626, 0)
            Me.RibbonBarOptions_MediaTypes.Name = "RibbonBarOptions_MediaTypes"
            Me.RibbonBarOptions_MediaTypes.SecurityEnabled = True
            Me.RibbonBarOptions_MediaTypes.Size = New System.Drawing.Size(76, 98)
            Me.RibbonBarOptions_MediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaTypes.TabIndex = 35
            Me.RibbonBarOptions_MediaTypes.Text = "Media Types"
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMediaTypes_CheckAll
            '
            Me.ButtonItemMediaTypes_CheckAll.Name = "ButtonItemMediaTypes_CheckAll"
            Me.ButtonItemMediaTypes_CheckAll.SecurityEnabled = True
            Me.ButtonItemMediaTypes_CheckAll.Stretch = True
            Me.ButtonItemMediaTypes_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_CheckAll.Text = "Check All"
            '
            'ButtonItemMediaTypes_UncheckAll
            '
            Me.ButtonItemMediaTypes_UncheckAll.BeginGroup = True
            Me.ButtonItemMediaTypes_UncheckAll.Name = "ButtonItemMediaTypes_UncheckAll"
            Me.ButtonItemMediaTypes_UncheckAll.SecurityEnabled = True
            Me.ButtonItemMediaTypes_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_UncheckAll.Text = "Uncheck All"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_MyBatches, Me.ButtonItemView_OtherUserSelections, Me.ButtonItemView_ShowDescriptions, Me.ButtonItemView_ProductionReview, Me.ButtonItemView_MediaReview})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(158, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(468, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 36
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
            '
            'ButtonItemView_MyBatches
            '
            Me.ButtonItemView_MyBatches.AutoCheckOnClick = True
            Me.ButtonItemView_MyBatches.BeginGroup = True
            Me.ButtonItemView_MyBatches.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_MyBatches.Name = "ButtonItemView_MyBatches"
            Me.ButtonItemView_MyBatches.RibbonWordWrap = False
            Me.ButtonItemView_MyBatches.SecurityEnabled = True
            Me.ButtonItemView_MyBatches.SubItemsExpandWidth = 14
            Me.ButtonItemView_MyBatches.Text = "My Batches"
            '
            'ButtonItemView_OtherUserSelections
            '
            Me.ButtonItemView_OtherUserSelections.BeginGroup = True
            Me.ButtonItemView_OtherUserSelections.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_OtherUserSelections.Name = "ButtonItemView_OtherUserSelections"
            Me.ButtonItemView_OtherUserSelections.RibbonWordWrap = False
            Me.ButtonItemView_OtherUserSelections.SecurityEnabled = True
            Me.ButtonItemView_OtherUserSelections.SubItemsExpandWidth = 14
            Me.ButtonItemView_OtherUserSelections.Text = "Other User's Batches"
            '
            'ButtonItemView_ShowDescriptions
            '
            Me.ButtonItemView_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemView_ShowDescriptions.BeginGroup = True
            Me.ButtonItemView_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowDescriptions.Name = "ButtonItemView_ShowDescriptions"
            Me.ButtonItemView_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemView_ShowDescriptions.SecurityEnabled = True
            Me.ButtonItemView_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowDescriptions.Text = "Show Descriptions"
            '
            'ButtonItemView_ProductionReview
            '
            Me.ButtonItemView_ProductionReview.BeginGroup = True
            Me.ButtonItemView_ProductionReview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ProductionReview.Name = "ButtonItemView_ProductionReview"
            Me.ButtonItemView_ProductionReview.RibbonWordWrap = False
            Me.ButtonItemView_ProductionReview.SecurityEnabled = True
            Me.ButtonItemView_ProductionReview.SubItemsExpandWidth = 14
            Me.ButtonItemView_ProductionReview.Text = "Production Review"
            '
            'ButtonItemView_MediaReview
            '
            Me.ButtonItemView_MediaReview.BeginGroup = True
            Me.ButtonItemView_MediaReview.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_MediaReview.Name = "ButtonItemView_MediaReview"
            Me.ButtonItemView_MediaReview.RibbonWordWrap = False
            Me.ButtonItemView_MediaReview.SecurityEnabled = True
            Me.ButtonItemView_MediaReview.SubItemsExpandWidth = 14
            Me.ButtonItemView_MediaReview.Text = "Media Review"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Edit, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(158, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 39
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
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Edit
            '
            Me.ButtonItemActions_Edit.BeginGroup = True
            Me.ButtonItemActions_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Edit.Name = "ButtonItemActions_Edit"
            Me.ButtonItemActions_Edit.RibbonWordWrap = False
            Me.ButtonItemActions_Edit.SecurityEnabled = True
            Me.ButtonItemActions_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Edit.Text = "Edit"
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
            'TabControlForm_BillingCommandCenter
            '
            Me.TabControlForm_BillingCommandCenter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_BillingCommandCenter.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_BillingCommandCenter.CanReorderTabs = False
            Me.TabControlForm_BillingCommandCenter.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_BillingCommandCenter.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_BillingCommandCenter.Controls.Add(Me.TabControlPanelProductionSelection_Details)
            Me.TabControlForm_BillingCommandCenter.Controls.Add(Me.TabControlPanelMediaSelection_Details)
            Me.TabControlForm_BillingCommandCenter.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_BillingCommandCenter.Location = New System.Drawing.Point(6, 12)
            Me.TabControlForm_BillingCommandCenter.Name = "TabControlForm_BillingCommandCenter"
            Me.TabControlForm_BillingCommandCenter.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_BillingCommandCenter.SelectedTabIndex = 0
            Me.TabControlForm_BillingCommandCenter.Size = New System.Drawing.Size(1016, 667)
            Me.TabControlForm_BillingCommandCenter.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_BillingCommandCenter.TabIndex = 0
            Me.TabControlForm_BillingCommandCenter.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_BillingCommandCenter.Tabs.Add(Me.TabItemBillingCommandCenter_ProductionSelectionTab)
            Me.TabControlForm_BillingCommandCenter.Tabs.Add(Me.TabItemBillingCommandCenter_MediaSelectionTab)
            Me.TabControlForm_BillingCommandCenter.TabStop = False
            '
            'TabControlPanelProductionSelection_Details
            '
            Me.TabControlPanelProductionSelection_Details.AutoScroll = True
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.GroupBoxProduction_JobMediaDateToBillDateRange)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.GroupBoxProduction_TypeOfJob)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.CheckBoxProduction_IncludeFinishedBatches)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.GroupBoxProduction_Include)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.DataGridViewProduction_Selections)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.GroupBoxProduction_Cutoffs)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.GroupBoxProduction_SelectBy)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.LabelProduction_BillingApprovalBatch)
            Me.TabControlPanelProductionSelection_Details.Controls.Add(Me.SearchableComboBoxProduction_BillingApprovalBatch)
            Me.TabControlPanelProductionSelection_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelection_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelection_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelection_Details.Name = "TabControlPanelProductionSelection_Details"
            Me.TabControlPanelProductionSelection_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelection_Details.Size = New System.Drawing.Size(1016, 640)
            Me.TabControlPanelProductionSelection_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelection_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelection_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelection_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelection_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelection_Details.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelection_Details.TabIndex = 0
            Me.TabControlPanelProductionSelection_Details.TabItem = Me.TabItemBillingCommandCenter_ProductionSelectionTab
            '
            'GroupBoxProduction_JobMediaDateToBillDateRange
            '
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Controls.Add(Me.CheckBoxProduction_IncludeJobDateToBill)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Controls.Add(Me.LabelProductionJobMediaDateRange_From)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerProductionJobMedia_DateFrom)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerProductionJobMedia_DateTo)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Controls.Add(Me.LabelProductionJobMediaDateRange_To)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Location = New System.Drawing.Point(4, 585)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Name = "GroupBoxProduction_JobMediaDateToBillDateRange"
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Size = New System.Drawing.Size(362, 52)
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.TabIndex = 6
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.Text = "Job or Media Date to Bill"
            '
            'CheckBoxProduction_IncludeJobDateToBill
            '
            Me.CheckBoxProduction_IncludeJobDateToBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProduction_IncludeJobDateToBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_IncludeJobDateToBill.CheckValue = 0
            Me.CheckBoxProduction_IncludeJobDateToBill.CheckValueChecked = 1
            Me.CheckBoxProduction_IncludeJobDateToBill.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxProduction_IncludeJobDateToBill.CheckValueUnchecked = 0
            Me.CheckBoxProduction_IncludeJobDateToBill.ChildControls = Nothing
            Me.CheckBoxProduction_IncludeJobDateToBill.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_IncludeJobDateToBill.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxProduction_IncludeJobDateToBill.Name = "CheckBoxProduction_IncludeJobDateToBill"
            Me.CheckBoxProduction_IncludeJobDateToBill.OldestSibling = Nothing
            Me.CheckBoxProduction_IncludeJobDateToBill.SecurityEnabled = True
            Me.CheckBoxProduction_IncludeJobDateToBill.SiblingControls = Nothing
            Me.CheckBoxProduction_IncludeJobDateToBill.Size = New System.Drawing.Size(65, 20)
            Me.CheckBoxProduction_IncludeJobDateToBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_IncludeJobDateToBill.TabIndex = 0
            Me.CheckBoxProduction_IncludeJobDateToBill.TabOnEnter = True
            Me.CheckBoxProduction_IncludeJobDateToBill.Text = "Include"
            '
            'LabelProductionJobMediaDateRange_From
            '
            Me.LabelProductionJobMediaDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionJobMediaDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionJobMediaDateRange_From.Location = New System.Drawing.Point(87, 24)
            Me.LabelProductionJobMediaDateRange_From.Name = "LabelProductionJobMediaDateRange_From"
            Me.LabelProductionJobMediaDateRange_From.Size = New System.Drawing.Size(38, 20)
            Me.LabelProductionJobMediaDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionJobMediaDateRange_From.TabIndex = 1
            Me.LabelProductionJobMediaDateRange_From.Text = "From:"
            '
            'DateTimePickerProductionJobMedia_DateFrom
            '
            Me.DateTimePickerProductionJobMedia_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionJobMedia_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionJobMedia_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionJobMedia_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionJobMedia_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerProductionJobMedia_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionJobMedia_DateFrom.DisplayName = ""
            Me.DateTimePickerProductionJobMedia_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionJobMedia_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionJobMedia_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerProductionJobMedia_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerProductionJobMedia_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionJobMedia_DateFrom.Location = New System.Drawing.Point(131, 24)
            Me.DateTimePickerProductionJobMedia_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionJobMedia_DateFrom.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionJobMedia_DateFrom.Name = "DateTimePickerProductionJobMedia_DateFrom"
            Me.DateTimePickerProductionJobMedia_DateFrom.ReadOnly = False
            Me.DateTimePickerProductionJobMedia_DateFrom.Size = New System.Drawing.Size(81, 21)
            Me.DateTimePickerProductionJobMedia_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionJobMedia_DateFrom.TabIndex = 2
            Me.DateTimePickerProductionJobMedia_DateFrom.TabOnEnter = True
            Me.DateTimePickerProductionJobMedia_DateFrom.Value = New Date(2013, 7, 23, 13, 58, 57, 366)
            '
            'DateTimePickerProductionJobMedia_DateTo
            '
            Me.DateTimePickerProductionJobMedia_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionJobMedia_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionJobMedia_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionJobMedia_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionJobMedia_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerProductionJobMedia_DateTo.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerProductionJobMedia_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionJobMedia_DateTo.DisplayName = ""
            Me.DateTimePickerProductionJobMedia_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionJobMedia_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionJobMedia_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerProductionJobMedia_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerProductionJobMedia_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionJobMedia_DateTo.Location = New System.Drawing.Point(253, 24)
            Me.DateTimePickerProductionJobMedia_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionJobMedia_DateTo.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionJobMedia_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionJobMedia_DateTo.Name = "DateTimePickerProductionJobMedia_DateTo"
            Me.DateTimePickerProductionJobMedia_DateTo.ReadOnly = False
            Me.DateTimePickerProductionJobMedia_DateTo.Size = New System.Drawing.Size(81, 21)
            Me.DateTimePickerProductionJobMedia_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionJobMedia_DateTo.TabIndex = 4
            Me.DateTimePickerProductionJobMedia_DateTo.TabOnEnter = True
            Me.DateTimePickerProductionJobMedia_DateTo.Value = New Date(2014, 4, 18, 14, 11, 55, 950)
            '
            'LabelProductionJobMediaDateRange_To
            '
            Me.LabelProductionJobMediaDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionJobMediaDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionJobMediaDateRange_To.Location = New System.Drawing.Point(218, 24)
            Me.LabelProductionJobMediaDateRange_To.Name = "LabelProductionJobMediaDateRange_To"
            Me.LabelProductionJobMediaDateRange_To.Size = New System.Drawing.Size(29, 20)
            Me.LabelProductionJobMediaDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionJobMediaDateRange_To.TabIndex = 3
            Me.LabelProductionJobMediaDateRange_To.Text = "To:"
            '
            'GroupBoxProduction_TypeOfJob
            '
            Me.GroupBoxProduction_TypeOfJob.Controls.Add(Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly)
            Me.GroupBoxProduction_TypeOfJob.Controls.Add(Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly)
            Me.GroupBoxProduction_TypeOfJob.Controls.Add(Me.RadioButtonProductionTypeOfJob_All)
            Me.GroupBoxProduction_TypeOfJob.Location = New System.Drawing.Point(4, 361)
            Me.GroupBoxProduction_TypeOfJob.Name = "GroupBoxProduction_TypeOfJob"
            Me.GroupBoxProduction_TypeOfJob.Size = New System.Drawing.Size(362, 106)
            Me.GroupBoxProduction_TypeOfJob.TabIndex = 4
            Me.GroupBoxProduction_TypeOfJob.Text = "Type of Job"
            '
            'RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly
            '
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Name = "RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly"
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabIndex = 2
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabStop = False
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Tag = "3"
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Text = "Service Fee  Jobs Only"
            '
            'RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly
            '
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Name = "RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly"
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabIndex = 1
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabStop = False
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Tag = "2"
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Text = "Advance Bill Jobs Only"
            '
            'RadioButtonProductionTypeOfJob_All
            '
            Me.RadioButtonProductionTypeOfJob_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_All.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonProductionTypeOfJob_All.Name = "RadioButtonProductionTypeOfJob_All"
            Me.RadioButtonProductionTypeOfJob_All.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_All.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionTypeOfJob_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_All.TabIndex = 0
            Me.RadioButtonProductionTypeOfJob_All.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_All.TabStop = False
            Me.RadioButtonProductionTypeOfJob_All.Tag = "1"
            Me.RadioButtonProductionTypeOfJob_All.Text = "All"
            '
            'CheckBoxProduction_IncludeFinishedBatches
            '
            Me.CheckBoxProduction_IncludeFinishedBatches.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProduction_IncludeFinishedBatches.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_IncludeFinishedBatches.CheckValue = 0
            Me.CheckBoxProduction_IncludeFinishedBatches.CheckValueChecked = 1
            Me.CheckBoxProduction_IncludeFinishedBatches.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxProduction_IncludeFinishedBatches.CheckValueUnchecked = 0
            Me.CheckBoxProduction_IncludeFinishedBatches.ChildControls = Nothing
            Me.CheckBoxProduction_IncludeFinishedBatches.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_IncludeFinishedBatches.Location = New System.Drawing.Point(372, 4)
            Me.CheckBoxProduction_IncludeFinishedBatches.Name = "CheckBoxProduction_IncludeFinishedBatches"
            Me.CheckBoxProduction_IncludeFinishedBatches.OldestSibling = Nothing
            Me.CheckBoxProduction_IncludeFinishedBatches.SecurityEnabled = True
            Me.CheckBoxProduction_IncludeFinishedBatches.SiblingControls = Nothing
            Me.CheckBoxProduction_IncludeFinishedBatches.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxProduction_IncludeFinishedBatches.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_IncludeFinishedBatches.TabIndex = 1
            Me.CheckBoxProduction_IncludeFinishedBatches.TabOnEnter = True
            Me.CheckBoxProduction_IncludeFinishedBatches.Text = "Include Finished Batches?"
            '
            'GroupBoxProduction_Include
            '
            Me.GroupBoxProduction_Include.Controls.Add(Me.RadioButtonProductionInclude_OpenJobs)
            Me.GroupBoxProduction_Include.Controls.Add(Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly)
            Me.GroupBoxProduction_Include.Controls.Add(Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords)
            Me.GroupBoxProduction_Include.Location = New System.Drawing.Point(4, 473)
            Me.GroupBoxProduction_Include.Name = "GroupBoxProduction_Include"
            Me.GroupBoxProduction_Include.Size = New System.Drawing.Size(362, 106)
            Me.GroupBoxProduction_Include.TabIndex = 5
            Me.GroupBoxProduction_Include.Text = "Include"
            '
            'RadioButtonProductionInclude_OpenJobs
            '
            Me.RadioButtonProductionInclude_OpenJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionInclude_OpenJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionInclude_OpenJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionInclude_OpenJobs.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonProductionInclude_OpenJobs.Name = "RadioButtonProductionInclude_OpenJobs"
            Me.RadioButtonProductionInclude_OpenJobs.SecurityEnabled = True
            Me.RadioButtonProductionInclude_OpenJobs.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionInclude_OpenJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionInclude_OpenJobs.TabIndex = 2
            Me.RadioButtonProductionInclude_OpenJobs.TabOnEnter = True
            Me.RadioButtonProductionInclude_OpenJobs.TabStop = False
            Me.RadioButtonProductionInclude_OpenJobs.Tag = "4"
            Me.RadioButtonProductionInclude_OpenJobs.Text = "Open Jobs"
            '
            'RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly
            '
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Name = "RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly"
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.SecurityEnabled = True
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.TabIndex = 1
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.TabOnEnter = True
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.TabStop = False
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Tag = "2"
            Me.RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly.Text = "Open Jobs with Unbilled Records Only"
            '
            'RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords
            '
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Name = "RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords"
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.SecurityEnabled = True
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Size = New System.Drawing.Size(352, 20)
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.TabIndex = 0
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.TabOnEnter = True
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.TabStop = False
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Tag = "1"
            Me.RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords.Text = "Open Jobs with Unbilled and Other Records"
            '
            'DataGridViewProduction_Selections
            '
            Me.DataGridViewProduction_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewProduction_Selections.AllowDragAndDrop = False
            Me.DataGridViewProduction_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewProduction_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProduction_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewProduction_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProduction_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewProduction_Selections.AutoloadRepositoryDatasource = True
            Me.DataGridViewProduction_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewProduction_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewProduction_Selections.DataSource = Nothing
            Me.DataGridViewProduction_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewProduction_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProduction_Selections.ItemDescription = ""
            Me.DataGridViewProduction_Selections.Location = New System.Drawing.Point(373, 30)
            Me.DataGridViewProduction_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewProduction_Selections.MultiSelect = True
            Me.DataGridViewProduction_Selections.Name = "DataGridViewProduction_Selections"
            Me.DataGridViewProduction_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewProduction_Selections.RunStandardValidation = True
            Me.DataGridViewProduction_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewProduction_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProduction_Selections.Size = New System.Drawing.Size(638, 606)
            Me.DataGridViewProduction_Selections.TabIndex = 7
            Me.DataGridViewProduction_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewProduction_Selections.ViewCaptionHeight = -1
            '
            'GroupBoxProduction_Cutoffs
            '
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.CheckBoxCutoff_LockRecords)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.LabelProductionCutoffs_IncomeOnlyDate)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.ComboBoxProductionCutoffs_APPostingPeriod)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.LabelProductionCutoffs_EmployeeDateTime)
            Me.GroupBoxProduction_Cutoffs.Controls.Add(Me.LabelProductionCutoffs_APPostingPeriod)
            Me.GroupBoxProduction_Cutoffs.Location = New System.Drawing.Point(4, 221)
            Me.GroupBoxProduction_Cutoffs.Name = "GroupBoxProduction_Cutoffs"
            Me.GroupBoxProduction_Cutoffs.Size = New System.Drawing.Size(362, 134)
            Me.GroupBoxProduction_Cutoffs.TabIndex = 3
            Me.GroupBoxProduction_Cutoffs.Text = "Cutoffs"
            '
            'CheckBoxCutoff_LockRecords
            '
            Me.CheckBoxCutoff_LockRecords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCutoff_LockRecords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCutoff_LockRecords.CheckValue = 0
            Me.CheckBoxCutoff_LockRecords.CheckValueChecked = 1
            Me.CheckBoxCutoff_LockRecords.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCutoff_LockRecords.CheckValueUnchecked = 0
            Me.CheckBoxCutoff_LockRecords.ChildControls = Nothing
            Me.CheckBoxCutoff_LockRecords.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCutoff_LockRecords.Location = New System.Drawing.Point(131, 103)
            Me.CheckBoxCutoff_LockRecords.Name = "CheckBoxCutoff_LockRecords"
            Me.CheckBoxCutoff_LockRecords.OldestSibling = Nothing
            Me.CheckBoxCutoff_LockRecords.SecurityEnabled = True
            Me.CheckBoxCutoff_LockRecords.SiblingControls = Nothing
            Me.CheckBoxCutoff_LockRecords.Size = New System.Drawing.Size(97, 20)
            Me.CheckBoxCutoff_LockRecords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCutoff_LockRecords.TabIndex = 28
            Me.CheckBoxCutoff_LockRecords.TabOnEnter = True
            Me.CheckBoxCutoff_LockRecords.Text = "Lock Records"
            '
            'DateTimePickerProductionCutoffs_IncomeOnlyTimeDate
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisplayName = ""
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FocusHighlightEnabled = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.FreeTextEntryMode = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Location = New System.Drawing.Point(131, 50)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Name = "DateTimePickerProductionCutoffs_IncomeOnlyTimeDate"
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.ReadOnly = False
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabIndex = 3
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'LabelProductionCutoffs_IncomeOnlyDate
            '
            Me.LabelProductionCutoffs_IncomeOnlyDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionCutoffs_IncomeOnlyDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionCutoffs_IncomeOnlyDate.Location = New System.Drawing.Point(5, 50)
            Me.LabelProductionCutoffs_IncomeOnlyDate.Name = "LabelProductionCutoffs_IncomeOnlyDate"
            Me.LabelProductionCutoffs_IncomeOnlyDate.Size = New System.Drawing.Size(120, 20)
            Me.LabelProductionCutoffs_IncomeOnlyDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionCutoffs_IncomeOnlyDate.TabIndex = 2
            Me.LabelProductionCutoffs_IncomeOnlyDate.Text = "Income Only Date:"
            '
            'ComboBoxProductionCutoffs_APPostingPeriod
            '
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ClientCode = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisableMouseWheel = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisplayMember = "Description"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DisplayName = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DivisionCode = ""
            Me.ComboBoxProductionCutoffs_APPostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FormattingEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ItemHeight = 16
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Location = New System.Drawing.Point(131, 76)
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Name = "ComboBoxProductionCutoffs_APPostingPeriod"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ReadOnly = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.SecurityEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Size = New System.Drawing.Size(135, 22)
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProductionCutoffs_APPostingPeriod.TabIndex = 5
            Me.ComboBoxProductionCutoffs_APPostingPeriod.TabOnEnter = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ValueMember = "Code"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.WatermarkText = "Select Post Period"
            '
            'DateTimePickerProductionCutoffs_EmployeeTimeDate
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonDropDown.Visible = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ButtonFreeText.Checked = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DisplayName = ""
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FocusHighlightEnabled = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.FreeTextEntryMode = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.IsPopupCalendarOpen = False
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Location = New System.Drawing.Point(131, 24)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Name = "DateTimePickerProductionCutoffs_EmployeeTimeDate"
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.ReadOnly = False
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabIndex = 1
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'LabelProductionCutoffs_EmployeeDateTime
            '
            Me.LabelProductionCutoffs_EmployeeDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionCutoffs_EmployeeDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionCutoffs_EmployeeDateTime.Location = New System.Drawing.Point(5, 24)
            Me.LabelProductionCutoffs_EmployeeDateTime.Name = "LabelProductionCutoffs_EmployeeDateTime"
            Me.LabelProductionCutoffs_EmployeeDateTime.Size = New System.Drawing.Size(120, 20)
            Me.LabelProductionCutoffs_EmployeeDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionCutoffs_EmployeeDateTime.TabIndex = 0
            Me.LabelProductionCutoffs_EmployeeDateTime.Text = "Employee Time Date:"
            '
            'LabelProductionCutoffs_APPostingPeriod
            '
            Me.LabelProductionCutoffs_APPostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionCutoffs_APPostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionCutoffs_APPostingPeriod.Location = New System.Drawing.Point(5, 76)
            Me.LabelProductionCutoffs_APPostingPeriod.Name = "LabelProductionCutoffs_APPostingPeriod"
            Me.LabelProductionCutoffs_APPostingPeriod.Size = New System.Drawing.Size(120, 20)
            Me.LabelProductionCutoffs_APPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionCutoffs_APPostingPeriod.TabIndex = 4
            Me.LabelProductionCutoffs_APPostingPeriod.Text = "A/P Posting Period:"
            '
            'GroupBoxProduction_SelectBy
            '
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_ClientBiller)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.NumericInputProductionSelectBy_JobNumber)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_SalesClass)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_AllEligibleJobs)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_JobComponent)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_Job)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_Campaign)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_ClientDivisionProduct)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_ClientDivision)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_Client)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_AccountExecutive)
            Me.GroupBoxProduction_SelectBy.Controls.Add(Me.RadioButtonProductionSelectBy_BillingApproval)
            Me.GroupBoxProduction_SelectBy.Location = New System.Drawing.Point(4, 30)
            Me.GroupBoxProduction_SelectBy.Name = "GroupBoxProduction_SelectBy"
            Me.GroupBoxProduction_SelectBy.Size = New System.Drawing.Size(362, 185)
            Me.GroupBoxProduction_SelectBy.TabIndex = 2
            Me.GroupBoxProduction_SelectBy.Text = "Select By"
            '
            'RadioButtonProductionSelectBy_ClientBiller
            '
            Me.RadioButtonProductionSelectBy_ClientBiller.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_ClientBiller.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_ClientBiller.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_ClientBiller.Location = New System.Drawing.Point(180, 24)
            Me.RadioButtonProductionSelectBy_ClientBiller.Name = "RadioButtonProductionSelectBy_ClientBiller"
            Me.RadioButtonProductionSelectBy_ClientBiller.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_ClientBiller.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_ClientBiller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_ClientBiller.TabIndex = 6
            Me.RadioButtonProductionSelectBy_ClientBiller.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_ClientBiller.TabStop = False
            Me.RadioButtonProductionSelectBy_ClientBiller.Tag = "11"
            Me.RadioButtonProductionSelectBy_ClientBiller.Text = "Client Biller"
            '
            'NumericInputProductionSelectBy_JobNumber
            '
            Me.NumericInputProductionSelectBy_JobNumber.AllowDrop = True
            Me.NumericInputProductionSelectBy_JobNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputProductionSelectBy_JobNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputProductionSelectBy_JobNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputProductionSelectBy_JobNumber.EnterMoveNextControl = True
            Me.NumericInputProductionSelectBy_JobNumber.Location = New System.Drawing.Point(265, 102)
            Me.NumericInputProductionSelectBy_JobNumber.Name = "NumericInputProductionSelectBy_JobNumber"
            Me.NumericInputProductionSelectBy_JobNumber.Properties.AllowMouseWheel = False
            Me.NumericInputProductionSelectBy_JobNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputProductionSelectBy_JobNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputProductionSelectBy_JobNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputProductionSelectBy_JobNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProductionSelectBy_JobNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputProductionSelectBy_JobNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProductionSelectBy_JobNumber.Properties.IsFloatValue = False
            Me.NumericInputProductionSelectBy_JobNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputProductionSelectBy_JobNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputProductionSelectBy_JobNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputProductionSelectBy_JobNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputProductionSelectBy_JobNumber.SecurityEnabled = True
            Me.NumericInputProductionSelectBy_JobNumber.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputProductionSelectBy_JobNumber.TabIndex = 0
            Me.NumericInputProductionSelectBy_JobNumber.TabStop = False
            '
            'RadioButtonProductionSelectBy_SalesClass
            '
            Me.RadioButtonProductionSelectBy_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_SalesClass.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_SalesClass.Location = New System.Drawing.Point(180, 50)
            Me.RadioButtonProductionSelectBy_SalesClass.Name = "RadioButtonProductionSelectBy_SalesClass"
            Me.RadioButtonProductionSelectBy_SalesClass.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_SalesClass.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_SalesClass.TabIndex = 7
            Me.RadioButtonProductionSelectBy_SalesClass.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_SalesClass.TabStop = False
            Me.RadioButtonProductionSelectBy_SalesClass.Tag = "9"
            Me.RadioButtonProductionSelectBy_SalesClass.Text = "Sales Class"
            '
            'RadioButtonProductionSelectBy_AllEligibleJobs
            '
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Name = "RadioButtonProductionSelectBy_AllEligibleJobs"
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.TabIndex = 0
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.TabStop = False
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Tag = "0"
            Me.RadioButtonProductionSelectBy_AllEligibleJobs.Text = "All Eligible Jobs"
            '
            'RadioButtonProductionSelectBy_JobComponent
            '
            Me.RadioButtonProductionSelectBy_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_JobComponent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_JobComponent.Location = New System.Drawing.Point(180, 128)
            Me.RadioButtonProductionSelectBy_JobComponent.Name = "RadioButtonProductionSelectBy_JobComponent"
            Me.RadioButtonProductionSelectBy_JobComponent.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_JobComponent.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_JobComponent.TabIndex = 10
            Me.RadioButtonProductionSelectBy_JobComponent.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_JobComponent.TabStop = False
            Me.RadioButtonProductionSelectBy_JobComponent.Tag = "7"
            Me.RadioButtonProductionSelectBy_JobComponent.Text = "Job Component"
            '
            'RadioButtonProductionSelectBy_Job
            '
            Me.RadioButtonProductionSelectBy_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_Job.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_Job.Location = New System.Drawing.Point(180, 102)
            Me.RadioButtonProductionSelectBy_Job.Name = "RadioButtonProductionSelectBy_Job"
            Me.RadioButtonProductionSelectBy_Job.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_Job.Size = New System.Drawing.Size(79, 20)
            Me.RadioButtonProductionSelectBy_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_Job.TabIndex = 9
            Me.RadioButtonProductionSelectBy_Job.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_Job.TabStop = False
            Me.RadioButtonProductionSelectBy_Job.Tag = "6"
            Me.RadioButtonProductionSelectBy_Job.Text = "Job"
            '
            'RadioButtonProductionSelectBy_Campaign
            '
            Me.RadioButtonProductionSelectBy_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_Campaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_Campaign.Location = New System.Drawing.Point(180, 76)
            Me.RadioButtonProductionSelectBy_Campaign.Name = "RadioButtonProductionSelectBy_Campaign"
            Me.RadioButtonProductionSelectBy_Campaign.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_Campaign.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_Campaign.TabIndex = 8
            Me.RadioButtonProductionSelectBy_Campaign.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_Campaign.TabStop = False
            Me.RadioButtonProductionSelectBy_Campaign.Tag = "5"
            Me.RadioButtonProductionSelectBy_Campaign.Text = "Campaign"
            '
            'RadioButtonProductionSelectBy_ClientDivisionProduct
            '
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Location = New System.Drawing.Point(5, 154)
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Name = "RadioButtonProductionSelectBy_ClientDivisionProduct"
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.TabIndex = 5
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.TabStop = False
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Tag = "4"
            Me.RadioButtonProductionSelectBy_ClientDivisionProduct.Text = "Client / Division / Product"
            '
            'RadioButtonProductionSelectBy_ClientDivision
            '
            Me.RadioButtonProductionSelectBy_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_ClientDivision.Location = New System.Drawing.Point(5, 128)
            Me.RadioButtonProductionSelectBy_ClientDivision.Name = "RadioButtonProductionSelectBy_ClientDivision"
            Me.RadioButtonProductionSelectBy_ClientDivision.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_ClientDivision.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_ClientDivision.TabIndex = 4
            Me.RadioButtonProductionSelectBy_ClientDivision.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_ClientDivision.TabStop = False
            Me.RadioButtonProductionSelectBy_ClientDivision.Tag = "3"
            Me.RadioButtonProductionSelectBy_ClientDivision.Text = "Client / Division"
            '
            'RadioButtonProductionSelectBy_Client
            '
            Me.RadioButtonProductionSelectBy_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_Client.Location = New System.Drawing.Point(5, 102)
            Me.RadioButtonProductionSelectBy_Client.Name = "RadioButtonProductionSelectBy_Client"
            Me.RadioButtonProductionSelectBy_Client.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_Client.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_Client.TabIndex = 3
            Me.RadioButtonProductionSelectBy_Client.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_Client.TabStop = False
            Me.RadioButtonProductionSelectBy_Client.Tag = "2"
            Me.RadioButtonProductionSelectBy_Client.Text = "Client"
            '
            'RadioButtonProductionSelectBy_AccountExecutive
            '
            Me.RadioButtonProductionSelectBy_AccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_AccountExecutive.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_AccountExecutive.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonProductionSelectBy_AccountExecutive.Name = "RadioButtonProductionSelectBy_AccountExecutive"
            Me.RadioButtonProductionSelectBy_AccountExecutive.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_AccountExecutive.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_AccountExecutive.TabIndex = 2
            Me.RadioButtonProductionSelectBy_AccountExecutive.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_AccountExecutive.TabStop = False
            Me.RadioButtonProductionSelectBy_AccountExecutive.Tag = "10"
            Me.RadioButtonProductionSelectBy_AccountExecutive.Text = "Account Executive"
            '
            'RadioButtonProductionSelectBy_BillingApproval
            '
            Me.RadioButtonProductionSelectBy_BillingApproval.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionSelectBy_BillingApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionSelectBy_BillingApproval.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionSelectBy_BillingApproval.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonProductionSelectBy_BillingApproval.Name = "RadioButtonProductionSelectBy_BillingApproval"
            Me.RadioButtonProductionSelectBy_BillingApproval.SecurityEnabled = True
            Me.RadioButtonProductionSelectBy_BillingApproval.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonProductionSelectBy_BillingApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionSelectBy_BillingApproval.TabIndex = 1
            Me.RadioButtonProductionSelectBy_BillingApproval.TabOnEnter = True
            Me.RadioButtonProductionSelectBy_BillingApproval.TabStop = False
            Me.RadioButtonProductionSelectBy_BillingApproval.Tag = "8"
            Me.RadioButtonProductionSelectBy_BillingApproval.Text = "Billing Approval"
            '
            'LabelProduction_BillingApprovalBatch
            '
            Me.LabelProduction_BillingApprovalBatch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_BillingApprovalBatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_BillingApprovalBatch.Location = New System.Drawing.Point(4, 4)
            Me.LabelProduction_BillingApprovalBatch.Name = "LabelProduction_BillingApprovalBatch"
            Me.LabelProduction_BillingApprovalBatch.Size = New System.Drawing.Size(116, 20)
            Me.LabelProduction_BillingApprovalBatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_BillingApprovalBatch.TabIndex = 0
            Me.LabelProduction_BillingApprovalBatch.Text = "Billing Approval Batch:"
            '
            'SearchableComboBoxProduction_BillingApprovalBatch
            '
            Me.SearchableComboBoxProduction_BillingApprovalBatch.ActiveFilterString = ""
            Me.SearchableComboBoxProduction_BillingApprovalBatch.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProduction_BillingApprovalBatch.AutoFillMode = False
            Me.SearchableComboBoxProduction_BillingApprovalBatch.BookmarkingEnabled = False
            Me.SearchableComboBoxProduction_BillingApprovalBatch.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.BillingApprovalBatch
            Me.SearchableComboBoxProduction_BillingApprovalBatch.DataSource = Nothing
            Me.SearchableComboBoxProduction_BillingApprovalBatch.DisableMouseWheel = True
            Me.SearchableComboBoxProduction_BillingApprovalBatch.DisplayName = ""
            Me.SearchableComboBoxProduction_BillingApprovalBatch.EnterMoveNextControl = True
            Me.SearchableComboBoxProduction_BillingApprovalBatch.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Location = New System.Drawing.Point(126, 4)
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Name = "SearchableComboBoxProduction_BillingApprovalBatch"
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.NullText = "Select Batch"
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.PopupView = Me.SearchableComboBoxView_BIllingApprovalBatch
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.ShowClearButton = False
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties.ValueMember = "ID"
            Me.SearchableComboBoxProduction_BillingApprovalBatch.SecurityEnabled = True
            Me.SearchableComboBoxProduction_BillingApprovalBatch.SelectedValue = Nothing
            Me.SearchableComboBoxProduction_BillingApprovalBatch.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxProduction_BillingApprovalBatch.TabIndex = 1
            '
            'SearchableComboBoxView_BIllingApprovalBatch
            '
            Me.SearchableComboBoxView_BIllingApprovalBatch.AFActiveFilterString = ""
            Me.SearchableComboBoxView_BIllingApprovalBatch.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_BIllingApprovalBatch.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_BIllingApprovalBatch.DataSourceClearing = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.EnableDisabledRows = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_BIllingApprovalBatch.Name = "SearchableComboBoxView_BIllingApprovalBatch"
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_BIllingApprovalBatch.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_BIllingApprovalBatch.RunStandardValidation = True
            Me.SearchableComboBoxView_BIllingApprovalBatch.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxView_BIllingApprovalBatch.SkipSettingFontOnModifyColumn = False
            '
            'TabItemBillingCommandCenter_ProductionSelectionTab
            '
            Me.TabItemBillingCommandCenter_ProductionSelectionTab.AttachedControl = Me.TabControlPanelProductionSelection_Details
            Me.TabItemBillingCommandCenter_ProductionSelectionTab.Name = "TabItemBillingCommandCenter_ProductionSelectionTab"
            Me.TabItemBillingCommandCenter_ProductionSelectionTab.Text = "Production Selection"
            '
            'TabControlPanelMediaSelection_Details
            '
            Me.TabControlPanelMediaSelection_Details.AutoScroll = True
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.GroupBoxMedia_JobMediaDateToBillDateRange)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.CheckBoxMedia_IncludeLegacyBroadcast)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.CheckBoxMedia_IncludeSpots)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.CheckBoxMedia_IncludeUnbilledOrdersOnly)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.GroupBoxMedia_SelectBy)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.DataGridViewMedia_Selections)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.GroupBoxMedia_BroadcastByMonth)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.GroupBoxMedia_Types)
            Me.TabControlPanelMediaSelection_Details.Controls.Add(Me.ComboBoxMedia_SelectBy)
            Me.TabControlPanelMediaSelection_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaSelection_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaSelection_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaSelection_Details.Name = "TabControlPanelMediaSelection_Details"
            Me.TabControlPanelMediaSelection_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaSelection_Details.Size = New System.Drawing.Size(1016, 640)
            Me.TabControlPanelMediaSelection_Details.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaSelection_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaSelection_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaSelection_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaSelection_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaSelection_Details.Style.GradientAngle = 90
            Me.TabControlPanelMediaSelection_Details.TabIndex = 11
            Me.TabControlPanelMediaSelection_Details.TabItem = Me.TabItemBillingCommandCenter_MediaSelectionTab
            '
            'GroupBoxMedia_JobMediaDateToBillDateRange
            '
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_From)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJobMedia_DateFrom)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJobMedia_DateTo)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_To)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Location = New System.Drawing.Point(4, 259)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Name = "GroupBoxMedia_JobMediaDateToBillDateRange"
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Size = New System.Drawing.Size(362, 55)
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.TabIndex = 7
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.Text = "Job or Media Date to Bill"
            '
            'LabelJobMediaDateRange_From
            '
            Me.LabelJobMediaDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobMediaDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobMediaDateRange_From.Location = New System.Drawing.Point(5, 24)
            Me.LabelJobMediaDateRange_From.Name = "LabelJobMediaDateRange_From"
            Me.LabelJobMediaDateRange_From.Size = New System.Drawing.Size(38, 20)
            Me.LabelJobMediaDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobMediaDateRange_From.TabIndex = 1
            Me.LabelJobMediaDateRange_From.Text = "From:"
            '
            'DateTimePickerJobMedia_DateFrom
            '
            Me.DateTimePickerJobMedia_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerJobMedia_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerJobMedia_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateFrom.ButtonClear.Visible = True
            Me.DateTimePickerJobMedia_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerJobMedia_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerJobMedia_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerJobMedia_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerJobMedia_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerJobMedia_DateFrom.DisplayName = ""
            Me.DateTimePickerJobMedia_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerJobMedia_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerJobMedia_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerJobMedia_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerJobMedia_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerJobMedia_DateFrom.Location = New System.Drawing.Point(49, 24)
            Me.DateTimePickerJobMedia_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerJobMedia_DateFrom.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerJobMedia_DateFrom.Name = "DateTimePickerJobMedia_DateFrom"
            Me.DateTimePickerJobMedia_DateFrom.ReadOnly = False
            Me.DateTimePickerJobMedia_DateFrom.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerJobMedia_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerJobMedia_DateFrom.TabIndex = 2
            Me.DateTimePickerJobMedia_DateFrom.TabOnEnter = True
            Me.DateTimePickerJobMedia_DateFrom.Value = New Date(2013, 7, 23, 13, 58, 57, 366)
            '
            'DateTimePickerJobMedia_DateTo
            '
            Me.DateTimePickerJobMedia_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerJobMedia_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerJobMedia_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateTo.ButtonClear.Visible = True
            Me.DateTimePickerJobMedia_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerJobMedia_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerJobMedia_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerJobMedia_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerJobMedia_DateTo.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerJobMedia_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerJobMedia_DateTo.DisplayName = ""
            Me.DateTimePickerJobMedia_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerJobMedia_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerJobMedia_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerJobMedia_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerJobMedia_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerJobMedia_DateTo.Location = New System.Drawing.Point(228, 24)
            Me.DateTimePickerJobMedia_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerJobMedia_DateTo.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerJobMedia_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerJobMedia_DateTo.Name = "DateTimePickerJobMedia_DateTo"
            Me.DateTimePickerJobMedia_DateTo.ReadOnly = False
            Me.DateTimePickerJobMedia_DateTo.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerJobMedia_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerJobMedia_DateTo.TabIndex = 4
            Me.DateTimePickerJobMedia_DateTo.TabOnEnter = True
            Me.DateTimePickerJobMedia_DateTo.Value = New Date(2014, 4, 18, 14, 11, 55, 950)
            '
            'LabelJobMediaDateRange_To
            '
            Me.LabelJobMediaDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelJobMediaDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelJobMediaDateRange_To.Location = New System.Drawing.Point(184, 25)
            Me.LabelJobMediaDateRange_To.Name = "LabelJobMediaDateRange_To"
            Me.LabelJobMediaDateRange_To.Size = New System.Drawing.Size(38, 20)
            Me.LabelJobMediaDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobMediaDateRange_To.TabIndex = 3
            Me.LabelJobMediaDateRange_To.Text = "To:"
            '
            'CheckBoxMedia_IncludeLegacyBroadcast
            '
            Me.CheckBoxMedia_IncludeLegacyBroadcast.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMedia_IncludeLegacyBroadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_IncludeLegacyBroadcast.CheckValue = 0
            Me.CheckBoxMedia_IncludeLegacyBroadcast.CheckValueChecked = 1
            Me.CheckBoxMedia_IncludeLegacyBroadcast.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMedia_IncludeLegacyBroadcast.CheckValueUnchecked = 0
            Me.CheckBoxMedia_IncludeLegacyBroadcast.ChildControls = Nothing
            Me.CheckBoxMedia_IncludeLegacyBroadcast.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_IncludeLegacyBroadcast.Location = New System.Drawing.Point(4, 534)
            Me.CheckBoxMedia_IncludeLegacyBroadcast.Name = "CheckBoxMedia_IncludeLegacyBroadcast"
            Me.CheckBoxMedia_IncludeLegacyBroadcast.OldestSibling = Nothing
            Me.CheckBoxMedia_IncludeLegacyBroadcast.SecurityEnabled = True
            Me.CheckBoxMedia_IncludeLegacyBroadcast.SiblingControls = Nothing
            Me.CheckBoxMedia_IncludeLegacyBroadcast.Size = New System.Drawing.Size(362, 20)
            Me.CheckBoxMedia_IncludeLegacyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_IncludeLegacyBroadcast.TabIndex = 6
            Me.CheckBoxMedia_IncludeLegacyBroadcast.TabOnEnter = True
            Me.CheckBoxMedia_IncludeLegacyBroadcast.Text = "Include Legacy Broadcast"
            '
            'CheckBoxMedia_IncludeSpots
            '
            Me.CheckBoxMedia_IncludeSpots.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMedia_IncludeSpots.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_IncludeSpots.CheckValue = 0
            Me.CheckBoxMedia_IncludeSpots.CheckValueChecked = 1
            Me.CheckBoxMedia_IncludeSpots.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMedia_IncludeSpots.CheckValueUnchecked = 0
            Me.CheckBoxMedia_IncludeSpots.ChildControls = Nothing
            Me.CheckBoxMedia_IncludeSpots.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_IncludeSpots.Location = New System.Drawing.Point(4, 508)
            Me.CheckBoxMedia_IncludeSpots.Name = "CheckBoxMedia_IncludeSpots"
            Me.CheckBoxMedia_IncludeSpots.OldestSibling = Nothing
            Me.CheckBoxMedia_IncludeSpots.SecurityEnabled = True
            Me.CheckBoxMedia_IncludeSpots.SiblingControls = Nothing
            Me.CheckBoxMedia_IncludeSpots.Size = New System.Drawing.Size(362, 20)
            Me.CheckBoxMedia_IncludeSpots.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_IncludeSpots.TabIndex = 5
            Me.CheckBoxMedia_IncludeSpots.TabOnEnter = True
            Me.CheckBoxMedia_IncludeSpots.Text = "Include Spots with Zero Billing Amounts?"
            '
            'CheckBoxMedia_IncludeUnbilledOrdersOnly
            '
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.CheckValue = 0
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.CheckValueChecked = 1
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.CheckValueUnchecked = 0
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.ChildControls = Nothing
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.Location = New System.Drawing.Point(4, 482)
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.Name = "CheckBoxMedia_IncludeUnbilledOrdersOnly"
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.OldestSibling = Nothing
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.SecurityEnabled = True
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.SiblingControls = Nothing
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.Size = New System.Drawing.Size(362, 20)
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.TabIndex = 4
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.TabOnEnter = True
            Me.CheckBoxMedia_IncludeUnbilledOrdersOnly.Text = "Include Unbilled Orders Only?"
            '
            'GroupBoxMedia_SelectBy
            '
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_ClientBiller)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.NumericInputMediaSelectBy_OrderNumber)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_AllEligibleOrders)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_LineNumber)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_OrderNumber)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_Campaign)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_Market)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_ClientPO)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_ClientDivisionProduct)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_ClientDivision)
            Me.GroupBoxMedia_SelectBy.Controls.Add(Me.RadioButtonMediaSelectBy_Client)
            Me.GroupBoxMedia_SelectBy.Location = New System.Drawing.Point(4, 320)
            Me.GroupBoxMedia_SelectBy.Name = "GroupBoxMedia_SelectBy"
            Me.GroupBoxMedia_SelectBy.Size = New System.Drawing.Size(362, 156)
            Me.GroupBoxMedia_SelectBy.TabIndex = 3
            Me.GroupBoxMedia_SelectBy.Text = "Select By"
            '
            'RadioButtonMediaSelectBy_ClientBiller
            '
            Me.RadioButtonMediaSelectBy_ClientBiller.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_ClientBiller.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_ClientBiller.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_ClientBiller.Location = New System.Drawing.Point(180, 128)
            Me.RadioButtonMediaSelectBy_ClientBiller.Name = "RadioButtonMediaSelectBy_ClientBiller"
            Me.RadioButtonMediaSelectBy_ClientBiller.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_ClientBiller.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_ClientBiller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_ClientBiller.TabIndex = 10
            Me.RadioButtonMediaSelectBy_ClientBiller.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_ClientBiller.TabStop = False
            Me.RadioButtonMediaSelectBy_ClientBiller.Tag = "9"
            Me.RadioButtonMediaSelectBy_ClientBiller.Text = "Client Biller"
            '
            'NumericInputMediaSelectBy_OrderNumber
            '
            Me.NumericInputMediaSelectBy_OrderNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMediaSelectBy_OrderNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMediaSelectBy_OrderNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMediaSelectBy_OrderNumber.EnterMoveNextControl = True
            Me.NumericInputMediaSelectBy_OrderNumber.Location = New System.Drawing.Point(279, 76)
            Me.NumericInputMediaSelectBy_OrderNumber.Name = "NumericInputMediaSelectBy_OrderNumber"
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.AllowMouseWheel = False
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.IsFloatValue = False
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputMediaSelectBy_OrderNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputMediaSelectBy_OrderNumber.SecurityEnabled = True
            Me.NumericInputMediaSelectBy_OrderNumber.Size = New System.Drawing.Size(78, 20)
            Me.NumericInputMediaSelectBy_OrderNumber.TabIndex = 9
            '
            'RadioButtonMediaSelectBy_AllEligibleOrders
            '
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Name = "RadioButtonMediaSelectBy_AllEligibleOrders"
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.TabIndex = 0
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.TabStop = False
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Tag = "0"
            Me.RadioButtonMediaSelectBy_AllEligibleOrders.Text = "All Eligible Orders"
            '
            'RadioButtonMediaSelectBy_LineNumber
            '
            Me.RadioButtonMediaSelectBy_LineNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_LineNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_LineNumber.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_LineNumber.Location = New System.Drawing.Point(180, 102)
            Me.RadioButtonMediaSelectBy_LineNumber.Name = "RadioButtonMediaSelectBy_LineNumber"
            Me.RadioButtonMediaSelectBy_LineNumber.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_LineNumber.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_LineNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_LineNumber.TabIndex = 7
            Me.RadioButtonMediaSelectBy_LineNumber.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_LineNumber.TabStop = False
            Me.RadioButtonMediaSelectBy_LineNumber.Tag = "8"
            Me.RadioButtonMediaSelectBy_LineNumber.Text = "Line Number"
            '
            'RadioButtonMediaSelectBy_OrderNumber
            '
            Me.RadioButtonMediaSelectBy_OrderNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_OrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_OrderNumber.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_OrderNumber.Location = New System.Drawing.Point(180, 76)
            Me.RadioButtonMediaSelectBy_OrderNumber.Name = "RadioButtonMediaSelectBy_OrderNumber"
            Me.RadioButtonMediaSelectBy_OrderNumber.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_OrderNumber.Size = New System.Drawing.Size(93, 20)
            Me.RadioButtonMediaSelectBy_OrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_OrderNumber.TabIndex = 5
            Me.RadioButtonMediaSelectBy_OrderNumber.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_OrderNumber.TabStop = False
            Me.RadioButtonMediaSelectBy_OrderNumber.Tag = "5"
            Me.RadioButtonMediaSelectBy_OrderNumber.Text = "Order Number"
            '
            'RadioButtonMediaSelectBy_Campaign
            '
            Me.RadioButtonMediaSelectBy_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_Campaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_Campaign.Location = New System.Drawing.Point(180, 50)
            Me.RadioButtonMediaSelectBy_Campaign.Name = "RadioButtonMediaSelectBy_Campaign"
            Me.RadioButtonMediaSelectBy_Campaign.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_Campaign.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_Campaign.TabIndex = 3
            Me.RadioButtonMediaSelectBy_Campaign.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_Campaign.TabStop = False
            Me.RadioButtonMediaSelectBy_Campaign.Tag = "1"
            Me.RadioButtonMediaSelectBy_Campaign.Text = "Campaign"
            '
            'RadioButtonMediaSelectBy_Market
            '
            Me.RadioButtonMediaSelectBy_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_Market.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_Market.Location = New System.Drawing.Point(180, 24)
            Me.RadioButtonMediaSelectBy_Market.Name = "RadioButtonMediaSelectBy_Market"
            Me.RadioButtonMediaSelectBy_Market.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_Market.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_Market.TabIndex = 1
            Me.RadioButtonMediaSelectBy_Market.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_Market.TabStop = False
            Me.RadioButtonMediaSelectBy_Market.Tag = "7"
            Me.RadioButtonMediaSelectBy_Market.Text = "Market"
            '
            'RadioButtonMediaSelectBy_ClientPO
            '
            Me.RadioButtonMediaSelectBy_ClientPO.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_ClientPO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_ClientPO.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_ClientPO.Location = New System.Drawing.Point(5, 128)
            Me.RadioButtonMediaSelectBy_ClientPO.Name = "RadioButtonMediaSelectBy_ClientPO"
            Me.RadioButtonMediaSelectBy_ClientPO.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_ClientPO.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_ClientPO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_ClientPO.TabIndex = 8
            Me.RadioButtonMediaSelectBy_ClientPO.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_ClientPO.TabStop = False
            Me.RadioButtonMediaSelectBy_ClientPO.Tag = "6"
            Me.RadioButtonMediaSelectBy_ClientPO.Text = "Client P.O."
            '
            'RadioButtonMediaSelectBy_ClientDivisionProduct
            '
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Location = New System.Drawing.Point(5, 102)
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Name = "RadioButtonMediaSelectBy_ClientDivisionProduct"
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.TabIndex = 6
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.TabStop = False
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Tag = "4"
            Me.RadioButtonMediaSelectBy_ClientDivisionProduct.Text = "Client / Division / Product"
            '
            'RadioButtonMediaSelectBy_ClientDivision
            '
            Me.RadioButtonMediaSelectBy_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_ClientDivision.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonMediaSelectBy_ClientDivision.Name = "RadioButtonMediaSelectBy_ClientDivision"
            Me.RadioButtonMediaSelectBy_ClientDivision.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_ClientDivision.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_ClientDivision.TabIndex = 4
            Me.RadioButtonMediaSelectBy_ClientDivision.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_ClientDivision.TabStop = False
            Me.RadioButtonMediaSelectBy_ClientDivision.Tag = "3"
            Me.RadioButtonMediaSelectBy_ClientDivision.Text = "Client / Division"
            '
            'RadioButtonMediaSelectBy_Client
            '
            Me.RadioButtonMediaSelectBy_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaSelectBy_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaSelectBy_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaSelectBy_Client.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonMediaSelectBy_Client.Name = "RadioButtonMediaSelectBy_Client"
            Me.RadioButtonMediaSelectBy_Client.SecurityEnabled = True
            Me.RadioButtonMediaSelectBy_Client.Size = New System.Drawing.Size(169, 20)
            Me.RadioButtonMediaSelectBy_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaSelectBy_Client.TabIndex = 2
            Me.RadioButtonMediaSelectBy_Client.TabOnEnter = True
            Me.RadioButtonMediaSelectBy_Client.TabStop = False
            Me.RadioButtonMediaSelectBy_Client.Tag = "2"
            Me.RadioButtonMediaSelectBy_Client.Text = "Client"
            '
            'DataGridViewMedia_Selections
            '
            Me.DataGridViewMedia_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewMedia_Selections.AllowDragAndDrop = False
            Me.DataGridViewMedia_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMedia_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMedia_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMedia_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMedia_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewMedia_Selections.AutoloadRepositoryDatasource = True
            Me.DataGridViewMedia_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewMedia_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewMedia_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMedia_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMedia_Selections.ItemDescription = ""
            Me.DataGridViewMedia_Selections.Location = New System.Drawing.Point(373, 4)
            Me.DataGridViewMedia_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewMedia_Selections.MultiSelect = True
            Me.DataGridViewMedia_Selections.Name = "DataGridViewMedia_Selections"
            Me.DataGridViewMedia_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMedia_Selections.RunStandardValidation = True
            Me.DataGridViewMedia_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewMedia_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMedia_Selections.Size = New System.Drawing.Size(638, 632)
            Me.DataGridViewMedia_Selections.TabIndex = 6
            Me.DataGridViewMedia_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewMedia_Selections.ViewCaptionHeight = -1
            '
            'GroupBoxMedia_BroadcastByMonth
            '
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.NumericInputMediaBroadcast_YearTo)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.NumericInputMediaBroadcast_YearFrom)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.ComboBoxMediaBroadcast_MonthTo)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.ComboBoxMediaBroadcast_MonthFrom)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.LabelMediaBroadcast_Range)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.CheckBoxMediaBroadcast_Television)
            Me.GroupBoxMedia_BroadcastByMonth.Controls.Add(Me.CheckBoxMediaBroadcast_Radio)
            Me.GroupBoxMedia_BroadcastByMonth.Location = New System.Drawing.Point(4, 171)
            Me.GroupBoxMedia_BroadcastByMonth.Name = "GroupBoxMedia_BroadcastByMonth"
            Me.GroupBoxMedia_BroadcastByMonth.Size = New System.Drawing.Size(362, 82)
            Me.GroupBoxMedia_BroadcastByMonth.TabIndex = 2
            Me.GroupBoxMedia_BroadcastByMonth.Text = "Broadcast By Month"
            '
            'NumericInputMediaBroadcast_YearTo
            '
            Me.NumericInputMediaBroadcast_YearTo.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMediaBroadcast_YearTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMediaBroadcast_YearTo.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearTo.EnterMoveNextControl = True
            Me.NumericInputMediaBroadcast_YearTo.Location = New System.Drawing.Point(265, 50)
            Me.NumericInputMediaBroadcast_YearTo.Name = "NumericInputMediaBroadcast_YearTo"
            Me.NumericInputMediaBroadcast_YearTo.Properties.AllowMouseWheel = False
            Me.NumericInputMediaBroadcast_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputMediaBroadcast_YearTo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMediaBroadcast_YearTo.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMediaBroadcast_YearTo.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMediaBroadcast_YearTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaBroadcast_YearTo.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMediaBroadcast_YearTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaBroadcast_YearTo.Properties.IsFloatValue = False
            Me.NumericInputMediaBroadcast_YearTo.Properties.Mask.EditMask = "f0"
            Me.NumericInputMediaBroadcast_YearTo.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMediaBroadcast_YearTo.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearTo.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearTo.SecurityEnabled = True
            Me.NumericInputMediaBroadcast_YearTo.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputMediaBroadcast_YearTo.TabIndex = 6
            '
            'NumericInputMediaBroadcast_YearFrom
            '
            Me.NumericInputMediaBroadcast_YearFrom.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMediaBroadcast_YearFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMediaBroadcast_YearFrom.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearFrom.EnterMoveNextControl = True
            Me.NumericInputMediaBroadcast_YearFrom.Location = New System.Drawing.Point(130, 50)
            Me.NumericInputMediaBroadcast_YearFrom.Name = "NumericInputMediaBroadcast_YearFrom"
            Me.NumericInputMediaBroadcast_YearFrom.Properties.AllowMouseWheel = False
            Me.NumericInputMediaBroadcast_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputMediaBroadcast_YearFrom.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMediaBroadcast_YearFrom.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMediaBroadcast_YearFrom.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMediaBroadcast_YearFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaBroadcast_YearFrom.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMediaBroadcast_YearFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMediaBroadcast_YearFrom.Properties.IsFloatValue = False
            Me.NumericInputMediaBroadcast_YearFrom.Properties.Mask.EditMask = "f0"
            Me.NumericInputMediaBroadcast_YearFrom.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMediaBroadcast_YearFrom.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearFrom.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputMediaBroadcast_YearFrom.SecurityEnabled = True
            Me.NumericInputMediaBroadcast_YearFrom.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputMediaBroadcast_YearFrom.TabIndex = 4
            '
            'ComboBoxMediaBroadcast_MonthTo
            '
            Me.ComboBoxMediaBroadcast_MonthTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaBroadcast_MonthTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxMediaBroadcast_MonthTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaBroadcast_MonthTo.AutoFindItemInDataSource = True
            Me.ComboBoxMediaBroadcast_MonthTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaBroadcast_MonthTo.BookmarkingEnabled = False
            Me.ComboBoxMediaBroadcast_MonthTo.ClientCode = ""
            Me.ComboBoxMediaBroadcast_MonthTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMediaBroadcast_MonthTo.DisableMouseWheel = True
            Me.ComboBoxMediaBroadcast_MonthTo.DisplayMember = "Value"
            Me.ComboBoxMediaBroadcast_MonthTo.DisplayName = ""
            Me.ComboBoxMediaBroadcast_MonthTo.DivisionCode = ""
            Me.ComboBoxMediaBroadcast_MonthTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaBroadcast_MonthTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaBroadcast_MonthTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMediaBroadcast_MonthTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaBroadcast_MonthTo.FocusHighlightEnabled = True
            Me.ComboBoxMediaBroadcast_MonthTo.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaBroadcast_MonthTo.FormattingEnabled = True
            Me.ComboBoxMediaBroadcast_MonthTo.ItemHeight = 16
            Me.ComboBoxMediaBroadcast_MonthTo.Location = New System.Drawing.Point(184, 50)
            Me.ComboBoxMediaBroadcast_MonthTo.Name = "ComboBoxMediaBroadcast_MonthTo"
            Me.ComboBoxMediaBroadcast_MonthTo.ReadOnly = False
            Me.ComboBoxMediaBroadcast_MonthTo.SecurityEnabled = True
            Me.ComboBoxMediaBroadcast_MonthTo.Size = New System.Drawing.Size(75, 22)
            Me.ComboBoxMediaBroadcast_MonthTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaBroadcast_MonthTo.TabIndex = 5
            Me.ComboBoxMediaBroadcast_MonthTo.TabOnEnter = True
            Me.ComboBoxMediaBroadcast_MonthTo.ValueMember = "Key"
            Me.ComboBoxMediaBroadcast_MonthTo.WatermarkText = "Select Month"
            '
            'ComboBoxMediaBroadcast_MonthFrom
            '
            Me.ComboBoxMediaBroadcast_MonthFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaBroadcast_MonthFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxMediaBroadcast_MonthFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaBroadcast_MonthFrom.AutoFindItemInDataSource = True
            Me.ComboBoxMediaBroadcast_MonthFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaBroadcast_MonthFrom.BookmarkingEnabled = False
            Me.ComboBoxMediaBroadcast_MonthFrom.ClientCode = ""
            Me.ComboBoxMediaBroadcast_MonthFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMediaBroadcast_MonthFrom.DisableMouseWheel = True
            Me.ComboBoxMediaBroadcast_MonthFrom.DisplayMember = "Value"
            Me.ComboBoxMediaBroadcast_MonthFrom.DisplayName = ""
            Me.ComboBoxMediaBroadcast_MonthFrom.DivisionCode = ""
            Me.ComboBoxMediaBroadcast_MonthFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaBroadcast_MonthFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaBroadcast_MonthFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMediaBroadcast_MonthFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaBroadcast_MonthFrom.FocusHighlightEnabled = True
            Me.ComboBoxMediaBroadcast_MonthFrom.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaBroadcast_MonthFrom.FormattingEnabled = True
            Me.ComboBoxMediaBroadcast_MonthFrom.ItemHeight = 16
            Me.ComboBoxMediaBroadcast_MonthFrom.Location = New System.Drawing.Point(49, 50)
            Me.ComboBoxMediaBroadcast_MonthFrom.Name = "ComboBoxMediaBroadcast_MonthFrom"
            Me.ComboBoxMediaBroadcast_MonthFrom.ReadOnly = False
            Me.ComboBoxMediaBroadcast_MonthFrom.SecurityEnabled = True
            Me.ComboBoxMediaBroadcast_MonthFrom.Size = New System.Drawing.Size(75, 22)
            Me.ComboBoxMediaBroadcast_MonthFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaBroadcast_MonthFrom.TabIndex = 3
            Me.ComboBoxMediaBroadcast_MonthFrom.TabOnEnter = True
            Me.ComboBoxMediaBroadcast_MonthFrom.ValueMember = "Key"
            Me.ComboBoxMediaBroadcast_MonthFrom.WatermarkText = "Select Month"
            '
            'LabelMediaBroadcast_Range
            '
            Me.LabelMediaBroadcast_Range.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaBroadcast_Range.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaBroadcast_Range.Location = New System.Drawing.Point(5, 50)
            Me.LabelMediaBroadcast_Range.Name = "LabelMediaBroadcast_Range"
            Me.LabelMediaBroadcast_Range.Size = New System.Drawing.Size(38, 20)
            Me.LabelMediaBroadcast_Range.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaBroadcast_Range.TabIndex = 2
            Me.LabelMediaBroadcast_Range.Text = "Range:"
            '
            'CheckBoxMediaBroadcast_Television
            '
            Me.CheckBoxMediaBroadcast_Television.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaBroadcast_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaBroadcast_Television.CheckValue = 0
            Me.CheckBoxMediaBroadcast_Television.CheckValueChecked = 1
            Me.CheckBoxMediaBroadcast_Television.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaBroadcast_Television.CheckValueUnchecked = 0
            Me.CheckBoxMediaBroadcast_Television.ChildControls = Nothing
            Me.CheckBoxMediaBroadcast_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaBroadcast_Television.Location = New System.Drawing.Point(184, 24)
            Me.CheckBoxMediaBroadcast_Television.Name = "CheckBoxMediaBroadcast_Television"
            Me.CheckBoxMediaBroadcast_Television.OldestSibling = Nothing
            Me.CheckBoxMediaBroadcast_Television.SecurityEnabled = True
            Me.CheckBoxMediaBroadcast_Television.SiblingControls = Nothing
            Me.CheckBoxMediaBroadcast_Television.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaBroadcast_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaBroadcast_Television.TabIndex = 1
            Me.CheckBoxMediaBroadcast_Television.TabOnEnter = True
            Me.CheckBoxMediaBroadcast_Television.Text = "Television"
            '
            'CheckBoxMediaBroadcast_Radio
            '
            Me.CheckBoxMediaBroadcast_Radio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaBroadcast_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaBroadcast_Radio.CheckValue = 0
            Me.CheckBoxMediaBroadcast_Radio.CheckValueChecked = 1
            Me.CheckBoxMediaBroadcast_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaBroadcast_Radio.CheckValueUnchecked = 0
            Me.CheckBoxMediaBroadcast_Radio.ChildControls = Nothing
            Me.CheckBoxMediaBroadcast_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaBroadcast_Radio.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxMediaBroadcast_Radio.Name = "CheckBoxMediaBroadcast_Radio"
            Me.CheckBoxMediaBroadcast_Radio.OldestSibling = Nothing
            Me.CheckBoxMediaBroadcast_Radio.SecurityEnabled = True
            Me.CheckBoxMediaBroadcast_Radio.SiblingControls = Nothing
            Me.CheckBoxMediaBroadcast_Radio.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaBroadcast_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaBroadcast_Radio.TabIndex = 0
            Me.CheckBoxMediaBroadcast_Radio.TabOnEnter = True
            Me.CheckBoxMediaBroadcast_Radio.Text = "Radio"
            '
            'GroupBoxMedia_Types
            '
            Me.GroupBoxMedia_Types.Controls.Add(Me.DateTimePickerMediaType_DateFrom)
            Me.GroupBoxMedia_Types.Controls.Add(Me.DateTimePickerMediaType_DateTo)
            Me.GroupBoxMedia_Types.Controls.Add(Me.LabelMediaType_DateTo)
            Me.GroupBoxMedia_Types.Controls.Add(Me.LabelMediaType_DateFrom)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_TelevisionDaily)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_RadioDaily)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_OutOfHome)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_Magazine)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_Internet)
            Me.GroupBoxMedia_Types.Controls.Add(Me.CheckBoxMediaType_Newspaper)
            Me.GroupBoxMedia_Types.Location = New System.Drawing.Point(4, 30)
            Me.GroupBoxMedia_Types.Name = "GroupBoxMedia_Types"
            Me.GroupBoxMedia_Types.Size = New System.Drawing.Size(362, 135)
            Me.GroupBoxMedia_Types.TabIndex = 1
            Me.GroupBoxMedia_Types.Text = "Select Media Types"
            '
            'DateTimePickerMediaType_DateFrom
            '
            Me.DateTimePickerMediaType_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerMediaType_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerMediaType_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerMediaType_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerMediaType_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerMediaType_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerMediaType_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerMediaType_DateFrom.DisplayName = ""
            Me.DateTimePickerMediaType_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerMediaType_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerMediaType_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerMediaType_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerMediaType_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerMediaType_DateFrom.Location = New System.Drawing.Point(49, 102)
            Me.DateTimePickerMediaType_DateFrom.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerMediaType_DateFrom.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerMediaType_DateFrom.Name = "DateTimePickerMediaType_DateFrom"
            Me.DateTimePickerMediaType_DateFrom.ReadOnly = False
            Me.DateTimePickerMediaType_DateFrom.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerMediaType_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerMediaType_DateFrom.TabIndex = 7
            Me.DateTimePickerMediaType_DateFrom.TabOnEnter = True
            Me.DateTimePickerMediaType_DateFrom.Value = New Date(2013, 7, 23, 13, 58, 57, 366)
            '
            'DateTimePickerMediaType_DateTo
            '
            Me.DateTimePickerMediaType_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerMediaType_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerMediaType_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerMediaType_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerMediaType_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerMediaType_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerMediaType_DateTo.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerMediaType_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerMediaType_DateTo.DisplayName = ""
            Me.DateTimePickerMediaType_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerMediaType_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerMediaType_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerMediaType_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerMediaType_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerMediaType_DateTo.Location = New System.Drawing.Point(228, 102)
            Me.DateTimePickerMediaType_DateTo.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerMediaType_DateTo.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMediaType_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerMediaType_DateTo.Name = "DateTimePickerMediaType_DateTo"
            Me.DateTimePickerMediaType_DateTo.ReadOnly = False
            Me.DateTimePickerMediaType_DateTo.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerMediaType_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerMediaType_DateTo.TabIndex = 9
            Me.DateTimePickerMediaType_DateTo.TabOnEnter = True
            Me.DateTimePickerMediaType_DateTo.Value = New Date(2014, 4, 18, 14, 11, 55, 950)
            '
            'LabelMediaType_DateTo
            '
            Me.LabelMediaType_DateTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaType_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaType_DateTo.Location = New System.Drawing.Point(184, 102)
            Me.LabelMediaType_DateTo.Name = "LabelMediaType_DateTo"
            Me.LabelMediaType_DateTo.Size = New System.Drawing.Size(38, 20)
            Me.LabelMediaType_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaType_DateTo.TabIndex = 8
            Me.LabelMediaType_DateTo.Text = "To:"
            '
            'LabelMediaType_DateFrom
            '
            Me.LabelMediaType_DateFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaType_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaType_DateFrom.Location = New System.Drawing.Point(5, 102)
            Me.LabelMediaType_DateFrom.Name = "LabelMediaType_DateFrom"
            Me.LabelMediaType_DateFrom.Size = New System.Drawing.Size(38, 20)
            Me.LabelMediaType_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaType_DateFrom.TabIndex = 6
            Me.LabelMediaType_DateFrom.Text = "From:"
            '
            'CheckBoxMediaType_TelevisionDaily
            '
            Me.CheckBoxMediaType_TelevisionDaily.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_TelevisionDaily.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_TelevisionDaily.CheckValue = 0
            Me.CheckBoxMediaType_TelevisionDaily.CheckValueChecked = 1
            Me.CheckBoxMediaType_TelevisionDaily.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_TelevisionDaily.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_TelevisionDaily.ChildControls = Nothing
            Me.CheckBoxMediaType_TelevisionDaily.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_TelevisionDaily.Location = New System.Drawing.Point(184, 76)
            Me.CheckBoxMediaType_TelevisionDaily.Name = "CheckBoxMediaType_TelevisionDaily"
            Me.CheckBoxMediaType_TelevisionDaily.OldestSibling = Nothing
            Me.CheckBoxMediaType_TelevisionDaily.SecurityEnabled = True
            Me.CheckBoxMediaType_TelevisionDaily.SiblingControls = Nothing
            Me.CheckBoxMediaType_TelevisionDaily.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_TelevisionDaily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_TelevisionDaily.TabIndex = 5
            Me.CheckBoxMediaType_TelevisionDaily.TabOnEnter = True
            Me.CheckBoxMediaType_TelevisionDaily.Text = "Television (Daily)"
            '
            'CheckBoxMediaType_RadioDaily
            '
            Me.CheckBoxMediaType_RadioDaily.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_RadioDaily.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_RadioDaily.CheckValue = 0
            Me.CheckBoxMediaType_RadioDaily.CheckValueChecked = 1
            Me.CheckBoxMediaType_RadioDaily.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_RadioDaily.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_RadioDaily.ChildControls = Nothing
            Me.CheckBoxMediaType_RadioDaily.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_RadioDaily.Location = New System.Drawing.Point(184, 50)
            Me.CheckBoxMediaType_RadioDaily.Name = "CheckBoxMediaType_RadioDaily"
            Me.CheckBoxMediaType_RadioDaily.OldestSibling = Nothing
            Me.CheckBoxMediaType_RadioDaily.SecurityEnabled = True
            Me.CheckBoxMediaType_RadioDaily.SiblingControls = Nothing
            Me.CheckBoxMediaType_RadioDaily.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_RadioDaily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_RadioDaily.TabIndex = 3
            Me.CheckBoxMediaType_RadioDaily.TabOnEnter = True
            Me.CheckBoxMediaType_RadioDaily.Text = "Radio (Daily)"
            '
            'CheckBoxMediaType_OutOfHome
            '
            Me.CheckBoxMediaType_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_OutOfHome.CheckValue = 0
            Me.CheckBoxMediaType_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMediaType_OutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_OutOfHome.ChildControls = Nothing
            Me.CheckBoxMediaType_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_OutOfHome.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxMediaType_OutOfHome.Name = "CheckBoxMediaType_OutOfHome"
            Me.CheckBoxMediaType_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMediaType_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMediaType_OutOfHome.SiblingControls = Nothing
            Me.CheckBoxMediaType_OutOfHome.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_OutOfHome.TabIndex = 4
            Me.CheckBoxMediaType_OutOfHome.TabOnEnter = True
            Me.CheckBoxMediaType_OutOfHome.Text = "Out of Home"
            '
            'CheckBoxMediaType_Magazine
            '
            Me.CheckBoxMediaType_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Magazine.CheckValue = 0
            Me.CheckBoxMediaType_Magazine.CheckValueChecked = 1
            Me.CheckBoxMediaType_Magazine.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Magazine.ChildControls = Nothing
            Me.CheckBoxMediaType_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Magazine.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxMediaType_Magazine.Name = "CheckBoxMediaType_Magazine"
            Me.CheckBoxMediaType_Magazine.OldestSibling = Nothing
            Me.CheckBoxMediaType_Magazine.SecurityEnabled = True
            Me.CheckBoxMediaType_Magazine.SiblingControls = Nothing
            Me.CheckBoxMediaType_Magazine.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Magazine.TabIndex = 2
            Me.CheckBoxMediaType_Magazine.TabOnEnter = True
            Me.CheckBoxMediaType_Magazine.Text = "Magazine"
            '
            'CheckBoxMediaType_Internet
            '
            Me.CheckBoxMediaType_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Internet.CheckValue = 0
            Me.CheckBoxMediaType_Internet.CheckValueChecked = 1
            Me.CheckBoxMediaType_Internet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Internet.ChildControls = Nothing
            Me.CheckBoxMediaType_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Internet.Location = New System.Drawing.Point(184, 24)
            Me.CheckBoxMediaType_Internet.Name = "CheckBoxMediaType_Internet"
            Me.CheckBoxMediaType_Internet.OldestSibling = Nothing
            Me.CheckBoxMediaType_Internet.SecurityEnabled = True
            Me.CheckBoxMediaType_Internet.SiblingControls = Nothing
            Me.CheckBoxMediaType_Internet.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Internet.TabIndex = 1
            Me.CheckBoxMediaType_Internet.TabOnEnter = True
            Me.CheckBoxMediaType_Internet.Text = "Internet"
            '
            'CheckBoxMediaType_Newspaper
            '
            Me.CheckBoxMediaType_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaType_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaType_Newspaper.CheckValue = 0
            Me.CheckBoxMediaType_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMediaType_Newspaper.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaType_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMediaType_Newspaper.ChildControls = Nothing
            Me.CheckBoxMediaType_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaType_Newspaper.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxMediaType_Newspaper.Name = "CheckBoxMediaType_Newspaper"
            Me.CheckBoxMediaType_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMediaType_Newspaper.SecurityEnabled = True
            Me.CheckBoxMediaType_Newspaper.SiblingControls = Nothing
            Me.CheckBoxMediaType_Newspaper.Size = New System.Drawing.Size(173, 20)
            Me.CheckBoxMediaType_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_Newspaper.TabIndex = 0
            Me.CheckBoxMediaType_Newspaper.TabOnEnter = True
            Me.CheckBoxMediaType_Newspaper.Text = "Newspaper"
            '
            'ComboBoxMedia_SelectBy
            '
            Me.ComboBoxMedia_SelectBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMedia_SelectBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMedia_SelectBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMedia_SelectBy.AutoFindItemInDataSource = False
            Me.ComboBoxMedia_SelectBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMedia_SelectBy.BookmarkingEnabled = False
            Me.ComboBoxMedia_SelectBy.ClientCode = ""
            Me.ComboBoxMedia_SelectBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxMedia_SelectBy.DisableMouseWheel = True
            Me.ComboBoxMedia_SelectBy.DisplayMember = "Name"
            Me.ComboBoxMedia_SelectBy.DisplayName = ""
            Me.ComboBoxMedia_SelectBy.DivisionCode = ""
            Me.ComboBoxMedia_SelectBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMedia_SelectBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMedia_SelectBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMedia_SelectBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMedia_SelectBy.FocusHighlightEnabled = True
            Me.ComboBoxMedia_SelectBy.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMedia_SelectBy.FormattingEnabled = True
            Me.ComboBoxMedia_SelectBy.ItemHeight = 16
            Me.ComboBoxMedia_SelectBy.Location = New System.Drawing.Point(4, 4)
            Me.ComboBoxMedia_SelectBy.Name = "ComboBoxMedia_SelectBy"
            Me.ComboBoxMedia_SelectBy.ReadOnly = False
            Me.ComboBoxMedia_SelectBy.SecurityEnabled = True
            Me.ComboBoxMedia_SelectBy.Size = New System.Drawing.Size(362, 22)
            Me.ComboBoxMedia_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMedia_SelectBy.TabIndex = 0
            Me.ComboBoxMedia_SelectBy.TabOnEnter = True
            Me.ComboBoxMedia_SelectBy.ValueMember = "Value"
            Me.ComboBoxMedia_SelectBy.WatermarkText = "Select"
            '
            'TabItemBillingCommandCenter_MediaSelectionTab
            '
            Me.TabItemBillingCommandCenter_MediaSelectionTab.AttachedControl = Me.TabControlPanelMediaSelection_Details
            Me.TabItemBillingCommandCenter_MediaSelectionTab.Name = "TabItemBillingCommandCenter_MediaSelectionTab"
            Me.TabItemBillingCommandCenter_MediaSelectionTab.Text = "Media Selection"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_UserBatches)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 691)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_UserBatches
            '
            Me.DataGridViewLeftSection_UserBatches.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_UserBatches.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_UserBatches.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_UserBatches.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_UserBatches.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_UserBatches.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_UserBatches.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_UserBatches.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_UserBatches.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_UserBatches.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_UserBatches.DataSource = Nothing
            Me.DataGridViewLeftSection_UserBatches.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_UserBatches.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_UserBatches.ItemDescription = "User Batch(es)"
            Me.DataGridViewLeftSection_UserBatches.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_UserBatches.MultiSelect = False
            Me.DataGridViewLeftSection_UserBatches.Name = "DataGridViewLeftSection_UserBatches"
            Me.DataGridViewLeftSection_UserBatches.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_UserBatches.RunStandardValidation = True
            Me.DataGridViewLeftSection_UserBatches.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_UserBatches.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_UserBatches.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_UserBatches.TabIndex = 0
            Me.DataGridViewLeftSection_UserBatches.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_UserBatches.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 9
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlForm_BillingCommandCenter)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(203, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1034, 691)
            Me.PanelForm_RightSection.TabIndex = 1
            '
            'SuperTooltip
            '
            Me.SuperTooltip.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
            Me.SuperTooltip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            '
            'BillingCommandCenterForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1237, 691)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterForm"
            Me.Text = "Billing Command Center"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_BillingCommandCenter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_BillingCommandCenter.ResumeLayout(False)
            Me.TabControlPanelProductionSelection_Details.ResumeLayout(False)
            CType(Me.GroupBoxProduction_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_JobMediaDateToBillDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerProductionJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerProductionJobMedia_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_TypeOfJob, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_TypeOfJob.ResumeLayout(False)
            CType(Me.GroupBoxProduction_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_Include.ResumeLayout(False)
            CType(Me.GroupBoxProduction_Cutoffs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_Cutoffs.ResumeLayout(False)
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_SelectBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_SelectBy.ResumeLayout(False)
            CType(Me.NumericInputProductionSelectBy_JobNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProduction_BillingApprovalBatch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_BIllingApprovalBatch, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelMediaSelection_Details.ResumeLayout(False)
            CType(Me.GroupBoxMedia_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMedia_JobMediaDateToBillDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerJobMedia_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMedia_SelectBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMedia_SelectBy.ResumeLayout(False)
            CType(Me.NumericInputMediaSelectBy_OrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMedia_BroadcastByMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMedia_BroadcastByMonth.ResumeLayout(False)
            CType(Me.NumericInputMediaBroadcast_YearTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMediaBroadcast_YearFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMedia_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMedia_Types.ResumeLayout(False)
            CType(Me.DateTimePickerMediaType_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerMediaType_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents TabControlForm_BillingCommandCenter As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelMediaSelection_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBillingCommandCenter_MediaSelectionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelection_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBillingCommandCenter_ProductionSelectionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelProduction_BillingApprovalBatch As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxProduction_BillingApprovalBatch As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_BIllingApprovalBatch As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents GroupBoxProduction_SelectBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonProductionSelectBy_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_Job As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_Campaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_ClientDivision As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_BillingApproval As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxProduction_Cutoffs As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DataGridViewProduction_Selections As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DateTimePickerProductionCutoffs_IncomeOnlyTimeDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelProductionCutoffs_IncomeOnlyDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxProductionCutoffs_APPostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerProductionCutoffs_EmployeeTimeDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelProductionCutoffs_EmployeeDateTime As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionCutoffs_APPostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxProduction_Include As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonProductionInclude_OpenJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionInclude_OpenJobsUnbilledRecordsOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionInclude_OpenJobsUnbilledWithOtherRecords As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxMedia_Types As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxMedia_SelectBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerMediaType_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelMediaType_DateTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaType_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxMediaType_TelevisionDaily As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaType_RadioDaily As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaType_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaType_Magazine As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaType_Internet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaType_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxMedia_BroadcastByMonth As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxMediaBroadcast_MonthTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxMediaBroadcast_MonthFrom As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaBroadcast_Range As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxMediaBroadcast_Television As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaBroadcast_Radio As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputMediaBroadcast_YearTo As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMediaBroadcast_YearFrom As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents DataGridViewMedia_Selections As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxMedia_IncludeSpots As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMedia_IncludeUnbilledOrdersOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxMedia_SelectBy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonMediaSelectBy_LineNumber As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_OrderNumber As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_Campaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_Market As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_ClientPO As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_ClientDivision As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DateTimePickerMediaType_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents RibbonBarOptions_MediaTypes As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaTypes_CheckAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMediaTypes_UncheckAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents NumericInputProductionSelectBy_JobNumber As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMediaSelectBy_OrderNumber As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_OtherUserSelections As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxProduction_IncludeFinishedBatches As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_UserBatches As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxProduction_TypeOfJob As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionTypeOfJob_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonItemView_ShowDescriptions As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RadioButtonProductionSelectBy_AllEligibleJobs As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonProductionSelectBy_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxCutoff_LockRecords As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_MyBatches As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RadioButtonMediaSelectBy_AllEligibleOrders As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RibbonBarOptions_ProcessInvoices As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProcessInvoices_CoopSplits As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Draft As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Assign As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Finish As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProcessInvoices_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents SuperTooltip As DevComponents.DotNetBar.SuperTooltip
        Friend WithEvents ButtonItemProcessInvoices_FinishDelete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_ProductionReview As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_MediaReview As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxMedia_IncludeLegacyBroadcast As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxMedia_JobMediaDateToBillDateRange As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelJobMediaDateRange_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerJobMedia_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerJobMedia_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelJobMediaDateRange_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemProcessInvoices_Currency As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RadioButtonProductionSelectBy_ClientBiller As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaSelectBy_ClientBiller As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxProduction_JobMediaDateToBillDateRange As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelProductionJobMediaDateRange_From As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerProductionJobMedia_DateFrom As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerProductionJobMedia_DateTo As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelProductionJobMediaDateRange_To As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxProduction_IncludeJobDateToBill As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace

