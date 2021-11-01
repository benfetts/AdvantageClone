Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanEditDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanEditDialog))
            Me.LabelInformation_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelInformation_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_StartMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Owner = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelForm_Owner = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TextBoxForm_Notes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Notes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputForm_StartYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.NumericInputForm_EndYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.ComboBoxForm_EndMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_StartYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_EndYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_EndYear)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_EndMonth)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Notes)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Notes)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Office)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_Office)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_StartYear)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_Owner)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Description)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Description)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Owner)
            Me.PanelForm_Form.Controls.Add(Me.LabelInformation_StartDate)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_StartMonth)
            Me.PanelForm_Form.Controls.Add(Me.LabelInformation_EndDate)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(413, 449)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(413, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(413, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 604)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(413, 18)
            '
            'LabelInformation_EndDate
            '
            Me.LabelInformation_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_EndDate.Location = New System.Drawing.Point(12, 84)
            Me.LabelInformation_EndDate.Name = "LabelInformation_EndDate"
            Me.LabelInformation_EndDate.Size = New System.Drawing.Size(68, 20)
            Me.LabelInformation_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_EndDate.TabIndex = 7
            Me.LabelInformation_EndDate.Text = "End Date:"
            '
            'LabelInformation_StartDate
            '
            Me.LabelInformation_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_StartDate.Location = New System.Drawing.Point(12, 58)
            Me.LabelInformation_StartDate.Name = "LabelInformation_StartDate"
            Me.LabelInformation_StartDate.Size = New System.Drawing.Size(68, 20)
            Me.LabelInformation_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_StartDate.TabIndex = 4
            Me.LabelInformation_StartDate.Text = "Start Date:"
            '
            'ComboBoxForm_StartMonth
            '
            Me.ComboBoxForm_StartMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_StartMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_StartMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_StartMonth.AutoFindItemInDataSource = False
            Me.ComboBoxForm_StartMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_StartMonth.BookmarkingEnabled = False
            Me.ComboBoxForm_StartMonth.DisableMouseWheel = False
            Me.ComboBoxForm_StartMonth.DisplayName = ""
            Me.ComboBoxForm_StartMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_StartMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_StartMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_StartMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_StartMonth.FocusHighlightEnabled = True
            Me.ComboBoxForm_StartMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_StartMonth.FormattingEnabled = True
            Me.ComboBoxForm_StartMonth.ItemHeight = 16
            Me.ComboBoxForm_StartMonth.Location = New System.Drawing.Point(86, 58)
            Me.ComboBoxForm_StartMonth.Name = "ComboBoxForm_StartMonth"
            Me.ComboBoxForm_StartMonth.ReadOnly = False
            Me.ComboBoxForm_StartMonth.SecurityEnabled = True
            Me.ComboBoxForm_StartMonth.Size = New System.Drawing.Size(168, 22)
            Me.ComboBoxForm_StartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_StartMonth.TabIndex = 5
            Me.ComboBoxForm_StartMonth.TabOnEnter = True
            Me.ComboBoxForm_StartMonth.WatermarkText = "Division"
            '
            'ComboBoxForm_Owner
            '
            Me.ComboBoxForm_Owner.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Owner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Owner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Owner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Owner.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Owner.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Owner.BookmarkingEnabled = False
            Me.ComboBoxForm_Owner.DisableMouseWheel = False
            Me.ComboBoxForm_Owner.DisplayName = ""
            Me.ComboBoxForm_Owner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Owner.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Owner.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Owner.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Owner.FocusHighlightEnabled = True
            Me.ComboBoxForm_Owner.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Owner.FormattingEnabled = True
            Me.ComboBoxForm_Owner.IntegralHeight = False
            Me.ComboBoxForm_Owner.ItemHeight = 16
            Me.ComboBoxForm_Owner.Location = New System.Drawing.Point(86, 32)
            Me.ComboBoxForm_Owner.Name = "ComboBoxForm_Owner"
            Me.ComboBoxForm_Owner.ReadOnly = False
            Me.ComboBoxForm_Owner.SecurityEnabled = True
            Me.ComboBoxForm_Owner.Size = New System.Drawing.Size(315, 22)
            Me.ComboBoxForm_Owner.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Owner.TabIndex = 3
            Me.ComboBoxForm_Owner.TabOnEnter = True
            Me.ComboBoxForm_Owner.WatermarkText = "Select Client"
            '
            'LabelForm_Owner
            '
            Me.LabelForm_Owner.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Owner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Owner.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_Owner.Name = "LabelForm_Owner"
            Me.LabelForm_Owner.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Owner.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Owner.TabIndex = 2
            Me.LabelForm_Owner.Text = "Owner:"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.AgencyImportPath = Nothing
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Description.DisplayName = ""
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(86, 110)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(315, 21)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 11
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 110)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 10
            Me.LabelForm_Description.Text = "Description:"
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Actions.DragDropSupport = True
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Cancel})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(126, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 1
            Me.RibbonBarFilePanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SecurityEnabled = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
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
            'TextBoxForm_Notes
            '
            Me.TextBoxForm_Notes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Notes.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Notes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Notes.CheckSpellingOnValidate = False
            Me.TextBoxForm_Notes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Notes.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Notes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Notes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Notes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Notes.FocusHighlightEnabled = True
            Me.TextBoxForm_Notes.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Notes.Location = New System.Drawing.Point(86, 163)
            Me.TextBoxForm_Notes.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Notes.Multiline = True
            Me.TextBoxForm_Notes.Name = "TextBoxForm_Notes"
            Me.TextBoxForm_Notes.SecurityEnabled = True
            Me.TextBoxForm_Notes.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Notes.Size = New System.Drawing.Size(315, 280)
            Me.TextBoxForm_Notes.StartingFolderName = Nothing
            Me.TextBoxForm_Notes.TabIndex = 14
            Me.TextBoxForm_Notes.TabOnEnter = False
            '
            'LabelForm_Notes
            '
            Me.LabelForm_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Notes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Notes.Location = New System.Drawing.Point(12, 163)
            Me.LabelForm_Notes.Name = "LabelForm_Notes"
            Me.LabelForm_Notes.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Notes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Notes.TabIndex = 13
            Me.LabelForm_Notes.Text = "Notes:"
            '
            'NumericInputForm_StartYear
            '
            Me.NumericInputForm_StartYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_StartYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_StartYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputForm_StartYear.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_StartYear.EnterMoveNextControl = True
            Me.NumericInputForm_StartYear.Location = New System.Drawing.Point(260, 58)
            Me.NumericInputForm_StartYear.Name = "NumericInputForm_StartYear"
            Me.NumericInputForm_StartYear.Properties.AllowMouseWheel = False
            Me.NumericInputForm_StartYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_StartYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_StartYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_StartYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_StartYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_StartYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_StartYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_StartYear.Properties.IsFloatValue = False
            Me.NumericInputForm_StartYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_StartYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_StartYear.Properties.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
            Me.NumericInputForm_StartYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputForm_StartYear.SecurityEnabled = True
            Me.NumericInputForm_StartYear.Size = New System.Drawing.Size(141, 20)
            Me.NumericInputForm_StartYear.TabIndex = 6
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 0
            Me.LabelForm_Office.Text = "Office:"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 16
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(86, 6)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.SecurityEnabled = True
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(315, 22)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 1
            Me.ComboBoxForm_Office.TabOnEnter = True
            Me.ComboBoxForm_Office.WatermarkText = "Select Client"
            '
            'NumericInputForm_EndYear
            '
            Me.NumericInputForm_EndYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_EndYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_EndYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputForm_EndYear.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_EndYear.EnterMoveNextControl = True
            Me.NumericInputForm_EndYear.Location = New System.Drawing.Point(260, 84)
            Me.NumericInputForm_EndYear.Name = "NumericInputForm_EndYear"
            Me.NumericInputForm_EndYear.Properties.AllowMouseWheel = False
            Me.NumericInputForm_EndYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_EndYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_EndYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_EndYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_EndYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_EndYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_EndYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_EndYear.Properties.IsFloatValue = False
            Me.NumericInputForm_EndYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_EndYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_EndYear.Properties.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
            Me.NumericInputForm_EndYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputForm_EndYear.SecurityEnabled = True
            Me.NumericInputForm_EndYear.Size = New System.Drawing.Size(141, 20)
            Me.NumericInputForm_EndYear.TabIndex = 9
            '
            'ComboBoxForm_EndMonth
            '
            Me.ComboBoxForm_EndMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndMonth.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndMonth.BookmarkingEnabled = False
            Me.ComboBoxForm_EndMonth.DisableMouseWheel = False
            Me.ComboBoxForm_EndMonth.DisplayName = ""
            Me.ComboBoxForm_EndMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_EndMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndMonth.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_EndMonth.FormattingEnabled = True
            Me.ComboBoxForm_EndMonth.ItemHeight = 16
            Me.ComboBoxForm_EndMonth.Location = New System.Drawing.Point(86, 84)
            Me.ComboBoxForm_EndMonth.Name = "ComboBoxForm_EndMonth"
            Me.ComboBoxForm_EndMonth.ReadOnly = False
            Me.ComboBoxForm_EndMonth.SecurityEnabled = True
            Me.ComboBoxForm_EndMonth.Size = New System.Drawing.Size(168, 22)
            Me.ComboBoxForm_EndMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndMonth.TabIndex = 8
            Me.ComboBoxForm_EndMonth.TabOnEnter = True
            Me.ComboBoxForm_EndMonth.WatermarkText = "Division"
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(86, 137)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(315, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 12
            Me.CheckBoxForm_Inactive.TabOnEnter = True
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'RevenueResourcePlanEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(423, 624)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RevenueResourcePlanEditDialog"
            Me.Text = "Revenue & Resource Plan"
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_StartYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_EndYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelInformation_EndDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelInformation_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_StartMonth As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Owner As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Owner As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents NumericInputForm_StartYear As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxForm_Notes As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Notes As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_EndYear As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxForm_EndMonth As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Office As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Office As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_Inactive As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace