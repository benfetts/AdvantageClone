Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CostRateForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostRateForm))
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxLeftSection_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLeftSection_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputLeftSection_EndYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxLeftSection_EndMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputLeftSection_StartYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxLeftSection_StartMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelLeftSection_UpdateHourlyCostAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLeftSection_DirectTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftSection_NonProductiveTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftSection_AllNonProductiveTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftSection_AlternateAmount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLeftSection_HoursForCalculation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_PeriodRangeForUpdates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLeftSection_StandardAmount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelLeftSection_Year = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftSection_Month = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarPanel_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Calculate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_UpdateTimeRecords = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.DataGridViewLeftSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.NumericInputLeftSection_EndYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputLeftSection_StartYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(924, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarPanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(924, 95)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarPanel_Actions, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(57, 92)
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
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_RightSection)
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_LeftSection)
            Me.PanelForm_Form.Size = New System.Drawing.Size(924, 366)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 521)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(924, 18)
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_Employees)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(365, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(559, 366)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'DataGridViewRightSection_Employees
            '
            Me.DataGridViewRightSection_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_Employees.ItemDescription = ""
            Me.DataGridViewRightSection_Employees.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewRightSection_Employees.MultiSelect = True
            Me.DataGridViewRightSection_Employees.Name = "DataGridViewRightSection_Employees"
            Me.DataGridViewRightSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_Employees.RunStandardValidation = True
            Me.DataGridViewRightSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_Employees.Size = New System.Drawing.Size(548, 355)
            Me.DataGridViewRightSection_Employees.TabIndex = 0
            Me.DataGridViewRightSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_Employees.ViewCaptionHeight = -1
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Employees)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_DepartmentTeam)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_To)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_From)
            Me.PanelForm_LeftSection.Controls.Add(Me.NumericInputLeftSection_EndYear)
            Me.PanelForm_LeftSection.Controls.Add(Me.ComboBoxLeftSection_EndMonth)
            Me.PanelForm_LeftSection.Controls.Add(Me.NumericInputLeftSection_StartYear)
            Me.PanelForm_LeftSection.Controls.Add(Me.ComboBoxLeftSection_StartMonth)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_UpdateHourlyCostAmount)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_DirectTime)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_NonProductiveTime)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_AllNonProductiveTime)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_AlternateAmount)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_HoursForCalculation)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_PeriodRangeForUpdates)
            Me.PanelForm_LeftSection.Controls.Add(Me.CheckBoxLeftSection_StandardAmount)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_Year)
            Me.PanelForm_LeftSection.Controls.Add(Me.LabelLeftSection_Month)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(359, 366)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'CheckBoxLeftSection_DepartmentTeam
            '
            '
            '
            '
            Me.CheckBoxLeftSection_DepartmentTeam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_DepartmentTeam.CheckValue = 0
            Me.CheckBoxLeftSection_DepartmentTeam.CheckValueChecked = 1
            Me.CheckBoxLeftSection_DepartmentTeam.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_DepartmentTeam.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_DepartmentTeam.ChildControls = Nothing
            Me.CheckBoxLeftSection_DepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_DepartmentTeam.Location = New System.Drawing.Point(5, 32)
            Me.CheckBoxLeftSection_DepartmentTeam.Name = "CheckBoxLeftSection_DepartmentTeam"
            Me.CheckBoxLeftSection_DepartmentTeam.OldestSibling = Nothing
            Me.CheckBoxLeftSection_DepartmentTeam.SecurityEnabled = True
            Me.CheckBoxLeftSection_DepartmentTeam.SiblingControls = Nothing
            Me.CheckBoxLeftSection_DepartmentTeam.Size = New System.Drawing.Size(115, 20)
            Me.CheckBoxLeftSection_DepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_DepartmentTeam.TabIndex = 1
            Me.CheckBoxLeftSection_DepartmentTeam.Text = "Department/Team"
            '
            'LabelLeftSection_To
            '
            Me.LabelLeftSection_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_To.Location = New System.Drawing.Point(5, 240)
            Me.LabelLeftSection_To.Name = "LabelLeftSection_To"
            Me.LabelLeftSection_To.Size = New System.Drawing.Size(49, 20)
            Me.LabelLeftSection_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_To.TabIndex = 14
            Me.LabelLeftSection_To.Text = "To:"
            '
            'LabelLeftSection_From
            '
            Me.LabelLeftSection_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_From.Location = New System.Drawing.Point(5, 214)
            Me.LabelLeftSection_From.Name = "LabelLeftSection_From"
            Me.LabelLeftSection_From.Size = New System.Drawing.Size(49, 20)
            Me.LabelLeftSection_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_From.TabIndex = 11
            Me.LabelLeftSection_From.Text = "From:"
            '
            'NumericInputLeftSection_EndYear
            '
            Me.NumericInputLeftSection_EndYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputLeftSection_EndYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputLeftSection_EndYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputLeftSection_EndYear.Location = New System.Drawing.Point(210, 240)
            Me.NumericInputLeftSection_EndYear.Name = "NumericInputLeftSection_EndYear"
            Me.NumericInputLeftSection_EndYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputLeftSection_EndYear.Properties.DisplayFormat.FormatString = "d4"
            Me.NumericInputLeftSection_EndYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftSection_EndYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputLeftSection_EndYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftSection_EndYear.Properties.IsFloatValue = False
            Me.NumericInputLeftSection_EndYear.Properties.Mask.EditMask = "d4"
            Me.NumericInputLeftSection_EndYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLeftSection_EndYear.Properties.MaxLength = 11
            Me.NumericInputLeftSection_EndYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputLeftSection_EndYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputLeftSection_EndYear.SecurityEnabled = True
            Me.NumericInputLeftSection_EndYear.Size = New System.Drawing.Size(61, 20)
            Me.NumericInputLeftSection_EndYear.TabIndex = 16
            '
            'ComboBoxLeftSection_EndMonth
            '
            Me.ComboBoxLeftSection_EndMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxLeftSection_EndMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxLeftSection_EndMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxLeftSection_EndMonth.AutoFindItemInDataSource = False
            Me.ComboBoxLeftSection_EndMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxLeftSection_EndMonth.BookmarkingEnabled = False
            Me.ComboBoxLeftSection_EndMonth.ClientCode = ""
            Me.ComboBoxLeftSection_EndMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxLeftSection_EndMonth.DisableMouseWheel = False
            Me.ComboBoxLeftSection_EndMonth.DisplayMember = "Value"
            Me.ComboBoxLeftSection_EndMonth.DisplayName = ""
            Me.ComboBoxLeftSection_EndMonth.DivisionCode = ""
            Me.ComboBoxLeftSection_EndMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxLeftSection_EndMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxLeftSection_EndMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxLeftSection_EndMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxLeftSection_EndMonth.FocusHighlightEnabled = True
            Me.ComboBoxLeftSection_EndMonth.FormattingEnabled = True
            Me.ComboBoxLeftSection_EndMonth.ItemHeight = 14
            Me.ComboBoxLeftSection_EndMonth.Location = New System.Drawing.Point(60, 240)
            Me.ComboBoxLeftSection_EndMonth.Name = "ComboBoxLeftSection_EndMonth"
            Me.ComboBoxLeftSection_EndMonth.PreventEnterBeep = False
            Me.ComboBoxLeftSection_EndMonth.ReadOnly = False
            Me.ComboBoxLeftSection_EndMonth.SecurityEnabled = True
            Me.ComboBoxLeftSection_EndMonth.Size = New System.Drawing.Size(144, 20)
            Me.ComboBoxLeftSection_EndMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxLeftSection_EndMonth.TabIndex = 15
            Me.ComboBoxLeftSection_EndMonth.ValueMember = "Key"
            Me.ComboBoxLeftSection_EndMonth.WatermarkText = "Select Month"
            '
            'NumericInputLeftSection_StartYear
            '
            Me.NumericInputLeftSection_StartYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputLeftSection_StartYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputLeftSection_StartYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputLeftSection_StartYear.Location = New System.Drawing.Point(210, 214)
            Me.NumericInputLeftSection_StartYear.Name = "NumericInputLeftSection_StartYear"
            Me.NumericInputLeftSection_StartYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputLeftSection_StartYear.Properties.DisplayFormat.FormatString = "d4"
            Me.NumericInputLeftSection_StartYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftSection_StartYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputLeftSection_StartYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftSection_StartYear.Properties.IsFloatValue = False
            Me.NumericInputLeftSection_StartYear.Properties.Mask.EditMask = "d4"
            Me.NumericInputLeftSection_StartYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLeftSection_StartYear.Properties.MaxLength = 11
            Me.NumericInputLeftSection_StartYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputLeftSection_StartYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputLeftSection_StartYear.SecurityEnabled = True
            Me.NumericInputLeftSection_StartYear.Size = New System.Drawing.Size(61, 20)
            Me.NumericInputLeftSection_StartYear.TabIndex = 13
            '
            'ComboBoxLeftSection_StartMonth
            '
            Me.ComboBoxLeftSection_StartMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxLeftSection_StartMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxLeftSection_StartMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxLeftSection_StartMonth.AutoFindItemInDataSource = False
            Me.ComboBoxLeftSection_StartMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxLeftSection_StartMonth.BookmarkingEnabled = False
            Me.ComboBoxLeftSection_StartMonth.ClientCode = ""
            Me.ComboBoxLeftSection_StartMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxLeftSection_StartMonth.DisableMouseWheel = False
            Me.ComboBoxLeftSection_StartMonth.DisplayMember = "Value"
            Me.ComboBoxLeftSection_StartMonth.DisplayName = ""
            Me.ComboBoxLeftSection_StartMonth.DivisionCode = ""
            Me.ComboBoxLeftSection_StartMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxLeftSection_StartMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxLeftSection_StartMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxLeftSection_StartMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxLeftSection_StartMonth.FocusHighlightEnabled = True
            Me.ComboBoxLeftSection_StartMonth.FormattingEnabled = True
            Me.ComboBoxLeftSection_StartMonth.ItemHeight = 14
            Me.ComboBoxLeftSection_StartMonth.Location = New System.Drawing.Point(60, 214)
            Me.ComboBoxLeftSection_StartMonth.Name = "ComboBoxLeftSection_StartMonth"
            Me.ComboBoxLeftSection_StartMonth.PreventEnterBeep = False
            Me.ComboBoxLeftSection_StartMonth.ReadOnly = False
            Me.ComboBoxLeftSection_StartMonth.SecurityEnabled = True
            Me.ComboBoxLeftSection_StartMonth.Size = New System.Drawing.Size(144, 20)
            Me.ComboBoxLeftSection_StartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxLeftSection_StartMonth.TabIndex = 12
            Me.ComboBoxLeftSection_StartMonth.ValueMember = "Key"
            Me.ComboBoxLeftSection_StartMonth.WatermarkText = "Select Month"
            '
            'LabelLeftSection_UpdateHourlyCostAmount
            '
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_UpdateHourlyCostAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_UpdateHourlyCostAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_UpdateHourlyCostAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_UpdateHourlyCostAmount.Location = New System.Drawing.Point(5, 6)
            Me.LabelLeftSection_UpdateHourlyCostAmount.Name = "LabelLeftSection_UpdateHourlyCostAmount"
            Me.LabelLeftSection_UpdateHourlyCostAmount.Size = New System.Drawing.Size(348, 20)
            Me.LabelLeftSection_UpdateHourlyCostAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_UpdateHourlyCostAmount.TabIndex = 0
            Me.LabelLeftSection_UpdateHourlyCostAmount.Text = "Update Hourly Cost Amount"
            '
            'CheckBoxLeftSection_DirectTime
            '
            '
            '
            '
            Me.CheckBoxLeftSection_DirectTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_DirectTime.CheckValue = 0
            Me.CheckBoxLeftSection_DirectTime.CheckValueChecked = 1
            Me.CheckBoxLeftSection_DirectTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_DirectTime.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_DirectTime.ChildControls = Nothing
            Me.CheckBoxLeftSection_DirectTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_DirectTime.Location = New System.Drawing.Point(5, 84)
            Me.CheckBoxLeftSection_DirectTime.Name = "CheckBoxLeftSection_DirectTime"
            Me.CheckBoxLeftSection_DirectTime.OldestSibling = Nothing
            Me.CheckBoxLeftSection_DirectTime.SecurityEnabled = True
            Me.CheckBoxLeftSection_DirectTime.SiblingControls = Nothing
            Me.CheckBoxLeftSection_DirectTime.Size = New System.Drawing.Size(348, 20)
            Me.CheckBoxLeftSection_DirectTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_DirectTime.TabIndex = 5
            Me.CheckBoxLeftSection_DirectTime.Text = "Direct Time"
            '
            'CheckBoxLeftSection_NonProductiveTime
            '
            '
            '
            '
            Me.CheckBoxLeftSection_NonProductiveTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_NonProductiveTime.CheckValue = 0
            Me.CheckBoxLeftSection_NonProductiveTime.CheckValueChecked = 1
            Me.CheckBoxLeftSection_NonProductiveTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_NonProductiveTime.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_NonProductiveTime.ChildControls = Nothing
            Me.CheckBoxLeftSection_NonProductiveTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_NonProductiveTime.Location = New System.Drawing.Point(5, 110)
            Me.CheckBoxLeftSection_NonProductiveTime.Name = "CheckBoxLeftSection_NonProductiveTime"
            Me.CheckBoxLeftSection_NonProductiveTime.OldestSibling = Nothing
            Me.CheckBoxLeftSection_NonProductiveTime.SecurityEnabled = True
            Me.CheckBoxLeftSection_NonProductiveTime.SiblingControls = Nothing
            Me.CheckBoxLeftSection_NonProductiveTime.Size = New System.Drawing.Size(348, 20)
            Me.CheckBoxLeftSection_NonProductiveTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_NonProductiveTime.TabIndex = 6
            Me.CheckBoxLeftSection_NonProductiveTime.Text = "Non Productive Time Except Designated Vacation, Sick, Personal"
            '
            'CheckBoxLeftSection_AllNonProductiveTime
            '
            '
            '
            '
            Me.CheckBoxLeftSection_AllNonProductiveTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_AllNonProductiveTime.CheckValue = 0
            Me.CheckBoxLeftSection_AllNonProductiveTime.CheckValueChecked = 1
            Me.CheckBoxLeftSection_AllNonProductiveTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_AllNonProductiveTime.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_AllNonProductiveTime.ChildControls = Nothing
            Me.CheckBoxLeftSection_AllNonProductiveTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_AllNonProductiveTime.Location = New System.Drawing.Point(5, 136)
            Me.CheckBoxLeftSection_AllNonProductiveTime.Name = "CheckBoxLeftSection_AllNonProductiveTime"
            Me.CheckBoxLeftSection_AllNonProductiveTime.OldestSibling = Nothing
            Me.CheckBoxLeftSection_AllNonProductiveTime.SecurityEnabled = True
            Me.CheckBoxLeftSection_AllNonProductiveTime.SiblingControls = Nothing
            Me.CheckBoxLeftSection_AllNonProductiveTime.Size = New System.Drawing.Size(348, 20)
            Me.CheckBoxLeftSection_AllNonProductiveTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_AllNonProductiveTime.TabIndex = 7
            Me.CheckBoxLeftSection_AllNonProductiveTime.Text = "All Non Productive Time"
            '
            'CheckBoxLeftSection_AlternateAmount
            '
            '
            '
            '
            Me.CheckBoxLeftSection_AlternateAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_AlternateAmount.CheckValue = 0
            Me.CheckBoxLeftSection_AlternateAmount.CheckValueChecked = 1
            Me.CheckBoxLeftSection_AlternateAmount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_AlternateAmount.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_AlternateAmount.ChildControls = Nothing
            Me.CheckBoxLeftSection_AlternateAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_AlternateAmount.Location = New System.Drawing.Point(245, 32)
            Me.CheckBoxLeftSection_AlternateAmount.Name = "CheckBoxLeftSection_AlternateAmount"
            Me.CheckBoxLeftSection_AlternateAmount.OldestSibling = Nothing
            Me.CheckBoxLeftSection_AlternateAmount.SecurityEnabled = True
            Me.CheckBoxLeftSection_AlternateAmount.SiblingControls = Nothing
            Me.CheckBoxLeftSection_AlternateAmount.Size = New System.Drawing.Size(108, 20)
            Me.CheckBoxLeftSection_AlternateAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_AlternateAmount.TabIndex = 3
            Me.CheckBoxLeftSection_AlternateAmount.Text = "Alternate Amount"
            '
            'LabelLeftSection_HoursForCalculation
            '
            Me.LabelLeftSection_HoursForCalculation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_HoursForCalculation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_HoursForCalculation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_HoursForCalculation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_HoursForCalculation.Location = New System.Drawing.Point(5, 58)
            Me.LabelLeftSection_HoursForCalculation.Name = "LabelLeftSection_HoursForCalculation"
            Me.LabelLeftSection_HoursForCalculation.Size = New System.Drawing.Size(348, 20)
            Me.LabelLeftSection_HoursForCalculation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_HoursForCalculation.TabIndex = 4
            Me.LabelLeftSection_HoursForCalculation.Text = "Select Hours for Alternate Cost Rate Calculation"
            '
            'LabelLeftSection_PeriodRangeForUpdates
            '
            Me.LabelLeftSection_PeriodRangeForUpdates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelLeftSection_PeriodRangeForUpdates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_PeriodRangeForUpdates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelLeftSection_PeriodRangeForUpdates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelLeftSection_PeriodRangeForUpdates.Location = New System.Drawing.Point(5, 162)
            Me.LabelLeftSection_PeriodRangeForUpdates.Name = "LabelLeftSection_PeriodRangeForUpdates"
            Me.LabelLeftSection_PeriodRangeForUpdates.Size = New System.Drawing.Size(348, 20)
            Me.LabelLeftSection_PeriodRangeForUpdates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_PeriodRangeForUpdates.TabIndex = 8
            Me.LabelLeftSection_PeriodRangeForUpdates.Text = "Period Range for Updates"
            '
            'CheckBoxLeftSection_StandardAmount
            '
            '
            '
            '
            Me.CheckBoxLeftSection_StandardAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftSection_StandardAmount.CheckValue = 0
            Me.CheckBoxLeftSection_StandardAmount.CheckValueChecked = 1
            Me.CheckBoxLeftSection_StandardAmount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLeftSection_StandardAmount.CheckValueUnchecked = 0
            Me.CheckBoxLeftSection_StandardAmount.ChildControls = Nothing
            Me.CheckBoxLeftSection_StandardAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftSection_StandardAmount.Location = New System.Drawing.Point(126, 32)
            Me.CheckBoxLeftSection_StandardAmount.Name = "CheckBoxLeftSection_StandardAmount"
            Me.CheckBoxLeftSection_StandardAmount.OldestSibling = Nothing
            Me.CheckBoxLeftSection_StandardAmount.SecurityEnabled = True
            Me.CheckBoxLeftSection_StandardAmount.SiblingControls = Nothing
            Me.CheckBoxLeftSection_StandardAmount.Size = New System.Drawing.Size(113, 20)
            Me.CheckBoxLeftSection_StandardAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftSection_StandardAmount.TabIndex = 2
            Me.CheckBoxLeftSection_StandardAmount.Text = "Standard Amount"
            '
            'LabelLeftSection_Year
            '
            Me.LabelLeftSection_Year.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_Year.Location = New System.Drawing.Point(210, 188)
            Me.LabelLeftSection_Year.Name = "LabelLeftSection_Year"
            Me.LabelLeftSection_Year.Size = New System.Drawing.Size(61, 20)
            Me.LabelLeftSection_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_Year.TabIndex = 10
            Me.LabelLeftSection_Year.Text = "Year"
            Me.LabelLeftSection_Year.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'LabelLeftSection_Month
            '
            Me.LabelLeftSection_Month.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_Month.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_Month.Location = New System.Drawing.Point(60, 188)
            Me.LabelLeftSection_Month.Name = "LabelLeftSection_Month"
            Me.LabelLeftSection_Month.Size = New System.Drawing.Size(144, 20)
            Me.LabelLeftSection_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_Month.TabIndex = 9
            Me.LabelLeftSection_Month.Text = "Month"
            Me.LabelLeftSection_Month.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'RibbonBarPanel_Actions
            '
            Me.RibbonBarPanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarPanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarPanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarPanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarPanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Calculate, Me.ButtonItemActions_UpdateTimeRecords, Me.ButtonItemActions_Export})
            Me.RibbonBarPanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarPanel_Actions.Location = New System.Drawing.Point(60, 0)
            Me.RibbonBarPanel_Actions.Name = "RibbonBarPanel_Actions"
            Me.RibbonBarPanel_Actions.SecurityEnabled = True
            Me.RibbonBarPanel_Actions.Size = New System.Drawing.Size(190, 92)
            Me.RibbonBarPanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarPanel_Actions.TabIndex = 1
            Me.RibbonBarPanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarPanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarPanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_Calculate
            '
            Me.ButtonItemActions_Calculate.BeginGroup = True
            Me.ButtonItemActions_Calculate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Calculate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Calculate.Name = "ButtonItemActions_Calculate"
            Me.ButtonItemActions_Calculate.RibbonWordWrap = False
            Me.ButtonItemActions_Calculate.Stretch = True
            Me.ButtonItemActions_Calculate.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Calculate.Text = "Calculate"
            '
            'ButtonItemActions_UpdateTimeRecords
            '
            Me.ButtonItemActions_UpdateTimeRecords.BeginGroup = True
            Me.ButtonItemActions_UpdateTimeRecords.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_UpdateTimeRecords.Enabled = False
            Me.ButtonItemActions_UpdateTimeRecords.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdateTimeRecords.Name = "ButtonItemActions_UpdateTimeRecords"
            Me.ButtonItemActions_UpdateTimeRecords.RibbonWordWrap = False
            Me.ButtonItemActions_UpdateTimeRecords.Stretch = True
            Me.ButtonItemActions_UpdateTimeRecords.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdateTimeRecords.Text = "Update Time"
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(359, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 366)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'DataGridViewLeftSection_Employees
            '
            Me.DataGridViewLeftSection_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Employees.DataSource = Nothing
            Me.DataGridViewLeftSection_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Employees.ItemDescription = "Employee(s)"
            Me.DataGridViewLeftSection_Employees.Location = New System.Drawing.Point(5, 266)
            Me.DataGridViewLeftSection_Employees.MultiSelect = True
            Me.DataGridViewLeftSection_Employees.Name = "DataGridViewLeftSection_Employees"
            Me.DataGridViewLeftSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Employees.RunStandardValidation = True
            Me.DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = True
            Me.DataGridViewLeftSection_Employees.Size = New System.Drawing.Size(348, 95)
            Me.DataGridViewLeftSection_Employees.TabIndex = 17
            Me.DataGridViewLeftSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Employees.ViewCaptionHeight = -1
            '
            'CostRateForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(934, 541)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CostRateForm"
            Me.Text = "Cost Rate Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.NumericInputLeftSection_EndYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputLeftSection_StartYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelLeftSection_UpdateHourlyCostAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxLeftSection_DirectTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftSection_NonProductiveTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftSection_AllNonProductiveTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftSection_AlternateAmount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelLeftSection_HoursForCalculation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_PeriodRangeForUpdates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxLeftSection_StandardAmount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelLeftSection_Year As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_Month As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewRightSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarPanel_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_UpdateTimeRecords As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Calculate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents NumericInputLeftSection_EndYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxLeftSection_EndMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputLeftSection_StartYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxLeftSection_StartMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxLeftSection_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelLeftSection_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftSection_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewLeftSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace