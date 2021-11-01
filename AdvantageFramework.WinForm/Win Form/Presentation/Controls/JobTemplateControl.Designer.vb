Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobTemplateControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobTemplateControl))
            Me.PanelRightSection_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_JobTemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_JobTemplateItems = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ComboBoxLeftSection_Items = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelLeftSection_Items = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelRightSection_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxTopSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTopSection_DefaultSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxTopSection_DefaultSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_LeftSection.SuspendLayout()
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_TopSection.SuspendLayout()
            CType(Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelRightSection_RightSection
            '
            Me.PanelRightSection_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_RightSection.Controls.Add(Me.DataGridViewRightSection_JobTemplateDetails)
            Me.PanelRightSection_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightSection.Location = New System.Drawing.Point(274, 78)
            Me.PanelRightSection_RightSection.Name = "PanelRightSection_RightSection"
            Me.PanelRightSection_RightSection.Size = New System.Drawing.Size(525, 407)
            Me.PanelRightSection_RightSection.TabIndex = 2
            '
            'DataGridViewRightSection_JobTemplateDetails
            '
            Me.DataGridViewRightSection_JobTemplateDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_JobTemplateDetails.AllowDragAndDrop = False
            Me.DataGridViewRightSection_JobTemplateDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_JobTemplateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_JobTemplateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_JobTemplateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_JobTemplateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_JobTemplateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_JobTemplateDetails.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_JobTemplateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_JobTemplateDetails.DataSource = Nothing
            Me.DataGridViewRightSection_JobTemplateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_JobTemplateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_JobTemplateDetails.ItemDescription = ""
            Me.DataGridViewRightSection_JobTemplateDetails.Location = New System.Drawing.Point(6, 0)
            Me.DataGridViewRightSection_JobTemplateDetails.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewRightSection_JobTemplateDetails.MultiSelect = True
            Me.DataGridViewRightSection_JobTemplateDetails.Name = "DataGridViewRightSection_JobTemplateDetails"
            Me.DataGridViewRightSection_JobTemplateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_JobTemplateDetails.RunStandardValidation = True
            Me.DataGridViewRightSection_JobTemplateDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_JobTemplateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_JobTemplateDetails.Size = New System.Drawing.Size(519, 407)
            Me.DataGridViewRightSection_JobTemplateDetails.TabIndex = 0
            Me.DataGridViewRightSection_JobTemplateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_JobTemplateDetails.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlRightSection_LeftRight
            '
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandableControl = Me.PanelRightSection_LeftSection
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlRightSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_LeftRight.Location = New System.Drawing.Point(268, 78)
            Me.ExpandableSplitterControlRightSection_LeftRight.Name = "ExpandableSplitterControlRightSection_LeftRight"
            Me.ExpandableSplitterControlRightSection_LeftRight.Size = New System.Drawing.Size(6, 407)
            Me.ExpandableSplitterControlRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlRightSection_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlRightSection_LeftRight.TabStop = False
            '
            'PanelRightSection_LeftSection
            '
            Me.PanelRightSection_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobTemplateItems)
            Me.PanelRightSection_LeftSection.Controls.Add(Me.ComboBoxLeftSection_Items)
            Me.PanelRightSection_LeftSection.Controls.Add(Me.LabelLeftSection_Items)
            Me.PanelRightSection_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRightSection_LeftSection.Location = New System.Drawing.Point(0, 78)
            Me.PanelRightSection_LeftSection.Name = "PanelRightSection_LeftSection"
            Me.PanelRightSection_LeftSection.Size = New System.Drawing.Size(268, 407)
            Me.PanelRightSection_LeftSection.TabIndex = 1
            '
            'DataGridViewLeftSection_JobTemplateItems
            '
            Me.DataGridViewLeftSection_JobTemplateItems.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_JobTemplateItems.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_JobTemplateItems.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_JobTemplateItems.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobTemplateItems.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobTemplateItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_JobTemplateItems.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobTemplateItems.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobTemplateItems.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_JobTemplateItems.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobTemplateItems.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobTemplateItems.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobTemplateItems.ItemDescription = ""
            Me.DataGridViewLeftSection_JobTemplateItems.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewLeftSection_JobTemplateItems.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewLeftSection_JobTemplateItems.MultiSelect = True
            Me.DataGridViewLeftSection_JobTemplateItems.Name = "DataGridViewLeftSection_JobTemplateItems"
            Me.DataGridViewLeftSection_JobTemplateItems.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobTemplateItems.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobTemplateItems.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_JobTemplateItems.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobTemplateItems.Size = New System.Drawing.Size(262, 381)
            Me.DataGridViewLeftSection_JobTemplateItems.TabIndex = 2
            Me.DataGridViewLeftSection_JobTemplateItems.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobTemplateItems.ViewCaptionHeight = -1
            '
            'ComboBoxLeftSection_Items
            '
            Me.ComboBoxLeftSection_Items.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxLeftSection_Items.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxLeftSection_Items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxLeftSection_Items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxLeftSection_Items.AutoFindItemInDataSource = False
            Me.ComboBoxLeftSection_Items.AutoSelectSingleItemDatasource = False
            Me.ComboBoxLeftSection_Items.BookmarkingEnabled = False
            Me.ComboBoxLeftSection_Items.ClientCode = ""
            Me.ComboBoxLeftSection_Items.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxLeftSection_Items.DisableMouseWheel = False
            Me.ComboBoxLeftSection_Items.DisplayMember = "Name"
            Me.ComboBoxLeftSection_Items.DisplayName = ""
            Me.ComboBoxLeftSection_Items.DivisionCode = ""
            Me.ComboBoxLeftSection_Items.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxLeftSection_Items.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxLeftSection_Items.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxLeftSection_Items.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxLeftSection_Items.FocusHighlightEnabled = True
            Me.ComboBoxLeftSection_Items.FormattingEnabled = True
            Me.ComboBoxLeftSection_Items.ItemHeight = 15
            Me.ComboBoxLeftSection_Items.Location = New System.Drawing.Point(43, 0)
            Me.ComboBoxLeftSection_Items.Name = "ComboBoxLeftSection_Items"
            Me.ComboBoxLeftSection_Items.ReadOnly = False
            Me.ComboBoxLeftSection_Items.SecurityEnabled = True
            Me.ComboBoxLeftSection_Items.Size = New System.Drawing.Size(219, 21)
            Me.ComboBoxLeftSection_Items.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxLeftSection_Items.TabIndex = 1
            Me.ComboBoxLeftSection_Items.TabOnEnter = True
            Me.ComboBoxLeftSection_Items.ValueMember = "Value"
            Me.ComboBoxLeftSection_Items.WatermarkText = "Select"
            '
            'LabelLeftSection_Items
            '
            Me.LabelLeftSection_Items.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_Items.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_Items.Location = New System.Drawing.Point(0, 0)
            Me.LabelLeftSection_Items.Name = "LabelLeftSection_Items"
            Me.LabelLeftSection_Items.Size = New System.Drawing.Size(37, 20)
            Me.LabelLeftSection_Items.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_Items.TabIndex = 0
            Me.LabelLeftSection_Items.Text = "Items:"
            '
            'PanelRightSection_TopSection
            '
            Me.PanelRightSection_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelRightSection_TopSection.Controls.Add(Me.SearchableComboBoxTopSection_DefaultSalesClass)
            Me.PanelRightSection_TopSection.Controls.Add(Me.CheckBoxTopSection_Inactive)
            Me.PanelRightSection_TopSection.Controls.Add(Me.TextBoxTopSection_Description)
            Me.PanelRightSection_TopSection.Controls.Add(Me.TextBoxTopSection_Code)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_Description)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_DefaultSalesClass)
            Me.PanelRightSection_TopSection.Controls.Add(Me.LabelTopSection_Code)
            Me.PanelRightSection_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelRightSection_TopSection.Name = "PanelRightSection_TopSection"
            Me.PanelRightSection_TopSection.Size = New System.Drawing.Size(799, 78)
            Me.PanelRightSection_TopSection.TabIndex = 0
            '
            'CheckBoxTopSection_Inactive
            '
            Me.CheckBoxTopSection_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTopSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTopSection_Inactive.CheckValue = 0
            Me.CheckBoxTopSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxTopSection_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTopSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxTopSection_Inactive.ChildControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTopSection_Inactive.Location = New System.Drawing.Point(182, 0)
            Me.CheckBoxTopSection_Inactive.Name = "CheckBoxTopSection_Inactive"
            Me.CheckBoxTopSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxTopSection_Inactive.SecurityEnabled = True
            Me.CheckBoxTopSection_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.Size = New System.Drawing.Size(617, 20)
            Me.CheckBoxTopSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTopSection_Inactive.TabIndex = 2
            Me.CheckBoxTopSection_Inactive.TabOnEnter = True
            Me.CheckBoxTopSection_Inactive.Text = "Inactive"
            '
            'TextBoxTopSection_Description
            '
            Me.TextBoxTopSection_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Description.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Description.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Description.Location = New System.Drawing.Point(113, 26)
            Me.TextBoxTopSection_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Description.Name = "TextBoxTopSection_Description"
            Me.TextBoxTopSection_Description.SecurityEnabled = True
            Me.TextBoxTopSection_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Description.Size = New System.Drawing.Size(685, 21)
            Me.TextBoxTopSection_Description.StartingFolderName = Nothing
            Me.TextBoxTopSection_Description.TabIndex = 4
            Me.TextBoxTopSection_Description.TabOnEnter = True
            '
            'TextBoxTopSection_Code
            '
            '
            '
            '
            Me.TextBoxTopSection_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Code.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Code.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Code.Location = New System.Drawing.Point(113, 0)
            Me.TextBoxTopSection_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Code.Name = "TextBoxTopSection_Code"
            Me.TextBoxTopSection_Code.SecurityEnabled = True
            Me.TextBoxTopSection_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Code.Size = New System.Drawing.Size(63, 21)
            Me.TextBoxTopSection_Code.StartingFolderName = Nothing
            Me.TextBoxTopSection_Code.TabIndex = 1
            Me.TextBoxTopSection_Code.TabOnEnter = True
            '
            'LabelTopSection_Description
            '
            Me.LabelTopSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Description.Location = New System.Drawing.Point(0, 26)
            Me.LabelTopSection_Description.Name = "LabelTopSection_Description"
            Me.LabelTopSection_Description.Size = New System.Drawing.Size(107, 20)
            Me.LabelTopSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Description.TabIndex = 3
            Me.LabelTopSection_Description.Text = "Description:"
            '
            'LabelTopSection_DefaultSalesClass
            '
            Me.LabelTopSection_DefaultSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_DefaultSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_DefaultSalesClass.Location = New System.Drawing.Point(0, 52)
            Me.LabelTopSection_DefaultSalesClass.Name = "LabelTopSection_DefaultSalesClass"
            Me.LabelTopSection_DefaultSalesClass.Size = New System.Drawing.Size(107, 20)
            Me.LabelTopSection_DefaultSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_DefaultSalesClass.TabIndex = 5
            Me.LabelTopSection_DefaultSalesClass.Text = "Default Sales Class:"
            '
            'LabelTopSection_Code
            '
            Me.LabelTopSection_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelTopSection_Code.Name = "LabelTopSection_Code"
            Me.LabelTopSection_Code.Size = New System.Drawing.Size(107, 20)
            Me.LabelTopSection_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Code.TabIndex = 0
            Me.LabelTopSection_Code.Text = "Code:"
            '
            'SearchableComboBoxTopSection_DefaultSalesClass
            '
            Me.SearchableComboBoxTopSection_DefaultSalesClass.ActiveFilterString = ""
            Me.SearchableComboBoxTopSection_DefaultSalesClass.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTopSection_DefaultSalesClass.AutoFillMode = False
            Me.SearchableComboBoxTopSection_DefaultSalesClass.BookmarkingEnabled = False
            Me.SearchableComboBoxTopSection_DefaultSalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.SalesClass
            Me.SearchableComboBoxTopSection_DefaultSalesClass.DataSource = Nothing
            Me.SearchableComboBoxTopSection_DefaultSalesClass.DisableMouseWheel = False
            Me.SearchableComboBoxTopSection_DefaultSalesClass.DisplayName = ""
            Me.SearchableComboBoxTopSection_DefaultSalesClass.EnterMoveNextControl = True
            Me.SearchableComboBoxTopSection_DefaultSalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Location = New System.Drawing.Point(113, 52)
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Name = "SearchableComboBoxTopSection_DefaultSalesClass"
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties.NullText = "Select Sales Class"
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxTopSection_DefaultSalesClass.SecurityEnabled = True
            Me.SearchableComboBoxTopSection_DefaultSalesClass.SelectedValue = Nothing
            Me.SearchableComboBoxTopSection_DefaultSalesClass.Size = New System.Drawing.Size(686, 20)
            Me.SearchableComboBoxTopSection_DefaultSalesClass.TabIndex = 6
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.AFActiveFilterString = ""
            Me.SearchableComboBox1View.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1View.AutoFilterLookupColumns = False
            Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1View.DataSourceClearing = False
            Me.SearchableComboBox1View.EnableDisabledRows = False
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1View.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBox1View.RunStandardValidation = True
            '
            'JobTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelRightSection_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlRightSection_LeftRight)
            Me.Controls.Add(Me.PanelRightSection_LeftSection)
            Me.Controls.Add(Me.PanelRightSection_TopSection)
            Me.Name = "JobTemplateControl"
            Me.Size = New System.Drawing.Size(799, 485)
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_LeftSection.ResumeLayout(False)
            CType(Me.PanelRightSection_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_TopSection.ResumeLayout(False)
            CType(Me.SearchableComboBoxTopSection_DefaultSalesClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelRightSection_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxTopSection_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTopSection_DefaultSalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ExpandableSplitterControlRightSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelRightSection_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_JobTemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ComboBoxLeftSection_Items As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelLeftSection_Items As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewLeftSection_JobTemplateItems As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxTopSection_DefaultSalesClass As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
