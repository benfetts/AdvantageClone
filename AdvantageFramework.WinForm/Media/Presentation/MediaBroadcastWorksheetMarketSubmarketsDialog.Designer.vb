Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketSubmarketsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketSubmarketsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_AvailableMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_AddAll = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Remove = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_RemoveAll = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewForm_SelectedMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFile_MarketGroups = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarketGroups_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonForm_MoveDown = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_MoveUp = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
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
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_MoveDown)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_MoveUp)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_SelectedMarkets)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_RemoveAll)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Remove)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddAll)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Add)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_AvailableMarkets)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(964, 446)
            Me.PanelForm_Form.TabIndex = 1
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(964, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_MarketGroups)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(964, 94)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_MarketGroups, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 601)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(964, 18)
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(106, 92)
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
            'DataGridViewForm_AvailableMarkets
            '
            Me.DataGridViewForm_AvailableMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableMarkets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableMarkets.ItemDescription = "Available Market(s)"
            Me.DataGridViewForm_AvailableMarkets.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewForm_AvailableMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_AvailableMarkets.ModifyGridRowHeight = False
            Me.DataGridViewForm_AvailableMarkets.MultiSelect = False
            Me.DataGridViewForm_AvailableMarkets.Name = "DataGridViewForm_AvailableMarkets"
            Me.DataGridViewForm_AvailableMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_AvailableMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_AvailableMarkets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableMarkets.Size = New System.Drawing.Size(380, 434)
            Me.DataGridViewForm_AvailableMarkets.TabIndex = 0
            Me.DataGridViewForm_AvailableMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableMarkets.ViewCaptionHeight = -1
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(398, 6)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 1
            Me.ButtonForm_Add.Text = ">"
            '
            'ButtonForm_AddAll
            '
            Me.ButtonForm_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddAll.Location = New System.Drawing.Point(398, 32)
            Me.ButtonForm_AddAll.Name = "ButtonForm_AddAll"
            Me.ButtonForm_AddAll.SecurityEnabled = True
            Me.ButtonForm_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddAll.TabIndex = 2
            Me.ButtonForm_AddAll.Text = ">>"
            '
            'ButtonForm_Remove
            '
            Me.ButtonForm_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Remove.Location = New System.Drawing.Point(398, 58)
            Me.ButtonForm_Remove.Name = "ButtonForm_Remove"
            Me.ButtonForm_Remove.SecurityEnabled = True
            Me.ButtonForm_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Remove.TabIndex = 3
            Me.ButtonForm_Remove.Text = "<"
            '
            'ButtonForm_RemoveAll
            '
            Me.ButtonForm_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveAll.Location = New System.Drawing.Point(398, 84)
            Me.ButtonForm_RemoveAll.Name = "ButtonForm_RemoveAll"
            Me.ButtonForm_RemoveAll.SecurityEnabled = True
            Me.ButtonForm_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveAll.TabIndex = 4
            Me.ButtonForm_RemoveAll.Text = "<<"
            '
            'DataGridViewForm_SelectedMarkets
            '
            Me.DataGridViewForm_SelectedMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_SelectedMarkets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_SelectedMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_SelectedMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_SelectedMarkets.ItemDescription = "Selected Market(s)"
            Me.DataGridViewForm_SelectedMarkets.Location = New System.Drawing.Point(479, 6)
            Me.DataGridViewForm_SelectedMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_SelectedMarkets.ModifyGridRowHeight = False
            Me.DataGridViewForm_SelectedMarkets.MultiSelect = False
            Me.DataGridViewForm_SelectedMarkets.Name = "DataGridViewForm_SelectedMarkets"
            Me.DataGridViewForm_SelectedMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_SelectedMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_SelectedMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_SelectedMarkets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_SelectedMarkets.Size = New System.Drawing.Size(392, 434)
            Me.DataGridViewForm_SelectedMarkets.TabIndex = 5
            Me.DataGridViewForm_SelectedMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_SelectedMarkets.ViewCaptionHeight = -1
            '
            'RibbonBarFile_MarketGroups
            '
            Me.RibbonBarFile_MarketGroups.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarFile_MarketGroups.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MarketGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_MarketGroups.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_MarketGroups.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_MarketGroups.DragDropSupport = True
            Me.RibbonBarFile_MarketGroups.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFile_MarketGroups.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarketGroups_Add})
            Me.RibbonBarFile_MarketGroups.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_MarketGroups.Location = New System.Drawing.Point(209, 0)
            Me.RibbonBarFile_MarketGroups.MinimumSize = New System.Drawing.Size(90, 0)
            Me.RibbonBarFile_MarketGroups.Name = "RibbonBarFile_MarketGroups"
            Me.RibbonBarFile_MarketGroups.SecurityEnabled = True
            Me.RibbonBarFile_MarketGroups.Size = New System.Drawing.Size(90, 92)
            Me.RibbonBarFile_MarketGroups.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_MarketGroups.TabIndex = 2
            Me.RibbonBarFile_MarketGroups.Text = "Market Groups"
            '
            '
            '
            Me.RibbonBarFile_MarketGroups.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MarketGroups.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemMarketGroups_Add
            '
            Me.ButtonItemMarketGroups_Add.BeginGroup = True
            Me.ButtonItemMarketGroups_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarketGroups_Add.Name = "ButtonItemMarketGroups_Add"
            Me.ButtonItemMarketGroups_Add.RibbonWordWrap = False
            Me.ButtonItemMarketGroups_Add.SecurityEnabled = True
            Me.ButtonItemMarketGroups_Add.SubItemsExpandWidth = 14
            Me.ButtonItemMarketGroups_Add.Text = "Add"
            '
            'ButtonForm_MoveDown
            '
            Me.ButtonForm_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveDown.Location = New System.Drawing.Point(877, 32)
            Me.ButtonForm_MoveDown.Name = "ButtonForm_MoveDown"
            Me.ButtonForm_MoveDown.SecurityEnabled = True
            Me.ButtonForm_MoveDown.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveDown.TabIndex = 7
            Me.ButtonForm_MoveDown.Text = "Move Down"
            '
            'ButtonForm_MoveUp
            '
            Me.ButtonForm_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveUp.Location = New System.Drawing.Point(877, 6)
            Me.ButtonForm_MoveUp.Name = "ButtonForm_MoveUp"
            Me.ButtonForm_MoveUp.SecurityEnabled = True
            Me.ButtonForm_MoveUp.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveUp.TabIndex = 6
            Me.ButtonForm_MoveUp.Text = "Move Up"
            '
            'MediaBroadcastWorksheetMarketSubmarketsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(974, 621)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketSubmarketsDialog"
            Me.Text = "Canadian Markets"
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents DataGridViewForm_AvailableMarkets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_SelectedMarkets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_RemoveAll As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Remove As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddAll As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonItemMarketGroups_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonForm_MoveDown As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveUp As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents RibbonBarFile_MarketGroups As WinForm.Presentation.Controls.RibbonBar
    End Class

End Namespace

