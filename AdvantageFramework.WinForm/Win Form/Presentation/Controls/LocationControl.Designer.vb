Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LocationControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.TextBoxRightSection_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRightSection_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRightSection_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRightSection_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRightSection_ID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRightSection_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_ID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.AddressControlRightSection_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.GroupBoxLogos_HeaderLogoSelection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ButtonHeaderLogo_LandscapeDelete = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonHeaderLogo_LandscapeSelect = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonHeaderLogo_PortraitDelete = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonHeaderLogo_PortraitSelect = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.RadioButtonControlHeaderLogoSelection_Hide = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlHeaderLogoSelection_Show = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelHeaderLogoSelection_LogoProperties = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PictureBoxHeaderLogoSelection_Landscape = New System.Windows.Forms.PictureBox()
            Me.LabelHeaderLogoSelection_LandscapeNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLogoSelection_PortraitNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxHeaderLogoSelection_Landscape = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelHeaderLogoSelection_Landscape = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderLogoSelection_Portrait = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxHeaderLogoSelection_Portrait = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.PictureBoxHeaderLogoSelection_Portrait = New System.Windows.Forms.PictureBox()
            Me.TabControlLocation_LocationDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelLogoTab_Logo = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxLogos_FooterLogoSelection = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ButtonFooterLogo_LandscapeDelete = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonFooterLogo_LandscapeSelect = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonFooterLogo_PortraitDelete = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonFooterLogo_PortraitSelect = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.RadioButtonControlFooterLogoSelection_Hide = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlFooterLogoSelection_Show = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelFooterLogoSelection_LogoProperties = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PictureBoxFooterLogoSelection_Landscape = New System.Windows.Forms.PictureBox()
            Me.LabelFooterLogoSelection_LandscapeNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelFooterLogoSelection_PortraitNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxFooterLogoSelection_Landscape = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelFooterLogoSelection_Landscape = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelFooterLogoSelection_Portrait = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxFooterLogoSelection_Portrait = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.PictureBoxFooterLogoSelection_Portrait = New System.Windows.Forms.PictureBox()
            Me.TabItemLocationDetails_LogoTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInformationTab_Information = New DevComponents.DotNetBar.TabControlPanel()
            Me.AdvTreeInformation_PrintSpecs = New AdvantageFramework.WinForm.Presentation.Controls.AdvTree()
            Me.NodePrintSpecs_PrintHeader = New DevComponents.AdvTree.Node()
            Me.NodePrintSpecs_PrintFooter = New DevComponents.AdvTree.Node()
            Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
            Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
            Me.TabItemLocationDetails_InformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.GroupBoxLogos_HeaderLogoSelection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLogos_HeaderLogoSelection.SuspendLayout()
            CType(Me.PictureBoxHeaderLogoSelection_Landscape, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxHeaderLogoSelection_Portrait, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlLocation_LocationDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlLocation_LocationDetails.SuspendLayout()
            Me.TabControlPanelLogoTab_Logo.SuspendLayout()
            CType(Me.GroupBoxLogos_FooterLogoSelection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLogos_FooterLogoSelection.SuspendLayout()
            CType(Me.PictureBoxFooterLogoSelection_Landscape, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxFooterLogoSelection_Portrait, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelInformationTab_Information.SuspendLayout()
            CType(Me.AdvTreeInformation_PrintSpecs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TextBoxRightSection_Fax
            '
            Me.TextBoxRightSection_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Fax.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Fax.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Fax.Location = New System.Drawing.Point(254, 81)
            Me.TextBoxRightSection_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Fax.Name = "TextBoxRightSection_Fax"
            Me.TextBoxRightSection_Fax.SecurityEnabled = True
            Me.TextBoxRightSection_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Fax.Size = New System.Drawing.Size(156, 20)
            Me.TextBoxRightSection_Fax.StartingFolderName = Nothing
            Me.TextBoxRightSection_Fax.TabIndex = 9
            Me.TextBoxRightSection_Fax.TabOnEnter = True
            '
            'TextBoxRightSection_Phone
            '
            '
            '
            '
            Me.TextBoxRightSection_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Phone.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Phone.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Phone.Location = New System.Drawing.Point(54, 81)
            Me.TextBoxRightSection_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Phone.Name = "TextBoxRightSection_Phone"
            Me.TextBoxRightSection_Phone.SecurityEnabled = True
            Me.TextBoxRightSection_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Phone.Size = New System.Drawing.Size(155, 20)
            Me.TextBoxRightSection_Phone.StartingFolderName = Nothing
            Me.TextBoxRightSection_Phone.TabIndex = 7
            Me.TextBoxRightSection_Phone.TabOnEnter = True
            '
            'TextBoxRightSection_Email
            '
            Me.TextBoxRightSection_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Email.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Email.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Email.Location = New System.Drawing.Point(54, 56)
            Me.TextBoxRightSection_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Email.Name = "TextBoxRightSection_Email"
            Me.TextBoxRightSection_Email.SecurityEnabled = True
            Me.TextBoxRightSection_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Email.Size = New System.Drawing.Size(356, 20)
            Me.TextBoxRightSection_Email.StartingFolderName = Nothing
            Me.TextBoxRightSection_Email.TabIndex = 5
            Me.TextBoxRightSection_Email.TabOnEnter = True
            '
            'TextBoxRightSection_Name
            '
            Me.TextBoxRightSection_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Name.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Name.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Name.Location = New System.Drawing.Point(54, 31)
            Me.TextBoxRightSection_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Name.Name = "TextBoxRightSection_Name"
            Me.TextBoxRightSection_Name.SecurityEnabled = True
            Me.TextBoxRightSection_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Name.Size = New System.Drawing.Size(356, 20)
            Me.TextBoxRightSection_Name.StartingFolderName = Nothing
            Me.TextBoxRightSection_Name.TabIndex = 3
            Me.TextBoxRightSection_Name.TabOnEnter = True
            '
            'TextBoxRightSection_ID
            '
            '
            '
            '
            Me.TextBoxRightSection_ID.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_ID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_ID.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_ID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_ID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_ID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_ID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_ID.FocusHighlightEnabled = True
            Me.TextBoxRightSection_ID.Location = New System.Drawing.Point(54, 6)
            Me.TextBoxRightSection_ID.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_ID.Name = "TextBoxRightSection_ID"
            Me.TextBoxRightSection_ID.SecurityEnabled = True
            Me.TextBoxRightSection_ID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_ID.Size = New System.Drawing.Size(77, 20)
            Me.TextBoxRightSection_ID.StartingFolderName = Nothing
            Me.TextBoxRightSection_ID.TabIndex = 1
            Me.TextBoxRightSection_ID.TabOnEnter = True
            '
            'LabelRightSection_Fax
            '
            Me.LabelRightSection_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Fax.Location = New System.Drawing.Point(215, 81)
            Me.LabelRightSection_Fax.Name = "LabelRightSection_Fax"
            Me.LabelRightSection_Fax.Size = New System.Drawing.Size(33, 20)
            Me.LabelRightSection_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Fax.TabIndex = 8
            Me.LabelRightSection_Fax.Text = "Fax:"
            '
            'LabelRightSection_Phone
            '
            Me.LabelRightSection_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Phone.Location = New System.Drawing.Point(6, 81)
            Me.LabelRightSection_Phone.Name = "LabelRightSection_Phone"
            Me.LabelRightSection_Phone.Size = New System.Drawing.Size(42, 20)
            Me.LabelRightSection_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Phone.TabIndex = 6
            Me.LabelRightSection_Phone.Text = "Phone:"
            '
            'LabelRightSection_Email
            '
            Me.LabelRightSection_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Email.Location = New System.Drawing.Point(6, 56)
            Me.LabelRightSection_Email.Name = "LabelRightSection_Email"
            Me.LabelRightSection_Email.Size = New System.Drawing.Size(42, 20)
            Me.LabelRightSection_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Email.TabIndex = 4
            Me.LabelRightSection_Email.Text = "Email:"
            '
            'LabelRightSection_Name
            '
            Me.LabelRightSection_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Name.Location = New System.Drawing.Point(6, 31)
            Me.LabelRightSection_Name.Name = "LabelRightSection_Name"
            Me.LabelRightSection_Name.Size = New System.Drawing.Size(42, 20)
            Me.LabelRightSection_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Name.TabIndex = 2
            Me.LabelRightSection_Name.Text = "Name:"
            '
            'LabelRightSection_ID
            '
            Me.LabelRightSection_ID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_ID.Location = New System.Drawing.Point(6, 6)
            Me.LabelRightSection_ID.Name = "LabelRightSection_ID"
            Me.LabelRightSection_ID.Size = New System.Drawing.Size(42, 20)
            Me.LabelRightSection_ID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_ID.TabIndex = 0
            Me.LabelRightSection_ID.Text = "ID:"
            '
            'AddressControlRightSection_Address
            '
            Me.AddressControlRightSection_Address.Address = Nothing
            Me.AddressControlRightSection_Address.Address2 = Nothing
            Me.AddressControlRightSection_Address.Address3 = Nothing
            Me.AddressControlRightSection_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlRightSection_Address.City = Nothing
            Me.AddressControlRightSection_Address.Country = Nothing
            Me.AddressControlRightSection_Address.County = Nothing
            Me.AddressControlRightSection_Address.DisableCountry = False
            Me.AddressControlRightSection_Address.DisableCounty = False
            Me.AddressControlRightSection_Address.Location = New System.Drawing.Point(6, 107)
            Me.AddressControlRightSection_Address.Name = "AddressControlRightSection_Address"
            Me.AddressControlRightSection_Address.ReadOnly = False
            Me.AddressControlRightSection_Address.ShowCountry = False
            Me.AddressControlRightSection_Address.ShowCounty = False
            Me.AddressControlRightSection_Address.Size = New System.Drawing.Size(404, 181)
            Me.AddressControlRightSection_Address.State = Nothing
            Me.AddressControlRightSection_Address.TabIndex = 10
            Me.AddressControlRightSection_Address.Title = "Address"
            Me.AddressControlRightSection_Address.Zip = Nothing
            '
            'GroupBoxLogos_HeaderLogoSelection
            '
            Me.GroupBoxLogos_HeaderLogoSelection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.ButtonHeaderLogo_LandscapeDelete)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.ButtonHeaderLogo_LandscapeSelect)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.ButtonHeaderLogo_PortraitDelete)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.ButtonHeaderLogo_PortraitSelect)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.RadioButtonControlHeaderLogoSelection_Hide)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.RadioButtonControlHeaderLogoSelection_Show)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.LabelHeaderLogoSelection_LogoProperties)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.PictureBoxHeaderLogoSelection_Landscape)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.LabelHeaderLogoSelection_LandscapeNotes)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.LabelLogoSelection_PortraitNotes)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.TextBoxHeaderLogoSelection_Landscape)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.LabelHeaderLogoSelection_Landscape)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.LabelHeaderLogoSelection_Portrait)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.TextBoxHeaderLogoSelection_Portrait)
            Me.GroupBoxLogos_HeaderLogoSelection.Controls.Add(Me.PictureBoxHeaderLogoSelection_Portrait)
            Me.GroupBoxLogos_HeaderLogoSelection.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxLogos_HeaderLogoSelection.Name = "GroupBoxLogos_HeaderLogoSelection"
            Me.GroupBoxLogos_HeaderLogoSelection.Size = New System.Drawing.Size(637, 220)
            Me.GroupBoxLogos_HeaderLogoSelection.TabIndex = 1
            Me.GroupBoxLogos_HeaderLogoSelection.Text = "Header Logo Selection"
            '
            'ButtonHeaderLogo_LandscapeDelete
            '
            Me.ButtonHeaderLogo_LandscapeDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonHeaderLogo_LandscapeDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonHeaderLogo_LandscapeDelete.Location = New System.Drawing.Point(344, 117)
            Me.ButtonHeaderLogo_LandscapeDelete.Name = "ButtonHeaderLogo_LandscapeDelete"
            Me.ButtonHeaderLogo_LandscapeDelete.SecurityEnabled = True
            Me.ButtonHeaderLogo_LandscapeDelete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonHeaderLogo_LandscapeDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonHeaderLogo_LandscapeDelete.TabIndex = 12
            Me.ButtonHeaderLogo_LandscapeDelete.Text = "Delete"
            '
            'ButtonHeaderLogo_LandscapeSelect
            '
            Me.ButtonHeaderLogo_LandscapeSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonHeaderLogo_LandscapeSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonHeaderLogo_LandscapeSelect.Location = New System.Drawing.Point(263, 117)
            Me.ButtonHeaderLogo_LandscapeSelect.Name = "ButtonHeaderLogo_LandscapeSelect"
            Me.ButtonHeaderLogo_LandscapeSelect.SecurityEnabled = True
            Me.ButtonHeaderLogo_LandscapeSelect.Size = New System.Drawing.Size(75, 20)
            Me.ButtonHeaderLogo_LandscapeSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonHeaderLogo_LandscapeSelect.TabIndex = 11
            Me.ButtonHeaderLogo_LandscapeSelect.Text = "Select"
            '
            'ButtonHeaderLogo_PortraitDelete
            '
            Me.ButtonHeaderLogo_PortraitDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonHeaderLogo_PortraitDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonHeaderLogo_PortraitDelete.Location = New System.Drawing.Point(344, 26)
            Me.ButtonHeaderLogo_PortraitDelete.Name = "ButtonHeaderLogo_PortraitDelete"
            Me.ButtonHeaderLogo_PortraitDelete.SecurityEnabled = True
            Me.ButtonHeaderLogo_PortraitDelete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonHeaderLogo_PortraitDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonHeaderLogo_PortraitDelete.TabIndex = 10
            Me.ButtonHeaderLogo_PortraitDelete.Text = "Delete"
            '
            'ButtonHeaderLogo_PortraitSelect
            '
            Me.ButtonHeaderLogo_PortraitSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonHeaderLogo_PortraitSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonHeaderLogo_PortraitSelect.Location = New System.Drawing.Point(263, 26)
            Me.ButtonHeaderLogo_PortraitSelect.Name = "ButtonHeaderLogo_PortraitSelect"
            Me.ButtonHeaderLogo_PortraitSelect.SecurityEnabled = True
            Me.ButtonHeaderLogo_PortraitSelect.Size = New System.Drawing.Size(75, 20)
            Me.ButtonHeaderLogo_PortraitSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonHeaderLogo_PortraitSelect.TabIndex = 9
            Me.ButtonHeaderLogo_PortraitSelect.Text = "Select"
            '
            'RadioButtonControlHeaderLogoSelection_Hide
            '
            Me.RadioButtonControlHeaderLogoSelection_Hide.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlHeaderLogoSelection_Hide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlHeaderLogoSelection_Hide.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlHeaderLogoSelection_Hide.Location = New System.Drawing.Point(171, 195)
            Me.RadioButtonControlHeaderLogoSelection_Hide.Name = "RadioButtonControlHeaderLogoSelection_Hide"
            Me.RadioButtonControlHeaderLogoSelection_Hide.SecurityEnabled = True
            Me.RadioButtonControlHeaderLogoSelection_Hide.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlHeaderLogoSelection_Hide.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlHeaderLogoSelection_Hide.TabIndex = 8
            Me.RadioButtonControlHeaderLogoSelection_Hide.TabOnEnter = True
            Me.RadioButtonControlHeaderLogoSelection_Hide.TabStop = False
            Me.RadioButtonControlHeaderLogoSelection_Hide.Text = "Hide"
            '
            'RadioButtonControlHeaderLogoSelection_Show
            '
            Me.RadioButtonControlHeaderLogoSelection_Show.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlHeaderLogoSelection_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlHeaderLogoSelection_Show.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlHeaderLogoSelection_Show.Location = New System.Drawing.Point(100, 195)
            Me.RadioButtonControlHeaderLogoSelection_Show.Name = "RadioButtonControlHeaderLogoSelection_Show"
            Me.RadioButtonControlHeaderLogoSelection_Show.SecurityEnabled = True
            Me.RadioButtonControlHeaderLogoSelection_Show.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlHeaderLogoSelection_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlHeaderLogoSelection_Show.TabIndex = 7
            Me.RadioButtonControlHeaderLogoSelection_Show.TabOnEnter = True
            Me.RadioButtonControlHeaderLogoSelection_Show.TabStop = False
            Me.RadioButtonControlHeaderLogoSelection_Show.Text = "Show"
            '
            'LabelHeaderLogoSelection_LogoProperties
            '
            Me.LabelHeaderLogoSelection_LogoProperties.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderLogoSelection_LogoProperties.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderLogoSelection_LogoProperties.Location = New System.Drawing.Point(6, 195)
            Me.LabelHeaderLogoSelection_LogoProperties.Name = "LabelHeaderLogoSelection_LogoProperties"
            Me.LabelHeaderLogoSelection_LogoProperties.Size = New System.Drawing.Size(90, 20)
            Me.LabelHeaderLogoSelection_LogoProperties.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderLogoSelection_LogoProperties.TabIndex = 6
            Me.LabelHeaderLogoSelection_LogoProperties.Text = "Logo Properties:"
            '
            'PictureBoxHeaderLogoSelection_Landscape
            '
            Me.PictureBoxHeaderLogoSelection_Landscape.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxHeaderLogoSelection_Landscape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBoxHeaderLogoSelection_Landscape.Location = New System.Drawing.Point(425, 117)
            Me.PictureBoxHeaderLogoSelection_Landscape.Name = "PictureBoxHeaderLogoSelection_Landscape"
            Me.PictureBoxHeaderLogoSelection_Landscape.Size = New System.Drawing.Size(205, 75)
            Me.PictureBoxHeaderLogoSelection_Landscape.TabIndex = 7
            Me.PictureBoxHeaderLogoSelection_Landscape.TabStop = False
            '
            'LabelHeaderLogoSelection_LandscapeNotes
            '
            Me.LabelHeaderLogoSelection_LandscapeNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderLogoSelection_LandscapeNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderLogoSelection_LandscapeNotes.Location = New System.Drawing.Point(101, 143)
            Me.LabelHeaderLogoSelection_LandscapeNotes.Name = "LabelHeaderLogoSelection_LandscapeNotes"
            Me.LabelHeaderLogoSelection_LandscapeNotes.Size = New System.Drawing.Size(318, 48)
            Me.LabelHeaderLogoSelection_LandscapeNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderLogoSelection_LandscapeNotes.TabIndex = 5
            Me.LabelHeaderLogoSelection_LandscapeNotes.Text = "Note: The logo must be exactly 9.95 inches wide by 1.5 inches tall with 96 DPI. Y" &
    "ou can place your graphics anywhere within this total image area to control hori" &
    "zontal and vertical spacing."
            Me.LabelHeaderLogoSelection_LandscapeNotes.WordWrap = True
            '
            'LabelLogoSelection_PortraitNotes
            '
            Me.LabelLogoSelection_PortraitNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLogoSelection_PortraitNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLogoSelection_PortraitNotes.Location = New System.Drawing.Point(100, 52)
            Me.LabelLogoSelection_PortraitNotes.Name = "LabelLogoSelection_PortraitNotes"
            Me.LabelLogoSelection_PortraitNotes.Size = New System.Drawing.Size(318, 48)
            Me.LabelLogoSelection_PortraitNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLogoSelection_PortraitNotes.TabIndex = 2
            Me.LabelLogoSelection_PortraitNotes.Text = "Note: The logo must be exactly 7.45 inches wide by 1.5 inches tall with 96 DPI. Y" &
    "ou can place your graphics anywhere within this total image area to control hori" &
    "zontal and vertical spacing."
            Me.LabelLogoSelection_PortraitNotes.WordWrap = True
            '
            'TextBoxHeaderLogoSelection_Landscape
            '
            '
            '
            '
            Me.TextBoxHeaderLogoSelection_Landscape.Border.Class = "TextBoxBorder"
            Me.TextBoxHeaderLogoSelection_Landscape.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeaderLogoSelection_Landscape.ButtonCustom.Visible = True
            Me.TextBoxHeaderLogoSelection_Landscape.CheckSpellingOnValidate = False
            Me.TextBoxHeaderLogoSelection_Landscape.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxHeaderLogoSelection_Landscape.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeaderLogoSelection_Landscape.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeaderLogoSelection_Landscape.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeaderLogoSelection_Landscape.FocusHighlightEnabled = True
            Me.TextBoxHeaderLogoSelection_Landscape.Location = New System.Drawing.Point(101, 117)
            Me.TextBoxHeaderLogoSelection_Landscape.MaxFileSize = CType(0, Long)
            Me.TextBoxHeaderLogoSelection_Landscape.Name = "TextBoxHeaderLogoSelection_Landscape"
            Me.TextBoxHeaderLogoSelection_Landscape.ReadOnly = True
            Me.TextBoxHeaderLogoSelection_Landscape.SecurityEnabled = True
            Me.TextBoxHeaderLogoSelection_Landscape.ShowSpellCheckCompleteMessage = True
            Me.TextBoxHeaderLogoSelection_Landscape.Size = New System.Drawing.Size(156, 21)
            Me.TextBoxHeaderLogoSelection_Landscape.StartingFolderName = Nothing
            Me.TextBoxHeaderLogoSelection_Landscape.TabIndex = 4
            Me.TextBoxHeaderLogoSelection_Landscape.TabOnEnter = True
            '
            'LabelHeaderLogoSelection_Landscape
            '
            Me.LabelHeaderLogoSelection_Landscape.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderLogoSelection_Landscape.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderLogoSelection_Landscape.Location = New System.Drawing.Point(5, 118)
            Me.LabelHeaderLogoSelection_Landscape.Name = "LabelHeaderLogoSelection_Landscape"
            Me.LabelHeaderLogoSelection_Landscape.Size = New System.Drawing.Size(90, 20)
            Me.LabelHeaderLogoSelection_Landscape.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderLogoSelection_Landscape.TabIndex = 3
            Me.LabelHeaderLogoSelection_Landscape.Text = "Landscape:"
            '
            'LabelHeaderLogoSelection_Portrait
            '
            Me.LabelHeaderLogoSelection_Portrait.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderLogoSelection_Portrait.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderLogoSelection_Portrait.Location = New System.Drawing.Point(5, 27)
            Me.LabelHeaderLogoSelection_Portrait.Name = "LabelHeaderLogoSelection_Portrait"
            Me.LabelHeaderLogoSelection_Portrait.Size = New System.Drawing.Size(90, 20)
            Me.LabelHeaderLogoSelection_Portrait.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderLogoSelection_Portrait.TabIndex = 0
            Me.LabelHeaderLogoSelection_Portrait.Text = "Portrait:"
            '
            'TextBoxHeaderLogoSelection_Portrait
            '
            '
            '
            '
            Me.TextBoxHeaderLogoSelection_Portrait.Border.Class = "TextBoxBorder"
            Me.TextBoxHeaderLogoSelection_Portrait.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeaderLogoSelection_Portrait.ButtonCustom.Visible = True
            Me.TextBoxHeaderLogoSelection_Portrait.CheckSpellingOnValidate = False
            Me.TextBoxHeaderLogoSelection_Portrait.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxHeaderLogoSelection_Portrait.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeaderLogoSelection_Portrait.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeaderLogoSelection_Portrait.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeaderLogoSelection_Portrait.FocusHighlightEnabled = True
            Me.TextBoxHeaderLogoSelection_Portrait.Location = New System.Drawing.Point(101, 26)
            Me.TextBoxHeaderLogoSelection_Portrait.MaxFileSize = CType(0, Long)
            Me.TextBoxHeaderLogoSelection_Portrait.Name = "TextBoxHeaderLogoSelection_Portrait"
            Me.TextBoxHeaderLogoSelection_Portrait.ReadOnly = True
            Me.TextBoxHeaderLogoSelection_Portrait.SecurityEnabled = True
            Me.TextBoxHeaderLogoSelection_Portrait.ShowSpellCheckCompleteMessage = True
            Me.TextBoxHeaderLogoSelection_Portrait.Size = New System.Drawing.Size(156, 21)
            Me.TextBoxHeaderLogoSelection_Portrait.StartingFolderName = Nothing
            Me.TextBoxHeaderLogoSelection_Portrait.TabIndex = 1
            Me.TextBoxHeaderLogoSelection_Portrait.TabOnEnter = True
            '
            'PictureBoxHeaderLogoSelection_Portrait
            '
            Me.PictureBoxHeaderLogoSelection_Portrait.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxHeaderLogoSelection_Portrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBoxHeaderLogoSelection_Portrait.Location = New System.Drawing.Point(425, 25)
            Me.PictureBoxHeaderLogoSelection_Portrait.Name = "PictureBoxHeaderLogoSelection_Portrait"
            Me.PictureBoxHeaderLogoSelection_Portrait.Size = New System.Drawing.Size(205, 75)
            Me.PictureBoxHeaderLogoSelection_Portrait.TabIndex = 0
            Me.PictureBoxHeaderLogoSelection_Portrait.TabStop = False
            '
            'TabControlLocation_LocationDetails
            '
            Me.TabControlLocation_LocationDetails.CanReorderTabs = False
            Me.TabControlLocation_LocationDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlLocation_LocationDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlLocation_LocationDetails.Controls.Add(Me.TabControlPanelLogoTab_Logo)
            Me.TabControlLocation_LocationDetails.Controls.Add(Me.TabControlPanelInformationTab_Information)
            Me.TabControlLocation_LocationDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlLocation_LocationDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlLocation_LocationDetails.Name = "TabControlLocation_LocationDetails"
            Me.TabControlLocation_LocationDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlLocation_LocationDetails.SelectedTabIndex = 0
            Me.TabControlLocation_LocationDetails.Size = New System.Drawing.Size(649, 481)
            Me.TabControlLocation_LocationDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlLocation_LocationDetails.TabIndex = 0
            Me.TabControlLocation_LocationDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlLocation_LocationDetails.Tabs.Add(Me.TabItemLocationDetails_InformationTab)
            Me.TabControlLocation_LocationDetails.Tabs.Add(Me.TabItemLocationDetails_LogoTab)
            Me.TabControlLocation_LocationDetails.Text = "TabControl1"
            '
            'TabControlPanelLogoTab_Logo
            '
            Me.TabControlPanelLogoTab_Logo.Controls.Add(Me.GroupBoxLogos_FooterLogoSelection)
            Me.TabControlPanelLogoTab_Logo.Controls.Add(Me.GroupBoxLogos_HeaderLogoSelection)
            Me.TabControlPanelLogoTab_Logo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelLogoTab_Logo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelLogoTab_Logo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelLogoTab_Logo.Name = "TabControlPanelLogoTab_Logo"
            Me.TabControlPanelLogoTab_Logo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelLogoTab_Logo.Size = New System.Drawing.Size(649, 454)
            Me.TabControlPanelLogoTab_Logo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelLogoTab_Logo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelLogoTab_Logo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelLogoTab_Logo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelLogoTab_Logo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelLogoTab_Logo.Style.GradientAngle = 90
            Me.TabControlPanelLogoTab_Logo.TabIndex = 0
            Me.TabControlPanelLogoTab_Logo.TabItem = Me.TabItemLocationDetails_LogoTab
            '
            'GroupBoxLogos_FooterLogoSelection
            '
            Me.GroupBoxLogos_FooterLogoSelection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.ButtonFooterLogo_LandscapeDelete)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.ButtonFooterLogo_LandscapeSelect)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.ButtonFooterLogo_PortraitDelete)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.ButtonFooterLogo_PortraitSelect)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.RadioButtonControlFooterLogoSelection_Hide)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.RadioButtonControlFooterLogoSelection_Show)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.LabelFooterLogoSelection_LogoProperties)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.PictureBoxFooterLogoSelection_Landscape)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.LabelFooterLogoSelection_LandscapeNotes)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.LabelFooterLogoSelection_PortraitNotes)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.TextBoxFooterLogoSelection_Landscape)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.LabelFooterLogoSelection_Landscape)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.LabelFooterLogoSelection_Portrait)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.TextBoxFooterLogoSelection_Portrait)
            Me.GroupBoxLogos_FooterLogoSelection.Controls.Add(Me.PictureBoxFooterLogoSelection_Portrait)
            Me.GroupBoxLogos_FooterLogoSelection.Location = New System.Drawing.Point(6, 232)
            Me.GroupBoxLogos_FooterLogoSelection.Name = "GroupBoxLogos_FooterLogoSelection"
            Me.GroupBoxLogos_FooterLogoSelection.Size = New System.Drawing.Size(637, 220)
            Me.GroupBoxLogos_FooterLogoSelection.TabIndex = 2
            Me.GroupBoxLogos_FooterLogoSelection.Text = "Footer Logo Selection"
            '
            'ButtonFooterLogo_LandscapeDelete
            '
            Me.ButtonFooterLogo_LandscapeDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonFooterLogo_LandscapeDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonFooterLogo_LandscapeDelete.Location = New System.Drawing.Point(344, 114)
            Me.ButtonFooterLogo_LandscapeDelete.Name = "ButtonFooterLogo_LandscapeDelete"
            Me.ButtonFooterLogo_LandscapeDelete.SecurityEnabled = True
            Me.ButtonFooterLogo_LandscapeDelete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonFooterLogo_LandscapeDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonFooterLogo_LandscapeDelete.TabIndex = 14
            Me.ButtonFooterLogo_LandscapeDelete.Text = "Delete"
            '
            'ButtonFooterLogo_LandscapeSelect
            '
            Me.ButtonFooterLogo_LandscapeSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonFooterLogo_LandscapeSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonFooterLogo_LandscapeSelect.Location = New System.Drawing.Point(263, 114)
            Me.ButtonFooterLogo_LandscapeSelect.Name = "ButtonFooterLogo_LandscapeSelect"
            Me.ButtonFooterLogo_LandscapeSelect.SecurityEnabled = True
            Me.ButtonFooterLogo_LandscapeSelect.Size = New System.Drawing.Size(75, 20)
            Me.ButtonFooterLogo_LandscapeSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonFooterLogo_LandscapeSelect.TabIndex = 13
            Me.ButtonFooterLogo_LandscapeSelect.Text = "Select"
            '
            'ButtonFooterLogo_PortraitDelete
            '
            Me.ButtonFooterLogo_PortraitDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonFooterLogo_PortraitDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonFooterLogo_PortraitDelete.Location = New System.Drawing.Point(344, 26)
            Me.ButtonFooterLogo_PortraitDelete.Name = "ButtonFooterLogo_PortraitDelete"
            Me.ButtonFooterLogo_PortraitDelete.SecurityEnabled = True
            Me.ButtonFooterLogo_PortraitDelete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonFooterLogo_PortraitDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonFooterLogo_PortraitDelete.TabIndex = 12
            Me.ButtonFooterLogo_PortraitDelete.Text = "Delete"
            '
            'ButtonFooterLogo_PortraitSelect
            '
            Me.ButtonFooterLogo_PortraitSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonFooterLogo_PortraitSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonFooterLogo_PortraitSelect.Location = New System.Drawing.Point(263, 26)
            Me.ButtonFooterLogo_PortraitSelect.Name = "ButtonFooterLogo_PortraitSelect"
            Me.ButtonFooterLogo_PortraitSelect.SecurityEnabled = True
            Me.ButtonFooterLogo_PortraitSelect.Size = New System.Drawing.Size(75, 20)
            Me.ButtonFooterLogo_PortraitSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonFooterLogo_PortraitSelect.TabIndex = 11
            Me.ButtonFooterLogo_PortraitSelect.Text = "Select"
            '
            'RadioButtonControlFooterLogoSelection_Hide
            '
            Me.RadioButtonControlFooterLogoSelection_Hide.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlFooterLogoSelection_Hide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlFooterLogoSelection_Hide.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlFooterLogoSelection_Hide.Location = New System.Drawing.Point(171, 195)
            Me.RadioButtonControlFooterLogoSelection_Hide.Name = "RadioButtonControlFooterLogoSelection_Hide"
            Me.RadioButtonControlFooterLogoSelection_Hide.SecurityEnabled = True
            Me.RadioButtonControlFooterLogoSelection_Hide.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlFooterLogoSelection_Hide.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlFooterLogoSelection_Hide.TabIndex = 8
            Me.RadioButtonControlFooterLogoSelection_Hide.TabOnEnter = True
            Me.RadioButtonControlFooterLogoSelection_Hide.TabStop = False
            Me.RadioButtonControlFooterLogoSelection_Hide.Text = "Hide"
            '
            'RadioButtonControlFooterLogoSelection_Show
            '
            Me.RadioButtonControlFooterLogoSelection_Show.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlFooterLogoSelection_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlFooterLogoSelection_Show.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlFooterLogoSelection_Show.Location = New System.Drawing.Point(100, 195)
            Me.RadioButtonControlFooterLogoSelection_Show.Name = "RadioButtonControlFooterLogoSelection_Show"
            Me.RadioButtonControlFooterLogoSelection_Show.SecurityEnabled = True
            Me.RadioButtonControlFooterLogoSelection_Show.Size = New System.Drawing.Size(65, 20)
            Me.RadioButtonControlFooterLogoSelection_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlFooterLogoSelection_Show.TabIndex = 7
            Me.RadioButtonControlFooterLogoSelection_Show.TabOnEnter = True
            Me.RadioButtonControlFooterLogoSelection_Show.TabStop = False
            Me.RadioButtonControlFooterLogoSelection_Show.Text = "Show"
            '
            'LabelFooterLogoSelection_LogoProperties
            '
            Me.LabelFooterLogoSelection_LogoProperties.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFooterLogoSelection_LogoProperties.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFooterLogoSelection_LogoProperties.Location = New System.Drawing.Point(6, 195)
            Me.LabelFooterLogoSelection_LogoProperties.Name = "LabelFooterLogoSelection_LogoProperties"
            Me.LabelFooterLogoSelection_LogoProperties.Size = New System.Drawing.Size(90, 20)
            Me.LabelFooterLogoSelection_LogoProperties.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFooterLogoSelection_LogoProperties.TabIndex = 6
            Me.LabelFooterLogoSelection_LogoProperties.Text = "Logo Properties:"
            '
            'PictureBoxFooterLogoSelection_Landscape
            '
            Me.PictureBoxFooterLogoSelection_Landscape.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxFooterLogoSelection_Landscape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBoxFooterLogoSelection_Landscape.Location = New System.Drawing.Point(425, 114)
            Me.PictureBoxFooterLogoSelection_Landscape.Name = "PictureBoxFooterLogoSelection_Landscape"
            Me.PictureBoxFooterLogoSelection_Landscape.Size = New System.Drawing.Size(205, 75)
            Me.PictureBoxFooterLogoSelection_Landscape.TabIndex = 7
            Me.PictureBoxFooterLogoSelection_Landscape.TabStop = False
            '
            'LabelFooterLogoSelection_LandscapeNotes
            '
            Me.LabelFooterLogoSelection_LandscapeNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFooterLogoSelection_LandscapeNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFooterLogoSelection_LandscapeNotes.Location = New System.Drawing.Point(101, 140)
            Me.LabelFooterLogoSelection_LandscapeNotes.Name = "LabelFooterLogoSelection_LandscapeNotes"
            Me.LabelFooterLogoSelection_LandscapeNotes.Size = New System.Drawing.Size(318, 49)
            Me.LabelFooterLogoSelection_LandscapeNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFooterLogoSelection_LandscapeNotes.TabIndex = 5
            Me.LabelFooterLogoSelection_LandscapeNotes.Text = "Note: The logo must be exactly 9.95 inches wide by 1.5 inches tall with 96 DPI. Y" &
    "ou can place your graphics anywhere within this total image area to control hori" &
    "zontal and vertical spacing."
            Me.LabelFooterLogoSelection_LandscapeNotes.WordWrap = True
            '
            'LabelFooterLogoSelection_PortraitNotes
            '
            Me.LabelFooterLogoSelection_PortraitNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFooterLogoSelection_PortraitNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFooterLogoSelection_PortraitNotes.Location = New System.Drawing.Point(100, 52)
            Me.LabelFooterLogoSelection_PortraitNotes.Name = "LabelFooterLogoSelection_PortraitNotes"
            Me.LabelFooterLogoSelection_PortraitNotes.Size = New System.Drawing.Size(318, 48)
            Me.LabelFooterLogoSelection_PortraitNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFooterLogoSelection_PortraitNotes.TabIndex = 2
            Me.LabelFooterLogoSelection_PortraitNotes.Text = "Note: The logo must be exactly 7.45 inches wide by 1.5 inches tall with 96 DPI. Y" &
    "ou can place your graphics anywhere within this total image area to control hori" &
    "zontal and vertical spacing."
            Me.LabelFooterLogoSelection_PortraitNotes.WordWrap = True
            '
            'TextBoxFooterLogoSelection_Landscape
            '
            '
            '
            '
            Me.TextBoxFooterLogoSelection_Landscape.Border.Class = "TextBoxBorder"
            Me.TextBoxFooterLogoSelection_Landscape.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxFooterLogoSelection_Landscape.ButtonCustom.Visible = True
            Me.TextBoxFooterLogoSelection_Landscape.CheckSpellingOnValidate = False
            Me.TextBoxFooterLogoSelection_Landscape.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxFooterLogoSelection_Landscape.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxFooterLogoSelection_Landscape.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxFooterLogoSelection_Landscape.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxFooterLogoSelection_Landscape.FocusHighlightEnabled = True
            Me.TextBoxFooterLogoSelection_Landscape.Location = New System.Drawing.Point(101, 114)
            Me.TextBoxFooterLogoSelection_Landscape.MaxFileSize = CType(0, Long)
            Me.TextBoxFooterLogoSelection_Landscape.Name = "TextBoxFooterLogoSelection_Landscape"
            Me.TextBoxFooterLogoSelection_Landscape.ReadOnly = True
            Me.TextBoxFooterLogoSelection_Landscape.SecurityEnabled = True
            Me.TextBoxFooterLogoSelection_Landscape.ShowSpellCheckCompleteMessage = True
            Me.TextBoxFooterLogoSelection_Landscape.Size = New System.Drawing.Size(156, 21)
            Me.TextBoxFooterLogoSelection_Landscape.StartingFolderName = Nothing
            Me.TextBoxFooterLogoSelection_Landscape.TabIndex = 4
            Me.TextBoxFooterLogoSelection_Landscape.TabOnEnter = True
            '
            'LabelFooterLogoSelection_Landscape
            '
            Me.LabelFooterLogoSelection_Landscape.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFooterLogoSelection_Landscape.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFooterLogoSelection_Landscape.Location = New System.Drawing.Point(5, 115)
            Me.LabelFooterLogoSelection_Landscape.Name = "LabelFooterLogoSelection_Landscape"
            Me.LabelFooterLogoSelection_Landscape.Size = New System.Drawing.Size(90, 20)
            Me.LabelFooterLogoSelection_Landscape.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFooterLogoSelection_Landscape.TabIndex = 3
            Me.LabelFooterLogoSelection_Landscape.Text = "Landscape:"
            '
            'LabelFooterLogoSelection_Portrait
            '
            Me.LabelFooterLogoSelection_Portrait.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFooterLogoSelection_Portrait.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFooterLogoSelection_Portrait.Location = New System.Drawing.Point(5, 27)
            Me.LabelFooterLogoSelection_Portrait.Name = "LabelFooterLogoSelection_Portrait"
            Me.LabelFooterLogoSelection_Portrait.Size = New System.Drawing.Size(90, 20)
            Me.LabelFooterLogoSelection_Portrait.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFooterLogoSelection_Portrait.TabIndex = 0
            Me.LabelFooterLogoSelection_Portrait.Text = "Portrait:"
            '
            'TextBoxFooterLogoSelection_Portrait
            '
            '
            '
            '
            Me.TextBoxFooterLogoSelection_Portrait.Border.Class = "TextBoxBorder"
            Me.TextBoxFooterLogoSelection_Portrait.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxFooterLogoSelection_Portrait.ButtonCustom.Visible = True
            Me.TextBoxFooterLogoSelection_Portrait.CheckSpellingOnValidate = False
            Me.TextBoxFooterLogoSelection_Portrait.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxFooterLogoSelection_Portrait.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxFooterLogoSelection_Portrait.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxFooterLogoSelection_Portrait.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxFooterLogoSelection_Portrait.FocusHighlightEnabled = True
            Me.TextBoxFooterLogoSelection_Portrait.Location = New System.Drawing.Point(101, 26)
            Me.TextBoxFooterLogoSelection_Portrait.MaxFileSize = CType(0, Long)
            Me.TextBoxFooterLogoSelection_Portrait.Name = "TextBoxFooterLogoSelection_Portrait"
            Me.TextBoxFooterLogoSelection_Portrait.ReadOnly = True
            Me.TextBoxFooterLogoSelection_Portrait.SecurityEnabled = True
            Me.TextBoxFooterLogoSelection_Portrait.ShowSpellCheckCompleteMessage = True
            Me.TextBoxFooterLogoSelection_Portrait.Size = New System.Drawing.Size(156, 21)
            Me.TextBoxFooterLogoSelection_Portrait.StartingFolderName = Nothing
            Me.TextBoxFooterLogoSelection_Portrait.TabIndex = 1
            Me.TextBoxFooterLogoSelection_Portrait.TabOnEnter = True
            '
            'PictureBoxFooterLogoSelection_Portrait
            '
            Me.PictureBoxFooterLogoSelection_Portrait.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxFooterLogoSelection_Portrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBoxFooterLogoSelection_Portrait.Location = New System.Drawing.Point(425, 25)
            Me.PictureBoxFooterLogoSelection_Portrait.Name = "PictureBoxFooterLogoSelection_Portrait"
            Me.PictureBoxFooterLogoSelection_Portrait.Size = New System.Drawing.Size(205, 75)
            Me.PictureBoxFooterLogoSelection_Portrait.TabIndex = 0
            Me.PictureBoxFooterLogoSelection_Portrait.TabStop = False
            '
            'TabItemLocationDetails_LogoTab
            '
            Me.TabItemLocationDetails_LogoTab.AttachedControl = Me.TabControlPanelLogoTab_Logo
            Me.TabItemLocationDetails_LogoTab.Name = "TabItemLocationDetails_LogoTab"
            Me.TabItemLocationDetails_LogoTab.Text = "Logos"
            '
            'TabControlPanelInformationTab_Information
            '
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.AdvTreeInformation_PrintSpecs)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelRightSection_ID)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.AddressControlRightSection_Address)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelRightSection_Name)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxRightSection_Fax)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelRightSection_Email)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxRightSection_Phone)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelRightSection_Phone)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxRightSection_Email)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelRightSection_Fax)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxRightSection_Name)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxRightSection_ID)
            Me.TabControlPanelInformationTab_Information.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInformationTab_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInformationTab_Information.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInformationTab_Information.Name = "TabControlPanelInformationTab_Information"
            Me.TabControlPanelInformationTab_Information.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInformationTab_Information.Size = New System.Drawing.Size(649, 454)
            Me.TabControlPanelInformationTab_Information.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInformationTab_Information.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInformationTab_Information.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInformationTab_Information.Style.GradientAngle = 90
            Me.TabControlPanelInformationTab_Information.TabIndex = 0
            Me.TabControlPanelInformationTab_Information.TabItem = Me.TabItemLocationDetails_InformationTab
            '
            'AdvTreeInformation_PrintSpecs
            '
            Me.AdvTreeInformation_PrintSpecs.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
            Me.AdvTreeInformation_PrintSpecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AdvTreeInformation_PrintSpecs.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.AdvTreeInformation_PrintSpecs.BackgroundStyle.Class = "TreeBorderKey"
            Me.AdvTreeInformation_PrintSpecs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.AdvTreeInformation_PrintSpecs.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.AdvTreeInformation_PrintSpecs.Location = New System.Drawing.Point(416, 6)
            Me.AdvTreeInformation_PrintSpecs.Name = "AdvTreeInformation_PrintSpecs"
            Me.AdvTreeInformation_PrintSpecs.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.NodePrintSpecs_PrintHeader, Me.NodePrintSpecs_PrintFooter})
            Me.AdvTreeInformation_PrintSpecs.NodesConnector = Me.NodeConnector1
            Me.AdvTreeInformation_PrintSpecs.NodeStyle = Me.ElementStyle1
            Me.AdvTreeInformation_PrintSpecs.PathSeparator = ";"
            Me.AdvTreeInformation_PrintSpecs.SecurityEnabled = True
            Me.AdvTreeInformation_PrintSpecs.Size = New System.Drawing.Size(227, 282)
            Me.AdvTreeInformation_PrintSpecs.Styles.Add(Me.ElementStyle1)
            Me.AdvTreeInformation_PrintSpecs.TabIndex = 11
            Me.AdvTreeInformation_PrintSpecs.Text = "AdvTree1"
            '
            'NodePrintSpecs_PrintHeader
            '
            Me.NodePrintSpecs_PrintHeader.CheckBoxVisible = True
            Me.NodePrintSpecs_PrintHeader.Name = "NodePrintSpecs_PrintHeader"
            Me.NodePrintSpecs_PrintHeader.Text = "Print Header"
            '
            'NodePrintSpecs_PrintFooter
            '
            Me.NodePrintSpecs_PrintFooter.CheckBoxVisible = True
            Me.NodePrintSpecs_PrintFooter.Name = "NodePrintSpecs_PrintFooter"
            Me.NodePrintSpecs_PrintFooter.Text = "Print Footer"
            '
            'NodeConnector1
            '
            Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
            '
            'ElementStyle1
            '
            Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ElementStyle1.Name = "ElementStyle1"
            Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
            '
            'TabItemLocationDetails_InformationTab
            '
            Me.TabItemLocationDetails_InformationTab.AttachedControl = Me.TabControlPanelInformationTab_Information
            Me.TabItemLocationDetails_InformationTab.Name = "TabItemLocationDetails_InformationTab"
            Me.TabItemLocationDetails_InformationTab.Text = "Information"
            '
            'LocationControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlLocation_LocationDetails)
            Me.Name = "LocationControl"
            Me.Size = New System.Drawing.Size(649, 481)
            CType(Me.GroupBoxLogos_HeaderLogoSelection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLogos_HeaderLogoSelection.ResumeLayout(False)
            CType(Me.PictureBoxHeaderLogoSelection_Landscape, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxHeaderLogoSelection_Portrait, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlLocation_LocationDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlLocation_LocationDetails.ResumeLayout(False)
            Me.TabControlPanelLogoTab_Logo.ResumeLayout(False)
            CType(Me.GroupBoxLogos_FooterLogoSelection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLogos_FooterLogoSelection.ResumeLayout(False)
            CType(Me.PictureBoxFooterLogoSelection_Landscape, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxFooterLogoSelection_Portrait, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelInformationTab_Information.ResumeLayout(False)
            CType(Me.AdvTreeInformation_PrintSpecs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxRightSection_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRightSection_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRightSection_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRightSection_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRightSection_ID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRightSection_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_ID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlRightSection_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents GroupBoxLogos_HeaderLogoSelection As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlHeaderLogoSelection_Hide As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlHeaderLogoSelection_Show As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelHeaderLogoSelection_LogoProperties As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PictureBoxHeaderLogoSelection_Landscape As System.Windows.Forms.PictureBox
        Friend WithEvents LabelHeaderLogoSelection_LandscapeNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLogoSelection_PortraitNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxHeaderLogoSelection_Landscape As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelHeaderLogoSelection_Landscape As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderLogoSelection_Portrait As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxHeaderLogoSelection_Portrait As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents PictureBoxHeaderLogoSelection_Portrait As System.Windows.Forms.PictureBox
        Friend WithEvents TabControlLocation_LocationDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelLogoTab_Logo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemLocationDetails_LogoTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInformationTab_Information As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemLocationDetails_InformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents AdvTreeInformation_PrintSpecs As AdvantageFramework.WinForm.Presentation.Controls.AdvTree
        Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
        Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
        Friend WithEvents GroupBoxLogos_FooterLogoSelection As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlFooterLogoSelection_Hide As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlFooterLogoSelection_Show As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelFooterLogoSelection_LogoProperties As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PictureBoxFooterLogoSelection_Landscape As System.Windows.Forms.PictureBox
        Friend WithEvents LabelFooterLogoSelection_LandscapeNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelFooterLogoSelection_PortraitNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxFooterLogoSelection_Landscape As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelFooterLogoSelection_Landscape As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelFooterLogoSelection_Portrait As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxFooterLogoSelection_Portrait As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents PictureBoxFooterLogoSelection_Portrait As System.Windows.Forms.PictureBox
        Friend WithEvents NodePrintSpecs_PrintHeader As DevComponents.AdvTree.Node
        Friend WithEvents NodePrintSpecs_PrintFooter As DevComponents.AdvTree.Node
        Friend WithEvents ButtonHeaderLogo_LandscapeDelete As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonHeaderLogo_LandscapeSelect As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonHeaderLogo_PortraitDelete As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonHeaderLogo_PortraitSelect As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonFooterLogo_LandscapeDelete As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonFooterLogo_LandscapeSelect As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonFooterLogo_PortraitDelete As MVC.Presentation.Controls.Button
        Friend WithEvents ButtonFooterLogo_PortraitSelect As MVC.Presentation.Controls.Button
    End Class

End Namespace
