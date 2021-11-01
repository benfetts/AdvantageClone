Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerAdServingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerAdServingDialog))
            Me.DataGridViewForm_AdServing = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CreateAdvertisers = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CreateCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CreatePlacements = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_UpdatePlacements = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ClearPlacement = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Report = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_FunctionGrid = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGrid_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGrid_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGrid_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_AdServing)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1044, 449)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1044, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_FunctionGrid)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1044, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_FunctionGrid, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(55, 92)
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
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1044, 18)
            '
            'DataGridViewForm_AdServing
            '
            Me.DataGridViewForm_AdServing.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AdServing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AdServing.DataSource = Nothing
            Me.DataGridViewForm_AdServing.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AdServing.ItemDescription = "Order Detail(s)"
            Me.DataGridViewForm_AdServing.Location = New System.Drawing.Point(4, 7)
            Me.DataGridViewForm_AdServing.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_AdServing.MultiSelect = True
            Me.DataGridViewForm_AdServing.Name = "DataGridViewForm_AdServing"
            Me.DataGridViewForm_AdServing.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AdServing.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_AdServing.Size = New System.Drawing.Size(1036, 435)
            Me.DataGridViewForm_AdServing.TabIndex = 5
            Me.DataGridViewForm_AdServing.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_CreateAdvertisers, Me.ButtonItemActions_CreateCampaigns, Me.ButtonItemActions_CreatePlacements, Me.ButtonItemActions_UpdatePlacements, Me.ButtonItemActions_ClearPlacement, Me.ButtonItemActions_Report})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(58, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(769, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 19
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
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
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'ButtonItemActions_CreateAdvertisers
            '
            Me.ButtonItemActions_CreateAdvertisers.BeginGroup = True
            Me.ButtonItemActions_CreateAdvertisers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateAdvertisers.Name = "ButtonItemActions_CreateAdvertisers"
            Me.ButtonItemActions_CreateAdvertisers.RibbonWordWrap = False
            Me.ButtonItemActions_CreateAdvertisers.SecurityEnabled = True
            Me.ButtonItemActions_CreateAdvertisers.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateAdvertisers.Text = "Create Advertisers"
            '
            'ButtonItemActions_CreateCampaigns
            '
            Me.ButtonItemActions_CreateCampaigns.BeginGroup = True
            Me.ButtonItemActions_CreateCampaigns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateCampaigns.Name = "ButtonItemActions_CreateCampaigns"
            Me.ButtonItemActions_CreateCampaigns.RibbonWordWrap = False
            Me.ButtonItemActions_CreateCampaigns.SecurityEnabled = True
            Me.ButtonItemActions_CreateCampaigns.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateCampaigns.Text = "Create Campaigns"
            '
            'ButtonItemActions_CreatePlacements
            '
            Me.ButtonItemActions_CreatePlacements.BeginGroup = True
            Me.ButtonItemActions_CreatePlacements.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreatePlacements.Name = "ButtonItemActions_CreatePlacements"
            Me.ButtonItemActions_CreatePlacements.RibbonWordWrap = False
            Me.ButtonItemActions_CreatePlacements.SecurityEnabled = True
            Me.ButtonItemActions_CreatePlacements.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreatePlacements.Text = "Create Placements"
            '
            'ButtonItemActions_UpdatePlacements
            '
            Me.ButtonItemActions_UpdatePlacements.BeginGroup = True
            Me.ButtonItemActions_UpdatePlacements.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdatePlacements.Name = "ButtonItemActions_UpdatePlacements"
            Me.ButtonItemActions_UpdatePlacements.RibbonWordWrap = False
            Me.ButtonItemActions_UpdatePlacements.SecurityEnabled = True
            Me.ButtonItemActions_UpdatePlacements.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdatePlacements.Text = "Update Placements"
            '
            'ButtonItemActions_ClearPlacement
            '
            Me.ButtonItemActions_ClearPlacement.BeginGroup = True
            Me.ButtonItemActions_ClearPlacement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ClearPlacement.Name = "ButtonItemActions_ClearPlacement"
            Me.ButtonItemActions_ClearPlacement.RibbonWordWrap = False
            Me.ButtonItemActions_ClearPlacement.SecurityEnabled = True
            Me.ButtonItemActions_ClearPlacement.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ClearPlacement.Text = "Clear Placement"
            '
            'ButtonItemActions_Report
            '
            Me.ButtonItemActions_Report.BeginGroup = True
            Me.ButtonItemActions_Report.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Report.Name = "ButtonItemActions_Report"
            Me.ButtonItemActions_Report.RibbonWordWrap = False
            Me.ButtonItemActions_Report.SecurityEnabled = True
            Me.ButtonItemActions_Report.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Report.Text = "Report"
            '
            'RibbonBarOptions_FunctionGrid
            '
            Me.RibbonBarOptions_FunctionGrid.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_FunctionGrid.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_FunctionGrid.DragDropSupport = True
            Me.RibbonBarOptions_FunctionGrid.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGrid_ChooseColumns, Me.ButtonItemGrid_RestoreDefaults, Me.ButtonItemGrid_SelectAll})
            Me.RibbonBarOptions_FunctionGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_FunctionGrid.Location = New System.Drawing.Point(827, 0)
            Me.RibbonBarOptions_FunctionGrid.Name = "RibbonBarOptions_FunctionGrid"
            Me.RibbonBarOptions_FunctionGrid.SecurityEnabled = True
            Me.RibbonBarOptions_FunctionGrid.Size = New System.Drawing.Size(253, 92)
            Me.RibbonBarOptions_FunctionGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_FunctionGrid.TabIndex = 20
            Me.RibbonBarOptions_FunctionGrid.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_FunctionGrid.Visible = False
            '
            'ButtonItemGrid_ChooseColumns
            '
            Me.ButtonItemGrid_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGrid_ChooseColumns.BeginGroup = True
            Me.ButtonItemGrid_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_ChooseColumns.Name = "ButtonItemGrid_ChooseColumns"
            Me.ButtonItemGrid_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGrid_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGrid_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGrid_RestoreDefaults
            '
            Me.ButtonItemGrid_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGrid_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_RestoreDefaults.Name = "ButtonItemGrid_RestoreDefaults"
            Me.ButtonItemGrid_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGrid_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGrid_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_RestoreDefaults.Text = "Restore Defaults"
            '
            'ButtonItemGrid_SelectAll
            '
            Me.ButtonItemGrid_SelectAll.AutoCheckOnClick = True
            Me.ButtonItemGrid_SelectAll.BeginGroup = True
            Me.ButtonItemGrid_SelectAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_SelectAll.Name = "ButtonItemGrid_SelectAll"
            Me.ButtonItemGrid_SelectAll.RibbonWordWrap = False
            Me.ButtonItemGrid_SelectAll.SecurityEnabled = True
            Me.ButtonItemGrid_SelectAll.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_SelectAll.Text = "Select All"
            '
            'MediaManagerAdServingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1054, 624)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerAdServingDialog"
            Me.Text = "Media Manager Ad Serving"
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
        Friend WithEvents DataGridViewForm_AdServing As WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Report As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarOptions_FunctionGrid As WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemGrid_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemGrid_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemGrid_SelectAll As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_CreateAdvertisers As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_CreateCampaigns As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_CreatePlacements As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_UpdatePlacements As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ClearPlacement As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace