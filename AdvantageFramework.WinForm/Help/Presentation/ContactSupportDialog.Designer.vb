Namespace Help.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ContactSupportDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContactSupportDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Send = New DevComponents.DotNetBar.ButtonItem()
            Me.CheckBoxForm_TechnicalSupport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_SoftwareSupport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxClientInformation_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelClientInformation_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_SupportDepartment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_ClientInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelClientInformation_EmployeeName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxClientInformation_EmployeeName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.AddressControlClientInformation_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.LabelClientInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxClientInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxClientInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelClientInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_IssueType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonIssueType_Enhancement = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonIssueType_Problem = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonIssueType_Bug = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxForm_Priority = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonPriority_Low = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPriority_Medium = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPriority_High = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_DescriptionOfIssue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_DescriptionOfIssue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_ClientInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_ClientInformation.SuspendLayout()
            CType(Me.GroupBoxForm_IssueType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_IssueType.SuspendLayout()
            CType(Me.GroupBoxForm_Priority, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Priority.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(946, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(946, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(2)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 91)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.LabelSettings_SupportDepartment)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_DescriptionOfIssue)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DescriptionOfIssue)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_Priority)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_IssueType)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_ClientInformation)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_SoftwareSupport)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_TechnicalSupport)
            Me.PanelForm_Form.Size = New System.Drawing.Size(946, 495)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 650)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(946, 18)
            Me.BarForm_StatusBar.Visible = True
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Send})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(63, 91)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'ButtonItemActions_Send
            '
            Me.ButtonItemActions_Send.BeginGroup = True
            Me.ButtonItemActions_Send.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Send.Name = "ButtonItemActions_Send"
            Me.ButtonItemActions_Send.RibbonWordWrap = False
            Me.ButtonItemActions_Send.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Send.Text = "Send"
            '
            'CheckBoxForm_TechnicalSupport
            '
            '
            '
            '
            Me.CheckBoxForm_TechnicalSupport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_TechnicalSupport.CheckValue = 0
            Me.CheckBoxForm_TechnicalSupport.CheckValueChecked = 1
            Me.CheckBoxForm_TechnicalSupport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_TechnicalSupport.CheckValueUnchecked = 0
            Me.CheckBoxForm_TechnicalSupport.ChildControls = CType(resources.GetObject("CheckBoxForm_TechnicalSupport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TechnicalSupport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_TechnicalSupport.Location = New System.Drawing.Point(3, 30)
            Me.CheckBoxForm_TechnicalSupport.Name = "CheckBoxForm_TechnicalSupport"
            Me.CheckBoxForm_TechnicalSupport.OldestSibling = Nothing
            Me.CheckBoxForm_TechnicalSupport.SecurityEnabled = True
            Me.CheckBoxForm_TechnicalSupport.SiblingControls = CType(resources.GetObject("CheckBoxForm_TechnicalSupport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TechnicalSupport.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxForm_TechnicalSupport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TechnicalSupport.TabIndex = 2
            Me.CheckBoxForm_TechnicalSupport.TabOnEnter = True
            Me.CheckBoxForm_TechnicalSupport.Text = "Technical Support"
            '
            'CheckBoxForm_SoftwareSupport
            '
            '
            '
            '
            Me.CheckBoxForm_SoftwareSupport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SoftwareSupport.CheckValue = 0
            Me.CheckBoxForm_SoftwareSupport.CheckValueChecked = 1
            Me.CheckBoxForm_SoftwareSupport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SoftwareSupport.CheckValueUnchecked = 0
            Me.CheckBoxForm_SoftwareSupport.ChildControls = CType(resources.GetObject("CheckBoxForm_SoftwareSupport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SoftwareSupport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SoftwareSupport.Location = New System.Drawing.Point(129, 30)
            Me.CheckBoxForm_SoftwareSupport.Name = "CheckBoxForm_SoftwareSupport"
            Me.CheckBoxForm_SoftwareSupport.OldestSibling = Nothing
            Me.CheckBoxForm_SoftwareSupport.SecurityEnabled = True
            Me.CheckBoxForm_SoftwareSupport.SiblingControls = CType(resources.GetObject("CheckBoxForm_SoftwareSupport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SoftwareSupport.Size = New System.Drawing.Size(113, 20)
            Me.CheckBoxForm_SoftwareSupport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SoftwareSupport.TabIndex = 3
            Me.CheckBoxForm_SoftwareSupport.TabOnEnter = True
            Me.CheckBoxForm_SoftwareSupport.Text = "Software Support"
            '
            'TextBoxClientInformation_EmailAddress
            '
            Me.TextBoxClientInformation_EmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxClientInformation_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxClientInformation_EmailAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxClientInformation_EmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxClientInformation_EmailAddress.CheckSpellingOnValidate = False
            Me.TextBoxClientInformation_EmailAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxClientInformation_EmailAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxClientInformation_EmailAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxClientInformation_EmailAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxClientInformation_EmailAddress.FocusHighlightEnabled = True
            Me.TextBoxClientInformation_EmailAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxClientInformation_EmailAddress.Location = New System.Drawing.Point(101, 105)
            Me.TextBoxClientInformation_EmailAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxClientInformation_EmailAddress.Name = "TextBoxClientInformation_EmailAddress"
            Me.TextBoxClientInformation_EmailAddress.SecurityEnabled = True
            Me.TextBoxClientInformation_EmailAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxClientInformation_EmailAddress.Size = New System.Drawing.Size(378, 21)
            Me.TextBoxClientInformation_EmailAddress.StartingFolderName = Nothing
            Me.TextBoxClientInformation_EmailAddress.TabIndex = 7
            Me.TextBoxClientInformation_EmailAddress.TabOnEnter = True
            '
            'LabelClientInformation_EmailAddress
            '
            Me.LabelClientInformation_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelClientInformation_EmailAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelClientInformation_EmailAddress.Location = New System.Drawing.Point(5, 105)
            Me.LabelClientInformation_EmailAddress.Name = "LabelClientInformation_EmailAddress"
            Me.LabelClientInformation_EmailAddress.Size = New System.Drawing.Size(90, 20)
            Me.LabelClientInformation_EmailAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelClientInformation_EmailAddress.TabIndex = 6
            Me.LabelClientInformation_EmailAddress.Text = "Email Address:"
            '
            'LabelSettings_SupportDepartment
            '
            Me.LabelSettings_SupportDepartment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SupportDepartment.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SupportDepartment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_SupportDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSettings_SupportDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSettings_SupportDepartment.Location = New System.Drawing.Point(3, 3)
            Me.LabelSettings_SupportDepartment.Name = "LabelSettings_SupportDepartment"
            Me.LabelSettings_SupportDepartment.Size = New System.Drawing.Size(484, 20)
            Me.LabelSettings_SupportDepartment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_SupportDepartment.TabIndex = 1
            Me.LabelSettings_SupportDepartment.Text = "Support Department"
            '
            'GroupBoxForm_ClientInformation
            '
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.LabelClientInformation_EmployeeName)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.TextBoxClientInformation_EmployeeName)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.AddressControlClientInformation_Address)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.LabelClientInformation_Name)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.TextBoxClientInformation_Name)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.TextBoxClientInformation_Phone)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.TextBoxClientInformation_EmailAddress)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.LabelClientInformation_Phone)
            Me.GroupBoxForm_ClientInformation.Controls.Add(Me.LabelClientInformation_EmailAddress)
            Me.GroupBoxForm_ClientInformation.Location = New System.Drawing.Point(3, 57)
            Me.GroupBoxForm_ClientInformation.Name = "GroupBoxForm_ClientInformation"
            Me.GroupBoxForm_ClientInformation.Size = New System.Drawing.Size(484, 316)
            Me.GroupBoxForm_ClientInformation.TabIndex = 0
            Me.GroupBoxForm_ClientInformation.Text = "Client Information"
            '
            'LabelClientInformation_EmployeeName
            '
            Me.LabelClientInformation_EmployeeName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelClientInformation_EmployeeName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelClientInformation_EmployeeName.Location = New System.Drawing.Point(5, 51)
            Me.LabelClientInformation_EmployeeName.Name = "LabelClientInformation_EmployeeName"
            Me.LabelClientInformation_EmployeeName.Size = New System.Drawing.Size(90, 20)
            Me.LabelClientInformation_EmployeeName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelClientInformation_EmployeeName.TabIndex = 2
            Me.LabelClientInformation_EmployeeName.Text = "Employee Name:"
            '
            'TextBoxClientInformation_EmployeeName
            '
            Me.TextBoxClientInformation_EmployeeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxClientInformation_EmployeeName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxClientInformation_EmployeeName.Border.Class = "TextBoxBorder"
            Me.TextBoxClientInformation_EmployeeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxClientInformation_EmployeeName.CheckSpellingOnValidate = False
            Me.TextBoxClientInformation_EmployeeName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxClientInformation_EmployeeName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxClientInformation_EmployeeName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxClientInformation_EmployeeName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxClientInformation_EmployeeName.FocusHighlightEnabled = True
            Me.TextBoxClientInformation_EmployeeName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxClientInformation_EmployeeName.Location = New System.Drawing.Point(101, 51)
            Me.TextBoxClientInformation_EmployeeName.MaxFileSize = CType(0, Long)
            Me.TextBoxClientInformation_EmployeeName.Name = "TextBoxClientInformation_EmployeeName"
            Me.TextBoxClientInformation_EmployeeName.SecurityEnabled = True
            Me.TextBoxClientInformation_EmployeeName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxClientInformation_EmployeeName.Size = New System.Drawing.Size(378, 21)
            Me.TextBoxClientInformation_EmployeeName.StartingFolderName = Nothing
            Me.TextBoxClientInformation_EmployeeName.TabIndex = 3
            Me.TextBoxClientInformation_EmployeeName.TabOnEnter = True
            '
            'AddressControlClientInformation_Address
            '
            Me.AddressControlClientInformation_Address.Address = Nothing
            Me.AddressControlClientInformation_Address.Address2 = Nothing
            Me.AddressControlClientInformation_Address.Address3 = Nothing
            Me.AddressControlClientInformation_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlClientInformation_Address.City = Nothing
            Me.AddressControlClientInformation_Address.Country = Nothing
            Me.AddressControlClientInformation_Address.County = Nothing
            Me.AddressControlClientInformation_Address.DisableCountry = True
            Me.AddressControlClientInformation_Address.DisableCounty = True
            Me.AddressControlClientInformation_Address.Location = New System.Drawing.Point(6, 133)
            Me.AddressControlClientInformation_Address.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlClientInformation_Address.Name = "AddressControlClientInformation_Address"
            Me.AddressControlClientInformation_Address.ReadOnly = False
            Me.AddressControlClientInformation_Address.ShowCountry = True
            Me.AddressControlClientInformation_Address.ShowCounty = True
            Me.AddressControlClientInformation_Address.Size = New System.Drawing.Size(472, 177)
            Me.AddressControlClientInformation_Address.State = Nothing
            Me.AddressControlClientInformation_Address.TabIndex = 8
            Me.AddressControlClientInformation_Address.Title = "Address"
            Me.AddressControlClientInformation_Address.Zip = Nothing
            '
            'LabelClientInformation_Name
            '
            Me.LabelClientInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelClientInformation_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelClientInformation_Name.Location = New System.Drawing.Point(5, 24)
            Me.LabelClientInformation_Name.Name = "LabelClientInformation_Name"
            Me.LabelClientInformation_Name.Size = New System.Drawing.Size(90, 20)
            Me.LabelClientInformation_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelClientInformation_Name.TabIndex = 0
            Me.LabelClientInformation_Name.Text = "Name:"
            '
            'TextBoxClientInformation_Name
            '
            Me.TextBoxClientInformation_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxClientInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxClientInformation_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxClientInformation_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxClientInformation_Name.CheckSpellingOnValidate = False
            Me.TextBoxClientInformation_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxClientInformation_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxClientInformation_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxClientInformation_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxClientInformation_Name.FocusHighlightEnabled = True
            Me.TextBoxClientInformation_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxClientInformation_Name.Location = New System.Drawing.Point(101, 24)
            Me.TextBoxClientInformation_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxClientInformation_Name.Name = "TextBoxClientInformation_Name"
            Me.TextBoxClientInformation_Name.SecurityEnabled = True
            Me.TextBoxClientInformation_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxClientInformation_Name.Size = New System.Drawing.Size(378, 21)
            Me.TextBoxClientInformation_Name.StartingFolderName = Nothing
            Me.TextBoxClientInformation_Name.TabIndex = 1
            Me.TextBoxClientInformation_Name.TabOnEnter = True
            '
            'TextBoxClientInformation_Phone
            '
            Me.TextBoxClientInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxClientInformation_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxClientInformation_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxClientInformation_Phone.CheckSpellingOnValidate = False
            Me.TextBoxClientInformation_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxClientInformation_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxClientInformation_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxClientInformation_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxClientInformation_Phone.FocusHighlightEnabled = True
            Me.TextBoxClientInformation_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxClientInformation_Phone.Location = New System.Drawing.Point(101, 78)
            Me.TextBoxClientInformation_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxClientInformation_Phone.Name = "TextBoxClientInformation_Phone"
            Me.TextBoxClientInformation_Phone.SecurityEnabled = True
            Me.TextBoxClientInformation_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxClientInformation_Phone.Size = New System.Drawing.Size(92, 21)
            Me.TextBoxClientInformation_Phone.StartingFolderName = Nothing
            Me.TextBoxClientInformation_Phone.TabIndex = 5
            Me.TextBoxClientInformation_Phone.TabOnEnter = True
            '
            'LabelClientInformation_Phone
            '
            Me.LabelClientInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelClientInformation_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelClientInformation_Phone.Location = New System.Drawing.Point(5, 79)
            Me.LabelClientInformation_Phone.Name = "LabelClientInformation_Phone"
            Me.LabelClientInformation_Phone.Size = New System.Drawing.Size(90, 20)
            Me.LabelClientInformation_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelClientInformation_Phone.TabIndex = 4
            Me.LabelClientInformation_Phone.Text = "Phone:"
            '
            'GroupBoxForm_IssueType
            '
            Me.GroupBoxForm_IssueType.Controls.Add(Me.RadioButtonIssueType_Enhancement)
            Me.GroupBoxForm_IssueType.Controls.Add(Me.RadioButtonIssueType_Problem)
            Me.GroupBoxForm_IssueType.Controls.Add(Me.RadioButtonIssueType_Bug)
            Me.GroupBoxForm_IssueType.Location = New System.Drawing.Point(4, 379)
            Me.GroupBoxForm_IssueType.Name = "GroupBoxForm_IssueType"
            Me.GroupBoxForm_IssueType.Size = New System.Drawing.Size(239, 59)
            Me.GroupBoxForm_IssueType.TabIndex = 5
            Me.GroupBoxForm_IssueType.Text = "Issue Type"
            '
            'RadioButtonIssueType_Enhancement
            '
            Me.RadioButtonIssueType_Enhancement.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonIssueType_Enhancement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonIssueType_Enhancement.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonIssueType_Enhancement.Location = New System.Drawing.Point(139, 24)
            Me.RadioButtonIssueType_Enhancement.Name = "RadioButtonIssueType_Enhancement"
            Me.RadioButtonIssueType_Enhancement.SecurityEnabled = True
            Me.RadioButtonIssueType_Enhancement.Size = New System.Drawing.Size(95, 20)
            Me.RadioButtonIssueType_Enhancement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonIssueType_Enhancement.TabIndex = 2
            Me.RadioButtonIssueType_Enhancement.TabOnEnter = True
            Me.RadioButtonIssueType_Enhancement.TabStop = False
            Me.RadioButtonIssueType_Enhancement.Text = "Enhancement"
            '
            'RadioButtonIssueType_Problem
            '
            Me.RadioButtonIssueType_Problem.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonIssueType_Problem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonIssueType_Problem.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonIssueType_Problem.Location = New System.Drawing.Point(61, 24)
            Me.RadioButtonIssueType_Problem.Name = "RadioButtonIssueType_Problem"
            Me.RadioButtonIssueType_Problem.SecurityEnabled = True
            Me.RadioButtonIssueType_Problem.Size = New System.Drawing.Size(72, 20)
            Me.RadioButtonIssueType_Problem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonIssueType_Problem.TabIndex = 1
            Me.RadioButtonIssueType_Problem.TabOnEnter = True
            Me.RadioButtonIssueType_Problem.TabStop = False
            Me.RadioButtonIssueType_Problem.Text = "Problem"
            '
            'RadioButtonIssueType_Bug
            '
            Me.RadioButtonIssueType_Bug.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonIssueType_Bug.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonIssueType_Bug.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonIssueType_Bug.Checked = True
            Me.RadioButtonIssueType_Bug.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonIssueType_Bug.CheckValue = "Y"
            Me.RadioButtonIssueType_Bug.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonIssueType_Bug.Name = "RadioButtonIssueType_Bug"
            Me.RadioButtonIssueType_Bug.SecurityEnabled = True
            Me.RadioButtonIssueType_Bug.Size = New System.Drawing.Size(50, 20)
            Me.RadioButtonIssueType_Bug.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonIssueType_Bug.TabIndex = 0
            Me.RadioButtonIssueType_Bug.TabOnEnter = True
            Me.RadioButtonIssueType_Bug.Text = "Bug"
            '
            'GroupBoxForm_Priority
            '
            Me.GroupBoxForm_Priority.Controls.Add(Me.RadioButtonPriority_Low)
            Me.GroupBoxForm_Priority.Controls.Add(Me.RadioButtonPriority_Medium)
            Me.GroupBoxForm_Priority.Controls.Add(Me.RadioButtonPriority_High)
            Me.GroupBoxForm_Priority.Location = New System.Drawing.Point(249, 379)
            Me.GroupBoxForm_Priority.Name = "GroupBoxForm_Priority"
            Me.GroupBoxForm_Priority.Size = New System.Drawing.Size(238, 59)
            Me.GroupBoxForm_Priority.TabIndex = 6
            Me.GroupBoxForm_Priority.Text = "Priority"
            '
            'RadioButtonPriority_Low
            '
            Me.RadioButtonPriority_Low.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPriority_Low.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPriority_Low.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPriority_Low.Location = New System.Drawing.Point(151, 24)
            Me.RadioButtonPriority_Low.Name = "RadioButtonPriority_Low"
            Me.RadioButtonPriority_Low.SecurityEnabled = True
            Me.RadioButtonPriority_Low.Size = New System.Drawing.Size(82, 20)
            Me.RadioButtonPriority_Low.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPriority_Low.TabIndex = 2
            Me.RadioButtonPriority_Low.TabOnEnter = True
            Me.RadioButtonPriority_Low.TabStop = False
            Me.RadioButtonPriority_Low.Text = "Low"
            '
            'RadioButtonPriority_Medium
            '
            Me.RadioButtonPriority_Medium.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPriority_Medium.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPriority_Medium.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPriority_Medium.Checked = True
            Me.RadioButtonPriority_Medium.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonPriority_Medium.CheckValue = "Y"
            Me.RadioButtonPriority_Medium.Location = New System.Drawing.Point(71, 24)
            Me.RadioButtonPriority_Medium.Name = "RadioButtonPriority_Medium"
            Me.RadioButtonPriority_Medium.SecurityEnabled = True
            Me.RadioButtonPriority_Medium.Size = New System.Drawing.Size(74, 20)
            Me.RadioButtonPriority_Medium.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPriority_Medium.TabIndex = 1
            Me.RadioButtonPriority_Medium.TabOnEnter = True
            Me.RadioButtonPriority_Medium.Text = "Medium"
            '
            'RadioButtonPriority_High
            '
            Me.RadioButtonPriority_High.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPriority_High.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPriority_High.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPriority_High.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonPriority_High.Name = "RadioButtonPriority_High"
            Me.RadioButtonPriority_High.SecurityEnabled = True
            Me.RadioButtonPriority_High.Size = New System.Drawing.Size(60, 20)
            Me.RadioButtonPriority_High.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPriority_High.TabIndex = 0
            Me.RadioButtonPriority_High.TabOnEnter = True
            Me.RadioButtonPriority_High.TabStop = False
            Me.RadioButtonPriority_High.Text = "High"
            '
            'LabelForm_DescriptionOfIssue
            '
            Me.LabelForm_DescriptionOfIssue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DescriptionOfIssue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_DescriptionOfIssue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DescriptionOfIssue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_DescriptionOfIssue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_DescriptionOfIssue.Location = New System.Drawing.Point(493, 3)
            Me.LabelForm_DescriptionOfIssue.Name = "LabelForm_DescriptionOfIssue"
            Me.LabelForm_DescriptionOfIssue.Size = New System.Drawing.Size(450, 20)
            Me.LabelForm_DescriptionOfIssue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DescriptionOfIssue.TabIndex = 7
            Me.LabelForm_DescriptionOfIssue.Text = "Description of Issue"
            '
            'TextBoxForm_DescriptionOfIssue
            '
            Me.TextBoxForm_DescriptionOfIssue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_DescriptionOfIssue.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_DescriptionOfIssue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_DescriptionOfIssue.CheckSpellingOnValidate = False
            Me.TextBoxForm_DescriptionOfIssue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_DescriptionOfIssue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_DescriptionOfIssue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_DescriptionOfIssue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_DescriptionOfIssue.FocusHighlightEnabled = True
            Me.TextBoxForm_DescriptionOfIssue.Location = New System.Drawing.Point(493, 30)
            Me.TextBoxForm_DescriptionOfIssue.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_DescriptionOfIssue.Multiline = True
            Me.TextBoxForm_DescriptionOfIssue.Name = "TextBoxForm_DescriptionOfIssue"
            Me.TextBoxForm_DescriptionOfIssue.SecurityEnabled = True
            Me.TextBoxForm_DescriptionOfIssue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_DescriptionOfIssue.Size = New System.Drawing.Size(450, 461)
            Me.TextBoxForm_DescriptionOfIssue.StartingFolderName = Nothing
            Me.TextBoxForm_DescriptionOfIssue.TabIndex = 8
            Me.TextBoxForm_DescriptionOfIssue.TabOnEnter = True
            '
            'ContactSupportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(956, 670)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "ContactSupportDialog"
            Me.Text = "Contact Support"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_ClientInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_ClientInformation.ResumeLayout(False)
            CType(Me.GroupBoxForm_IssueType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_IssueType.ResumeLayout(False)
            CType(Me.GroupBoxForm_Priority, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Priority.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Send As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents CheckBoxForm_TechnicalSupport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_SoftwareSupport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxClientInformation_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelClientInformation_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_SupportDepartment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_ClientInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents AddressControlClientInformation_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents LabelClientInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxClientInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxClientInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelClientInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_IssueType As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_Priority As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonIssueType_Enhancement As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonIssueType_Problem As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonIssueType_Bug As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPriority_Low As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPriority_Medium As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPriority_High As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_DescriptionOfIssue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_DescriptionOfIssue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelClientInformation_EmployeeName As WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxClientInformation_EmployeeName As WinForm.Presentation.Controls.TextBox
    End Class

End Namespace