Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog))
            Me.DataGridViewForm_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_Worksheet = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFile_Options = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemOptions_CopySpots = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_CopyRates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Worksheet)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Markets)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_Options)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_Options, 0)
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
            'DataGridViewForm_Markets
            '
            Me.DataGridViewForm_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Markets.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Markets.Location = New System.Drawing.Point(12, 233)
            Me.DataGridViewForm_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Markets.ModifyGridRowHeight = False
            Me.DataGridViewForm_Markets.MultiSelect = False
            Me.DataGridViewForm_Markets.Name = "DataGridViewForm_Markets"
            Me.DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Markets.Size = New System.Drawing.Size(958, 319)
            Me.DataGridViewForm_Markets.TabIndex = 19
            Me.DataGridViewForm_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Markets.ViewCaptionHeight = -1
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Copy, Me.ButtonItemActions_Cancel})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(114, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 3
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
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
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
            'DataGridViewForm_Worksheet
            '
            Me.DataGridViewForm_Worksheet.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Worksheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Worksheet.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Worksheet.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Worksheet.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Worksheet.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewForm_Worksheet.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Worksheet.ModifyGridRowHeight = False
            Me.DataGridViewForm_Worksheet.MultiSelect = False
            Me.DataGridViewForm_Worksheet.Name = "DataGridViewForm_Worksheet"
            Me.DataGridViewForm_Worksheet.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Worksheet.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Worksheet.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Worksheet.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Worksheet.Size = New System.Drawing.Size(958, 221)
            Me.DataGridViewForm_Worksheet.TabIndex = 20
            Me.DataGridViewForm_Worksheet.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Worksheet.ViewCaptionHeight = -1
            '
            'RibbonBarFile_Options
            '
            Me.RibbonBarFile_Options.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFile_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_Options.DragDropSupport = True
            Me.RibbonBarFile_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_CopySpots, Me.ButtonItemOptions_CopyRates})
            Me.RibbonBarFile_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_Options.Location = New System.Drawing.Point(217, 0)
            Me.RibbonBarFile_Options.Name = "RibbonBarFile_Options"
            Me.RibbonBarFile_Options.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarFile_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_Options.TabIndex = 4
            Me.RibbonBarFile_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarFile_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOptions_CopySpots
            '
            Me.ButtonItemOptions_CopySpots.AutoCheckOnClick = True
            Me.ButtonItemOptions_CopySpots.BeginGroup = True
            Me.ButtonItemOptions_CopySpots.Checked = True
            Me.ButtonItemOptions_CopySpots.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_CopySpots.Name = "ButtonItemOptions_CopySpots"
            Me.ButtonItemOptions_CopySpots.RibbonWordWrap = False
            Me.ButtonItemOptions_CopySpots.SecurityEnabled = True
            Me.ButtonItemOptions_CopySpots.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_CopySpots.Text = "Copy Spots"
            '
            'ButtonItemOptions_CopyRates
            '
            Me.ButtonItemOptions_CopyRates.AutoCheckOnClick = True
            Me.ButtonItemOptions_CopyRates.BeginGroup = True
            Me.ButtonItemOptions_CopyRates.Checked = True
            Me.ButtonItemOptions_CopyRates.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemOptions_CopyRates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_CopyRates.Name = "ButtonItemOptions_CopyRates"
            Me.ButtonItemOptions_CopyRates.RibbonWordWrap = False
            Me.ButtonItemOptions_CopyRates.SecurityEnabled = True
            Me.ButtonItemOptions_CopyRates.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_CopyRates.Text = "Copy Rates"
            '
            'MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDi" &
    "alog"
            Me.Text = "Market Schedule Copy Vendor Schedule To Another Market"
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

        Friend WithEvents DataGridViewForm_Markets As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemActions_Copy As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_Worksheet As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarFile_Options As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemOptions_CopySpots As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_CopyRates As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace