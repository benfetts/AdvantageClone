Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BroadcastResearchToolForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BroadcastResearchToolForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ReportView = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReportView_ByAge = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportView_ByGender = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportView_ByAgeGender = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportView_ByGenderAge = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Metrics = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMetrics_Up = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMetrics_Down = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Demographics = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDemographics_Up = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDemographics_Down = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_Books = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelNational_National = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelNational_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlNational_ResearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelNationalReportType = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxNational_TimeType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalTimeType_Commercial = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalTimeType_Program = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.PanelNationalReportType_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelNationalNetworks_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_NetworksSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonNationalNetworks_AddSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonNationalNetworks_RemoveSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl4 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelNationalNetworks_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_NetworksAvailable = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.GroupBoxNational_Ethnicity = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalEthnicity_Hispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalEthnicity_GeneralMarket = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.ComboBoxNational_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.Label = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemNational_ReportType = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNationalDates = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxNationalDates_ShowAirings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxNationalDates_ShowProgramTypes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ComboBoxNationalDates_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelNationalDates_Stream = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxNationalDates_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelNationalDates_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxNationalDates_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxNationalDates_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.GroupBoxNationalDates_Corrections = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalCorrections_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalCorrections_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalCorrections_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNationalDates_Premieres = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalPremieres_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalPremieres_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalPremieres_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNationalDates_Repeats = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalRepeats_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalRepeats_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalRepeats_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNationalDates_Overnights = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalOvernights_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalOvernights_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalOvernights_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNationalDates_Specials = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalSpecials_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalSpecials_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalSpecials_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNationalDates_Breakouts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonNationalBreakout_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalBreakout_Only = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationalBreakout_Ignore = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxNational_DateCodeDates = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateEditNationalDates_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditNationalDates_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.LabelNationalDates_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RadioButtonNationDates_Dates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNationDates_DateCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.LabelNationalDates_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNationalDates_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelNationalDates_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemNational_Dates = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNationalResults = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlResults_NationalResults = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelNational_ResultsData = New DevComponents.DotNetBar.TabControlPanel()
            Me.BandedDataGridViewNationalResults = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TabItemNationalResults_Data = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNational_ResultsDashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerControl1 = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemNationalResults_Dashboard = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemNational_Results = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNationalDemographics = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelNationalDemographics = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelNationalDemographics_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_DemographicsSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonNationalDemographics_AddSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonNationalDemographics_RemoveSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl3 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelNationalDemographics_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_DemographicsAvailable = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemNational_Demographics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNationalMetrics = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelNationalMetrics = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelNationalMetrics_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_MetricsSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonNationalMetrics_AddSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonNationalMetrics_RemoveSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl5 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelNationalMetrics_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_MetricsAvailable = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemNational_Metrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelNational_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewNational_UserCriterias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_NationalTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadioCounty_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlSpotRadioCounty_ResearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCountyMarket = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSpotRadioCounty_Years = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.GroupBoxSpotRadioCounty_Dayparts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxCountyDaypart84 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxCountyDaypart68 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxCounty_ShowFrequency = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelCounty_MaxRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputCounty_MaxRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.ComboBoxCounty_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelCounty_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxCounty_Demographic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelCounty_Demographic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelCounty_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxCounty_County = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.TabItemSpotRadioCounty_MarketBooks = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCountyResults = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlResults_RadioCountyResults = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelCountyData = New DevComponents.DotNetBar.TabControlPanel()
            Me.BandedDataGridViewSpotRadioCountyResults = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TabItemRadioCountyResults_RadioCountyDataTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCountyDashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerRadioCountyDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemCountyResults_Dashboard = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemSpotRadioCounty_Results = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCountyStations = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadioCountyStation = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBottomSpotRadioCountyStation_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadioCounty_SelectedStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotRadioCountyStation_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotRadioCounty_Stations = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBottomSpotRadioCountyStation_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadioCounty_AvailableStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotRadioCounty_Stations = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCountyMetrics = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadioCountyMetrics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelSpotRadioCountyMetrics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadioCounty_SelectedMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotRadioCountyMetrics_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotRadioCountyMetrics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadioCounty_AvailableMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotRadioCounty_Metrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotRadioCounty_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadioCounty_UserCriterias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_SpotRadioCountyTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadio_SpotRadio = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadio_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlSpotRadio_ResearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSpotRadioMarket_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSpotRadioMarket_MaxRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputSpotRadioMarket_MaxRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.ComboBoxSpotRadioMarket_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelSpotRadioMarket_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewSpotRadio_Books = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ComboBoxSpotRadioMarketDemographic_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelSpotRadioMarket_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxSpotRadioMarket_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxSpotRadioOptions_ShowFrequency = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotRadioOptions_ShowFormat = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotRadioOptions_TotalListening = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotRadioOptions_ShowSpill = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.GroupBoxSpotRadioMarket_Ethnicity = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSpotRadioEthnicity_Hispanic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioEthnicity_Black = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioEthnicity_All = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.SearchableComboBoxSpotRadioMarket_Qualitative = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelSpotRadioMarket_Qualitative = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxSpotRadioMarket_Demographic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelSpotRadioMarket_Demo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelSpotRadioMarket_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxSpotRadio_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxSpotRadioViewControl_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.TabItemSpotRadio_MarketBooks = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadioResults_Results = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlResults_RadioResults = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelRadioDataTab_RadioData = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSpotRadioResults_Footer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.BandedDataGridViewSpotRadioResults = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TabItemRadioResults_RadioDataTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerRadioDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemRadioResults_RadioDashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemSpotRadio_Results = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSpotRadio_Dayparts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelSpotRadio_DaypartNote = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxSpotRadioMarket_ListeningType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSpotRadioListeningType_OutOfHome = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioListeningType_Car = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioListeningType_Work = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioListeningType_Home = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioListeningType_Total = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxSpotRadioMarket_Geography = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSpotRadioGeography_DMA = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioGeography_TSA = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSpotRadioGeography_Metro = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TabItemSpotRadio_GeographyDayparts = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadioMetrics_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadioMetrics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelSpotRadioMetrics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadio_SelectedMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotRadioMetrics_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotRadioMetrics_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotRadio_Metrics = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotRadioMetrics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadio_AvailableMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotRadio_Metrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotRadioStations_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotRadioMarketStation_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBottomSpotRadioStation_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadio_SelectedStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotRadioStation_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotRadioStation_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotRadio_Stations = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBottomSpotRadioStation_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadio_AvailableStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotRadio_Stations = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControlSpotRadio_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotRadio_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotRadio_UserCriterias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_SpotRadioTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotTV_SpotTV = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotTV_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlSpotTV_ResearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSpotTVMarketStations_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.ComboBoxSpotTVMarketStation_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelSpotTVMarketStation_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelSpotTVMarketStation_MaximumRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputSpotTVMarketStation_MaximumRank = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.ComboBoxSpotTVMarketStation_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.PanelSpotTVMarketStation_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBottomSpotTVMarketStation_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_SelectedStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotTVStation_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotTVStation_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBottomSpotTVMarketStation_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_AvailableStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.GroupBoxSpotTVMarketStation_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotTVOptions_ShowSpill = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotTVOptions_DominantProgramming = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxSpotTVOptions_ShowProgramName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelSpotTVMarketStation_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelSpotTVMarketStation_ReportType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxSpotTVMarketStation_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxSpotTVViewControl_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.TabItemSpotTV_MarketStations = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotTVBooks_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSpotTV_DayTimes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterSpotTVDaysTimes = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.ShareHPUTBookControl_Books = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ShareHPUTBookControl()
            Me.TabItemSpotTV_Books = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotTVResults_Results = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlResults_TVResults = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelTVDataTab_TVData = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSpotTVResults_Footer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.BandedDataGridViewSpotTVResults = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TabItemTVResults_TVDataTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTVDashboardTab_TVDashboard = New DevComponents.DotNetBar.TabControlPanel()
            Me.DashboardViewerTVDashboard_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.TabItemTVResults_TVDashboardTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemSpotTV_Results = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotTVMetrics_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotTVMetrics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelSpotTVMetrics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_SelectedMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotTVMetrics_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotTVMetrics_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotTVMetrics = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotTVMetrics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_AvailableMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotTV_Metrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSpotTVDemographics_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSpotTVDemographics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelSpotTVDemographics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_SelectedDemographics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonSpotTVDemographics_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonSpotTVDemographics_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControlSpotTVDemographics = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotTVDemographics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_AvailableDemographics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemSpotTV_Demographics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControlSpotTV_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSpotTV_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewSpotTV_UserCriterias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemTabs_SpotTVTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Tabs.SuspendLayout()
            Me.TabControlPanelNational_National.SuspendLayout()
            CType(Me.PanelNational_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNational_RightSection.SuspendLayout()
            CType(Me.TabControlNational_ResearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlNational_ResearchCriteria.SuspendLayout()
            Me.TabControlPanelNationalReportType.SuspendLayout()
            CType(Me.GroupBoxNational_TimeType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNational_TimeType.SuspendLayout()
            CType(Me.PanelNationalReportType_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalReportType_Bottom.SuspendLayout()
            CType(Me.PanelNationalNetworks_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalNetworks_RightSection.SuspendLayout()
            CType(Me.PanelNationalNetworks_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalNetworks_LeftSection.SuspendLayout()
            CType(Me.GroupBoxNational_Ethnicity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNational_Ethnicity.SuspendLayout()
            Me.TabControlPanelNationalDates.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Corrections, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Corrections.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Premieres, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Premieres.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Repeats, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Repeats.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Overnights, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Overnights.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Specials, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Specials.SuspendLayout()
            CType(Me.GroupBoxNationalDates_Breakouts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNationalDates_Breakouts.SuspendLayout()
            CType(Me.GroupBoxNational_DateCodeDates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNational_DateCodeDates.SuspendLayout()
            CType(Me.DateEditNationalDates_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditNationalDates_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditNationalDates_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditNationalDates_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelNationalResults.SuspendLayout()
            CType(Me.TabControlResults_NationalResults, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlResults_NationalResults.SuspendLayout()
            Me.TabControlPanelNational_ResultsData.SuspendLayout()
            Me.TabControlPanelNational_ResultsDashboard.SuspendLayout()
            CType(Me.DashboardViewerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelNationalDemographics.SuspendLayout()
            CType(Me.PanelNationalDemographics, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalDemographics.SuspendLayout()
            CType(Me.PanelNationalDemographics_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalDemographics_RightSection.SuspendLayout()
            CType(Me.PanelNationalDemographics_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalDemographics_LeftSection.SuspendLayout()
            Me.TabControlPanelNationalMetrics.SuspendLayout()
            CType(Me.PanelNationalMetrics, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalMetrics.SuspendLayout()
            CType(Me.PanelNationalMetrics_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalMetrics_RightSection.SuspendLayout()
            CType(Me.PanelNationalMetrics_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNationalMetrics_LeftSection.SuspendLayout()
            CType(Me.PanelNational_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelNational_LeftSection.SuspendLayout()
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.SuspendLayout()
            CType(Me.PanelSpotRadioCounty_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCounty_RightSection.SuspendLayout()
            CType(Me.TabControlSpotRadioCounty_ResearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlSpotRadioCounty_ResearchCriteria.SuspendLayout()
            Me.TabControlPanelCountyMarket.SuspendLayout()
            CType(Me.GroupBoxSpotRadioCounty_Dayparts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotRadioCounty_Dayparts.SuspendLayout()
            CType(Me.NumericInputCounty_MaxRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCounty_Demographic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCounty_County.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCountyResults.SuspendLayout()
            CType(Me.TabControlResults_RadioCountyResults, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlResults_RadioCountyResults.SuspendLayout()
            Me.TabControlPanelCountyData.SuspendLayout()
            Me.TabControlPanelCountyDashboard.SuspendLayout()
            CType(Me.DashboardViewerRadioCountyDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCountyStations.SuspendLayout()
            CType(Me.PanelSpotRadioCountyStation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCountyStation.SuspendLayout()
            CType(Me.PanelBottomSpotRadioCountyStation_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotRadioCountyStation_RightSection.SuspendLayout()
            CType(Me.PanelBottomSpotRadioCountyStation_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotRadioCountyStation_LeftSection.SuspendLayout()
            Me.TabControlPanelCountyMetrics.SuspendLayout()
            CType(Me.PanelSpotRadioCountyMetrics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCountyMetrics_Criteria.SuspendLayout()
            CType(Me.PanelSpotRadioCountyMetrics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCountyMetrics_Right.SuspendLayout()
            CType(Me.PanelSpotRadioCountyMetrics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCountyMetrics_Left.SuspendLayout()
            CType(Me.PanelSpotRadioCounty_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioCounty_LeftSection.SuspendLayout()
            Me.TabControlPanelSpotRadio_SpotRadio.SuspendLayout()
            CType(Me.PanelSpotRadio_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadio_RightSection.SuspendLayout()
            CType(Me.TabControlSpotRadio_ResearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlSpotRadio_ResearchCriteria.SuspendLayout()
            Me.TabControlPanelSpotRadioMarket_Criteria.SuspendLayout()
            CType(Me.NumericInputSpotRadioMarket_MaxRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxSpotRadioMarket_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotRadioMarket_Options.SuspendLayout()
            CType(Me.GroupBoxSpotRadioMarket_Ethnicity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotRadioMarket_Ethnicity.SuspendLayout()
            CType(Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotRadio_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotRadioViewControl_Market, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSpotRadioResults_Results.SuspendLayout()
            CType(Me.TabControlResults_RadioResults, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlResults_RadioResults.SuspendLayout()
            Me.TabControlPanelRadioDataTab_RadioData.SuspendLayout()
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.SuspendLayout()
            CType(Me.DashboardViewerRadioDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.SuspendLayout()
            CType(Me.GroupBoxSpotRadioMarket_ListeningType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotRadioMarket_ListeningType.SuspendLayout()
            CType(Me.GroupBoxSpotRadioMarket_Geography, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotRadioMarket_Geography.SuspendLayout()
            Me.TabControlPanelSpotRadioMetrics_Criteria.SuspendLayout()
            CType(Me.PanelSpotRadioMetrics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioMetrics_Criteria.SuspendLayout()
            CType(Me.PanelSpotRadioMetrics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioMetrics_Right.SuspendLayout()
            CType(Me.PanelSpotRadioMetrics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioMetrics_Left.SuspendLayout()
            Me.TabControlPanelSpotRadioStations_Criteria.SuspendLayout()
            CType(Me.PanelSpotRadioMarketStation_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadioMarketStation_Bottom.SuspendLayout()
            CType(Me.PanelBottomSpotRadioStation_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotRadioStation_RightSection.SuspendLayout()
            CType(Me.PanelBottomSpotRadioStation_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotRadioStation_LeftSection.SuspendLayout()
            CType(Me.PanelSpotRadio_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotRadio_LeftSection.SuspendLayout()
            Me.TabControlPanelSpotTV_SpotTV.SuspendLayout()
            CType(Me.PanelSpotTV_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTV_RightSection.SuspendLayout()
            CType(Me.TabControlSpotTV_ResearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlSpotTV_ResearchCriteria.SuspendLayout()
            Me.TabControlPanelSpotTVMarketStations_Criteria.SuspendLayout()
            CType(Me.NumericInputSpotTVMarketStation_MaximumRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelSpotTVMarketStation_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVMarketStation_Bottom.SuspendLayout()
            CType(Me.PanelBottomSpotTVMarketStation_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotTVMarketStation_RightSection.SuspendLayout()
            CType(Me.PanelBottomSpotTVMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomSpotTVMarketStation_LeftSection.SuspendLayout()
            CType(Me.GroupBoxSpotTVMarketStation_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSpotTVMarketStation_Options.SuspendLayout()
            CType(Me.SearchableComboBoxSpotTVMarketStation_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSpotTVBooks_Criteria.SuspendLayout()
            Me.TabControlPanelSpotTVResults_Results.SuspendLayout()
            CType(Me.TabControlResults_TVResults, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlResults_TVResults.SuspendLayout()
            Me.TabControlPanelTVDataTab_TVData.SuspendLayout()
            Me.TabControlPanelTVDashboardTab_TVDashboard.SuspendLayout()
            CType(Me.DashboardViewerTVDashboard_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSpotTVMetrics_Criteria.SuspendLayout()
            CType(Me.PanelSpotTVMetrics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVMetrics_Criteria.SuspendLayout()
            CType(Me.PanelSpotTVMetrics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVMetrics_Right.SuspendLayout()
            CType(Me.PanelSpotTVMetrics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVMetrics_Left.SuspendLayout()
            Me.TabControlPanelSpotTVDemographics_Criteria.SuspendLayout()
            CType(Me.PanelSpotTVDemographics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVDemographics_Criteria.SuspendLayout()
            CType(Me.PanelSpotTVDemographics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVDemographics_Right.SuspendLayout()
            CType(Me.PanelSpotTVDemographics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTVDemographics_Left.SuspendLayout()
            CType(Me.PanelSpotTV_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSpotTV_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ReportView)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Metrics)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Demographics)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(13, 4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1014, 98)
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
            'RibbonBarOptions_ReportView
            '
            Me.RibbonBarOptions_ReportView.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReportView.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportView.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReportView.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReportView.DragDropSupport = True
            Me.RibbonBarOptions_ReportView.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_ReportView.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReportView_ByAge, Me.ButtonItemReportView_ByGender, Me.ButtonItemReportView_ByAgeGender, Me.ButtonItemReportView_ByGenderAge})
            Me.RibbonBarOptions_ReportView.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReportView.Location = New System.Drawing.Point(633, 0)
            Me.RibbonBarOptions_ReportView.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_ReportView.Name = "RibbonBarOptions_ReportView"
            Me.RibbonBarOptions_ReportView.SecurityEnabled = True
            Me.RibbonBarOptions_ReportView.Size = New System.Drawing.Size(299, 98)
            Me.RibbonBarOptions_ReportView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReportView.TabIndex = 5
            Me.RibbonBarOptions_ReportView.Text = "Report View"
            '
            '
            '
            Me.RibbonBarOptions_ReportView.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportView.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportView.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemReportView_ByAge
            '
            Me.ButtonItemReportView_ByAge.AutoCheckOnClick = True
            Me.ButtonItemReportView_ByAge.BeginGroup = True
            Me.ButtonItemReportView_ByAge.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportView_ByAge.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportView_ByAge.Name = "ButtonItemReportView_ByAge"
            Me.ButtonItemReportView_ByAge.OptionGroup = "ReportView"
            Me.ButtonItemReportView_ByAge.RibbonWordWrap = False
            Me.ButtonItemReportView_ByAge.SubItemsExpandWidth = 14
            Me.ButtonItemReportView_ByAge.Text = "By Age"
            '
            'ButtonItemReportView_ByGender
            '
            Me.ButtonItemReportView_ByGender.AutoCheckOnClick = True
            Me.ButtonItemReportView_ByGender.BeginGroup = True
            Me.ButtonItemReportView_ByGender.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportView_ByGender.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportView_ByGender.Name = "ButtonItemReportView_ByGender"
            Me.ButtonItemReportView_ByGender.OptionGroup = "ReportView"
            Me.ButtonItemReportView_ByGender.RibbonWordWrap = False
            Me.ButtonItemReportView_ByGender.SubItemsExpandWidth = 14
            Me.ButtonItemReportView_ByGender.Text = "By Gender"
            '
            'ButtonItemReportView_ByAgeGender
            '
            Me.ButtonItemReportView_ByAgeGender.AutoCheckOnClick = True
            Me.ButtonItemReportView_ByAgeGender.BeginGroup = True
            Me.ButtonItemReportView_ByAgeGender.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportView_ByAgeGender.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportView_ByAgeGender.Name = "ButtonItemReportView_ByAgeGender"
            Me.ButtonItemReportView_ByAgeGender.OptionGroup = "ReportView"
            Me.ButtonItemReportView_ByAgeGender.RibbonWordWrap = False
            Me.ButtonItemReportView_ByAgeGender.SubItemsExpandWidth = 14
            Me.ButtonItemReportView_ByAgeGender.Text = "By Age/Gender"
            '
            'ButtonItemReportView_ByGenderAge
            '
            Me.ButtonItemReportView_ByGenderAge.AutoCheckOnClick = True
            Me.ButtonItemReportView_ByGenderAge.BeginGroup = True
            Me.ButtonItemReportView_ByGenderAge.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportView_ByGenderAge.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportView_ByGenderAge.Name = "ButtonItemReportView_ByGenderAge"
            Me.ButtonItemReportView_ByGenderAge.OptionGroup = "ReportView"
            Me.ButtonItemReportView_ByGenderAge.RibbonWordWrap = False
            Me.ButtonItemReportView_ByGenderAge.SubItemsExpandWidth = 14
            Me.ButtonItemReportView_ByGenderAge.Text = "By Gender/Age"
            '
            'RibbonBarOptions_Dashboard
            '
            Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Dashboard.DragDropSupport = True
            Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
            Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(568, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 4
            Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDashboard_Edit
            '
            Me.ButtonItemDashboard_Edit.BeginGroup = True
            Me.ButtonItemDashboard_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Metrics
            '
            Me.RibbonBarOptions_Metrics.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Metrics.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Metrics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Metrics.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Metrics.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Metrics.DragDropSupport = True
            Me.RibbonBarOptions_Metrics.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMetrics_Up, Me.ButtonItemMetrics_Down})
            Me.RibbonBarOptions_Metrics.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Metrics.Location = New System.Drawing.Point(484, 0)
            Me.RibbonBarOptions_Metrics.Name = "RibbonBarOptions_Metrics"
            Me.RibbonBarOptions_Metrics.SecurityEnabled = True
            Me.RibbonBarOptions_Metrics.Size = New System.Drawing.Size(84, 98)
            Me.RibbonBarOptions_Metrics.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Metrics.TabIndex = 3
            Me.RibbonBarOptions_Metrics.Text = "Metrics"
            '
            '
            '
            Me.RibbonBarOptions_Metrics.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Metrics.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Metrics.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMetrics_Up
            '
            Me.ButtonItemMetrics_Up.BeginGroup = True
            Me.ButtonItemMetrics_Up.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMetrics_Up.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMetrics_Up.Name = "ButtonItemMetrics_Up"
            Me.ButtonItemMetrics_Up.SecurityEnabled = True
            Me.ButtonItemMetrics_Up.Stretch = True
            Me.ButtonItemMetrics_Up.SubItemsExpandWidth = 14
            Me.ButtonItemMetrics_Up.Text = "Up"
            '
            'ButtonItemMetrics_Down
            '
            Me.ButtonItemMetrics_Down.BeginGroup = True
            Me.ButtonItemMetrics_Down.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMetrics_Down.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMetrics_Down.Name = "ButtonItemMetrics_Down"
            Me.ButtonItemMetrics_Down.SecurityEnabled = True
            Me.ButtonItemMetrics_Down.Stretch = True
            Me.ButtonItemMetrics_Down.SubItemsExpandWidth = 14
            Me.ButtonItemMetrics_Down.Text = "Down"
            '
            'RibbonBarOptions_Demographics
            '
            Me.RibbonBarOptions_Demographics.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Demographics.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Demographics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Demographics.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Demographics.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Demographics.DragDropSupport = True
            Me.RibbonBarOptions_Demographics.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDemographics_Up, Me.ButtonItemDemographics_Down})
            Me.RibbonBarOptions_Demographics.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Demographics.Location = New System.Drawing.Point(395, 0)
            Me.RibbonBarOptions_Demographics.Name = "RibbonBarOptions_Demographics"
            Me.RibbonBarOptions_Demographics.SecurityEnabled = True
            Me.RibbonBarOptions_Demographics.Size = New System.Drawing.Size(89, 98)
            Me.RibbonBarOptions_Demographics.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Demographics.TabIndex = 2
            Me.RibbonBarOptions_Demographics.Text = "Demographics"
            '
            '
            '
            Me.RibbonBarOptions_Demographics.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Demographics.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Demographics.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDemographics_Up
            '
            Me.ButtonItemDemographics_Up.BeginGroup = True
            Me.ButtonItemDemographics_Up.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDemographics_Up.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDemographics_Up.Name = "ButtonItemDemographics_Up"
            Me.ButtonItemDemographics_Up.SecurityEnabled = True
            Me.ButtonItemDemographics_Up.Stretch = True
            Me.ButtonItemDemographics_Up.SubItemsExpandWidth = 14
            Me.ButtonItemDemographics_Up.Text = "Up"
            '
            'ButtonItemDemographics_Down
            '
            Me.ButtonItemDemographics_Down.BeginGroup = True
            Me.ButtonItemDemographics_Down.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDemographics_Down.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDemographics_Down.Name = "ButtonItemDemographics_Down"
            Me.ButtonItemDemographics_Down.SecurityEnabled = True
            Me.ButtonItemDemographics_Down.Stretch = True
            Me.ButtonItemDemographics_Down.SubItemsExpandWidth = 14
            Me.ButtonItemDemographics_Down.Text = "Down"
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
            Me.RibbonBarOptions_View.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_Books})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(330, 0)
            Me.RibbonBarOptions_View.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(65, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 6
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
            'ButtonItemView_Books
            '
            Me.ButtonItemView_Books.BeginGroup = True
            Me.ButtonItemView_Books.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_Books.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_Books.Name = "ButtonItemView_Books"
            Me.ButtonItemView_Books.RibbonWordWrap = False
            Me.ButtonItemView_Books.SubItemsExpandWidth = 14
            Me.ButtonItemView_Books.Text = "Books"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Edit, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Process, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(330, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Edit
            '
            Me.ButtonItemActions_Edit.BeginGroup = True
            Me.ButtonItemActions_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Edit.Name = "ButtonItemActions_Edit"
            Me.ButtonItemActions_Edit.SecurityEnabled = True
            Me.ButtonItemActions_Edit.Stretch = True
            Me.ButtonItemActions_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Edit.Text = "Edit"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
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
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.Stretch = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
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
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'TabControlForm_Tabs
            '
            Me.TabControlForm_Tabs.BackColor = System.Drawing.Color.White
            Me.TabControlForm_Tabs.CanReorderTabs = True
            Me.TabControlForm_Tabs.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelNational_National)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelSpotTV_SpotTV)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelSpotRadioCounty_SpotRadioCounty)
            Me.TabControlForm_Tabs.Controls.Add(Me.TabControlPanelSpotRadio_SpotRadio)
            Me.TabControlForm_Tabs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlForm_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Tabs.Location = New System.Drawing.Point(0, 0)
            Me.TabControlForm_Tabs.Name = "TabControlForm_Tabs"
            Me.TabControlForm_Tabs.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Tabs.SelectedTabIndex = 0
            Me.TabControlForm_Tabs.Size = New System.Drawing.Size(1054, 624)
            Me.TabControlForm_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Tabs.TabIndex = 6
            Me.TabControlForm_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_SpotTVTab)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_SpotRadioTab)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_SpotRadioCountyTab)
            Me.TabControlForm_Tabs.Tabs.Add(Me.TabItemTabs_NationalTab)
            Me.TabControlForm_Tabs.Text = "TabControl1"
            '
            'TabControlPanelNational_National
            '
            Me.TabControlPanelNational_National.Controls.Add(Me.PanelNational_RightSection)
            Me.TabControlPanelNational_National.Controls.Add(Me.ExpandableSplitterControl1)
            Me.TabControlPanelNational_National.Controls.Add(Me.PanelNational_LeftSection)
            Me.TabControlPanelNational_National.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNational_National.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNational_National.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNational_National.Name = "TabControlPanelNational_National"
            Me.TabControlPanelNational_National.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNational_National.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelNational_National.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNational_National.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNational_National.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNational_National.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNational_National.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNational_National.Style.GradientAngle = 90
            Me.TabControlPanelNational_National.TabIndex = 19
            Me.TabControlPanelNational_National.TabItem = Me.TabItemTabs_NationalTab
            '
            'PanelNational_RightSection
            '
            Me.PanelNational_RightSection.Controls.Add(Me.TabControlNational_ResearchCriteria)
            Me.PanelNational_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelNational_RightSection.Location = New System.Drawing.Point(204, 1)
            Me.PanelNational_RightSection.Name = "PanelNational_RightSection"
            Me.PanelNational_RightSection.Size = New System.Drawing.Size(849, 595)
            Me.PanelNational_RightSection.TabIndex = 50
            '
            'TabControlNational_ResearchCriteria
            '
            Me.TabControlNational_ResearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlNational_ResearchCriteria.BackColor = System.Drawing.Color.White
            Me.TabControlNational_ResearchCriteria.CanReorderTabs = False
            Me.TabControlNational_ResearchCriteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlNational_ResearchCriteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlNational_ResearchCriteria.Controls.Add(Me.TabControlPanelNationalReportType)
            Me.TabControlNational_ResearchCriteria.Controls.Add(Me.TabControlPanelNationalDates)
            Me.TabControlNational_ResearchCriteria.Controls.Add(Me.TabControlPanelNationalResults)
            Me.TabControlNational_ResearchCriteria.Controls.Add(Me.TabControlPanelNationalDemographics)
            Me.TabControlNational_ResearchCriteria.Controls.Add(Me.TabControlPanelNationalMetrics)
            Me.TabControlNational_ResearchCriteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlNational_ResearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlNational_ResearchCriteria.Name = "TabControlNational_ResearchCriteria"
            Me.TabControlNational_ResearchCriteria.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlNational_ResearchCriteria.SelectedTabIndex = 0
            Me.TabControlNational_ResearchCriteria.Size = New System.Drawing.Size(825, 571)
            Me.TabControlNational_ResearchCriteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlNational_ResearchCriteria.TabIndex = 0
            Me.TabControlNational_ResearchCriteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlNational_ResearchCriteria.Tabs.Add(Me.TabItemNational_ReportType)
            Me.TabControlNational_ResearchCriteria.Tabs.Add(Me.TabItemNational_Dates)
            Me.TabControlNational_ResearchCriteria.Tabs.Add(Me.TabItemNational_Demographics)
            Me.TabControlNational_ResearchCriteria.Tabs.Add(Me.TabItemNational_Metrics)
            Me.TabControlNational_ResearchCriteria.Tabs.Add(Me.TabItemNational_Results)
            '
            'TabControlPanelNationalReportType
            '
            Me.TabControlPanelNationalReportType.Controls.Add(Me.GroupBoxNational_TimeType)
            Me.TabControlPanelNationalReportType.Controls.Add(Me.PanelNationalReportType_Bottom)
            Me.TabControlPanelNationalReportType.Controls.Add(Me.GroupBoxNational_Ethnicity)
            Me.TabControlPanelNationalReportType.Controls.Add(Me.ComboBoxNational_ReportType)
            Me.TabControlPanelNationalReportType.Controls.Add(Me.Label)
            Me.TabControlPanelNationalReportType.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNationalReportType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNationalReportType.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNationalReportType.Name = "TabControlPanelNationalReportType"
            Me.TabControlPanelNationalReportType.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNationalReportType.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelNationalReportType.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNationalReportType.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNationalReportType.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNationalReportType.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNationalReportType.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNationalReportType.Style.GradientAngle = 90
            Me.TabControlPanelNationalReportType.TabIndex = 0
            Me.TabControlPanelNationalReportType.TabItem = Me.TabItemNational_ReportType
            '
            'GroupBoxNational_TimeType
            '
            Me.GroupBoxNational_TimeType.Controls.Add(Me.RadioButtonNationalTimeType_Commercial)
            Me.GroupBoxNational_TimeType.Controls.Add(Me.RadioButtonNationalTimeType_Program)
            Me.GroupBoxNational_TimeType.Location = New System.Drawing.Point(264, 35)
            Me.GroupBoxNational_TimeType.Name = "GroupBoxNational_TimeType"
            Me.GroupBoxNational_TimeType.Size = New System.Drawing.Size(245, 56)
            Me.GroupBoxNational_TimeType.TabIndex = 19
            Me.GroupBoxNational_TimeType.Text = "Time Type"
            '
            'RadioButtonNationalTimeType_Commercial
            '
            Me.RadioButtonNationalTimeType_Commercial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalTimeType_Commercial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalTimeType_Commercial.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalTimeType_Commercial.Location = New System.Drawing.Point(122, 22)
            Me.RadioButtonNationalTimeType_Commercial.Name = "RadioButtonNationalTimeType_Commercial"
            Me.RadioButtonNationalTimeType_Commercial.SecurityEnabled = True
            Me.RadioButtonNationalTimeType_Commercial.Size = New System.Drawing.Size(111, 20)
            Me.RadioButtonNationalTimeType_Commercial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalTimeType_Commercial.TabIndex = 3
            Me.RadioButtonNationalTimeType_Commercial.TabOnEnter = True
            Me.RadioButtonNationalTimeType_Commercial.TabStop = False
            Me.RadioButtonNationalTimeType_Commercial.Tag = "C"
            Me.RadioButtonNationalTimeType_Commercial.Text = "Commercial"
            '
            'RadioButtonNationalTimeType_Program
            '
            Me.RadioButtonNationalTimeType_Program.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalTimeType_Program.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalTimeType_Program.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalTimeType_Program.Checked = True
            Me.RadioButtonNationalTimeType_Program.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalTimeType_Program.CheckValue = "Y"
            Me.RadioButtonNationalTimeType_Program.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalTimeType_Program.Name = "RadioButtonNationalTimeType_Program"
            Me.RadioButtonNationalTimeType_Program.SecurityEnabled = True
            Me.RadioButtonNationalTimeType_Program.Size = New System.Drawing.Size(111, 20)
            Me.RadioButtonNationalTimeType_Program.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalTimeType_Program.TabIndex = 1
            Me.RadioButtonNationalTimeType_Program.TabOnEnter = True
            Me.RadioButtonNationalTimeType_Program.Tag = "P"
            Me.RadioButtonNationalTimeType_Program.Text = "Program"
            '
            'PanelNationalReportType_Bottom
            '
            Me.PanelNationalReportType_Bottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelNationalReportType_Bottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalReportType_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelNationalReportType_Bottom.Controls.Add(Me.PanelNationalNetworks_RightSection)
            Me.PanelNationalReportType_Bottom.Controls.Add(Me.ExpandableSplitterControl4)
            Me.PanelNationalReportType_Bottom.Controls.Add(Me.PanelNationalNetworks_LeftSection)
            Me.PanelNationalReportType_Bottom.Location = New System.Drawing.Point(11, 97)
            Me.PanelNationalReportType_Bottom.Name = "PanelNationalReportType_Bottom"
            Me.PanelNationalReportType_Bottom.Size = New System.Drawing.Size(810, 443)
            Me.PanelNationalReportType_Bottom.TabIndex = 20
            '
            'PanelNationalNetworks_RightSection
            '
            Me.PanelNationalNetworks_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalNetworks_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalNetworks_RightSection.Controls.Add(Me.DataGridViewNational_NetworksSelected)
            Me.PanelNationalNetworks_RightSection.Controls.Add(Me.ButtonNationalNetworks_AddSelected)
            Me.PanelNationalNetworks_RightSection.Controls.Add(Me.ButtonNationalNetworks_RemoveSelected)
            Me.PanelNationalNetworks_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelNationalNetworks_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelNationalNetworks_RightSection.Name = "PanelNationalNetworks_RightSection"
            Me.PanelNationalNetworks_RightSection.Size = New System.Drawing.Size(483, 439)
            Me.PanelNationalNetworks_RightSection.TabIndex = 1
            '
            'DataGridViewNational_NetworksSelected
            '
            Me.DataGridViewNational_NetworksSelected.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_NetworksSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_NetworksSelected.AutoUpdateViewCaption = True
            Me.DataGridViewNational_NetworksSelected.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_NetworksSelected.ItemDescription = "Selected Network(s)"
            Me.DataGridViewNational_NetworksSelected.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewNational_NetworksSelected.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_NetworksSelected.ModifyGridRowHeight = False
            Me.DataGridViewNational_NetworksSelected.MultiSelect = True
            Me.DataGridViewNational_NetworksSelected.Name = "DataGridViewNational_NetworksSelected"
            Me.DataGridViewNational_NetworksSelected.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_NetworksSelected.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_NetworksSelected.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_NetworksSelected.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_NetworksSelected.Size = New System.Drawing.Size(392, 429)
            Me.DataGridViewNational_NetworksSelected.TabIndex = 2
            Me.DataGridViewNational_NetworksSelected.UseEmbeddedNavigator = False
            Me.DataGridViewNational_NetworksSelected.ViewCaptionHeight = -1
            '
            'ButtonNationalNetworks_AddSelected
            '
            Me.ButtonNationalNetworks_AddSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalNetworks_AddSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalNetworks_AddSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonNationalNetworks_AddSelected.Name = "ButtonNationalNetworks_AddSelected"
            Me.ButtonNationalNetworks_AddSelected.SecurityEnabled = True
            Me.ButtonNationalNetworks_AddSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalNetworks_AddSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalNetworks_AddSelected.TabIndex = 0
            Me.ButtonNationalNetworks_AddSelected.Text = ">"
            '
            'ButtonNationalNetworks_RemoveSelected
            '
            Me.ButtonNationalNetworks_RemoveSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalNetworks_RemoveSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalNetworks_RemoveSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonNationalNetworks_RemoveSelected.Name = "ButtonNationalNetworks_RemoveSelected"
            Me.ButtonNationalNetworks_RemoveSelected.SecurityEnabled = True
            Me.ButtonNationalNetworks_RemoveSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalNetworks_RemoveSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalNetworks_RemoveSelected.TabIndex = 1
            Me.ButtonNationalNetworks_RemoveSelected.Text = "<"
            '
            'ExpandableSplitterControl4
            '
            Me.ExpandableSplitterControl4.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl4.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl4.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl4.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl4.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl4.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl4.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl4.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl4.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl4.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl4.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl4.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl4.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl4.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl4.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl4.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl4.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl4.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl4.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl4.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl4.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl4.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl4.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl4.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl4.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl4.Name = "ExpandableSplitterControl4"
            Me.ExpandableSplitterControl4.Size = New System.Drawing.Size(6, 439)
            Me.ExpandableSplitterControl4.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl4.TabIndex = 20
            Me.ExpandableSplitterControl4.TabStop = False
            '
            'PanelNationalNetworks_LeftSection
            '
            Me.PanelNationalNetworks_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalNetworks_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalNetworks_LeftSection.Controls.Add(Me.DataGridViewNational_NetworksAvailable)
            Me.PanelNationalNetworks_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelNationalNetworks_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelNationalNetworks_LeftSection.Name = "PanelNationalNetworks_LeftSection"
            Me.PanelNationalNetworks_LeftSection.Size = New System.Drawing.Size(317, 439)
            Me.PanelNationalNetworks_LeftSection.TabIndex = 0
            '
            'DataGridViewNational_NetworksAvailable
            '
            Me.DataGridViewNational_NetworksAvailable.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_NetworksAvailable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_NetworksAvailable.AutoUpdateViewCaption = True
            Me.DataGridViewNational_NetworksAvailable.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_NetworksAvailable.ItemDescription = "Available Network(s)"
            Me.DataGridViewNational_NetworksAvailable.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewNational_NetworksAvailable.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_NetworksAvailable.ModifyGridRowHeight = False
            Me.DataGridViewNational_NetworksAvailable.MultiSelect = True
            Me.DataGridViewNational_NetworksAvailable.Name = "DataGridViewNational_NetworksAvailable"
            Me.DataGridViewNational_NetworksAvailable.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_NetworksAvailable.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_NetworksAvailable.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_NetworksAvailable.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_NetworksAvailable.Size = New System.Drawing.Size(306, 429)
            Me.DataGridViewNational_NetworksAvailable.TabIndex = 0
            Me.DataGridViewNational_NetworksAvailable.UseEmbeddedNavigator = False
            Me.DataGridViewNational_NetworksAvailable.ViewCaptionHeight = -1
            '
            'GroupBoxNational_Ethnicity
            '
            Me.GroupBoxNational_Ethnicity.Controls.Add(Me.RadioButtonNationalEthnicity_Hispanic)
            Me.GroupBoxNational_Ethnicity.Controls.Add(Me.RadioButtonNationalEthnicity_GeneralMarket)
            Me.GroupBoxNational_Ethnicity.Location = New System.Drawing.Point(13, 35)
            Me.GroupBoxNational_Ethnicity.Name = "GroupBoxNational_Ethnicity"
            Me.GroupBoxNational_Ethnicity.Size = New System.Drawing.Size(245, 56)
            Me.GroupBoxNational_Ethnicity.TabIndex = 17
            Me.GroupBoxNational_Ethnicity.Text = "Ethnicity"
            '
            'RadioButtonNationalEthnicity_Hispanic
            '
            Me.RadioButtonNationalEthnicity_Hispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalEthnicity_Hispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalEthnicity_Hispanic.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalEthnicity_Hispanic.Location = New System.Drawing.Point(122, 22)
            Me.RadioButtonNationalEthnicity_Hispanic.Name = "RadioButtonNationalEthnicity_Hispanic"
            Me.RadioButtonNationalEthnicity_Hispanic.SecurityEnabled = True
            Me.RadioButtonNationalEthnicity_Hispanic.Size = New System.Drawing.Size(111, 20)
            Me.RadioButtonNationalEthnicity_Hispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalEthnicity_Hispanic.TabIndex = 3
            Me.RadioButtonNationalEthnicity_Hispanic.TabOnEnter = True
            Me.RadioButtonNationalEthnicity_Hispanic.TabStop = False
            Me.RadioButtonNationalEthnicity_Hispanic.Tag = "H"
            Me.RadioButtonNationalEthnicity_Hispanic.Text = "Hispanic"
            '
            'RadioButtonNationalEthnicity_GeneralMarket
            '
            Me.RadioButtonNationalEthnicity_GeneralMarket.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalEthnicity_GeneralMarket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalEthnicity_GeneralMarket.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalEthnicity_GeneralMarket.Checked = True
            Me.RadioButtonNationalEthnicity_GeneralMarket.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalEthnicity_GeneralMarket.CheckValue = "Y"
            Me.RadioButtonNationalEthnicity_GeneralMarket.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalEthnicity_GeneralMarket.Name = "RadioButtonNationalEthnicity_GeneralMarket"
            Me.RadioButtonNationalEthnicity_GeneralMarket.SecurityEnabled = True
            Me.RadioButtonNationalEthnicity_GeneralMarket.Size = New System.Drawing.Size(111, 20)
            Me.RadioButtonNationalEthnicity_GeneralMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalEthnicity_GeneralMarket.TabIndex = 1
            Me.RadioButtonNationalEthnicity_GeneralMarket.TabOnEnter = True
            Me.RadioButtonNationalEthnicity_GeneralMarket.Tag = "G"
            Me.RadioButtonNationalEthnicity_GeneralMarket.Text = "General Market"
            '
            'ComboBoxNational_ReportType
            '
            Me.ComboBoxNational_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNational_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxNational_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNational_ReportType.AutoFindItemInDataSource = True
            Me.ComboBoxNational_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNational_ReportType.BookmarkingEnabled = False
            Me.ComboBoxNational_ReportType.DisableMouseWheel = True
            Me.ComboBoxNational_ReportType.DisplayMember = "Display"
            Me.ComboBoxNational_ReportType.DisplayName = "Report Type"
            Me.ComboBoxNational_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNational_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxNational_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxNational_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNational_ReportType.FocusHighlightEnabled = True
            Me.ComboBoxNational_ReportType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNational_ReportType.FormattingEnabled = True
            Me.ComboBoxNational_ReportType.ItemHeight = 16
            Me.ComboBoxNational_ReportType.Location = New System.Drawing.Point(98, 7)
            Me.ComboBoxNational_ReportType.Name = "ComboBoxNational_ReportType"
            Me.ComboBoxNational_ReportType.ReadOnly = False
            Me.ComboBoxNational_ReportType.SecurityEnabled = True
            Me.ComboBoxNational_ReportType.Size = New System.Drawing.Size(213, 22)
            Me.ComboBoxNational_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNational_ReportType.TabIndex = 5
            Me.ComboBoxNational_ReportType.TabOnEnter = True
            Me.ComboBoxNational_ReportType.ValueMember = "Value"
            Me.ComboBoxNational_ReportType.WatermarkText = "Select Month"
            '
            'Label
            '
            Me.Label.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label.Location = New System.Drawing.Point(11, 5)
            Me.Label.Name = "Label"
            Me.Label.Size = New System.Drawing.Size(82, 20)
            Me.Label.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label.TabIndex = 4
            Me.Label.Text = "Report Type:"
            '
            'TabItemNational_ReportType
            '
            Me.TabItemNational_ReportType.AttachedControl = Me.TabControlPanelNationalReportType
            Me.TabItemNational_ReportType.Name = "TabItemNational_ReportType"
            Me.TabItemNational_ReportType.Text = "Report Type/Networks"
            '
            'TabControlPanelNationalDates
            '
            Me.TabControlPanelNationalDates.Controls.Add(Me.CheckBoxNationalDates_ShowAirings)
            Me.TabControlPanelNationalDates.Controls.Add(Me.CheckBoxNationalDates_ShowProgramTypes)
            Me.TabControlPanelNationalDates.Controls.Add(Me.ComboBoxNationalDates_Stream)
            Me.TabControlPanelNationalDates.Controls.Add(Me.LabelNationalDates_Stream)
            Me.TabControlPanelNationalDates.Controls.Add(Me.TextBoxNationalDates_EndTime)
            Me.TabControlPanelNationalDates.Controls.Add(Me.LabelNationalDates_EndTime)
            Me.TabControlPanelNationalDates.Controls.Add(Me.TextBoxNationalDates_StartTime)
            Me.TabControlPanelNationalDates.Controls.Add(Me.TextBoxNationalDates_Days)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Corrections)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Premieres)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Repeats)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Overnights)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Specials)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNationalDates_Breakouts)
            Me.TabControlPanelNationalDates.Controls.Add(Me.GroupBoxNational_DateCodeDates)
            Me.TabControlPanelNationalDates.Controls.Add(Me.LabelNationalDates_Days)
            Me.TabControlPanelNationalDates.Controls.Add(Me.LabelNationalDates_StartTime)
            Me.TabControlPanelNationalDates.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNationalDates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNationalDates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNationalDates.Name = "TabControlPanelNationalDates"
            Me.TabControlPanelNationalDates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNationalDates.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelNationalDates.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNationalDates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNationalDates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNationalDates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNationalDates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNationalDates.Style.GradientAngle = 90
            Me.TabControlPanelNationalDates.TabIndex = 50
            Me.TabControlPanelNationalDates.TabItem = Me.TabItemNational_Dates
            '
            'CheckBoxNationalDates_ShowAirings
            '
            Me.CheckBoxNationalDates_ShowAirings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDates_ShowAirings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDates_ShowAirings.CheckValue = 0
            Me.CheckBoxNationalDates_ShowAirings.CheckValueChecked = 1
            Me.CheckBoxNationalDates_ShowAirings.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDates_ShowAirings.CheckValueUnchecked = 0
            Me.CheckBoxNationalDates_ShowAirings.ChildControls = Nothing
            Me.CheckBoxNationalDates_ShowAirings.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDates_ShowAirings.Location = New System.Drawing.Point(11, 315)
            Me.CheckBoxNationalDates_ShowAirings.Name = "CheckBoxNationalDates_ShowAirings"
            Me.CheckBoxNationalDates_ShowAirings.OldestSibling = Nothing
            Me.CheckBoxNationalDates_ShowAirings.SecurityEnabled = True
            Me.CheckBoxNationalDates_ShowAirings.SiblingControls = Nothing
            Me.CheckBoxNationalDates_ShowAirings.Size = New System.Drawing.Size(133, 20)
            Me.CheckBoxNationalDates_ShowAirings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDates_ShowAirings.TabIndex = 22
            Me.CheckBoxNationalDates_ShowAirings.TabOnEnter = True
            Me.CheckBoxNationalDates_ShowAirings.Text = "Show # Airings"
            '
            'CheckBoxNationalDates_ShowProgramTypes
            '
            Me.CheckBoxNationalDates_ShowProgramTypes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxNationalDates_ShowProgramTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNationalDates_ShowProgramTypes.CheckValue = 0
            Me.CheckBoxNationalDates_ShowProgramTypes.CheckValueChecked = 1
            Me.CheckBoxNationalDates_ShowProgramTypes.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNationalDates_ShowProgramTypes.CheckValueUnchecked = 0
            Me.CheckBoxNationalDates_ShowProgramTypes.ChildControls = Nothing
            Me.CheckBoxNationalDates_ShowProgramTypes.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNationalDates_ShowProgramTypes.Location = New System.Drawing.Point(11, 289)
            Me.CheckBoxNationalDates_ShowProgramTypes.Name = "CheckBoxNationalDates_ShowProgramTypes"
            Me.CheckBoxNationalDates_ShowProgramTypes.OldestSibling = Nothing
            Me.CheckBoxNationalDates_ShowProgramTypes.SecurityEnabled = True
            Me.CheckBoxNationalDates_ShowProgramTypes.SiblingControls = Nothing
            Me.CheckBoxNationalDates_ShowProgramTypes.Size = New System.Drawing.Size(133, 20)
            Me.CheckBoxNationalDates_ShowProgramTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNationalDates_ShowProgramTypes.TabIndex = 21
            Me.CheckBoxNationalDates_ShowProgramTypes.TabOnEnter = True
            Me.CheckBoxNationalDates_ShowProgramTypes.Text = "Show Program Types"
            '
            'ComboBoxNationalDates_Stream
            '
            Me.ComboBoxNationalDates_Stream.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNationalDates_Stream.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxNationalDates_Stream.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNationalDates_Stream.AutoFindItemInDataSource = True
            Me.ComboBoxNationalDates_Stream.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNationalDates_Stream.BookmarkingEnabled = False
            Me.ComboBoxNationalDates_Stream.DisableMouseWheel = True
            Me.ComboBoxNationalDates_Stream.DisplayMember = "Display"
            Me.ComboBoxNationalDates_Stream.DisplayName = "Stream"
            Me.ComboBoxNationalDates_Stream.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNationalDates_Stream.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxNationalDates_Stream.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxNationalDates_Stream.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNationalDates_Stream.FocusHighlightEnabled = True
            Me.ComboBoxNationalDates_Stream.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNationalDates_Stream.FormattingEnabled = True
            Me.ComboBoxNationalDates_Stream.ItemHeight = 16
            Me.ComboBoxNationalDates_Stream.Location = New System.Drawing.Point(273, 67)
            Me.ComboBoxNationalDates_Stream.Name = "ComboBoxNationalDates_Stream"
            Me.ComboBoxNationalDates_Stream.ReadOnly = False
            Me.ComboBoxNationalDates_Stream.SecurityEnabled = True
            Me.ComboBoxNationalDates_Stream.Size = New System.Drawing.Size(80, 22)
            Me.ComboBoxNationalDates_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNationalDates_Stream.TabIndex = 4
            Me.ComboBoxNationalDates_Stream.TabOnEnter = True
            Me.ComboBoxNationalDates_Stream.ValueMember = "Value"
            Me.ComboBoxNationalDates_Stream.WatermarkText = "Select Month"
            '
            'LabelNationalDates_Stream
            '
            Me.LabelNationalDates_Stream.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_Stream.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_Stream.Location = New System.Drawing.Point(185, 69)
            Me.LabelNationalDates_Stream.Name = "LabelNationalDates_Stream"
            Me.LabelNationalDates_Stream.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_Stream.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_Stream.TabIndex = 3
            Me.LabelNationalDates_Stream.Text = "Stream:"
            '
            'TextBoxNationalDates_EndTime
            '
            Me.TextBoxNationalDates_EndTime.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxNationalDates_EndTime.Border.Class = "TextBoxBorder"
            Me.TextBoxNationalDates_EndTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNationalDates_EndTime.CheckSpellingOnValidate = False
            Me.TextBoxNationalDates_EndTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNationalDates_EndTime.DisplayName = "End Time"
            Me.TextBoxNationalDates_EndTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNationalDates_EndTime.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNationalDates_EndTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNationalDates_EndTime.FocusHighlightEnabled = True
            Me.TextBoxNationalDates_EndTime.Location = New System.Drawing.Point(273, 95)
            Me.TextBoxNationalDates_EndTime.MaxFileSize = CType(0, Long)
            Me.TextBoxNationalDates_EndTime.Name = "TextBoxNationalDates_EndTime"
            Me.TextBoxNationalDates_EndTime.SecurityEnabled = True
            Me.TextBoxNationalDates_EndTime.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNationalDates_EndTime.Size = New System.Drawing.Size(80, 21)
            Me.TextBoxNationalDates_EndTime.StartingFolderName = Nothing
            Me.TextBoxNationalDates_EndTime.TabIndex = 8
            Me.TextBoxNationalDates_EndTime.TabOnEnter = True
            '
            'LabelNationalDates_EndTime
            '
            Me.LabelNationalDates_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_EndTime.Location = New System.Drawing.Point(185, 95)
            Me.LabelNationalDates_EndTime.Name = "LabelNationalDates_EndTime"
            Me.LabelNationalDates_EndTime.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_EndTime.TabIndex = 7
            Me.LabelNationalDates_EndTime.Text = "End Time:"
            '
            'TextBoxNationalDates_StartTime
            '
            Me.TextBoxNationalDates_StartTime.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxNationalDates_StartTime.Border.Class = "TextBoxBorder"
            Me.TextBoxNationalDates_StartTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNationalDates_StartTime.CheckSpellingOnValidate = False
            Me.TextBoxNationalDates_StartTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNationalDates_StartTime.DisplayName = "Start Time"
            Me.TextBoxNationalDates_StartTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNationalDates_StartTime.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNationalDates_StartTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNationalDates_StartTime.FocusHighlightEnabled = True
            Me.TextBoxNationalDates_StartTime.Location = New System.Drawing.Point(99, 95)
            Me.TextBoxNationalDates_StartTime.MaxFileSize = CType(0, Long)
            Me.TextBoxNationalDates_StartTime.Name = "TextBoxNationalDates_StartTime"
            Me.TextBoxNationalDates_StartTime.SecurityEnabled = True
            Me.TextBoxNationalDates_StartTime.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNationalDates_StartTime.Size = New System.Drawing.Size(80, 21)
            Me.TextBoxNationalDates_StartTime.StartingFolderName = Nothing
            Me.TextBoxNationalDates_StartTime.TabIndex = 6
            Me.TextBoxNationalDates_StartTime.TabOnEnter = True
            '
            'TextBoxNationalDates_Days
            '
            Me.TextBoxNationalDates_Days.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxNationalDates_Days.Border.Class = "TextBoxBorder"
            Me.TextBoxNationalDates_Days.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNationalDates_Days.CheckSpellingOnValidate = False
            Me.TextBoxNationalDates_Days.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNationalDates_Days.DisplayName = "Days"
            Me.TextBoxNationalDates_Days.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNationalDates_Days.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNationalDates_Days.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNationalDates_Days.FocusHighlightEnabled = True
            Me.TextBoxNationalDates_Days.Location = New System.Drawing.Point(99, 69)
            Me.TextBoxNationalDates_Days.MaxFileSize = CType(0, Long)
            Me.TextBoxNationalDates_Days.Name = "TextBoxNationalDates_Days"
            Me.TextBoxNationalDates_Days.SecurityEnabled = True
            Me.TextBoxNationalDates_Days.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNationalDates_Days.Size = New System.Drawing.Size(80, 21)
            Me.TextBoxNationalDates_Days.StartingFolderName = Nothing
            Me.TextBoxNationalDates_Days.TabIndex = 2
            Me.TextBoxNationalDates_Days.TabOnEnter = True
            '
            'GroupBoxNationalDates_Corrections
            '
            Me.GroupBoxNationalDates_Corrections.Controls.Add(Me.RadioButtonNationalCorrections_Exclude)
            Me.GroupBoxNationalDates_Corrections.Controls.Add(Me.RadioButtonNationalCorrections_Only)
            Me.GroupBoxNationalDates_Corrections.Controls.Add(Me.RadioButtonNationalCorrections_Ignore)
            Me.GroupBoxNationalDates_Corrections.Location = New System.Drawing.Point(329, 233)
            Me.GroupBoxNationalDates_Corrections.Name = "GroupBoxNationalDates_Corrections"
            Me.GroupBoxNationalDates_Corrections.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Corrections.TabIndex = 18
            Me.GroupBoxNationalDates_Corrections.Text = "Corrections"
            '
            'RadioButtonNationalCorrections_Exclude
            '
            Me.RadioButtonNationalCorrections_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalCorrections_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalCorrections_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalCorrections_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalCorrections_Exclude.Name = "RadioButtonNationalCorrections_Exclude"
            Me.RadioButtonNationalCorrections_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalCorrections_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalCorrections_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalCorrections_Exclude.TabIndex = 4
            Me.RadioButtonNationalCorrections_Exclude.TabOnEnter = True
            Me.RadioButtonNationalCorrections_Exclude.TabStop = False
            Me.RadioButtonNationalCorrections_Exclude.Tag = "E"
            Me.RadioButtonNationalCorrections_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalCorrections_Only
            '
            Me.RadioButtonNationalCorrections_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalCorrections_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalCorrections_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalCorrections_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalCorrections_Only.Name = "RadioButtonNationalCorrections_Only"
            Me.RadioButtonNationalCorrections_Only.SecurityEnabled = True
            Me.RadioButtonNationalCorrections_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalCorrections_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalCorrections_Only.TabIndex = 3
            Me.RadioButtonNationalCorrections_Only.TabOnEnter = True
            Me.RadioButtonNationalCorrections_Only.TabStop = False
            Me.RadioButtonNationalCorrections_Only.Tag = "O"
            Me.RadioButtonNationalCorrections_Only.Text = "Only"
            '
            'RadioButtonNationalCorrections_Ignore
            '
            Me.RadioButtonNationalCorrections_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalCorrections_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalCorrections_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalCorrections_Ignore.Checked = True
            Me.RadioButtonNationalCorrections_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalCorrections_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalCorrections_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalCorrections_Ignore.Name = "RadioButtonNationalCorrections_Ignore"
            Me.RadioButtonNationalCorrections_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalCorrections_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalCorrections_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalCorrections_Ignore.TabIndex = 1
            Me.RadioButtonNationalCorrections_Ignore.TabOnEnter = True
            Me.RadioButtonNationalCorrections_Ignore.Tag = "I"
            Me.RadioButtonNationalCorrections_Ignore.Text = "Include"
            '
            'GroupBoxNationalDates_Premieres
            '
            Me.GroupBoxNationalDates_Premieres.Controls.Add(Me.RadioButtonNationalPremieres_Exclude)
            Me.GroupBoxNationalDates_Premieres.Controls.Add(Me.RadioButtonNationalPremieres_Only)
            Me.GroupBoxNationalDates_Premieres.Controls.Add(Me.RadioButtonNationalPremieres_Ignore)
            Me.GroupBoxNationalDates_Premieres.Location = New System.Drawing.Point(329, 177)
            Me.GroupBoxNationalDates_Premieres.Name = "GroupBoxNationalDates_Premieres"
            Me.GroupBoxNationalDates_Premieres.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Premieres.TabIndex = 16
            Me.GroupBoxNationalDates_Premieres.Text = "Premieres"
            '
            'RadioButtonNationalPremieres_Exclude
            '
            Me.RadioButtonNationalPremieres_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalPremieres_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalPremieres_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalPremieres_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalPremieres_Exclude.Name = "RadioButtonNationalPremieres_Exclude"
            Me.RadioButtonNationalPremieres_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalPremieres_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalPremieres_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalPremieres_Exclude.TabIndex = 4
            Me.RadioButtonNationalPremieres_Exclude.TabOnEnter = True
            Me.RadioButtonNationalPremieres_Exclude.TabStop = False
            Me.RadioButtonNationalPremieres_Exclude.Tag = "E"
            Me.RadioButtonNationalPremieres_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalPremieres_Only
            '
            Me.RadioButtonNationalPremieres_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalPremieres_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalPremieres_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalPremieres_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalPremieres_Only.Name = "RadioButtonNationalPremieres_Only"
            Me.RadioButtonNationalPremieres_Only.SecurityEnabled = True
            Me.RadioButtonNationalPremieres_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalPremieres_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalPremieres_Only.TabIndex = 3
            Me.RadioButtonNationalPremieres_Only.TabOnEnter = True
            Me.RadioButtonNationalPremieres_Only.TabStop = False
            Me.RadioButtonNationalPremieres_Only.Tag = "O"
            Me.RadioButtonNationalPremieres_Only.Text = "Only"
            '
            'RadioButtonNationalPremieres_Ignore
            '
            Me.RadioButtonNationalPremieres_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalPremieres_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalPremieres_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalPremieres_Ignore.Checked = True
            Me.RadioButtonNationalPremieres_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalPremieres_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalPremieres_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalPremieres_Ignore.Name = "RadioButtonNationalPremieres_Ignore"
            Me.RadioButtonNationalPremieres_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalPremieres_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalPremieres_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalPremieres_Ignore.TabIndex = 1
            Me.RadioButtonNationalPremieres_Ignore.TabOnEnter = True
            Me.RadioButtonNationalPremieres_Ignore.Tag = "I"
            Me.RadioButtonNationalPremieres_Ignore.Text = "Include"
            '
            'GroupBoxNationalDates_Repeats
            '
            Me.GroupBoxNationalDates_Repeats.Controls.Add(Me.RadioButtonNationalRepeats_Exclude)
            Me.GroupBoxNationalDates_Repeats.Controls.Add(Me.RadioButtonNationalRepeats_Only)
            Me.GroupBoxNationalDates_Repeats.Controls.Add(Me.RadioButtonNationalRepeats_Ignore)
            Me.GroupBoxNationalDates_Repeats.Location = New System.Drawing.Point(329, 121)
            Me.GroupBoxNationalDates_Repeats.Name = "GroupBoxNationalDates_Repeats"
            Me.GroupBoxNationalDates_Repeats.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Repeats.TabIndex = 14
            Me.GroupBoxNationalDates_Repeats.Text = "Repeats"
            '
            'RadioButtonNationalRepeats_Exclude
            '
            Me.RadioButtonNationalRepeats_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalRepeats_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalRepeats_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalRepeats_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalRepeats_Exclude.Name = "RadioButtonNationalRepeats_Exclude"
            Me.RadioButtonNationalRepeats_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalRepeats_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalRepeats_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalRepeats_Exclude.TabIndex = 4
            Me.RadioButtonNationalRepeats_Exclude.TabOnEnter = True
            Me.RadioButtonNationalRepeats_Exclude.TabStop = False
            Me.RadioButtonNationalRepeats_Exclude.Tag = "E"
            Me.RadioButtonNationalRepeats_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalRepeats_Only
            '
            Me.RadioButtonNationalRepeats_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalRepeats_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalRepeats_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalRepeats_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalRepeats_Only.Name = "RadioButtonNationalRepeats_Only"
            Me.RadioButtonNationalRepeats_Only.SecurityEnabled = True
            Me.RadioButtonNationalRepeats_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalRepeats_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalRepeats_Only.TabIndex = 3
            Me.RadioButtonNationalRepeats_Only.TabOnEnter = True
            Me.RadioButtonNationalRepeats_Only.TabStop = False
            Me.RadioButtonNationalRepeats_Only.Tag = "O"
            Me.RadioButtonNationalRepeats_Only.Text = "Only"
            '
            'RadioButtonNationalRepeats_Ignore
            '
            Me.RadioButtonNationalRepeats_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalRepeats_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalRepeats_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalRepeats_Ignore.Checked = True
            Me.RadioButtonNationalRepeats_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalRepeats_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalRepeats_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalRepeats_Ignore.Name = "RadioButtonNationalRepeats_Ignore"
            Me.RadioButtonNationalRepeats_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalRepeats_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalRepeats_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalRepeats_Ignore.TabIndex = 1
            Me.RadioButtonNationalRepeats_Ignore.TabOnEnter = True
            Me.RadioButtonNationalRepeats_Ignore.Tag = "I"
            Me.RadioButtonNationalRepeats_Ignore.Text = "Include"
            '
            'GroupBoxNationalDates_Overnights
            '
            Me.GroupBoxNationalDates_Overnights.Controls.Add(Me.RadioButtonNationalOvernights_Exclude)
            Me.GroupBoxNationalDates_Overnights.Controls.Add(Me.RadioButtonNationalOvernights_Only)
            Me.GroupBoxNationalDates_Overnights.Controls.Add(Me.RadioButtonNationalOvernights_Ignore)
            Me.GroupBoxNationalDates_Overnights.Location = New System.Drawing.Point(11, 233)
            Me.GroupBoxNationalDates_Overnights.Name = "GroupBoxNationalDates_Overnights"
            Me.GroupBoxNationalDates_Overnights.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Overnights.TabIndex = 17
            Me.GroupBoxNationalDates_Overnights.Text = "Overnights"
            '
            'RadioButtonNationalOvernights_Exclude
            '
            Me.RadioButtonNationalOvernights_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalOvernights_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalOvernights_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalOvernights_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalOvernights_Exclude.Name = "RadioButtonNationalOvernights_Exclude"
            Me.RadioButtonNationalOvernights_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalOvernights_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalOvernights_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalOvernights_Exclude.TabIndex = 4
            Me.RadioButtonNationalOvernights_Exclude.TabOnEnter = True
            Me.RadioButtonNationalOvernights_Exclude.TabStop = False
            Me.RadioButtonNationalOvernights_Exclude.Tag = "E"
            Me.RadioButtonNationalOvernights_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalOvernights_Only
            '
            Me.RadioButtonNationalOvernights_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalOvernights_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalOvernights_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalOvernights_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalOvernights_Only.Name = "RadioButtonNationalOvernights_Only"
            Me.RadioButtonNationalOvernights_Only.SecurityEnabled = True
            Me.RadioButtonNationalOvernights_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalOvernights_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalOvernights_Only.TabIndex = 3
            Me.RadioButtonNationalOvernights_Only.TabOnEnter = True
            Me.RadioButtonNationalOvernights_Only.TabStop = False
            Me.RadioButtonNationalOvernights_Only.Tag = "O"
            Me.RadioButtonNationalOvernights_Only.Text = "Only"
            '
            'RadioButtonNationalOvernights_Ignore
            '
            Me.RadioButtonNationalOvernights_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalOvernights_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalOvernights_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalOvernights_Ignore.Checked = True
            Me.RadioButtonNationalOvernights_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalOvernights_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalOvernights_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalOvernights_Ignore.Name = "RadioButtonNationalOvernights_Ignore"
            Me.RadioButtonNationalOvernights_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalOvernights_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalOvernights_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalOvernights_Ignore.TabIndex = 1
            Me.RadioButtonNationalOvernights_Ignore.TabOnEnter = True
            Me.RadioButtonNationalOvernights_Ignore.Tag = "I"
            Me.RadioButtonNationalOvernights_Ignore.Text = "Include"
            '
            'GroupBoxNationalDates_Specials
            '
            Me.GroupBoxNationalDates_Specials.Controls.Add(Me.RadioButtonNationalSpecials_Exclude)
            Me.GroupBoxNationalDates_Specials.Controls.Add(Me.RadioButtonNationalSpecials_Only)
            Me.GroupBoxNationalDates_Specials.Controls.Add(Me.RadioButtonNationalSpecials_Ignore)
            Me.GroupBoxNationalDates_Specials.Location = New System.Drawing.Point(11, 177)
            Me.GroupBoxNationalDates_Specials.Name = "GroupBoxNationalDates_Specials"
            Me.GroupBoxNationalDates_Specials.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Specials.TabIndex = 15
            Me.GroupBoxNationalDates_Specials.Text = "Specials"
            '
            'RadioButtonNationalSpecials_Exclude
            '
            Me.RadioButtonNationalSpecials_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalSpecials_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalSpecials_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalSpecials_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalSpecials_Exclude.Name = "RadioButtonNationalSpecials_Exclude"
            Me.RadioButtonNationalSpecials_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalSpecials_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalSpecials_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalSpecials_Exclude.TabIndex = 4
            Me.RadioButtonNationalSpecials_Exclude.TabOnEnter = True
            Me.RadioButtonNationalSpecials_Exclude.TabStop = False
            Me.RadioButtonNationalSpecials_Exclude.Tag = "E"
            Me.RadioButtonNationalSpecials_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalSpecials_Only
            '
            Me.RadioButtonNationalSpecials_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalSpecials_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalSpecials_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalSpecials_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalSpecials_Only.Name = "RadioButtonNationalSpecials_Only"
            Me.RadioButtonNationalSpecials_Only.SecurityEnabled = True
            Me.RadioButtonNationalSpecials_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalSpecials_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalSpecials_Only.TabIndex = 3
            Me.RadioButtonNationalSpecials_Only.TabOnEnter = True
            Me.RadioButtonNationalSpecials_Only.TabStop = False
            Me.RadioButtonNationalSpecials_Only.Tag = "O"
            Me.RadioButtonNationalSpecials_Only.Text = "Only"
            '
            'RadioButtonNationalSpecials_Ignore
            '
            Me.RadioButtonNationalSpecials_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalSpecials_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalSpecials_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalSpecials_Ignore.Checked = True
            Me.RadioButtonNationalSpecials_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalSpecials_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalSpecials_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalSpecials_Ignore.Name = "RadioButtonNationalSpecials_Ignore"
            Me.RadioButtonNationalSpecials_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalSpecials_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalSpecials_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalSpecials_Ignore.TabIndex = 1
            Me.RadioButtonNationalSpecials_Ignore.TabOnEnter = True
            Me.RadioButtonNationalSpecials_Ignore.Tag = "I"
            Me.RadioButtonNationalSpecials_Ignore.Text = "Include"
            '
            'GroupBoxNationalDates_Breakouts
            '
            Me.GroupBoxNationalDates_Breakouts.Controls.Add(Me.RadioButtonNationalBreakout_Exclude)
            Me.GroupBoxNationalDates_Breakouts.Controls.Add(Me.RadioButtonNationalBreakout_Only)
            Me.GroupBoxNationalDates_Breakouts.Controls.Add(Me.RadioButtonNationalBreakout_Ignore)
            Me.GroupBoxNationalDates_Breakouts.Location = New System.Drawing.Point(11, 121)
            Me.GroupBoxNationalDates_Breakouts.Name = "GroupBoxNationalDates_Breakouts"
            Me.GroupBoxNationalDates_Breakouts.Size = New System.Drawing.Size(312, 50)
            Me.GroupBoxNationalDates_Breakouts.TabIndex = 13
            Me.GroupBoxNationalDates_Breakouts.Text = "Breakouts"
            '
            'RadioButtonNationalBreakout_Exclude
            '
            Me.RadioButtonNationalBreakout_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalBreakout_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalBreakout_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalBreakout_Exclude.Location = New System.Drawing.Point(170, 22)
            Me.RadioButtonNationalBreakout_Exclude.Name = "RadioButtonNationalBreakout_Exclude"
            Me.RadioButtonNationalBreakout_Exclude.SecurityEnabled = True
            Me.RadioButtonNationalBreakout_Exclude.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalBreakout_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalBreakout_Exclude.TabIndex = 4
            Me.RadioButtonNationalBreakout_Exclude.TabOnEnter = True
            Me.RadioButtonNationalBreakout_Exclude.TabStop = False
            Me.RadioButtonNationalBreakout_Exclude.Tag = "E"
            Me.RadioButtonNationalBreakout_Exclude.Text = "Exclude"
            '
            'RadioButtonNationalBreakout_Only
            '
            Me.RadioButtonNationalBreakout_Only.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalBreakout_Only.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalBreakout_Only.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalBreakout_Only.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonNationalBreakout_Only.Name = "RadioButtonNationalBreakout_Only"
            Me.RadioButtonNationalBreakout_Only.SecurityEnabled = True
            Me.RadioButtonNationalBreakout_Only.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalBreakout_Only.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalBreakout_Only.TabIndex = 3
            Me.RadioButtonNationalBreakout_Only.TabOnEnter = True
            Me.RadioButtonNationalBreakout_Only.TabStop = False
            Me.RadioButtonNationalBreakout_Only.Tag = "O"
            Me.RadioButtonNationalBreakout_Only.Text = "Only"
            '
            'RadioButtonNationalBreakout_Ignore
            '
            Me.RadioButtonNationalBreakout_Ignore.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationalBreakout_Ignore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationalBreakout_Ignore.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationalBreakout_Ignore.Checked = True
            Me.RadioButtonNationalBreakout_Ignore.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationalBreakout_Ignore.CheckValue = "Y"
            Me.RadioButtonNationalBreakout_Ignore.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonNationalBreakout_Ignore.Name = "RadioButtonNationalBreakout_Ignore"
            Me.RadioButtonNationalBreakout_Ignore.SecurityEnabled = True
            Me.RadioButtonNationalBreakout_Ignore.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonNationalBreakout_Ignore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationalBreakout_Ignore.TabIndex = 1
            Me.RadioButtonNationalBreakout_Ignore.TabOnEnter = True
            Me.RadioButtonNationalBreakout_Ignore.Tag = "I"
            Me.RadioButtonNationalBreakout_Ignore.Text = "Include"
            '
            'GroupBoxNational_DateCodeDates
            '
            Me.GroupBoxNational_DateCodeDates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.DateEditNationalDates_EndDate)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.DateEditNationalDates_StartDate)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.LabelNationalDates_EndDate)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.RadioButtonNationDates_Dates)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.RadioButtonNationDates_DateCode)
            Me.GroupBoxNational_DateCodeDates.Controls.Add(Me.LabelNationalDates_StartDate)
            Me.GroupBoxNational_DateCodeDates.Location = New System.Drawing.Point(11, 7)
            Me.GroupBoxNational_DateCodeDates.Name = "GroupBoxNational_DateCodeDates"
            Me.GroupBoxNational_DateCodeDates.Size = New System.Drawing.Size(810, 56)
            Me.GroupBoxNational_DateCodeDates.TabIndex = 0
            Me.GroupBoxNational_DateCodeDates.Text = "Dates / Date Code"
            '
            'DateEditNationalDates_EndDate
            '
            Me.DateEditNationalDates_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditNationalDates_EndDate.DisplayName = ""
            Me.DateEditNationalDates_EndDate.EditValue = Nothing
            Me.DateEditNationalDates_EndDate.Location = New System.Drawing.Point(351, 24)
            Me.DateEditNationalDates_EndDate.Name = "DateEditNationalDates_EndDate"
            Me.DateEditNationalDates_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditNationalDates_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditNationalDates_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditNationalDates_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditNationalDates_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditNationalDates_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditNationalDates_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditNationalDates_EndDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditNationalDates_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditNationalDates_EndDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditNationalDates_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditNationalDates_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditNationalDates_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditNationalDates_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditNationalDates_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditNationalDates_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditNationalDates_EndDate.SecurityEnabled = True
            Me.DateEditNationalDates_EndDate.Size = New System.Drawing.Size(97, 20)
            Me.DateEditNationalDates_EndDate.TabIndex = 5
            Me.DateEditNationalDates_EndDate.TabOnEnter = True
            Me.DateEditNationalDates_EndDate.Tag = "9/2/2015"
            '
            'DateEditNationalDates_StartDate
            '
            Me.DateEditNationalDates_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditNationalDates_StartDate.DisplayName = ""
            Me.DateEditNationalDates_StartDate.EditValue = Nothing
            Me.DateEditNationalDates_StartDate.Location = New System.Drawing.Point(160, 24)
            Me.DateEditNationalDates_StartDate.Name = "DateEditNationalDates_StartDate"
            Me.DateEditNationalDates_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditNationalDates_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditNationalDates_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditNationalDates_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditNationalDates_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditNationalDates_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditNationalDates_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditNationalDates_StartDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditNationalDates_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditNationalDates_StartDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditNationalDates_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditNationalDates_StartDate.Properties.Mask.EditMask = ""
            Me.DateEditNationalDates_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditNationalDates_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditNationalDates_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditNationalDates_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditNationalDates_StartDate.SecurityEnabled = True
            Me.DateEditNationalDates_StartDate.Size = New System.Drawing.Size(97, 20)
            Me.DateEditNationalDates_StartDate.TabIndex = 3
            Me.DateEditNationalDates_StartDate.TabOnEnter = True
            Me.DateEditNationalDates_StartDate.Tag = "9/2/2015"
            '
            'LabelNationalDates_EndDate
            '
            Me.LabelNationalDates_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_EndDate.Location = New System.Drawing.Point(263, 24)
            Me.LabelNationalDates_EndDate.Name = "LabelNationalDates_EndDate"
            Me.LabelNationalDates_EndDate.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_EndDate.TabIndex = 4
            Me.LabelNationalDates_EndDate.Text = "End Date:"
            '
            'RadioButtonNationDates_Dates
            '
            Me.RadioButtonNationDates_Dates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationDates_Dates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationDates_Dates.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationDates_Dates.Checked = True
            Me.RadioButtonNationDates_Dates.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNationDates_Dates.CheckValue = "Y"
            Me.RadioButtonNationDates_Dates.Location = New System.Drawing.Point(7, 24)
            Me.RadioButtonNationDates_Dates.Name = "RadioButtonNationDates_Dates"
            Me.RadioButtonNationDates_Dates.SecurityEnabled = True
            Me.RadioButtonNationDates_Dates.Size = New System.Drawing.Size(59, 20)
            Me.RadioButtonNationDates_Dates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationDates_Dates.TabIndex = 1
            Me.RadioButtonNationDates_Dates.TabOnEnter = True
            Me.RadioButtonNationDates_Dates.Tag = "D"
            Me.RadioButtonNationDates_Dates.Text = "Dates"
            '
            'RadioButtonNationDates_DateCode
            '
            Me.RadioButtonNationDates_DateCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNationDates_DateCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNationDates_DateCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNationDates_DateCode.Location = New System.Drawing.Point(482, 24)
            Me.RadioButtonNationDates_DateCode.Name = "RadioButtonNationDates_DateCode"
            Me.RadioButtonNationDates_DateCode.SecurityEnabled = True
            Me.RadioButtonNationDates_DateCode.Size = New System.Drawing.Size(83, 20)
            Me.RadioButtonNationDates_DateCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNationDates_DateCode.TabIndex = 6
            Me.RadioButtonNationDates_DateCode.TabOnEnter = True
            Me.RadioButtonNationDates_DateCode.TabStop = False
            Me.RadioButtonNationDates_DateCode.Tag = "C"
            Me.RadioButtonNationDates_DateCode.Text = "Date Code"
            Me.RadioButtonNationDates_DateCode.Visible = False
            '
            'LabelNationalDates_StartDate
            '
            Me.LabelNationalDates_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_StartDate.Location = New System.Drawing.Point(72, 24)
            Me.LabelNationalDates_StartDate.Name = "LabelNationalDates_StartDate"
            Me.LabelNationalDates_StartDate.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_StartDate.TabIndex = 2
            Me.LabelNationalDates_StartDate.Text = "Start Date:"
            '
            'LabelNationalDates_Days
            '
            Me.LabelNationalDates_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_Days.Location = New System.Drawing.Point(11, 69)
            Me.LabelNationalDates_Days.Name = "LabelNationalDates_Days"
            Me.LabelNationalDates_Days.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_Days.TabIndex = 1
            Me.LabelNationalDates_Days.Text = "Days:"
            '
            'LabelNationalDates_StartTime
            '
            Me.LabelNationalDates_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNationalDates_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNationalDates_StartTime.Location = New System.Drawing.Point(11, 95)
            Me.LabelNationalDates_StartTime.Name = "LabelNationalDates_StartTime"
            Me.LabelNationalDates_StartTime.Size = New System.Drawing.Size(82, 20)
            Me.LabelNationalDates_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNationalDates_StartTime.TabIndex = 5
            Me.LabelNationalDates_StartTime.Text = "Start Time:"
            '
            'TabItemNational_Dates
            '
            Me.TabItemNational_Dates.AttachedControl = Me.TabControlPanelNationalDates
            Me.TabItemNational_Dates.Name = "TabItemNational_Dates"
            Me.TabItemNational_Dates.Text = "Dates/Days/Times/Filters"
            '
            'TabControlPanelNationalResults
            '
            Me.TabControlPanelNationalResults.Controls.Add(Me.TabControlResults_NationalResults)
            Me.TabControlPanelNationalResults.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNationalResults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNationalResults.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNationalResults.Name = "TabControlPanelNationalResults"
            Me.TabControlPanelNationalResults.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNationalResults.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelNationalResults.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNationalResults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNationalResults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNationalResults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNationalResults.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNationalResults.Style.GradientAngle = 90
            Me.TabControlPanelNationalResults.TabIndex = 34
            Me.TabControlPanelNationalResults.TabItem = Me.TabItemNational_Results
            '
            'TabControlResults_NationalResults
            '
            Me.TabControlResults_NationalResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlResults_NationalResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlResults_NationalResults.CanReorderTabs = False
            Me.TabControlResults_NationalResults.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlResults_NationalResults.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlResults_NationalResults.Controls.Add(Me.TabControlPanelNational_ResultsData)
            Me.TabControlResults_NationalResults.Controls.Add(Me.TabControlPanelNational_ResultsDashboard)
            Me.TabControlResults_NationalResults.ForeColor = System.Drawing.Color.Black
            Me.TabControlResults_NationalResults.Location = New System.Drawing.Point(4, 4)
            Me.TabControlResults_NationalResults.Name = "TabControlResults_NationalResults"
            Me.TabControlResults_NationalResults.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlResults_NationalResults.SelectedTabIndex = 0
            Me.TabControlResults_NationalResults.Size = New System.Drawing.Size(817, 536)
            Me.TabControlResults_NationalResults.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlResults_NationalResults.TabIndex = 4
            Me.TabControlResults_NationalResults.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlResults_NationalResults.Tabs.Add(Me.TabItemNationalResults_Data)
            Me.TabControlResults_NationalResults.Tabs.Add(Me.TabItemNationalResults_Dashboard)
            Me.TabControlResults_NationalResults.TabStop = False
            '
            'TabControlPanelNational_ResultsData
            '
            Me.TabControlPanelNational_ResultsData.Controls.Add(Me.BandedDataGridViewNationalResults)
            Me.TabControlPanelNational_ResultsData.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNational_ResultsData.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNational_ResultsData.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNational_ResultsData.Name = "TabControlPanelNational_ResultsData"
            Me.TabControlPanelNational_ResultsData.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNational_ResultsData.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelNational_ResultsData.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNational_ResultsData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNational_ResultsData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNational_ResultsData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNational_ResultsData.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNational_ResultsData.Style.GradientAngle = 90
            Me.TabControlPanelNational_ResultsData.TabIndex = 10
            Me.TabControlPanelNational_ResultsData.TabItem = Me.TabItemNationalResults_Data
            '
            'BandedDataGridViewNationalResults
            '
            Me.BandedDataGridViewNationalResults.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewNationalResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewNationalResults.AutoUpdateViewCaption = True
            Me.BandedDataGridViewNationalResults.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewNationalResults.ItemDescription = "Item(s)"
            Me.BandedDataGridViewNationalResults.Location = New System.Drawing.Point(4, 4)
            Me.BandedDataGridViewNationalResults.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewNationalResults.ModifyGridRowHeight = False
            Me.BandedDataGridViewNationalResults.MultiSelect = True
            Me.BandedDataGridViewNationalResults.Name = "BandedDataGridViewNationalResults"
            Me.BandedDataGridViewNationalResults.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewNationalResults.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewNationalResults.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewNationalResults.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewNationalResults.Size = New System.Drawing.Size(808, 501)
            Me.BandedDataGridViewNationalResults.TabIndex = 0
            Me.BandedDataGridViewNationalResults.UseEmbeddedNavigator = False
            Me.BandedDataGridViewNationalResults.ViewCaptionHeight = -1
            '
            'TabItemNationalResults_Data
            '
            Me.TabItemNationalResults_Data.AttachedControl = Me.TabControlPanelNational_ResultsData
            Me.TabItemNationalResults_Data.Name = "TabItemNationalResults_Data"
            Me.TabItemNationalResults_Data.Text = "Data"
            '
            'TabControlPanelNational_ResultsDashboard
            '
            Me.TabControlPanelNational_ResultsDashboard.Controls.Add(Me.DashboardViewerControl1)
            Me.TabControlPanelNational_ResultsDashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNational_ResultsDashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNational_ResultsDashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNational_ResultsDashboard.Name = "TabControlPanelNational_ResultsDashboard"
            Me.TabControlPanelNational_ResultsDashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNational_ResultsDashboard.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelNational_ResultsDashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNational_ResultsDashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNational_ResultsDashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNational_ResultsDashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNational_ResultsDashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNational_ResultsDashboard.Style.GradientAngle = 90
            Me.TabControlPanelNational_ResultsDashboard.TabIndex = 11
            Me.TabControlPanelNational_ResultsDashboard.TabItem = Me.TabItemNationalResults_Dashboard
            '
            'DashboardViewerControl1
            '
            Me.DashboardViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DashboardViewerControl1.Location = New System.Drawing.Point(1, 1)
            Me.DashboardViewerControl1.Name = "DashboardViewerControl1"
            Me.DashboardViewerControl1.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerControl1.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerControl1.Size = New System.Drawing.Size(815, 507)
            Me.DashboardViewerControl1.TabIndex = 2
            '
            'TabItemNationalResults_Dashboard
            '
            Me.TabItemNationalResults_Dashboard.AttachedControl = Me.TabControlPanelNational_ResultsDashboard
            Me.TabItemNationalResults_Dashboard.Name = "TabItemNationalResults_Dashboard"
            Me.TabItemNationalResults_Dashboard.Text = "Dashboard"
            '
            'TabItemNational_Results
            '
            Me.TabItemNational_Results.AttachedControl = Me.TabControlPanelNationalResults
            Me.TabItemNational_Results.Name = "TabItemNational_Results"
            Me.TabItemNational_Results.Text = "Results"
            '
            'TabControlPanelNationalDemographics
            '
            Me.TabControlPanelNationalDemographics.Controls.Add(Me.PanelNationalDemographics)
            Me.TabControlPanelNationalDemographics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNationalDemographics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNationalDemographics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNationalDemographics.Name = "TabControlPanelNationalDemographics"
            Me.TabControlPanelNationalDemographics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNationalDemographics.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelNationalDemographics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNationalDemographics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNationalDemographics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNationalDemographics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNationalDemographics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNationalDemographics.Style.GradientAngle = 90
            Me.TabControlPanelNationalDemographics.TabIndex = 25
            Me.TabControlPanelNationalDemographics.TabItem = Me.TabItemNational_Demographics
            '
            'PanelNationalDemographics
            '
            Me.PanelNationalDemographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelNationalDemographics.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalDemographics.Appearance.Options.UseBackColor = True
            Me.PanelNationalDemographics.Controls.Add(Me.PanelNationalDemographics_RightSection)
            Me.PanelNationalDemographics.Controls.Add(Me.ExpandableSplitterControl3)
            Me.PanelNationalDemographics.Controls.Add(Me.PanelNationalDemographics_LeftSection)
            Me.PanelNationalDemographics.Location = New System.Drawing.Point(4, 4)
            Me.PanelNationalDemographics.Name = "PanelNationalDemographics"
            Me.PanelNationalDemographics.Size = New System.Drawing.Size(817, 536)
            Me.PanelNationalDemographics.TabIndex = 8
            '
            'PanelNationalDemographics_RightSection
            '
            Me.PanelNationalDemographics_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalDemographics_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalDemographics_RightSection.Controls.Add(Me.DataGridViewNational_DemographicsSelected)
            Me.PanelNationalDemographics_RightSection.Controls.Add(Me.ButtonNationalDemographics_AddSelected)
            Me.PanelNationalDemographics_RightSection.Controls.Add(Me.ButtonNationalDemographics_RemoveSelected)
            Me.PanelNationalDemographics_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelNationalDemographics_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelNationalDemographics_RightSection.Name = "PanelNationalDemographics_RightSection"
            Me.PanelNationalDemographics_RightSection.Size = New System.Drawing.Size(490, 532)
            Me.PanelNationalDemographics_RightSection.TabIndex = 1
            '
            'DataGridViewNational_DemographicsSelected
            '
            Me.DataGridViewNational_DemographicsSelected.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_DemographicsSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_DemographicsSelected.AutoUpdateViewCaption = True
            Me.DataGridViewNational_DemographicsSelected.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_DemographicsSelected.ItemDescription = "Selected Demographic(s)"
            Me.DataGridViewNational_DemographicsSelected.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewNational_DemographicsSelected.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_DemographicsSelected.ModifyGridRowHeight = False
            Me.DataGridViewNational_DemographicsSelected.MultiSelect = True
            Me.DataGridViewNational_DemographicsSelected.Name = "DataGridViewNational_DemographicsSelected"
            Me.DataGridViewNational_DemographicsSelected.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_DemographicsSelected.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_DemographicsSelected.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_DemographicsSelected.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_DemographicsSelected.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewNational_DemographicsSelected.TabIndex = 2
            Me.DataGridViewNational_DemographicsSelected.UseEmbeddedNavigator = False
            Me.DataGridViewNational_DemographicsSelected.ViewCaptionHeight = -1
            '
            'ButtonNationalDemographics_AddSelected
            '
            Me.ButtonNationalDemographics_AddSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalDemographics_AddSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalDemographics_AddSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonNationalDemographics_AddSelected.Name = "ButtonNationalDemographics_AddSelected"
            Me.ButtonNationalDemographics_AddSelected.SecurityEnabled = True
            Me.ButtonNationalDemographics_AddSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalDemographics_AddSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalDemographics_AddSelected.TabIndex = 0
            Me.ButtonNationalDemographics_AddSelected.Text = ">"
            '
            'ButtonNationalDemographics_RemoveSelected
            '
            Me.ButtonNationalDemographics_RemoveSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalDemographics_RemoveSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalDemographics_RemoveSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonNationalDemographics_RemoveSelected.Name = "ButtonNationalDemographics_RemoveSelected"
            Me.ButtonNationalDemographics_RemoveSelected.SecurityEnabled = True
            Me.ButtonNationalDemographics_RemoveSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalDemographics_RemoveSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalDemographics_RemoveSelected.TabIndex = 1
            Me.ButtonNationalDemographics_RemoveSelected.Text = "<"
            '
            'ExpandableSplitterControl3
            '
            Me.ExpandableSplitterControl3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl3.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl3.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl3.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl3.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl3.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl3.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl3.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl3.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl3.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl3.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl3.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl3.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl3.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl3.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl3.Name = "ExpandableSplitterControl3"
            Me.ExpandableSplitterControl3.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControl3.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl3.TabIndex = 20
            Me.ExpandableSplitterControl3.TabStop = False
            '
            'PanelNationalDemographics_LeftSection
            '
            Me.PanelNationalDemographics_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalDemographics_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalDemographics_LeftSection.Controls.Add(Me.DataGridViewNational_DemographicsAvailable)
            Me.PanelNationalDemographics_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelNationalDemographics_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelNationalDemographics_LeftSection.Name = "PanelNationalDemographics_LeftSection"
            Me.PanelNationalDemographics_LeftSection.Size = New System.Drawing.Size(317, 532)
            Me.PanelNationalDemographics_LeftSection.TabIndex = 0
            '
            'DataGridViewNational_DemographicsAvailable
            '
            Me.DataGridViewNational_DemographicsAvailable.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_DemographicsAvailable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_DemographicsAvailable.AutoUpdateViewCaption = True
            Me.DataGridViewNational_DemographicsAvailable.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_DemographicsAvailable.ItemDescription = "Available Demographic(s)"
            Me.DataGridViewNational_DemographicsAvailable.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewNational_DemographicsAvailable.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_DemographicsAvailable.ModifyGridRowHeight = False
            Me.DataGridViewNational_DemographicsAvailable.MultiSelect = True
            Me.DataGridViewNational_DemographicsAvailable.Name = "DataGridViewNational_DemographicsAvailable"
            Me.DataGridViewNational_DemographicsAvailable.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_DemographicsAvailable.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_DemographicsAvailable.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_DemographicsAvailable.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_DemographicsAvailable.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewNational_DemographicsAvailable.TabIndex = 0
            Me.DataGridViewNational_DemographicsAvailable.UseEmbeddedNavigator = False
            Me.DataGridViewNational_DemographicsAvailable.ViewCaptionHeight = -1
            '
            'TabItemNational_Demographics
            '
            Me.TabItemNational_Demographics.AttachedControl = Me.TabControlPanelNationalDemographics
            Me.TabItemNational_Demographics.Name = "TabItemNational_Demographics"
            Me.TabItemNational_Demographics.Text = "Demographics"
            '
            'TabControlPanelNationalMetrics
            '
            Me.TabControlPanelNationalMetrics.Controls.Add(Me.PanelNationalMetrics)
            Me.TabControlPanelNationalMetrics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNationalMetrics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNationalMetrics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNationalMetrics.Name = "TabControlPanelNationalMetrics"
            Me.TabControlPanelNationalMetrics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNationalMetrics.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelNationalMetrics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNationalMetrics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNationalMetrics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNationalMetrics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNationalMetrics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNationalMetrics.Style.GradientAngle = 90
            Me.TabControlPanelNationalMetrics.TabIndex = 57
            Me.TabControlPanelNationalMetrics.TabItem = Me.TabItemNational_Metrics
            '
            'PanelNationalMetrics
            '
            Me.PanelNationalMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelNationalMetrics.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalMetrics.Appearance.Options.UseBackColor = True
            Me.PanelNationalMetrics.Controls.Add(Me.PanelNationalMetrics_RightSection)
            Me.PanelNationalMetrics.Controls.Add(Me.ExpandableSplitterControl5)
            Me.PanelNationalMetrics.Controls.Add(Me.PanelNationalMetrics_LeftSection)
            Me.PanelNationalMetrics.Location = New System.Drawing.Point(4, 4)
            Me.PanelNationalMetrics.Name = "PanelNationalMetrics"
            Me.PanelNationalMetrics.Size = New System.Drawing.Size(817, 536)
            Me.PanelNationalMetrics.TabIndex = 9
            '
            'PanelNationalMetrics_RightSection
            '
            Me.PanelNationalMetrics_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalMetrics_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalMetrics_RightSection.Controls.Add(Me.DataGridViewNational_MetricsSelected)
            Me.PanelNationalMetrics_RightSection.Controls.Add(Me.ButtonNationalMetrics_AddSelected)
            Me.PanelNationalMetrics_RightSection.Controls.Add(Me.ButtonNationalMetrics_RemoveSelected)
            Me.PanelNationalMetrics_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelNationalMetrics_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelNationalMetrics_RightSection.Name = "PanelNationalMetrics_RightSection"
            Me.PanelNationalMetrics_RightSection.Size = New System.Drawing.Size(490, 532)
            Me.PanelNationalMetrics_RightSection.TabIndex = 1
            '
            'DataGridViewNational_MetricsSelected
            '
            Me.DataGridViewNational_MetricsSelected.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_MetricsSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_MetricsSelected.AutoUpdateViewCaption = True
            Me.DataGridViewNational_MetricsSelected.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_MetricsSelected.ItemDescription = "Selected Metric(s)"
            Me.DataGridViewNational_MetricsSelected.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewNational_MetricsSelected.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_MetricsSelected.ModifyGridRowHeight = False
            Me.DataGridViewNational_MetricsSelected.MultiSelect = True
            Me.DataGridViewNational_MetricsSelected.Name = "DataGridViewNational_MetricsSelected"
            Me.DataGridViewNational_MetricsSelected.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_MetricsSelected.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_MetricsSelected.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_MetricsSelected.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_MetricsSelected.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewNational_MetricsSelected.TabIndex = 2
            Me.DataGridViewNational_MetricsSelected.UseEmbeddedNavigator = False
            Me.DataGridViewNational_MetricsSelected.ViewCaptionHeight = -1
            '
            'ButtonNationalMetrics_AddSelected
            '
            Me.ButtonNationalMetrics_AddSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalMetrics_AddSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalMetrics_AddSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonNationalMetrics_AddSelected.Name = "ButtonNationalMetrics_AddSelected"
            Me.ButtonNationalMetrics_AddSelected.SecurityEnabled = True
            Me.ButtonNationalMetrics_AddSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalMetrics_AddSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalMetrics_AddSelected.TabIndex = 0
            Me.ButtonNationalMetrics_AddSelected.Text = ">"
            '
            'ButtonNationalMetrics_RemoveSelected
            '
            Me.ButtonNationalMetrics_RemoveSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNationalMetrics_RemoveSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNationalMetrics_RemoveSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonNationalMetrics_RemoveSelected.Name = "ButtonNationalMetrics_RemoveSelected"
            Me.ButtonNationalMetrics_RemoveSelected.SecurityEnabled = True
            Me.ButtonNationalMetrics_RemoveSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonNationalMetrics_RemoveSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNationalMetrics_RemoveSelected.TabIndex = 1
            Me.ButtonNationalMetrics_RemoveSelected.Text = "<"
            '
            'ExpandableSplitterControl5
            '
            Me.ExpandableSplitterControl5.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl5.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl5.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl5.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl5.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl5.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl5.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl5.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl5.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl5.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl5.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl5.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl5.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl5.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl5.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl5.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl5.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl5.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl5.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl5.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl5.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl5.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl5.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl5.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl5.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl5.Name = "ExpandableSplitterControl5"
            Me.ExpandableSplitterControl5.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControl5.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl5.TabIndex = 20
            Me.ExpandableSplitterControl5.TabStop = False
            '
            'PanelNationalMetrics_LeftSection
            '
            Me.PanelNationalMetrics_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelNationalMetrics_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelNationalMetrics_LeftSection.Controls.Add(Me.DataGridViewNational_MetricsAvailable)
            Me.PanelNationalMetrics_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelNationalMetrics_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelNationalMetrics_LeftSection.Name = "PanelNationalMetrics_LeftSection"
            Me.PanelNationalMetrics_LeftSection.Size = New System.Drawing.Size(317, 532)
            Me.PanelNationalMetrics_LeftSection.TabIndex = 0
            '
            'DataGridViewNational_MetricsAvailable
            '
            Me.DataGridViewNational_MetricsAvailable.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_MetricsAvailable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_MetricsAvailable.AutoUpdateViewCaption = True
            Me.DataGridViewNational_MetricsAvailable.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_MetricsAvailable.ItemDescription = "Available Metric(s)"
            Me.DataGridViewNational_MetricsAvailable.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewNational_MetricsAvailable.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_MetricsAvailable.ModifyGridRowHeight = False
            Me.DataGridViewNational_MetricsAvailable.MultiSelect = True
            Me.DataGridViewNational_MetricsAvailable.Name = "DataGridViewNational_MetricsAvailable"
            Me.DataGridViewNational_MetricsAvailable.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_MetricsAvailable.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_MetricsAvailable.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_MetricsAvailable.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_MetricsAvailable.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewNational_MetricsAvailable.TabIndex = 0
            Me.DataGridViewNational_MetricsAvailable.UseEmbeddedNavigator = False
            Me.DataGridViewNational_MetricsAvailable.ViewCaptionHeight = -1
            '
            'TabItemNational_Metrics
            '
            Me.TabItemNational_Metrics.AttachedControl = Me.TabControlPanelNationalMetrics
            Me.TabItemNational_Metrics.Name = "TabItemNational_Metrics"
            Me.TabItemNational_Metrics.Text = "Metrics"
            '
            'ExpandableSplitterControl1
            '
            Me.ExpandableSplitterControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(198, 1)
            Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
            Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 595)
            Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl1.TabIndex = 49
            Me.ExpandableSplitterControl1.TabStop = False
            '
            'PanelNational_LeftSection
            '
            Me.PanelNational_LeftSection.Controls.Add(Me.DataGridViewNational_UserCriterias)
            Me.PanelNational_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelNational_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelNational_LeftSection.Name = "PanelNational_LeftSection"
            Me.PanelNational_LeftSection.Size = New System.Drawing.Size(197, 595)
            Me.PanelNational_LeftSection.TabIndex = 48
            '
            'DataGridViewNational_UserCriterias
            '
            Me.DataGridViewNational_UserCriterias.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNational_UserCriterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNational_UserCriterias.AutoUpdateViewCaption = True
            Me.DataGridViewNational_UserCriterias.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNational_UserCriterias.ItemDescription = "Report(s)"
            Me.DataGridViewNational_UserCriterias.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewNational_UserCriterias.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewNational_UserCriterias.ModifyGridRowHeight = False
            Me.DataGridViewNational_UserCriterias.MultiSelect = False
            Me.DataGridViewNational_UserCriterias.Name = "DataGridViewNational_UserCriterias"
            Me.DataGridViewNational_UserCriterias.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewNational_UserCriterias.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewNational_UserCriterias.ShowRowSelectionIfHidden = True
            Me.DataGridViewNational_UserCriterias.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNational_UserCriterias.Size = New System.Drawing.Size(180, 571)
            Me.DataGridViewNational_UserCriterias.TabIndex = 0
            Me.DataGridViewNational_UserCriterias.UseEmbeddedNavigator = False
            Me.DataGridViewNational_UserCriterias.ViewCaptionHeight = -1
            '
            'TabItemTabs_NationalTab
            '
            Me.TabItemTabs_NationalTab.AttachedControl = Me.TabControlPanelNational_National
            Me.TabItemTabs_NationalTab.Name = "TabItemTabs_NationalTab"
            Me.TabItemTabs_NationalTab.Text = "National"
            '
            'TabControlPanelSpotRadioCounty_SpotRadioCounty
            '
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Controls.Add(Me.PanelSpotRadioCounty_RightSection)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Controls.Add(Me.ExpandableSplitterControlSpotRadioCounty_LeftRight)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Controls.Add(Me.PanelSpotRadioCounty_LeftSection)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Name = "TabControlPanelSpotRadioCounty_SpotRadioCounty"
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.TabIndex = 9
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.TabItem = Me.TabItemTabs_SpotRadioCountyTab
            '
            'PanelSpotRadioCounty_RightSection
            '
            Me.PanelSpotRadioCounty_RightSection.Controls.Add(Me.TabControlSpotRadioCounty_ResearchCriteria)
            Me.PanelSpotRadioCounty_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotRadioCounty_RightSection.Location = New System.Drawing.Point(204, 1)
            Me.PanelSpotRadioCounty_RightSection.Name = "PanelSpotRadioCounty_RightSection"
            Me.PanelSpotRadioCounty_RightSection.Size = New System.Drawing.Size(849, 595)
            Me.PanelSpotRadioCounty_RightSection.TabIndex = 13
            '
            'TabControlSpotRadioCounty_ResearchCriteria
            '
            Me.TabControlSpotRadioCounty_ResearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlSpotRadioCounty_ResearchCriteria.BackColor = System.Drawing.Color.White
            Me.TabControlSpotRadioCounty_ResearchCriteria.CanReorderTabs = False
            Me.TabControlSpotRadioCounty_ResearchCriteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlSpotRadioCounty_ResearchCriteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlSpotRadioCounty_ResearchCriteria.Controls.Add(Me.TabControlPanelCountyMarket)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Controls.Add(Me.TabControlPanelCountyResults)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Controls.Add(Me.TabControlPanelCountyStations)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Controls.Add(Me.TabControlPanelCountyMetrics)
            Me.TabControlSpotRadioCounty_ResearchCriteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlSpotRadioCounty_ResearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Name = "TabControlSpotRadioCounty_ResearchCriteria"
            Me.TabControlSpotRadioCounty_ResearchCriteria.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlSpotRadioCounty_ResearchCriteria.SelectedTabIndex = 0
            Me.TabControlSpotRadioCounty_ResearchCriteria.Size = New System.Drawing.Size(825, 571)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlSpotRadioCounty_ResearchCriteria.TabIndex = 0
            Me.TabControlSpotRadioCounty_ResearchCriteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlSpotRadioCounty_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadioCounty_MarketBooks)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadioCounty_Stations)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadioCounty_Metrics)
            Me.TabControlSpotRadioCounty_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadioCounty_Results)
            '
            'TabControlPanelCountyMarket
            '
            Me.TabControlPanelCountyMarket.Controls.Add(Me.DataGridViewSpotRadioCounty_Years)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.GroupBoxSpotRadioCounty_Dayparts)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.CheckBoxCounty_ShowFrequency)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.LabelCounty_MaxRank)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.NumericInputCounty_MaxRank)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.ComboBoxCounty_ReportType)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.LabelCounty_ReportType)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.SearchableComboBoxCounty_Demographic)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.LabelCounty_Demographic)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.LabelCounty_Market)
            Me.TabControlPanelCountyMarket.Controls.Add(Me.SearchableComboBoxCounty_County)
            Me.TabControlPanelCountyMarket.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyMarket.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyMarket.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyMarket.Name = "TabControlPanelCountyMarket"
            Me.TabControlPanelCountyMarket.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyMarket.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelCountyMarket.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyMarket.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyMarket.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyMarket.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyMarket.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyMarket.Style.GradientAngle = 90
            Me.TabControlPanelCountyMarket.TabIndex = 0
            Me.TabControlPanelCountyMarket.TabItem = Me.TabItemSpotRadioCounty_MarketBooks
            '
            'DataGridViewSpotRadioCounty_Years
            '
            Me.DataGridViewSpotRadioCounty_Years.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_Years.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_Years.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_Years.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_Years.ItemDescription = "Year(s)"
            Me.DataGridViewSpotRadioCounty_Years.Location = New System.Drawing.Point(11, 173)
            Me.DataGridViewSpotRadioCounty_Years.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_Years.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_Years.MultiSelect = True
            Me.DataGridViewSpotRadioCounty_Years.Name = "DataGridViewSpotRadioCounty_Years"
            Me.DataGridViewSpotRadioCounty_Years.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSpotRadioCounty_Years.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_Years.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_Years.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_Years.Size = New System.Drawing.Size(805, 367)
            Me.DataGridViewSpotRadioCounty_Years.TabIndex = 16
            Me.DataGridViewSpotRadioCounty_Years.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_Years.ViewCaptionHeight = -1
            '
            'GroupBoxSpotRadioCounty_Dayparts
            '
            Me.GroupBoxSpotRadioCounty_Dayparts.Controls.Add(Me.CheckBoxCountyDaypart84)
            Me.GroupBoxSpotRadioCounty_Dayparts.Controls.Add(Me.CheckBoxCountyDaypart68)
            Me.GroupBoxSpotRadioCounty_Dayparts.Location = New System.Drawing.Point(11, 85)
            Me.GroupBoxSpotRadioCounty_Dayparts.Name = "GroupBoxSpotRadioCounty_Dayparts"
            Me.GroupBoxSpotRadioCounty_Dayparts.Size = New System.Drawing.Size(453, 56)
            Me.GroupBoxSpotRadioCounty_Dayparts.TabIndex = 15
            Me.GroupBoxSpotRadioCounty_Dayparts.Text = "Daypart(s)"
            '
            'CheckBoxCountyDaypart84
            '
            Me.CheckBoxCountyDaypart84.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCountyDaypart84.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCountyDaypart84.CheckValue = 0
            Me.CheckBoxCountyDaypart84.CheckValueChecked = 1
            Me.CheckBoxCountyDaypart84.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCountyDaypart84.CheckValueUnchecked = 0
            Me.CheckBoxCountyDaypart84.ChildControls = Nothing
            Me.CheckBoxCountyDaypart84.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCountyDaypart84.Location = New System.Drawing.Point(151, 24)
            Me.CheckBoxCountyDaypart84.Name = "CheckBoxCountyDaypart84"
            Me.CheckBoxCountyDaypart84.OldestSibling = Nothing
            Me.CheckBoxCountyDaypart84.SecurityEnabled = True
            Me.CheckBoxCountyDaypart84.SiblingControls = Nothing
            Me.CheckBoxCountyDaypart84.Size = New System.Drawing.Size(149, 20)
            Me.CheckBoxCountyDaypart84.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCountyDaypart84.TabIndex = 11
            Me.CheckBoxCountyDaypart84.TabOnEnter = True
            Me.CheckBoxCountyDaypart84.Tag = "84"
            Me.CheckBoxCountyDaypart84.Text = "Mon-Sun / 6AM - 12AM"
            '
            'CheckBoxCountyDaypart68
            '
            Me.CheckBoxCountyDaypart68.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCountyDaypart68.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCountyDaypart68.CheckValue = 0
            Me.CheckBoxCountyDaypart68.CheckValueChecked = 1
            Me.CheckBoxCountyDaypart68.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCountyDaypart68.CheckValueUnchecked = 0
            Me.CheckBoxCountyDaypart68.ChildControls = Nothing
            Me.CheckBoxCountyDaypart68.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCountyDaypart68.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxCountyDaypart68.Name = "CheckBoxCountyDaypart68"
            Me.CheckBoxCountyDaypart68.OldestSibling = Nothing
            Me.CheckBoxCountyDaypart68.SecurityEnabled = True
            Me.CheckBoxCountyDaypart68.SiblingControls = Nothing
            Me.CheckBoxCountyDaypart68.Size = New System.Drawing.Size(140, 20)
            Me.CheckBoxCountyDaypart68.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCountyDaypart68.TabIndex = 10
            Me.CheckBoxCountyDaypart68.TabOnEnter = True
            Me.CheckBoxCountyDaypart68.Tag = "68"
            Me.CheckBoxCountyDaypart68.Text = "Mon-Fri / 6AM - 7PM"
            '
            'CheckBoxCounty_ShowFrequency
            '
            Me.CheckBoxCounty_ShowFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCounty_ShowFrequency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCounty_ShowFrequency.CheckValue = 0
            Me.CheckBoxCounty_ShowFrequency.CheckValueChecked = 1
            Me.CheckBoxCounty_ShowFrequency.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCounty_ShowFrequency.CheckValueUnchecked = 0
            Me.CheckBoxCounty_ShowFrequency.ChildControls = Nothing
            Me.CheckBoxCounty_ShowFrequency.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCounty_ShowFrequency.Location = New System.Drawing.Point(11, 147)
            Me.CheckBoxCounty_ShowFrequency.Name = "CheckBoxCounty_ShowFrequency"
            Me.CheckBoxCounty_ShowFrequency.OldestSibling = Nothing
            Me.CheckBoxCounty_ShowFrequency.SecurityEnabled = True
            Me.CheckBoxCounty_ShowFrequency.SiblingControls = Nothing
            Me.CheckBoxCounty_ShowFrequency.Size = New System.Drawing.Size(112, 20)
            Me.CheckBoxCounty_ShowFrequency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCounty_ShowFrequency.TabIndex = 9
            Me.CheckBoxCounty_ShowFrequency.TabOnEnter = True
            Me.CheckBoxCounty_ShowFrequency.Text = "Show Frequency"
            '
            'LabelCounty_MaxRank
            '
            Me.LabelCounty_MaxRank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCounty_MaxRank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCounty_MaxRank.Location = New System.Drawing.Point(318, 33)
            Me.LabelCounty_MaxRank.Name = "LabelCounty_MaxRank"
            Me.LabelCounty_MaxRank.Size = New System.Drawing.Size(63, 20)
            Me.LabelCounty_MaxRank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCounty_MaxRank.TabIndex = 6
            Me.LabelCounty_MaxRank.Text = "Max Rank:"
            '
            'NumericInputCounty_MaxRank
            '
            Me.NumericInputCounty_MaxRank.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCounty_MaxRank.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputCounty_MaxRank.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputCounty_MaxRank.EnterMoveNextControl = True
            Me.NumericInputCounty_MaxRank.Location = New System.Drawing.Point(387, 34)
            Me.NumericInputCounty_MaxRank.Name = "NumericInputCounty_MaxRank"
            Me.NumericInputCounty_MaxRank.Properties.AllowMouseWheel = False
            Me.NumericInputCounty_MaxRank.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputCounty_MaxRank.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputCounty_MaxRank.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputCounty_MaxRank.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputCounty_MaxRank.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCounty_MaxRank.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputCounty_MaxRank.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCounty_MaxRank.Properties.IsFloatValue = False
            Me.NumericInputCounty_MaxRank.Properties.Mask.EditMask = "f0"
            Me.NumericInputCounty_MaxRank.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCounty_MaxRank.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputCounty_MaxRank.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputCounty_MaxRank.SecurityEnabled = True
            Me.NumericInputCounty_MaxRank.Size = New System.Drawing.Size(58, 20)
            Me.NumericInputCounty_MaxRank.TabIndex = 7
            '
            'ComboBoxCounty_ReportType
            '
            Me.ComboBoxCounty_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCounty_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxCounty_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCounty_ReportType.AutoFindItemInDataSource = True
            Me.ComboBoxCounty_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCounty_ReportType.BookmarkingEnabled = False
            Me.ComboBoxCounty_ReportType.DisableMouseWheel = True
            Me.ComboBoxCounty_ReportType.DisplayMember = "Display"
            Me.ComboBoxCounty_ReportType.DisplayName = "Report Type"
            Me.ComboBoxCounty_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCounty_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCounty_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCounty_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCounty_ReportType.FocusHighlightEnabled = True
            Me.ComboBoxCounty_ReportType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCounty_ReportType.FormattingEnabled = True
            Me.ComboBoxCounty_ReportType.ItemHeight = 16
            Me.ComboBoxCounty_ReportType.Location = New System.Drawing.Point(99, 31)
            Me.ComboBoxCounty_ReportType.Name = "ComboBoxCounty_ReportType"
            Me.ComboBoxCounty_ReportType.ReadOnly = False
            Me.ComboBoxCounty_ReportType.SecurityEnabled = True
            Me.ComboBoxCounty_ReportType.Size = New System.Drawing.Size(213, 22)
            Me.ComboBoxCounty_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCounty_ReportType.TabIndex = 5
            Me.ComboBoxCounty_ReportType.TabOnEnter = True
            Me.ComboBoxCounty_ReportType.ValueMember = "Value"
            Me.ComboBoxCounty_ReportType.WatermarkText = "Select Month"
            '
            'LabelCounty_ReportType
            '
            Me.LabelCounty_ReportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCounty_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCounty_ReportType.Location = New System.Drawing.Point(11, 31)
            Me.LabelCounty_ReportType.Name = "LabelCounty_ReportType"
            Me.LabelCounty_ReportType.Size = New System.Drawing.Size(82, 20)
            Me.LabelCounty_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCounty_ReportType.TabIndex = 4
            Me.LabelCounty_ReportType.Text = "Report Type:"
            '
            'SearchableComboBoxCounty_Demographic
            '
            Me.SearchableComboBoxCounty_Demographic.ActiveFilterString = ""
            Me.SearchableComboBoxCounty_Demographic.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCounty_Demographic.AutoFillMode = False
            Me.SearchableComboBoxCounty_Demographic.BookmarkingEnabled = False
            Me.SearchableComboBoxCounty_Demographic.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBoxCounty_Demographic.DataSource = Nothing
            Me.SearchableComboBoxCounty_Demographic.DisableMouseWheel = True
            Me.SearchableComboBoxCounty_Demographic.DisplayName = ""
            Me.SearchableComboBoxCounty_Demographic.EditValue = ""
            Me.SearchableComboBoxCounty_Demographic.EnterMoveNextControl = True
            Me.SearchableComboBoxCounty_Demographic.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCounty_Demographic.Location = New System.Drawing.Point(98, 59)
            Me.SearchableComboBoxCounty_Demographic.Name = "SearchableComboBoxCounty_Demographic"
            Me.SearchableComboBoxCounty_Demographic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCounty_Demographic.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCounty_Demographic.Properties.NullText = "Select Demographic"
            Me.SearchableComboBoxCounty_Demographic.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxCounty_Demographic.Properties.ShowClearButton = False
            Me.SearchableComboBoxCounty_Demographic.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCounty_Demographic.SecurityEnabled = True
            Me.SearchableComboBoxCounty_Demographic.SelectedValue = ""
            Me.SearchableComboBoxCounty_Demographic.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxCounty_Demographic.TabIndex = 9
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
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
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView4.ModifyGridRowHeight = False
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
            Me.GridView4.SkipAddingControlsOnModifyColumn = False
            Me.GridView4.SkipSettingFontOnModifyColumn = False
            '
            'LabelCounty_Demographic
            '
            Me.LabelCounty_Demographic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCounty_Demographic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCounty_Demographic.Location = New System.Drawing.Point(11, 57)
            Me.LabelCounty_Demographic.Name = "LabelCounty_Demographic"
            Me.LabelCounty_Demographic.Size = New System.Drawing.Size(81, 20)
            Me.LabelCounty_Demographic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCounty_Demographic.TabIndex = 8
            Me.LabelCounty_Demographic.Text = "Demographic:"
            '
            'LabelCounty_Market
            '
            Me.LabelCounty_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCounty_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCounty_Market.Location = New System.Drawing.Point(11, 5)
            Me.LabelCounty_Market.Name = "LabelCounty_Market"
            Me.LabelCounty_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelCounty_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCounty_Market.TabIndex = 2
            Me.LabelCounty_Market.Text = "County:"
            '
            'SearchableComboBoxCounty_County
            '
            Me.SearchableComboBoxCounty_County.ActiveFilterString = ""
            Me.SearchableComboBoxCounty_County.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCounty_County.AutoFillMode = False
            Me.SearchableComboBoxCounty_County.BookmarkingEnabled = False
            Me.SearchableComboBoxCounty_County.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioCounty
            Me.SearchableComboBoxCounty_County.DataSource = Nothing
            Me.SearchableComboBoxCounty_County.DisableMouseWheel = True
            Me.SearchableComboBoxCounty_County.DisplayName = ""
            Me.SearchableComboBoxCounty_County.EditValue = ""
            Me.SearchableComboBoxCounty_County.EnterMoveNextControl = True
            Me.SearchableComboBoxCounty_County.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCounty_County.Location = New System.Drawing.Point(99, 5)
            Me.SearchableComboBoxCounty_County.Name = "SearchableComboBoxCounty_County"
            Me.SearchableComboBoxCounty_County.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCounty_County.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxCounty_County.Properties.NullText = "Select County"
            Me.SearchableComboBoxCounty_County.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxCounty_County.Properties.ShowClearButton = False
            Me.SearchableComboBoxCounty_County.Properties.ValueMember = "CountyCode"
            Me.SearchableComboBoxCounty_County.SecurityEnabled = True
            Me.SearchableComboBoxCounty_County.SelectedValue = ""
            Me.SearchableComboBoxCounty_County.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxCounty_County.TabIndex = 3
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView5.ModifyGridRowHeight = False
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView5.OptionsBehavior.Editable = False
            Me.GridView5.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView5.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsSelection.MultiSelect = True
            Me.GridView5.OptionsView.ColumnAutoWidth = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView5.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView5.SkipAddingControlsOnModifyColumn = False
            Me.GridView5.SkipSettingFontOnModifyColumn = False
            '
            'TabItemSpotRadioCounty_MarketBooks
            '
            Me.TabItemSpotRadioCounty_MarketBooks.AttachedControl = Me.TabControlPanelCountyMarket
            Me.TabItemSpotRadioCounty_MarketBooks.Name = "TabItemSpotRadioCounty_MarketBooks"
            Me.TabItemSpotRadioCounty_MarketBooks.Text = "County/Report/Demo/DP/Years"
            '
            'TabControlPanelCountyResults
            '
            Me.TabControlPanelCountyResults.Controls.Add(Me.TabControlResults_RadioCountyResults)
            Me.TabControlPanelCountyResults.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyResults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyResults.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyResults.Name = "TabControlPanelCountyResults"
            Me.TabControlPanelCountyResults.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyResults.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelCountyResults.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyResults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyResults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyResults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyResults.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyResults.Style.GradientAngle = 90
            Me.TabControlPanelCountyResults.TabIndex = 34
            Me.TabControlPanelCountyResults.TabItem = Me.TabItemSpotRadioCounty_Results
            '
            'TabControlResults_RadioCountyResults
            '
            Me.TabControlResults_RadioCountyResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlResults_RadioCountyResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlResults_RadioCountyResults.CanReorderTabs = False
            Me.TabControlResults_RadioCountyResults.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlResults_RadioCountyResults.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlResults_RadioCountyResults.Controls.Add(Me.TabControlPanelCountyData)
            Me.TabControlResults_RadioCountyResults.Controls.Add(Me.TabControlPanelCountyDashboard)
            Me.TabControlResults_RadioCountyResults.ForeColor = System.Drawing.Color.Black
            Me.TabControlResults_RadioCountyResults.Location = New System.Drawing.Point(4, 4)
            Me.TabControlResults_RadioCountyResults.Name = "TabControlResults_RadioCountyResults"
            Me.TabControlResults_RadioCountyResults.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlResults_RadioCountyResults.SelectedTabIndex = 0
            Me.TabControlResults_RadioCountyResults.Size = New System.Drawing.Size(817, 536)
            Me.TabControlResults_RadioCountyResults.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlResults_RadioCountyResults.TabIndex = 4
            Me.TabControlResults_RadioCountyResults.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlResults_RadioCountyResults.Tabs.Add(Me.TabItemRadioCountyResults_RadioCountyDataTab)
            Me.TabControlResults_RadioCountyResults.Tabs.Add(Me.TabItemCountyResults_Dashboard)
            Me.TabControlResults_RadioCountyResults.TabStop = False
            '
            'TabControlPanelCountyData
            '
            Me.TabControlPanelCountyData.Controls.Add(Me.BandedDataGridViewSpotRadioCountyResults)
            Me.TabControlPanelCountyData.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyData.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyData.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyData.Name = "TabControlPanelCountyData"
            Me.TabControlPanelCountyData.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyData.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelCountyData.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyData.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyData.Style.GradientAngle = 90
            Me.TabControlPanelCountyData.TabIndex = 10
            Me.TabControlPanelCountyData.TabItem = Me.TabItemRadioCountyResults_RadioCountyDataTab
            '
            'BandedDataGridViewSpotRadioCountyResults
            '
            Me.BandedDataGridViewSpotRadioCountyResults.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewSpotRadioCountyResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewSpotRadioCountyResults.AutoUpdateViewCaption = True
            Me.BandedDataGridViewSpotRadioCountyResults.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewSpotRadioCountyResults.ItemDescription = "Item(s)"
            Me.BandedDataGridViewSpotRadioCountyResults.Location = New System.Drawing.Point(4, 4)
            Me.BandedDataGridViewSpotRadioCountyResults.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewSpotRadioCountyResults.ModifyGridRowHeight = False
            Me.BandedDataGridViewSpotRadioCountyResults.MultiSelect = True
            Me.BandedDataGridViewSpotRadioCountyResults.Name = "BandedDataGridViewSpotRadioCountyResults"
            Me.BandedDataGridViewSpotRadioCountyResults.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewSpotRadioCountyResults.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewSpotRadioCountyResults.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewSpotRadioCountyResults.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewSpotRadioCountyResults.Size = New System.Drawing.Size(808, 501)
            Me.BandedDataGridViewSpotRadioCountyResults.TabIndex = 0
            Me.BandedDataGridViewSpotRadioCountyResults.UseEmbeddedNavigator = False
            Me.BandedDataGridViewSpotRadioCountyResults.ViewCaptionHeight = -1
            '
            'TabItemRadioCountyResults_RadioCountyDataTab
            '
            Me.TabItemRadioCountyResults_RadioCountyDataTab.AttachedControl = Me.TabControlPanelCountyData
            Me.TabItemRadioCountyResults_RadioCountyDataTab.Name = "TabItemRadioCountyResults_RadioCountyDataTab"
            Me.TabItemRadioCountyResults_RadioCountyDataTab.Text = "Data"
            '
            'TabControlPanelCountyDashboard
            '
            Me.TabControlPanelCountyDashboard.Controls.Add(Me.DashboardViewerRadioCountyDashboard_Dashboard)
            Me.TabControlPanelCountyDashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyDashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyDashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyDashboard.Name = "TabControlPanelCountyDashboard"
            Me.TabControlPanelCountyDashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyDashboard.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelCountyDashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyDashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyDashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyDashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyDashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyDashboard.Style.GradientAngle = 90
            Me.TabControlPanelCountyDashboard.TabIndex = 11
            Me.TabControlPanelCountyDashboard.TabItem = Me.TabItemCountyResults_Dashboard
            '
            'DashboardViewerRadioCountyDashboard_Dashboard
            '
            Me.DashboardViewerRadioCountyDashboard_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DashboardViewerRadioCountyDashboard_Dashboard.Location = New System.Drawing.Point(1, 1)
            Me.DashboardViewerRadioCountyDashboard_Dashboard.Name = "DashboardViewerRadioCountyDashboard_Dashboard"
            Me.DashboardViewerRadioCountyDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerRadioCountyDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerRadioCountyDashboard_Dashboard.Size = New System.Drawing.Size(815, 507)
            Me.DashboardViewerRadioCountyDashboard_Dashboard.TabIndex = 2
            '
            'TabItemCountyResults_Dashboard
            '
            Me.TabItemCountyResults_Dashboard.AttachedControl = Me.TabControlPanelCountyDashboard
            Me.TabItemCountyResults_Dashboard.Name = "TabItemCountyResults_Dashboard"
            Me.TabItemCountyResults_Dashboard.Text = "Dashboard"
            '
            'TabItemSpotRadioCounty_Results
            '
            Me.TabItemSpotRadioCounty_Results.AttachedControl = Me.TabControlPanelCountyResults
            Me.TabItemSpotRadioCounty_Results.Name = "TabItemSpotRadioCounty_Results"
            Me.TabItemSpotRadioCounty_Results.Text = "Results"
            '
            'TabControlPanelCountyStations
            '
            Me.TabControlPanelCountyStations.Controls.Add(Me.PanelSpotRadioCountyStation)
            Me.TabControlPanelCountyStations.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyStations.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyStations.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyStations.Name = "TabControlPanelCountyStations"
            Me.TabControlPanelCountyStations.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyStations.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelCountyStations.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyStations.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyStations.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyStations.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyStations.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyStations.Style.GradientAngle = 90
            Me.TabControlPanelCountyStations.TabIndex = 50
            Me.TabControlPanelCountyStations.TabItem = Me.TabItemSpotRadioCounty_Stations
            '
            'PanelSpotRadioCountyStation
            '
            Me.PanelSpotRadioCountyStation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotRadioCountyStation.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioCountyStation.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioCountyStation.Controls.Add(Me.PanelBottomSpotRadioCountyStation_RightSection)
            Me.PanelSpotRadioCountyStation.Controls.Add(Me.ExpandableSplitterControlSpotRadioCounty_Stations)
            Me.PanelSpotRadioCountyStation.Controls.Add(Me.PanelBottomSpotRadioCountyStation_LeftSection)
            Me.PanelSpotRadioCountyStation.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotRadioCountyStation.Name = "PanelSpotRadioCountyStation"
            Me.PanelSpotRadioCountyStation.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotRadioCountyStation.TabIndex = 7
            '
            'PanelBottomSpotRadioCountyStation_RightSection
            '
            Me.PanelBottomSpotRadioCountyStation_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotRadioCountyStation_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotRadioCountyStation_RightSection.Controls.Add(Me.DataGridViewSpotRadioCounty_SelectedStations)
            Me.PanelBottomSpotRadioCountyStation_RightSection.Controls.Add(Me.ButtonSpotRadioCountyStation_AddToSelected)
            Me.PanelBottomSpotRadioCountyStation_RightSection.Controls.Add(Me.ButtonSpotRadioCountyStation_RemoveFromSelected)
            Me.PanelBottomSpotRadioCountyStation_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomSpotRadioCountyStation_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelBottomSpotRadioCountyStation_RightSection.Name = "PanelBottomSpotRadioCountyStation_RightSection"
            Me.PanelBottomSpotRadioCountyStation_RightSection.Size = New System.Drawing.Size(490, 532)
            Me.PanelBottomSpotRadioCountyStation_RightSection.TabIndex = 1
            '
            'DataGridViewSpotRadioCounty_SelectedStations
            '
            Me.DataGridViewSpotRadioCounty_SelectedStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_SelectedStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_SelectedStations.ItemDescription = "Selected Station(s)"
            Me.DataGridViewSpotRadioCounty_SelectedStations.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotRadioCounty_SelectedStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_SelectedStations.MultiSelect = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.Name = "DataGridViewSpotRadioCounty_SelectedStations"
            Me.DataGridViewSpotRadioCounty_SelectedStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadioCounty_SelectedStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_SelectedStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_SelectedStations.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotRadioCounty_SelectedStations.TabIndex = 2
            Me.DataGridViewSpotRadioCounty_SelectedStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_SelectedStations.ViewCaptionHeight = -1
            '
            'ButtonSpotRadioCountyStation_AddToSelected
            '
            Me.ButtonSpotRadioCountyStation_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioCountyStation_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioCountyStation_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotRadioCountyStation_AddToSelected.Name = "ButtonSpotRadioCountyStation_AddToSelected"
            Me.ButtonSpotRadioCountyStation_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotRadioCountyStation_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioCountyStation_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioCountyStation_AddToSelected.TabIndex = 0
            Me.ButtonSpotRadioCountyStation_AddToSelected.Text = ">"
            '
            'ButtonSpotRadioCountyStation_RemoveFromSelected
            '
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.Name = "ButtonSpotRadioCountyStation_RemoveFromSelected"
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotRadioCountyStation_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotRadioCounty_Stations
            '
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.Name = "ExpandableSplitterControlSpotRadioCounty_Stations"
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.TabIndex = 20
            Me.ExpandableSplitterControlSpotRadioCounty_Stations.TabStop = False
            '
            'PanelBottomSpotRadioCountyStation_LeftSection
            '
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Controls.Add(Me.DataGridViewSpotRadioCounty_AvailableStations)
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Name = "PanelBottomSpotRadioCountyStation_LeftSection"
            Me.PanelBottomSpotRadioCountyStation_LeftSection.Size = New System.Drawing.Size(317, 532)
            Me.PanelBottomSpotRadioCountyStation_LeftSection.TabIndex = 0
            '
            'DataGridViewSpotRadioCounty_AvailableStations
            '
            Me.DataGridViewSpotRadioCounty_AvailableStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_AvailableStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_AvailableStations.ItemDescription = "Available Station(s)"
            Me.DataGridViewSpotRadioCounty_AvailableStations.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotRadioCounty_AvailableStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_AvailableStations.MultiSelect = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.Name = "DataGridViewSpotRadioCounty_AvailableStations"
            Me.DataGridViewSpotRadioCounty_AvailableStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadioCounty_AvailableStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_AvailableStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_AvailableStations.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotRadioCounty_AvailableStations.TabIndex = 0
            Me.DataGridViewSpotRadioCounty_AvailableStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_AvailableStations.ViewCaptionHeight = -1
            '
            'TabItemSpotRadioCounty_Stations
            '
            Me.TabItemSpotRadioCounty_Stations.AttachedControl = Me.TabControlPanelCountyStations
            Me.TabItemSpotRadioCounty_Stations.Name = "TabItemSpotRadioCounty_Stations"
            Me.TabItemSpotRadioCounty_Stations.Text = "Stations"
            '
            'TabControlPanelCountyMetrics
            '
            Me.TabControlPanelCountyMetrics.Controls.Add(Me.PanelSpotRadioCountyMetrics_Criteria)
            Me.TabControlPanelCountyMetrics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCountyMetrics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCountyMetrics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCountyMetrics.Name = "TabControlPanelCountyMetrics"
            Me.TabControlPanelCountyMetrics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCountyMetrics.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelCountyMetrics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCountyMetrics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCountyMetrics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCountyMetrics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCountyMetrics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCountyMetrics.Style.GradientAngle = 90
            Me.TabControlPanelCountyMetrics.TabIndex = 25
            Me.TabControlPanelCountyMetrics.TabItem = Me.TabItemSpotRadioCounty_Metrics
            '
            'PanelSpotRadioCountyMetrics_Criteria
            '
            Me.PanelSpotRadioCountyMetrics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotRadioCountyMetrics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioCountyMetrics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioCountyMetrics_Criteria.Controls.Add(Me.PanelSpotRadioCountyMetrics_Right)
            Me.PanelSpotRadioCountyMetrics_Criteria.Controls.Add(Me.ExpandableSplitterControlSpotRadioCounty_Metrics)
            Me.PanelSpotRadioCountyMetrics_Criteria.Controls.Add(Me.PanelSpotRadioCountyMetrics_Left)
            Me.PanelSpotRadioCountyMetrics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotRadioCountyMetrics_Criteria.Name = "PanelSpotRadioCountyMetrics_Criteria"
            Me.PanelSpotRadioCountyMetrics_Criteria.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotRadioCountyMetrics_Criteria.TabIndex = 8
            '
            'PanelSpotRadioCountyMetrics_Right
            '
            Me.PanelSpotRadioCountyMetrics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioCountyMetrics_Right.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioCountyMetrics_Right.Controls.Add(Me.DataGridViewSpotRadioCounty_SelectedMetrics)
            Me.PanelSpotRadioCountyMetrics_Right.Controls.Add(Me.ButtonSpotRadioCountyMetrics_AddToSelected)
            Me.PanelSpotRadioCountyMetrics_Right.Controls.Add(Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected)
            Me.PanelSpotRadioCountyMetrics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotRadioCountyMetrics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelSpotRadioCountyMetrics_Right.Name = "PanelSpotRadioCountyMetrics_Right"
            Me.PanelSpotRadioCountyMetrics_Right.Size = New System.Drawing.Size(490, 532)
            Me.PanelSpotRadioCountyMetrics_Right.TabIndex = 1
            '
            'DataGridViewSpotRadioCounty_SelectedMetrics
            '
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ItemDescription = "Selected Metric(s)"
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.MultiSelect = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.Name = "DataGridViewSpotRadioCounty_SelectedMetrics"
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.TabIndex = 2
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_SelectedMetrics.ViewCaptionHeight = -1
            '
            'ButtonSpotRadioCountyMetrics_AddToSelected
            '
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.Name = "ButtonSpotRadioCountyMetrics_AddToSelected"
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.TabIndex = 0
            Me.ButtonSpotRadioCountyMetrics_AddToSelected.Text = ">"
            '
            'ButtonSpotRadioCountyMetrics_RemoveFromSelected
            '
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.Name = "ButtonSpotRadioCountyMetrics_RemoveFromSelected"
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotRadioCountyMetrics_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotRadioCounty_Metrics
            '
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.Name = "ExpandableSplitterControlSpotRadioCounty_Metrics"
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.TabIndex = 20
            Me.ExpandableSplitterControlSpotRadioCounty_Metrics.TabStop = False
            '
            'PanelSpotRadioCountyMetrics_Left
            '
            Me.PanelSpotRadioCountyMetrics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioCountyMetrics_Left.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioCountyMetrics_Left.Controls.Add(Me.DataGridViewSpotRadioCounty_AvailableMetrics)
            Me.PanelSpotRadioCountyMetrics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotRadioCountyMetrics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelSpotRadioCountyMetrics_Left.Name = "PanelSpotRadioCountyMetrics_Left"
            Me.PanelSpotRadioCountyMetrics_Left.Size = New System.Drawing.Size(317, 532)
            Me.PanelSpotRadioCountyMetrics_Left.TabIndex = 0
            '
            'DataGridViewSpotRadioCounty_AvailableMetrics
            '
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ItemDescription = "Available Metric(s)"
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.MultiSelect = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.Name = "DataGridViewSpotRadioCounty_AvailableMetrics"
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.TabIndex = 0
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_AvailableMetrics.ViewCaptionHeight = -1
            '
            'TabItemSpotRadioCounty_Metrics
            '
            Me.TabItemSpotRadioCounty_Metrics.AttachedControl = Me.TabControlPanelCountyMetrics
            Me.TabItemSpotRadioCounty_Metrics.Name = "TabItemSpotRadioCounty_Metrics"
            Me.TabItemSpotRadioCounty_Metrics.Text = "Metrics"
            '
            'ExpandableSplitterControlSpotRadioCounty_LeftRight
            '
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.Location = New System.Drawing.Point(198, 1)
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.Name = "ExpandableSplitterControlSpotRadioCounty_LeftRight"
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.Size = New System.Drawing.Size(6, 595)
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.TabIndex = 12
            Me.ExpandableSplitterControlSpotRadioCounty_LeftRight.TabStop = False
            '
            'PanelSpotRadioCounty_LeftSection
            '
            Me.PanelSpotRadioCounty_LeftSection.Controls.Add(Me.DataGridViewSpotRadioCounty_UserCriterias)
            Me.PanelSpotRadioCounty_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotRadioCounty_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelSpotRadioCounty_LeftSection.Name = "PanelSpotRadioCounty_LeftSection"
            Me.PanelSpotRadioCounty_LeftSection.Size = New System.Drawing.Size(197, 595)
            Me.PanelSpotRadioCounty_LeftSection.TabIndex = 2
            '
            'DataGridViewSpotRadioCounty_UserCriterias
            '
            Me.DataGridViewSpotRadioCounty_UserCriterias.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadioCounty_UserCriterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadioCounty_UserCriterias.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadioCounty_UserCriterias.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadioCounty_UserCriterias.ItemDescription = "Report(s)"
            Me.DataGridViewSpotRadioCounty_UserCriterias.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewSpotRadioCounty_UserCriterias.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadioCounty_UserCriterias.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadioCounty_UserCriterias.MultiSelect = False
            Me.DataGridViewSpotRadioCounty_UserCriterias.Name = "DataGridViewSpotRadioCounty_UserCriterias"
            Me.DataGridViewSpotRadioCounty_UserCriterias.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadioCounty_UserCriterias.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadioCounty_UserCriterias.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadioCounty_UserCriterias.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadioCounty_UserCriterias.Size = New System.Drawing.Size(180, 571)
            Me.DataGridViewSpotRadioCounty_UserCriterias.TabIndex = 0
            Me.DataGridViewSpotRadioCounty_UserCriterias.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadioCounty_UserCriterias.ViewCaptionHeight = -1
            '
            'TabItemTabs_SpotRadioCountyTab
            '
            Me.TabItemTabs_SpotRadioCountyTab.AttachedControl = Me.TabControlPanelSpotRadioCounty_SpotRadioCounty
            Me.TabItemTabs_SpotRadioCountyTab.Name = "TabItemTabs_SpotRadioCountyTab"
            Me.TabItemTabs_SpotRadioCountyTab.Text = "Spot Radio County"
            '
            'TabControlPanelSpotRadio_SpotRadio
            '
            Me.TabControlPanelSpotRadio_SpotRadio.Controls.Add(Me.PanelSpotRadio_RightSection)
            Me.TabControlPanelSpotRadio_SpotRadio.Controls.Add(Me.ExpandableSplitterControlSpotRadio_LeftRight)
            Me.TabControlPanelSpotRadio_SpotRadio.Controls.Add(Me.PanelSpotRadio_LeftSection)
            Me.TabControlPanelSpotRadio_SpotRadio.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadio_SpotRadio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadio_SpotRadio.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadio_SpotRadio.Name = "TabControlPanelSpotRadio_SpotRadio"
            Me.TabControlPanelSpotRadio_SpotRadio.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadio_SpotRadio.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelSpotRadio_SpotRadio.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadio_SpotRadio.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadio_SpotRadio.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadio_SpotRadio.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadio_SpotRadio.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadio_SpotRadio.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadio_SpotRadio.TabIndex = 5
            Me.TabControlPanelSpotRadio_SpotRadio.TabItem = Me.TabItemTabs_SpotRadioTab
            '
            'PanelSpotRadio_RightSection
            '
            Me.PanelSpotRadio_RightSection.Controls.Add(Me.TabControlSpotRadio_ResearchCriteria)
            Me.PanelSpotRadio_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotRadio_RightSection.Location = New System.Drawing.Point(204, 1)
            Me.PanelSpotRadio_RightSection.Name = "PanelSpotRadio_RightSection"
            Me.PanelSpotRadio_RightSection.Size = New System.Drawing.Size(849, 595)
            Me.PanelSpotRadio_RightSection.TabIndex = 12
            '
            'TabControlSpotRadio_ResearchCriteria
            '
            Me.TabControlSpotRadio_ResearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlSpotRadio_ResearchCriteria.BackColor = System.Drawing.Color.White
            Me.TabControlSpotRadio_ResearchCriteria.CanReorderTabs = False
            Me.TabControlSpotRadio_ResearchCriteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlSpotRadio_ResearchCriteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlSpotRadio_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotRadioMarket_Criteria)
            Me.TabControlSpotRadio_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotRadioResults_Results)
            Me.TabControlSpotRadio_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotRadioGeographyDayparts_Criteria)
            Me.TabControlSpotRadio_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotRadioMetrics_Criteria)
            Me.TabControlSpotRadio_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotRadioStations_Criteria)
            Me.TabControlSpotRadio_ResearchCriteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlSpotRadio_ResearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlSpotRadio_ResearchCriteria.Name = "TabControlSpotRadio_ResearchCriteria"
            Me.TabControlSpotRadio_ResearchCriteria.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlSpotRadio_ResearchCriteria.SelectedTabIndex = 0
            Me.TabControlSpotRadio_ResearchCriteria.Size = New System.Drawing.Size(825, 571)
            Me.TabControlSpotRadio_ResearchCriteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlSpotRadio_ResearchCriteria.TabIndex = 0
            Me.TabControlSpotRadio_ResearchCriteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlSpotRadio_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadio_MarketBooks)
            Me.TabControlSpotRadio_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadio_GeographyDayparts)
            Me.TabControlSpotRadio_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadio_Stations)
            Me.TabControlSpotRadio_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadio_Metrics)
            Me.TabControlSpotRadio_ResearchCriteria.Tabs.Add(Me.TabItemSpotRadio_Results)
            '
            'TabControlPanelSpotRadioMarket_Criteria
            '
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_MaxRank)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.NumericInputSpotRadioMarket_MaxRank)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.ComboBoxSpotRadioMarket_Source)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_Source)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.DataGridViewSpotRadio_Books)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.ComboBoxSpotRadioMarketDemographic_ReportType)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_ReportType)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.GroupBoxSpotRadioMarket_Options)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.GroupBoxSpotRadioMarket_Ethnicity)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.SearchableComboBoxSpotRadioMarket_Qualitative)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_Qualitative)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.SearchableComboBoxSpotRadioMarket_Demographic)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_Demo)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.LabelSpotRadioMarket_Market)
            Me.TabControlPanelSpotRadioMarket_Criteria.Controls.Add(Me.SearchableComboBoxSpotRadio_Market)
            Me.TabControlPanelSpotRadioMarket_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioMarket_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioMarket_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioMarket_Criteria.Name = "TabControlPanelSpotRadioMarket_Criteria"
            Me.TabControlPanelSpotRadioMarket_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioMarket_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioMarket_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioMarket_Criteria.TabIndex = 0
            Me.TabControlPanelSpotRadioMarket_Criteria.TabItem = Me.TabItemSpotRadio_MarketBooks
            '
            'LabelSpotRadioMarket_MaxRank
            '
            Me.LabelSpotRadioMarket_MaxRank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_MaxRank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_MaxRank.Location = New System.Drawing.Point(323, 53)
            Me.LabelSpotRadioMarket_MaxRank.Name = "LabelSpotRadioMarket_MaxRank"
            Me.LabelSpotRadioMarket_MaxRank.Size = New System.Drawing.Size(63, 20)
            Me.LabelSpotRadioMarket_MaxRank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_MaxRank.TabIndex = 6
            Me.LabelSpotRadioMarket_MaxRank.Text = "Max Rank:"
            '
            'NumericInputSpotRadioMarket_MaxRank
            '
            Me.NumericInputSpotRadioMarket_MaxRank.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSpotRadioMarket_MaxRank.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputSpotRadioMarket_MaxRank.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputSpotRadioMarket_MaxRank.EnterMoveNextControl = True
            Me.NumericInputSpotRadioMarket_MaxRank.Location = New System.Drawing.Point(392, 55)
            Me.NumericInputSpotRadioMarket_MaxRank.Name = "NumericInputSpotRadioMarket_MaxRank"
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.AllowMouseWheel = False
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.IsFloatValue = False
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.Mask.EditMask = "f0"
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputSpotRadioMarket_MaxRank.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputSpotRadioMarket_MaxRank.SecurityEnabled = True
            Me.NumericInputSpotRadioMarket_MaxRank.Size = New System.Drawing.Size(58, 20)
            Me.NumericInputSpotRadioMarket_MaxRank.TabIndex = 7
            '
            'ComboBoxSpotRadioMarket_Source
            '
            Me.ComboBoxSpotRadioMarket_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSpotRadioMarket_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxSpotRadioMarket_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSpotRadioMarket_Source.AutoFindItemInDataSource = True
            Me.ComboBoxSpotRadioMarket_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSpotRadioMarket_Source.BookmarkingEnabled = False
            Me.ComboBoxSpotRadioMarket_Source.DisableMouseWheel = True
            Me.ComboBoxSpotRadioMarket_Source.DisplayMember = "Display"
            Me.ComboBoxSpotRadioMarket_Source.DisplayName = "Source"
            Me.ComboBoxSpotRadioMarket_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSpotRadioMarket_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSpotRadioMarket_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSpotRadioMarket_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSpotRadioMarket_Source.FocusHighlightEnabled = True
            Me.ComboBoxSpotRadioMarket_Source.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSpotRadioMarket_Source.FormattingEnabled = True
            Me.ComboBoxSpotRadioMarket_Source.ItemHeight = 16
            Me.ComboBoxSpotRadioMarket_Source.Location = New System.Drawing.Point(99, 3)
            Me.ComboBoxSpotRadioMarket_Source.Name = "ComboBoxSpotRadioMarket_Source"
            Me.ComboBoxSpotRadioMarket_Source.ReadOnly = False
            Me.ComboBoxSpotRadioMarket_Source.SecurityEnabled = True
            Me.ComboBoxSpotRadioMarket_Source.Size = New System.Drawing.Size(213, 22)
            Me.ComboBoxSpotRadioMarket_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSpotRadioMarket_Source.TabIndex = 1
            Me.ComboBoxSpotRadioMarket_Source.TabOnEnter = True
            Me.ComboBoxSpotRadioMarket_Source.ValueMember = "Value"
            Me.ComboBoxSpotRadioMarket_Source.WatermarkText = "Select Month"
            '
            'LabelSpotRadioMarket_Source
            '
            Me.LabelSpotRadioMarket_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_Source.Location = New System.Drawing.Point(11, 5)
            Me.LabelSpotRadioMarket_Source.Name = "LabelSpotRadioMarket_Source"
            Me.LabelSpotRadioMarket_Source.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotRadioMarket_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_Source.TabIndex = 0
            Me.LabelSpotRadioMarket_Source.Text = "Source:"
            '
            'DataGridViewSpotRadio_Books
            '
            Me.DataGridViewSpotRadio_Books.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_Books.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_Books.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_Books.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_Books.ItemDescription = "Book(s)"
            Me.DataGridViewSpotRadio_Books.Location = New System.Drawing.Point(11, 256)
            Me.DataGridViewSpotRadio_Books.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_Books.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_Books.MultiSelect = True
            Me.DataGridViewSpotRadio_Books.Name = "DataGridViewSpotRadio_Books"
            Me.DataGridViewSpotRadio_Books.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSpotRadio_Books.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_Books.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_Books.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_Books.Size = New System.Drawing.Size(805, 284)
            Me.DataGridViewSpotRadio_Books.TabIndex = 14
            Me.DataGridViewSpotRadio_Books.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_Books.ViewCaptionHeight = -1
            '
            'ComboBoxSpotRadioMarketDemographic_ReportType
            '
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.AutoFindItemInDataSource = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.BookmarkingEnabled = False
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.DisableMouseWheel = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.DisplayMember = "Display"
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.DisplayName = "Report Type"
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.FocusHighlightEnabled = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.FormattingEnabled = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ItemHeight = 16
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.Location = New System.Drawing.Point(99, 53)
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.Name = "ComboBoxSpotRadioMarketDemographic_ReportType"
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ReadOnly = False
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.SecurityEnabled = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.Size = New System.Drawing.Size(213, 22)
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.TabIndex = 5
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.TabOnEnter = True
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.ValueMember = "Value"
            Me.ComboBoxSpotRadioMarketDemographic_ReportType.WatermarkText = "Select Month"
            '
            'LabelSpotRadioMarket_ReportType
            '
            Me.LabelSpotRadioMarket_ReportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_ReportType.Location = New System.Drawing.Point(11, 53)
            Me.LabelSpotRadioMarket_ReportType.Name = "LabelSpotRadioMarket_ReportType"
            Me.LabelSpotRadioMarket_ReportType.Size = New System.Drawing.Size(82, 20)
            Me.LabelSpotRadioMarket_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_ReportType.TabIndex = 4
            Me.LabelSpotRadioMarket_ReportType.Text = "Report Type:"
            '
            'GroupBoxSpotRadioMarket_Options
            '
            Me.GroupBoxSpotRadioMarket_Options.Controls.Add(Me.CheckBoxSpotRadioOptions_ShowFrequency)
            Me.GroupBoxSpotRadioMarket_Options.Controls.Add(Me.CheckBoxSpotRadioOptions_ShowFormat)
            Me.GroupBoxSpotRadioMarket_Options.Controls.Add(Me.CheckBoxSpotRadioOptions_TotalListening)
            Me.GroupBoxSpotRadioMarket_Options.Controls.Add(Me.CheckBoxSpotRadioOptions_ShowSpill)
            Me.GroupBoxSpotRadioMarket_Options.Location = New System.Drawing.Point(11, 132)
            Me.GroupBoxSpotRadioMarket_Options.Name = "GroupBoxSpotRadioMarket_Options"
            Me.GroupBoxSpotRadioMarket_Options.Size = New System.Drawing.Size(301, 56)
            Me.GroupBoxSpotRadioMarket_Options.TabIndex = 12
            Me.GroupBoxSpotRadioMarket_Options.Text = "Options"
            '
            'CheckBoxSpotRadioOptions_ShowFrequency
            '
            Me.CheckBoxSpotRadioOptions_ShowFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotRadioOptions_ShowFrequency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotRadioOptions_ShowFrequency.CheckValue = 0
            Me.CheckBoxSpotRadioOptions_ShowFrequency.CheckValueChecked = 1
            Me.CheckBoxSpotRadioOptions_ShowFrequency.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotRadioOptions_ShowFrequency.CheckValueUnchecked = 0
            Me.CheckBoxSpotRadioOptions_ShowFrequency.ChildControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFrequency.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotRadioOptions_ShowFrequency.Location = New System.Drawing.Point(184, 24)
            Me.CheckBoxSpotRadioOptions_ShowFrequency.Name = "CheckBoxSpotRadioOptions_ShowFrequency"
            Me.CheckBoxSpotRadioOptions_ShowFrequency.OldestSibling = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFrequency.SecurityEnabled = True
            Me.CheckBoxSpotRadioOptions_ShowFrequency.SiblingControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFrequency.Size = New System.Drawing.Size(112, 20)
            Me.CheckBoxSpotRadioOptions_ShowFrequency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotRadioOptions_ShowFrequency.TabIndex = 9
            Me.CheckBoxSpotRadioOptions_ShowFrequency.TabOnEnter = True
            Me.CheckBoxSpotRadioOptions_ShowFrequency.Text = "Show Frequency"
            '
            'CheckBoxSpotRadioOptions_ShowFormat
            '
            Me.CheckBoxSpotRadioOptions_ShowFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotRadioOptions_ShowFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotRadioOptions_ShowFormat.CheckValue = 0
            Me.CheckBoxSpotRadioOptions_ShowFormat.CheckValueChecked = 1
            Me.CheckBoxSpotRadioOptions_ShowFormat.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotRadioOptions_ShowFormat.CheckValueUnchecked = 0
            Me.CheckBoxSpotRadioOptions_ShowFormat.ChildControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFormat.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotRadioOptions_ShowFormat.Location = New System.Drawing.Point(88, 24)
            Me.CheckBoxSpotRadioOptions_ShowFormat.Name = "CheckBoxSpotRadioOptions_ShowFormat"
            Me.CheckBoxSpotRadioOptions_ShowFormat.OldestSibling = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFormat.SecurityEnabled = True
            Me.CheckBoxSpotRadioOptions_ShowFormat.SiblingControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowFormat.Size = New System.Drawing.Size(90, 20)
            Me.CheckBoxSpotRadioOptions_ShowFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotRadioOptions_ShowFormat.TabIndex = 8
            Me.CheckBoxSpotRadioOptions_ShowFormat.TabOnEnter = True
            Me.CheckBoxSpotRadioOptions_ShowFormat.Text = "Show Format"
            '
            'CheckBoxSpotRadioOptions_TotalListening
            '
            Me.CheckBoxSpotRadioOptions_TotalListening.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxSpotRadioOptions_TotalListening.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotRadioOptions_TotalListening.CheckValue = 0
            Me.CheckBoxSpotRadioOptions_TotalListening.CheckValueChecked = 1
            Me.CheckBoxSpotRadioOptions_TotalListening.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotRadioOptions_TotalListening.CheckValueUnchecked = 0
            Me.CheckBoxSpotRadioOptions_TotalListening.ChildControls = Nothing
            Me.CheckBoxSpotRadioOptions_TotalListening.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotRadioOptions_TotalListening.Location = New System.Drawing.Point(201, 45)
            Me.CheckBoxSpotRadioOptions_TotalListening.Name = "CheckBoxSpotRadioOptions_TotalListening"
            Me.CheckBoxSpotRadioOptions_TotalListening.OldestSibling = Nothing
            Me.CheckBoxSpotRadioOptions_TotalListening.SecurityEnabled = True
            Me.CheckBoxSpotRadioOptions_TotalListening.SiblingControls = Nothing
            Me.CheckBoxSpotRadioOptions_TotalListening.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxSpotRadioOptions_TotalListening.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotRadioOptions_TotalListening.TabIndex = 7
            Me.CheckBoxSpotRadioOptions_TotalListening.TabOnEnter = True
            Me.CheckBoxSpotRadioOptions_TotalListening.Text = "Total Listening"
            Me.CheckBoxSpotRadioOptions_TotalListening.Visible = False
            '
            'CheckBoxSpotRadioOptions_ShowSpill
            '
            Me.CheckBoxSpotRadioOptions_ShowSpill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotRadioOptions_ShowSpill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotRadioOptions_ShowSpill.CheckValue = 0
            Me.CheckBoxSpotRadioOptions_ShowSpill.CheckValueChecked = 1
            Me.CheckBoxSpotRadioOptions_ShowSpill.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotRadioOptions_ShowSpill.CheckValueUnchecked = 0
            Me.CheckBoxSpotRadioOptions_ShowSpill.ChildControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowSpill.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotRadioOptions_ShowSpill.Location = New System.Drawing.Point(6, 24)
            Me.CheckBoxSpotRadioOptions_ShowSpill.Name = "CheckBoxSpotRadioOptions_ShowSpill"
            Me.CheckBoxSpotRadioOptions_ShowSpill.OldestSibling = Nothing
            Me.CheckBoxSpotRadioOptions_ShowSpill.SecurityEnabled = True
            Me.CheckBoxSpotRadioOptions_ShowSpill.SiblingControls = Nothing
            Me.CheckBoxSpotRadioOptions_ShowSpill.Size = New System.Drawing.Size(76, 20)
            Me.CheckBoxSpotRadioOptions_ShowSpill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotRadioOptions_ShowSpill.TabIndex = 2
            Me.CheckBoxSpotRadioOptions_ShowSpill.TabOnEnter = True
            Me.CheckBoxSpotRadioOptions_ShowSpill.Text = "Show Spill"
            '
            'GroupBoxSpotRadioMarket_Ethnicity
            '
            Me.GroupBoxSpotRadioMarket_Ethnicity.Controls.Add(Me.RadioButtonSpotRadioEthnicity_Hispanic)
            Me.GroupBoxSpotRadioMarket_Ethnicity.Controls.Add(Me.RadioButtonSpotRadioEthnicity_Black)
            Me.GroupBoxSpotRadioMarket_Ethnicity.Controls.Add(Me.RadioButtonSpotRadioEthnicity_All)
            Me.GroupBoxSpotRadioMarket_Ethnicity.Location = New System.Drawing.Point(11, 194)
            Me.GroupBoxSpotRadioMarket_Ethnicity.Name = "GroupBoxSpotRadioMarket_Ethnicity"
            Me.GroupBoxSpotRadioMarket_Ethnicity.Size = New System.Drawing.Size(301, 56)
            Me.GroupBoxSpotRadioMarket_Ethnicity.TabIndex = 13
            Me.GroupBoxSpotRadioMarket_Ethnicity.Text = "Ethnicity"
            '
            'RadioButtonSpotRadioEthnicity_Hispanic
            '
            Me.RadioButtonSpotRadioEthnicity_Hispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioEthnicity_Hispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioEthnicity_Hispanic.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Name = "RadioButtonSpotRadioEthnicity_Hispanic"
            Me.RadioButtonSpotRadioEthnicity_Hispanic.SecurityEnabled = True
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioEthnicity_Hispanic.TabIndex = 3
            Me.RadioButtonSpotRadioEthnicity_Hispanic.TabOnEnter = True
            Me.RadioButtonSpotRadioEthnicity_Hispanic.TabStop = False
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Tag = "3"
            Me.RadioButtonSpotRadioEthnicity_Hispanic.Text = "Hispanic"
            '
            'RadioButtonSpotRadioEthnicity_Black
            '
            Me.RadioButtonSpotRadioEthnicity_Black.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioEthnicity_Black.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioEthnicity_Black.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioEthnicity_Black.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonSpotRadioEthnicity_Black.Name = "RadioButtonSpotRadioEthnicity_Black"
            Me.RadioButtonSpotRadioEthnicity_Black.SecurityEnabled = True
            Me.RadioButtonSpotRadioEthnicity_Black.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonSpotRadioEthnicity_Black.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioEthnicity_Black.TabIndex = 2
            Me.RadioButtonSpotRadioEthnicity_Black.TabOnEnter = True
            Me.RadioButtonSpotRadioEthnicity_Black.TabStop = False
            Me.RadioButtonSpotRadioEthnicity_Black.Tag = "2"
            Me.RadioButtonSpotRadioEthnicity_Black.Text = "Black"
            '
            'RadioButtonSpotRadioEthnicity_All
            '
            Me.RadioButtonSpotRadioEthnicity_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioEthnicity_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioEthnicity_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioEthnicity_All.Checked = True
            Me.RadioButtonSpotRadioEthnicity_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSpotRadioEthnicity_All.CheckValue = "Y"
            Me.RadioButtonSpotRadioEthnicity_All.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonSpotRadioEthnicity_All.Name = "RadioButtonSpotRadioEthnicity_All"
            Me.RadioButtonSpotRadioEthnicity_All.SecurityEnabled = True
            Me.RadioButtonSpotRadioEthnicity_All.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSpotRadioEthnicity_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioEthnicity_All.TabIndex = 1
            Me.RadioButtonSpotRadioEthnicity_All.TabOnEnter = True
            Me.RadioButtonSpotRadioEthnicity_All.Tag = "1"
            Me.RadioButtonSpotRadioEthnicity_All.Text = "All"
            '
            'SearchableComboBoxSpotRadioMarket_Qualitative
            '
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.ActiveFilterString = ""
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.AutoFillMode = False
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.BookmarkingEnabled = False
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioQualitative
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.DataSource = Nothing
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.DisableMouseWheel = True
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.DisplayName = ""
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.EditValue = ""
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.EnterMoveNextControl = True
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Location = New System.Drawing.Point(99, 106)
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Name = "SearchableComboBoxSpotRadioMarket_Qualitative"
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.NullText = "Select Qualitative"
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.ShowClearButton = False
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties.ValueMember = "ID"
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.SecurityEnabled = True
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.SelectedValue = ""
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxSpotRadioMarket_Qualitative.TabIndex = 11
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
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
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView2.ModifyGridRowHeight = False
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
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'LabelSpotRadioMarket_Qualitative
            '
            Me.LabelSpotRadioMarket_Qualitative.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_Qualitative.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_Qualitative.Location = New System.Drawing.Point(12, 106)
            Me.LabelSpotRadioMarket_Qualitative.Name = "LabelSpotRadioMarket_Qualitative"
            Me.LabelSpotRadioMarket_Qualitative.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotRadioMarket_Qualitative.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_Qualitative.TabIndex = 10
            Me.LabelSpotRadioMarket_Qualitative.Text = "Qualitative:"
            '
            'SearchableComboBoxSpotRadioMarket_Demographic
            '
            Me.SearchableComboBoxSpotRadioMarket_Demographic.ActiveFilterString = ""
            Me.SearchableComboBoxSpotRadioMarket_Demographic.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSpotRadioMarket_Demographic.AutoFillMode = False
            Me.SearchableComboBoxSpotRadioMarket_Demographic.BookmarkingEnabled = False
            Me.SearchableComboBoxSpotRadioMarket_Demographic.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBoxSpotRadioMarket_Demographic.DataSource = Nothing
            Me.SearchableComboBoxSpotRadioMarket_Demographic.DisableMouseWheel = True
            Me.SearchableComboBoxSpotRadioMarket_Demographic.DisplayName = ""
            Me.SearchableComboBoxSpotRadioMarket_Demographic.EditValue = ""
            Me.SearchableComboBoxSpotRadioMarket_Demographic.EnterMoveNextControl = True
            Me.SearchableComboBoxSpotRadioMarket_Demographic.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Location = New System.Drawing.Point(99, 80)
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Name = "SearchableComboBoxSpotRadioMarket_Demographic"
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.NullText = "Select Demographic"
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.ShowClearButton = False
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties.ValueMember = "ID"
            Me.SearchableComboBoxSpotRadioMarket_Demographic.SecurityEnabled = True
            Me.SearchableComboBoxSpotRadioMarket_Demographic.SelectedValue = ""
            Me.SearchableComboBoxSpotRadioMarket_Demographic.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxSpotRadioMarket_Demographic.TabIndex = 9
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
            'LabelSpotRadioMarket_Demo
            '
            Me.LabelSpotRadioMarket_Demo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_Demo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_Demo.Location = New System.Drawing.Point(12, 80)
            Me.LabelSpotRadioMarket_Demo.Name = "LabelSpotRadioMarket_Demo"
            Me.LabelSpotRadioMarket_Demo.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotRadioMarket_Demo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_Demo.TabIndex = 8
            Me.LabelSpotRadioMarket_Demo.Text = "Demographic:"
            '
            'LabelSpotRadioMarket_Market
            '
            Me.LabelSpotRadioMarket_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioMarket_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioMarket_Market.Location = New System.Drawing.Point(11, 29)
            Me.LabelSpotRadioMarket_Market.Name = "LabelSpotRadioMarket_Market"
            Me.LabelSpotRadioMarket_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotRadioMarket_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioMarket_Market.TabIndex = 2
            Me.LabelSpotRadioMarket_Market.Text = "Market:"
            '
            'SearchableComboBoxSpotRadio_Market
            '
            Me.SearchableComboBoxSpotRadio_Market.ActiveFilterString = ""
            Me.SearchableComboBoxSpotRadio_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSpotRadio_Market.AutoFillMode = False
            Me.SearchableComboBoxSpotRadio_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxSpotRadio_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxSpotRadio_Market.DataSource = Nothing
            Me.SearchableComboBoxSpotRadio_Market.DisableMouseWheel = True
            Me.SearchableComboBoxSpotRadio_Market.DisplayName = ""
            Me.SearchableComboBoxSpotRadio_Market.EditValue = ""
            Me.SearchableComboBoxSpotRadio_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxSpotRadio_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSpotRadio_Market.Location = New System.Drawing.Point(99, 29)
            Me.SearchableComboBoxSpotRadio_Market.Name = "SearchableComboBoxSpotRadio_Market"
            Me.SearchableComboBoxSpotRadio_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSpotRadio_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSpotRadio_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxSpotRadio_Market.Properties.PopupView = Me.SearchableComboBoxSpotRadioViewControl_Market
            Me.SearchableComboBoxSpotRadio_Market.Properties.ShowClearButton = False
            Me.SearchableComboBoxSpotRadio_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSpotRadio_Market.SecurityEnabled = True
            Me.SearchableComboBoxSpotRadio_Market.SelectedValue = ""
            Me.SearchableComboBoxSpotRadio_Market.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxSpotRadio_Market.TabIndex = 3
            '
            'SearchableComboBoxSpotRadioViewControl_Market
            '
            Me.SearchableComboBoxSpotRadioViewControl_Market.AFActiveFilterString = ""
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxSpotRadioViewControl_Market.EnableDisabledRows = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxSpotRadioViewControl_Market.ModifyColumnSettingsOnEachDataSource = True
            Me.SearchableComboBoxSpotRadioViewControl_Market.ModifyGridRowHeight = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.Name = "SearchableComboBoxSpotRadioViewControl_Market"
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsBehavior.Editable = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxSpotRadioViewControl_Market.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxSpotRadioViewControl_Market.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxSpotRadioViewControl_Market.SkipSettingFontOnModifyColumn = False
            '
            'TabItemSpotRadio_MarketBooks
            '
            Me.TabItemSpotRadio_MarketBooks.AttachedControl = Me.TabControlPanelSpotRadioMarket_Criteria
            Me.TabItemSpotRadio_MarketBooks.Name = "TabItemSpotRadio_MarketBooks"
            Me.TabItemSpotRadio_MarketBooks.Text = "Market/Report Type/Demo/Books"
            '
            'TabControlPanelSpotRadioResults_Results
            '
            Me.TabControlPanelSpotRadioResults_Results.Controls.Add(Me.TabControlResults_RadioResults)
            Me.TabControlPanelSpotRadioResults_Results.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioResults_Results.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioResults_Results.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioResults_Results.Name = "TabControlPanelSpotRadioResults_Results"
            Me.TabControlPanelSpotRadioResults_Results.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioResults_Results.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotRadioResults_Results.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioResults_Results.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioResults_Results.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioResults_Results.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioResults_Results.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioResults_Results.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioResults_Results.TabIndex = 34
            Me.TabControlPanelSpotRadioResults_Results.TabItem = Me.TabItemSpotRadio_Results
            '
            'TabControlResults_RadioResults
            '
            Me.TabControlResults_RadioResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlResults_RadioResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlResults_RadioResults.CanReorderTabs = False
            Me.TabControlResults_RadioResults.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlResults_RadioResults.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlResults_RadioResults.Controls.Add(Me.TabControlPanelRadioDataTab_RadioData)
            Me.TabControlResults_RadioResults.Controls.Add(Me.TabControlPanelRadioDashboardTab_RadioDashboard)
            Me.TabControlResults_RadioResults.ForeColor = System.Drawing.Color.Black
            Me.TabControlResults_RadioResults.Location = New System.Drawing.Point(4, 4)
            Me.TabControlResults_RadioResults.Name = "TabControlResults_RadioResults"
            Me.TabControlResults_RadioResults.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlResults_RadioResults.SelectedTabIndex = 0
            Me.TabControlResults_RadioResults.Size = New System.Drawing.Size(817, 536)
            Me.TabControlResults_RadioResults.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlResults_RadioResults.TabIndex = 4
            Me.TabControlResults_RadioResults.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlResults_RadioResults.Tabs.Add(Me.TabItemRadioResults_RadioDataTab)
            Me.TabControlResults_RadioResults.Tabs.Add(Me.TabItemRadioResults_RadioDashboardTab)
            Me.TabControlResults_RadioResults.TabStop = False
            '
            'TabControlPanelRadioDataTab_RadioData
            '
            Me.TabControlPanelRadioDataTab_RadioData.Controls.Add(Me.LabelSpotRadioResults_Footer)
            Me.TabControlPanelRadioDataTab_RadioData.Controls.Add(Me.BandedDataGridViewSpotRadioResults)
            Me.TabControlPanelRadioDataTab_RadioData.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioDataTab_RadioData.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioDataTab_RadioData.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioDataTab_RadioData.Name = "TabControlPanelRadioDataTab_RadioData"
            Me.TabControlPanelRadioDataTab_RadioData.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioDataTab_RadioData.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelRadioDataTab_RadioData.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioDataTab_RadioData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioDataTab_RadioData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioDataTab_RadioData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioDataTab_RadioData.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioDataTab_RadioData.Style.GradientAngle = 90
            Me.TabControlPanelRadioDataTab_RadioData.TabIndex = 10
            Me.TabControlPanelRadioDataTab_RadioData.TabItem = Me.TabItemRadioResults_RadioDataTab
            '
            'LabelSpotRadioResults_Footer
            '
            Me.LabelSpotRadioResults_Footer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadioResults_Footer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadioResults_Footer.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.LabelSpotRadioResults_Footer.Location = New System.Drawing.Point(1, 444)
            Me.LabelSpotRadioResults_Footer.Name = "LabelSpotRadioResults_Footer"
            Me.LabelSpotRadioResults_Footer.Size = New System.Drawing.Size(815, 64)
            Me.LabelSpotRadioResults_Footer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadioResults_Footer.TabIndex = 5
            Me.LabelSpotRadioResults_Footer.WordWrap = True
            '
            'BandedDataGridViewSpotRadioResults
            '
            Me.BandedDataGridViewSpotRadioResults.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewSpotRadioResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewSpotRadioResults.AutoUpdateViewCaption = True
            Me.BandedDataGridViewSpotRadioResults.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewSpotRadioResults.ItemDescription = "Item(s)"
            Me.BandedDataGridViewSpotRadioResults.Location = New System.Drawing.Point(4, 4)
            Me.BandedDataGridViewSpotRadioResults.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewSpotRadioResults.ModifyGridRowHeight = False
            Me.BandedDataGridViewSpotRadioResults.MultiSelect = True
            Me.BandedDataGridViewSpotRadioResults.Name = "BandedDataGridViewSpotRadioResults"
            Me.BandedDataGridViewSpotRadioResults.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewSpotRadioResults.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewSpotRadioResults.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewSpotRadioResults.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewSpotRadioResults.Size = New System.Drawing.Size(808, 434)
            Me.BandedDataGridViewSpotRadioResults.TabIndex = 0
            Me.BandedDataGridViewSpotRadioResults.UseEmbeddedNavigator = False
            Me.BandedDataGridViewSpotRadioResults.ViewCaptionHeight = -1
            '
            'TabItemRadioResults_RadioDataTab
            '
            Me.TabItemRadioResults_RadioDataTab.AttachedControl = Me.TabControlPanelRadioDataTab_RadioData
            Me.TabItemRadioResults_RadioDataTab.Name = "TabItemRadioResults_RadioDataTab"
            Me.TabItemRadioResults_RadioDataTab.Text = "Data"
            '
            'TabControlPanelRadioDashboardTab_RadioDashboard
            '
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Controls.Add(Me.DashboardViewerRadioDashboard_Dashboard)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Name = "TabControlPanelRadioDashboardTab_RadioDashboard"
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.Style.GradientAngle = 90
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.TabIndex = 11
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.TabItem = Me.TabItemRadioResults_RadioDashboardTab
            '
            'DashboardViewerRadioDashboard_Dashboard
            '
            Me.DashboardViewerRadioDashboard_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DashboardViewerRadioDashboard_Dashboard.Location = New System.Drawing.Point(1, 1)
            Me.DashboardViewerRadioDashboard_Dashboard.Name = "DashboardViewerRadioDashboard_Dashboard"
            Me.DashboardViewerRadioDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerRadioDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerRadioDashboard_Dashboard.Size = New System.Drawing.Size(815, 507)
            Me.DashboardViewerRadioDashboard_Dashboard.TabIndex = 2
            '
            'TabItemRadioResults_RadioDashboardTab
            '
            Me.TabItemRadioResults_RadioDashboardTab.AttachedControl = Me.TabControlPanelRadioDashboardTab_RadioDashboard
            Me.TabItemRadioResults_RadioDashboardTab.Name = "TabItemRadioResults_RadioDashboardTab"
            Me.TabItemRadioResults_RadioDashboardTab.Text = "Dashboard"
            '
            'TabItemSpotRadio_Results
            '
            Me.TabItemSpotRadio_Results.AttachedControl = Me.TabControlPanelSpotRadioResults_Results
            Me.TabItemSpotRadio_Results.Name = "TabItemSpotRadio_Results"
            Me.TabItemSpotRadio_Results.Text = "Results"
            '
            'TabControlPanelSpotRadioGeographyDayparts_Criteria
            '
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Controls.Add(Me.DataGridViewSpotRadio_Dayparts)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Controls.Add(Me.LabelSpotRadio_DaypartNote)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Controls.Add(Me.GroupBoxSpotRadioMarket_ListeningType)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Controls.Add(Me.GroupBoxSpotRadioMarket_Geography)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Name = "TabControlPanelSpotRadioGeographyDayparts_Criteria"
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.TabIndex = 11
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.TabItem = Me.TabItemSpotRadio_GeographyDayparts
            '
            'DataGridViewSpotRadio_Dayparts
            '
            Me.DataGridViewSpotRadio_Dayparts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_Dayparts.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_Dayparts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewSpotRadio_Dayparts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_Dayparts.ItemDescription = "Daypart(s)"
            Me.DataGridViewSpotRadio_Dayparts.Location = New System.Drawing.Point(1, 133)
            Me.DataGridViewSpotRadio_Dayparts.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_Dayparts.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_Dayparts.MultiSelect = True
            Me.DataGridViewSpotRadio_Dayparts.Name = "DataGridViewSpotRadio_Dayparts"
            Me.DataGridViewSpotRadio_Dayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSpotRadio_Dayparts.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_Dayparts.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_Dayparts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_Dayparts.Size = New System.Drawing.Size(823, 410)
            Me.DataGridViewSpotRadio_Dayparts.TabIndex = 3
            Me.DataGridViewSpotRadio_Dayparts.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_Dayparts.ViewCaptionHeight = -1
            '
            'LabelSpotRadio_DaypartNote
            '
            Me.LabelSpotRadio_DaypartNote.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotRadio_DaypartNote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotRadio_DaypartNote.Dock = System.Windows.Forms.DockStyle.Top
            Me.LabelSpotRadio_DaypartNote.Location = New System.Drawing.Point(1, 113)
            Me.LabelSpotRadio_DaypartNote.Name = "LabelSpotRadio_DaypartNote"
            Me.LabelSpotRadio_DaypartNote.Size = New System.Drawing.Size(823, 20)
            Me.LabelSpotRadio_DaypartNote.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotRadio_DaypartNote.TabIndex = 15
            Me.LabelSpotRadio_DaypartNote.Text = "Dayparts are noted with available qualifiers and metrics.  Non Standard Dayparts " &
    "only support AQH metrics."
            '
            'GroupBoxSpotRadioMarket_ListeningType
            '
            Me.GroupBoxSpotRadioMarket_ListeningType.Controls.Add(Me.RadioButtonSpotRadioListeningType_OutOfHome)
            Me.GroupBoxSpotRadioMarket_ListeningType.Controls.Add(Me.RadioButtonSpotRadioListeningType_Car)
            Me.GroupBoxSpotRadioMarket_ListeningType.Controls.Add(Me.RadioButtonSpotRadioListeningType_Work)
            Me.GroupBoxSpotRadioMarket_ListeningType.Controls.Add(Me.RadioButtonSpotRadioListeningType_Home)
            Me.GroupBoxSpotRadioMarket_ListeningType.Controls.Add(Me.RadioButtonSpotRadioListeningType_Total)
            Me.GroupBoxSpotRadioMarket_ListeningType.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBoxSpotRadioMarket_ListeningType.Location = New System.Drawing.Point(1, 57)
            Me.GroupBoxSpotRadioMarket_ListeningType.Name = "GroupBoxSpotRadioMarket_ListeningType"
            Me.GroupBoxSpotRadioMarket_ListeningType.Size = New System.Drawing.Size(823, 56)
            Me.GroupBoxSpotRadioMarket_ListeningType.TabIndex = 11
            Me.GroupBoxSpotRadioMarket_ListeningType.Text = "Listening Location"
            '
            'RadioButtonSpotRadioListeningType_OutOfHome
            '
            Me.RadioButtonSpotRadioListeningType_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioListeningType_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioListeningType_OutOfHome.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Location = New System.Drawing.Point(420, 22)
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Name = "RadioButtonSpotRadioListeningType_OutOfHome"
            Me.RadioButtonSpotRadioListeningType_OutOfHome.SecurityEnabled = True
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioListeningType_OutOfHome.TabIndex = 5
            Me.RadioButtonSpotRadioListeningType_OutOfHome.TabOnEnter = True
            Me.RadioButtonSpotRadioListeningType_OutOfHome.TabStop = False
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Tag = "6"
            Me.RadioButtonSpotRadioListeningType_OutOfHome.Text = "Out of Home"
            '
            'RadioButtonSpotRadioListeningType_Car
            '
            Me.RadioButtonSpotRadioListeningType_Car.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioListeningType_Car.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioListeningType_Car.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioListeningType_Car.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonSpotRadioListeningType_Car.Name = "RadioButtonSpotRadioListeningType_Car"
            Me.RadioButtonSpotRadioListeningType_Car.SecurityEnabled = True
            Me.RadioButtonSpotRadioListeningType_Car.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonSpotRadioListeningType_Car.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioListeningType_Car.TabIndex = 4
            Me.RadioButtonSpotRadioListeningType_Car.TabOnEnter = True
            Me.RadioButtonSpotRadioListeningType_Car.TabStop = False
            Me.RadioButtonSpotRadioListeningType_Car.Tag = "4"
            Me.RadioButtonSpotRadioListeningType_Car.Text = "Car"
            '
            'RadioButtonSpotRadioListeningType_Work
            '
            Me.RadioButtonSpotRadioListeningType_Work.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioListeningType_Work.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioListeningType_Work.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioListeningType_Work.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonSpotRadioListeningType_Work.Name = "RadioButtonSpotRadioListeningType_Work"
            Me.RadioButtonSpotRadioListeningType_Work.SecurityEnabled = True
            Me.RadioButtonSpotRadioListeningType_Work.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonSpotRadioListeningType_Work.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioListeningType_Work.TabIndex = 3
            Me.RadioButtonSpotRadioListeningType_Work.TabOnEnter = True
            Me.RadioButtonSpotRadioListeningType_Work.TabStop = False
            Me.RadioButtonSpotRadioListeningType_Work.Tag = "3"
            Me.RadioButtonSpotRadioListeningType_Work.Text = "Work"
            '
            'RadioButtonSpotRadioListeningType_Home
            '
            Me.RadioButtonSpotRadioListeningType_Home.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioListeningType_Home.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioListeningType_Home.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioListeningType_Home.Location = New System.Drawing.Point(302, 22)
            Me.RadioButtonSpotRadioListeningType_Home.Name = "RadioButtonSpotRadioListeningType_Home"
            Me.RadioButtonSpotRadioListeningType_Home.SecurityEnabled = True
            Me.RadioButtonSpotRadioListeningType_Home.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonSpotRadioListeningType_Home.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioListeningType_Home.TabIndex = 2
            Me.RadioButtonSpotRadioListeningType_Home.TabOnEnter = True
            Me.RadioButtonSpotRadioListeningType_Home.TabStop = False
            Me.RadioButtonSpotRadioListeningType_Home.Tag = "2"
            Me.RadioButtonSpotRadioListeningType_Home.Text = "Home"
            '
            'RadioButtonSpotRadioListeningType_Total
            '
            Me.RadioButtonSpotRadioListeningType_Total.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioListeningType_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioListeningType_Total.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioListeningType_Total.Checked = True
            Me.RadioButtonSpotRadioListeningType_Total.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSpotRadioListeningType_Total.CheckValue = "Y"
            Me.RadioButtonSpotRadioListeningType_Total.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonSpotRadioListeningType_Total.Name = "RadioButtonSpotRadioListeningType_Total"
            Me.RadioButtonSpotRadioListeningType_Total.SecurityEnabled = True
            Me.RadioButtonSpotRadioListeningType_Total.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSpotRadioListeningType_Total.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioListeningType_Total.TabIndex = 1
            Me.RadioButtonSpotRadioListeningType_Total.TabOnEnter = True
            Me.RadioButtonSpotRadioListeningType_Total.Tag = "1"
            Me.RadioButtonSpotRadioListeningType_Total.Text = "Total"
            '
            'GroupBoxSpotRadioMarket_Geography
            '
            Me.GroupBoxSpotRadioMarket_Geography.Controls.Add(Me.RadioButtonSpotRadioGeography_DMA)
            Me.GroupBoxSpotRadioMarket_Geography.Controls.Add(Me.RadioButtonSpotRadioGeography_TSA)
            Me.GroupBoxSpotRadioMarket_Geography.Controls.Add(Me.RadioButtonSpotRadioGeography_Metro)
            Me.GroupBoxSpotRadioMarket_Geography.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBoxSpotRadioMarket_Geography.Location = New System.Drawing.Point(1, 1)
            Me.GroupBoxSpotRadioMarket_Geography.Name = "GroupBoxSpotRadioMarket_Geography"
            Me.GroupBoxSpotRadioMarket_Geography.Size = New System.Drawing.Size(823, 56)
            Me.GroupBoxSpotRadioMarket_Geography.TabIndex = 10
            Me.GroupBoxSpotRadioMarket_Geography.Text = "Geography"
            '
            'RadioButtonSpotRadioGeography_DMA
            '
            Me.RadioButtonSpotRadioGeography_DMA.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioGeography_DMA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioGeography_DMA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioGeography_DMA.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonSpotRadioGeography_DMA.Name = "RadioButtonSpotRadioGeography_DMA"
            Me.RadioButtonSpotRadioGeography_DMA.SecurityEnabled = True
            Me.RadioButtonSpotRadioGeography_DMA.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonSpotRadioGeography_DMA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioGeography_DMA.TabIndex = 3
            Me.RadioButtonSpotRadioGeography_DMA.TabOnEnter = True
            Me.RadioButtonSpotRadioGeography_DMA.TabStop = False
            Me.RadioButtonSpotRadioGeography_DMA.Tag = "3"
            Me.RadioButtonSpotRadioGeography_DMA.Text = "DMA"
            '
            'RadioButtonSpotRadioGeography_TSA
            '
            Me.RadioButtonSpotRadioGeography_TSA.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioGeography_TSA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioGeography_TSA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioGeography_TSA.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonSpotRadioGeography_TSA.Name = "RadioButtonSpotRadioGeography_TSA"
            Me.RadioButtonSpotRadioGeography_TSA.SecurityEnabled = True
            Me.RadioButtonSpotRadioGeography_TSA.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonSpotRadioGeography_TSA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioGeography_TSA.TabIndex = 2
            Me.RadioButtonSpotRadioGeography_TSA.TabOnEnter = True
            Me.RadioButtonSpotRadioGeography_TSA.TabStop = False
            Me.RadioButtonSpotRadioGeography_TSA.Tag = "2"
            Me.RadioButtonSpotRadioGeography_TSA.Text = "TSA"
            '
            'RadioButtonSpotRadioGeography_Metro
            '
            Me.RadioButtonSpotRadioGeography_Metro.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSpotRadioGeography_Metro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSpotRadioGeography_Metro.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSpotRadioGeography_Metro.Checked = True
            Me.RadioButtonSpotRadioGeography_Metro.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSpotRadioGeography_Metro.CheckValue = "Y"
            Me.RadioButtonSpotRadioGeography_Metro.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonSpotRadioGeography_Metro.Name = "RadioButtonSpotRadioGeography_Metro"
            Me.RadioButtonSpotRadioGeography_Metro.SecurityEnabled = True
            Me.RadioButtonSpotRadioGeography_Metro.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSpotRadioGeography_Metro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSpotRadioGeography_Metro.TabIndex = 1
            Me.RadioButtonSpotRadioGeography_Metro.TabOnEnter = True
            Me.RadioButtonSpotRadioGeography_Metro.Tag = "1"
            Me.RadioButtonSpotRadioGeography_Metro.Text = "Metro"
            '
            'TabItemSpotRadio_GeographyDayparts
            '
            Me.TabItemSpotRadio_GeographyDayparts.AttachedControl = Me.TabControlPanelSpotRadioGeographyDayparts_Criteria
            Me.TabItemSpotRadio_GeographyDayparts.Name = "TabItemSpotRadio_GeographyDayparts"
            Me.TabItemSpotRadio_GeographyDayparts.Text = "Geography/Dayparts"
            '
            'TabControlPanelSpotRadioMetrics_Criteria
            '
            Me.TabControlPanelSpotRadioMetrics_Criteria.Controls.Add(Me.PanelSpotRadioMetrics_Criteria)
            Me.TabControlPanelSpotRadioMetrics_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioMetrics_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioMetrics_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioMetrics_Criteria.Name = "TabControlPanelSpotRadioMetrics_Criteria"
            Me.TabControlPanelSpotRadioMetrics_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioMetrics_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioMetrics_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioMetrics_Criteria.TabIndex = 25
            Me.TabControlPanelSpotRadioMetrics_Criteria.TabItem = Me.TabItemSpotRadio_Metrics
            '
            'PanelSpotRadioMetrics_Criteria
            '
            Me.PanelSpotRadioMetrics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotRadioMetrics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioMetrics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioMetrics_Criteria.Controls.Add(Me.PanelSpotRadioMetrics_Right)
            Me.PanelSpotRadioMetrics_Criteria.Controls.Add(Me.ExpandableSplitterControlSpotRadio_Metrics)
            Me.PanelSpotRadioMetrics_Criteria.Controls.Add(Me.PanelSpotRadioMetrics_Left)
            Me.PanelSpotRadioMetrics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotRadioMetrics_Criteria.Name = "PanelSpotRadioMetrics_Criteria"
            Me.PanelSpotRadioMetrics_Criteria.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotRadioMetrics_Criteria.TabIndex = 8
            '
            'PanelSpotRadioMetrics_Right
            '
            Me.PanelSpotRadioMetrics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioMetrics_Right.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioMetrics_Right.Controls.Add(Me.DataGridViewSpotRadio_SelectedMetrics)
            Me.PanelSpotRadioMetrics_Right.Controls.Add(Me.ButtonSpotRadioMetrics_AddToSelected)
            Me.PanelSpotRadioMetrics_Right.Controls.Add(Me.ButtonSpotRadioMetrics_RemoveFromSelected)
            Me.PanelSpotRadioMetrics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotRadioMetrics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelSpotRadioMetrics_Right.Name = "PanelSpotRadioMetrics_Right"
            Me.PanelSpotRadioMetrics_Right.Size = New System.Drawing.Size(490, 532)
            Me.PanelSpotRadioMetrics_Right.TabIndex = 1
            '
            'DataGridViewSpotRadio_SelectedMetrics
            '
            Me.DataGridViewSpotRadio_SelectedMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_SelectedMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_SelectedMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_SelectedMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_SelectedMetrics.ItemDescription = "Selected Metric(s)"
            Me.DataGridViewSpotRadio_SelectedMetrics.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotRadio_SelectedMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_SelectedMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_SelectedMetrics.MultiSelect = True
            Me.DataGridViewSpotRadio_SelectedMetrics.Name = "DataGridViewSpotRadio_SelectedMetrics"
            Me.DataGridViewSpotRadio_SelectedMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadio_SelectedMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_SelectedMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_SelectedMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_SelectedMetrics.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotRadio_SelectedMetrics.TabIndex = 2
            Me.DataGridViewSpotRadio_SelectedMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_SelectedMetrics.ViewCaptionHeight = -1
            '
            'ButtonSpotRadioMetrics_AddToSelected
            '
            Me.ButtonSpotRadioMetrics_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioMetrics_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioMetrics_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotRadioMetrics_AddToSelected.Name = "ButtonSpotRadioMetrics_AddToSelected"
            Me.ButtonSpotRadioMetrics_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotRadioMetrics_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioMetrics_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioMetrics_AddToSelected.TabIndex = 0
            Me.ButtonSpotRadioMetrics_AddToSelected.Text = ">"
            '
            'ButtonSpotRadioMetrics_RemoveFromSelected
            '
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.Name = "ButtonSpotRadioMetrics_RemoveFromSelected"
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotRadioMetrics_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotRadio_Metrics
            '
            Me.ExpandableSplitterControlSpotRadio_Metrics.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Metrics.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadio_Metrics.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Metrics.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Metrics.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadio_Metrics.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Metrics.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Metrics.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_Metrics.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotRadio_Metrics.Name = "ExpandableSplitterControlSpotRadio_Metrics"
            Me.ExpandableSplitterControlSpotRadio_Metrics.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotRadio_Metrics.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadio_Metrics.TabIndex = 20
            Me.ExpandableSplitterControlSpotRadio_Metrics.TabStop = False
            '
            'PanelSpotRadioMetrics_Left
            '
            Me.PanelSpotRadioMetrics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioMetrics_Left.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioMetrics_Left.Controls.Add(Me.DataGridViewSpotRadio_AvailableMetrics)
            Me.PanelSpotRadioMetrics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotRadioMetrics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelSpotRadioMetrics_Left.Name = "PanelSpotRadioMetrics_Left"
            Me.PanelSpotRadioMetrics_Left.Size = New System.Drawing.Size(317, 532)
            Me.PanelSpotRadioMetrics_Left.TabIndex = 0
            '
            'DataGridViewSpotRadio_AvailableMetrics
            '
            Me.DataGridViewSpotRadio_AvailableMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_AvailableMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_AvailableMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_AvailableMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_AvailableMetrics.ItemDescription = "Available Metric(s)"
            Me.DataGridViewSpotRadio_AvailableMetrics.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotRadio_AvailableMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_AvailableMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_AvailableMetrics.MultiSelect = True
            Me.DataGridViewSpotRadio_AvailableMetrics.Name = "DataGridViewSpotRadio_AvailableMetrics"
            Me.DataGridViewSpotRadio_AvailableMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadio_AvailableMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_AvailableMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_AvailableMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_AvailableMetrics.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotRadio_AvailableMetrics.TabIndex = 0
            Me.DataGridViewSpotRadio_AvailableMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_AvailableMetrics.ViewCaptionHeight = -1
            '
            'TabItemSpotRadio_Metrics
            '
            Me.TabItemSpotRadio_Metrics.AttachedControl = Me.TabControlPanelSpotRadioMetrics_Criteria
            Me.TabItemSpotRadio_Metrics.Name = "TabItemSpotRadio_Metrics"
            Me.TabItemSpotRadio_Metrics.Text = "Metrics"
            '
            'TabControlPanelSpotRadioStations_Criteria
            '
            Me.TabControlPanelSpotRadioStations_Criteria.Controls.Add(Me.PanelSpotRadioMarketStation_Bottom)
            Me.TabControlPanelSpotRadioStations_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotRadioStations_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotRadioStations_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotRadioStations_Criteria.Name = "TabControlPanelSpotRadioStations_Criteria"
            Me.TabControlPanelSpotRadioStations_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotRadioStations_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotRadioStations_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotRadioStations_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotRadioStations_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotRadioStations_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotRadioStations_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotRadioStations_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotRadioStations_Criteria.TabIndex = 50
            Me.TabControlPanelSpotRadioStations_Criteria.TabItem = Me.TabItemSpotRadio_Stations
            '
            'PanelSpotRadioMarketStation_Bottom
            '
            Me.PanelSpotRadioMarketStation_Bottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotRadioMarketStation_Bottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotRadioMarketStation_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelSpotRadioMarketStation_Bottom.Controls.Add(Me.PanelBottomSpotRadioStation_RightSection)
            Me.PanelSpotRadioMarketStation_Bottom.Controls.Add(Me.ExpandableSplitterControlSpotRadio_Stations)
            Me.PanelSpotRadioMarketStation_Bottom.Controls.Add(Me.PanelBottomSpotRadioStation_LeftSection)
            Me.PanelSpotRadioMarketStation_Bottom.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotRadioMarketStation_Bottom.Name = "PanelSpotRadioMarketStation_Bottom"
            Me.PanelSpotRadioMarketStation_Bottom.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotRadioMarketStation_Bottom.TabIndex = 7
            '
            'PanelBottomSpotRadioStation_RightSection
            '
            Me.PanelBottomSpotRadioStation_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotRadioStation_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotRadioStation_RightSection.Controls.Add(Me.DataGridViewSpotRadio_SelectedStations)
            Me.PanelBottomSpotRadioStation_RightSection.Controls.Add(Me.ButtonSpotRadioStation_AddToSelected)
            Me.PanelBottomSpotRadioStation_RightSection.Controls.Add(Me.ButtonSpotRadioStation_RemoveFromSelected)
            Me.PanelBottomSpotRadioStation_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomSpotRadioStation_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelBottomSpotRadioStation_RightSection.Name = "PanelBottomSpotRadioStation_RightSection"
            Me.PanelBottomSpotRadioStation_RightSection.Size = New System.Drawing.Size(490, 532)
            Me.PanelBottomSpotRadioStation_RightSection.TabIndex = 1
            '
            'DataGridViewSpotRadio_SelectedStations
            '
            Me.DataGridViewSpotRadio_SelectedStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_SelectedStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_SelectedStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_SelectedStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_SelectedStations.ItemDescription = "Selected Station(s)"
            Me.DataGridViewSpotRadio_SelectedStations.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotRadio_SelectedStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_SelectedStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_SelectedStations.MultiSelect = True
            Me.DataGridViewSpotRadio_SelectedStations.Name = "DataGridViewSpotRadio_SelectedStations"
            Me.DataGridViewSpotRadio_SelectedStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadio_SelectedStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_SelectedStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_SelectedStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_SelectedStations.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotRadio_SelectedStations.TabIndex = 2
            Me.DataGridViewSpotRadio_SelectedStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_SelectedStations.ViewCaptionHeight = -1
            '
            'ButtonSpotRadioStation_AddToSelected
            '
            Me.ButtonSpotRadioStation_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioStation_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioStation_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotRadioStation_AddToSelected.Name = "ButtonSpotRadioStation_AddToSelected"
            Me.ButtonSpotRadioStation_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotRadioStation_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioStation_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioStation_AddToSelected.TabIndex = 0
            Me.ButtonSpotRadioStation_AddToSelected.Text = ">"
            '
            'ButtonSpotRadioStation_RemoveFromSelected
            '
            Me.ButtonSpotRadioStation_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotRadioStation_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotRadioStation_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotRadioStation_RemoveFromSelected.Name = "ButtonSpotRadioStation_RemoveFromSelected"
            Me.ButtonSpotRadioStation_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotRadioStation_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotRadioStation_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotRadioStation_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotRadioStation_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotRadio_Stations
            '
            Me.ExpandableSplitterControlSpotRadio_Stations.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Stations.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadio_Stations.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Stations.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Stations.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadio_Stations.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Stations.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_Stations.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadio_Stations.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadio_Stations.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Stations.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_Stations.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_Stations.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_Stations.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_Stations.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotRadio_Stations.Name = "ExpandableSplitterControlSpotRadio_Stations"
            Me.ExpandableSplitterControlSpotRadio_Stations.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotRadio_Stations.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadio_Stations.TabIndex = 20
            Me.ExpandableSplitterControlSpotRadio_Stations.TabStop = False
            '
            'PanelBottomSpotRadioStation_LeftSection
            '
            Me.PanelBottomSpotRadioStation_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotRadioStation_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotRadioStation_LeftSection.Controls.Add(Me.DataGridViewSpotRadio_AvailableStations)
            Me.PanelBottomSpotRadioStation_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBottomSpotRadioStation_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBottomSpotRadioStation_LeftSection.Name = "PanelBottomSpotRadioStation_LeftSection"
            Me.PanelBottomSpotRadioStation_LeftSection.Size = New System.Drawing.Size(317, 532)
            Me.PanelBottomSpotRadioStation_LeftSection.TabIndex = 0
            '
            'DataGridViewSpotRadio_AvailableStations
            '
            Me.DataGridViewSpotRadio_AvailableStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_AvailableStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_AvailableStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_AvailableStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_AvailableStations.ItemDescription = "Available Station(s)"
            Me.DataGridViewSpotRadio_AvailableStations.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotRadio_AvailableStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_AvailableStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_AvailableStations.MultiSelect = True
            Me.DataGridViewSpotRadio_AvailableStations.Name = "DataGridViewSpotRadio_AvailableStations"
            Me.DataGridViewSpotRadio_AvailableStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadio_AvailableStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_AvailableStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_AvailableStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_AvailableStations.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotRadio_AvailableStations.TabIndex = 0
            Me.DataGridViewSpotRadio_AvailableStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_AvailableStations.ViewCaptionHeight = -1
            '
            'TabItemSpotRadio_Stations
            '
            Me.TabItemSpotRadio_Stations.AttachedControl = Me.TabControlPanelSpotRadioStations_Criteria
            Me.TabItemSpotRadio_Stations.Name = "TabItemSpotRadio_Stations"
            Me.TabItemSpotRadio_Stations.Text = "Stations"
            '
            'ExpandableSplitterControlSpotRadio_LeftRight
            '
            Me.ExpandableSplitterControlSpotRadio_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotRadio_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotRadio_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotRadio_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotRadio_LeftRight.Location = New System.Drawing.Point(198, 1)
            Me.ExpandableSplitterControlSpotRadio_LeftRight.Name = "ExpandableSplitterControlSpotRadio_LeftRight"
            Me.ExpandableSplitterControlSpotRadio_LeftRight.Size = New System.Drawing.Size(6, 595)
            Me.ExpandableSplitterControlSpotRadio_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotRadio_LeftRight.TabIndex = 11
            Me.ExpandableSplitterControlSpotRadio_LeftRight.TabStop = False
            '
            'PanelSpotRadio_LeftSection
            '
            Me.PanelSpotRadio_LeftSection.Controls.Add(Me.DataGridViewSpotRadio_UserCriterias)
            Me.PanelSpotRadio_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotRadio_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelSpotRadio_LeftSection.Name = "PanelSpotRadio_LeftSection"
            Me.PanelSpotRadio_LeftSection.Size = New System.Drawing.Size(197, 595)
            Me.PanelSpotRadio_LeftSection.TabIndex = 1
            '
            'DataGridViewSpotRadio_UserCriterias
            '
            Me.DataGridViewSpotRadio_UserCriterias.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotRadio_UserCriterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotRadio_UserCriterias.AutoUpdateViewCaption = True
            Me.DataGridViewSpotRadio_UserCriterias.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotRadio_UserCriterias.ItemDescription = "Report(s)"
            Me.DataGridViewSpotRadio_UserCriterias.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewSpotRadio_UserCriterias.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotRadio_UserCriterias.ModifyGridRowHeight = False
            Me.DataGridViewSpotRadio_UserCriterias.MultiSelect = False
            Me.DataGridViewSpotRadio_UserCriterias.Name = "DataGridViewSpotRadio_UserCriterias"
            Me.DataGridViewSpotRadio_UserCriterias.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotRadio_UserCriterias.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotRadio_UserCriterias.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotRadio_UserCriterias.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotRadio_UserCriterias.Size = New System.Drawing.Size(180, 571)
            Me.DataGridViewSpotRadio_UserCriterias.TabIndex = 0
            Me.DataGridViewSpotRadio_UserCriterias.UseEmbeddedNavigator = False
            Me.DataGridViewSpotRadio_UserCriterias.ViewCaptionHeight = -1
            '
            'TabItemTabs_SpotRadioTab
            '
            Me.TabItemTabs_SpotRadioTab.AttachedControl = Me.TabControlPanelSpotRadio_SpotRadio
            Me.TabItemTabs_SpotRadioTab.Name = "TabItemTabs_SpotRadioTab"
            Me.TabItemTabs_SpotRadioTab.Text = "Spot Radio Market"
            '
            'TabControlPanelSpotTV_SpotTV
            '
            Me.TabControlPanelSpotTV_SpotTV.Controls.Add(Me.PanelSpotTV_RightSection)
            Me.TabControlPanelSpotTV_SpotTV.Controls.Add(Me.ExpandableSplitterControlSpotTV_LeftRight)
            Me.TabControlPanelSpotTV_SpotTV.Controls.Add(Me.PanelSpotTV_LeftSection)
            Me.TabControlPanelSpotTV_SpotTV.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTV_SpotTV.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTV_SpotTV.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTV_SpotTV.Name = "TabControlPanelSpotTV_SpotTV"
            Me.TabControlPanelSpotTV_SpotTV.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTV_SpotTV.Size = New System.Drawing.Size(1054, 597)
            Me.TabControlPanelSpotTV_SpotTV.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTV_SpotTV.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTV_SpotTV.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTV_SpotTV.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTV_SpotTV.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTV_SpotTV.Style.GradientAngle = 90
            Me.TabControlPanelSpotTV_SpotTV.TabIndex = 1
            Me.TabControlPanelSpotTV_SpotTV.TabItem = Me.TabItemTabs_SpotTVTab
            '
            'PanelSpotTV_RightSection
            '
            Me.PanelSpotTV_RightSection.Controls.Add(Me.TabControlSpotTV_ResearchCriteria)
            Me.PanelSpotTV_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotTV_RightSection.Location = New System.Drawing.Point(204, 1)
            Me.PanelSpotTV_RightSection.Name = "PanelSpotTV_RightSection"
            Me.PanelSpotTV_RightSection.Size = New System.Drawing.Size(849, 595)
            Me.PanelSpotTV_RightSection.TabIndex = 13
            '
            'TabControlSpotTV_ResearchCriteria
            '
            Me.TabControlSpotTV_ResearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlSpotTV_ResearchCriteria.BackColor = System.Drawing.Color.White
            Me.TabControlSpotTV_ResearchCriteria.CanReorderTabs = False
            Me.TabControlSpotTV_ResearchCriteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlSpotTV_ResearchCriteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlSpotTV_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotTVMarketStations_Criteria)
            Me.TabControlSpotTV_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotTVBooks_Criteria)
            Me.TabControlSpotTV_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotTVResults_Results)
            Me.TabControlSpotTV_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotTVMetrics_Criteria)
            Me.TabControlSpotTV_ResearchCriteria.Controls.Add(Me.TabControlPanelSpotTVDemographics_Criteria)
            Me.TabControlSpotTV_ResearchCriteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlSpotTV_ResearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlSpotTV_ResearchCriteria.Name = "TabControlSpotTV_ResearchCriteria"
            Me.TabControlSpotTV_ResearchCriteria.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlSpotTV_ResearchCriteria.SelectedTabIndex = 0
            Me.TabControlSpotTV_ResearchCriteria.Size = New System.Drawing.Size(825, 571)
            Me.TabControlSpotTV_ResearchCriteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlSpotTV_ResearchCriteria.TabIndex = 0
            Me.TabControlSpotTV_ResearchCriteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlSpotTV_ResearchCriteria.Tabs.Add(Me.TabItemSpotTV_MarketStations)
            Me.TabControlSpotTV_ResearchCriteria.Tabs.Add(Me.TabItemSpotTV_Books)
            Me.TabControlSpotTV_ResearchCriteria.Tabs.Add(Me.TabItemSpotTV_Demographics)
            Me.TabControlSpotTV_ResearchCriteria.Tabs.Add(Me.TabItemSpotTV_Metrics)
            Me.TabControlSpotTV_ResearchCriteria.Tabs.Add(Me.TabItemSpotTV_Results)
            '
            'TabControlPanelSpotTVMarketStations_Criteria
            '
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.ComboBoxSpotTVMarketStation_Source)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.LabelSpotTVMarketStation_Source)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.LabelSpotTVMarketStation_MaximumRank)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.NumericInputSpotTVMarketStation_MaximumRank)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.ComboBoxSpotTVMarketStation_ReportType)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.PanelSpotTVMarketStation_Bottom)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.GroupBoxSpotTVMarketStation_Options)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.LabelSpotTVMarketStation_Market)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.LabelSpotTVMarketStation_ReportType)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Controls.Add(Me.SearchableComboBoxSpotTVMarketStation_Market)
            Me.TabControlPanelSpotTVMarketStations_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTVMarketStations_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTVMarketStations_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Name = "TabControlPanelSpotTVMarketStations_Criteria"
            Me.TabControlPanelSpotTVMarketStations_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTVMarketStations_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotTVMarketStations_Criteria.TabIndex = 0
            Me.TabControlPanelSpotTVMarketStations_Criteria.TabItem = Me.TabItemSpotTV_MarketStations
            '
            'ComboBoxSpotTVMarketStation_Source
            '
            Me.ComboBoxSpotTVMarketStation_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSpotTVMarketStation_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxSpotTVMarketStation_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSpotTVMarketStation_Source.AutoFindItemInDataSource = True
            Me.ComboBoxSpotTVMarketStation_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSpotTVMarketStation_Source.BookmarkingEnabled = False
            Me.ComboBoxSpotTVMarketStation_Source.DisableMouseWheel = True
            Me.ComboBoxSpotTVMarketStation_Source.DisplayMember = "Display"
            Me.ComboBoxSpotTVMarketStation_Source.DisplayName = "Source"
            Me.ComboBoxSpotTVMarketStation_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSpotTVMarketStation_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSpotTVMarketStation_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSpotTVMarketStation_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSpotTVMarketStation_Source.FocusHighlightEnabled = True
            Me.ComboBoxSpotTVMarketStation_Source.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSpotTVMarketStation_Source.FormattingEnabled = True
            Me.ComboBoxSpotTVMarketStation_Source.ItemHeight = 16
            Me.ComboBoxSpotTVMarketStation_Source.Location = New System.Drawing.Point(99, 4)
            Me.ComboBoxSpotTVMarketStation_Source.Name = "ComboBoxSpotTVMarketStation_Source"
            Me.ComboBoxSpotTVMarketStation_Source.ReadOnly = False
            Me.ComboBoxSpotTVMarketStation_Source.SecurityEnabled = True
            Me.ComboBoxSpotTVMarketStation_Source.Size = New System.Drawing.Size(226, 22)
            Me.ComboBoxSpotTVMarketStation_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSpotTVMarketStation_Source.TabIndex = 1
            Me.ComboBoxSpotTVMarketStation_Source.TabOnEnter = True
            Me.ComboBoxSpotTVMarketStation_Source.ValueMember = "Value"
            Me.ComboBoxSpotTVMarketStation_Source.WatermarkText = "Select Month"
            '
            'LabelSpotTVMarketStation_Source
            '
            Me.LabelSpotTVMarketStation_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotTVMarketStation_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotTVMarketStation_Source.Location = New System.Drawing.Point(12, 4)
            Me.LabelSpotTVMarketStation_Source.Name = "LabelSpotTVMarketStation_Source"
            Me.LabelSpotTVMarketStation_Source.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotTVMarketStation_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotTVMarketStation_Source.TabIndex = 0
            Me.LabelSpotTVMarketStation_Source.Text = "Source:"
            '
            'LabelSpotTVMarketStation_MaximumRank
            '
            Me.LabelSpotTVMarketStation_MaximumRank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotTVMarketStation_MaximumRank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotTVMarketStation_MaximumRank.Location = New System.Drawing.Point(337, 29)
            Me.LabelSpotTVMarketStation_MaximumRank.Name = "LabelSpotTVMarketStation_MaximumRank"
            Me.LabelSpotTVMarketStation_MaximumRank.Size = New System.Drawing.Size(63, 20)
            Me.LabelSpotTVMarketStation_MaximumRank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotTVMarketStation_MaximumRank.TabIndex = 4
            Me.LabelSpotTVMarketStation_MaximumRank.Text = "Max Rank:"
            '
            'NumericInputSpotTVMarketStation_MaximumRank
            '
            Me.NumericInputSpotTVMarketStation_MaximumRank.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSpotTVMarketStation_MaximumRank.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputSpotTVMarketStation_MaximumRank.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputSpotTVMarketStation_MaximumRank.EnterMoveNextControl = True
            Me.NumericInputSpotTVMarketStation_MaximumRank.Location = New System.Drawing.Point(406, 30)
            Me.NumericInputSpotTVMarketStation_MaximumRank.Name = "NumericInputSpotTVMarketStation_MaximumRank"
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.AllowMouseWheel = False
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.IsFloatValue = False
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.Mask.EditMask = "f0"
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputSpotTVMarketStation_MaximumRank.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputSpotTVMarketStation_MaximumRank.SecurityEnabled = True
            Me.NumericInputSpotTVMarketStation_MaximumRank.Size = New System.Drawing.Size(58, 20)
            Me.NumericInputSpotTVMarketStation_MaximumRank.TabIndex = 5
            '
            'ComboBoxSpotTVMarketStation_ReportType
            '
            Me.ComboBoxSpotTVMarketStation_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSpotTVMarketStation_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxSpotTVMarketStation_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSpotTVMarketStation_ReportType.AutoFindItemInDataSource = True
            Me.ComboBoxSpotTVMarketStation_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSpotTVMarketStation_ReportType.BookmarkingEnabled = False
            Me.ComboBoxSpotTVMarketStation_ReportType.DisableMouseWheel = True
            Me.ComboBoxSpotTVMarketStation_ReportType.DisplayMember = "Display"
            Me.ComboBoxSpotTVMarketStation_ReportType.DisplayName = "Report Type"
            Me.ComboBoxSpotTVMarketStation_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSpotTVMarketStation_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSpotTVMarketStation_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSpotTVMarketStation_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSpotTVMarketStation_ReportType.FocusHighlightEnabled = True
            Me.ComboBoxSpotTVMarketStation_ReportType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSpotTVMarketStation_ReportType.FormattingEnabled = True
            Me.ComboBoxSpotTVMarketStation_ReportType.ItemHeight = 16
            Me.ComboBoxSpotTVMarketStation_ReportType.Location = New System.Drawing.Point(99, 55)
            Me.ComboBoxSpotTVMarketStation_ReportType.Name = "ComboBoxSpotTVMarketStation_ReportType"
            Me.ComboBoxSpotTVMarketStation_ReportType.ReadOnly = False
            Me.ComboBoxSpotTVMarketStation_ReportType.SecurityEnabled = True
            Me.ComboBoxSpotTVMarketStation_ReportType.Size = New System.Drawing.Size(226, 22)
            Me.ComboBoxSpotTVMarketStation_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSpotTVMarketStation_ReportType.TabIndex = 5
            Me.ComboBoxSpotTVMarketStation_ReportType.TabOnEnter = True
            Me.ComboBoxSpotTVMarketStation_ReportType.ValueMember = "Value"
            Me.ComboBoxSpotTVMarketStation_ReportType.WatermarkText = "Select Month"
            '
            'PanelSpotTVMarketStation_Bottom
            '
            Me.PanelSpotTVMarketStation_Bottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotTVMarketStation_Bottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVMarketStation_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVMarketStation_Bottom.Controls.Add(Me.PanelBottomSpotTVMarketStation_RightSection)
            Me.PanelSpotTVMarketStation_Bottom.Controls.Add(Me.ExpandableSplitterSpotTVMarketStations_LeftRight)
            Me.PanelSpotTVMarketStation_Bottom.Controls.Add(Me.PanelBottomSpotTVMarketStation_LeftSection)
            Me.PanelSpotTVMarketStation_Bottom.Location = New System.Drawing.Point(12, 141)
            Me.PanelSpotTVMarketStation_Bottom.Name = "PanelSpotTVMarketStation_Bottom"
            Me.PanelSpotTVMarketStation_Bottom.Size = New System.Drawing.Size(801, 398)
            Me.PanelSpotTVMarketStation_Bottom.TabIndex = 6
            '
            'PanelBottomSpotTVMarketStation_RightSection
            '
            Me.PanelBottomSpotTVMarketStation_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotTVMarketStation_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.DataGridViewSpotTV_SelectedStations)
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.ButtonSpotTVStation_AddToSelected)
            Me.PanelBottomSpotTVMarketStation_RightSection.Controls.Add(Me.ButtonSpotTVStation_RemoveFromSelected)
            Me.PanelBottomSpotTVMarketStation_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomSpotTVMarketStation_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelBottomSpotTVMarketStation_RightSection.Name = "PanelBottomSpotTVMarketStation_RightSection"
            Me.PanelBottomSpotTVMarketStation_RightSection.Size = New System.Drawing.Size(474, 394)
            Me.PanelBottomSpotTVMarketStation_RightSection.TabIndex = 1
            '
            'DataGridViewSpotTV_SelectedStations
            '
            Me.DataGridViewSpotTV_SelectedStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_SelectedStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_SelectedStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_SelectedStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_SelectedStations.ItemDescription = "Selected Station(s)"
            Me.DataGridViewSpotTV_SelectedStations.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotTV_SelectedStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_SelectedStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_SelectedStations.MultiSelect = True
            Me.DataGridViewSpotTV_SelectedStations.Name = "DataGridViewSpotTV_SelectedStations"
            Me.DataGridViewSpotTV_SelectedStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_SelectedStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_SelectedStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_SelectedStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_SelectedStations.Size = New System.Drawing.Size(383, 384)
            Me.DataGridViewSpotTV_SelectedStations.TabIndex = 2
            Me.DataGridViewSpotTV_SelectedStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_SelectedStations.ViewCaptionHeight = -1
            '
            'ButtonSpotTVStation_AddToSelected
            '
            Me.ButtonSpotTVStation_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVStation_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVStation_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotTVStation_AddToSelected.Name = "ButtonSpotTVStation_AddToSelected"
            Me.ButtonSpotTVStation_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotTVStation_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVStation_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVStation_AddToSelected.TabIndex = 0
            Me.ButtonSpotTVStation_AddToSelected.Text = ">"
            '
            'ButtonSpotTVStation_RemoveFromSelected
            '
            Me.ButtonSpotTVStation_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVStation_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVStation_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotTVStation_RemoveFromSelected.Name = "ButtonSpotTVStation_RemoveFromSelected"
            Me.ButtonSpotTVStation_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotTVStation_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVStation_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVStation_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotTVStation_RemoveFromSelected.Text = "<"
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
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Name = "ExpandableSplitterSpotTVMarketStations_LeftRight"
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Size = New System.Drawing.Size(6, 394)
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.TabIndex = 20
            Me.ExpandableSplitterSpotTVMarketStations_LeftRight.TabStop = False
            '
            'PanelBottomSpotTVMarketStation_LeftSection
            '
            Me.PanelBottomSpotTVMarketStation_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomSpotTVMarketStation_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomSpotTVMarketStation_LeftSection.Controls.Add(Me.DataGridViewSpotTV_AvailableStations)
            Me.PanelBottomSpotTVMarketStation_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBottomSpotTVMarketStation_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBottomSpotTVMarketStation_LeftSection.Name = "PanelBottomSpotTVMarketStation_LeftSection"
            Me.PanelBottomSpotTVMarketStation_LeftSection.Size = New System.Drawing.Size(317, 394)
            Me.PanelBottomSpotTVMarketStation_LeftSection.TabIndex = 0
            '
            'DataGridViewSpotTV_AvailableStations
            '
            Me.DataGridViewSpotTV_AvailableStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_AvailableStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_AvailableStations.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_AvailableStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_AvailableStations.ItemDescription = "Available Station(s)"
            Me.DataGridViewSpotTV_AvailableStations.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotTV_AvailableStations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_AvailableStations.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_AvailableStations.MultiSelect = True
            Me.DataGridViewSpotTV_AvailableStations.Name = "DataGridViewSpotTV_AvailableStations"
            Me.DataGridViewSpotTV_AvailableStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_AvailableStations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_AvailableStations.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_AvailableStations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_AvailableStations.Size = New System.Drawing.Size(306, 394)
            Me.DataGridViewSpotTV_AvailableStations.TabIndex = 0
            Me.DataGridViewSpotTV_AvailableStations.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_AvailableStations.ViewCaptionHeight = -1
            '
            'GroupBoxSpotTVMarketStation_Options
            '
            Me.GroupBoxSpotTVMarketStation_Options.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSpotTVMarketStation_Options.Controls.Add(Me.CheckBoxSpotTVOptions_GroupByDaysTimes)
            Me.GroupBoxSpotTVMarketStation_Options.Controls.Add(Me.CheckBoxSpotTVOptions_ShowSpill)
            Me.GroupBoxSpotTVMarketStation_Options.Controls.Add(Me.CheckBoxSpotTVOptions_DominantProgramming)
            Me.GroupBoxSpotTVMarketStation_Options.Controls.Add(Me.CheckBoxSpotTVOptions_ShowProgramName)
            Me.GroupBoxSpotTVMarketStation_Options.Location = New System.Drawing.Point(12, 83)
            Me.GroupBoxSpotTVMarketStation_Options.Name = "GroupBoxSpotTVMarketStation_Options"
            Me.GroupBoxSpotTVMarketStation_Options.Size = New System.Drawing.Size(801, 52)
            Me.GroupBoxSpotTVMarketStation_Options.TabIndex = 5
            Me.GroupBoxSpotTVMarketStation_Options.Text = "Options"
            '
            'CheckBoxSpotTVOptions_GroupByDaysTimes
            '
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.CheckValue = 0
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.CheckValueChecked = 1
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.CheckValueUnchecked = 0
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.ChildControls = Nothing
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.Location = New System.Drawing.Point(427, 24)
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.Name = "CheckBoxSpotTVOptions_GroupByDaysTimes"
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.OldestSibling = Nothing
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.SecurityEnabled = True
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.SiblingControls = Nothing
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.TabIndex = 3
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.TabOnEnter = True
            Me.CheckBoxSpotTVOptions_GroupByDaysTimes.Text = "Group By Days / Times"
            '
            'CheckBoxSpotTVOptions_ShowSpill
            '
            Me.CheckBoxSpotTVOptions_ShowSpill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotTVOptions_ShowSpill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotTVOptions_ShowSpill.CheckValue = 0
            Me.CheckBoxSpotTVOptions_ShowSpill.CheckValueChecked = 1
            Me.CheckBoxSpotTVOptions_ShowSpill.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotTVOptions_ShowSpill.CheckValueUnchecked = 0
            Me.CheckBoxSpotTVOptions_ShowSpill.ChildControls = Nothing
            Me.CheckBoxSpotTVOptions_ShowSpill.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotTVOptions_ShowSpill.Location = New System.Drawing.Point(323, 24)
            Me.CheckBoxSpotTVOptions_ShowSpill.Name = "CheckBoxSpotTVOptions_ShowSpill"
            Me.CheckBoxSpotTVOptions_ShowSpill.OldestSibling = Nothing
            Me.CheckBoxSpotTVOptions_ShowSpill.SecurityEnabled = True
            Me.CheckBoxSpotTVOptions_ShowSpill.SiblingControls = Nothing
            Me.CheckBoxSpotTVOptions_ShowSpill.Size = New System.Drawing.Size(98, 20)
            Me.CheckBoxSpotTVOptions_ShowSpill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotTVOptions_ShowSpill.TabIndex = 2
            Me.CheckBoxSpotTVOptions_ShowSpill.TabOnEnter = True
            Me.CheckBoxSpotTVOptions_ShowSpill.Text = "Show Spill"
            '
            'CheckBoxSpotTVOptions_DominantProgramming
            '
            Me.CheckBoxSpotTVOptions_DominantProgramming.AutoCheck = False
            Me.CheckBoxSpotTVOptions_DominantProgramming.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotTVOptions_DominantProgramming.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotTVOptions_DominantProgramming.CheckValue = 0
            Me.CheckBoxSpotTVOptions_DominantProgramming.CheckValueChecked = 1
            Me.CheckBoxSpotTVOptions_DominantProgramming.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotTVOptions_DominantProgramming.CheckValueUnchecked = 0
            Me.CheckBoxSpotTVOptions_DominantProgramming.ChildControls = Nothing
            Me.CheckBoxSpotTVOptions_DominantProgramming.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotTVOptions_DominantProgramming.Enabled = False
            Me.CheckBoxSpotTVOptions_DominantProgramming.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxSpotTVOptions_DominantProgramming.Name = "CheckBoxSpotTVOptions_DominantProgramming"
            Me.CheckBoxSpotTVOptions_DominantProgramming.OldestSibling = Nothing
            Me.CheckBoxSpotTVOptions_DominantProgramming.SecurityEnabled = True
            Me.CheckBoxSpotTVOptions_DominantProgramming.SiblingControls = Nothing
            Me.CheckBoxSpotTVOptions_DominantProgramming.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxSpotTVOptions_DominantProgramming.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotTVOptions_DominantProgramming.TabIndex = 0
            Me.CheckBoxSpotTVOptions_DominantProgramming.TabOnEnter = True
            Me.CheckBoxSpotTVOptions_DominantProgramming.Text = "Dominant Programming"
            '
            'CheckBoxSpotTVOptions_ShowProgramName
            '
            Me.CheckBoxSpotTVOptions_ShowProgramName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSpotTVOptions_ShowProgramName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSpotTVOptions_ShowProgramName.CheckValue = 0
            Me.CheckBoxSpotTVOptions_ShowProgramName.CheckValueChecked = 1
            Me.CheckBoxSpotTVOptions_ShowProgramName.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSpotTVOptions_ShowProgramName.CheckValueUnchecked = 0
            Me.CheckBoxSpotTVOptions_ShowProgramName.ChildControls = Nothing
            Me.CheckBoxSpotTVOptions_ShowProgramName.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSpotTVOptions_ShowProgramName.Location = New System.Drawing.Point(164, 24)
            Me.CheckBoxSpotTVOptions_ShowProgramName.Name = "CheckBoxSpotTVOptions_ShowProgramName"
            Me.CheckBoxSpotTVOptions_ShowProgramName.OldestSibling = Nothing
            Me.CheckBoxSpotTVOptions_ShowProgramName.SecurityEnabled = True
            Me.CheckBoxSpotTVOptions_ShowProgramName.SiblingControls = Nothing
            Me.CheckBoxSpotTVOptions_ShowProgramName.Size = New System.Drawing.Size(153, 20)
            Me.CheckBoxSpotTVOptions_ShowProgramName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSpotTVOptions_ShowProgramName.TabIndex = 1
            Me.CheckBoxSpotTVOptions_ShowProgramName.TabOnEnter = True
            Me.CheckBoxSpotTVOptions_ShowProgramName.Text = "Show Program Name"
            '
            'LabelSpotTVMarketStation_Market
            '
            Me.LabelSpotTVMarketStation_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotTVMarketStation_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotTVMarketStation_Market.Location = New System.Drawing.Point(11, 29)
            Me.LabelSpotTVMarketStation_Market.Name = "LabelSpotTVMarketStation_Market"
            Me.LabelSpotTVMarketStation_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotTVMarketStation_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotTVMarketStation_Market.TabIndex = 2
            Me.LabelSpotTVMarketStation_Market.Text = "Market:"
            '
            'LabelSpotTVMarketStation_ReportType
            '
            Me.LabelSpotTVMarketStation_ReportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotTVMarketStation_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotTVMarketStation_ReportType.Location = New System.Drawing.Point(12, 55)
            Me.LabelSpotTVMarketStation_ReportType.Name = "LabelSpotTVMarketStation_ReportType"
            Me.LabelSpotTVMarketStation_ReportType.Size = New System.Drawing.Size(81, 20)
            Me.LabelSpotTVMarketStation_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotTVMarketStation_ReportType.TabIndex = 4
            Me.LabelSpotTVMarketStation_ReportType.Text = "Report Type:"
            '
            'SearchableComboBoxSpotTVMarketStation_Market
            '
            Me.SearchableComboBoxSpotTVMarketStation_Market.ActiveFilterString = ""
            Me.SearchableComboBoxSpotTVMarketStation_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSpotTVMarketStation_Market.AutoFillMode = False
            Me.SearchableComboBoxSpotTVMarketStation_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxSpotTVMarketStation_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxSpotTVMarketStation_Market.DataSource = Nothing
            Me.SearchableComboBoxSpotTVMarketStation_Market.DisableMouseWheel = True
            Me.SearchableComboBoxSpotTVMarketStation_Market.DisplayName = ""
            Me.SearchableComboBoxSpotTVMarketStation_Market.EditValue = ""
            Me.SearchableComboBoxSpotTVMarketStation_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxSpotTVMarketStation_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSpotTVMarketStation_Market.Location = New System.Drawing.Point(99, 30)
            Me.SearchableComboBoxSpotTVMarketStation_Market.Name = "SearchableComboBoxSpotTVMarketStation_Market"
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.PopupView = Me.SearchableComboBoxSpotTVViewControl_Market
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.ShowClearButton = False
            Me.SearchableComboBoxSpotTVMarketStation_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSpotTVMarketStation_Market.SecurityEnabled = True
            Me.SearchableComboBoxSpotTVMarketStation_Market.SelectedValue = ""
            Me.SearchableComboBoxSpotTVMarketStation_Market.Size = New System.Drawing.Size(226, 20)
            Me.SearchableComboBoxSpotTVMarketStation_Market.TabIndex = 3
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
            'TabItemSpotTV_MarketStations
            '
            Me.TabItemSpotTV_MarketStations.AttachedControl = Me.TabControlPanelSpotTVMarketStations_Criteria
            Me.TabItemSpotTV_MarketStations.Name = "TabItemSpotTV_MarketStations"
            Me.TabItemSpotTV_MarketStations.Text = "Market/Report Type/Stations"
            '
            'TabControlPanelSpotTVBooks_Criteria
            '
            Me.TabControlPanelSpotTVBooks_Criteria.Controls.Add(Me.DataGridViewSpotTV_DayTimes)
            Me.TabControlPanelSpotTVBooks_Criteria.Controls.Add(Me.ExpandableSplitterSpotTVDaysTimes)
            Me.TabControlPanelSpotTVBooks_Criteria.Controls.Add(Me.ShareHPUTBookControl_Books)
            Me.TabControlPanelSpotTVBooks_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTVBooks_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTVBooks_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTVBooks_Criteria.Name = "TabControlPanelSpotTVBooks_Criteria"
            Me.TabControlPanelSpotTVBooks_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTVBooks_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotTVBooks_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTVBooks_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTVBooks_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTVBooks_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTVBooks_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTVBooks_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotTVBooks_Criteria.TabIndex = 11
            Me.TabControlPanelSpotTVBooks_Criteria.TabItem = Me.TabItemSpotTV_Books
            '
            'DataGridViewSpotTV_DayTimes
            '
            Me.DataGridViewSpotTV_DayTimes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_DayTimes.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_DayTimes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewSpotTV_DayTimes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_DayTimes.ItemDescription = "Day Time(s)"
            Me.DataGridViewSpotTV_DayTimes.Location = New System.Drawing.Point(1, 287)
            Me.DataGridViewSpotTV_DayTimes.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_DayTimes.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_DayTimes.MultiSelect = True
            Me.DataGridViewSpotTV_DayTimes.Name = "DataGridViewSpotTV_DayTimes"
            Me.DataGridViewSpotTV_DayTimes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_DayTimes.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_DayTimes.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_DayTimes.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_DayTimes.Size = New System.Drawing.Size(823, 256)
            Me.DataGridViewSpotTV_DayTimes.TabIndex = 14
            Me.DataGridViewSpotTV_DayTimes.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_DayTimes.ViewCaptionHeight = -1
            '
            'ExpandableSplitterSpotTVDaysTimes
            '
            Me.ExpandableSplitterSpotTVDaysTimes.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVDaysTimes.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterSpotTVDaysTimes.Cursor = System.Windows.Forms.Cursors.HSplit
            Me.ExpandableSplitterSpotTVDaysTimes.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterSpotTVDaysTimes.ExpandableControl = Me.ShareHPUTBookControl_Books
            Me.ExpandableSplitterSpotTVDaysTimes.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVDaysTimes.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVDaysTimes.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterSpotTVDaysTimes.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVDaysTimes.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSpotTVDaysTimes.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterSpotTVDaysTimes.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterSpotTVDaysTimes.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVDaysTimes.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterSpotTVDaysTimes.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterSpotTVDaysTimes.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterSpotTVDaysTimes.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterSpotTVDaysTimes.Location = New System.Drawing.Point(1, 281)
            Me.ExpandableSplitterSpotTVDaysTimes.Name = "ExpandableSplitterSpotTVDaysTimes"
            Me.ExpandableSplitterSpotTVDaysTimes.Size = New System.Drawing.Size(823, 6)
            Me.ExpandableSplitterSpotTVDaysTimes.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterSpotTVDaysTimes.TabIndex = 13
            Me.ExpandableSplitterSpotTVDaysTimes.TabStop = False
            '
            'ShareHPUTBookControl_Books
            '
            Me.ShareHPUTBookControl_Books.Dock = System.Windows.Forms.DockStyle.Top
            Me.ShareHPUTBookControl_Books.Location = New System.Drawing.Point(1, 1)
            Me.ShareHPUTBookControl_Books.Name = "ShareHPUTBookControl_Books"
            Me.ShareHPUTBookControl_Books.Size = New System.Drawing.Size(823, 280)
            Me.ShareHPUTBookControl_Books.TabIndex = 0
            '
            'TabItemSpotTV_Books
            '
            Me.TabItemSpotTV_Books.AttachedControl = Me.TabControlPanelSpotTVBooks_Criteria
            Me.TabItemSpotTV_Books.Name = "TabItemSpotTV_Books"
            Me.TabItemSpotTV_Books.Text = "Books/Days/Times"
            '
            'TabControlPanelSpotTVResults_Results
            '
            Me.TabControlPanelSpotTVResults_Results.Controls.Add(Me.TabControlResults_TVResults)
            Me.TabControlPanelSpotTVResults_Results.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTVResults_Results.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTVResults_Results.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTVResults_Results.Name = "TabControlPanelSpotTVResults_Results"
            Me.TabControlPanelSpotTVResults_Results.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTVResults_Results.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotTVResults_Results.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTVResults_Results.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTVResults_Results.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTVResults_Results.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTVResults_Results.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTVResults_Results.Style.GradientAngle = 90
            Me.TabControlPanelSpotTVResults_Results.TabIndex = 34
            Me.TabControlPanelSpotTVResults_Results.TabItem = Me.TabItemSpotTV_Results
            '
            'TabControlResults_TVResults
            '
            Me.TabControlResults_TVResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlResults_TVResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlResults_TVResults.CanReorderTabs = False
            Me.TabControlResults_TVResults.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlResults_TVResults.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlResults_TVResults.Controls.Add(Me.TabControlPanelTVDataTab_TVData)
            Me.TabControlResults_TVResults.Controls.Add(Me.TabControlPanelTVDashboardTab_TVDashboard)
            Me.TabControlResults_TVResults.ForeColor = System.Drawing.Color.Black
            Me.TabControlResults_TVResults.Location = New System.Drawing.Point(4, 4)
            Me.TabControlResults_TVResults.Name = "TabControlResults_TVResults"
            Me.TabControlResults_TVResults.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlResults_TVResults.SelectedTabIndex = 0
            Me.TabControlResults_TVResults.Size = New System.Drawing.Size(817, 536)
            Me.TabControlResults_TVResults.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlResults_TVResults.TabIndex = 3
            Me.TabControlResults_TVResults.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlResults_TVResults.Tabs.Add(Me.TabItemTVResults_TVDataTab)
            Me.TabControlResults_TVResults.Tabs.Add(Me.TabItemTVResults_TVDashboardTab)
            Me.TabControlResults_TVResults.TabStop = False
            '
            'TabControlPanelTVDataTab_TVData
            '
            Me.TabControlPanelTVDataTab_TVData.Controls.Add(Me.LabelSpotTVResults_Footer)
            Me.TabControlPanelTVDataTab_TVData.Controls.Add(Me.BandedDataGridViewSpotTVResults)
            Me.TabControlPanelTVDataTab_TVData.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTVDataTab_TVData.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTVDataTab_TVData.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTVDataTab_TVData.Name = "TabControlPanelTVDataTab_TVData"
            Me.TabControlPanelTVDataTab_TVData.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTVDataTab_TVData.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelTVDataTab_TVData.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTVDataTab_TVData.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTVDataTab_TVData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTVDataTab_TVData.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTVDataTab_TVData.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTVDataTab_TVData.Style.GradientAngle = 90
            Me.TabControlPanelTVDataTab_TVData.TabIndex = 10
            Me.TabControlPanelTVDataTab_TVData.TabItem = Me.TabItemTVResults_TVDataTab
            '
            'LabelSpotTVResults_Footer
            '
            Me.LabelSpotTVResults_Footer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSpotTVResults_Footer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSpotTVResults_Footer.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.LabelSpotTVResults_Footer.Location = New System.Drawing.Point(1, 444)
            Me.LabelSpotTVResults_Footer.Name = "LabelSpotTVResults_Footer"
            Me.LabelSpotTVResults_Footer.Size = New System.Drawing.Size(815, 64)
            Me.LabelSpotTVResults_Footer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSpotTVResults_Footer.TabIndex = 6
            Me.LabelSpotTVResults_Footer.WordWrap = True
            '
            'BandedDataGridViewSpotTVResults
            '
            Me.BandedDataGridViewSpotTVResults.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewSpotTVResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewSpotTVResults.AutoUpdateViewCaption = True
            Me.BandedDataGridViewSpotTVResults.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewSpotTVResults.ItemDescription = "Item(s)"
            Me.BandedDataGridViewSpotTVResults.Location = New System.Drawing.Point(4, 4)
            Me.BandedDataGridViewSpotTVResults.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewSpotTVResults.ModifyGridRowHeight = False
            Me.BandedDataGridViewSpotTVResults.MultiSelect = True
            Me.BandedDataGridViewSpotTVResults.Name = "BandedDataGridViewSpotTVResults"
            Me.BandedDataGridViewSpotTVResults.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewSpotTVResults.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewSpotTVResults.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewSpotTVResults.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewSpotTVResults.Size = New System.Drawing.Size(808, 434)
            Me.BandedDataGridViewSpotTVResults.TabIndex = 0
            Me.BandedDataGridViewSpotTVResults.UseEmbeddedNavigator = False
            Me.BandedDataGridViewSpotTVResults.ViewCaptionHeight = -1
            '
            'TabItemTVResults_TVDataTab
            '
            Me.TabItemTVResults_TVDataTab.AttachedControl = Me.TabControlPanelTVDataTab_TVData
            Me.TabItemTVResults_TVDataTab.Name = "TabItemTVResults_TVDataTab"
            Me.TabItemTVResults_TVDataTab.Text = "Data"
            '
            'TabControlPanelTVDashboardTab_TVDashboard
            '
            Me.TabControlPanelTVDashboardTab_TVDashboard.Controls.Add(Me.DashboardViewerTVDashboard_Dashboard)
            Me.TabControlPanelTVDashboardTab_TVDashboard.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTVDashboardTab_TVDashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTVDashboardTab_TVDashboard.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTVDashboardTab_TVDashboard.Name = "TabControlPanelTVDashboardTab_TVDashboard"
            Me.TabControlPanelTVDashboardTab_TVDashboard.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTVDashboardTab_TVDashboard.Size = New System.Drawing.Size(817, 509)
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTVDashboardTab_TVDashboard.Style.GradientAngle = 90
            Me.TabControlPanelTVDashboardTab_TVDashboard.TabIndex = 11
            Me.TabControlPanelTVDashboardTab_TVDashboard.TabItem = Me.TabItemTVResults_TVDashboardTab
            '
            'DashboardViewerTVDashboard_Dashboard
            '
            Me.DashboardViewerTVDashboard_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DashboardViewerTVDashboard_Dashboard.Location = New System.Drawing.Point(1, 1)
            Me.DashboardViewerTVDashboard_Dashboard.Name = "DashboardViewerTVDashboard_Dashboard"
            Me.DashboardViewerTVDashboard_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerTVDashboard_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerTVDashboard_Dashboard.Size = New System.Drawing.Size(815, 507)
            Me.DashboardViewerTVDashboard_Dashboard.TabIndex = 2
            '
            'TabItemTVResults_TVDashboardTab
            '
            Me.TabItemTVResults_TVDashboardTab.AttachedControl = Me.TabControlPanelTVDashboardTab_TVDashboard
            Me.TabItemTVResults_TVDashboardTab.Name = "TabItemTVResults_TVDashboardTab"
            Me.TabItemTVResults_TVDashboardTab.Text = "Dashboard"
            '
            'TabItemSpotTV_Results
            '
            Me.TabItemSpotTV_Results.AttachedControl = Me.TabControlPanelSpotTVResults_Results
            Me.TabItemSpotTV_Results.Name = "TabItemSpotTV_Results"
            Me.TabItemSpotTV_Results.Text = "Results"
            '
            'TabControlPanelSpotTVMetrics_Criteria
            '
            Me.TabControlPanelSpotTVMetrics_Criteria.Controls.Add(Me.PanelSpotTVMetrics_Criteria)
            Me.TabControlPanelSpotTVMetrics_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTVMetrics_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTVMetrics_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTVMetrics_Criteria.Name = "TabControlPanelSpotTVMetrics_Criteria"
            Me.TabControlPanelSpotTVMetrics_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTVMetrics_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTVMetrics_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotTVMetrics_Criteria.TabIndex = 25
            Me.TabControlPanelSpotTVMetrics_Criteria.TabItem = Me.TabItemSpotTV_Metrics
            '
            'PanelSpotTVMetrics_Criteria
            '
            Me.PanelSpotTVMetrics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotTVMetrics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVMetrics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVMetrics_Criteria.Controls.Add(Me.PanelSpotTVMetrics_Right)
            Me.PanelSpotTVMetrics_Criteria.Controls.Add(Me.ExpandableSplitterControlSpotTVMetrics)
            Me.PanelSpotTVMetrics_Criteria.Controls.Add(Me.PanelSpotTVMetrics_Left)
            Me.PanelSpotTVMetrics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotTVMetrics_Criteria.Name = "PanelSpotTVMetrics_Criteria"
            Me.PanelSpotTVMetrics_Criteria.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotTVMetrics_Criteria.TabIndex = 8
            '
            'PanelSpotTVMetrics_Right
            '
            Me.PanelSpotTVMetrics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVMetrics_Right.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVMetrics_Right.Controls.Add(Me.DataGridViewSpotTV_SelectedMetrics)
            Me.PanelSpotTVMetrics_Right.Controls.Add(Me.ButtonSpotTVMetrics_AddToSelected)
            Me.PanelSpotTVMetrics_Right.Controls.Add(Me.ButtonSpotTVMetrics_RemoveFromSelected)
            Me.PanelSpotTVMetrics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotTVMetrics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelSpotTVMetrics_Right.Name = "PanelSpotTVMetrics_Right"
            Me.PanelSpotTVMetrics_Right.Size = New System.Drawing.Size(490, 532)
            Me.PanelSpotTVMetrics_Right.TabIndex = 1
            '
            'DataGridViewSpotTV_SelectedMetrics
            '
            Me.DataGridViewSpotTV_SelectedMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_SelectedMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_SelectedMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_SelectedMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_SelectedMetrics.ItemDescription = "Selected Metric(s)"
            Me.DataGridViewSpotTV_SelectedMetrics.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotTV_SelectedMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_SelectedMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_SelectedMetrics.MultiSelect = True
            Me.DataGridViewSpotTV_SelectedMetrics.Name = "DataGridViewSpotTV_SelectedMetrics"
            Me.DataGridViewSpotTV_SelectedMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_SelectedMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_SelectedMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_SelectedMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_SelectedMetrics.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotTV_SelectedMetrics.TabIndex = 2
            Me.DataGridViewSpotTV_SelectedMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_SelectedMetrics.ViewCaptionHeight = -1
            '
            'ButtonSpotTVMetrics_AddToSelected
            '
            Me.ButtonSpotTVMetrics_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVMetrics_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVMetrics_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotTVMetrics_AddToSelected.Name = "ButtonSpotTVMetrics_AddToSelected"
            Me.ButtonSpotTVMetrics_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotTVMetrics_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVMetrics_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVMetrics_AddToSelected.TabIndex = 0
            Me.ButtonSpotTVMetrics_AddToSelected.Text = ">"
            '
            'ButtonSpotTVMetrics_RemoveFromSelected
            '
            Me.ButtonSpotTVMetrics_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVMetrics_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVMetrics_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotTVMetrics_RemoveFromSelected.Name = "ButtonSpotTVMetrics_RemoveFromSelected"
            Me.ButtonSpotTVMetrics_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotTVMetrics_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVMetrics_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVMetrics_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotTVMetrics_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotTVMetrics
            '
            Me.ExpandableSplitterControlSpotTVMetrics.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVMetrics.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotTVMetrics.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVMetrics.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVMetrics.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotTVMetrics.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVMetrics.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTVMetrics.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotTVMetrics.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotTVMetrics.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVMetrics.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVMetrics.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVMetrics.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVMetrics.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTVMetrics.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotTVMetrics.Name = "ExpandableSplitterControlSpotTVMetrics"
            Me.ExpandableSplitterControlSpotTVMetrics.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotTVMetrics.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotTVMetrics.TabIndex = 20
            Me.ExpandableSplitterControlSpotTVMetrics.TabStop = False
            '
            'PanelSpotTVMetrics_Left
            '
            Me.PanelSpotTVMetrics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVMetrics_Left.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVMetrics_Left.Controls.Add(Me.DataGridViewSpotTV_AvailableMetrics)
            Me.PanelSpotTVMetrics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotTVMetrics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelSpotTVMetrics_Left.Name = "PanelSpotTVMetrics_Left"
            Me.PanelSpotTVMetrics_Left.Size = New System.Drawing.Size(317, 532)
            Me.PanelSpotTVMetrics_Left.TabIndex = 0
            '
            'DataGridViewSpotTV_AvailableMetrics
            '
            Me.DataGridViewSpotTV_AvailableMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_AvailableMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_AvailableMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_AvailableMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_AvailableMetrics.ItemDescription = "Available Metric(s)"
            Me.DataGridViewSpotTV_AvailableMetrics.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotTV_AvailableMetrics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_AvailableMetrics.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_AvailableMetrics.MultiSelect = True
            Me.DataGridViewSpotTV_AvailableMetrics.Name = "DataGridViewSpotTV_AvailableMetrics"
            Me.DataGridViewSpotTV_AvailableMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_AvailableMetrics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_AvailableMetrics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_AvailableMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_AvailableMetrics.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotTV_AvailableMetrics.TabIndex = 0
            Me.DataGridViewSpotTV_AvailableMetrics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_AvailableMetrics.ViewCaptionHeight = -1
            '
            'TabItemSpotTV_Metrics
            '
            Me.TabItemSpotTV_Metrics.AttachedControl = Me.TabControlPanelSpotTVMetrics_Criteria
            Me.TabItemSpotTV_Metrics.Name = "TabItemSpotTV_Metrics"
            Me.TabItemSpotTV_Metrics.Text = "Metrics"
            '
            'TabControlPanelSpotTVDemographics_Criteria
            '
            Me.TabControlPanelSpotTVDemographics_Criteria.Controls.Add(Me.PanelSpotTVDemographics_Criteria)
            Me.TabControlPanelSpotTVDemographics_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSpotTVDemographics_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSpotTVDemographics_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSpotTVDemographics_Criteria.Name = "TabControlPanelSpotTVDemographics_Criteria"
            Me.TabControlPanelSpotTVDemographics_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSpotTVDemographics_Criteria.Size = New System.Drawing.Size(825, 544)
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSpotTVDemographics_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelSpotTVDemographics_Criteria.TabIndex = 21
            Me.TabControlPanelSpotTVDemographics_Criteria.TabItem = Me.TabItemSpotTV_Demographics
            '
            'PanelSpotTVDemographics_Criteria
            '
            Me.PanelSpotTVDemographics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelSpotTVDemographics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVDemographics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVDemographics_Criteria.Controls.Add(Me.PanelSpotTVDemographics_Right)
            Me.PanelSpotTVDemographics_Criteria.Controls.Add(Me.ExpandableSplitterControlSpotTVDemographics)
            Me.PanelSpotTVDemographics_Criteria.Controls.Add(Me.PanelSpotTVDemographics_Left)
            Me.PanelSpotTVDemographics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelSpotTVDemographics_Criteria.Name = "PanelSpotTVDemographics_Criteria"
            Me.PanelSpotTVDemographics_Criteria.Size = New System.Drawing.Size(817, 536)
            Me.PanelSpotTVDemographics_Criteria.TabIndex = 7
            '
            'PanelSpotTVDemographics_Right
            '
            Me.PanelSpotTVDemographics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVDemographics_Right.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVDemographics_Right.Controls.Add(Me.DataGridViewSpotTV_SelectedDemographics)
            Me.PanelSpotTVDemographics_Right.Controls.Add(Me.ButtonSpotTVDemographics_AddToSelected)
            Me.PanelSpotTVDemographics_Right.Controls.Add(Me.ButtonSpotTVDemographics_RemoveFromSelected)
            Me.PanelSpotTVDemographics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSpotTVDemographics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelSpotTVDemographics_Right.Name = "PanelSpotTVDemographics_Right"
            Me.PanelSpotTVDemographics_Right.Size = New System.Drawing.Size(490, 532)
            Me.PanelSpotTVDemographics_Right.TabIndex = 1
            '
            'DataGridViewSpotTV_SelectedDemographics
            '
            Me.DataGridViewSpotTV_SelectedDemographics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_SelectedDemographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_SelectedDemographics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_SelectedDemographics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_SelectedDemographics.ItemDescription = "Selected Demographic(s)"
            Me.DataGridViewSpotTV_SelectedDemographics.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewSpotTV_SelectedDemographics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_SelectedDemographics.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_SelectedDemographics.MultiSelect = True
            Me.DataGridViewSpotTV_SelectedDemographics.Name = "DataGridViewSpotTV_SelectedDemographics"
            Me.DataGridViewSpotTV_SelectedDemographics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_SelectedDemographics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_SelectedDemographics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_SelectedDemographics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_SelectedDemographics.Size = New System.Drawing.Size(399, 522)
            Me.DataGridViewSpotTV_SelectedDemographics.TabIndex = 2
            Me.DataGridViewSpotTV_SelectedDemographics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_SelectedDemographics.ViewCaptionHeight = -1
            '
            'ButtonSpotTVDemographics_AddToSelected
            '
            Me.ButtonSpotTVDemographics_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVDemographics_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVDemographics_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonSpotTVDemographics_AddToSelected.Name = "ButtonSpotTVDemographics_AddToSelected"
            Me.ButtonSpotTVDemographics_AddToSelected.SecurityEnabled = True
            Me.ButtonSpotTVDemographics_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVDemographics_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVDemographics_AddToSelected.TabIndex = 0
            Me.ButtonSpotTVDemographics_AddToSelected.Text = ">"
            '
            'ButtonSpotTVDemographics_RemoveFromSelected
            '
            Me.ButtonSpotTVDemographics_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSpotTVDemographics_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSpotTVDemographics_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonSpotTVDemographics_RemoveFromSelected.Name = "ButtonSpotTVDemographics_RemoveFromSelected"
            Me.ButtonSpotTVDemographics_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonSpotTVDemographics_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSpotTVDemographics_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSpotTVDemographics_RemoveFromSelected.TabIndex = 1
            Me.ButtonSpotTVDemographics_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControlSpotTVDemographics
            '
            Me.ExpandableSplitterControlSpotTVDemographics.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVDemographics.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotTVDemographics.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVDemographics.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVDemographics.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotTVDemographics.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVDemographics.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTVDemographics.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotTVDemographics.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotTVDemographics.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVDemographics.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTVDemographics.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTVDemographics.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTVDemographics.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTVDemographics.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControlSpotTVDemographics.Name = "ExpandableSplitterControlSpotTVDemographics"
            Me.ExpandableSplitterControlSpotTVDemographics.Size = New System.Drawing.Size(6, 532)
            Me.ExpandableSplitterControlSpotTVDemographics.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotTVDemographics.TabIndex = 20
            Me.ExpandableSplitterControlSpotTVDemographics.TabStop = False
            '
            'PanelSpotTVDemographics_Left
            '
            Me.PanelSpotTVDemographics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSpotTVDemographics_Left.Appearance.Options.UseBackColor = True
            Me.PanelSpotTVDemographics_Left.Controls.Add(Me.DataGridViewSpotTV_AvailableDemographics)
            Me.PanelSpotTVDemographics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotTVDemographics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelSpotTVDemographics_Left.Name = "PanelSpotTVDemographics_Left"
            Me.PanelSpotTVDemographics_Left.Size = New System.Drawing.Size(317, 532)
            Me.PanelSpotTVDemographics_Left.TabIndex = 0
            '
            'DataGridViewSpotTV_AvailableDemographics
            '
            Me.DataGridViewSpotTV_AvailableDemographics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_AvailableDemographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_AvailableDemographics.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_AvailableDemographics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_AvailableDemographics.ItemDescription = "Available Demographic(s)"
            Me.DataGridViewSpotTV_AvailableDemographics.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewSpotTV_AvailableDemographics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_AvailableDemographics.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_AvailableDemographics.MultiSelect = True
            Me.DataGridViewSpotTV_AvailableDemographics.Name = "DataGridViewSpotTV_AvailableDemographics"
            Me.DataGridViewSpotTV_AvailableDemographics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_AvailableDemographics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_AvailableDemographics.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_AvailableDemographics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_AvailableDemographics.Size = New System.Drawing.Size(306, 522)
            Me.DataGridViewSpotTV_AvailableDemographics.TabIndex = 0
            Me.DataGridViewSpotTV_AvailableDemographics.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_AvailableDemographics.ViewCaptionHeight = -1
            '
            'TabItemSpotTV_Demographics
            '
            Me.TabItemSpotTV_Demographics.AttachedControl = Me.TabControlPanelSpotTVDemographics_Criteria
            Me.TabItemSpotTV_Demographics.Name = "TabItemSpotTV_Demographics"
            Me.TabItemSpotTV_Demographics.Text = "Demographics"
            '
            'ExpandableSplitterControlSpotTV_LeftRight
            '
            Me.ExpandableSplitterControlSpotTV_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTV_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSpotTV_LeftRight.ExpandableControl = Me.PanelSpotTV_LeftSection
            Me.ExpandableSplitterControlSpotTV_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTV_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTV_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSpotTV_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTV_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSpotTV_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSpotTV_LeftRight.Location = New System.Drawing.Point(198, 1)
            Me.ExpandableSplitterControlSpotTV_LeftRight.Name = "ExpandableSplitterControlSpotTV_LeftRight"
            Me.ExpandableSplitterControlSpotTV_LeftRight.Size = New System.Drawing.Size(6, 595)
            Me.ExpandableSplitterControlSpotTV_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSpotTV_LeftRight.TabIndex = 12
            Me.ExpandableSplitterControlSpotTV_LeftRight.TabStop = False
            '
            'PanelSpotTV_LeftSection
            '
            Me.PanelSpotTV_LeftSection.Controls.Add(Me.DataGridViewSpotTV_UserCriterias)
            Me.PanelSpotTV_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSpotTV_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelSpotTV_LeftSection.Name = "PanelSpotTV_LeftSection"
            Me.PanelSpotTV_LeftSection.Size = New System.Drawing.Size(197, 595)
            Me.PanelSpotTV_LeftSection.TabIndex = 11
            '
            'DataGridViewSpotTV_UserCriterias
            '
            Me.DataGridViewSpotTV_UserCriterias.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSpotTV_UserCriterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSpotTV_UserCriterias.AutoUpdateViewCaption = True
            Me.DataGridViewSpotTV_UserCriterias.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSpotTV_UserCriterias.ItemDescription = "Report(s)"
            Me.DataGridViewSpotTV_UserCriterias.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewSpotTV_UserCriterias.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSpotTV_UserCriterias.ModifyGridRowHeight = False
            Me.DataGridViewSpotTV_UserCriterias.MultiSelect = False
            Me.DataGridViewSpotTV_UserCriterias.Name = "DataGridViewSpotTV_UserCriterias"
            Me.DataGridViewSpotTV_UserCriterias.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSpotTV_UserCriterias.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSpotTV_UserCriterias.ShowRowSelectionIfHidden = True
            Me.DataGridViewSpotTV_UserCriterias.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSpotTV_UserCriterias.Size = New System.Drawing.Size(180, 571)
            Me.DataGridViewSpotTV_UserCriterias.TabIndex = 0
            Me.DataGridViewSpotTV_UserCriterias.UseEmbeddedNavigator = False
            Me.DataGridViewSpotTV_UserCriterias.ViewCaptionHeight = -1
            '
            'TabItemTabs_SpotTVTab
            '
            Me.TabItemTabs_SpotTVTab.AttachedControl = Me.TabControlPanelSpotTV_SpotTV
            Me.TabItemTabs_SpotTVTab.Name = "TabItemTabs_SpotTVTab"
            Me.TabItemTabs_SpotTVTab.Text = "Spot TV"
            '
            'BroadcastResearchToolForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1054, 624)
            Me.Controls.Add(Me.TabControlForm_Tabs)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BroadcastResearchToolForm"
            Me.Text = "Broadcast Research Tool"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Tabs.ResumeLayout(False)
            Me.TabControlPanelNational_National.ResumeLayout(False)
            CType(Me.PanelNational_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNational_RightSection.ResumeLayout(False)
            CType(Me.TabControlNational_ResearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlNational_ResearchCriteria.ResumeLayout(False)
            Me.TabControlPanelNationalReportType.ResumeLayout(False)
            CType(Me.GroupBoxNational_TimeType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNational_TimeType.ResumeLayout(False)
            CType(Me.PanelNationalReportType_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalReportType_Bottom.ResumeLayout(False)
            CType(Me.PanelNationalNetworks_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalNetworks_RightSection.ResumeLayout(False)
            CType(Me.PanelNationalNetworks_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalNetworks_LeftSection.ResumeLayout(False)
            CType(Me.GroupBoxNational_Ethnicity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNational_Ethnicity.ResumeLayout(False)
            Me.TabControlPanelNationalDates.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Corrections, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Corrections.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Premieres, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Premieres.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Repeats, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Repeats.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Overnights, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Overnights.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Specials, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Specials.ResumeLayout(False)
            CType(Me.GroupBoxNationalDates_Breakouts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNationalDates_Breakouts.ResumeLayout(False)
            CType(Me.GroupBoxNational_DateCodeDates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNational_DateCodeDates.ResumeLayout(False)
            CType(Me.DateEditNationalDates_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditNationalDates_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditNationalDates_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditNationalDates_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelNationalResults.ResumeLayout(False)
            CType(Me.TabControlResults_NationalResults, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlResults_NationalResults.ResumeLayout(False)
            Me.TabControlPanelNational_ResultsData.ResumeLayout(False)
            Me.TabControlPanelNational_ResultsDashboard.ResumeLayout(False)
            CType(Me.DashboardViewerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelNationalDemographics.ResumeLayout(False)
            CType(Me.PanelNationalDemographics, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalDemographics.ResumeLayout(False)
            CType(Me.PanelNationalDemographics_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalDemographics_RightSection.ResumeLayout(False)
            CType(Me.PanelNationalDemographics_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalDemographics_LeftSection.ResumeLayout(False)
            Me.TabControlPanelNationalMetrics.ResumeLayout(False)
            CType(Me.PanelNationalMetrics, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalMetrics.ResumeLayout(False)
            CType(Me.PanelNationalMetrics_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalMetrics_RightSection.ResumeLayout(False)
            CType(Me.PanelNationalMetrics_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNationalMetrics_LeftSection.ResumeLayout(False)
            CType(Me.PanelNational_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelNational_LeftSection.ResumeLayout(False)
            Me.TabControlPanelSpotRadioCounty_SpotRadioCounty.ResumeLayout(False)
            CType(Me.PanelSpotRadioCounty_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCounty_RightSection.ResumeLayout(False)
            CType(Me.TabControlSpotRadioCounty_ResearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlSpotRadioCounty_ResearchCriteria.ResumeLayout(False)
            Me.TabControlPanelCountyMarket.ResumeLayout(False)
            CType(Me.GroupBoxSpotRadioCounty_Dayparts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotRadioCounty_Dayparts.ResumeLayout(False)
            CType(Me.NumericInputCounty_MaxRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCounty_Demographic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCounty_County.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCountyResults.ResumeLayout(False)
            CType(Me.TabControlResults_RadioCountyResults, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlResults_RadioCountyResults.ResumeLayout(False)
            Me.TabControlPanelCountyData.ResumeLayout(False)
            Me.TabControlPanelCountyDashboard.ResumeLayout(False)
            CType(Me.DashboardViewerRadioCountyDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCountyStations.ResumeLayout(False)
            CType(Me.PanelSpotRadioCountyStation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCountyStation.ResumeLayout(False)
            CType(Me.PanelBottomSpotRadioCountyStation_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotRadioCountyStation_RightSection.ResumeLayout(False)
            CType(Me.PanelBottomSpotRadioCountyStation_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotRadioCountyStation_LeftSection.ResumeLayout(False)
            Me.TabControlPanelCountyMetrics.ResumeLayout(False)
            CType(Me.PanelSpotRadioCountyMetrics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCountyMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotRadioCountyMetrics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCountyMetrics_Right.ResumeLayout(False)
            CType(Me.PanelSpotRadioCountyMetrics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCountyMetrics_Left.ResumeLayout(False)
            CType(Me.PanelSpotRadioCounty_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioCounty_LeftSection.ResumeLayout(False)
            Me.TabControlPanelSpotRadio_SpotRadio.ResumeLayout(False)
            CType(Me.PanelSpotRadio_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadio_RightSection.ResumeLayout(False)
            CType(Me.TabControlSpotRadio_ResearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlSpotRadio_ResearchCriteria.ResumeLayout(False)
            Me.TabControlPanelSpotRadioMarket_Criteria.ResumeLayout(False)
            CType(Me.NumericInputSpotRadioMarket_MaxRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxSpotRadioMarket_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotRadioMarket_Options.ResumeLayout(False)
            CType(Me.GroupBoxSpotRadioMarket_Ethnicity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotRadioMarket_Ethnicity.ResumeLayout(False)
            CType(Me.SearchableComboBoxSpotRadioMarket_Qualitative.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotRadioMarket_Demographic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotRadio_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotRadioViewControl_Market, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSpotRadioResults_Results.ResumeLayout(False)
            CType(Me.TabControlResults_RadioResults, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlResults_RadioResults.ResumeLayout(False)
            Me.TabControlPanelRadioDataTab_RadioData.ResumeLayout(False)
            Me.TabControlPanelRadioDashboardTab_RadioDashboard.ResumeLayout(False)
            CType(Me.DashboardViewerRadioDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSpotRadioGeographyDayparts_Criteria.ResumeLayout(False)
            CType(Me.GroupBoxSpotRadioMarket_ListeningType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotRadioMarket_ListeningType.ResumeLayout(False)
            CType(Me.GroupBoxSpotRadioMarket_Geography, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotRadioMarket_Geography.ResumeLayout(False)
            Me.TabControlPanelSpotRadioMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotRadioMetrics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotRadioMetrics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioMetrics_Right.ResumeLayout(False)
            CType(Me.PanelSpotRadioMetrics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioMetrics_Left.ResumeLayout(False)
            Me.TabControlPanelSpotRadioStations_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotRadioMarketStation_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadioMarketStation_Bottom.ResumeLayout(False)
            CType(Me.PanelBottomSpotRadioStation_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotRadioStation_RightSection.ResumeLayout(False)
            CType(Me.PanelBottomSpotRadioStation_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotRadioStation_LeftSection.ResumeLayout(False)
            CType(Me.PanelSpotRadio_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotRadio_LeftSection.ResumeLayout(False)
            Me.TabControlPanelSpotTV_SpotTV.ResumeLayout(False)
            CType(Me.PanelSpotTV_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTV_RightSection.ResumeLayout(False)
            CType(Me.TabControlSpotTV_ResearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlSpotTV_ResearchCriteria.ResumeLayout(False)
            Me.TabControlPanelSpotTVMarketStations_Criteria.ResumeLayout(False)
            CType(Me.NumericInputSpotTVMarketStation_MaximumRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelSpotTVMarketStation_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVMarketStation_Bottom.ResumeLayout(False)
            CType(Me.PanelBottomSpotTVMarketStation_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotTVMarketStation_RightSection.ResumeLayout(False)
            CType(Me.PanelBottomSpotTVMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomSpotTVMarketStation_LeftSection.ResumeLayout(False)
            CType(Me.GroupBoxSpotTVMarketStation_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSpotTVMarketStation_Options.ResumeLayout(False)
            CType(Me.SearchableComboBoxSpotTVMarketStation_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSpotTVViewControl_Market, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSpotTVBooks_Criteria.ResumeLayout(False)
            Me.TabControlPanelSpotTVResults_Results.ResumeLayout(False)
            CType(Me.TabControlResults_TVResults, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlResults_TVResults.ResumeLayout(False)
            Me.TabControlPanelTVDataTab_TVData.ResumeLayout(False)
            Me.TabControlPanelTVDashboardTab_TVDashboard.ResumeLayout(False)
            CType(Me.DashboardViewerTVDashboard_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSpotTVMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotTVMetrics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotTVMetrics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVMetrics_Right.ResumeLayout(False)
            CType(Me.PanelSpotTVMetrics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVMetrics_Left.ResumeLayout(False)
            Me.TabControlPanelSpotTVDemographics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotTVDemographics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVDemographics_Criteria.ResumeLayout(False)
            CType(Me.PanelSpotTVDemographics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVDemographics_Right.ResumeLayout(False)
            CType(Me.PanelSpotTVDemographics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTVDemographics_Left.ResumeLayout(False)
            CType(Me.PanelSpotTV_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSpotTV_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Metrics As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMetrics_Up As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMetrics_Down As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Demographics As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDemographics_Up As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDemographics_Down As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_Tabs As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSpotTV_SpotTV As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotTV_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlSpotTV_ResearchCriteria As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSpotTVMarketStations_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ComboBoxSpotTVMarketStation_ReportType As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents PanelSpotTVMarketStation_Bottom As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBottomSpotTVMarketStation_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_SelectedStations As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotTVStation_AddToSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotTVStation_RemoveFromSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterSpotTVMarketStations_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBottomSpotTVMarketStation_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_AvailableStations As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxSpotTVMarketStation_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxSpotTVOptions_DominantProgramming As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSpotTVOptions_ShowProgramName As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelSpotTVMarketStation_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelSpotTVMarketStation_ReportType As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSpotTVMarketStation_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxSpotTVViewControl_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents TabItemSpotTV_MarketStations As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotTVResults_Results As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BandedDataGridViewSpotTVResults As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents TabItemSpotTV_Results As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotTVBooks_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ShareHPUTBookControl_Books As AdvantageFramework.WinForm.MVC.Presentation.Controls.ShareHPUTBookControl
        Friend WithEvents TabItemSpotTV_Books As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotTVMetrics_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotTVMetrics_Criteria As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSpotTVMetrics_Right As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_SelectedMetrics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotTVMetrics_AddToSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotTVMetrics_RemoveFromSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotTVMetrics As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotTVMetrics_Left As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_AvailableMetrics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotTV_Metrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotTVDemographics_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotTVDemographics_Criteria As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSpotTVDemographics_Right As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_SelectedDemographics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotTVDemographics_AddToSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotTVDemographics_RemoveFromSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotTVDemographics As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotTVDemographics_Left As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_AvailableDemographics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotTV_Demographics As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterControlSpotTV_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotTV_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotTV_UserCriterias As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemTabs_SpotTVTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotRadio_SpotRadio As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_SpotRadioTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelSpotRadio_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadio_UserCriterias As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlSpotRadio_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotRadio_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlSpotRadio_ResearchCriteria As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSpotRadioMarket_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxSpotRadioMarket_Ethnicity As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonSpotRadioEthnicity_Hispanic As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioEthnicity_Black As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioEthnicity_All As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents SearchableComboBoxSpotRadioMarket_Qualitative As AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelSpotRadioMarket_Qualitative As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSpotRadioMarket_Demographic As AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelSpotRadioMarket_Demo As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelSpotRadioMarket_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSpotRadio_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxSpotRadioViewControl_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents TabItemSpotRadio_MarketBooks As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotRadioStations_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotRadioMarketStation_Bottom As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBottomSpotRadioStation_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadio_SelectedStations As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotRadioStation_AddToSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotRadioStation_RemoveFromSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotRadio_Stations As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBottomSpotRadioStation_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadio_AvailableStations As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotRadio_Stations As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotRadioMetrics_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotRadioMetrics_Criteria As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSpotRadioMetrics_Right As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadio_SelectedMetrics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotRadioMetrics_AddToSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotRadioMetrics_RemoveFromSelected As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotRadio_Metrics As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotRadioMetrics_Left As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadio_AvailableMetrics As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotRadio_Metrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotRadioGeographyDayparts_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSpotRadio_GeographyDayparts As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSpotRadioResults_Results As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BandedDataGridViewSpotRadioResults As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents TabItemSpotRadio_Results As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxSpotTVOptions_ShowSpill As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxSpotRadioMarket_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxSpotRadioOptions_ShowSpill As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ExpandableSplitterSpotTVDaysTimes As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents DataGridViewSpotTV_DayTimes As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewSpotRadio_Dayparts As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxSpotRadioOptions_ShowFormat As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSpotRadioOptions_TotalListening As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelSpotRadioMarket_ReportType As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxSpotRadioMarketDemographic_ReportType As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelSpotRadio_DaypartNote As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxSpotRadioOptions_ShowFrequency As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxSpotRadioMarket_Geography As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonSpotRadioGeography_DMA As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioGeography_TSA As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioGeography_Metro As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxSpotRadioMarket_ListeningType As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonSpotRadioListeningType_OutOfHome As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioListeningType_Car As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioListeningType_Work As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioListeningType_Home As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSpotRadioListeningType_Total As AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewSpotRadio_Books As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DashboardViewerTVDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlResults_TVResults As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelTVDataTab_TVData As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTVResults_TVDataTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTVDashboardTab_TVDashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTVResults_TVDashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlResults_RadioResults As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelRadioDashboardTab_RadioDashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerRadioDashboard_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemRadioResults_RadioDashboardTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRadioDataTab_RadioData As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRadioResults_RadioDataTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarOptions_ReportView As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReportView_ByAge As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReportView_ByGender As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReportView_ByAgeGender As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelSpotRadioResults_Footer As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonItemReportView_ByGenderAge As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelSpotTVResults_Footer As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelSpotRadioMarket_Source As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxSpotRadioMarket_Source As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelSpotTVMarketStation_MaximumRank As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputSpotTVMarketStation_MaximumRank As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelSpotRadioMarket_MaxRank As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputSpotRadioMarket_MaxRank As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelSpotTVMarketStation_Source As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxSpotTVMarketStation_Source As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents TabControlPanelSpotRadioCounty_SpotRadioCounty As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_SpotRadioCountyTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelSpotRadioCounty_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlSpotRadioCounty_ResearchCriteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelCountyMarket As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelCounty_MaxRank As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputCounty_MaxRank As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxCounty_ReportType As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelCounty_ReportType As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxCounty_ShowFrequency As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxCounty_Demographic As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelCounty_Demographic As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelCounty_Market As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxCounty_County As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents TabItemSpotRadioCounty_MarketBooks As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCountyResults As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlResults_RadioCountyResults As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelCountyData As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BandedDataGridViewSpotRadioCountyResults As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents TabItemRadioCountyResults_RadioCountyDataTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCountyDashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerRadioCountyDashboard_Dashboard As WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemCountyResults_Dashboard As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemSpotRadioCounty_Results As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCountyMetrics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotRadioCountyMetrics_Criteria As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelSpotRadioCountyMetrics_Right As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadioCounty_SelectedMetrics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotRadioCountyMetrics_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotRadioCountyMetrics_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotRadioCounty_Metrics As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotRadioCountyMetrics_Left As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadioCounty_AvailableMetrics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotRadioCounty_Metrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCountyStations As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelSpotRadioCountyStation As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBottomSpotRadioCountyStation_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadioCounty_SelectedStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSpotRadioCountyStation_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonSpotRadioCountyStation_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControlSpotRadioCounty_Stations As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBottomSpotRadioCountyStation_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadioCounty_AvailableStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemSpotRadioCounty_Stations As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterControlSpotRadioCounty_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSpotRadioCounty_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewSpotRadioCounty_UserCriterias As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxSpotRadioCounty_Dayparts As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxCountyDaypart84 As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCountyDaypart68 As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewSpotRadioCounty_Years As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxSpotTVOptions_GroupByDaysTimes As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_Books As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelNational_National As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_NationalTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelNational_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_UserCriterias As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelNational_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlNational_ResearchCriteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelNationalReportType As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemNational_ReportType As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNationalResults As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlResults_NationalResults As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelNational_ResultsData As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BandedDataGridViewNationalResults As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents TabItemNationalResults_Data As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNational_ResultsDashboard As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DashboardViewerControl1 As WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents TabItemNationalResults_Dashboard As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemNational_Results As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNationalDates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemNational_Dates As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNationalDemographics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelNationalDemographics As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelNationalDemographics_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_DemographicsSelected As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonNationalDemographics_AddSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonNationalDemographics_RemoveSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl3 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelNationalDemographics_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_DemographicsAvailable As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemNational_Demographics As DevComponents.DotNetBar.TabItem
        Friend WithEvents ExpandableSplitterControl1 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents TabControlPanelNationalMetrics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemNational_Metrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxNational_ReportType As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents Label As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents PanelNationalReportType_Bottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelNationalNetworks_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_NetworksSelected As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonNationalNetworks_AddSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonNationalNetworks_RemoveSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl4 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelNationalNetworks_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_NetworksAvailable As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxNational_Ethnicity As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalEthnicity_Hispanic As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalEthnicity_GeneralMarket As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNationalDates_StartDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxNationalDates_Breakouts As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalBreakout_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalBreakout_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNational_DateCodeDates As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationDates_Dates As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationDates_DateCode As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNationalDates_Days As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNationalDates_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelNationalDates_EndDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents RadioButtonNationalBreakout_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNationalDates_Overnights As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalOvernights_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalOvernights_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalOvernights_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNationalDates_Specials As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalSpecials_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalSpecials_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalSpecials_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNationalDates_Corrections As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalCorrections_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalCorrections_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalCorrections_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNationalDates_Premieres As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalPremieres_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalPremieres_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalPremieres_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxNationalDates_Repeats As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalRepeats_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalRepeats_Only As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalRepeats_Ignore As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelNationalMetrics As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelNationalMetrics_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_MetricsSelected As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonNationalMetrics_AddSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonNationalMetrics_RemoveSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl5 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelNationalMetrics_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewNational_MetricsAvailable As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxNational_TimeType As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonNationalTimeType_Commercial As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNationalTimeType_Program As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxNationalDates_Days As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxNationalDates_EndTime As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelNationalDates_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxNationalDates_StartTime As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxNationalDates_Stream As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelNationalDates_Stream As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DateEditNationalDates_StartDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents DateEditNationalDates_EndDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents CheckBoxNationalDates_ShowAirings As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNationalDates_ShowProgramTypes As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace