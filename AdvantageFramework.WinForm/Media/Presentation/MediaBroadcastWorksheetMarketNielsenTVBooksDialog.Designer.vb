Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketNielsenTVBooksDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketNielsenTVBooksDialog))
			Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.DataGridViewForm_NielsenTVBooks = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
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
			Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_NielsenTVBooks)
			Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
			Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
			Me.PanelForm_Form.Size = New System.Drawing.Size(619, 374)
			'
			'RibbonControlForm_MainRibbon
			'
			'
			'
			'
			Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(619, 154)
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
			Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(619, 94)
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
			Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 529)
			Me.BarForm_StatusBar.Size = New System.Drawing.Size(619, 18)
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
			Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Delete})
			Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
			Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
			Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(152, 92)
			Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarFilePanel_Actions.TabIndex = 2
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
			'DataGridViewForm_NielsenTVBooks
			'
			Me.DataGridViewForm_NielsenTVBooks.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_NielsenTVBooks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_NielsenTVBooks.AutoUpdateViewCaption = True
			Me.DataGridViewForm_NielsenTVBooks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_NielsenTVBooks.ItemDescription = "Book(s)"
			Me.DataGridViewForm_NielsenTVBooks.Location = New System.Drawing.Point(12, 6)
			Me.DataGridViewForm_NielsenTVBooks.ModifyColumnSettingsOnEachDataSource = True
			Me.DataGridViewForm_NielsenTVBooks.ModifyGridRowHeight = False
			Me.DataGridViewForm_NielsenTVBooks.MultiSelect = False
			Me.DataGridViewForm_NielsenTVBooks.Name = "DataGridViewForm_NielsenTVBooks"
			Me.DataGridViewForm_NielsenTVBooks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewForm_NielsenTVBooks.ShowRowSelectionIfHidden = True
			Me.DataGridViewForm_NielsenTVBooks.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_NielsenTVBooks.Size = New System.Drawing.Size(595, 362)
			Me.DataGridViewForm_NielsenTVBooks.TabIndex = 19
			Me.DataGridViewForm_NielsenTVBooks.UseEmbeddedNavigator = False
			Me.DataGridViewForm_NielsenTVBooks.ViewCaptionHeight = -1
			'
			'MediaBroadcastWorksheetMarketNielsenTVBooksDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(629, 549)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaBroadcastWorksheetMarketNielsenTVBooksDialog"
			Me.Text = "Worksheet Market Books"
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

		Friend WithEvents DataGridViewForm_NielsenTVBooks As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
	End Class

End Namespace