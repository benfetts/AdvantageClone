Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketGoalDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketGoalDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CopyToAnotherMarket = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CopyFromAnotherMarket = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Goals = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGoals_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGoals_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGoals_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGoals_EnterByPercentage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.RibbonBarOptions_Markets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerMarkets_Markets = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemMarkets_Markets = New DevComponents.DotNetBar.ComboBoxItem()
            Me.DataGridViewForm_Goals = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFile_MediaPlan = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemMediaPlan_LoadGoals = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.NumericInputForm_TotalGRPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelForm_TotalGRPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_VarianceGRPs = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_VarianceBudget = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputForm_TotalBudget = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelForm_TotalBudget = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_TotalGRPs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_TotalBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_VarianceBudget)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_TotalBudget)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_TotalBudget)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_VarianceGRPs)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_TotalGRPs)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_TotalGRPs)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Goals)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            Me.PanelForm_Form.TabIndex = 0
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFile_MediaPlan)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Goals)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Markets)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Markets, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Goals, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFile_MediaPlan, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(89, 92)
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
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_CopyToAnotherMarket, Me.ButtonItemActions_CopyFromAnotherMarket})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(290, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(269, 92)
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
            'ButtonItemActions_CopyToAnotherMarket
            '
            Me.ButtonItemActions_CopyToAnotherMarket.BeginGroup = True
            Me.ButtonItemActions_CopyToAnotherMarket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CopyToAnotherMarket.Name = "ButtonItemActions_CopyToAnotherMarket"
            Me.ButtonItemActions_CopyToAnotherMarket.RibbonWordWrap = False
            Me.ButtonItemActions_CopyToAnotherMarket.SecurityEnabled = True
            Me.ButtonItemActions_CopyToAnotherMarket.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CopyToAnotherMarket.Text = "<span width=""12""></span>Copy To <br></br>Another Market"
            '
            'ButtonItemActions_CopyFromAnotherMarket
            '
            Me.ButtonItemActions_CopyFromAnotherMarket.BeginGroup = True
            Me.ButtonItemActions_CopyFromAnotherMarket.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CopyFromAnotherMarket.Name = "ButtonItemActions_CopyFromAnotherMarket"
            Me.ButtonItemActions_CopyFromAnotherMarket.RibbonWordWrap = False
            Me.ButtonItemActions_CopyFromAnotherMarket.SecurityEnabled = True
            Me.ButtonItemActions_CopyFromAnotherMarket.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CopyFromAnotherMarket.Text = "<span width=""9""></span>Copy From <br></br>Another Market"
            '
            'RibbonBarOptions_Goals
            '
            Me.RibbonBarOptions_Goals.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Goals.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Goals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Goals.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Goals.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Goals.DragDropSupport = True
            Me.RibbonBarOptions_Goals.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGoals_Add, Me.ButtonItemGoals_Delete, Me.ButtonItemGoals_Copy, Me.ButtonItemGoals_EnterByPercentage})
            Me.RibbonBarOptions_Goals.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Goals.Location = New System.Drawing.Point(559, 0)
            Me.RibbonBarOptions_Goals.Name = "RibbonBarOptions_Goals"
            Me.RibbonBarOptions_Goals.SecurityEnabled = True
            Me.RibbonBarOptions_Goals.Size = New System.Drawing.Size(175, 92)
            Me.RibbonBarOptions_Goals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Goals.TabIndex = 21
            Me.RibbonBarOptions_Goals.Text = "Goals"
            '
            '
            '
            Me.RibbonBarOptions_Goals.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Goals.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemGoals_Add
            '
            Me.ButtonItemGoals_Add.BeginGroup = True
            Me.ButtonItemGoals_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGoals_Add.Name = "ButtonItemGoals_Add"
            Me.ButtonItemGoals_Add.RibbonWordWrap = False
            Me.ButtonItemGoals_Add.SecurityEnabled = True
            Me.ButtonItemGoals_Add.SubItemsExpandWidth = 14
            Me.ButtonItemGoals_Add.Text = "Add"
            '
            'ButtonItemGoals_Delete
            '
            Me.ButtonItemGoals_Delete.BeginGroup = True
            Me.ButtonItemGoals_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGoals_Delete.Name = "ButtonItemGoals_Delete"
            Me.ButtonItemGoals_Delete.RibbonWordWrap = False
            Me.ButtonItemGoals_Delete.SecurityEnabled = True
            Me.ButtonItemGoals_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemGoals_Delete.Text = "Delete"
            '
            'ButtonItemGoals_Copy
            '
            Me.ButtonItemGoals_Copy.BeginGroup = True
            Me.ButtonItemGoals_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGoals_Copy.Name = "ButtonItemGoals_Copy"
            Me.ButtonItemGoals_Copy.RibbonWordWrap = False
            Me.ButtonItemGoals_Copy.SecurityEnabled = True
            Me.ButtonItemGoals_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemGoals_Copy.Text = "Copy"
            '
            'ButtonItemGoals_EnterByPercentage
            '
            Me.ButtonItemGoals_EnterByPercentage.AutoCheckOnClick = True
            Me.ButtonItemGoals_EnterByPercentage.BeginGroup = True
            Me.ButtonItemGoals_EnterByPercentage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGoals_EnterByPercentage.Name = "ButtonItemGoals_EnterByPercentage"
            Me.ButtonItemGoals_EnterByPercentage.RibbonWordWrap = False
            Me.ButtonItemGoals_EnterByPercentage.SecurityEnabled = True
            Me.ButtonItemGoals_EnterByPercentage.SubItemsExpandWidth = 14
            Me.ButtonItemGoals_EnterByPercentage.Text = "Enter By<br></br>Percentage"
            '
            'RibbonBarOptions_Markets
            '
            Me.RibbonBarOptions_Markets.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Markets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Markets.DragDropSupport = True
            Me.RibbonBarOptions_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerMarkets_Markets})
            Me.RibbonBarOptions_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Markets.Location = New System.Drawing.Point(92, 0)
            Me.RibbonBarOptions_Markets.Name = "RibbonBarOptions_Markets"
            Me.RibbonBarOptions_Markets.SecurityEnabled = True
            Me.RibbonBarOptions_Markets.Size = New System.Drawing.Size(198, 92)
            Me.RibbonBarOptions_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Markets.TabIndex = 25
            Me.RibbonBarOptions_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerMarkets_Markets
            '
            '
            '
            '
            Me.ItemContainerMarkets_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerMarkets_Markets.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerMarkets_Markets.MinimumSize = New System.Drawing.Size(151, 0)
            Me.ItemContainerMarkets_Markets.Name = "ItemContainerMarkets_Markets"
            Me.ItemContainerMarkets_Markets.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemMarkets_Markets})
            '
            '
            '
            Me.ItemContainerMarkets_Markets.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerMarkets_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemMarkets_Markets
            '
            Me.ComboBoxItemMarkets_Markets.ComboWidth = 185
            Me.ComboBoxItemMarkets_Markets.DropDownHeight = 106
            Me.ComboBoxItemMarkets_Markets.Name = "ComboBoxItemMarkets_Markets"
            Me.ComboBoxItemMarkets_Markets.Stretch = True
            '
            'DataGridViewForm_Goals
            '
            Me.DataGridViewForm_Goals.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Goals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Goals.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Goals.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Goals.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Goals.Location = New System.Drawing.Point(12, 58)
            Me.DataGridViewForm_Goals.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Goals.ModifyGridRowHeight = True
            Me.DataGridViewForm_Goals.MultiSelect = True
            Me.DataGridViewForm_Goals.Name = "DataGridViewForm_Goals"
            Me.DataGridViewForm_Goals.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Goals.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Goals.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Goals.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Goals.Size = New System.Drawing.Size(958, 491)
            Me.DataGridViewForm_Goals.TabIndex = 6
            Me.DataGridViewForm_Goals.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Goals.ViewCaptionHeight = -1
            '
            'RibbonBarFile_MediaPlan
            '
            Me.RibbonBarFile_MediaPlan.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFile_MediaPlan.ContainerControlProcessDialogKey = True
            Me.RibbonBarFile_MediaPlan.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFile_MediaPlan.DragDropSupport = True
            Me.RibbonBarFile_MediaPlan.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaPlan_LoadGoals})
            Me.RibbonBarFile_MediaPlan.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFile_MediaPlan.Location = New System.Drawing.Point(734, 0)
            Me.RibbonBarFile_MediaPlan.Name = "RibbonBarFile_MediaPlan"
            Me.RibbonBarFile_MediaPlan.Size = New System.Drawing.Size(92, 92)
            Me.RibbonBarFile_MediaPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFile_MediaPlan.TabIndex = 26
            Me.RibbonBarFile_MediaPlan.Text = "Media Plan"
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFile_MediaPlan.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemMediaPlan_LoadGoals
            '
            Me.ButtonItemMediaPlan_LoadGoals.BeginGroup = True
            Me.ButtonItemMediaPlan_LoadGoals.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaPlan_LoadGoals.Name = "ButtonItemMediaPlan_LoadGoals"
            Me.ButtonItemMediaPlan_LoadGoals.RibbonWordWrap = False
            Me.ButtonItemMediaPlan_LoadGoals.SecurityEnabled = True
            Me.ButtonItemMediaPlan_LoadGoals.SubItemsExpandWidth = 14
            Me.ButtonItemMediaPlan_LoadGoals.Text = "Load Goals"
            '
            'NumericInputForm_TotalGRPs
            '
            Me.NumericInputForm_TotalGRPs.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_TotalGRPs.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_TotalGRPs.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_TotalGRPs.EnterMoveNextControl = True
            Me.NumericInputForm_TotalGRPs.Location = New System.Drawing.Point(119, 6)
            Me.NumericInputForm_TotalGRPs.Name = "NumericInputForm_TotalGRPs"
            Me.NumericInputForm_TotalGRPs.Properties.AllowMouseWheel = False
            Me.NumericInputForm_TotalGRPs.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_TotalGRPs.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_TotalGRPs.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_TotalGRPs.Properties.DisplayFormat.FormatString = "f1"
            Me.NumericInputForm_TotalGRPs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalGRPs.Properties.EditFormat.FormatString = "f1"
            Me.NumericInputForm_TotalGRPs.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalGRPs.Properties.Mask.EditMask = "f1"
            Me.NumericInputForm_TotalGRPs.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_TotalGRPs.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputForm_TotalGRPs.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_TotalGRPs.SecurityEnabled = True
            Me.NumericInputForm_TotalGRPs.Size = New System.Drawing.Size(150, 20)
            Me.NumericInputForm_TotalGRPs.TabIndex = 1
            '
            'LabelForm_TotalGRPs
            '
            Me.LabelForm_TotalGRPs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalGRPs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalGRPs.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_TotalGRPs.Name = "LabelForm_TotalGRPs"
            Me.LabelForm_TotalGRPs.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_TotalGRPs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalGRPs.TabIndex = 0
            Me.LabelForm_TotalGRPs.Text = "Total GRPs:"
            '
            'LabelForm_VarianceGRPs
            '
            Me.LabelForm_VarianceGRPs.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VarianceGRPs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VarianceGRPs.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_VarianceGRPs.Name = "LabelForm_VarianceGRPs"
            Me.LabelForm_VarianceGRPs.Size = New System.Drawing.Size(257, 20)
            Me.LabelForm_VarianceGRPs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VarianceGRPs.TabIndex = 4
            Me.LabelForm_VarianceGRPs.Text = "Variance GRPs: {0}"
            '
            'LabelForm_VarianceBudget
            '
            Me.LabelForm_VarianceBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VarianceBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VarianceBudget.Location = New System.Drawing.Point(275, 32)
            Me.LabelForm_VarianceBudget.Name = "LabelForm_VarianceBudget"
            Me.LabelForm_VarianceBudget.Size = New System.Drawing.Size(257, 20)
            Me.LabelForm_VarianceBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VarianceBudget.TabIndex = 5
            Me.LabelForm_VarianceBudget.Text = "Variance Budget: {0}"
            '
            'NumericInputForm_TotalBudget
            '
            Me.NumericInputForm_TotalBudget.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_TotalBudget.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputForm_TotalBudget.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_TotalBudget.EnterMoveNextControl = True
            Me.NumericInputForm_TotalBudget.Location = New System.Drawing.Point(381, 6)
            Me.NumericInputForm_TotalBudget.Name = "NumericInputForm_TotalBudget"
            Me.NumericInputForm_TotalBudget.Properties.AllowMouseWheel = False
            Me.NumericInputForm_TotalBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_TotalBudget.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_TotalBudget.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_TotalBudget.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputForm_TotalBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalBudget.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputForm_TotalBudget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_TotalBudget.Properties.Mask.EditMask = "c2"
            Me.NumericInputForm_TotalBudget.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_TotalBudget.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputForm_TotalBudget.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_TotalBudget.SecurityEnabled = True
            Me.NumericInputForm_TotalBudget.Size = New System.Drawing.Size(150, 20)
            Me.NumericInputForm_TotalBudget.TabIndex = 3
            '
            'LabelForm_TotalBudget
            '
            Me.LabelForm_TotalBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TotalBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TotalBudget.Location = New System.Drawing.Point(275, 6)
            Me.LabelForm_TotalBudget.Name = "LabelForm_TotalBudget"
            Me.LabelForm_TotalBudget.Size = New System.Drawing.Size(100, 20)
            Me.LabelForm_TotalBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TotalBudget.TabIndex = 2
            Me.LabelForm_TotalBudget.Text = "Total Budget:"
            '
            'MediaBroadcastWorksheetMarketGoalDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketGoalDialog"
            Me.Text = "Media Broadcast Worksheet Market Goals"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_TotalGRPs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_TotalBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBarOptions_Goals As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGoals_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGoals_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents RibbonBarOptions_Markets As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ItemContainerMarkets_Markets As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ComboBoxItemMarkets_Markets As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents DataGridViewForm_Goals As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemGoals_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarFile_MediaPlan As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemMediaPlan_LoadGoals As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelForm_VarianceBudget As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_TotalBudget As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_TotalBudget As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_VarianceGRPs As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_TotalGRPs As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_TotalGRPs As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonItemGoals_EnterByPercentage As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_CopyToAnotherMarket As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_CopyFromAnotherMarket As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace