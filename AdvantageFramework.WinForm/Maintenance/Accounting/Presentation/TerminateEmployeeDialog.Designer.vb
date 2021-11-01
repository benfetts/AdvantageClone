Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TerminateEmployeeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TerminateEmployeeDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TerminationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_RemoveSecuritySettings = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_EmployeeName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_TerminationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_UnTerminate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_TerminationDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(193, 93)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(274, 93)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.Class = ""
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(97, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 0
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'LabelForm_TerminationDate
            '
            Me.LabelForm_TerminationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TerminationDate.BackgroundStyle.Class = ""
            Me.LabelForm_TerminationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TerminationDate.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_TerminationDate.Name = "LabelForm_TerminationDate"
            Me.LabelForm_TerminationDate.Size = New System.Drawing.Size(97, 20)
            Me.LabelForm_TerminationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TerminationDate.TabIndex = 2
            Me.LabelForm_TerminationDate.Text = "Termination Date:"
            '
            'CheckBoxForm_RemoveSecuritySettings
            '
            '
            '
            '
            Me.CheckBoxForm_RemoveSecuritySettings.BackgroundStyle.Class = ""
            Me.CheckBoxForm_RemoveSecuritySettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_RemoveSecuritySettings.CheckValue = 0
            Me.CheckBoxForm_RemoveSecuritySettings.CheckValueChecked = 1
            Me.CheckBoxForm_RemoveSecuritySettings.CheckValueUnchecked = 0
            Me.CheckBoxForm_RemoveSecuritySettings.ChildControls = CType(resources.GetObject("CheckBoxForm_RemoveSecuritySettings.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_RemoveSecuritySettings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_RemoveSecuritySettings.Location = New System.Drawing.Point(115, 67)
            Me.CheckBoxForm_RemoveSecuritySettings.Name = "CheckBoxForm_RemoveSecuritySettings"
            Me.CheckBoxForm_RemoveSecuritySettings.OldestSibling = Nothing
            Me.CheckBoxForm_RemoveSecuritySettings.SecurityEnabled = True
            Me.CheckBoxForm_RemoveSecuritySettings.SiblingControls = CType(resources.GetObject("CheckBoxForm_RemoveSecuritySettings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_RemoveSecuritySettings.Size = New System.Drawing.Size(234, 20)
            Me.CheckBoxForm_RemoveSecuritySettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_RemoveSecuritySettings.TabIndex = 5
            Me.CheckBoxForm_RemoveSecuritySettings.Text = "Remove security settings and passwords"
            '
            'LabelForm_EmployeeName
            '
            Me.LabelForm_EmployeeName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmployeeName.BackgroundStyle.Class = ""
            Me.LabelForm_EmployeeName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmployeeName.Location = New System.Drawing.Point(115, 12)
            Me.LabelForm_EmployeeName.Name = "LabelForm_EmployeeName"
            Me.LabelForm_EmployeeName.Size = New System.Drawing.Size(234, 20)
            Me.LabelForm_EmployeeName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmployeeName.TabIndex = 1
            Me.LabelForm_EmployeeName.Text = "{EmployeeName}"
            '
            'DateTimePickerForm_TerminationDate
            '
            Me.DateTimePickerForm_TerminationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_TerminationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_TerminationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TerminationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_TerminationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_TerminationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_TerminationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_TerminationDate.CustomFormat = ""
            Me.DateTimePickerForm_TerminationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_TerminationDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_TerminationDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_TerminationDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_TerminationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_TerminationDate.Location = New System.Drawing.Point(115, 41)
            Me.DateTimePickerForm_TerminationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.BackgroundStyle.Class = ""
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.Class = ""
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.DisplayMonth = New Date(2012, 6, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.NavigationBackgroundStyle.Class = ""
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_TerminationDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_TerminationDate.Name = "DateTimePickerForm_TerminationDate"
            Me.DateTimePickerForm_TerminationDate.Size = New System.Drawing.Size(126, 20)
            Me.DateTimePickerForm_TerminationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_TerminationDate.TabIndex = 3
            '
            'LabelForm_UnTerminate
            '
            Me.LabelForm_UnTerminate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UnTerminate.BackgroundStyle.Class = ""
            Me.LabelForm_UnTerminate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UnTerminate.Location = New System.Drawing.Point(12, 67)
            Me.LabelForm_UnTerminate.Name = "LabelForm_UnTerminate"
            Me.LabelForm_UnTerminate.Size = New System.Drawing.Size(337, 20)
            Me.LabelForm_UnTerminate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UnTerminate.TabIndex = 4
            Me.LabelForm_UnTerminate.Text = "This Employee is terminated. Clicking 'Ok' will un-terminate."
            Me.LabelForm_UnTerminate.Visible = False
            '
            'TerminateEmployeeDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(361, 125)
            Me.Controls.Add(Me.DateTimePickerForm_TerminationDate)
            Me.Controls.Add(Me.LabelForm_EmployeeName)
            Me.Controls.Add(Me.LabelForm_TerminationDate)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.CheckBoxForm_RemoveSecuritySettings)
            Me.Controls.Add(Me.LabelForm_UnTerminate)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TerminateEmployeeDialog"
            Me.Text = "Terminate Employee"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_TerminationDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TerminationDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_RemoveSecuritySettings As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_EmployeeName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_TerminationDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_UnTerminate As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace