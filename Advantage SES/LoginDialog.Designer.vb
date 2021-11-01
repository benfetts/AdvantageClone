<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose( disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonForm_Cancel = New System.Windows.Forms.Button()
        Me.ButtonForm_OK = New System.Windows.Forms.Button()
        Me.TextBoxForm_Password = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_UserName = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_Database = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_Server = New System.Windows.Forms.TextBox()
        Me.LabelForm_Password = New System.Windows.Forms.Label()
        Me.LabelForm_UserName = New System.Windows.Forms.Label()
        Me.LabelForm_Database = New System.Windows.Forms.Label()
        Me.LabelForm_Server = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonForm_Cancel
        '
        Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Cancel.Location = New System.Drawing.Point(346, 258)
        Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
        Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_Cancel.TabIndex = 10
        Me.ButtonForm_Cancel.Text = "Cancel"
        '
        'ButtonForm_OK
        '
        Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_OK.Location = New System.Drawing.Point(265, 258)
        Me.ButtonForm_OK.Name = "ButtonForm_OK"
        Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
        Me.ButtonForm_OK.TabIndex = 9
        Me.ButtonForm_OK.Text = "OK"
        '
        'TextBoxForm_Password
        '
        Me.TextBoxForm_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Password.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Password.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Password.Location = New System.Drawing.Point(78, 204)
        Me.TextBoxForm_Password.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
        Me.TextBoxForm_Password.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Password.TabIndex = 7
        Me.TextBoxForm_Password.UseSystemPasswordChar = True
        '
        'TextBoxForm_UserName
        '
        Me.TextBoxForm_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_UserName.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_UserName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_UserName.Location = New System.Drawing.Point(78, 178)
        Me.TextBoxForm_UserName.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
        Me.TextBoxForm_UserName.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_UserName.TabIndex = 5
        '
        'TextBoxForm_Database
        '
        Me.TextBoxForm_Database.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Database.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Database.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Database.Location = New System.Drawing.Point(78, 152)
        Me.TextBoxForm_Database.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Database.Name = "TextBoxForm_Database"
        Me.TextBoxForm_Database.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Database.TabIndex = 3
        '
        'TextBoxForm_Server
        '
        Me.TextBoxForm_Server.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Server.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Server.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Server.Location = New System.Drawing.Point(78, 126)
        Me.TextBoxForm_Server.MinimumSize = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Server.Name = "TextBoxForm_Server"
        Me.TextBoxForm_Server.Size = New System.Drawing.Size(343, 20)
        Me.TextBoxForm_Server.TabIndex = 1
        '
        'LabelForm_Password
        '
        Me.LabelForm_Password.BackColor = System.Drawing.Color.Transparent
        Me.LabelForm_Password.ForeColor = System.Drawing.Color.Black
        Me.LabelForm_Password.Location = New System.Drawing.Point(12, 204)
        Me.LabelForm_Password.Name = "LabelForm_Password"
        Me.LabelForm_Password.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_Password.TabIndex = 6
        Me.LabelForm_Password.Text = "Password:"
        '
        'LabelForm_UserName
        '
        Me.LabelForm_UserName.BackColor = System.Drawing.Color.Transparent
        Me.LabelForm_UserName.ForeColor = System.Drawing.Color.Black
        Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 178)
        Me.LabelForm_UserName.Name = "LabelForm_UserName"
        Me.LabelForm_UserName.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_UserName.TabIndex = 4
        Me.LabelForm_UserName.Text = "User ID:"
        '
        'LabelForm_Database
        '
        Me.LabelForm_Database.BackColor = System.Drawing.Color.Transparent
        Me.LabelForm_Database.ForeColor = System.Drawing.Color.Black
        Me.LabelForm_Database.Location = New System.Drawing.Point(12, 152)
        Me.LabelForm_Database.Name = "LabelForm_Database"
        Me.LabelForm_Database.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_Database.TabIndex = 2
        Me.LabelForm_Database.Text = "Database:"
        '
        'LabelForm_Server
        '
        Me.LabelForm_Server.BackColor = System.Drawing.Color.Transparent
        Me.LabelForm_Server.ForeColor = System.Drawing.Color.Black
        Me.LabelForm_Server.Location = New System.Drawing.Point(12, 126)
        Me.LabelForm_Server.Name = "LabelForm_Server"
        Me.LabelForm_Server.Size = New System.Drawing.Size(60, 20)
        Me.LabelForm_Server.TabIndex = 0
        Me.LabelForm_Server.Text = "Server:"
        '
        'LoginDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.AdvantageSES.My.Resources.Resources.AquaNewLoginImage
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(433, 290)
        Me.ControlBox = False
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelForm_Server As System.Windows.Forms.Label
    Friend WithEvents LabelForm_Database As System.Windows.Forms.Label
    Friend WithEvents LabelForm_UserName As System.Windows.Forms.Label
    Friend WithEvents LabelForm_Password As System.Windows.Forms.Label
    Friend WithEvents TextBoxForm_Server As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxForm_Database As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxForm_UserName As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxForm_Password As System.Windows.Forms.TextBox
    Friend WithEvents ButtonForm_OK As System.Windows.Forms.Button
    Friend WithEvents ButtonForm_Cancel As System.Windows.Forms.Button
End Class
