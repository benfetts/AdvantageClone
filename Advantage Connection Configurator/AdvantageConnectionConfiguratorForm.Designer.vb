<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdvantageConnectionConfiguratorForm
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

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
        Me.RibbonControlForm_Main = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanelOptionsTab_Options = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_Validate = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItemMain_OptionsTab = New DevComponents.DotNetBar.RibbonTabItem()
        Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.DataGridViewForm_ConnectionDatabaseProfiles = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.DefaultLookAndFeelOffice2010Blue = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.RibbonBarOptions_NTAuth = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemNTAuth_AutoEnable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.RibbonControlForm_Main.SuspendLayout()
        Me.RibbonPanelOptionsTab_Options.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControlForm_Main
        '
        Me.RibbonControlForm_Main.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonControlForm_Main.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControlForm_Main.CanCustomize = False
        Me.RibbonControlForm_Main.CaptionVisible = True
        Me.RibbonControlForm_Main.Controls.Add(Me.RibbonPanelOptionsTab_Options)
        Me.RibbonControlForm_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControlForm_Main.EnableQatPlacement = False
        Me.RibbonControlForm_Main.ForeColor = System.Drawing.Color.Black
        Me.RibbonControlForm_Main.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItemMain_OptionsTab})
        Me.RibbonControlForm_Main.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControlForm_Main.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControlForm_Main.Name = "RibbonControlForm_Main"
        Me.RibbonControlForm_Main.Size = New System.Drawing.Size(634, 154)
        Me.RibbonControlForm_Main.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControlForm_Main.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControlForm_Main.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControlForm_Main.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControlForm_Main.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControlForm_Main.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControlForm_Main.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControlForm_Main.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControlForm_Main.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControlForm_Main.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControlForm_Main.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControlForm_Main.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControlForm_Main.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControlForm_Main.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControlForm_Main.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControlForm_Main.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControlForm_Main.TabGroupHeight = 14
        Me.RibbonControlForm_Main.TabIndex = 0
        Me.RibbonControlForm_Main.UseCustomizeDialog = False
        '
        'RibbonPanelOptionsTab_Options
        '
        Me.RibbonPanelOptionsTab_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanelOptionsTab_Options.Controls.Add(Me.RibbonBarOptions_NTAuth)
        Me.RibbonPanelOptionsTab_Options.Controls.Add(Me.RibbonBarOptions_Actions)
        Me.RibbonPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 53)
        Me.RibbonPanelOptionsTab_Options.Name = "RibbonPanelOptionsTab_Options"
        Me.RibbonPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanelOptionsTab_Options.Size = New System.Drawing.Size(634, 101)
        '
        '
        '
        Me.RibbonPanelOptionsTab_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelOptionsTab_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelOptionsTab_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanelOptionsTab_Options.TabIndex = 1
        '
        'RibbonBarOptions_Actions
        '
        Me.RibbonBarOptions_Actions.AutoOverflowEnabled = True
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
        Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Validate})
        Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
        Me.RibbonBarOptions_Actions.SecurityEnabled = True
        Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(175, 99)
        Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarOptions_Actions.TabIndex = 0
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
        Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
        Me.ButtonItemActions_Save.Text = "Save"
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
        'ButtonItemActions_Cancel
        '
        Me.ButtonItemActions_Cancel.BeginGroup = True
        Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
        Me.ButtonItemActions_Cancel.RibbonWordWrap = False
        Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
        Me.ButtonItemActions_Cancel.Text = "Cancel"
        '
        'ButtonItemActions_Validate
        '
        Me.ButtonItemActions_Validate.BeginGroup = True
        Me.ButtonItemActions_Validate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemActions_Validate.Name = "ButtonItemActions_Validate"
        Me.ButtonItemActions_Validate.SubItemsExpandWidth = 14
        Me.ButtonItemActions_Validate.Text = "Validate"
        '
        'RibbonTabItemMain_OptionsTab
        '
        Me.RibbonTabItemMain_OptionsTab.Checked = True
        Me.RibbonTabItemMain_OptionsTab.Name = "RibbonTabItemMain_OptionsTab"
        Me.RibbonTabItemMain_OptionsTab.Panel = Me.RibbonPanelOptionsTab_Options
        Me.RibbonTabItemMain_OptionsTab.Text = "Options"
        '
        'StyleManager
        '
        Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'DataGridViewForm_ConnectionDatabaseProfiles
        '
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AddFixedColumnCheckItemsToGridMenu = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AllowDragAndDrop = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AllowExtraItemsInGridLookupEdits = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AllowSelectGroupHeaderRow = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AutoFilterLookupColumns = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AutoloadRepositoryDatasource = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.AutoUpdateViewCaption = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
        Me.DataGridViewForm_ConnectionDatabaseProfiles.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewForm_ConnectionDatabaseProfiles.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewForm_ConnectionDatabaseProfiles.ItemDescription = ""
        Me.DataGridViewForm_ConnectionDatabaseProfiles.Location = New System.Drawing.Point(17, 161)
        Me.DataGridViewForm_ConnectionDatabaseProfiles.MultiSelect = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.Name = "DataGridViewForm_ConnectionDatabaseProfiles"
        Me.DataGridViewForm_ConnectionDatabaseProfiles.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.DataGridViewForm_ConnectionDatabaseProfiles.RunStandardValidation = True
        Me.DataGridViewForm_ConnectionDatabaseProfiles.ShowColumnMenuOnRightClick = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.ShowSelectDeselectAllButtons = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.Size = New System.Drawing.Size(610, 221)
        Me.DataGridViewForm_ConnectionDatabaseProfiles.TabIndex = 1
        Me.DataGridViewForm_ConnectionDatabaseProfiles.UseEmbeddedNavigator = False
        Me.DataGridViewForm_ConnectionDatabaseProfiles.ViewCaptionHeight = -1
        '
        'DefaultLookAndFeelOffice2010Blue
        '
        Me.DefaultLookAndFeelOffice2010Blue.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'RibbonBarOptions_NTAuth
        '
        Me.RibbonBarOptions_NTAuth.AutoOverflowEnabled = False
        '
        '
        '
        Me.RibbonBarOptions_NTAuth.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarOptions_NTAuth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarOptions_NTAuth.ContainerControlProcessDialogKey = True
        Me.RibbonBarOptions_NTAuth.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarOptions_NTAuth.DragDropSupport = True
        Me.RibbonBarOptions_NTAuth.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarOptions_NTAuth.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemNTAuth_AutoEnable})
        Me.RibbonBarOptions_NTAuth.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarOptions_NTAuth.Location = New System.Drawing.Point(178, 0)
        Me.RibbonBarOptions_NTAuth.MinimumSize = New System.Drawing.Size(65, 0)
        Me.RibbonBarOptions_NTAuth.Name = "RibbonBarOptions_NTAuth"
        Me.RibbonBarOptions_NTAuth.SecurityEnabled = True
        Me.RibbonBarOptions_NTAuth.Size = New System.Drawing.Size(98, 99)
        Me.RibbonBarOptions_NTAuth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarOptions_NTAuth.TabIndex = 36
        Me.RibbonBarOptions_NTAuth.Text = "NT Auth"
        '
        '
        '
        Me.RibbonBarOptions_NTAuth.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarOptions_NTAuth.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ButtonItemNTAuth_AutoEnable
        '
        Me.ButtonItemNTAuth_AutoEnable.AutoCheckOnClick = True
        Me.ButtonItemNTAuth_AutoEnable.BeginGroup = True
        Me.ButtonItemNTAuth_AutoEnable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemNTAuth_AutoEnable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemNTAuth_AutoEnable.Name = "ButtonItemNTAuth_AutoEnable"
        Me.ButtonItemNTAuth_AutoEnable.RibbonWordWrap = False
        Me.ButtonItemNTAuth_AutoEnable.SecurityEnabled = True
        Me.ButtonItemNTAuth_AutoEnable.SubItemsExpandWidth = 14
        Me.ButtonItemNTAuth_AutoEnable.Text = "Auto Enable"
        Me.ButtonItemNTAuth_AutoEnable.Tooltip = "Auto Enable NT Auth"
        '
        'AdvantageConnectionConfiguratorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 420)
        Me.Controls.Add(Me.DataGridViewForm_ConnectionDatabaseProfiles)
        Me.Controls.Add(Me.RibbonControlForm_Main)
        Me.Name = "AdvantageConnectionConfiguratorForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advantage Connection Configurator"
        Me.RibbonControlForm_Main.ResumeLayout(False)
        Me.RibbonControlForm_Main.PerformLayout()
        Me.RibbonPanelOptionsTab_Options.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControlForm_Main As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanelOptionsTab_Options As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents RibbonTabItemMain_OptionsTab As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    Friend WithEvents DataGridViewForm_ConnectionDatabaseProfiles As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItemActions_Validate As DevComponents.DotNetBar.ButtonItem
    Protected WithEvents DefaultLookAndFeelOffice2010Blue As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBarOptions_NTAuth As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemNTAuth_AutoEnable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
End Class
