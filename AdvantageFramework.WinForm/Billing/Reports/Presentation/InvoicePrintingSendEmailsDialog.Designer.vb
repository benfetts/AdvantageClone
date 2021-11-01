Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class InvoicePrintingSendEmailsDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingSendEmailsDialog))
            Me.ButtonForm_AddBCC = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddCC = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddTo = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_BCC = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_CC = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ComboBoxForm_Source = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_RecipientSource = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_AvailableRecipients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_DefaultEmailSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDefaultEmailSettings_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_SendToDocumentManager = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_IncludeCoverSheet = New DevComponents.DotNetBar.ButtonItem()
            Me.TextBoxForm_Body = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RibbonBarOptions_PackageOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerPackageOptions_PackageOptions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemPackageOptions_OneZipPerInvoice = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_OneZip = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_SinglePDF = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.CheckBoxItemInclude_APDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_ExpenseDocuments = New DevComponents.DotNetBar.CheckBoxItem()
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
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddBCC)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddCC)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddTo)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_BCC)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_CC)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_Source)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_RecipientSource)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_AvailableRecipients)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_To)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PackageOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Options)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_DefaultEmailSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 97)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_DefaultEmailSettings, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Options, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Include, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PackageOptions, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'ButtonForm_AddBCC
            '
            Me.ButtonForm_AddBCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddBCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddBCC.Location = New System.Drawing.Point(544, 268)
            Me.ButtonForm_AddBCC.Name = "ButtonForm_AddBCC"
            Me.ButtonForm_AddBCC.SecurityEnabled = True
            Me.ButtonForm_AddBCC.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddBCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddBCC.TabIndex = 19
            Me.ButtonForm_AddBCC.Text = "Bcc: ->"
            '
            'ButtonForm_AddCC
            '
            Me.ButtonForm_AddCC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddCC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddCC.Location = New System.Drawing.Point(544, 137)
            Me.ButtonForm_AddCC.Name = "ButtonForm_AddCC"
            Me.ButtonForm_AddCC.SecurityEnabled = True
            Me.ButtonForm_AddCC.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddCC.TabIndex = 17
            Me.ButtonForm_AddCC.Text = "Cc: ->"
            '
            'ButtonForm_AddTo
            '
            Me.ButtonForm_AddTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddTo.Location = New System.Drawing.Point(544, 6)
            Me.ButtonForm_AddTo.Name = "ButtonForm_AddTo"
            Me.ButtonForm_AddTo.SecurityEnabled = True
            Me.ButtonForm_AddTo.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddTo.TabIndex = 15
            Me.ButtonForm_AddTo.Text = "To: ->"
            '
            'DataGridViewForm_BCC
            '
            Me.DataGridViewForm_BCC.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_BCC.AllowDragAndDrop = False
            Me.DataGridViewForm_BCC.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_BCC.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_BCC.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_BCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_BCC.AutoFilterLookupColumns = False
            Me.DataGridViewForm_BCC.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_BCC.AutoUpdateViewCaption = True
            Me.DataGridViewForm_BCC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_BCC.DataSource = Nothing
            Me.DataGridViewForm_BCC.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_BCC.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_BCC.ItemDescription = "BCC Recipient(s)"
            Me.DataGridViewForm_BCC.Location = New System.Drawing.Point(625, 268)
            Me.DataGridViewForm_BCC.MultiSelect = True
            Me.DataGridViewForm_BCC.Name = "DataGridViewForm_BCC"
            Me.DataGridViewForm_BCC.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_BCC.RunStandardValidation = True
            Me.DataGridViewForm_BCC.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_BCC.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_BCC.Size = New System.Drawing.Size(345, 125)
            Me.DataGridViewForm_BCC.TabIndex = 20
            Me.DataGridViewForm_BCC.TabStop = False
            Me.DataGridViewForm_BCC.UseEmbeddedNavigator = False
            Me.DataGridViewForm_BCC.ViewCaptionHeight = -1
            '
            'DataGridViewForm_CC
            '
            Me.DataGridViewForm_CC.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CC.AllowDragAndDrop = False
            Me.DataGridViewForm_CC.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CC.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CC.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CC.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CC.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CC.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CC.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CC.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CC.ItemDescription = "CC Recipient(s)"
            Me.DataGridViewForm_CC.Location = New System.Drawing.Point(625, 137)
            Me.DataGridViewForm_CC.MultiSelect = True
            Me.DataGridViewForm_CC.Name = "DataGridViewForm_CC"
            Me.DataGridViewForm_CC.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CC.RunStandardValidation = True
            Me.DataGridViewForm_CC.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CC.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CC.Size = New System.Drawing.Size(345, 125)
            Me.DataGridViewForm_CC.TabIndex = 18
            Me.DataGridViewForm_CC.TabStop = False
            Me.DataGridViewForm_CC.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CC.ViewCaptionHeight = -1
            '
            'ComboBoxForm_Source
            '
            Me.ComboBoxForm_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Source.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Source.BookmarkingEnabled = False
            Me.ComboBoxForm_Source.ClientCode = ""
            Me.ComboBoxForm_Source.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_Source.DisableMouseWheel = False
            Me.ComboBoxForm_Source.DisplayName = ""
            Me.ComboBoxForm_Source.DivisionCode = ""
            Me.ComboBoxForm_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Source.FocusHighlightEnabled = True
            Me.ComboBoxForm_Source.FormattingEnabled = True
            Me.ComboBoxForm_Source.ItemHeight = 16
            Me.ComboBoxForm_Source.Location = New System.Drawing.Point(74, 6)
            Me.ComboBoxForm_Source.Name = "ComboBoxForm_Source"
            Me.ComboBoxForm_Source.ReadOnly = False
            Me.ComboBoxForm_Source.SecurityEnabled = True
            Me.ComboBoxForm_Source.Size = New System.Drawing.Size(464, 22)
            Me.ComboBoxForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Source.TabIndex = 13
            Me.ComboBoxForm_Source.TabOnEnter = True
            '
            'LabelForm_RecipientSource
            '
            Me.LabelForm_RecipientSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RecipientSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RecipientSource.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_RecipientSource.Name = "LabelForm_RecipientSource"
            Me.LabelForm_RecipientSource.Size = New System.Drawing.Size(56, 20)
            Me.LabelForm_RecipientSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RecipientSource.TabIndex = 12
            Me.LabelForm_RecipientSource.Text = "Source:"
            '
            'DataGridViewForm_AvailableRecipients
            '
            Me.DataGridViewForm_AvailableRecipients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_AvailableRecipients.AllowDragAndDrop = False
            Me.DataGridViewForm_AvailableRecipients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_AvailableRecipients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableRecipients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AvailableRecipients.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AvailableRecipients.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AvailableRecipients.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableRecipients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AvailableRecipients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AvailableRecipients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableRecipients.ItemDescription = "Contact(s)"
            Me.DataGridViewForm_AvailableRecipients.Location = New System.Drawing.Point(12, 32)
            Me.DataGridViewForm_AvailableRecipients.MultiSelect = True
            Me.DataGridViewForm_AvailableRecipients.Name = "DataGridViewForm_AvailableRecipients"
            Me.DataGridViewForm_AvailableRecipients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableRecipients.RunStandardValidation = True
            Me.DataGridViewForm_AvailableRecipients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_AvailableRecipients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableRecipients.Size = New System.Drawing.Size(526, 361)
            Me.DataGridViewForm_AvailableRecipients.TabIndex = 14
            Me.DataGridViewForm_AvailableRecipients.TabStop = False
            Me.DataGridViewForm_AvailableRecipients.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableRecipients.ViewCaptionHeight = -1
            '
            'DataGridViewForm_To
            '
            Me.DataGridViewForm_To.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_To.AllowDragAndDrop = False
            Me.DataGridViewForm_To.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_To.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_To.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_To.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_To.AutoFilterLookupColumns = False
            Me.DataGridViewForm_To.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_To.AutoUpdateViewCaption = True
            Me.DataGridViewForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_To.DataSource = Nothing
            Me.DataGridViewForm_To.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_To.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_To.ItemDescription = "To Recipient(s)"
            Me.DataGridViewForm_To.Location = New System.Drawing.Point(625, 6)
            Me.DataGridViewForm_To.MultiSelect = True
            Me.DataGridViewForm_To.Name = "DataGridViewForm_To"
            Me.DataGridViewForm_To.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_To.RunStandardValidation = True
            Me.DataGridViewForm_To.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_To.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_To.Size = New System.Drawing.Size(345, 125)
            Me.DataGridViewForm_To.TabIndex = 16
            Me.DataGridViewForm_To.TabStop = False
            Me.DataGridViewForm_To.UseEmbeddedNavigator = False
            Me.DataGridViewForm_To.ViewCaptionHeight = -1
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
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(93, 399)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.SecurityEnabled = True
            Me.TextBoxForm_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(877, 21)
            Me.TextBoxForm_Subject.StartingFolderName = Nothing
            Me.TextBoxForm_Subject.TabIndex = 22
            Me.TextBoxForm_Subject.TabOnEnter = True
            '
            'LabelForm_Body
            '
            Me.LabelForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Body.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Body.Location = New System.Drawing.Point(12, 426)
            Me.LabelForm_Body.Name = "LabelForm_Body"
            Me.LabelForm_Body.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Body.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Body.TabIndex = 23
            Me.LabelForm_Body.Text = "Body:"
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(12, 399)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(75, 21)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 21
            Me.LabelForm_Subject.Text = "Subject:"
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
            Me.RibbonBarOptions_DefaultEmailSettings.Location = New System.Drawing.Point(218, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.MinimumSize = New System.Drawing.Size(133, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.Name = "RibbonBarOptions_DefaultEmailSettings"
            Me.RibbonBarOptions_DefaultEmailSettings.SecurityEnabled = True
            Me.RibbonBarOptions_DefaultEmailSettings.Size = New System.Drawing.Size(133, 95)
            Me.RibbonBarOptions_DefaultEmailSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DefaultEmailSettings.TabIndex = 15
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 95)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 16
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
            Me.RibbonBarOptions_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_SendToDocumentManager, Me.ButtonItemOptions_IncludeCoverSheet})
            Me.RibbonBarOptions_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Options.Location = New System.Drawing.Point(351, 0)
            Me.RibbonBarOptions_Options.MinimumSize = New System.Drawing.Size(133, 0)
            Me.RibbonBarOptions_Options.Name = "RibbonBarOptions_Options"
            Me.RibbonBarOptions_Options.SecurityEnabled = True
            Me.RibbonBarOptions_Options.Size = New System.Drawing.Size(187, 95)
            Me.RibbonBarOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Options.TabIndex = 17
            Me.RibbonBarOptions_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOptions_SendToDocumentManager
            '
            Me.ButtonItemOptions_SendToDocumentManager.AutoCheckOnClick = True
            Me.ButtonItemOptions_SendToDocumentManager.BeginGroup = True
            Me.ButtonItemOptions_SendToDocumentManager.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_SendToDocumentManager.Name = "ButtonItemOptions_SendToDocumentManager"
            Me.ButtonItemOptions_SendToDocumentManager.RibbonWordWrap = False
            Me.ButtonItemOptions_SendToDocumentManager.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_SendToDocumentManager.Text = "<span width=""25""></span>Send To <br></br>Document Manager"
            '
            'ButtonItemOptions_IncludeCoverSheet
            '
            Me.ButtonItemOptions_IncludeCoverSheet.AutoCheckOnClick = True
            Me.ButtonItemOptions_IncludeCoverSheet.BeginGroup = True
            Me.ButtonItemOptions_IncludeCoverSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_IncludeCoverSheet.Name = "ButtonItemOptions_IncludeCoverSheet"
            Me.ButtonItemOptions_IncludeCoverSheet.RibbonWordWrap = False
            Me.ButtonItemOptions_IncludeCoverSheet.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_IncludeCoverSheet.Text = "<span width=""12""></span>Include <br></br>Cover Sheet"
            '
            'TextBoxForm_Body
            '
            Me.TextBoxForm_Body.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
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
            Me.TextBoxForm_Body.Location = New System.Drawing.Point(93, 426)
            Me.TextBoxForm_Body.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Body.Multiline = True
            Me.TextBoxForm_Body.Name = "TextBoxForm_Body"
            Me.TextBoxForm_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxForm_Body.SecurityEnabled = True
            Me.TextBoxForm_Body.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(877, 123)
            Me.TextBoxForm_Body.StartingFolderName = Nothing
            Me.TextBoxForm_Body.TabIndex = 25
            Me.TextBoxForm_Body.TabOnEnter = False
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
            Me.RibbonBarOptions_PackageOptions.Location = New System.Drawing.Point(675, 0)
            Me.RibbonBarOptions_PackageOptions.Name = "RibbonBarOptions_PackageOptions"
            Me.RibbonBarOptions_PackageOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PackageOptions.Size = New System.Drawing.Size(189, 95)
            Me.RibbonBarOptions_PackageOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PackageOptions.TabIndex = 26
            Me.RibbonBarOptions_PackageOptions.Text = "Package Options"
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PackageOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
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
            Me.ItemContainerPackageOptions_PackageOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemPackageOptions_OneZipPerInvoice
            '
            Me.ButtonItemPackageOptions_OneZipPerInvoice.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
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
            Me.ButtonItemPackageOptions_OneZip.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
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
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(538, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(137, 95)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 27
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
            'InvoicePrintingSendEmailsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "InvoicePrintingSendEmailsDialog"
            Me.ShowUnsavedChangesOnFormClosing = False
            Me.Text = "Send Emails"
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
        Friend WithEvents ButtonForm_AddBCC As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddCC As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddTo As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_BCC As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_CC As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ComboBoxForm_Source As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_RecipientSource As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_AvailableRecipients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_To As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Body As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents RibbonBarOptions_DefaultEmailSettings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDefaultEmailSettings_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemOptions_SendToDocumentManager As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxForm_Body As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents RibbonBarOptions_PackageOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPackageOptions_OneZipPerInvoice As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemPackageOptions_OneZip As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents CheckBoxItemInclude_APDocuments As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_ExpenseDocuments As DevComponents.DotNetBar.CheckBoxItem
        Private WithEvents ButtonItemOptions_IncludeCoverSheet As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ItemContainerPackageOptions_PackageOptions As DevComponents.DotNetBar.ItemContainer
		Friend WithEvents ButtonItemPackageOptions_SinglePDF As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace