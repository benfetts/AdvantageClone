Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerSendRemindersDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerSendRemindersDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_CCToSender = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RibbonBarOptions_DefaultEmailSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDefaultEmailSettings_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_QuickSelection = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerQuickSelection_Email = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemQuickSelection_SelectAllEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemQuickSelection_DeselectAllEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerQuickSelection_Print = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemQuickSelection_SelectAllPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemQuickSelection_DeselectAllPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Location.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1048, 154)
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
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_QuickSelection)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_DefaultEmailSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 54)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1048, 100)
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
            Me.RibbonPanelFile_FilePanel.Visible = True
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_DefaultEmailSettings, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_QuickSelection, 0)
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
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 98)
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
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 2
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Location)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Location)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_CCToSender)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Contacts)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1048, 409)
            Me.PanelForm_Form.TabIndex = 0
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 564)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1048, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Process, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
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
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_Contacts
            '
            Me.DataGridViewForm_Contacts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Contacts.AllowDragAndDrop = False
            Me.DataGridViewForm_Contacts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Contacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Contacts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Contacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Contacts.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Contacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Contacts.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Contacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Contacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Contacts.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Contacts.Location = New System.Drawing.Point(12, 174)
            Me.DataGridViewForm_Contacts.MultiSelect = True
            Me.DataGridViewForm_Contacts.Name = "DataGridViewForm_Contacts"
            Me.DataGridViewForm_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Contacts.RunStandardValidation = True
            Me.DataGridViewForm_Contacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Contacts.Size = New System.Drawing.Size(1024, 228)
            Me.DataGridViewForm_Contacts.TabIndex = 13
            Me.DataGridViewForm_Contacts.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Contacts.ViewCaptionHeight = -1
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(12, 7)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(75, 21)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 6
            Me.LabelForm_Subject.Text = "Subject:"
            '
            'LabelForm_Body
            '
            Me.LabelForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Body.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Body.Location = New System.Drawing.Point(12, 34)
            Me.LabelForm_Body.Name = "LabelForm_Body"
            Me.LabelForm_Body.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Body.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Body.TabIndex = 8
            Me.LabelForm_Body.Text = "Body:"
            '
            'TextBoxForm_Body
            '
            Me.TextBoxForm_Body.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Body.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Body.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Body.CheckSpellingOnValidate = False
            Me.TextBoxForm_Body.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Body.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Body.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Body.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Body.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Body.FocusHighlightEnabled = True
            Me.TextBoxForm_Body.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Body.Location = New System.Drawing.Point(93, 34)
            Me.TextBoxForm_Body.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Body.Multiline = True
            Me.TextBoxForm_Body.Name = "TextBoxForm_Body"
            Me.TextBoxForm_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxForm_Body.SecurityEnabled = True
            Me.TextBoxForm_Body.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(943, 82)
            Me.TextBoxForm_Body.StartingFolderName = Nothing
            Me.TextBoxForm_Body.TabIndex = 9
            Me.TextBoxForm_Body.TabOnEnter = False
            '
            'TextBoxForm_Subject
            '
            Me.TextBoxForm_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Subject.CheckSpellingOnValidate = False
            Me.TextBoxForm_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Subject.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Subject.FocusHighlightEnabled = True
            Me.TextBoxForm_Subject.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(93, 7)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.SecurityEnabled = True
            Me.TextBoxForm_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(943, 21)
            Me.TextBoxForm_Subject.StartingFolderName = Nothing
            Me.TextBoxForm_Subject.TabIndex = 7
            Me.TextBoxForm_Subject.TabOnEnter = True
            '
            'CheckBoxForm_CCToSender
            '
            Me.CheckBoxForm_CCToSender.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_CCToSender.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CCToSender.CheckValue = 0
            Me.CheckBoxForm_CCToSender.CheckValueChecked = 1
            Me.CheckBoxForm_CCToSender.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CCToSender.CheckValueUnchecked = 0
            Me.CheckBoxForm_CCToSender.ChildControls = CType(resources.GetObject("CheckBoxForm_CCToSender.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CCToSender.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CCToSender.Location = New System.Drawing.Point(93, 122)
            Me.CheckBoxForm_CCToSender.Name = "CheckBoxForm_CCToSender"
            Me.CheckBoxForm_CCToSender.OldestSibling = Nothing
            Me.CheckBoxForm_CCToSender.SecurityEnabled = True
            Me.CheckBoxForm_CCToSender.SiblingControls = CType(resources.GetObject("CheckBoxForm_CCToSender.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CCToSender.Size = New System.Drawing.Size(943, 20)
            Me.CheckBoxForm_CCToSender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CCToSender.TabIndex = 10
            Me.CheckBoxForm_CCToSender.TabOnEnter = True
            Me.CheckBoxForm_CCToSender.Text = "CC to Sender"
            '
            'RibbonBarOptions_DefaultEmailSettings
            '
            Me.RibbonBarOptions_DefaultEmailSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultEmailSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DefaultEmailSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DefaultEmailSettings.DragDropSupport = True
            Me.RibbonBarOptions_DefaultEmailSettings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_DefaultEmailSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDefaultEmailSettings_Save})
            Me.RibbonBarOptions_DefaultEmailSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DefaultEmailSettings.Location = New System.Drawing.Point(219, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.MinimumSize = New System.Drawing.Size(133, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.Name = "RibbonBarOptions_DefaultEmailSettings"
            Me.RibbonBarOptions_DefaultEmailSettings.SecurityEnabled = True
            Me.RibbonBarOptions_DefaultEmailSettings.Size = New System.Drawing.Size(133, 98)
            Me.RibbonBarOptions_DefaultEmailSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DefaultEmailSettings.TabIndex = 14
            Me.RibbonBarOptions_DefaultEmailSettings.Text = "Default Email Settings"
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultEmailSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDefaultEmailSettings_Save
            '
            Me.ButtonItemDefaultEmailSettings_Save.BeginGroup = True
            Me.ButtonItemDefaultEmailSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDefaultEmailSettings_Save.Name = "ButtonItemDefaultEmailSettings_Save"
            Me.ButtonItemDefaultEmailSettings_Save.RibbonWordWrap = False
            Me.ButtonItemDefaultEmailSettings_Save.SubItemsExpandWidth = 14
            Me.ButtonItemDefaultEmailSettings_Save.Text = "Save"
            '
            'RibbonBarOptions_QuickSelection
            '
            Me.RibbonBarOptions_QuickSelection.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_QuickSelection.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickSelection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickSelection.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_QuickSelection.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_QuickSelection.DragDropSupport = True
            Me.RibbonBarOptions_QuickSelection.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerQuickSelection_Email, Me.ItemContainerQuickSelection_Print})
            Me.RibbonBarOptions_QuickSelection.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_QuickSelection.Location = New System.Drawing.Point(352, 0)
            Me.RibbonBarOptions_QuickSelection.Name = "RibbonBarOptions_QuickSelection"
            Me.RibbonBarOptions_QuickSelection.SecurityEnabled = True
            Me.RibbonBarOptions_QuickSelection.Size = New System.Drawing.Size(200, 98)
            Me.RibbonBarOptions_QuickSelection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_QuickSelection.TabIndex = 31
            Me.RibbonBarOptions_QuickSelection.Text = "Quick Selection"
            '
            '
            '
            Me.RibbonBarOptions_QuickSelection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_QuickSelection.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_QuickSelection.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerQuickSelection_Email
            '
            '
            '
            '
            Me.ItemContainerQuickSelection_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerQuickSelection_Email.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerQuickSelection_Email.Name = "ItemContainerQuickSelection_Email"
            Me.ItemContainerQuickSelection_Email.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickSelection_SelectAllEmail, Me.ButtonItemQuickSelection_DeselectAllEmail})
            '
            '
            '
            Me.ItemContainerQuickSelection_Email.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerQuickSelection_Email.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemQuickSelection_SelectAllEmail
            '
            Me.ButtonItemQuickSelection_SelectAllEmail.Name = "ButtonItemQuickSelection_SelectAllEmail"
            Me.ButtonItemQuickSelection_SelectAllEmail.SubItemsExpandWidth = 14
            Me.ButtonItemQuickSelection_SelectAllEmail.Text = "Select All Email"
            '
            'ButtonItemQuickSelection_DeselectAllEmail
            '
            Me.ButtonItemQuickSelection_DeselectAllEmail.Name = "ButtonItemQuickSelection_DeselectAllEmail"
            Me.ButtonItemQuickSelection_DeselectAllEmail.SubItemsExpandWidth = 14
            Me.ButtonItemQuickSelection_DeselectAllEmail.Text = "Deselect All Email"
            '
            'ItemContainerQuickSelection_Print
            '
            '
            '
            '
            Me.ItemContainerQuickSelection_Print.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerQuickSelection_Print.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerQuickSelection_Print.Name = "ItemContainerQuickSelection_Print"
            Me.ItemContainerQuickSelection_Print.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemQuickSelection_SelectAllPrint, Me.ButtonItemQuickSelection_DeselectAllPrint})
            '
            '
            '
            Me.ItemContainerQuickSelection_Print.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerQuickSelection_Print.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemQuickSelection_SelectAllPrint
            '
            Me.ButtonItemQuickSelection_SelectAllPrint.Name = "ButtonItemQuickSelection_SelectAllPrint"
            Me.ButtonItemQuickSelection_SelectAllPrint.SubItemsExpandWidth = 14
            Me.ButtonItemQuickSelection_SelectAllPrint.Text = "Select All Print"
            '
            'ButtonItemQuickSelection_DeselectAllPrint
            '
            Me.ButtonItemQuickSelection_DeselectAllPrint.Name = "ButtonItemQuickSelection_DeselectAllPrint"
            Me.ButtonItemQuickSelection_DeselectAllPrint.SubItemsExpandWidth = 14
            Me.ButtonItemQuickSelection_DeselectAllPrint.Text = "Deselect All Print"
            '
            'LabelForm_Location
            '
            Me.LabelForm_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Location.Location = New System.Drawing.Point(12, 148)
            Me.LabelForm_Location.Name = "LabelForm_Location"
            Me.LabelForm_Location.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Location.TabIndex = 11
            Me.LabelForm_Location.Text = "Location:"
            '
            'SearchableComboBoxForm_Location
            '
            Me.SearchableComboBoxForm_Location.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Location.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Location.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Location.AutoFillMode = False
            Me.SearchableComboBoxForm_Location.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Location.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Location
            Me.SearchableComboBoxForm_Location.DataSource = Nothing
            Me.SearchableComboBoxForm_Location.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Location.DisplayName = ""
            Me.SearchableComboBoxForm_Location.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Location.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_Location.Location = New System.Drawing.Point(93, 148)
            Me.SearchableComboBoxForm_Location.Name = "SearchableComboBoxForm_Location"
            Me.SearchableComboBoxForm_Location.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Location.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Location.Properties.NullText = "Select Location"
            Me.SearchableComboBoxForm_Location.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Location.Properties.ValueMember = "ID"
            Me.SearchableComboBoxForm_Location.Properties.View = Me.GridView1
            Me.SearchableComboBoxForm_Location.SecurityEnabled = True
            Me.SearchableComboBoxForm_Location.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Location.Size = New System.Drawing.Size(943, 20)
            Me.SearchableComboBoxForm_Location.TabIndex = 12
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'MediaManagerSendRemindersDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1058, 584)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "MediaManagerSendRemindersDialog"
            Me.Text = "Media Manager Send Reminders"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Location.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxForm_Body As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Body As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Contacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_CCToSender As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents RibbonBarOptions_DefaultEmailSettings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDefaultEmailSettings_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_QuickSelection As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerQuickSelection_Email As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemQuickSelection_SelectAllEmail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemQuickSelection_DeselectAllEmail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerQuickSelection_Print As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemQuickSelection_SelectAllPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemQuickSelection_DeselectAllPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_Location As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Location As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.Presentation.Controls.GridView
    End Class

End Namespace

