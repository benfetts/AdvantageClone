Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetCopyDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_CDP = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFile_DataOptions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemDataOptions_CopySpots = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDataOptions_CopyRates = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFile_Options = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemOptions_UseLatestRevision = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_UseOriginalRevision = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_CDP)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(753, 369)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(753, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_DataOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_Options)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(753, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_DataOptions, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(94, 92)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 524)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(753, 18)
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
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(97, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(114, 92)
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
            'DataGridViewForm_CDP
            '
            Me.DataGridViewForm_CDP.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CDP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CDP.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CDP.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CDP.ItemDescription = "CDP(s)"
            Me.DataGridViewForm_CDP.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewForm_CDP.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_CDP.ModifyGridRowHeight = False
            Me.DataGridViewForm_CDP.MultiSelect = False
            Me.DataGridViewForm_CDP.Name = "DataGridViewForm_CDP"
            Me.DataGridViewForm_CDP.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CDP.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_CDP.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_CDP.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CDP.Size = New System.Drawing.Size(729, 357)
            Me.DataGridViewForm_CDP.TabIndex = 4
            Me.DataGridViewForm_CDP.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CDP.ViewCaptionHeight = -1
            '
            'RibbonBarFile_DataOptions
            '
            Me.RibbonBarFile_DataOptions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFile_DataOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_DataOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_DataOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_DataOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_DataOptions.DragDropSupport = True
            Me.RibbonBarFile_DataOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDataOptions_CopySpots, Me.ButtonItemDataOptions_CopyRates})
            Me.RibbonBarFile_DataOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_DataOptions.Location = New System.Drawing.Point(353, 0)
            Me.RibbonBarFile_DataOptions.Name = "RibbonBarFile_DataOptions"
            Me.RibbonBarFile_DataOptions.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarFile_DataOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_DataOptions.TabIndex = 3
            Me.RibbonBarFile_DataOptions.Text = "Data Options"
            '
            '
            '
            Me.RibbonBarFile_DataOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_DataOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemDataOptions_CopySpots
            '
            Me.ButtonItemDataOptions_CopySpots.AutoCheckOnClick = True
            Me.ButtonItemDataOptions_CopySpots.BeginGroup = True
            Me.ButtonItemDataOptions_CopySpots.Checked = True
            Me.ButtonItemDataOptions_CopySpots.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDataOptions_CopySpots.Name = "ButtonItemDataOptions_CopySpots"
            Me.ButtonItemDataOptions_CopySpots.RibbonWordWrap = False
            Me.ButtonItemDataOptions_CopySpots.SecurityEnabled = True
            Me.ButtonItemDataOptions_CopySpots.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_CopySpots.Text = "Copy Spots"
            '
            'ButtonItemDataOptions_CopyRates
            '
            Me.ButtonItemDataOptions_CopyRates.AutoCheckOnClick = True
            Me.ButtonItemDataOptions_CopyRates.BeginGroup = True
            Me.ButtonItemDataOptions_CopyRates.Checked = True
            Me.ButtonItemDataOptions_CopyRates.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemDataOptions_CopyRates.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDataOptions_CopyRates.Name = "ButtonItemDataOptions_CopyRates"
            Me.ButtonItemDataOptions_CopyRates.RibbonWordWrap = False
            Me.ButtonItemDataOptions_CopyRates.SecurityEnabled = True
            Me.ButtonItemDataOptions_CopyRates.SubItemsExpandWidth = 14
            Me.ButtonItemDataOptions_CopyRates.Text = "Copy Rates"
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
            Me.RibbonBarFile_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_UseLatestRevision, Me.ButtonItemOptions_UseOriginalRevision})
            Me.RibbonBarFile_Options.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarFile_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_Options.Location = New System.Drawing.Point(211, 0)
            Me.RibbonBarFile_Options.Name = "RibbonBarFile_Options"
            Me.RibbonBarFile_Options.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarFile_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_Options.TabIndex = 2
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
            'ButtonItemOptions_UseLatestRevision
            '
            Me.ButtonItemOptions_UseLatestRevision.AutoCheckOnClick = True
            Me.ButtonItemOptions_UseLatestRevision.BeginGroup = True
            Me.ButtonItemOptions_UseLatestRevision.Checked = True
            Me.ButtonItemOptions_UseLatestRevision.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_UseLatestRevision.Name = "ButtonItemOptions_UseLatestRevision"
            Me.ButtonItemOptions_UseLatestRevision.OptionGroup = "REV"
            Me.ButtonItemOptions_UseLatestRevision.RibbonWordWrap = False
            Me.ButtonItemOptions_UseLatestRevision.SecurityEnabled = True
            Me.ButtonItemOptions_UseLatestRevision.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_UseLatestRevision.Text = "Use Latest Revision"
            '
            'ButtonItemOptions_UseOriginalRevision
            '
            Me.ButtonItemOptions_UseOriginalRevision.AutoCheckOnClick = True
            Me.ButtonItemOptions_UseOriginalRevision.BeginGroup = True
            Me.ButtonItemOptions_UseOriginalRevision.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_UseOriginalRevision.Name = "ButtonItemOptions_UseOriginalRevision"
            Me.ButtonItemOptions_UseOriginalRevision.OptionGroup = "REV"
            Me.ButtonItemOptions_UseOriginalRevision.RibbonWordWrap = False
            Me.ButtonItemOptions_UseOriginalRevision.SecurityEnabled = True
            Me.ButtonItemOptions_UseOriginalRevision.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_UseOriginalRevision.Text = "Use Original Schedule"
            '
            'MediaBroadcastWorksheetCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(763, 544)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetCopyDialog"
            Me.Text = "Worksheet Copy"
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
        Friend WithEvents ButtonItemActions_Copy As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_CDP As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarFile_DataOptions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemDataOptions_CopySpots As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDataOptions_CopyRates As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFile_Options As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemOptions_UseLatestRevision As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_UseOriginalRevision As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace