<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageOutlookAddinSettingsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageOutlookAddinSettingsDialog))
        Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_LogIn = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TextBoxForm_User = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelForm_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_LoggedInAs = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.ButtonForm_LogOut = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonForm_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
        Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me._DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.SuspendLayout()
        '
        'ButtonForm_OK
        '
        Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_OK.Location = New System.Drawing.Point(340, 142)
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
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(421, 142)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
        Me.ButtonForm_Cancel.SecurityEnabled = True
        Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_Cancel.TabIndex = 10
        Me.ButtonForm_Cancel.Text = "Cancel"
        '
        'ButtonForm_LogIn
        '
        Me.ButtonForm_LogIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_LogIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_LogIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_LogIn.Location = New System.Drawing.Point(421, 38)
        Me.ButtonForm_LogIn.Name = "ButtonForm_LogIn"
        Me.ButtonForm_LogIn.SecurityEnabled = True
        Me.ButtonForm_LogIn.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_LogIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_LogIn.TabIndex = 2
        Me.ButtonForm_LogIn.TabStop = False
        Me.ButtonForm_LogIn.Text = "Log In"
        '
        'TextBoxForm_User
        '
        Me.TextBoxForm_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_User.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxForm_User.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_User.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_User.CheckSpellingOnValidate = False
        Me.TextBoxForm_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_User.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_User.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_User.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxForm_User.FocusHighlightEnabled = True
        Me.TextBoxForm_User.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_User.Location = New System.Drawing.Point(73, 64)
        Me.TextBoxForm_User.MaxFileSize = CType(0, Long)
        Me.TextBoxForm_User.Name = "TextBoxForm_User"
        Me.TextBoxForm_User.ReadOnly = True
        Me.TextBoxForm_User.ShowSpellCheckCompleteMessage = True
        Me.TextBoxForm_User.Size = New System.Drawing.Size(423, 20)
        Me.TextBoxForm_User.TabIndex = 4
        Me.TextBoxForm_User.TabOnEnter = True
        '
        'LabelForm_User
        '
        Me.LabelForm_User.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelForm_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_User.Location = New System.Drawing.Point(12, 64)
        Me.LabelForm_User.Name = "LabelForm_User"
        Me.LabelForm_User.Size = New System.Drawing.Size(55, 20)
        Me.LabelForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_User.TabIndex = 3
        Me.LabelForm_User.Text = "User:"
        Me.LabelForm_User.WordWrap = True
        '
        'LabelForm_LoggedInAs
        '
        Me.LabelForm_LoggedInAs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelForm_LoggedInAs.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderBottomWidth = 1
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelForm_LoggedInAs.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LabelForm_LoggedInAs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_LoggedInAs.Location = New System.Drawing.Point(73, 38)
        Me.LabelForm_LoggedInAs.Name = "LabelForm_LoggedInAs"
        Me.LabelForm_LoggedInAs.Size = New System.Drawing.Size(342, 20)
        Me.LabelForm_LoggedInAs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_LoggedInAs.TabIndex = 0
        Me.LabelForm_LoggedInAs.Text = "Logged In As"
        '
        'LabelForm_Employee
        '
        Me.LabelForm_Employee.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 90)
        Me.LabelForm_Employee.Name = "LabelForm_Employee"
        Me.LabelForm_Employee.Size = New System.Drawing.Size(55, 20)
        Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Employee.TabIndex = 5
        Me.LabelForm_Employee.Text = "Employee:"
        Me.LabelForm_Employee.WordWrap = True
        '
        'TextBoxForm_Employee
        '
        Me.TextBoxForm_Employee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Employee.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxForm_Employee.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Employee.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Employee.CheckSpellingOnValidate = False
        Me.TextBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxForm_Employee.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxForm_Employee.FocusHighlightEnabled = True
        Me.TextBoxForm_Employee.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Employee.Location = New System.Drawing.Point(73, 90)
        Me.TextBoxForm_Employee.MaxFileSize = CType(0, Long)
        Me.TextBoxForm_Employee.Name = "TextBoxForm_Employee"
        Me.TextBoxForm_Employee.ReadOnly = True
        Me.TextBoxForm_Employee.ShowSpellCheckCompleteMessage = True
        Me.TextBoxForm_Employee.Size = New System.Drawing.Size(423, 20)
        Me.TextBoxForm_Employee.TabIndex = 6
        Me.TextBoxForm_Employee.TabOnEnter = True
        '
        'ButtonForm_LogOut
        '
        Me.ButtonForm_LogOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_LogOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_LogOut.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_LogOut.Location = New System.Drawing.Point(421, 38)
        Me.ButtonForm_LogOut.Name = "ButtonForm_LogOut"
        Me.ButtonForm_LogOut.SecurityEnabled = True
        Me.ButtonForm_LogOut.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_LogOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_LogOut.TabIndex = 1
        Me.ButtonForm_LogOut.TabStop = False
        Me.ButtonForm_LogOut.Text = "Log Out"
        '
        'RadioButtonForm_SyncAdvantageAppointmentsOnly
        '
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Location = New System.Drawing.Point(12, 116)
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Name = "RadioButtonForm_SyncAdvantageAppointmentsOnly"
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.SecurityEnabled = True
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Size = New System.Drawing.Size(484, 20)
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.TabIndex = 11
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.TabStop = False
        Me.RadioButtonForm_SyncAdvantageAppointmentsOnly.Text = "Sync Advantage Appointments Only"
        '
        'RadioButtonForm_None
        '
        Me.RadioButtonForm_None.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonForm_None.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonForm_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_None.Location = New System.Drawing.Point(12, 142)
        Me.RadioButtonForm_None.Name = "RadioButtonForm_None"
        Me.RadioButtonForm_None.SecurityEnabled = True
        Me.RadioButtonForm_None.Size = New System.Drawing.Size(322, 20)
        Me.RadioButtonForm_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_None.TabIndex = 12
        Me.RadioButtonForm_None.TabStop = False
        Me.RadioButtonForm_None.Text = "None"
        '
        'RadioButtonForm_SyncOutlookAndAdvantageAppointments
        '
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked = True
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.CheckValue = "Y"
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Location = New System.Drawing.Point(12, 12)
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Name = "RadioButtonForm_SyncOutlookAndAdvantageAppointments"
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.SecurityEnabled = True
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Size = New System.Drawing.Size(239, 20)
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.TabIndex = 13
        Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments.Text = "Sync Outlook And Advantage Appointments"
        '
        'StyleManager
        '
        Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        '_DefaultLookAndFeel
        '
        Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2013"
        '
        'AdvantageOutlookAddinSettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 174)
        Me.Controls.Add(Me.RadioButtonForm_SyncOutlookAndAdvantageAppointments)
        Me.Controls.Add(Me.RadioButtonForm_None)
        Me.Controls.Add(Me.ButtonForm_Cancel)
        Me.Controls.Add(Me.LabelForm_LoggedInAs)
        Me.Controls.Add(Me.TextBoxForm_Employee)
        Me.Controls.Add(Me.RadioButtonForm_SyncAdvantageAppointmentsOnly)
        Me.Controls.Add(Me.ButtonForm_LogOut)
        Me.Controls.Add(Me.ButtonForm_OK)
        Me.Controls.Add(Me.LabelForm_Employee)
        Me.Controls.Add(Me.TextBoxForm_User)
        Me.Controls.Add(Me.ButtonForm_LogIn)
        Me.Controls.Add(Me.LabelForm_User)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdvantageOutlookAddinSettingsDialog"
        Me.Text = "Advantage Outlook Add-in Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonForm_LogIn As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TextBoxForm_User As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelForm_User As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelForm_LoggedInAs As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents ButtonForm_LogOut As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents RadioButtonForm_SyncAdvantageAppointmentsOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    Friend WithEvents RadioButtonForm_None As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    Friend WithEvents RadioButtonForm_SyncOutlookAndAdvantageAppointments As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    Protected Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    Private WithEvents _DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
