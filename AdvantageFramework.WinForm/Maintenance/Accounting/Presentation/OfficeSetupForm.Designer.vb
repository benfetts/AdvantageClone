Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OfficeSetupForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OfficeSetupForm))
			Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.DataGridViewLeftSection_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemDocuments_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemDocuments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_OverheadSets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemOverheadSets_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemOverheadSets_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemSalesTaxAccounts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemSalesTaxAccounts_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemSalesClassFunctionAccounts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemSalesClassFunctionAccounts_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemSalesClassFunctionAccounts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarMergeContainerForm_FunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemFunctionAccounts_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemFunctionAccounts_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemFunctionAccounts_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.OfficeControlRightSection_Office = New AdvantageFramework.WinForm.Presentation.Controls.OfficeControl()
			Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_LeftSection.SuspendLayout()
			Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelForm_RightSection.SuspendLayout()
			Me.SuspendLayout()
			'
			'ExpandableSplitterControlForm_LeftRight
			'
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
			Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
			Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
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
			Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(230, 0)
			Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
			Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 668)
			Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
			Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
			'
			'PanelForm_LeftSection
			'
			Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Offices)
			Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
			Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 668)
			Me.PanelForm_LeftSection.TabIndex = 3
			'
			'DataGridViewLeftSection_Offices
			'
			Me.DataGridViewLeftSection_Offices.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewLeftSection_Offices.AllowDragAndDrop = False
			Me.DataGridViewLeftSection_Offices.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewLeftSection_Offices.AllowSelectGroupHeaderRow = True
			Me.DataGridViewLeftSection_Offices.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewLeftSection_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewLeftSection_Offices.AutoFilterLookupColumns = False
			Me.DataGridViewLeftSection_Offices.AutoloadRepositoryDatasource = True
			Me.DataGridViewLeftSection_Offices.AutoUpdateViewCaption = True
			Me.DataGridViewLeftSection_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewLeftSection_Offices.DataSource = Nothing
			Me.DataGridViewLeftSection_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewLeftSection_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewLeftSection_Offices.ItemDescription = ""
			Me.DataGridViewLeftSection_Offices.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewLeftSection_Offices.MultiSelect = True
			Me.DataGridViewLeftSection_Offices.Name = "DataGridViewLeftSection_Offices"
			Me.DataGridViewLeftSection_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewLeftSection_Offices.RunStandardValidation = True
			Me.DataGridViewLeftSection_Offices.ShowColumnMenuOnRightClick = False
			Me.DataGridViewLeftSection_Offices.ShowSelectDeselectAllButtons = False
			Me.DataGridViewLeftSection_Offices.Size = New System.Drawing.Size(212, 644)
			Me.DataGridViewLeftSection_Offices.TabIndex = 0
			Me.DataGridViewLeftSection_Offices.UseEmbeddedNavigator = False
			Me.DataGridViewLeftSection_Offices.ViewCaptionHeight = -1
			'
			'RibbonBarMergeContainerForm_Options
			'
			Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Documents)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_OverheadSets)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_SalesTaxAccounts)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_FunctionAccounts)
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 406)
			Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
			Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
			Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1064, 98)
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
			Me.RibbonBarMergeContainerForm_Options.TabIndex = 8
			Me.RibbonBarMergeContainerForm_Options.Visible = False
			'
			'RibbonBarOptions_Documents
			'
			Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Documents.DragDropSupport = True
			Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
			Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(790, 0)
			Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
			Me.RibbonBarOptions_Documents.SecurityEnabled = True
			Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(219, 98)
			Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Documents.TabIndex = 8
			Me.RibbonBarOptions_Documents.Text = "Documents"
			'
			'
			'
			Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemDocuments_Upload
			'
			Me.ButtonItemDocuments_Upload.BeginGroup = True
			Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
			Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
			Me.ButtonItemDocuments_Upload.SecurityEnabled = True
			Me.ButtonItemDocuments_Upload.SplitButton = True
			Me.ButtonItemDocuments_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
			Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Upload.Text = "Upload"
			'
			'ButtonItemDocuments_Download
			'
			Me.ButtonItemDocuments_Download.BeginGroup = True
			Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
			Me.ButtonItemDocuments_Download.RibbonWordWrap = False
			Me.ButtonItemDocuments_Download.SecurityEnabled = True
			Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Download.Text = "Download"
			'
			'ButtonItemDocuments_OpenURL
			'
			Me.ButtonItemDocuments_OpenURL.BeginGroup = True
			Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
			Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
			Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
			Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
			'
			'ButtonItemDocuments_Delete
			'
			Me.ButtonItemDocuments_Delete.BeginGroup = True
			Me.ButtonItemDocuments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemDocuments_Delete.Name = "ButtonItemDocuments_Delete"
			Me.ButtonItemDocuments_Delete.RibbonWordWrap = False
			Me.ButtonItemDocuments_Delete.SecurityEnabled = True
			Me.ButtonItemDocuments_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemDocuments_Delete.Text = "Delete"
			'
			'RibbonBarMergeContainerForm_OverheadSets
			'
			Me.RibbonBarMergeContainerForm_OverheadSets.AutoOverflowEnabled = True
			'
			'
			'
			Me.RibbonBarMergeContainerForm_OverheadSets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_OverheadSets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_OverheadSets.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_OverheadSets.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_OverheadSets.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_OverheadSets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOverheadSets_Delete, Me.ButtonItemOverheadSets_Cancel})
			Me.RibbonBarMergeContainerForm_OverheadSets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_OverheadSets.Location = New System.Drawing.Point(673, 0)
			Me.RibbonBarMergeContainerForm_OverheadSets.Name = "RibbonBarMergeContainerForm_OverheadSets"
			Me.RibbonBarMergeContainerForm_OverheadSets.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_OverheadSets.Size = New System.Drawing.Size(117, 98)
			Me.RibbonBarMergeContainerForm_OverheadSets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_OverheadSets.TabIndex = 9
			Me.RibbonBarMergeContainerForm_OverheadSets.Text = "Overhead Sets"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_OverheadSets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_OverheadSets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_OverheadSets.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemOverheadSets_Delete
			'
			Me.ButtonItemOverheadSets_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemOverheadSets_Delete.Name = "ButtonItemOverheadSets_Delete"
			Me.ButtonItemOverheadSets_Delete.RibbonWordWrap = False
			Me.ButtonItemOverheadSets_Delete.SecurityEnabled = True
			Me.ButtonItemOverheadSets_Delete.Stretch = True
			Me.ButtonItemOverheadSets_Delete.Text = "Delete"
			'
			'ButtonItemOverheadSets_Cancel
			'
			Me.ButtonItemOverheadSets_Cancel.BeginGroup = True
			Me.ButtonItemOverheadSets_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemOverheadSets_Cancel.Name = "ButtonItemOverheadSets_Cancel"
			Me.ButtonItemOverheadSets_Cancel.SecurityEnabled = True
			Me.ButtonItemOverheadSets_Cancel.Text = "Cancel"
			'
			'RibbonBarMergeContainerForm_SalesTaxAccounts
			'
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.AutoOverflowEnabled = True
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSalesTaxAccounts_Delete, Me.ButtonItemSalesTaxAccounts_Cancel})
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Location = New System.Drawing.Point(556, 0)
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Name = "RibbonBarMergeContainerForm_SalesTaxAccounts"
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Size = New System.Drawing.Size(117, 98)
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.TabIndex = 6
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.Text = "Sales Tax Accounts"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_SalesTaxAccounts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemSalesTaxAccounts_Delete
			'
			Me.ButtonItemSalesTaxAccounts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSalesTaxAccounts_Delete.Name = "ButtonItemSalesTaxAccounts_Delete"
			Me.ButtonItemSalesTaxAccounts_Delete.RibbonWordWrap = False
			Me.ButtonItemSalesTaxAccounts_Delete.SecurityEnabled = True
			Me.ButtonItemSalesTaxAccounts_Delete.Stretch = True
			Me.ButtonItemSalesTaxAccounts_Delete.Text = "Delete"
			'
			'ButtonItemSalesTaxAccounts_Cancel
			'
			Me.ButtonItemSalesTaxAccounts_Cancel.BeginGroup = True
			Me.ButtonItemSalesTaxAccounts_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSalesTaxAccounts_Cancel.Name = "ButtonItemSalesTaxAccounts_Cancel"
			Me.ButtonItemSalesTaxAccounts_Cancel.SecurityEnabled = True
			Me.ButtonItemSalesTaxAccounts_Cancel.Text = "Cancel"
			'
			'RibbonBarMergeContainerForm_SalesClassFunctionAccounts
			'
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.AutoOverflowEnabled = True
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSalesClassFunctionAccounts_Delete, Me.ButtonItemSalesClassFunctionAccounts_Cancel, Me.ButtonItemSalesClassFunctionAccounts_Copy})
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Location = New System.Drawing.Point(397, 0)
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Name = "RibbonBarMergeContainerForm_SalesClassFunctionAccounts"
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Size = New System.Drawing.Size(159, 98)
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.TabIndex = 5
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.Text = "Sales Class Function Accounts"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_SalesClassFunctionAccounts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemSalesClassFunctionAccounts_Delete
			'
			Me.ButtonItemSalesClassFunctionAccounts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSalesClassFunctionAccounts_Delete.Name = "ButtonItemSalesClassFunctionAccounts_Delete"
			Me.ButtonItemSalesClassFunctionAccounts_Delete.SecurityEnabled = True
			Me.ButtonItemSalesClassFunctionAccounts_Delete.Text = "Delete"
			'
			'ButtonItemSalesClassFunctionAccounts_Cancel
			'
			Me.ButtonItemSalesClassFunctionAccounts_Cancel.BeginGroup = True
			Me.ButtonItemSalesClassFunctionAccounts_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSalesClassFunctionAccounts_Cancel.Name = "ButtonItemSalesClassFunctionAccounts_Cancel"
			Me.ButtonItemSalesClassFunctionAccounts_Cancel.SecurityEnabled = True
			Me.ButtonItemSalesClassFunctionAccounts_Cancel.Text = "Cancel"
			'
			'ButtonItemSalesClassFunctionAccounts_Copy
			'
			Me.ButtonItemSalesClassFunctionAccounts_Copy.BeginGroup = True
			Me.ButtonItemSalesClassFunctionAccounts_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemSalesClassFunctionAccounts_Copy.Name = "ButtonItemSalesClassFunctionAccounts_Copy"
			Me.ButtonItemSalesClassFunctionAccounts_Copy.SecurityEnabled = True
			Me.ButtonItemSalesClassFunctionAccounts_Copy.Text = "Copy"
			'
			'RibbonBarMergeContainerForm_FunctionAccounts
			'
			Me.RibbonBarMergeContainerForm_FunctionAccounts.AutoOverflowEnabled = True
			'
			'
			'
			Me.RibbonBarMergeContainerForm_FunctionAccounts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_FunctionAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_FunctionAccounts.ContainerControlProcessDialogKey = True
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarMergeContainerForm_FunctionAccounts.DragDropSupport = True
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFunctionAccounts_Delete, Me.ButtonItemFunctionAccounts_Cancel, Me.ButtonItemFunctionAccounts_Copy})
			Me.RibbonBarMergeContainerForm_FunctionAccounts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Location = New System.Drawing.Point(245, 0)
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Name = "RibbonBarMergeContainerForm_FunctionAccounts"
			Me.RibbonBarMergeContainerForm_FunctionAccounts.SecurityEnabled = True
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Size = New System.Drawing.Size(152, 98)
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_FunctionAccounts.TabIndex = 4
			Me.RibbonBarMergeContainerForm_FunctionAccounts.Text = "Function Accounts"
			'
			'
			'
			Me.RibbonBarMergeContainerForm_FunctionAccounts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_FunctionAccounts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_FunctionAccounts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
			'
			'ButtonItemFunctionAccounts_Delete
			'
			Me.ButtonItemFunctionAccounts_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFunctionAccounts_Delete.Name = "ButtonItemFunctionAccounts_Delete"
			Me.ButtonItemFunctionAccounts_Delete.RibbonWordWrap = False
			Me.ButtonItemFunctionAccounts_Delete.SecurityEnabled = True
			Me.ButtonItemFunctionAccounts_Delete.Stretch = True
			Me.ButtonItemFunctionAccounts_Delete.Text = "Delete"
			'
			'ButtonItemFunctionAccounts_Cancel
			'
			Me.ButtonItemFunctionAccounts_Cancel.BeginGroup = True
			Me.ButtonItemFunctionAccounts_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFunctionAccounts_Cancel.Name = "ButtonItemFunctionAccounts_Cancel"
			Me.ButtonItemFunctionAccounts_Cancel.SecurityEnabled = True
			Me.ButtonItemFunctionAccounts_Cancel.Text = "Cancel"
			'
			'ButtonItemFunctionAccounts_Copy
			'
			Me.ButtonItemFunctionAccounts_Copy.BeginGroup = True
			Me.ButtonItemFunctionAccounts_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemFunctionAccounts_Copy.Name = "ButtonItemFunctionAccounts_Copy"
			Me.ButtonItemFunctionAccounts_Copy.SecurityEnabled = True
			Me.ButtonItemFunctionAccounts_Copy.Text = "Copy"
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
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Refresh})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(245, 98)
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
			Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
			Me.ButtonItemActions_Export.RibbonWordWrap = False
			Me.ButtonItemActions_Export.SecurityEnabled = True
			Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Export.Text = "Export"
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
			'ButtonItemActions_Refresh
			'
			Me.ButtonItemActions_Refresh.BeginGroup = True
			Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
			Me.ButtonItemActions_Refresh.RibbonWordWrap = False
			Me.ButtonItemActions_Refresh.SecurityEnabled = True
			Me.ButtonItemActions_Refresh.Stretch = True
			Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Refresh.Text = "Refresh"
			'
			'PanelForm_RightSection
			'
			Me.PanelForm_RightSection.Controls.Add(Me.OfficeControlRightSection_Office)
			Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
			Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
			Me.PanelForm_RightSection.Size = New System.Drawing.Size(947, 668)
			Me.PanelForm_RightSection.TabIndex = 5
			'
			'OfficeControlRightSection_Office
			'
			Me.OfficeControlRightSection_Office.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.OfficeControlRightSection_Office.Location = New System.Drawing.Point(6, 12)
			Me.OfficeControlRightSection_Office.Name = "OfficeControlRightSection_Office"
			Me.OfficeControlRightSection_Office.Size = New System.Drawing.Size(929, 644)
			Me.OfficeControlRightSection_Office.TabIndex = 0
			'
			'ButtonItemUpload_EmailLink
			'
			Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
			Me.ButtonItemUpload_EmailLink.Text = "Email Link"
			'
			'OfficeSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1183, 668)
			Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
			Me.Controls.Add(Me.PanelForm_RightSection)
			Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
			Me.Controls.Add(Me.PanelForm_LeftSection)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "OfficeSetupForm"
			Me.Text = "Office Maintenance"
			CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_LeftSection.ResumeLayout(False)
			Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
			CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelForm_RightSection.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_SalesClassFunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSalesClassFunctionAccounts_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSalesClassFunctionAccounts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_FunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFunctionAccounts_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFunctionAccounts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents OfficeControlRightSection_Office As AdvantageFramework.WinForm.Presentation.Controls.OfficeControl
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSalesClassFunctionAccounts_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_SalesTaxAccounts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSalesTaxAccounts_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSalesTaxAccounts_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_OverheadSets As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOverheadSets_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOverheadSets_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFunctionAccounts_Copy As WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
	End Class

End Namespace