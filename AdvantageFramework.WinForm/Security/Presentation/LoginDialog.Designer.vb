Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LoginDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginDialog))
            Me.LabelForm_ResetPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ChangePassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_UseWindowsAuthentication = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Server = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Server = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AccessCodeMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AuthenticationCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_AuthenticationCode = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_ResendAuthenticationCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'LabelForm_ResetPassword
            '
            Me.LabelForm_ResetPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ResetPassword.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_ResetPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ResetPassword.ForeColor = System.Drawing.Color.White
            Me.LabelForm_ResetPassword.Location = New System.Drawing.Point(320, 230)
            Me.LabelForm_ResetPassword.Name = "LabelForm_ResetPassword"
            Me.LabelForm_ResetPassword.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_ResetPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ResetPassword.TabIndex = 12
            Me.LabelForm_ResetPassword.Text = "<a href="""" name="""">Forgot Password</a>"
            '
            'LabelForm_ChangePassword
            '
            Me.LabelForm_ChangePassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ChangePassword.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_ChangePassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ChangePassword.ForeColor = System.Drawing.Color.White
            Me.LabelForm_ChangePassword.Location = New System.Drawing.Point(213, 230)
            Me.LabelForm_ChangePassword.Name = "LabelForm_ChangePassword"
            Me.LabelForm_ChangePassword.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_ChangePassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ChangePassword.TabIndex = 11
            Me.LabelForm_ChangePassword.Text = "<a href="""" name="""">Change Password</a>"
            '
            'CheckBoxForm_UseWindowsAuthentication
            '
            Me.CheckBoxForm_UseWindowsAuthentication.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UseWindowsAuthentication.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_UseWindowsAuthentication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseWindowsAuthentication.CheckValue = 0
            Me.CheckBoxForm_UseWindowsAuthentication.CheckValueChecked = 1
            Me.CheckBoxForm_UseWindowsAuthentication.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UseWindowsAuthentication.CheckValueUnchecked = 0
            Me.CheckBoxForm_UseWindowsAuthentication.ChildControls = CType(resources.GetObject("CheckBoxForm_UseWindowsAuthentication.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseWindowsAuthentication.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UseWindowsAuthentication.Location = New System.Drawing.Point(12, 258)
            Me.CheckBoxForm_UseWindowsAuthentication.Name = "CheckBoxForm_UseWindowsAuthentication"
            Me.CheckBoxForm_UseWindowsAuthentication.OldestSibling = Nothing
            Me.CheckBoxForm_UseWindowsAuthentication.SecurityEnabled = True
            Me.CheckBoxForm_UseWindowsAuthentication.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseWindowsAuthentication.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseWindowsAuthentication.Size = New System.Drawing.Size(164, 20)
            Me.CheckBoxForm_UseWindowsAuthentication.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseWindowsAuthentication.TabIndex = 8
            Me.CheckBoxForm_UseWindowsAuthentication.TabOnEnter = True
            Me.CheckBoxForm_UseWindowsAuthentication.TabStop = False
            Me.CheckBoxForm_UseWindowsAuthentication.Text = "Use Windows Authentication"
            Me.CheckBoxForm_UseWindowsAuthentication.TextColor = System.Drawing.Color.Black
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(346, 258)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(265, 258)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'TextBoxForm_Password
            '
            Me.TextBoxForm_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Password.CheckSpellingOnValidate = False
            Me.TextBoxForm_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Password.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Password.FocusHighlightEnabled = True
            Me.TextBoxForm_Password.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(78, 204)
            Me.TextBoxForm_Password.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Password.MinimumSize = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.SecurityEnabled = True
            Me.TextBoxForm_Password.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Password.StartingFolderName = Nothing
            Me.TextBoxForm_Password.TabIndex = 7
            Me.TextBoxForm_Password.TabOnEnter = True
            Me.TextBoxForm_Password.UseSystemPasswordChar = True
            '
            'TextBoxForm_UserName
            '
            Me.TextBoxForm_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UserName.CheckSpellingOnValidate = False
            Me.TextBoxForm_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UserName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserName.FocusHighlightEnabled = True
            Me.TextBoxForm_UserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_UserName.Location = New System.Drawing.Point(78, 178)
            Me.TextBoxForm_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_UserName.MinimumSize = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
            Me.TextBoxForm_UserName.SecurityEnabled = True
            Me.TextBoxForm_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_UserName.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_UserName.StartingFolderName = Nothing
            Me.TextBoxForm_UserName.TabIndex = 5
            Me.TextBoxForm_UserName.TabOnEnter = True
            '
            'TextBoxForm_Database
            '
            Me.TextBoxForm_Database.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Database.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Database.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Database.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Database.CheckSpellingOnValidate = False
            Me.TextBoxForm_Database.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Database.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Database.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Database.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Database.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Database.FocusHighlightEnabled = True
            Me.TextBoxForm_Database.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Database.Location = New System.Drawing.Point(78, 152)
            Me.TextBoxForm_Database.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Database.MinimumSize = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Database.Name = "TextBoxForm_Database"
            Me.TextBoxForm_Database.SecurityEnabled = True
            Me.TextBoxForm_Database.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Database.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Database.StartingFolderName = Nothing
            Me.TextBoxForm_Database.TabIndex = 3
            Me.TextBoxForm_Database.TabOnEnter = True
            '
            'TextBoxForm_Server
            '
            Me.TextBoxForm_Server.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Server.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Server.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Server.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Server.CheckSpellingOnValidate = False
            Me.TextBoxForm_Server.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Server.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Server.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Server.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Server.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Server.FocusHighlightEnabled = True
            Me.TextBoxForm_Server.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Server.Location = New System.Drawing.Point(78, 126)
            Me.TextBoxForm_Server.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Server.MinimumSize = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Server.Name = "TextBoxForm_Server"
            Me.TextBoxForm_Server.SecurityEnabled = True
            Me.TextBoxForm_Server.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Server.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Server.StartingFolderName = Nothing
            Me.TextBoxForm_Server.TabIndex = 1
            Me.TextBoxForm_Server.TabOnEnter = True
            '
            'LabelForm_Password
            '
            Me.LabelForm_Password.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Password.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_Password.Location = New System.Drawing.Point(12, 204)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 6
            Me.LabelForm_Password.Text = "Password:"
            '
            'LabelForm_UserName
            '
            Me.LabelForm_UserName.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserName.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 178)
            Me.LabelForm_UserName.Name = "LabelForm_UserName"
            Me.LabelForm_UserName.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserName.TabIndex = 4
            Me.LabelForm_UserName.Text = "User ID:"
            '
            'LabelForm_Database
            '
            Me.LabelForm_Database.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Database.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Database.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_Database.Location = New System.Drawing.Point(12, 152)
            Me.LabelForm_Database.Name = "LabelForm_Database"
            Me.LabelForm_Database.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_Database.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Database.TabIndex = 2
            Me.LabelForm_Database.Text = "Database:"
            '
            'LabelForm_Server
            '
            Me.LabelForm_Server.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Server.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Server.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_Server.Location = New System.Drawing.Point(12, 126)
            Me.LabelForm_Server.Name = "LabelForm_Server"
            Me.LabelForm_Server.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_Server.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Server.TabIndex = 0
            Me.LabelForm_Server.Text = "Server:"
            '
            'LabelForm_AccessCodeMessage
            '
            Me.LabelForm_AccessCodeMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AccessCodeMessage.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_AccessCodeMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AccessCodeMessage.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_AccessCodeMessage.Location = New System.Drawing.Point(12, 167)
            Me.LabelForm_AccessCodeMessage.Name = "LabelForm_AccessCodeMessage"
            Me.LabelForm_AccessCodeMessage.Size = New System.Drawing.Size(409, 32)
            Me.LabelForm_AccessCodeMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AccessCodeMessage.TabIndex = 15
            Me.LabelForm_AccessCodeMessage.Text = "An authentication code was sent to {0}. <br></br>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please enter it below."
            Me.LabelForm_AccessCodeMessage.Visible = False
            Me.LabelForm_AccessCodeMessage.WordWrap = True
            '
            'LabelForm_AuthenticationCode
            '
            Me.LabelForm_AuthenticationCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AuthenticationCode.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_AuthenticationCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AuthenticationCode.ForeColor = System.Drawing.Color.Black
            Me.LabelForm_AuthenticationCode.Location = New System.Drawing.Point(12, 205)
            Me.LabelForm_AuthenticationCode.Name = "LabelForm_AuthenticationCode"
            Me.LabelForm_AuthenticationCode.Size = New System.Drawing.Size(107, 20)
            Me.LabelForm_AuthenticationCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AuthenticationCode.TabIndex = 13
            Me.LabelForm_AuthenticationCode.Text = "Authentication Code:"
            Me.LabelForm_AuthenticationCode.Visible = False
            '
            'TextBoxForm_AuthenticationCode
            '
            Me.TextBoxForm_AuthenticationCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_AuthenticationCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_AuthenticationCode.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_AuthenticationCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_AuthenticationCode.CheckSpellingOnValidate = False
            Me.TextBoxForm_AuthenticationCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_AuthenticationCode.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_AuthenticationCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_AuthenticationCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_AuthenticationCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_AuthenticationCode.FocusHighlightEnabled = True
            Me.TextBoxForm_AuthenticationCode.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_AuthenticationCode.Location = New System.Drawing.Point(125, 205)
            Me.TextBoxForm_AuthenticationCode.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_AuthenticationCode.Name = "TextBoxForm_AuthenticationCode"
            Me.TextBoxForm_AuthenticationCode.SecurityEnabled = True
            Me.TextBoxForm_AuthenticationCode.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_AuthenticationCode.Size = New System.Drawing.Size(296, 20)
            Me.TextBoxForm_AuthenticationCode.StartingFolderName = Nothing
            Me.TextBoxForm_AuthenticationCode.TabIndex = 14
            Me.TextBoxForm_AuthenticationCode.TabOnEnter = True
            Me.TextBoxForm_AuthenticationCode.UseSystemPasswordChar = True
            Me.TextBoxForm_AuthenticationCode.Visible = False
            '
            'LabelForm_ResendAuthenticationCode
            '
            Me.LabelForm_ResendAuthenticationCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ResendAuthenticationCode.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_ResendAuthenticationCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ResendAuthenticationCode.ForeColor = System.Drawing.Color.White
            Me.LabelForm_ResendAuthenticationCode.Location = New System.Drawing.Point(157, 230)
            Me.LabelForm_ResendAuthenticationCode.Name = "LabelForm_ResendAuthenticationCode"
            Me.LabelForm_ResendAuthenticationCode.Size = New System.Drawing.Size(50, 20)
            Me.LabelForm_ResendAuthenticationCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ResendAuthenticationCode.TabIndex = 16
            Me.LabelForm_ResendAuthenticationCode.Text = "<a href="""" name="""">Resend</a>"
            Me.LabelForm_ResendAuthenticationCode.Visible = False
            '
            'LoginDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
            Me.BackgroundImage = Global.AdvantageFramework.My.Resources.Resources.AquaNewLoginImage
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BottomLeftCornerSize = 0
            Me.BottomRightCornerSize = 0
            Me.ClientSize = New System.Drawing.Size(433, 290)
            Me.ControlBox = False
            Me.Controls.Add(Me.LabelForm_ResendAuthenticationCode)
            Me.Controls.Add(Me.LabelForm_ResetPassword)
            Me.Controls.Add(Me.LabelForm_ChangePassword)
            Me.Controls.Add(Me.CheckBoxForm_UseWindowsAuthentication)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.TextBoxForm_UserName)
            Me.Controls.Add(Me.TextBoxForm_Database)
            Me.Controls.Add(Me.TextBoxForm_Server)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.LabelForm_UserName)
            Me.Controls.Add(Me.LabelForm_Database)
            Me.Controls.Add(Me.LabelForm_Server)
            Me.Controls.Add(Me.LabelForm_AccessCodeMessage)
            Me.Controls.Add(Me.LabelForm_AuthenticationCode)
            Me.Controls.Add(Me.TextBoxForm_AuthenticationCode)
            Me.DoubleBuffered = True
            Me.EnableGlass = False
            Me.FlattenMDIBorder = False
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LoginDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.TopLeftCornerSize = 0
            Me.TopRightCornerSize = 0
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Server As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Database As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Server As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Database As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_UseWindowsAuthentication As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_ChangePassword As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ResetPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_AuthenticationCode As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_AuthenticationCode As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AccessCodeMessage As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ResendAuthenticationCode As WinForm.Presentation.Controls.Label
    End Class

End Namespace
