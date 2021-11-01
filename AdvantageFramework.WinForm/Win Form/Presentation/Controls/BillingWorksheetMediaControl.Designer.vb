Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingWorksheetMediaControl
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
            Me.CheckBoxxControl_IncludeSpots = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_JobMediaDateToBillDateRange = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelJobMediaDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerJobMedia_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerJobMedia_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelJobMediaDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxControl_BroadcastByMonth = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputMediaBroadcast_YearTo = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputMediaBroadcast_YearFrom = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMediaBroadcast_MonthTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxMediaBroadcast_MonthFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaBroadcast_Range = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMediaBroadcast_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaBroadcast_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Types = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
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
            Me.ComboBoxControl_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxControl_OmitZeroUnbilledAmounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.GroupBoxControl_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_JobMediaDateToBillDateRange.SuspendLayout()
            CType(Me.DateTimePickerJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerJobMedia_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_BroadcastByMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_BroadcastByMonth.SuspendLayout()
            CType(Me.NumericInputMediaBroadcast_YearTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMediaBroadcast_YearFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Types.SuspendLayout()
            CType(Me.DateTimePickerMediaType_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerMediaType_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CheckBoxxControl_IncludeSpots
            '
            Me.CheckBoxxControl_IncludeSpots.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxxControl_IncludeSpots.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxxControl_IncludeSpots.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxxControl_IncludeSpots.CheckValue = 0
            Me.CheckBoxxControl_IncludeSpots.CheckValueChecked = 1
            Me.CheckBoxxControl_IncludeSpots.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxxControl_IncludeSpots.CheckValueUnchecked = 0
            Me.CheckBoxxControl_IncludeSpots.ChildControls = Nothing
            Me.CheckBoxxControl_IncludeSpots.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxxControl_IncludeSpots.Location = New System.Drawing.Point(0, 343)
            Me.CheckBoxxControl_IncludeSpots.Name = "CheckBoxxControl_IncludeSpots"
            Me.CheckBoxxControl_IncludeSpots.OldestSibling = Nothing
            Me.CheckBoxxControl_IncludeSpots.SecurityEnabled = True
            Me.CheckBoxxControl_IncludeSpots.SiblingControls = Nothing
            Me.CheckBoxxControl_IncludeSpots.Size = New System.Drawing.Size(335, 20)
            Me.CheckBoxxControl_IncludeSpots.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxxControl_IncludeSpots.TabIndex = 6
            Me.CheckBoxxControl_IncludeSpots.TabOnEnter = True
            Me.CheckBoxxControl_IncludeSpots.Text = "Include Spots with Zero Billing Amounts?"
            '
            'CheckBoxControl_IncludeUnbilledOrdersOnly
            '
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.CheckValue = 0
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.CheckValueChecked = 1
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.CheckValueUnchecked = 0
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.ChildControls = Nothing
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Location = New System.Drawing.Point(0, 317)
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Name = "CheckBoxControl_IncludeUnbilledOrdersOnly"
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.OldestSibling = Nothing
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.SecurityEnabled = True
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.SiblingControls = Nothing
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Size = New System.Drawing.Size(335, 20)
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.TabIndex = 5
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.TabOnEnter = True
            Me.CheckBoxControl_IncludeUnbilledOrdersOnly.Text = "Include Unbilled Orders Only?"
            '
            'GroupBoxControl_JobMediaDateToBillDateRange
            '
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_From)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJobMedia_DateFrom)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Controls.Add(Me.DateTimePickerJobMedia_DateTo)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Controls.Add(Me.LabelJobMediaDateRange_To)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Location = New System.Drawing.Point(0, 256)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Name = "GroupBoxControl_JobMediaDateToBillDateRange"
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Size = New System.Drawing.Size(335, 55)
            Me.GroupBoxControl_JobMediaDateToBillDateRange.TabIndex = 4
            Me.GroupBoxControl_JobMediaDateToBillDateRange.Text = "Job or Media Date to Bill"
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
            Me.DateTimePickerJobMedia_DateFrom.Size = New System.Drawing.Size(114, 21)
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
            Me.DateTimePickerJobMedia_DateTo.Location = New System.Drawing.Point(216, 24)
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
            Me.DateTimePickerJobMedia_DateTo.Size = New System.Drawing.Size(114, 21)
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
            Me.LabelJobMediaDateRange_To.Size = New System.Drawing.Size(26, 20)
            Me.LabelJobMediaDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelJobMediaDateRange_To.TabIndex = 3
            Me.LabelJobMediaDateRange_To.Text = "To:"
            '
            'GroupBoxControl_BroadcastByMonth
            '
            Me.GroupBoxControl_BroadcastByMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_BroadcastByMonth.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_BroadcastByMonth.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.NumericInputMediaBroadcast_YearTo)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.NumericInputMediaBroadcast_YearFrom)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.ComboBoxMediaBroadcast_MonthTo)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.ComboBoxMediaBroadcast_MonthFrom)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.LabelMediaBroadcast_Range)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.CheckBoxMediaBroadcast_Television)
            Me.GroupBoxControl_BroadcastByMonth.Controls.Add(Me.CheckBoxMediaBroadcast_Radio)
            Me.GroupBoxControl_BroadcastByMonth.Location = New System.Drawing.Point(0, 168)
            Me.GroupBoxControl_BroadcastByMonth.Name = "GroupBoxControl_BroadcastByMonth"
            Me.GroupBoxControl_BroadcastByMonth.Size = New System.Drawing.Size(335, 82)
            Me.GroupBoxControl_BroadcastByMonth.TabIndex = 3
            Me.GroupBoxControl_BroadcastByMonth.Text = "Broadcast By Month"
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
            Me.CheckBoxMediaBroadcast_Television.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxMediaBroadcast_Television.Size = New System.Drawing.Size(146, 20)
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
            'GroupBoxControl_Types
            '
            Me.GroupBoxControl_Types.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Types.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxControl_Types.Appearance.Options.UseBackColor = True
            Me.GroupBoxControl_Types.Controls.Add(Me.DateTimePickerMediaType_DateFrom)
            Me.GroupBoxControl_Types.Controls.Add(Me.DateTimePickerMediaType_DateTo)
            Me.GroupBoxControl_Types.Controls.Add(Me.LabelMediaType_DateTo)
            Me.GroupBoxControl_Types.Controls.Add(Me.LabelMediaType_DateFrom)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_TelevisionDaily)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_RadioDaily)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_OutOfHome)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_Magazine)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_Internet)
            Me.GroupBoxControl_Types.Controls.Add(Me.CheckBoxMediaType_Newspaper)
            Me.GroupBoxControl_Types.Location = New System.Drawing.Point(0, 27)
            Me.GroupBoxControl_Types.Name = "GroupBoxControl_Types"
            Me.GroupBoxControl_Types.Size = New System.Drawing.Size(335, 135)
            Me.GroupBoxControl_Types.TabIndex = 2
            Me.GroupBoxControl_Types.Text = "Select Media Types"
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
            Me.CheckBoxMediaType_TelevisionDaily.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxMediaType_TelevisionDaily.Size = New System.Drawing.Size(146, 20)
            Me.CheckBoxMediaType_TelevisionDaily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaType_TelevisionDaily.TabIndex = 5
            Me.CheckBoxMediaType_TelevisionDaily.TabOnEnter = True
            Me.CheckBoxMediaType_TelevisionDaily.Text = "Television (Daily)"
            '
            'CheckBoxMediaType_RadioDaily
            '
            Me.CheckBoxMediaType_RadioDaily.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxMediaType_RadioDaily.Size = New System.Drawing.Size(146, 20)
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
            Me.CheckBoxMediaType_Internet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxMediaType_Internet.Size = New System.Drawing.Size(146, 20)
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
            'ComboBoxControl_SelectBy
            '
            Me.ComboBoxControl_SelectBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_SelectBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxControl_SelectBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_SelectBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_SelectBy.AutoFindItemInDataSource = False
            Me.ComboBoxControl_SelectBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_SelectBy.BookmarkingEnabled = False
            Me.ComboBoxControl_SelectBy.ClientCode = ""
            Me.ComboBoxControl_SelectBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxControl_SelectBy.DisableMouseWheel = True
            Me.ComboBoxControl_SelectBy.DisplayMember = "Name"
            Me.ComboBoxControl_SelectBy.DisplayName = ""
            Me.ComboBoxControl_SelectBy.DivisionCode = ""
            Me.ComboBoxControl_SelectBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_SelectBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_SelectBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_SelectBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_SelectBy.FocusHighlightEnabled = True
            Me.ComboBoxControl_SelectBy.FormattingEnabled = True
            Me.ComboBoxControl_SelectBy.ItemHeight = 15
            Me.ComboBoxControl_SelectBy.Location = New System.Drawing.Point(0, 0)
            Me.ComboBoxControl_SelectBy.Name = "ComboBoxControl_SelectBy"
            Me.ComboBoxControl_SelectBy.ReadOnly = False
            Me.ComboBoxControl_SelectBy.SecurityEnabled = True
            Me.ComboBoxControl_SelectBy.Size = New System.Drawing.Size(335, 21)
            Me.ComboBoxControl_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_SelectBy.TabIndex = 1
            Me.ComboBoxControl_SelectBy.TabOnEnter = True
            Me.ComboBoxControl_SelectBy.ValueMember = "Value"
            Me.ComboBoxControl_SelectBy.WatermarkText = "Select"
            '
            'CheckBoxControl_OmitZeroUnbilledAmounts
            '
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.CheckValue = 0
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.CheckValueChecked = 1
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.CheckValueUnchecked = 0
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.ChildControls = Nothing
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Location = New System.Drawing.Point(0, 369)
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Name = "CheckBoxControl_OmitZeroUnbilledAmounts"
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.OldestSibling = Nothing
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.SecurityEnabled = True
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.SiblingControls = Nothing
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Size = New System.Drawing.Size(335, 20)
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.TabIndex = 7
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.TabOnEnter = True
            Me.CheckBoxControl_OmitZeroUnbilledAmounts.Text = "Omit Zero Unbilled Amounts"
            '
            'BillingWorksheetMediaControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.CheckBoxControl_OmitZeroUnbilledAmounts)
            Me.Controls.Add(Me.CheckBoxxControl_IncludeSpots)
            Me.Controls.Add(Me.CheckBoxControl_IncludeUnbilledOrdersOnly)
            Me.Controls.Add(Me.GroupBoxControl_JobMediaDateToBillDateRange)
            Me.Controls.Add(Me.ComboBoxControl_SelectBy)
            Me.Controls.Add(Me.GroupBoxControl_BroadcastByMonth)
            Me.Controls.Add(Me.GroupBoxControl_Types)
            Me.Name = "BillingWorksheetMediaControl"
            Me.Size = New System.Drawing.Size(335, 395)
            CType(Me.GroupBoxControl_JobMediaDateToBillDateRange, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_JobMediaDateToBillDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerJobMedia_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerJobMedia_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_BroadcastByMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_BroadcastByMonth.ResumeLayout(False)
            CType(Me.NumericInputMediaBroadcast_YearTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMediaBroadcast_YearFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_Types, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Types.ResumeLayout(False)
            CType(Me.DateTimePickerMediaType_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerMediaType_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ComboBoxControl_SelectBy As ComboBox
        Friend WithEvents GroupBoxControl_Types As GroupBox
        Friend WithEvents DateTimePickerMediaType_DateFrom As DateTimePicker
        Friend WithEvents DateTimePickerMediaType_DateTo As DateTimePicker
        Friend WithEvents LabelMediaType_DateTo As Label
        Friend WithEvents LabelMediaType_DateFrom As Label
        Friend WithEvents CheckBoxMediaType_TelevisionDaily As CheckBox
        Friend WithEvents CheckBoxMediaType_RadioDaily As CheckBox
        Friend WithEvents CheckBoxMediaType_OutOfHome As CheckBox
        Friend WithEvents CheckBoxMediaType_Magazine As CheckBox
        Friend WithEvents CheckBoxMediaType_Internet As CheckBox
        Friend WithEvents CheckBoxMediaType_Newspaper As CheckBox
        Friend WithEvents GroupBoxControl_BroadcastByMonth As GroupBox
        Friend WithEvents NumericInputMediaBroadcast_YearTo As NumericInput
        Friend WithEvents NumericInputMediaBroadcast_YearFrom As NumericInput
        Friend WithEvents ComboBoxMediaBroadcast_MonthTo As ComboBox
        Friend WithEvents ComboBoxMediaBroadcast_MonthFrom As ComboBox
        Friend WithEvents LabelMediaBroadcast_Range As Label
        Friend WithEvents CheckBoxMediaBroadcast_Television As CheckBox
        Friend WithEvents CheckBoxMediaBroadcast_Radio As CheckBox
        Friend WithEvents GroupBoxControl_JobMediaDateToBillDateRange As GroupBox
        Friend WithEvents LabelJobMediaDateRange_From As Label
        Friend WithEvents DateTimePickerJobMedia_DateFrom As DateTimePicker
        Friend WithEvents DateTimePickerJobMedia_DateTo As DateTimePicker
        Friend WithEvents LabelJobMediaDateRange_To As Label
        Friend WithEvents CheckBoxControl_IncludeUnbilledOrdersOnly As CheckBox
        Friend WithEvents CheckBoxxControl_IncludeSpots As CheckBox
        Friend WithEvents CheckBoxControl_OmitZeroUnbilledAmounts As CheckBox
    End Class

End Namespace