Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetOrderDataDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetOrderDataDialog))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_MarketDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterForm_LeftRightSections = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_MarketDetailData = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ItemContainerActions_Revisions = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemRevisions_Revision = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemRevisions_Revisions = New DevComponents.DotNetBar.ComboBoxItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterForm_LeftRightSections)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_RightSection)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_LeftSection)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1108, 458)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1108, 154)
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
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1108, 94)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 613)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1108, 18)
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_MarketDetails)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(325, 458)
            Me.PanelForm_LeftSection.TabIndex = 12
            '
            'DataGridViewLeftSection_MarketDetails
            '
            Me.DataGridViewLeftSection_MarketDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_MarketDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_MarketDetails.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_MarketDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_MarketDetails.ItemDescription = "Market Detail(s)"
            Me.DataGridViewLeftSection_MarketDetails.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_MarketDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_MarketDetails.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_MarketDetails.MultiSelect = False
            Me.DataGridViewLeftSection_MarketDetails.Name = "DataGridViewLeftSection_MarketDetails"
            Me.DataGridViewLeftSection_MarketDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_MarketDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_MarketDetails.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_MarketDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_MarketDetails.Size = New System.Drawing.Size(307, 434)
            Me.DataGridViewLeftSection_MarketDetails.TabIndex = 1
            Me.DataGridViewLeftSection_MarketDetails.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_MarketDetails.ViewCaptionHeight = -1
            '
            'ExpandableSplitterForm_LeftRightSections
            '
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftRightSections.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftRightSections.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftRightSections.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftRightSections.Location = New System.Drawing.Point(325, 0)
            Me.ExpandableSplitterForm_LeftRightSections.Name = "ExpandableSplitterForm_LeftRightSections"
            Me.ExpandableSplitterForm_LeftRightSections.Size = New System.Drawing.Size(6, 458)
            Me.ExpandableSplitterForm_LeftRightSections.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftRightSections.TabIndex = 13
            Me.ExpandableSplitterForm_LeftRightSections.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_MarketDetailData)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(325, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(783, 458)
            Me.PanelForm_RightSection.TabIndex = 15
            '
            'DataGridViewRightSection_MarketDetailData
            '
            Me.DataGridViewRightSection_MarketDetailData.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_MarketDetailData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_MarketDetailData.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_MarketDetailData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_MarketDetailData.ItemDescription = "Market Detail Data(s)"
            Me.DataGridViewRightSection_MarketDetailData.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewRightSection_MarketDetailData.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRightSection_MarketDetailData.ModifyGridRowHeight = False
            Me.DataGridViewRightSection_MarketDetailData.MultiSelect = False
            Me.DataGridViewRightSection_MarketDetailData.Name = "DataGridViewRightSection_MarketDetailData"
            Me.DataGridViewRightSection_MarketDetailData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_MarketDetailData.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRightSection_MarketDetailData.ShowRowSelectionIfHidden = True
            Me.DataGridViewRightSection_MarketDetailData.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_MarketDetailData.Size = New System.Drawing.Size(759, 434)
            Me.DataGridViewRightSection_MarketDetailData.TabIndex = 15
            Me.DataGridViewRightSection_MarketDetailData.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_MarketDetailData.ViewCaptionHeight = -1
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = False
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_Revisions})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(149, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 23
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
            'ItemContainerActions_Revisions
            '
            '
            '
            '
            Me.ItemContainerActions_Revisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Revisions.Name = "ItemContainerActions_Revisions"
            Me.ItemContainerActions_Revisions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemRevisions_Revision, Me.ComboBoxItemRevisions_Revisions})
            '
            '
            '
            Me.ItemContainerActions_Revisions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerActions_Revisions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemRevisions_Revision
            '
            Me.LabelItemRevisions_Revision.Name = "LabelItemRevisions_Revision"
            Me.LabelItemRevisions_Revision.Text = "Revision:"
            '
            'ComboBoxItemRevisions_Revisions
            '
            Me.ComboBoxItemRevisions_Revisions.ComboWidth = 75
            Me.ComboBoxItemRevisions_Revisions.DropDownHeight = 106
            Me.ComboBoxItemRevisions_Revisions.Name = "ComboBoxItemRevisions_Revisions"
            Me.ComboBoxItemRevisions_Revisions.Text = "ComboBoxItem1"
            '
            'MediaBroadcastWorksheetOrderDataDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1118, 633)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetOrderDataDialog"
            Me.Text = "Worksheet Order Data"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ExpandableSplitterForm_LeftRightSections As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
		Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
		Friend WithEvents DataGridViewLeftSection_MarketDetails As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
		Friend WithEvents DataGridViewRightSection_MarketDetailData As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ItemContainerActions_Revisions As DevComponents.DotNetBar.ItemContainer
		Friend WithEvents LabelItemRevisions_Revision As DevComponents.DotNetBar.LabelItem
		Friend WithEvents ComboBoxItemRevisions_Revisions As DevComponents.DotNetBar.ComboBoxItem
	End Class

End Namespace