Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VirtualCreditCardTransactionLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VirtualCreditCardTransactionLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.GroupBoxForm_DateRangeType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonDateRangeType_OpenOrderLine = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDateRangeType_VCCTransaction = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxForm_IncludeTransactionDetail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxForm_DateRangeType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_DateRangeType.SuspendLayout()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(137, 191)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(218, 191)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'GroupBoxForm_DateRangeType
            '
            Me.GroupBoxForm_DateRangeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_DateRangeType.Controls.Add(Me.RadioButtonDateRangeType_OpenOrderLine)
            Me.GroupBoxForm_DateRangeType.Controls.Add(Me.RadioButtonDateRangeType_VCCTransaction)
            Me.GroupBoxForm_DateRangeType.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_DateRangeType.Name = "GroupBoxForm_DateRangeType"
            Me.GroupBoxForm_DateRangeType.Size = New System.Drawing.Size(281, 86)
            Me.GroupBoxForm_DateRangeType.TabIndex = 0
            Me.GroupBoxForm_DateRangeType.Text = "Date Range Type"
            '
            'RadioButtonDateRangeType_OpenOrderLine
            '
            Me.RadioButtonDateRangeType_OpenOrderLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonDateRangeType_OpenOrderLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDateRangeType_OpenOrderLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDateRangeType_OpenOrderLine.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDateRangeType_OpenOrderLine.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonDateRangeType_OpenOrderLine.Name = "RadioButtonDateRangeType_OpenOrderLine"
            Me.RadioButtonDateRangeType_OpenOrderLine.SecurityEnabled = True
            Me.RadioButtonDateRangeType_OpenOrderLine.Size = New System.Drawing.Size(271, 20)
            Me.RadioButtonDateRangeType_OpenOrderLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDateRangeType_OpenOrderLine.TabIndex = 1
            Me.RadioButtonDateRangeType_OpenOrderLine.TabOnEnter = True
            Me.RadioButtonDateRangeType_OpenOrderLine.TabStop = False
            Me.RadioButtonDateRangeType_OpenOrderLine.Tag = "2"
            Me.RadioButtonDateRangeType_OpenOrderLine.Text = "All Orders within an Order/Line Date Range"
            '
            'RadioButtonDateRangeType_VCCTransaction
            '
            Me.RadioButtonDateRangeType_VCCTransaction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonDateRangeType_VCCTransaction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDateRangeType_VCCTransaction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDateRangeType_VCCTransaction.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDateRangeType_VCCTransaction.Checked = True
            Me.RadioButtonDateRangeType_VCCTransaction.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDateRangeType_VCCTransaction.CheckValue = "Y"
            Me.RadioButtonDateRangeType_VCCTransaction.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonDateRangeType_VCCTransaction.Name = "RadioButtonDateRangeType_VCCTransaction"
            Me.RadioButtonDateRangeType_VCCTransaction.SecurityEnabled = True
            Me.RadioButtonDateRangeType_VCCTransaction.Size = New System.Drawing.Size(271, 20)
            Me.RadioButtonDateRangeType_VCCTransaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDateRangeType_VCCTransaction.TabIndex = 0
            Me.RadioButtonDateRangeType_VCCTransaction.TabOnEnter = True
            Me.RadioButtonDateRangeType_VCCTransaction.Tag = "1"
            Me.RadioButtonDateRangeType_VCCTransaction.Text = "Virtual Credit Card Transaction Date Range"
            '
            'CheckBoxForm_IncludeTransactionDetail
            '
            Me.CheckBoxForm_IncludeTransactionDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeTransactionDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeTransactionDetail.CheckValue = 0
            Me.CheckBoxForm_IncludeTransactionDetail.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeTransactionDetail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeTransactionDetail.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeTransactionDetail.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeTransactionDetail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeTransactionDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeTransactionDetail.Location = New System.Drawing.Point(12, 156)
            Me.CheckBoxForm_IncludeTransactionDetail.Name = "CheckBoxForm_IncludeTransactionDetail"
            Me.CheckBoxForm_IncludeTransactionDetail.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeTransactionDetail.SecurityEnabled = True
            Me.CheckBoxForm_IncludeTransactionDetail.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeTransactionDetail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeTransactionDetail.Size = New System.Drawing.Size(281, 21)
            Me.CheckBoxForm_IncludeTransactionDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeTransactionDetail.TabIndex = 5
            Me.CheckBoxForm_IncludeTransactionDetail.TabOnEnter = True
            Me.CheckBoxForm_IncludeTransactionDetail.Text = "Include Transaction Detail"
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
            Me.DateTimePickerForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_EndDate.DisplayName = ""
            Me.DateTimePickerForm_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EndDate.Location = New System.Drawing.Point(119, 130)
            Me.DateTimePickerForm_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_EndDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
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
            Me.DateTimePickerForm_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_EndDate.Size = New System.Drawing.Size(103, 20)
            Me.DateTimePickerForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EndDate.TabIndex = 4
            Me.DateTimePickerForm_EndDate.TabOnEnter = True
            Me.DateTimePickerForm_EndDate.Value = New Date(2014, 5, 29, 9, 35, 2, 204)
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 130)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 3
            Me.LabelForm_EndDate.Text = "End Date:"
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
            Me.DateTimePickerForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.DisplayName = ""
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(119, 104)
            Me.DateTimePickerForm_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartDate.MinDate = New Date(1980, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
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
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(103, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 2
            Me.DateTimePickerForm_StartDate.TabOnEnter = True
            Me.DateTimePickerForm_StartDate.Value = New Date(2014, 5, 29, 9, 35, 2, 267)
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 104)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(98, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 1
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'VirtualCreditCardTransactionLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(305, 223)
            Me.Controls.Add(Me.DateTimePickerForm_EndDate)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.CheckBoxForm_IncludeTransactionDetail)
            Me.Controls.Add(Me.GroupBoxForm_DateRangeType)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VirtualCreditCardTransactionLoadingDialog"
            Me.Text = "Virtual Credit Card Transactions Criteria"
            CType(Me.GroupBoxForm_DateRangeType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_DateRangeType.ResumeLayout(False)
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxForm_DateRangeType As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonDateRangeType_OpenOrderLine As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDateRangeType_VCCTransaction As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxForm_IncludeTransactionDetail As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DateTimePickerForm_EndDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_EndDate As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_StartDate As WinForm.Presentation.Controls.Label
    End Class

End Namespace