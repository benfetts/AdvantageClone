Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanMasterPlanEditDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanMasterPlanEditDialog))
			Me.MediaPlanMasterPlanForm_MasterPlan = New AdvantageFramework.WinForm.Presentation.Controls.MediaPlanMasterPlanControl()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarOptions_PrintingOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemPrintingOptions_ShowHiatusDates = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemPrintingOptions_GroupByMediaTypes = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonControlForm_MainRibbon.SuspendLayout()
			Me.RibbonPanelFile_FilePanel.SuspendLayout()
			CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_Form.SuspendLayout()
			CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'RibbonControlForm_MainRibbon
			'
			'
			'
			'
			Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Dashboard)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PrintingOptions)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
			Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
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
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PrintingOptions, 0)
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Dashboard, 0)
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
			'PanelForm_Form
			'
			Me.PanelForm_Form.Controls.Add(Me.MediaPlanMasterPlanForm_MasterPlan)
			Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
			'
			'BarForm_StatusBar
			'
			Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
			Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
			'
			'MediaPlanMasterPlanForm_MasterPlan
			'
			Me.MediaPlanMasterPlanForm_MasterPlan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.MediaPlanMasterPlanForm_MasterPlan.Location = New System.Drawing.Point(12, 6)
			Me.MediaPlanMasterPlanForm_MasterPlan.Name = "MediaPlanMasterPlanForm_MasterPlan"
			Me.MediaPlanMasterPlanForm_MasterPlan.Size = New System.Drawing.Size(958, 543)
			Me.MediaPlanMasterPlanForm_MasterPlan.TabIndex = 0
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Print})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(172, 92)
			Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Actions.TabIndex = 10
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
			'ButtonItemActions_Print
			'
			Me.ButtonItemActions_Print.BeginGroup = True
			Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
			Me.ButtonItemActions_Print.RibbonWordWrap = False
			Me.ButtonItemActions_Print.SecurityEnabled = True
			Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Print.Text = "Print"
			'
			'RibbonBarOptions_Dashboard
			'
			Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Dashboard.DragDropSupport = True
			Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
			Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
			Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(566, 0)
			Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
			Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
			Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
			Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 92)
			Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Dashboard.TabIndex = 12
			Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
			'
			'
			'
			Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemDashboard_Edit
			'
			Me.ButtonItemDashboard_Edit.BeginGroup = True
			Me.ButtonItemDashboard_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
			Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
			Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
			Me.ButtonItemDashboard_Edit.Text = "Edit"
			'
			'RibbonBarOptions_PrintingOptions
			'
			Me.RibbonBarOptions_PrintingOptions.AutoOverflowEnabled = False
			Me.RibbonBarOptions_PrintingOptions.AutoSizeItems = False
			'
			'
			'
			Me.RibbonBarOptions_PrintingOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_PrintingOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_PrintingOptions.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_PrintingOptions.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_PrintingOptions.DragDropSupport = True
			Me.RibbonBarOptions_PrintingOptions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
			Me.RibbonBarOptions_PrintingOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrintingOptions_ShowHiatusDates, Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates, Me.ButtonItemPrintingOptions_GroupByMediaTypes})
			Me.RibbonBarOptions_PrintingOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_PrintingOptions.Location = New System.Drawing.Point(275, 0)
			Me.RibbonBarOptions_PrintingOptions.MinimumSize = New System.Drawing.Size(120, 0)
			Me.RibbonBarOptions_PrintingOptions.Name = "RibbonBarOptions_PrintingOptions"
			Me.RibbonBarOptions_PrintingOptions.SecurityEnabled = True
			Me.RibbonBarOptions_PrintingOptions.Size = New System.Drawing.Size(291, 92)
			Me.RibbonBarOptions_PrintingOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_PrintingOptions.TabIndex = 11
			Me.RibbonBarOptions_PrintingOptions.Text = "Printing Options"
			'
			'
			'
			Me.RibbonBarOptions_PrintingOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_PrintingOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_PrintingOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ButtonItemPrintingOptions_ShowHiatusDates
			'
			Me.ButtonItemPrintingOptions_ShowHiatusDates.AutoCheckOnClick = True
			Me.ButtonItemPrintingOptions_ShowHiatusDates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemPrintingOptions_ShowHiatusDates.Checked = True
			Me.ButtonItemPrintingOptions_ShowHiatusDates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemPrintingOptions_ShowHiatusDates.Name = "ButtonItemPrintingOptions_ShowHiatusDates"
			Me.ButtonItemPrintingOptions_ShowHiatusDates.RibbonWordWrap = False
			Me.ButtonItemPrintingOptions_ShowHiatusDates.SubItemsExpandWidth = 14
			Me.ButtonItemPrintingOptions_ShowHiatusDates.Text = "<span width=""15""></span>Show<br></br>Hiatus Dates"
			'
			'ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates
			'
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.AutoCheckOnClick = True
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = True
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Name = "ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates"
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.RibbonWordWrap = False
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.SubItemsExpandWidth = 14
			Me.ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Text = "Add Column Headers<br></br><span width=""10""></span>To All Estimates"
			'
			'ButtonItemPrintingOptions_GroupByMediaTypes
			'
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.AutoCheckOnClick = True
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.BeginGroup = True
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.ImageFixedSize = New System.Drawing.Size(32, 32)
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.Name = "ButtonItemPrintingOptions_GroupByMediaTypes"
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.RibbonWordWrap = False
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.SubItemsExpandWidth = 14
			Me.ButtonItemPrintingOptions_GroupByMediaTypes.Text = "<span width=""5""></span>Group By<br></br>Media Types"
			'
			'MediaPlanMasterPlanEditDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(992, 730)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaPlanMasterPlanEditDialog"
			Me.Text = "Master Plan"
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
		Friend WithEvents MediaPlanMasterPlanForm_MasterPlan As WinForm.Presentation.Controls.MediaPlanMasterPlanControl
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_PrintingOptions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPrintingOptions_ShowHiatusDates As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemPrintingOptions_GroupByMediaTypes As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
