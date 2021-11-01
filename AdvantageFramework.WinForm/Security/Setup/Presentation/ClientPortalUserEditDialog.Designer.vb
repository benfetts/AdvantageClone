Namespace Security.Setup.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientPortalUserEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientPortalUserEditDialog))
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_FullName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_UserInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserCode = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_UserCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_WorkspaceTemplate = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_WorkspaceTemplate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DefaultInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_InformationMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_DefaultAgencyContact = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_DefaultAgencyContact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_DefaultAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_DefaultAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PasswordInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PasswordMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ConfirmPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_ConfirmPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_User = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ClientInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.Enabled = False
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(137, 116)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_Name.TabIndex = 7
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'LabelForm_FullName
            '
            Me.LabelForm_FullName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FullName.BackgroundStyle.Class = ""
            Me.LabelForm_FullName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FullName.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_FullName.Name = "LabelForm_FullName"
            Me.LabelForm_FullName.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_FullName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FullName.TabIndex = 6
            Me.LabelForm_FullName.Text = "Full Name:"
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
            Me.TextBoxForm_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserName.FocusHighlightEnabled = True
            Me.TextBoxForm_UserName.Location = New System.Drawing.Point(137, 142)
            Me.TextBoxForm_UserName.Name = "TextBoxForm_UserName"
            Me.TextBoxForm_UserName.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_UserName.TabIndex = 9
            Me.TextBoxForm_UserName.TabOnEnter = True
            '
            'LabelForm_UserName
            '
            Me.LabelForm_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserName.BackgroundStyle.Class = ""
            Me.LabelForm_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserName.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_UserName.Name = "LabelForm_UserName"
            Me.LabelForm_UserName.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserName.TabIndex = 8
            Me.LabelForm_UserName.Text = "User Name:"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(385, 454)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 31
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(466, 454)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 32
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(385, 454)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 30
            Me.ButtonForm_Add.Text = "Add"
            '
            'LabelForm_UserInformation
            '
            Me.LabelForm_UserInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_UserInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UserInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_UserInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_UserInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UserInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UserInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UserInformation.BackgroundStyle.Class = ""
            Me.LabelForm_UserInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_UserInformation.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_UserInformation.Name = "LabelForm_UserInformation"
            Me.LabelForm_UserInformation.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_UserInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserInformation.TabIndex = 5
            Me.LabelForm_UserInformation.Text = "User Information"
            '
            'TextBoxForm_UserCode
            '
            Me.TextBoxForm_UserCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_UserCode.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UserCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UserCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UserCode.Enabled = False
            Me.TextBoxForm_UserCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UserCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserCode.FocusHighlightEnabled = True
            Me.TextBoxForm_UserCode.Location = New System.Drawing.Point(137, 168)
            Me.TextBoxForm_UserCode.Name = "TextBoxForm_UserCode"
            Me.TextBoxForm_UserCode.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_UserCode.TabIndex = 11
            Me.TextBoxForm_UserCode.TabOnEnter = True
            '
            'LabelForm_UserCode
            '
            Me.LabelForm_UserCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserCode.BackgroundStyle.Class = ""
            Me.LabelForm_UserCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserCode.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_UserCode.Name = "LabelForm_UserCode"
            Me.LabelForm_UserCode.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_UserCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserCode.TabIndex = 10
            Me.LabelForm_UserCode.Text = "User Code:"
            '
            'TextBoxForm_Email
            '
            Me.TextBoxForm_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Email.Enabled = False
            Me.TextBoxForm_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Email.FocusHighlightEnabled = True
            Me.TextBoxForm_Email.Location = New System.Drawing.Point(137, 194)
            Me.TextBoxForm_Email.Name = "TextBoxForm_Email"
            Me.TextBoxForm_Email.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_Email.TabIndex = 13
            Me.TextBoxForm_Email.TabOnEnter = True
            '
            'LabelForm_Email
            '
            Me.LabelForm_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Email.BackgroundStyle.Class = ""
            Me.LabelForm_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Email.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_Email.Name = "LabelForm_Email"
            Me.LabelForm_Email.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Email.TabIndex = 12
            Me.LabelForm_Email.Text = "Email:"
            '
            'ComboBoxForm_WorkspaceTemplate
            '
            Me.ComboBoxForm_WorkspaceTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_WorkspaceTemplate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_WorkspaceTemplate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_WorkspaceTemplate.BookmarkingEnabled = False
            Me.ComboBoxForm_WorkspaceTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.WorkspaceTemplate
            Me.ComboBoxForm_WorkspaceTemplate.DisplayMember = "Name"
            Me.ComboBoxForm_WorkspaceTemplate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_WorkspaceTemplate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_WorkspaceTemplate.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_WorkspaceTemplate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_WorkspaceTemplate.FocusHighlightEnabled = True
            Me.ComboBoxForm_WorkspaceTemplate.FormattingEnabled = True
            Me.ComboBoxForm_WorkspaceTemplate.ItemHeight = 14
            Me.ComboBoxForm_WorkspaceTemplate.Location = New System.Drawing.Point(137, 220)
            Me.ComboBoxForm_WorkspaceTemplate.Name = "ComboBoxForm_WorkspaceTemplate"
            Me.ComboBoxForm_WorkspaceTemplate.PreventEnterBeep = False
            Me.ComboBoxForm_WorkspaceTemplate.Size = New System.Drawing.Size(404, 20)
            Me.ComboBoxForm_WorkspaceTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_WorkspaceTemplate.TabIndex = 17
            Me.ComboBoxForm_WorkspaceTemplate.ValueMember = "ID"
            Me.ComboBoxForm_WorkspaceTemplate.WatermarkText = "Select Workspace Template"
            '
            'LabelForm_WorkspaceTemplate
            '
            Me.LabelForm_WorkspaceTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WorkspaceTemplate.BackgroundStyle.Class = ""
            Me.LabelForm_WorkspaceTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WorkspaceTemplate.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_WorkspaceTemplate.Name = "LabelForm_WorkspaceTemplate"
            Me.LabelForm_WorkspaceTemplate.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_WorkspaceTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WorkspaceTemplate.TabIndex = 16
            Me.LabelForm_WorkspaceTemplate.Text = "Workspace Template:"
            '
            'LabelForm_DefaultInformation
            '
            Me.LabelForm_DefaultInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DefaultInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DefaultInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DefaultInformation.BackgroundStyle.Class = ""
            Me.LabelForm_DefaultInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_DefaultInformation.Location = New System.Drawing.Point(12, 350)
            Me.LabelForm_DefaultInformation.Name = "LabelForm_DefaultInformation"
            Me.LabelForm_DefaultInformation.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_DefaultInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultInformation.TabIndex = 24
            Me.LabelForm_DefaultInformation.Text = "Default Information **"
            '
            'LabelForm_InformationMessage
            '
            Me.LabelForm_InformationMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_InformationMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InformationMessage.BackgroundStyle.Class = ""
            Me.LabelForm_InformationMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InformationMessage.Location = New System.Drawing.Point(12, 428)
            Me.LabelForm_InformationMessage.Name = "LabelForm_InformationMessage"
            Me.LabelForm_InformationMessage.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_InformationMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InformationMessage.TabIndex = 29
            Me.LabelForm_InformationMessage.Text = "**A Selection must be made for one Default in order for Client-initiated Alerts t" & _
        "o operate. "
            '
            'ComboBoxForm_DefaultAgencyContact
            '
            Me.ComboBoxForm_DefaultAgencyContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_DefaultAgencyContact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DefaultAgencyContact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DefaultAgencyContact.BookmarkingEnabled = False
            Me.ComboBoxForm_DefaultAgencyContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_DefaultAgencyContact.DisplayMember = "FullName"
            Me.ComboBoxForm_DefaultAgencyContact.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DefaultAgencyContact.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_DefaultAgencyContact.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_DefaultAgencyContact.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_DefaultAgencyContact.FocusHighlightEnabled = True
            Me.ComboBoxForm_DefaultAgencyContact.FormattingEnabled = True
            Me.ComboBoxForm_DefaultAgencyContact.ItemHeight = 14
            Me.ComboBoxForm_DefaultAgencyContact.Location = New System.Drawing.Point(137, 402)
            Me.ComboBoxForm_DefaultAgencyContact.Name = "ComboBoxForm_DefaultAgencyContact"
            Me.ComboBoxForm_DefaultAgencyContact.PreventEnterBeep = False
            Me.ComboBoxForm_DefaultAgencyContact.Size = New System.Drawing.Size(404, 20)
            Me.ComboBoxForm_DefaultAgencyContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DefaultAgencyContact.TabIndex = 28
            Me.ComboBoxForm_DefaultAgencyContact.ValueMember = "Code"
            Me.ComboBoxForm_DefaultAgencyContact.WatermarkText = "Select Employee"
            '
            'LabelForm_DefaultAgencyContact
            '
            Me.LabelForm_DefaultAgencyContact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultAgencyContact.BackgroundStyle.Class = ""
            Me.LabelForm_DefaultAgencyContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultAgencyContact.Location = New System.Drawing.Point(12, 402)
            Me.LabelForm_DefaultAgencyContact.Name = "LabelForm_DefaultAgencyContact"
            Me.LabelForm_DefaultAgencyContact.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_DefaultAgencyContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultAgencyContact.TabIndex = 27
            Me.LabelForm_DefaultAgencyContact.Text = "Default Agency Contact:"
            '
            'ComboBoxForm_DefaultAlertGroup
            '
            Me.ComboBoxForm_DefaultAlertGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_DefaultAlertGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DefaultAlertGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DefaultAlertGroup.BookmarkingEnabled = False
            Me.ComboBoxForm_DefaultAlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertGroup
            Me.ComboBoxForm_DefaultAlertGroup.DisplayMember = "Description"
            Me.ComboBoxForm_DefaultAlertGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DefaultAlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_DefaultAlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_DefaultAlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_DefaultAlertGroup.FocusHighlightEnabled = True
            Me.ComboBoxForm_DefaultAlertGroup.FormattingEnabled = True
            Me.ComboBoxForm_DefaultAlertGroup.ItemHeight = 14
            Me.ComboBoxForm_DefaultAlertGroup.Location = New System.Drawing.Point(137, 376)
            Me.ComboBoxForm_DefaultAlertGroup.Name = "ComboBoxForm_DefaultAlertGroup"
            Me.ComboBoxForm_DefaultAlertGroup.PreventEnterBeep = False
            Me.ComboBoxForm_DefaultAlertGroup.Size = New System.Drawing.Size(404, 20)
            Me.ComboBoxForm_DefaultAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DefaultAlertGroup.TabIndex = 26
            Me.ComboBoxForm_DefaultAlertGroup.ValueMember = "Code"
            Me.ComboBoxForm_DefaultAlertGroup.WatermarkText = "Select Alert Group"
            '
            'LabelForm_DefaultAlertGroup
            '
            Me.LabelForm_DefaultAlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultAlertGroup.BackgroundStyle.Class = ""
            Me.LabelForm_DefaultAlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultAlertGroup.Location = New System.Drawing.Point(12, 376)
            Me.LabelForm_DefaultAlertGroup.Name = "LabelForm_DefaultAlertGroup"
            Me.LabelForm_DefaultAlertGroup.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_DefaultAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultAlertGroup.TabIndex = 25
            Me.LabelForm_DefaultAlertGroup.Text = "Default Alert Group:"
            '
            'LabelForm_PasswordInformation
            '
            Me.LabelForm_PasswordInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PasswordInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PasswordInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PasswordInformation.BackgroundStyle.Class = ""
            Me.LabelForm_PasswordInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PasswordInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_PasswordInformation.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_PasswordInformation.Name = "LabelForm_PasswordInformation"
            Me.LabelForm_PasswordInformation.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_PasswordInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PasswordInformation.TabIndex = 18
            Me.LabelForm_PasswordInformation.Text = "Password Information"
            '
            'LabelForm_PasswordMessage
            '
            Me.LabelForm_PasswordMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PasswordMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PasswordMessage.BackgroundStyle.Class = ""
            Me.LabelForm_PasswordMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PasswordMessage.Location = New System.Drawing.Point(12, 272)
            Me.LabelForm_PasswordMessage.Name = "LabelForm_PasswordMessage"
            Me.LabelForm_PasswordMessage.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_PasswordMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PasswordMessage.TabIndex = 19
            Me.LabelForm_PasswordMessage.Text = "*Password must be at least 8 characters long, has to contain letters and numbers," & _
        " and one uppercase letter. "
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
            Me.TextBoxForm_ConfirmPassword.Location = New System.Drawing.Point(137, 324)
            Me.TextBoxForm_ConfirmPassword.Name = "TextBoxForm_ConfirmPassword"
            Me.TextBoxForm_ConfirmPassword.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_ConfirmPassword.TabIndex = 23
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
            Me.LabelForm_Password.Location = New System.Drawing.Point(12, 298)
            Me.LabelForm_Password.Name = "LabelForm_Password"
            Me.LabelForm_Password.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Password.TabIndex = 20
            Me.LabelForm_Password.Text = "Password:"
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
            Me.TextBoxForm_Password.Location = New System.Drawing.Point(137, 298)
            Me.TextBoxForm_Password.Name = "TextBoxForm_Password"
            Me.TextBoxForm_Password.Size = New System.Drawing.Size(404, 20)
            Me.TextBoxForm_Password.TabIndex = 21
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
            Me.LabelForm_ConfirmPassword.Location = New System.Drawing.Point(12, 324)
            Me.LabelForm_ConfirmPassword.Name = "LabelForm_ConfirmPassword"
            Me.LabelForm_ConfirmPassword.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_ConfirmPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ConfirmPassword.TabIndex = 22
            Me.LabelForm_ConfirmPassword.Text = "Confirm Password:"
            '
            'ComboBoxForm_User
            '
            Me.ComboBoxForm_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_User.BookmarkingEnabled = False
            Me.ComboBoxForm_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_User.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_User.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_User.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_User.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_User.FocusHighlightEnabled = True
            Me.ComboBoxForm_User.FormattingEnabled = True
            Me.ComboBoxForm_User.ItemHeight = 14
            Me.ComboBoxForm_User.Location = New System.Drawing.Point(137, 64)
            Me.ComboBoxForm_User.Name = "ComboBoxForm_User"
            Me.ComboBoxForm_User.PreventEnterBeep = False
            Me.ComboBoxForm_User.Size = New System.Drawing.Size(404, 20)
            Me.ComboBoxForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_User.TabIndex = 4
            '
            'LabelForm_User
            '
            Me.LabelForm_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_User.BackgroundStyle.Class = ""
            Me.LabelForm_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_User.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_User.Name = "LabelForm_User"
            Me.LabelForm_User.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_User.TabIndex = 3
            Me.LabelForm_User.Text = "User:"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(137, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(404, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 2
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.Class = ""
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(119, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 1
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_ClientInformation
            '
            Me.LabelForm_ClientInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ClientInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ClientInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ClientInformation.BackgroundStyle.Class = ""
            Me.LabelForm_ClientInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ClientInformation.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ClientInformation.Name = "LabelForm_ClientInformation"
            Me.LabelForm_ClientInformation.Size = New System.Drawing.Size(529, 20)
            Me.LabelForm_ClientInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientInformation.TabIndex = 0
            Me.LabelForm_ClientInformation.Text = "Client Information"
            '
            'ClientPortalUserEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(553, 486)
            Me.Controls.Add(Me.LabelForm_ClientInformation)
            Me.Controls.Add(Me.ComboBoxForm_User)
            Me.Controls.Add(Me.LabelForm_User)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ComboBoxForm_WorkspaceTemplate)
            Me.Controls.Add(Me.LabelForm_WorkspaceTemplate)
            Me.Controls.Add(Me.TextBoxForm_Email)
            Me.Controls.Add(Me.TextBoxForm_ConfirmPassword)
            Me.Controls.Add(Me.LabelForm_PasswordInformation)
            Me.Controls.Add(Me.LabelForm_Email)
            Me.Controls.Add(Me.LabelForm_Password)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_ConfirmPassword)
            Me.Controls.Add(Me.TextBoxForm_UserCode)
            Me.Controls.Add(Me.TextBoxForm_Password)
            Me.Controls.Add(Me.LabelForm_PasswordMessage)
            Me.Controls.Add(Me.LabelForm_DefaultInformation)
            Me.Controls.Add(Me.ComboBoxForm_DefaultAgencyContact)
            Me.Controls.Add(Me.LabelForm_DefaultAgencyContact)
            Me.Controls.Add(Me.ComboBoxForm_DefaultAlertGroup)
            Me.Controls.Add(Me.LabelForm_DefaultAlertGroup)
            Me.Controls.Add(Me.LabelForm_InformationMessage)
            Me.Controls.Add(Me.LabelForm_UserCode)
            Me.Controls.Add(Me.LabelForm_UserInformation)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.LabelForm_FullName)
            Me.Controls.Add(Me.TextBoxForm_UserName)
            Me.Controls.Add(Me.LabelForm_UserName)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientPortalUserEditDialog"
            Me.Text = "Add Client Portal User"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_FullName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_UserInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UserCode As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_UserCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PasswordInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_WorkspaceTemplate As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_WorkspaceTemplate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DefaultInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_InformationMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_DefaultAgencyContact As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_DefaultAgencyContact As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_DefaultAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_DefaultAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PasswordMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_ConfirmPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Password As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_ConfirmPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_User As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ClientInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace