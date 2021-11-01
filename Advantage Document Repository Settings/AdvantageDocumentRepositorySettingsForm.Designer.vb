<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageDocumentRepositorySettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxForm_Password = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_UserName = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_Domain = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_Path = New System.Windows.Forms.TextBox()
        Me.LabelForm_Password = New System.Windows.Forms.Label()
        Me.LabelForm_UserName = New System.Windows.Forms.Label()
        Me.LabelForm_Domain = New System.Windows.Forms.Label()
        Me.LabelForm_Path = New System.Windows.Forms.Label()
        Me.ButtonForm_Save = New System.Windows.Forms.Button()
        Me.ButtonForm_SaveAndClose = New System.Windows.Forms.Button()
        Me.ButtonForm_Close = New System.Windows.Forms.Button()
        Me.LabelForm_FileSizeLimit = New System.Windows.Forms.Label()
        Me.LabelForm_FileSizeLimitInfo = New System.Windows.Forms.Label()
        Me.LabelForm_TotalRepositorySizeLimitInfo = New System.Windows.Forms.Label()
        Me.LabelForm_TotalRepositorySizeLimit = New System.Windows.Forms.Label()
        Me.ButtonForm_Browse = New System.Windows.Forms.Button()
        Me.NumericInputForm_TotalRepositorySizeLimit = New AdvantageDocumentRepositorySettings.NumericInput()
        Me.NumericInputForm_FileSizeLimit = New AdvantageDocumentRepositorySettings.NumericInput()
        CType(Me.NumericInputForm_TotalRepositorySizeLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputForm_FileSizeLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxForm_Password
        '
        Me.TextBoxForm_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Password.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_Password.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Password.Location = New System.Drawing.Point(158, 96)
        Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
        Me.TextBoxForm_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxForm_Password.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_Password.TabIndex = 8
        Me.TextBoxForm_Password.UseSystemPasswordChar = True
        '
        'TextBoxForm_UserName
        '
        Me.TextBoxForm_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_UserName.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_UserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_UserName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_UserName.Location = New System.Drawing.Point(158, 67)
        Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
        Me.TextBoxForm_UserName.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_UserName.TabIndex = 6
        '
        'TextBoxForm_Domain
        '
        Me.TextBoxForm_Domain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Domain.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Domain.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_Domain.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Domain.Location = New System.Drawing.Point(158, 38)
        Me.TextBoxForm_Domain.Name = "TextBoxForm_Domain"
        Me.TextBoxForm_Domain.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_Domain.TabIndex = 4
        '
        'TextBoxForm_Path
        '
        Me.TextBoxForm_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_Path.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_Path.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_Path.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_Path.Location = New System.Drawing.Point(158, 9)
        Me.TextBoxForm_Path.MinimumSize = New System.Drawing.Size(4, 23)
        Me.TextBoxForm_Path.Name = "TextBoxForm_Path"
        Me.TextBoxForm_Path.Size = New System.Drawing.Size(540, 23)
        Me.TextBoxForm_Path.TabIndex = 1
        '
        'LabelForm_Password
        '
        Me.LabelForm_Password.BackColor = System.Drawing.Color.White
        Me.LabelForm_Password.Location = New System.Drawing.Point(12, 96)
        Me.LabelForm_Password.Name = "LabelForm_Password"
        Me.LabelForm_Password.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_Password.TabIndex = 7
        Me.LabelForm_Password.Text = "Password:"
        Me.LabelForm_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_UserName
        '
        Me.LabelForm_UserName.BackColor = System.Drawing.Color.White
        Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 67)
        Me.LabelForm_UserName.Name = "LabelForm_UserName"
        Me.LabelForm_UserName.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_UserName.TabIndex = 5
        Me.LabelForm_UserName.Text = "User Name:"
        Me.LabelForm_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_Domain
        '
        Me.LabelForm_Domain.BackColor = System.Drawing.Color.White
        Me.LabelForm_Domain.Location = New System.Drawing.Point(12, 38)
        Me.LabelForm_Domain.Name = "LabelForm_Domain"
        Me.LabelForm_Domain.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_Domain.TabIndex = 3
        Me.LabelForm_Domain.Text = "Domain:"
        Me.LabelForm_Domain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_Path
        '
        Me.LabelForm_Path.BackColor = System.Drawing.Color.White
        Me.LabelForm_Path.Location = New System.Drawing.Point(12, 9)
        Me.LabelForm_Path.Name = "LabelForm_Path"
        Me.LabelForm_Path.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_Path.TabIndex = 0
        Me.LabelForm_Path.Text = "Path:"
        Me.LabelForm_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonForm_Save
        '
        Me.ButtonForm_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Save.Location = New System.Drawing.Point(517, 154)
        Me.ButtonForm_Save.Name = "ButtonForm_Save"
        Me.ButtonForm_Save.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForm_Save.TabIndex = 15
        Me.ButtonForm_Save.Text = "Save"
        Me.ButtonForm_Save.UseVisualStyleBackColor = True
        '
        'ButtonForm_SaveAndClose
        '
        Me.ButtonForm_SaveAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_SaveAndClose.Location = New System.Drawing.Point(598, 154)
        Me.ButtonForm_SaveAndClose.Name = "ButtonForm_SaveAndClose"
        Me.ButtonForm_SaveAndClose.Size = New System.Drawing.Size(100, 23)
        Me.ButtonForm_SaveAndClose.TabIndex = 16
        Me.ButtonForm_SaveAndClose.Text = "Save & Close"
        Me.ButtonForm_SaveAndClose.UseMnemonic = False
        Me.ButtonForm_SaveAndClose.UseVisualStyleBackColor = True
        '
        'ButtonForm_Close
        '
        Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Close.Location = New System.Drawing.Point(704, 154)
        Me.ButtonForm_Close.Name = "ButtonForm_Close"
        Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForm_Close.TabIndex = 17
        Me.ButtonForm_Close.Text = "Close"
        Me.ButtonForm_Close.UseVisualStyleBackColor = True
        '
        'LabelForm_FileSizeLimit
        '
        Me.LabelForm_FileSizeLimit.BackColor = System.Drawing.Color.White
        Me.LabelForm_FileSizeLimit.Location = New System.Drawing.Point(12, 125)
        Me.LabelForm_FileSizeLimit.Name = "LabelForm_FileSizeLimit"
        Me.LabelForm_FileSizeLimit.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_FileSizeLimit.TabIndex = 9
        Me.LabelForm_FileSizeLimit.Text = "File Size Limit:"
        Me.LabelForm_FileSizeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_FileSizeLimitInfo
        '
        Me.LabelForm_FileSizeLimitInfo.BackColor = System.Drawing.Color.White
        Me.LabelForm_FileSizeLimitInfo.Location = New System.Drawing.Point(228, 125)
        Me.LabelForm_FileSizeLimitInfo.Name = "LabelForm_FileSizeLimitInfo"
        Me.LabelForm_FileSizeLimitInfo.Size = New System.Drawing.Size(83, 23)
        Me.LabelForm_FileSizeLimitInfo.TabIndex = 11
        Me.LabelForm_FileSizeLimitInfo.Text = "MB (0-500)"
        Me.LabelForm_FileSizeLimitInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_TotalRepositorySizeLimitInfo
        '
        Me.LabelForm_TotalRepositorySizeLimitInfo.BackColor = System.Drawing.Color.White
        Me.LabelForm_TotalRepositorySizeLimitInfo.Location = New System.Drawing.Point(228, 154)
        Me.LabelForm_TotalRepositorySizeLimitInfo.Name = "LabelForm_TotalRepositorySizeLimitInfo"
        Me.LabelForm_TotalRepositorySizeLimitInfo.Size = New System.Drawing.Size(83, 23)
        Me.LabelForm_TotalRepositorySizeLimitInfo.TabIndex = 14
        Me.LabelForm_TotalRepositorySizeLimitInfo.Text = "GB"
        Me.LabelForm_TotalRepositorySizeLimitInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_TotalRepositorySizeLimit
        '
        Me.LabelForm_TotalRepositorySizeLimit.BackColor = System.Drawing.Color.White
        Me.LabelForm_TotalRepositorySizeLimit.Location = New System.Drawing.Point(12, 154)
        Me.LabelForm_TotalRepositorySizeLimit.Name = "LabelForm_TotalRepositorySizeLimit"
        Me.LabelForm_TotalRepositorySizeLimit.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_TotalRepositorySizeLimit.TabIndex = 12
        Me.LabelForm_TotalRepositorySizeLimit.Text = "Total Repository Size Limit:"
        Me.LabelForm_TotalRepositorySizeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonForm_Browse
        '
        Me.ButtonForm_Browse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Browse.Location = New System.Drawing.Point(704, 9)
        Me.ButtonForm_Browse.Name = "ButtonForm_Browse"
        Me.ButtonForm_Browse.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForm_Browse.TabIndex = 2
        Me.ButtonForm_Browse.Text = "Browse"
        Me.ButtonForm_Browse.UseVisualStyleBackColor = True
        '
        'NumericInputForm_TotalRepositorySizeLimit
        '
        Me.NumericInputForm_TotalRepositorySizeLimit.AutoSize = True
        Me.NumericInputForm_TotalRepositorySizeLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericInputForm_TotalRepositorySizeLimit.InterceptArrowKeys = False
        Me.NumericInputForm_TotalRepositorySizeLimit.Location = New System.Drawing.Point(158, 154)
        Me.NumericInputForm_TotalRepositorySizeLimit.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericInputForm_TotalRepositorySizeLimit.Name = "NumericInputForm_TotalRepositorySizeLimit"
        Me.NumericInputForm_TotalRepositorySizeLimit.Size = New System.Drawing.Size(64, 23)
        Me.NumericInputForm_TotalRepositorySizeLimit.TabIndex = 13
        '
        'NumericInputForm_FileSizeLimit
        '
        Me.NumericInputForm_FileSizeLimit.AutoSize = True
        Me.NumericInputForm_FileSizeLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericInputForm_FileSizeLimit.InterceptArrowKeys = False
        Me.NumericInputForm_FileSizeLimit.Location = New System.Drawing.Point(158, 125)
        Me.NumericInputForm_FileSizeLimit.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumericInputForm_FileSizeLimit.Name = "NumericInputForm_FileSizeLimit"
        Me.NumericInputForm_FileSizeLimit.Size = New System.Drawing.Size(64, 23)
        Me.NumericInputForm_FileSizeLimit.TabIndex = 10
        '
        'AdvantageDocumentRepositorySettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(791, 189)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonForm_Browse)
        Me.Controls.Add(Me.LabelForm_TotalRepositorySizeLimitInfo)
        Me.Controls.Add(Me.LabelForm_TotalRepositorySizeLimit)
        Me.Controls.Add(Me.NumericInputForm_TotalRepositorySizeLimit)
        Me.Controls.Add(Me.LabelForm_FileSizeLimitInfo)
        Me.Controls.Add(Me.ButtonForm_Save)
        Me.Controls.Add(Me.ButtonForm_SaveAndClose)
        Me.Controls.Add(Me.LabelForm_FileSizeLimit)
        Me.Controls.Add(Me.ButtonForm_Close)
        Me.Controls.Add(Me.NumericInputForm_FileSizeLimit)
        Me.Controls.Add(Me.LabelForm_Path)
        Me.Controls.Add(Me.TextBoxForm_Path)
        Me.Controls.Add(Me.LabelForm_Password)
        Me.Controls.Add(Me.TextBoxForm_Password)
        Me.Controls.Add(Me.TextBoxForm_Domain)
        Me.Controls.Add(Me.TextBoxForm_UserName)
        Me.Controls.Add(Me.LabelForm_UserName)
        Me.Controls.Add(Me.LabelForm_Domain)
        Me.Name = "AdvantageDocumentRepositorySettingsForm"
        Me.Text = "Advantage Document Repository Settings"
        CType(Me.NumericInputForm_TotalRepositorySizeLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputForm_FileSizeLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend TextBoxForm_Password As System.Windows.Forms.TextBox
    Friend TextBoxForm_UserName As System.Windows.Forms.TextBox
    Friend TextBoxForm_Domain As System.Windows.Forms.TextBox
    Friend TextBoxForm_Path As System.Windows.Forms.TextBox
    Friend LabelForm_Password As System.Windows.Forms.Label
    Friend LabelForm_UserName As System.Windows.Forms.Label
    Friend LabelForm_Domain As System.Windows.Forms.Label
    Friend LabelForm_Path As System.Windows.Forms.Label
    Friend WithEvents ButtonForm_SaveAndClose As Button
    Friend WithEvents ButtonForm_Close As Button
    Friend WithEvents ButtonForm_Save As Button
    Friend WithEvents LabelForm_FileSizeLimit As Label
    Friend WithEvents NumericInputForm_FileSizeLimit As NumericInput
    Friend WithEvents LabelForm_FileSizeLimitInfo As Label
    Friend WithEvents LabelForm_TotalRepositorySizeLimitInfo As Label
    Friend WithEvents LabelForm_TotalRepositorySizeLimit As Label
    Friend WithEvents NumericInputForm_TotalRepositorySizeLimit As NumericInput
    Friend WithEvents ButtonForm_Browse As Button
End Class
