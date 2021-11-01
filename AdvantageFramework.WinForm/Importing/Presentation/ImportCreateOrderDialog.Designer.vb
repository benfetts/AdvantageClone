Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ImportCreateOrderDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportCreateOrderDialog))
			Me.DataGridViewForm_Orders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
			Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
			Me.RibbonBarOptions_OrderTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemOrderType_NewOnly = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemOrderType_NewAndRevised = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.LabelForm_OrderDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TextBoxForm_OrderDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
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
			Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Orders)
			Me.PanelForm_Form.Controls.Add(Me.LabelForm_OrderDescription)
			Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_OrderDescription)
			Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
			Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
			Me.PanelForm_Form.Size = New System.Drawing.Size(1076, 319)
			'
			'RibbonControlForm_MainRibbon
			'
			'
			'
			'
			Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
			Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
			Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1076, 154)
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
			Me.RibbonControlForm_MainRibbon.TabIndex = 0
			Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
			'
			'RibbonPanelFile_FilePanel
			'
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_OrderTypes)
			Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
			Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
			Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
			Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1076, 94)
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
			Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_OrderTypes, 0)
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
			Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(2)
			Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 90)
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
			Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 474)
			Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
			Me.BarForm_StatusBar.Size = New System.Drawing.Size(1076, 18)
			'
			'DataGridViewForm_Orders
			'
			Me.DataGridViewForm_Orders.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewForm_Orders.AllowDragAndDrop = False
			Me.DataGridViewForm_Orders.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewForm_Orders.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_Orders.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewForm_Orders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_Orders.AutoFilterLookupColumns = False
			Me.DataGridViewForm_Orders.AutoloadRepositoryDatasource = True
			Me.DataGridViewForm_Orders.AutoUpdateViewCaption = True
			Me.DataGridViewForm_Orders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
			Me.DataGridViewForm_Orders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewForm_Orders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_Orders.ItemDescription = "Media Order(s)"
			Me.DataGridViewForm_Orders.Location = New System.Drawing.Point(4, 34)
			Me.DataGridViewForm_Orders.Margin = New System.Windows.Forms.Padding(4)
			Me.DataGridViewForm_Orders.MultiSelect = True
			Me.DataGridViewForm_Orders.Name = "DataGridViewForm_Orders"
			Me.DataGridViewForm_Orders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewForm_Orders.RunStandardValidation = True
			Me.DataGridViewForm_Orders.ShowColumnMenuOnRightClick = False
			Me.DataGridViewForm_Orders.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_Orders.Size = New System.Drawing.Size(1068, 277)
			Me.DataGridViewForm_Orders.TabIndex = 2
			Me.DataGridViewForm_Orders.UseEmbeddedNavigator = False
			Me.DataGridViewForm_Orders.ViewCaptionHeight = -1
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 90)
			Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Actions.TabIndex = 1
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
			'ButtonItemActions_Delete
			'
			Me.ButtonItemActions_Delete.BeginGroup = True
			Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
			Me.ButtonItemActions_Delete.RibbonWordWrap = False
			Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Delete.Text = "Delete"
			'
			'RibbonBarOptions_OrderTypes
			'
			Me.RibbonBarOptions_OrderTypes.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_OrderTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_OrderTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_OrderTypes.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_OrderTypes.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_OrderTypes.DragDropSupport = True
			Me.RibbonBarOptions_OrderTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOrderType_NewOnly, Me.ButtonItemOrderType_NewAndRevised})
			Me.RibbonBarOptions_OrderTypes.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
			Me.RibbonBarOptions_OrderTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_OrderTypes.Location = New System.Drawing.Point(246, 0)
			Me.RibbonBarOptions_OrderTypes.Name = "RibbonBarOptions_OrderTypes"
			Me.RibbonBarOptions_OrderTypes.SecurityEnabled = True
			Me.RibbonBarOptions_OrderTypes.Size = New System.Drawing.Size(148, 90)
			Me.RibbonBarOptions_OrderTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_OrderTypes.TabIndex = 24
			Me.RibbonBarOptions_OrderTypes.Text = "Create Order Types"
			'
			'
			'
			Me.RibbonBarOptions_OrderTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_OrderTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_OrderTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ButtonItemOrderType_NewOnly
			'
			Me.ButtonItemOrderType_NewOnly.AutoCheckOnClick = True
			Me.ButtonItemOrderType_NewOnly.Name = "ButtonItemOrderType_NewOnly"
			Me.ButtonItemOrderType_NewOnly.OptionGroup = "OrderType"
			Me.ButtonItemOrderType_NewOnly.SecurityEnabled = True
			Me.ButtonItemOrderType_NewOnly.Stretch = True
			Me.ButtonItemOrderType_NewOnly.SubItemsExpandWidth = 14
			Me.ButtonItemOrderType_NewOnly.Text = "New Orders Only"
			'
			'ButtonItemOrderType_NewAndRevised
			'
			Me.ButtonItemOrderType_NewAndRevised.AutoCheckOnClick = True
			Me.ButtonItemOrderType_NewAndRevised.BeginGroup = True
			Me.ButtonItemOrderType_NewAndRevised.Name = "ButtonItemOrderType_NewAndRevised"
			Me.ButtonItemOrderType_NewAndRevised.OptionGroup = "OrderType"
			Me.ButtonItemOrderType_NewAndRevised.SecurityEnabled = True
			Me.ButtonItemOrderType_NewAndRevised.SubItemsExpandWidth = 14
			Me.ButtonItemOrderType_NewAndRevised.Text = "New and Revised Orders"
			'
			'LabelForm_OrderDescription
			'
			Me.LabelForm_OrderDescription.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_OrderDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_OrderDescription.Location = New System.Drawing.Point(4, 7)
			Me.LabelForm_OrderDescription.Name = "LabelForm_OrderDescription"
			Me.LabelForm_OrderDescription.Size = New System.Drawing.Size(99, 20)
			Me.LabelForm_OrderDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_OrderDescription.TabIndex = 0
			Me.LabelForm_OrderDescription.Text = "Order Description:"
			'
			'TextBoxForm_OrderDescription
			'
			Me.TextBoxForm_OrderDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TextBoxForm_OrderDescription.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.TextBoxForm_OrderDescription.Border.Class = "TextBoxBorder"
			Me.TextBoxForm_OrderDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxForm_OrderDescription.CheckSpellingOnValidate = False
			Me.TextBoxForm_OrderDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxForm_OrderDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxForm_OrderDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxForm_OrderDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxForm_OrderDescription.FocusHighlightEnabled = True
			Me.TextBoxForm_OrderDescription.ForeColor = System.Drawing.Color.Black
			Me.TextBoxForm_OrderDescription.Location = New System.Drawing.Point(109, 6)
			Me.TextBoxForm_OrderDescription.MaxFileSize = CType(0, Long)
			Me.TextBoxForm_OrderDescription.Name = "TextBoxForm_OrderDescription"
			Me.TextBoxForm_OrderDescription.SecurityEnabled = True
			Me.TextBoxForm_OrderDescription.ShowSpellCheckCompleteMessage = True
			Me.TextBoxForm_OrderDescription.Size = New System.Drawing.Size(963, 21)
			Me.TextBoxForm_OrderDescription.StartingFolderName = Nothing
			Me.TextBoxForm_OrderDescription.TabIndex = 1
			Me.TextBoxForm_OrderDescription.TabOnEnter = True
			Me.TextBoxForm_OrderDescription.TabStop = False
			'
			'ImportCreateOrderDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1086, 494)
			Me.CloseButtonVisible = False
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Margin = New System.Windows.Forms.Padding(4)
			Me.Name = "ImportCreateOrderDialog"
			Me.Text = "Create Orders"
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
		Friend WithEvents DataGridViewForm_Orders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
		Friend WithEvents RibbonBarOptions_OrderTypes As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOrderType_NewOnly As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOrderType_NewAndRevised As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents LabelForm_OrderDescription As WinForm.Presentation.Controls.Label
		Friend WithEvents TextBoxForm_OrderDescription As WinForm.Presentation.Controls.TextBox
	End Class

End Namespace