<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageSESForm
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
        Me.LabelTop_CreateTable = New System.Windows.Forms.Label()
        Me.ButtonTop_CreateTable = New System.Windows.Forms.Button()
        Me.TextBoxForm_DefaultPassword = New System.Windows.Forms.TextBox()
        Me.LabelForm_OAuth2 = New System.Windows.Forms.Label()
        Me.ComboBoxForm_AuthenticationMethod = New System.Windows.Forms.ComboBox()
        Me.TextBoxForm_ReplyToAddress = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_DefaultUserName = New System.Windows.Forms.TextBox()
        Me.TextBoxForm_SenderAddress = New System.Windows.Forms.TextBox()
        Me.RadioButtonForm_NoSecureProtocol = New System.Windows.Forms.RadioButton()
        Me.TextBoxForm_OutgoingServerAddress = New System.Windows.Forms.TextBox()
        Me.RadioButtonForm_UseTLS = New System.Windows.Forms.RadioButton()
        Me.LabelForm_ReplyToAddress = New System.Windows.Forms.Label()
        Me.LabelForm_DefaultSenderPassword = New System.Windows.Forms.Label()
        Me.RadioButtonForm_UseSSL = New System.Windows.Forms.RadioButton()
        Me.LabelForm_DefaultUserName = New System.Windows.Forms.Label()
        Me.LabelForm_SenderAddress = New System.Windows.Forms.Label()
        Me.LabelForm_OutgoingServerAddress = New System.Windows.Forms.Label()
        Me.LabelForm_PortNumber = New System.Windows.Forms.Label()
        Me.LabelForm_AuthenticationMethod = New System.Windows.Forms.Label()
        Me.PanelForm_Top = New System.Windows.Forms.Panel()
        Me.ButtonTop_Close = New System.Windows.Forms.Button()
        Me.PanelForm_Form = New System.Windows.Forms.Panel()
        Me.ButtonForm_Save = New System.Windows.Forms.Button()
        Me.ButtonForm_SaveAndClose = New System.Windows.Forms.Button()
        Me.ButtonForm_Close = New System.Windows.Forms.Button()
        Me.NumericInputForm_PortNumber = New AdvantageSES.NumericInput()
        Me.PanelForm_Top.SuspendLayout()
        Me.PanelForm_Form.SuspendLayout()
        CType(Me.NumericInputForm_PortNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelTop_CreateTable
        '
        Me.LabelTop_CreateTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTop_CreateTable.ForeColor = System.Drawing.Color.Red
        Me.LabelTop_CreateTable.Location = New System.Drawing.Point(12, 9)
        Me.LabelTop_CreateTable.Name = "LabelTop_CreateTable"
        Me.LabelTop_CreateTable.Size = New System.Drawing.Size(580, 23)
        Me.LabelTop_CreateTable.TabIndex = 0
        Me.LabelTop_CreateTable.Text = "Table has not been created"
        Me.LabelTop_CreateTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonTop_CreateTable
        '
        Me.ButtonTop_CreateTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTop_CreateTable.Location = New System.Drawing.Point(598, 9)
        Me.ButtonTop_CreateTable.Name = "ButtonTop_CreateTable"
        Me.ButtonTop_CreateTable.Size = New System.Drawing.Size(100, 23)
        Me.ButtonTop_CreateTable.TabIndex = 1
        Me.ButtonTop_CreateTable.Text = "Create Table"
        Me.ButtonTop_CreateTable.UseVisualStyleBackColor = True
        '
        'TextBoxForm_DefaultPassword
        '
        Me.TextBoxForm_DefaultPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_DefaultPassword.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_DefaultPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_DefaultPassword.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_DefaultPassword.Location = New System.Drawing.Point(158, 147)
        Me.TextBoxForm_DefaultPassword.Name = "TextBoxForm_DefaultPassword"
        Me.TextBoxForm_DefaultPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxForm_DefaultPassword.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_DefaultPassword.TabIndex = 14
        Me.TextBoxForm_DefaultPassword.UseSystemPasswordChar = True
        '
        'LabelForm_OAuth2
        '
        Me.LabelForm_OAuth2.BackColor = System.Drawing.Color.White
        Me.LabelForm_OAuth2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelForm_OAuth2.Location = New System.Drawing.Point(158, 147)
        Me.LabelForm_OAuth2.Name = "LabelForm_OAuth2"
        Me.LabelForm_OAuth2.Size = New System.Drawing.Size(630, 23)
        Me.LabelForm_OAuth2.TabIndex = 31
        Me.LabelForm_OAuth2.Text = "Email Account is {0}. <a name=""{1}"">{2}</a>"
        '
        'ComboBoxForm_AuthenticationMethod
        '
        Me.ComboBoxForm_AuthenticationMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxForm_AuthenticationMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxForm_AuthenticationMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxForm_AuthenticationMethod.DisplayMember = "Description"
        Me.ComboBoxForm_AuthenticationMethod.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxForm_AuthenticationMethod.FormattingEnabled = True
        Me.ComboBoxForm_AuthenticationMethod.ItemHeight = 13
        Me.ComboBoxForm_AuthenticationMethod.Location = New System.Drawing.Point(158, 3)
        Me.ComboBoxForm_AuthenticationMethod.Name = "ComboBoxForm_AuthenticationMethod"
        Me.ComboBoxForm_AuthenticationMethod.Size = New System.Drawing.Size(621, 21)
        Me.ComboBoxForm_AuthenticationMethod.TabIndex = 1
        Me.ComboBoxForm_AuthenticationMethod.ValueMember = "Code"
        '
        'TextBoxForm_ReplyToAddress
        '
        Me.TextBoxForm_ReplyToAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_ReplyToAddress.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_ReplyToAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_ReplyToAddress.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_ReplyToAddress.Location = New System.Drawing.Point(158, 176)
        Me.TextBoxForm_ReplyToAddress.Name = "TextBoxForm_ReplyToAddress"
        Me.TextBoxForm_ReplyToAddress.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_ReplyToAddress.TabIndex = 16
        '
        'TextBoxForm_DefaultUserName
        '
        Me.TextBoxForm_DefaultUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_DefaultUserName.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_DefaultUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_DefaultUserName.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_DefaultUserName.Location = New System.Drawing.Point(158, 118)
        Me.TextBoxForm_DefaultUserName.Name = "TextBoxForm_DefaultUserName"
        Me.TextBoxForm_DefaultUserName.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_DefaultUserName.TabIndex = 12
        '
        'TextBoxForm_SenderAddress
        '
        Me.TextBoxForm_SenderAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_SenderAddress.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_SenderAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_SenderAddress.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_SenderAddress.Location = New System.Drawing.Point(158, 89)
        Me.TextBoxForm_SenderAddress.Name = "TextBoxForm_SenderAddress"
        Me.TextBoxForm_SenderAddress.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_SenderAddress.TabIndex = 10
        '
        'RadioButtonForm_NoSecureProtocol
        '
        Me.RadioButtonForm_NoSecureProtocol.BackColor = System.Drawing.Color.White
        Me.RadioButtonForm_NoSecureProtocol.Location = New System.Drawing.Point(379, 32)
        Me.RadioButtonForm_NoSecureProtocol.Name = "RadioButtonForm_NoSecureProtocol"
        Me.RadioButtonForm_NoSecureProtocol.Size = New System.Drawing.Size(126, 23)
        Me.RadioButtonForm_NoSecureProtocol.TabIndex = 6
        Me.RadioButtonForm_NoSecureProtocol.Text = "No Secure Protocol"
        Me.RadioButtonForm_NoSecureProtocol.UseVisualStyleBackColor = False
        '
        'TextBoxForm_OutgoingServerAddress
        '
        Me.TextBoxForm_OutgoingServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxForm_OutgoingServerAddress.BackColor = System.Drawing.Color.White
        Me.TextBoxForm_OutgoingServerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxForm_OutgoingServerAddress.ForeColor = System.Drawing.Color.Black
        Me.TextBoxForm_OutgoingServerAddress.Location = New System.Drawing.Point(158, 61)
        Me.TextBoxForm_OutgoingServerAddress.MinimumSize = New System.Drawing.Size(4, 23)
        Me.TextBoxForm_OutgoingServerAddress.Name = "TextBoxForm_OutgoingServerAddress"
        Me.TextBoxForm_OutgoingServerAddress.Size = New System.Drawing.Size(621, 23)
        Me.TextBoxForm_OutgoingServerAddress.TabIndex = 8
        '
        'RadioButtonForm_UseTLS
        '
        Me.RadioButtonForm_UseTLS.BackColor = System.Drawing.Color.White
        Me.RadioButtonForm_UseTLS.Location = New System.Drawing.Point(304, 32)
        Me.RadioButtonForm_UseTLS.Name = "RadioButtonForm_UseTLS"
        Me.RadioButtonForm_UseTLS.Size = New System.Drawing.Size(69, 23)
        Me.RadioButtonForm_UseTLS.TabIndex = 5
        Me.RadioButtonForm_UseTLS.Text = "Use TLS"
        Me.RadioButtonForm_UseTLS.UseVisualStyleBackColor = False
        '
        'LabelForm_ReplyToAddress
        '
        Me.LabelForm_ReplyToAddress.BackColor = System.Drawing.Color.White
        Me.LabelForm_ReplyToAddress.Location = New System.Drawing.Point(12, 176)
        Me.LabelForm_ReplyToAddress.Name = "LabelForm_ReplyToAddress"
        Me.LabelForm_ReplyToAddress.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_ReplyToAddress.TabIndex = 15
        Me.LabelForm_ReplyToAddress.Text = "Default Reply To Address:"
        Me.LabelForm_ReplyToAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_DefaultSenderPassword
        '
        Me.LabelForm_DefaultSenderPassword.BackColor = System.Drawing.Color.White
        Me.LabelForm_DefaultSenderPassword.Location = New System.Drawing.Point(12, 147)
        Me.LabelForm_DefaultSenderPassword.Name = "LabelForm_DefaultSenderPassword"
        Me.LabelForm_DefaultSenderPassword.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_DefaultSenderPassword.TabIndex = 13
        Me.LabelForm_DefaultSenderPassword.Text = "Default Sender Password:"
        Me.LabelForm_DefaultSenderPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButtonForm_UseSSL
        '
        Me.RadioButtonForm_UseSSL.BackColor = System.Drawing.Color.White
        Me.RadioButtonForm_UseSSL.Location = New System.Drawing.Point(228, 32)
        Me.RadioButtonForm_UseSSL.Name = "RadioButtonForm_UseSSL"
        Me.RadioButtonForm_UseSSL.Size = New System.Drawing.Size(70, 23)
        Me.RadioButtonForm_UseSSL.TabIndex = 4
        Me.RadioButtonForm_UseSSL.Text = "Use SSL"
        Me.RadioButtonForm_UseSSL.UseVisualStyleBackColor = False
        '
        'LabelForm_DefaultUserName
        '
        Me.LabelForm_DefaultUserName.BackColor = System.Drawing.Color.White
        Me.LabelForm_DefaultUserName.Location = New System.Drawing.Point(12, 118)
        Me.LabelForm_DefaultUserName.Name = "LabelForm_DefaultUserName"
        Me.LabelForm_DefaultUserName.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_DefaultUserName.TabIndex = 11
        Me.LabelForm_DefaultUserName.Text = "Default Sender User Name:"
        Me.LabelForm_DefaultUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_SenderAddress
        '
        Me.LabelForm_SenderAddress.BackColor = System.Drawing.Color.White
        Me.LabelForm_SenderAddress.Location = New System.Drawing.Point(12, 89)
        Me.LabelForm_SenderAddress.Name = "LabelForm_SenderAddress"
        Me.LabelForm_SenderAddress.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_SenderAddress.TabIndex = 9
        Me.LabelForm_SenderAddress.Text = "Default Sender Address:"
        Me.LabelForm_SenderAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_OutgoingServerAddress
        '
        Me.LabelForm_OutgoingServerAddress.BackColor = System.Drawing.Color.White
        Me.LabelForm_OutgoingServerAddress.Location = New System.Drawing.Point(12, 61)
        Me.LabelForm_OutgoingServerAddress.Name = "LabelForm_OutgoingServerAddress"
        Me.LabelForm_OutgoingServerAddress.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_OutgoingServerAddress.TabIndex = 7
        Me.LabelForm_OutgoingServerAddress.Text = "Outgoing Server Address:"
        Me.LabelForm_OutgoingServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_PortNumber
        '
        Me.LabelForm_PortNumber.BackColor = System.Drawing.Color.White
        Me.LabelForm_PortNumber.Location = New System.Drawing.Point(12, 32)
        Me.LabelForm_PortNumber.Name = "LabelForm_PortNumber"
        Me.LabelForm_PortNumber.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_PortNumber.TabIndex = 2
        Me.LabelForm_PortNumber.Text = "Port Number:"
        Me.LabelForm_PortNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelForm_AuthenticationMethod
        '
        Me.LabelForm_AuthenticationMethod.BackColor = System.Drawing.Color.White
        Me.LabelForm_AuthenticationMethod.Location = New System.Drawing.Point(12, 3)
        Me.LabelForm_AuthenticationMethod.Name = "LabelForm_AuthenticationMethod"
        Me.LabelForm_AuthenticationMethod.Size = New System.Drawing.Size(140, 23)
        Me.LabelForm_AuthenticationMethod.TabIndex = 0
        Me.LabelForm_AuthenticationMethod.Text = "Authentication Method:"
        Me.LabelForm_AuthenticationMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelForm_Top
        '
        Me.PanelForm_Top.Controls.Add(Me.ButtonTop_Close)
        Me.PanelForm_Top.Controls.Add(Me.LabelTop_CreateTable)
        Me.PanelForm_Top.Controls.Add(Me.ButtonTop_CreateTable)
        Me.PanelForm_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelForm_Top.Location = New System.Drawing.Point(0, 0)
        Me.PanelForm_Top.Name = "PanelForm_Top"
        Me.PanelForm_Top.Size = New System.Drawing.Size(791, 40)
        Me.PanelForm_Top.TabIndex = 0
        '
        'ButtonTop_Close
        '
        Me.ButtonTop_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTop_Close.Location = New System.Drawing.Point(704, 9)
        Me.ButtonTop_Close.Name = "ButtonTop_Close"
        Me.ButtonTop_Close.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTop_Close.TabIndex = 20
        Me.ButtonTop_Close.Text = "Close"
        Me.ButtonTop_Close.UseVisualStyleBackColor = True
        '
        'PanelForm_Form
        '
        Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Save)
        Me.PanelForm_Form.Controls.Add(Me.ButtonForm_SaveAndClose)
        Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Close)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_AuthenticationMethod)
        Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_AuthenticationMethod)
        Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_DefaultPassword)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_PortNumber)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_OAuth2)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_OutgoingServerAddress)
        Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_PortNumber)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_SenderAddress)
        Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_ReplyToAddress)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_DefaultUserName)
        Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_DefaultUserName)
        Me.PanelForm_Form.Controls.Add(Me.RadioButtonForm_UseSSL)
        Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_SenderAddress)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_DefaultSenderPassword)
        Me.PanelForm_Form.Controls.Add(Me.RadioButtonForm_NoSecureProtocol)
        Me.PanelForm_Form.Controls.Add(Me.LabelForm_ReplyToAddress)
        Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_OutgoingServerAddress)
        Me.PanelForm_Form.Controls.Add(Me.RadioButtonForm_UseTLS)
        Me.PanelForm_Form.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelForm_Form.Enabled = False
        Me.PanelForm_Form.Location = New System.Drawing.Point(0, 40)
        Me.PanelForm_Form.Name = "PanelForm_Form"
        Me.PanelForm_Form.Size = New System.Drawing.Size(791, 240)
        Me.PanelForm_Form.TabIndex = 1
        '
        'ButtonForm_Save
        '
        Me.ButtonForm_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Save.Location = New System.Drawing.Point(517, 205)
        Me.ButtonForm_Save.Name = "ButtonForm_Save"
        Me.ButtonForm_Save.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForm_Save.TabIndex = 17
        Me.ButtonForm_Save.Text = "Save"
        Me.ButtonForm_Save.UseVisualStyleBackColor = True
        '
        'ButtonForm_SaveAndClose
        '
        Me.ButtonForm_SaveAndClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_SaveAndClose.Location = New System.Drawing.Point(598, 205)
        Me.ButtonForm_SaveAndClose.Name = "ButtonForm_SaveAndClose"
        Me.ButtonForm_SaveAndClose.Size = New System.Drawing.Size(100, 23)
        Me.ButtonForm_SaveAndClose.TabIndex = 18
        Me.ButtonForm_SaveAndClose.Text = "Save & Close"
        Me.ButtonForm_SaveAndClose.UseMnemonic = False
        Me.ButtonForm_SaveAndClose.UseVisualStyleBackColor = True
        '
        'ButtonForm_Close
        '
        Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonForm_Close.Location = New System.Drawing.Point(704, 205)
        Me.ButtonForm_Close.Name = "ButtonForm_Close"
        Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForm_Close.TabIndex = 19
        Me.ButtonForm_Close.Text = "Close"
        Me.ButtonForm_Close.UseVisualStyleBackColor = True
        '
        'NumericInputForm_PortNumber
        '
        Me.NumericInputForm_PortNumber.AutoSize = True
        Me.NumericInputForm_PortNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericInputForm_PortNumber.InterceptArrowKeys = False
        Me.NumericInputForm_PortNumber.Location = New System.Drawing.Point(158, 32)
        Me.NumericInputForm_PortNumber.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.NumericInputForm_PortNumber.Name = "NumericInputForm_PortNumber"
        Me.NumericInputForm_PortNumber.Size = New System.Drawing.Size(64, 23)
        Me.NumericInputForm_PortNumber.TabIndex = 3
        '
        'AdvantageSESForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 280)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelForm_Form)
        Me.Controls.Add(Me.PanelForm_Top)
        Me.Name = "AdvantageSESForm"
        Me.Text = "Advantage SES"
        Me.PanelForm_Top.ResumeLayout(False)
        Me.PanelForm_Form.ResumeLayout(False)
        Me.PanelForm_Form.PerformLayout()
        CType(Me.NumericInputForm_PortNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelTop_CreateTable As Label
    Friend WithEvents ButtonTop_CreateTable As Button
    Friend TextBoxForm_DefaultPassword As System.Windows.Forms.TextBox
    Friend LabelForm_OAuth2 As System.Windows.Forms.Label
    Friend ComboBoxForm_AuthenticationMethod As System.Windows.Forms.ComboBox
    Friend NumericInputForm_PortNumber As NumericInput
    Friend TextBoxForm_ReplyToAddress As System.Windows.Forms.TextBox
    Friend TextBoxForm_DefaultUserName As System.Windows.Forms.TextBox
    Friend TextBoxForm_SenderAddress As System.Windows.Forms.TextBox
    Friend RadioButtonForm_NoSecureProtocol As System.Windows.Forms.RadioButton
    Friend TextBoxForm_OutgoingServerAddress As System.Windows.Forms.TextBox
    Friend RadioButtonForm_UseTLS As System.Windows.Forms.RadioButton
    Friend LabelForm_ReplyToAddress As System.Windows.Forms.Label
    Friend LabelForm_DefaultSenderPassword As System.Windows.Forms.Label
    Friend RadioButtonForm_UseSSL As System.Windows.Forms.RadioButton
    Friend LabelForm_DefaultUserName As System.Windows.Forms.Label
    Friend LabelForm_SenderAddress As System.Windows.Forms.Label
    Friend LabelForm_OutgoingServerAddress As System.Windows.Forms.Label
    Friend LabelForm_PortNumber As System.Windows.Forms.Label
    Friend LabelForm_AuthenticationMethod As System.Windows.Forms.Label
    Friend WithEvents PanelForm_Top As Panel
    Friend WithEvents PanelForm_Form As Panel
    Friend WithEvents ButtonForm_SaveAndClose As Button
    Friend WithEvents ButtonForm_Close As Button
    Friend WithEvents ButtonForm_Save As Button
    Friend WithEvents ButtonTop_Close As Button
End Class
