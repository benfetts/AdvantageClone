Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanActualizeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanActualizeDialog))
            Me.DataGridViewForm_EstimateDetail = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Actualize = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ActualizeNoRollFoward = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollFowardAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollFowardNext = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollForwardPercent = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_FunctionGrid = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGrid_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGrid_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_BottomSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_BottomSection.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_BottomSection)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1011, 489)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1011, 154)
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
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1011, 94)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 644)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1011, 18)
            '
            'DataGridViewForm_EstimateDetail
            '
            Me.DataGridViewForm_EstimateDetail.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_EstimateDetail.AutoUpdateViewCaption = False
            Me.DataGridViewForm_EstimateDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_EstimateDetail.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_EstimateDetail.ItemDescription = "Estimate Detail(s)"
            Me.DataGridViewForm_EstimateDetail.Location = New System.Drawing.Point(2, 2)
            Me.DataGridViewForm_EstimateDetail.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_EstimateDetail.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_EstimateDetail.ModifyGridRowHeight = False
            Me.DataGridViewForm_EstimateDetail.MultiSelect = True
            Me.DataGridViewForm_EstimateDetail.Name = "DataGridViewForm_EstimateDetail"
            Me.DataGridViewForm_EstimateDetail.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_EstimateDetail.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_EstimateDetail.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_EstimateDetail.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_EstimateDetail.Size = New System.Drawing.Size(1007, 485)
            Me.DataGridViewForm_EstimateDetail.TabIndex = 5
            Me.DataGridViewForm_EstimateDetail.UseEmbeddedNavigator = False
            Me.DataGridViewForm_EstimateDetail.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_Actualize})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(58, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(286, 92)
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
            Me.ButtonItemActions_Refresh.Visible = False
            '
            'ButtonItemActions_Actualize
            '
            Me.ButtonItemActions_Actualize.AutoExpandOnClick = True
            Me.ButtonItemActions_Actualize.BeginGroup = True
            Me.ButtonItemActions_Actualize.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemActions_Actualize.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Actualize.Name = "ButtonItemActions_Actualize"
            Me.ButtonItemActions_Actualize.RibbonWordWrap = False
            Me.ButtonItemActions_Actualize.SecurityEnabled = True
            Me.ButtonItemActions_Actualize.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ActualizeNoRollFoward, Me.ButtonItemActions_ActualizeRollFowardAll, Me.ButtonItemActions_ActualizeRollFowardNext, Me.ButtonItemActions_ActualizeRollForwardPercent})
            Me.ButtonItemActions_Actualize.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Actualize.Text = "Actualize"
            '
            'ButtonItemActions_ActualizeNoRollFoward
            '
            Me.ButtonItemActions_ActualizeNoRollFoward.Name = "ButtonItemActions_ActualizeNoRollFoward"
            Me.ButtonItemActions_ActualizeNoRollFoward.Text = "No Roll Foward"
            '
            'ButtonItemActions_ActualizeRollFowardAll
            '
            Me.ButtonItemActions_ActualizeRollFowardAll.Name = "ButtonItemActions_ActualizeRollFowardAll"
            Me.ButtonItemActions_ActualizeRollFowardAll.Text = "Roll Forward All"
            '
            'ButtonItemActions_ActualizeRollFowardNext
            '
            Me.ButtonItemActions_ActualizeRollFowardNext.Name = "ButtonItemActions_ActualizeRollFowardNext"
            Me.ButtonItemActions_ActualizeRollFowardNext.Text = "Roll Forward Next"
            '
            'ButtonItemActions_ActualizeRollForwardPercent
            '
            Me.ButtonItemActions_ActualizeRollForwardPercent.Name = "ButtonItemActions_ActualizeRollForwardPercent"
            Me.ButtonItemActions_ActualizeRollForwardPercent.Text = "Roll Forward Percent"
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
            Me.RibbonBarOptions_FunctionGrid.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGrid_ChooseColumns, Me.ButtonItemGrid_RestoreDefaults})
            Me.RibbonBarOptions_FunctionGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_FunctionGrid.Location = New System.Drawing.Point(344, 0)
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
            'PanelForm_BottomSection
            '
            Me.PanelForm_BottomSection.Controls.Add(Me.DataGridViewForm_EstimateDetail)
            Me.PanelForm_BottomSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_BottomSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_BottomSection.Name = "PanelForm_BottomSection"
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(1011, 489)
            Me.PanelForm_BottomSection.TabIndex = 24
            '
            'MediaPlanActualizeDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1021, 664)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanActualizeDialog"
            Me.Text = "Media Plan Actualize"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_BottomSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_EstimateDetail As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_FunctionGrid As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGrid_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGrid_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents PanelForm_BottomSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Actualize As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeNoRollFoward As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeRollFowardAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeRollFowardNext As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeRollForwardPercent As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
