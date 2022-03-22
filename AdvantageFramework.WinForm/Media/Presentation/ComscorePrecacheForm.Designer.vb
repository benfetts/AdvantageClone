Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ComscorePrecacheForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComscorePrecacheForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TabControlForm_ComscorePrecacheDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDemographicsTab_Demographics = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDemographics_Demographics = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemForm_DemographicsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBooksTab_Books = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewBooks_Books = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemForm_BooksTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMarketStationTab_MarketStation = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_Stations = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.TabItemForm_MarketStationsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemForm_CachedTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCachedTab_Cached = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewCached_Cached = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_ComscorePrecacheDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ComscorePrecacheDetails.SuspendLayout()
            Me.TabControlPanelDemographicsTab_Demographics.SuspendLayout()
            Me.TabControlPanelBooksTab_Books.SuspendLayout()
            Me.TabControlPanelMarketStationTab_MarketStation.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.TabControlPanelCachedTab_Cached.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(94, 2)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(689, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 10
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(110, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 37
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'TabControlForm_ComscorePrecacheDetails
            '
            Me.TabControlForm_ComscorePrecacheDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ComscorePrecacheDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_ComscorePrecacheDetails.CanReorderTabs = False
            Me.TabControlForm_ComscorePrecacheDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_ComscorePrecacheDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_ComscorePrecacheDetails.Controls.Add(Me.TabControlPanelCachedTab_Cached)
            Me.TabControlForm_ComscorePrecacheDetails.Controls.Add(Me.TabControlPanelDemographicsTab_Demographics)
            Me.TabControlForm_ComscorePrecacheDetails.Controls.Add(Me.TabControlPanelMarketStationTab_MarketStation)
            Me.TabControlForm_ComscorePrecacheDetails.Controls.Add(Me.TabControlPanelBooksTab_Books)
            Me.TabControlForm_ComscorePrecacheDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_ComscorePrecacheDetails.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ComscorePrecacheDetails.Name = "TabControlForm_ComscorePrecacheDetails"
            Me.TabControlForm_ComscorePrecacheDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ComscorePrecacheDetails.SelectedTabIndex = 0
            Me.TabControlForm_ComscorePrecacheDetails.Size = New System.Drawing.Size(790, 397)
            Me.TabControlForm_ComscorePrecacheDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ComscorePrecacheDetails.TabIndex = 11
            Me.TabControlForm_ComscorePrecacheDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ComscorePrecacheDetails.Tabs.Add(Me.TabItemForm_MarketStationsTab)
            Me.TabControlForm_ComscorePrecacheDetails.Tabs.Add(Me.TabItemForm_BooksTab)
            Me.TabControlForm_ComscorePrecacheDetails.Tabs.Add(Me.TabItemForm_DemographicsTab)
            Me.TabControlForm_ComscorePrecacheDetails.Tabs.Add(Me.TabItemForm_CachedTab)
            Me.TabControlForm_ComscorePrecacheDetails.TabStop = False
            '
            'TabControlPanelDemographicsTab_Demographics
            '
            Me.TabControlPanelDemographicsTab_Demographics.Controls.Add(Me.DataGridViewDemographics_Demographics)
            Me.TabControlPanelDemographicsTab_Demographics.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDemographicsTab_Demographics.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDemographicsTab_Demographics.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDemographicsTab_Demographics.Name = "TabControlPanelDemographicsTab_Demographics"
            Me.TabControlPanelDemographicsTab_Demographics.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDemographicsTab_Demographics.Size = New System.Drawing.Size(790, 370)
            Me.TabControlPanelDemographicsTab_Demographics.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDemographicsTab_Demographics.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDemographicsTab_Demographics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDemographicsTab_Demographics.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDemographicsTab_Demographics.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDemographicsTab_Demographics.Style.GradientAngle = 90
            Me.TabControlPanelDemographicsTab_Demographics.TabIndex = 8
            Me.TabControlPanelDemographicsTab_Demographics.TabItem = Me.TabItemForm_DemographicsTab
            '
            'DataGridViewDemographics_Demographics
            '
            Me.DataGridViewDemographics_Demographics.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDemographics_Demographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDemographics_Demographics.AutoUpdateViewCaption = True
            Me.DataGridViewDemographics_Demographics.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDemographics_Demographics.ItemDescription = ""
            Me.DataGridViewDemographics_Demographics.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewDemographics_Demographics.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDemographics_Demographics.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDemographics_Demographics.ModifyGridRowHeight = False
            Me.DataGridViewDemographics_Demographics.MultiSelect = False
            Me.DataGridViewDemographics_Demographics.Name = "DataGridViewDemographics_Demographics"
            Me.DataGridViewDemographics_Demographics.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDemographics_Demographics.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDemographics_Demographics.ShowRowSelectionIfHidden = True
            Me.DataGridViewDemographics_Demographics.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDemographics_Demographics.Size = New System.Drawing.Size(784, 362)
            Me.DataGridViewDemographics_Demographics.TabIndex = 1
            Me.DataGridViewDemographics_Demographics.UseEmbeddedNavigator = False
            Me.DataGridViewDemographics_Demographics.ViewCaptionHeight = -1
            '
            'TabItemForm_DemographicsTab
            '
            Me.TabItemForm_DemographicsTab.AttachedControl = Me.TabControlPanelDemographicsTab_Demographics
            Me.TabItemForm_DemographicsTab.Name = "TabItemForm_DemographicsTab"
            Me.TabItemForm_DemographicsTab.Text = "Demographics"
            '
            'TabControlPanelBooksTab_Books
            '
            Me.TabControlPanelBooksTab_Books.Controls.Add(Me.DataGridViewBooks_Books)
            Me.TabControlPanelBooksTab_Books.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBooksTab_Books.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBooksTab_Books.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBooksTab_Books.Name = "TabControlPanelBooksTab_Books"
            Me.TabControlPanelBooksTab_Books.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBooksTab_Books.Size = New System.Drawing.Size(790, 370)
            Me.TabControlPanelBooksTab_Books.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBooksTab_Books.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBooksTab_Books.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBooksTab_Books.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBooksTab_Books.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBooksTab_Books.Style.GradientAngle = 90
            Me.TabControlPanelBooksTab_Books.TabIndex = 5
            Me.TabControlPanelBooksTab_Books.TabItem = Me.TabItemForm_BooksTab
            '
            'DataGridViewBooks_Books
            '
            Me.DataGridViewBooks_Books.AllowSelectGroupHeaderRow = True
            Me.DataGridViewBooks_Books.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewBooks_Books.AutoUpdateViewCaption = True
            Me.DataGridViewBooks_Books.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewBooks_Books.ItemDescription = ""
            Me.DataGridViewBooks_Books.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewBooks_Books.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewBooks_Books.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewBooks_Books.ModifyGridRowHeight = False
            Me.DataGridViewBooks_Books.MultiSelect = False
            Me.DataGridViewBooks_Books.Name = "DataGridViewBooks_Books"
            Me.DataGridViewBooks_Books.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewBooks_Books.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewBooks_Books.ShowRowSelectionIfHidden = True
            Me.DataGridViewBooks_Books.ShowSelectDeselectAllButtons = False
            Me.DataGridViewBooks_Books.Size = New System.Drawing.Size(784, 362)
            Me.DataGridViewBooks_Books.TabIndex = 0
            Me.DataGridViewBooks_Books.UseEmbeddedNavigator = False
            Me.DataGridViewBooks_Books.ViewCaptionHeight = -1
            '
            'TabItemForm_BooksTab
            '
            Me.TabItemForm_BooksTab.AttachedControl = Me.TabControlPanelBooksTab_Books
            Me.TabItemForm_BooksTab.Name = "TabItemForm_BooksTab"
            Me.TabItemForm_BooksTab.Text = "Books"
            '
            'TabControlPanelMarketStationTab_MarketStation
            '
            Me.TabControlPanelMarketStationTab_MarketStation.Controls.Add(Me.PanelForm_RightSection)
            Me.TabControlPanelMarketStationTab_MarketStation.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.TabControlPanelMarketStationTab_MarketStation.Controls.Add(Me.PanelForm_LeftSection)
            Me.TabControlPanelMarketStationTab_MarketStation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMarketStationTab_MarketStation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMarketStationTab_MarketStation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMarketStationTab_MarketStation.Name = "TabControlPanelMarketStationTab_MarketStation"
            Me.TabControlPanelMarketStationTab_MarketStation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMarketStationTab_MarketStation.Size = New System.Drawing.Size(790, 370)
            Me.TabControlPanelMarketStationTab_MarketStation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMarketStationTab_MarketStation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMarketStationTab_MarketStation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMarketStationTab_MarketStation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMarketStationTab_MarketStation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMarketStationTab_MarketStation.Style.GradientAngle = 90
            Me.TabControlPanelMarketStationTab_MarketStation.TabIndex = 3
            Me.TabControlPanelMarketStationTab_MarketStation.TabItem = Me.TabItemForm_MarketStationsTab
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Stations)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(310, 1)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(479, 368)
            Me.PanelForm_RightSection.TabIndex = 3
            '
            'DataGridViewRightSection_Stations
            '
            Me.DataGridViewRightSection_Stations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Stations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Stations.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_Stations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Stations.ItemDescription = ""
            Me.DataGridViewRightSection_Stations.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewRightSection_Stations.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightSection_Stations.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRightSection_Stations.ModifyGridRowHeight = False
            Me.DataGridViewRightSection_Stations.MultiSelect = False
            Me.DataGridViewRightSection_Stations.Name = "DataGridViewRightSection_Stations"
            Me.DataGridViewRightSection_Stations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Stations.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRightSection_Stations.ShowRowSelectionIfHidden = True
            Me.DataGridViewRightSection_Stations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Stations.Size = New System.Drawing.Size(467, 356)
            Me.DataGridViewRightSection_Stations.TabIndex = 1
            Me.DataGridViewRightSection_Stations.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Stations.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(304, 1)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 368)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 2
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Markets)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(303, 368)
            Me.PanelForm_LeftSection.TabIndex = 1
            '
            'DataGridViewLeftSection_Markets
            '
            Me.DataGridViewLeftSection_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Markets.ItemDescription = ""
            Me.DataGridViewLeftSection_Markets.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_Markets.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLeftSection_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_Markets.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_Markets.MultiSelect = False
            Me.DataGridViewLeftSection_Markets.Name = "DataGridViewLeftSection_Markets"
            Me.DataGridViewLeftSection_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Markets.Size = New System.Drawing.Size(291, 356)
            Me.DataGridViewLeftSection_Markets.TabIndex = 1
            Me.DataGridViewLeftSection_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Markets.ViewCaptionHeight = -1
            '
            'TabItemForm_MarketStationsTab
            '
            Me.TabItemForm_MarketStationsTab.AttachedControl = Me.TabControlPanelMarketStationTab_MarketStation
            Me.TabItemForm_MarketStationsTab.Name = "TabItemForm_MarketStationsTab"
            Me.TabItemForm_MarketStationsTab.Text = "Market / Stations"
            '
            'TabItemForm_CachedTab
            '
            Me.TabItemForm_CachedTab.AttachedControl = Me.TabControlPanelCachedTab_Cached
            Me.TabItemForm_CachedTab.Name = "TabItemForm_CachedTab"
            Me.TabItemForm_CachedTab.Text = "Cached"
            '
            'TabControlPanelCachedTab_Cached
            '
            Me.TabControlPanelCachedTab_Cached.Controls.Add(Me.DataGridViewCached_Cached)
            Me.TabControlPanelCachedTab_Cached.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCachedTab_Cached.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCachedTab_Cached.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCachedTab_Cached.Name = "TabControlPanelCachedTab_Cached"
            Me.TabControlPanelCachedTab_Cached.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCachedTab_Cached.Size = New System.Drawing.Size(790, 370)
            Me.TabControlPanelCachedTab_Cached.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCachedTab_Cached.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCachedTab_Cached.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCachedTab_Cached.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCachedTab_Cached.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCachedTab_Cached.Style.GradientAngle = 90
            Me.TabControlPanelCachedTab_Cached.TabIndex = 18
            Me.TabControlPanelCachedTab_Cached.TabItem = Me.TabItemForm_CachedTab
            '
            'DataGridViewCached_Cached
            '
            Me.DataGridViewCached_Cached.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCached_Cached.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCached_Cached.AutoUpdateViewCaption = True
            Me.DataGridViewCached_Cached.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCached_Cached.ItemDescription = ""
            Me.DataGridViewCached_Cached.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewCached_Cached.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewCached_Cached.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewCached_Cached.ModifyGridRowHeight = False
            Me.DataGridViewCached_Cached.MultiSelect = False
            Me.DataGridViewCached_Cached.Name = "DataGridViewCached_Cached"
            Me.DataGridViewCached_Cached.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewCached_Cached.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewCached_Cached.ShowRowSelectionIfHidden = True
            Me.DataGridViewCached_Cached.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCached_Cached.Size = New System.Drawing.Size(784, 362)
            Me.DataGridViewCached_Cached.TabIndex = 2
            Me.DataGridViewCached_Cached.UseEmbeddedNavigator = False
            Me.DataGridViewCached_Cached.ViewCaptionHeight = -1
            '
            'ComscorePrecacheForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 421)
            Me.Controls.Add(Me.TabControlForm_ComscorePrecacheDetails)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ComscorePrecacheForm"
            Me.Text = "Comscore Pre-cache Selection"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_ComscorePrecacheDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ComscorePrecacheDetails.ResumeLayout(False)
            Me.TabControlPanelDemographicsTab_Demographics.ResumeLayout(False)
            Me.TabControlPanelBooksTab_Books.ResumeLayout(False)
            Me.TabControlPanelMarketStationTab_MarketStation.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.TabControlPanelCachedTab_Cached.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Add As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlForm_ComscorePrecacheDetails As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelMarketStationTab_MarketStation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemForm_MarketStationsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDemographicsTab_Demographics As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewDemographics_Demographics As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemForm_DemographicsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBooksTab_Books As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewBooks_Books As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemForm_BooksTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelForm_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Markets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_Stations As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents TabControlPanelCachedTab_Cached As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewCached_Cached As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents TabItemForm_CachedTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace
