Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeReconciliationForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceFeeReconciliationForm))
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelLeftSection_FeeTimePostedDateRangeTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_FeeTimePostedDateRange = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxLeftSection_FeePeriodsTo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxLeftSection_FeePeriodsFrom = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelLeftSection_FeePeriodsTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_FeePeriodsFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_FeePeriods = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewSelectionCriteria_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectionCriteria_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectionCriteria_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectionCriteria_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewProductionCommission_Functions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewProductionCommission_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxProductionCommission_ProductionCommission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewStandardFee_Functions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewStandardFee_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxStandardFee_PostedBasedOnFunctions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxStandardFee_StandardFee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlForm_ServiceFeeReconciliation = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlFeeCriteria_Settings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionCommissionTab_ProductionCommission = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelProductionCommission_ProductionCommission = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelProductionCommission_PCRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelProductionCommission_PCLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabItemSettings_ProductionCommissionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelStandardFeeTab_StandardFee = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelStandardFee_StandardFee = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelStandardFee_SFRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterStandardFee_SFLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelStandardFee_SFLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabItemSettings_StandardFeeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaCommissionTab_MediaCommission = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxMediaCommission_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaCommission_MediaCommission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaCommission_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaCommission_Broadcast = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaCommission_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaCommission_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemSettings_MediaCommissionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemSettings_FeeTimeCriteriaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemServiceFeeReconciliation_FeeCriteriaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutSelectionCriteria_SelectionCriteria = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelSelectionCriteria_RightSection = New System.Windows.Forms.Panel()
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelRightSection_GroupByOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRightSection_SummaryStyle = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxRightSection_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelRightSection_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_SummaryStyle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelSelectionCriteria_LeftSection = New System.Windows.Forms.Panel()
            Me.LabelLeftSection_PrimaryDisplayOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelLeftSection_PrimaryDisplayOption = New System.Windows.Forms.Panel()
            Me.RadioButtonPrimaryDisplayOption_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPrimaryDisplayOption_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelServiceFeeTypeCriteria_FilterOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelServiceFeeTypeCriteria_SelectOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonServiceFeeTypeCriteria_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Process = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_ServiceFeeReconciliation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ServiceFeeReconciliation.SuspendLayout()
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.SuspendLayout()
            CType(Me.TabControlFeeCriteria_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlFeeCriteria_Settings.SuspendLayout()
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.SuspendLayout()
            CType(Me.PanelProductionCommission_ProductionCommission, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelProductionCommission_ProductionCommission.SuspendLayout()
            CType(Me.PanelProductionCommission_PCRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelProductionCommission_PCRightSection.SuspendLayout()
            CType(Me.PanelProductionCommission_PCLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelProductionCommission_PCLeftSection.SuspendLayout()
            Me.TabControlPanelStandardFeeTab_StandardFee.SuspendLayout()
            CType(Me.PanelStandardFee_StandardFee, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelStandardFee_StandardFee.SuspendLayout()
            CType(Me.PanelStandardFee_SFRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelStandardFee_SFRightSection.SuspendLayout()
            CType(Me.PanelStandardFee_SFLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelStandardFee_SFLeftSection.SuspendLayout()
            Me.TabControlPanelMediaCommissionTab_MediaCommission.SuspendLayout()
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.SuspendLayout()
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.SuspendLayout()
            Me.TableLayoutSelectionCriteria_SelectionCriteria.SuspendLayout()
            Me.PanelSelectionCriteria_RightSection.SuspendLayout()
            Me.PanelSelectionCriteria_LeftSection.SuspendLayout()
            Me.PanelLeftSection_PrimaryDisplayOption.SuspendLayout()
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DateTimePickerLeftSection_FeeTimePostedDateRangeTo
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ButtonDropDown.Visible = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ButtonFreeText.Checked = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.CustomFormat = ""
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.FocusHighlightEnabled = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.FreeTextEntryMode = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.IsPopupCalendarOpen = False
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Location = New System.Drawing.Point(147, 130)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.DisplayMonth = New Date(2011, 11, 1, 0, 0, 0, 0)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Name = "DateTimePickerLeftSection_FeeTimePostedDateRangeTo"
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.ReadOnly = False
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo.TabIndex = 11
            '
            'DateTimePickerLeftSection_FeeTimePostedDateRangeFrom
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.CustomFormat = ""
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.FocusHighlightEnabled = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.FreeTextEntryMode = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Location = New System.Drawing.Point(37, 130)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.DisplayMonth = New Date(2011, 11, 1, 0, 0, 0, 0)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Name = "DateTimePickerLeftSection_FeeTimePostedDateRangeFrom"
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.ReadOnly = False
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Size = New System.Drawing.Size(80, 20)
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.TabIndex = 9
            '
            'LabelLeftSection_FeeTimePostedDateRangeTo
            '
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.Location = New System.Drawing.Point(123, 130)
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.Name = "LabelLeftSection_FeeTimePostedDateRangeTo"
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.Size = New System.Drawing.Size(18, 20)
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.TabIndex = 10
            Me.LabelLeftSection_FeeTimePostedDateRangeTo.Text = "To:"
            '
            'LabelLeftSection_FeeTimePostedDateRangeFrom
            '
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.Location = New System.Drawing.Point(0, 130)
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.Name = "LabelLeftSection_FeeTimePostedDateRangeFrom"
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.Size = New System.Drawing.Size(31, 20)
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.TabIndex = 8
            Me.LabelLeftSection_FeeTimePostedDateRangeFrom.Text = "From:"
            '
            'LabelLeftSection_FeeTimePostedDateRange
            '
            Me.LabelLeftSection_FeeTimePostedDateRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLeftSection_FeeTimePostedDateRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeeTimePostedDateRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeeTimePostedDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_FeeTimePostedDateRange.Location = New System.Drawing.Point(0, 104)
            Me.LabelLeftSection_FeeTimePostedDateRange.Name = "LabelLeftSection_FeeTimePostedDateRange"
            Me.LabelLeftSection_FeeTimePostedDateRange.Size = New System.Drawing.Size(522, 20)
            Me.LabelLeftSection_FeeTimePostedDateRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeeTimePostedDateRange.TabIndex = 7
            Me.LabelLeftSection_FeeTimePostedDateRange.Text = "Fee Time Posted Date Range"
            '
            'TextBoxLeftSection_FeePeriodsTo
            '
            '
            '
            '
            Me.TextBoxLeftSection_FeePeriodsTo.Border.Class = "TextBoxBorder"
            Me.TextBoxLeftSection_FeePeriodsTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLeftSection_FeePeriodsTo.ButtonCustom.Visible = True
            Me.TextBoxLeftSection_FeePeriodsTo.CheckSpellingOnValidate = False
            Me.TextBoxLeftSection_FeePeriodsTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.PostPeriod
            Me.TextBoxLeftSection_FeePeriodsTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxLeftSection_FeePeriodsTo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLeftSection_FeePeriodsTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLeftSection_FeePeriodsTo.FocusHighlightEnabled = True
            Me.TextBoxLeftSection_FeePeriodsTo.Location = New System.Drawing.Point(147, 78)
            Me.TextBoxLeftSection_FeePeriodsTo.Name = "TextBoxLeftSection_FeePeriodsTo"
            Me.TextBoxLeftSection_FeePeriodsTo.Size = New System.Drawing.Size(80, 20)
            Me.TextBoxLeftSection_FeePeriodsTo.TabIndex = 6
            Me.TextBoxLeftSection_FeePeriodsTo.TabOnEnter = True
            '
            'TextBoxLeftSection_FeePeriodsFrom
            '
            '
            '
            '
            Me.TextBoxLeftSection_FeePeriodsFrom.Border.Class = "TextBoxBorder"
            Me.TextBoxLeftSection_FeePeriodsFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxLeftSection_FeePeriodsFrom.ButtonCustom.Visible = True
            Me.TextBoxLeftSection_FeePeriodsFrom.CheckSpellingOnValidate = False
            Me.TextBoxLeftSection_FeePeriodsFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.PostPeriod
            Me.TextBoxLeftSection_FeePeriodsFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxLeftSection_FeePeriodsFrom.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxLeftSection_FeePeriodsFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxLeftSection_FeePeriodsFrom.FocusHighlightEnabled = True
            Me.TextBoxLeftSection_FeePeriodsFrom.Location = New System.Drawing.Point(37, 78)
            Me.TextBoxLeftSection_FeePeriodsFrom.Name = "TextBoxLeftSection_FeePeriodsFrom"
            Me.TextBoxLeftSection_FeePeriodsFrom.Size = New System.Drawing.Size(80, 20)
            Me.TextBoxLeftSection_FeePeriodsFrom.TabIndex = 4
            Me.TextBoxLeftSection_FeePeriodsFrom.TabOnEnter = True
            '
            'LabelLeftSection_FeePeriodsTo
            '
            Me.LabelLeftSection_FeePeriodsTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeePeriodsTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeePeriodsTo.Location = New System.Drawing.Point(123, 78)
            Me.LabelLeftSection_FeePeriodsTo.Name = "LabelLeftSection_FeePeriodsTo"
            Me.LabelLeftSection_FeePeriodsTo.Size = New System.Drawing.Size(18, 20)
            Me.LabelLeftSection_FeePeriodsTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeePeriodsTo.TabIndex = 5
            Me.LabelLeftSection_FeePeriodsTo.Text = "To:"
            '
            'LabelLeftSection_FeePeriodsFrom
            '
            Me.LabelLeftSection_FeePeriodsFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeePeriodsFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeePeriodsFrom.Location = New System.Drawing.Point(0, 78)
            Me.LabelLeftSection_FeePeriodsFrom.Name = "LabelLeftSection_FeePeriodsFrom"
            Me.LabelLeftSection_FeePeriodsFrom.Size = New System.Drawing.Size(31, 20)
            Me.LabelLeftSection_FeePeriodsFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeePeriodsFrom.TabIndex = 3
            Me.LabelLeftSection_FeePeriodsFrom.Text = "From:"
            '
            'LabelLeftSection_FeePeriods
            '
            Me.LabelLeftSection_FeePeriods.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLeftSection_FeePeriods.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_FeePeriods.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_FeePeriods.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_FeePeriods.Location = New System.Drawing.Point(0, 52)
            Me.LabelLeftSection_FeePeriods.Name = "LabelLeftSection_FeePeriods"
            Me.LabelLeftSection_FeePeriods.Size = New System.Drawing.Size(522, 20)
            Me.LabelLeftSection_FeePeriods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_FeePeriods.TabIndex = 2
            Me.LabelLeftSection_FeePeriods.Text = "Fee Periods"
            '
            'DataGridViewSelectionCriteria_Criteria
            '
            Me.DataGridViewSelectionCriteria_Criteria.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectionCriteria_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectionCriteria_Criteria.AutoFilterLookupColumns = False
            Me.DataGridViewSelectionCriteria_Criteria.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectionCriteria_Criteria.BackColor = System.Drawing.Color.White
            Me.DataGridViewSelectionCriteria_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectionCriteria_Criteria.Enabled = False
            Me.DataGridViewSelectionCriteria_Criteria.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectionCriteria_Criteria.ItemDescription = ""
            Me.DataGridViewSelectionCriteria_Criteria.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectionCriteria_Criteria.MultiSelect = True
            Me.DataGridViewSelectionCriteria_Criteria.Name = "DataGridViewSelectionCriteria_Criteria"
            Me.DataGridViewSelectionCriteria_Criteria.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectionCriteria_Criteria.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectionCriteria_Criteria.Size = New System.Drawing.Size(1056, 274)
            Me.DataGridViewSelectionCriteria_Criteria.TabIndex = 4
            Me.DataGridViewSelectionCriteria_Criteria.UseEmbeddedNavigator = False
            Me.DataGridViewSelectionCriteria_Criteria.ViewCaptionHeight = -1
            '
            'RadioButtonSelectionCriteria_ClientDivisionProduct
            '
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Location = New System.Drawing.Point(203, 4)
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Name = "RadioButtonSelectionCriteria_ClientDivisionProduct"
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Size = New System.Drawing.Size(133, 20)
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.TabIndex = 3
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.TabStop = False
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Text = "Client/Division/Product"
            '
            'RadioButtonSelectionCriteria_ClientDivision
            '
            Me.RadioButtonSelectionCriteria_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_ClientDivision.Location = New System.Drawing.Point(104, 4)
            Me.RadioButtonSelectionCriteria_ClientDivision.Name = "RadioButtonSelectionCriteria_ClientDivision"
            Me.RadioButtonSelectionCriteria_ClientDivision.Size = New System.Drawing.Size(93, 20)
            Me.RadioButtonSelectionCriteria_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_ClientDivision.TabIndex = 2
            Me.RadioButtonSelectionCriteria_ClientDivision.TabStop = False
            Me.RadioButtonSelectionCriteria_ClientDivision.Text = "Client/Division"
            '
            'RadioButtonSelectionCriteria_Client
            '
            Me.RadioButtonSelectionCriteria_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_Client.Location = New System.Drawing.Point(45, 4)
            Me.RadioButtonSelectionCriteria_Client.Name = "RadioButtonSelectionCriteria_Client"
            Me.RadioButtonSelectionCriteria_Client.Size = New System.Drawing.Size(53, 20)
            Me.RadioButtonSelectionCriteria_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_Client.TabIndex = 1
            Me.RadioButtonSelectionCriteria_Client.TabStop = False
            Me.RadioButtonSelectionCriteria_Client.Text = "Client"
            '
            'RadioButtonSelectionCriteria_All
            '
            Me.RadioButtonSelectionCriteria_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_All.Checked = True
            Me.RadioButtonSelectionCriteria_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectionCriteria_All.CheckValue = "Y"
            Me.RadioButtonSelectionCriteria_All.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectionCriteria_All.Name = "RadioButtonSelectionCriteria_All"
            Me.RadioButtonSelectionCriteria_All.Size = New System.Drawing.Size(35, 20)
            Me.RadioButtonSelectionCriteria_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_All.TabIndex = 0
            Me.RadioButtonSelectionCriteria_All.Text = "All"
            '
            'DataGridViewProductionCommission_Functions
            '
            Me.DataGridViewProductionCommission_Functions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProductionCommission_Functions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProductionCommission_Functions.AutoFilterLookupColumns = False
            Me.DataGridViewProductionCommission_Functions.AutoloadRepositoryDatasource = True
            Me.DataGridViewProductionCommission_Functions.BackColor = System.Drawing.Color.White
            Me.DataGridViewProductionCommission_Functions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewProductionCommission_Functions.Enabled = False
            Me.DataGridViewProductionCommission_Functions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProductionCommission_Functions.ItemDescription = ""
            Me.DataGridViewProductionCommission_Functions.Location = New System.Drawing.Point(6, 26)
            Me.DataGridViewProductionCommission_Functions.MultiSelect = True
            Me.DataGridViewProductionCommission_Functions.Name = "DataGridViewProductionCommission_Functions"
            Me.DataGridViewProductionCommission_Functions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewProductionCommission_Functions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProductionCommission_Functions.Size = New System.Drawing.Size(642, 380)
            Me.DataGridViewProductionCommission_Functions.TabIndex = 8
            Me.DataGridViewProductionCommission_Functions.UseEmbeddedNavigator = False
            Me.DataGridViewProductionCommission_Functions.ViewCaptionHeight = -1
            '
            'DataGridViewProductionCommission_SalesClasses
            '
            Me.DataGridViewProductionCommission_SalesClasses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProductionCommission_SalesClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProductionCommission_SalesClasses.AutoFilterLookupColumns = False
            Me.DataGridViewProductionCommission_SalesClasses.AutoloadRepositoryDatasource = True
            Me.DataGridViewProductionCommission_SalesClasses.BackColor = System.Drawing.Color.White
            Me.DataGridViewProductionCommission_SalesClasses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewProductionCommission_SalesClasses.DataSource = Nothing
            Me.DataGridViewProductionCommission_SalesClasses.Enabled = False
            Me.DataGridViewProductionCommission_SalesClasses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProductionCommission_SalesClasses.ItemDescription = ""
            Me.DataGridViewProductionCommission_SalesClasses.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewProductionCommission_SalesClasses.MultiSelect = True
            Me.DataGridViewProductionCommission_SalesClasses.Name = "DataGridViewProductionCommission_SalesClasses"
            Me.DataGridViewProductionCommission_SalesClasses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewProductionCommission_SalesClasses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProductionCommission_SalesClasses.Size = New System.Drawing.Size(389, 380)
            Me.DataGridViewProductionCommission_SalesClasses.TabIndex = 4
            Me.DataGridViewProductionCommission_SalesClasses.UseEmbeddedNavigator = False
            Me.DataGridViewProductionCommission_SalesClasses.ViewCaptionHeight = -1
            '
            'CheckBoxProductionCommission_PostedBasedOnFunctions
            '
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.CheckValue = 0
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.CheckValueChecked = 1
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.CheckValueUnchecked = 0
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.ChildControls = CType(resources.GetObject("CheckBoxProductionCommission_PostedBasedOnFunctions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Enabled = False
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Location = New System.Drawing.Point(6, 0)
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Name = "CheckBoxProductionCommission_PostedBasedOnFunctions"
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.OldestSibling = Nothing
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.SecurityEnabled = True
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.SiblingControls = CType(resources.GetObject("CheckBoxProductionCommission_PostedBasedOnFunctions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Size = New System.Drawing.Size(642, 20)
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.TabIndex = 7
            Me.CheckBoxProductionCommission_PostedBasedOnFunctions.Text = "Posted based on Functions"
            '
            'CheckBoxProductionCommission_PostedBasedOnSalesClass
            '
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.CheckValue = 0
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.CheckValueChecked = 1
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.CheckValueUnchecked = 0
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.ChildControls = CType(resources.GetObject("CheckBoxProductionCommission_PostedBasedOnSalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Enabled = False
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Name = "CheckBoxProductionCommission_PostedBasedOnSalesClass"
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.OldestSibling = Nothing
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.SecurityEnabled = True
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.SiblingControls = CType(resources.GetObject("CheckBoxProductionCommission_PostedBasedOnSalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Size = New System.Drawing.Size(389, 20)
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.TabIndex = 3
            Me.CheckBoxProductionCommission_PostedBasedOnSalesClass.Text = "Posted based on Sales Class"
            '
            'CheckBoxProductionCommission_ProductionCommission
            '
            Me.CheckBoxProductionCommission_ProductionCommission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxProductionCommission_ProductionCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProductionCommission_ProductionCommission.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxProductionCommission_ProductionCommission.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.CheckBoxProductionCommission_ProductionCommission.BackgroundStyle.BorderBottomWidth = 1
            Me.CheckBoxProductionCommission_ProductionCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProductionCommission_ProductionCommission.CheckValue = 0
            Me.CheckBoxProductionCommission_ProductionCommission.CheckValueChecked = 1
            Me.CheckBoxProductionCommission_ProductionCommission.CheckValueUnchecked = 0
            Me.CheckBoxProductionCommission_ProductionCommission.ChildControls = CType(resources.GetObject("CheckBoxProductionCommission_ProductionCommission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_ProductionCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProductionCommission_ProductionCommission.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckBoxProductionCommission_ProductionCommission.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxProductionCommission_ProductionCommission.Name = "CheckBoxProductionCommission_ProductionCommission"
            Me.CheckBoxProductionCommission_ProductionCommission.OldestSibling = Nothing
            Me.CheckBoxProductionCommission_ProductionCommission.SecurityEnabled = True
            Me.CheckBoxProductionCommission_ProductionCommission.SiblingControls = CType(resources.GetObject("CheckBoxProductionCommission_ProductionCommission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProductionCommission_ProductionCommission.Size = New System.Drawing.Size(1048, 20)
            Me.CheckBoxProductionCommission_ProductionCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProductionCommission_ProductionCommission.TabIndex = 0
            Me.CheckBoxProductionCommission_ProductionCommission.Text = "Production Commission"
            Me.CheckBoxProductionCommission_ProductionCommission.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            '
            'DataGridViewStandardFee_Functions
            '
            Me.DataGridViewStandardFee_Functions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewStandardFee_Functions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewStandardFee_Functions.AutoFilterLookupColumns = False
            Me.DataGridViewStandardFee_Functions.AutoloadRepositoryDatasource = True
            Me.DataGridViewStandardFee_Functions.BackColor = System.Drawing.Color.White
            Me.DataGridViewStandardFee_Functions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewStandardFee_Functions.DataSource = Nothing
            Me.DataGridViewStandardFee_Functions.Enabled = False
            Me.DataGridViewStandardFee_Functions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewStandardFee_Functions.ItemDescription = ""
            Me.DataGridViewStandardFee_Functions.Location = New System.Drawing.Point(6, 26)
            Me.DataGridViewStandardFee_Functions.MultiSelect = True
            Me.DataGridViewStandardFee_Functions.Name = "DataGridViewStandardFee_Functions"
            Me.DataGridViewStandardFee_Functions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewStandardFee_Functions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewStandardFee_Functions.Size = New System.Drawing.Size(635, 354)
            Me.DataGridViewStandardFee_Functions.TabIndex = 9
            Me.DataGridViewStandardFee_Functions.UseEmbeddedNavigator = False
            Me.DataGridViewStandardFee_Functions.ViewCaptionHeight = -1
            '
            'DataGridViewStandardFee_SalesClasses
            '
            Me.DataGridViewStandardFee_SalesClasses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewStandardFee_SalesClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewStandardFee_SalesClasses.AutoFilterLookupColumns = False
            Me.DataGridViewStandardFee_SalesClasses.AutoloadRepositoryDatasource = True
            Me.DataGridViewStandardFee_SalesClasses.BackColor = System.Drawing.Color.White
            Me.DataGridViewStandardFee_SalesClasses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewStandardFee_SalesClasses.Enabled = False
            Me.DataGridViewStandardFee_SalesClasses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewStandardFee_SalesClasses.ItemDescription = ""
            Me.DataGridViewStandardFee_SalesClasses.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewStandardFee_SalesClasses.MultiSelect = True
            Me.DataGridViewStandardFee_SalesClasses.Name = "DataGridViewStandardFee_SalesClasses"
            Me.DataGridViewStandardFee_SalesClasses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewStandardFee_SalesClasses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewStandardFee_SalesClasses.Size = New System.Drawing.Size(391, 354)
            Me.DataGridViewStandardFee_SalesClasses.TabIndex = 5
            Me.DataGridViewStandardFee_SalesClasses.UseEmbeddedNavigator = False
            Me.DataGridViewStandardFee_SalesClasses.ViewCaptionHeight = -1
            '
            'CheckBoxStandardFee_AllComponentsMarkedAsFee
            '
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.CheckValue = 0
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.CheckValueChecked = 1
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.CheckValueUnchecked = 0
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.ChildControls = Nothing
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Enabled = False
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Location = New System.Drawing.Point(8, 30)
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Name = "CheckBoxStandardFee_AllComponentsMarkedAsFee"
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.OldestSibling = Nothing
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.SecurityEnabled = True
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.SiblingControls = Nothing
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.TabIndex = 1
            Me.CheckBoxStandardFee_AllComponentsMarkedAsFee.Text = "All Job/Comp marked as Fee"
            '
            'CheckBoxStandardFee_PostedBasedOnFunctions
            '
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.CheckValue = 0
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.CheckValueChecked = 1
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.CheckValueUnchecked = 0
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.ChildControls = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Enabled = False
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Location = New System.Drawing.Point(6, 0)
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Name = "CheckBoxStandardFee_PostedBasedOnFunctions"
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.OldestSibling = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.SecurityEnabled = True
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.SiblingControls = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Size = New System.Drawing.Size(635, 20)
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.TabIndex = 8
            Me.CheckBoxStandardFee_PostedBasedOnFunctions.Text = "Posted based on Functions"
            '
            'CheckBoxStandardFee_PostedBasedOnSalesClass
            '
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.CheckValue = 0
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.CheckValueChecked = 1
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.CheckValueUnchecked = 0
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.ChildControls = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Enabled = False
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Name = "CheckBoxStandardFee_PostedBasedOnSalesClass"
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.OldestSibling = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.SecurityEnabled = True
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.SiblingControls = Nothing
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Size = New System.Drawing.Size(391, 20)
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.TabIndex = 4
            Me.CheckBoxStandardFee_PostedBasedOnSalesClass.Text = "Posted based on Sales Class"
            '
            'CheckBoxStandardFee_StandardFee
            '
            Me.CheckBoxStandardFee_StandardFee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxStandardFee_StandardFee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxStandardFee_StandardFee.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxStandardFee_StandardFee.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.CheckBoxStandardFee_StandardFee.BackgroundStyle.BorderBottomWidth = 1
            Me.CheckBoxStandardFee_StandardFee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxStandardFee_StandardFee.CheckValue = 0
            Me.CheckBoxStandardFee_StandardFee.CheckValueChecked = 1
            Me.CheckBoxStandardFee_StandardFee.CheckValueUnchecked = 0
            Me.CheckBoxStandardFee_StandardFee.ChildControls = Nothing
            Me.CheckBoxStandardFee_StandardFee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxStandardFee_StandardFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckBoxStandardFee_StandardFee.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxStandardFee_StandardFee.Name = "CheckBoxStandardFee_StandardFee"
            Me.CheckBoxStandardFee_StandardFee.OldestSibling = Nothing
            Me.CheckBoxStandardFee_StandardFee.SecurityEnabled = True
            Me.CheckBoxStandardFee_StandardFee.SiblingControls = Nothing
            Me.CheckBoxStandardFee_StandardFee.Size = New System.Drawing.Size(1048, 20)
            Me.CheckBoxStandardFee_StandardFee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxStandardFee_StandardFee.TabIndex = 0
            Me.CheckBoxStandardFee_StandardFee.Text = "Standard Fee (Income Only)"
            Me.CheckBoxStandardFee_StandardFee.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            '
            'TabControlForm_ServiceFeeReconciliation
            '
            Me.TabControlForm_ServiceFeeReconciliation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ServiceFeeReconciliation.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_ServiceFeeReconciliation.CanReorderTabs = False
            Me.TabControlForm_ServiceFeeReconciliation.Controls.Add(Me.TabControlPanelFeeCriteriaTab_FeeCriteria)
            Me.TabControlForm_ServiceFeeReconciliation.Controls.Add(Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria)
            Me.TabControlForm_ServiceFeeReconciliation.Controls.Add(Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria)
            Me.TabControlForm_ServiceFeeReconciliation.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ServiceFeeReconciliation.Name = "TabControlForm_ServiceFeeReconciliation"
            Me.TabControlForm_ServiceFeeReconciliation.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ServiceFeeReconciliation.SelectedTabIndex = 0
            Me.TabControlForm_ServiceFeeReconciliation.Size = New System.Drawing.Size(1064, 492)
            Me.TabControlForm_ServiceFeeReconciliation.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ServiceFeeReconciliation.TabIndex = 4
            Me.TabControlForm_ServiceFeeReconciliation.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ServiceFeeReconciliation.Tabs.Add(Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab)
            Me.TabControlForm_ServiceFeeReconciliation.Tabs.Add(Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab)
            Me.TabControlForm_ServiceFeeReconciliation.Tabs.Add(Me.TabItemServiceFeeReconciliation_FeeCriteriaTab)
            '
            'TabControlPanelFeeCriteriaTab_FeeCriteria
            '
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Controls.Add(Me.TabControlFeeCriteria_Settings)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Name = "TabControlPanelFeeCriteriaTab_FeeCriteria"
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Size = New System.Drawing.Size(1064, 470)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.Style.GradientAngle = 90
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.TabIndex = 3
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.TabItem = Me.TabItemServiceFeeReconciliation_FeeCriteriaTab
            '
            'TabControlFeeCriteria_Settings
            '
            Me.TabControlFeeCriteria_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlFeeCriteria_Settings.CanReorderTabs = False
            Me.TabControlFeeCriteria_Settings.Controls.Add(Me.TabControlPanelProductionCommissionTab_ProductionCommission)
            Me.TabControlFeeCriteria_Settings.Controls.Add(Me.TabControlPanelStandardFeeTab_StandardFee)
            Me.TabControlFeeCriteria_Settings.Controls.Add(Me.TabControlPanelMediaCommissionTab_MediaCommission)
            Me.TabControlFeeCriteria_Settings.Controls.Add(Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria)
            Me.TabControlFeeCriteria_Settings.Location = New System.Drawing.Point(4, 4)
            Me.TabControlFeeCriteria_Settings.Name = "TabControlFeeCriteria_Settings"
            Me.TabControlFeeCriteria_Settings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlFeeCriteria_Settings.SelectedTabIndex = 3
            Me.TabControlFeeCriteria_Settings.Size = New System.Drawing.Size(1056, 462)
            Me.TabControlFeeCriteria_Settings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlFeeCriteria_Settings.TabIndex = 10
            Me.TabControlFeeCriteria_Settings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlFeeCriteria_Settings.Tabs.Add(Me.TabItemSettings_StandardFeeTab)
            Me.TabControlFeeCriteria_Settings.Tabs.Add(Me.TabItemSettings_ProductionCommissionTab)
            Me.TabControlFeeCriteria_Settings.Tabs.Add(Me.TabItemSettings_MediaCommissionTab)
            Me.TabControlFeeCriteria_Settings.Tabs.Add(Me.TabItemSettings_FeeTimeCriteriaTab)
            Me.TabControlFeeCriteria_Settings.Text = "TabControl1"
            '
            'TabControlPanelProductionCommissionTab_ProductionCommission
            '
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Controls.Add(Me.PanelProductionCommission_ProductionCommission)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Controls.Add(Me.CheckBoxProductionCommission_ProductionCommission)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Name = "TabControlPanelProductionCommissionTab_ProductionCommission"
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Size = New System.Drawing.Size(1056, 440)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.Style.GradientAngle = 90
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.TabIndex = 2
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.TabItem = Me.TabItemSettings_ProductionCommissionTab
            '
            'PanelProductionCommission_ProductionCommission
            '
            Me.PanelProductionCommission_ProductionCommission.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelProductionCommission_ProductionCommission.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelProductionCommission_ProductionCommission.Appearance.Options.UseBackColor = True
            Me.PanelProductionCommission_ProductionCommission.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelProductionCommission_ProductionCommission.Controls.Add(Me.PanelProductionCommission_PCRightSection)
            Me.PanelProductionCommission_ProductionCommission.Controls.Add(Me.ExpandableSplitterProductionCommission_PCLeftRightSection)
            Me.PanelProductionCommission_ProductionCommission.Controls.Add(Me.PanelProductionCommission_PCLeftSection)
            Me.PanelProductionCommission_ProductionCommission.Location = New System.Drawing.Point(4, 30)
            Me.PanelProductionCommission_ProductionCommission.Name = "PanelProductionCommission_ProductionCommission"
            Me.PanelProductionCommission_ProductionCommission.Size = New System.Drawing.Size(1049, 406)
            Me.PanelProductionCommission_ProductionCommission.TabIndex = 1
            '
            'PanelProductionCommission_PCRightSection
            '
            Me.PanelProductionCommission_PCRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelProductionCommission_PCRightSection.Appearance.Options.UseBackColor = True
            Me.PanelProductionCommission_PCRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelProductionCommission_PCRightSection.Controls.Add(Me.DataGridViewProductionCommission_Functions)
            Me.PanelProductionCommission_PCRightSection.Controls.Add(Me.CheckBoxProductionCommission_PostedBasedOnFunctions)
            Me.PanelProductionCommission_PCRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelProductionCommission_PCRightSection.Location = New System.Drawing.Point(401, 0)
            Me.PanelProductionCommission_PCRightSection.Name = "PanelProductionCommission_PCRightSection"
            Me.PanelProductionCommission_PCRightSection.Size = New System.Drawing.Size(648, 406)
            Me.PanelProductionCommission_PCRightSection.TabIndex = 6
            '
            'ExpandableSplitterProductionCommission_PCLeftRightSection
            '
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.ExpandableControl = Me.PanelProductionCommission_PCLeftSection
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.Location = New System.Drawing.Point(395, 0)
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.Name = "ExpandableSplitterProductionCommission_PCLeftRightSection"
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.Size = New System.Drawing.Size(6, 406)
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.TabIndex = 5
            Me.ExpandableSplitterProductionCommission_PCLeftRightSection.TabStop = False
            '
            'PanelProductionCommission_PCLeftSection
            '
            Me.PanelProductionCommission_PCLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelProductionCommission_PCLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelProductionCommission_PCLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelProductionCommission_PCLeftSection.Controls.Add(Me.DataGridViewProductionCommission_SalesClasses)
            Me.PanelProductionCommission_PCLeftSection.Controls.Add(Me.CheckBoxProductionCommission_PostedBasedOnSalesClass)
            Me.PanelProductionCommission_PCLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelProductionCommission_PCLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelProductionCommission_PCLeftSection.Name = "PanelProductionCommission_PCLeftSection"
            Me.PanelProductionCommission_PCLeftSection.Size = New System.Drawing.Size(395, 406)
            Me.PanelProductionCommission_PCLeftSection.TabIndex = 2
            '
            'TabItemSettings_ProductionCommissionTab
            '
            Me.TabItemSettings_ProductionCommissionTab.AttachedControl = Me.TabControlPanelProductionCommissionTab_ProductionCommission
            Me.TabItemSettings_ProductionCommissionTab.Name = "TabItemSettings_ProductionCommissionTab"
            Me.TabItemSettings_ProductionCommissionTab.Text = "Production Commission"
            '
            'TabControlPanelStandardFeeTab_StandardFee
            '
            Me.TabControlPanelStandardFeeTab_StandardFee.Controls.Add(Me.PanelStandardFee_StandardFee)
            Me.TabControlPanelStandardFeeTab_StandardFee.Controls.Add(Me.CheckBoxStandardFee_StandardFee)
            Me.TabControlPanelStandardFeeTab_StandardFee.Controls.Add(Me.CheckBoxStandardFee_AllComponentsMarkedAsFee)
            Me.TabControlPanelStandardFeeTab_StandardFee.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStandardFeeTab_StandardFee.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelStandardFeeTab_StandardFee.Name = "TabControlPanelStandardFeeTab_StandardFee"
            Me.TabControlPanelStandardFeeTab_StandardFee.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStandardFeeTab_StandardFee.Size = New System.Drawing.Size(1056, 440)
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStandardFeeTab_StandardFee.Style.GradientAngle = 90
            Me.TabControlPanelStandardFeeTab_StandardFee.TabIndex = 1
            Me.TabControlPanelStandardFeeTab_StandardFee.TabItem = Me.TabItemSettings_StandardFeeTab
            '
            'PanelStandardFee_StandardFee
            '
            Me.PanelStandardFee_StandardFee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelStandardFee_StandardFee.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelStandardFee_StandardFee.Appearance.Options.UseBackColor = True
            Me.PanelStandardFee_StandardFee.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelStandardFee_StandardFee.Controls.Add(Me.PanelStandardFee_SFRightSection)
            Me.PanelStandardFee_StandardFee.Controls.Add(Me.ExpandableSplitterStandardFee_SFLeftRightSection)
            Me.PanelStandardFee_StandardFee.Controls.Add(Me.PanelStandardFee_SFLeftSection)
            Me.PanelStandardFee_StandardFee.Location = New System.Drawing.Point(8, 56)
            Me.PanelStandardFee_StandardFee.Name = "PanelStandardFee_StandardFee"
            Me.PanelStandardFee_StandardFee.Size = New System.Drawing.Size(1044, 380)
            Me.PanelStandardFee_StandardFee.TabIndex = 2
            '
            'PanelStandardFee_SFRightSection
            '
            Me.PanelStandardFee_SFRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelStandardFee_SFRightSection.Appearance.Options.UseBackColor = True
            Me.PanelStandardFee_SFRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelStandardFee_SFRightSection.Controls.Add(Me.CheckBoxStandardFee_PostedBasedOnFunctions)
            Me.PanelStandardFee_SFRightSection.Controls.Add(Me.DataGridViewStandardFee_Functions)
            Me.PanelStandardFee_SFRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelStandardFee_SFRightSection.Location = New System.Drawing.Point(403, 0)
            Me.PanelStandardFee_SFRightSection.Name = "PanelStandardFee_SFRightSection"
            Me.PanelStandardFee_SFRightSection.Size = New System.Drawing.Size(641, 380)
            Me.PanelStandardFee_SFRightSection.TabIndex = 7
            '
            'ExpandableSplitterStandardFee_SFLeftRightSection
            '
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.ExpandableControl = Me.PanelStandardFee_SFLeftSection
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.Location = New System.Drawing.Point(397, 0)
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.Name = "ExpandableSplitterStandardFee_SFLeftRightSection"
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.Size = New System.Drawing.Size(6, 380)
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.TabIndex = 6
            Me.ExpandableSplitterStandardFee_SFLeftRightSection.TabStop = False
            '
            'PanelStandardFee_SFLeftSection
            '
            Me.PanelStandardFee_SFLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelStandardFee_SFLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelStandardFee_SFLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelStandardFee_SFLeftSection.Controls.Add(Me.CheckBoxStandardFee_PostedBasedOnSalesClass)
            Me.PanelStandardFee_SFLeftSection.Controls.Add(Me.DataGridViewStandardFee_SalesClasses)
            Me.PanelStandardFee_SFLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelStandardFee_SFLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelStandardFee_SFLeftSection.Name = "PanelStandardFee_SFLeftSection"
            Me.PanelStandardFee_SFLeftSection.Size = New System.Drawing.Size(397, 380)
            Me.PanelStandardFee_SFLeftSection.TabIndex = 3
            '
            'TabItemSettings_StandardFeeTab
            '
            Me.TabItemSettings_StandardFeeTab.AttachedControl = Me.TabControlPanelStandardFeeTab_StandardFee
            Me.TabItemSettings_StandardFeeTab.Name = "TabItemSettings_StandardFeeTab"
            Me.TabItemSettings_StandardFeeTab.Text = "Standard Fee"
            '
            'TabControlPanelMediaCommissionTab_MediaCommission
            '
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_OutOfHome)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_MediaCommission)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_Internet)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_Broadcast)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_Newspaper)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Controls.Add(Me.CheckBoxMediaCommission_Magazine)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Name = "TabControlPanelMediaCommissionTab_MediaCommission"
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Size = New System.Drawing.Size(1056, 440)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.Style.GradientAngle = 90
            Me.TabControlPanelMediaCommissionTab_MediaCommission.TabIndex = 3
            Me.TabControlPanelMediaCommissionTab_MediaCommission.TabItem = Me.TabItemSettings_MediaCommissionTab
            '
            'CheckBoxMediaCommission_OutOfHome
            '
            Me.CheckBoxMediaCommission_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_OutOfHome.CheckValue = 0
            Me.CheckBoxMediaCommission_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_OutOfHome.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_OutOfHome.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_OutOfHome.Enabled = False
            Me.CheckBoxMediaCommission_OutOfHome.Location = New System.Drawing.Point(8, 134)
            Me.CheckBoxMediaCommission_OutOfHome.Name = "CheckBoxMediaCommission_OutOfHome"
            Me.CheckBoxMediaCommission_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMediaCommission_OutOfHome.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_OutOfHome.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_OutOfHome.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxMediaCommission_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_OutOfHome.TabIndex = 5
            Me.CheckBoxMediaCommission_OutOfHome.Text = "Out of Home"
            '
            'CheckBoxMediaCommission_MediaCommission
            '
            Me.CheckBoxMediaCommission_MediaCommission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaCommission_MediaCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_MediaCommission.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.CheckBoxMediaCommission_MediaCommission.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.CheckBoxMediaCommission_MediaCommission.BackgroundStyle.BorderBottomWidth = 1
            Me.CheckBoxMediaCommission_MediaCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_MediaCommission.CheckValue = 0
            Me.CheckBoxMediaCommission_MediaCommission.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_MediaCommission.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_MediaCommission.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_MediaCommission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_MediaCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_MediaCommission.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckBoxMediaCommission_MediaCommission.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxMediaCommission_MediaCommission.Name = "CheckBoxMediaCommission_MediaCommission"
            Me.CheckBoxMediaCommission_MediaCommission.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_MediaCommission.SecurityEnabled = True
            Me.CheckBoxMediaCommission_MediaCommission.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_MediaCommission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_MediaCommission.Size = New System.Drawing.Size(1048, 20)
            Me.CheckBoxMediaCommission_MediaCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_MediaCommission.TabIndex = 0
            Me.CheckBoxMediaCommission_MediaCommission.Text = "Media Commission"
            Me.CheckBoxMediaCommission_MediaCommission.TextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            '
            'CheckBoxMediaCommission_Internet
            '
            Me.CheckBoxMediaCommission_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_Internet.CheckValue = 0
            Me.CheckBoxMediaCommission_Internet.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_Internet.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_Internet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_Internet.Enabled = False
            Me.CheckBoxMediaCommission_Internet.Location = New System.Drawing.Point(8, 108)
            Me.CheckBoxMediaCommission_Internet.Name = "CheckBoxMediaCommission_Internet"
            Me.CheckBoxMediaCommission_Internet.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_Internet.SecurityEnabled = True
            Me.CheckBoxMediaCommission_Internet.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_Internet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Internet.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxMediaCommission_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_Internet.TabIndex = 4
            Me.CheckBoxMediaCommission_Internet.Text = "Internet"
            '
            'CheckBoxMediaCommission_Broadcast
            '
            Me.CheckBoxMediaCommission_Broadcast.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_Broadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_Broadcast.CheckValue = 0
            Me.CheckBoxMediaCommission_Broadcast.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_Broadcast.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_Broadcast.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_Broadcast.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Broadcast.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_Broadcast.Enabled = False
            Me.CheckBoxMediaCommission_Broadcast.Location = New System.Drawing.Point(8, 30)
            Me.CheckBoxMediaCommission_Broadcast.Name = "CheckBoxMediaCommission_Broadcast"
            Me.CheckBoxMediaCommission_Broadcast.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_Broadcast.SecurityEnabled = True
            Me.CheckBoxMediaCommission_Broadcast.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_Broadcast.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Broadcast.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxMediaCommission_Broadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_Broadcast.TabIndex = 1
            Me.CheckBoxMediaCommission_Broadcast.Text = "Broadcast"
            '
            'CheckBoxMediaCommission_Newspaper
            '
            Me.CheckBoxMediaCommission_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_Newspaper.CheckValue = 0
            Me.CheckBoxMediaCommission_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_Newspaper.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_Newspaper.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_Newspaper.Enabled = False
            Me.CheckBoxMediaCommission_Newspaper.Location = New System.Drawing.Point(8, 82)
            Me.CheckBoxMediaCommission_Newspaper.Name = "CheckBoxMediaCommission_Newspaper"
            Me.CheckBoxMediaCommission_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_Newspaper.SecurityEnabled = True
            Me.CheckBoxMediaCommission_Newspaper.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_Newspaper.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Newspaper.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxMediaCommission_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_Newspaper.TabIndex = 3
            Me.CheckBoxMediaCommission_Newspaper.Text = "Newspaper"
            '
            'CheckBoxMediaCommission_Magazine
            '
            Me.CheckBoxMediaCommission_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaCommission_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaCommission_Magazine.CheckValue = 0
            Me.CheckBoxMediaCommission_Magazine.CheckValueChecked = 1
            Me.CheckBoxMediaCommission_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMediaCommission_Magazine.ChildControls = CType(resources.GetObject("CheckBoxMediaCommission_Magazine.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaCommission_Magazine.Enabled = False
            Me.CheckBoxMediaCommission_Magazine.Location = New System.Drawing.Point(8, 56)
            Me.CheckBoxMediaCommission_Magazine.Name = "CheckBoxMediaCommission_Magazine"
            Me.CheckBoxMediaCommission_Magazine.OldestSibling = Nothing
            Me.CheckBoxMediaCommission_Magazine.SecurityEnabled = True
            Me.CheckBoxMediaCommission_Magazine.SiblingControls = CType(resources.GetObject("CheckBoxMediaCommission_Magazine.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaCommission_Magazine.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxMediaCommission_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaCommission_Magazine.TabIndex = 2
            Me.CheckBoxMediaCommission_Magazine.Text = "Magazine"
            '
            'TabItemSettings_MediaCommissionTab
            '
            Me.TabItemSettings_MediaCommissionTab.AttachedControl = Me.TabControlPanelMediaCommissionTab_MediaCommission
            Me.TabItemSettings_MediaCommissionTab.Name = "TabItemSettings_MediaCommissionTab"
            Me.TabItemSettings_MediaCommissionTab.Text = "Media Commission"
            '
            'TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria
            '
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Controls.Add(Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Controls.Add(Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Controls.Add(Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Controls.Add(Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Controls.Add(Me.CheckBoxFeeTimeCriteria_StandardFeeTime)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Name = "TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria"
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Size = New System.Drawing.Size(1056, 440)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.Style.GradientAngle = 90
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.TabIndex = 4
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.TabItem = Me.TabItemSettings_FeeTimeCriteriaTab
            '
            'CheckBoxFeeTimeCriteria_FeeTimeProductionCommission
            '
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.CheckValue = 0
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.CheckValueChecked = 1
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.CheckValueUnchecked = 0
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.ChildControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Location = New System.Drawing.Point(8, 82)
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Name = "CheckBoxFeeTimeCriteria_FeeTimeProductionCommission"
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.OldestSibling = Nothing
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.SecurityEnabled = True
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.SiblingControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Size = New System.Drawing.Size(188, 20)
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.TabIndex = 3
            Me.CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Text = "Fee Time Production Commission"
            '
            'CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly
            '
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.CheckValue = 0
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.CheckValueChecked = 1
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.CheckValueUnchecked = 0
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.ChildControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Name = "CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly"
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.OldestSibling = Nothing
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.SecurityEnabled = True
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.SiblingControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Size = New System.Drawing.Size(192, 20)
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.TabIndex = 0
            Me.CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Text = "Include Un-reconciled Only"
            '
            'CheckBoxFeeTimeCriteria_FeeTimeMediaCommission
            '
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.CheckValue = 0
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.CheckValueChecked = 1
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.CheckValueUnchecked = 0
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.ChildControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Location = New System.Drawing.Point(8, 108)
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Name = "CheckBoxFeeTimeCriteria_FeeTimeMediaCommission"
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.OldestSibling = Nothing
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.SecurityEnabled = True
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.SiblingControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Size = New System.Drawing.Size(188, 20)
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.TabIndex = 4
            Me.CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Text = "Fee Time Media Commission"
            '
            'LabelFeeTimeCriteria_TypesOfFeeTimeToInclude
            '
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Location = New System.Drawing.Point(4, 30)
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Name = "LabelFeeTimeCriteria_TypesOfFeeTimeToInclude"
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Size = New System.Drawing.Size(192, 20)
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.TabIndex = 1
            Me.LabelFeeTimeCriteria_TypesOfFeeTimeToInclude.Text = "Types of Fee Time to Include"
            '
            'CheckBoxFeeTimeCriteria_StandardFeeTime
            '
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.CheckValue = 0
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.CheckValueChecked = 1
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.CheckValueUnchecked = 0
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.ChildControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_StandardFeeTime.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.Location = New System.Drawing.Point(8, 56)
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.Name = "CheckBoxFeeTimeCriteria_StandardFeeTime"
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.OldestSibling = Nothing
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.SecurityEnabled = True
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.SiblingControls = CType(resources.GetObject("CheckBoxFeeTimeCriteria_StandardFeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.Size = New System.Drawing.Size(188, 20)
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.TabIndex = 2
            Me.CheckBoxFeeTimeCriteria_StandardFeeTime.Text = "Standard Fee Time"
            '
            'TabItemSettings_FeeTimeCriteriaTab
            '
            Me.TabItemSettings_FeeTimeCriteriaTab.AttachedControl = Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria
            Me.TabItemSettings_FeeTimeCriteriaTab.Name = "TabItemSettings_FeeTimeCriteriaTab"
            Me.TabItemSettings_FeeTimeCriteriaTab.Text = "Fee Time Criteria"
            '
            'TabItemServiceFeeReconciliation_FeeCriteriaTab
            '
            Me.TabItemServiceFeeReconciliation_FeeCriteriaTab.AttachedControl = Me.TabControlPanelFeeCriteriaTab_FeeCriteria
            Me.TabItemServiceFeeReconciliation_FeeCriteriaTab.Name = "TabItemServiceFeeReconciliation_FeeCriteriaTab"
            Me.TabItemServiceFeeReconciliation_FeeCriteriaTab.Text = "Fee Criteria"
            '
            'TabControlPanelSelectionCriteriaTab_SelectionCriteria
            '
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.TableLayoutSelectionCriteria_SelectionCriteria)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_All)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_Client)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_ClientDivision)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_ClientDivisionProduct)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Controls.Add(Me.DataGridViewSelectionCriteria_Criteria)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Name = "TabControlPanelSelectionCriteriaTab_SelectionCriteria"
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Size = New System.Drawing.Size(1064, 470)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.Style.GradientAngle = 90
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.TabIndex = 0
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.TabItem = Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab
            '
            'TableLayoutSelectionCriteria_SelectionCriteria
            '
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.BackColor = System.Drawing.Color.White
            Me.TableLayoutSelectionCriteria_SelectionCriteria.ColumnCount = 2
            Me.TableLayoutSelectionCriteria_SelectionCriteria.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutSelectionCriteria_SelectionCriteria.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Controls.Add(Me.PanelSelectionCriteria_RightSection, 1, 0)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Controls.Add(Me.PanelSelectionCriteria_LeftSection, 0, 0)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Location = New System.Drawing.Point(4, 310)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Name = "TableLayoutSelectionCriteria_SelectionCriteria"
            Me.TableLayoutSelectionCriteria_SelectionCriteria.RowCount = 1
            Me.TableLayoutSelectionCriteria_SelectionCriteria.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutSelectionCriteria_SelectionCriteria.Size = New System.Drawing.Size(1056, 156)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.TabIndex = 5
            '
            'PanelSelectionCriteria_RightSection
            '
            Me.PanelSelectionCriteria_RightSection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSelectionCriteria_RightSection.BackColor = System.Drawing.Color.White
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.LabelRightSection_GroupByOptions)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.ComboBoxRightSection_SummaryStyle)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.ComboBoxRightSection_GroupBy)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.LabelRightSection_GroupBy)
            Me.PanelSelectionCriteria_RightSection.Controls.Add(Me.LabelRightSection_SummaryStyle)
            Me.PanelSelectionCriteria_RightSection.Location = New System.Drawing.Point(531, 3)
            Me.PanelSelectionCriteria_RightSection.Name = "PanelSelectionCriteria_RightSection"
            Me.PanelSelectionCriteria_RightSection.Size = New System.Drawing.Size(522, 150)
            Me.PanelSelectionCriteria_RightSection.TabIndex = 24
            '
            'CheckBoxRightSection_AddFeeDescriptionToGroupBy
            '
            '
            '
            '
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.CheckValue = 0
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.CheckValueChecked = 1
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.CheckValueUnchecked = 0
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.ChildControls = CType(resources.GetObject("CheckBoxRightSection_AddFeeDescriptionToGroupBy.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.Location = New System.Drawing.Point(183, 78)
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.Name = "CheckBoxRightSection_AddFeeDescriptionToGroupBy"
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.OldestSibling = Nothing
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.SecurityEnabled = True
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.SiblingControls = CType(resources.GetObject("CheckBoxRightSection_AddFeeDescriptionToGroupBy.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.Size = New System.Drawing.Size(292, 20)
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.TabIndex = 4
            Me.CheckBoxRightSection_AddFeeDescriptionToGroupBy.Text = "Add Time/Fee Details"
            '
            'CheckBoxRightSection_IncludeServiceFeeTypeLevel
            '
            '
            '
            '
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.CheckValue = 0
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.CheckValueChecked = 1
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.CheckValueUnchecked = 0
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.ChildControls = CType(resources.GetObject("CheckBoxRightSection_IncludeServiceFeeTypeLevel.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Enabled = False
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Location = New System.Drawing.Point(0, 78)
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Name = "CheckBoxRightSection_IncludeServiceFeeTypeLevel"
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.OldestSibling = Nothing
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.SecurityEnabled = True
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.SiblingControls = CType(resources.GetObject("CheckBoxRightSection_IncludeServiceFeeTypeLevel.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Size = New System.Drawing.Size(177, 20)
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.TabIndex = 3
            Me.CheckBoxRightSection_IncludeServiceFeeTypeLevel.Text = "Include Service Fee Type Level"
            '
            'LabelRightSection_GroupByOptions
            '
            Me.LabelRightSection_GroupByOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightSection_GroupByOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupByOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_GroupByOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelRightSection_GroupByOptions.Location = New System.Drawing.Point(0, 52)
            Me.LabelRightSection_GroupByOptions.Name = "LabelRightSection_GroupByOptions"
            Me.LabelRightSection_GroupByOptions.Size = New System.Drawing.Size(521, 20)
            Me.LabelRightSection_GroupByOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_GroupByOptions.TabIndex = 2
            Me.LabelRightSection_GroupByOptions.Text = "Group By Options"
            '
            'ComboBoxRightSection_SummaryStyle
            '
            Me.ComboBoxRightSection_SummaryStyle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_SummaryStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_SummaryStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_SummaryStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_SummaryStyle.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_SummaryStyle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_SummaryStyle.BookmarkingEnabled = False
            Me.ComboBoxRightSection_SummaryStyle.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ServiceFeeReconciliationSummaryStyles
            Me.ComboBoxRightSection_SummaryStyle.DisableMouseWheel = False
            Me.ComboBoxRightSection_SummaryStyle.DisplayMember = "Description"
            Me.ComboBoxRightSection_SummaryStyle.DisplayName = ""
            Me.ComboBoxRightSection_SummaryStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_SummaryStyle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRightSection_SummaryStyle.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_SummaryStyle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_SummaryStyle.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_SummaryStyle.FormattingEnabled = True
            Me.ComboBoxRightSection_SummaryStyle.ItemHeight = 14
            Me.ComboBoxRightSection_SummaryStyle.Location = New System.Drawing.Point(0, 130)
            Me.ComboBoxRightSection_SummaryStyle.Name = "ComboBoxRightSection_SummaryStyle"
            Me.ComboBoxRightSection_SummaryStyle.PreventEnterBeep = False
            Me.ComboBoxRightSection_SummaryStyle.ReadOnly = False
            Me.ComboBoxRightSection_SummaryStyle.Size = New System.Drawing.Size(522, 20)
            Me.ComboBoxRightSection_SummaryStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_SummaryStyle.TabIndex = 6
            Me.ComboBoxRightSection_SummaryStyle.ValueMember = "Code"
            Me.ComboBoxRightSection_SummaryStyle.WatermarkText = "Select Summary Style"
            '
            'ComboBoxRightSection_GroupBy
            '
            Me.ComboBoxRightSection_GroupBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_GroupBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_GroupBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_GroupBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_GroupBy.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_GroupBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_GroupBy.BookmarkingEnabled = False
            Me.ComboBoxRightSection_GroupBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ServiceFeeReconciliationGroupByOptions
            Me.ComboBoxRightSection_GroupBy.DisableMouseWheel = False
            Me.ComboBoxRightSection_GroupBy.DisplayMember = "Description"
            Me.ComboBoxRightSection_GroupBy.DisplayName = ""
            Me.ComboBoxRightSection_GroupBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_GroupBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRightSection_GroupBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_GroupBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_GroupBy.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_GroupBy.FormattingEnabled = True
            Me.ComboBoxRightSection_GroupBy.ItemHeight = 14
            Me.ComboBoxRightSection_GroupBy.Location = New System.Drawing.Point(0, 26)
            Me.ComboBoxRightSection_GroupBy.Name = "ComboBoxRightSection_GroupBy"
            Me.ComboBoxRightSection_GroupBy.PreventEnterBeep = False
            Me.ComboBoxRightSection_GroupBy.ReadOnly = False
            Me.ComboBoxRightSection_GroupBy.Size = New System.Drawing.Size(521, 20)
            Me.ComboBoxRightSection_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_GroupBy.TabIndex = 1
            Me.ComboBoxRightSection_GroupBy.ValueMember = "Code"
            Me.ComboBoxRightSection_GroupBy.WatermarkText = "Select Group By Option"
            '
            'LabelRightSection_GroupBy
            '
            Me.LabelRightSection_GroupBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightSection_GroupBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupBy.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_GroupBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_GroupBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelRightSection_GroupBy.Location = New System.Drawing.Point(0, 0)
            Me.LabelRightSection_GroupBy.Name = "LabelRightSection_GroupBy"
            Me.LabelRightSection_GroupBy.Size = New System.Drawing.Size(521, 20)
            Me.LabelRightSection_GroupBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_GroupBy.TabIndex = 0
            Me.LabelRightSection_GroupBy.Text = "Group By"
            '
            'LabelRightSection_SummaryStyle
            '
            Me.LabelRightSection_SummaryStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightSection_SummaryStyle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightSection_SummaryStyle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_SummaryStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelRightSection_SummaryStyle.Location = New System.Drawing.Point(0, 104)
            Me.LabelRightSection_SummaryStyle.Name = "LabelRightSection_SummaryStyle"
            Me.LabelRightSection_SummaryStyle.Size = New System.Drawing.Size(522, 20)
            Me.LabelRightSection_SummaryStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_SummaryStyle.TabIndex = 5
            Me.LabelRightSection_SummaryStyle.Text = "Summary Style"
            '
            'PanelSelectionCriteria_LeftSection
            '
            Me.PanelSelectionCriteria_LeftSection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSelectionCriteria_LeftSection.BackColor = System.Drawing.Color.White
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_PrimaryDisplayOption)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.PanelLeftSection_PrimaryDisplayOption)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeePeriodsTo)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeePeriodsFrom)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.TextBoxLeftSection_FeePeriodsFrom)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeePeriods)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.TextBoxLeftSection_FeePeriodsTo)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeeTimePostedDateRange)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeeTimePostedDateRangeTo)
            Me.PanelSelectionCriteria_LeftSection.Controls.Add(Me.LabelLeftSection_FeeTimePostedDateRangeFrom)
            Me.PanelSelectionCriteria_LeftSection.Location = New System.Drawing.Point(3, 3)
            Me.PanelSelectionCriteria_LeftSection.Name = "PanelSelectionCriteria_LeftSection"
            Me.PanelSelectionCriteria_LeftSection.Size = New System.Drawing.Size(522, 150)
            Me.PanelSelectionCriteria_LeftSection.TabIndex = 23
            '
            'LabelLeftSection_PrimaryDisplayOption
            '
            Me.LabelLeftSection_PrimaryDisplayOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelLeftSection_PrimaryDisplayOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PrimaryDisplayOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_PrimaryDisplayOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_PrimaryDisplayOption.Location = New System.Drawing.Point(0, 0)
            Me.LabelLeftSection_PrimaryDisplayOption.Name = "LabelLeftSection_PrimaryDisplayOption"
            Me.LabelLeftSection_PrimaryDisplayOption.Size = New System.Drawing.Size(522, 20)
            Me.LabelLeftSection_PrimaryDisplayOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_PrimaryDisplayOption.TabIndex = 0
            Me.LabelLeftSection_PrimaryDisplayOption.Text = "Primary Display Option"
            '
            'PanelLeftSection_PrimaryDisplayOption
            '
            Me.PanelLeftSection_PrimaryDisplayOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelLeftSection_PrimaryDisplayOption.BackColor = System.Drawing.Color.White
            Me.PanelLeftSection_PrimaryDisplayOption.Controls.Add(Me.RadioButtonPrimaryDisplayOption_Client)
            Me.PanelLeftSection_PrimaryDisplayOption.Controls.Add(Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct)
            Me.PanelLeftSection_PrimaryDisplayOption.Controls.Add(Me.RadioButtonPrimaryDisplayOption_ClientDivision)
            Me.PanelLeftSection_PrimaryDisplayOption.Location = New System.Drawing.Point(0, 26)
            Me.PanelLeftSection_PrimaryDisplayOption.Name = "PanelLeftSection_PrimaryDisplayOption"
            Me.PanelLeftSection_PrimaryDisplayOption.Size = New System.Drawing.Size(522, 20)
            Me.PanelLeftSection_PrimaryDisplayOption.TabIndex = 1
            '
            'RadioButtonPrimaryDisplayOption_Client
            '
            Me.RadioButtonPrimaryDisplayOption_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrimaryDisplayOption_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrimaryDisplayOption_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrimaryDisplayOption_Client.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonPrimaryDisplayOption_Client.Name = "RadioButtonPrimaryDisplayOption_Client"
            Me.RadioButtonPrimaryDisplayOption_Client.Size = New System.Drawing.Size(53, 20)
            Me.RadioButtonPrimaryDisplayOption_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrimaryDisplayOption_Client.TabIndex = 0
            Me.RadioButtonPrimaryDisplayOption_Client.TabStop = False
            Me.RadioButtonPrimaryDisplayOption_Client.Text = "Client"
            '
            'RadioButtonPrimaryDisplayOption_ClientDivisionProduct
            '
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Location = New System.Drawing.Point(158, 0)
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Name = "RadioButtonPrimaryDisplayOption_ClientDivisionProduct"
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Size = New System.Drawing.Size(133, 20)
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.TabIndex = 2
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.TabStop = False
            Me.RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Text = "Client/Division/Product"
            '
            'RadioButtonPrimaryDisplayOption_ClientDivision
            '
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.Location = New System.Drawing.Point(59, 0)
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.Name = "RadioButtonPrimaryDisplayOption_ClientDivision"
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.Size = New System.Drawing.Size(93, 20)
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.TabIndex = 1
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.TabStop = False
            Me.RadioButtonPrimaryDisplayOption_ClientDivision.Text = "Client/Division"
            '
            'TabItemServiceFeeReconciliation_SelectionCriteriaTab
            '
            Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab.AttachedControl = Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria
            Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab.Name = "TabItemServiceFeeReconciliation_SelectionCriteriaTab"
            Me.TabItemServiceFeeReconciliation_SelectionCriteriaTab.Text = "Selection Criteria"
            '
            'TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria
            '
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.LabelServiceFeeTypeCriteria_FilterOption)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.LabelServiceFeeTypeCriteria_SelectOption)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.RadioButtonServiceFeeTypeCriteria_None)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.RadioButtonServiceFeeTypeCriteria_JobComponent)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Controls.Add(Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Name = "TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria"
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Size = New System.Drawing.Size(1064, 470)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.Style.GradientAngle = 90
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.TabIndex = 1
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.TabItem = Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab
            '
            'LabelServiceFeeTypeCriteria_FilterOption
            '
            Me.LabelServiceFeeTypeCriteria_FilterOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_FilterOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceFeeTypeCriteria_FilterOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelServiceFeeTypeCriteria_FilterOption.Location = New System.Drawing.Point(4, 56)
            Me.LabelServiceFeeTypeCriteria_FilterOption.Name = "LabelServiceFeeTypeCriteria_FilterOption"
            Me.LabelServiceFeeTypeCriteria_FilterOption.Size = New System.Drawing.Size(1056, 20)
            Me.LabelServiceFeeTypeCriteria_FilterOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceFeeTypeCriteria_FilterOption.TabIndex = 5
            Me.LabelServiceFeeTypeCriteria_FilterOption.Text = "Filter for Fee Time and Fees Billed"
            '
            'LabelServiceFeeTypeCriteria_SelectOption
            '
            Me.LabelServiceFeeTypeCriteria_SelectOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelServiceFeeTypeCriteria_SelectOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceFeeTypeCriteria_SelectOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelServiceFeeTypeCriteria_SelectOption.Location = New System.Drawing.Point(4, 4)
            Me.LabelServiceFeeTypeCriteria_SelectOption.Name = "LabelServiceFeeTypeCriteria_SelectOption"
            Me.LabelServiceFeeTypeCriteria_SelectOption.Size = New System.Drawing.Size(1056, 20)
            Me.LabelServiceFeeTypeCriteria_SelectOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceFeeTypeCriteria_SelectOption.TabIndex = 0
            Me.LabelServiceFeeTypeCriteria_SelectOption.Text = "Select Option for Gathering Fee Time"
            '
            'RadioButtonServiceFeeTypeCriteria_None
            '
            Me.RadioButtonServiceFeeTypeCriteria_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonServiceFeeTypeCriteria_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonServiceFeeTypeCriteria_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonServiceFeeTypeCriteria_None.Checked = True
            Me.RadioButtonServiceFeeTypeCriteria_None.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonServiceFeeTypeCriteria_None.CheckValue = "Y"
            Me.RadioButtonServiceFeeTypeCriteria_None.Location = New System.Drawing.Point(4, 30)
            Me.RadioButtonServiceFeeTypeCriteria_None.Name = "RadioButtonServiceFeeTypeCriteria_None"
            Me.RadioButtonServiceFeeTypeCriteria_None.Size = New System.Drawing.Size(53, 20)
            Me.RadioButtonServiceFeeTypeCriteria_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonServiceFeeTypeCriteria_None.TabIndex = 1
            Me.RadioButtonServiceFeeTypeCriteria_None.Text = "None"
            '
            'RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment
            '
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Location = New System.Drawing.Point(63, 30)
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Name = "RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment"
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Size = New System.Drawing.Size(168, 20)
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.TabIndex = 2
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.TabStop = False
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Text = "Employee Default Department"
            '
            'RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment
            '
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Location = New System.Drawing.Point(237, 30)
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Name = "RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment"
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Size = New System.Drawing.Size(187, 20)
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.TabIndex = 3
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.TabStop = False
            Me.RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Text = "Employee Time Entry Department"
            '
            'RadioButtonServiceFeeTypeCriteria_JobComponent
            '
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.Location = New System.Drawing.Point(430, 30)
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.Name = "RadioButtonServiceFeeTypeCriteria_JobComponent"
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.Size = New System.Drawing.Size(102, 20)
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.TabIndex = 4
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.TabStop = False
            Me.RadioButtonServiceFeeTypeCriteria_JobComponent.Text = "Job/Component"
            '
            'DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes
            '
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.AutoFilterLookupColumns = False
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.BackColor = System.Drawing.Color.White
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.DataSource = Nothing
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Enabled = False
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.ItemDescription = ""
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Location = New System.Drawing.Point(4, 82)
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.MultiSelect = True
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Name = "DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes"
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Size = New System.Drawing.Size(1056, 384)
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.TabIndex = 6
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.UseEmbeddedNavigator = False
            Me.DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.ViewCaptionHeight = -1
            '
            'TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab
            '
            Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab.AttachedControl = Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria
            Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab.Name = "TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab"
            Me.TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab.Text = "Service Fee Type Criteria"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(660, 1)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(125, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 40
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_Actions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(100, 98)
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
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'ButtonForm_Process
            '
            Me.ButtonForm_Process.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Process.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Process.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Process.Location = New System.Drawing.Point(920, 484)
            Me.ButtonForm_Process.Name = "ButtonForm_Process"
            Me.ButtonForm_Process.SecurityEnabled = True
            Me.ButtonForm_Process.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Process.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Process.TabIndex = 42
            Me.ButtonForm_Process.Text = "Process"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(1001, 484)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 41
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ServiceFeeReconciliationForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1088, 516)
            Me.Controls.Add(Me.TabControlForm_ServiceFeeReconciliation)
            Me.Controls.Add(Me.ButtonForm_Process)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServiceFeeReconciliationForm"
            Me.Text = "Service Fee Reconciliation"
            CType(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerLeftSection_FeeTimePostedDateRangeFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_ServiceFeeReconciliation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ServiceFeeReconciliation.ResumeLayout(False)
            Me.TabControlPanelFeeCriteriaTab_FeeCriteria.ResumeLayout(False)
            CType(Me.TabControlFeeCriteria_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlFeeCriteria_Settings.ResumeLayout(False)
            Me.TabControlPanelProductionCommissionTab_ProductionCommission.ResumeLayout(False)
            CType(Me.PanelProductionCommission_ProductionCommission, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelProductionCommission_ProductionCommission.ResumeLayout(False)
            CType(Me.PanelProductionCommission_PCRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelProductionCommission_PCRightSection.ResumeLayout(False)
            CType(Me.PanelProductionCommission_PCLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelProductionCommission_PCLeftSection.ResumeLayout(False)
            Me.TabControlPanelStandardFeeTab_StandardFee.ResumeLayout(False)
            CType(Me.PanelStandardFee_StandardFee, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelStandardFee_StandardFee.ResumeLayout(False)
            CType(Me.PanelStandardFee_SFRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelStandardFee_SFRightSection.ResumeLayout(False)
            CType(Me.PanelStandardFee_SFLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelStandardFee_SFLeftSection.ResumeLayout(False)
            Me.TabControlPanelMediaCommissionTab_MediaCommission.ResumeLayout(False)
            Me.TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria.ResumeLayout(False)
            Me.TabControlPanelSelectionCriteriaTab_SelectionCriteria.ResumeLayout(False)
            Me.TableLayoutSelectionCriteria_SelectionCriteria.ResumeLayout(False)
            Me.PanelSelectionCriteria_RightSection.ResumeLayout(False)
            Me.PanelSelectionCriteria_LeftSection.ResumeLayout(False)
            Me.PanelLeftSection_PrimaryDisplayOption.ResumeLayout(False)
            Me.TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewSelectionCriteria_Criteria As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectionCriteria_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectionCriteria_ClientDivision As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectionCriteria_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectionCriteria_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelLeftSection_FeeTimePostedDateRangeTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_FeeTimePostedDateRangeFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_FeeTimePostedDateRange As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxLeftSection_FeePeriodsTo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxLeftSection_FeePeriodsFrom As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelLeftSection_FeePeriodsTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_FeePeriodsFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_FeePeriods As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerLeftSection_FeeTimePostedDateRangeTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerLeftSection_FeeTimePostedDateRangeFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxStandardFee_AllComponentsMarkedAsFee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxStandardFee_PostedBasedOnFunctions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxStandardFee_PostedBasedOnSalesClass As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxStandardFee_StandardFee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewStandardFee_Functions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewStandardFee_SalesClasses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewProductionCommission_Functions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewProductionCommission_SalesClasses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxProductionCommission_PostedBasedOnFunctions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxProductionCommission_PostedBasedOnSalesClass As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxProductionCommission_ProductionCommission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlForm_ServiceFeeReconciliation As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelFeeCriteriaTab_FeeCriteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemServiceFeeReconciliation_FeeCriteriaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectionCriteriaTab_SelectionCriteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemServiceFeeReconciliation_SelectionCriteriaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxFeeTimeCriteria_StandardFeeTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFeeTimeCriteria_FeeTimeMediaCommission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxFeeTimeCriteria_FeeTimeProductionCommission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlFeeCriteria_Settings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionCommissionTab_ProductionCommission As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSettings_ProductionCommissionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelStandardFeeTab_StandardFee As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSettings_StandardFeeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelFeeTimeCriteria_TypesOfFeeTimeToInclude As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_Internet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_Magazine As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_Broadcast As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaCommission_MediaCommission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelFeeTimeCriteriaTab_FeeTimeCriteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSettings_FeeTimeCriteriaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaCommissionTab_MediaCommission As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSettings_MediaCommissionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelLeftSection_PrimaryDisplayOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonPrimaryDisplayOption_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPrimaryDisplayOption_ClientDivision As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPrimaryDisplayOption_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelLeftSection_PrimaryDisplayOption As System.Windows.Forms.Panel
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelServiceFeeReconciliation_ServiceFeeTypeCriteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonServiceFeeTypeCriteria_JobComponent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonServiceFeeTypeCriteria_None As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelServiceFeeTypeCriteria_SelectOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelServiceFeeTypeCriteria_FilterOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutSelectionCriteria_SelectionCriteria As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelSelectionCriteria_RightSection As System.Windows.Forms.Panel
        Friend WithEvents ComboBoxRightSection_SummaryStyle As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxRightSection_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelRightSection_GroupBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_SummaryStyle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelSelectionCriteria_LeftSection As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxRightSection_AddFeeDescriptionToGroupBy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightSection_IncludeServiceFeeTypeLevel As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelRightSection_GroupByOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Process As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelProductionCommission_ProductionCommission As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelProductionCommission_PCRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterProductionCommission_PCLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelProductionCommission_PCLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelStandardFee_StandardFee As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelStandardFee_SFRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterStandardFee_SFLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelStandardFee_SFLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
    End Class

End Namespace
