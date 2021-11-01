Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaOrderPrintingOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaOrderPrintingOptionsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_FormatLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.VerticalGridMediaOrder_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.OrderPrintSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.categoryPrintOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowLocationID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryReportFormat = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIsCustomFormat = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowReportFormat = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryStandardOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowDateOverride = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRemoveSignatureLines = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeEmployeeSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPutSignatureBelowAllComments = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSeparationPolicy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOrderHeaderCommentOption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintRevision = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMediaTitleOption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMediaTitleOverride = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowApplyExchangeRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExchangeRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryOptionalHeaderInformation = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMarket = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDivisionName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintProductDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryOptionalFooterInformation = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowShippingAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAgencyCommission = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryRepOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.categoryRep1Options = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeRep1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDefaultLabelFromVendor1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRep1Label = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryRep2Options = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeRep2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDefaultLabelFromVendor2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRep2Label = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryOptionalDetailInformation = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowBroadcastShowEmptyWeeks = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowShowLineNumbers = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowProgramming = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowStartTime = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowEndTime = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLength = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRemarks = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowProductionSize = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowHeadline = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIssue = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowURL = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowCopyArea = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPlacement1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPlacement2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTargetAudience = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowEdition = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSection = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMaterial = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAdNumber = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowJobNumber = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMaterialDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowSpaceCloseDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInstructions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMiscInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOrderCopy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMaterialNotes = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPositionInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowCloseInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRateInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDays = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDaypart = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAddedValue = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowBookends = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrimaryRating = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrimaryCPP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDayDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrimaryImpressions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrimaryAQH = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrimaryCPM = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeFlighting = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeLineMarket = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryQuantityRate = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowGuaranteed = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowProjected = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowActual = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowCostPer = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetQtyOverrideText = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeClientAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.VerticalGridMediaOrder_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.OrderPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "DevExpress Design"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.VerticalGridMediaOrder_Settings)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Format)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_FormatLabel)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.PanelForm_Form.Size = New System.Drawing.Size(647, 383)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(647, 154)
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
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(647, 93)
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
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 538)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(647, 18)
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 91)
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
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'LabelForm_FormatLabel
            '
            Me.LabelForm_FormatLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FormatLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FormatLabel.Location = New System.Drawing.Point(12, 7)
            Me.LabelForm_FormatLabel.Name = "LabelForm_FormatLabel"
            Me.LabelForm_FormatLabel.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_FormatLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FormatLabel.TabIndex = 0
            Me.LabelForm_FormatLabel.Text = "Format:"
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(69, 7)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(566, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 1
            '
            'VerticalGridMediaOrder_Settings
            '
            Me.VerticalGridMediaOrder_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridMediaOrder_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridMediaOrder_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridMediaOrder_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridMediaOrder_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridMediaOrder_Settings.DataSource = Me.OrderPrintSettingBindingSource
            Me.VerticalGridMediaOrder_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridMediaOrder_Settings.Location = New System.Drawing.Point(12, 33)
            Me.VerticalGridMediaOrder_Settings.Name = "VerticalGridMediaOrder_Settings"
            Me.VerticalGridMediaOrder_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridMediaOrder_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridMediaOrder_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridMediaOrder_Settings.RecordWidth = 88
            Me.VerticalGridMediaOrder_Settings.RowHeaderWidth = 112
            Me.VerticalGridMediaOrder_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryPrintOptions, Me.categoryReportFormat, Me.categoryStandardOptions, Me.categoryOptionalHeaderInformation, Me.categoryOptionalFooterInformation, Me.categoryRepOptions, Me.categoryOptionalDetailInformation, Me.categoryQuantityRate})
            Me.VerticalGridMediaOrder_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridMediaOrder_Settings.Size = New System.Drawing.Size(623, 344)
            Me.VerticalGridMediaOrder_Settings.TabIndex = 2
            Me.VerticalGridMediaOrder_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'OrderPrintSettingBindingSource
            '
            Me.OrderPrintSettingBindingSource.DataSource = GetType(AdvantageFramework.Media.Classes.OrderPrintSetting)
            '
            'categoryPrintOptions
            '
            Me.categoryPrintOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowLocationID})
            Me.categoryPrintOptions.Name = "categoryPrintOptions"
            Me.categoryPrintOptions.Properties.Caption = "Print Options"
            '
            'rowLocationID
            '
            Me.rowLocationID.Name = "rowLocationID"
            Me.rowLocationID.Properties.Caption = "Location"
            Me.rowLocationID.Properties.FieldName = "LocationID"
            '
            'categoryReportFormat
            '
            Me.categoryReportFormat.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIsCustomFormat, Me.rowReportFormat})
            Me.categoryReportFormat.Name = "categoryReportFormat"
            Me.categoryReportFormat.Properties.Caption = "Report Format"
            '
            'rowIsCustomFormat
            '
            Me.rowIsCustomFormat.Name = "rowIsCustomFormat"
            Me.rowIsCustomFormat.Properties.Caption = "Is Custom Format"
            Me.rowIsCustomFormat.Properties.ReadOnly = False
            Me.rowIsCustomFormat.Visible = False
            '
            'rowReportFormat
            '
            Me.rowReportFormat.Name = "rowReportFormat"
            Me.rowReportFormat.Properties.Caption = "Report Format"
            Me.rowReportFormat.Properties.FieldName = "ReportFormat"
            '
            'categoryStandardOptions
            '
            Me.categoryStandardOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowDateOverride, Me.rowRemoveSignatureLines, Me.rowExcludeEmployeeSignature, Me.rowPutSignatureBelowAllComments, Me.rowSeparationPolicy, Me.rowOrderHeaderCommentOption, Me.rowPrintRevision, Me.rowMediaTitleOption, Me.rowMediaTitleOverride, Me.rowIncludeClientAddress, Me.rowApplyExchangeRate, Me.rowExchangeRate})
            Me.categoryStandardOptions.Name = "categoryStandardOptions"
            Me.categoryStandardOptions.Properties.Caption = "Standard Options"
            '
            'rowDateOverride
            '
            Me.rowDateOverride.Name = "rowDateOverride"
            Me.rowDateOverride.Properties.Caption = "Date Override"
            Me.rowDateOverride.Properties.FieldName = "DateOverride"
            '
            'rowRemoveSignatureLines
            '
            Me.rowRemoveSignatureLines.Name = "rowRemoveSignatureLines"
            Me.rowRemoveSignatureLines.Properties.Caption = "Remove Signature Lines"
            Me.rowRemoveSignatureLines.Properties.FieldName = "RemoveSignatureLines"
            '
            'rowExcludeEmployeeSignature
            '
            Me.rowExcludeEmployeeSignature.Name = "rowExcludeEmployeeSignature"
            Me.rowExcludeEmployeeSignature.Properties.Caption = "Exclude Employee Signature"
            Me.rowExcludeEmployeeSignature.Properties.FieldName = "ExcludeEmployeeSignature"
            '
            'rowPutSignatureBelowAllComments
            '
            Me.rowPutSignatureBelowAllComments.Name = "rowPutSignatureBelowAllComments"
            Me.rowPutSignatureBelowAllComments.Properties.Caption = "Put Signature Below All Comments"
            Me.rowPutSignatureBelowAllComments.Properties.FieldName = "PutSignatureBelowAllComments"
            '
            'rowSeparationPolicy
            '
            Me.rowSeparationPolicy.Name = "rowSeparationPolicy"
            Me.rowSeparationPolicy.Properties.Caption = "Separation Policy"
            Me.rowSeparationPolicy.Properties.FieldName = "SeparationPolicy"
            '
            'rowOrderHeaderCommentOption
            '
            Me.rowOrderHeaderCommentOption.Name = "rowOrderHeaderCommentOption"
            Me.rowOrderHeaderCommentOption.Properties.Caption = "Order Header Comment"
            Me.rowOrderHeaderCommentOption.Properties.FieldName = "OrderHeaderCommentOption"
            '
            'rowPrintRevision
            '
            Me.rowPrintRevision.Name = "rowPrintRevision"
            Me.rowPrintRevision.Properties.Caption = "Print Revision"
            Me.rowPrintRevision.Properties.FieldName = "PrintRevision"
            '
            'rowMediaTitleOption
            '
            Me.rowMediaTitleOption.Name = "rowMediaTitleOption"
            Me.rowMediaTitleOption.Properties.Caption = "Media Title Option"
            Me.rowMediaTitleOption.Properties.FieldName = "MediaTitleOption"
            '
            'rowMediaTitleOverride
            '
            Me.rowMediaTitleOverride.Name = "rowMediaTitleOverride"
            Me.rowMediaTitleOverride.Properties.Caption = "Media Title Override"
            Me.rowMediaTitleOverride.Properties.FieldName = "MediaTitleOverride"
            '
            'rowApplyExchangeRate
            '
            Me.rowApplyExchangeRate.Name = "rowApplyExchangeRate"
            Me.rowApplyExchangeRate.Properties.Caption = "Apply Exchange Rate"
            Me.rowApplyExchangeRate.Properties.FieldName = "ApplyExchangeRate"
            '
            'rowExchangeRate
            '
            Me.rowExchangeRate.Name = "rowExchangeRate"
            Me.rowExchangeRate.Properties.Caption = "Exchange Rate"
            Me.rowExchangeRate.Properties.FieldName = "ExchangeRate"
            Me.rowExchangeRate.Properties.Format.FormatString = """{0:n4}"""
            '
            'categoryOptionalHeaderInformation
            '
            Me.categoryOptionalHeaderInformation.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowCampaign, Me.rowMarket, Me.rowPrintClientName, Me.rowPrintDivisionName, Me.rowPrintProductDescription})
            Me.categoryOptionalHeaderInformation.Name = "categoryOptionalHeaderInformation"
            Me.categoryOptionalHeaderInformation.Properties.Caption = "Optional Header Information"
            '
            'rowCampaign
            '
            Me.rowCampaign.Name = "rowCampaign"
            Me.rowCampaign.Properties.Caption = "Campaign"
            Me.rowCampaign.Properties.FieldName = "Campaign"
            '
            'rowMarket
            '
            Me.rowMarket.Name = "rowMarket"
            Me.rowMarket.Properties.Caption = "Market"
            Me.rowMarket.Properties.FieldName = "Market"
            '
            'rowPrintClientName
            '
            Me.rowPrintClientName.Name = "rowPrintClientName"
            Me.rowPrintClientName.Properties.Caption = "Print Client Name"
            Me.rowPrintClientName.Properties.FieldName = "PrintClientName"
            '
            'rowPrintDivisionName
            '
            Me.rowPrintDivisionName.Name = "rowPrintDivisionName"
            Me.rowPrintDivisionName.Properties.Caption = "Print Division Name"
            Me.rowPrintDivisionName.Properties.FieldName = "PrintDivisionName"
            '
            'rowPrintProductDescription
            '
            Me.rowPrintProductDescription.Name = "rowPrintProductDescription"
            Me.rowPrintProductDescription.Properties.Caption = "Print Product Description"
            Me.rowPrintProductDescription.Properties.FieldName = "PrintProductDescription"
            '
            'categoryOptionalFooterInformation
            '
            Me.categoryOptionalFooterInformation.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowShippingAddress, Me.rowAgencyCommission})
            Me.categoryOptionalFooterInformation.Name = "categoryOptionalFooterInformation"
            Me.categoryOptionalFooterInformation.Properties.Caption = "Optional Footer Information"
            '
            'rowShippingAddress
            '
            Me.rowShippingAddress.Name = "rowShippingAddress"
            Me.rowShippingAddress.Properties.Caption = "Shipping Address"
            Me.rowShippingAddress.Properties.FieldName = "ShippingAddress"
            '
            'rowAgencyCommission
            '
            Me.rowAgencyCommission.Name = "rowAgencyCommission"
            Me.rowAgencyCommission.Properties.Caption = "Show Commission on Gross"
            Me.rowAgencyCommission.Properties.FieldName = "AgencyCommission"
            '
            'categoryRepOptions
            '
            Me.categoryRepOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryRep1Options, Me.categoryRep2Options})
            Me.categoryRepOptions.Name = "categoryRepOptions"
            Me.categoryRepOptions.Properties.Caption = "Rep Options"
            '
            'categoryRep1Options
            '
            Me.categoryRep1Options.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeRep1, Me.rowDefaultLabelFromVendor1, Me.rowRep1Label})
            Me.categoryRep1Options.Name = "categoryRep1Options"
            Me.categoryRep1Options.Properties.Caption = "Rep 1 Options"
            '
            'rowIncludeRep1
            '
            Me.rowIncludeRep1.Name = "rowIncludeRep1"
            Me.rowIncludeRep1.Properties.Caption = "Include on Vendor Order"
            Me.rowIncludeRep1.Properties.FieldName = "IncludeRep1"
            '
            'rowDefaultLabelFromVendor1
            '
            Me.rowDefaultLabelFromVendor1.Name = "rowDefaultLabelFromVendor1"
            Me.rowDefaultLabelFromVendor1.Properties.Caption = "Default Label From Vendor"
            Me.rowDefaultLabelFromVendor1.Properties.FieldName = "DefaultLabelFromVendor1"
            '
            'rowRep1Label
            '
            Me.rowRep1Label.Name = "rowRep1Label"
            Me.rowRep1Label.Properties.Caption = "Label"
            Me.rowRep1Label.Properties.FieldName = "Rep1Label"
            '
            'categoryRep2Options
            '
            Me.categoryRep2Options.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeRep2, Me.rowDefaultLabelFromVendor2, Me.rowRep2Label})
            Me.categoryRep2Options.Name = "categoryRep2Options"
            Me.categoryRep2Options.Properties.Caption = "Rep 2 Options"
            '
            'rowIncludeRep2
            '
            Me.rowIncludeRep2.Name = "rowIncludeRep2"
            Me.rowIncludeRep2.Properties.Caption = "Include on Vendor Order"
            Me.rowIncludeRep2.Properties.FieldName = "IncludeRep2"
            '
            'rowDefaultLabelFromVendor2
            '
            Me.rowDefaultLabelFromVendor2.Name = "rowDefaultLabelFromVendor2"
            Me.rowDefaultLabelFromVendor2.Properties.Caption = "Default Label From Vendor"
            Me.rowDefaultLabelFromVendor2.Properties.FieldName = "DefaultLabelFromVendor2"
            '
            'rowRep2Label
            '
            Me.rowRep2Label.Name = "rowRep2Label"
            Me.rowRep2Label.Properties.Caption = "Label"
            Me.rowRep2Label.Properties.FieldName = "Rep2Label"
            '
            'categoryOptionalDetailInformation
            '
            Me.categoryOptionalDetailInformation.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowBroadcastShowEmptyWeeks, Me.rowShowLineNumbers, Me.rowProgramming, Me.rowStartTime, Me.rowEndTime, Me.rowLength, Me.rowRemarks, Me.rowProductionSize, Me.rowType, Me.rowHeadline, Me.rowIssue, Me.rowURL, Me.rowLocation, Me.rowCopyArea, Me.rowPlacement1, Me.rowPlacement2, Me.rowTargetAudience, Me.rowEdition, Me.rowSection, Me.rowMaterial, Me.rowAdNumber, Me.rowJobNumber, Me.rowMaterialDueDate, Me.rowSpaceCloseDate, Me.rowInstructions, Me.rowMiscInfo, Me.rowOrderCopy, Me.rowMaterialNotes, Me.rowPositionInfo, Me.rowCloseInfo, Me.rowRateInfo, Me.rowDays, Me.rowDaypart, Me.rowAddedValue, Me.rowBookends, Me.rowPrimaryRating, Me.rowPrimaryCPP, Me.rowPrintDayDate, Me.rowPrimaryImpressions, Me.rowPrimaryAQH, Me.rowPrimaryCPM, Me.rowIncludeFlighting, Me.rowIncludeLineMarket})
            Me.categoryOptionalDetailInformation.Name = "categoryOptionalDetailInformation"
            Me.categoryOptionalDetailInformation.Properties.Caption = "Optional Detail Information"
            '
            'rowBroadcastShowEmptyWeeks
            '
            Me.rowBroadcastShowEmptyWeeks.Name = "rowBroadcastShowEmptyWeeks"
            Me.rowBroadcastShowEmptyWeeks.Properties.Caption = "Show weeks w/out spots"
            Me.rowBroadcastShowEmptyWeeks.Properties.FieldName = "BroadcastShowEmptyWeeks"
            '
            'rowShowLineNumbers
            '
            Me.rowShowLineNumbers.Name = "rowShowLineNumbers"
            Me.rowShowLineNumbers.Properties.Caption = "Show Line Numbers"
            Me.rowShowLineNumbers.Properties.FieldName = "ShowLineNumbers"
            '
            'rowProgramming
            '
            Me.rowProgramming.Name = "rowProgramming"
            Me.rowProgramming.Properties.Caption = "Programming"
            Me.rowProgramming.Properties.FieldName = "Programming"
            '
            'rowStartTime
            '
            Me.rowStartTime.Name = "rowStartTime"
            Me.rowStartTime.Properties.Caption = "Start Time"
            Me.rowStartTime.Properties.FieldName = "StartTime"
            '
            'rowEndTime
            '
            Me.rowEndTime.Name = "rowEndTime"
            Me.rowEndTime.Properties.Caption = "End Time"
            Me.rowEndTime.Properties.FieldName = "EndTime"
            '
            'rowLength
            '
            Me.rowLength.Name = "rowLength"
            Me.rowLength.Properties.Caption = "Length"
            Me.rowLength.Properties.FieldName = "Length"
            '
            'rowRemarks
            '
            Me.rowRemarks.Name = "rowRemarks"
            Me.rowRemarks.Properties.Caption = "Remarks"
            Me.rowRemarks.Properties.FieldName = "Remarks"
            '
            'rowProductionSize
            '
            Me.rowProductionSize.Name = "rowProductionSize"
            Me.rowProductionSize.Properties.Caption = "Production Size"
            Me.rowProductionSize.Properties.FieldName = "ProductionSize"
            '
            'rowType
            '
            Me.rowType.Name = "rowType"
            Me.rowType.Properties.Caption = "Type"
            Me.rowType.Properties.FieldName = "Type"
            '
            'rowHeadline
            '
            Me.rowHeadline.Name = "rowHeadline"
            Me.rowHeadline.Properties.Caption = "Headline"
            Me.rowHeadline.Properties.FieldName = "Headline"
            '
            'rowIssue
            '
            Me.rowIssue.Name = "rowIssue"
            Me.rowIssue.Properties.Caption = "Issue"
            Me.rowIssue.Properties.FieldName = "Issue"
            '
            'rowURL
            '
            Me.rowURL.Name = "rowURL"
            Me.rowURL.Properties.Caption = "URL"
            Me.rowURL.Properties.FieldName = "URL"
            '
            'rowLocation
            '
            Me.rowLocation.Name = "rowLocation"
            Me.rowLocation.Properties.Caption = "Location"
            Me.rowLocation.Properties.FieldName = "Location"
            '
            'rowCopyArea
            '
            Me.rowCopyArea.Name = "rowCopyArea"
            Me.rowCopyArea.Properties.Caption = "Copy Area"
            Me.rowCopyArea.Properties.FieldName = "CopyArea"
            '
            'rowPlacement1
            '
            Me.rowPlacement1.Name = "rowPlacement1"
            Me.rowPlacement1.Properties.Caption = "Placement"
            Me.rowPlacement1.Properties.FieldName = "Placement1"
            '
            'rowPlacement2
            '
            Me.rowPlacement2.Name = "rowPlacement2"
            Me.rowPlacement2.Properties.Caption = "Package Name"
            Me.rowPlacement2.Properties.FieldName = "Placement2"
            '
            'rowTargetAudience
            '
            Me.rowTargetAudience.Name = "rowTargetAudience"
            Me.rowTargetAudience.Properties.Caption = "Target Audience"
            Me.rowTargetAudience.Properties.FieldName = "TargetAudience"
            '
            'rowEdition
            '
            Me.rowEdition.Name = "rowEdition"
            Me.rowEdition.Properties.Caption = "Edition"
            Me.rowEdition.Properties.FieldName = "Edition"
            '
            'rowSection
            '
            Me.rowSection.Name = "rowSection"
            Me.rowSection.Properties.Caption = "Section"
            Me.rowSection.Properties.FieldName = "Section"
            '
            'rowMaterial
            '
            Me.rowMaterial.Name = "rowMaterial"
            Me.rowMaterial.Properties.Caption = "Material"
            Me.rowMaterial.Properties.FieldName = "Material"
            '
            'rowAdNumber
            '
            Me.rowAdNumber.Name = "rowAdNumber"
            Me.rowAdNumber.Properties.Caption = "Ad Number"
            Me.rowAdNumber.Properties.FieldName = "AdNumber"
            '
            'rowJobNumber
            '
            Me.rowJobNumber.Name = "rowJobNumber"
            Me.rowJobNumber.Properties.Caption = "Job Number"
            Me.rowJobNumber.Properties.FieldName = "JobNumber"
            '
            'rowMaterialDueDate
            '
            Me.rowMaterialDueDate.Name = "rowMaterialDueDate"
            Me.rowMaterialDueDate.Properties.Caption = "Material Due Date"
            Me.rowMaterialDueDate.Properties.FieldName = "MaterialDueDate"
            '
            'rowSpaceCloseDate
            '
            Me.rowSpaceCloseDate.Name = "rowSpaceCloseDate"
            Me.rowSpaceCloseDate.Properties.Caption = "Space Close Date"
            Me.rowSpaceCloseDate.Properties.FieldName = "SpaceCloseDate"
            '
            'rowInstructions
            '
            Me.rowInstructions.Name = "rowInstructions"
            Me.rowInstructions.Properties.Caption = "Instructions"
            Me.rowInstructions.Properties.FieldName = "Instructions"
            '
            'rowMiscInfo
            '
            Me.rowMiscInfo.Name = "rowMiscInfo"
            Me.rowMiscInfo.Properties.Caption = "Misc Info"
            Me.rowMiscInfo.Properties.FieldName = "MiscInfo"
            '
            'rowOrderCopy
            '
            Me.rowOrderCopy.Name = "rowOrderCopy"
            Me.rowOrderCopy.Properties.Caption = "Order Copy"
            Me.rowOrderCopy.Properties.FieldName = "OrderCopy"
            '
            'rowMaterialNotes
            '
            Me.rowMaterialNotes.Name = "rowMaterialNotes"
            Me.rowMaterialNotes.Properties.Caption = "Material Notes"
            Me.rowMaterialNotes.Properties.FieldName = "MaterialNotes"
            '
            'rowPositionInfo
            '
            Me.rowPositionInfo.Name = "rowPositionInfo"
            Me.rowPositionInfo.Properties.Caption = "Position Info"
            Me.rowPositionInfo.Properties.FieldName = "PositionInfo"
            '
            'rowCloseInfo
            '
            Me.rowCloseInfo.Name = "rowCloseInfo"
            Me.rowCloseInfo.Properties.Caption = "Close Info"
            Me.rowCloseInfo.Properties.FieldName = "CloseInfo"
            '
            'rowRateInfo
            '
            Me.rowRateInfo.Name = "rowRateInfo"
            Me.rowRateInfo.Properties.Caption = "Rate Info"
            Me.rowRateInfo.Properties.FieldName = "RateInfo"
            '
            'rowDays
            '
            Me.rowDays.Name = "rowDays"
            Me.rowDays.Properties.Caption = "Days"
            Me.rowDays.Properties.FieldName = "Days"
            '
            'rowDaypart
            '
            Me.rowDaypart.Name = "rowDaypart"
            Me.rowDaypart.Properties.Caption = "Daypart"
            Me.rowDaypart.Properties.FieldName = "Daypart"
            '
            'rowAddedValue
            '
            Me.rowAddedValue.Name = "rowAddedValue"
            Me.rowAddedValue.Properties.Caption = "Added Value"
            Me.rowAddedValue.Properties.FieldName = "AddedValue"
            '
            'rowBookends
            '
            Me.rowBookends.Name = "rowBookends"
            Me.rowBookends.Properties.Caption = "Bookends"
            Me.rowBookends.Properties.FieldName = "Bookends"
            '
            'rowPrimaryRating
            '
            Me.rowPrimaryRating.Name = "rowPrimaryRating"
            Me.rowPrimaryRating.Properties.Caption = "Primary Ratings"
            Me.rowPrimaryRating.Properties.FieldName = "PrimaryRatings"
            '
            'rowPrimaryCPP
            '
            Me.rowPrimaryCPP.Name = "rowPrimaryCPP"
            Me.rowPrimaryCPP.Properties.Caption = "Primary CPP"
            Me.rowPrimaryCPP.Properties.FieldName = "PrimaryCPP"
            '
            'rowPrintDayDate
            '
            Me.rowPrintDayDate.Name = "rowPrintDayDate"
            Me.rowPrintDayDate.Properties.Caption = "Print Day/Date"
            Me.rowPrintDayDate.Properties.FieldName = "PrintDayDate"
            '
            'rowPrimaryImpressions
            '
            Me.rowPrimaryImpressions.Name = "rowPrimaryImpressions"
            Me.rowPrimaryImpressions.Properties.Caption = "Primary Impressions"
            Me.rowPrimaryImpressions.Properties.FieldName = "PrimaryImpressions"
            '
            'rowPrimaryAQH
            '
            Me.rowPrimaryAQH.Name = "rowPrimaryAQH"
            Me.rowPrimaryAQH.Properties.Caption = "Primary AQH(00)"
            Me.rowPrimaryAQH.Properties.FieldName = "PrimaryAQH"
            '
            'rowPrimaryCPM
            '
            Me.rowPrimaryCPM.Name = "rowPrimaryCPM"
            Me.rowPrimaryCPM.Properties.Caption = "Primary CPM"
            Me.rowPrimaryCPM.Properties.FieldName = "PrimaryCPM"
            '
            'rowIncludeFlighting
            '
            Me.rowIncludeFlighting.Name = "rowIncludeFlighting"
            Me.rowIncludeFlighting.Properties.Caption = "Include Flighting"
            Me.rowIncludeFlighting.Properties.FieldName = "IncludeFlighting"
            '
            'rowIncludeLineMarket
            '
            Me.rowIncludeLineMarket.Name = "rowIncludeLineMarket"
            Me.rowIncludeLineMarket.Properties.Caption = "Include Line Market"
            Me.rowIncludeLineMarket.Properties.FieldName = "IncludeLineMarket"
            '
            'categoryQuantityRate
            '
            Me.categoryQuantityRate.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowGuaranteed, Me.rowProjected, Me.rowActual, Me.rowCostPer, Me.rowInternetQtyOverrideText})
            Me.categoryQuantityRate.Name = "categoryQuantityRate"
            Me.categoryQuantityRate.Properties.Caption = "Quantity/Rate"
            '
            'rowGuaranteed
            '
            Me.rowGuaranteed.Name = "rowGuaranteed"
            Me.rowGuaranteed.Properties.Caption = "Guaranteed"
            Me.rowGuaranteed.Properties.FieldName = "Guaranteed"
            '
            'rowProjected
            '
            Me.rowProjected.Name = "rowProjected"
            Me.rowProjected.Properties.Caption = "Projected"
            Me.rowProjected.Properties.FieldName = "Projected"
            '
            'rowActual
            '
            Me.rowActual.Name = "rowActual"
            Me.rowActual.Properties.Caption = "Actual"
            Me.rowActual.Properties.FieldName = "Actual"
            '
            'rowCostPer
            '
            Me.rowCostPer.Name = "rowCostPer"
            Me.rowCostPer.Properties.Caption = "Cost Per"
            Me.rowCostPer.Properties.FieldName = "CostPer"
            '
            'rowInternetQtyOverrideText
            '
            Me.rowInternetQtyOverrideText.Name = "rowInternetQtyOverrideText"
            Me.rowInternetQtyOverrideText.Properties.Caption = "Internet Qty Override Text"
            Me.rowInternetQtyOverrideText.Properties.FieldName = "InternetQtyOverrideText"
            '
            'rowIncludeClientAddress
            '
            Me.rowIncludeClientAddress.Name = "rowIncludeClientAddress"
            Me.rowIncludeClientAddress.Properties.Caption = "Include Client Address"
            Me.rowIncludeClientAddress.Properties.FieldName = "IncludeClientAddress"
            '
            'MediaOrderPrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(657, 558)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "MediaOrderPrintingOptionsDialog"
            Me.Text = "Media Order Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.VerticalGridMediaOrder_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.OrderPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Private WithEvents LabelForm_FormatLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents VerticalGridMediaOrder_Settings As WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents OrderPrintSettingBindingSource As Windows.Forms.BindingSource
        Friend WithEvents categoryPrintOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowLocationID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryReportFormat As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIsCustomFormat As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowReportFormat As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryStandardOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowDateOverride As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeEmployeeSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintRevision As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMediaTitleOption As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryOptionalHeaderInformation As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMarket As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDivisionName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintProductDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryOptionalFooterInformation As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowShippingAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryRepOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents categoryRep1Options As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeRep1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDefaultLabelFromVendor1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRep1Label As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryRep2Options As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeRep2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDefaultLabelFromVendor2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRep2Label As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryOptionalDetailInformation As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowProgramming As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowStartTime As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowEndTime As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLength As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRemarks As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowProductionSize As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHeadline As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIssue As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowURL As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowCopyArea As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPlacement1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPlacement2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTargetAudience As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowEdition As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSection As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMaterial As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAdNumber As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowJobNumber As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMaterialDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSpaceCloseDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInstructions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMiscInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOrderCopy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMaterialNotes As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPositionInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowCloseInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRateInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryQuantityRate As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowGuaranteed As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowProjected As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowActual As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowCostPer As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOrderHeaderCommentOption As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSeparationPolicy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrimaryCPP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrimaryRating As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBookends As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAddedValue As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDaypart As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDays As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAgencyCommission As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPutSignatureBelowAllComments As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDayDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrimaryCPM As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrimaryImpressions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrimaryAQH As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRemoveSignatureLines As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowLineNumbers As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeFlighting As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeLineMarket As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetQtyOverrideText As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBroadcastShowEmptyWeeks As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowApplyExchangeRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExchangeRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMediaTitleOverride As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeClientAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

