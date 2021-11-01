Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeInOutInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeInOutInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_LimitEntries = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_StartingDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            CType(Me.DateTimePickerForm_StartingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(160, 85)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(241, 85)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_LimitEntries
            '
            '
            '
            '
            Me.CheckBoxForm_LimitEntries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_LimitEntries.CheckValue = 0
            Me.CheckBoxForm_LimitEntries.CheckValueChecked = 1
            Me.CheckBoxForm_LimitEntries.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_LimitEntries.CheckValueUnchecked = 0
            Me.CheckBoxForm_LimitEntries.ChildControls = CType(resources.GetObject("CheckBoxForm_LimitEntries.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LimitEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_LimitEntries.Location = New System.Drawing.Point(12, 38)
            Me.CheckBoxForm_LimitEntries.Name = "CheckBoxForm_LimitEntries"
            Me.CheckBoxForm_LimitEntries.OldestSibling = Nothing
            Me.CheckBoxForm_LimitEntries.SecurityEnabled = True
            Me.CheckBoxForm_LimitEntries.SiblingControls = CType(resources.GetObject("CheckBoxForm_LimitEntries.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LimitEntries.Size = New System.Drawing.Size(304, 20)
            Me.CheckBoxForm_LimitEntries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_LimitEntries.TabIndex = 29
            Me.CheckBoxForm_LimitEntries.TabOnEnter = True
            Me.CheckBoxForm_LimitEntries.Text = "Limit to last entry for employee"
            '
            'LabelForm_StartingDate
            '
            Me.LabelForm_StartingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingDate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StartingDate.Name = "LabelForm_StartingDate"
            Me.LabelForm_StartingDate.Size = New System.Drawing.Size(83, 20)
            Me.LabelForm_StartingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingDate.TabIndex = 30
            Me.LabelForm_StartingDate.Text = "Starting Date:"
            '
            'DateTimePickerForm_StartingDate
            '
            Me.DateTimePickerForm_StartingDate.AllowEmptyState = False
            Me.DateTimePickerForm_StartingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_StartingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_StartingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_StartingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_StartingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_StartingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_StartingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartingDate.DisplayName = ""
            Me.DateTimePickerForm_StartingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartingDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartingDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartingDate.Location = New System.Drawing.Point(101, 12)
            Me.DateTimePickerForm_StartingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_StartingDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_StartingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_StartingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_StartingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartingDate.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_StartingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_StartingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_StartingDate.Name = "DateTimePickerForm_StartingDate"
            Me.DateTimePickerForm_StartingDate.ReadOnly = False
            Me.DateTimePickerForm_StartingDate.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_StartingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartingDate.TabIndex = 31
            Me.DateTimePickerForm_StartingDate.TabOnEnter = True
            Me.DateTimePickerForm_StartingDate.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'EmployeeInOutInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(328, 117)
            Me.Controls.Add(Me.LabelForm_StartingDate)
            Me.Controls.Add(Me.DateTimePickerForm_StartingDate)
            Me.Controls.Add(Me.CheckBoxForm_LimitEntries)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeInOutInitialLoadingDialog"
            Me.Text = "Employee In-Out Initial Criteria"
            CType(Me.DateTimePickerForm_StartingDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_LimitEntries As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_StartingDate As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_StartingDate As WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace