<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBoxForm_DatabaseSettings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.ButtonDatabaseSettings_Test = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonDatabaseSettings_Build = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TextBoxDatabaseSettings_ConnectionString = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelDatabaseSettings_ConnectionString = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar1 = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.QatCustomizeItem1 = New DevComponents.DotNetBar.QatCustomizeItem()
        Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.CheckBoxEnforcePasswordPolicy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxAddOnlyToDatabase = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxIsFirst = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TextBox1 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.Label5 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.IntegerInputIsAdvantageAdmin = New DevComponents.Editors.IntegerInput()
        Me.Label4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.IntegerInputIsSecurityAdmin = New DevComponents.Editors.IntegerInput()
        Me.Label3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.IntegerInputPasswordColumn = New DevComponents.Editors.IntegerInput()
        Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.IntegerInputUserNameColumn = New DevComponents.Editors.IntegerInput()
        Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxMustChangeAtNextLogin = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        CType(Me.GroupBoxForm_DatabaseSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxForm_DatabaseSettings.SuspendLayout()
        Me.RibbonControl1.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.IntegerInputIsAdvantageAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInputIsSecurityAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInputPasswordColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerInputUserNameColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxForm_DatabaseSettings
        '
        Me.GroupBoxForm_DatabaseSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxForm_DatabaseSettings.Controls.Add(Me.ButtonDatabaseSettings_Test)
        Me.GroupBoxForm_DatabaseSettings.Controls.Add(Me.ButtonDatabaseSettings_Build)
        Me.GroupBoxForm_DatabaseSettings.Controls.Add(Me.TextBoxDatabaseSettings_ConnectionString)
        Me.GroupBoxForm_DatabaseSettings.Controls.Add(Me.LabelDatabaseSettings_ConnectionString)
        Me.GroupBoxForm_DatabaseSettings.Location = New System.Drawing.Point(17, 155)
        Me.GroupBoxForm_DatabaseSettings.Name = "GroupBoxForm_DatabaseSettings"
        Me.GroupBoxForm_DatabaseSettings.Size = New System.Drawing.Size(957, 75)
        Me.GroupBoxForm_DatabaseSettings.TabIndex = 3
        Me.GroupBoxForm_DatabaseSettings.Text = "Database Settings"
        '
        'ButtonDatabaseSettings_Test
        '
        Me.ButtonDatabaseSettings_Test.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonDatabaseSettings_Test.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDatabaseSettings_Test.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonDatabaseSettings_Test.Location = New System.Drawing.Point(876, 49)
        Me.ButtonDatabaseSettings_Test.Name = "ButtonDatabaseSettings_Test"
        Me.ButtonDatabaseSettings_Test.SecurityEnabled = True
        Me.ButtonDatabaseSettings_Test.Size = New System.Drawing.Size(75, 20)
        Me.ButtonDatabaseSettings_Test.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonDatabaseSettings_Test.TabIndex = 3
        Me.ButtonDatabaseSettings_Test.Text = "Test"
        '
        'ButtonDatabaseSettings_Build
        '
        Me.ButtonDatabaseSettings_Build.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonDatabaseSettings_Build.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDatabaseSettings_Build.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonDatabaseSettings_Build.Location = New System.Drawing.Point(795, 49)
        Me.ButtonDatabaseSettings_Build.Name = "ButtonDatabaseSettings_Build"
        Me.ButtonDatabaseSettings_Build.SecurityEnabled = True
        Me.ButtonDatabaseSettings_Build.Size = New System.Drawing.Size(75, 20)
        Me.ButtonDatabaseSettings_Build.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonDatabaseSettings_Build.TabIndex = 2
        Me.ButtonDatabaseSettings_Build.Text = "Build"
        '
        'TextBoxDatabaseSettings_ConnectionString
        '
        Me.TextBoxDatabaseSettings_ConnectionString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDatabaseSettings_ConnectionString.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxDatabaseSettings_ConnectionString.Border.Class = "TextBoxBorder"
        Me.TextBoxDatabaseSettings_ConnectionString.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxDatabaseSettings_ConnectionString.CheckSpellingOnValidate = False
        Me.TextBoxDatabaseSettings_ConnectionString.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxDatabaseSettings_ConnectionString.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxDatabaseSettings_ConnectionString.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxDatabaseSettings_ConnectionString.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxDatabaseSettings_ConnectionString.FocusHighlightEnabled = True
        Me.TextBoxDatabaseSettings_ConnectionString.ForeColor = System.Drawing.Color.Black
        Me.TextBoxDatabaseSettings_ConnectionString.Location = New System.Drawing.Point(119, 23)
        Me.TextBoxDatabaseSettings_ConnectionString.MaxFileSize = CType(0, Long)
        Me.TextBoxDatabaseSettings_ConnectionString.Name = "TextBoxDatabaseSettings_ConnectionString"
        Me.TextBoxDatabaseSettings_ConnectionString.ReadOnly = True
        Me.TextBoxDatabaseSettings_ConnectionString.SecurityEnabled = True
        Me.TextBoxDatabaseSettings_ConnectionString.ShowSpellCheckCompleteMessage = True
        Me.TextBoxDatabaseSettings_ConnectionString.Size = New System.Drawing.Size(832, 20)
        Me.TextBoxDatabaseSettings_ConnectionString.StartingFolderName = Nothing
        Me.TextBoxDatabaseSettings_ConnectionString.TabIndex = 1
        Me.TextBoxDatabaseSettings_ConnectionString.TabOnEnter = True
        '
        'LabelDatabaseSettings_ConnectionString
        '
        Me.LabelDatabaseSettings_ConnectionString.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelDatabaseSettings_ConnectionString.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelDatabaseSettings_ConnectionString.Location = New System.Drawing.Point(13, 23)
        Me.LabelDatabaseSettings_ConnectionString.Name = "LabelDatabaseSettings_ConnectionString"
        Me.LabelDatabaseSettings_ConnectionString.Size = New System.Drawing.Size(100, 20)
        Me.LabelDatabaseSettings_ConnectionString.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelDatabaseSettings_ConnectionString.TabIndex = 0
        Me.LabelDatabaseSettings_ConnectionString.Text = "Connection String:"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl1.CaptionVisible = True
        Me.RibbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl1.ForeColor = System.Drawing.Color.Black
        Me.RibbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem1})
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.RibbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.QatCustomizeItem1})
        Me.RibbonControl1.Size = New System.Drawing.Size(981, 154)
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl1.TabGroupHeight = 14
        Me.RibbonControl1.TabIndex = 4
        Me.RibbonControl1.Text = "RibbonControl1"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanel1.Size = New System.Drawing.Size(981, 98)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.SecurityEnabled = True
        Me.RibbonBar1.Size = New System.Drawing.Size(77, 95)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = "Actions"
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItemsExpandWidth = 14
        Me.ButtonItem1.Text = "Import"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.Checked = True
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel1
        Me.RibbonTabItem1.Text = "File"
        '
        'QatCustomizeItem1
        '
        Me.QatCustomizeItem1.Name = "QatCustomizeItem1"
        '
        'StyleManager
        '
        Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CheckBoxMustChangeAtNextLogin)
        Me.GroupBox1.Controls.Add(Me.CheckBoxEnforcePasswordPolicy)
        Me.GroupBox1.Controls.Add(Me.CheckBoxAddOnlyToDatabase)
        Me.GroupBox1.Controls.Add(Me.CheckBoxIsFirst)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.IntegerInputIsAdvantageAdmin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.IntegerInputIsSecurityAdmin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.IntegerInputPasswordColumn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.IntegerInputUserNameColumn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 236)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(957, 75)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.Text = "File Settings"
        '
        'CheckBoxEnforcePasswordPolicy
        '
        '
        '
        '
        Me.CheckBoxEnforcePasswordPolicy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxEnforcePasswordPolicy.CheckValue = 0
        Me.CheckBoxEnforcePasswordPolicy.CheckValueChecked = 1
        Me.CheckBoxEnforcePasswordPolicy.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxEnforcePasswordPolicy.CheckValueUnchecked = 0
        Me.CheckBoxEnforcePasswordPolicy.ChildControls = Nothing
        Me.CheckBoxEnforcePasswordPolicy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxEnforcePasswordPolicy.Location = New System.Drawing.Point(639, 51)
        Me.CheckBoxEnforcePasswordPolicy.Name = "CheckBoxEnforcePasswordPolicy"
        Me.CheckBoxEnforcePasswordPolicy.OldestSibling = Nothing
        Me.CheckBoxEnforcePasswordPolicy.SecurityEnabled = True
        Me.CheckBoxEnforcePasswordPolicy.SiblingControls = Nothing
        Me.CheckBoxEnforcePasswordPolicy.Size = New System.Drawing.Size(145, 20)
        Me.CheckBoxEnforcePasswordPolicy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxEnforcePasswordPolicy.TabIndex = 13
        Me.CheckBoxEnforcePasswordPolicy.Text = "Enforce Password Policy"
        '
        'CheckBoxAddOnlyToDatabase
        '
        '
        '
        '
        Me.CheckBoxAddOnlyToDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxAddOnlyToDatabase.CheckValue = 0
        Me.CheckBoxAddOnlyToDatabase.CheckValueChecked = 1
        Me.CheckBoxAddOnlyToDatabase.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxAddOnlyToDatabase.CheckValueUnchecked = 0
        Me.CheckBoxAddOnlyToDatabase.ChildControls = CType(resources.GetObject("CheckBoxAddOnlyToDatabase.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxAddOnlyToDatabase.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxAddOnlyToDatabase.Location = New System.Drawing.Point(639, 24)
        Me.CheckBoxAddOnlyToDatabase.Name = "CheckBoxAddOnlyToDatabase"
        Me.CheckBoxAddOnlyToDatabase.OldestSibling = Nothing
        Me.CheckBoxAddOnlyToDatabase.SecurityEnabled = True
        Me.CheckBoxAddOnlyToDatabase.SiblingControls = CType(resources.GetObject("CheckBoxAddOnlyToDatabase.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxAddOnlyToDatabase.Size = New System.Drawing.Size(145, 20)
        Me.CheckBoxAddOnlyToDatabase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxAddOnlyToDatabase.TabIndex = 12
        Me.CheckBoxAddOnlyToDatabase.Text = "Add Only to database"
        '
        'CheckBoxIsFirst
        '
        '
        '
        '
        Me.CheckBoxIsFirst.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxIsFirst.CheckValue = 0
        Me.CheckBoxIsFirst.CheckValueChecked = 1
        Me.CheckBoxIsFirst.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxIsFirst.CheckValueUnchecked = 0
        Me.CheckBoxIsFirst.ChildControls = CType(resources.GetObject("CheckBoxIsFirst.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxIsFirst.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxIsFirst.Location = New System.Drawing.Point(435, 23)
        Me.CheckBoxIsFirst.Name = "CheckBoxIsFirst"
        Me.CheckBoxIsFirst.OldestSibling = Nothing
        Me.CheckBoxIsFirst.SecurityEnabled = True
        Me.CheckBoxIsFirst.SiblingControls = CType(resources.GetObject("CheckBoxIsFirst.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxIsFirst.Size = New System.Drawing.Size(198, 20)
        Me.CheckBoxIsFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxIsFirst.TabIndex = 11
        Me.CheckBoxIsFirst.Text = "First Row has column headers"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBox1.Border.Class = "TextBoxBorder"
        Me.TextBox1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBox1.CheckSpellingOnValidate = False
        Me.TextBox1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBox1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBox1.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBox1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBox1.FocusHighlightEnabled = True
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(494, 51)
        Me.TextBox1.MaxFileSize = CType(0, Long)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.SecurityEnabled = True
        Me.TextBox1.ShowSpellCheckCompleteMessage = True
        Me.TextBox1.Size = New System.Drawing.Size(139, 20)
        Me.TextBox1.StartingFolderName = Nothing
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.TabOnEnter = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Label5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label5.Location = New System.Drawing.Point(435, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 20)
        Me.Label5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Client ID:"
        '
        'IntegerInputIsAdvantageAdmin
        '
        '
        '
        '
        Me.IntegerInputIsAdvantageAdmin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInputIsAdvantageAdmin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInputIsAdvantageAdmin.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInputIsAdvantageAdmin.Location = New System.Drawing.Point(349, 50)
        Me.IntegerInputIsAdvantageAdmin.MinValue = 0
        Me.IntegerInputIsAdvantageAdmin.Name = "IntegerInputIsAdvantageAdmin"
        Me.IntegerInputIsAdvantageAdmin.ShowUpDown = True
        Me.IntegerInputIsAdvantageAdmin.Size = New System.Drawing.Size(80, 20)
        Me.IntegerInputIsAdvantageAdmin.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Label4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label4.Location = New System.Drawing.Point(205, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 20)
        Me.Label4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Is Advantage Admin:"
        '
        'IntegerInputIsSecurityAdmin
        '
        '
        '
        '
        Me.IntegerInputIsSecurityAdmin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInputIsSecurityAdmin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInputIsSecurityAdmin.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInputIsSecurityAdmin.Location = New System.Drawing.Point(349, 24)
        Me.IntegerInputIsSecurityAdmin.MinValue = 0
        Me.IntegerInputIsSecurityAdmin.Name = "IntegerInputIsSecurityAdmin"
        Me.IntegerInputIsSecurityAdmin.ShowUpDown = True
        Me.IntegerInputIsSecurityAdmin.Size = New System.Drawing.Size(80, 20)
        Me.IntegerInputIsSecurityAdmin.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label3.Location = New System.Drawing.Point(205, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 20)
        Me.Label3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Is Security Admin Column:"
        '
        'IntegerInputPasswordColumn
        '
        Me.IntegerInputPasswordColumn.AllowEmptyState = False
        '
        '
        '
        Me.IntegerInputPasswordColumn.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInputPasswordColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInputPasswordColumn.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInputPasswordColumn.Location = New System.Drawing.Point(119, 50)
        Me.IntegerInputPasswordColumn.MinValue = 0
        Me.IntegerInputPasswordColumn.Name = "IntegerInputPasswordColumn"
        Me.IntegerInputPasswordColumn.ShowUpDown = True
        Me.IntegerInputPasswordColumn.Size = New System.Drawing.Size(80, 20)
        Me.IntegerInputPasswordColumn.TabIndex = 4
        Me.IntegerInputPasswordColumn.Value = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password Column:"
        '
        'IntegerInputUserNameColumn
        '
        Me.IntegerInputUserNameColumn.AllowEmptyState = False
        '
        '
        '
        Me.IntegerInputUserNameColumn.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntegerInputUserNameColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntegerInputUserNameColumn.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntegerInputUserNameColumn.Location = New System.Drawing.Point(119, 24)
        Me.IntegerInputUserNameColumn.MinValue = 0
        Me.IntegerInputUserNameColumn.Name = "IntegerInputUserNameColumn"
        Me.IntegerInputUserNameColumn.ShowUpDown = True
        Me.IntegerInputUserNameColumn.Size = New System.Drawing.Size(80, 20)
        Me.IntegerInputUserNameColumn.TabIndex = 2
        Me.IntegerInputUserNameColumn.Value = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name Column:"
        '
        'CheckBoxMustChangeAtNextLogin
        '
        '
        '
        '
        Me.CheckBoxMustChangeAtNextLogin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMustChangeAtNextLogin.CheckValue = 0
        Me.CheckBoxMustChangeAtNextLogin.CheckValueChecked = 1
        Me.CheckBoxMustChangeAtNextLogin.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMustChangeAtNextLogin.CheckValueUnchecked = 0
        Me.CheckBoxMustChangeAtNextLogin.ChildControls = Nothing
        Me.CheckBoxMustChangeAtNextLogin.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMustChangeAtNextLogin.Location = New System.Drawing.Point(790, 51)
        Me.CheckBoxMustChangeAtNextLogin.Name = "CheckBoxMustChangeAtNextLogin"
        Me.CheckBoxMustChangeAtNextLogin.OldestSibling = Nothing
        Me.CheckBoxMustChangeAtNextLogin.SecurityEnabled = True
        Me.CheckBoxMustChangeAtNextLogin.SiblingControls = Nothing
        Me.CheckBoxMustChangeAtNextLogin.Size = New System.Drawing.Size(161, 20)
        Me.CheckBoxMustChangeAtNextLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMustChangeAtNextLogin.TabIndex = 14
        Me.CheckBoxMustChangeAtNextLogin.Text = "Must Change At Next Login"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 372)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.GroupBoxForm_DatabaseSettings)
        Me.Name = "Form1"
        Me.Text = "Internal User Setup Utility"
        CType(Me.GroupBoxForm_DatabaseSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxForm_DatabaseSettings.ResumeLayout(False)
        Me.RibbonControl1.ResumeLayout(False)
        Me.RibbonControl1.PerformLayout()
        Me.RibbonPanel1.ResumeLayout(False)
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.IntegerInputIsAdvantageAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInputIsSecurityAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInputPasswordColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerInputUserNameColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxForm_DatabaseSettings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents ButtonDatabaseSettings_Test As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonDatabaseSettings_Build As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TextBoxDatabaseSettings_ConnectionString As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelDatabaseSettings_ConnectionString As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonBar1 As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents QatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    Friend WithEvents GroupBox1 As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents IntegerInputPasswordColumn As DevComponents.Editors.IntegerInput
    Friend WithEvents Label2 As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents IntegerInputUserNameColumn As DevComponents.Editors.IntegerInput
    Friend WithEvents Label1 As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents Label5 As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents IntegerInputIsAdvantageAdmin As DevComponents.Editors.IntegerInput
    Friend WithEvents Label4 As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents IntegerInputIsSecurityAdmin As DevComponents.Editors.IntegerInput
    Friend WithEvents Label3 As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBox1 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents CheckBoxIsFirst As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxAddOnlyToDatabase As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxEnforcePasswordPolicy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxMustChangeAtNextLogin As AdvantageFramework.WinForm.Presentation.Controls.CheckBox

End Class
