Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvoicePrintingAutoEmailDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingAutoEmailDialog))
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
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.CheckBoxItemInclude_APDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_ExpenseDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonBarOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerOptions_Options1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptions_SendToDocumentManager = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_IncludeCoverSheet = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_SendToProductContact = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerOptions_Options2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOptions_SendSingleEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            Me.RibbonBarOptions_QuickSelection = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerQuickSelection_Email = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemQuickSelection_SelectAllEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemQuickSelection_DeselectAllEmail = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerQuickSelection_Print = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemQuickSelection_SelectAllPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemQuickSelection_DeselectAllPrint = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_PackageOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerPackageOptions_PackageOptions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemPackageOptions_OneZipPerInvoice = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_OneZip = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_SinglePDF = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_CCToSender)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Contacts)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1020, 291)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1020, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PackageOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Options)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_DefaultEmailSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1020, 97)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Options, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Include, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PackageOptions, 0)
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
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 446)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1020, 18)
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
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 95)
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
            Me.DataGridViewForm_Contacts.DataSource = Nothing
            Me.DataGridViewForm_Contacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Contacts.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Contacts.Location = New System.Drawing.Point(10, 148)
            Me.DataGridViewForm_Contacts.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.DataGridViewForm_Contacts.MultiSelect = True
            Me.DataGridViewForm_Contacts.Name = "DataGridViewForm_Contacts"
            Me.DataGridViewForm_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Contacts.RunStandardValidation = True
            Me.DataGridViewForm_Contacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Contacts.Size = New System.Drawing.Size(998, 138)
            Me.DataGridViewForm_Contacts.TabIndex = 11
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
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(915, 82)
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
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(915, 21)
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
            Me.CheckBoxForm_CCToSender.Size = New System.Drawing.Size(915, 20)
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
            Me.RibbonBarOptions_DefaultEmailSettings.Size = New System.Drawing.Size(133, 95)
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
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.DragDropSupport = True
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemInclude_APDocuments, Me.CheckBoxItemInclude_ExpenseDocuments})
            Me.RibbonBarOptions_Include.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(699, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(137, 95)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 30
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'CheckBoxItemInclude_APDocuments
            '
            Me.CheckBoxItemInclude_APDocuments.Name = "CheckBoxItemInclude_APDocuments"
            Me.CheckBoxItemInclude_APDocuments.Text = "AP Documents"
            '
            'CheckBoxItemInclude_ExpenseDocuments
            '
            Me.CheckBoxItemInclude_ExpenseDocuments.Name = "CheckBoxItemInclude_ExpenseDocuments"
            Me.CheckBoxItemInclude_ExpenseDocuments.Text = "Expense Documents"
            '
            'RibbonBarOptions_Options
            '
            Me.RibbonBarOptions_Options.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Options.DragDropSupport = True
            Me.RibbonBarOptions_Options.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerOptions_Options1, Me.ItemContainerOptions_Options2})
            Me.RibbonBarOptions_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Options.Location = New System.Drawing.Point(352, 0)
            Me.RibbonBarOptions_Options.Name = "RibbonBarOptions_Options"
            Me.RibbonBarOptions_Options.SecurityEnabled = True
            Me.RibbonBarOptions_Options.Size = New System.Drawing.Size(347, 95)
            Me.RibbonBarOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Options.TabIndex = 28
            Me.RibbonBarOptions_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerOptions_Options1
            '
            '
            '
            '
            Me.ItemContainerOptions_Options1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_Options1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_Options1.Name = "ItemContainerOptions_Options1"
            Me.ItemContainerOptions_Options1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_SendToDocumentManager, Me.ButtonItemOptions_IncludeCoverSheet, Me.ButtonItemOptions_SendToProductContact})
            '
            '
            '
            Me.ItemContainerOptions_Options1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_Options1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptions_SendToDocumentManager
            '
            Me.ButtonItemOptions_SendToDocumentManager.AutoCheckOnClick = True
            Me.ButtonItemOptions_SendToDocumentManager.BeginGroup = True
            Me.ButtonItemOptions_SendToDocumentManager.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_SendToDocumentManager.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemOptions_SendToDocumentManager.Name = "ButtonItemOptions_SendToDocumentManager"
            Me.ButtonItemOptions_SendToDocumentManager.RibbonWordWrap = False
            Me.ButtonItemOptions_SendToDocumentManager.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_SendToDocumentManager.Text = "Send To Document Manager"
            '
            'ButtonItemOptions_IncludeCoverSheet
            '
            Me.ButtonItemOptions_IncludeCoverSheet.AutoCheckOnClick = True
            Me.ButtonItemOptions_IncludeCoverSheet.BeginGroup = True
            Me.ButtonItemOptions_IncludeCoverSheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_IncludeCoverSheet.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemOptions_IncludeCoverSheet.Name = "ButtonItemOptions_IncludeCoverSheet"
            Me.ButtonItemOptions_IncludeCoverSheet.RibbonWordWrap = False
            Me.ButtonItemOptions_IncludeCoverSheet.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_IncludeCoverSheet.Text = "Include Cover Sheet"
            '
            'ButtonItemOptions_SendToProductContact
            '
            Me.ButtonItemOptions_SendToProductContact.AutoCheckOnClick = True
            Me.ButtonItemOptions_SendToProductContact.BeginGroup = True
            Me.ButtonItemOptions_SendToProductContact.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_SendToProductContact.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemOptions_SendToProductContact.Name = "ButtonItemOptions_SendToProductContact"
            Me.ButtonItemOptions_SendToProductContact.RibbonWordWrap = False
            Me.ButtonItemOptions_SendToProductContact.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_SendToProductContact.Text = "Send To Product Contact"
            '
            'ItemContainerOptions_Options2
            '
            '
            '
            '
            Me.ItemContainerOptions_Options2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_Options2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_Options2.Name = "ItemContainerOptions_Options2"
            Me.ItemContainerOptions_Options2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_SendSingleEmail})
            '
            '
            '
            Me.ItemContainerOptions_Options2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerOptions_Options2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptions_SendSingleEmail
            '
            Me.ButtonItemOptions_SendSingleEmail.AutoCheckOnClick = True
            Me.ButtonItemOptions_SendSingleEmail.BeginGroup = True
            Me.ButtonItemOptions_SendSingleEmail.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemOptions_SendSingleEmail.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemOptions_SendSingleEmail.Name = "ButtonItemOptions_SendSingleEmail"
            Me.ButtonItemOptions_SendSingleEmail.Text = "Send Single Email"
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
            Me.RibbonBarOptions_QuickSelection.Location = New System.Drawing.Point(1025, 0)
            Me.RibbonBarOptions_QuickSelection.Name = "RibbonBarOptions_QuickSelection"
            Me.RibbonBarOptions_QuickSelection.SecurityEnabled = True
            Me.RibbonBarOptions_QuickSelection.Size = New System.Drawing.Size(200, 95)
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
            Me.ItemContainerQuickSelection_Email.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerQuickSelection_Email.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            Me.ItemContainerQuickSelection_Print.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerQuickSelection_Print.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            'RibbonBarOptions_PackageOptions
            '
            Me.RibbonBarOptions_PackageOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PackageOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PackageOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PackageOptions.DragDropSupport = True
            Me.RibbonBarOptions_PackageOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerPackageOptions_PackageOptions, Me.ButtonItemPackageOptions_SinglePDF})
            Me.RibbonBarOptions_PackageOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PackageOptions.Location = New System.Drawing.Point(836, 0)
            Me.RibbonBarOptions_PackageOptions.Name = "RibbonBarOptions_PackageOptions"
            Me.RibbonBarOptions_PackageOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PackageOptions.Size = New System.Drawing.Size(189, 95)
            Me.RibbonBarOptions_PackageOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PackageOptions.TabIndex = 32
            Me.RibbonBarOptions_PackageOptions.Text = "Package Options"
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerPackageOptions_PackageOptions
            '
            '
            '
            '
            Me.ItemContainerPackageOptions_PackageOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerPackageOptions_PackageOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerPackageOptions_PackageOptions.Name = "ItemContainerPackageOptions_PackageOptions"
            Me.ItemContainerPackageOptions_PackageOptions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPackageOptions_OneZipPerInvoice, Me.ButtonItemPackageOptions_OneZip})
            '
            '
            '
            Me.ItemContainerPackageOptions_PackageOptions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerPackageOptions_PackageOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemPackageOptions_OneZipPerInvoice
            '
            Me.ButtonItemPackageOptions_OneZipPerInvoice.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Name = "ButtonItemPackageOptions_OneZipPerInvoice"
            Me.ButtonItemPackageOptions_OneZipPerInvoice.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Stretch = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Text = "One Zip Per Invoice"
            '
            'ButtonItemPackageOptions_OneZip
            '
            Me.ButtonItemPackageOptions_OneZip.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_OneZip.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZip.Checked = True
            Me.ButtonItemPackageOptions_OneZip.Name = "ButtonItemPackageOptions_OneZip"
            Me.ButtonItemPackageOptions_OneZip.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZip.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZip.Stretch = True
            Me.ButtonItemPackageOptions_OneZip.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZip.Text = "One Zip"
            '
            'ButtonItemPackageOptions_SinglePDF
            '
            Me.ButtonItemPackageOptions_SinglePDF.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_SinglePDF.Name = "ButtonItemPackageOptions_SinglePDF"
            Me.ButtonItemPackageOptions_SinglePDF.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_SinglePDF.Text = "Single PDF"
            '
            'InvoicePrintingAutoEmailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1030, 466)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "InvoicePrintingAutoEmailDialog"
            Me.Text = "Invoice Printing Auto Email"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
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
		Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents CheckBoxItemInclude_APDocuments As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_ExpenseDocuments As DevComponents.DotNetBar.CheckBoxItem
        Private WithEvents RibbonBarOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemOptions_SendToDocumentManager As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemOptions_IncludeCoverSheet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
        Friend WithEvents RibbonBarOptions_QuickSelection As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerQuickSelection_Email As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemQuickSelection_SelectAllEmail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemQuickSelection_DeselectAllEmail As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerQuickSelection_Print As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemQuickSelection_SelectAllPrint As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemQuickSelection_DeselectAllPrint As DevComponents.DotNetBar.ButtonItem
		Private WithEvents RibbonBarOptions_PackageOptions As WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ItemContainerPackageOptions_PackageOptions As DevComponents.DotNetBar.ItemContainer
		Private WithEvents ButtonItemPackageOptions_OneZipPerInvoice As WinForm.Presentation.Controls.ButtonItem
		Private WithEvents ButtonItemPackageOptions_OneZip As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemPackageOptions_SinglePDF As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemOptions_SendToProductContact As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerOptions_Options1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerOptions_Options2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOptions_SendSingleEmail As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

