Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IncomeOnlyForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncomeOnlyForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_View = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.IncomeOnlyControlRightSection_IncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.IncomeOnlyControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ServiceFees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemServiceFees_Generate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemServiceFees_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemContracts_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemContracts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_IncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemIncomeOnly_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_ClearFilters = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ShowAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSearch_Search = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemSearch_Search = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ItemContainerSearch_SearchBy = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearch_SelectBy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSearch_SelectAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemServiceFees_GenerateAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_View)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 502)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_View
            '
            Me.DataGridViewLeftSection_View.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_View.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_View.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_View.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_View.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_View.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_View.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_View.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_View.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_View.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_View.ItemDescription = ""
            Me.DataGridViewLeftSection_View.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_View.MultiSelect = True
            Me.DataGridViewLeftSection_View.Name = "DataGridViewLeftSection_View"
            Me.DataGridViewLeftSection_View.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_View.RunStandardValidation = True
            Me.DataGridViewLeftSection_View.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_View.Size = New System.Drawing.Size(180, 478)
            Me.DataGridViewLeftSection_View.TabIndex = 0
            Me.DataGridViewLeftSection_View.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_View.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 502)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.IncomeOnlyControlRightSection_IncomeOnly)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(203, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1050, 502)
            Me.PanelForm_RightSection.TabIndex = 1
            '
            'IncomeOnlyControlRightSection_IncomeOnly
            '
            Me.IncomeOnlyControlRightSection_IncomeOnly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.IncomeOnlyControlRightSection_IncomeOnly.Location = New System.Drawing.Point(6, 12)
            Me.IncomeOnlyControlRightSection_IncomeOnly.Name = "IncomeOnlyControlRightSection_IncomeOnly"
            Me.IncomeOnlyControlRightSection_IncomeOnly.ShowDescriptions = False
            Me.IncomeOnlyControlRightSection_IncomeOnly.Size = New System.Drawing.Size(1032, 478)
            Me.IncomeOnlyControlRightSection_IncomeOnly.TabIndex = 0
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ServiceFees)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Contracts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_IncomeOnly)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(32, 64)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1198, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_ServiceFees
            '
            Me.RibbonBarOptions_ServiceFees.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ServiceFees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ServiceFees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ServiceFees.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ServiceFees.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ServiceFees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemServiceFees_Generate, Me.ButtonItemServiceFees_GenerateAll, Me.ButtonItemServiceFees_View})
            Me.RibbonBarOptions_ServiceFees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ServiceFees.Location = New System.Drawing.Point(906, 0)
            Me.RibbonBarOptions_ServiceFees.Name = "RibbonBarOptions_ServiceFees"
            Me.RibbonBarOptions_ServiceFees.SecurityEnabled = True
            Me.RibbonBarOptions_ServiceFees.Size = New System.Drawing.Size(241, 98)
            Me.RibbonBarOptions_ServiceFees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ServiceFees.TabIndex = 4
            Me.RibbonBarOptions_ServiceFees.Text = "Service Fees"
            '
            '
            '
            Me.RibbonBarOptions_ServiceFees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ServiceFees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ServiceFees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemServiceFees_Generate
            '
            Me.ButtonItemServiceFees_Generate.BeginGroup = True
            Me.ButtonItemServiceFees_Generate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemServiceFees_Generate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemServiceFees_Generate.Name = "ButtonItemServiceFees_Generate"
            Me.ButtonItemServiceFees_Generate.RibbonWordWrap = False
            Me.ButtonItemServiceFees_Generate.SecurityEnabled = True
            Me.ButtonItemServiceFees_Generate.Stretch = True
            Me.ButtonItemServiceFees_Generate.SubItemsExpandWidth = 14
            Me.ButtonItemServiceFees_Generate.Text = "Generate Fees"
            '
            'ButtonItemServiceFees_View
            '
            Me.ButtonItemServiceFees_View.BeginGroup = True
            Me.ButtonItemServiceFees_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemServiceFees_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemServiceFees_View.Name = "ButtonItemServiceFees_View"
            Me.ButtonItemServiceFees_View.RibbonWordWrap = False
            Me.ButtonItemServiceFees_View.SecurityEnabled = True
            Me.ButtonItemServiceFees_View.Stretch = True
            Me.ButtonItemServiceFees_View.SubItemsExpandWidth = 14
            Me.ButtonItemServiceFees_View.Text = "View"
            '
            'RibbonBarOptions_Contracts
            '
            Me.RibbonBarOptions_Contracts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Contracts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contracts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contracts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Contracts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Contracts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemContracts_Add, Me.ButtonItemContracts_Copy, Me.ButtonItemContracts_Delete})
            Me.RibbonBarOptions_Contracts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Contracts.Location = New System.Drawing.Point(792, 0)
            Me.RibbonBarOptions_Contracts.Name = "RibbonBarOptions_Contracts"
            Me.RibbonBarOptions_Contracts.SecurityEnabled = True
            Me.RibbonBarOptions_Contracts.Size = New System.Drawing.Size(114, 98)
            Me.RibbonBarOptions_Contracts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Contracts.TabIndex = 3
            Me.RibbonBarOptions_Contracts.Text = "Service Fee Contract"
            '
            '
            '
            Me.RibbonBarOptions_Contracts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Contracts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Contracts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemContracts_Add
            '
            Me.ButtonItemContracts_Add.BeginGroup = True
            Me.ButtonItemContracts_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemContracts_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Add.Name = "ButtonItemContracts_Add"
            Me.ButtonItemContracts_Add.RibbonWordWrap = False
            Me.ButtonItemContracts_Add.SecurityEnabled = True
            Me.ButtonItemContracts_Add.Stretch = True
            Me.ButtonItemContracts_Add.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Add.Text = "Add"
            '
            'ButtonItemContracts_Copy
            '
            Me.ButtonItemContracts_Copy.BeginGroup = True
            Me.ButtonItemContracts_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemContracts_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Copy.Name = "ButtonItemContracts_Copy"
            Me.ButtonItemContracts_Copy.RibbonWordWrap = False
            Me.ButtonItemContracts_Copy.SecurityEnabled = True
            Me.ButtonItemContracts_Copy.Stretch = True
            Me.ButtonItemContracts_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Copy.Text = "Copy"
            '
            'ButtonItemContracts_Delete
            '
            Me.ButtonItemContracts_Delete.BeginGroup = True
            Me.ButtonItemContracts_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemContracts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemContracts_Delete.Name = "ButtonItemContracts_Delete"
            Me.ButtonItemContracts_Delete.RibbonWordWrap = False
            Me.ButtonItemContracts_Delete.SecurityEnabled = True
            Me.ButtonItemContracts_Delete.Stretch = True
            Me.ButtonItemContracts_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemContracts_Delete.Text = "Delete"
            '
            'RibbonBarOptions_IncomeOnly
            '
            Me.RibbonBarOptions_IncomeOnly.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeOnly.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_IncomeOnly.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_IncomeOnly.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIncomeOnly_Copy, Me.ButtonItemIncomeOnly_CopyFrom, Me.ButtonItemIncomeOnly_CopyTo, Me.ButtonItemIncomeOnly_Delete, Me.ButtonItemIncomeOnly_Cancel, Me.ButtonItemIncomeOnly_ClearFilters})
            Me.RibbonBarOptions_IncomeOnly.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_IncomeOnly.Location = New System.Drawing.Point(482, 0)
            Me.RibbonBarOptions_IncomeOnly.Name = "RibbonBarOptions_IncomeOnly"
            Me.RibbonBarOptions_IncomeOnly.SecurityEnabled = True
            Me.RibbonBarOptions_IncomeOnly.Size = New System.Drawing.Size(310, 98)
            Me.RibbonBarOptions_IncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_IncomeOnly.TabIndex = 2
            Me.RibbonBarOptions_IncomeOnly.Text = "Income Only"
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeOnly.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemIncomeOnly_Copy
            '
            Me.ButtonItemIncomeOnly_Copy.BeginGroup = True
            Me.ButtonItemIncomeOnly_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_Copy.Name = "ButtonItemIncomeOnly_Copy"
            Me.ButtonItemIncomeOnly_Copy.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_Copy.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_Copy.Stretch = True
            Me.ButtonItemIncomeOnly_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_Copy.Text = "Copy"
            '
            'ButtonItemIncomeOnly_CopyFrom
            '
            Me.ButtonItemIncomeOnly_CopyFrom.BeginGroup = True
            Me.ButtonItemIncomeOnly_CopyFrom.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_CopyFrom.Name = "ButtonItemIncomeOnly_CopyFrom"
            Me.ButtonItemIncomeOnly_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_CopyFrom.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_CopyFrom.Stretch = True
            Me.ButtonItemIncomeOnly_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_CopyFrom.Text = "Copy From"
            '
            'ButtonItemIncomeOnly_CopyTo
            '
            Me.ButtonItemIncomeOnly_CopyTo.BeginGroup = True
            Me.ButtonItemIncomeOnly_CopyTo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_CopyTo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_CopyTo.Name = "ButtonItemIncomeOnly_CopyTo"
            Me.ButtonItemIncomeOnly_CopyTo.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_CopyTo.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_CopyTo.Stretch = True
            Me.ButtonItemIncomeOnly_CopyTo.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_CopyTo.Text = "Copy To"
            '
            'ButtonItemIncomeOnly_Delete
            '
            Me.ButtonItemIncomeOnly_Delete.BeginGroup = True
            Me.ButtonItemIncomeOnly_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_Delete.Name = "ButtonItemIncomeOnly_Delete"
            Me.ButtonItemIncomeOnly_Delete.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_Delete.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_Delete.Stretch = True
            Me.ButtonItemIncomeOnly_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_Delete.Text = "Delete"
            '
            'ButtonItemIncomeOnly_Cancel
            '
            Me.ButtonItemIncomeOnly_Cancel.BeginGroup = True
            Me.ButtonItemIncomeOnly_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_Cancel.Name = "ButtonItemIncomeOnly_Cancel"
            Me.ButtonItemIncomeOnly_Cancel.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_Cancel.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_Cancel.Stretch = True
            Me.ButtonItemIncomeOnly_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_Cancel.Text = "Cancel"
            '
            'ButtonItemIncomeOnly_ClearFilters
            '
            Me.ButtonItemIncomeOnly_ClearFilters.BeginGroup = True
            Me.ButtonItemIncomeOnly_ClearFilters.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_ClearFilters.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_ClearFilters.Name = "ButtonItemIncomeOnly_ClearFilters"
            Me.ButtonItemIncomeOnly_ClearFilters.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_ClearFilters.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_ClearFilters.Stretch = True
            Me.ButtonItemIncomeOnly_ClearFilters.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_ClearFilters.Text = "Clear Filters"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Print, Me.ButtonItemActions_ShowAll, Me.ButtonItemActions_ShowDescriptions, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(200, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(282, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
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
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_ShowAll
            '
            Me.ButtonItemActions_ShowAll.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowAll.BeginGroup = True
            Me.ButtonItemActions_ShowAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ShowAll.Name = "ButtonItemActions_ShowAll"
            Me.ButtonItemActions_ShowAll.RibbonWordWrap = False
            Me.ButtonItemActions_ShowAll.SecurityEnabled = True
            Me.ButtonItemActions_ShowAll.Stretch = True
            Me.ButtonItemActions_ShowAll.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowAll.Text = "Show All"
            '
            'ButtonItemActions_ShowDescriptions
            '
            Me.ButtonItemActions_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowDescriptions.BeginGroup = True
            Me.ButtonItemActions_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ShowDescriptions.Name = "ButtonItemActions_ShowDescriptions"
            Me.ButtonItemActions_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemActions_ShowDescriptions.SecurityEnabled = True
            Me.ButtonItemActions_ShowDescriptions.Stretch = True
            Me.ButtonItemActions_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowDescriptions.Text = "Show Descriptions"
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
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Search, Me.ItemContainerSearch_SearchBy})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(200, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 0
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerSearch_Search
            '
            '
            '
            '
            Me.ItemContainerSearch_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Search.FixedSize = New System.Drawing.Size(135, 0)
            Me.ItemContainerSearch_Search.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_Search.Name = "ItemContainerSearch_Search"
            Me.ItemContainerSearch_Search.ResizeItemsToFit = False
            Me.ItemContainerSearch_Search.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemSearch_Search})
            '
            '
            '
            Me.ItemContainerSearch_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemSearch_Search
            '
            Me.ComboBoxItemSearch_Search.ComboWidth = 125
            Me.ComboBoxItemSearch_Search.DropDownHeight = 106
            Me.ComboBoxItemSearch_Search.Name = "ComboBoxItemSearch_Search"
            Me.ComboBoxItemSearch_Search.Text = "ComboBoxItem1"
            '
            'ItemContainerSearch_SearchBy
            '
            '
            '
            '
            Me.ItemContainerSearch_SearchBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_SearchBy.BeginGroup = True
            Me.ItemContainerSearch_SearchBy.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_SearchBy.Name = "ItemContainerSearch_SearchBy"
            Me.ItemContainerSearch_SearchBy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearch_SelectBy, Me.ButtonItemSearch_SelectAll})
            '
            '
            '
            Me.ItemContainerSearch_SearchBy.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_SearchBy.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSearch_SelectBy
            '
            Me.ButtonItemSearch_SelectBy.AutoCheckOnClick = True
            Me.ButtonItemSearch_SelectBy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_SelectBy.Checked = True
            Me.ButtonItemSearch_SelectBy.Name = "ButtonItemSearch_SelectBy"
            Me.ButtonItemSearch_SelectBy.OptionGroup = "SearchFilter"
            Me.ButtonItemSearch_SelectBy.RibbonWordWrap = False
            Me.ButtonItemSearch_SelectBy.Stretch = True
            Me.ButtonItemSearch_SelectBy.Text = "Select By"
            '
            'ButtonItemSearch_SelectAll
            '
            Me.ButtonItemSearch_SelectAll.AutoCheckOnClick = True
            Me.ButtonItemSearch_SelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_SelectAll.Name = "ButtonItemSearch_SelectAll"
            Me.ButtonItemSearch_SelectAll.OptionGroup = "SearchFilter"
            Me.ButtonItemSearch_SelectAll.RibbonWordWrap = False
            Me.ButtonItemSearch_SelectAll.Stretch = True
            Me.ButtonItemSearch_SelectAll.Text = "Select All"
            '
            'ButtonItemServiceFees_GenerateAll
            '
            Me.ButtonItemServiceFees_GenerateAll.BeginGroup = True
            Me.ButtonItemServiceFees_GenerateAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemServiceFees_GenerateAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemServiceFees_GenerateAll.Name = "ButtonItemServiceFees_GenerateAll"
            Me.ButtonItemServiceFees_GenerateAll.RibbonWordWrap = False
            Me.ButtonItemServiceFees_GenerateAll.SecurityEnabled = True
            Me.ButtonItemServiceFees_GenerateAll.Stretch = True
            Me.ButtonItemServiceFees_GenerateAll.SubItemsExpandWidth = 14
            Me.ButtonItemServiceFees_GenerateAll.Text = "Generate Fees (All)"
            '
            'IncomeOnlyForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1253, 502)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "IncomeOnlyForm"
            Me.Text = "Income Only"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_View As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_IncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemIncomeOnly_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents IncomeOnlyControlRightSection_IncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.IncomeOnlyControl
        Friend WithEvents ButtonItemIncomeOnly_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSearch_Search As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemSearch_Search As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemIncomeOnly_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_CopyTo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ItemContainerSearch_SearchBy As DevComponents.DotNetBar.ItemContainer
        Private WithEvents ButtonItemSearch_SelectBy As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemSearch_SelectAll As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_ShowDescriptions As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Contracts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemContracts_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_ClearFilters As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemContracts_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ServiceFees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemServiceFees_Generate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemServiceFees_View As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_ShowAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemServiceFees_GenerateAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

