Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorComboRadioStationDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorComboRadioStationDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_AvailableVendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_AddAll = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Remove = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_RemoveAll = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewForm_SelectedVendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_SelectedVendors)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_RemoveAll)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Remove)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddAll)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_Add)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_AvailableVendors)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(868, 446)
            Me.PanelForm_Form.TabIndex = 1
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(868, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(868, 94)
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
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(868, 18)
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
            'DataGridViewForm_AvailableVendors
            '
            Me.DataGridViewForm_AvailableVendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableVendors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableVendors.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableVendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableVendors.ItemDescription = "Available Station(s)"
            Me.DataGridViewForm_AvailableVendors.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewForm_AvailableVendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_AvailableVendors.ModifyGridRowHeight = False
            Me.DataGridViewForm_AvailableVendors.MultiSelect = False
            Me.DataGridViewForm_AvailableVendors.Name = "DataGridViewForm_AvailableVendors"
            Me.DataGridViewForm_AvailableVendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableVendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_AvailableVendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_AvailableVendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableVendors.Size = New System.Drawing.Size(380, 434)
            Me.DataGridViewForm_AvailableVendors.TabIndex = 0
            Me.DataGridViewForm_AvailableVendors.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableVendors.ViewCaptionHeight = -1
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
            'DataGridViewForm_SelectedVendors
            '
            Me.DataGridViewForm_SelectedVendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_SelectedVendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_SelectedVendors.AutoUpdateViewCaption = True
            Me.DataGridViewForm_SelectedVendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_SelectedVendors.ItemDescription = "Selected Station(s)"
            Me.DataGridViewForm_SelectedVendors.Location = New System.Drawing.Point(479, 6)
            Me.DataGridViewForm_SelectedVendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_SelectedVendors.ModifyGridRowHeight = False
            Me.DataGridViewForm_SelectedVendors.MultiSelect = False
            Me.DataGridViewForm_SelectedVendors.Name = "DataGridViewForm_SelectedVendors"
            Me.DataGridViewForm_SelectedVendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_SelectedVendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_SelectedVendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_SelectedVendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_SelectedVendors.Size = New System.Drawing.Size(377, 434)
            Me.DataGridViewForm_SelectedVendors.TabIndex = 5
            Me.DataGridViewForm_SelectedVendors.UseEmbeddedNavigator = False
            Me.DataGridViewForm_SelectedVendors.ViewCaptionHeight = -1
            '
            'VendorComboRadioStationDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(878, 621)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VendorComboRadioStationDialog"
            Me.Text = "Combo Radio Stations"
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

        Friend WithEvents DataGridViewForm_AvailableVendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_SelectedVendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_RemoveAll As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Remove As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddAll As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace

