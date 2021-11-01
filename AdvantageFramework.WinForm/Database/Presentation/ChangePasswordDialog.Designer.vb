Namespace Database.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ChangePasswordDialog
        Inherits DevComponents.DotNetBar.Office2007Form

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
            Me.LabelForm_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'LabelForm_OldPassword
            '
            Me.LabelForm_OldPassword.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OldPassword.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_OldPassword.Name = "LabelForm_OldPassword"
            Me.LabelForm_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OldPassword.TabIndex = 0
            Me.LabelForm_OldPassword.Text = "Old Password:"
            '
            'TextBoxForm_ConfirmNewPassword
            '
            Me.TextBoxForm_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxForm_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_ConfirmNewPassword.Location = New System.Drawing.Point(142, 64)
            Me.TextBoxForm_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ConfirmNewPassword.Name = "TextBoxForm_ConfirmNewPassword"
            Me.TextBoxForm_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxForm_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ConfirmNewPassword.Size = New System.Drawing.Size(231, 20)
            Me.TextBoxForm_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxForm_ConfirmNewPassword.TabIndex = 5
            Me.TextBoxForm_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxForm_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelForm_NewPassword
            '
            Me.LabelForm_NewPassword.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NewPassword.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_NewPassword.Name = "LabelForm_NewPassword"
            Me.LabelForm_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NewPassword.TabIndex = 2
            Me.LabelForm_NewPassword.Text = "New Password:"
            '
            'TextBoxForm_NewPassword
            '
            Me.TextBoxForm_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxForm_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_NewPassword.Location = New System.Drawing.Point(142, 38)
            Me.TextBoxForm_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_NewPassword.Name = "TextBoxForm_NewPassword"
            Me.TextBoxForm_NewPassword.SecurityEnabled = True
            Me.TextBoxForm_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_NewPassword.Size = New System.Drawing.Size(231, 20)
            Me.TextBoxForm_NewPassword.StartingFolderName = Nothing
            Me.TextBoxForm_NewPassword.TabIndex = 3
            Me.TextBoxForm_NewPassword.TabOnEnter = True
            Me.TextBoxForm_NewPassword.UseSystemPasswordChar = True
            '
            'LabelForm_ConfirmNewPassword
            '
            Me.LabelForm_ConfirmNewPassword.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ConfirmNewPassword.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_ConfirmNewPassword.Name = "LabelForm_ConfirmNewPassword"
            Me.LabelForm_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelForm_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ConfirmNewPassword.TabIndex = 4
            Me.LabelForm_ConfirmNewPassword.Text = "Confirm New Password:"
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
            Me.TextBoxForm_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxForm_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_OldPassword.Location = New System.Drawing.Point(142, 12)
            Me.TextBoxForm_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_OldPassword.Name = "TextBoxForm_OldPassword"
            Me.TextBoxForm_OldPassword.SecurityEnabled = True
            Me.TextBoxForm_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_OldPassword.Size = New System.Drawing.Size(231, 20)
            Me.TextBoxForm_OldPassword.StartingFolderName = Nothing
            Me.TextBoxForm_OldPassword.TabIndex = 1
            Me.TextBoxForm_OldPassword.TabOnEnter = True
            Me.TextBoxForm_OldPassword.UseSystemPasswordChar = True
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(298, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(217, 90)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'ChangePasswordDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(381, 118)
            Me.ControlBox = False
            Me.Controls.Add(Me.LabelForm_OldPassword)
            Me.Controls.Add(Me.TextBoxForm_ConfirmNewPassword)
            Me.Controls.Add(Me.LabelForm_NewPassword)
            Me.Controls.Add(Me.TextBoxForm_NewPassword)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_ConfirmNewPassword)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.TextBoxForm_OldPassword)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangePasswordDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Change Password"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace