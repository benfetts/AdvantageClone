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
        Me.SuspendLayout()
        '
        'CheckBoxForm_UseWindowsAuthentication
        '
        Me.CheckBoxForm_UseWindowsAuthentication.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxForm_UseWindowsAuthentication.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckBoxForm_UseWindowsAuthentication.BackgroundStyle.Class = ""
        Me.CheckBoxForm_UseWindowsAuthentication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxForm_UseWindowsAuthentication.Location = New System.Drawing.Point(12, 258)
        Me.CheckBoxForm_UseWindowsAuthentication.Name = "CheckBoxForm_UseWindowsAuthentication"
        Me.CheckBoxForm_UseWindowsAuthentication.Size = New System.Drawing.Size(164, 20)
        Me.CheckBoxForm_UseWindowsAuthentication.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxForm_UseWindowsAuthentication.TabIndex = 8
        Me.CheckBoxForm_UseWindowsAuthentication.TabStop = False
        Me.CheckBoxForm_UseWindowsAuthentication.Text = "Use Windows Authentication"
        '
        'ButtonForm_Cancel
        '
        Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(346, 258)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
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
        Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonForm_OK.TabIndex = 9
        Me.ButtonForm_OK.Text = "OK"
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
        Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Password.FocusHighlightEnabled = True
        Me.TextBoxForm_Password.Location = New System.Drawing.Point(78, 204)
        Me.TextBoxForm_Password.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
        Me.TextBoxForm_Password.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Password.TabIndex = 7
        Me.TextBoxForm_Password.TabOnEnter = True
        Me.TextBoxForm_Password.UseSystemPasswordChar = True
        '
        'TextBoxForm_UserName
        '
        Me.TextBoxForm_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxForm_UserName.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_UserName.FocusHighlightEnabled = True
        Me.TextBoxForm_UserName.Location = New System.Drawing.Point(78, 178)
        Me.TextBoxForm_UserName.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
        Me.TextBoxForm_UserName.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_UserName.TabIndex = 5
        Me.TextBoxForm_UserName.TabOnEnter = True
        '
        'TextBoxForm_Database
        '
        Me.TextBoxForm_Database.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxForm_Database.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Database.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Database.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Database.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Database.FocusHighlightEnabled = True
        Me.TextBoxForm_Database.Location = New System.Drawing.Point(78, 152)
        Me.TextBoxForm_Database.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Database.Name = "TextBoxForm_Database"
        Me.TextBoxForm_Database.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Database.TabIndex = 3
        Me.TextBoxForm_Database.TabOnEnter = True
        '
        'TextBoxForm_Server
        '
        Me.TextBoxForm_Server.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TextBoxForm_Server.Border.Class = "TextBoxBorder"
        Me.TextBoxForm_Server.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxForm_Server.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxForm_Server.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxForm_Server.FocusHighlightEnabled = True
        Me.TextBoxForm_Server.Location = New System.Drawing.Point(78, 126)
        Me.TextBoxForm_Server.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Server.Name = "TextBoxForm_Server"
        Me.TextBoxForm_Server.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Server.TabIndex = 1
        Me.TextBoxForm_Server.TabOnEnter = True
        '
        'LabelForm_Password
        '
        Me.LabelForm_Password.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelForm_Password.BackgroundStyle.Class = ""
        Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        Me.LabelForm_UserName.BackgroundStyle.Class = ""
        Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 178)
        Me.LabelForm_UserName.Name = "LabelForm_UserName"
        Me.LabelForm_UserName.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_UserName.TabIndex = 4
        Me.LabelForm_UserName.Text = "User Name:"
        '
        'LabelForm_Database
        '
        Me.LabelForm_Database.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelForm_Database.BackgroundStyle.Class = ""
        Me.LabelForm_Database.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        Me.LabelForm_Server.BackgroundStyle.Class = ""
        Me.LabelForm_Server.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelForm_Server.Location = New System.Drawing.Point(12, 126)
        Me.LabelForm_Server.Name = "LabelForm_Server"
        Me.LabelForm_Server.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_Server.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelForm_Server.TabIndex = 0
        Me.LabelForm_Server.Text = "Server:"
        '
        'LoginDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(433, 290)
        Me.ControlBox = False
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
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
End Class
