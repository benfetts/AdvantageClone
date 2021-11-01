Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTemplateDataEntryDialog
        Inherits WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTemplateDataEntryDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_PivotColumn = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPivotColumn_Swap = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PivotGridForm_DataEnty = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl()
            Me.RibbonBarOptions_Market = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarket_Include = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PivotGridForm_DataEnty, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.PivotGridForm_DataEnty)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1169, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1169, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Market)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PivotColumn)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1169, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PivotColumn, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Market, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
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
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
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
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1169, 18)
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(147, 92)
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
            'RibbonBarOptions_PivotColumn
            '
            Me.RibbonBarOptions_PivotColumn.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PivotColumn.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PivotColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PivotColumn.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PivotColumn.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PivotColumn.DragDropSupport = True
            Me.RibbonBarOptions_PivotColumn.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPivotColumn_Swap})
            Me.RibbonBarOptions_PivotColumn.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PivotColumn.Location = New System.Drawing.Point(202, 0)
            Me.RibbonBarOptions_PivotColumn.Name = "RibbonBarOptions_PivotColumn"
            Me.RibbonBarOptions_PivotColumn.SecurityEnabled = True
            Me.RibbonBarOptions_PivotColumn.Size = New System.Drawing.Size(60, 92)
            Me.RibbonBarOptions_PivotColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PivotColumn.TabIndex = 5
            Me.RibbonBarOptions_PivotColumn.Text = "Pivot"
            '
            '
            '
            Me.RibbonBarOptions_PivotColumn.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PivotColumn.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PivotColumn.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_PivotColumn.Visible = False
            '
            'ButtonItemPivotColumn_Swap
            '
            Me.ButtonItemPivotColumn_Swap.BeginGroup = True
            Me.ButtonItemPivotColumn_Swap.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPivotColumn_Swap.Name = "ButtonItemPivotColumn_Swap"
            Me.ButtonItemPivotColumn_Swap.RibbonWordWrap = False
            Me.ButtonItemPivotColumn_Swap.SecurityEnabled = True
            Me.ButtonItemPivotColumn_Swap.SubItemsExpandWidth = 14
            Me.ButtonItemPivotColumn_Swap.Text = "Swap"
            '
            'PivotGridForm_DataEnty
            '
            Me.PivotGridForm_DataEnty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PivotGridForm_DataEnty.Location = New System.Drawing.Point(12, 6)
            Me.PivotGridForm_DataEnty.Name = "PivotGridForm_DataEnty"
            Me.PivotGridForm_DataEnty.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
            Me.PivotGridForm_DataEnty.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Never
            Me.PivotGridForm_DataEnty.OptionsCustomization.FilterPanelVisible = DevExpress.XtraPivotGrid.FilterPanelVisible.Never
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintColumnAreaOnEveryPage = True
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.[False]
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintUnusedFilterFields = False
            Me.PivotGridForm_DataEnty.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.[True]
            Me.PivotGridForm_DataEnty.OptionsPrint.UsePrintAppearance = True
            Me.PivotGridForm_DataEnty.OptionsView.ShowColumnTotals = False
            Me.PivotGridForm_DataEnty.OptionsView.ShowFilterHeaders = False
            Me.PivotGridForm_DataEnty.OptionsView.ShowFilterSeparatorBar = False
            Me.PivotGridForm_DataEnty.OptionsView.ShowGrandTotalsForSingleValues = True
            Me.PivotGridForm_DataEnty.OptionsView.ShowRowGrandTotalHeader = False
            Me.PivotGridForm_DataEnty.OptionsView.ShowRowGrandTotals = False
            Me.PivotGridForm_DataEnty.OptionsView.ShowRowTotals = False
            Me.PivotGridForm_DataEnty.RetrieveFieldsOnLoadDataSource = True
            Me.PivotGridForm_DataEnty.Size = New System.Drawing.Size(1145, 543)
            Me.PivotGridForm_DataEnty.TabIndex = 18
            Me.PivotGridForm_DataEnty.WriteEditValueToAllDataSourceItems = True
            '
            'RibbonBarOptions_Market
            '
            Me.RibbonBarOptions_Market.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Market.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Market.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Market.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Market.DragDropSupport = True
            Me.RibbonBarOptions_Market.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarket_Include})
            Me.RibbonBarOptions_Market.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Market.Location = New System.Drawing.Point(262, 0)
            Me.RibbonBarOptions_Market.Name = "RibbonBarOptions_Market"
            Me.RibbonBarOptions_Market.SecurityEnabled = True
            Me.RibbonBarOptions_Market.Size = New System.Drawing.Size(60, 92)
            Me.RibbonBarOptions_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Market.TabIndex = 6
            Me.RibbonBarOptions_Market.Text = "Market"
            '
            '
            '
            Me.RibbonBarOptions_Market.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Market.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Market.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_Market.Visible = False
            '
            'ButtonItemMarket_Include
            '
            Me.ButtonItemMarket_Include.AutoCheckOnClick = True
            Me.ButtonItemMarket_Include.BeginGroup = True
            Me.ButtonItemMarket_Include.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarket_Include.Name = "ButtonItemMarket_Include"
            Me.ButtonItemMarket_Include.RibbonWordWrap = False
            Me.ButtonItemMarket_Include.SecurityEnabled = True
            Me.ButtonItemMarket_Include.SubItemsExpandWidth = 14
            Me.ButtonItemMarket_Include.Text = "Include"
            '
            'MediaTemplateDataEntryDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTemplateDataEntryDialog"
            Me.Text = ""
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PivotGridForm_DataEnty, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_PivotColumn As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents PivotGridForm_DataEnty As WinForm.Presentation.Controls.PivotGridControl
        Friend WithEvents ButtonItemPivotColumn_Swap As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Market As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMarket_Include As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
