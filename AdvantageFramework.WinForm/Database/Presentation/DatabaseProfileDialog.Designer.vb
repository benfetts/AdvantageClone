Namespace Database.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DatabaseProfileDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatabaseProfileDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.GroupBoxForm_EmailSettings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelEmailSettings_DeleteMessages = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxEmailSettings_DeleteMessages = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxEmailSettings_Port = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmailSettings_Port = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmailSettings_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmailSettings_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmailSettings_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmailSettings_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmailSettings_EmailServer = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmailSettings_EmailServer = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RefreshEmailSettings = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Database = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Server = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Server = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_CPPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_CPUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_CPUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_TestAdmin = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_TestCP = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.GroupBoxForm_EmailSettings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_EmailSettings.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(526, 326)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 18
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'GroupBoxForm_EmailSettings
            '
            Me.GroupBoxForm_EmailSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.LabelEmailSettings_DeleteMessages)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.CheckBoxEmailSettings_DeleteMessages)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.TextBoxEmailSettings_Port)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.LabelEmailSettings_Port)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.TextBoxEmailSettings_Password)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.LabelEmailSettings_Password)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.TextBoxEmailSettings_UserName)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.LabelEmailSettings_UserName)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.TextBoxEmailSettings_EmailServer)
            Me.GroupBoxForm_EmailSettings.Controls.Add(Me.LabelEmailSettings_EmailServer)
            Me.GroupBoxForm_EmailSettings.Location = New System.Drawing.Point(12, 168)
            Me.GroupBoxForm_EmailSettings.Name = "GroupBoxForm_EmailSettings"
            Me.GroupBoxForm_EmailSettings.Size = New System.Drawing.Size(589, 152)
            Me.GroupBoxForm_EmailSettings.TabIndex = 14
            Me.GroupBoxForm_EmailSettings.Text = "Email Settings"
            '
            'LabelEmailSettings_DeleteMessages
            '
            Me.LabelEmailSettings_DeleteMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelEmailSettings_DeleteMessages.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailSettings_DeleteMessages.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailSettings_DeleteMessages.Location = New System.Drawing.Point(145, 127)
            Me.LabelEmailSettings_DeleteMessages.Name = "LabelEmailSettings_DeleteMessages"
            Me.LabelEmailSettings_DeleteMessages.Size = New System.Drawing.Size(438, 20)
            Me.LabelEmailSettings_DeleteMessages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailSettings_DeleteMessages.TabIndex = 9
            Me.LabelEmailSettings_DeleteMessages.Text = "Delete Messages After Reading (Email Listener Only)"
            '
            'CheckBoxEmailSettings_DeleteMessages
            '
            Me.CheckBoxEmailSettings_DeleteMessages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxEmailSettings_DeleteMessages.AutoCheck = False
            '
            '
            '
            Me.CheckBoxEmailSettings_DeleteMessages.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEmailSettings_DeleteMessages.CheckValue = 0
            Me.CheckBoxEmailSettings_DeleteMessages.CheckValueChecked = 1
            Me.CheckBoxEmailSettings_DeleteMessages.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxEmailSettings_DeleteMessages.CheckValueUnchecked = 0
            Me.CheckBoxEmailSettings_DeleteMessages.ChildControls = CType(resources.GetObject("CheckBoxEmailSettings_DeleteMessages.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEmailSettings_DeleteMessages.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEmailSettings_DeleteMessages.Enabled = False
            Me.CheckBoxEmailSettings_DeleteMessages.ForeColor = System.Drawing.Color.Black
            Me.CheckBoxEmailSettings_DeleteMessages.Location = New System.Drawing.Point(120, 127)
            Me.CheckBoxEmailSettings_DeleteMessages.Name = "CheckBoxEmailSettings_DeleteMessages"
            Me.CheckBoxEmailSettings_DeleteMessages.OldestSibling = Nothing
            Me.CheckBoxEmailSettings_DeleteMessages.SecurityEnabled = True
            Me.CheckBoxEmailSettings_DeleteMessages.SiblingControls = CType(resources.GetObject("CheckBoxEmailSettings_DeleteMessages.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEmailSettings_DeleteMessages.Size = New System.Drawing.Size(19, 20)
            Me.CheckBoxEmailSettings_DeleteMessages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEmailSettings_DeleteMessages.TabIndex = 8
            '
            'TextBoxEmailSettings_Port
            '
            '
            '
            '
            Me.TextBoxEmailSettings_Port.Border.Class = "TextBoxBorder"
            Me.TextBoxEmailSettings_Port.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmailSettings_Port.CheckSpellingOnValidate = False
            Me.TextBoxEmailSettings_Port.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmailSettings_Port.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmailSettings_Port.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmailSettings_Port.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmailSettings_Port.FocusHighlightEnabled = True
            Me.TextBoxEmailSettings_Port.Location = New System.Drawing.Point(119, 101)
            Me.TextBoxEmailSettings_Port.MaxFileSize = CType(0, Long)
            Me.TextBoxEmailSettings_Port.Name = "TextBoxEmailSettings_Port"
            Me.TextBoxEmailSettings_Port.ReadOnly = True
            Me.TextBoxEmailSettings_Port.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmailSettings_Port.Size = New System.Drawing.Size(124, 20)
            Me.TextBoxEmailSettings_Port.TabIndex = 7
            Me.TextBoxEmailSettings_Port.TabOnEnter = True
            '
            'LabelEmailSettings_Port
            '
            Me.LabelEmailSettings_Port.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailSettings_Port.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailSettings_Port.Location = New System.Drawing.Point(13, 101)
            Me.LabelEmailSettings_Port.Name = "LabelEmailSettings_Port"
            Me.LabelEmailSettings_Port.Size = New System.Drawing.Size(100, 20)
            Me.LabelEmailSettings_Port.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailSettings_Port.TabIndex = 6
            Me.LabelEmailSettings_Port.Text = "Port:"
            '
            'TextBoxEmailSettings_Password
            '
            Me.TextBoxEmailSettings_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmailSettings_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxEmailSettings_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmailSettings_Password.CheckSpellingOnValidate = False
            Me.TextBoxEmailSettings_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmailSettings_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmailSettings_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmailSettings_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmailSettings_Password.FocusHighlightEnabled = True
            Me.TextBoxEmailSettings_Password.Location = New System.Drawing.Point(119, 75)
            Me.TextBoxEmailSettings_Password.MaxFileSize = CType(0, Long)
            Me.TextBoxEmailSettings_Password.Name = "TextBoxEmailSettings_Password"
            Me.TextBoxEmailSettings_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.TextBoxEmailSettings_Password.ReadOnly = True
            Me.TextBoxEmailSettings_Password.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmailSettings_Password.Size = New System.Drawing.Size(464, 20)
            Me.TextBoxEmailSettings_Password.TabIndex = 5
            Me.TextBoxEmailSettings_Password.TabOnEnter = True
            '
            'LabelEmailSettings_Password
            '
            Me.LabelEmailSettings_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailSettings_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailSettings_Password.Location = New System.Drawing.Point(13, 75)
            Me.LabelEmailSettings_Password.Name = "LabelEmailSettings_Password"
            Me.LabelEmailSettings_Password.Size = New System.Drawing.Size(100, 20)
            Me.LabelEmailSettings_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailSettings_Password.TabIndex = 4
            Me.LabelEmailSettings_Password.Text = "Password:"
            '
            'TextBoxEmailSettings_UserName
            '
            Me.TextBoxEmailSettings_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmailSettings_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxEmailSettings_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmailSettings_UserName.CheckSpellingOnValidate = False
            Me.TextBoxEmailSettings_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmailSettings_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmailSettings_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmailSettings_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmailSettings_UserName.FocusHighlightEnabled = True
            Me.TextBoxEmailSettings_UserName.Location = New System.Drawing.Point(119, 49)
            Me.TextBoxEmailSettings_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxEmailSettings_UserName.Name = "TextBoxEmailSettings_UserName"
            Me.TextBoxEmailSettings_UserName.ReadOnly = True
            Me.TextBoxEmailSettings_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmailSettings_UserName.Size = New System.Drawing.Size(464, 20)
            Me.TextBoxEmailSettings_UserName.TabIndex = 3
            Me.TextBoxEmailSettings_UserName.TabOnEnter = True
            '
            'LabelEmailSettings_UserName
            '
            Me.LabelEmailSettings_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailSettings_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailSettings_UserName.Location = New System.Drawing.Point(13, 49)
            Me.LabelEmailSettings_UserName.Name = "LabelEmailSettings_UserName"
            Me.LabelEmailSettings_UserName.Size = New System.Drawing.Size(100, 20)
            Me.LabelEmailSettings_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailSettings_UserName.TabIndex = 2
            Me.LabelEmailSettings_UserName.Text = "User Name:"
            '
            'TextBoxEmailSettings_EmailServer
            '
            Me.TextBoxEmailSettings_EmailServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmailSettings_EmailServer.Border.Class = "TextBoxBorder"
            Me.TextBoxEmailSettings_EmailServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmailSettings_EmailServer.CheckSpellingOnValidate = False
            Me.TextBoxEmailSettings_EmailServer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmailSettings_EmailServer.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmailSettings_EmailServer.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmailSettings_EmailServer.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmailSettings_EmailServer.FocusHighlightEnabled = True
            Me.TextBoxEmailSettings_EmailServer.Location = New System.Drawing.Point(119, 23)
            Me.TextBoxEmailSettings_EmailServer.MaxFileSize = CType(0, Long)
            Me.TextBoxEmailSettings_EmailServer.Name = "TextBoxEmailSettings_EmailServer"
            Me.TextBoxEmailSettings_EmailServer.ReadOnly = True
            Me.TextBoxEmailSettings_EmailServer.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmailSettings_EmailServer.Size = New System.Drawing.Size(464, 20)
            Me.TextBoxEmailSettings_EmailServer.TabIndex = 1
            Me.TextBoxEmailSettings_EmailServer.TabOnEnter = True
            '
            'LabelEmailSettings_EmailServer
            '
            Me.LabelEmailSettings_EmailServer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailSettings_EmailServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailSettings_EmailServer.Location = New System.Drawing.Point(13, 23)
            Me.LabelEmailSettings_EmailServer.Name = "LabelEmailSettings_EmailServer"
            Me.LabelEmailSettings_EmailServer.Size = New System.Drawing.Size(100, 20)
            Me.LabelEmailSettings_EmailServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailSettings_EmailServer.TabIndex = 0
            Me.LabelEmailSettings_EmailServer.Text = "Email Server:"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(445, 326)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 17
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(445, 326)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 16
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_RefreshEmailSettings
            '
            Me.ButtonForm_RefreshEmailSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RefreshEmailSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_RefreshEmailSettings.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RefreshEmailSettings.Location = New System.Drawing.Point(12, 326)
            Me.ButtonForm_RefreshEmailSettings.Name = "ButtonForm_RefreshEmailSettings"
            Me.ButtonForm_RefreshEmailSettings.SecurityEnabled = True
            Me.ButtonForm_RefreshEmailSettings.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RefreshEmailSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RefreshEmailSettings.TabIndex = 15
            Me.ButtonForm_RefreshEmailSettings.Text = "Refresh"
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
            Me.TextBoxForm_Password.CheckSpellingOnValidate = False
            Me.TextBoxForm_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Password.FocusHighlightEnabled = True
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(118, 90)
            Me.TextBoxForm_Password.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(402, 20)
            Me.TextBoxForm_Password.TabIndex = 7
            Me.TextBoxForm_Password.TabOnEnter = True
            Me.TextBoxForm_Password.UseSystemPasswordChar = True
            '
            'LabelForm_Password
            '
            Me.LabelForm_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Password.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 6
            Me.LabelForm_Password.Text = "Password:"
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
            Me.TextBoxForm_UserName.CheckSpellingOnValidate = False
            Me.TextBoxForm_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserName.FocusHighlightEnabled = True
            Me.TextBoxForm_UserName.Location = New System.Drawing.Point(118, 64)
            Me.TextBoxForm_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
            Me.TextBoxForm_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_UserName.Size = New System.Drawing.Size(402, 20)
            Me.TextBoxForm_UserName.TabIndex = 5
            Me.TextBoxForm_UserName.TabOnEnter = True
            '
            'LabelForm_UserName
            '
            Me.LabelForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_UserName.Name = "LabelForm_UserName"
            Me.LabelForm_UserName.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserName.TabIndex = 4
            Me.LabelForm_UserName.Text = "User Name:"
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
            Me.TextBoxForm_Database.CheckSpellingOnValidate = False
            Me.TextBoxForm_Database.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Database.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Database.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Database.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Database.FocusHighlightEnabled = True
            Me.TextBoxForm_Database.Location = New System.Drawing.Point(118, 38)
            Me.TextBoxForm_Database.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Database.Name = "TextBoxForm_Database"
            Me.TextBoxForm_Database.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Database.Size = New System.Drawing.Size(483, 20)
            Me.TextBoxForm_Database.TabIndex = 3
            Me.TextBoxForm_Database.TabOnEnter = True
            '
            'LabelForm_Database
            '
            Me.LabelForm_Database.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Database.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Database.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Database.Name = "LabelForm_Database"
            Me.LabelForm_Database.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_Database.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Database.TabIndex = 2
            Me.LabelForm_Database.Text = "Database:"
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
            Me.TextBoxForm_Server.CheckSpellingOnValidate = False
            Me.TextBoxForm_Server.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Server.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Server.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Server.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Server.FocusHighlightEnabled = True
            Me.TextBoxForm_Server.Location = New System.Drawing.Point(118, 12)
            Me.TextBoxForm_Server.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Server.Name = "TextBoxForm_Server"
            Me.TextBoxForm_Server.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Server.Size = New System.Drawing.Size(483, 20)
            Me.TextBoxForm_Server.TabIndex = 1
            Me.TextBoxForm_Server.TabOnEnter = True
            '
            'LabelForm_Server
            '
            Me.LabelForm_Server.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Server.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Server.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Server.Name = "LabelForm_Server"
            Me.LabelForm_Server.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_Server.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Server.TabIndex = 0
            Me.LabelForm_Server.Text = "Server:"
            '
            'TextBoxForm_CPPassword
            '
            Me.TextBoxForm_CPPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_CPPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_CPPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_CPPassword.CheckSpellingOnValidate = False
            Me.TextBoxForm_CPPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_CPPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_CPPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_CPPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_CPPassword.FocusHighlightEnabled = True
            Me.TextBoxForm_CPPassword.Location = New System.Drawing.Point(118, 142)
            Me.TextBoxForm_CPPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_CPPassword.Name = "TextBoxForm_CPPassword"
            Me.TextBoxForm_CPPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_CPPassword.Size = New System.Drawing.Size(402, 20)
            Me.TextBoxForm_CPPassword.TabIndex = 12
            Me.TextBoxForm_CPPassword.TabOnEnter = True
            Me.TextBoxForm_CPPassword.UseSystemPasswordChar = True
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(12, 142)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(100, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 11
            Me.Label1.Text = "CP Password:"
            '
            'TextBoxForm_CPUserName
            '
            Me.TextBoxForm_CPUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_CPUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_CPUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_CPUserName.CheckSpellingOnValidate = False
            Me.TextBoxForm_CPUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_CPUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_CPUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_CPUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_CPUserName.FocusHighlightEnabled = True
            Me.TextBoxForm_CPUserName.Location = New System.Drawing.Point(118, 116)
            Me.TextBoxForm_CPUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_CPUserName.Name = "TextBoxForm_CPUserName"
            Me.TextBoxForm_CPUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_CPUserName.Size = New System.Drawing.Size(402, 20)
            Me.TextBoxForm_CPUserName.TabIndex = 10
            Me.TextBoxForm_CPUserName.TabOnEnter = True
            '
            'LabelForm_CPUserName
            '
            Me.LabelForm_CPUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CPUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CPUserName.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_CPUserName.Name = "LabelForm_CPUserName"
            Me.LabelForm_CPUserName.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_CPUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CPUserName.TabIndex = 9
            Me.LabelForm_CPUserName.Text = "CP User Name:"
            '
            'ButtonForm_TestAdmin
            '
            Me.ButtonForm_TestAdmin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_TestAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_TestAdmin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_TestAdmin.Location = New System.Drawing.Point(526, 90)
            Me.ButtonForm_TestAdmin.Name = "ButtonForm_TestAdmin"
            Me.ButtonForm_TestAdmin.SecurityEnabled = True
            Me.ButtonForm_TestAdmin.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_TestAdmin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_TestAdmin.TabIndex = 8
            Me.ButtonForm_TestAdmin.Text = "Test"
            '
            'ButtonForm_TestCP
            '
            Me.ButtonForm_TestCP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_TestCP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_TestCP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_TestCP.Location = New System.Drawing.Point(526, 142)
            Me.ButtonForm_TestCP.Name = "ButtonForm_TestCP"
            Me.ButtonForm_TestCP.SecurityEnabled = True
            Me.ButtonForm_TestCP.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_TestCP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_TestCP.TabIndex = 13
            Me.ButtonForm_TestCP.Text = "Test"
            '
            'DatabaseProfileDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(613, 358)
            Me.Controls.Add(Me.ButtonForm_TestCP)
            Me.Controls.Add(Me.ButtonForm_TestAdmin)
            Me.Controls.Add(Me.TextBoxForm_CPPassword)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TextBoxForm_CPUserName)
            Me.Controls.Add(Me.LabelForm_CPUserName)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.TextBoxForm_UserName)
            Me.Controls.Add(Me.LabelForm_UserName)
            Me.Controls.Add(Me.TextBoxForm_Database)
            Me.Controls.Add(Me.LabelForm_Database)
            Me.Controls.Add(Me.TextBoxForm_Server)
            Me.Controls.Add(Me.LabelForm_Server)
            Me.Controls.Add(Me.ButtonForm_RefreshEmailSettings)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.GroupBoxForm_EmailSettings)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DatabaseProfileDialog"
            Me.Text = "Database Profile"
            CType(Me.GroupBoxForm_EmailSettings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_EmailSettings.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxForm_EmailSettings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxEmailSettings_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmailSettings_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmailSettings_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmailSettings_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmailSettings_EmailServer As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmailSettings_EmailServer As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxEmailSettings_DeleteMessages As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxEmailSettings_Port As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmailSettings_Port As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelEmailSettings_DeleteMessages As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_RefreshEmailSettings As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Database As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Database As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Server As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Server As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_CPPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_CPUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_CPUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_TestAdmin As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_TestCP As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace