Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ServiceEventLog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceEventLog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_RunService = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_View = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ServiceEvents = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_ServiceStatus = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_DownloadFiles = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_RadioPeriods = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_TVBooks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_TVCUMEBooks = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_View)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(981, 441)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(981, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 56)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(981, 98)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 96)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 596)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(981, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Refresh, Me.ButtonItemActions_RunService, Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(219, 96)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'ButtonItemActions_RunService
            '
            Me.ButtonItemActions_RunService.BeginGroup = True
            Me.ButtonItemActions_RunService.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_RunService.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_RunService.Name = "ButtonItemActions_RunService"
            Me.ButtonItemActions_RunService.RibbonWordWrap = False
            Me.ButtonItemActions_RunService.SecurityEnabled = True
            Me.ButtonItemActions_RunService.Stretch = True
            Me.ButtonItemActions_RunService.SubItemsExpandWidth = 14
            Me.ButtonItemActions_RunService.Text = "Run Service"
            '
            'DataGridViewForm_View
            '
            Me.DataGridViewForm_View.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_View.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_View.AutoUpdateViewCaption = True
            Me.DataGridViewForm_View.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_View.ItemDescription = ""
            Me.DataGridViewForm_View.Location = New System.Drawing.Point(3, 6)
            Me.DataGridViewForm_View.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_View.ModifyGridRowHeight = False
            Me.DataGridViewForm_View.MultiSelect = False
            Me.DataGridViewForm_View.Name = "DataGridViewForm_View"
            Me.DataGridViewForm_View.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_View.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_View.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_View.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_View.Size = New System.Drawing.Size(975, 429)
            Me.DataGridViewForm_View.TabIndex = 5
            Me.DataGridViewForm_View.UseEmbeddedNavigator = False
            Me.DataGridViewForm_View.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ServiceEvents, Me.ButtonItemView_ServiceStatus, Me.ButtonItemView_DownloadFiles, Me.ButtonItemView_RadioPeriods, Me.ButtonItemView_TVBooks, Me.ButtonItemView_TVCUMEBooks})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(322, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(491, 96)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 2
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemView_ServiceEvents
            '
            Me.ButtonItemView_ServiceEvents.AutoCheckOnClick = True
            Me.ButtonItemView_ServiceEvents.BeginGroup = True
            Me.ButtonItemView_ServiceEvents.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_ServiceEvents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ServiceEvents.Name = "ButtonItemView_ServiceEvents"
            Me.ButtonItemView_ServiceEvents.OptionGroup = "Views"
            Me.ButtonItemView_ServiceEvents.RibbonWordWrap = False
            Me.ButtonItemView_ServiceEvents.SecurityEnabled = True
            Me.ButtonItemView_ServiceEvents.Stretch = True
            Me.ButtonItemView_ServiceEvents.SubItemsExpandWidth = 14
            Me.ButtonItemView_ServiceEvents.Text = "Service Events"
            '
            'ButtonItemView_ServiceStatus
            '
            Me.ButtonItemView_ServiceStatus.AutoCheckOnClick = True
            Me.ButtonItemView_ServiceStatus.BeginGroup = True
            Me.ButtonItemView_ServiceStatus.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_ServiceStatus.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ServiceStatus.Name = "ButtonItemView_ServiceStatus"
            Me.ButtonItemView_ServiceStatus.OptionGroup = "Views"
            Me.ButtonItemView_ServiceStatus.RibbonWordWrap = False
            Me.ButtonItemView_ServiceStatus.SecurityEnabled = True
            Me.ButtonItemView_ServiceStatus.Stretch = True
            Me.ButtonItemView_ServiceStatus.SubItemsExpandWidth = 14
            Me.ButtonItemView_ServiceStatus.Text = "Service Status"
            '
            'ButtonItemView_DownloadFiles
            '
            Me.ButtonItemView_DownloadFiles.AutoCheckOnClick = True
            Me.ButtonItemView_DownloadFiles.BeginGroup = True
            Me.ButtonItemView_DownloadFiles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_DownloadFiles.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_DownloadFiles.Name = "ButtonItemView_DownloadFiles"
            Me.ButtonItemView_DownloadFiles.OptionGroup = "Views"
            Me.ButtonItemView_DownloadFiles.RibbonWordWrap = False
            Me.ButtonItemView_DownloadFiles.SecurityEnabled = True
            Me.ButtonItemView_DownloadFiles.Stretch = True
            Me.ButtonItemView_DownloadFiles.SubItemsExpandWidth = 14
            Me.ButtonItemView_DownloadFiles.Text = "Download Files"
            '
            'ButtonItemView_RadioPeriods
            '
            Me.ButtonItemView_RadioPeriods.AutoCheckOnClick = True
            Me.ButtonItemView_RadioPeriods.BeginGroup = True
            Me.ButtonItemView_RadioPeriods.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_RadioPeriods.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_RadioPeriods.Name = "ButtonItemView_RadioPeriods"
            Me.ButtonItemView_RadioPeriods.OptionGroup = "Views"
            Me.ButtonItemView_RadioPeriods.RibbonWordWrap = False
            Me.ButtonItemView_RadioPeriods.SecurityEnabled = True
            Me.ButtonItemView_RadioPeriods.Stretch = True
            Me.ButtonItemView_RadioPeriods.SubItemsExpandWidth = 14
            Me.ButtonItemView_RadioPeriods.Text = "Radio Periods"
            '
            'ButtonItemView_TVBooks
            '
            Me.ButtonItemView_TVBooks.AutoCheckOnClick = True
            Me.ButtonItemView_TVBooks.BeginGroup = True
            Me.ButtonItemView_TVBooks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_TVBooks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_TVBooks.Name = "ButtonItemView_TVBooks"
            Me.ButtonItemView_TVBooks.OptionGroup = "Views"
            Me.ButtonItemView_TVBooks.RibbonWordWrap = False
            Me.ButtonItemView_TVBooks.SecurityEnabled = True
            Me.ButtonItemView_TVBooks.Stretch = True
            Me.ButtonItemView_TVBooks.SubItemsExpandWidth = 14
            Me.ButtonItemView_TVBooks.Text = "TV Books"
            '
            'ButtonItemView_TVCUMEBooks
            '
            Me.ButtonItemView_TVCUMEBooks.AutoCheckOnClick = True
            Me.ButtonItemView_TVCUMEBooks.BeginGroup = True
            Me.ButtonItemView_TVCUMEBooks.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_TVCUMEBooks.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_TVCUMEBooks.Name = "ButtonItemView_TVCUMEBooks"
            Me.ButtonItemView_TVCUMEBooks.OptionGroup = "Views"
            Me.ButtonItemView_TVCUMEBooks.RibbonWordWrap = False
            Me.ButtonItemView_TVCUMEBooks.SecurityEnabled = True
            Me.ButtonItemView_TVCUMEBooks.Stretch = True
            Me.ButtonItemView_TVCUMEBooks.SubItemsExpandWidth = 14
            Me.ButtonItemView_TVCUMEBooks.Text = "TV CUME Books"
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ServiceEventLog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(991, 616)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServiceEventLog"
            Me.Text = "Service Event Log"
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

        Friend WithEvents DataGridViewForm_View As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ServiceEvents As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_DownloadFiles As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_RadioPeriods As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_TVBooks As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_TVCUMEBooks As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_ServiceStatus As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_RunService As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

