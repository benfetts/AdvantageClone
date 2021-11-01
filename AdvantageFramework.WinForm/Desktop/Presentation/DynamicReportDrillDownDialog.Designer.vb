Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DynamicReportDrillDownDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DynamicReportDrillDownDialog))
            Me.DataGridViewForm_DrillDownItems = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            Me.RibbonControlForm_MainRibbon.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.CaptionVisible = True
            Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanelFile_FilePanel)
            Me.RibbonControlForm_MainRibbon.Dock = System.Windows.Forms.DockStyle.Top
            Me.RibbonControlForm_MainRibbon.EnableQatPlacement = False
            Me.RibbonControlForm_MainRibbon.ForeColor = System.Drawing.Color.Black
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItemMainRibbon_File})
            Me.RibbonControlForm_MainRibbon.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
            Me.RibbonControlForm_MainRibbon.Location = New System.Drawing.Point(5, 1)
            Me.RibbonControlForm_MainRibbon.MdiSystemItemVisible = False
            Me.RibbonControlForm_MainRibbon.Name = "RibbonControlForm_MainRibbon"
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
            Me.RibbonControlForm_MainRibbon.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(780, 154)
            Me.RibbonControlForm_MainRibbon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
            Me.RibbonControlForm_MainRibbon.TabGroupHeight = 14
            Me.RibbonControlForm_MainRibbon.TabGroupsVisible = True
            Me.RibbonControlForm_MainRibbon.TabIndex = 1
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Name = "RibbonPanelFile_FilePanel"
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(780, 94)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 1
            Me.RibbonPanelFile_FilePanel.Visible = True
            '
            'RibbonBarFilePanel_System
            '
            Me.RibbonBarFilePanel_System.AutoOverflowEnabled = False
            Me.RibbonBarFilePanel_System.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_System.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_System.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_System.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSystem_Close})
            Me.RibbonBarFilePanel_System.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(3, 0)
            Me.RibbonBarFilePanel_System.Name = "RibbonBarFilePanel_System"
            Me.RibbonBarFilePanel_System.ResizeItemsToFit = False
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 91)
            Me.RibbonBarFilePanel_System.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_System.TabIndex = 0
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle

            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            Me.ButtonItemSystem_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSystem_Close.Name = "ButtonItemSystem_Close"
            Me.ButtonItemSystem_Close.SubItemsExpandWidth = 14
            Me.ButtonItemSystem_Close.Text = "Close"
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.AutoExpandOnClick = True
            Me.Office2007StartButtonMainRibbon_Home.CanCustomize = False
            Me.Office2007StartButtonMainRibbon_Home.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 2
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 2
            Me.Office2007StartButtonMainRibbon_Home.Name = "Office2007StartButtonMainRibbon_Home"
            Me.Office2007StartButtonMainRibbon_Home.ShowSubItems = False
            Me.Office2007StartButtonMainRibbon_Home.Text = "Home"
            Me.Office2007StartButtonMainRibbon_Home.Visible = False
            '
            'RibbonTabItemMainRibbon_File
            '
            Me.RibbonTabItemMainRibbon_File.Checked = True
            Me.RibbonTabItemMainRibbon_File.Name = "RibbonTabItemMainRibbon_File"
            Me.RibbonTabItemMainRibbon_File.Panel = Me.RibbonPanelFile_FilePanel
            Me.RibbonTabItemMainRibbon_File.Text = "File"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_DrillDownItems)
            Me.PanelForm_Form.Size = New System.Drawing.Size(780, 293)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.AccessibleDescription = "DotNetBar Bar ()"
            Me.BarForm_StatusBar.AccessibleName = "DotNetBar Bar"
            Me.BarForm_StatusBar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
            Me.BarForm_StatusBar.AntiAlias = True
            Me.BarForm_StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar
            Me.BarForm_StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.BarForm_StatusBar.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.BarForm_StatusBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
            Me.BarForm_StatusBar.ItemSpacing = 3
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 448)
            Me.BarForm_StatusBar.Name = "BarForm_StatusBar"
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(780, 18)
            Me.BarForm_StatusBar.Stretch = True
            Me.BarForm_StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.BarForm_StatusBar.TabIndex = 16
            Me.BarForm_StatusBar.TabStop = False
            '
            'DataGridViewForm_DrillDownItems
            '
            Me.DataGridViewForm_DrillDownItems.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_DrillDownItems.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_DrillDownItems.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_DrillDownItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_DrillDownItems.AutoFilterLookupColumns = False
            Me.DataGridViewForm_DrillDownItems.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_DrillDownItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_DrillDownItems.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_DrillDownItems.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_DrillDownItems.ItemDescription = "Item(s)"
            Me.DataGridViewForm_DrillDownItems.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewForm_DrillDownItems.MultiSelect = True
            Me.DataGridViewForm_DrillDownItems.Name = "DataGridViewForm_DrillDownItems"
            Me.DataGridViewForm_DrillDownItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_DrillDownItems.RunStandardValidation = True
            Me.DataGridViewForm_DrillDownItems.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_DrillDownItems.Size = New System.Drawing.Size(774, 287)
            Me.DataGridViewForm_DrillDownItems.TabIndex = 0
            Me.DataGridViewForm_DrillDownItems.UseEmbeddedNavigator = False
            Me.DataGridViewForm_DrillDownItems.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(138, 0)
            Me.RibbonBarOptions_Actions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RibbonBarOptions_Actions.MinimumSize = New System.Drawing.Size(80, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(80, 126)
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
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'DynamicReportDrillDownDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(790, 468)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DynamicReportDrillDownDialog"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_DrillDownItems As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Print As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace