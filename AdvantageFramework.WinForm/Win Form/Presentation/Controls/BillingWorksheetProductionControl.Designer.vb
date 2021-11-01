Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingWorksheetProductionControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingWorksheetProductionControl))
            Me.CheckBoxControl_PrintItemDetail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_IncludeContingency = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_IncludeNonBillableAPIODetail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_JobType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonProductionTypeOfJob_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxControl_IncludeNonBillableTimeDetail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Cutoffs = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelCutoffs_IncomeOnlyDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelCutoffs_EmployeeDateTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCutoffs_APPostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxControl_JobOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonJobOptions_OpenJobs = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNonbillableStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNonbillableEndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerNonbillableStartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerNonbillableEndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.CheckBoxControl_TimeComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_APComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_IOComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.GroupBoxControl_JobType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_JobType.SuspendLayout()
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Cutoffs.SuspendLayout()
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_JobOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_JobOptions.SuspendLayout()
            CType(Me.DateTimePickerNonbillableStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNonbillableEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CheckBoxControl_PrintItemDetail
            '
            '
            '
            '
            Me.CheckBoxControl_PrintItemDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_PrintItemDetail.CheckValue = 0
            Me.CheckBoxControl_PrintItemDetail.CheckValueChecked = 1
            Me.CheckBoxControl_PrintItemDetail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_PrintItemDetail.CheckValueUnchecked = 0
            Me.CheckBoxControl_PrintItemDetail.ChildControls = CType(resources.GetObject("CheckBoxControl_PrintItemDetail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_PrintItemDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_PrintItemDetail.Location = New System.Drawing.Point(0, 417)
            Me.CheckBoxControl_PrintItemDetail.Name = "CheckBoxControl_PrintItemDetail"
            Me.CheckBoxControl_PrintItemDetail.OldestSibling = Nothing
            Me.CheckBoxControl_PrintItemDetail.SecurityEnabled = True
            Me.CheckBoxControl_PrintItemDetail.SiblingControls = CType(resources.GetObject("CheckBoxControl_PrintItemDetail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_PrintItemDetail.Size = New System.Drawing.Size(102, 20)
            Me.CheckBoxControl_PrintItemDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_PrintItemDetail.TabIndex = 12
            Me.CheckBoxControl_PrintItemDetail.TabOnEnter = True
            Me.CheckBoxControl_PrintItemDetail.Text = "Print Item Detail"
            '
            'CheckBoxControl_IncludeContingency
            '
            Me.CheckBoxControl_IncludeContingency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_IncludeContingency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IncludeContingency.CheckValue = 0
            Me.CheckBoxControl_IncludeContingency.CheckValueChecked = 1
            Me.CheckBoxControl_IncludeContingency.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IncludeContingency.CheckValueUnchecked = 0
            Me.CheckBoxControl_IncludeContingency.ChildControls = CType(resources.GetObject("CheckBoxControl_IncludeContingency.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeContingency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IncludeContingency.Location = New System.Drawing.Point(0, 339)
            Me.CheckBoxControl_IncludeContingency.Name = "CheckBoxControl_IncludeContingency"
            Me.CheckBoxControl_IncludeContingency.OldestSibling = Nothing
            Me.CheckBoxControl_IncludeContingency.SecurityEnabled = True
            Me.CheckBoxControl_IncludeContingency.SiblingControls = CType(resources.GetObject("CheckBoxControl_IncludeContingency.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeContingency.Size = New System.Drawing.Size(553, 20)
            Me.CheckBoxControl_IncludeContingency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IncludeContingency.TabIndex = 5
            Me.CheckBoxControl_IncludeContingency.TabOnEnter = True
            Me.CheckBoxControl_IncludeContingency.Text = "Include Contingency"
            '
            'CheckBoxControl_IncludeNonBillableAPIODetail
            '
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.CheckValue = 0
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.CheckValueChecked = 1
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.CheckValueUnchecked = 0
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.ChildControls = CType(resources.GetObject("CheckBoxControl_IncludeNonBillableAPIODetail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Location = New System.Drawing.Point(0, 391)
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Name = "CheckBoxControl_IncludeNonBillableAPIODetail"
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.OldestSibling = Nothing
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.SecurityEnabled = True
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.SiblingControls = CType(resources.GetObject("CheckBoxControl_IncludeNonBillableAPIODetail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Size = New System.Drawing.Size(553, 20)
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.TabIndex = 11
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.TabOnEnter = True
            Me.CheckBoxControl_IncludeNonBillableAPIODetail.Text = "Include Non-Billable AP/IO Detail"
            '
            'GroupBoxControl_JobType
            '
            Me.GroupBoxControl_JobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_JobType.Controls.Add(Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly)
            Me.GroupBoxControl_JobType.Controls.Add(Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly)
            Me.GroupBoxControl_JobType.Controls.Add(Me.RadioButtonProductionTypeOfJob_All)
            Me.GroupBoxControl_JobType.Location = New System.Drawing.Point(0, 113)
            Me.GroupBoxControl_JobType.Name = "GroupBoxControl_JobType"
            Me.GroupBoxControl_JobType.Size = New System.Drawing.Size(553, 106)
            Me.GroupBoxControl_JobType.TabIndex = 3
            Me.GroupBoxControl_JobType.Text = "Type of Job"
            '
            'RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly
            '
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Name = "RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly"
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Size = New System.Drawing.Size(547, 20)
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabIndex = 2
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.TabStop = False
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Tag = "3"
            Me.RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly.Text = "Service Fee  Jobs Only"
            '
            'RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly
            '
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Name = "RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly"
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Size = New System.Drawing.Size(547, 20)
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabIndex = 1
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.TabStop = False
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Tag = "2"
            Me.RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly.Text = "Advance Bill Jobs Only"
            '
            'RadioButtonProductionTypeOfJob_All
            '
            Me.RadioButtonProductionTypeOfJob_All.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonProductionTypeOfJob_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonProductionTypeOfJob_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonProductionTypeOfJob_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonProductionTypeOfJob_All.Checked = True
            Me.RadioButtonProductionTypeOfJob_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonProductionTypeOfJob_All.CheckValue = "Y"
            Me.RadioButtonProductionTypeOfJob_All.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonProductionTypeOfJob_All.Name = "RadioButtonProductionTypeOfJob_All"
            Me.RadioButtonProductionTypeOfJob_All.SecurityEnabled = True
            Me.RadioButtonProductionTypeOfJob_All.Size = New System.Drawing.Size(547, 20)
            Me.RadioButtonProductionTypeOfJob_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonProductionTypeOfJob_All.TabIndex = 0
            Me.RadioButtonProductionTypeOfJob_All.TabOnEnter = True
            Me.RadioButtonProductionTypeOfJob_All.Tag = "1"
            Me.RadioButtonProductionTypeOfJob_All.Text = "All"
            '
            'CheckBoxControl_IncludeNonBillableTimeDetail
            '
            '
            '
            '
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.CheckValue = 0
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.CheckValueChecked = 1
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.CheckValueUnchecked = 0
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.ChildControls = CType(resources.GetObject("CheckBoxControl_IncludeNonBillableTimeDetail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.Location = New System.Drawing.Point(0, 365)
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.Name = "CheckBoxControl_IncludeNonBillableTimeDetail"
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.OldestSibling = Nothing
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.SecurityEnabled = True
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.SiblingControls = CType(resources.GetObject("CheckBoxControl_IncludeNonBillableTimeDetail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.Size = New System.Drawing.Size(183, 20)
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.TabIndex = 6
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.TabOnEnter = True
            Me.CheckBoxControl_IncludeNonBillableTimeDetail.Text = "Include Non-Billable Time Detail"
            '
            'GroupBoxControl_Cutoffs
            '
            Me.GroupBoxControl_Cutoffs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Cutoffs.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_Cutoffs.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_IncomeOnlyDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.ComboBoxProductionCutoffs_APPostingPeriod)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_EmployeeDateTime)
            Me.GroupBoxControl_Cutoffs.Controls.Add(Me.LabelCutoffs_APPostingPeriod)
            Me.GroupBoxControl_Cutoffs.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxControl_Cutoffs.Name = "GroupBoxControl_Cutoffs"
            Me.GroupBoxControl_Cutoffs.Size = New System.Drawing.Size(553, 107)
            Me.GroupBoxControl_Cutoffs.TabIndex = 2
            Me.GroupBoxControl_Cutoffs.Text = "Cutoffs"
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
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.DisplayName = "Income Only Date"
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
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Size = New System.Drawing.Size(134, 21)
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabIndex = 3
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'LabelCutoffs_IncomeOnlyDate
            '
            Me.LabelCutoffs_IncomeOnlyDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_IncomeOnlyDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_IncomeOnlyDate.Location = New System.Drawing.Point(5, 50)
            Me.LabelCutoffs_IncomeOnlyDate.Name = "LabelCutoffs_IncomeOnlyDate"
            Me.LabelCutoffs_IncomeOnlyDate.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_IncomeOnlyDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_IncomeOnlyDate.TabIndex = 2
            Me.LabelCutoffs_IncomeOnlyDate.Text = "Income Only Date:"
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
            Me.ComboBoxProductionCutoffs_APPostingPeriod.FormattingEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ItemHeight = 16
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Location = New System.Drawing.Point(131, 76)
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Name = "ComboBoxProductionCutoffs_APPostingPeriod"
            Me.ComboBoxProductionCutoffs_APPostingPeriod.ReadOnly = False
            Me.ComboBoxProductionCutoffs_APPostingPeriod.SecurityEnabled = True
            Me.ComboBoxProductionCutoffs_APPostingPeriod.Size = New System.Drawing.Size(134, 22)
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
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.DisplayName = "Employee Time Date"
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
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Size = New System.Drawing.Size(134, 21)
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabIndex = 1
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.TabOnEnter = True
            Me.DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'LabelCutoffs_EmployeeDateTime
            '
            Me.LabelCutoffs_EmployeeDateTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_EmployeeDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_EmployeeDateTime.Location = New System.Drawing.Point(5, 24)
            Me.LabelCutoffs_EmployeeDateTime.Name = "LabelCutoffs_EmployeeDateTime"
            Me.LabelCutoffs_EmployeeDateTime.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_EmployeeDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_EmployeeDateTime.TabIndex = 0
            Me.LabelCutoffs_EmployeeDateTime.Text = "Employee Time Date:"
            '
            'LabelCutoffs_APPostingPeriod
            '
            Me.LabelCutoffs_APPostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCutoffs_APPostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCutoffs_APPostingPeriod.Location = New System.Drawing.Point(5, 76)
            Me.LabelCutoffs_APPostingPeriod.Name = "LabelCutoffs_APPostingPeriod"
            Me.LabelCutoffs_APPostingPeriod.Size = New System.Drawing.Size(120, 20)
            Me.LabelCutoffs_APPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCutoffs_APPostingPeriod.TabIndex = 4
            Me.LabelCutoffs_APPostingPeriod.Text = "A/P Posting Period:"
            '
            'GroupBoxControl_JobOptions
            '
            Me.GroupBoxControl_JobOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_JobOptions.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_JobOptions.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_JobOptions.Controls.Add(Me.RadioButtonJobOptions_OpenJobs)
            Me.GroupBoxControl_JobOptions.Controls.Add(Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly)
            Me.GroupBoxControl_JobOptions.Controls.Add(Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords)
            Me.GroupBoxControl_JobOptions.Location = New System.Drawing.Point(0, 225)
            Me.GroupBoxControl_JobOptions.Name = "GroupBoxControl_JobOptions"
            Me.GroupBoxControl_JobOptions.Size = New System.Drawing.Size(553, 108)
            Me.GroupBoxControl_JobOptions.TabIndex = 4
            Me.GroupBoxControl_JobOptions.Text = "Job Options"
            '
            'RadioButtonJobOptions_OpenJobs
            '
            Me.RadioButtonJobOptions_OpenJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonJobOptions_OpenJobs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobOptions_OpenJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobOptions_OpenJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobOptions_OpenJobs.Location = New System.Drawing.Point(5, 76)
            Me.RadioButtonJobOptions_OpenJobs.Name = "RadioButtonJobOptions_OpenJobs"
            Me.RadioButtonJobOptions_OpenJobs.SecurityEnabled = True
            Me.RadioButtonJobOptions_OpenJobs.Size = New System.Drawing.Size(543, 20)
            Me.RadioButtonJobOptions_OpenJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobOptions_OpenJobs.TabIndex = 2
            Me.RadioButtonJobOptions_OpenJobs.TabOnEnter = True
            Me.RadioButtonJobOptions_OpenJobs.TabStop = False
            Me.RadioButtonJobOptions_OpenJobs.Tag = "3"
            Me.RadioButtonJobOptions_OpenJobs.Text = "Open Jobs"
            '
            'RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly
            '
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Name = "RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly"
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.SecurityEnabled = True
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Size = New System.Drawing.Size(543, 20)
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.TabIndex = 1
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.TabOnEnter = True
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.TabStop = False
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Tag = "2"
            Me.RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly.Text = "Open Jobs with Unbilled Records Only"
            '
            'RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords
            '
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Checked = True
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.CheckValue = "Y"
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Name = "RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords"
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.SecurityEnabled = True
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Size = New System.Drawing.Size(543, 20)
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.TabIndex = 0
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.TabOnEnter = True
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Tag = "1"
            Me.RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords.Text = "Open Jobs with Unbilled and Other Records"
            '
            'LabelNonbillableStartDate
            '
            Me.LabelNonbillableStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonbillableStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonbillableStartDate.Location = New System.Drawing.Point(189, 365)
            Me.LabelNonbillableStartDate.Name = "LabelNonbillableStartDate"
            Me.LabelNonbillableStartDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelNonbillableStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonbillableStartDate.TabIndex = 7
            Me.LabelNonbillableStartDate.Text = "From Date:"
            '
            'LabelNonbillableEndDate
            '
            Me.LabelNonbillableEndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonbillableEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonbillableEndDate.Location = New System.Drawing.Point(349, 365)
            Me.LabelNonbillableEndDate.Name = "LabelNonbillableEndDate"
            Me.LabelNonbillableEndDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelNonbillableEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonbillableEndDate.TabIndex = 9
            Me.LabelNonbillableEndDate.Text = "To Date:"
            '
            'DateTimePickerNonbillableStartDate
            '
            Me.DateTimePickerNonbillableStartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNonbillableStartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNonbillableStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNonbillableStartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerNonbillableStartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerNonbillableStartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNonbillableStartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNonbillableStartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonbillableStartDate.DisplayName = "From Date"
            Me.DateTimePickerNonbillableStartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonbillableStartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonbillableStartDate.FocusHighlightEnabled = True
            Me.DateTimePickerNonbillableStartDate.FreeTextEntryMode = True
            Me.DateTimePickerNonbillableStartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerNonbillableStartDate.Location = New System.Drawing.Point(255, 365)
            Me.DateTimePickerNonbillableStartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNonbillableStartDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableStartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNonbillableStartDate.Name = "DateTimePickerNonbillableStartDate"
            Me.DateTimePickerNonbillableStartDate.ReadOnly = False
            Me.DateTimePickerNonbillableStartDate.Size = New System.Drawing.Size(88, 20)
            Me.DateTimePickerNonbillableStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonbillableStartDate.TabIndex = 8
            Me.DateTimePickerNonbillableStartDate.TabOnEnter = True
            Me.DateTimePickerNonbillableStartDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'DateTimePickerNonbillableEndDate
            '
            Me.DateTimePickerNonbillableEndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNonbillableEndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNonbillableEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNonbillableEndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerNonbillableEndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerNonbillableEndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNonbillableEndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNonbillableEndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonbillableEndDate.DisplayName = "To Date"
            Me.DateTimePickerNonbillableEndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonbillableEndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonbillableEndDate.FocusHighlightEnabled = True
            Me.DateTimePickerNonbillableEndDate.FreeTextEntryMode = True
            Me.DateTimePickerNonbillableEndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerNonbillableEndDate.Location = New System.Drawing.Point(415, 365)
            Me.DateTimePickerNonbillableEndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNonbillableEndDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonbillableEndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNonbillableEndDate.Name = "DateTimePickerNonbillableEndDate"
            Me.DateTimePickerNonbillableEndDate.ReadOnly = False
            Me.DateTimePickerNonbillableEndDate.Size = New System.Drawing.Size(88, 20)
            Me.DateTimePickerNonbillableEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonbillableEndDate.TabIndex = 10
            Me.DateTimePickerNonbillableEndDate.TabOnEnter = True
            Me.DateTimePickerNonbillableEndDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'CheckBoxControl_TimeComments
            '
            '
            '
            '
            Me.CheckBoxControl_TimeComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_TimeComments.CheckValue = 0
            Me.CheckBoxControl_TimeComments.CheckValueChecked = 1
            Me.CheckBoxControl_TimeComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_TimeComments.CheckValueUnchecked = 0
            Me.CheckBoxControl_TimeComments.ChildControls = CType(resources.GetObject("CheckBoxControl_TimeComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_TimeComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_TimeComments.Location = New System.Drawing.Point(108, 417)
            Me.CheckBoxControl_TimeComments.Name = "CheckBoxControl_TimeComments"
            Me.CheckBoxControl_TimeComments.OldestSibling = Nothing
            Me.CheckBoxControl_TimeComments.SecurityEnabled = True
            Me.CheckBoxControl_TimeComments.SiblingControls = CType(resources.GetObject("CheckBoxControl_TimeComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_TimeComments.Size = New System.Drawing.Size(150, 20)
            Me.CheckBoxControl_TimeComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_TimeComments.TabIndex = 13
            Me.CheckBoxControl_TimeComments.TabOnEnter = True
            Me.CheckBoxControl_TimeComments.Text = "Populate Time Comments"
            '
            'CheckBoxControl_APComments
            '
            '
            '
            '
            Me.CheckBoxControl_APComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_APComments.CheckValue = 0
            Me.CheckBoxControl_APComments.CheckValueChecked = 1
            Me.CheckBoxControl_APComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_APComments.CheckValueUnchecked = 0
            Me.CheckBoxControl_APComments.ChildControls = CType(resources.GetObject("CheckBoxControl_APComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_APComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_APComments.Location = New System.Drawing.Point(264, 417)
            Me.CheckBoxControl_APComments.Name = "CheckBoxControl_APComments"
            Me.CheckBoxControl_APComments.OldestSibling = Nothing
            Me.CheckBoxControl_APComments.SecurityEnabled = True
            Me.CheckBoxControl_APComments.SiblingControls = CType(resources.GetObject("CheckBoxControl_APComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_APComments.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxControl_APComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_APComments.TabIndex = 14
            Me.CheckBoxControl_APComments.TabOnEnter = True
            Me.CheckBoxControl_APComments.Text = "Populate AP Comments"
            '
            'CheckBoxControl_IOComments
            '
            '
            '
            '
            Me.CheckBoxControl_IOComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IOComments.CheckValue = 0
            Me.CheckBoxControl_IOComments.CheckValueChecked = 1
            Me.CheckBoxControl_IOComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IOComments.CheckValueUnchecked = 0
            Me.CheckBoxControl_IOComments.ChildControls = CType(resources.GetObject("CheckBoxControl_IOComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IOComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IOComments.Location = New System.Drawing.Point(411, 417)
            Me.CheckBoxControl_IOComments.Name = "CheckBoxControl_IOComments"
            Me.CheckBoxControl_IOComments.OldestSibling = Nothing
            Me.CheckBoxControl_IOComments.SecurityEnabled = True
            Me.CheckBoxControl_IOComments.SiblingControls = CType(resources.GetObject("CheckBoxControl_IOComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_IOComments.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxControl_IOComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IOComments.TabIndex = 15
            Me.CheckBoxControl_IOComments.TabOnEnter = True
            Me.CheckBoxControl_IOComments.Text = "Populate IO Comments"
            '
            'BillingWorksheetProductionControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.CheckBoxControl_IOComments)
            Me.Controls.Add(Me.CheckBoxControl_APComments)
            Me.Controls.Add(Me.CheckBoxControl_TimeComments)
            Me.Controls.Add(Me.DateTimePickerNonbillableEndDate)
            Me.Controls.Add(Me.DateTimePickerNonbillableStartDate)
            Me.Controls.Add(Me.LabelNonbillableEndDate)
            Me.Controls.Add(Me.LabelNonbillableStartDate)
            Me.Controls.Add(Me.CheckBoxControl_PrintItemDetail)
            Me.Controls.Add(Me.CheckBoxControl_IncludeContingency)
            Me.Controls.Add(Me.CheckBoxControl_IncludeNonBillableAPIODetail)
            Me.Controls.Add(Me.GroupBoxControl_JobType)
            Me.Controls.Add(Me.CheckBoxControl_IncludeNonBillableTimeDetail)
            Me.Controls.Add(Me.GroupBoxControl_Cutoffs)
            Me.Controls.Add(Me.GroupBoxControl_JobOptions)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "BillingWorksheetProductionControl"
            Me.Size = New System.Drawing.Size(553, 447)
            CType(Me.GroupBoxControl_JobType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_JobType.ResumeLayout(False)
            CType(Me.GroupBoxControl_Cutoffs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Cutoffs.ResumeLayout(False)
            CType(Me.DateTimePickerProductionCutoffs_IncomeOnlyTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerProductionCutoffs_EmployeeTimeDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_JobOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_JobOptions.ResumeLayout(False)
            CType(Me.DateTimePickerNonbillableStartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNonbillableEndDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelCutoffs_APPostingPeriod As Label
        Friend WithEvents LabelCutoffs_EmployeeDateTime As Label
        Friend WithEvents DateTimePickerProductionCutoffs_EmployeeTimeDate As DateTimePicker
        Friend WithEvents ComboBoxProductionCutoffs_APPostingPeriod As ComboBox
        Friend WithEvents LabelCutoffs_IncomeOnlyDate As Label
        Friend WithEvents DateTimePickerProductionCutoffs_IncomeOnlyTimeDate As DateTimePicker
        Friend WithEvents GroupBoxControl_Cutoffs As GroupBox
        Friend WithEvents GroupBoxControl_JobOptions As GroupBox
        Friend WithEvents RadioButtonJobOptions_OpenJobs As RadioButtonControl
        Friend WithEvents RadioButtonJobOptions_OpenJobsUnbilledRecordsOnly As RadioButtonControl
        Friend WithEvents RadioButtonJobOptions_OpenJobsUnbilledWithOtherRecords As RadioButtonControl
        Friend WithEvents CheckBoxControl_IncludeContingency As CheckBox
        Friend WithEvents CheckBoxControl_PrintItemDetail As CheckBox
        Friend WithEvents CheckBoxControl_IncludeNonBillableAPIODetail As CheckBox
        Friend WithEvents CheckBoxControl_IncludeNonBillableTimeDetail As CheckBox
        Friend WithEvents GroupBoxControl_JobType As GroupBox
        Friend WithEvents RadioButtonProductionTypeOfJob_ServiceFeeJobsOnly As RadioButtonControl
        Friend WithEvents RadioButtonProductionTypeOfJob_AdvanceBillJobsOnly As RadioButtonControl
        Friend WithEvents RadioButtonProductionTypeOfJob_All As RadioButtonControl
        Friend WithEvents LabelNonbillableStartDate As Label
        Friend WithEvents LabelNonbillableEndDate As Label
        Friend WithEvents DateTimePickerNonbillableStartDate As DateTimePicker
        Friend WithEvents DateTimePickerNonbillableEndDate As DateTimePicker
        Friend WithEvents CheckBoxControl_TimeComments As CheckBox
        Friend WithEvents CheckBoxControl_APComments As CheckBox
        Friend WithEvents CheckBoxControl_IOComments As CheckBox
    End Class

End Namespace