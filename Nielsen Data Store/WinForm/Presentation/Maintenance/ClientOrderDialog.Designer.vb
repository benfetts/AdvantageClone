Namespace WinForm.Presentation.Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientOrderDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientOrderDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_ClientOrders = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ClientOrderControlRightSection_Order = New NielsenDataStore.WinForm.Presentation.Controls.ClientOrderControl()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_SpotTV = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_Radio = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_RadioCounty = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Markets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarket_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMarket_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_States = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemState_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemState_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_RightSection)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_LeftSection)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1123, 551)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1123, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_States)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Markets)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 56)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1123, 98)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Markets, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_States, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 706)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1123, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(209, 96)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            Me.ButtonItemActions_Export.Visible = False
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_ClientOrders)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(312, 551)
            Me.PanelForm_LeftSection.TabIndex = 1
            '
            'DataGridViewLeftSection_ClientOrders
            '
            Me.DataGridViewLeftSection_ClientOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_ClientOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_ClientOrders.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_ClientOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_ClientOrders.ItemDescription = "Order(s)"
            Me.DataGridViewLeftSection_ClientOrders.Location = New System.Drawing.Point(12, 6)
            Me.DataGridViewLeftSection_ClientOrders.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_ClientOrders.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_ClientOrders.MultiSelect = False
            Me.DataGridViewLeftSection_ClientOrders.Name = "DataGridViewLeftSection_ClientOrders"
            Me.DataGridViewLeftSection_ClientOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_ClientOrders.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_ClientOrders.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_ClientOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_ClientOrders.Size = New System.Drawing.Size(294, 533)
            Me.DataGridViewLeftSection_ClientOrders.TabIndex = 1
            Me.DataGridViewLeftSection_ClientOrders.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_ClientOrders.ViewCaptionHeight = -1
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.ClientOrderControlRightSection_Order)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(312, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(811, 551)
            Me.PanelForm_RightSection.TabIndex = 3
            '
            'ClientOrderControlRightSection_Order
            '
            Me.ClientOrderControlRightSection_Order.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientOrderControlRightSection_Order.Location = New System.Drawing.Point(14, 6)
            Me.ClientOrderControlRightSection_Order.Name = "ClientOrderControlRightSection_Order"
            Me.ClientOrderControlRightSection_Order.Size = New System.Drawing.Size(785, 533)
            Me.ClientOrderControlRightSection_Order.TabIndex = 3
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_SpotTV, Me.ButtonItemView_Radio, Me.ButtonItemView_RadioCounty})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(312, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(247, 96)
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
            'ButtonItemView_SpotTV
            '
            Me.ButtonItemView_SpotTV.AutoCheckOnClick = True
            Me.ButtonItemView_SpotTV.BeginGroup = True
            Me.ButtonItemView_SpotTV.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_SpotTV.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_SpotTV.Name = "ButtonItemView_SpotTV"
            Me.ButtonItemView_SpotTV.OptionGroup = "View"
            Me.ButtonItemView_SpotTV.RibbonWordWrap = False
            Me.ButtonItemView_SpotTV.Stretch = True
            Me.ButtonItemView_SpotTV.SubItemsExpandWidth = 14
            Me.ButtonItemView_SpotTV.Text = "Spot TV"
            '
            'ButtonItemView_Radio
            '
            Me.ButtonItemView_Radio.AutoCheckOnClick = True
            Me.ButtonItemView_Radio.BeginGroup = True
            Me.ButtonItemView_Radio.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_Radio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Radio.Name = "ButtonItemView_Radio"
            Me.ButtonItemView_Radio.OptionGroup = "View"
            Me.ButtonItemView_Radio.RibbonWordWrap = False
            Me.ButtonItemView_Radio.Stretch = True
            Me.ButtonItemView_Radio.SubItemsExpandWidth = 14
            Me.ButtonItemView_Radio.Text = "Radio"
            '
            'ButtonItemView_RadioCounty
            '
            Me.ButtonItemView_RadioCounty.AutoCheckOnClick = True
            Me.ButtonItemView_RadioCounty.BeginGroup = True
            Me.ButtonItemView_RadioCounty.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_RadioCounty.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_RadioCounty.Name = "ButtonItemView_RadioCounty"
            Me.ButtonItemView_RadioCounty.OptionGroup = "View"
            Me.ButtonItemView_RadioCounty.RibbonWordWrap = False
            Me.ButtonItemView_RadioCounty.Stretch = True
            Me.ButtonItemView_RadioCounty.SubItemsExpandWidth = 14
            Me.ButtonItemView_RadioCounty.Text = "Radio County"
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
            Me.RibbonBarOptions_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarket_Delete, Me.ButtonItemMarket_Cancel})
            Me.RibbonBarOptions_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Markets.Location = New System.Drawing.Point(559, 0)
            Me.RibbonBarOptions_Markets.Name = "RibbonBarOptions_Markets"
            Me.RibbonBarOptions_Markets.SecurityEnabled = True
            Me.RibbonBarOptions_Markets.Size = New System.Drawing.Size(136, 96)
            Me.RibbonBarOptions_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Markets.TabIndex = 3
            Me.RibbonBarOptions_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMarket_Delete
            '
            Me.ButtonItemMarket_Delete.BeginGroup = True
            Me.ButtonItemMarket_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarket_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarket_Delete.Name = "ButtonItemMarket_Delete"
            Me.ButtonItemMarket_Delete.RibbonWordWrap = False
            Me.ButtonItemMarket_Delete.SecurityEnabled = True
            Me.ButtonItemMarket_Delete.Stretch = True
            Me.ButtonItemMarket_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemMarket_Delete.Text = "Delete"
            '
            'ButtonItemMarket_Cancel
            '
            Me.ButtonItemMarket_Cancel.BeginGroup = True
            Me.ButtonItemMarket_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarket_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarket_Cancel.Name = "ButtonItemMarket_Cancel"
            Me.ButtonItemMarket_Cancel.RibbonWordWrap = False
            Me.ButtonItemMarket_Cancel.SecurityEnabled = True
            Me.ButtonItemMarket_Cancel.Stretch = True
            Me.ButtonItemMarket_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemMarket_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_States
            '
            Me.RibbonBarOptions_States.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_States.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_States.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_States.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_States.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_States.DragDropSupport = True
            Me.RibbonBarOptions_States.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemState_Delete, Me.ButtonItemState_Cancel})
            Me.RibbonBarOptions_States.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_States.Location = New System.Drawing.Point(695, 0)
            Me.RibbonBarOptions_States.Name = "RibbonBarOptions_States"
            Me.RibbonBarOptions_States.SecurityEnabled = True
            Me.RibbonBarOptions_States.Size = New System.Drawing.Size(136, 96)
            Me.RibbonBarOptions_States.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_States.TabIndex = 4
            Me.RibbonBarOptions_States.Text = "States"
            '
            '
            '
            Me.RibbonBarOptions_States.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_States.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_States.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemState_Delete
            '
            Me.ButtonItemState_Delete.BeginGroup = True
            Me.ButtonItemState_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemState_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemState_Delete.Name = "ButtonItemState_Delete"
            Me.ButtonItemState_Delete.RibbonWordWrap = False
            Me.ButtonItemState_Delete.SecurityEnabled = True
            Me.ButtonItemState_Delete.Stretch = True
            Me.ButtonItemState_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemState_Delete.Text = "Delete"
            '
            'ButtonItemState_Cancel
            '
            Me.ButtonItemState_Cancel.BeginGroup = True
            Me.ButtonItemState_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemState_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemState_Cancel.Name = "ButtonItemState_Cancel"
            Me.ButtonItemState_Cancel.RibbonWordWrap = False
            Me.ButtonItemState_Cancel.SecurityEnabled = True
            Me.ButtonItemState_Cancel.Stretch = True
            Me.ButtonItemState_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemState_Cancel.Text = "Cancel"
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.WhiteSmoke
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.Empty
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(312, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 551)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.Stretch = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ClientOrderDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1133, 726)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientOrderDialog"
            Me.Text = "Client Order(s)"
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
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_ClientOrders As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ClientOrderControlRightSection_Order As Controls.ClientOrderControl
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_SpotTV As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemView_Radio As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Markets As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMarket_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMarket_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemView_RadioCounty As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_States As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemState_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemState_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

