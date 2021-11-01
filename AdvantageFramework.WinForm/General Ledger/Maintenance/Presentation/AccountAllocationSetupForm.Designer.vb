Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountAllocationSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountAllocationSetupForm))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonControlRightSection_SquareFootage = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlRightSection_Percentage = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlRightSection_NumberOfEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewRightSection_Allocations = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.NumericInputRightSection_Total = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRightSection_Total = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxRightSection_AllocationDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxRightSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxRightSection_Account = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelRightSection_AllocationType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_AllocationDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_AccountCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_GLAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.NumericInputRightSection_Total.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.RadioButtonControlRightSection_SquareFootage)
            Me.PanelForm_RightSection.Controls.Add(Me.RadioButtonControlRightSection_Percentage)
            Me.PanelForm_RightSection.Controls.Add(Me.RadioButtonControlRightSection_NumberOfEmployees)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Allocations)
            Me.PanelForm_RightSection.Controls.Add(Me.NumericInputRightSection_Total)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_Total)
            Me.PanelForm_RightSection.Controls.Add(Me.TextBoxRightSection_AllocationDescription)
            Me.PanelForm_RightSection.Controls.Add(Me.CheckBoxRightSection_Inactive)
            Me.PanelForm_RightSection.Controls.Add(Me.ComboBoxRightSection_Account)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_AllocationType)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_AllocationDescription)
            Me.PanelForm_RightSection.Controls.Add(Me.LabelRightSection_AccountCode)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(236, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(658, 477)
            Me.PanelForm_RightSection.TabIndex = 5
            '
            'RadioButtonControlRightSection_SquareFootage
            '
            '
            '
            '
            Me.RadioButtonControlRightSection_SquareFootage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRightSection_SquareFootage.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRightSection_SquareFootage.Location = New System.Drawing.Point(223, 64)
            Me.RadioButtonControlRightSection_SquareFootage.Name = "RadioButtonControlRightSection_SquareFootage"
            Me.RadioButtonControlRightSection_SquareFootage.Size = New System.Drawing.Size(108, 20)
            Me.RadioButtonControlRightSection_SquareFootage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRightSection_SquareFootage.TabIndex = 7
            Me.RadioButtonControlRightSection_SquareFootage.TabStop = False
            Me.RadioButtonControlRightSection_SquareFootage.Text = "Square Footage"
            '
            'RadioButtonControlRightSection_Percentage
            '
            '
            '
            '
            Me.RadioButtonControlRightSection_Percentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRightSection_Percentage.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRightSection_Percentage.Location = New System.Drawing.Point(127, 64)
            Me.RadioButtonControlRightSection_Percentage.Name = "RadioButtonControlRightSection_Percentage"
            Me.RadioButtonControlRightSection_Percentage.Size = New System.Drawing.Size(90, 20)
            Me.RadioButtonControlRightSection_Percentage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRightSection_Percentage.TabIndex = 6
            Me.RadioButtonControlRightSection_Percentage.TabStop = False
            Me.RadioButtonControlRightSection_Percentage.Text = "Percentage"
            '
            'RadioButtonControlRightSection_NumberOfEmployees
            '
            Me.RadioButtonControlRightSection_NumberOfEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.RadioButtonControlRightSection_NumberOfEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRightSection_NumberOfEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRightSection_NumberOfEmployees.Location = New System.Drawing.Point(337, 64)
            Me.RadioButtonControlRightSection_NumberOfEmployees.Name = "RadioButtonControlRightSection_NumberOfEmployees"
            Me.RadioButtonControlRightSection_NumberOfEmployees.Size = New System.Drawing.Size(309, 20)
            Me.RadioButtonControlRightSection_NumberOfEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRightSection_NumberOfEmployees.TabIndex = 8
            Me.RadioButtonControlRightSection_NumberOfEmployees.TabStop = False
            Me.RadioButtonControlRightSection_NumberOfEmployees.Text = "Number of Employees"
            '
            'DataGridViewRightSection_Allocations
            '
            Me.DataGridViewRightSection_Allocations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Allocations.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_Allocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Allocations.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Allocations.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Allocations.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_Allocations.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_Allocations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Allocations.ItemDescription = "GL Allocation Detail(s)"
            Me.DataGridViewRightSection_Allocations.Location = New System.Drawing.Point(6, 116)
            Me.DataGridViewRightSection_Allocations.MultiSelect = True
            Me.DataGridViewRightSection_Allocations.Name = "DataGridViewRightSection_Allocations"
            Me.DataGridViewRightSection_Allocations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRightSection_Allocations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Allocations.Size = New System.Drawing.Size(640, 349)
            Me.DataGridViewRightSection_Allocations.TabIndex = 11
            Me.DataGridViewRightSection_Allocations.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Allocations.ViewCaptionHeight = -1
            '
            'NumericInputRightSection_Total
            '
            Me.NumericInputRightSection_Total.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Long]
            Me.NumericInputRightSection_Total.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRightSection_Total.Location = New System.Drawing.Point(127, 90)
            Me.NumericInputRightSection_Total.Name = "NumericInputRightSection_Total"
            Me.NumericInputRightSection_Total.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRightSection_Total.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputRightSection_Total.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightSection_Total.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputRightSection_Total.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightSection_Total.Properties.IsFloatValue = False
            Me.NumericInputRightSection_Total.Properties.Mask.EditMask = "f0"
            Me.NumericInputRightSection_Total.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRightSection_Total.Properties.MaxLength = 20
            Me.NumericInputRightSection_Total.Properties.MaxValue = New Decimal(New Integer() {-1, 2147483647, 0, 0})
            Me.NumericInputRightSection_Total.Properties.MinValue = New Decimal(New Integer() {-1, 2147483647, 0, -2147483648})
            Me.NumericInputRightSection_Total.Size = New System.Drawing.Size(107, 20)
            Me.NumericInputRightSection_Total.TabIndex = 10
            '
            'LabelRightSection_Total
            '
            Me.LabelRightSection_Total.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Total.Location = New System.Drawing.Point(6, 90)
            Me.LabelRightSection_Total.Name = "LabelRightSection_Total"
            Me.LabelRightSection_Total.Size = New System.Drawing.Size(115, 20)
            Me.LabelRightSection_Total.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Total.TabIndex = 9
            Me.LabelRightSection_Total.Text = "Total Square Feet:"
            '
            'TextBoxRightSection_AllocationDescription
            '
            Me.TextBoxRightSection_AllocationDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_AllocationDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_AllocationDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_AllocationDescription.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_AllocationDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_AllocationDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_AllocationDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_AllocationDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_AllocationDescription.FocusHighlightEnabled = True
            Me.TextBoxRightSection_AllocationDescription.Location = New System.Drawing.Point(127, 38)
            Me.TextBoxRightSection_AllocationDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_AllocationDescription.Name = "TextBoxRightSection_AllocationDescription"
            Me.TextBoxRightSection_AllocationDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_AllocationDescription.Size = New System.Drawing.Size(519, 20)
            Me.TextBoxRightSection_AllocationDescription.TabIndex = 4
            Me.TextBoxRightSection_AllocationDescription.TabOnEnter = True
            '
            'CheckBoxRightSection_Inactive
            '
            Me.CheckBoxRightSection_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRightSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRightSection_Inactive.CheckValue = 0
            Me.CheckBoxRightSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxRightSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxRightSection_Inactive.ChildControls = CType(resources.GetObject("CheckBoxRightSection_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRightSection_Inactive.Location = New System.Drawing.Point(576, 12)
            Me.CheckBoxRightSection_Inactive.Name = "CheckBoxRightSection_Inactive"
            Me.CheckBoxRightSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxRightSection_Inactive.SecurityEnabled = True
            Me.CheckBoxRightSection_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxRightSection_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightSection_Inactive.Size = New System.Drawing.Size(70, 20)
            Me.CheckBoxRightSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightSection_Inactive.TabIndex = 2
            Me.CheckBoxRightSection_Inactive.Text = "Inactive"
            '
            'ComboBoxRightSection_Account
            '
            Me.ComboBoxRightSection_Account.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_Account.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_Account.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_Account.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_Account.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_Account.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_Account.BookmarkingEnabled = False
            Me.ComboBoxRightSection_Account.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
            Me.ComboBoxRightSection_Account.DisableMouseWheel = False
            Me.ComboBoxRightSection_Account.DisplayMember = "Description"
            Me.ComboBoxRightSection_Account.DisplayName = ""
            Me.ComboBoxRightSection_Account.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_Account.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRightSection_Account.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_Account.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_Account.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_Account.FormattingEnabled = True
            Me.ComboBoxRightSection_Account.ItemHeight = 14
            Me.ComboBoxRightSection_Account.Location = New System.Drawing.Point(127, 12)
            Me.ComboBoxRightSection_Account.Name = "ComboBoxRightSection_Account"
            Me.ComboBoxRightSection_Account.PreventEnterBeep = False
            Me.ComboBoxRightSection_Account.ReadOnly = False
            Me.ComboBoxRightSection_Account.Size = New System.Drawing.Size(443, 20)
            Me.ComboBoxRightSection_Account.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_Account.TabIndex = 1
            Me.ComboBoxRightSection_Account.ValueMember = "Code"
            Me.ComboBoxRightSection_Account.WatermarkText = "Select General Ledger Account"
            '
            'LabelRightSection_AllocationType
            '
            Me.LabelRightSection_AllocationType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_AllocationType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_AllocationType.Location = New System.Drawing.Point(6, 64)
            Me.LabelRightSection_AllocationType.Name = "LabelRightSection_AllocationType"
            Me.LabelRightSection_AllocationType.Size = New System.Drawing.Size(115, 20)
            Me.LabelRightSection_AllocationType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_AllocationType.TabIndex = 5
            Me.LabelRightSection_AllocationType.Text = "Allocation Type:"
            '
            'LabelRightSection_AllocationDescription
            '
            Me.LabelRightSection_AllocationDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_AllocationDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_AllocationDescription.Location = New System.Drawing.Point(6, 38)
            Me.LabelRightSection_AllocationDescription.Name = "LabelRightSection_AllocationDescription"
            Me.LabelRightSection_AllocationDescription.Size = New System.Drawing.Size(115, 20)
            Me.LabelRightSection_AllocationDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_AllocationDescription.TabIndex = 3
            Me.LabelRightSection_AllocationDescription.Text = "Allocation Description:"
            '
            'LabelRightSection_AccountCode
            '
            Me.LabelRightSection_AccountCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_AccountCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_AccountCode.Location = New System.Drawing.Point(6, 12)
            Me.LabelRightSection_AccountCode.Name = "LabelRightSection_AccountCode"
            Me.LabelRightSection_AccountCode.Size = New System.Drawing.Size(115, 20)
            Me.LabelRightSection_AccountCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_AccountCode.TabIndex = 0
            Me.LabelRightSection_AccountCode.Text = "Account:"
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
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 477)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_GLAccounts)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(230, 477)
            Me.PanelForm_LeftSection.TabIndex = 3
            '
            'DataGridViewLeftSection_GLAccounts
            '
            Me.DataGridViewLeftSection_GLAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_GLAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_GLAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_GLAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_GLAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_GLAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_GLAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_GLAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_GLAccounts.ItemDescription = "GL Account(s)"
            Me.DataGridViewLeftSection_GLAccounts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_GLAccounts.MultiSelect = True
            Me.DataGridViewLeftSection_GLAccounts.Name = "DataGridViewLeftSection_GLAccounts"
            Me.DataGridViewLeftSection_GLAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_GLAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_GLAccounts.Size = New System.Drawing.Size(212, 453)
            Me.DataGridViewLeftSection_GLAccounts.TabIndex = 0
            Me.DataGridViewLeftSection_GLAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_GLAccounts.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(297, 98)
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
            'RibbonBarOptions_Details
            '
            Me.RibbonBarOptions_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Cancel, Me.ButtonItemDetails_Delete})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(89, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(105, 98)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 1
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.BeginGroup = True
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.RibbonWordWrap = False
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Print, Me.ButtonItemActions_Save})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(89, 98)
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
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
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
            'AccountAllocationSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(894, 477)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountAllocationSetupForm"
            Me.Text = "GL Account Allocation Maintenance"
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.NumericInputRightSection_Total.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_GLAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RadioButtonControlRightSection_SquareFootage As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlRightSection_Percentage As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlRightSection_NumberOfEmployees As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewRightSection_Allocations As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputRightSection_Total As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelRightSection_Total As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxRightSection_AllocationDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxRightSection_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxRightSection_Account As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelRightSection_AllocationType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_AllocationDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_AccountCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem

    End Class

End Namespace