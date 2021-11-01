Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DigitalCampaignDetailDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DigitalCampaignDetailDialog))
            Dim XyDiagram4 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
            Dim Series7 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim Series8 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim LineSeriesView4 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
            Dim XyDiagram5 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
            Dim Series9 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim Series10 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim LineSeriesView5 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
            Dim XyDiagram6 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
            Dim Series11 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim Series12 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim LineSeriesView6 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
            Me.DataGridViewForm_EstimateDetail = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemExport_Grid = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_Images = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Actualize = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ActualizeNoRollFoward = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollFowardAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollFowardNext = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ActualizeRollForwardPercent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ReviseOrders = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_FunctionGrid = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemGrid_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemGrid_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_Flight = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemView_Periods = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemChartView_Impressions = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemChartView_Clicks = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemChartView_Units = New DevComponents.DotNetBar.ButtonItem()
            Me.GaugeControlForm_RevenueGoal = New DevExpress.XtraGauges.Win.GaugeControl()
            Me.CircularGauge_RevenueGoal = New DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge()
            Me.LabelComponent1 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent2 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent9 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.ArcScaleRangeBarComponent1 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent()
            Me.ArcScaleComponent1 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent()
            Me.LabelForm_Buyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Buyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_EstimateNumberAndName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Estimate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Campaign = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_Campaign = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.ExpandablePanelControl_HeaderInfo = New DevComponents.DotNetBar.ExpandablePanel()
            Me.TabControlHeader_Visuals = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGaugesTab_Gauges = New DevComponents.DotNetBar.TabControlPanel()
            Me.GaugeControlForm_ImpressionsGoal = New DevExpress.XtraGauges.Win.GaugeControl()
            Me.CircularGauge_ImpressionsGauge = New DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge()
            Me.LabelComponent5 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent6 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent7 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.ArcScaleRangeBarComponent3 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent()
            Me.ArcScaleComponent3 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent()
            Me.LabelGauges_VerticalLine2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelGauges_VerticalLine1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GaugeControlForm_SpendGoal = New DevExpress.XtraGauges.Win.GaugeControl()
            Me.CircularGauge_SpendGoal = New DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge()
            Me.LabelComponent3 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent4 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.LabelComponent8 = New DevExpress.XtraGauges.Win.Base.LabelComponent()
            Me.ArcScaleRangeBarComponent2 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent()
            Me.ArcScaleComponent2 = New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent()
            Me.TabItemVisuals_Gauges = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelChartsTab_Charts = New DevComponents.DotNetBar.TabControlPanel()
            Me.ChartControlCharts_Impressions = New DevExpress.XtraCharts.ChartControl()
            Me.DigitalEstimateDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ChartControlCharts_Spend = New DevExpress.XtraCharts.ChartControl()
            Me.ChartControlCharts_Revenue = New DevExpress.XtraCharts.ChartControl()
            Me.TabItemVisuals_Charts = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_BottomSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.FolderBrowserDialogExport = New System.Windows.Forms.FolderBrowserDialog()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CircularGauge_RevenueGoal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleRangeBarComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ExpandablePanelControl_HeaderInfo.SuspendLayout()
            CType(Me.TabControlHeader_Visuals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlHeader_Visuals.SuspendLayout()
            Me.TabControlPanelGaugesTab_Gauges.SuspendLayout()
            CType(Me.CircularGauge_ImpressionsGauge, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleRangeBarComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CircularGauge_SpendGoal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LabelComponent8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleRangeBarComponent2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ArcScaleComponent2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelChartsTab_Charts.SuspendLayout()
            CType(Me.ChartControlCharts_Impressions, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(XyDiagram4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(LineSeriesView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DigitalEstimateDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartControlCharts_Spend, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(XyDiagram5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(LineSeriesView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartControlCharts_Revenue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(XyDiagram6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series12, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(LineSeriesView6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_BottomSection.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_BottomSection)
            Me.PanelForm_Form.Controls.Add(Me.ExpandablePanelControl_HeaderInfo)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1011, 489)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1011, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_FunctionGrid)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1011, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_FunctionGrid, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(55, 92)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 644)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1011, 18)
            '
            'DataGridViewForm_EstimateDetail
            '
            Me.DataGridViewForm_EstimateDetail.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_EstimateDetail.AutoUpdateViewCaption = False
            Me.DataGridViewForm_EstimateDetail.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_EstimateDetail.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_EstimateDetail.ItemDescription = "Estimate Detail(s)"
            Me.DataGridViewForm_EstimateDetail.Location = New System.Drawing.Point(2, 2)
            Me.DataGridViewForm_EstimateDetail.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_EstimateDetail.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_EstimateDetail.ModifyGridRowHeight = False
            Me.DataGridViewForm_EstimateDetail.MultiSelect = True
            Me.DataGridViewForm_EstimateDetail.Name = "DataGridViewForm_EstimateDetail"
            Me.DataGridViewForm_EstimateDetail.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_EstimateDetail.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_EstimateDetail.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_EstimateDetail.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_EstimateDetail.Size = New System.Drawing.Size(1007, 177)
            Me.DataGridViewForm_EstimateDetail.TabIndex = 5
            Me.DataGridViewForm_EstimateDetail.UseEmbeddedNavigator = False
            Me.DataGridViewForm_EstimateDetail.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Refresh, Me.ButtonItemActions_Actualize, Me.ButtonItemActions_ReviseOrders})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(58, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(286, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 19
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_Grid, Me.ButtonItemExport_Images})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemExport_Grid
            '
            Me.ButtonItemExport_Grid.Name = "ButtonItemExport_Grid"
            Me.ButtonItemExport_Grid.Text = "Grid"
            '
            'ButtonItemExport_Images
            '
            Me.ButtonItemExport_Images.Name = "ButtonItemExport_Images"
            Me.ButtonItemExport_Images.Text = "Images"
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
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            Me.ButtonItemActions_Refresh.Visible = False
            '
            'ButtonItemActions_Actualize
            '
            Me.ButtonItemActions_Actualize.AutoExpandOnClick = True
            Me.ButtonItemActions_Actualize.BeginGroup = True
            Me.ButtonItemActions_Actualize.ImageFixedSize = New System.Drawing.Size(32, 32)
            Me.ButtonItemActions_Actualize.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Actualize.Name = "ButtonItemActions_Actualize"
            Me.ButtonItemActions_Actualize.RibbonWordWrap = False
            Me.ButtonItemActions_Actualize.SecurityEnabled = True
            Me.ButtonItemActions_Actualize.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ActualizeNoRollFoward, Me.ButtonItemActions_ActualizeRollFowardAll, Me.ButtonItemActions_ActualizeRollFowardNext, Me.ButtonItemActions_ActualizeRollForwardPercent})
            Me.ButtonItemActions_Actualize.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Actualize.Text = "Actualize"
            '
            'ButtonItemActions_ActualizeNoRollFoward
            '
            Me.ButtonItemActions_ActualizeNoRollFoward.Name = "ButtonItemActions_ActualizeNoRollFoward"
            Me.ButtonItemActions_ActualizeNoRollFoward.Text = "No Roll Foward"
            '
            'ButtonItemActions_ActualizeRollFowardAll
            '
            Me.ButtonItemActions_ActualizeRollFowardAll.Name = "ButtonItemActions_ActualizeRollFowardAll"
            Me.ButtonItemActions_ActualizeRollFowardAll.Text = "Roll Forward All"
            '
            'ButtonItemActions_ActualizeRollFowardNext
            '
            Me.ButtonItemActions_ActualizeRollFowardNext.Name = "ButtonItemActions_ActualizeRollFowardNext"
            Me.ButtonItemActions_ActualizeRollFowardNext.Text = "Roll Forward Next"
            '
            'ButtonItemActions_ActualizeRollForwardPercent
            '
            Me.ButtonItemActions_ActualizeRollForwardPercent.Name = "ButtonItemActions_ActualizeRollForwardPercent"
            Me.ButtonItemActions_ActualizeRollForwardPercent.Text = "Roll Forward Percent"
            '
            'ButtonItemActions_ReviseOrders
            '
            Me.ButtonItemActions_ReviseOrders.BeginGroup = True
            Me.ButtonItemActions_ReviseOrders.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ReviseOrders.Name = "ButtonItemActions_ReviseOrders"
            Me.ButtonItemActions_ReviseOrders.RibbonWordWrap = False
            Me.ButtonItemActions_ReviseOrders.SecurityEnabled = True
            Me.ButtonItemActions_ReviseOrders.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ReviseOrders.Text = "Revise Orders"
            '
            'RibbonBarOptions_FunctionGrid
            '
            Me.RibbonBarOptions_FunctionGrid.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_FunctionGrid.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_FunctionGrid.DragDropSupport = True
            Me.RibbonBarOptions_FunctionGrid.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemGrid_ChooseColumns, Me.ButtonItemGrid_RestoreDefaults})
            Me.RibbonBarOptions_FunctionGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_FunctionGrid.Location = New System.Drawing.Point(523, 0)
            Me.RibbonBarOptions_FunctionGrid.Name = "RibbonBarOptions_FunctionGrid"
            Me.RibbonBarOptions_FunctionGrid.SecurityEnabled = True
            Me.RibbonBarOptions_FunctionGrid.Size = New System.Drawing.Size(201, 92)
            Me.RibbonBarOptions_FunctionGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_FunctionGrid.TabIndex = 20
            Me.RibbonBarOptions_FunctionGrid.Text = "Grid Options"
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemGrid_ChooseColumns
            '
            Me.ButtonItemGrid_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemGrid_ChooseColumns.BeginGroup = True
            Me.ButtonItemGrid_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_ChooseColumns.Name = "ButtonItemGrid_ChooseColumns"
            Me.ButtonItemGrid_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemGrid_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemGrid_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemGrid_RestoreDefaults
            '
            Me.ButtonItemGrid_RestoreDefaults.BeginGroup = True
            Me.ButtonItemGrid_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemGrid_RestoreDefaults.Name = "ButtonItemGrid_RestoreDefaults"
            Me.ButtonItemGrid_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemGrid_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemGrid_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemGrid_RestoreDefaults.Text = "Restore Defaults"
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
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Flight, Me.ButtonItemView_Periods, Me.ItemContainer1})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(344, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(179, 92)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 40
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemView_Flight
            '
            Me.ButtonItemView_Flight.AutoCheckOnClick = True
            Me.ButtonItemView_Flight.BeginGroup = True
            Me.ButtonItemView_Flight.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Flight.Name = "ButtonItemView_Flight"
            Me.ButtonItemView_Flight.OptionGroup = "View"
            Me.ButtonItemView_Flight.RibbonWordWrap = False
            Me.ButtonItemView_Flight.SecurityEnabled = True
            Me.ButtonItemView_Flight.SubItemsExpandWidth = 14
            Me.ButtonItemView_Flight.Text = "Flight"
            '
            'ButtonItemView_Periods
            '
            Me.ButtonItemView_Periods.AutoCheckOnClick = True
            Me.ButtonItemView_Periods.BeginGroup = True
            Me.ButtonItemView_Periods.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Periods.Name = "ButtonItemView_Periods"
            Me.ButtonItemView_Periods.OptionGroup = "View"
            Me.ButtonItemView_Periods.RibbonWordWrap = False
            Me.ButtonItemView_Periods.SecurityEnabled = True
            Me.ButtonItemView_Periods.SubItemsExpandWidth = 14
            Me.ButtonItemView_Periods.Text = "Periods"
            '
            'ItemContainer1
            '
            '
            '
            '
            Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainer1.BeginGroup = True
            Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainer1.Name = "ItemContainer1"
            Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemChartView_Impressions, Me.ButtonItemChartView_Clicks, Me.ButtonItemChartView_Units})
            '
            '
            '
            Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemChartView_Impressions
            '
            Me.ButtonItemChartView_Impressions.AutoCheckOnClick = True
            Me.ButtonItemChartView_Impressions.Name = "ButtonItemChartView_Impressions"
            Me.ButtonItemChartView_Impressions.Text = "Impressions"
            '
            'ButtonItemChartView_Clicks
            '
            Me.ButtonItemChartView_Clicks.AutoCheckOnClick = True
            Me.ButtonItemChartView_Clicks.Name = "ButtonItemChartView_Clicks"
            Me.ButtonItemChartView_Clicks.Text = "Clicks"
            '
            'ButtonItemChartView_Units
            '
            Me.ButtonItemChartView_Units.AutoCheckOnClick = True
            Me.ButtonItemChartView_Units.Name = "ButtonItemChartView_Units"
            Me.ButtonItemChartView_Units.Text = "Units"
            '
            'GaugeControlForm_RevenueGoal
            '
            Me.GaugeControlForm_RevenueGoal.AutoLayout = False
            Me.GaugeControlForm_RevenueGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.GaugeControlForm_RevenueGoal.ColorScheme.TargetElements = CType((DevExpress.XtraGauges.Core.Base.TargetElement.RangeBar Or DevExpress.XtraGauges.Core.Base.TargetElement.Label), DevExpress.XtraGauges.Core.Base.TargetElement)
            Me.GaugeControlForm_RevenueGoal.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.CircularGauge_RevenueGoal})
            Me.GaugeControlForm_RevenueGoal.Location = New System.Drawing.Point(675, 4)
            Me.GaugeControlForm_RevenueGoal.Name = "GaugeControlForm_RevenueGoal"
            Me.GaugeControlForm_RevenueGoal.Size = New System.Drawing.Size(325, 211)
            Me.GaugeControlForm_RevenueGoal.TabIndex = 6
            '
            'CircularGauge_RevenueGoal
            '
            Me.CircularGauge_RevenueGoal.Bounds = New System.Drawing.Rectangle(1, 1, 324, 210)
            Me.CircularGauge_RevenueGoal.Labels.AddRange(New DevExpress.XtraGauges.Win.Base.LabelComponent() {Me.LabelComponent1, Me.LabelComponent2, Me.LabelComponent9})
            Me.CircularGauge_RevenueGoal.Name = "CircularGauge_RevenueGoal"
            Me.CircularGauge_RevenueGoal.RangeBars.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent() {Me.ArcScaleRangeBarComponent1})
            Me.CircularGauge_RevenueGoal.Scales.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent() {Me.ArcScaleComponent1})
            '
            'LabelComponent1
            '
            Me.LabelComponent1.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent1.Name = "circularGauge1_Label1"
            Me.LabelComponent1.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 100.0!)
            Me.LabelComponent1.Size = New System.Drawing.SizeF(100.0!, 30.0!)
            Me.LabelComponent1.Text = "0"
            Me.LabelComponent1.ZOrder = -1001
            '
            'LabelComponent2
            '
            Me.LabelComponent2.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent2.AppearanceText.Format = New DevExpress.XtraGauges.Core.Drawing.StringFormatObject(System.Drawing.StringAlignment.Center, System.Drawing.StringAlignment.Near, System.Drawing.StringTrimming.Character, System.Drawing.StringFormatFlags.NoClip)
            Me.LabelComponent2.Name = "circularGauge1_Label2"
            Me.LabelComponent2.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 150.0!)
            Me.LabelComponent2.Size = New System.Drawing.SizeF(140.0!, 60.0!)
            Me.LabelComponent2.Text = "0 of 0"
            Me.LabelComponent2.ZOrder = -1001
            '
            'LabelComponent9
            '
            Me.LabelComponent9.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelComponent9.AppearanceText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black")
            Me.LabelComponent9.Name = "CircularGauge_RevenueGoal_Label3"
            Me.LabelComponent9.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 70.0!)
            Me.LabelComponent9.Text = "REVENUE"
            Me.LabelComponent9.ZOrder = -1001
            '
            'ArcScaleRangeBarComponent1
            '
            Me.ArcScaleRangeBarComponent1.ArcScale = Me.ArcScaleComponent1
            Me.ArcScaleRangeBarComponent1.Name = "circularGauge1_RangeBar2"
            Me.ArcScaleRangeBarComponent1.RoundedCaps = True
            Me.ArcScaleRangeBarComponent1.ShowBackground = True
            Me.ArcScaleRangeBarComponent1.StartOffset = 80.0!
            Me.ArcScaleRangeBarComponent1.ZOrder = -10
            '
            'ArcScaleComponent1
            '
            Me.ArcScaleComponent1.AppearanceMajorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent1.AppearanceMajorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent1.AppearanceMinorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent1.AppearanceMinorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent1.AppearanceTickmarkText.Font = New System.Drawing.Font("Tahoma", 8.5!)
            Me.ArcScaleComponent1.AppearanceTickmarkText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A")
            Me.ArcScaleComponent1.Center = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 125.0!)
            Me.ArcScaleComponent1.EndAngle = 60.0!
            Me.ArcScaleComponent1.MajorTickCount = 0
            Me.ArcScaleComponent1.MajorTickmark.FormatString = "{0:F0}"
            Me.ArcScaleComponent1.MajorTickmark.ShapeOffset = -14.0!
            Me.ArcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1
            Me.ArcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight
            Me.ArcScaleComponent1.MaxValue = 100.0!
            Me.ArcScaleComponent1.MinorTickCount = 0
            Me.ArcScaleComponent1.MinorTickmark.ShapeOffset = -7.0!
            Me.ArcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2
            Me.ArcScaleComponent1.Name = "scale1"
            Me.ArcScaleComponent1.StartAngle = -240.0!
            '
            'LabelForm_Buyer
            '
            Me.LabelForm_Buyer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Buyer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Buyer.Location = New System.Drawing.Point(345, 32)
            Me.LabelForm_Buyer.Name = "LabelForm_Buyer"
            Me.LabelForm_Buyer.Size = New System.Drawing.Size(37, 20)
            Me.LabelForm_Buyer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Buyer.TabIndex = 9
            Me.LabelForm_Buyer.Text = "Buyer:"
            '
            'TextBoxForm_Buyer
            '
            Me.TextBoxForm_Buyer.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxForm_Buyer.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Buyer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Buyer.CheckSpellingOnValidate = False
            Me.TextBoxForm_Buyer.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Buyer.DisplayName = ""
            Me.TextBoxForm_Buyer.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Buyer.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Buyer.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Buyer.FocusHighlightEnabled = True
            Me.TextBoxForm_Buyer.Location = New System.Drawing.Point(388, 32)
            Me.TextBoxForm_Buyer.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Buyer.Name = "TextBoxForm_Buyer"
            Me.TextBoxForm_Buyer.PreventEnterBeep = True
            Me.TextBoxForm_Buyer.ReadOnly = True
            Me.TextBoxForm_Buyer.SecurityEnabled = True
            Me.TextBoxForm_Buyer.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Buyer.Size = New System.Drawing.Size(228, 21)
            Me.TextBoxForm_Buyer.StartingFolderName = Nothing
            Me.TextBoxForm_Buyer.TabIndex = 10
            Me.TextBoxForm_Buyer.TabOnEnter = True
            Me.TextBoxForm_Buyer.TabStop = False
            '
            'LabelForm_EstimateNumberAndName
            '
            Me.LabelForm_EstimateNumberAndName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EstimateNumberAndName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EstimateNumberAndName.Location = New System.Drawing.Point(12, 32)
            Me.LabelForm_EstimateNumberAndName.Name = "LabelForm_EstimateNumberAndName"
            Me.LabelForm_EstimateNumberAndName.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_EstimateNumberAndName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EstimateNumberAndName.TabIndex = 11
            Me.LabelForm_EstimateNumberAndName.Text = "Estimate:"
            '
            'TextBoxForm_Estimate
            '
            Me.TextBoxForm_Estimate.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxForm_Estimate.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Estimate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Estimate.CheckSpellingOnValidate = False
            Me.TextBoxForm_Estimate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Estimate.DisplayName = ""
            Me.TextBoxForm_Estimate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Estimate.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Estimate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Estimate.FocusHighlightEnabled = True
            Me.TextBoxForm_Estimate.Location = New System.Drawing.Point(73, 32)
            Me.TextBoxForm_Estimate.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Estimate.Name = "TextBoxForm_Estimate"
            Me.TextBoxForm_Estimate.PreventEnterBeep = True
            Me.TextBoxForm_Estimate.ReadOnly = True
            Me.TextBoxForm_Estimate.SecurityEnabled = True
            Me.TextBoxForm_Estimate.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Estimate.Size = New System.Drawing.Size(266, 21)
            Me.TextBoxForm_Estimate.StartingFolderName = Nothing
            Me.TextBoxForm_Estimate.TabIndex = 12
            Me.TextBoxForm_Estimate.TabOnEnter = True
            Me.TextBoxForm_Estimate.TabStop = False
            '
            'LabelForm_Campaign
            '
            Me.LabelForm_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Campaign.Location = New System.Drawing.Point(622, 32)
            Me.LabelForm_Campaign.Name = "LabelForm_Campaign"
            Me.LabelForm_Campaign.Size = New System.Drawing.Size(57, 20)
            Me.LabelForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Campaign.TabIndex = 15
            Me.LabelForm_Campaign.Text = "Campaign:"
            '
            'TextBoxForm_Campaign
            '
            Me.TextBoxForm_Campaign.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxForm_Campaign.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Campaign.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Campaign.CheckSpellingOnValidate = False
            Me.TextBoxForm_Campaign.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Campaign.DisplayName = ""
            Me.TextBoxForm_Campaign.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Campaign.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Campaign.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Campaign.FocusHighlightEnabled = True
            Me.TextBoxForm_Campaign.Location = New System.Drawing.Point(685, 32)
            Me.TextBoxForm_Campaign.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Campaign.Name = "TextBoxForm_Campaign"
            Me.TextBoxForm_Campaign.PreventEnterBeep = True
            Me.TextBoxForm_Campaign.ReadOnly = True
            Me.TextBoxForm_Campaign.SecurityEnabled = True
            Me.TextBoxForm_Campaign.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Campaign.Size = New System.Drawing.Size(228, 21)
            Me.TextBoxForm_Campaign.StartingFolderName = Nothing
            Me.TextBoxForm_Campaign.TabIndex = 16
            Me.TextBoxForm_Campaign.TabOnEnter = True
            Me.TextBoxForm_Campaign.TabStop = False
            '
            'ExpandablePanelControl_HeaderInfo
            '
            Me.ExpandablePanelControl_HeaderInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_HeaderInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxForm_Estimate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelForm_EstimateNumberAndName)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TabControlHeader_Visuals)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelForm_Buyer)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxForm_Campaign)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxForm_Buyer)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelForm_Campaign)
            Me.ExpandablePanelControl_HeaderInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelControl_HeaderInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandablePanelControl_HeaderInfo.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelControl_HeaderInfo.Name = "ExpandablePanelControl_HeaderInfo"
            Me.ExpandablePanelControl_HeaderInfo.Size = New System.Drawing.Size(1011, 308)
            Me.ExpandablePanelControl_HeaderInfo.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_HeaderInfo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_HeaderInfo.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_HeaderInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_HeaderInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_HeaderInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_HeaderInfo.Style.GradientAngle = 90
            Me.ExpandablePanelControl_HeaderInfo.TabIndex = 20
            Me.ExpandablePanelControl_HeaderInfo.TextDockConstrained = False
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_HeaderInfo.TitleText = "Digital Campaign Tracker"
            '
            'TabControlHeader_Visuals
            '
            Me.TabControlHeader_Visuals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlHeader_Visuals.BackColor = System.Drawing.Color.White
            Me.TabControlHeader_Visuals.CanReorderTabs = False
            Me.TabControlHeader_Visuals.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlHeader_Visuals.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlHeader_Visuals.Controls.Add(Me.TabControlPanelGaugesTab_Gauges)
            Me.TabControlHeader_Visuals.Controls.Add(Me.TabControlPanelChartsTab_Charts)
            Me.TabControlHeader_Visuals.ForeColor = System.Drawing.Color.Black
            Me.TabControlHeader_Visuals.Location = New System.Drawing.Point(3, 59)
            Me.TabControlHeader_Visuals.Name = "TabControlHeader_Visuals"
            Me.TabControlHeader_Visuals.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlHeader_Visuals.SelectedTabIndex = 2
            Me.TabControlHeader_Visuals.Size = New System.Drawing.Size(1005, 246)
            Me.TabControlHeader_Visuals.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlHeader_Visuals.TabIndex = 47
            Me.TabControlHeader_Visuals.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlHeader_Visuals.Tabs.Add(Me.TabItemVisuals_Gauges)
            Me.TabControlHeader_Visuals.Tabs.Add(Me.TabItemVisuals_Charts)
            Me.TabControlHeader_Visuals.TabStop = False
            '
            'TabControlPanelGaugesTab_Gauges
            '
            Me.TabControlPanelGaugesTab_Gauges.Controls.Add(Me.GaugeControlForm_ImpressionsGoal)
            Me.TabControlPanelGaugesTab_Gauges.Controls.Add(Me.LabelGauges_VerticalLine2)
            Me.TabControlPanelGaugesTab_Gauges.Controls.Add(Me.LabelGauges_VerticalLine1)
            Me.TabControlPanelGaugesTab_Gauges.Controls.Add(Me.GaugeControlForm_SpendGoal)
            Me.TabControlPanelGaugesTab_Gauges.Controls.Add(Me.GaugeControlForm_RevenueGoal)
            Me.TabControlPanelGaugesTab_Gauges.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGaugesTab_Gauges.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGaugesTab_Gauges.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGaugesTab_Gauges.Name = "TabControlPanelGaugesTab_Gauges"
            Me.TabControlPanelGaugesTab_Gauges.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGaugesTab_Gauges.Size = New System.Drawing.Size(1005, 219)
            Me.TabControlPanelGaugesTab_Gauges.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGaugesTab_Gauges.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGaugesTab_Gauges.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGaugesTab_Gauges.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGaugesTab_Gauges.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGaugesTab_Gauges.Style.GradientAngle = 90
            Me.TabControlPanelGaugesTab_Gauges.TabIndex = 0
            Me.TabControlPanelGaugesTab_Gauges.TabItem = Me.TabItemVisuals_Gauges
            '
            'GaugeControlForm_ImpressionsGoal
            '
            Me.GaugeControlForm_ImpressionsGoal.AutoLayout = False
            Me.GaugeControlForm_ImpressionsGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.GaugeControlForm_ImpressionsGoal.ColorScheme.TargetElements = CType((DevExpress.XtraGauges.Core.Base.TargetElement.RangeBar Or DevExpress.XtraGauges.Core.Base.TargetElement.Label), DevExpress.XtraGauges.Core.Base.TargetElement)
            Me.GaugeControlForm_ImpressionsGoal.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.CircularGauge_ImpressionsGauge})
            Me.GaugeControlForm_ImpressionsGoal.Location = New System.Drawing.Point(4, 4)
            Me.GaugeControlForm_ImpressionsGoal.Name = "GaugeControlForm_ImpressionsGoal"
            Me.GaugeControlForm_ImpressionsGoal.Size = New System.Drawing.Size(325, 211)
            Me.GaugeControlForm_ImpressionsGoal.TabIndex = 19
            '
            'CircularGauge_ImpressionsGauge
            '
            Me.CircularGauge_ImpressionsGauge.Bounds = New System.Drawing.Rectangle(1, 1, 324, 210)
            Me.CircularGauge_ImpressionsGauge.Labels.AddRange(New DevExpress.XtraGauges.Win.Base.LabelComponent() {Me.LabelComponent5, Me.LabelComponent6, Me.LabelComponent7})
            Me.CircularGauge_ImpressionsGauge.Name = "CircularGauge_ImpressionsGauge"
            Me.CircularGauge_ImpressionsGauge.RangeBars.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent() {Me.ArcScaleRangeBarComponent3})
            Me.CircularGauge_ImpressionsGauge.Scales.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent() {Me.ArcScaleComponent3})
            '
            'LabelComponent5
            '
            Me.LabelComponent5.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent5.Name = "circularGauge1_Label1"
            Me.LabelComponent5.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 100.0!)
            Me.LabelComponent5.Size = New System.Drawing.SizeF(100.0!, 30.0!)
            Me.LabelComponent5.Text = "0"
            Me.LabelComponent5.ZOrder = -1001
            '
            'LabelComponent6
            '
            Me.LabelComponent6.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent6.AppearanceText.Format = New DevExpress.XtraGauges.Core.Drawing.StringFormatObject(System.Drawing.StringAlignment.Center, System.Drawing.StringAlignment.Near, System.Drawing.StringTrimming.Character, System.Drawing.StringFormatFlags.NoClip)
            Me.LabelComponent6.Name = "circularGauge1_Label2"
            Me.LabelComponent6.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 150.0!)
            Me.LabelComponent6.Size = New System.Drawing.SizeF(140.0!, 60.0!)
            Me.LabelComponent6.Text = "0 of 0"
            Me.LabelComponent6.ZOrder = -1001
            '
            'LabelComponent7
            '
            Me.LabelComponent7.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelComponent7.AppearanceText.Format = New DevExpress.XtraGauges.Core.Drawing.StringFormatObject(System.Drawing.StringAlignment.Center, System.Drawing.StringAlignment.Center, System.Drawing.StringTrimming.None, System.Drawing.StringFormatFlags.NoClip)
            Me.LabelComponent7.AppearanceText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black")
            Me.LabelComponent7.Name = "CircularGauge_ImpressionsGauge_Label3"
            Me.LabelComponent7.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 70.0!)
            Me.LabelComponent7.Text = "IMPRESSIONS"
            Me.LabelComponent7.ZOrder = -1001
            '
            'ArcScaleRangeBarComponent3
            '
            Me.ArcScaleRangeBarComponent3.ArcScale = Me.ArcScaleComponent3
            Me.ArcScaleRangeBarComponent3.Name = "circularGauge1_RangeBar2"
            Me.ArcScaleRangeBarComponent3.RoundedCaps = True
            Me.ArcScaleRangeBarComponent3.ShowBackground = True
            Me.ArcScaleRangeBarComponent3.StartOffset = 80.0!
            Me.ArcScaleRangeBarComponent3.ZOrder = -10
            '
            'ArcScaleComponent3
            '
            Me.ArcScaleComponent3.AppearanceMajorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent3.AppearanceMajorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent3.AppearanceMinorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent3.AppearanceMinorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent3.AppearanceTickmarkText.Font = New System.Drawing.Font("Tahoma", 8.5!)
            Me.ArcScaleComponent3.AppearanceTickmarkText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A")
            Me.ArcScaleComponent3.Center = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 125.0!)
            Me.ArcScaleComponent3.EndAngle = 60.0!
            Me.ArcScaleComponent3.MajorTickCount = 0
            Me.ArcScaleComponent3.MajorTickmark.FormatString = "{0:F0}"
            Me.ArcScaleComponent3.MajorTickmark.ShapeOffset = -14.0!
            Me.ArcScaleComponent3.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1
            Me.ArcScaleComponent3.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight
            Me.ArcScaleComponent3.MaxValue = 100.0!
            Me.ArcScaleComponent3.MinorTickCount = 0
            Me.ArcScaleComponent3.MinorTickmark.ShapeOffset = -7.0!
            Me.ArcScaleComponent3.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2
            Me.ArcScaleComponent3.Name = "scale1"
            Me.ArcScaleComponent3.StartAngle = -240.0!
            '
            'LabelGauges_VerticalLine2
            '
            Me.LabelGauges_VerticalLine2.BackColor = System.Drawing.Color.LightGray
            '
            '
            '
            Me.LabelGauges_VerticalLine2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGauges_VerticalLine2.Location = New System.Drawing.Point(670, 5)
            Me.LabelGauges_VerticalLine2.Name = "LabelGauges_VerticalLine2"
            Me.LabelGauges_VerticalLine2.Size = New System.Drawing.Size(1, 210)
            Me.LabelGauges_VerticalLine2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGauges_VerticalLine2.TabIndex = 17
            '
            'LabelGauges_VerticalLine1
            '
            Me.LabelGauges_VerticalLine1.BackColor = System.Drawing.Color.LightGray
            '
            '
            '
            Me.LabelGauges_VerticalLine1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGauges_VerticalLine1.Location = New System.Drawing.Point(334, 5)
            Me.LabelGauges_VerticalLine1.Name = "LabelGauges_VerticalLine1"
            Me.LabelGauges_VerticalLine1.Size = New System.Drawing.Size(1, 210)
            Me.LabelGauges_VerticalLine1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGauges_VerticalLine1.TabIndex = 16
            '
            'GaugeControlForm_SpendGoal
            '
            Me.GaugeControlForm_SpendGoal.AutoLayout = False
            Me.GaugeControlForm_SpendGoal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.GaugeControlForm_SpendGoal.ColorScheme.TargetElements = CType((DevExpress.XtraGauges.Core.Base.TargetElement.RangeBar Or DevExpress.XtraGauges.Core.Base.TargetElement.Label), DevExpress.XtraGauges.Core.Base.TargetElement)
            Me.GaugeControlForm_SpendGoal.Gauges.AddRange(New DevExpress.XtraGauges.Base.IGauge() {Me.CircularGauge_SpendGoal})
            Me.GaugeControlForm_SpendGoal.Location = New System.Drawing.Point(340, 4)
            Me.GaugeControlForm_SpendGoal.Name = "GaugeControlForm_SpendGoal"
            Me.GaugeControlForm_SpendGoal.Size = New System.Drawing.Size(325, 211)
            Me.GaugeControlForm_SpendGoal.TabIndex = 14
            '
            'CircularGauge_SpendGoal
            '
            Me.CircularGauge_SpendGoal.Bounds = New System.Drawing.Rectangle(1, 1, 324, 210)
            Me.CircularGauge_SpendGoal.Labels.AddRange(New DevExpress.XtraGauges.Win.Base.LabelComponent() {Me.LabelComponent3, Me.LabelComponent4, Me.LabelComponent8})
            Me.CircularGauge_SpendGoal.Name = "CircularGauge_SpendGoal"
            Me.CircularGauge_SpendGoal.RangeBars.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent() {Me.ArcScaleRangeBarComponent2})
            Me.CircularGauge_SpendGoal.Scales.AddRange(New DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent() {Me.ArcScaleComponent2})
            '
            'LabelComponent3
            '
            Me.LabelComponent3.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent3.Name = "circularGauge1_Label1"
            Me.LabelComponent3.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 100.0!)
            Me.LabelComponent3.Size = New System.Drawing.SizeF(100.0!, 30.0!)
            Me.LabelComponent3.Text = "0"
            Me.LabelComponent3.ZOrder = -1001
            '
            'LabelComponent4
            '
            Me.LabelComponent4.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.LabelComponent4.AppearanceText.Format = New DevExpress.XtraGauges.Core.Drawing.StringFormatObject(System.Drawing.StringAlignment.Center, System.Drawing.StringAlignment.Near, System.Drawing.StringTrimming.Character, System.Drawing.StringFormatFlags.NoClip)
            Me.LabelComponent4.Name = "circularGauge1_Label2"
            Me.LabelComponent4.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 150.0!)
            Me.LabelComponent4.Size = New System.Drawing.SizeF(140.0!, 60.0!)
            Me.LabelComponent4.Text = "0 of 0"
            Me.LabelComponent4.ZOrder = -1001
            '
            'LabelComponent8
            '
            Me.LabelComponent8.AppearanceText.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelComponent8.AppearanceText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black")
            Me.LabelComponent8.Name = "CircularGauge_SpendGoal_Label3"
            Me.LabelComponent8.Position = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 70.0!)
            Me.LabelComponent8.Text = "SPEND"
            Me.LabelComponent8.ZOrder = -1001
            '
            'ArcScaleRangeBarComponent2
            '
            Me.ArcScaleRangeBarComponent2.ArcScale = Me.ArcScaleComponent2
            Me.ArcScaleRangeBarComponent2.Name = "circularGauge1_RangeBar2"
            Me.ArcScaleRangeBarComponent2.RoundedCaps = True
            Me.ArcScaleRangeBarComponent2.ShowBackground = True
            Me.ArcScaleRangeBarComponent2.StartOffset = 80.0!
            Me.ArcScaleRangeBarComponent2.ZOrder = -10
            '
            'ArcScaleComponent2
            '
            Me.ArcScaleComponent2.AppearanceMajorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent2.AppearanceMajorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent2.AppearanceMinorTickmark.BorderBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent2.AppearanceMinorTickmark.ContentBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White")
            Me.ArcScaleComponent2.AppearanceTickmarkText.Font = New System.Drawing.Font("Tahoma", 8.5!)
            Me.ArcScaleComponent2.AppearanceTickmarkText.TextBrush = New DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A")
            Me.ArcScaleComponent2.Center = New DevExpress.XtraGauges.Core.Base.PointF2D(125.0!, 125.0!)
            Me.ArcScaleComponent2.EndAngle = 60.0!
            Me.ArcScaleComponent2.MajorTickCount = 0
            Me.ArcScaleComponent2.MajorTickmark.FormatString = "{0:F0}"
            Me.ArcScaleComponent2.MajorTickmark.ShapeOffset = -14.0!
            Me.ArcScaleComponent2.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1
            Me.ArcScaleComponent2.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight
            Me.ArcScaleComponent2.MaxValue = 100.0!
            Me.ArcScaleComponent2.MinorTickCount = 0
            Me.ArcScaleComponent2.MinorTickmark.ShapeOffset = -7.0!
            Me.ArcScaleComponent2.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2
            Me.ArcScaleComponent2.Name = "scale1"
            Me.ArcScaleComponent2.StartAngle = -240.0!
            '
            'TabItemVisuals_Gauges
            '
            Me.TabItemVisuals_Gauges.AttachedControl = Me.TabControlPanelGaugesTab_Gauges
            Me.TabItemVisuals_Gauges.Name = "TabItemVisuals_Gauges"
            Me.TabItemVisuals_Gauges.Text = "Goal Tracking"
            '
            'TabControlPanelChartsTab_Charts
            '
            Me.TabControlPanelChartsTab_Charts.Controls.Add(Me.ChartControlCharts_Impressions)
            Me.TabControlPanelChartsTab_Charts.Controls.Add(Me.ChartControlCharts_Spend)
            Me.TabControlPanelChartsTab_Charts.Controls.Add(Me.ChartControlCharts_Revenue)
            Me.TabControlPanelChartsTab_Charts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelChartsTab_Charts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelChartsTab_Charts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelChartsTab_Charts.Name = "TabControlPanelChartsTab_Charts"
            Me.TabControlPanelChartsTab_Charts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelChartsTab_Charts.Size = New System.Drawing.Size(1005, 219)
            Me.TabControlPanelChartsTab_Charts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelChartsTab_Charts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelChartsTab_Charts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelChartsTab_Charts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelChartsTab_Charts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelChartsTab_Charts.Style.GradientAngle = 90
            Me.TabControlPanelChartsTab_Charts.TabIndex = 2
            Me.TabControlPanelChartsTab_Charts.TabItem = Me.TabItemVisuals_Charts
            '
            'ChartControlCharts_Impressions
            '
            Me.ChartControlCharts_Impressions.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
            Me.ChartControlCharts_Impressions.DataSource = Me.DigitalEstimateDetailBindingSource
            XyDiagram4.AxisX.VisibleInPanesSerializable = "-1"
            XyDiagram4.AxisY.VisibleInPanesSerializable = "-1"
            Me.ChartControlCharts_Impressions.Diagram = XyDiagram4
            Me.ChartControlCharts_Impressions.Legend.Name = "Default Legend"
            Me.ChartControlCharts_Impressions.Location = New System.Drawing.Point(4, 4)
            Me.ChartControlCharts_Impressions.Name = "ChartControlCharts_Impressions"
            Series7.ArgumentDataMember = "EstimateLineString"
            Series7.Name = "Actual Impressions"
            Series7.ToolTipHintDataMember = "VendorName"
            Series7.ValueDataMembersSerializable = "ActualImpressions"
            Series8.ArgumentDataMember = "EstimateLineString"
            Series8.Name = "Plan Impressions"
            Series8.ToolTipHintDataMember = "VendorName"
            Series8.ValueDataMembersSerializable = "PlanImpressions"
            LineSeriesView4.Color = System.Drawing.Color.Chartreuse
            Series8.View = LineSeriesView4
            Me.ChartControlCharts_Impressions.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series7, Series8}
            Me.ChartControlCharts_Impressions.Size = New System.Drawing.Size(325, 211)
            Me.ChartControlCharts_Impressions.TabIndex = 3
            '
            'DigitalEstimateDetailBindingSource
            '
            Me.DigitalEstimateDetailBindingSource.DataSource = GetType(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)
            '
            'ChartControlCharts_Spend
            '
            Me.ChartControlCharts_Spend.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
            Me.ChartControlCharts_Spend.DataSource = Me.DigitalEstimateDetailBindingSource
            XyDiagram5.AxisX.VisibleInPanesSerializable = "-1"
            XyDiagram5.AxisY.VisibleInPanesSerializable = "-1"
            Me.ChartControlCharts_Spend.Diagram = XyDiagram5
            Me.ChartControlCharts_Spend.Legend.Name = "Default Legend"
            Me.ChartControlCharts_Spend.Location = New System.Drawing.Point(339, 4)
            Me.ChartControlCharts_Spend.Name = "ChartControlCharts_Spend"
            Series9.ArgumentDataMember = "EstimateLineString"
            Series9.Name = "Actual Spend"
            Series9.ToolTipHintDataMember = "VendorName"
            Series9.ValueDataMembersSerializable = "ActualSpend"
            Series10.ArgumentDataMember = "EstimateLineString"
            Series10.Name = "Plan Spend"
            Series10.ToolTipHintDataMember = "VendorName"
            Series10.ValueDataMembersSerializable = "PlanSpend"
            LineSeriesView5.Color = System.Drawing.Color.Chartreuse
            Series10.View = LineSeriesView5
            Me.ChartControlCharts_Spend.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series9, Series10}
            Me.ChartControlCharts_Spend.Size = New System.Drawing.Size(325, 211)
            Me.ChartControlCharts_Spend.TabIndex = 2
            '
            'ChartControlCharts_Revenue
            '
            Me.ChartControlCharts_Revenue.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.[False]
            Me.ChartControlCharts_Revenue.DataSource = Me.DigitalEstimateDetailBindingSource
            XyDiagram6.AxisX.VisibleInPanesSerializable = "-1"
            XyDiagram6.AxisY.VisibleInPanesSerializable = "-1"
            Me.ChartControlCharts_Revenue.Diagram = XyDiagram6
            Me.ChartControlCharts_Revenue.Legend.Name = "Default Legend"
            Me.ChartControlCharts_Revenue.Location = New System.Drawing.Point(675, 4)
            Me.ChartControlCharts_Revenue.Name = "ChartControlCharts_Revenue"
            Series11.ArgumentDataMember = "EstimateLineString"
            Series11.Name = "Actual Revenue"
            Series11.ToolTipHintDataMember = "VendorName"
            Series11.ValueDataMembersSerializable = "ActualRevenue"
            Series12.ArgumentDataMember = "EstimateLineString"
            Series12.Name = "Plan Revenue"
            Series12.ToolTipHintDataMember = "VendorName"
            Series12.ValueDataMembersSerializable = "PlanRevenue"
            LineSeriesView6.Color = System.Drawing.Color.Chartreuse
            Series12.View = LineSeriesView6
            Me.ChartControlCharts_Revenue.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series11, Series12}
            Me.ChartControlCharts_Revenue.Size = New System.Drawing.Size(325, 211)
            Me.ChartControlCharts_Revenue.TabIndex = 1
            '
            'TabItemVisuals_Charts
            '
            Me.TabItemVisuals_Charts.AttachedControl = Me.TabControlPanelChartsTab_Charts
            Me.TabItemVisuals_Charts.Name = "TabItemVisuals_Charts"
            Me.TabItemVisuals_Charts.Text = "Goal Tracking by Estimate"
            '
            'PanelForm_BottomSection
            '
            Me.PanelForm_BottomSection.Controls.Add(Me.DataGridViewForm_EstimateDetail)
            Me.PanelForm_BottomSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_BottomSection.Location = New System.Drawing.Point(0, 308)
            Me.PanelForm_BottomSection.Name = "PanelForm_BottomSection"
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(1011, 181)
            Me.PanelForm_BottomSection.TabIndex = 24
            '
            'DigitalCampaignDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1021, 664)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DigitalCampaignDetailDialog"
            Me.Text = "Digital Campaign Detail"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CircularGauge_RevenueGoal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleRangeBarComponent1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleComponent1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ExpandablePanelControl_HeaderInfo.ResumeLayout(False)
            CType(Me.TabControlHeader_Visuals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlHeader_Visuals.ResumeLayout(False)
            Me.TabControlPanelGaugesTab_Gauges.ResumeLayout(False)
            CType(Me.CircularGauge_ImpressionsGauge, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleRangeBarComponent3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleComponent3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CircularGauge_SpendGoal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LabelComponent8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleRangeBarComponent2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ArcScaleComponent2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelChartsTab_Charts.ResumeLayout(False)
            CType(XyDiagram4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(LineSeriesView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartControlCharts_Impressions, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DigitalEstimateDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(XyDiagram5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(LineSeriesView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartControlCharts_Spend, System.ComponentModel.ISupportInitialize).EndInit()
            CType(XyDiagram6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(LineSeriesView6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series12, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartControlCharts_Revenue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_BottomSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_EstimateDetail As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_FunctionGrid As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemGrid_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemGrid_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemView_Flight As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemView_Periods As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents GaugeControlForm_RevenueGoal As DevExpress.XtraGauges.Win.GaugeControl
        Friend WithEvents TextBoxForm_Campaign As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Campaign As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Estimate As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_EstimateNumberAndName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Buyer As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Buyer As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CircularGauge_RevenueGoal As DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge
        Private WithEvents LabelComponent1 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents LabelComponent2 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents ArcScaleRangeBarComponent1 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent
        Private WithEvents ArcScaleComponent1 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent
        Friend WithEvents ExpandablePanelControl_HeaderInfo As DevComponents.DotNetBar.ExpandablePanel
        Private WithEvents PanelForm_BottomSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Actualize As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeNoRollFoward As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlHeader_Visuals As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGaugesTab_Gauges As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVisuals_Gauges As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelChartsTab_Charts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVisuals_Charts As DevComponents.DotNetBar.TabItem
        Friend WithEvents GaugeControlForm_SpendGoal As DevExpress.XtraGauges.Win.GaugeControl
        Friend WithEvents CircularGauge_SpendGoal As DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge
        Private WithEvents LabelComponent3 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents LabelComponent4 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents ArcScaleRangeBarComponent2 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent
        Private WithEvents ArcScaleComponent2 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent
        Friend WithEvents LabelGauges_VerticalLine1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelGauges_VerticalLine2 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ChartControlCharts_Revenue As DevExpress.XtraCharts.ChartControl
        Friend WithEvents DigitalEstimateDetailBindingSource As Windows.Forms.BindingSource
        Friend WithEvents ChartControlCharts_Impressions As DevExpress.XtraCharts.ChartControl
        Friend WithEvents ChartControlCharts_Spend As DevExpress.XtraCharts.ChartControl
        Friend WithEvents GaugeControlForm_ImpressionsGoal As DevExpress.XtraGauges.Win.GaugeControl
        Friend WithEvents CircularGauge_ImpressionsGauge As DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge
        Private WithEvents LabelComponent5 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents LabelComponent6 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents ArcScaleRangeBarComponent3 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent
        Private WithEvents ArcScaleComponent3 As DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent
        Friend WithEvents ButtonItemActions_ActualizeRollFowardAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeRollFowardNext As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ActualizeRollForwardPercent As DevComponents.DotNetBar.ButtonItem
        Private WithEvents LabelComponent7 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents LabelComponent8 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Private WithEvents LabelComponent9 As DevExpress.XtraGauges.Win.Base.LabelComponent
        Friend WithEvents FolderBrowserDialogExport As Windows.Forms.FolderBrowserDialog
        Friend WithEvents ButtonItemExport_Grid As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_Images As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemChartView_Impressions As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemChartView_Clicks As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemChartView_Units As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ReviseOrders As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
