Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DivisionSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DivisionSetupForm))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DivisionControlRightSection_Division = New AdvantageFramework.WinForm.Presentation.Controls.DivisionControl()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Divisions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_SortOptions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemSortOptions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSortOptions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Documents = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemDocuments_Upload = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Download = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_ProductActions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemProduct_Actions = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProductActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAddProduct_New = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAddProduct_CopyFrom = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAddProduct_CopyTo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProductActions_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProductActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDocuments_Delete = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DivisionControlRightSection_Division)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(704, 533)
            Me.PanelForm_RightSection.TabIndex = 5
            '
            'DivisionControlRightSection_Division
            '
            Me.DivisionControlRightSection_Division.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DivisionControlRightSection_Division.Location = New System.Drawing.Point(6, 12)
            Me.DivisionControlRightSection_Division.Name = "DivisionControlRightSection_Division"
            Me.DivisionControlRightSection_Division.Size = New System.Drawing.Size(686, 509)
            Me.DivisionControlRightSection_Division.TabIndex = 5
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
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 533)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Divisions)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 533)
            Me.PanelForm_LeftSection.TabIndex = 3
            '
            'DataGridViewLeftSection_Divisions
            '
            Me.DataGridViewLeftSection_Divisions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Divisions.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Divisions.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Divisions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Divisions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Divisions.ItemDescription = ""
            Me.DataGridViewLeftSection_Divisions.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Divisions.MultiSelect = True
            Me.DataGridViewLeftSection_Divisions.Name = "DataGridViewLeftSection_Divisions"
            Me.DataGridViewLeftSection_Divisions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Divisions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Divisions.Size = New System.Drawing.Size(212, 509)
            Me.DataGridViewLeftSection_Divisions.TabIndex = 0
            Me.DataGridViewLeftSection_Divisions.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Divisions.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_SortOptions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_Documents)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarMergeContainerForm_ProductActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(548, 98)
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
            'RibbonBarOptions_SortOptions
            '
            Me.RibbonBarOptions_SortOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SortOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SortOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SortOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SortOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SortOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSortOptions_Delete, Me.ButtonItemSortOptions_Cancel})
            Me.RibbonBarOptions_SortOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SortOptions.Location = New System.Drawing.Point(433, 0)
            Me.RibbonBarOptions_SortOptions.Name = "RibbonBarOptions_SortOptions"
            Me.RibbonBarOptions_SortOptions.Size = New System.Drawing.Size(98, 98)
            Me.RibbonBarOptions_SortOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SortOptions.TabIndex = 6
            Me.RibbonBarOptions_SortOptions.Text = "Sort Options"
            '
            '
            '
            Me.RibbonBarOptions_SortOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SortOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SortOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSortOptions_Delete
            '
            Me.ButtonItemSortOptions_Delete.BeginGroup = True
            Me.ButtonItemSortOptions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSortOptions_Delete.Name = "ButtonItemSortOptions_Delete"
            Me.ButtonItemSortOptions_Delete.RibbonWordWrap = False
            Me.ButtonItemSortOptions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemSortOptions_Delete.Text = "Delete"
            '
            'ButtonItemSortOptions_Cancel
            '
            Me.ButtonItemSortOptions_Cancel.BeginGroup = True
            Me.ButtonItemSortOptions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSortOptions_Cancel.Name = "ButtonItemSortOptions_Cancel"
            Me.ButtonItemSortOptions_Cancel.RibbonWordWrap = False
            Me.ButtonItemSortOptions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemSortOptions_Cancel.Text = "Cancel"
            '
            'RibbonBarMergeContainerForm_Documents
            '
            Me.RibbonBarMergeContainerForm_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarMergeContainerForm_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarMergeContainerForm_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Upload, Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL, Me.ButtonItemDocuments_Delete})
            Me.RibbonBarMergeContainerForm_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarMergeContainerForm_Documents.Location = New System.Drawing.Point(216, 0)
            Me.RibbonBarMergeContainerForm_Documents.Name = "RibbonBarMergeContainerForm_Documents"
            Me.RibbonBarMergeContainerForm_Documents.Size = New System.Drawing.Size(217, 98)
            Me.RibbonBarMergeContainerForm_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Documents.TabIndex = 5
            Me.RibbonBarMergeContainerForm_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDocuments_Upload
            '
            Me.ButtonItemDocuments_Upload.BeginGroup = True
            Me.ButtonItemDocuments_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Upload.Name = "ButtonItemDocuments_Upload"
            Me.ButtonItemDocuments_Upload.RibbonWordWrap = False
            Me.ButtonItemDocuments_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Upload.Text = "Upload"
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
            '
            'ButtonItemDocuments_OpenURL
            '
            Me.ButtonItemDocuments_OpenURL.BeginGroup = True
            Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
            Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
            Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
            '
            'RibbonBarMergeContainerForm_ProductActions
            '
            Me.RibbonBarMergeContainerForm_ProductActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ProductActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ProductActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_ProductActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarMergeContainerForm_ProductActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarMergeContainerForm_ProductActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProduct_Actions})
            Me.RibbonBarMergeContainerForm_ProductActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarMergeContainerForm_ProductActions.Location = New System.Drawing.Point(145, 0)
            Me.RibbonBarMergeContainerForm_ProductActions.Name = "RibbonBarMergeContainerForm_ProductActions"
            Me.RibbonBarMergeContainerForm_ProductActions.Size = New System.Drawing.Size(71, 98)
            Me.RibbonBarMergeContainerForm_ProductActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_ProductActions.TabIndex = 3
            Me.RibbonBarMergeContainerForm_ProductActions.Text = "Product"
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ProductActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ProductActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_ProductActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemProduct_Actions
            '
            Me.ButtonItemProduct_Actions.AutoExpandOnClick = True
            Me.ButtonItemProduct_Actions.BeginGroup = True
            Me.ButtonItemProduct_Actions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Actions.Name = "ButtonItemProduct_Actions"
            Me.ButtonItemProduct_Actions.RibbonWordWrap = False
            Me.ButtonItemProduct_Actions.SplitButton = True
            Me.ButtonItemProduct_Actions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProductActions_Add, Me.ButtonItemProductActions_Edit, Me.ButtonItemProductActions_Delete})
            Me.ButtonItemProduct_Actions.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Actions.Text = "Actions"
            '
            'ButtonItemProductActions_Add
            '
            Me.ButtonItemProductActions_Add.Name = "ButtonItemProductActions_Add"
            Me.ButtonItemProductActions_Add.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAddProduct_New, Me.ButtonItemAddProduct_CopyFrom, Me.ButtonItemAddProduct_CopyTo})
            Me.ButtonItemProductActions_Add.Text = "Add"
            '
            'ButtonItemAddProduct_New
            '
            Me.ButtonItemAddProduct_New.Name = "ButtonItemAddProduct_New"
            Me.ButtonItemAddProduct_New.Text = "New"
            '
            'ButtonItemAddProduct_CopyFrom
            '
            Me.ButtonItemAddProduct_CopyFrom.Name = "ButtonItemAddProduct_CopyFrom"
            Me.ButtonItemAddProduct_CopyFrom.Text = "Copy From"
            '
            'ButtonItemAddProduct_CopyTo
            '
            Me.ButtonItemAddProduct_CopyTo.Name = "ButtonItemAddProduct_CopyTo"
            Me.ButtonItemAddProduct_CopyTo.Text = "Copy To"
            '
            'ButtonItemProductActions_Edit
            '
            Me.ButtonItemProductActions_Edit.Name = "ButtonItemProductActions_Edit"
            Me.ButtonItemProductActions_Edit.Text = "Edit"
            '
            'ButtonItemProductActions_Delete
            '
            Me.ButtonItemProductActions_Delete.Name = "ButtonItemProductActions_Delete"
            Me.ButtonItemProductActions_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(145, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItem3
            '
            Me.ButtonItem3.BeginGroup = True
            Me.ButtonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItem3.Name = "ButtonItem3"
            Me.ButtonItem3.RibbonWordWrap = False
            Me.ButtonItem3.SubItemsExpandWidth = 14
            Me.ButtonItem3.Text = "Delete"
            '
            'ButtonItemDocuments_Delete
            '
            Me.ButtonItemDocuments_Delete.BeginGroup = True
            Me.ButtonItemDocuments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Delete.Name = "ButtonItemDocuments_Delete"
            Me.ButtonItemDocuments_Delete.RibbonWordWrap = False
            Me.ButtonItemDocuments_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Delete.Text = "Delete"
            '
            'DivisionSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(940, 533)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DivisionSetupForm"
            Me.Text = "Division Setup"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Divisions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DivisionControlRightSection_Division As AdvantageFramework.WinForm.Presentation.Controls.DivisionControl
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_ProductActions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemProduct_Actions As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProductActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAddProduct_New As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProductActions_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProductActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAddProduct_CopyTo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAddProduct_CopyFrom As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarMergeContainerForm_Documents As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBarOptions_SortOptions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemSortOptions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSortOptions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_Upload As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_Download As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDocuments_Delete As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace