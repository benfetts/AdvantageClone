Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaResearchToolForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaResearchToolForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_UnitTests = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelcomScore_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.ComboBoxComscore_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.PanelComscore_TVStations = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBottomSpotTVMarketStation_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewComscore_SelectedStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonComscoreTVStation_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonComscoreTVStation_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBottomSpotTVMarketStation_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewComscore_AvailableStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewComscore_SelectedDemos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelComscoreMarket = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelComscoreStartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelComscoreEndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelComscoreStartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerComscore_EndTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelComscoreEndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerComscore_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerComscore_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerComscore_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemUnitTests_comScore = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAudienceMetrics_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.Label1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_BookMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputAudienceMetrics_BookYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.ComboBoxAudienceMetrics_BookMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxAudienceMetrics_Station = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DataGridViewAudienceMetrics_SelectedDemos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewAudienceMetrics_Results = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ComboBoxAudienceMetrics_SampleType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.GroupBoxAudienceMetrics_Days = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxDays_Fri = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Sat = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Sun = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Thu = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Mon = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Tue = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDays_Wed = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxAudienceMetrics_NielsenService = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelAudienceMetrics_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxAudienceMetrics_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelAudienceMetrics_Station = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_Service = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_SampleType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerAudienceMetrics_DayStarts = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelAudienceMetrics_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_DayStarts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAudienceMetrics_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerAudienceMetrics_EndTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelAudienceMetrics_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerAudienceMetrics_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerAudienceMetrics_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxAudienceMetrics_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerAudienceMetrics_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemUnitTests_AudienceMetrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewComscore_Results = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemUnitTests_comScoreResults = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNational_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxNational_GroupBy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonGroupBy_Network = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGroupBy_Date = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGroupBy_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SearchableComboBoxNational_MarketBreak = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxNational_Service = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DataGridViewNational_SelectedDemos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewNational_Results = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ComboBoxNational_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.GroupBoxNational_Days = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxNationalDays_Fri = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Sat = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Sun = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Thu = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Mon = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Tue = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDays_Wed = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxNational_TimeType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelNational_Media = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_Service = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_MarketBreak = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_TimeType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNational_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerNational_EndTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelNational_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerNational_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerNational_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxNational_Media = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerNational_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemUnitTests_AudienceMetricsNational = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRadio_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckRadio_Friday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Saturday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Sunday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Thursday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Monday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Tuesday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckRadio_Wednesday = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelRadio_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerRadio_EndTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelRadio_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateTimePickerRadio_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxRadio_Station = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView13 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRadio_StationOrCombo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewRadio_Results = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewRadio_SelectedDemos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelRadio_Geography = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxRadio_Geography = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRadio_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxRadio_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelRadio_Period = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxRadio_Period = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TabItemUnitTests_AudienceMetricsRadio = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_UnitTests, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_UnitTests.SuspendLayout()
            Me.TabControlPanelcomScore_Criteria.SuspendLayout()
            CType(Me.PanelComscore_TVStations, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelComscore_TVStations.SuspendLayout()
            CType(Me.PanelBottomSpotTVMarketStation_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotTVMarketStation_RightSection.SuspendLayout()
            CType(Me.PanelBottomSpotTVMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotTVMarketStation_LeftSection.SuspendLayout()
            CType(Me.DateTimePickerComscore_EndTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerComscore_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerComscore_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerComscore_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelAudienceMetrics_Criteria.SuspendLayout()
            CType(Me.NumericInputAudienceMetrics_BookYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxAudienceMetrics_Station.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxAudienceMetrics_Days, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxAudienceMetrics_Days.SuspendLayout()
            CType(Me.DateTimePickerAudienceMetrics_DayStarts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerAudienceMetrics_EndTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerAudienceMetrics_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerAudienceMetrics_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxAudienceMetrics_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerAudienceMetrics_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelNational_Criteria.SuspendLayout()
            CType(Me.GroupBoxNational_GroupBy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNational_GroupBy.SuspendLayout()
            CType(Me.SearchableComboBoxNational_MarketBreak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxNational_Service.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxNational_Days, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNational_Days.SuspendLayout()
            CType(Me.DateTimePickerNational_EndTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNational_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNational_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxNational_Media.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNational_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelRadio_Criteria.SuspendLayout()
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.DateTimePickerRadio_EndTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerRadio_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRadio_Station.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRadio_Geography.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRadio_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxRadio_Period.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(424, 181)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(584, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(254, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.SecurityEnabled = True
            Me.ButtonItemActions_Process.Stretch = True
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'TabControlForm_UnitTests
            '
            Me.TabControlForm_UnitTests.BackColor = System.Drawing.Color.White
            Me.TabControlForm_UnitTests.CanReorderTabs = False
            Me.TabControlForm_UnitTests.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_UnitTests.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_UnitTests.Controls.Add(Me.TabControlPanelcomScore_Criteria)
            Me.TabControlForm_UnitTests.Controls.Add(Me.TabControlPanelAudienceMetrics_Criteria)
            Me.TabControlForm_UnitTests.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_UnitTests.Controls.Add(Me.TabControlPanelNational_Criteria)
            Me.TabControlForm_UnitTests.Controls.Add(Me.TabControlPanelRadio_Criteria)
            Me.TabControlForm_UnitTests.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlForm_UnitTests.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_UnitTests.Location = New System.Drawing.Point(0, 0)
            Me.TabControlForm_UnitTests.Name = "TabControlForm_UnitTests"
            Me.TabControlForm_UnitTests.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_UnitTests.SelectedTabIndex = 0
            Me.TabControlForm_UnitTests.Size = New System.Drawing.Size(1054, 624)
            Me.TabControlForm_UnitTests.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_UnitTests.TabIndex = 0
            Me.TabControlForm_UnitTests.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_UnitTests.Tabs.Add(Me.TabItemUnitTests_AudienceMetrics)
            Me.TabControlForm_UnitTests.Tabs.Add(Me.TabItemUnitTests_AudienceMetricsNational)
            Me.TabControlForm_UnitTests.Tabs.Add(Me.TabItemUnitTests_AudienceMetricsRadio)
            Me.TabControlForm_UnitTests.Tabs.Add(Me.TabItemUnitTests_comScore)
            Me.TabControlForm_UnitTests.Tabs.Add(Me.TabItemUnitTests_comScoreResults)
            '
            'TabControlPanelcomScore_Criteria
            '
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.ComboBoxComscore_Market)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.PanelComscore_TVStations)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.DataGridViewComscore_SelectedDemos)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.LabelComscoreMarket)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.LabelComscoreStartDate)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.LabelComscoreEndDate)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.LabelComscoreStartTime)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.DateTimePickerComscore_EndTime)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.LabelComscoreEndTime)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.DateTimePickerComscore_StartTime)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.DateTimePickerComscore_EndDate)
            Me.TabControlPanelcomScore_Criteria.Controls.Add(Me.DateTimePickerComscore_StartDate)
            Me.TabControlPanelcomScore_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelcomScore_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelcomScore_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelcomScore_Criteria.Name = "TabControlPanelcomScore_Criteria"
            Me.TabControlPanelcomScore_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelcomScore_Criteria.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelcomScore_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelcomScore_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelcomScore_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelcomScore_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelcomScore_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelcomScore_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelcomScore_Criteria.TabIndex = 21
            Me.TabControlPanelcomScore_Criteria.TabItem = Me.TabItemUnitTests_comScore
            '
            'ComboBoxComscore_Market
            '
            Me.ComboBoxComscore_Market.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxComscore_Market.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxComscore_Market.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxComscore_Market.AutoFindItemInDataSource = False
            Me.ComboBoxComscore_Market.AutoSelectSingleItemDatasource = False
            Me.ComboBoxComscore_Market.BookmarkingEnabled = False
            Me.ComboBoxComscore_Market.DisableMouseWheel = True
            Me.ComboBoxComscore_Market.DisplayMember = "Display"
            Me.ComboBoxComscore_Market.DisplayName = "Market"
            Me.ComboBoxComscore_Market.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxComscore_Market.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxComscore_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxComscore_Market.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxComscore_Market.FocusHighlightEnabled = True
            Me.ComboBoxComscore_Market.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxComscore_Market.FormattingEnabled = True
            Me.ComboBoxComscore_Market.ItemHeight = 16
            Me.ComboBoxComscore_Market.Location = New System.Drawing.Point(81, 56)
            Me.ComboBoxComscore_Market.Name = "ComboBoxComscore_Market"
            Me.ComboBoxComscore_Market.ReadOnly = False
            Me.ComboBoxComscore_Market.SecurityEnabled = True
            Me.ComboBoxComscore_Market.Size = New System.Drawing.Size(237, 22)
            Me.ComboBoxComscore_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxComscore_Market.TabIndex = 9
            Me.ComboBoxComscore_Market.TabOnEnter = True
            Me.ComboBoxComscore_Market.ValueMember = "Value"
            Me.ComboBoxComscore_Market.WatermarkText = "Select"
            '
            'PanelComscore_TVStations
            '
            Me.PanelComscore_TVStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelComscore_TVStations.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelComscore_TVStations.Appearance.Options.UseBackColor = True
            Me.PanelComscore_TVStations.Controls.Add(Me.PanelBottomSpotTVMarketStation_RightSection)
            Me.PanelComscore_TVStations.Controls.Add(Me.ExpandableSplitterSpotTVMarketStations_LeftRight)
            Me.PanelComscore_TVStations.Controls.Add(Me.PanelBottomSpotTVMarketStation_LeftSection)
            Me.PanelComscore_TVStations.Location = New System.Drawing.Point(381, 4)
            Me.PanelComscore_TVStations.Name = "PanelComscore_TVStations"
            Me.PanelComscore_TVStations.Size = New System.Drawing.Size(669, 587)
            Me.PanelComscore_TVStations.TabIndex = 17
            '
            'PanelBottomSpotTVMarketStation_RightSection
            '
            Me.PanelBottomSpotTVMarketStation_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotTVMarketStation_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.DataGridViewComscore_SelectedStations)
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.ButtonComscoreTVStation_AddToSelected)
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.ButtonComscoreTVStation_RemoveFromSelected)
            Me.PanelBottomSpotTVMarketStation_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomSpotTVMarketStation_RightSection.Location = New System.Drawing.Point(303, 2)
            Me.PanelBottomSpotTVMarketStation_RightSection.Name = "PanelBottomSpotTVMarketStation_RightSection"
            Me.PanelBottomSpotTVMarketStation_RightSection.Size = New System.Drawing.Size(364, 583)
            Me.PanelBottomSpotTVMarketStation_RightSection.TabIndex = 1
            '
            'DataGridViewComscore_SelectedStations
            '
            Me.DataGridViewComscore_SelectedStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewComscore_SelectedStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewComscore_SelectedStations.AutoUpdateViewCaption = True
            Me.DataGridViewComscore_SelectedStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewComscore_SelectedStations.ItemDescription = "Selected Station(s)"
            Me.DataGridViewComscore_SelectedStations.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewComscore_SelectedStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewComscore_SelectedStations.ModifyGridRowHeight = False
            Me.DataGridViewComscore_SelectedStations.MultiSelect = True
            Me.DataGridViewComscore_SelectedStations.Name = "DataGridViewComscore_SelectedStations"
            Me.DataGridViewComscore_SelectedStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewComscore_SelectedStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewComscore_SelectedStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewComscore_SelectedStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewComscore_SelectedStations.Size = New System.Drawing.Size(273, 573)
            Me.DataGridViewComscore_SelectedStations.TabIndex = 14
            Me.DataGridViewComscore_SelectedStations.UseEmbeddedNavigator = False
            Me.DataGridViewComscore_SelectedStations.ViewCaptionHeight = -1
            '
            'ButtonComscoreTVStation_AddToSelected
            '
            Me.ButtonComscoreTVStation_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonComscoreTVStation_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonComscoreTVStation_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonComscoreTVStation_AddToSelected.Name = "ButtonComscoreTVStation_AddToSelected"
            Me.ButtonComscoreTVStation_AddToSelected.SecurityEnabled = True
            Me.ButtonComscoreTVStation_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonComscoreTVStation_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonComscoreTVStation_AddToSelected.TabIndex = 12
            Me.ButtonComscoreTVStation_AddToSelected.Text = ">"
            '
            'ButtonComscoreTVStation_RemoveFromSelected
            '
            Me.ButtonComscoreTVStation_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonComscoreTVStation_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonComscoreTVStation_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonComscoreTVStation_RemoveFromSelected.Name = "ButtonComscoreTVStation_RemoveFromSelected"
            Me.ButtonComscoreTVStation_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonComscoreTVStation_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonComscoreTVStation_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonComscoreTVStation_RemoveFromSelected.TabIndex = 13
            Me.ButtonComscoreTVStation_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterSpotTVMarketStations_LeftRight
            '
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Location = New System.Drawing.Point(297, 2)
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Name = "ExpandableSplitterSpotTVMarketStations_LeftRight"
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Size = New System.Drawing.Size(6, 583)
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.TabIndex = 20
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.TabStop = False
            '
            'PanelBottomSpotTVMarketStation_LeftSection
            '
            Me.PanelBottomSpotTVMarketStation_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotTVMarketStation_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotTVMarketStation_LeftSection.Controls.Add(Me.DataGridViewComscore_AvailableStations)
            Me.PanelBottomSpotTVMarketStation_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBottomSpotTVMarketStation_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBottomSpotTVMarketStation_LeftSection.Name = "PanelBottomSpotTVMarketStation_LeftSection"
            Me.PanelBottomSpotTVMarketStation_LeftSection.Size = New System.Drawing.Size(295, 583)
            Me.PanelBottomSpotTVMarketStation_LeftSection.TabIndex = 0
            '
            'DataGridViewComscore_AvailableStations
            '
            Me.DataGridViewComscore_AvailableStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewComscore_AvailableStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewComscore_AvailableStations.AutoUpdateViewCaption = True
            Me.DataGridViewComscore_AvailableStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewComscore_AvailableStations.ItemDescription = "Available Station(s)"
            Me.DataGridViewComscore_AvailableStations.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewComscore_AvailableStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewComscore_AvailableStations.ModifyGridRowHeight = False
            Me.DataGridViewComscore_AvailableStations.MultiSelect = True
            Me.DataGridViewComscore_AvailableStations.Name = "DataGridViewComscore_AvailableStations"
            Me.DataGridViewComscore_AvailableStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewComscore_AvailableStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewComscore_AvailableStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewComscore_AvailableStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewComscore_AvailableStations.Size = New System.Drawing.Size(284, 573)
            Me.DataGridViewComscore_AvailableStations.TabIndex = 11
            Me.DataGridViewComscore_AvailableStations.UseEmbeddedNavigator = False
            Me.DataGridViewComscore_AvailableStations.ViewCaptionHeight = -1
            '
            'DataGridViewComscore_SelectedDemos
            '
            Me.DataGridViewComscore_SelectedDemos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewComscore_SelectedDemos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewComscore_SelectedDemos.AutoUpdateViewCaption = True
            Me.DataGridViewComscore_SelectedDemos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewComscore_SelectedDemos.ItemDescription = ""
            Me.DataGridViewComscore_SelectedDemos.Location = New System.Drawing.Point(12, 83)
            Me.DataGridViewComscore_SelectedDemos.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewComscore_SelectedDemos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewComscore_SelectedDemos.ModifyGridRowHeight = False
            Me.DataGridViewComscore_SelectedDemos.MultiSelect = True
            Me.DataGridViewComscore_SelectedDemos.Name = "DataGridViewComscore_SelectedDemos"
            Me.DataGridViewComscore_SelectedDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewComscore_SelectedDemos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewComscore_SelectedDemos.ShowRowSelectionIfHidden = True
            Me.DataGridViewComscore_SelectedDemos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewComscore_SelectedDemos.Size = New System.Drawing.Size(362, 508)
            Me.DataGridViewComscore_SelectedDemos.TabIndex = 10
            Me.DataGridViewComscore_SelectedDemos.UseEmbeddedNavigator = False
            Me.DataGridViewComscore_SelectedDemos.ViewCaptionHeight = -1
            '
            'LabelComscoreMarket
            '
            Me.LabelComscoreMarket.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreMarket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreMarket.Location = New System.Drawing.Point(12, 56)
            Me.LabelComscoreMarket.Name = "LabelComscoreMarket"
            Me.LabelComscoreMarket.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreMarket.TabIndex = 8
            Me.LabelComscoreMarket.Text = "Market:"
            '
            'LabelComscoreStartDate
            '
            Me.LabelComscoreStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreStartDate.Location = New System.Drawing.Point(12, 4)
            Me.LabelComscoreStartDate.Name = "LabelComscoreStartDate"
            Me.LabelComscoreStartDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreStartDate.TabIndex = 0
            Me.LabelComscoreStartDate.Text = "Start Date:"
            '
            'LabelComscoreEndDate
            '
            Me.LabelComscoreEndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreEndDate.Location = New System.Drawing.Point(12, 30)
            Me.LabelComscoreEndDate.Name = "LabelComscoreEndDate"
            Me.LabelComscoreEndDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreEndDate.TabIndex = 4
            Me.LabelComscoreEndDate.Text = "End Date:"
            '
            'LabelComscoreStartTime
            '
            Me.LabelComscoreStartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreStartTime.Location = New System.Drawing.Point(168, 4)
            Me.LabelComscoreStartTime.Name = "LabelComscoreStartTime"
            Me.LabelComscoreStartTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreStartTime.TabIndex = 2
            Me.LabelComscoreStartTime.Text = "Start Time:"
            '
            'DateTimePickerComscore_EndTime
            '
            Me.DateTimePickerComscore_EndTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_EndTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_EndTime.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_EndTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerComscore_EndTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerComscore_EndTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_EndTime.DisplayName = "End Time"
            Me.DateTimePickerComscore_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_EndTime.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerComscore_EndTime.FreeTextEntryMode = True
            Me.DateTimePickerComscore_EndTime.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_EndTime.Location = New System.Drawing.Point(237, 30)
            Me.DateTimePickerComscore_EndTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_EndTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_EndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_EndTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_EndTime.MonthCalendar.Visible = False
            Me.DateTimePickerComscore_EndTime.Name = "DateTimePickerComscore_EndTime"
            Me.DateTimePickerComscore_EndTime.ReadOnly = False
            Me.DateTimePickerComscore_EndTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_EndTime.TabIndex = 7
            Me.DateTimePickerComscore_EndTime.TabOnEnter = True
            Me.DateTimePickerComscore_EndTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerComscore_EndTime.Value = New Date(2017, 1, 13, 11, 26, 32, 251)
            '
            'LabelComscoreEndTime
            '
            Me.LabelComscoreEndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComscoreEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComscoreEndTime.Location = New System.Drawing.Point(168, 30)
            Me.LabelComscoreEndTime.Name = "LabelComscoreEndTime"
            Me.LabelComscoreEndTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelComscoreEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComscoreEndTime.TabIndex = 6
            Me.LabelComscoreEndTime.Text = "End Time:"
            '
            'DateTimePickerComscore_StartTime
            '
            Me.DateTimePickerComscore_StartTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_StartTime.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerComscore_StartTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerComscore_StartTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_StartTime.DisplayName = "Start Time"
            Me.DateTimePickerComscore_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_StartTime.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerComscore_StartTime.FreeTextEntryMode = True
            Me.DateTimePickerComscore_StartTime.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_StartTime.Location = New System.Drawing.Point(237, 4)
            Me.DateTimePickerComscore_StartTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_StartTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_StartTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_StartTime.MonthCalendar.Visible = False
            Me.DateTimePickerComscore_StartTime.Name = "DateTimePickerComscore_StartTime"
            Me.DateTimePickerComscore_StartTime.ReadOnly = False
            Me.DateTimePickerComscore_StartTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_StartTime.TabIndex = 3
            Me.DateTimePickerComscore_StartTime.TabOnEnter = True
            Me.DateTimePickerComscore_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerComscore_StartTime.Value = New Date(2017, 1, 13, 11, 26, 28, 875)
            '
            'DateTimePickerComscore_EndDate
            '
            Me.DateTimePickerComscore_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerComscore_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerComscore_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerComscore_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_EndDate.DisplayName = "End Date"
            Me.DateTimePickerComscore_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerComscore_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_EndDate.Location = New System.Drawing.Point(81, 30)
            Me.DateTimePickerComscore_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_EndDate.Name = "DateTimePickerComscore_EndDate"
            Me.DateTimePickerComscore_EndDate.ReadOnly = False
            Me.DateTimePickerComscore_EndDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_EndDate.TabIndex = 5
            Me.DateTimePickerComscore_EndDate.TabOnEnter = True
            Me.DateTimePickerComscore_EndDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'DateTimePickerComscore_StartDate
            '
            Me.DateTimePickerComscore_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerComscore_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerComscore_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerComscore_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerComscore_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerComscore_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerComscore_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerComscore_StartDate.DisplayName = "Start Date"
            Me.DateTimePickerComscore_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerComscore_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerComscore_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerComscore_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerComscore_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerComscore_StartDate.Location = New System.Drawing.Point(81, 4)
            Me.DateTimePickerComscore_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerComscore_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerComscore_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerComscore_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerComscore_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerComscore_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerComscore_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerComscore_StartDate.Name = "DateTimePickerComscore_StartDate"
            Me.DateTimePickerComscore_StartDate.ReadOnly = False
            Me.DateTimePickerComscore_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerComscore_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerComscore_StartDate.TabIndex = 1
            Me.DateTimePickerComscore_StartDate.TabOnEnter = True
            Me.DateTimePickerComscore_StartDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'TabItemUnitTests_comScore
            '
            Me.TabItemUnitTests_comScore.AttachedControl = Me.TabControlPanelcomScore_Criteria
            Me.TabItemUnitTests_comScore.Name = "TabItemUnitTests_comScore"
            Me.TabItemUnitTests_comScore.Text = "Comscore Tester"
            '
            'TabControlPanelAudienceMetrics_Criteria
            '
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.Label1)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_BookMonth)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.NumericInputAudienceMetrics_BookYear)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.ComboBoxAudienceMetrics_BookMonth)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.SearchableComboBoxAudienceMetrics_Station)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DataGridViewAudienceMetrics_SelectedDemos)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DataGridViewAudienceMetrics_Results)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.ComboBoxAudienceMetrics_SampleType)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.GroupBoxAudienceMetrics_Days)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.ComboBoxAudienceMetrics_NielsenService)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_Market)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.ComboBoxAudienceMetrics_Stream)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_Station)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_Stream)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_Service)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_SampleType)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_StartDate)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DateTimePickerAudienceMetrics_DayStarts)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_EndDate)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_DayStarts)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_StartTime)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DateTimePickerAudienceMetrics_EndTime)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.LabelAudienceMetrics_EndTime)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DateTimePickerAudienceMetrics_StartTime)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DateTimePickerAudienceMetrics_EndDate)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.SearchableComboBoxAudienceMetrics_Market)
            Me.TabControlPanelAudienceMetrics_Criteria.Controls.Add(Me.DateTimePickerAudienceMetrics_StartDate)
            Me.TabControlPanelAudienceMetrics_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAudienceMetrics_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAudienceMetrics_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAudienceMetrics_Criteria.Name = "TabControlPanelAudienceMetrics_Criteria"
            Me.TabControlPanelAudienceMetrics_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAudienceMetrics_Criteria.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelAudienceMetrics_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAudienceMetrics_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAudienceMetrics_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAudienceMetrics_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAudienceMetrics_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAudienceMetrics_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelAudienceMetrics_Criteria.TabIndex = 0
            Me.TabControlPanelAudienceMetrics_Criteria.TabItem = Me.TabItemUnitTests_AudienceMetrics
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(224, 30)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(63, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 14
            Me.Label1.Text = "Book Year:"
            '
            'LabelAudienceMetrics_BookMonth
            '
            Me.LabelAudienceMetrics_BookMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_BookMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_BookMonth.Location = New System.Drawing.Point(224, 4)
            Me.LabelAudienceMetrics_BookMonth.Name = "LabelAudienceMetrics_BookMonth"
            Me.LabelAudienceMetrics_BookMonth.Size = New System.Drawing.Size(63, 20)
            Me.LabelAudienceMetrics_BookMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_BookMonth.TabIndex = 12
            Me.LabelAudienceMetrics_BookMonth.Text = "Book Month:"
            '
            'NumericInputAudienceMetrics_BookYear
            '
            Me.NumericInputAudienceMetrics_BookYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAudienceMetrics_BookYear.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputAudienceMetrics_BookYear.EditValue = New Decimal(New Integer() {2017, 0, 0, 0})
            Me.NumericInputAudienceMetrics_BookYear.EnterMoveNextControl = True
            Me.NumericInputAudienceMetrics_BookYear.Location = New System.Drawing.Point(293, 30)
            Me.NumericInputAudienceMetrics_BookYear.Name = "NumericInputAudienceMetrics_BookYear"
            Me.NumericInputAudienceMetrics_BookYear.Properties.AllowMouseWheel = False
            Me.NumericInputAudienceMetrics_BookYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAudienceMetrics_BookYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputAudienceMetrics_BookYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputAudienceMetrics_BookYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputAudienceMetrics_BookYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAudienceMetrics_BookYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputAudienceMetrics_BookYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAudienceMetrics_BookYear.Properties.IsFloatValue = False
            Me.NumericInputAudienceMetrics_BookYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputAudienceMetrics_BookYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAudienceMetrics_BookYear.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputAudienceMetrics_BookYear.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputAudienceMetrics_BookYear.SecurityEnabled = True
            Me.NumericInputAudienceMetrics_BookYear.Size = New System.Drawing.Size(81, 20)
            Me.NumericInputAudienceMetrics_BookYear.TabIndex = 15
            '
            'ComboBoxAudienceMetrics_BookMonth
            '
            Me.ComboBoxAudienceMetrics_BookMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAudienceMetrics_BookMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxAudienceMetrics_BookMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAudienceMetrics_BookMonth.AutoFindItemInDataSource = True
            Me.ComboBoxAudienceMetrics_BookMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAudienceMetrics_BookMonth.BookmarkingEnabled = False
            Me.ComboBoxAudienceMetrics_BookMonth.DisableMouseWheel = True
            Me.ComboBoxAudienceMetrics_BookMonth.DisplayMember = "Display"
            Me.ComboBoxAudienceMetrics_BookMonth.DisplayName = "Book Month"
            Me.ComboBoxAudienceMetrics_BookMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAudienceMetrics_BookMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAudienceMetrics_BookMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAudienceMetrics_BookMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAudienceMetrics_BookMonth.FocusHighlightEnabled = True
            Me.ComboBoxAudienceMetrics_BookMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxAudienceMetrics_BookMonth.FormattingEnabled = True
            Me.ComboBoxAudienceMetrics_BookMonth.ItemHeight = 16
            Me.ComboBoxAudienceMetrics_BookMonth.Location = New System.Drawing.Point(293, 5)
            Me.ComboBoxAudienceMetrics_BookMonth.Name = "ComboBoxAudienceMetrics_BookMonth"
            Me.ComboBoxAudienceMetrics_BookMonth.ReadOnly = False
            Me.ComboBoxAudienceMetrics_BookMonth.SecurityEnabled = True
            Me.ComboBoxAudienceMetrics_BookMonth.Size = New System.Drawing.Size(81, 22)
            Me.ComboBoxAudienceMetrics_BookMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAudienceMetrics_BookMonth.TabIndex = 13
            Me.ComboBoxAudienceMetrics_BookMonth.TabOnEnter = True
            Me.ComboBoxAudienceMetrics_BookMonth.ValueMember = "Value"
            Me.ComboBoxAudienceMetrics_BookMonth.WatermarkText = "Select Month"
            '
            'SearchableComboBoxAudienceMetrics_Station
            '
            Me.SearchableComboBoxAudienceMetrics_Station.ActiveFilterString = ""
            Me.SearchableComboBoxAudienceMetrics_Station.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxAudienceMetrics_Station.AutoFillMode = False
            Me.SearchableComboBoxAudienceMetrics_Station.BookmarkingEnabled = False
            Me.SearchableComboBoxAudienceMetrics_Station.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenStation
            Me.SearchableComboBoxAudienceMetrics_Station.DataSource = Nothing
            Me.SearchableComboBoxAudienceMetrics_Station.DisableMouseWheel = True
            Me.SearchableComboBoxAudienceMetrics_Station.DisplayName = ""
            Me.SearchableComboBoxAudienceMetrics_Station.EditValue = ""
            Me.SearchableComboBoxAudienceMetrics_Station.EnterMoveNextControl = True
            Me.SearchableComboBoxAudienceMetrics_Station.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxAudienceMetrics_Station.Location = New System.Drawing.Point(99, 30)
            Me.SearchableComboBoxAudienceMetrics_Station.Name = "SearchableComboBoxAudienceMetrics_Station"
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.NullText = "Select Station"
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.ShowClearButton = False
            Me.SearchableComboBoxAudienceMetrics_Station.Properties.ValueMember = "Code"
            Me.SearchableComboBoxAudienceMetrics_Station.SecurityEnabled = True
            Me.SearchableComboBoxAudienceMetrics_Station.SelectedValue = ""
            Me.SearchableComboBoxAudienceMetrics_Station.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxAudienceMetrics_Station.TabIndex = 3
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
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
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
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
            Me.GridView1.RunStandardValidation = True
            '
            'DataGridViewAudienceMetrics_SelectedDemos
            '
            Me.DataGridViewAudienceMetrics_SelectedDemos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAudienceMetrics_SelectedDemos.AutoUpdateViewCaption = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAudienceMetrics_SelectedDemos.ItemDescription = ""
            Me.DataGridViewAudienceMetrics_SelectedDemos.Location = New System.Drawing.Point(12, 216)
            Me.DataGridViewAudienceMetrics_SelectedDemos.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewAudienceMetrics_SelectedDemos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.ModifyGridRowHeight = False
            Me.DataGridViewAudienceMetrics_SelectedDemos.MultiSelect = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.Name = "DataGridViewAudienceMetrics_SelectedDemos"
            Me.DataGridViewAudienceMetrics_SelectedDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAudienceMetrics_SelectedDemos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.ShowRowSelectionIfHidden = True
            Me.DataGridViewAudienceMetrics_SelectedDemos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAudienceMetrics_SelectedDemos.Size = New System.Drawing.Size(362, 376)
            Me.DataGridViewAudienceMetrics_SelectedDemos.TabIndex = 25
            Me.DataGridViewAudienceMetrics_SelectedDemos.UseEmbeddedNavigator = False
            Me.DataGridViewAudienceMetrics_SelectedDemos.ViewCaptionHeight = -1
            '
            'DataGridViewAudienceMetrics_Results
            '
            Me.DataGridViewAudienceMetrics_Results.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAudienceMetrics_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAudienceMetrics_Results.AutoUpdateViewCaption = True
            Me.DataGridViewAudienceMetrics_Results.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAudienceMetrics_Results.ItemDescription = "Audience Metric(s)"
            Me.DataGridViewAudienceMetrics_Results.Location = New System.Drawing.Point(382, 5)
            Me.DataGridViewAudienceMetrics_Results.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewAudienceMetrics_Results.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewAudienceMetrics_Results.ModifyGridRowHeight = False
            Me.DataGridViewAudienceMetrics_Results.MultiSelect = True
            Me.DataGridViewAudienceMetrics_Results.Name = "DataGridViewAudienceMetrics_Results"
            Me.DataGridViewAudienceMetrics_Results.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAudienceMetrics_Results.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewAudienceMetrics_Results.ShowRowSelectionIfHidden = True
            Me.DataGridViewAudienceMetrics_Results.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAudienceMetrics_Results.Size = New System.Drawing.Size(659, 587)
            Me.DataGridViewAudienceMetrics_Results.TabIndex = 26
            Me.DataGridViewAudienceMetrics_Results.UseEmbeddedNavigator = False
            Me.DataGridViewAudienceMetrics_Results.ViewCaptionHeight = -1
            '
            'ComboBoxAudienceMetrics_SampleType
            '
            Me.ComboBoxAudienceMetrics_SampleType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAudienceMetrics_SampleType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAudienceMetrics_SampleType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAudienceMetrics_SampleType.AutoFindItemInDataSource = False
            Me.ComboBoxAudienceMetrics_SampleType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAudienceMetrics_SampleType.BookmarkingEnabled = False
            Me.ComboBoxAudienceMetrics_SampleType.DisableMouseWheel = True
            Me.ComboBoxAudienceMetrics_SampleType.DisplayMember = "Display"
            Me.ComboBoxAudienceMetrics_SampleType.DisplayName = "Sample Type"
            Me.ComboBoxAudienceMetrics_SampleType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAudienceMetrics_SampleType.Enabled = False
            Me.ComboBoxAudienceMetrics_SampleType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAudienceMetrics_SampleType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAudienceMetrics_SampleType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAudienceMetrics_SampleType.FocusHighlightEnabled = True
            Me.ComboBoxAudienceMetrics_SampleType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxAudienceMetrics_SampleType.FormattingEnabled = True
            Me.ComboBoxAudienceMetrics_SampleType.ItemHeight = 16
            Me.ComboBoxAudienceMetrics_SampleType.Location = New System.Drawing.Point(99, 108)
            Me.ComboBoxAudienceMetrics_SampleType.Name = "ComboBoxAudienceMetrics_SampleType"
            Me.ComboBoxAudienceMetrics_SampleType.ReadOnly = False
            Me.ComboBoxAudienceMetrics_SampleType.SecurityEnabled = True
            Me.ComboBoxAudienceMetrics_SampleType.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxAudienceMetrics_SampleType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAudienceMetrics_SampleType.TabIndex = 9
            Me.ComboBoxAudienceMetrics_SampleType.TabOnEnter = True
            Me.ComboBoxAudienceMetrics_SampleType.ValueMember = "Value"
            Me.ComboBoxAudienceMetrics_SampleType.WatermarkText = "Select"
            '
            'GroupBoxAudienceMetrics_Days
            '
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Fri)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Sat)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Sun)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Thu)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Mon)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Tue)
            Me.GroupBoxAudienceMetrics_Days.Controls.Add(Me.CheckBoxDays_Wed)
            Me.GroupBoxAudienceMetrics_Days.Location = New System.Drawing.Point(12, 160)
            Me.GroupBoxAudienceMetrics_Days.Name = "GroupBoxAudienceMetrics_Days"
            Me.GroupBoxAudienceMetrics_Days.Size = New System.Drawing.Size(362, 49)
            Me.GroupBoxAudienceMetrics_Days.TabIndex = 24
            Me.GroupBoxAudienceMetrics_Days.Text = "Days"
            '
            'CheckBoxDays_Fri
            '
            Me.CheckBoxDays_Fri.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Fri.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Fri.CheckValue = 0
            Me.CheckBoxDays_Fri.CheckValueChecked = 1
            Me.CheckBoxDays_Fri.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Fri.CheckValueUnchecked = 0
            Me.CheckBoxDays_Fri.ChildControls = Nothing
            Me.CheckBoxDays_Fri.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Fri.Location = New System.Drawing.Point(201, 24)
            Me.CheckBoxDays_Fri.Name = "CheckBoxDays_Fri"
            Me.CheckBoxDays_Fri.OldestSibling = Nothing
            Me.CheckBoxDays_Fri.SecurityEnabled = True
            Me.CheckBoxDays_Fri.SiblingControls = Nothing
            Me.CheckBoxDays_Fri.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Fri.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Fri.TabIndex = 4
            Me.CheckBoxDays_Fri.TabOnEnter = True
            Me.CheckBoxDays_Fri.Text = "Fri"
            '
            'CheckBoxDays_Sat
            '
            Me.CheckBoxDays_Sat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Sat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Sat.CheckValue = 0
            Me.CheckBoxDays_Sat.CheckValueChecked = 1
            Me.CheckBoxDays_Sat.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Sat.CheckValueUnchecked = 0
            Me.CheckBoxDays_Sat.ChildControls = Nothing
            Me.CheckBoxDays_Sat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Sat.Location = New System.Drawing.Point(250, 24)
            Me.CheckBoxDays_Sat.Name = "CheckBoxDays_Sat"
            Me.CheckBoxDays_Sat.OldestSibling = Nothing
            Me.CheckBoxDays_Sat.SecurityEnabled = True
            Me.CheckBoxDays_Sat.SiblingControls = Nothing
            Me.CheckBoxDays_Sat.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Sat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Sat.TabIndex = 5
            Me.CheckBoxDays_Sat.TabOnEnter = True
            Me.CheckBoxDays_Sat.Text = "Sat"
            '
            'CheckBoxDays_Sun
            '
            Me.CheckBoxDays_Sun.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Sun.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Sun.CheckValue = 0
            Me.CheckBoxDays_Sun.CheckValueChecked = 1
            Me.CheckBoxDays_Sun.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Sun.CheckValueUnchecked = 0
            Me.CheckBoxDays_Sun.ChildControls = Nothing
            Me.CheckBoxDays_Sun.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Sun.Location = New System.Drawing.Point(299, 24)
            Me.CheckBoxDays_Sun.Name = "CheckBoxDays_Sun"
            Me.CheckBoxDays_Sun.OldestSibling = Nothing
            Me.CheckBoxDays_Sun.SecurityEnabled = True
            Me.CheckBoxDays_Sun.SiblingControls = Nothing
            Me.CheckBoxDays_Sun.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Sun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Sun.TabIndex = 6
            Me.CheckBoxDays_Sun.TabOnEnter = True
            Me.CheckBoxDays_Sun.Text = "Sun"
            '
            'CheckBoxDays_Thu
            '
            Me.CheckBoxDays_Thu.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Thu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Thu.CheckValue = 0
            Me.CheckBoxDays_Thu.CheckValueChecked = 1
            Me.CheckBoxDays_Thu.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Thu.CheckValueUnchecked = 0
            Me.CheckBoxDays_Thu.ChildControls = Nothing
            Me.CheckBoxDays_Thu.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Thu.Location = New System.Drawing.Point(152, 24)
            Me.CheckBoxDays_Thu.Name = "CheckBoxDays_Thu"
            Me.CheckBoxDays_Thu.OldestSibling = Nothing
            Me.CheckBoxDays_Thu.SecurityEnabled = True
            Me.CheckBoxDays_Thu.SiblingControls = Nothing
            Me.CheckBoxDays_Thu.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Thu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Thu.TabIndex = 3
            Me.CheckBoxDays_Thu.TabOnEnter = True
            Me.CheckBoxDays_Thu.Text = "Thu"
            '
            'CheckBoxDays_Mon
            '
            Me.CheckBoxDays_Mon.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Mon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Mon.CheckValue = 0
            Me.CheckBoxDays_Mon.CheckValueChecked = 1
            Me.CheckBoxDays_Mon.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Mon.CheckValueUnchecked = 0
            Me.CheckBoxDays_Mon.ChildControls = Nothing
            Me.CheckBoxDays_Mon.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Mon.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxDays_Mon.Name = "CheckBoxDays_Mon"
            Me.CheckBoxDays_Mon.OldestSibling = Nothing
            Me.CheckBoxDays_Mon.SecurityEnabled = True
            Me.CheckBoxDays_Mon.SiblingControls = Nothing
            Me.CheckBoxDays_Mon.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Mon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Mon.TabIndex = 0
            Me.CheckBoxDays_Mon.TabOnEnter = True
            Me.CheckBoxDays_Mon.Text = "Mon"
            '
            'CheckBoxDays_Tue
            '
            Me.CheckBoxDays_Tue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Tue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Tue.CheckValue = 0
            Me.CheckBoxDays_Tue.CheckValueChecked = 1
            Me.CheckBoxDays_Tue.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Tue.CheckValueUnchecked = 0
            Me.CheckBoxDays_Tue.ChildControls = Nothing
            Me.CheckBoxDays_Tue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Tue.Location = New System.Drawing.Point(54, 24)
            Me.CheckBoxDays_Tue.Name = "CheckBoxDays_Tue"
            Me.CheckBoxDays_Tue.OldestSibling = Nothing
            Me.CheckBoxDays_Tue.SecurityEnabled = True
            Me.CheckBoxDays_Tue.SiblingControls = Nothing
            Me.CheckBoxDays_Tue.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Tue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Tue.TabIndex = 1
            Me.CheckBoxDays_Tue.TabOnEnter = True
            Me.CheckBoxDays_Tue.Text = "Tue"
            '
            'CheckBoxDays_Wed
            '
            Me.CheckBoxDays_Wed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDays_Wed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDays_Wed.CheckValue = 0
            Me.CheckBoxDays_Wed.CheckValueChecked = 1
            Me.CheckBoxDays_Wed.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDays_Wed.CheckValueUnchecked = 0
            Me.CheckBoxDays_Wed.ChildControls = Nothing
            Me.CheckBoxDays_Wed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDays_Wed.Location = New System.Drawing.Point(103, 24)
            Me.CheckBoxDays_Wed.Name = "CheckBoxDays_Wed"
            Me.CheckBoxDays_Wed.OldestSibling = Nothing
            Me.CheckBoxDays_Wed.SecurityEnabled = True
            Me.CheckBoxDays_Wed.SiblingControls = Nothing
            Me.CheckBoxDays_Wed.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxDays_Wed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDays_Wed.TabIndex = 2
            Me.CheckBoxDays_Wed.TabOnEnter = True
            Me.CheckBoxDays_Wed.Text = "Wed"
            '
            'ComboBoxAudienceMetrics_NielsenService
            '
            Me.ComboBoxAudienceMetrics_NielsenService.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAudienceMetrics_NielsenService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAudienceMetrics_NielsenService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAudienceMetrics_NielsenService.AutoFindItemInDataSource = False
            Me.ComboBoxAudienceMetrics_NielsenService.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAudienceMetrics_NielsenService.BookmarkingEnabled = False
            Me.ComboBoxAudienceMetrics_NielsenService.DisableMouseWheel = True
            Me.ComboBoxAudienceMetrics_NielsenService.DisplayMember = "Display"
            Me.ComboBoxAudienceMetrics_NielsenService.DisplayName = "Service"
            Me.ComboBoxAudienceMetrics_NielsenService.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAudienceMetrics_NielsenService.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAudienceMetrics_NielsenService.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAudienceMetrics_NielsenService.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAudienceMetrics_NielsenService.FocusHighlightEnabled = True
            Me.ComboBoxAudienceMetrics_NielsenService.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxAudienceMetrics_NielsenService.FormattingEnabled = True
            Me.ComboBoxAudienceMetrics_NielsenService.ItemHeight = 16
            Me.ComboBoxAudienceMetrics_NielsenService.Location = New System.Drawing.Point(99, 82)
            Me.ComboBoxAudienceMetrics_NielsenService.Name = "ComboBoxAudienceMetrics_NielsenService"
            Me.ComboBoxAudienceMetrics_NielsenService.ReadOnly = False
            Me.ComboBoxAudienceMetrics_NielsenService.SecurityEnabled = True
            Me.ComboBoxAudienceMetrics_NielsenService.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxAudienceMetrics_NielsenService.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAudienceMetrics_NielsenService.TabIndex = 7
            Me.ComboBoxAudienceMetrics_NielsenService.TabOnEnter = True
            Me.ComboBoxAudienceMetrics_NielsenService.ValueMember = "Value"
            Me.ComboBoxAudienceMetrics_NielsenService.WatermarkText = "Select"
            '
            'LabelAudienceMetrics_Market
            '
            Me.LabelAudienceMetrics_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_Market.Location = New System.Drawing.Point(12, 4)
            Me.LabelAudienceMetrics_Market.Name = "LabelAudienceMetrics_Market"
            Me.LabelAudienceMetrics_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_Market.TabIndex = 0
            Me.LabelAudienceMetrics_Market.Text = "Market:"
            '
            'ComboBoxAudienceMetrics_Stream
            '
            Me.ComboBoxAudienceMetrics_Stream.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAudienceMetrics_Stream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAudienceMetrics_Stream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAudienceMetrics_Stream.AutoFindItemInDataSource = False
            Me.ComboBoxAudienceMetrics_Stream.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAudienceMetrics_Stream.BookmarkingEnabled = False
            Me.ComboBoxAudienceMetrics_Stream.DisableMouseWheel = True
            Me.ComboBoxAudienceMetrics_Stream.DisplayMember = "Display"
            Me.ComboBoxAudienceMetrics_Stream.DisplayName = "Stream"
            Me.ComboBoxAudienceMetrics_Stream.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAudienceMetrics_Stream.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAudienceMetrics_Stream.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxAudienceMetrics_Stream.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAudienceMetrics_Stream.FocusHighlightEnabled = True
            Me.ComboBoxAudienceMetrics_Stream.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxAudienceMetrics_Stream.FormattingEnabled = True
            Me.ComboBoxAudienceMetrics_Stream.ItemHeight = 16
            Me.ComboBoxAudienceMetrics_Stream.Location = New System.Drawing.Point(99, 56)
            Me.ComboBoxAudienceMetrics_Stream.Name = "ComboBoxAudienceMetrics_Stream"
            Me.ComboBoxAudienceMetrics_Stream.ReadOnly = False
            Me.ComboBoxAudienceMetrics_Stream.SecurityEnabled = True
            Me.ComboBoxAudienceMetrics_Stream.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxAudienceMetrics_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAudienceMetrics_Stream.TabIndex = 5
            Me.ComboBoxAudienceMetrics_Stream.TabOnEnter = True
            Me.ComboBoxAudienceMetrics_Stream.ValueMember = "Value"
            Me.ComboBoxAudienceMetrics_Stream.WatermarkText = "Select"
            '
            'LabelAudienceMetrics_Station
            '
            Me.LabelAudienceMetrics_Station.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_Station.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_Station.Location = New System.Drawing.Point(12, 30)
            Me.LabelAudienceMetrics_Station.Name = "LabelAudienceMetrics_Station"
            Me.LabelAudienceMetrics_Station.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_Station.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_Station.TabIndex = 2
            Me.LabelAudienceMetrics_Station.Text = "Station:"
            '
            'LabelAudienceMetrics_Stream
            '
            Me.LabelAudienceMetrics_Stream.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_Stream.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_Stream.Location = New System.Drawing.Point(12, 56)
            Me.LabelAudienceMetrics_Stream.Name = "LabelAudienceMetrics_Stream"
            Me.LabelAudienceMetrics_Stream.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_Stream.TabIndex = 4
            Me.LabelAudienceMetrics_Stream.Text = "Stream:"
            '
            'LabelAudienceMetrics_Service
            '
            Me.LabelAudienceMetrics_Service.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_Service.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_Service.Location = New System.Drawing.Point(12, 82)
            Me.LabelAudienceMetrics_Service.Name = "LabelAudienceMetrics_Service"
            Me.LabelAudienceMetrics_Service.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_Service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_Service.TabIndex = 6
            Me.LabelAudienceMetrics_Service.Text = "Service:"
            '
            'LabelAudienceMetrics_SampleType
            '
            Me.LabelAudienceMetrics_SampleType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_SampleType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_SampleType.Location = New System.Drawing.Point(12, 108)
            Me.LabelAudienceMetrics_SampleType.Name = "LabelAudienceMetrics_SampleType"
            Me.LabelAudienceMetrics_SampleType.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_SampleType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_SampleType.TabIndex = 8
            Me.LabelAudienceMetrics_SampleType.Text = "Sample Type:"
            '
            'LabelAudienceMetrics_StartDate
            '
            Me.LabelAudienceMetrics_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_StartDate.Location = New System.Drawing.Point(224, 56)
            Me.LabelAudienceMetrics_StartDate.Name = "LabelAudienceMetrics_StartDate"
            Me.LabelAudienceMetrics_StartDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelAudienceMetrics_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_StartDate.TabIndex = 16
            Me.LabelAudienceMetrics_StartDate.Text = "Start Date:"
            '
            'DateTimePickerAudienceMetrics_DayStarts
            '
            Me.DateTimePickerAudienceMetrics_DayStarts.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_DayStarts.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAudienceMetrics_DayStarts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_DayStarts.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAudienceMetrics_DayStarts.ButtonFreeText.Checked = True
            Me.DateTimePickerAudienceMetrics_DayStarts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerAudienceMetrics_DayStarts.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerAudienceMetrics_DayStarts.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAudienceMetrics_DayStarts.DisplayName = "Day Starts"
            Me.DateTimePickerAudienceMetrics_DayStarts.Enabled = False
            Me.DateTimePickerAudienceMetrics_DayStarts.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAudienceMetrics_DayStarts.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAudienceMetrics_DayStarts.FocusHighlightEnabled = True
            Me.DateTimePickerAudienceMetrics_DayStarts.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerAudienceMetrics_DayStarts.FreeTextEntryMode = True
            Me.DateTimePickerAudienceMetrics_DayStarts.IsPopupCalendarOpen = False
            Me.DateTimePickerAudienceMetrics_DayStarts.Location = New System.Drawing.Point(99, 134)
            Me.DateTimePickerAudienceMetrics_DayStarts.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAudienceMetrics_DayStarts.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAudienceMetrics_DayStarts.MonthCalendar.Visible = False
            Me.DateTimePickerAudienceMetrics_DayStarts.Name = "DateTimePickerAudienceMetrics_DayStarts"
            Me.DateTimePickerAudienceMetrics_DayStarts.ReadOnly = False
            Me.DateTimePickerAudienceMetrics_DayStarts.Size = New System.Drawing.Size(119, 20)
            Me.DateTimePickerAudienceMetrics_DayStarts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAudienceMetrics_DayStarts.TabIndex = 11
            Me.DateTimePickerAudienceMetrics_DayStarts.TabOnEnter = True
            Me.DateTimePickerAudienceMetrics_DayStarts.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerAudienceMetrics_DayStarts.Value = New Date(2017, 1, 13, 11, 26, 32, 251)
            '
            'LabelAudienceMetrics_EndDate
            '
            Me.LabelAudienceMetrics_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_EndDate.Location = New System.Drawing.Point(224, 82)
            Me.LabelAudienceMetrics_EndDate.Name = "LabelAudienceMetrics_EndDate"
            Me.LabelAudienceMetrics_EndDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelAudienceMetrics_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_EndDate.TabIndex = 18
            Me.LabelAudienceMetrics_EndDate.Text = "End Date:"
            '
            'LabelAudienceMetrics_DayStarts
            '
            Me.LabelAudienceMetrics_DayStarts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_DayStarts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_DayStarts.Location = New System.Drawing.Point(12, 134)
            Me.LabelAudienceMetrics_DayStarts.Name = "LabelAudienceMetrics_DayStarts"
            Me.LabelAudienceMetrics_DayStarts.Size = New System.Drawing.Size(81, 20)
            Me.LabelAudienceMetrics_DayStarts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_DayStarts.TabIndex = 10
            Me.LabelAudienceMetrics_DayStarts.Text = "Day Starts:"
            '
            'LabelAudienceMetrics_StartTime
            '
            Me.LabelAudienceMetrics_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_StartTime.Location = New System.Drawing.Point(224, 108)
            Me.LabelAudienceMetrics_StartTime.Name = "LabelAudienceMetrics_StartTime"
            Me.LabelAudienceMetrics_StartTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelAudienceMetrics_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_StartTime.TabIndex = 20
            Me.LabelAudienceMetrics_StartTime.Text = "Start Time:"
            '
            'DateTimePickerAudienceMetrics_EndTime
            '
            Me.DateTimePickerAudienceMetrics_EndTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAudienceMetrics_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAudienceMetrics_EndTime.ButtonFreeText.Checked = True
            Me.DateTimePickerAudienceMetrics_EndTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerAudienceMetrics_EndTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerAudienceMetrics_EndTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAudienceMetrics_EndTime.DisplayName = "End Time"
            Me.DateTimePickerAudienceMetrics_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAudienceMetrics_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAudienceMetrics_EndTime.FocusHighlightEnabled = True
            Me.DateTimePickerAudienceMetrics_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerAudienceMetrics_EndTime.FreeTextEntryMode = True
            Me.DateTimePickerAudienceMetrics_EndTime.IsPopupCalendarOpen = False
            Me.DateTimePickerAudienceMetrics_EndTime.Location = New System.Drawing.Point(293, 134)
            Me.DateTimePickerAudienceMetrics_EndTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAudienceMetrics_EndTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAudienceMetrics_EndTime.MonthCalendar.Visible = False
            Me.DateTimePickerAudienceMetrics_EndTime.Name = "DateTimePickerAudienceMetrics_EndTime"
            Me.DateTimePickerAudienceMetrics_EndTime.ReadOnly = False
            Me.DateTimePickerAudienceMetrics_EndTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerAudienceMetrics_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAudienceMetrics_EndTime.TabIndex = 23
            Me.DateTimePickerAudienceMetrics_EndTime.TabOnEnter = True
            Me.DateTimePickerAudienceMetrics_EndTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerAudienceMetrics_EndTime.Value = New Date(2017, 1, 13, 11, 26, 32, 251)
            '
            'LabelAudienceMetrics_EndTime
            '
            Me.LabelAudienceMetrics_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAudienceMetrics_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAudienceMetrics_EndTime.Location = New System.Drawing.Point(224, 134)
            Me.LabelAudienceMetrics_EndTime.Name = "LabelAudienceMetrics_EndTime"
            Me.LabelAudienceMetrics_EndTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelAudienceMetrics_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAudienceMetrics_EndTime.TabIndex = 22
            Me.LabelAudienceMetrics_EndTime.Text = "End Time:"
            '
            'DateTimePickerAudienceMetrics_StartTime
            '
            Me.DateTimePickerAudienceMetrics_StartTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAudienceMetrics_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAudienceMetrics_StartTime.ButtonFreeText.Checked = True
            Me.DateTimePickerAudienceMetrics_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerAudienceMetrics_StartTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerAudienceMetrics_StartTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAudienceMetrics_StartTime.DisplayName = "Start Time"
            Me.DateTimePickerAudienceMetrics_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAudienceMetrics_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAudienceMetrics_StartTime.FocusHighlightEnabled = True
            Me.DateTimePickerAudienceMetrics_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerAudienceMetrics_StartTime.FreeTextEntryMode = True
            Me.DateTimePickerAudienceMetrics_StartTime.IsPopupCalendarOpen = False
            Me.DateTimePickerAudienceMetrics_StartTime.Location = New System.Drawing.Point(293, 108)
            Me.DateTimePickerAudienceMetrics_StartTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAudienceMetrics_StartTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAudienceMetrics_StartTime.MonthCalendar.Visible = False
            Me.DateTimePickerAudienceMetrics_StartTime.Name = "DateTimePickerAudienceMetrics_StartTime"
            Me.DateTimePickerAudienceMetrics_StartTime.ReadOnly = False
            Me.DateTimePickerAudienceMetrics_StartTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerAudienceMetrics_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAudienceMetrics_StartTime.TabIndex = 21
            Me.DateTimePickerAudienceMetrics_StartTime.TabOnEnter = True
            Me.DateTimePickerAudienceMetrics_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerAudienceMetrics_StartTime.Value = New Date(2017, 1, 13, 11, 26, 28, 875)
            '
            'DateTimePickerAudienceMetrics_EndDate
            '
            Me.DateTimePickerAudienceMetrics_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAudienceMetrics_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAudienceMetrics_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerAudienceMetrics_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerAudienceMetrics_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerAudienceMetrics_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerAudienceMetrics_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAudienceMetrics_EndDate.DisplayName = "End Date"
            Me.DateTimePickerAudienceMetrics_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAudienceMetrics_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAudienceMetrics_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerAudienceMetrics_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerAudienceMetrics_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerAudienceMetrics_EndDate.Location = New System.Drawing.Point(293, 82)
            Me.DateTimePickerAudienceMetrics_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAudienceMetrics_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAudienceMetrics_EndDate.Name = "DateTimePickerAudienceMetrics_EndDate"
            Me.DateTimePickerAudienceMetrics_EndDate.ReadOnly = False
            Me.DateTimePickerAudienceMetrics_EndDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerAudienceMetrics_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAudienceMetrics_EndDate.TabIndex = 19
            Me.DateTimePickerAudienceMetrics_EndDate.TabOnEnter = True
            Me.DateTimePickerAudienceMetrics_EndDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'SearchableComboBoxAudienceMetrics_Market
            '
            Me.SearchableComboBoxAudienceMetrics_Market.ActiveFilterString = ""
            Me.SearchableComboBoxAudienceMetrics_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxAudienceMetrics_Market.AutoFillMode = False
            Me.SearchableComboBoxAudienceMetrics_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxAudienceMetrics_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxAudienceMetrics_Market.DataSource = Nothing
            Me.SearchableComboBoxAudienceMetrics_Market.DisableMouseWheel = True
            Me.SearchableComboBoxAudienceMetrics_Market.DisplayName = ""
            Me.SearchableComboBoxAudienceMetrics_Market.EditValue = ""
            Me.SearchableComboBoxAudienceMetrics_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxAudienceMetrics_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxAudienceMetrics_Market.Location = New System.Drawing.Point(99, 4)
            Me.SearchableComboBoxAudienceMetrics_Market.Name = "SearchableComboBoxAudienceMetrics_Market"
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.PopupView = Me.SearchableComboBoxViewControl_PostPeriod
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.ShowClearButton = False
            Me.SearchableComboBoxAudienceMetrics_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxAudienceMetrics_Market.SecurityEnabled = True
            Me.SearchableComboBoxAudienceMetrics_Market.SelectedValue = ""
            Me.SearchableComboBoxAudienceMetrics_Market.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxAudienceMetrics_Market.TabIndex = 1
            '
            'SearchableComboBoxViewControl_PostPeriod
            '
            Me.SearchableComboBoxViewControl_PostPeriod.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_PostPeriod.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_PostPeriod.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_PostPeriod.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_PostPeriod.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_PostPeriod.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_PostPeriod.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_PostPeriod.Name = "SearchableComboBoxViewControl_PostPeriod"
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_PostPeriod.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_PostPeriod.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_PostPeriod.RunStandardValidation = True
            '
            'DateTimePickerAudienceMetrics_StartDate
            '
            Me.DateTimePickerAudienceMetrics_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerAudienceMetrics_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerAudienceMetrics_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerAudienceMetrics_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerAudienceMetrics_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerAudienceMetrics_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerAudienceMetrics_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerAudienceMetrics_StartDate.DisplayName = "Start Date"
            Me.DateTimePickerAudienceMetrics_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerAudienceMetrics_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerAudienceMetrics_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerAudienceMetrics_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerAudienceMetrics_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerAudienceMetrics_StartDate.Location = New System.Drawing.Point(293, 56)
            Me.DateTimePickerAudienceMetrics_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerAudienceMetrics_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerAudienceMetrics_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerAudienceMetrics_StartDate.Name = "DateTimePickerAudienceMetrics_StartDate"
            Me.DateTimePickerAudienceMetrics_StartDate.ReadOnly = False
            Me.DateTimePickerAudienceMetrics_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerAudienceMetrics_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerAudienceMetrics_StartDate.TabIndex = 17
            Me.DateTimePickerAudienceMetrics_StartDate.TabOnEnter = True
            Me.DateTimePickerAudienceMetrics_StartDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'TabItemUnitTests_AudienceMetrics
            '
            Me.TabItemUnitTests_AudienceMetrics.AttachedControl = Me.TabControlPanelAudienceMetrics_Criteria
            Me.TabItemUnitTests_AudienceMetrics.Name = "TabItemUnitTests_AudienceMetrics"
            Me.TabItemUnitTests_AudienceMetrics.Text = "Audience Metrics (Spots)"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.DataGridViewComscore_Results)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 34
            Me.TabControlPanel1.TabItem = Me.TabItemUnitTests_comScoreResults
            '
            'DataGridViewComscore_Results
            '
            Me.DataGridViewComscore_Results.AllowSelectGroupHeaderRow = True
            Me.DataGridViewComscore_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewComscore_Results.AutoUpdateViewCaption = True
            Me.DataGridViewComscore_Results.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewComscore_Results.ItemDescription = "Audience Metric(s)"
            Me.DataGridViewComscore_Results.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewComscore_Results.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewComscore_Results.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewComscore_Results.ModifyGridRowHeight = False
            Me.DataGridViewComscore_Results.MultiSelect = True
            Me.DataGridViewComscore_Results.Name = "DataGridViewComscore_Results"
            Me.DataGridViewComscore_Results.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewComscore_Results.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewComscore_Results.ShowRowSelectionIfHidden = True
            Me.DataGridViewComscore_Results.ShowSelectDeselectAllButtons = False
            Me.DataGridViewComscore_Results.Size = New System.Drawing.Size(1044, 586)
            Me.DataGridViewComscore_Results.TabIndex = 23
            Me.DataGridViewComscore_Results.UseEmbeddedNavigator = False
            Me.DataGridViewComscore_Results.ViewCaptionHeight = -1
            '
            'TabItemUnitTests_comScoreResults
            '
            Me.TabItemUnitTests_comScoreResults.AttachedControl = Me.TabControlPanel1
            Me.TabItemUnitTests_comScoreResults.Name = "TabItemUnitTests_comScoreResults"
            Me.TabItemUnitTests_comScoreResults.Text = "Comscore Results"
            '
            'TabControlPanelNational_Criteria
            '
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.GroupBoxNational_GroupBy)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.SearchableComboBoxNational_MarketBreak)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.SearchableComboBoxNational_Service)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DataGridViewNational_SelectedDemos)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DataGridViewNational_Results)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.ComboBoxNational_Stream)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.GroupBoxNational_Days)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.ComboBoxNational_TimeType)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_Media)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_Service)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_MarketBreak)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_TimeType)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_Stream)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_StartDate)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_EndDate)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_StartTime)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DateTimePickerNational_EndTime)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.LabelNational_EndTime)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DateTimePickerNational_StartTime)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DateTimePickerNational_EndDate)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.SearchableComboBoxNational_Media)
            Me.TabControlPanelNational_Criteria.Controls.Add(Me.DateTimePickerNational_StartDate)
            Me.TabControlPanelNational_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNational_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNational_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNational_Criteria.Name = "TabControlPanelNational_Criteria"
            Me.TabControlPanelNational_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNational_Criteria.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelNational_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNational_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNational_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNational_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNational_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNational_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelNational_Criteria.TabIndex = 4
            Me.TabControlPanelNational_Criteria.TabItem = Me.TabItemUnitTests_AudienceMetricsNational
            '
            'GroupBoxNational_GroupBy
            '
            Me.GroupBoxNational_GroupBy.Controls.Add(Me.RadioButtonGroupBy_Network)
            Me.GroupBoxNational_GroupBy.Controls.Add(Me.RadioButtonGroupBy_Date)
            Me.GroupBoxNational_GroupBy.Controls.Add(Me.RadioButtonGroupBy_None)
            Me.GroupBoxNational_GroupBy.Location = New System.Drawing.Point(12, 191)
            Me.GroupBoxNational_GroupBy.Name = "GroupBoxNational_GroupBy"
            Me.GroupBoxNational_GroupBy.Size = New System.Drawing.Size(362, 49)
            Me.GroupBoxNational_GroupBy.TabIndex = 23
            Me.GroupBoxNational_GroupBy.Text = "Group By"
            '
            'RadioButtonGroupBy_Network
            '
            Me.RadioButtonGroupBy_Network.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGroupBy_Network.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGroupBy_Network.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGroupBy_Network.Location = New System.Drawing.Point(217, 24)
            Me.RadioButtonGroupBy_Network.Name = "RadioButtonGroupBy_Network"
            Me.RadioButtonGroupBy_Network.SecurityEnabled = True
            Me.RadioButtonGroupBy_Network.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonGroupBy_Network.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGroupBy_Network.TabIndex = 2
            Me.RadioButtonGroupBy_Network.TabOnEnter = True
            Me.RadioButtonGroupBy_Network.TabStop = False
            Me.RadioButtonGroupBy_Network.Tag = ""
            Me.RadioButtonGroupBy_Network.Text = "Network"
            '
            'RadioButtonGroupBy_Date
            '
            Me.RadioButtonGroupBy_Date.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGroupBy_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGroupBy_Date.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGroupBy_Date.Location = New System.Drawing.Point(111, 24)
            Me.RadioButtonGroupBy_Date.Name = "RadioButtonGroupBy_Date"
            Me.RadioButtonGroupBy_Date.SecurityEnabled = True
            Me.RadioButtonGroupBy_Date.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonGroupBy_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGroupBy_Date.TabIndex = 1
            Me.RadioButtonGroupBy_Date.TabOnEnter = True
            Me.RadioButtonGroupBy_Date.TabStop = False
            Me.RadioButtonGroupBy_Date.Tag = ""
            Me.RadioButtonGroupBy_Date.Text = "Date"
            '
            'RadioButtonGroupBy_None
            '
            Me.RadioButtonGroupBy_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGroupBy_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGroupBy_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGroupBy_None.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonGroupBy_None.Name = "RadioButtonGroupBy_None"
            Me.RadioButtonGroupBy_None.SecurityEnabled = True
            Me.RadioButtonGroupBy_None.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonGroupBy_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGroupBy_None.TabIndex = 0
            Me.RadioButtonGroupBy_None.TabOnEnter = True
            Me.RadioButtonGroupBy_None.TabStop = False
            Me.RadioButtonGroupBy_None.Tag = ""
            Me.RadioButtonGroupBy_None.Text = "None"
            '
            'SearchableComboBoxNational_MarketBreak
            '
            Me.SearchableComboBoxNational_MarketBreak.ActiveFilterString = ""
            Me.SearchableComboBoxNational_MarketBreak.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxNational_MarketBreak.AutoFillMode = False
            Me.SearchableComboBoxNational_MarketBreak.BookmarkingEnabled = False
            Me.SearchableComboBoxNational_MarketBreak.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxNational_MarketBreak.DataSource = Nothing
            Me.SearchableComboBoxNational_MarketBreak.DisableMouseWheel = True
            Me.SearchableComboBoxNational_MarketBreak.DisplayName = ""
            Me.SearchableComboBoxNational_MarketBreak.EditValue = ""
            Me.SearchableComboBoxNational_MarketBreak.EnterMoveNextControl = True
            Me.SearchableComboBoxNational_MarketBreak.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxNational_MarketBreak.Location = New System.Drawing.Point(99, 56)
            Me.SearchableComboBoxNational_MarketBreak.Name = "SearchableComboBoxNational_MarketBreak"
            Me.SearchableComboBoxNational_MarketBreak.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxNational_MarketBreak.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxNational_MarketBreak.Properties.NullText = "Select Market Break"
            Me.SearchableComboBoxNational_MarketBreak.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxNational_MarketBreak.Properties.ShowClearButton = False
            Me.SearchableComboBoxNational_MarketBreak.Properties.ValueMember = "ID"
            Me.SearchableComboBoxNational_MarketBreak.SecurityEnabled = True
            Me.SearchableComboBoxNational_MarketBreak.SelectedValue = ""
            Me.SearchableComboBoxNational_MarketBreak.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxNational_MarketBreak.TabIndex = 5
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView4.OptionsBehavior.Editable = False
            Me.GridView4.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView4.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsSelection.MultiSelect = True
            Me.GridView4.OptionsView.ColumnAutoWidth = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            '
            'SearchableComboBoxNational_Service
            '
            Me.SearchableComboBoxNational_Service.ActiveFilterString = ""
            Me.SearchableComboBoxNational_Service.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxNational_Service.AutoFillMode = False
            Me.SearchableComboBoxNational_Service.BookmarkingEnabled = False
            Me.SearchableComboBoxNational_Service.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxNational_Service.DataSource = Nothing
            Me.SearchableComboBoxNational_Service.DisableMouseWheel = True
            Me.SearchableComboBoxNational_Service.DisplayName = ""
            Me.SearchableComboBoxNational_Service.EditValue = ""
            Me.SearchableComboBoxNational_Service.EnterMoveNextControl = True
            Me.SearchableComboBoxNational_Service.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxNational_Service.Location = New System.Drawing.Point(99, 30)
            Me.SearchableComboBoxNational_Service.Name = "SearchableComboBoxNational_Service"
            Me.SearchableComboBoxNational_Service.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxNational_Service.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxNational_Service.Properties.NullText = "Select Service"
            Me.SearchableComboBoxNational_Service.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxNational_Service.Properties.ShowClearButton = False
            Me.SearchableComboBoxNational_Service.Properties.ValueMember = "ID"
            Me.SearchableComboBoxNational_Service.SecurityEnabled = True
            Me.SearchableComboBoxNational_Service.SelectedValue = ""
            Me.SearchableComboBoxNational_Service.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxNational_Service.TabIndex = 3
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'DataGridViewNational_SelectedDemos
            '
            Me.DataGridViewNational_SelectedDemos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_SelectedDemos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_SelectedDemos.AutoUpdateViewCaption = True
            Me.DataGridViewNational_SelectedDemos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_SelectedDemos.ItemDescription = ""
            Me.DataGridViewNational_SelectedDemos.Location = New System.Drawing.Point(12, 247)
            Me.DataGridViewNational_SelectedDemos.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewNational_SelectedDemos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_SelectedDemos.ModifyGridRowHeight = False
            Me.DataGridViewNational_SelectedDemos.MultiSelect = True
            Me.DataGridViewNational_SelectedDemos.Name = "DataGridViewNational_SelectedDemos"
            Me.DataGridViewNational_SelectedDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_SelectedDemos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_SelectedDemos.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_SelectedDemos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_SelectedDemos.Size = New System.Drawing.Size(362, 345)
            Me.DataGridViewNational_SelectedDemos.TabIndex = 24
            Me.DataGridViewNational_SelectedDemos.UseEmbeddedNavigator = False
            Me.DataGridViewNational_SelectedDemos.ViewCaptionHeight = -1
            '
            'DataGridViewNational_Results
            '
            Me.DataGridViewNational_Results.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_Results.AutoUpdateViewCaption = True
            Me.DataGridViewNational_Results.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_Results.ItemDescription = "Audience Metric(s)"
            Me.DataGridViewNational_Results.Location = New System.Drawing.Point(382, 5)
            Me.DataGridViewNational_Results.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewNational_Results.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_Results.ModifyGridRowHeight = False
            Me.DataGridViewNational_Results.MultiSelect = True
            Me.DataGridViewNational_Results.Name = "DataGridViewNational_Results"
            Me.DataGridViewNational_Results.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_Results.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_Results.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_Results.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_Results.Size = New System.Drawing.Size(659, 587)
            Me.DataGridViewNational_Results.TabIndex = 25
            Me.DataGridViewNational_Results.UseEmbeddedNavigator = False
            Me.DataGridViewNational_Results.ViewCaptionHeight = -1
            '
            'ComboBoxNational_Stream
            '
            Me.ComboBoxNational_Stream.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNational_Stream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxNational_Stream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNational_Stream.AutoFindItemInDataSource = False
            Me.ComboBoxNational_Stream.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNational_Stream.BookmarkingEnabled = False
            Me.ComboBoxNational_Stream.DisableMouseWheel = True
            Me.ComboBoxNational_Stream.DisplayMember = "Display"
            Me.ComboBoxNational_Stream.DisplayName = "Stream"
            Me.ComboBoxNational_Stream.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNational_Stream.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxNational_Stream.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxNational_Stream.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNational_Stream.FocusHighlightEnabled = True
            Me.ComboBoxNational_Stream.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNational_Stream.FormattingEnabled = True
            Me.ComboBoxNational_Stream.ItemHeight = 16
            Me.ComboBoxNational_Stream.Location = New System.Drawing.Point(99, 108)
            Me.ComboBoxNational_Stream.Name = "ComboBoxNational_Stream"
            Me.ComboBoxNational_Stream.ReadOnly = False
            Me.ComboBoxNational_Stream.SecurityEnabled = True
            Me.ComboBoxNational_Stream.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxNational_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNational_Stream.TabIndex = 9
            Me.ComboBoxNational_Stream.TabOnEnter = True
            Me.ComboBoxNational_Stream.ValueMember = "Value"
            Me.ComboBoxNational_Stream.WatermarkText = "Select"
            '
            'GroupBoxNational_Days
            '
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Fri)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Sat)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Sun)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Thu)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Mon)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Tue)
            Me.GroupBoxNational_Days.Controls.Add(Me.CheckBoxNationalDays_Wed)
            Me.GroupBoxNational_Days.Location = New System.Drawing.Point(12, 136)
            Me.GroupBoxNational_Days.Name = "GroupBoxNational_Days"
            Me.GroupBoxNational_Days.Size = New System.Drawing.Size(362, 49)
            Me.GroupBoxNational_Days.TabIndex = 22
            Me.GroupBoxNational_Days.Text = "Days"
            '
            'CheckBoxNationalDays_Fri
            '
            Me.CheckBoxNationalDays_Fri.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Fri.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Fri.CheckValue = 0
            Me.CheckBoxNationalDays_Fri.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Fri.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Fri.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Fri.ChildControls = Nothing
            Me.CheckBoxNationalDays_Fri.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Fri.Location = New System.Drawing.Point(201, 24)
            Me.CheckBoxNationalDays_Fri.Name = "CheckBoxNationalDays_Fri"
            Me.CheckBoxNationalDays_Fri.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Fri.SecurityEnabled = True
            Me.CheckBoxNationalDays_Fri.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Fri.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Fri.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Fri.TabIndex = 4
            Me.CheckBoxNationalDays_Fri.TabOnEnter = True
            Me.CheckBoxNationalDays_Fri.Text = "Fri"
            '
            'CheckBoxNationalDays_Sat
            '
            Me.CheckBoxNationalDays_Sat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Sat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Sat.CheckValue = 0
            Me.CheckBoxNationalDays_Sat.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Sat.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Sat.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Sat.ChildControls = Nothing
            Me.CheckBoxNationalDays_Sat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Sat.Location = New System.Drawing.Point(250, 24)
            Me.CheckBoxNationalDays_Sat.Name = "CheckBoxNationalDays_Sat"
            Me.CheckBoxNationalDays_Sat.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Sat.SecurityEnabled = True
            Me.CheckBoxNationalDays_Sat.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Sat.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Sat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Sat.TabIndex = 5
            Me.CheckBoxNationalDays_Sat.TabOnEnter = True
            Me.CheckBoxNationalDays_Sat.Text = "Sat"
            '
            'CheckBoxNationalDays_Sun
            '
            Me.CheckBoxNationalDays_Sun.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Sun.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Sun.CheckValue = 0
            Me.CheckBoxNationalDays_Sun.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Sun.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Sun.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Sun.ChildControls = Nothing
            Me.CheckBoxNationalDays_Sun.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Sun.Location = New System.Drawing.Point(299, 24)
            Me.CheckBoxNationalDays_Sun.Name = "CheckBoxNationalDays_Sun"
            Me.CheckBoxNationalDays_Sun.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Sun.SecurityEnabled = True
            Me.CheckBoxNationalDays_Sun.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Sun.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Sun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Sun.TabIndex = 6
            Me.CheckBoxNationalDays_Sun.TabOnEnter = True
            Me.CheckBoxNationalDays_Sun.Text = "Sun"
            '
            'CheckBoxNationalDays_Thu
            '
            Me.CheckBoxNationalDays_Thu.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Thu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Thu.CheckValue = 0
            Me.CheckBoxNationalDays_Thu.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Thu.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Thu.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Thu.ChildControls = Nothing
            Me.CheckBoxNationalDays_Thu.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Thu.Location = New System.Drawing.Point(152, 24)
            Me.CheckBoxNationalDays_Thu.Name = "CheckBoxNationalDays_Thu"
            Me.CheckBoxNationalDays_Thu.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Thu.SecurityEnabled = True
            Me.CheckBoxNationalDays_Thu.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Thu.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Thu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Thu.TabIndex = 3
            Me.CheckBoxNationalDays_Thu.TabOnEnter = True
            Me.CheckBoxNationalDays_Thu.Text = "Thu"
            '
            'CheckBoxNationalDays_Mon
            '
            Me.CheckBoxNationalDays_Mon.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Mon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Mon.CheckValue = 0
            Me.CheckBoxNationalDays_Mon.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Mon.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Mon.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Mon.ChildControls = Nothing
            Me.CheckBoxNationalDays_Mon.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Mon.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxNationalDays_Mon.Name = "CheckBoxNationalDays_Mon"
            Me.CheckBoxNationalDays_Mon.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Mon.SecurityEnabled = True
            Me.CheckBoxNationalDays_Mon.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Mon.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Mon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Mon.TabIndex = 0
            Me.CheckBoxNationalDays_Mon.TabOnEnter = True
            Me.CheckBoxNationalDays_Mon.Text = "Mon"
            '
            'CheckBoxNationalDays_Tue
            '
            Me.CheckBoxNationalDays_Tue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Tue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Tue.CheckValue = 0
            Me.CheckBoxNationalDays_Tue.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Tue.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Tue.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Tue.ChildControls = Nothing
            Me.CheckBoxNationalDays_Tue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Tue.Location = New System.Drawing.Point(54, 24)
            Me.CheckBoxNationalDays_Tue.Name = "CheckBoxNationalDays_Tue"
            Me.CheckBoxNationalDays_Tue.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Tue.SecurityEnabled = True
            Me.CheckBoxNationalDays_Tue.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Tue.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Tue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Tue.TabIndex = 1
            Me.CheckBoxNationalDays_Tue.TabOnEnter = True
            Me.CheckBoxNationalDays_Tue.Text = "Tue"
            '
            'CheckBoxNationalDays_Wed
            '
            Me.CheckBoxNationalDays_Wed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDays_Wed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDays_Wed.CheckValue = 0
            Me.CheckBoxNationalDays_Wed.CheckValueChecked = 1
            Me.CheckBoxNationalDays_Wed.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDays_Wed.CheckValueUnchecked = 0
            Me.CheckBoxNationalDays_Wed.ChildControls = Nothing
            Me.CheckBoxNationalDays_Wed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDays_Wed.Location = New System.Drawing.Point(103, 24)
            Me.CheckBoxNationalDays_Wed.Name = "CheckBoxNationalDays_Wed"
            Me.CheckBoxNationalDays_Wed.OldestSibling = Nothing
            Me.CheckBoxNationalDays_Wed.SecurityEnabled = True
            Me.CheckBoxNationalDays_Wed.SiblingControls = Nothing
            Me.CheckBoxNationalDays_Wed.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxNationalDays_Wed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDays_Wed.TabIndex = 2
            Me.CheckBoxNationalDays_Wed.TabOnEnter = True
            Me.CheckBoxNationalDays_Wed.Text = "Wed"
            '
            'ComboBoxNational_TimeType
            '
            Me.ComboBoxNational_TimeType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNational_TimeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxNational_TimeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNational_TimeType.AutoFindItemInDataSource = False
            Me.ComboBoxNational_TimeType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNational_TimeType.BookmarkingEnabled = False
            Me.ComboBoxNational_TimeType.DisableMouseWheel = True
            Me.ComboBoxNational_TimeType.DisplayMember = "Display"
            Me.ComboBoxNational_TimeType.DisplayName = "Time Type"
            Me.ComboBoxNational_TimeType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNational_TimeType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxNational_TimeType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxNational_TimeType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNational_TimeType.FocusHighlightEnabled = True
            Me.ComboBoxNational_TimeType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNational_TimeType.FormattingEnabled = True
            Me.ComboBoxNational_TimeType.ItemHeight = 16
            Me.ComboBoxNational_TimeType.Location = New System.Drawing.Point(99, 82)
            Me.ComboBoxNational_TimeType.Name = "ComboBoxNational_TimeType"
            Me.ComboBoxNational_TimeType.ReadOnly = False
            Me.ComboBoxNational_TimeType.SecurityEnabled = True
            Me.ComboBoxNational_TimeType.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxNational_TimeType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNational_TimeType.TabIndex = 7
            Me.ComboBoxNational_TimeType.TabOnEnter = True
            Me.ComboBoxNational_TimeType.ValueMember = "Value"
            Me.ComboBoxNational_TimeType.WatermarkText = "Select"
            '
            'LabelNational_Media
            '
            Me.LabelNational_Media.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_Media.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_Media.Location = New System.Drawing.Point(12, 4)
            Me.LabelNational_Media.Name = "LabelNational_Media"
            Me.LabelNational_Media.Size = New System.Drawing.Size(81, 20)
            Me.LabelNational_Media.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_Media.TabIndex = 0
            Me.LabelNational_Media.Text = "Media:"
            '
            'LabelNational_Service
            '
            Me.LabelNational_Service.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_Service.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_Service.Location = New System.Drawing.Point(12, 30)
            Me.LabelNational_Service.Name = "LabelNational_Service"
            Me.LabelNational_Service.Size = New System.Drawing.Size(81, 20)
            Me.LabelNational_Service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_Service.TabIndex = 2
            Me.LabelNational_Service.Text = "Service:"
            '
            'LabelNational_MarketBreak
            '
            Me.LabelNational_MarketBreak.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_MarketBreak.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_MarketBreak.Location = New System.Drawing.Point(12, 56)
            Me.LabelNational_MarketBreak.Name = "LabelNational_MarketBreak"
            Me.LabelNational_MarketBreak.Size = New System.Drawing.Size(81, 20)
            Me.LabelNational_MarketBreak.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_MarketBreak.TabIndex = 4
            Me.LabelNational_MarketBreak.Text = "Market Break:"
            '
            'LabelNational_TimeType
            '
            Me.LabelNational_TimeType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_TimeType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_TimeType.Location = New System.Drawing.Point(12, 82)
            Me.LabelNational_TimeType.Name = "LabelNational_TimeType"
            Me.LabelNational_TimeType.Size = New System.Drawing.Size(81, 20)
            Me.LabelNational_TimeType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_TimeType.TabIndex = 6
            Me.LabelNational_TimeType.Text = "Time Type:"
            '
            'LabelNational_Stream
            '
            Me.LabelNational_Stream.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_Stream.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_Stream.Location = New System.Drawing.Point(12, 108)
            Me.LabelNational_Stream.Name = "LabelNational_Stream"
            Me.LabelNational_Stream.Size = New System.Drawing.Size(81, 20)
            Me.LabelNational_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_Stream.TabIndex = 8
            Me.LabelNational_Stream.Text = "Stream:"
            '
            'LabelNational_StartDate
            '
            Me.LabelNational_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_StartDate.Location = New System.Drawing.Point(224, 4)
            Me.LabelNational_StartDate.Name = "LabelNational_StartDate"
            Me.LabelNational_StartDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelNational_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_StartDate.TabIndex = 14
            Me.LabelNational_StartDate.Text = "Start Date:"
            '
            'LabelNational_EndDate
            '
            Me.LabelNational_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_EndDate.Location = New System.Drawing.Point(224, 30)
            Me.LabelNational_EndDate.Name = "LabelNational_EndDate"
            Me.LabelNational_EndDate.Size = New System.Drawing.Size(63, 20)
            Me.LabelNational_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_EndDate.TabIndex = 16
            Me.LabelNational_EndDate.Text = "End Date:"
            '
            'LabelNational_StartTime
            '
            Me.LabelNational_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_StartTime.Location = New System.Drawing.Point(224, 56)
            Me.LabelNational_StartTime.Name = "LabelNational_StartTime"
            Me.LabelNational_StartTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelNational_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_StartTime.TabIndex = 18
            Me.LabelNational_StartTime.Text = "Start Time:"
            '
            'DateTimePickerNational_EndTime
            '
            Me.DateTimePickerNational_EndTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNational_EndTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNational_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNational_EndTime.ButtonFreeText.Checked = True
            Me.DateTimePickerNational_EndTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerNational_EndTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerNational_EndTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNational_EndTime.DisplayName = "End Time"
            Me.DateTimePickerNational_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNational_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNational_EndTime.FocusHighlightEnabled = True
            Me.DateTimePickerNational_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerNational_EndTime.FreeTextEntryMode = True
            Me.DateTimePickerNational_EndTime.IsPopupCalendarOpen = False
            Me.DateTimePickerNational_EndTime.Location = New System.Drawing.Point(293, 82)
            Me.DateTimePickerNational_EndTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNational_EndTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNational_EndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNational_EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNational_EndTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNational_EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNational_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNational_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNational_EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNational_EndTime.MonthCalendar.Visible = False
            Me.DateTimePickerNational_EndTime.Name = "DateTimePickerNational_EndTime"
            Me.DateTimePickerNational_EndTime.ReadOnly = False
            Me.DateTimePickerNational_EndTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerNational_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNational_EndTime.TabIndex = 21
            Me.DateTimePickerNational_EndTime.TabOnEnter = True
            Me.DateTimePickerNational_EndTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerNational_EndTime.Value = New Date(2017, 1, 13, 11, 26, 32, 251)
            '
            'LabelNational_EndTime
            '
            Me.LabelNational_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNational_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNational_EndTime.Location = New System.Drawing.Point(224, 82)
            Me.LabelNational_EndTime.Name = "LabelNational_EndTime"
            Me.LabelNational_EndTime.Size = New System.Drawing.Size(63, 20)
            Me.LabelNational_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNational_EndTime.TabIndex = 20
            Me.LabelNational_EndTime.Text = "End Time:"
            '
            'DateTimePickerNational_StartTime
            '
            Me.DateTimePickerNational_StartTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNational_StartTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNational_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNational_StartTime.ButtonFreeText.Checked = True
            Me.DateTimePickerNational_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerNational_StartTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerNational_StartTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNational_StartTime.DisplayName = "Start Time"
            Me.DateTimePickerNational_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNational_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNational_StartTime.FocusHighlightEnabled = True
            Me.DateTimePickerNational_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerNational_StartTime.FreeTextEntryMode = True
            Me.DateTimePickerNational_StartTime.IsPopupCalendarOpen = False
            Me.DateTimePickerNational_StartTime.Location = New System.Drawing.Point(293, 56)
            Me.DateTimePickerNational_StartTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNational_StartTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNational_StartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNational_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNational_StartTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNational_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNational_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNational_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNational_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNational_StartTime.MonthCalendar.Visible = False
            Me.DateTimePickerNational_StartTime.Name = "DateTimePickerNational_StartTime"
            Me.DateTimePickerNational_StartTime.ReadOnly = False
            Me.DateTimePickerNational_StartTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerNational_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNational_StartTime.TabIndex = 19
            Me.DateTimePickerNational_StartTime.TabOnEnter = True
            Me.DateTimePickerNational_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerNational_StartTime.Value = New Date(2017, 1, 13, 11, 26, 28, 875)
            '
            'DateTimePickerNational_EndDate
            '
            Me.DateTimePickerNational_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNational_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNational_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNational_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerNational_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerNational_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNational_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNational_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNational_EndDate.DisplayName = "End Date"
            Me.DateTimePickerNational_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNational_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNational_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerNational_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerNational_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerNational_EndDate.Location = New System.Drawing.Point(293, 30)
            Me.DateTimePickerNational_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNational_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNational_EndDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNational_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNational_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNational_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNational_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNational_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNational_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNational_EndDate.Name = "DateTimePickerNational_EndDate"
            Me.DateTimePickerNational_EndDate.ReadOnly = False
            Me.DateTimePickerNational_EndDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerNational_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNational_EndDate.TabIndex = 17
            Me.DateTimePickerNational_EndDate.TabOnEnter = True
            Me.DateTimePickerNational_EndDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'SearchableComboBoxNational_Media
            '
            Me.SearchableComboBoxNational_Media.ActiveFilterString = ""
            Me.SearchableComboBoxNational_Media.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxNational_Media.AutoFillMode = False
            Me.SearchableComboBoxNational_Media.BookmarkingEnabled = False
            Me.SearchableComboBoxNational_Media.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxNational_Media.DataSource = Nothing
            Me.SearchableComboBoxNational_Media.DisableMouseWheel = True
            Me.SearchableComboBoxNational_Media.DisplayName = ""
            Me.SearchableComboBoxNational_Media.EditValue = ""
            Me.SearchableComboBoxNational_Media.EnterMoveNextControl = True
            Me.SearchableComboBoxNational_Media.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxNational_Media.Location = New System.Drawing.Point(99, 4)
            Me.SearchableComboBoxNational_Media.Name = "SearchableComboBoxNational_Media"
            Me.SearchableComboBoxNational_Media.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxNational_Media.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxNational_Media.Properties.NullText = "Select Media"
            Me.SearchableComboBoxNational_Media.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxNational_Media.Properties.ShowClearButton = False
            Me.SearchableComboBoxNational_Media.Properties.ValueMember = "ID"
            Me.SearchableComboBoxNational_Media.SecurityEnabled = True
            Me.SearchableComboBoxNational_Media.SelectedValue = ""
            Me.SearchableComboBoxNational_Media.Size = New System.Drawing.Size(119, 20)
            Me.SearchableComboBoxNational_Media.TabIndex = 1
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.Editable = False
            Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsSelection.MultiSelect = True
            Me.GridView3.OptionsView.ColumnAutoWidth = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            '
            'DateTimePickerNational_StartDate
            '
            Me.DateTimePickerNational_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNational_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNational_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNational_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerNational_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerNational_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNational_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNational_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNational_StartDate.DisplayName = "Start Date"
            Me.DateTimePickerNational_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNational_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNational_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerNational_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerNational_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerNational_StartDate.Location = New System.Drawing.Point(293, 4)
            Me.DateTimePickerNational_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNational_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNational_StartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerNational_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNational_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNational_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNational_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNational_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNational_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNational_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNational_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNational_StartDate.Name = "DateTimePickerNational_StartDate"
            Me.DateTimePickerNational_StartDate.ReadOnly = False
            Me.DateTimePickerNational_StartDate.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerNational_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNational_StartDate.TabIndex = 15
            Me.DateTimePickerNational_StartDate.TabOnEnter = True
            Me.DateTimePickerNational_StartDate.Value = New Date(2017, 1, 13, 11, 25, 50, 65)
            '
            'TabItemUnitTests_AudienceMetricsNational
            '
            Me.TabItemUnitTests_AudienceMetricsNational.AttachedControl = Me.TabControlPanelNational_Criteria
            Me.TabItemUnitTests_AudienceMetricsNational.Name = "TabItemUnitTests_AudienceMetricsNational"
            Me.TabItemUnitTests_AudienceMetricsNational.Text = "Audience Metrics (National)"
            '
            'TabControlPanelRadio_Criteria
            '
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.GroupBox1)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_StartTime)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.DateTimePickerRadio_EndTime)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_EndTime)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.DateTimePickerRadio_StartTime)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.SearchableComboBoxRadio_Station)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_StationOrCombo)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.DataGridViewRadio_Results)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.DataGridViewRadio_SelectedDemos)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_Geography)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.SearchableComboBoxRadio_Geography)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_Market)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.SearchableComboBoxRadio_Market)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.LabelRadio_Period)
            Me.TabControlPanelRadio_Criteria.Controls.Add(Me.SearchableComboBoxRadio_Period)
            Me.TabControlPanelRadio_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadio_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadio_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadio_Criteria.Name = "TabControlPanelRadio_Criteria"
            Me.TabControlPanelRadio_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadio_Criteria.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelRadio_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadio_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadio_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadio_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadio_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadio_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelRadio_Criteria.TabIndex = 11
            Me.TabControlPanelRadio_Criteria.TabItem = Me.TabItemUnitTests_AudienceMetricsRadio
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Friday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Saturday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Sunday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Thursday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Monday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Tuesday)
            Me.GroupBox1.Controls.Add(Me.CheckRadio_Wednesday)
            Me.GroupBox1.Location = New System.Drawing.Point(13, 108)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(362, 49)
            Me.GroupBox1.TabIndex = 23
            Me.GroupBox1.Text = "Days"
            '
            'CheckRadio_Friday
            '
            Me.CheckRadio_Friday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Friday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Friday.CheckValue = 0
            Me.CheckRadio_Friday.CheckValueChecked = 1
            Me.CheckRadio_Friday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Friday.CheckValueUnchecked = 0
            Me.CheckRadio_Friday.ChildControls = Nothing
            Me.CheckRadio_Friday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Friday.Location = New System.Drawing.Point(201, 24)
            Me.CheckRadio_Friday.Name = "CheckRadio_Friday"
            Me.CheckRadio_Friday.OldestSibling = Nothing
            Me.CheckRadio_Friday.SecurityEnabled = True
            Me.CheckRadio_Friday.SiblingControls = Nothing
            Me.CheckRadio_Friday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Friday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Friday.TabIndex = 4
            Me.CheckRadio_Friday.TabOnEnter = True
            Me.CheckRadio_Friday.Text = "Fri"
            '
            'CheckRadio_Saturday
            '
            Me.CheckRadio_Saturday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Saturday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Saturday.CheckValue = 0
            Me.CheckRadio_Saturday.CheckValueChecked = 1
            Me.CheckRadio_Saturday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Saturday.CheckValueUnchecked = 0
            Me.CheckRadio_Saturday.ChildControls = Nothing
            Me.CheckRadio_Saturday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Saturday.Location = New System.Drawing.Point(250, 24)
            Me.CheckRadio_Saturday.Name = "CheckRadio_Saturday"
            Me.CheckRadio_Saturday.OldestSibling = Nothing
            Me.CheckRadio_Saturday.SecurityEnabled = True
            Me.CheckRadio_Saturday.SiblingControls = Nothing
            Me.CheckRadio_Saturday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Saturday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Saturday.TabIndex = 5
            Me.CheckRadio_Saturday.TabOnEnter = True
            Me.CheckRadio_Saturday.Text = "Sat"
            '
            'CheckRadio_Sunday
            '
            Me.CheckRadio_Sunday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Sunday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Sunday.CheckValue = 0
            Me.CheckRadio_Sunday.CheckValueChecked = 1
            Me.CheckRadio_Sunday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Sunday.CheckValueUnchecked = 0
            Me.CheckRadio_Sunday.ChildControls = Nothing
            Me.CheckRadio_Sunday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Sunday.Location = New System.Drawing.Point(299, 24)
            Me.CheckRadio_Sunday.Name = "CheckRadio_Sunday"
            Me.CheckRadio_Sunday.OldestSibling = Nothing
            Me.CheckRadio_Sunday.SecurityEnabled = True
            Me.CheckRadio_Sunday.SiblingControls = Nothing
            Me.CheckRadio_Sunday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Sunday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Sunday.TabIndex = 6
            Me.CheckRadio_Sunday.TabOnEnter = True
            Me.CheckRadio_Sunday.Text = "Sun"
            '
            'CheckRadio_Thursday
            '
            Me.CheckRadio_Thursday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Thursday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Thursday.CheckValue = 0
            Me.CheckRadio_Thursday.CheckValueChecked = 1
            Me.CheckRadio_Thursday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Thursday.CheckValueUnchecked = 0
            Me.CheckRadio_Thursday.ChildControls = Nothing
            Me.CheckRadio_Thursday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Thursday.Location = New System.Drawing.Point(152, 24)
            Me.CheckRadio_Thursday.Name = "CheckRadio_Thursday"
            Me.CheckRadio_Thursday.OldestSibling = Nothing
            Me.CheckRadio_Thursday.SecurityEnabled = True
            Me.CheckRadio_Thursday.SiblingControls = Nothing
            Me.CheckRadio_Thursday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Thursday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Thursday.TabIndex = 3
            Me.CheckRadio_Thursday.TabOnEnter = True
            Me.CheckRadio_Thursday.Text = "Thu"
            '
            'CheckRadio_Monday
            '
            Me.CheckRadio_Monday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Monday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Monday.CheckValue = 0
            Me.CheckRadio_Monday.CheckValueChecked = 1
            Me.CheckRadio_Monday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Monday.CheckValueUnchecked = 0
            Me.CheckRadio_Monday.ChildControls = Nothing
            Me.CheckRadio_Monday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Monday.Location = New System.Drawing.Point(5, 24)
            Me.CheckRadio_Monday.Name = "CheckRadio_Monday"
            Me.CheckRadio_Monday.OldestSibling = Nothing
            Me.CheckRadio_Monday.SecurityEnabled = True
            Me.CheckRadio_Monday.SiblingControls = Nothing
            Me.CheckRadio_Monday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Monday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Monday.TabIndex = 0
            Me.CheckRadio_Monday.TabOnEnter = True
            Me.CheckRadio_Monday.Text = "Mon"
            '
            'CheckRadio_Tuesday
            '
            Me.CheckRadio_Tuesday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Tuesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Tuesday.CheckValue = 0
            Me.CheckRadio_Tuesday.CheckValueChecked = 1
            Me.CheckRadio_Tuesday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Tuesday.CheckValueUnchecked = 0
            Me.CheckRadio_Tuesday.ChildControls = Nothing
            Me.CheckRadio_Tuesday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Tuesday.Location = New System.Drawing.Point(54, 24)
            Me.CheckRadio_Tuesday.Name = "CheckRadio_Tuesday"
            Me.CheckRadio_Tuesday.OldestSibling = Nothing
            Me.CheckRadio_Tuesday.SecurityEnabled = True
            Me.CheckRadio_Tuesday.SiblingControls = Nothing
            Me.CheckRadio_Tuesday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Tuesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Tuesday.TabIndex = 1
            Me.CheckRadio_Tuesday.TabOnEnter = True
            Me.CheckRadio_Tuesday.Text = "Tue"
            '
            'CheckRadio_Wednesday
            '
            Me.CheckRadio_Wednesday.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckRadio_Wednesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckRadio_Wednesday.CheckValue = 0
            Me.CheckRadio_Wednesday.CheckValueChecked = 1
            Me.CheckRadio_Wednesday.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckRadio_Wednesday.CheckValueUnchecked = 0
            Me.CheckRadio_Wednesday.ChildControls = Nothing
            Me.CheckRadio_Wednesday.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckRadio_Wednesday.Location = New System.Drawing.Point(103, 24)
            Me.CheckRadio_Wednesday.Name = "CheckRadio_Wednesday"
            Me.CheckRadio_Wednesday.OldestSibling = Nothing
            Me.CheckRadio_Wednesday.SecurityEnabled = True
            Me.CheckRadio_Wednesday.SiblingControls = Nothing
            Me.CheckRadio_Wednesday.Size = New System.Drawing.Size(43, 20)
            Me.CheckRadio_Wednesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckRadio_Wednesday.TabIndex = 2
            Me.CheckRadio_Wednesday.TabOnEnter = True
            Me.CheckRadio_Wednesday.Text = "Wed"
            '
            'LabelRadio_StartTime
            '
            Me.LabelRadio_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_StartTime.Location = New System.Drawing.Point(13, 163)
            Me.LabelRadio_StartTime.Name = "LabelRadio_StartTime"
            Me.LabelRadio_StartTime.Size = New System.Drawing.Size(80, 20)
            Me.LabelRadio_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_StartTime.TabIndex = 11
            Me.LabelRadio_StartTime.Text = "Start Time:"
            '
            'DateTimePickerRadio_EndTime
            '
            Me.DateTimePickerRadio_EndTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerRadio_EndTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerRadio_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_EndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerRadio_EndTime.ButtonFreeText.Checked = True
            Me.DateTimePickerRadio_EndTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerRadio_EndTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerRadio_EndTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerRadio_EndTime.DisplayName = "End Time"
            Me.DateTimePickerRadio_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerRadio_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerRadio_EndTime.FocusHighlightEnabled = True
            Me.DateTimePickerRadio_EndTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerRadio_EndTime.FreeTextEntryMode = True
            Me.DateTimePickerRadio_EndTime.IsPopupCalendarOpen = False
            Me.DateTimePickerRadio_EndTime.Location = New System.Drawing.Point(294, 163)
            Me.DateTimePickerRadio_EndTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerRadio_EndTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerRadio_EndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerRadio_EndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerRadio_EndTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerRadio_EndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_EndTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerRadio_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerRadio_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRadio_EndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerRadio_EndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_EndTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerRadio_EndTime.MonthCalendar.Visible = False
            Me.DateTimePickerRadio_EndTime.Name = "DateTimePickerRadio_EndTime"
            Me.DateTimePickerRadio_EndTime.ReadOnly = False
            Me.DateTimePickerRadio_EndTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerRadio_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerRadio_EndTime.TabIndex = 14
            Me.DateTimePickerRadio_EndTime.TabOnEnter = True
            Me.DateTimePickerRadio_EndTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerRadio_EndTime.Value = New Date(2017, 1, 13, 11, 26, 32, 251)
            '
            'LabelRadio_EndTime
            '
            Me.LabelRadio_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_EndTime.Location = New System.Drawing.Point(208, 163)
            Me.LabelRadio_EndTime.Name = "LabelRadio_EndTime"
            Me.LabelRadio_EndTime.Size = New System.Drawing.Size(80, 20)
            Me.LabelRadio_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_EndTime.TabIndex = 13
            Me.LabelRadio_EndTime.Text = "End Time:"
            '
            'DateTimePickerRadio_StartTime
            '
            Me.DateTimePickerRadio_StartTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerRadio_StartTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerRadio_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_StartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerRadio_StartTime.ButtonFreeText.Checked = True
            Me.DateTimePickerRadio_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerRadio_StartTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerRadio_StartTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerRadio_StartTime.DisplayName = "Start Time"
            Me.DateTimePickerRadio_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerRadio_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerRadio_StartTime.FocusHighlightEnabled = True
            Me.DateTimePickerRadio_StartTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerRadio_StartTime.FreeTextEntryMode = True
            Me.DateTimePickerRadio_StartTime.IsPopupCalendarOpen = False
            Me.DateTimePickerRadio_StartTime.Location = New System.Drawing.Point(100, 163)
            Me.DateTimePickerRadio_StartTime.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerRadio_StartTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerRadio_StartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerRadio_StartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerRadio_StartTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerRadio_StartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_StartTime.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerRadio_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerRadio_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerRadio_StartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerRadio_StartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerRadio_StartTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerRadio_StartTime.MonthCalendar.Visible = False
            Me.DateTimePickerRadio_StartTime.Name = "DateTimePickerRadio_StartTime"
            Me.DateTimePickerRadio_StartTime.ReadOnly = False
            Me.DateTimePickerRadio_StartTime.Size = New System.Drawing.Size(81, 20)
            Me.DateTimePickerRadio_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerRadio_StartTime.TabIndex = 12
            Me.DateTimePickerRadio_StartTime.TabOnEnter = True
            Me.DateTimePickerRadio_StartTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerRadio_StartTime.Value = New Date(2017, 1, 13, 11, 26, 28, 875)
            '
            'SearchableComboBoxRadio_Station
            '
            Me.SearchableComboBoxRadio_Station.ActiveFilterString = ""
            Me.SearchableComboBoxRadio_Station.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRadio_Station.AutoFillMode = False
            Me.SearchableComboBoxRadio_Station.BookmarkingEnabled = False
            Me.SearchableComboBoxRadio_Station.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioStation
            Me.SearchableComboBoxRadio_Station.DataSource = Nothing
            Me.SearchableComboBoxRadio_Station.DisableMouseWheel = True
            Me.SearchableComboBoxRadio_Station.DisplayName = ""
            Me.SearchableComboBoxRadio_Station.EditValue = ""
            Me.SearchableComboBoxRadio_Station.EnterMoveNextControl = True
            Me.SearchableComboBoxRadio_Station.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxRadio_Station.Location = New System.Drawing.Point(100, 82)
            Me.SearchableComboBoxRadio_Station.Name = "SearchableComboBoxRadio_Station"
            Me.SearchableComboBoxRadio_Station.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRadio_Station.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRadio_Station.Properties.NullText = "Select Station"
            Me.SearchableComboBoxRadio_Station.Properties.PopupView = Me.GridView13
            Me.SearchableComboBoxRadio_Station.Properties.ShowClearButton = False
            Me.SearchableComboBoxRadio_Station.Properties.ValueMember = "ComboID"
            Me.SearchableComboBoxRadio_Station.SecurityEnabled = True
            Me.SearchableComboBoxRadio_Station.SelectedValue = ""
            Me.SearchableComboBoxRadio_Station.Size = New System.Drawing.Size(275, 20)
            Me.SearchableComboBoxRadio_Station.TabIndex = 8
            '
            'GridView13
            '
            Me.GridView13.AFActiveFilterString = ""
            Me.GridView13.AllowExtraItemsInGridLookupEdits = True
            Me.GridView13.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView13.AutoFilterLookupColumns = False
            Me.GridView13.AutoloadRepositoryDatasource = True
            Me.GridView13.DataSourceClearing = False
            Me.GridView13.EnableDisabledRows = False
            Me.GridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView13.Name = "GridView13"
            Me.GridView13.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView13.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView13.OptionsBehavior.Editable = False
            Me.GridView13.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView13.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView13.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView13.OptionsSelection.MultiSelect = True
            Me.GridView13.OptionsView.ColumnAutoWidth = False
            Me.GridView13.OptionsView.ShowGroupPanel = False
            Me.GridView13.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView13.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView13.RunStandardValidation = True
            '
            'LabelRadio_StationOrCombo
            '
            Me.LabelRadio_StationOrCombo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_StationOrCombo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_StationOrCombo.Location = New System.Drawing.Point(13, 82)
            Me.LabelRadio_StationOrCombo.Name = "LabelRadio_StationOrCombo"
            Me.LabelRadio_StationOrCombo.Size = New System.Drawing.Size(81, 20)
            Me.LabelRadio_StationOrCombo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_StationOrCombo.TabIndex = 7
            Me.LabelRadio_StationOrCombo.Text = "Station:"
            '
            'DataGridViewRadio_Results
            '
            Me.DataGridViewRadio_Results.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRadio_Results.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRadio_Results.AutoUpdateViewCaption = True
            Me.DataGridViewRadio_Results.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRadio_Results.ItemDescription = "Audience Metric(s)"
            Me.DataGridViewRadio_Results.Location = New System.Drawing.Point(382, 5)
            Me.DataGridViewRadio_Results.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRadio_Results.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRadio_Results.ModifyGridRowHeight = False
            Me.DataGridViewRadio_Results.MultiSelect = True
            Me.DataGridViewRadio_Results.Name = "DataGridViewRadio_Results"
            Me.DataGridViewRadio_Results.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRadio_Results.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRadio_Results.ShowRowSelectionIfHidden = True
            Me.DataGridViewRadio_Results.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRadio_Results.Size = New System.Drawing.Size(659, 587)
            Me.DataGridViewRadio_Results.TabIndex = 21
            Me.DataGridViewRadio_Results.UseEmbeddedNavigator = False
            Me.DataGridViewRadio_Results.ViewCaptionHeight = -1
            '
            'DataGridViewRadio_SelectedDemos
            '
            Me.DataGridViewRadio_SelectedDemos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRadio_SelectedDemos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRadio_SelectedDemos.AutoUpdateViewCaption = True
            Me.DataGridViewRadio_SelectedDemos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRadio_SelectedDemos.ItemDescription = ""
            Me.DataGridViewRadio_SelectedDemos.Location = New System.Drawing.Point(12, 190)
            Me.DataGridViewRadio_SelectedDemos.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRadio_SelectedDemos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRadio_SelectedDemos.ModifyGridRowHeight = False
            Me.DataGridViewRadio_SelectedDemos.MultiSelect = True
            Me.DataGridViewRadio_SelectedDemos.Name = "DataGridViewRadio_SelectedDemos"
            Me.DataGridViewRadio_SelectedDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRadio_SelectedDemos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRadio_SelectedDemos.ShowRowSelectionIfHidden = True
            Me.DataGridViewRadio_SelectedDemos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRadio_SelectedDemos.Size = New System.Drawing.Size(362, 402)
            Me.DataGridViewRadio_SelectedDemos.TabIndex = 15
            Me.DataGridViewRadio_SelectedDemos.UseEmbeddedNavigator = False
            Me.DataGridViewRadio_SelectedDemos.ViewCaptionHeight = -1
            '
            'LabelRadio_Geography
            '
            Me.LabelRadio_Geography.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_Geography.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_Geography.Location = New System.Drawing.Point(11, 56)
            Me.LabelRadio_Geography.Name = "LabelRadio_Geography"
            Me.LabelRadio_Geography.Size = New System.Drawing.Size(82, 20)
            Me.LabelRadio_Geography.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_Geography.TabIndex = 5
            Me.LabelRadio_Geography.Text = "Geography:"
            '
            'SearchableComboBoxRadio_Geography
            '
            Me.SearchableComboBoxRadio_Geography.ActiveFilterString = ""
            Me.SearchableComboBoxRadio_Geography.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRadio_Geography.AutoFillMode = False
            Me.SearchableComboBoxRadio_Geography.BookmarkingEnabled = False
            Me.SearchableComboBoxRadio_Geography.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxRadio_Geography.DataSource = Nothing
            Me.SearchableComboBoxRadio_Geography.DisableMouseWheel = True
            Me.SearchableComboBoxRadio_Geography.DisplayName = "Geography"
            Me.SearchableComboBoxRadio_Geography.EditValue = ""
            Me.SearchableComboBoxRadio_Geography.EnterMoveNextControl = True
            Me.SearchableComboBoxRadio_Geography.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxRadio_Geography.Location = New System.Drawing.Point(99, 56)
            Me.SearchableComboBoxRadio_Geography.Name = "SearchableComboBoxRadio_Geography"
            Me.SearchableComboBoxRadio_Geography.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRadio_Geography.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxRadio_Geography.Properties.NullText = "Select"
            Me.SearchableComboBoxRadio_Geography.Properties.PopupView = Me.GridView8
            Me.SearchableComboBoxRadio_Geography.Properties.ShowClearButton = False
            Me.SearchableComboBoxRadio_Geography.Properties.ValueMember = "Code"
            Me.SearchableComboBoxRadio_Geography.SecurityEnabled = True
            Me.SearchableComboBoxRadio_Geography.SelectedValue = ""
            Me.SearchableComboBoxRadio_Geography.Size = New System.Drawing.Size(276, 20)
            Me.SearchableComboBoxRadio_Geography.TabIndex = 6
            '
            'GridView8
            '
            Me.GridView8.AFActiveFilterString = ""
            Me.GridView8.AllowExtraItemsInGridLookupEdits = True
            Me.GridView8.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView8.AutoFilterLookupColumns = False
            Me.GridView8.AutoloadRepositoryDatasource = True
            Me.GridView8.DataSourceClearing = False
            Me.GridView8.EnableDisabledRows = False
            Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView8.Name = "GridView8"
            Me.GridView8.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView8.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView8.OptionsBehavior.Editable = False
            Me.GridView8.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView8.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView8.OptionsSelection.MultiSelect = True
            Me.GridView8.OptionsView.ColumnAutoWidth = False
            Me.GridView8.OptionsView.ShowGroupPanel = False
            Me.GridView8.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView8.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView8.RunStandardValidation = True
            '
            'LabelRadio_Market
            '
            Me.LabelRadio_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_Market.Location = New System.Drawing.Point(11, 4)
            Me.LabelRadio_Market.Name = "LabelRadio_Market"
            Me.LabelRadio_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelRadio_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_Market.TabIndex = 0
            Me.LabelRadio_Market.Text = "Market:"
            '
            'SearchableComboBoxRadio_Market
            '
            Me.SearchableComboBoxRadio_Market.ActiveFilterString = ""
            Me.SearchableComboBoxRadio_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRadio_Market.AutoFillMode = False
            Me.SearchableComboBoxRadio_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxRadio_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioMarket
            Me.SearchableComboBoxRadio_Market.DataSource = Nothing
            Me.SearchableComboBoxRadio_Market.DisableMouseWheel = True
            Me.SearchableComboBoxRadio_Market.DisplayName = ""
            Me.SearchableComboBoxRadio_Market.EditValue = ""
            Me.SearchableComboBoxRadio_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxRadio_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxRadio_Market.Location = New System.Drawing.Point(99, 4)
            Me.SearchableComboBoxRadio_Market.Name = "SearchableComboBoxRadio_Market"
            Me.SearchableComboBoxRadio_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRadio_Market.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRadio_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxRadio_Market.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxRadio_Market.Properties.ShowClearButton = False
            Me.SearchableComboBoxRadio_Market.Properties.ValueMember = "Number"
            Me.SearchableComboBoxRadio_Market.SecurityEnabled = True
            Me.SearchableComboBoxRadio_Market.SelectedValue = ""
            Me.SearchableComboBoxRadio_Market.Size = New System.Drawing.Size(276, 20)
            Me.SearchableComboBoxRadio_Market.TabIndex = 1
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView7.OptionsBehavior.Editable = False
            Me.GridView7.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView7.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsSelection.MultiSelect = True
            Me.GridView7.OptionsView.ColumnAutoWidth = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView7.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView7.RunStandardValidation = True
            '
            'LabelRadio_Period
            '
            Me.LabelRadio_Period.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_Period.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_Period.Location = New System.Drawing.Point(11, 30)
            Me.LabelRadio_Period.Name = "LabelRadio_Period"
            Me.LabelRadio_Period.Size = New System.Drawing.Size(81, 20)
            Me.LabelRadio_Period.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_Period.TabIndex = 3
            Me.LabelRadio_Period.Text = "Period:"
            '
            'SearchableComboBoxRadio_Period
            '
            Me.SearchableComboBoxRadio_Period.ActiveFilterString = ""
            Me.SearchableComboBoxRadio_Period.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxRadio_Period.AutoFillMode = False
            Me.SearchableComboBoxRadio_Period.BookmarkingEnabled = False
            Me.SearchableComboBoxRadio_Period.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioPeriod
            Me.SearchableComboBoxRadio_Period.DataSource = Nothing
            Me.SearchableComboBoxRadio_Period.DisableMouseWheel = True
            Me.SearchableComboBoxRadio_Period.DisplayName = ""
            Me.SearchableComboBoxRadio_Period.EditValue = ""
            Me.SearchableComboBoxRadio_Period.EnterMoveNextControl = True
            Me.SearchableComboBoxRadio_Period.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxRadio_Period.Location = New System.Drawing.Point(99, 30)
            Me.SearchableComboBoxRadio_Period.Name = "SearchableComboBoxRadio_Period"
            Me.SearchableComboBoxRadio_Period.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxRadio_Period.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxRadio_Period.Properties.NullText = "Select Period"
            Me.SearchableComboBoxRadio_Period.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxRadio_Period.Properties.ShowClearButton = False
            Me.SearchableComboBoxRadio_Period.Properties.ValueMember = "ID"
            Me.SearchableComboBoxRadio_Period.SecurityEnabled = True
            Me.SearchableComboBoxRadio_Period.SelectedValue = ""
            Me.SearchableComboBoxRadio_Period.Size = New System.Drawing.Size(276, 20)
            Me.SearchableComboBoxRadio_Period.TabIndex = 4
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView6.OptionsBehavior.Editable = False
            Me.GridView6.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView6.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsSelection.MultiSelect = True
            Me.GridView6.OptionsView.ColumnAutoWidth = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView6.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView6.RunStandardValidation = True
            '
            'TabItemUnitTests_AudienceMetricsRadio
            '
            Me.TabItemUnitTests_AudienceMetricsRadio.AttachedControl = Me.TabControlPanelRadio_Criteria
            Me.TabItemUnitTests_AudienceMetricsRadio.Name = "TabItemUnitTests_AudienceMetricsRadio"
            Me.TabItemUnitTests_AudienceMetricsRadio.Text = "Audience Metrics (Radio)"
            '
            'MediaResearchToolForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1054, 624)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_UnitTests)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaResearchToolForm"
            Me.Text = "Media Research Tester"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_UnitTests, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_UnitTests.ResumeLayout(False)
            Me.TabControlPanelcomScore_Criteria.ResumeLayout(False)
            CType(Me.PanelComscore_TVStations, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelComscore_TVStations.ResumeLayout(False)
            CType(Me.PanelBottomSpotTVMarketStation_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotTVMarketStation_RightSection.ResumeLayout(False)
            CType(Me.PanelBottomSpotTVMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotTVMarketStation_LeftSection.ResumeLayout(False)
            CType(Me.DateTimePickerComscore_EndTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerComscore_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerComscore_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerComscore_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelAudienceMetrics_Criteria.ResumeLayout(False)
            CType(Me.NumericInputAudienceMetrics_BookYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxAudienceMetrics_Station.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxAudienceMetrics_Days, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxAudienceMetrics_Days.ResumeLayout(False)
            CType(Me.DateTimePickerAudienceMetrics_DayStarts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerAudienceMetrics_EndTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerAudienceMetrics_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerAudienceMetrics_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxAudienceMetrics_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_PostPeriod, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerAudienceMetrics_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelNational_Criteria.ResumeLayout(False)
            CType(Me.GroupBoxNational_GroupBy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNational_GroupBy.ResumeLayout(False)
            CType(Me.SearchableComboBoxNational_MarketBreak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxNational_Service.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxNational_Days, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNational_Days.ResumeLayout(False)
            CType(Me.DateTimePickerNational_EndTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNational_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNational_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxNational_Media.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNational_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelRadio_Criteria.ResumeLayout(False)
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.DateTimePickerRadio_EndTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerRadio_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRadio_Station.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRadio_Geography.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRadio_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxRadio_Period.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_UnitTests As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAudienceMetrics_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUnitTests_AudienceMetrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelAudienceMetrics_SampleType As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_Service As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_Stream As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_Market As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_Station As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_EndDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_StartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxAudienceMetrics_Days As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxDays_Fri As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Sat As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Sun As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Thu As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Mon As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Tue As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDays_Wed As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxAudienceMetrics_Market As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_PostPeriod As WinForm.Presentation.Controls.GridView
        Friend WithEvents DateTimePickerAudienceMetrics_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerAudienceMetrics_EndTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerAudienceMetrics_StartTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerAudienceMetrics_EndDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerAudienceMetrics_DayStarts As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelAudienceMetrics_DayStarts As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ComboBoxAudienceMetrics_Stream As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAudienceMetrics_SampleType As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAudienceMetrics_NielsenService As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewAudienceMetrics_SelectedDemos As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewAudienceMetrics_Results As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxAudienceMetrics_Station As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.Presentation.Controls.GridView
        Friend WithEvents ComboBoxAudienceMetrics_BookMonth As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputAudienceMetrics_BookYear As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents Label1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAudienceMetrics_BookMonth As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabControlPanelNational_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUnitTests_AudienceMetricsNational As DevComponents.DotNetBar.TabItem
        Friend WithEvents SearchableComboBoxNational_Service As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.Presentation.Controls.GridView
        Friend WithEvents DataGridViewNational_SelectedDemos As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewNational_Results As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ComboBoxNational_Stream As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxNational_Days As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxNationalDays_Fri As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Sat As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Sun As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Thu As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Mon As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Tue As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDays_Wed As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxNational_TimeType As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelNational_Media As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_Service As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_MarketBreak As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_TimeType As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_Stream As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_StartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_EndDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNational_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerNational_EndTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelNational_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerNational_StartTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerNational_EndDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxNational_Media As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As WinForm.Presentation.Controls.GridView
        Friend WithEvents DateTimePickerNational_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxNational_MarketBreak As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As WinForm.Presentation.Controls.GridView
        Friend WithEvents GroupBoxNational_GroupBy As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonGroupBy_None As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGroupBy_Network As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGroupBy_Date As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanelRadio_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUnitTests_AudienceMetricsRadio As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelRadio_Period As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxRadio_Period As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelRadio_Geography As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxRadio_Geography As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelRadio_Market As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxRadio_Market As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As WinForm.Presentation.Controls.GridView
        Friend WithEvents DataGridViewRadio_Results As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewRadio_SelectedDemos As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxRadio_Station As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView13 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelRadio_StationOrCombo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelRadio_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerRadio_EndTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelRadio_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerRadio_StartTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents GroupBox1 As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckRadio_Friday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Saturday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Sunday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Thursday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Monday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Tuesday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckRadio_Wednesday As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelcomScore_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemUnitTests_comScore As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelComscoreMarket As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelComscoreStartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelComscoreEndDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelComscoreStartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerComscore_EndTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelComscoreEndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateTimePickerComscore_StartTime As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerComscore_EndDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerComscore_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DataGridViewComscore_SelectedDemos As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewComscore_Results As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemUnitTests_comScoreResults As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelComscore_TVStations As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBottomSpotTVMarketStation_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewComscore_SelectedStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonComscoreTVStation_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonComscoreTVStation_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterSpotTVMarketStations_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBottomSpotTVMarketStation_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewComscore_AvailableStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ComboBoxComscore_Market As WinForm.MVC.Presentation.Controls.ComboBox
    End Class

End Namespace