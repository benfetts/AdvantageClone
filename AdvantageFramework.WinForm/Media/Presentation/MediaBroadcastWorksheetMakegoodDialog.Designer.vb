Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMakegoodDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMakegoodDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Accept = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Reject = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelPanel_Vendor = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RibbonBarFilePanel_View = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemView_Rates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_Responses = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.BandedDataGridViewPanel_StagingMakegoods = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TextBoxPanel_VendorName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.RibbonBarOptions_GridOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGridOptions_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGridOptions_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.TextBoxPanel_VendorName)
            Me.PanelForm_Form.Controls.Add(Me.BandedDataGridViewPanel_StagingMakegoods)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_Vendor)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(698, 449)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(698, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_GridOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(698, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_View, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_GridOptions, 0)
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
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(698, 18)
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Accept, Me.ButtonItemActions_Reject})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(145, 92)
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
            'ButtonItemActions_Accept
            '
            Me.ButtonItemActions_Accept.BeginGroup = True
            Me.ButtonItemActions_Accept.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Accept.Name = "ButtonItemActions_Accept"
            Me.ButtonItemActions_Accept.RibbonWordWrap = False
            Me.ButtonItemActions_Accept.SecurityEnabled = True
            Me.ButtonItemActions_Accept.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Accept.Text = "Accept"
            '
            'ButtonItemActions_Reject
            '
            Me.ButtonItemActions_Reject.BeginGroup = True
            Me.ButtonItemActions_Reject.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Reject.Name = "ButtonItemActions_Reject"
            Me.ButtonItemActions_Reject.RibbonWordWrap = False
            Me.ButtonItemActions_Reject.SecurityEnabled = True
            Me.ButtonItemActions_Reject.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Reject.Text = "Reject"
            '
            'LabelPanel_Vendor
            '
            Me.LabelPanel_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Vendor.Location = New System.Drawing.Point(12, 6)
            Me.LabelPanel_Vendor.Name = "LabelPanel_Vendor"
            Me.LabelPanel_Vendor.Size = New System.Drawing.Size(68, 20)
            Me.LabelPanel_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Vendor.TabIndex = 0
            Me.LabelPanel_Vendor.Text = "Vendor:"
            '
            'RibbonBarFilePanel_View
            '
            Me.RibbonBarFilePanel_View.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_View.DragDropSupport = True
            Me.RibbonBarFilePanel_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Rates, Me.ButtonItemView_Responses})
            Me.RibbonBarFilePanel_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_View.Location = New System.Drawing.Point(248, 0)
            Me.RibbonBarFilePanel_View.Name = "RibbonBarFilePanel_View"
            Me.RibbonBarFilePanel_View.Size = New System.Drawing.Size(145, 92)
            Me.RibbonBarFilePanel_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_View.TabIndex = 2
            Me.RibbonBarFilePanel_View.Text = "View"
            '
            '
            '
            Me.RibbonBarFilePanel_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemView_Rates
            '
            Me.ButtonItemView_Rates.AutoCheckOnClick = True
            Me.ButtonItemView_Rates.BeginGroup = True
            Me.ButtonItemView_Rates.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemView_Rates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Rates.Name = "ButtonItemView_Rates"
            Me.ButtonItemView_Rates.RibbonWordWrap = False
            Me.ButtonItemView_Rates.SecurityEnabled = True
            Me.ButtonItemView_Rates.SubItemsExpandWidth = 14
            Me.ButtonItemView_Rates.Text = "Rates"
            '
            'ButtonItemView_Responses
            '
            Me.ButtonItemView_Responses.BeginGroup = True
            Me.ButtonItemView_Responses.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_Responses.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Responses.Name = "ButtonItemView_Responses"
            Me.ButtonItemView_Responses.RibbonWordWrap = False
            Me.ButtonItemView_Responses.SecurityEnabled = True
            Me.ButtonItemView_Responses.Stretch = True
            Me.ButtonItemView_Responses.SubItemsExpandWidth = 14
            Me.ButtonItemView_Responses.Text = "Responses"
            '
            'BandedDataGridViewPanel_StagingMakegoods
            '
            Me.BandedDataGridViewPanel_StagingMakegoods.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewPanel_StagingMakegoods.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewPanel_StagingMakegoods.AutoUpdateViewCaption = True
            Me.BandedDataGridViewPanel_StagingMakegoods.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewPanel_StagingMakegoods.ItemDescription = "Staging Makegoods"
            Me.BandedDataGridViewPanel_StagingMakegoods.Location = New System.Drawing.Point(12, 32)
            Me.BandedDataGridViewPanel_StagingMakegoods.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewPanel_StagingMakegoods.ModifyGridRowHeight = False
            Me.BandedDataGridViewPanel_StagingMakegoods.MultiSelect = False
            Me.BandedDataGridViewPanel_StagingMakegoods.Name = "BandedDataGridViewPanel_StagingMakegoods"
            Me.BandedDataGridViewPanel_StagingMakegoods.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewPanel_StagingMakegoods.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewPanel_StagingMakegoods.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewPanel_StagingMakegoods.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewPanel_StagingMakegoods.Size = New System.Drawing.Size(674, 411)
            Me.BandedDataGridViewPanel_StagingMakegoods.TabIndex = 4
            Me.BandedDataGridViewPanel_StagingMakegoods.UseEmbeddedNavigator = False
            Me.BandedDataGridViewPanel_StagingMakegoods.ViewCaptionHeight = -1
            '
            'TextBoxPanel_VendorName
            '
            Me.TextBoxPanel_VendorName.AgencyImportPath = Nothing
            Me.TextBoxPanel_VendorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPanel_VendorName.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_VendorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_VendorName.CheckSpellingOnValidate = False
            Me.TextBoxPanel_VendorName.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_VendorName.DisplayName = ""
            Me.TextBoxPanel_VendorName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_VendorName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_VendorName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_VendorName.FocusHighlightEnabled = True
            Me.TextBoxPanel_VendorName.Location = New System.Drawing.Point(86, 6)
            Me.TextBoxPanel_VendorName.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_VendorName.Name = "TextBoxPanel_VendorName"
            Me.TextBoxPanel_VendorName.PreventEnterBeep = True
            Me.TextBoxPanel_VendorName.ReadOnly = True
            Me.TextBoxPanel_VendorName.SecurityEnabled = True
            Me.TextBoxPanel_VendorName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_VendorName.Size = New System.Drawing.Size(600, 21)
            Me.TextBoxPanel_VendorName.StartingFolderName = Nothing
            Me.TextBoxPanel_VendorName.TabIndex = 5
            Me.TextBoxPanel_VendorName.TabOnEnter = True
            '
            'RibbonBarOptions_GridOptions
            '
            Me.RibbonBarOptions_GridOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_GridOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_GridOptions.DragDropSupport = True
            Me.RibbonBarOptions_GridOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGridOptions_ChooseColumns, Me.ButtonItemGridOptions_RestoreDefaults})
            Me.RibbonBarOptions_GridOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_GridOptions.Location = New System.Drawing.Point(393, 0)
            Me.RibbonBarOptions_GridOptions.Name = "RibbonBarOptions_GridOptions"
            Me.RibbonBarOptions_GridOptions.SecurityEnabled = True
            Me.RibbonBarOptions_GridOptions.Size = New System.Drawing.Size(198, 92)
            Me.RibbonBarOptions_GridOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_GridOptions.TabIndex = 14
            Me.RibbonBarOptions_GridOptions.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_GridOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_GridOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGridOptions_ChooseColumns
            '
            Me.ButtonItemGridOptions_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGridOptions_ChooseColumns.BeginGroup = True
            Me.ButtonItemGridOptions_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_ChooseColumns.Name = "ButtonItemGridOptions_ChooseColumns"
            Me.ButtonItemGridOptions_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGridOptions_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGridOptions_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGridOptions_RestoreDefaults
            '
            Me.ButtonItemGridOptions_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGridOptions_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGridOptions_RestoreDefaults.Name = "ButtonItemGridOptions_RestoreDefaults"
            Me.ButtonItemGridOptions_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGridOptions_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGridOptions_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGridOptions_RestoreDefaults.Text = "Restore Defaults"
            '
            'MediaBroadcastWorksheetMakegoodDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(708, 624)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMakegoodDialog"
            Me.Text = "Broadcast Worksheet Makegoods"
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
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemActions_Accept As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Reject As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelPanel_Vendor As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents RibbonBarFilePanel_View As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemView_Rates As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents BandedDataGridViewPanel_StagingMakegoods As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents TextBoxPanel_VendorName As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents ButtonItemView_Responses As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_GridOptions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGridOptions_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGridOptions_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace