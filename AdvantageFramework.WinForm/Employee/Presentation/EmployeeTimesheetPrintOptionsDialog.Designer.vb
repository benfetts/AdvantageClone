Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimesheetPrintOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimesheetPrintOptionsDialog))
            Me.ButtonForm_Print = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_ExcludeEmployeeSignature = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlForm_Summary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_DetailWithComments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_ReportType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SortByLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_SortBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_OptionsHeader = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Print
            '
            Me.ButtonForm_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Print.Location = New System.Drawing.Point(150, 168)
            Me.ButtonForm_Print.Name = "ButtonForm_Print"
            Me.ButtonForm_Print.SecurityEnabled = True
            Me.ButtonForm_Print.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Print.TabIndex = 11
            Me.ButtonForm_Print.Text = "Print"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(231, 168)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_ExcludeEmployeeSignature
            '
            '
            '
            '
            Me.CheckBoxForm_ExcludeEmployeeSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValue = 0
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeEmployeeSignature.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeEmployeeSignature.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeEmployeeSignature.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeEmployeeSignature.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeEmployeeSignature.Location = New System.Drawing.Point(75, 142)
            Me.CheckBoxForm_ExcludeEmployeeSignature.Name = "CheckBoxForm_ExcludeEmployeeSignature"
            Me.CheckBoxForm_ExcludeEmployeeSignature.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeEmployeeSignature.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeEmployeeSignature.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeEmployeeSignature.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeEmployeeSignature.Size = New System.Drawing.Size(231, 20)
            Me.CheckBoxForm_ExcludeEmployeeSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeEmployeeSignature.TabIndex = 10
            Me.CheckBoxForm_ExcludeEmployeeSignature.Text = "Exclude Employee Signature"
            '
            'RadioButtonControlForm_Summary
            '
            Me.RadioButtonControlForm_Summary.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonControlForm_Summary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_Summary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_Summary.Checked = True
            Me.RadioButtonControlForm_Summary.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlForm_Summary.CheckValue = "Y"
            Me.RadioButtonControlForm_Summary.Location = New System.Drawing.Point(12, 38)
            Me.RadioButtonControlForm_Summary.Name = "RadioButtonControlForm_Summary"
            Me.RadioButtonControlForm_Summary.SecurityEnabled = True
            Me.RadioButtonControlForm_Summary.Size = New System.Drawing.Size(83, 20)
            Me.RadioButtonControlForm_Summary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_Summary.TabIndex = 1
            Me.RadioButtonControlForm_Summary.Text = "Summary"
            '
            'RadioButtonControlForm_DetailWithComments
            '
            Me.RadioButtonControlForm_DetailWithComments.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonControlForm_DetailWithComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_DetailWithComments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_DetailWithComments.Location = New System.Drawing.Point(101, 38)
            Me.RadioButtonControlForm_DetailWithComments.Name = "RadioButtonControlForm_DetailWithComments"
            Me.RadioButtonControlForm_DetailWithComments.SecurityEnabled = True
            Me.RadioButtonControlForm_DetailWithComments.Size = New System.Drawing.Size(205, 20)
            Me.RadioButtonControlForm_DetailWithComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_DetailWithComments.TabIndex = 2
            Me.RadioButtonControlForm_DetailWithComments.TabStop = False
            Me.RadioButtonControlForm_DetailWithComments.Text = "Detail with Comments"
            '
            'LabelForm_ReportType
            '
            Me.LabelForm_ReportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ReportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportType.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportType.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportType.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportType.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ReportType.Name = "LabelForm_ReportType"
            Me.LabelForm_ReportType.Size = New System.Drawing.Size(294, 20)
            Me.LabelForm_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportType.TabIndex = 0
            Me.LabelForm_ReportType.Text = "Report Type"
            '
            'LabelForm_SortByLabel
            '
            Me.LabelForm_SortByLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SortByLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SortByLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SortByLabel.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_SortByLabel.Name = "LabelForm_SortByLabel"
            Me.LabelForm_SortByLabel.Size = New System.Drawing.Size(57, 20)
            Me.LabelForm_SortByLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SortByLabel.TabIndex = 7
            Me.LabelForm_SortByLabel.Text = "Sort By:"
            '
            'ComboBoxForm_SortBy
            '
            Me.ComboBoxForm_SortBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SortBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SortBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SortBy.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SortBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SortBy.BookmarkingEnabled = False
            Me.ComboBoxForm_SortBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_SortBy.DisableMouseWheel = False
            Me.ComboBoxForm_SortBy.DisplayMember = "Description"
            Me.ComboBoxForm_SortBy.DisplayName = ""
            Me.ComboBoxForm_SortBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SortBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_SortBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_SortBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SortBy.FocusHighlightEnabled = True
            Me.ComboBoxForm_SortBy.FormattingEnabled = True
            Me.ComboBoxForm_SortBy.ItemHeight = 14
            Me.ComboBoxForm_SortBy.Location = New System.Drawing.Point(75, 116)
            Me.ComboBoxForm_SortBy.Name = "ComboBoxForm_SortBy"
            Me.ComboBoxForm_SortBy.PreventEnterBeep = False
            Me.ComboBoxForm_SortBy.ReadOnly = False
            Me.ComboBoxForm_SortBy.SecurityEnabled = True
            Me.ComboBoxForm_SortBy.Size = New System.Drawing.Size(231, 20)
            Me.ComboBoxForm_SortBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SortBy.TabIndex = 9
            Me.ComboBoxForm_SortBy.ValueMember = "Code"
            Me.ComboBoxForm_SortBy.WatermarkText = "Select"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(57, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 3
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'DateTimePickerForm_StartDate
            '
            Me.DateTimePickerForm_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_StartDate.CustomFormat = ""
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(75, 64)
            Me.DateTimePickerForm_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2013, 11, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_StartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_StartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_StartDate.Name = "DateTimePickerForm_StartDate"
            Me.DateTimePickerForm_StartDate.ReadOnly = False
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 4
            Me.DateTimePickerForm_StartDate.Value = New Date(2013, 11, 27, 10, 19, 48, 250)
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(162, 64)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(57, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 5
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'DateTimePickerForm_EndDate
            '
            Me.DateTimePickerForm_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_EndDate.CustomFormat = ""
            Me.DateTimePickerForm_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.DateTimePickerForm_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EndDate.Location = New System.Drawing.Point(225, 64)
            Me.DateTimePickerForm_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.DisplayMonth = New Date(2013, 11, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_EndDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_EndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_EndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_EndDate.Name = "DateTimePickerForm_EndDate"
            Me.DateTimePickerForm_EndDate.ReadOnly = False
            Me.DateTimePickerForm_EndDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EndDate.TabIndex = 6
            Me.DateTimePickerForm_EndDate.Value = New Date(2013, 11, 27, 10, 19, 48, 273)
            '
            'LabelForm_OptionsHeader
            '
            Me.LabelForm_OptionsHeader.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OptionsHeader.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_OptionsHeader.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_OptionsHeader.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_OptionsHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OptionsHeader.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_OptionsHeader.Name = "LabelForm_OptionsHeader"
            Me.LabelForm_OptionsHeader.Size = New System.Drawing.Size(294, 20)
            Me.LabelForm_OptionsHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OptionsHeader.TabIndex = 8
            Me.LabelForm_OptionsHeader.Text = "Options"
            '
            'EmployeeTimesheetPrintOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(318, 200)
            Me.Controls.Add(Me.LabelForm_OptionsHeader)
            Me.Controls.Add(Me.DateTimePickerForm_EndDate)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.ComboBoxForm_SortBy)
            Me.Controls.Add(Me.LabelForm_SortByLabel)
            Me.Controls.Add(Me.LabelForm_ReportType)
            Me.Controls.Add(Me.RadioButtonControlForm_DetailWithComments)
            Me.Controls.Add(Me.RadioButtonControlForm_Summary)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Print)
            Me.Controls.Add(Me.CheckBoxForm_ExcludeEmployeeSignature)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimesheetPrintOptionsDialog"
            Me.Text = "Timesheet"
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Print As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_ExcludeEmployeeSignature As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlForm_Summary As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_DetailWithComments As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents LabelForm_ReportType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_SortByLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_SortBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_OptionsHeader As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace