Namespace Database.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SQLUserEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SQLUserEditDialog))
            Me.LabelForm_LoginName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_LoginName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Confirm = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Confirm = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_IsSecurityAdmin = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_EnforcePasswordPolicy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonForm_Windows = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_SQLUser = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'LabelForm_LoginName
            '
            Me.LabelForm_LoginName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LoginName.BackgroundStyle.Class = ""
            Me.LabelForm_LoginName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LoginName.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_LoginName.Name = "LabelForm_LoginName"
            Me.LabelForm_LoginName.Size = New System.Drawing.Size(65, 20)
            Me.LabelForm_LoginName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LoginName.TabIndex = 0
            Me.LabelForm_LoginName.Text = "Login Name:"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(318, 142)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 10
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(318, 142)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 11
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(399, 142)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TextBoxForm_LoginName
            '
            '
            '
            '
            Me.TextBoxForm_LoginName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_LoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_LoginName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_LoginName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_LoginName.FocusHighlightEnabled = True
            Me.TextBoxForm_LoginName.Location = New System.Drawing.Point(83, 12)
            Me.TextBoxForm_LoginName.Name = "TextBoxForm_LoginName"
            Me.TextBoxForm_LoginName.Size = New System.Drawing.Size(391, 20)
            Me.TextBoxForm_LoginName.TabIndex = 1
            Me.TextBoxForm_LoginName.TabOnEnter = True
            '
            'TextBoxForm_Password
            '
            '
            '
            '
            Me.TextBoxForm_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Password.Enabled = False
            Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Password.FocusHighlightEnabled = True
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(222, 64)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(252, 20)
            Me.TextBoxForm_Password.TabIndex = 5
            Me.TextBoxForm_Password.TabOnEnter = True
            Me.TextBoxForm_Password.UseSystemPasswordChar = True
            '
            'TextBoxForm_Confirm
            '
            '
            '
            '
            Me.TextBoxForm_Confirm.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Confirm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Confirm.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Confirm.Enabled = False
            Me.TextBoxForm_Confirm.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Confirm.FocusHighlightEnabled = True
            Me.TextBoxForm_Confirm.Location = New System.Drawing.Point(222, 90)
            Me.TextBoxForm_Confirm.Name = "TextBoxForm_Confirm"
            Me.TextBoxForm_Confirm.Size = New System.Drawing.Size(252, 20)
            Me.TextBoxForm_Confirm.TabIndex = 7
            Me.TextBoxForm_Confirm.TabOnEnter = True
            Me.TextBoxForm_Confirm.UseSystemPasswordChar = True
            '
            'LabelForm_Password
            '
            Me.LabelForm_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Password.BackgroundStyle.Class = ""
            Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Password.Location = New System.Drawing.Point(164, 64)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(52, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 4
            Me.LabelForm_Password.Text = "Password:"
            '
            'LabelForm_Confirm
            '
            Me.LabelForm_Confirm.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Confirm.BackgroundStyle.Class = ""
            Me.LabelForm_Confirm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Confirm.Location = New System.Drawing.Point(164, 90)
            Me.LabelForm_Confirm.Name = "LabelForm_Confirm"
            Me.LabelForm_Confirm.Size = New System.Drawing.Size(52, 20)
            Me.LabelForm_Confirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Confirm.TabIndex = 6
            Me.LabelForm_Confirm.Text = "Confirm:"
            '
            'CheckBoxForm_IsSecurityAdmin
            '
            '
            '
            '
            Me.CheckBoxForm_IsSecurityAdmin.BackgroundStyle.Class = ""
            Me.CheckBoxForm_IsSecurityAdmin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsSecurityAdmin.Location = New System.Drawing.Point(77, 116)
            Me.CheckBoxForm_IsSecurityAdmin.Name = "CheckBoxForm_IsSecurityAdmin"
            Me.CheckBoxForm_IsSecurityAdmin.Size = New System.Drawing.Size(139, 20)
            Me.CheckBoxForm_IsSecurityAdmin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsSecurityAdmin.TabIndex = 8
            Me.CheckBoxForm_IsSecurityAdmin.Text = "Is Security Admin"
            '
            'CheckBoxForm_EnforcePasswordPolicy
            '
            '
            '
            '
            Me.CheckBoxForm_EnforcePasswordPolicy.BackgroundStyle.Class = ""
            Me.CheckBoxForm_EnforcePasswordPolicy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_EnforcePasswordPolicy.Checked = True
            Me.CheckBoxForm_EnforcePasswordPolicy.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxForm_EnforcePasswordPolicy.CheckValue = "Y"
            Me.CheckBoxForm_EnforcePasswordPolicy.Enabled = False
            Me.CheckBoxForm_EnforcePasswordPolicy.Location = New System.Drawing.Point(222, 116)
            Me.CheckBoxForm_EnforcePasswordPolicy.Name = "CheckBoxForm_EnforcePasswordPolicy"
            Me.CheckBoxForm_EnforcePasswordPolicy.Size = New System.Drawing.Size(252, 20)
            Me.CheckBoxForm_EnforcePasswordPolicy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_EnforcePasswordPolicy.TabIndex = 9
            Me.CheckBoxForm_EnforcePasswordPolicy.Text = "Enforce Password Policy"
            '
            'RadioButtonForm_Windows
            '
            Me.RadioButtonForm_Windows.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Windows.BackgroundStyle.Class = ""
            Me.RadioButtonForm_Windows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Windows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Windows.Checked = True
            Me.RadioButtonForm_Windows.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Windows.CheckValue = "Y"
            Me.RadioButtonForm_Windows.Location = New System.Drawing.Point(83, 38)
            Me.RadioButtonForm_Windows.Name = "RadioButtonForm_Windows"
            Me.RadioButtonForm_Windows.Size = New System.Drawing.Size(75, 20)
            Me.RadioButtonForm_Windows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Windows.TabIndex = 2
            Me.RadioButtonForm_Windows.Text = "Windows"
            '
            'RadioButtonForm_SQLUser
            '
            Me.RadioButtonForm_SQLUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_SQLUser.BackgroundStyle.Class = ""
            Me.RadioButtonForm_SQLUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_SQLUser.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_SQLUser.Location = New System.Drawing.Point(83, 64)
            Me.RadioButtonForm_SQLUser.Name = "RadioButtonForm_SQLUser"
            Me.RadioButtonForm_SQLUser.Size = New System.Drawing.Size(75, 20)
            Me.RadioButtonForm_SQLUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_SQLUser.TabIndex = 3
            Me.RadioButtonForm_SQLUser.Text = "SQL User"
            '
            'SQLUserEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(486, 174)
            Me.Controls.Add(Me.RadioButtonForm_Windows)
            Me.Controls.Add(Me.RadioButtonForm_SQLUser)
            Me.Controls.Add(Me.CheckBoxForm_EnforcePasswordPolicy)
            Me.Controls.Add(Me.CheckBoxForm_IsSecurityAdmin)
            Me.Controls.Add(Me.LabelForm_Confirm)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.TextBoxForm_Confirm)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.LabelForm_LoginName)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.TextBoxForm_LoginName)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SQLUserEditDialog"
            Me.Text = "SQL User"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_LoginName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_LoginName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Confirm As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Confirm As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_IsSecurityAdmin As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_EnforcePasswordPolicy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonForm_Windows As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_SQLUser As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace