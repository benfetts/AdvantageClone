Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SelectDateRangeDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectDateRangeDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DateTimePickerPanelDates_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerPanelDates_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelPanelDates_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanelDates_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonPanelDates_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPanelDates_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_Dates = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.DateTimePickerPanelDates_From, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerPanelDates_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Dates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Dates.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(208, 85)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(289, 85)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DateTimePickerPanelDates_From
            '
            Me.DateTimePickerPanelDates_From.AllowEmptyState = False
            Me.DateTimePickerPanelDates_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerPanelDates_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerPanelDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerPanelDates_From.ButtonDropDown.Visible = True
            Me.DateTimePickerPanelDates_From.ButtonFreeText.Checked = True
            Me.DateTimePickerPanelDates_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerPanelDates_From.CustomFormat = ""
            Me.DateTimePickerPanelDates_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerPanelDates_From.DisplayName = ""
            Me.DateTimePickerPanelDates_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerPanelDates_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerPanelDates_From.FocusHighlightEnabled = True
            Me.DateTimePickerPanelDates_From.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerPanelDates_From.FreeTextEntryMode = True
            Me.DateTimePickerPanelDates_From.IsPopupCalendarOpen = False
            Me.DateTimePickerPanelDates_From.Location = New System.Drawing.Point(60, 5)
            Me.DateTimePickerPanelDates_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerPanelDates_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerPanelDates_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerPanelDates_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerPanelDates_From.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerPanelDates_From.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerPanelDates_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerPanelDates_From.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerPanelDates_From.Name = "DateTimePickerPanelDates_From"
            Me.DateTimePickerPanelDates_From.ReadOnly = False
            Me.DateTimePickerPanelDates_From.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerPanelDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerPanelDates_From.TabIndex = 1
            Me.DateTimePickerPanelDates_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'DateTimePickerPanelDates_To
            '
            Me.DateTimePickerPanelDates_To.AllowEmptyState = False
            Me.DateTimePickerPanelDates_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerPanelDates_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerPanelDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerPanelDates_To.ButtonDropDown.Visible = True
            Me.DateTimePickerPanelDates_To.ButtonFreeText.Checked = True
            Me.DateTimePickerPanelDates_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerPanelDates_To.CustomFormat = ""
            Me.DateTimePickerPanelDates_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerPanelDates_To.DisplayName = ""
            Me.DateTimePickerPanelDates_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerPanelDates_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerPanelDates_To.FocusHighlightEnabled = True
            Me.DateTimePickerPanelDates_To.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerPanelDates_To.FreeTextEntryMode = True
            Me.DateTimePickerPanelDates_To.IsPopupCalendarOpen = False
            Me.DateTimePickerPanelDates_To.Location = New System.Drawing.Point(60, 31)
            Me.DateTimePickerPanelDates_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerPanelDates_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerPanelDates_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerPanelDates_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerPanelDates_To.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerPanelDates_To.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerPanelDates_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerPanelDates_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerPanelDates_To.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerPanelDates_To.Name = "DateTimePickerPanelDates_To"
            Me.DateTimePickerPanelDates_To.ReadOnly = False
            Me.DateTimePickerPanelDates_To.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerPanelDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerPanelDates_To.TabIndex = 3
            Me.DateTimePickerPanelDates_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'LabelPanelDates_From
            '
            Me.LabelPanelDates_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanelDates_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanelDates_From.Location = New System.Drawing.Point(9, 5)
            Me.LabelPanelDates_From.Name = "LabelPanelDates_From"
            Me.LabelPanelDates_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelPanelDates_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanelDates_From.TabIndex = 0
            Me.LabelPanelDates_From.Text = "From:"
            '
            'LabelPanelDates_To
            '
            Me.LabelPanelDates_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanelDates_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanelDates_To.Location = New System.Drawing.Point(9, 31)
            Me.LabelPanelDates_To.Name = "LabelPanelDates_To"
            Me.LabelPanelDates_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelPanelDates_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanelDates_To.TabIndex = 2
            Me.LabelPanelDates_To.Text = "To:"
            '
            'ButtonPanelDates_YTD
            '
            Me.ButtonPanelDates_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_YTD.Location = New System.Drawing.Point(190, 5)
            Me.ButtonPanelDates_YTD.Name = "ButtonPanelDates_YTD"
            Me.ButtonPanelDates_YTD.SecurityEnabled = True
            Me.ButtonPanelDates_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_YTD.TabIndex = 4
            Me.ButtonPanelDates_YTD.Text = "YTD"
            '
            'ButtonPanelDates_MTD
            '
            Me.ButtonPanelDates_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_MTD.Location = New System.Drawing.Point(190, 31)
            Me.ButtonPanelDates_MTD.Name = "ButtonPanelDates_MTD"
            Me.ButtonPanelDates_MTD.SecurityEnabled = True
            Me.ButtonPanelDates_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_MTD.TabIndex = 6
            Me.ButtonPanelDates_MTD.Text = "MTD"
            '
            'ButtonPanelDates_1Year
            '
            Me.ButtonPanelDates_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_1Year.Location = New System.Drawing.Point(271, 5)
            Me.ButtonPanelDates_1Year.Name = "ButtonPanelDates_1Year"
            Me.ButtonPanelDates_1Year.SecurityEnabled = True
            Me.ButtonPanelDates_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_1Year.TabIndex = 5
            Me.ButtonPanelDates_1Year.Text = "1 Year"
            '
            'ButtonPanelDates_2Years
            '
            Me.ButtonPanelDates_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPanelDates_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPanelDates_2Years.Location = New System.Drawing.Point(271, 31)
            Me.ButtonPanelDates_2Years.Name = "ButtonPanelDates_2Years"
            Me.ButtonPanelDates_2Years.SecurityEnabled = True
            Me.ButtonPanelDates_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPanelDates_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPanelDates_2Years.TabIndex = 7
            Me.ButtonPanelDates_2Years.Text = "2 Years"
            '
            'PanelForm_Dates
            '
            Me.PanelForm_Dates.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.PanelForm_Dates.Appearance.Options.UseBackColor = True
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_2Years)
            Me.PanelForm_Dates.Controls.Add(Me.DateTimePickerPanelDates_To)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_1Year)
            Me.PanelForm_Dates.Controls.Add(Me.DateTimePickerPanelDates_From)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_MTD)
            Me.PanelForm_Dates.Controls.Add(Me.LabelPanelDates_From)
            Me.PanelForm_Dates.Controls.Add(Me.ButtonPanelDates_YTD)
            Me.PanelForm_Dates.Controls.Add(Me.LabelPanelDates_To)
            Me.PanelForm_Dates.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_Dates.Name = "PanelForm_Dates"
            Me.PanelForm_Dates.Size = New System.Drawing.Size(353, 67)
            Me.PanelForm_Dates.TabIndex = 2
            '
            'SelectDateRangeDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(376, 117)
            Me.Controls.Add(Me.PanelForm_Dates)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SelectDateRangeDialog"
            Me.Text = "Select Date Range"
            CType(Me.DateTimePickerPanelDates_From, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerPanelDates_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Dates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Dates.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DateTimePickerPanelDates_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerPanelDates_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelPanelDates_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanelDates_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonPanelDates_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonPanelDates_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_Dates As AdvantageFramework.WinForm.Presentation.Controls.Panel
    End Class

End Namespace