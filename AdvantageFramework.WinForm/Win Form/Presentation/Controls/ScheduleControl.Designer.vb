Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ScheduleControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScheduleControl))
            Me.DateTimePickerControl_RunAtTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelControl_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxFrequency_Sunday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Frequency = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxFrequency_Saturday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFrequency_Friday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFrequency_Thursday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFrequency_Wednesday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFrequency_Tuesday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxFrequency_Monday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonFrequency_Weekly = New System.Windows.Forms.RadioButton()
            Me.RadioButtonFrequency_Daily = New System.Windows.Forms.RadioButton()
            Me.CheckBoxControl_RepeatEvery = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxControl_RepeatEvery = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.DateTimePickerControl_RunAtTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_Frequency, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Frequency.SuspendLayout()
            Me.SuspendLayout()
            '
            'DateTimePickerControl_RunAtTime
            '
            Me.DateTimePickerControl_RunAtTime.AllowEmptyState = False
            Me.DateTimePickerControl_RunAtTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_RunAtTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_RunAtTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_RunAtTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_RunAtTime.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_RunAtTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerControl_RunAtTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerControl_RunAtTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_RunAtTime.DisplayName = ""
            Me.DateTimePickerControl_RunAtTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_RunAtTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_RunAtTime.FocusHighlightEnabled = True
            Me.DateTimePickerControl_RunAtTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerControl_RunAtTime.FreeTextEntryMode = True
            Me.DateTimePickerControl_RunAtTime.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_RunAtTime.Location = New System.Drawing.Point(81, 0)
            Me.DateTimePickerControl_RunAtTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_RunAtTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.Visible = False
            Me.DateTimePickerControl_RunAtTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerControl_RunAtTime.Name = "DateTimePickerControl_RunAtTime"
            Me.DateTimePickerControl_RunAtTime.ReadOnly = False
            Me.DateTimePickerControl_RunAtTime.Size = New System.Drawing.Size(100, 20)
            Me.DateTimePickerControl_RunAtTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_RunAtTime.TabIndex = 6
            Me.DateTimePickerControl_RunAtTime.TabOnEnter = True
            Me.DateTimePickerControl_RunAtTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerControl_RunAtTime.Value = New Date(2014, 10, 23, 12, 0, 0, 0)
            '
            'LabelControl_RunAt
            '
            Me.LabelControl_RunAt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_RunAt.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_RunAt.Name = "LabelControl_RunAt"
            Me.LabelControl_RunAt.Size = New System.Drawing.Size(75, 20)
            Me.LabelControl_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_RunAt.TabIndex = 5
            Me.LabelControl_RunAt.Text = "Run At:"
            '
            'CheckBoxFrequency_Sunday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Sunday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Sunday.CheckValue = 0
            Me.CheckBoxFrequency_Sunday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Sunday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Sunday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Sunday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Sunday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Sunday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Sunday.Location = New System.Drawing.Point(5, 48)
            Me.CheckBoxFrequency_Sunday.Name = "CheckBoxFrequency_Sunday"
            Me.CheckBoxFrequency_Sunday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Sunday.SecurityEnabled = True
            Me.CheckBoxFrequency_Sunday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Sunday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Sunday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Sunday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Sunday.TabIndex = 8
            Me.CheckBoxFrequency_Sunday.TabOnEnter = True
            Me.CheckBoxFrequency_Sunday.Text = "Sun"
            '
            'GroupBoxControl_Frequency
            '
            Me.GroupBoxControl_Frequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Saturday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Friday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Thursday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Wednesday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Tuesday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Monday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.RadioButtonFrequency_Weekly)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.CheckBoxFrequency_Sunday)
            Me.GroupBoxControl_Frequency.Controls.Add(Me.RadioButtonFrequency_Daily)
            Me.GroupBoxControl_Frequency.Location = New System.Drawing.Point(0, 26)
            Me.GroupBoxControl_Frequency.Name = "GroupBoxControl_Frequency"
            Me.GroupBoxControl_Frequency.Size = New System.Drawing.Size(337, 83)
            Me.GroupBoxControl_Frequency.TabIndex = 13
            Me.GroupBoxControl_Frequency.Text = "Frequency"
            '
            'CheckBoxFrequency_Saturday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Saturday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Saturday.CheckValue = 0
            Me.CheckBoxFrequency_Saturday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Saturday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Saturday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Saturday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Saturday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Saturday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Saturday.Location = New System.Drawing.Point(293, 48)
            Me.CheckBoxFrequency_Saturday.Name = "CheckBoxFrequency_Saturday"
            Me.CheckBoxFrequency_Saturday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Saturday.SecurityEnabled = True
            Me.CheckBoxFrequency_Saturday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Saturday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Saturday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Saturday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Saturday.TabIndex = 18
            Me.CheckBoxFrequency_Saturday.TabOnEnter = True
            Me.CheckBoxFrequency_Saturday.Text = "Sat"
            '
            'CheckBoxFrequency_Friday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Friday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Friday.CheckValue = 0
            Me.CheckBoxFrequency_Friday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Friday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Friday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Friday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Friday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Friday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Friday.Location = New System.Drawing.Point(245, 48)
            Me.CheckBoxFrequency_Friday.Name = "CheckBoxFrequency_Friday"
            Me.CheckBoxFrequency_Friday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Friday.SecurityEnabled = True
            Me.CheckBoxFrequency_Friday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Friday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Friday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Friday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Friday.TabIndex = 17
            Me.CheckBoxFrequency_Friday.TabOnEnter = True
            Me.CheckBoxFrequency_Friday.Text = "Fri"
            '
            'CheckBoxFrequency_Thursday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Thursday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Thursday.CheckValue = 0
            Me.CheckBoxFrequency_Thursday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Thursday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Thursday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Thursday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Thursday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Thursday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Thursday.Location = New System.Drawing.Point(197, 48)
            Me.CheckBoxFrequency_Thursday.Name = "CheckBoxFrequency_Thursday"
            Me.CheckBoxFrequency_Thursday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Thursday.SecurityEnabled = True
            Me.CheckBoxFrequency_Thursday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Thursday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Thursday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Thursday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Thursday.TabIndex = 16
            Me.CheckBoxFrequency_Thursday.TabOnEnter = True
            Me.CheckBoxFrequency_Thursday.Text = "Thu"
            '
            'CheckBoxFrequency_Wednesday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Wednesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Wednesday.CheckValue = 0
            Me.CheckBoxFrequency_Wednesday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Wednesday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Wednesday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Wednesday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Wednesday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Wednesday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Wednesday.Location = New System.Drawing.Point(149, 48)
            Me.CheckBoxFrequency_Wednesday.Name = "CheckBoxFrequency_Wednesday"
            Me.CheckBoxFrequency_Wednesday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Wednesday.SecurityEnabled = True
            Me.CheckBoxFrequency_Wednesday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Wednesday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Wednesday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Wednesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Wednesday.TabIndex = 15
            Me.CheckBoxFrequency_Wednesday.TabOnEnter = True
            Me.CheckBoxFrequency_Wednesday.Text = "Wed"
            '
            'CheckBoxFrequency_Tuesday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Tuesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Tuesday.CheckValue = 0
            Me.CheckBoxFrequency_Tuesday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Tuesday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Tuesday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Tuesday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Tuesday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Tuesday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Tuesday.Location = New System.Drawing.Point(101, 48)
            Me.CheckBoxFrequency_Tuesday.Name = "CheckBoxFrequency_Tuesday"
            Me.CheckBoxFrequency_Tuesday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Tuesday.SecurityEnabled = True
            Me.CheckBoxFrequency_Tuesday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Tuesday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Tuesday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Tuesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Tuesday.TabIndex = 14
            Me.CheckBoxFrequency_Tuesday.TabOnEnter = True
            Me.CheckBoxFrequency_Tuesday.Text = "Tue"
            '
            'CheckBoxFrequency_Monday
            '
            '
            '
            '
            Me.CheckBoxFrequency_Monday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrequency_Monday.CheckValue = 0
            Me.CheckBoxFrequency_Monday.CheckValueChecked = 1
            Me.CheckBoxFrequency_Monday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrequency_Monday.CheckValueUnchecked = 0
            Me.CheckBoxFrequency_Monday.ChildControls = CType(resources.GetObject("CheckBoxFrequency_Monday.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Monday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrequency_Monday.Location = New System.Drawing.Point(53, 48)
            Me.CheckBoxFrequency_Monday.Name = "CheckBoxFrequency_Monday"
            Me.CheckBoxFrequency_Monday.OldestSibling = Nothing
            Me.CheckBoxFrequency_Monday.SecurityEnabled = True
            Me.CheckBoxFrequency_Monday.SiblingControls = CType(resources.GetObject("CheckBoxFrequency_Monday.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxFrequency_Monday.Size = New System.Drawing.Size(42, 23)
            Me.CheckBoxFrequency_Monday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrequency_Monday.TabIndex = 13
            Me.CheckBoxFrequency_Monday.TabOnEnter = True
            Me.CheckBoxFrequency_Monday.Text = "Mon"
            '
            'RadioButtonFrequency_Weekly
            '
            Me.RadioButtonFrequency_Weekly.AutoSize = True
            Me.RadioButtonFrequency_Weekly.Location = New System.Drawing.Point(59, 25)
            Me.RadioButtonFrequency_Weekly.Name = "RadioButtonFrequency_Weekly"
            Me.RadioButtonFrequency_Weekly.Size = New System.Drawing.Size(60, 17)
            Me.RadioButtonFrequency_Weekly.TabIndex = 12
            Me.RadioButtonFrequency_Weekly.TabStop = True
            Me.RadioButtonFrequency_Weekly.Text = "Weekly"
            Me.RadioButtonFrequency_Weekly.UseVisualStyleBackColor = True
            '
            'RadioButtonFrequency_Daily
            '
            Me.RadioButtonFrequency_Daily.AutoSize = True
            Me.RadioButtonFrequency_Daily.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonFrequency_Daily.Name = "RadioButtonFrequency_Daily"
            Me.RadioButtonFrequency_Daily.Size = New System.Drawing.Size(48, 17)
            Me.RadioButtonFrequency_Daily.TabIndex = 11
            Me.RadioButtonFrequency_Daily.TabStop = True
            Me.RadioButtonFrequency_Daily.Text = "Daily"
            Me.RadioButtonFrequency_Daily.UseVisualStyleBackColor = True
            '
            'CheckBoxControl_RepeatEvery
            '
            '
            '
            '
            Me.CheckBoxControl_RepeatEvery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_RepeatEvery.CheckValue = 0
            Me.CheckBoxControl_RepeatEvery.CheckValueChecked = 1
            Me.CheckBoxControl_RepeatEvery.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_RepeatEvery.CheckValueUnchecked = 0
            Me.CheckBoxControl_RepeatEvery.ChildControls = CType(resources.GetObject("CheckBoxControl_RepeatEvery.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_RepeatEvery.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_RepeatEvery.Location = New System.Drawing.Point(0, 115)
            Me.CheckBoxControl_RepeatEvery.Name = "CheckBoxControl_RepeatEvery"
            Me.CheckBoxControl_RepeatEvery.OldestSibling = Nothing
            Me.CheckBoxControl_RepeatEvery.SecurityEnabled = True
            Me.CheckBoxControl_RepeatEvery.SiblingControls = CType(resources.GetObject("CheckBoxControl_RepeatEvery.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_RepeatEvery.Size = New System.Drawing.Size(95, 23)
            Me.CheckBoxControl_RepeatEvery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_RepeatEvery.TabIndex = 14
            Me.CheckBoxControl_RepeatEvery.TabOnEnter = True
            Me.CheckBoxControl_RepeatEvery.Text = "Repeat Every:"
            '
            'ComboBoxControl_RepeatEvery
            '
            Me.ComboBoxControl_RepeatEvery.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_RepeatEvery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_RepeatEvery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_RepeatEvery.AutoFindItemInDataSource = False
            Me.ComboBoxControl_RepeatEvery.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_RepeatEvery.BookmarkingEnabled = False
            Me.ComboBoxControl_RepeatEvery.ClientCode = ""
            Me.ComboBoxControl_RepeatEvery.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxControl_RepeatEvery.DisableMouseWheel = False
            Me.ComboBoxControl_RepeatEvery.DisplayMember = "Name"
            Me.ComboBoxControl_RepeatEvery.DisplayName = ""
            Me.ComboBoxControl_RepeatEvery.DivisionCode = ""
            Me.ComboBoxControl_RepeatEvery.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_RepeatEvery.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_RepeatEvery.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_RepeatEvery.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_RepeatEvery.FocusHighlightEnabled = True
            Me.ComboBoxControl_RepeatEvery.FormattingEnabled = True
            Me.ComboBoxControl_RepeatEvery.ItemHeight = 15
            Me.ComboBoxControl_RepeatEvery.Location = New System.Drawing.Point(101, 117)
            Me.ComboBoxControl_RepeatEvery.Name = "ComboBoxControl_RepeatEvery"
            Me.ComboBoxControl_RepeatEvery.ReadOnly = False
            Me.ComboBoxControl_RepeatEvery.SecurityEnabled = True
            Me.ComboBoxControl_RepeatEvery.Size = New System.Drawing.Size(138, 21)
            Me.ComboBoxControl_RepeatEvery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_RepeatEvery.TabIndex = 15
            Me.ComboBoxControl_RepeatEvery.TabOnEnter = True
            Me.ComboBoxControl_RepeatEvery.ValueMember = "Code"
            Me.ComboBoxControl_RepeatEvery.WatermarkText = "Select Client"
            '
            'ScheduleControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.ComboBoxControl_RepeatEvery)
            Me.Controls.Add(Me.CheckBoxControl_RepeatEvery)
            Me.Controls.Add(Me.GroupBoxControl_Frequency)
            Me.Controls.Add(Me.DateTimePickerControl_RunAtTime)
            Me.Controls.Add(Me.LabelControl_RunAt)
            Me.Name = "ScheduleControl"
            Me.Size = New System.Drawing.Size(337, 171)
            CType(Me.DateTimePickerControl_RunAtTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_Frequency, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Frequency.ResumeLayout(False)
            Me.GroupBoxControl_Frequency.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents DateTimePickerControl_RunAtTime As DateTimePicker
        Friend WithEvents LabelControl_RunAt As Label
        Friend WithEvents CheckBoxFrequency_Sunday As CheckBox
        Friend WithEvents GroupBoxControl_Frequency As GroupBox
        Friend WithEvents RadioButtonFrequency_Weekly As Windows.Forms.RadioButton
        Friend WithEvents RadioButtonFrequency_Daily As Windows.Forms.RadioButton
        Friend WithEvents CheckBoxFrequency_Saturday As CheckBox
        Friend WithEvents CheckBoxFrequency_Friday As CheckBox
        Friend WithEvents CheckBoxFrequency_Thursday As CheckBox
        Friend WithEvents CheckBoxFrequency_Wednesday As CheckBox
        Friend WithEvents CheckBoxFrequency_Tuesday As CheckBox
        Friend WithEvents CheckBoxFrequency_Monday As CheckBox
        Friend WithEvents CheckBoxControl_RepeatEvery As CheckBox
        Friend WithEvents ComboBoxControl_RepeatEvery As ComboBox
    End Class

End Namespace