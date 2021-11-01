Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeUpdateDatesDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeUpdateDatesDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_FromDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EnterToAndFromDates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ToDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_DateFrom = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_DateTo = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_ApplyDatesTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Vacation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Sick = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Personal = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_UpdateByStartDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            CType(Me.DateTimePickerForm_DateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(241, 142)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(160, 142)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 11
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_FromDate
            '
            Me.LabelForm_FromDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FromDate.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_FromDate.Name = "LabelForm_FromDate"
            Me.LabelForm_FromDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_FromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FromDate.TabIndex = 2
            Me.LabelForm_FromDate.Text = "From Date:"
            '
            'LabelForm_EnterToAndFromDates
            '
            Me.LabelForm_EnterToAndFromDates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_EnterToAndFromDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EnterToAndFromDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_EnterToAndFromDates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_EnterToAndFromDates.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EnterToAndFromDates.Name = "LabelForm_EnterToAndFromDates"
            Me.LabelForm_EnterToAndFromDates.Size = New System.Drawing.Size(304, 20)
            Me.LabelForm_EnterToAndFromDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EnterToAndFromDates.TabIndex = 1
            Me.LabelForm_EnterToAndFromDates.Text = "Please Enter To and From Dates"
            '
            'LabelForm_ToDate
            '
            Me.LabelForm_ToDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ToDate.Location = New System.Drawing.Point(167, 64)
            Me.LabelForm_ToDate.Name = "LabelForm_ToDate"
            Me.LabelForm_ToDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_ToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ToDate.TabIndex = 5
            Me.LabelForm_ToDate.Text = "To Date:"
            '
            'DateTimePickerForm_DateFrom
            '
            Me.DateTimePickerForm_DateFrom.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DateFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DateFrom.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DateFrom.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DateFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DateFrom.CustomFormat = ""
            Me.DateTimePickerForm_DateFrom.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DateFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DateFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DateFrom.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DateFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DateFrom.FreeTextEntryMode = True
            Me.DateTimePickerForm_DateFrom.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DateFrom.Location = New System.Drawing.Point(78, 64)
            Me.DateTimePickerForm_DateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_DateFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DateFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.DisplayMonth = New Date(2012, 4, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DateFrom.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DateFrom.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DateFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateFrom.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DateFrom.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DateFrom.Name = "DateTimePickerForm_DateFrom"
            Me.DateTimePickerForm_DateFrom.ReadOnly = False
            Me.DateTimePickerForm_DateFrom.Size = New System.Drawing.Size(83, 20)
            Me.DateTimePickerForm_DateFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DateFrom.TabIndex = 4
            Me.DateTimePickerForm_DateFrom.Value = New Date(2013, 11, 6, 11, 43, 32, 837)
            '
            'DateTimePickerForm_DateTo
            '
            Me.DateTimePickerForm_DateTo.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DateTo.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DateTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DateTo.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DateTo.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DateTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DateTo.CustomFormat = ""
            Me.DateTimePickerForm_DateTo.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DateTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DateTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DateTo.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DateTo.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DateTo.FreeTextEntryMode = True
            Me.DateTimePickerForm_DateTo.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DateTo.Location = New System.Drawing.Point(233, 64)
            Me.DateTimePickerForm_DateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_DateTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DateTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.DisplayMonth = New Date(2012, 4, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DateTo.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DateTo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DateTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateTo.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DateTo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DateTo.Name = "DateTimePickerForm_DateTo"
            Me.DateTimePickerForm_DateTo.ReadOnly = False
            Me.DateTimePickerForm_DateTo.Size = New System.Drawing.Size(83, 20)
            Me.DateTimePickerForm_DateTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DateTo.TabIndex = 6
            Me.DateTimePickerForm_DateTo.Value = New Date(2013, 11, 6, 11, 43, 32, 877)
            '
            'LabelForm_ApplyDatesTo
            '
            Me.LabelForm_ApplyDatesTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ApplyDatesTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ApplyDatesTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ApplyDatesTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ApplyDatesTo.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_ApplyDatesTo.Name = "LabelForm_ApplyDatesTo"
            Me.LabelForm_ApplyDatesTo.Size = New System.Drawing.Size(304, 20)
            Me.LabelForm_ApplyDatesTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ApplyDatesTo.TabIndex = 7
            Me.LabelForm_ApplyDatesTo.Text = "Apply Dates to"
            '
            'CheckBoxForm_Vacation
            '
            '
            '
            '
            Me.CheckBoxForm_Vacation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Vacation.CheckValue = 0
            Me.CheckBoxForm_Vacation.CheckValueChecked = 1
            Me.CheckBoxForm_Vacation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Vacation.CheckValueUnchecked = 0
            Me.CheckBoxForm_Vacation.ChildControls = CType(resources.GetObject("CheckBoxForm_Vacation.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vacation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Vacation.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_Vacation.Name = "CheckBoxForm_Vacation"
            Me.CheckBoxForm_Vacation.OldestSibling = Nothing
            Me.CheckBoxForm_Vacation.SecurityEnabled = True
            Me.CheckBoxForm_Vacation.SiblingControls = CType(resources.GetObject("CheckBoxForm_Vacation.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vacation.Size = New System.Drawing.Size(97, 20)
            Me.CheckBoxForm_Vacation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Vacation.TabIndex = 8
            Me.CheckBoxForm_Vacation.Text = "Vacation"
            '
            'CheckBoxForm_Sick
            '
            '
            '
            '
            Me.CheckBoxForm_Sick.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Sick.CheckValue = 0
            Me.CheckBoxForm_Sick.CheckValueChecked = 1
            Me.CheckBoxForm_Sick.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Sick.CheckValueUnchecked = 0
            Me.CheckBoxForm_Sick.ChildControls = CType(resources.GetObject("CheckBoxForm_Sick.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Sick.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Sick.Location = New System.Drawing.Point(115, 116)
            Me.CheckBoxForm_Sick.Name = "CheckBoxForm_Sick"
            Me.CheckBoxForm_Sick.OldestSibling = Nothing
            Me.CheckBoxForm_Sick.SecurityEnabled = True
            Me.CheckBoxForm_Sick.SiblingControls = CType(resources.GetObject("CheckBoxForm_Sick.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Sick.Size = New System.Drawing.Size(97, 20)
            Me.CheckBoxForm_Sick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Sick.TabIndex = 9
            Me.CheckBoxForm_Sick.Text = "Sick"
            '
            'CheckBoxForm_Personal
            '
            '
            '
            '
            Me.CheckBoxForm_Personal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Personal.CheckValue = 0
            Me.CheckBoxForm_Personal.CheckValueChecked = 1
            Me.CheckBoxForm_Personal.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Personal.CheckValueUnchecked = 0
            Me.CheckBoxForm_Personal.ChildControls = CType(resources.GetObject("CheckBoxForm_Personal.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Personal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Personal.Location = New System.Drawing.Point(218, 116)
            Me.CheckBoxForm_Personal.Name = "CheckBoxForm_Personal"
            Me.CheckBoxForm_Personal.OldestSibling = Nothing
            Me.CheckBoxForm_Personal.SecurityEnabled = True
            Me.CheckBoxForm_Personal.SiblingControls = CType(resources.GetObject("CheckBoxForm_Personal.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Personal.Size = New System.Drawing.Size(98, 20)
            Me.CheckBoxForm_Personal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Personal.TabIndex = 10
            Me.CheckBoxForm_Personal.Text = "Personal"
            '
            'CheckBoxForm_UpdateByStartDate
            '
            '
            '
            '
            Me.CheckBoxForm_UpdateByStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UpdateByStartDate.CheckValue = 0
            Me.CheckBoxForm_UpdateByStartDate.CheckValueChecked = 1
            Me.CheckBoxForm_UpdateByStartDate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UpdateByStartDate.CheckValueUnchecked = 0
            Me.CheckBoxForm_UpdateByStartDate.ChildControls = CType(resources.GetObject("CheckBoxForm_UpdateByStartDate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateByStartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UpdateByStartDate.Location = New System.Drawing.Point(12, 12)
            Me.CheckBoxForm_UpdateByStartDate.Name = "CheckBoxForm_UpdateByStartDate"
            Me.CheckBoxForm_UpdateByStartDate.OldestSibling = Nothing
            Me.CheckBoxForm_UpdateByStartDate.SecurityEnabled = True
            Me.CheckBoxForm_UpdateByStartDate.SiblingControls = CType(resources.GetObject("CheckBoxForm_UpdateByStartDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateByStartDate.Size = New System.Drawing.Size(304, 20)
            Me.CheckBoxForm_UpdateByStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UpdateByStartDate.TabIndex = 0
            Me.CheckBoxForm_UpdateByStartDate.Text = "Updated based on Employment Date"
            '
            'NumericInputForm_Year
            '
            Me.NumericInputForm_Year.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_Year.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Year.Location = New System.Drawing.Point(78, 64)
            Me.NumericInputForm_Year.Name = "NumericInputForm_Year"
            Me.NumericInputForm_Year.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_Year.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_Year.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Year.Properties.IsFloatValue = False
            Me.NumericInputForm_Year.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_Year.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Year.Properties.MaxLength = 11
            Me.NumericInputForm_Year.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputForm_Year.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_Year.Size = New System.Drawing.Size(83, 20)
            Me.NumericInputForm_Year.TabIndex = 3
            '
            'EmployeeUpdateDatesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(328, 174)
            Me.Controls.Add(Me.NumericInputForm_Year)
            Me.Controls.Add(Me.CheckBoxForm_UpdateByStartDate)
            Me.Controls.Add(Me.LabelForm_ApplyDatesTo)
            Me.Controls.Add(Me.CheckBoxForm_Sick)
            Me.Controls.Add(Me.CheckBoxForm_Vacation)
            Me.Controls.Add(Me.CheckBoxForm_Personal)
            Me.Controls.Add(Me.LabelForm_EnterToAndFromDates)
            Me.Controls.Add(Me.DateTimePickerForm_DateTo)
            Me.Controls.Add(Me.DateTimePickerForm_DateFrom)
            Me.Controls.Add(Me.LabelForm_FromDate)
            Me.Controls.Add(Me.LabelForm_ToDate)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeUpdateDatesDialog"
            Me.Text = "Update Dates"
            CType(Me.DateTimePickerForm_DateFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_FromDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EnterToAndFromDates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ToDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_DateFrom As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_DateTo As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_ApplyDatesTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Vacation As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Sick As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Personal As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UpdateByStartDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputForm_Year As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace