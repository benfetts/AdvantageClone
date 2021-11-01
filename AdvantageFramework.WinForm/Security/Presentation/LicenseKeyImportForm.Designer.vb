Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LicenseKeyImportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicenseKeyImportForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.TextBoxForm_LicenseKeyFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_LicenseKeyFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectedLicenseKeyFileInformation_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrentLicenseKeyFileInformation_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_LicenseKeyInformation = New System.Windows.Forms.Panel()
            Me.PanelForm_ComscoreLicenseInfo = New System.Windows.Forms.Panel()
            Me.GroupBoxComscoreSelectedLicenseInfo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelComscoreSelected_ComscoreIDValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComscoreSelected_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComscoreSelected_ComscoreID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelComscoreSelected_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxComscoreCurrentLicenseInfo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelCurrectComscore_ClientIDValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrectComscore_AgencyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrectComscore_ClientID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrectComscore_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.GroupBoxForm_SelectedLicenseKeyFileInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.SuspendLayout()
            CType(Me.GroupBoxForm_CurrentLicenseKeyFileInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.SuspendLayout()
            Me.PanelForm_LicenseKeyInformation.SuspendLayout()
            Me.PanelForm_ComscoreLicenseInfo.SuspendLayout()
            CType(Me.GroupBoxComscoreSelectedLicenseInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxComscoreSelectedLicenseInfo.SuspendLayout()
            CType(Me.GroupBoxComscoreCurrentLicenseInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxComscoreCurrentLicenseInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(16, 11)
            Me.RibbonBarMergeContainerForm_Options.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(209, 121)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Import})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(108, 121)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.RibbonWordWrap = False
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'TextBoxForm_LicenseKeyFile
            '
            Me.TextBoxForm_LicenseKeyFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_LicenseKeyFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_LicenseKeyFile.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_LicenseKeyFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_LicenseKeyFile.ButtonCustom.Visible = True
            Me.TextBoxForm_LicenseKeyFile.CheckSpellingOnValidate = False
            Me.TextBoxForm_LicenseKeyFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_LicenseKeyFile.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_LicenseKeyFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_LicenseKeyFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.ADVLIC
            Me.TextBoxForm_LicenseKeyFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_LicenseKeyFile.FocusHighlightEnabled = True
            Me.TextBoxForm_LicenseKeyFile.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_LicenseKeyFile.Location = New System.Drawing.Point(16, 47)
            Me.TextBoxForm_LicenseKeyFile.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_LicenseKeyFile.Name = "TextBoxForm_LicenseKeyFile"
            Me.TextBoxForm_LicenseKeyFile.SecurityEnabled = True
            Me.TextBoxForm_LicenseKeyFile.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_LicenseKeyFile.Size = New System.Drawing.Size(636, 20)
            Me.TextBoxForm_LicenseKeyFile.StartingFolderName = Nothing
            Me.TextBoxForm_LicenseKeyFile.TabIndex = 9
            Me.TextBoxForm_LicenseKeyFile.TabOnEnter = True
            '
            'LabelForm_LicenseKeyFile
            '
            Me.LabelForm_LicenseKeyFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_LicenseKeyFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LicenseKeyFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LicenseKeyFile.Location = New System.Drawing.Point(16, 15)
            Me.LabelForm_LicenseKeyFile.Margin = New System.Windows.Forms.Padding(4)
            Me.LabelForm_LicenseKeyFile.Name = "LabelForm_LicenseKeyFile"
            Me.LabelForm_LicenseKeyFile.Size = New System.Drawing.Size(636, 25)
            Me.LabelForm_LicenseKeyFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LicenseKeyFile.TabIndex = 8
            Me.LabelForm_LicenseKeyFile.Text = "License Key File:"
            '
            'GroupBoxForm_SelectedLicenseKeyFileInformation
            '
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_AgencyName)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Controls.Add(Me.LabelSelectedLicenseKeyFileInformation_Agency)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Location = New System.Drawing.Point(4, 3)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Name = "GroupBoxForm_SelectedLicenseKeyFileInformation"
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Size = New System.Drawing.Size(636, 209)
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.TabIndex = 10
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.Text = "Selected License Key File Information"
            '
            'LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo
            '
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Location = New System.Drawing.Point(193, 181)
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Name = "LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo"
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.TabIndex = 12
            '
            'LabelSelectedLicenseKeyFileInformation_ProofingEnabled
            '
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.Location = New System.Drawing.Point(5, 181)
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.Name = "LabelSelectedLicenseKeyFileInformation_ProofingEnabled"
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.TabIndex = 11
            Me.LabelSelectedLicenseKeyFileInformation_ProofingEnabled.Text = "Proofing Enabled?"
            '
            'LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount
            '
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Location = New System.Drawing.Point(193, 155)
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Name = "LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount"
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.TabIndex = 12
            '
            'LabelSelectedLicenseKeyFileInformation_APILicenseQuantity
            '
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.Location = New System.Drawing.Point(5, 155)
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.Name = "LabelSelectedLicenseKeyFileInformation_APILicenseQuantity"
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.TabIndex = 11
            Me.LabelSelectedLicenseKeyFileInformation_APILicenseQuantity.Text = "API License Quantity:"
            '
            'LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount
            '
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Location = New System.Drawing.Point(193, 129)
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Name = "LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount"
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.TabIndex = 10
            '
            'LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity
            '
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.Location = New System.Drawing.Point(5, 129)
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.Name = "LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity"
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.TabIndex = 9
            Me.LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity.Text = "Media Tools License Quantity:"
            '
            'LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount
            '
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Location = New System.Drawing.Point(193, 103)
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Name = "LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount"
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.TabIndex = 8
            '
            'LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount
            '
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Location = New System.Drawing.Point(193, 77)
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Name = "LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount"
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.TabIndex = 7
            '
            'LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount
            '
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Location = New System.Drawing.Point(193, 51)
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Name = "LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount"
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.TabIndex = 6
            '
            'LabelSelectedLicenseKeyFileInformation_AgencyName
            '
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.Location = New System.Drawing.Point(193, 25)
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.Name = "LabelSelectedLicenseKeyFileInformation_AgencyName"
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.Size = New System.Drawing.Size(438, 20)
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.TabIndex = 5
            Me.LabelSelectedLicenseKeyFileInformation_AgencyName.UseMnemonic = False
            '
            'LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity
            '
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Location = New System.Drawing.Point(5, 77)
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Name = "LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity"
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.TabIndex = 4
            Me.LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Text = "Webvantage Only License Quantity:"
            '
            'LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity
            '
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.Location = New System.Drawing.Point(5, 103)
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.Name = "LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity"
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.TabIndex = 3
            Me.LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity.Text = "Client Portal License Quantity:"
            '
            'LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity
            '
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.Location = New System.Drawing.Point(5, 51)
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.Name = "LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity"
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.TabIndex = 1
            Me.LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity.Text = "Power License Quantity:"
            '
            'LabelSelectedLicenseKeyFileInformation_Agency
            '
            Me.LabelSelectedLicenseKeyFileInformation_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectedLicenseKeyFileInformation_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectedLicenseKeyFileInformation_Agency.Location = New System.Drawing.Point(5, 25)
            Me.LabelSelectedLicenseKeyFileInformation_Agency.Name = "LabelSelectedLicenseKeyFileInformation_Agency"
            Me.LabelSelectedLicenseKeyFileInformation_Agency.Size = New System.Drawing.Size(182, 20)
            Me.LabelSelectedLicenseKeyFileInformation_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectedLicenseKeyFileInformation_Agency.TabIndex = 0
            Me.LabelSelectedLicenseKeyFileInformation_Agency.Text = "Agency:"
            '
            'GroupBoxForm_CurrentLicenseKeyFileInformation
            '
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_AgencyName)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Controls.Add(Me.LabelCurrentLicenseKeyFileInformation_Agency)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Location = New System.Drawing.Point(4, 218)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Name = "GroupBoxForm_CurrentLicenseKeyFileInformation"
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Size = New System.Drawing.Size(636, 214)
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.TabIndex = 11
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.Text = "Current License Key File Information"
            '
            'LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo
            '
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Location = New System.Drawing.Point(193, 181)
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Name = "LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo"
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.TabIndex = 12
            '
            'LabelCurrentLicenseKeyFileInformation_ProofingEnabled
            '
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.Location = New System.Drawing.Point(5, 181)
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.Name = "LabelCurrentLicenseKeyFileInformation_ProofingEnabled"
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.TabIndex = 13
            Me.LabelCurrentLicenseKeyFileInformation_ProofingEnabled.Text = "Proofing Enabled?"
            '
            'LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount
            '
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Location = New System.Drawing.Point(193, 155)
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Name = "LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount"
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.TabIndex = 14
            '
            'LabelCurrentLicenseKeyFileInformation_APILicenseQuantity
            '
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.Location = New System.Drawing.Point(5, 155)
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.Name = "LabelCurrentLicenseKeyFileInformation_APILicenseQuantity"
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.TabIndex = 13
            Me.LabelCurrentLicenseKeyFileInformation_APILicenseQuantity.Text = "API License Quantity:"
            '
            'LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount
            '
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Location = New System.Drawing.Point(193, 129)
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Name = "LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount"
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.TabIndex = 12
            '
            'LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity
            '
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.Location = New System.Drawing.Point(5, 129)
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.Name = "LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity"
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.TabIndex = 11
            Me.LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity.Text = "Media Tools License Quantity:"
            '
            'LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount
            '
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Location = New System.Drawing.Point(193, 103)
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Name = "LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount"
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.TabIndex = 8
            '
            'LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount
            '
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Location = New System.Drawing.Point(193, 77)
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Name = "LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount"
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.TabIndex = 7
            '
            'LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount
            '
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Location = New System.Drawing.Point(193, 51)
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Name = "LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount"
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.TabIndex = 6
            '
            'LabelCurrentLicenseKeyFileInformation_AgencyName
            '
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.Location = New System.Drawing.Point(193, 25)
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.Name = "LabelCurrentLicenseKeyFileInformation_AgencyName"
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.TabIndex = 5
            Me.LabelCurrentLicenseKeyFileInformation_AgencyName.UseMnemonic = False
            '
            'LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity
            '
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Location = New System.Drawing.Point(5, 77)
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Name = "LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity"
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.TabIndex = 4
            Me.LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity.Text = "Webvantage Only License Quantity:"
            '
            'LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity
            '
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.Location = New System.Drawing.Point(5, 103)
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.Name = "LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity"
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.TabIndex = 3
            Me.LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity.Text = "Client Portal License Quantity:"
            '
            'LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity
            '
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.Location = New System.Drawing.Point(5, 51)
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.Name = "LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity"
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.TabIndex = 1
            Me.LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity.Text = "Power License Quantity:"
            '
            'LabelCurrentLicenseKeyFileInformation_Agency
            '
            Me.LabelCurrentLicenseKeyFileInformation_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentLicenseKeyFileInformation_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentLicenseKeyFileInformation_Agency.Location = New System.Drawing.Point(5, 25)
            Me.LabelCurrentLicenseKeyFileInformation_Agency.Name = "LabelCurrentLicenseKeyFileInformation_Agency"
            Me.LabelCurrentLicenseKeyFileInformation_Agency.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrentLicenseKeyFileInformation_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentLicenseKeyFileInformation_Agency.TabIndex = 0
            Me.LabelCurrentLicenseKeyFileInformation_Agency.Text = "Agency:"
            '
            'PanelForm_LicenseKeyInformation
            '
            Me.PanelForm_LicenseKeyInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_LicenseKeyInformation.Controls.Add(Me.GroupBoxForm_SelectedLicenseKeyFileInformation)
            Me.PanelForm_LicenseKeyInformation.Controls.Add(Me.GroupBoxForm_CurrentLicenseKeyFileInformation)
            Me.PanelForm_LicenseKeyInformation.Location = New System.Drawing.Point(12, 73)
            Me.PanelForm_LicenseKeyInformation.Name = "PanelForm_LicenseKeyInformation"
            Me.PanelForm_LicenseKeyInformation.Size = New System.Drawing.Size(645, 444)
            Me.PanelForm_LicenseKeyInformation.TabIndex = 15
            '
            'PanelForm_ComscoreLicenseInfo
            '
            Me.PanelForm_ComscoreLicenseInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_ComscoreLicenseInfo.Controls.Add(Me.GroupBoxComscoreSelectedLicenseInfo)
            Me.PanelForm_ComscoreLicenseInfo.Controls.Add(Me.GroupBoxComscoreCurrentLicenseInfo)
            Me.PanelForm_ComscoreLicenseInfo.Location = New System.Drawing.Point(12, 73)
            Me.PanelForm_ComscoreLicenseInfo.Name = "PanelForm_ComscoreLicenseInfo"
            Me.PanelForm_ComscoreLicenseInfo.Size = New System.Drawing.Size(645, 444)
            Me.PanelForm_ComscoreLicenseInfo.TabIndex = 16
            '
            'GroupBoxComscoreSelectedLicenseInfo
            '
            Me.GroupBoxComscoreSelectedLicenseInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxComscoreSelectedLicenseInfo.Controls.Add(Me.LabelComscoreSelected_ComscoreIDValue)
            Me.GroupBoxComscoreSelectedLicenseInfo.Controls.Add(Me.LabelComscoreSelected_AgencyName)
            Me.GroupBoxComscoreSelectedLicenseInfo.Controls.Add(Me.LabelComscoreSelected_ComscoreID)
            Me.GroupBoxComscoreSelectedLicenseInfo.Controls.Add(Me.LabelComscoreSelected_Agency)
            Me.GroupBoxComscoreSelectedLicenseInfo.Location = New System.Drawing.Point(4, 3)
            Me.GroupBoxComscoreSelectedLicenseInfo.Name = "GroupBoxComscoreSelectedLicenseInfo"
            Me.GroupBoxComscoreSelectedLicenseInfo.Size = New System.Drawing.Size(636, 81)
            Me.GroupBoxComscoreSelectedLicenseInfo.TabIndex = 10
            Me.GroupBoxComscoreSelectedLicenseInfo.Text = "Selected License Key File Information"
            '
            'LabelComscoreSelected_ComscoreIDValue
            '
            Me.LabelComscoreSelected_ComscoreIDValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelComscoreSelected_ComscoreIDValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreSelected_ComscoreIDValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreSelected_ComscoreIDValue.Location = New System.Drawing.Point(193, 51)
            Me.LabelComscoreSelected_ComscoreIDValue.Name = "LabelComscoreSelected_ComscoreIDValue"
            Me.LabelComscoreSelected_ComscoreIDValue.Size = New System.Drawing.Size(438, 20)
            Me.LabelComscoreSelected_ComscoreIDValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreSelected_ComscoreIDValue.TabIndex = 6
            '
            'LabelComscoreSelected_AgencyName
            '
            Me.LabelComscoreSelected_AgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelComscoreSelected_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreSelected_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreSelected_AgencyName.Location = New System.Drawing.Point(193, 25)
            Me.LabelComscoreSelected_AgencyName.Name = "LabelComscoreSelected_AgencyName"
            Me.LabelComscoreSelected_AgencyName.Size = New System.Drawing.Size(438, 20)
            Me.LabelComscoreSelected_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreSelected_AgencyName.TabIndex = 5
            Me.LabelComscoreSelected_AgencyName.UseMnemonic = False
            '
            'LabelComscoreSelected_ComscoreID
            '
            Me.LabelComscoreSelected_ComscoreID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreSelected_ComscoreID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreSelected_ComscoreID.Location = New System.Drawing.Point(5, 51)
            Me.LabelComscoreSelected_ComscoreID.Name = "LabelComscoreSelected_ComscoreID"
            Me.LabelComscoreSelected_ComscoreID.Size = New System.Drawing.Size(182, 20)
            Me.LabelComscoreSelected_ComscoreID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreSelected_ComscoreID.TabIndex = 1
            Me.LabelComscoreSelected_ComscoreID.Text = "Comscore Client ID:"
            '
            'LabelComscoreSelected_Agency
            '
            Me.LabelComscoreSelected_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreSelected_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreSelected_Agency.Location = New System.Drawing.Point(5, 25)
            Me.LabelComscoreSelected_Agency.Name = "LabelComscoreSelected_Agency"
            Me.LabelComscoreSelected_Agency.Size = New System.Drawing.Size(182, 20)
            Me.LabelComscoreSelected_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreSelected_Agency.TabIndex = 0
            Me.LabelComscoreSelected_Agency.Text = "Agency:"
            '
            'GroupBoxComscoreCurrentLicenseInfo
            '
            Me.GroupBoxComscoreCurrentLicenseInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxComscoreCurrentLicenseInfo.Controls.Add(Me.LabelCurrectComscore_ClientIDValue)
            Me.GroupBoxComscoreCurrentLicenseInfo.Controls.Add(Me.LabelCurrectComscore_AgencyName)
            Me.GroupBoxComscoreCurrentLicenseInfo.Controls.Add(Me.LabelCurrectComscore_ClientID)
            Me.GroupBoxComscoreCurrentLicenseInfo.Controls.Add(Me.LabelCurrectComscore_Agency)
            Me.GroupBoxComscoreCurrentLicenseInfo.Location = New System.Drawing.Point(4, 90)
            Me.GroupBoxComscoreCurrentLicenseInfo.Name = "GroupBoxComscoreCurrentLicenseInfo"
            Me.GroupBoxComscoreCurrentLicenseInfo.Size = New System.Drawing.Size(636, 347)
            Me.GroupBoxComscoreCurrentLicenseInfo.TabIndex = 11
            Me.GroupBoxComscoreCurrentLicenseInfo.Text = "Current License Key File Information"
            '
            'LabelCurrectComscore_ClientIDValue
            '
            Me.LabelCurrectComscore_ClientIDValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrectComscore_ClientIDValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrectComscore_ClientIDValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrectComscore_ClientIDValue.Location = New System.Drawing.Point(193, 51)
            Me.LabelCurrectComscore_ClientIDValue.Name = "LabelCurrectComscore_ClientIDValue"
            Me.LabelCurrectComscore_ClientIDValue.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrectComscore_ClientIDValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrectComscore_ClientIDValue.TabIndex = 6
            '
            'LabelCurrectComscore_AgencyName
            '
            Me.LabelCurrectComscore_AgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCurrectComscore_AgencyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrectComscore_AgencyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrectComscore_AgencyName.Location = New System.Drawing.Point(193, 25)
            Me.LabelCurrectComscore_AgencyName.Name = "LabelCurrectComscore_AgencyName"
            Me.LabelCurrectComscore_AgencyName.Size = New System.Drawing.Size(438, 20)
            Me.LabelCurrectComscore_AgencyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrectComscore_AgencyName.TabIndex = 5
            Me.LabelCurrectComscore_AgencyName.UseMnemonic = False
            '
            'LabelCurrectComscore_ClientID
            '
            Me.LabelCurrectComscore_ClientID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrectComscore_ClientID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrectComscore_ClientID.Location = New System.Drawing.Point(5, 51)
            Me.LabelCurrectComscore_ClientID.Name = "LabelCurrectComscore_ClientID"
            Me.LabelCurrectComscore_ClientID.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrectComscore_ClientID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrectComscore_ClientID.TabIndex = 1
            Me.LabelCurrectComscore_ClientID.Text = "Comscore Client ID:"
            '
            'LabelCurrectComscore_Agency
            '
            Me.LabelCurrectComscore_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrectComscore_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrectComscore_Agency.Location = New System.Drawing.Point(5, 25)
            Me.LabelCurrectComscore_Agency.Name = "LabelCurrectComscore_Agency"
            Me.LabelCurrectComscore_Agency.Size = New System.Drawing.Size(182, 20)
            Me.LabelCurrectComscore_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrectComscore_Agency.TabIndex = 0
            Me.LabelCurrectComscore_Agency.Text = "Agency:"
            '
            'LicenseKeyImportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(669, 523)
            Me.Controls.Add(Me.PanelForm_LicenseKeyInformation)
            Me.Controls.Add(Me.PanelForm_ComscoreLicenseInfo)
            Me.Controls.Add(Me.TextBoxForm_LicenseKeyFile)
            Me.Controls.Add(Me.LabelForm_LicenseKeyFile)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "LicenseKeyImportForm"
            Me.Text = "License Key Import"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.GroupBoxForm_SelectedLicenseKeyFileInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_SelectedLicenseKeyFileInformation.ResumeLayout(False)
            CType(Me.GroupBoxForm_CurrentLicenseKeyFileInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_CurrentLicenseKeyFileInformation.ResumeLayout(False)
            Me.PanelForm_LicenseKeyInformation.ResumeLayout(False)
            Me.PanelForm_ComscoreLicenseInfo.ResumeLayout(False)
            CType(Me.GroupBoxComscoreSelectedLicenseInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxComscoreSelectedLicenseInfo.ResumeLayout(False)
            CType(Me.GroupBoxComscoreCurrentLicenseInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxComscoreCurrentLicenseInfo.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Import As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxForm_LicenseKeyFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_LicenseKeyFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_SelectedLicenseKeyFileInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_Agency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_AgencyName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_CurrentLicenseKeyFileInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_AgencyName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_Agency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_APILicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_APILicenseQuantity As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_LicenseKeyInformation As Windows.Forms.Panel
        Friend WithEvents PanelForm_ComscoreLicenseInfo As Windows.Forms.Panel
        Friend WithEvents GroupBoxComscoreSelectedLicenseInfo As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelComscoreSelected_ComscoreIDValue As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComscoreSelected_AgencyName As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComscoreSelected_ComscoreID As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelComscoreSelected_Agency As WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxComscoreCurrentLicenseInfo As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCurrectComscore_ClientIDValue As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrectComscore_AgencyName As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrectComscore_ClientID As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrectComscore_Agency As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_ProofingEnabled As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_ProofingEnabled As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo As WinForm.Presentation.Controls.Label
    End Class

End Namespace
