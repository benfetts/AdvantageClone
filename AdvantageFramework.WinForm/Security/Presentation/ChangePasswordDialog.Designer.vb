Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ChangePasswordDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePasswordDialog))
            Me.TabControlForm_Passwords = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGoogleTab_Google = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelGoogle_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGoogle_GoogleServices = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemPasswords_GoogleTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmailTab_Email = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelEmail_GoogleNote = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelEmail_GoogleServices = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelEmail_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmail_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmail_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmail_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmail_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmail_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelEmail_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxEmail_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_EmailTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSugarCRM_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSugarCRM_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSugarCRM_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSugarCRM_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSugarCRM_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSugarCRM_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSugarCRM_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSugarCRM_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_SugarCRMTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdAssistTab_AdAssist = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelAdAssist_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdAssist_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAdAssist_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdAssist_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAdAssist_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdAssist_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_AdAssistTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProofHQTab_ProofHQ = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelProofHQ_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProofHQ_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelProofHQ_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProofHQ_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelProofHQ_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProofHQ_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelProofHQ_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxProofHQ_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_ProofHQTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelAdobeSignature_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdobeSignature_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAdobeSignature_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdobeSignature_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAdobeSignature_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAdobeSignature_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_AdobeSignatureTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVCCTab_VCC = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelVCC_UserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxVCC_UserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelVCC_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxVCC_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelVCC_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxVCC_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelVCC_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxVCC_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_VCCTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBillingApprovalTab_BillingApproval = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelBillingApproval_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxBillingApproval_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelBillingApproval_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxBillingApproval_NewPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelBillingApproval_ConfirmNewPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxBillingApproval_OldPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemPasswords_BillingApprovalTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Save = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.TabControlForm_Passwords, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Passwords.SuspendLayout()
            Me.TabControlPanelGoogleTab_Google.SuspendLayout()
            Me.TabControlPanelEmailTab_Email.SuspendLayout()
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.SuspendLayout()
            Me.TabControlPanelAdAssistTab_AdAssist.SuspendLayout()
            Me.TabControlPanelProofHQTab_ProofHQ.SuspendLayout()
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.SuspendLayout()
            Me.TabControlPanelVCCTab_VCC.SuspendLayout()
            Me.TabControlPanelBillingApprovalTab_BillingApproval.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlForm_Passwords
            '
            Me.TabControlForm_Passwords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Passwords.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Passwords.CanReorderTabs = False
            Me.TabControlForm_Passwords.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Passwords.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelGoogleTab_Google)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelEmailTab_Email)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelAdAssistTab_AdAssist)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelSugarCRMTTab_SugarCRMT)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelProofHQTab_ProofHQ)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelAdobeSignatureTab_AdobeSignature)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelVCCTab_VCC)
            Me.TabControlForm_Passwords.Controls.Add(Me.TabControlPanelBillingApprovalTab_BillingApproval)
            Me.TabControlForm_Passwords.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Passwords.Name = "TabControlForm_Passwords"
            Me.TabControlForm_Passwords.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Passwords.SelectedTabIndex = 0
            Me.TabControlForm_Passwords.Size = New System.Drawing.Size(668, 173)
            Me.TabControlForm_Passwords.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Passwords.TabIndex = 8
            Me.TabControlForm_Passwords.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_AdAssistTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_BillingApprovalTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_EmailTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_GoogleTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_SugarCRMTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_ProofHQTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_AdobeSignatureTab)
            Me.TabControlForm_Passwords.Tabs.Add(Me.TabItemPasswords_VCCTab)
            Me.TabControlForm_Passwords.Text = "TabControl1"
            '
            'TabControlPanelGoogleTab_Google
            '
            Me.TabControlPanelGoogleTab_Google.Controls.Add(Me.LabelGoogle_Note)
            Me.TabControlPanelGoogleTab_Google.Controls.Add(Me.LabelGoogle_GoogleServices)
            Me.TabControlPanelGoogleTab_Google.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGoogleTab_Google.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGoogleTab_Google.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGoogleTab_Google.Name = "TabControlPanelGoogleTab_Google"
            Me.TabControlPanelGoogleTab_Google.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGoogleTab_Google.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelGoogleTab_Google.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGoogleTab_Google.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGoogleTab_Google.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGoogleTab_Google.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGoogleTab_Google.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGoogleTab_Google.Style.GradientAngle = 90
            Me.TabControlPanelGoogleTab_Google.TabIndex = 33
            Me.TabControlPanelGoogleTab_Google.TabItem = Me.TabItemPasswords_GoogleTab
            '
            'LabelGoogle_Note
            '
            Me.LabelGoogle_Note.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGoogle_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGoogle_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGoogle_Note.Location = New System.Drawing.Point(307, 4)
            Me.LabelGoogle_Note.Name = "LabelGoogle_Note"
            Me.LabelGoogle_Note.Size = New System.Drawing.Size(357, 20)
            Me.LabelGoogle_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGoogle_Note.TabIndex = 11
            Me.LabelGoogle_Note.Text = "This will enable Gmail and Calendar."
            '
            'LabelGoogle_GoogleServices
            '
            Me.LabelGoogle_GoogleServices.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGoogle_GoogleServices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGoogle_GoogleServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGoogle_GoogleServices.Location = New System.Drawing.Point(4, 4)
            Me.LabelGoogle_GoogleServices.Name = "LabelGoogle_GoogleServices"
            Me.LabelGoogle_GoogleServices.Size = New System.Drawing.Size(297, 20)
            Me.LabelGoogle_GoogleServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGoogle_GoogleServices.TabIndex = 8
            Me.LabelGoogle_GoogleServices.Text = "Google Services are currently {0}. <a name=""{1}"">{1}</a>"
            Me.LabelGoogle_GoogleServices.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'TabItemPasswords_GoogleTab
            '
            Me.TabItemPasswords_GoogleTab.AttachedControl = Me.TabControlPanelGoogleTab_Google
            Me.TabItemPasswords_GoogleTab.Name = "TabItemPasswords_GoogleTab"
            Me.TabItemPasswords_GoogleTab.Text = "Google"
            '
            'TabControlPanelEmailTab_Email
            '
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_GoogleNote)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_GoogleServices)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_Email)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.TextBoxEmail_Email)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_OldPassword)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.TextBoxEmail_ConfirmNewPassword)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_NewPassword)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.TextBoxEmail_NewPassword)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.LabelEmail_ConfirmNewPassword)
            Me.TabControlPanelEmailTab_Email.Controls.Add(Me.TextBoxEmail_OldPassword)
            Me.TabControlPanelEmailTab_Email.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmailTab_Email.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmailTab_Email.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmailTab_Email.Name = "TabControlPanelEmailTab_Email"
            Me.TabControlPanelEmailTab_Email.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmailTab_Email.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelEmailTab_Email.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmailTab_Email.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmailTab_Email.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmailTab_Email.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmailTab_Email.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmailTab_Email.Style.GradientAngle = 90
            Me.TabControlPanelEmailTab_Email.TabIndex = 5
            Me.TabControlPanelEmailTab_Email.TabItem = Me.TabItemPasswords_EmailTab
            '
            'LabelEmail_GoogleNote
            '
            Me.LabelEmail_GoogleNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelEmail_GoogleNote.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_GoogleNote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_GoogleNote.Location = New System.Drawing.Point(512, 108)
            Me.LabelEmail_GoogleNote.Name = "LabelEmail_GoogleNote"
            Me.LabelEmail_GoogleNote.Size = New System.Drawing.Size(152, 20)
            Me.LabelEmail_GoogleNote.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_GoogleNote.TabIndex = 10
            Me.LabelEmail_GoogleNote.Text = "For Gmail users only"
            '
            'LabelEmail_GoogleServices
            '
            Me.LabelEmail_GoogleServices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_GoogleServices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_GoogleServices.Location = New System.Drawing.Point(134, 108)
            Me.LabelEmail_GoogleServices.Name = "LabelEmail_GoogleServices"
            Me.LabelEmail_GoogleServices.Size = New System.Drawing.Size(372, 20)
            Me.LabelEmail_GoogleServices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_GoogleServices.TabIndex = 9
            Me.LabelEmail_GoogleServices.Text = "Google Services are currently {0}. <a name=""{1}"">{1}</a>"
            Me.LabelEmail_GoogleServices.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'LabelEmail_Email
            '
            Me.LabelEmail_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_Email.Location = New System.Drawing.Point(4, 4)
            Me.LabelEmail_Email.Name = "LabelEmail_Email"
            Me.LabelEmail_Email.Size = New System.Drawing.Size(124, 20)
            Me.LabelEmail_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_Email.TabIndex = 0
            Me.LabelEmail_Email.Text = "Email:"
            '
            'TextBoxEmail_Email
            '
            Me.TextBoxEmail_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmail_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxEmail_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmail_Email.CheckSpellingOnValidate = False
            Me.TextBoxEmail_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmail_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmail_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmail_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmail_Email.FocusHighlightEnabled = True
            Me.TextBoxEmail_Email.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxEmail_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxEmail_Email.Name = "TextBoxEmail_Email"
            Me.TextBoxEmail_Email.SecurityEnabled = True
            Me.TextBoxEmail_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmail_Email.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxEmail_Email.StartingFolderName = Nothing
            Me.TextBoxEmail_Email.TabIndex = 1
            Me.TextBoxEmail_Email.TabOnEnter = True
            '
            'LabelEmail_OldPassword
            '
            Me.LabelEmail_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_OldPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelEmail_OldPassword.Name = "LabelEmail_OldPassword"
            Me.LabelEmail_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelEmail_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_OldPassword.TabIndex = 2
            Me.LabelEmail_OldPassword.Text = "Old Password:"
            '
            'TextBoxEmail_ConfirmNewPassword
            '
            Me.TextBoxEmail_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmail_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxEmail_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmail_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxEmail_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmail_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmail_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmail_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmail_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxEmail_ConfirmNewPassword.Location = New System.Drawing.Point(134, 82)
            Me.TextBoxEmail_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxEmail_ConfirmNewPassword.Name = "TextBoxEmail_ConfirmNewPassword"
            Me.TextBoxEmail_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxEmail_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmail_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxEmail_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxEmail_ConfirmNewPassword.TabIndex = 7
            Me.TextBoxEmail_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxEmail_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelEmail_NewPassword
            '
            Me.LabelEmail_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_NewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelEmail_NewPassword.Name = "LabelEmail_NewPassword"
            Me.LabelEmail_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelEmail_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_NewPassword.TabIndex = 4
            Me.LabelEmail_NewPassword.Text = "New Password:"
            '
            'TextBoxEmail_NewPassword
            '
            Me.TextBoxEmail_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmail_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxEmail_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmail_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxEmail_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmail_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmail_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmail_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmail_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxEmail_NewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxEmail_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxEmail_NewPassword.Name = "TextBoxEmail_NewPassword"
            Me.TextBoxEmail_NewPassword.SecurityEnabled = True
            Me.TextBoxEmail_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmail_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxEmail_NewPassword.StartingFolderName = Nothing
            Me.TextBoxEmail_NewPassword.TabIndex = 5
            Me.TextBoxEmail_NewPassword.TabOnEnter = True
            Me.TextBoxEmail_NewPassword.UseSystemPasswordChar = True
            '
            'LabelEmail_ConfirmNewPassword
            '
            Me.LabelEmail_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmail_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmail_ConfirmNewPassword.Location = New System.Drawing.Point(4, 82)
            Me.LabelEmail_ConfirmNewPassword.Name = "LabelEmail_ConfirmNewPassword"
            Me.LabelEmail_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelEmail_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmail_ConfirmNewPassword.TabIndex = 6
            Me.LabelEmail_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxEmail_OldPassword
            '
            Me.TextBoxEmail_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxEmail_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxEmail_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEmail_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxEmail_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEmail_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEmail_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEmail_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEmail_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxEmail_OldPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxEmail_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxEmail_OldPassword.Name = "TextBoxEmail_OldPassword"
            Me.TextBoxEmail_OldPassword.ReadOnly = True
            Me.TextBoxEmail_OldPassword.SecurityEnabled = True
            Me.TextBoxEmail_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEmail_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxEmail_OldPassword.StartingFolderName = Nothing
            Me.TextBoxEmail_OldPassword.TabIndex = 3
            Me.TextBoxEmail_OldPassword.TabOnEnter = True
            Me.TextBoxEmail_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_EmailTab
            '
            Me.TabItemPasswords_EmailTab.AttachedControl = Me.TabControlPanelEmailTab_Email
            Me.TabItemPasswords_EmailTab.Name = "TabItemPasswords_EmailTab"
            Me.TabItemPasswords_EmailTab.Text = "Email"
            '
            'TabControlPanelSugarCRMTTab_SugarCRMT
            '
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.LabelSugarCRM_UserName)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.TextBoxSugarCRM_UserName)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.LabelSugarCRM_OldPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.TextBoxSugarCRM_ConfirmNewPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.LabelSugarCRM_NewPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.TextBoxSugarCRM_NewPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.LabelSugarCRM_ConfirmNewPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Controls.Add(Me.TextBoxSugarCRM_OldPassword)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Name = "TabControlPanelSugarCRMTTab_SugarCRMT"
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.Style.GradientAngle = 90
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.TabIndex = 6
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.TabItem = Me.TabItemPasswords_SugarCRMTab
            '
            'LabelSugarCRM_UserName
            '
            Me.LabelSugarCRM_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSugarCRM_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSugarCRM_UserName.Location = New System.Drawing.Point(4, 4)
            Me.LabelSugarCRM_UserName.Name = "LabelSugarCRM_UserName"
            Me.LabelSugarCRM_UserName.Size = New System.Drawing.Size(124, 20)
            Me.LabelSugarCRM_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSugarCRM_UserName.TabIndex = 0
            Me.LabelSugarCRM_UserName.Text = "User Name:"
            '
            'TextBoxSugarCRM_UserName
            '
            Me.TextBoxSugarCRM_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSugarCRM_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSugarCRM_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSugarCRM_UserName.CheckSpellingOnValidate = False
            Me.TextBoxSugarCRM_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSugarCRM_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSugarCRM_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSugarCRM_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSugarCRM_UserName.FocusHighlightEnabled = True
            Me.TextBoxSugarCRM_UserName.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxSugarCRM_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSugarCRM_UserName.Name = "TextBoxSugarCRM_UserName"
            Me.TextBoxSugarCRM_UserName.SecurityEnabled = True
            Me.TextBoxSugarCRM_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSugarCRM_UserName.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxSugarCRM_UserName.StartingFolderName = Nothing
            Me.TextBoxSugarCRM_UserName.TabIndex = 1
            Me.TextBoxSugarCRM_UserName.TabOnEnter = True
            '
            'LabelSugarCRM_OldPassword
            '
            Me.LabelSugarCRM_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSugarCRM_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSugarCRM_OldPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelSugarCRM_OldPassword.Name = "LabelSugarCRM_OldPassword"
            Me.LabelSugarCRM_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelSugarCRM_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSugarCRM_OldPassword.TabIndex = 2
            Me.LabelSugarCRM_OldPassword.Text = "Old Password:"
            '
            'TextBoxSugarCRM_ConfirmNewPassword
            '
            Me.TextBoxSugarCRM_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSugarCRM_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSugarCRM_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSugarCRM_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxSugarCRM_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSugarCRM_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSugarCRM_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSugarCRM_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSugarCRM_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxSugarCRM_ConfirmNewPassword.Location = New System.Drawing.Point(134, 82)
            Me.TextBoxSugarCRM_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSugarCRM_ConfirmNewPassword.Name = "TextBoxSugarCRM_ConfirmNewPassword"
            Me.TextBoxSugarCRM_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxSugarCRM_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSugarCRM_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxSugarCRM_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxSugarCRM_ConfirmNewPassword.TabIndex = 7
            Me.TextBoxSugarCRM_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxSugarCRM_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelSugarCRM_NewPassword
            '
            Me.LabelSugarCRM_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSugarCRM_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSugarCRM_NewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelSugarCRM_NewPassword.Name = "LabelSugarCRM_NewPassword"
            Me.LabelSugarCRM_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelSugarCRM_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSugarCRM_NewPassword.TabIndex = 4
            Me.LabelSugarCRM_NewPassword.Text = "New Password:"
            '
            'TextBoxSugarCRM_NewPassword
            '
            Me.TextBoxSugarCRM_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSugarCRM_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSugarCRM_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSugarCRM_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxSugarCRM_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSugarCRM_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSugarCRM_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSugarCRM_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSugarCRM_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxSugarCRM_NewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxSugarCRM_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSugarCRM_NewPassword.Name = "TextBoxSugarCRM_NewPassword"
            Me.TextBoxSugarCRM_NewPassword.SecurityEnabled = True
            Me.TextBoxSugarCRM_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSugarCRM_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxSugarCRM_NewPassword.StartingFolderName = Nothing
            Me.TextBoxSugarCRM_NewPassword.TabIndex = 5
            Me.TextBoxSugarCRM_NewPassword.TabOnEnter = True
            Me.TextBoxSugarCRM_NewPassword.UseSystemPasswordChar = True
            '
            'LabelSugarCRM_ConfirmNewPassword
            '
            Me.LabelSugarCRM_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSugarCRM_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSugarCRM_ConfirmNewPassword.Location = New System.Drawing.Point(4, 82)
            Me.LabelSugarCRM_ConfirmNewPassword.Name = "LabelSugarCRM_ConfirmNewPassword"
            Me.LabelSugarCRM_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelSugarCRM_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSugarCRM_ConfirmNewPassword.TabIndex = 6
            Me.LabelSugarCRM_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxSugarCRM_OldPassword
            '
            Me.TextBoxSugarCRM_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSugarCRM_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSugarCRM_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSugarCRM_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxSugarCRM_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSugarCRM_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSugarCRM_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSugarCRM_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSugarCRM_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxSugarCRM_OldPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxSugarCRM_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSugarCRM_OldPassword.Name = "TextBoxSugarCRM_OldPassword"
            Me.TextBoxSugarCRM_OldPassword.ReadOnly = True
            Me.TextBoxSugarCRM_OldPassword.SecurityEnabled = True
            Me.TextBoxSugarCRM_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSugarCRM_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxSugarCRM_OldPassword.StartingFolderName = Nothing
            Me.TextBoxSugarCRM_OldPassword.TabIndex = 3
            Me.TextBoxSugarCRM_OldPassword.TabOnEnter = True
            Me.TextBoxSugarCRM_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_SugarCRMTab
            '
            Me.TabItemPasswords_SugarCRMTab.AttachedControl = Me.TabControlPanelSugarCRMTTab_SugarCRMT
            Me.TabItemPasswords_SugarCRMTab.Name = "TabItemPasswords_SugarCRMTab"
            Me.TabItemPasswords_SugarCRMTab.Text = "Sugar CRM"
            '
            'TabControlPanelAdAssistTab_AdAssist
            '
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.LabelAdAssist_OldPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.TextBoxAdAssist_ConfirmNewPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.LabelAdAssist_NewPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.TextBoxAdAssist_NewPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.LabelAdAssist_ConfirmNewPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.Controls.Add(Me.TextBoxAdAssist_OldPassword)
            Me.TabControlPanelAdAssistTab_AdAssist.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdAssistTab_AdAssist.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdAssistTab_AdAssist.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdAssistTab_AdAssist.Name = "TabControlPanelAdAssistTab_AdAssist"
            Me.TabControlPanelAdAssistTab_AdAssist.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdAssistTab_AdAssist.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelAdAssistTab_AdAssist.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdAssistTab_AdAssist.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdAssistTab_AdAssist.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdAssistTab_AdAssist.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdAssistTab_AdAssist.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdAssistTab_AdAssist.Style.GradientAngle = 90
            Me.TabControlPanelAdAssistTab_AdAssist.TabIndex = 2
            Me.TabControlPanelAdAssistTab_AdAssist.TabItem = Me.TabItemPasswords_AdAssistTab
            '
            'LabelAdAssist_OldPassword
            '
            Me.LabelAdAssist_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdAssist_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdAssist_OldPassword.Location = New System.Drawing.Point(4, 4)
            Me.LabelAdAssist_OldPassword.Name = "LabelAdAssist_OldPassword"
            Me.LabelAdAssist_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdAssist_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdAssist_OldPassword.TabIndex = 6
            Me.LabelAdAssist_OldPassword.Text = "Old Password:"
            '
            'TextBoxAdAssist_ConfirmNewPassword
            '
            Me.TextBoxAdAssist_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdAssist_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdAssist_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdAssist_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdAssist_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdAssist_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdAssist_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdAssist_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdAssist_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxAdAssist_ConfirmNewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxAdAssist_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdAssist_ConfirmNewPassword.Name = "TextBoxAdAssist_ConfirmNewPassword"
            Me.TextBoxAdAssist_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxAdAssist_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdAssist_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdAssist_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxAdAssist_ConfirmNewPassword.TabIndex = 11
            Me.TextBoxAdAssist_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxAdAssist_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelAdAssist_NewPassword
            '
            Me.LabelAdAssist_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdAssist_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdAssist_NewPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelAdAssist_NewPassword.Name = "LabelAdAssist_NewPassword"
            Me.LabelAdAssist_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdAssist_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdAssist_NewPassword.TabIndex = 8
            Me.LabelAdAssist_NewPassword.Text = "New Password:"
            '
            'TextBoxAdAssist_NewPassword
            '
            Me.TextBoxAdAssist_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdAssist_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdAssist_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdAssist_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdAssist_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdAssist_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdAssist_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdAssist_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdAssist_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxAdAssist_NewPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxAdAssist_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdAssist_NewPassword.Name = "TextBoxAdAssist_NewPassword"
            Me.TextBoxAdAssist_NewPassword.SecurityEnabled = True
            Me.TextBoxAdAssist_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdAssist_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdAssist_NewPassword.StartingFolderName = Nothing
            Me.TextBoxAdAssist_NewPassword.TabIndex = 9
            Me.TextBoxAdAssist_NewPassword.TabOnEnter = True
            Me.TextBoxAdAssist_NewPassword.UseSystemPasswordChar = True
            '
            'LabelAdAssist_ConfirmNewPassword
            '
            Me.LabelAdAssist_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdAssist_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdAssist_ConfirmNewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelAdAssist_ConfirmNewPassword.Name = "LabelAdAssist_ConfirmNewPassword"
            Me.LabelAdAssist_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdAssist_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdAssist_ConfirmNewPassword.TabIndex = 10
            Me.LabelAdAssist_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxAdAssist_OldPassword
            '
            Me.TextBoxAdAssist_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdAssist_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdAssist_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdAssist_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdAssist_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdAssist_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdAssist_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdAssist_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdAssist_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxAdAssist_OldPassword.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxAdAssist_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdAssist_OldPassword.Name = "TextBoxAdAssist_OldPassword"
            Me.TextBoxAdAssist_OldPassword.ReadOnly = True
            Me.TextBoxAdAssist_OldPassword.SecurityEnabled = True
            Me.TextBoxAdAssist_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdAssist_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdAssist_OldPassword.StartingFolderName = Nothing
            Me.TextBoxAdAssist_OldPassword.TabIndex = 7
            Me.TextBoxAdAssist_OldPassword.TabOnEnter = True
            Me.TextBoxAdAssist_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_AdAssistTab
            '
            Me.TabItemPasswords_AdAssistTab.AttachedControl = Me.TabControlPanelAdAssistTab_AdAssist
            Me.TabItemPasswords_AdAssistTab.Name = "TabItemPasswords_AdAssistTab"
            Me.TabItemPasswords_AdAssistTab.Text = "AdAssist"
            '
            'TabControlPanelProofHQTab_ProofHQ
            '
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.LabelProofHQ_UserName)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.TextBoxProofHQ_UserName)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.LabelProofHQ_OldPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.TextBoxProofHQ_ConfirmNewPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.LabelProofHQ_NewPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.TextBoxProofHQ_NewPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.LabelProofHQ_ConfirmNewPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.Controls.Add(Me.TextBoxProofHQ_OldPassword)
            Me.TabControlPanelProofHQTab_ProofHQ.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProofHQTab_ProofHQ.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProofHQTab_ProofHQ.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProofHQTab_ProofHQ.Name = "TabControlPanelProofHQTab_ProofHQ"
            Me.TabControlPanelProofHQTab_ProofHQ.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProofHQTab_ProofHQ.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelProofHQTab_ProofHQ.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProofHQTab_ProofHQ.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProofHQTab_ProofHQ.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProofHQTab_ProofHQ.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProofHQTab_ProofHQ.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProofHQTab_ProofHQ.Style.GradientAngle = 90
            Me.TabControlPanelProofHQTab_ProofHQ.TabIndex = 7
            Me.TabControlPanelProofHQTab_ProofHQ.TabItem = Me.TabItemPasswords_ProofHQTab
            '
            'LabelProofHQ_UserName
            '
            Me.LabelProofHQ_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProofHQ_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProofHQ_UserName.Location = New System.Drawing.Point(4, 4)
            Me.LabelProofHQ_UserName.Name = "LabelProofHQ_UserName"
            Me.LabelProofHQ_UserName.Size = New System.Drawing.Size(124, 20)
            Me.LabelProofHQ_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProofHQ_UserName.TabIndex = 0
            Me.LabelProofHQ_UserName.Text = "User Name:"
            '
            'TextBoxProofHQ_UserName
            '
            Me.TextBoxProofHQ_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxProofHQ_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxProofHQ_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProofHQ_UserName.CheckSpellingOnValidate = False
            Me.TextBoxProofHQ_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProofHQ_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProofHQ_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProofHQ_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProofHQ_UserName.FocusHighlightEnabled = True
            Me.TextBoxProofHQ_UserName.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxProofHQ_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxProofHQ_UserName.Name = "TextBoxProofHQ_UserName"
            Me.TextBoxProofHQ_UserName.SecurityEnabled = True
            Me.TextBoxProofHQ_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProofHQ_UserName.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxProofHQ_UserName.StartingFolderName = Nothing
            Me.TextBoxProofHQ_UserName.TabIndex = 1
            Me.TextBoxProofHQ_UserName.TabOnEnter = True
            '
            'LabelProofHQ_OldPassword
            '
            Me.LabelProofHQ_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProofHQ_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProofHQ_OldPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelProofHQ_OldPassword.Name = "LabelProofHQ_OldPassword"
            Me.LabelProofHQ_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelProofHQ_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProofHQ_OldPassword.TabIndex = 2
            Me.LabelProofHQ_OldPassword.Text = "Old Password:"
            '
            'TextBoxProofHQ_ConfirmNewPassword
            '
            Me.TextBoxProofHQ_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxProofHQ_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxProofHQ_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProofHQ_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxProofHQ_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProofHQ_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProofHQ_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProofHQ_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProofHQ_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxProofHQ_ConfirmNewPassword.Location = New System.Drawing.Point(134, 82)
            Me.TextBoxProofHQ_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxProofHQ_ConfirmNewPassword.Name = "TextBoxProofHQ_ConfirmNewPassword"
            Me.TextBoxProofHQ_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxProofHQ_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProofHQ_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxProofHQ_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxProofHQ_ConfirmNewPassword.TabIndex = 7
            Me.TextBoxProofHQ_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxProofHQ_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelProofHQ_NewPassword
            '
            Me.LabelProofHQ_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProofHQ_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProofHQ_NewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelProofHQ_NewPassword.Name = "LabelProofHQ_NewPassword"
            Me.LabelProofHQ_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelProofHQ_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProofHQ_NewPassword.TabIndex = 4
            Me.LabelProofHQ_NewPassword.Text = "New Password:"
            '
            'TextBoxProofHQ_NewPassword
            '
            Me.TextBoxProofHQ_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxProofHQ_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxProofHQ_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProofHQ_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxProofHQ_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProofHQ_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProofHQ_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProofHQ_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProofHQ_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxProofHQ_NewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxProofHQ_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxProofHQ_NewPassword.Name = "TextBoxProofHQ_NewPassword"
            Me.TextBoxProofHQ_NewPassword.SecurityEnabled = True
            Me.TextBoxProofHQ_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProofHQ_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxProofHQ_NewPassword.StartingFolderName = Nothing
            Me.TextBoxProofHQ_NewPassword.TabIndex = 5
            Me.TextBoxProofHQ_NewPassword.TabOnEnter = True
            Me.TextBoxProofHQ_NewPassword.UseSystemPasswordChar = True
            '
            'LabelProofHQ_ConfirmNewPassword
            '
            Me.LabelProofHQ_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProofHQ_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProofHQ_ConfirmNewPassword.Location = New System.Drawing.Point(4, 82)
            Me.LabelProofHQ_ConfirmNewPassword.Name = "LabelProofHQ_ConfirmNewPassword"
            Me.LabelProofHQ_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelProofHQ_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProofHQ_ConfirmNewPassword.TabIndex = 6
            Me.LabelProofHQ_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxProofHQ_OldPassword
            '
            Me.TextBoxProofHQ_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxProofHQ_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxProofHQ_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProofHQ_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxProofHQ_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProofHQ_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxProofHQ_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProofHQ_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProofHQ_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxProofHQ_OldPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxProofHQ_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxProofHQ_OldPassword.Name = "TextBoxProofHQ_OldPassword"
            Me.TextBoxProofHQ_OldPassword.ReadOnly = True
            Me.TextBoxProofHQ_OldPassword.SecurityEnabled = True
            Me.TextBoxProofHQ_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProofHQ_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxProofHQ_OldPassword.StartingFolderName = Nothing
            Me.TextBoxProofHQ_OldPassword.TabIndex = 3
            Me.TextBoxProofHQ_OldPassword.TabOnEnter = True
            Me.TextBoxProofHQ_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_ProofHQTab
            '
            Me.TabItemPasswords_ProofHQTab.AttachedControl = Me.TabControlPanelProofHQTab_ProofHQ
            Me.TabItemPasswords_ProofHQTab.Name = "TabItemPasswords_ProofHQTab"
            Me.TabItemPasswords_ProofHQTab.Text = "ProofHQ"
            '
            'TabControlPanelAdobeSignatureTab_AdobeSignature
            '
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.LabelAdobeSignature_OldPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.TextBoxAdobeSignature_ConfirmNewPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.LabelAdobeSignature_NewPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.TextBoxAdobeSignature_NewPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.LabelAdobeSignature_ConfirmNewPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Controls.Add(Me.TextBoxAdobeSignature_OldPassword)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Name = "TabControlPanelAdobeSignatureTab_AdobeSignature"
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.Style.GradientAngle = 90
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.TabIndex = 8
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.TabItem = Me.TabItemPasswords_AdobeSignatureTab
            '
            'LabelAdobeSignature_OldPassword
            '
            Me.LabelAdobeSignature_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdobeSignature_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdobeSignature_OldPassword.Location = New System.Drawing.Point(4, 4)
            Me.LabelAdobeSignature_OldPassword.Name = "LabelAdobeSignature_OldPassword"
            Me.LabelAdobeSignature_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdobeSignature_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdobeSignature_OldPassword.TabIndex = 0
            Me.LabelAdobeSignature_OldPassword.Text = "Old Password:"
            '
            'TextBoxAdobeSignature_ConfirmNewPassword
            '
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdobeSignature_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdobeSignature_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdobeSignature_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdobeSignature_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdobeSignature_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdobeSignature_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxAdobeSignature_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Name = "TextBoxAdobeSignature_ConfirmNewPassword"
            Me.TextBoxAdobeSignature_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxAdobeSignature_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdobeSignature_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdobeSignature_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxAdobeSignature_ConfirmNewPassword.TabIndex = 5
            Me.TextBoxAdobeSignature_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxAdobeSignature_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelAdobeSignature_NewPassword
            '
            Me.LabelAdobeSignature_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdobeSignature_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdobeSignature_NewPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelAdobeSignature_NewPassword.Name = "LabelAdobeSignature_NewPassword"
            Me.LabelAdobeSignature_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdobeSignature_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdobeSignature_NewPassword.TabIndex = 2
            Me.LabelAdobeSignature_NewPassword.Text = "New Password:"
            '
            'TextBoxAdobeSignature_NewPassword
            '
            Me.TextBoxAdobeSignature_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdobeSignature_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdobeSignature_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdobeSignature_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdobeSignature_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdobeSignature_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdobeSignature_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdobeSignature_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdobeSignature_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxAdobeSignature_NewPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxAdobeSignature_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdobeSignature_NewPassword.Name = "TextBoxAdobeSignature_NewPassword"
            Me.TextBoxAdobeSignature_NewPassword.SecurityEnabled = True
            Me.TextBoxAdobeSignature_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdobeSignature_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdobeSignature_NewPassword.StartingFolderName = Nothing
            Me.TextBoxAdobeSignature_NewPassword.TabIndex = 3
            Me.TextBoxAdobeSignature_NewPassword.TabOnEnter = True
            Me.TextBoxAdobeSignature_NewPassword.UseSystemPasswordChar = True
            '
            'LabelAdobeSignature_ConfirmNewPassword
            '
            Me.LabelAdobeSignature_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAdobeSignature_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAdobeSignature_ConfirmNewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelAdobeSignature_ConfirmNewPassword.Name = "LabelAdobeSignature_ConfirmNewPassword"
            Me.LabelAdobeSignature_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelAdobeSignature_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAdobeSignature_ConfirmNewPassword.TabIndex = 4
            Me.LabelAdobeSignature_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxAdobeSignature_OldPassword
            '
            Me.TextBoxAdobeSignature_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxAdobeSignature_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxAdobeSignature_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAdobeSignature_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxAdobeSignature_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAdobeSignature_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAdobeSignature_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAdobeSignature_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAdobeSignature_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxAdobeSignature_OldPassword.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxAdobeSignature_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxAdobeSignature_OldPassword.Name = "TextBoxAdobeSignature_OldPassword"
            Me.TextBoxAdobeSignature_OldPassword.ReadOnly = True
            Me.TextBoxAdobeSignature_OldPassword.SecurityEnabled = True
            Me.TextBoxAdobeSignature_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAdobeSignature_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxAdobeSignature_OldPassword.StartingFolderName = Nothing
            Me.TextBoxAdobeSignature_OldPassword.TabIndex = 1
            Me.TextBoxAdobeSignature_OldPassword.TabOnEnter = True
            Me.TextBoxAdobeSignature_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_AdobeSignatureTab
            '
            Me.TabItemPasswords_AdobeSignatureTab.AttachedControl = Me.TabControlPanelAdobeSignatureTab_AdobeSignature
            Me.TabItemPasswords_AdobeSignatureTab.Name = "TabItemPasswords_AdobeSignatureTab"
            Me.TabItemPasswords_AdobeSignatureTab.Text = "Adobe Signature"
            '
            'TabControlPanelVCCTab_VCC
            '
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.LabelVCC_UserName)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.TextBoxVCC_UserName)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.LabelVCC_OldPassword)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.TextBoxVCC_ConfirmNewPassword)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.LabelVCC_NewPassword)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.TextBoxVCC_NewPassword)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.LabelVCC_ConfirmNewPassword)
            Me.TabControlPanelVCCTab_VCC.Controls.Add(Me.TextBoxVCC_OldPassword)
            Me.TabControlPanelVCCTab_VCC.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVCCTab_VCC.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVCCTab_VCC.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVCCTab_VCC.Name = "TabControlPanelVCCTab_VCC"
            Me.TabControlPanelVCCTab_VCC.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVCCTab_VCC.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelVCCTab_VCC.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVCCTab_VCC.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVCCTab_VCC.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVCCTab_VCC.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVCCTab_VCC.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVCCTab_VCC.Style.GradientAngle = 90
            Me.TabControlPanelVCCTab_VCC.TabIndex = 9
            Me.TabControlPanelVCCTab_VCC.TabItem = Me.TabItemPasswords_VCCTab
            '
            'LabelVCC_UserName
            '
            Me.LabelVCC_UserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVCC_UserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVCC_UserName.Location = New System.Drawing.Point(4, 4)
            Me.LabelVCC_UserName.Name = "LabelVCC_UserName"
            Me.LabelVCC_UserName.Size = New System.Drawing.Size(124, 20)
            Me.LabelVCC_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVCC_UserName.TabIndex = 8
            Me.LabelVCC_UserName.Text = "User Name:"
            '
            'TextBoxVCC_UserName
            '
            Me.TextBoxVCC_UserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxVCC_UserName.Border.Class = "TextBoxBorder"
            Me.TextBoxVCC_UserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVCC_UserName.CheckSpellingOnValidate = False
            Me.TextBoxVCC_UserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVCC_UserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVCC_UserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVCC_UserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVCC_UserName.FocusHighlightEnabled = True
            Me.TextBoxVCC_UserName.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxVCC_UserName.MaxFileSize = CType(0, Long)
            Me.TextBoxVCC_UserName.Name = "TextBoxVCC_UserName"
            Me.TextBoxVCC_UserName.SecurityEnabled = True
            Me.TextBoxVCC_UserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVCC_UserName.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxVCC_UserName.StartingFolderName = Nothing
            Me.TextBoxVCC_UserName.TabIndex = 9
            Me.TextBoxVCC_UserName.TabOnEnter = True
            '
            'LabelVCC_OldPassword
            '
            Me.LabelVCC_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVCC_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVCC_OldPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelVCC_OldPassword.Name = "LabelVCC_OldPassword"
            Me.LabelVCC_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelVCC_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVCC_OldPassword.TabIndex = 10
            Me.LabelVCC_OldPassword.Text = "Old Password:"
            '
            'TextBoxVCC_ConfirmNewPassword
            '
            Me.TextBoxVCC_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxVCC_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxVCC_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVCC_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxVCC_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVCC_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVCC_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVCC_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVCC_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxVCC_ConfirmNewPassword.Location = New System.Drawing.Point(134, 82)
            Me.TextBoxVCC_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxVCC_ConfirmNewPassword.Name = "TextBoxVCC_ConfirmNewPassword"
            Me.TextBoxVCC_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxVCC_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVCC_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxVCC_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxVCC_ConfirmNewPassword.TabIndex = 15
            Me.TextBoxVCC_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxVCC_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelVCC_NewPassword
            '
            Me.LabelVCC_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVCC_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVCC_NewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelVCC_NewPassword.Name = "LabelVCC_NewPassword"
            Me.LabelVCC_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelVCC_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVCC_NewPassword.TabIndex = 12
            Me.LabelVCC_NewPassword.Text = "New Password:"
            '
            'TextBoxVCC_NewPassword
            '
            Me.TextBoxVCC_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxVCC_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxVCC_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVCC_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxVCC_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVCC_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVCC_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVCC_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVCC_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxVCC_NewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxVCC_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxVCC_NewPassword.Name = "TextBoxVCC_NewPassword"
            Me.TextBoxVCC_NewPassword.SecurityEnabled = True
            Me.TextBoxVCC_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVCC_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxVCC_NewPassword.StartingFolderName = Nothing
            Me.TextBoxVCC_NewPassword.TabIndex = 13
            Me.TextBoxVCC_NewPassword.TabOnEnter = True
            Me.TextBoxVCC_NewPassword.UseSystemPasswordChar = True
            '
            'LabelVCC_ConfirmNewPassword
            '
            Me.LabelVCC_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVCC_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVCC_ConfirmNewPassword.Location = New System.Drawing.Point(4, 82)
            Me.LabelVCC_ConfirmNewPassword.Name = "LabelVCC_ConfirmNewPassword"
            Me.LabelVCC_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelVCC_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVCC_ConfirmNewPassword.TabIndex = 14
            Me.LabelVCC_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxVCC_OldPassword
            '
            Me.TextBoxVCC_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxVCC_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxVCC_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVCC_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxVCC_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVCC_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVCC_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVCC_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVCC_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxVCC_OldPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxVCC_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxVCC_OldPassword.Name = "TextBoxVCC_OldPassword"
            Me.TextBoxVCC_OldPassword.ReadOnly = True
            Me.TextBoxVCC_OldPassword.SecurityEnabled = True
            Me.TextBoxVCC_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVCC_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxVCC_OldPassword.StartingFolderName = Nothing
            Me.TextBoxVCC_OldPassword.TabIndex = 11
            Me.TextBoxVCC_OldPassword.TabOnEnter = True
            Me.TextBoxVCC_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_VCCTab
            '
            Me.TabItemPasswords_VCCTab.AttachedControl = Me.TabControlPanelVCCTab_VCC
            Me.TabItemPasswords_VCCTab.Name = "TabItemPasswords_VCCTab"
            Me.TabItemPasswords_VCCTab.Text = "VCC"
            '
            'TabControlPanelBillingApprovalTab_BillingApproval
            '
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.LabelBillingApproval_OldPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.TextBoxBillingApproval_ConfirmNewPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.LabelBillingApproval_NewPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.TextBoxBillingApproval_NewPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.LabelBillingApproval_ConfirmNewPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Controls.Add(Me.TextBoxBillingApproval_OldPassword)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Name = "TabControlPanelBillingApprovalTab_BillingApproval"
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Size = New System.Drawing.Size(668, 146)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.Style.GradientAngle = 90
            Me.TabControlPanelBillingApprovalTab_BillingApproval.TabIndex = 3
            Me.TabControlPanelBillingApprovalTab_BillingApproval.TabItem = Me.TabItemPasswords_BillingApprovalTab
            '
            'LabelBillingApproval_OldPassword
            '
            Me.LabelBillingApproval_OldPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingApproval_OldPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingApproval_OldPassword.Location = New System.Drawing.Point(4, 4)
            Me.LabelBillingApproval_OldPassword.Name = "LabelBillingApproval_OldPassword"
            Me.LabelBillingApproval_OldPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelBillingApproval_OldPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingApproval_OldPassword.TabIndex = 12
            Me.LabelBillingApproval_OldPassword.Text = "Old Password:"
            '
            'TextBoxBillingApproval_ConfirmNewPassword
            '
            Me.TextBoxBillingApproval_ConfirmNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxBillingApproval_ConfirmNewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingApproval_ConfirmNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingApproval_ConfirmNewPassword.CheckSpellingOnValidate = False
            Me.TextBoxBillingApproval_ConfirmNewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingApproval_ConfirmNewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingApproval_ConfirmNewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingApproval_ConfirmNewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingApproval_ConfirmNewPassword.FocusHighlightEnabled = True
            Me.TextBoxBillingApproval_ConfirmNewPassword.Location = New System.Drawing.Point(134, 56)
            Me.TextBoxBillingApproval_ConfirmNewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingApproval_ConfirmNewPassword.Name = "TextBoxBillingApproval_ConfirmNewPassword"
            Me.TextBoxBillingApproval_ConfirmNewPassword.SecurityEnabled = True
            Me.TextBoxBillingApproval_ConfirmNewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingApproval_ConfirmNewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxBillingApproval_ConfirmNewPassword.StartingFolderName = Nothing
            Me.TextBoxBillingApproval_ConfirmNewPassword.TabIndex = 17
            Me.TextBoxBillingApproval_ConfirmNewPassword.TabOnEnter = True
            Me.TextBoxBillingApproval_ConfirmNewPassword.UseSystemPasswordChar = True
            '
            'LabelBillingApproval_NewPassword
            '
            Me.LabelBillingApproval_NewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingApproval_NewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingApproval_NewPassword.Location = New System.Drawing.Point(4, 30)
            Me.LabelBillingApproval_NewPassword.Name = "LabelBillingApproval_NewPassword"
            Me.LabelBillingApproval_NewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelBillingApproval_NewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingApproval_NewPassword.TabIndex = 14
            Me.LabelBillingApproval_NewPassword.Text = "New Password:"
            '
            'TextBoxBillingApproval_NewPassword
            '
            Me.TextBoxBillingApproval_NewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxBillingApproval_NewPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingApproval_NewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingApproval_NewPassword.CheckSpellingOnValidate = False
            Me.TextBoxBillingApproval_NewPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingApproval_NewPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingApproval_NewPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingApproval_NewPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingApproval_NewPassword.FocusHighlightEnabled = True
            Me.TextBoxBillingApproval_NewPassword.Location = New System.Drawing.Point(134, 30)
            Me.TextBoxBillingApproval_NewPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingApproval_NewPassword.Name = "TextBoxBillingApproval_NewPassword"
            Me.TextBoxBillingApproval_NewPassword.SecurityEnabled = True
            Me.TextBoxBillingApproval_NewPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingApproval_NewPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxBillingApproval_NewPassword.StartingFolderName = Nothing
            Me.TextBoxBillingApproval_NewPassword.TabIndex = 15
            Me.TextBoxBillingApproval_NewPassword.TabOnEnter = True
            Me.TextBoxBillingApproval_NewPassword.UseSystemPasswordChar = True
            '
            'LabelBillingApproval_ConfirmNewPassword
            '
            Me.LabelBillingApproval_ConfirmNewPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingApproval_ConfirmNewPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingApproval_ConfirmNewPassword.Location = New System.Drawing.Point(4, 56)
            Me.LabelBillingApproval_ConfirmNewPassword.Name = "LabelBillingApproval_ConfirmNewPassword"
            Me.LabelBillingApproval_ConfirmNewPassword.Size = New System.Drawing.Size(124, 20)
            Me.LabelBillingApproval_ConfirmNewPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingApproval_ConfirmNewPassword.TabIndex = 16
            Me.LabelBillingApproval_ConfirmNewPassword.Text = "Confirm New Password:"
            '
            'TextBoxBillingApproval_OldPassword
            '
            Me.TextBoxBillingApproval_OldPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxBillingApproval_OldPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingApproval_OldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingApproval_OldPassword.CheckSpellingOnValidate = False
            Me.TextBoxBillingApproval_OldPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingApproval_OldPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingApproval_OldPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingApproval_OldPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingApproval_OldPassword.FocusHighlightEnabled = True
            Me.TextBoxBillingApproval_OldPassword.Location = New System.Drawing.Point(134, 4)
            Me.TextBoxBillingApproval_OldPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingApproval_OldPassword.Name = "TextBoxBillingApproval_OldPassword"
            Me.TextBoxBillingApproval_OldPassword.ReadOnly = True
            Me.TextBoxBillingApproval_OldPassword.SecurityEnabled = True
            Me.TextBoxBillingApproval_OldPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingApproval_OldPassword.Size = New System.Drawing.Size(530, 20)
            Me.TextBoxBillingApproval_OldPassword.StartingFolderName = Nothing
            Me.TextBoxBillingApproval_OldPassword.TabIndex = 13
            Me.TextBoxBillingApproval_OldPassword.TabOnEnter = True
            Me.TextBoxBillingApproval_OldPassword.UseSystemPasswordChar = True
            '
            'TabItemPasswords_BillingApprovalTab
            '
            Me.TabItemPasswords_BillingApprovalTab.AttachedControl = Me.TabControlPanelBillingApprovalTab_BillingApproval
            Me.TabItemPasswords_BillingApprovalTab.Name = "TabItemPasswords_BillingApprovalTab"
            Me.TabItemPasswords_BillingApprovalTab.Text = "Billing Approval"
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(605, 191)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 7
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Save
            '
            Me.ButtonForm_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Save.Location = New System.Drawing.Point(524, 191)
            Me.ButtonForm_Save.Name = "ButtonForm_Save"
            Me.ButtonForm_Save.SecurityEnabled = True
            Me.ButtonForm_Save.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Save.TabIndex = 6
            Me.ButtonForm_Save.Text = "Save"
            '
            'ChangePasswordDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(692, 223)
            Me.ControlBox = False
            Me.Controls.Add(Me.TabControlForm_Passwords)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.ButtonForm_Save)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangePasswordDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Change Password"
            CType(Me.TabControlForm_Passwords, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Passwords.ResumeLayout(False)
            Me.TabControlPanelGoogleTab_Google.ResumeLayout(False)
            Me.TabControlPanelEmailTab_Email.ResumeLayout(False)
            Me.TabControlPanelSugarCRMTTab_SugarCRMT.ResumeLayout(False)
            Me.TabControlPanelAdAssistTab_AdAssist.ResumeLayout(False)
            Me.TabControlPanelProofHQTab_ProofHQ.ResumeLayout(False)
            Me.TabControlPanelAdobeSignatureTab_AdobeSignature.ResumeLayout(False)
            Me.TabControlPanelVCCTab_VCC.ResumeLayout(False)
            Me.TabControlPanelBillingApprovalTab_BillingApproval.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Save As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_Passwords As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        'Friend WithEvents TabControlPanelQuoteApprovalTab_QuoteApproval As DevComponents.DotNetBar.TabControlPanel
        'Friend WithEvents LabelQuoteApproval_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        'Friend WithEvents TextBoxQuoteApproval_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        'Friend WithEvents LabelQuoteApproval_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        'Friend WithEvents TextBoxQuoteApproval_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        'Friend WithEvents LabelQuoteApproval_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        'Friend WithEvents TextBoxQuoteApproval_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        'Friend WithEvents TabItemPasswords_QuoteApprovalTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBillingApprovalTab_BillingApproval As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelBillingApproval_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingApproval_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelBillingApproval_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingApproval_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelBillingApproval_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingApproval_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_BillingApprovalTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAdAssistTab_AdAssist As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelAdAssist_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdAssist_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAdAssist_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdAssist_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAdAssist_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdAssist_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_AdAssistTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEmailTab_Email As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelEmail_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmail_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmail_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmail_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelEmail_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmail_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_EmailTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSugarCRMTTab_SugarCRMT As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelSugarCRM_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSugarCRM_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSugarCRM_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSugarCRM_NewPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSugarCRM_ConfirmNewPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSugarCRM_OldPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_SugarCRMTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelEmail_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxEmail_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSugarCRM_UserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSugarCRM_UserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlPanelProofHQTab_ProofHQ As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelProofHQ_UserName As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProofHQ_UserName As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelProofHQ_OldPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProofHQ_ConfirmNewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelProofHQ_NewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProofHQ_NewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelProofHQ_ConfirmNewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxProofHQ_OldPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_ProofHQTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAdobeSignatureTab_AdobeSignature As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelAdobeSignature_OldPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdobeSignature_ConfirmNewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAdobeSignature_NewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdobeSignature_NewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAdobeSignature_ConfirmNewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAdobeSignature_OldPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_AdobeSignatureTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVCCTab_VCC As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelVCC_UserName As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxVCC_UserName As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelVCC_OldPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxVCC_ConfirmNewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelVCC_NewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxVCC_NewPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelVCC_ConfirmNewPassword As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxVCC_OldPassword As WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemPasswords_VCCTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelEmail_GoogleServices As WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelGoogleTab_Google As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelGoogle_Note As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGoogle_GoogleServices As WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemPasswords_GoogleTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelEmail_GoogleNote As WinForm.Presentation.Controls.Label
    End Class

End Namespace
