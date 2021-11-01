Namespace GeneralLedger.Processing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UnpostedJournalEntryDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnpostedJournalEntryDialog))
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
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlPanelChartsTab_Charts = New DevComponents.DotNetBar.TabControlPanel()
            Me.ChartControlCharts_Impressions = New DevExpress.XtraCharts.ChartControl()
            Me.DigitalEstimateDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.ChartControlCharts_Spend = New DevExpress.XtraCharts.ChartControl()
            Me.ChartControlCharts_Revenue = New DevExpress.XtraCharts.ChartControl()
            Me.DataGridViewForm_UnpostedJournalEntries = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_PostingPeriodFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_PostPeriodTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelForm_PostingPeriodTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_PostPeriodFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxSpotTVViewControl_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
            CType(Me.SearchableComboBoxForm_PostPeriodTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_PostPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_UnpostedJournalEntries)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_PostingPeriodFrom)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_PostPeriodTo)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_PostingPeriodTo)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_PostPeriodFrom)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Refresh})
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
            Me.RibbonBarOptions_Actions.Visible = False
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
            'DataGridViewForm_UnpostedJournalEntries
            '
            Me.DataGridViewForm_UnpostedJournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_UnpostedJournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_UnpostedJournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewForm_UnpostedJournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_UnpostedJournalEntries.ItemDescription = "Journal Entries to Update"
            Me.DataGridViewForm_UnpostedJournalEntries.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewForm_UnpostedJournalEntries.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_UnpostedJournalEntries.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_UnpostedJournalEntries.ModifyGridRowHeight = False
            Me.DataGridViewForm_UnpostedJournalEntries.MultiSelect = False
            Me.DataGridViewForm_UnpostedJournalEntries.Name = "DataGridViewForm_UnpostedJournalEntries"
            Me.DataGridViewForm_UnpostedJournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_UnpostedJournalEntries.SelectRowsWhenSelectDeselectAllButtonClicked = False
            Me.DataGridViewForm_UnpostedJournalEntries.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_UnpostedJournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_UnpostedJournalEntries.Size = New System.Drawing.Size(985, 475)
            Me.DataGridViewForm_UnpostedJournalEntries.TabIndex = 9
            Me.DataGridViewForm_UnpostedJournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewForm_UnpostedJournalEntries.ViewCaptionHeight = -1
            '
            'LabelForm_PostingPeriodFrom
            '
            Me.LabelForm_PostingPeriodFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriodFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriodFrom.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_PostingPeriodFrom.Name = "LabelForm_PostingPeriodFrom"
            Me.LabelForm_PostingPeriodFrom.Size = New System.Drawing.Size(113, 20)
            Me.LabelForm_PostingPeriodFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriodFrom.TabIndex = 5
            Me.LabelForm_PostingPeriodFrom.Text = "Posting Period From:"
            Me.LabelForm_PostingPeriodFrom.Visible = False
            '
            'SearchableComboBoxForm_PostPeriodTo
            '
            Me.SearchableComboBoxForm_PostPeriodTo.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriodTo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriodTo.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriodTo.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriodTo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriodTo.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriodTo.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriodTo.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriodTo.EditValue = ""
            Me.SearchableComboBoxForm_PostPeriodTo.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_PostPeriodTo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriodTo.Location = New System.Drawing.Point(395, 7)
            Me.SearchableComboBoxForm_PostPeriodTo.Name = "SearchableComboBoxForm_PostPeriodTo"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriodTo.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriodTo.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriodTo.SelectedValue = ""
            Me.SearchableComboBoxForm_PostPeriodTo.Size = New System.Drawing.Size(226, 20)
            Me.SearchableComboBoxForm_PostPeriodTo.TabIndex = 8
            Me.SearchableComboBoxForm_PostPeriodTo.Visible = False
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView1.ModifyGridRowHeight = False
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.Editable = False
            Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_PostingPeriodTo
            '
            Me.LabelForm_PostingPeriodTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriodTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriodTo.Location = New System.Drawing.Point(363, 6)
            Me.LabelForm_PostingPeriodTo.Name = "LabelForm_PostingPeriodTo"
            Me.LabelForm_PostingPeriodTo.Size = New System.Drawing.Size(26, 20)
            Me.LabelForm_PostingPeriodTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriodTo.TabIndex = 7
            Me.LabelForm_PostingPeriodTo.Text = "To:"
            Me.LabelForm_PostingPeriodTo.Visible = False
            '
            'SearchableComboBoxForm_PostPeriodFrom
            '
            Me.SearchableComboBoxForm_PostPeriodFrom.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriodFrom.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriodFrom.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriodFrom.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriodFrom.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriodFrom.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriodFrom.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.EditValue = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_PostPeriodFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriodFrom.Location = New System.Drawing.Point(131, 7)
            Me.SearchableComboBoxForm_PostPeriodFrom.Name = "SearchableComboBoxForm_PostPeriodFrom"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.PopupView = Me.SearchableComboBoxSpotTVViewControl_Market
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriodFrom.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriodFrom.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriodFrom.SelectedValue = ""
            Me.SearchableComboBoxForm_PostPeriodFrom.Size = New System.Drawing.Size(226, 20)
            Me.SearchableComboBoxForm_PostPeriodFrom.TabIndex = 6
            Me.SearchableComboBoxForm_PostPeriodFrom.Visible = False
            '
            'SearchableComboBoxSpotTVViewControl_Market
            '
            Me.SearchableComboBoxSpotTVViewControl_Market.AFActiveFilterString = ""
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotTVViewControl_Market.EnableDisabledRows = False
            Me.SearchableComboBoxSpotTVViewControl_Market.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxSpotTVViewControl_Market.ModifyColumnSettingsOnEachDataSource = True
            Me.SearchableComboBoxSpotTVViewControl_Market.ModifyGridRowHeight = False
            Me.SearchableComboBoxSpotTVViewControl_Market.Name = "SearchableComboBoxSpotTVViewControl_Market"
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsBehavior.Editable = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxSpotTVViewControl_Market.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxSpotTVViewControl_Market.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxSpotTVViewControl_Market.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxSpotTVViewControl_Market.SkipSettingFontOnModifyColumn = False
            '
            'UnpostedJournalEntryDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UnpostedJournalEntryDialog"
            Me.Text = "Query Unposted Journal Entries"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
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
            CType(Me.SearchableComboBoxForm_PostPeriodTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_PostPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelChartsTab_Charts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ChartControlCharts_Revenue As DevExpress.XtraCharts.ChartControl
        Friend WithEvents DigitalEstimateDetailBindingSource As Windows.Forms.BindingSource
        Friend WithEvents ChartControlCharts_Impressions As DevExpress.XtraCharts.ChartControl
        Friend WithEvents ChartControlCharts_Spend As DevExpress.XtraCharts.ChartControl
        Friend WithEvents DataGridViewForm_UnpostedJournalEntries As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_PostingPeriodFrom As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_PostPeriodTo As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelForm_PostingPeriodTo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_PostPeriodFrom As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxSpotTVViewControl_Market As WinForm.MVC.Presentation.Controls.GridView
    End Class

End Namespace
