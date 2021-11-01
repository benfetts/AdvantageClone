Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SpotRadioResearchForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpotRadioResearchForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Metrics = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMetrics_Up = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMetrics_Down = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_DayTimes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDayTimes_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDayTimes_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Books = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemBooks_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemBooks_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Process = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_ResearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDaysTimes_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDayparts_Dayparts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemResearchCriteria_DaysTimes = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMarket_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMarket_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxInclude_TotalListening = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_ERadio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_OTAIS = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_XCodes = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_Networks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_Simulcast = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInclude_Stations = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMarket_Ethnicity = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonEthnicity_IAS = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonEthnicity_Hispanic = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonEthnicity_Black = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonEthnicity_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxMarket_ListeningType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonListeningType_OOH = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonListeningType_Car = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonListeningType_Work = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonListeningType_Home = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonListeningType_Total = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SearchableComboBoxMarket_Qualitative = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelMarket_Qualitative = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxMarket_Demographic = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelMarket_Demo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxMarket_Geography = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonGeography_DMA = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGeography_TSA = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGeography_Metro = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxMarket_OutputType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonOutput_AudienceComp = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOutput_Trend = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOutput_Ranker = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelMarket_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxMarket_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.TabItemResearchCriteria_Market = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelStations_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelMarketStation_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelBottomMarketStation_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_SelectedStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonRightSectionStation_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonRightSectionStation_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelBottomMarketStation_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableStations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemResearchCriteria_Stations = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelFormats_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelDemographics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelDemographics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_SelectedFormats = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonRightSectionFormats_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonRightSectionFormats_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelDemographics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableFormats = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemResearchCriteria_Formats = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMetrics_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelMetrics_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelMetrics_Right = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_SelectedMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonRightSectionMetrics_AddToSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonRightSectionMetrics_RemoveFromSelected = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ExpandableSplitterControl2 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelMetrics_Left = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableMetrics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemResearchCriteria_Metrics = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBooks_Criteria = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewBooks_Books = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemResearchCriteria_Books = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelResults_Results = New DevComponents.DotNetBar.TabControlPanel()
            Me.BandedDataGridViewResults = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.TabItemResearchCriteria_Results = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_UserCriterias = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_ResearchCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ResearchCriteria.SuspendLayout()
            Me.TabControlPanelDaysTimes_Criteria.SuspendLayout()
            Me.TabControlPanelMarket_Criteria.SuspendLayout()
            CType(Me.GroupBoxMarket_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMarket_Include.SuspendLayout()
            CType(Me.GroupBoxMarket_Ethnicity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMarket_Ethnicity.SuspendLayout()
            CType(Me.GroupBoxMarket_ListeningType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMarket_ListeningType.SuspendLayout()
            CType(Me.SearchableComboBoxMarket_Qualitative.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMarket_Demographic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMarket_Geography, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMarket_Geography.SuspendLayout()
            CType(Me.GroupBoxMarket_OutputType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMarket_OutputType.SuspendLayout()
            CType(Me.SearchableComboBoxMarket_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_Market, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelStations_Criteria.SuspendLayout()
            CType(Me.PanelMarketStation_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMarketStation_Bottom.SuspendLayout()
            CType(Me.PanelBottomMarketStation_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomMarketStation_RightSection.SuspendLayout()
            CType(Me.PanelBottomMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBottomMarketStation_LeftSection.SuspendLayout()
            Me.TabControlPanelFormats_Criteria.SuspendLayout()
            CType(Me.PanelDemographics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDemographics_Criteria.SuspendLayout()
            CType(Me.PanelDemographics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDemographics_Right.SuspendLayout()
            CType(Me.PanelDemographics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDemographics_Left.SuspendLayout()
            Me.TabControlPanelMetrics_Criteria.SuspendLayout()
            CType(Me.PanelMetrics_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMetrics_Criteria.SuspendLayout()
            CType(Me.PanelMetrics_Right, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMetrics_Right.SuspendLayout()
            CType(Me.PanelMetrics_Left, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMetrics_Left.SuspendLayout()
            Me.TabControlPanelBooks_Criteria.SuspendLayout()
            Me.TabControlPanelResults_Results.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Metrics)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_DayTimes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Books)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(308, 4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(677, 98)
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
            Me.RibbonBarOptions_Metrics.Location = New System.Drawing.Point(429, 0)
            Me.RibbonBarOptions_Metrics.Name = "RibbonBarOptions_Metrics"
            Me.RibbonBarOptions_Metrics.SecurityEnabled = True
            Me.RibbonBarOptions_Metrics.Size = New System.Drawing.Size(84, 98)
            Me.RibbonBarOptions_Metrics.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Metrics.TabIndex = 5
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
            'RibbonBarOptions_DayTimes
            '
            Me.RibbonBarOptions_DayTimes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DayTimes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DayTimes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DayTimes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DayTimes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DayTimes.DragDropSupport = True
            Me.RibbonBarOptions_DayTimes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDayTimes_Cancel, Me.ButtonItemDayTimes_Delete})
            Me.RibbonBarOptions_DayTimes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DayTimes.Location = New System.Drawing.Point(321, 0)
            Me.RibbonBarOptions_DayTimes.Name = "RibbonBarOptions_DayTimes"
            Me.RibbonBarOptions_DayTimes.SecurityEnabled = True
            Me.RibbonBarOptions_DayTimes.Size = New System.Drawing.Size(108, 98)
            Me.RibbonBarOptions_DayTimes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DayTimes.TabIndex = 4
            Me.RibbonBarOptions_DayTimes.Text = "Day/Times"
            '
            '
            '
            Me.RibbonBarOptions_DayTimes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DayTimes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DayTimes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDayTimes_Cancel
            '
            Me.ButtonItemDayTimes_Cancel.BeginGroup = True
            Me.ButtonItemDayTimes_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDayTimes_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDayTimes_Cancel.Name = "ButtonItemDayTimes_Cancel"
            Me.ButtonItemDayTimes_Cancel.SecurityEnabled = True
            Me.ButtonItemDayTimes_Cancel.Stretch = True
            Me.ButtonItemDayTimes_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDayTimes_Cancel.Text = "Cancel"
            '
            'ButtonItemDayTimes_Delete
            '
            Me.ButtonItemDayTimes_Delete.BeginGroup = True
            Me.ButtonItemDayTimes_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDayTimes_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDayTimes_Delete.Name = "ButtonItemDayTimes_Delete"
            Me.ButtonItemDayTimes_Delete.SecurityEnabled = True
            Me.ButtonItemDayTimes_Delete.Stretch = True
            Me.ButtonItemDayTimes_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDayTimes_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Books
            '
            Me.RibbonBarOptions_Books.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Books.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Books.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Books.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Books.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Books.DragDropSupport = True
            Me.RibbonBarOptions_Books.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemBooks_Cancel, Me.ButtonItemBooks_Delete})
            Me.RibbonBarOptions_Books.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Books.Location = New System.Drawing.Point(219, 0)
            Me.RibbonBarOptions_Books.Name = "RibbonBarOptions_Books"
            Me.RibbonBarOptions_Books.SecurityEnabled = True
            Me.RibbonBarOptions_Books.Size = New System.Drawing.Size(102, 98)
            Me.RibbonBarOptions_Books.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Books.TabIndex = 1
            Me.RibbonBarOptions_Books.Text = "Books"
            '
            '
            '
            Me.RibbonBarOptions_Books.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Books.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Books.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemBooks_Cancel
            '
            Me.ButtonItemBooks_Cancel.BeginGroup = True
            Me.ButtonItemBooks_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemBooks_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBooks_Cancel.Name = "ButtonItemBooks_Cancel"
            Me.ButtonItemBooks_Cancel.SecurityEnabled = True
            Me.ButtonItemBooks_Cancel.Stretch = True
            Me.ButtonItemBooks_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemBooks_Cancel.Text = "Cancel"
            '
            'ButtonItemBooks_Delete
            '
            Me.ButtonItemBooks_Delete.BeginGroup = True
            Me.ButtonItemBooks_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemBooks_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemBooks_Delete.Name = "ButtonItemBooks_Delete"
            Me.ButtonItemBooks_Delete.SecurityEnabled = True
            Me.ButtonItemBooks_Delete.Stretch = True
            Me.ButtonItemBooks_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemBooks_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(219, 98)
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
            'TabControlForm_ResearchCriteria
            '
            Me.TabControlForm_ResearchCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ResearchCriteria.BackColor = System.Drawing.Color.White
            Me.TabControlForm_ResearchCriteria.CanReorderTabs = False
            Me.TabControlForm_ResearchCriteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_ResearchCriteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelDaysTimes_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelMarket_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelStations_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelFormats_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelMetrics_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelBooks_Criteria)
            Me.TabControlForm_ResearchCriteria.Controls.Add(Me.TabControlPanelResults_Results)
            Me.TabControlForm_ResearchCriteria.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_ResearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ResearchCriteria.Name = "TabControlForm_ResearchCriteria"
            Me.TabControlForm_ResearchCriteria.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ResearchCriteria.SelectedTabIndex = 0
            Me.TabControlForm_ResearchCriteria.Size = New System.Drawing.Size(833, 600)
            Me.TabControlForm_ResearchCriteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ResearchCriteria.TabIndex = 0
            Me.TabControlForm_ResearchCriteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Market)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Books)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_DaysTimes)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Metrics)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Formats)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Stations)
            Me.TabControlForm_ResearchCriteria.Tabs.Add(Me.TabItemResearchCriteria_Results)
            '
            'TabControlPanelDaysTimes_Criteria
            '
            Me.TabControlPanelDaysTimes_Criteria.Controls.Add(Me.DataGridViewDayparts_Dayparts)
            Me.TabControlPanelDaysTimes_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDaysTimes_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDaysTimes_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDaysTimes_Criteria.Name = "TabControlPanelDaysTimes_Criteria"
            Me.TabControlPanelDaysTimes_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDaysTimes_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelDaysTimes_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDaysTimes_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDaysTimes_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDaysTimes_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDaysTimes_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDaysTimes_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelDaysTimes_Criteria.TabIndex = 4
            Me.TabControlPanelDaysTimes_Criteria.TabItem = Me.TabItemResearchCriteria_DaysTimes
            '
            'DataGridViewDayparts_Dayparts
            '
            Me.DataGridViewDayparts_Dayparts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDayparts_Dayparts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDayparts_Dayparts.AutoUpdateViewCaption = True
            Me.DataGridViewDayparts_Dayparts.DataSource = Nothing
            Me.DataGridViewDayparts_Dayparts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDayparts_Dayparts.ItemDescription = "Daypart(s)"
            Me.DataGridViewDayparts_Dayparts.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewDayparts_Dayparts.MultiSelect = True
            Me.DataGridViewDayparts_Dayparts.Name = "DataGridViewDayparts_Dayparts"
            Me.DataGridViewDayparts_Dayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDayparts_Dayparts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDayparts_Dayparts.Size = New System.Drawing.Size(825, 565)
            Me.DataGridViewDayparts_Dayparts.TabIndex = 1
            Me.DataGridViewDayparts_Dayparts.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_DaysTimes
            '
            Me.TabItemResearchCriteria_DaysTimes.AttachedControl = Me.TabControlPanelDaysTimes_Criteria
            Me.TabItemResearchCriteria_DaysTimes.Name = "TabItemResearchCriteria_DaysTimes"
            Me.TabItemResearchCriteria_DaysTimes.Text = "Dayparts"
            '
            'TabControlPanelMarket_Criteria
            '
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.GroupBoxMarket_Include)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.GroupBoxMarket_Ethnicity)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.GroupBoxMarket_ListeningType)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.SearchableComboBoxMarket_Qualitative)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.LabelMarket_Qualitative)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.SearchableComboBoxMarket_Demographic)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.LabelMarket_Demo)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.GroupBoxMarket_Geography)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.GroupBoxMarket_OutputType)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.LabelMarket_Market)
            Me.TabControlPanelMarket_Criteria.Controls.Add(Me.SearchableComboBoxMarket_Market)
            Me.TabControlPanelMarket_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMarket_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMarket_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMarket_Criteria.Name = "TabControlPanelMarket_Criteria"
            Me.TabControlPanelMarket_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMarket_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelMarket_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMarket_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMarket_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMarket_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMarket_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMarket_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelMarket_Criteria.TabIndex = 0
            Me.TabControlPanelMarket_Criteria.TabItem = Me.TabItemResearchCriteria_Market
            '
            'GroupBoxMarket_Include
            '
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_TotalListening)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_ERadio)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_OTAIS)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_XCodes)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_Networks)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_Simulcast)
            Me.GroupBoxMarket_Include.Controls.Add(Me.CheckBoxInclude_Stations)
            Me.GroupBoxMarket_Include.Location = New System.Drawing.Point(12, 330)
            Me.GroupBoxMarket_Include.Name = "GroupBoxMarket_Include"
            Me.GroupBoxMarket_Include.Size = New System.Drawing.Size(586, 82)
            Me.GroupBoxMarket_Include.TabIndex = 10
            Me.GroupBoxMarket_Include.Text = "Include"
            '
            'CheckBoxInclude_TotalListening
            '
            Me.CheckBoxInclude_TotalListening.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_TotalListening.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_TotalListening.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_TotalListening.CheckValue = 0
            Me.CheckBoxInclude_TotalListening.CheckValueChecked = 1
            Me.CheckBoxInclude_TotalListening.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_TotalListening.CheckValueUnchecked = 0
            Me.CheckBoxInclude_TotalListening.ChildControls = Nothing
            Me.CheckBoxInclude_TotalListening.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_TotalListening.Location = New System.Drawing.Point(231, 50)
            Me.CheckBoxInclude_TotalListening.Name = "CheckBoxInclude_TotalListening"
            Me.CheckBoxInclude_TotalListening.OldestSibling = Nothing
            Me.CheckBoxInclude_TotalListening.SecurityEnabled = True
            Me.CheckBoxInclude_TotalListening.SiblingControls = Nothing
            Me.CheckBoxInclude_TotalListening.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_TotalListening.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_TotalListening.TabIndex = 6
            Me.CheckBoxInclude_TotalListening.TabOnEnter = True
            Me.CheckBoxInclude_TotalListening.Text = "Total Listening"
            '
            'CheckBoxInclude_ERadio
            '
            Me.CheckBoxInclude_ERadio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_ERadio.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_ERadio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_ERadio.CheckValue = 0
            Me.CheckBoxInclude_ERadio.CheckValueChecked = 1
            Me.CheckBoxInclude_ERadio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_ERadio.CheckValueUnchecked = 0
            Me.CheckBoxInclude_ERadio.ChildControls = Nothing
            Me.CheckBoxInclude_ERadio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_ERadio.Location = New System.Drawing.Point(118, 50)
            Me.CheckBoxInclude_ERadio.Name = "CheckBoxInclude_ERadio"
            Me.CheckBoxInclude_ERadio.OldestSibling = Nothing
            Me.CheckBoxInclude_ERadio.SecurityEnabled = True
            Me.CheckBoxInclude_ERadio.SiblingControls = Nothing
            Me.CheckBoxInclude_ERadio.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_ERadio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_ERadio.TabIndex = 5
            Me.CheckBoxInclude_ERadio.TabOnEnter = True
            Me.CheckBoxInclude_ERadio.Text = "eRadio"
            '
            'CheckBoxInclude_OTAIS
            '
            Me.CheckBoxInclude_OTAIS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_OTAIS.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_OTAIS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_OTAIS.CheckValue = 0
            Me.CheckBoxInclude_OTAIS.CheckValueChecked = 1
            Me.CheckBoxInclude_OTAIS.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_OTAIS.CheckValueUnchecked = 0
            Me.CheckBoxInclude_OTAIS.ChildControls = Nothing
            Me.CheckBoxInclude_OTAIS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_OTAIS.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxInclude_OTAIS.Name = "CheckBoxInclude_OTAIS"
            Me.CheckBoxInclude_OTAIS.OldestSibling = Nothing
            Me.CheckBoxInclude_OTAIS.SecurityEnabled = True
            Me.CheckBoxInclude_OTAIS.SiblingControls = Nothing
            Me.CheckBoxInclude_OTAIS.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_OTAIS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_OTAIS.TabIndex = 4
            Me.CheckBoxInclude_OTAIS.TabOnEnter = True
            Me.CheckBoxInclude_OTAIS.Text = "OTAIS"
            '
            'CheckBoxInclude_XCodes
            '
            Me.CheckBoxInclude_XCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_XCodes.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_XCodes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_XCodes.CheckValue = 0
            Me.CheckBoxInclude_XCodes.CheckValueChecked = 1
            Me.CheckBoxInclude_XCodes.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_XCodes.CheckValueUnchecked = 0
            Me.CheckBoxInclude_XCodes.ChildControls = Nothing
            Me.CheckBoxInclude_XCodes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_XCodes.Location = New System.Drawing.Point(344, 24)
            Me.CheckBoxInclude_XCodes.Name = "CheckBoxInclude_XCodes"
            Me.CheckBoxInclude_XCodes.OldestSibling = Nothing
            Me.CheckBoxInclude_XCodes.SecurityEnabled = True
            Me.CheckBoxInclude_XCodes.SiblingControls = Nothing
            Me.CheckBoxInclude_XCodes.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_XCodes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_XCodes.TabIndex = 3
            Me.CheckBoxInclude_XCodes.TabOnEnter = True
            Me.CheckBoxInclude_XCodes.Text = "X-Codes"
            '
            'CheckBoxInclude_Networks
            '
            Me.CheckBoxInclude_Networks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_Networks.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_Networks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_Networks.CheckValue = 0
            Me.CheckBoxInclude_Networks.CheckValueChecked = 1
            Me.CheckBoxInclude_Networks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_Networks.CheckValueUnchecked = 0
            Me.CheckBoxInclude_Networks.ChildControls = Nothing
            Me.CheckBoxInclude_Networks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_Networks.Location = New System.Drawing.Point(231, 24)
            Me.CheckBoxInclude_Networks.Name = "CheckBoxInclude_Networks"
            Me.CheckBoxInclude_Networks.OldestSibling = Nothing
            Me.CheckBoxInclude_Networks.SecurityEnabled = True
            Me.CheckBoxInclude_Networks.SiblingControls = Nothing
            Me.CheckBoxInclude_Networks.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_Networks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_Networks.TabIndex = 2
            Me.CheckBoxInclude_Networks.TabOnEnter = True
            Me.CheckBoxInclude_Networks.Text = "Networks"
            '
            'CheckBoxInclude_Simulcast
            '
            Me.CheckBoxInclude_Simulcast.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_Simulcast.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_Simulcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_Simulcast.CheckValue = 0
            Me.CheckBoxInclude_Simulcast.CheckValueChecked = 1
            Me.CheckBoxInclude_Simulcast.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_Simulcast.CheckValueUnchecked = 0
            Me.CheckBoxInclude_Simulcast.ChildControls = Nothing
            Me.CheckBoxInclude_Simulcast.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_Simulcast.Location = New System.Drawing.Point(118, 24)
            Me.CheckBoxInclude_Simulcast.Name = "CheckBoxInclude_Simulcast"
            Me.CheckBoxInclude_Simulcast.OldestSibling = Nothing
            Me.CheckBoxInclude_Simulcast.SecurityEnabled = True
            Me.CheckBoxInclude_Simulcast.SiblingControls = Nothing
            Me.CheckBoxInclude_Simulcast.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_Simulcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_Simulcast.TabIndex = 1
            Me.CheckBoxInclude_Simulcast.TabOnEnter = True
            Me.CheckBoxInclude_Simulcast.Text = "Simulcast"
            '
            'CheckBoxInclude_Stations
            '
            Me.CheckBoxInclude_Stations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxInclude_Stations.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxInclude_Stations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInclude_Stations.CheckValue = 0
            Me.CheckBoxInclude_Stations.CheckValueChecked = 1
            Me.CheckBoxInclude_Stations.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInclude_Stations.CheckValueUnchecked = 0
            Me.CheckBoxInclude_Stations.ChildControls = Nothing
            Me.CheckBoxInclude_Stations.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInclude_Stations.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxInclude_Stations.Name = "CheckBoxInclude_Stations"
            Me.CheckBoxInclude_Stations.OldestSibling = Nothing
            Me.CheckBoxInclude_Stations.SecurityEnabled = True
            Me.CheckBoxInclude_Stations.SiblingControls = Nothing
            Me.CheckBoxInclude_Stations.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxInclude_Stations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInclude_Stations.TabIndex = 0
            Me.CheckBoxInclude_Stations.TabOnEnter = True
            Me.CheckBoxInclude_Stations.Text = "Stations"
            '
            'GroupBoxMarket_Ethnicity
            '
            Me.GroupBoxMarket_Ethnicity.Controls.Add(Me.RadioButtonEthnicity_IAS)
            Me.GroupBoxMarket_Ethnicity.Controls.Add(Me.RadioButtonEthnicity_Hispanic)
            Me.GroupBoxMarket_Ethnicity.Controls.Add(Me.RadioButtonEthnicity_Black)
            Me.GroupBoxMarket_Ethnicity.Controls.Add(Me.RadioButtonEthnicity_All)
            Me.GroupBoxMarket_Ethnicity.Location = New System.Drawing.Point(11, 268)
            Me.GroupBoxMarket_Ethnicity.Name = "GroupBoxMarket_Ethnicity"
            Me.GroupBoxMarket_Ethnicity.Size = New System.Drawing.Size(586, 56)
            Me.GroupBoxMarket_Ethnicity.TabIndex = 9
            Me.GroupBoxMarket_Ethnicity.Text = "Ethnicity"
            '
            'RadioButtonEthnicity_IAS
            '
            Me.RadioButtonEthnicity_IAS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonEthnicity_IAS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEthnicity_IAS.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEthnicity_IAS.Location = New System.Drawing.Point(302, 22)
            Me.RadioButtonEthnicity_IAS.Name = "RadioButtonEthnicity_IAS"
            Me.RadioButtonEthnicity_IAS.SecurityEnabled = True
            Me.RadioButtonEthnicity_IAS.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonEthnicity_IAS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEthnicity_IAS.TabIndex = 4
            Me.RadioButtonEthnicity_IAS.TabOnEnter = True
            Me.RadioButtonEthnicity_IAS.TabStop = False
            Me.RadioButtonEthnicity_IAS.Tag = "4"
            Me.RadioButtonEthnicity_IAS.Text = "IAS"
            '
            'RadioButtonEthnicity_Hispanic
            '
            Me.RadioButtonEthnicity_Hispanic.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonEthnicity_Hispanic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEthnicity_Hispanic.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEthnicity_Hispanic.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonEthnicity_Hispanic.Name = "RadioButtonEthnicity_Hispanic"
            Me.RadioButtonEthnicity_Hispanic.SecurityEnabled = True
            Me.RadioButtonEthnicity_Hispanic.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonEthnicity_Hispanic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEthnicity_Hispanic.TabIndex = 3
            Me.RadioButtonEthnicity_Hispanic.TabOnEnter = True
            Me.RadioButtonEthnicity_Hispanic.TabStop = False
            Me.RadioButtonEthnicity_Hispanic.Tag = "3"
            Me.RadioButtonEthnicity_Hispanic.Text = "Hispanic"
            '
            'RadioButtonEthnicity_Black
            '
            Me.RadioButtonEthnicity_Black.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonEthnicity_Black.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEthnicity_Black.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEthnicity_Black.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonEthnicity_Black.Name = "RadioButtonEthnicity_Black"
            Me.RadioButtonEthnicity_Black.SecurityEnabled = True
            Me.RadioButtonEthnicity_Black.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonEthnicity_Black.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEthnicity_Black.TabIndex = 2
            Me.RadioButtonEthnicity_Black.TabOnEnter = True
            Me.RadioButtonEthnicity_Black.TabStop = False
            Me.RadioButtonEthnicity_Black.Tag = "2"
            Me.RadioButtonEthnicity_Black.Text = "Black"
            '
            'RadioButtonEthnicity_All
            '
            Me.RadioButtonEthnicity_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonEthnicity_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEthnicity_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEthnicity_All.Checked = True
            Me.RadioButtonEthnicity_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonEthnicity_All.CheckValue = "Y"
            Me.RadioButtonEthnicity_All.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonEthnicity_All.Name = "RadioButtonEthnicity_All"
            Me.RadioButtonEthnicity_All.SecurityEnabled = True
            Me.RadioButtonEthnicity_All.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonEthnicity_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEthnicity_All.TabIndex = 1
            Me.RadioButtonEthnicity_All.TabOnEnter = True
            Me.RadioButtonEthnicity_All.Tag = "1"
            Me.RadioButtonEthnicity_All.Text = "All"
            '
            'GroupBoxMarket_ListeningType
            '
            Me.GroupBoxMarket_ListeningType.Controls.Add(Me.RadioButtonListeningType_OOH)
            Me.GroupBoxMarket_ListeningType.Controls.Add(Me.RadioButtonListeningType_Car)
            Me.GroupBoxMarket_ListeningType.Controls.Add(Me.RadioButtonListeningType_Work)
            Me.GroupBoxMarket_ListeningType.Controls.Add(Me.RadioButtonListeningType_Home)
            Me.GroupBoxMarket_ListeningType.Controls.Add(Me.RadioButtonListeningType_Total)
            Me.GroupBoxMarket_ListeningType.Location = New System.Drawing.Point(12, 206)
            Me.GroupBoxMarket_ListeningType.Name = "GroupBoxMarket_ListeningType"
            Me.GroupBoxMarket_ListeningType.Size = New System.Drawing.Size(586, 56)
            Me.GroupBoxMarket_ListeningType.TabIndex = 8
            Me.GroupBoxMarket_ListeningType.Text = "Listening Type"
            '
            'RadioButtonListeningType_OOH
            '
            Me.RadioButtonListeningType_OOH.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonListeningType_OOH.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonListeningType_OOH.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonListeningType_OOH.Location = New System.Drawing.Point(420, 22)
            Me.RadioButtonListeningType_OOH.Name = "RadioButtonListeningType_OOH"
            Me.RadioButtonListeningType_OOH.SecurityEnabled = True
            Me.RadioButtonListeningType_OOH.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonListeningType_OOH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonListeningType_OOH.TabIndex = 5
            Me.RadioButtonListeningType_OOH.TabOnEnter = True
            Me.RadioButtonListeningType_OOH.TabStop = False
            Me.RadioButtonListeningType_OOH.Tag = "6"
            Me.RadioButtonListeningType_OOH.Text = "Out of Home"
            '
            'RadioButtonListeningType_Car
            '
            Me.RadioButtonListeningType_Car.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonListeningType_Car.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonListeningType_Car.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonListeningType_Car.Location = New System.Drawing.Point(302, 22)
            Me.RadioButtonListeningType_Car.Name = "RadioButtonListeningType_Car"
            Me.RadioButtonListeningType_Car.SecurityEnabled = True
            Me.RadioButtonListeningType_Car.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonListeningType_Car.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonListeningType_Car.TabIndex = 4
            Me.RadioButtonListeningType_Car.TabOnEnter = True
            Me.RadioButtonListeningType_Car.TabStop = False
            Me.RadioButtonListeningType_Car.Tag = "4"
            Me.RadioButtonListeningType_Car.Text = "Car"
            '
            'RadioButtonListeningType_Work
            '
            Me.RadioButtonListeningType_Work.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonListeningType_Work.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonListeningType_Work.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonListeningType_Work.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonListeningType_Work.Name = "RadioButtonListeningType_Work"
            Me.RadioButtonListeningType_Work.SecurityEnabled = True
            Me.RadioButtonListeningType_Work.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonListeningType_Work.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonListeningType_Work.TabIndex = 3
            Me.RadioButtonListeningType_Work.TabOnEnter = True
            Me.RadioButtonListeningType_Work.TabStop = False
            Me.RadioButtonListeningType_Work.Tag = "3"
            Me.RadioButtonListeningType_Work.Text = "Work"
            '
            'RadioButtonListeningType_Home
            '
            Me.RadioButtonListeningType_Home.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonListeningType_Home.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonListeningType_Home.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonListeningType_Home.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonListeningType_Home.Name = "RadioButtonListeningType_Home"
            Me.RadioButtonListeningType_Home.SecurityEnabled = True
            Me.RadioButtonListeningType_Home.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonListeningType_Home.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonListeningType_Home.TabIndex = 2
            Me.RadioButtonListeningType_Home.TabOnEnter = True
            Me.RadioButtonListeningType_Home.TabStop = False
            Me.RadioButtonListeningType_Home.Tag = "2"
            Me.RadioButtonListeningType_Home.Text = "Home"
            '
            'RadioButtonListeningType_Total
            '
            Me.RadioButtonListeningType_Total.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonListeningType_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonListeningType_Total.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonListeningType_Total.Checked = True
            Me.RadioButtonListeningType_Total.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonListeningType_Total.CheckValue = "Y"
            Me.RadioButtonListeningType_Total.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonListeningType_Total.Name = "RadioButtonListeningType_Total"
            Me.RadioButtonListeningType_Total.SecurityEnabled = True
            Me.RadioButtonListeningType_Total.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonListeningType_Total.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonListeningType_Total.TabIndex = 1
            Me.RadioButtonListeningType_Total.TabOnEnter = True
            Me.RadioButtonListeningType_Total.Tag = "1"
            Me.RadioButtonListeningType_Total.Text = "Total"
            '
            'SearchableComboBoxMarket_Qualitative
            '
            Me.SearchableComboBoxMarket_Qualitative.ActiveFilterString = ""
            Me.SearchableComboBoxMarket_Qualitative.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMarket_Qualitative.AutoFillMode = False
            Me.SearchableComboBoxMarket_Qualitative.BookmarkingEnabled = False
            Me.SearchableComboBoxMarket_Qualitative.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.NielsenRadioQualitative
            Me.SearchableComboBoxMarket_Qualitative.DataSource = Nothing
            Me.SearchableComboBoxMarket_Qualitative.DisableMouseWheel = True
            Me.SearchableComboBoxMarket_Qualitative.DisplayName = ""
            Me.SearchableComboBoxMarket_Qualitative.EditValue = ""
            Me.SearchableComboBoxMarket_Qualitative.EnterMoveNextControl = True
            Me.SearchableComboBoxMarket_Qualitative.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxMarket_Qualitative.Location = New System.Drawing.Point(99, 56)
            Me.SearchableComboBoxMarket_Qualitative.Name = "SearchableComboBoxMarket_Qualitative"
            Me.SearchableComboBoxMarket_Qualitative.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMarket_Qualitative.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxMarket_Qualitative.Properties.NullText = "Select Qualitative"
            Me.SearchableComboBoxMarket_Qualitative.Properties.ShowClearButton = False
            Me.SearchableComboBoxMarket_Qualitative.Properties.ValueMember = "ID"
            Me.SearchableComboBoxMarket_Qualitative.Properties.View = Me.GridView2
            Me.SearchableComboBoxMarket_Qualitative.SecurityEnabled = True
            Me.SearchableComboBoxMarket_Qualitative.SelectedValue = ""
            Me.SearchableComboBoxMarket_Qualitative.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxMarket_Qualitative.TabIndex = 5
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
            '
            'LabelMarket_Qualitative
            '
            Me.LabelMarket_Qualitative.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMarket_Qualitative.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMarket_Qualitative.Location = New System.Drawing.Point(12, 56)
            Me.LabelMarket_Qualitative.Name = "LabelMarket_Qualitative"
            Me.LabelMarket_Qualitative.Size = New System.Drawing.Size(81, 20)
            Me.LabelMarket_Qualitative.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMarket_Qualitative.TabIndex = 4
            Me.LabelMarket_Qualitative.Text = "Qualitative:"
            '
            'SearchableComboBoxMarket_Demographic
            '
            Me.SearchableComboBoxMarket_Demographic.ActiveFilterString = ""
            Me.SearchableComboBoxMarket_Demographic.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMarket_Demographic.AutoFillMode = False
            Me.SearchableComboBoxMarket_Demographic.BookmarkingEnabled = False
            Me.SearchableComboBoxMarket_Demographic.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBoxMarket_Demographic.DataSource = Nothing
            Me.SearchableComboBoxMarket_Demographic.DisableMouseWheel = True
            Me.SearchableComboBoxMarket_Demographic.DisplayName = ""
            Me.SearchableComboBoxMarket_Demographic.EditValue = ""
            Me.SearchableComboBoxMarket_Demographic.EnterMoveNextControl = True
            Me.SearchableComboBoxMarket_Demographic.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxMarket_Demographic.Location = New System.Drawing.Point(99, 30)
            Me.SearchableComboBoxMarket_Demographic.Name = "SearchableComboBoxMarket_Demographic"
            Me.SearchableComboBoxMarket_Demographic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMarket_Demographic.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMarket_Demographic.Properties.NullText = "Select Demographic"
            Me.SearchableComboBoxMarket_Demographic.Properties.ShowClearButton = False
            Me.SearchableComboBoxMarket_Demographic.Properties.ValueMember = "ID"
            Me.SearchableComboBoxMarket_Demographic.Properties.View = Me.GridView1
            Me.SearchableComboBoxMarket_Demographic.SecurityEnabled = True
            Me.SearchableComboBoxMarket_Demographic.SelectedValue = ""
            Me.SearchableComboBoxMarket_Demographic.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxMarket_Demographic.TabIndex = 3
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
            '
            'LabelMarket_Demo
            '
            Me.LabelMarket_Demo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMarket_Demo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMarket_Demo.Location = New System.Drawing.Point(12, 30)
            Me.LabelMarket_Demo.Name = "LabelMarket_Demo"
            Me.LabelMarket_Demo.Size = New System.Drawing.Size(81, 20)
            Me.LabelMarket_Demo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMarket_Demo.TabIndex = 2
            Me.LabelMarket_Demo.Text = "Demo:"
            '
            'GroupBoxMarket_Geography
            '
            Me.GroupBoxMarket_Geography.Controls.Add(Me.RadioButtonGeography_DMA)
            Me.GroupBoxMarket_Geography.Controls.Add(Me.RadioButtonGeography_TSA)
            Me.GroupBoxMarket_Geography.Controls.Add(Me.RadioButtonGeography_Metro)
            Me.GroupBoxMarket_Geography.Location = New System.Drawing.Point(11, 144)
            Me.GroupBoxMarket_Geography.Name = "GroupBoxMarket_Geography"
            Me.GroupBoxMarket_Geography.Size = New System.Drawing.Size(301, 56)
            Me.GroupBoxMarket_Geography.TabIndex = 7
            Me.GroupBoxMarket_Geography.Text = "Geography"
            '
            'RadioButtonGeography_DMA
            '
            Me.RadioButtonGeography_DMA.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGeography_DMA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGeography_DMA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGeography_DMA.Location = New System.Drawing.Point(184, 22)
            Me.RadioButtonGeography_DMA.Name = "RadioButtonGeography_DMA"
            Me.RadioButtonGeography_DMA.SecurityEnabled = True
            Me.RadioButtonGeography_DMA.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonGeography_DMA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGeography_DMA.TabIndex = 3
            Me.RadioButtonGeography_DMA.TabOnEnter = True
            Me.RadioButtonGeography_DMA.TabStop = False
            Me.RadioButtonGeography_DMA.Tag = "3"
            Me.RadioButtonGeography_DMA.Text = "DMA"
            '
            'RadioButtonGeography_TSA
            '
            Me.RadioButtonGeography_TSA.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGeography_TSA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGeography_TSA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGeography_TSA.Location = New System.Drawing.Point(88, 22)
            Me.RadioButtonGeography_TSA.Name = "RadioButtonGeography_TSA"
            Me.RadioButtonGeography_TSA.SecurityEnabled = True
            Me.RadioButtonGeography_TSA.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonGeography_TSA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGeography_TSA.TabIndex = 2
            Me.RadioButtonGeography_TSA.TabOnEnter = True
            Me.RadioButtonGeography_TSA.TabStop = False
            Me.RadioButtonGeography_TSA.Tag = "2"
            Me.RadioButtonGeography_TSA.Text = "TSA"
            '
            'RadioButtonGeography_Metro
            '
            Me.RadioButtonGeography_Metro.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonGeography_Metro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGeography_Metro.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGeography_Metro.Checked = True
            Me.RadioButtonGeography_Metro.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonGeography_Metro.CheckValue = "Y"
            Me.RadioButtonGeography_Metro.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonGeography_Metro.Name = "RadioButtonGeography_Metro"
            Me.RadioButtonGeography_Metro.SecurityEnabled = True
            Me.RadioButtonGeography_Metro.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonGeography_Metro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGeography_Metro.TabIndex = 1
            Me.RadioButtonGeography_Metro.TabOnEnter = True
            Me.RadioButtonGeography_Metro.Tag = "1"
            Me.RadioButtonGeography_Metro.Text = "Metro"
            '
            'GroupBoxMarket_OutputType
            '
            Me.GroupBoxMarket_OutputType.Controls.Add(Me.RadioButtonOutput_AudienceComp)
            Me.GroupBoxMarket_OutputType.Controls.Add(Me.RadioButtonOutput_Trend)
            Me.GroupBoxMarket_OutputType.Controls.Add(Me.RadioButtonOutput_Ranker)
            Me.GroupBoxMarket_OutputType.Location = New System.Drawing.Point(12, 82)
            Me.GroupBoxMarket_OutputType.Name = "GroupBoxMarket_OutputType"
            Me.GroupBoxMarket_OutputType.Size = New System.Drawing.Size(300, 56)
            Me.GroupBoxMarket_OutputType.TabIndex = 6
            Me.GroupBoxMarket_OutputType.Text = "Output Type"
            '
            'RadioButtonOutput_AudienceComp
            '
            Me.RadioButtonOutput_AudienceComp.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOutput_AudienceComp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOutput_AudienceComp.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOutput_AudienceComp.Location = New System.Drawing.Point(183, 22)
            Me.RadioButtonOutput_AudienceComp.Name = "RadioButtonOutput_AudienceComp"
            Me.RadioButtonOutput_AudienceComp.SecurityEnabled = True
            Me.RadioButtonOutput_AudienceComp.Size = New System.Drawing.Size(112, 20)
            Me.RadioButtonOutput_AudienceComp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOutput_AudienceComp.TabIndex = 3
            Me.RadioButtonOutput_AudienceComp.TabOnEnter = True
            Me.RadioButtonOutput_AudienceComp.TabStop = False
            Me.RadioButtonOutput_AudienceComp.Tag = "3"
            Me.RadioButtonOutput_AudienceComp.Text = "Audience Comp"
            '
            'RadioButtonOutput_Trend
            '
            Me.RadioButtonOutput_Trend.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOutput_Trend.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOutput_Trend.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOutput_Trend.Location = New System.Drawing.Point(87, 22)
            Me.RadioButtonOutput_Trend.Name = "RadioButtonOutput_Trend"
            Me.RadioButtonOutput_Trend.SecurityEnabled = True
            Me.RadioButtonOutput_Trend.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonOutput_Trend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOutput_Trend.TabIndex = 2
            Me.RadioButtonOutput_Trend.TabOnEnter = True
            Me.RadioButtonOutput_Trend.TabStop = False
            Me.RadioButtonOutput_Trend.Tag = "2"
            Me.RadioButtonOutput_Trend.Text = "Trend"
            '
            'RadioButtonOutput_Ranker
            '
            Me.RadioButtonOutput_Ranker.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOutput_Ranker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOutput_Ranker.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOutput_Ranker.Checked = True
            Me.RadioButtonOutput_Ranker.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonOutput_Ranker.CheckValue = "Y"
            Me.RadioButtonOutput_Ranker.Location = New System.Drawing.Point(5, 22)
            Me.RadioButtonOutput_Ranker.Name = "RadioButtonOutput_Ranker"
            Me.RadioButtonOutput_Ranker.SecurityEnabled = True
            Me.RadioButtonOutput_Ranker.Size = New System.Drawing.Size(76, 20)
            Me.RadioButtonOutput_Ranker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOutput_Ranker.TabIndex = 1
            Me.RadioButtonOutput_Ranker.TabOnEnter = True
            Me.RadioButtonOutput_Ranker.Tag = "1"
            Me.RadioButtonOutput_Ranker.Text = "Ranker"
            '
            'LabelMarket_Market
            '
            Me.LabelMarket_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMarket_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMarket_Market.Location = New System.Drawing.Point(12, 4)
            Me.LabelMarket_Market.Name = "LabelMarket_Market"
            Me.LabelMarket_Market.Size = New System.Drawing.Size(81, 20)
            Me.LabelMarket_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMarket_Market.TabIndex = 0
            Me.LabelMarket_Market.Text = "Market:"
            '
            'SearchableComboBoxMarket_Market
            '
            Me.SearchableComboBoxMarket_Market.ActiveFilterString = ""
            Me.SearchableComboBoxMarket_Market.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMarket_Market.AutoFillMode = False
            Me.SearchableComboBoxMarket_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxMarket_Market.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxMarket_Market.DataSource = Nothing
            Me.SearchableComboBoxMarket_Market.DisableMouseWheel = True
            Me.SearchableComboBoxMarket_Market.DisplayName = ""
            Me.SearchableComboBoxMarket_Market.EditValue = ""
            Me.SearchableComboBoxMarket_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxMarket_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxMarket_Market.Location = New System.Drawing.Point(99, 4)
            Me.SearchableComboBoxMarket_Market.Name = "SearchableComboBoxMarket_Market"
            Me.SearchableComboBoxMarket_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMarket_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMarket_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxMarket_Market.Properties.ShowClearButton = False
            Me.SearchableComboBoxMarket_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMarket_Market.Properties.View = Me.SearchableComboBoxViewControl_Market
            Me.SearchableComboBoxMarket_Market.SecurityEnabled = True
            Me.SearchableComboBoxMarket_Market.SelectedValue = ""
            Me.SearchableComboBoxMarket_Market.Size = New System.Drawing.Size(213, 20)
            Me.SearchableComboBoxMarket_Market.TabIndex = 1
            '
            'SearchableComboBoxViewControl_Market
            '
            Me.SearchableComboBoxViewControl_Market.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_Market.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Market.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_Market.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_Market.Name = "SearchableComboBoxViewControl_Market"
            Me.SearchableComboBoxViewControl_Market.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Market.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Market.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_Market.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_Market.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_Market.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_Market.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_Market.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_Market.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_Market.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            '
            'TabItemResearchCriteria_Market
            '
            Me.TabItemResearchCriteria_Market.AttachedControl = Me.TabControlPanelMarket_Criteria
            Me.TabItemResearchCriteria_Market.Name = "TabItemResearchCriteria_Market"
            Me.TabItemResearchCriteria_Market.Text = "Market"
            '
            'TabControlPanelStations_Criteria
            '
            Me.TabControlPanelStations_Criteria.Controls.Add(Me.PanelMarketStation_Bottom)
            Me.TabControlPanelStations_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelStations_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStations_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelStations_Criteria.Name = "TabControlPanelStations_Criteria"
            Me.TabControlPanelStations_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStations_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelStations_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelStations_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelStations_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStations_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStations_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStations_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelStations_Criteria.TabIndex = 50
            Me.TabControlPanelStations_Criteria.TabItem = Me.TabItemResearchCriteria_Stations
            '
            'PanelMarketStation_Bottom
            '
            Me.PanelMarketStation_Bottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelMarketStation_Bottom.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelMarketStation_Bottom.Appearance.Options.UseBackColor = True
            Me.PanelMarketStation_Bottom.Controls.Add(Me.PanelBottomMarketStation_RightSection)
            Me.PanelMarketStation_Bottom.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.PanelMarketStation_Bottom.Controls.Add(Me.PanelBottomMarketStation_LeftSection)
            Me.PanelMarketStation_Bottom.Location = New System.Drawing.Point(4, 4)
            Me.PanelMarketStation_Bottom.Name = "PanelMarketStation_Bottom"
            Me.PanelMarketStation_Bottom.Size = New System.Drawing.Size(825, 565)
            Me.PanelMarketStation_Bottom.TabIndex = 7
            '
            'PanelBottomMarketStation_RightSection
            '
            Me.PanelBottomMarketStation_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomMarketStation_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomMarketStation_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedStations)
            Me.PanelBottomMarketStation_RightSection.Controls.Add(Me.ButtonRightSectionStation_AddToSelected)
            Me.PanelBottomMarketStation_RightSection.Controls.Add(Me.ButtonRightSectionStation_RemoveFromSelected)
            Me.PanelBottomMarketStation_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBottomMarketStation_RightSection.Location = New System.Drawing.Point(325, 2)
            Me.PanelBottomMarketStation_RightSection.Name = "PanelBottomMarketStation_RightSection"
            Me.PanelBottomMarketStation_RightSection.Size = New System.Drawing.Size(498, 561)
            Me.PanelBottomMarketStation_RightSection.TabIndex = 1
            '
            'DataGridViewRightSection_SelectedStations
            '
            Me.DataGridViewRightSection_SelectedStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedStations.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedStations.ItemDescription = "Selected Station(s)"
            Me.DataGridViewRightSection_SelectedStations.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_SelectedStations.MultiSelect = True
            Me.DataGridViewRightSection_SelectedStations.Name = "DataGridViewRightSection_SelectedStations"
            Me.DataGridViewRightSection_SelectedStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedStations.ShowSelectDeselectAllButtons = True
            Me.DataGridViewRightSection_SelectedStations.Size = New System.Drawing.Size(407, 551)
            Me.DataGridViewRightSection_SelectedStations.TabIndex = 2
            Me.DataGridViewRightSection_SelectedStations.ViewCaptionHeight = -1
            '
            'ButtonRightSectionStation_AddToSelected
            '
            Me.ButtonRightSectionStation_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionStation_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionStation_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSectionStation_AddToSelected.Name = "ButtonRightSectionStation_AddToSelected"
            Me.ButtonRightSectionStation_AddToSelected.SecurityEnabled = True
            Me.ButtonRightSectionStation_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionStation_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionStation_AddToSelected.TabIndex = 0
            Me.ButtonRightSectionStation_AddToSelected.Text = ">"
            '
            'ButtonRightSectionStation_RemoveFromSelected
            '
            Me.ButtonRightSectionStation_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionStation_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionStation_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSectionStation_RemoveFromSelected.Name = "ButtonRightSectionStation_RemoveFromSelected"
            Me.ButtonRightSectionStation_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonRightSectionStation_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionStation_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionStation_RemoveFromSelected.TabIndex = 1
            Me.ButtonRightSectionStation_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControl_LeftRight
            '
            Me.ExpandableSplitterControl_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl_LeftRight.Name = "ExpandableSplitterControl_LeftRight"
            Me.ExpandableSplitterControl_LeftRight.Size = New System.Drawing.Size(6, 561)
            Me.ExpandableSplitterControl_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl_LeftRight.TabIndex = 20
            Me.ExpandableSplitterControl_LeftRight.TabStop = False
            '
            'PanelBottomMarketStation_LeftSection
            '
            Me.PanelBottomMarketStation_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelBottomMarketStation_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelBottomMarketStation_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableStations)
            Me.PanelBottomMarketStation_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelBottomMarketStation_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelBottomMarketStation_LeftSection.Name = "PanelBottomMarketStation_LeftSection"
            Me.PanelBottomMarketStation_LeftSection.Size = New System.Drawing.Size(317, 561)
            Me.PanelBottomMarketStation_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableStations
            '
            Me.DataGridViewLeftSection_AvailableStations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableStations.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableStations.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableStations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableStations.ItemDescription = "Available Station(s)"
            Me.DataGridViewLeftSection_AvailableStations.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableStations.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableStations.Name = "DataGridViewLeftSection_AvailableStations"
            Me.DataGridViewLeftSection_AvailableStations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableStations.ShowSelectDeselectAllButtons = True
            Me.DataGridViewLeftSection_AvailableStations.Size = New System.Drawing.Size(306, 551)
            Me.DataGridViewLeftSection_AvailableStations.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableStations.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_Stations
            '
            Me.TabItemResearchCriteria_Stations.AttachedControl = Me.TabControlPanelStations_Criteria
            Me.TabItemResearchCriteria_Stations.Name = "TabItemResearchCriteria_Stations"
            Me.TabItemResearchCriteria_Stations.Text = "Stations"
            '
            'TabControlPanelFormats_Criteria
            '
            Me.TabControlPanelFormats_Criteria.Controls.Add(Me.PanelDemographics_Criteria)
            Me.TabControlPanelFormats_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelFormats_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFormats_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelFormats_Criteria.Name = "TabControlPanelFormats_Criteria"
            Me.TabControlPanelFormats_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFormats_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelFormats_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelFormats_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelFormats_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFormats_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFormats_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFormats_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelFormats_Criteria.TabIndex = 21
            Me.TabControlPanelFormats_Criteria.TabItem = Me.TabItemResearchCriteria_Formats
            '
            'PanelDemographics_Criteria
            '
            Me.PanelDemographics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelDemographics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDemographics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelDemographics_Criteria.Controls.Add(Me.PanelDemographics_Right)
            Me.PanelDemographics_Criteria.Controls.Add(Me.ExpandableSplitterControl1)
            Me.PanelDemographics_Criteria.Controls.Add(Me.PanelDemographics_Left)
            Me.PanelDemographics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelDemographics_Criteria.Name = "PanelDemographics_Criteria"
            Me.PanelDemographics_Criteria.Size = New System.Drawing.Size(825, 565)
            Me.PanelDemographics_Criteria.TabIndex = 7
            '
            'PanelDemographics_Right
            '
            Me.PanelDemographics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDemographics_Right.Appearance.Options.UseBackColor = True
            Me.PanelDemographics_Right.Controls.Add(Me.DataGridViewRightSection_SelectedFormats)
            Me.PanelDemographics_Right.Controls.Add(Me.ButtonRightSectionFormats_AddToSelected)
            Me.PanelDemographics_Right.Controls.Add(Me.ButtonRightSectionFormats_RemoveFromSelected)
            Me.PanelDemographics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelDemographics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelDemographics_Right.Name = "PanelDemographics_Right"
            Me.PanelDemographics_Right.Size = New System.Drawing.Size(498, 561)
            Me.PanelDemographics_Right.TabIndex = 1
            '
            'DataGridViewRightSection_SelectedFormats
            '
            Me.DataGridViewRightSection_SelectedFormats.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedFormats.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedFormats.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedFormats.ItemDescription = "Selected Format(s)"
            Me.DataGridViewRightSection_SelectedFormats.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_SelectedFormats.MultiSelect = True
            Me.DataGridViewRightSection_SelectedFormats.Name = "DataGridViewRightSection_SelectedFormats"
            Me.DataGridViewRightSection_SelectedFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedFormats.Size = New System.Drawing.Size(407, 551)
            Me.DataGridViewRightSection_SelectedFormats.TabIndex = 2
            Me.DataGridViewRightSection_SelectedFormats.ViewCaptionHeight = -1
            '
            'ButtonRightSectionFormats_AddToSelected
            '
            Me.ButtonRightSectionFormats_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionFormats_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionFormats_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSectionFormats_AddToSelected.Name = "ButtonRightSectionFormats_AddToSelected"
            Me.ButtonRightSectionFormats_AddToSelected.SecurityEnabled = True
            Me.ButtonRightSectionFormats_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionFormats_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionFormats_AddToSelected.TabIndex = 0
            Me.ButtonRightSectionFormats_AddToSelected.Text = ">"
            '
            'ButtonRightSectionFormats_RemoveFromSelected
            '
            Me.ButtonRightSectionFormats_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionFormats_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionFormats_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSectionFormats_RemoveFromSelected.Name = "ButtonRightSectionFormats_RemoveFromSelected"
            Me.ButtonRightSectionFormats_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonRightSectionFormats_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionFormats_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionFormats_RemoveFromSelected.TabIndex = 1
            Me.ButtonRightSectionFormats_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControl1
            '
            Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
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
            Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
            Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 561)
            Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl1.TabIndex = 20
            Me.ExpandableSplitterControl1.TabStop = False
            '
            'PanelDemographics_Left
            '
            Me.PanelDemographics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDemographics_Left.Appearance.Options.UseBackColor = True
            Me.PanelDemographics_Left.Controls.Add(Me.DataGridViewLeftSection_AvailableFormats)
            Me.PanelDemographics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelDemographics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelDemographics_Left.Name = "PanelDemographics_Left"
            Me.PanelDemographics_Left.Size = New System.Drawing.Size(317, 561)
            Me.PanelDemographics_Left.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableFormats
            '
            Me.DataGridViewLeftSection_AvailableFormats.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableFormats.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableFormats.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableFormats.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableFormats.ItemDescription = "Available Format(s)"
            Me.DataGridViewLeftSection_AvailableFormats.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableFormats.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableFormats.Name = "DataGridViewLeftSection_AvailableFormats"
            Me.DataGridViewLeftSection_AvailableFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableFormats.Size = New System.Drawing.Size(306, 551)
            Me.DataGridViewLeftSection_AvailableFormats.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableFormats.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_Formats
            '
            Me.TabItemResearchCriteria_Formats.AttachedControl = Me.TabControlPanelFormats_Criteria
            Me.TabItemResearchCriteria_Formats.Name = "TabItemResearchCriteria_Formats"
            Me.TabItemResearchCriteria_Formats.Text = "Formats"
            '
            'TabControlPanelMetrics_Criteria
            '
            Me.TabControlPanelMetrics_Criteria.Controls.Add(Me.PanelMetrics_Criteria)
            Me.TabControlPanelMetrics_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMetrics_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMetrics_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMetrics_Criteria.Name = "TabControlPanelMetrics_Criteria"
            Me.TabControlPanelMetrics_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMetrics_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelMetrics_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMetrics_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMetrics_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMetrics_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMetrics_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMetrics_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelMetrics_Criteria.TabIndex = 25
            Me.TabControlPanelMetrics_Criteria.TabItem = Me.TabItemResearchCriteria_Metrics
            '
            'PanelMetrics_Criteria
            '
            Me.PanelMetrics_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelMetrics_Criteria.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelMetrics_Criteria.Appearance.Options.UseBackColor = True
            Me.PanelMetrics_Criteria.Controls.Add(Me.PanelMetrics_Right)
            Me.PanelMetrics_Criteria.Controls.Add(Me.ExpandableSplitterControl2)
            Me.PanelMetrics_Criteria.Controls.Add(Me.PanelMetrics_Left)
            Me.PanelMetrics_Criteria.Location = New System.Drawing.Point(4, 4)
            Me.PanelMetrics_Criteria.Name = "PanelMetrics_Criteria"
            Me.PanelMetrics_Criteria.Size = New System.Drawing.Size(825, 565)
            Me.PanelMetrics_Criteria.TabIndex = 8
            '
            'PanelMetrics_Right
            '
            Me.PanelMetrics_Right.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelMetrics_Right.Appearance.Options.UseBackColor = True
            Me.PanelMetrics_Right.Controls.Add(Me.DataGridViewRightSection_SelectedMetrics)
            Me.PanelMetrics_Right.Controls.Add(Me.ButtonRightSectionMetrics_AddToSelected)
            Me.PanelMetrics_Right.Controls.Add(Me.ButtonRightSectionMetrics_RemoveFromSelected)
            Me.PanelMetrics_Right.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMetrics_Right.Location = New System.Drawing.Point(325, 2)
            Me.PanelMetrics_Right.Name = "PanelMetrics_Right"
            Me.PanelMetrics_Right.Size = New System.Drawing.Size(498, 561)
            Me.PanelMetrics_Right.TabIndex = 1
            '
            'DataGridViewRightSection_SelectedMetrics
            '
            Me.DataGridViewRightSection_SelectedMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedMetrics.DataSource = Nothing
            Me.DataGridViewRightSection_SelectedMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedMetrics.ItemDescription = "Selected Metric(s)"
            Me.DataGridViewRightSection_SelectedMetrics.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_SelectedMetrics.MultiSelect = True
            Me.DataGridViewRightSection_SelectedMetrics.Name = "DataGridViewRightSection_SelectedMetrics"
            Me.DataGridViewRightSection_SelectedMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedMetrics.Size = New System.Drawing.Size(407, 551)
            Me.DataGridViewRightSection_SelectedMetrics.TabIndex = 2
            Me.DataGridViewRightSection_SelectedMetrics.ViewCaptionHeight = -1
            '
            'ButtonRightSectionMetrics_AddToSelected
            '
            Me.ButtonRightSectionMetrics_AddToSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionMetrics_AddToSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionMetrics_AddToSelected.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSectionMetrics_AddToSelected.Name = "ButtonRightSectionMetrics_AddToSelected"
            Me.ButtonRightSectionMetrics_AddToSelected.SecurityEnabled = True
            Me.ButtonRightSectionMetrics_AddToSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionMetrics_AddToSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionMetrics_AddToSelected.TabIndex = 0
            Me.ButtonRightSectionMetrics_AddToSelected.Text = ">"
            '
            'ButtonRightSectionMetrics_RemoveFromSelected
            '
            Me.ButtonRightSectionMetrics_RemoveFromSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSectionMetrics_RemoveFromSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSectionMetrics_RemoveFromSelected.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSectionMetrics_RemoveFromSelected.Name = "ButtonRightSectionMetrics_RemoveFromSelected"
            Me.ButtonRightSectionMetrics_RemoveFromSelected.SecurityEnabled = True
            Me.ButtonRightSectionMetrics_RemoveFromSelected.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSectionMetrics_RemoveFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSectionMetrics_RemoveFromSelected.TabIndex = 1
            Me.ButtonRightSectionMetrics_RemoveFromSelected.Text = "<"
            '
            'ExpandableSplitterControl2
            '
            Me.ExpandableSplitterControl2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl2.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl2.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl2.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl2.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl2.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl2.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl2.Location = New System.Drawing.Point(319, 2)
            Me.ExpandableSplitterControl2.Name = "ExpandableSplitterControl2"
            Me.ExpandableSplitterControl2.Size = New System.Drawing.Size(6, 561)
            Me.ExpandableSplitterControl2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl2.TabIndex = 20
            Me.ExpandableSplitterControl2.TabStop = False
            '
            'PanelMetrics_Left
            '
            Me.PanelMetrics_Left.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelMetrics_Left.Appearance.Options.UseBackColor = True
            Me.PanelMetrics_Left.Controls.Add(Me.DataGridViewLeftSection_AvailableMetrics)
            Me.PanelMetrics_Left.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelMetrics_Left.Location = New System.Drawing.Point(2, 2)
            Me.PanelMetrics_Left.Name = "PanelMetrics_Left"
            Me.PanelMetrics_Left.Size = New System.Drawing.Size(317, 561)
            Me.PanelMetrics_Left.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableMetrics
            '
            Me.DataGridViewLeftSection_AvailableMetrics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableMetrics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableMetrics.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableMetrics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableMetrics.ItemDescription = "Available Metric(s)"
            Me.DataGridViewLeftSection_AvailableMetrics.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableMetrics.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableMetrics.Name = "DataGridViewLeftSection_AvailableMetrics"
            Me.DataGridViewLeftSection_AvailableMetrics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableMetrics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableMetrics.Size = New System.Drawing.Size(306, 551)
            Me.DataGridViewLeftSection_AvailableMetrics.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableMetrics.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_Metrics
            '
            Me.TabItemResearchCriteria_Metrics.AttachedControl = Me.TabControlPanelMetrics_Criteria
            Me.TabItemResearchCriteria_Metrics.Name = "TabItemResearchCriteria_Metrics"
            Me.TabItemResearchCriteria_Metrics.Text = "Metrics"
            '
            'TabControlPanelBooks_Criteria
            '
            Me.TabControlPanelBooks_Criteria.Controls.Add(Me.DataGridViewBooks_Books)
            Me.TabControlPanelBooks_Criteria.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBooks_Criteria.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBooks_Criteria.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBooks_Criteria.Name = "TabControlPanelBooks_Criteria"
            Me.TabControlPanelBooks_Criteria.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBooks_Criteria.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelBooks_Criteria.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBooks_Criteria.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBooks_Criteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBooks_Criteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBooks_Criteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBooks_Criteria.Style.GradientAngle = 90
            Me.TabControlPanelBooks_Criteria.TabIndex = 11
            Me.TabControlPanelBooks_Criteria.TabItem = Me.TabItemResearchCriteria_Books
            '
            'DataGridViewBooks_Books
            '
            Me.DataGridViewBooks_Books.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBooks_Books.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBooks_Books.AutoUpdateViewCaption = True
            Me.DataGridViewBooks_Books.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBooks_Books.ItemDescription = "Book(s)"
            Me.DataGridViewBooks_Books.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewBooks_Books.MultiSelect = True
            Me.DataGridViewBooks_Books.Name = "DataGridViewBooks_Books"
            Me.DataGridViewBooks_Books.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewBooks_Books.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBooks_Books.Size = New System.Drawing.Size(825, 565)
            Me.DataGridViewBooks_Books.TabIndex = 2
            Me.DataGridViewBooks_Books.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_Books
            '
            Me.TabItemResearchCriteria_Books.AttachedControl = Me.TabControlPanelBooks_Criteria
            Me.TabItemResearchCriteria_Books.Name = "TabItemResearchCriteria_Books"
            Me.TabItemResearchCriteria_Books.Text = "Books"
            '
            'TabControlPanelResults_Results
            '
            Me.TabControlPanelResults_Results.Controls.Add(Me.BandedDataGridViewResults)
            Me.TabControlPanelResults_Results.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelResults_Results.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelResults_Results.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelResults_Results.Name = "TabControlPanelResults_Results"
            Me.TabControlPanelResults_Results.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelResults_Results.Size = New System.Drawing.Size(833, 573)
            Me.TabControlPanelResults_Results.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelResults_Results.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelResults_Results.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelResults_Results.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelResults_Results.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelResults_Results.Style.GradientAngle = 90
            Me.TabControlPanelResults_Results.TabIndex = 34
            Me.TabControlPanelResults_Results.TabItem = Me.TabItemResearchCriteria_Results
            '
            'BandedDataGridViewResults
            '
            Me.BandedDataGridViewResults.AddFixedColumnCheckItemsToGridMenu = False
            Me.BandedDataGridViewResults.AllowDragAndDrop = False
            Me.BandedDataGridViewResults.AllowExtraItemsInGridLookupEdits = True
            Me.BandedDataGridViewResults.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewResults.AlwaysForceShowRowSelectionOnUserInput = True
            Me.BandedDataGridViewResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewResults.AutoUpdateViewCaption = True
            Me.BandedDataGridViewResults.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView.Type.[Default]
            Me.BandedDataGridViewResults.DataSource = Nothing
            Me.BandedDataGridViewResults.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.BandedDataGridView.DataSourceViewOptions.[Default]
            Me.BandedDataGridViewResults.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewResults.ItemDescription = "Item(s)"
            Me.BandedDataGridViewResults.Location = New System.Drawing.Point(4, 4)
            Me.BandedDataGridViewResults.MultiSelect = True
            Me.BandedDataGridViewResults.Name = "BandedDataGridViewResults"
            Me.BandedDataGridViewResults.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewResults.ShowColumnMenuOnRightClick = False
            Me.BandedDataGridViewResults.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewResults.Size = New System.Drawing.Size(825, 565)
            Me.BandedDataGridViewResults.TabIndex = 0
            Me.BandedDataGridViewResults.UseEmbeddedNavigator = False
            Me.BandedDataGridViewResults.ViewCaptionHeight = -1
            '
            'TabItemResearchCriteria_Results
            '
            Me.TabItemResearchCriteria_Results.AttachedControl = Me.TabControlPanelResults_Results
            Me.TabItemResearchCriteria_Results.Name = "TabItemResearchCriteria_Results"
            Me.TabItemResearchCriteria_Results.Text = "Results"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_UserCriterias)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 624)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_UserCriterias
            '
            Me.DataGridViewLeftSection_UserCriterias.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_UserCriterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_UserCriterias.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_UserCriterias.DataSource = Nothing
            Me.DataGridViewLeftSection_UserCriterias.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_UserCriterias.ItemDescription = "Criteria(s)"
            Me.DataGridViewLeftSection_UserCriterias.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_UserCriterias.MultiSelect = False
            Me.DataGridViewLeftSection_UserCriterias.Name = "DataGridViewLeftSection_UserCriterias"
            Me.DataGridViewLeftSection_UserCriterias.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_UserCriterias.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_UserCriterias.Size = New System.Drawing.Size(180, 600)
            Me.DataGridViewLeftSection_UserCriterias.TabIndex = 0
            Me.DataGridViewLeftSection_UserCriterias.ViewCaptionHeight = -1
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.TabControlForm_ResearchCriteria)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(197, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(857, 624)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(197, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 624)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 10
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'SpotRadioResearchForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1054, 624)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SpotRadioResearchForm"
            Me.Text = "Spot Radio Research Tool"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_ResearchCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ResearchCriteria.ResumeLayout(False)
            Me.TabControlPanelDaysTimes_Criteria.ResumeLayout(False)
            Me.TabControlPanelMarket_Criteria.ResumeLayout(False)
            CType(Me.GroupBoxMarket_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMarket_Include.ResumeLayout(False)
            CType(Me.GroupBoxMarket_Ethnicity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMarket_Ethnicity.ResumeLayout(False)
            CType(Me.GroupBoxMarket_ListeningType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMarket_ListeningType.ResumeLayout(False)
            CType(Me.SearchableComboBoxMarket_Qualitative.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMarket_Demographic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMarket_Geography, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMarket_Geography.ResumeLayout(False)
            CType(Me.GroupBoxMarket_OutputType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMarket_OutputType.ResumeLayout(False)
            CType(Me.SearchableComboBoxMarket_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_Market, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelStations_Criteria.ResumeLayout(False)
            CType(Me.PanelMarketStation_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMarketStation_Bottom.ResumeLayout(False)
            CType(Me.PanelBottomMarketStation_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomMarketStation_RightSection.ResumeLayout(False)
            CType(Me.PanelBottomMarketStation_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBottomMarketStation_LeftSection.ResumeLayout(False)
            Me.TabControlPanelFormats_Criteria.ResumeLayout(False)
            CType(Me.PanelDemographics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDemographics_Criteria.ResumeLayout(False)
            CType(Me.PanelDemographics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDemographics_Right.ResumeLayout(False)
            CType(Me.PanelDemographics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDemographics_Left.ResumeLayout(False)
            Me.TabControlPanelMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelMetrics_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMetrics_Criteria.ResumeLayout(False)
            CType(Me.PanelMetrics_Right, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMetrics_Right.ResumeLayout(False)
            CType(Me.PanelMetrics_Left, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMetrics_Left.ResumeLayout(False)
            Me.TabControlPanelBooks_Criteria.ResumeLayout(False)
            Me.TabControlPanelResults_Results.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Process As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_ResearchCriteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelMarket_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemResearchCriteria_Market As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelMarket_Market As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxMarket_Market As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_Market As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents TabControlPanelDaysTimes_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemResearchCriteria_DaysTimes As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBooks_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemResearchCriteria_Books As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxMarket_OutputType As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RibbonBarOptions_Books As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemBooks_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemBooks_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_UserCriterias As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelFormats_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelDemographics_Criteria As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelDemographics_Right As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_SelectedFormats As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSectionFormats_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonRightSectionFormats_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl1 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelDemographics_Left As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableFormats As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemResearchCriteria_Formats As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMetrics_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelMetrics_Criteria As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelMetrics_Right As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_SelectedMetrics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSectionMetrics_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonRightSectionMetrics_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl2 As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelMetrics_Left As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableMetrics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemResearchCriteria_Metrics As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewDayparts_Dayparts As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelResults_Results As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemResearchCriteria_Results As DevComponents.DotNetBar.TabItem
        Friend WithEvents BandedDataGridViewResults As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents RibbonBarOptions_DayTimes As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDayTimes_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDayTimes_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelMarket_Demo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxMarket_Geography As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonGeography_DMA As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGeography_TSA As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGeography_Metro As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOutput_AudienceComp As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOutput_Trend As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOutput_Ranker As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxMarket_ListeningType As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonListeningType_Work As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonListeningType_Home As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonListeningType_Total As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents SearchableComboBoxMarket_Qualitative As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelMarket_Qualitative As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxMarket_Demographic As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents RadioButtonListeningType_OOH As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonListeningType_Car As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxMarket_Ethnicity As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonEthnicity_IAS As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonEthnicity_Hispanic As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonEthnicity_Black As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonEthnicity_All As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxMarket_Include As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxInclude_TotalListening As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_ERadio As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_OTAIS As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_XCodes As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_Networks As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_Simulcast As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInclude_Stations As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelStations_Criteria As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemResearchCriteria_Stations As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelMarketStation_Bottom As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelBottomMarketStation_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_SelectedStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonRightSectionStation_AddToSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonRightSectionStation_RemoveFromSelected As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ExpandableSplitterControl_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelBottomMarketStation_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableStations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewBooks_Books As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Metrics As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMetrics_Up As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMetrics_Down As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace