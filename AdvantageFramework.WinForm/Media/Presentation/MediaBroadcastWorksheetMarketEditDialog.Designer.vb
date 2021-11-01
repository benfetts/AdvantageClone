Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketEditDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketEditDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFile_MediaPlan = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemMediaPlan_LoadMarkets = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFile_Books = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemBooks_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemBooks_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.RibbonBarFile_Submarkets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSubmarkets_Manage = New DevComponents.DotNetBar.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Markets)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            Me.PanelForm_Form.TabIndex = 0
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_Submarkets)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_Books)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_MediaPlan)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_MediaPlan, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_Books, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_Submarkets, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(152, 92)
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
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
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
            'DataGridViewForm_Markets
            '
            Me.DataGridViewForm_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewForm_Markets.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewForm_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Markets.ModifyGridRowHeight = False
            Me.DataGridViewForm_Markets.MultiSelect = False
            Me.DataGridViewForm_Markets.Name = "DataGridViewForm_Markets"
            Me.DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Markets.Size = New System.Drawing.Size(958, 543)
            Me.DataGridViewForm_Markets.TabIndex = 18
            Me.DataGridViewForm_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Markets.ViewCaptionHeight = -1
            '
            'RibbonBarFile_MediaPlan
            '
            Me.RibbonBarFile_MediaPlan.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_MediaPlan.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_MediaPlan.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_MediaPlan.DragDropSupport = True
            Me.RibbonBarFile_MediaPlan.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaPlan_LoadMarkets})
            Me.RibbonBarFile_MediaPlan.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_MediaPlan.Location = New System.Drawing.Point(255, 0)
            Me.RibbonBarFile_MediaPlan.Name = "RibbonBarFile_MediaPlan"
            Me.RibbonBarFile_MediaPlan.Size = New System.Drawing.Size(92, 92)
            Me.RibbonBarFile_MediaPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_MediaPlan.TabIndex = 2
            Me.RibbonBarFile_MediaPlan.Text = "Media Plan"
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemMediaPlan_LoadMarkets
            '
            Me.ButtonItemMediaPlan_LoadMarkets.BeginGroup = True
            Me.ButtonItemMediaPlan_LoadMarkets.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlan_LoadMarkets.Name = "ButtonItemMediaPlan_LoadMarkets"
            Me.ButtonItemMediaPlan_LoadMarkets.RibbonWordWrap = False
            Me.ButtonItemMediaPlan_LoadMarkets.SecurityEnabled = True
            Me.ButtonItemMediaPlan_LoadMarkets.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlan_LoadMarkets.Text = "Load Markets"
            '
            'RibbonBarFile_Books
            '
            Me.RibbonBarFile_Books.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFile_Books.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Books.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_Books.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_Books.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_Books.DragDropSupport = True
            Me.RibbonBarFile_Books.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBooks_Add, Me.ButtonItemBooks_CopyTo})
            Me.RibbonBarFile_Books.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_Books.Location = New System.Drawing.Point(347, 0)
            Me.RibbonBarFile_Books.Name = "RibbonBarFile_Books"
            Me.RibbonBarFile_Books.Size = New System.Drawing.Size(97, 92)
            Me.RibbonBarFile_Books.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_Books.TabIndex = 3
            Me.RibbonBarFile_Books.Text = "Books"
            '
            '
            '
            Me.RibbonBarFile_Books.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Books.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemBooks_Add
            '
            Me.ButtonItemBooks_Add.BeginGroup = True
            Me.ButtonItemBooks_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBooks_Add.Name = "ButtonItemBooks_Add"
            Me.ButtonItemBooks_Add.RibbonWordWrap = False
            Me.ButtonItemBooks_Add.SecurityEnabled = True
            Me.ButtonItemBooks_Add.SubItemsExpandWidth = 14
            Me.ButtonItemBooks_Add.Text = "Add"
            '
            'ButtonItemBooks_CopyTo
            '
            Me.ButtonItemBooks_CopyTo.BeginGroup = True
            Me.ButtonItemBooks_CopyTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBooks_CopyTo.Name = "ButtonItemBooks_CopyTo"
            Me.ButtonItemBooks_CopyTo.RibbonWordWrap = False
            Me.ButtonItemBooks_CopyTo.SecurityEnabled = True
            Me.ButtonItemBooks_CopyTo.SubItemsExpandWidth = 14
            Me.ButtonItemBooks_CopyTo.Text = "Copy To"
            '
            'ToolTipController
            '
            '
            'RibbonBarFile_Submarkets
            '
            Me.RibbonBarFile_Submarkets.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFile_Submarkets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Submarkets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_Submarkets.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_Submarkets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_Submarkets.DragDropSupport = True
            Me.RibbonBarFile_Submarkets.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFile_Submarkets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSubmarkets_Manage})
            Me.RibbonBarFile_Submarkets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_Submarkets.Location = New System.Drawing.Point(444, 0)
            Me.RibbonBarFile_Submarkets.MinimumSize = New System.Drawing.Size(104, 0)
            Me.RibbonBarFile_Submarkets.Name = "RibbonBarFile_Submarkets"
            Me.RibbonBarFile_Submarkets.SecurityEnabled = True
            Me.RibbonBarFile_Submarkets.Size = New System.Drawing.Size(104, 92)
            Me.RibbonBarFile_Submarkets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_Submarkets.TabIndex = 32
            Me.RibbonBarFile_Submarkets.Text = "Canadian Markets"
            '
            '
            '
            Me.RibbonBarFile_Submarkets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Submarkets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSubmarkets_Manage
            '
            Me.ButtonItemSubmarkets_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSubmarkets_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSubmarkets_Manage.Name = "ButtonItemSubmarkets_Manage"
            Me.ButtonItemSubmarkets_Manage.RibbonWordWrap = False
            Me.ButtonItemSubmarkets_Manage.Stretch = True
            Me.ButtonItemSubmarkets_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemSubmarkets_Manage.Text = "Manage"
            '
            'MediaBroadcastWorksheetMarketEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketEditDialog"
            Me.Text = "Broadcast Worksheet Markets"
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
		Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents DataGridViewForm_Markets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarFile_MediaPlan As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ButtonItemMediaPlan_LoadMarkets As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents RibbonBarFile_Books As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ButtonItemBooks_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemBooks_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents RibbonBarFile_Submarkets As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSubmarkets_Manage As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace