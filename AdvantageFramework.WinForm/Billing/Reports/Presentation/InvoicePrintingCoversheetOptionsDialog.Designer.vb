Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvoicePrintingCoversheetOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingCoversheetOptionsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelForm_CoversheetType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_CoversheetTypeDefault = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_CoversheetTypeAlternate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Title = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxForm_Contact = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxContact_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.PanelContact_ContactLocation = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonContactLocation_AddressBlock = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonContactLocation_AttnLine = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelContactLocation_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonContact_FirstFound = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonContact_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonContact_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_Contact, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Contact.SuspendLayout()
            CType(Me.SearchableComboBoxContact_ContactType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelContact_ContactLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelContact_ContactLocation.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_Contact)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Title)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Title)
            Me.PanelForm_Form.Controls.Add(Me.RadioButtonForm_CoversheetTypeAlternate)
            Me.PanelForm_Form.Controls.Add(Me.RadioButtonForm_CoversheetTypeDefault)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_CoversheetType)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(713, 175)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(713, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(713, 94)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
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
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 330)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(713, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(114, 92)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'LabelForm_CoversheetType
            '
            Me.LabelForm_CoversheetType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CoversheetType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CoversheetType.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_CoversheetType.Name = "LabelForm_CoversheetType"
            Me.LabelForm_CoversheetType.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_CoversheetType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CoversheetType.TabIndex = 0
            Me.LabelForm_CoversheetType.Text = "Coversheet Type:"
            '
            'RadioButtonForm_CoversheetTypeDefault
            '
            Me.RadioButtonForm_CoversheetTypeDefault.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_CoversheetTypeDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_CoversheetTypeDefault.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_CoversheetTypeDefault.Checked = True
            Me.RadioButtonForm_CoversheetTypeDefault.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_CoversheetTypeDefault.CheckValue = "Y"
            Me.RadioButtonForm_CoversheetTypeDefault.Location = New System.Drawing.Point(118, 6)
            Me.RadioButtonForm_CoversheetTypeDefault.Name = "RadioButtonForm_CoversheetTypeDefault"
            Me.RadioButtonForm_CoversheetTypeDefault.SecurityEnabled = True
            Me.RadioButtonForm_CoversheetTypeDefault.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonForm_CoversheetTypeDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_CoversheetTypeDefault.TabIndex = 1
            Me.RadioButtonForm_CoversheetTypeDefault.TabOnEnter = True
            Me.RadioButtonForm_CoversheetTypeDefault.Text = "Default"
            '
            'RadioButtonForm_CoversheetTypeAlternate
            '
            Me.RadioButtonForm_CoversheetTypeAlternate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_CoversheetTypeAlternate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_CoversheetTypeAlternate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_CoversheetTypeAlternate.Location = New System.Drawing.Point(224, 6)
            Me.RadioButtonForm_CoversheetTypeAlternate.Name = "RadioButtonForm_CoversheetTypeAlternate"
            Me.RadioButtonForm_CoversheetTypeAlternate.SecurityEnabled = True
            Me.RadioButtonForm_CoversheetTypeAlternate.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonForm_CoversheetTypeAlternate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_CoversheetTypeAlternate.TabIndex = 2
            Me.RadioButtonForm_CoversheetTypeAlternate.TabOnEnter = True
            Me.RadioButtonForm_CoversheetTypeAlternate.TabStop = False
            Me.RadioButtonForm_CoversheetTypeAlternate.Text = "Alternate"
            '
            'LabelForm_Title
            '
            Me.LabelForm_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Title.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_Title.Name = "LabelForm_Title"
            Me.LabelForm_Title.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Title.TabIndex = 3
            Me.LabelForm_Title.Text = "Title:"
            '
            'TextBoxForm_Title
            '
            Me.TextBoxForm_Title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Title.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Title.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Title.CheckSpellingOnValidate = False
            Me.TextBoxForm_Title.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Title.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Title.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Title.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Title.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Title.FocusHighlightEnabled = True
            Me.TextBoxForm_Title.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Title.Location = New System.Drawing.Point(118, 32)
            Me.TextBoxForm_Title.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Title.Name = "TextBoxForm_Title"
            Me.TextBoxForm_Title.SecurityEnabled = True
            Me.TextBoxForm_Title.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Title.Size = New System.Drawing.Size(583, 21)
            Me.TextBoxForm_Title.StartingFolderName = Nothing
            Me.TextBoxForm_Title.TabIndex = 4
            Me.TextBoxForm_Title.TabOnEnter = True
            '
            'GroupBoxForm_Contact
            '
            Me.GroupBoxForm_Contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Contact.Controls.Add(Me.SearchableComboBoxContact_ContactType)
            Me.GroupBoxForm_Contact.Controls.Add(Me.PanelContact_ContactLocation)
            Me.GroupBoxForm_Contact.Controls.Add(Me.RadioButtonContact_FirstFound)
            Me.GroupBoxForm_Contact.Controls.Add(Me.RadioButtonContact_ContactType)
            Me.GroupBoxForm_Contact.Controls.Add(Me.RadioButtonContact_None)
            Me.GroupBoxForm_Contact.Location = New System.Drawing.Point(12, 58)
            Me.GroupBoxForm_Contact.LookAndFeel.SkinName = "Office 2013"
            Me.GroupBoxForm_Contact.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GroupBoxForm_Contact.Name = "GroupBoxForm_Contact"
            Me.GroupBoxForm_Contact.Size = New System.Drawing.Size(689, 79)
            Me.GroupBoxForm_Contact.TabIndex = 5
            Me.GroupBoxForm_Contact.Text = "Contact"
            '
            'SearchableComboBoxContact_ContactType
            '
            Me.SearchableComboBoxContact_ContactType.ActiveFilterString = ""
            Me.SearchableComboBoxContact_ContactType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxContact_ContactType.AutoFillMode = False
            Me.SearchableComboBoxContact_ContactType.BookmarkingEnabled = False
            Me.SearchableComboBoxContact_ContactType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ContactType
            Me.SearchableComboBoxContact_ContactType.DataSource = Nothing
            Me.SearchableComboBoxContact_ContactType.DisableMouseWheel = False
            Me.SearchableComboBoxContact_ContactType.DisplayName = ""
            Me.SearchableComboBoxContact_ContactType.Enabled = False
            Me.SearchableComboBoxContact_ContactType.EnterMoveNextControl = True
            Me.SearchableComboBoxContact_ContactType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxContact_ContactType.Location = New System.Drawing.Point(212, 24)
            Me.SearchableComboBoxContact_ContactType.Name = "SearchableComboBoxContact_ContactType"
            Me.SearchableComboBoxContact_ContactType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxContact_ContactType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxContact_ContactType.Properties.NullText = "Select Contact Type"
            Me.SearchableComboBoxContact_ContactType.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxContact_ContactType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxContact_ContactType.SecurityEnabled = True
            Me.SearchableComboBoxContact_ContactType.SelectedValue = Nothing
            Me.SearchableComboBoxContact_ContactType.Size = New System.Drawing.Size(200, 20)
            Me.SearchableComboBoxContact_ContactType.TabIndex = 6
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
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'PanelContact_ContactLocation
            '
            Me.PanelContact_ContactLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelContact_ContactLocation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelContact_ContactLocation.Controls.Add(Me.RadioButtonContactLocation_AddressBlock)
            Me.PanelContact_ContactLocation.Controls.Add(Me.RadioButtonContactLocation_AttnLine)
            Me.PanelContact_ContactLocation.Controls.Add(Me.LabelContactLocation_Location)
            Me.PanelContact_ContactLocation.Location = New System.Drawing.Point(5, 50)
            Me.PanelContact_ContactLocation.LookAndFeel.SkinName = "Office 2013"
            Me.PanelContact_ContactLocation.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelContact_ContactLocation.Name = "PanelContact_ContactLocation"
            Me.PanelContact_ContactLocation.Size = New System.Drawing.Size(679, 20)
            Me.PanelContact_ContactLocation.TabIndex = 4
            '
            'RadioButtonContactLocation_AddressBlock
            '
            Me.RadioButtonContactLocation_AddressBlock.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonContactLocation_AddressBlock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonContactLocation_AddressBlock.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonContactLocation_AddressBlock.Location = New System.Drawing.Point(207, 0)
            Me.RadioButtonContactLocation_AddressBlock.Name = "RadioButtonContactLocation_AddressBlock"
            Me.RadioButtonContactLocation_AddressBlock.SecurityEnabled = True
            Me.RadioButtonContactLocation_AddressBlock.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonContactLocation_AddressBlock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonContactLocation_AddressBlock.TabIndex = 2
            Me.RadioButtonContactLocation_AddressBlock.TabOnEnter = True
            Me.RadioButtonContactLocation_AddressBlock.TabStop = False
            Me.RadioButtonContactLocation_AddressBlock.Text = "Address Block"
            '
            'RadioButtonContactLocation_AttnLine
            '
            Me.RadioButtonContactLocation_AttnLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonContactLocation_AttnLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonContactLocation_AttnLine.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonContactLocation_AttnLine.Checked = True
            Me.RadioButtonContactLocation_AttnLine.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonContactLocation_AttnLine.CheckValue = "Y"
            Me.RadioButtonContactLocation_AttnLine.Location = New System.Drawing.Point(101, 0)
            Me.RadioButtonContactLocation_AttnLine.Name = "RadioButtonContactLocation_AttnLine"
            Me.RadioButtonContactLocation_AttnLine.SecurityEnabled = True
            Me.RadioButtonContactLocation_AttnLine.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonContactLocation_AttnLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonContactLocation_AttnLine.TabIndex = 1
            Me.RadioButtonContactLocation_AttnLine.TabOnEnter = True
            Me.RadioButtonContactLocation_AttnLine.Text = "Attn Line"
            '
            'LabelContactLocation_Location
            '
            Me.LabelContactLocation_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactLocation_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactLocation_Location.Location = New System.Drawing.Point(0, 0)
            Me.LabelContactLocation_Location.Name = "LabelContactLocation_Location"
            Me.LabelContactLocation_Location.Size = New System.Drawing.Size(95, 20)
            Me.LabelContactLocation_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactLocation_Location.TabIndex = 0
            Me.LabelContactLocation_Location.Text = "Location:"
            '
            'RadioButtonContact_FirstFound
            '
            Me.RadioButtonContact_FirstFound.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonContact_FirstFound.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonContact_FirstFound.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonContact_FirstFound.Location = New System.Drawing.Point(418, 24)
            Me.RadioButtonContact_FirstFound.Name = "RadioButtonContact_FirstFound"
            Me.RadioButtonContact_FirstFound.SecurityEnabled = True
            Me.RadioButtonContact_FirstFound.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonContact_FirstFound.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonContact_FirstFound.TabIndex = 3
            Me.RadioButtonContact_FirstFound.TabOnEnter = True
            Me.RadioButtonContact_FirstFound.TabStop = False
            Me.RadioButtonContact_FirstFound.Text = "First Found"
            '
            'RadioButtonContact_ContactType
            '
            Me.RadioButtonContact_ContactType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonContact_ContactType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonContact_ContactType.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonContact_ContactType.Location = New System.Drawing.Point(106, 24)
            Me.RadioButtonContact_ContactType.Name = "RadioButtonContact_ContactType"
            Me.RadioButtonContact_ContactType.SecurityEnabled = True
            Me.RadioButtonContact_ContactType.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonContact_ContactType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonContact_ContactType.TabIndex = 1
            Me.RadioButtonContact_ContactType.TabOnEnter = True
            Me.RadioButtonContact_ContactType.TabStop = False
            Me.RadioButtonContact_ContactType.Text = "Contact Type"
            '
            'RadioButtonContact_None
            '
            Me.RadioButtonContact_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonContact_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonContact_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonContact_None.Checked = True
            Me.RadioButtonContact_None.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonContact_None.CheckValue = "Y"
            Me.RadioButtonContact_None.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonContact_None.Name = "RadioButtonContact_None"
            Me.RadioButtonContact_None.SecurityEnabled = True
            Me.RadioButtonContact_None.Size = New System.Drawing.Size(95, 20)
            Me.RadioButtonContact_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonContact_None.TabIndex = 0
            Me.RadioButtonContact_None.TabOnEnter = True
            Me.RadioButtonContact_None.Text = "None"
            '
            'InvoicePrintingCoversheetOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(723, 350)
            Me.CloseButtonVisible = False
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "InvoicePrintingCoversheetOptionsDialog"
            Me.Text = "Invoice Printing - Coversheet Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_Contact, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Contact.ResumeLayout(False)
            CType(Me.SearchableComboBoxContact_ContactType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelContact_ContactLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelContact_ContactLocation.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_CoversheetType As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Title As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_CoversheetTypeAlternate As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_CoversheetTypeDefault As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxForm_Contact As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PanelContact_ContactLocation As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonContactLocation_AddressBlock As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonContactLocation_AttnLine As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelContactLocation_Location As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonContact_FirstFound As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonContact_ContactType As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonContact_None As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxForm_Title As WinForm.Presentation.Controls.TextBox
        Friend WithEvents SearchableComboBoxContact_ContactType As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.Presentation.Controls.GridView
    End Class

End Namespace

