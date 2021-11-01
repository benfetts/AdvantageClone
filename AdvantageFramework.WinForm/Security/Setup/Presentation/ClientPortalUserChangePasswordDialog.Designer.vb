Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientPortalUserChangePasswordDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientPortalUserChangePasswordDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Save = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ConfirmPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_ConfirmPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(338, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Save
            '
            Me.ButtonForm_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Save.Location = New System.Drawing.Point(257, 90)
            Me.ButtonForm_Save.Name = "ButtonForm_Save"
            Me.ButtonForm_Save.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Save.TabIndex = 6
            Me.ButtonForm_Save.Text = "Save"
            '
            'LabelForm_OldPassword
            '
            Me.LabelForm_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OldPassword.BackgroundStyle.Class = ""
            Me.LabelForm_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OldPassword.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_OldPassword.Name = "LabelForm_OldPassword"
            Me.LabelForm_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OldPassword.TabIndex = 0
            Me.LabelForm_OldPassword.Text = "Old Password:"
            '
            'TextBoxForm_ConfirmPassword
            '
            Me.TextBoxForm_ConfirmPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_ConfirmPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ConfirmPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_ConfirmPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ConfirmPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ConfirmPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ConfirmPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_ConfirmPassword.Location = New System.Drawing.Point(142, 64)
            Me.TextBoxForm_ConfirmPassword.Name = "TextBoxForm_ConfirmPassword"
            Me.TextBoxForm_ConfirmPassword.Size = New System.Drawing.Size(271, 20)
            Me.TextBoxForm_ConfirmPassword.TabIndex = 5
            Me.TextBoxForm_ConfirmPassword.TabOnEnter = True
            Me.TextBoxForm_ConfirmPassword.UseSystemPasswordChar = True
            '
            'LabelForm_Password
            '
            Me.LabelForm_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Password.BackgroundStyle.Class = ""
            Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Password.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 2
            Me.LabelForm_Password.Text = "New Password:"
            '
            'TextBoxForm_Password
            '
            Me.TextBoxForm_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Password.FocusHighlightEnabled = True
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(142, 38)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(271, 20)
            Me.TextBoxForm_Password.TabIndex = 3
            Me.TextBoxForm_Password.TabOnEnter = True
            Me.TextBoxForm_Password.UseSystemPasswordChar = True
            '
            'LabelForm_ConfirmPassword
            '
            Me.LabelForm_ConfirmPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ConfirmPassword.BackgroundStyle.Class = ""
            Me.LabelForm_ConfirmPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ConfirmPassword.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_ConfirmPassword.Name = "LabelForm_ConfirmPassword"
            Me.LabelForm_ConfirmPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_ConfirmPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ConfirmPassword.TabIndex = 4
            Me.LabelForm_ConfirmPassword.Text = "Confirm New Password:"
            '
            'TextBoxForm_OldPassword
            '
            Me.TextBoxForm_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_OldPassword.Location = New System.Drawing.Point(142, 12)
            Me.TextBoxForm_OldPassword.Name = "TextBoxForm_OldPassword"
            Me.TextBoxForm_OldPassword.ReadOnly = True
            Me.TextBoxForm_OldPassword.Size = New System.Drawing.Size(271, 20)
            Me.TextBoxForm_OldPassword.TabIndex = 1
            Me.TextBoxForm_OldPassword.TabOnEnter = True
            Me.TextBoxForm_OldPassword.UseSystemPasswordChar = True
            '
            'ClientPortalUserChangePasswordDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(425, 122)
            Me.ControlBox = False
            Me.Controls.Add(Me.LabelForm_OldPassword)
            Me.Controls.Add(Me.TextBoxForm_ConfirmPassword)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.LabelForm_ConfirmPassword)
            Me.Controls.Add(Me.TextBoxForm_OldPassword)
            Me.Controls.Add(Me.ButtonForm_Save)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ClientPortalUserChangePasswordDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Change Password"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Save As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_ConfirmPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_ConfirmPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace