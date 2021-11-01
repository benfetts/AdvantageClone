Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateRowEditDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateRowEditDialog))
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.LabelForm_Balance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.ComboBoxForm_Balance = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.RadioButtonAccountRowDetails_AccountType = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.ComboBoxAccountRowDetails_AccountType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.ComboBoxAccountRowDetails_AccountGroup = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.RadioButtonAccountRowDetails_AccountGroup = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.ComboBoxAccountRowDetails_Account = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.RadioButtonAccountRowDetails_Account = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.ComboBoxAccountRowDetails_AccountRangeStart = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.RadioButtonAccountRowDetails_AccountRange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.ComboBoxAccountRowDetails_AccountRangeTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.RadioButtonAccountRowDetails_Wildcard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.TextBoxAccountRowDetails_Wildcard = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.ComboBoxForm_DisplayType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.LabelForm_DisplayType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.CheckBoxAccountRowDetails_UseBaseCodes = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.ComboBoxForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TabControlForm_RowDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails = New DevComponents.DotNetBar.TabControlPanel()
			Me.LabelAccountRowDetails_DataCalculations = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.PanelAccountRowDetails_DataCalculations = New System.Windows.Forms.Panel()
			Me.RadioButtonDataCalculations_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonDataCalculations_YearToDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonDataCalculations_SelectedPeriod = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.PanelAccountRowDetails_DataOptions = New System.Windows.Forms.Panel()
			Me.RadioButtonDataOptions_PeriodChange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonDataOptions_EndingBalance = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonDataOptions_BeginningBalance = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.LabelAccountRowDetails_DataOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TabItemRowDetails_AccountRowDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails = New DevComponents.DotNetBar.TabControlPanel()
			Me.PanelTotalRowDetails_TotalRowDetails = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.PanelTotalRowDetails_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.ButtonRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.DataGridViewRightSection_RelatedRows = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelTotalRowDetails_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.DataGridViewLeftSection_Rows = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.ComboBoxTableRowDetails_TotalBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
			Me.LabelTableRowDetails_TotalBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.TabItemRowDetails_TotalRowDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
			Me.LabelForm_IndentSpaces = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.NumericInputForm_IndentSpaces = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
			Me.CheckBoxForm_Bold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.CheckBoxForm_UnderlineAmount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.CheckBoxForm_SuppressIfAllZeros = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
			Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.LabelForm_Style = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.CheckBoxForm_Rollup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.CheckBoxForm_DoubleUnderlineAmount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			Me.CheckBoxForm_IsVisible = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			CType(Me.TabControlForm_RowDetails, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TabControlForm_RowDetails.SuspendLayout()
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.SuspendLayout()
			Me.PanelAccountRowDetails_DataCalculations.SuspendLayout()
			Me.PanelAccountRowDetails_DataOptions.SuspendLayout()
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.SuspendLayout()
			CType(Me.PanelTotalRowDetails_TotalRowDetails, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelTotalRowDetails_TotalRowDetails.SuspendLayout()
			CType(Me.PanelTotalRowDetails_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelTotalRowDetails_RightSection.SuspendLayout()
			CType(Me.PanelTotalRowDetails_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelTotalRowDetails_LeftSection.SuspendLayout()
			CType(Me.NumericInputForm_IndentSpaces.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(479, 495)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 23
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'LabelForm_Balance
			'
			Me.LabelForm_Balance.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Balance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Balance.Location = New System.Drawing.Point(296, 38)
			Me.LabelForm_Balance.Name = "LabelForm_Balance"
			Me.LabelForm_Balance.Size = New System.Drawing.Size(48, 20)
			Me.LabelForm_Balance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Balance.TabIndex = 4
			Me.LabelForm_Balance.Text = "Balance:"
			'
			'ComboBoxForm_Balance
			'
			Me.ComboBoxForm_Balance.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxForm_Balance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxForm_Balance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxForm_Balance.AutoFindItemInDataSource = False
			Me.ComboBoxForm_Balance.AutoSelectSingleItemDatasource = False
			Me.ComboBoxForm_Balance.BookmarkingEnabled = False
			Me.ComboBoxForm_Balance.ClientCode = ""
			Me.ComboBoxForm_Balance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
			Me.ComboBoxForm_Balance.DisableMouseWheel = False
			Me.ComboBoxForm_Balance.DisplayMember = "Name"
			Me.ComboBoxForm_Balance.DisplayName = ""
			Me.ComboBoxForm_Balance.DivisionCode = ""
			Me.ComboBoxForm_Balance.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxForm_Balance.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxForm_Balance.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxForm_Balance.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxForm_Balance.FocusHighlightEnabled = True
			Me.ComboBoxForm_Balance.FormattingEnabled = True
			Me.ComboBoxForm_Balance.ItemHeight = 14
			Me.ComboBoxForm_Balance.Location = New System.Drawing.Point(380, 38)
			Me.ComboBoxForm_Balance.Name = "ComboBoxForm_Balance"
			Me.ComboBoxForm_Balance.ReadOnly = False
			Me.ComboBoxForm_Balance.SecurityEnabled = True
			Me.ComboBoxForm_Balance.Size = New System.Drawing.Size(174, 20)
			Me.ComboBoxForm_Balance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxForm_Balance.TabIndex = 5
			Me.ComboBoxForm_Balance.TabOnEnter = True
			Me.ComboBoxForm_Balance.ValueMember = "Value"
			Me.ComboBoxForm_Balance.WatermarkText = "Select"
			'
			'RadioButtonAccountRowDetails_AccountType
			'
			Me.RadioButtonAccountRowDetails_AccountType.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonAccountRowDetails_AccountType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonAccountRowDetails_AccountType.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonAccountRowDetails_AccountType.Checked = True
			Me.RadioButtonAccountRowDetails_AccountType.CheckState = System.Windows.Forms.CheckState.Checked
			Me.RadioButtonAccountRowDetails_AccountType.CheckValue = "Y"
			Me.RadioButtonAccountRowDetails_AccountType.Location = New System.Drawing.Point(4, 4)
			Me.RadioButtonAccountRowDetails_AccountType.Name = "RadioButtonAccountRowDetails_AccountType"
			Me.RadioButtonAccountRowDetails_AccountType.SecurityEnabled = True
			Me.RadioButtonAccountRowDetails_AccountType.Size = New System.Drawing.Size(126, 20)
			Me.RadioButtonAccountRowDetails_AccountType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonAccountRowDetails_AccountType.TabIndex = 0
			Me.RadioButtonAccountRowDetails_AccountType.TabOnEnter = True
			Me.RadioButtonAccountRowDetails_AccountType.Text = "Account Type"
			'
			'ComboBoxAccountRowDetails_AccountType
			'
			Me.ComboBoxAccountRowDetails_AccountType.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxAccountRowDetails_AccountType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxAccountRowDetails_AccountType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxAccountRowDetails_AccountType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxAccountRowDetails_AccountType.AutoFindItemInDataSource = False
			Me.ComboBoxAccountRowDetails_AccountType.AutoSelectSingleItemDatasource = False
			Me.ComboBoxAccountRowDetails_AccountType.BookmarkingEnabled = False
			Me.ComboBoxAccountRowDetails_AccountType.ClientCode = ""
			Me.ComboBoxAccountRowDetails_AccountType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
			Me.ComboBoxAccountRowDetails_AccountType.DisableMouseWheel = False
			Me.ComboBoxAccountRowDetails_AccountType.DisplayMember = "Description"
			Me.ComboBoxAccountRowDetails_AccountType.DisplayName = ""
			Me.ComboBoxAccountRowDetails_AccountType.DivisionCode = ""
			Me.ComboBoxAccountRowDetails_AccountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxAccountRowDetails_AccountType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxAccountRowDetails_AccountType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxAccountRowDetails_AccountType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxAccountRowDetails_AccountType.FocusHighlightEnabled = True
			Me.ComboBoxAccountRowDetails_AccountType.FormattingEnabled = True
			Me.ComboBoxAccountRowDetails_AccountType.ItemHeight = 14
			Me.ComboBoxAccountRowDetails_AccountType.Location = New System.Drawing.Point(136, 4)
			Me.ComboBoxAccountRowDetails_AccountType.Name = "ComboBoxAccountRowDetails_AccountType"
			Me.ComboBoxAccountRowDetails_AccountType.ReadOnly = False
			Me.ComboBoxAccountRowDetails_AccountType.SecurityEnabled = True
			Me.ComboBoxAccountRowDetails_AccountType.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxAccountRowDetails_AccountType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxAccountRowDetails_AccountType.TabIndex = 1
			Me.ComboBoxAccountRowDetails_AccountType.TabOnEnter = True
			Me.ComboBoxAccountRowDetails_AccountType.ValueMember = "Code"
			Me.ComboBoxAccountRowDetails_AccountType.WatermarkText = "Select"
			'
			'ComboBoxAccountRowDetails_AccountGroup
			'
			Me.ComboBoxAccountRowDetails_AccountGroup.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxAccountRowDetails_AccountGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxAccountRowDetails_AccountGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxAccountRowDetails_AccountGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxAccountRowDetails_AccountGroup.AutoFindItemInDataSource = False
			Me.ComboBoxAccountRowDetails_AccountGroup.AutoSelectSingleItemDatasource = False
			Me.ComboBoxAccountRowDetails_AccountGroup.BookmarkingEnabled = False
			Me.ComboBoxAccountRowDetails_AccountGroup.ClientCode = ""
			Me.ComboBoxAccountRowDetails_AccountGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AccountGroup
			Me.ComboBoxAccountRowDetails_AccountGroup.DisableMouseWheel = False
			Me.ComboBoxAccountRowDetails_AccountGroup.DisplayMember = "Description"
			Me.ComboBoxAccountRowDetails_AccountGroup.DisplayName = ""
			Me.ComboBoxAccountRowDetails_AccountGroup.DivisionCode = ""
			Me.ComboBoxAccountRowDetails_AccountGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxAccountRowDetails_AccountGroup.Enabled = False
			Me.ComboBoxAccountRowDetails_AccountGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxAccountRowDetails_AccountGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxAccountRowDetails_AccountGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxAccountRowDetails_AccountGroup.FocusHighlightEnabled = True
			Me.ComboBoxAccountRowDetails_AccountGroup.FormattingEnabled = True
			Me.ComboBoxAccountRowDetails_AccountGroup.ItemHeight = 14
			Me.ComboBoxAccountRowDetails_AccountGroup.Location = New System.Drawing.Point(136, 30)
			Me.ComboBoxAccountRowDetails_AccountGroup.Name = "ComboBoxAccountRowDetails_AccountGroup"
			Me.ComboBoxAccountRowDetails_AccountGroup.ReadOnly = False
			Me.ComboBoxAccountRowDetails_AccountGroup.SecurityEnabled = True
			Me.ComboBoxAccountRowDetails_AccountGroup.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxAccountRowDetails_AccountGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxAccountRowDetails_AccountGroup.TabIndex = 3
			Me.ComboBoxAccountRowDetails_AccountGroup.TabOnEnter = True
			Me.ComboBoxAccountRowDetails_AccountGroup.ValueMember = "Code"
			Me.ComboBoxAccountRowDetails_AccountGroup.WatermarkText = "Select Account Group"
			'
			'RadioButtonAccountRowDetails_AccountGroup
			'
			Me.RadioButtonAccountRowDetails_AccountGroup.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonAccountRowDetails_AccountGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonAccountRowDetails_AccountGroup.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonAccountRowDetails_AccountGroup.Location = New System.Drawing.Point(4, 30)
			Me.RadioButtonAccountRowDetails_AccountGroup.Name = "RadioButtonAccountRowDetails_AccountGroup"
			Me.RadioButtonAccountRowDetails_AccountGroup.SecurityEnabled = True
			Me.RadioButtonAccountRowDetails_AccountGroup.Size = New System.Drawing.Size(126, 20)
			Me.RadioButtonAccountRowDetails_AccountGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonAccountRowDetails_AccountGroup.TabIndex = 2
			Me.RadioButtonAccountRowDetails_AccountGroup.TabOnEnter = True
			Me.RadioButtonAccountRowDetails_AccountGroup.TabStop = False
			Me.RadioButtonAccountRowDetails_AccountGroup.Text = "Account Group"
			'
			'ComboBoxAccountRowDetails_Account
			'
			Me.ComboBoxAccountRowDetails_Account.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxAccountRowDetails_Account.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxAccountRowDetails_Account.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxAccountRowDetails_Account.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxAccountRowDetails_Account.AutoFindItemInDataSource = False
			Me.ComboBoxAccountRowDetails_Account.AutoSelectSingleItemDatasource = False
			Me.ComboBoxAccountRowDetails_Account.BookmarkingEnabled = False
			Me.ComboBoxAccountRowDetails_Account.ClientCode = ""
			Me.ComboBoxAccountRowDetails_Account.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
			Me.ComboBoxAccountRowDetails_Account.DisableMouseWheel = False
			Me.ComboBoxAccountRowDetails_Account.DisplayMember = "Description"
			Me.ComboBoxAccountRowDetails_Account.DisplayName = ""
			Me.ComboBoxAccountRowDetails_Account.DivisionCode = ""
			Me.ComboBoxAccountRowDetails_Account.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxAccountRowDetails_Account.Enabled = False
			Me.ComboBoxAccountRowDetails_Account.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxAccountRowDetails_Account.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxAccountRowDetails_Account.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxAccountRowDetails_Account.FocusHighlightEnabled = True
			Me.ComboBoxAccountRowDetails_Account.FormattingEnabled = True
			Me.ComboBoxAccountRowDetails_Account.ItemHeight = 14
			Me.ComboBoxAccountRowDetails_Account.Location = New System.Drawing.Point(136, 56)
			Me.ComboBoxAccountRowDetails_Account.Name = "ComboBoxAccountRowDetails_Account"
			Me.ComboBoxAccountRowDetails_Account.ReadOnly = False
			Me.ComboBoxAccountRowDetails_Account.SecurityEnabled = True
			Me.ComboBoxAccountRowDetails_Account.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxAccountRowDetails_Account.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxAccountRowDetails_Account.TabIndex = 5
			Me.ComboBoxAccountRowDetails_Account.TabOnEnter = True
			Me.ComboBoxAccountRowDetails_Account.ValueMember = "Code"
			Me.ComboBoxAccountRowDetails_Account.WatermarkText = "Select General Ledger Account"
			'
			'RadioButtonAccountRowDetails_Account
			'
			Me.RadioButtonAccountRowDetails_Account.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonAccountRowDetails_Account.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonAccountRowDetails_Account.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonAccountRowDetails_Account.Location = New System.Drawing.Point(4, 56)
			Me.RadioButtonAccountRowDetails_Account.Name = "RadioButtonAccountRowDetails_Account"
			Me.RadioButtonAccountRowDetails_Account.SecurityEnabled = True
			Me.RadioButtonAccountRowDetails_Account.Size = New System.Drawing.Size(126, 20)
			Me.RadioButtonAccountRowDetails_Account.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonAccountRowDetails_Account.TabIndex = 4
			Me.RadioButtonAccountRowDetails_Account.TabOnEnter = True
			Me.RadioButtonAccountRowDetails_Account.TabStop = False
			Me.RadioButtonAccountRowDetails_Account.Text = "Account"
			'
			'ComboBoxAccountRowDetails_AccountRangeStart
			'
			Me.ComboBoxAccountRowDetails_AccountRangeStart.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxAccountRowDetails_AccountRangeStart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxAccountRowDetails_AccountRangeStart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxAccountRowDetails_AccountRangeStart.AutoFindItemInDataSource = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.AutoSelectSingleItemDatasource = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.BookmarkingEnabled = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ClientCode = ""
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
			Me.ComboBoxAccountRowDetails_AccountRangeStart.DisableMouseWheel = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.DisplayMember = "Description"
			Me.ComboBoxAccountRowDetails_AccountRangeStart.DisplayName = ""
			Me.ComboBoxAccountRowDetails_AccountRangeStart.DivisionCode = ""
			Me.ComboBoxAccountRowDetails_AccountRangeStart.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Enabled = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxAccountRowDetails_AccountRangeStart.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxAccountRowDetails_AccountRangeStart.FocusHighlightEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeStart.FormattingEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ItemHeight = 14
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Location = New System.Drawing.Point(136, 82)
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Name = "ComboBoxAccountRowDetails_AccountRangeStart"
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ReadOnly = False
			Me.ComboBoxAccountRowDetails_AccountRangeStart.SecurityEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxAccountRowDetails_AccountRangeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxAccountRowDetails_AccountRangeStart.TabIndex = 7
			Me.ComboBoxAccountRowDetails_AccountRangeStart.TabOnEnter = True
			Me.ComboBoxAccountRowDetails_AccountRangeStart.ValueMember = "Code"
			Me.ComboBoxAccountRowDetails_AccountRangeStart.WatermarkText = "Select General Ledger Account"
			'
			'RadioButtonAccountRowDetails_AccountRange
			'
			Me.RadioButtonAccountRowDetails_AccountRange.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonAccountRowDetails_AccountRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonAccountRowDetails_AccountRange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonAccountRowDetails_AccountRange.Location = New System.Drawing.Point(4, 82)
			Me.RadioButtonAccountRowDetails_AccountRange.Name = "RadioButtonAccountRowDetails_AccountRange"
			Me.RadioButtonAccountRowDetails_AccountRange.SecurityEnabled = True
			Me.RadioButtonAccountRowDetails_AccountRange.Size = New System.Drawing.Size(126, 20)
			Me.RadioButtonAccountRowDetails_AccountRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonAccountRowDetails_AccountRange.TabIndex = 6
			Me.RadioButtonAccountRowDetails_AccountRange.TabOnEnter = True
			Me.RadioButtonAccountRowDetails_AccountRange.TabStop = False
			Me.RadioButtonAccountRowDetails_AccountRange.Text = "Account Range"
			'
			'ComboBoxAccountRowDetails_AccountRangeTo
			'
			Me.ComboBoxAccountRowDetails_AccountRangeTo.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxAccountRowDetails_AccountRangeTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxAccountRowDetails_AccountRangeTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxAccountRowDetails_AccountRangeTo.AutoFindItemInDataSource = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.AutoSelectSingleItemDatasource = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.BookmarkingEnabled = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ClientCode = ""
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
			Me.ComboBoxAccountRowDetails_AccountRangeTo.DisableMouseWheel = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.DisplayMember = "Description"
			Me.ComboBoxAccountRowDetails_AccountRangeTo.DisplayName = ""
			Me.ComboBoxAccountRowDetails_AccountRangeTo.DivisionCode = ""
			Me.ComboBoxAccountRowDetails_AccountRangeTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Enabled = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxAccountRowDetails_AccountRangeTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxAccountRowDetails_AccountRangeTo.FocusHighlightEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeTo.FormattingEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ItemHeight = 14
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Location = New System.Drawing.Point(136, 108)
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Name = "ComboBoxAccountRowDetails_AccountRangeTo"
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ReadOnly = False
			Me.ComboBoxAccountRowDetails_AccountRangeTo.SecurityEnabled = True
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxAccountRowDetails_AccountRangeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxAccountRowDetails_AccountRangeTo.TabIndex = 9
			Me.ComboBoxAccountRowDetails_AccountRangeTo.TabOnEnter = True
			Me.ComboBoxAccountRowDetails_AccountRangeTo.ValueMember = "Code"
			Me.ComboBoxAccountRowDetails_AccountRangeTo.WatermarkText = "Select General Ledger Account"
			'
			'RadioButtonAccountRowDetails_Wildcard
			'
			Me.RadioButtonAccountRowDetails_Wildcard.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonAccountRowDetails_Wildcard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonAccountRowDetails_Wildcard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonAccountRowDetails_Wildcard.Location = New System.Drawing.Point(4, 134)
			Me.RadioButtonAccountRowDetails_Wildcard.Name = "RadioButtonAccountRowDetails_Wildcard"
			Me.RadioButtonAccountRowDetails_Wildcard.SecurityEnabled = True
			Me.RadioButtonAccountRowDetails_Wildcard.Size = New System.Drawing.Size(126, 20)
			Me.RadioButtonAccountRowDetails_Wildcard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonAccountRowDetails_Wildcard.TabIndex = 10
			Me.RadioButtonAccountRowDetails_Wildcard.TabOnEnter = True
			Me.RadioButtonAccountRowDetails_Wildcard.TabStop = False
			Me.RadioButtonAccountRowDetails_Wildcard.Text = "Wildcard"
			Me.RadioButtonAccountRowDetails_Wildcard.Visible = False
			'
			'TextBoxAccountRowDetails_Wildcard
			'
			Me.TextBoxAccountRowDetails_Wildcard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TextBoxAccountRowDetails_Wildcard.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.TextBoxAccountRowDetails_Wildcard.Border.Class = "TextBoxBorder"
			Me.TextBoxAccountRowDetails_Wildcard.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxAccountRowDetails_Wildcard.CheckSpellingOnValidate = False
			Me.TextBoxAccountRowDetails_Wildcard.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxAccountRowDetails_Wildcard.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxAccountRowDetails_Wildcard.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxAccountRowDetails_Wildcard.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxAccountRowDetails_Wildcard.FocusHighlightEnabled = True
			Me.TextBoxAccountRowDetails_Wildcard.ForeColor = System.Drawing.Color.Black
			Me.TextBoxAccountRowDetails_Wildcard.Location = New System.Drawing.Point(136, 134)
			Me.TextBoxAccountRowDetails_Wildcard.MaxFileSize = CType(0, Long)
			Me.TextBoxAccountRowDetails_Wildcard.Name = "TextBoxAccountRowDetails_Wildcard"
			Me.TextBoxAccountRowDetails_Wildcard.SecurityEnabled = True
			Me.TextBoxAccountRowDetails_Wildcard.ShowSpellCheckCompleteMessage = True
			Me.TextBoxAccountRowDetails_Wildcard.Size = New System.Drawing.Size(402, 20)
			Me.TextBoxAccountRowDetails_Wildcard.StartingFolderName = Nothing
			Me.TextBoxAccountRowDetails_Wildcard.TabIndex = 11
			Me.TextBoxAccountRowDetails_Wildcard.TabOnEnter = True
			Me.TextBoxAccountRowDetails_Wildcard.Visible = False
			'
			'ComboBoxForm_DisplayType
			'
			Me.ComboBoxForm_DisplayType.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxForm_DisplayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxForm_DisplayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxForm_DisplayType.AutoFindItemInDataSource = False
			Me.ComboBoxForm_DisplayType.AutoSelectSingleItemDatasource = False
			Me.ComboBoxForm_DisplayType.BookmarkingEnabled = False
			Me.ComboBoxForm_DisplayType.ClientCode = ""
			Me.ComboBoxForm_DisplayType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
			Me.ComboBoxForm_DisplayType.DisableMouseWheel = False
			Me.ComboBoxForm_DisplayType.DisplayMember = "Name"
			Me.ComboBoxForm_DisplayType.DisplayName = ""
			Me.ComboBoxForm_DisplayType.DivisionCode = ""
			Me.ComboBoxForm_DisplayType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxForm_DisplayType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxForm_DisplayType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxForm_DisplayType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxForm_DisplayType.FocusHighlightEnabled = True
			Me.ComboBoxForm_DisplayType.FormattingEnabled = True
			Me.ComboBoxForm_DisplayType.ItemHeight = 14
			Me.ComboBoxForm_DisplayType.Location = New System.Drawing.Point(90, 64)
			Me.ComboBoxForm_DisplayType.Name = "ComboBoxForm_DisplayType"
			Me.ComboBoxForm_DisplayType.ReadOnly = False
			Me.ComboBoxForm_DisplayType.SecurityEnabled = True
			Me.ComboBoxForm_DisplayType.Size = New System.Drawing.Size(200, 20)
			Me.ComboBoxForm_DisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxForm_DisplayType.TabIndex = 7
			Me.ComboBoxForm_DisplayType.TabOnEnter = True
			Me.ComboBoxForm_DisplayType.ValueMember = "Value"
			Me.ComboBoxForm_DisplayType.WatermarkText = "Select"
			'
			'LabelForm_DisplayType
			'
			Me.LabelForm_DisplayType.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_DisplayType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_DisplayType.Location = New System.Drawing.Point(12, 64)
			Me.LabelForm_DisplayType.Name = "LabelForm_DisplayType"
			Me.LabelForm_DisplayType.Size = New System.Drawing.Size(72, 20)
			Me.LabelForm_DisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_DisplayType.TabIndex = 6
			Me.LabelForm_DisplayType.Text = "Display Type:"
			'
			'CheckBoxAccountRowDetails_UseBaseCodes
			'
			Me.CheckBoxAccountRowDetails_UseBaseCodes.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.CheckBoxAccountRowDetails_UseBaseCodes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxAccountRowDetails_UseBaseCodes.CheckValue = 0
			Me.CheckBoxAccountRowDetails_UseBaseCodes.CheckValueChecked = 1
			Me.CheckBoxAccountRowDetails_UseBaseCodes.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxAccountRowDetails_UseBaseCodes.CheckValueUnchecked = 0
			Me.CheckBoxAccountRowDetails_UseBaseCodes.ChildControls = CType(resources.GetObject("CheckBoxAccountRowDetails_UseBaseCodes.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxAccountRowDetails_UseBaseCodes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxAccountRowDetails_UseBaseCodes.Location = New System.Drawing.Point(25, 108)
			Me.CheckBoxAccountRowDetails_UseBaseCodes.Name = "CheckBoxAccountRowDetails_UseBaseCodes"
			Me.CheckBoxAccountRowDetails_UseBaseCodes.OldestSibling = Nothing
			Me.CheckBoxAccountRowDetails_UseBaseCodes.SecurityEnabled = True
			Me.CheckBoxAccountRowDetails_UseBaseCodes.SiblingControls = CType(resources.GetObject("CheckBoxAccountRowDetails_UseBaseCodes.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxAccountRowDetails_UseBaseCodes.Size = New System.Drawing.Size(105, 20)
			Me.CheckBoxAccountRowDetails_UseBaseCodes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxAccountRowDetails_UseBaseCodes.TabIndex = 8
			Me.CheckBoxAccountRowDetails_UseBaseCodes.TabOnEnter = True
			Me.CheckBoxAccountRowDetails_UseBaseCodes.Text = "Use Base Codes"
			'
			'ComboBoxForm_Type
			'
			Me.ComboBoxForm_Type.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxForm_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxForm_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxForm_Type.AutoFindItemInDataSource = False
			Me.ComboBoxForm_Type.AutoSelectSingleItemDatasource = False
			Me.ComboBoxForm_Type.BookmarkingEnabled = False
			Me.ComboBoxForm_Type.ClientCode = ""
			Me.ComboBoxForm_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
			Me.ComboBoxForm_Type.DisableMouseWheel = False
			Me.ComboBoxForm_Type.DisplayMember = "Name"
			Me.ComboBoxForm_Type.DisplayName = ""
			Me.ComboBoxForm_Type.DivisionCode = ""
			Me.ComboBoxForm_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxForm_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxForm_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxForm_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxForm_Type.FocusHighlightEnabled = True
			Me.ComboBoxForm_Type.FormattingEnabled = True
			Me.ComboBoxForm_Type.ItemHeight = 14
			Me.ComboBoxForm_Type.Location = New System.Drawing.Point(90, 38)
			Me.ComboBoxForm_Type.Name = "ComboBoxForm_Type"
			Me.ComboBoxForm_Type.ReadOnly = False
			Me.ComboBoxForm_Type.SecurityEnabled = True
			Me.ComboBoxForm_Type.Size = New System.Drawing.Size(200, 20)
			Me.ComboBoxForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxForm_Type.TabIndex = 3
			Me.ComboBoxForm_Type.TabOnEnter = True
			Me.ComboBoxForm_Type.ValueMember = "Value"
			Me.ComboBoxForm_Type.WatermarkText = "Select"
			'
			'LabelForm_Type
			'
			Me.LabelForm_Type.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Type.Location = New System.Drawing.Point(12, 38)
			Me.LabelForm_Type.Name = "LabelForm_Type"
			Me.LabelForm_Type.Size = New System.Drawing.Size(72, 20)
			Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Type.TabIndex = 2
			Me.LabelForm_Type.Text = "Type:"
			'
			'TabControlForm_RowDetails
			'
			Me.TabControlForm_RowDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TabControlForm_RowDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
			Me.TabControlForm_RowDetails.CanReorderTabs = False
			Me.TabControlForm_RowDetails.ColorScheme.TabBackground = System.Drawing.Color.White
			Me.TabControlForm_RowDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
			Me.TabControlForm_RowDetails.Controls.Add(Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails)
			Me.TabControlForm_RowDetails.Controls.Add(Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails)
			Me.TabControlForm_RowDetails.ForeColor = System.Drawing.Color.Black
			Me.TabControlForm_RowDetails.Location = New System.Drawing.Point(12, 116)
			Me.TabControlForm_RowDetails.Name = "TabControlForm_RowDetails"
			Me.TabControlForm_RowDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
			Me.TabControlForm_RowDetails.SelectedTabIndex = 0
			Me.TabControlForm_RowDetails.Size = New System.Drawing.Size(542, 373)
			Me.TabControlForm_RowDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
			Me.TabControlForm_RowDetails.TabIndex = 20
			Me.TabControlForm_RowDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
			Me.TabControlForm_RowDetails.Tabs.Add(Me.TabItemRowDetails_AccountRowDetailsTab)
			Me.TabControlForm_RowDetails.Tabs.Add(Me.TabItemRowDetails_TotalRowDetailsTab)
			'
			'TabControlPanelAccountRowDetailsTab_AccountRowDetails
			'
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.LabelAccountRowDetails_DataCalculations)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.PanelAccountRowDetails_DataCalculations)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.PanelAccountRowDetails_DataOptions)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.LabelAccountRowDetails_DataOptions)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.RadioButtonAccountRowDetails_AccountType)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.ComboBoxAccountRowDetails_AccountType)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.RadioButtonAccountRowDetails_AccountGroup)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.ComboBoxAccountRowDetails_AccountGroup)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.CheckBoxAccountRowDetails_UseBaseCodes)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.RadioButtonAccountRowDetails_Account)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.ComboBoxAccountRowDetails_Account)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.RadioButtonAccountRowDetails_AccountRange)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.TextBoxAccountRowDetails_Wildcard)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.ComboBoxAccountRowDetails_AccountRangeStart)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.RadioButtonAccountRowDetails_Wildcard)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Controls.Add(Me.ComboBoxAccountRowDetails_AccountRangeTo)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.DisabledBackColor = System.Drawing.Color.Empty
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Location = New System.Drawing.Point(0, 27)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Name = "TabControlPanelAccountRowDetailsTab_AccountRowDetails"
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Padding = New System.Windows.Forms.Padding(1)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Size = New System.Drawing.Size(542, 346)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.BackColor1.Color = System.Drawing.Color.White
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
			Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.Style.GradientAngle = 90
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.TabIndex = 0
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.TabItem = Me.TabItemRowDetails_AccountRowDetailsTab
			'
			'LabelAccountRowDetails_DataCalculations
			'
			Me.LabelAccountRowDetails_DataCalculations.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderBottomWidth = 1
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataCalculations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelAccountRowDetails_DataCalculations.Location = New System.Drawing.Point(4, 160)
			Me.LabelAccountRowDetails_DataCalculations.Name = "LabelAccountRowDetails_DataCalculations"
			Me.LabelAccountRowDetails_DataCalculations.Size = New System.Drawing.Size(152, 20)
			Me.LabelAccountRowDetails_DataCalculations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelAccountRowDetails_DataCalculations.TabIndex = 12
			Me.LabelAccountRowDetails_DataCalculations.Text = "Data Calculations"
			'
			'PanelAccountRowDetails_DataCalculations
			'
			Me.PanelAccountRowDetails_DataCalculations.BackColor = System.Drawing.Color.White
			Me.PanelAccountRowDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_All)
			Me.PanelAccountRowDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_YearToDate)
			Me.PanelAccountRowDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_SelectedPeriod)
			Me.PanelAccountRowDetails_DataCalculations.Location = New System.Drawing.Point(4, 186)
			Me.PanelAccountRowDetails_DataCalculations.Name = "PanelAccountRowDetails_DataCalculations"
			Me.PanelAccountRowDetails_DataCalculations.Size = New System.Drawing.Size(152, 80)
			Me.PanelAccountRowDetails_DataCalculations.TabIndex = 13
			'
			'RadioButtonDataCalculations_All
			'
			Me.RadioButtonDataCalculations_All.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataCalculations_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataCalculations_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataCalculations_All.Location = New System.Drawing.Point(0, 52)
			Me.RadioButtonDataCalculations_All.Name = "RadioButtonDataCalculations_All"
			Me.RadioButtonDataCalculations_All.SecurityEnabled = True
			Me.RadioButtonDataCalculations_All.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataCalculations_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataCalculations_All.TabIndex = 2
			Me.RadioButtonDataCalculations_All.TabOnEnter = True
			Me.RadioButtonDataCalculations_All.TabStop = False
			Me.RadioButtonDataCalculations_All.Text = "All"
			'
			'RadioButtonDataCalculations_YearToDate
			'
			Me.RadioButtonDataCalculations_YearToDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataCalculations_YearToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataCalculations_YearToDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataCalculations_YearToDate.Checked = True
			Me.RadioButtonDataCalculations_YearToDate.CheckState = System.Windows.Forms.CheckState.Checked
			Me.RadioButtonDataCalculations_YearToDate.CheckValue = "Y"
			Me.RadioButtonDataCalculations_YearToDate.Location = New System.Drawing.Point(0, 0)
			Me.RadioButtonDataCalculations_YearToDate.Name = "RadioButtonDataCalculations_YearToDate"
			Me.RadioButtonDataCalculations_YearToDate.SecurityEnabled = True
			Me.RadioButtonDataCalculations_YearToDate.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataCalculations_YearToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataCalculations_YearToDate.TabIndex = 0
			Me.RadioButtonDataCalculations_YearToDate.TabOnEnter = True
			Me.RadioButtonDataCalculations_YearToDate.Text = "Year To Date"
			'
			'RadioButtonDataCalculations_SelectedPeriod
			'
			Me.RadioButtonDataCalculations_SelectedPeriod.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataCalculations_SelectedPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataCalculations_SelectedPeriod.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataCalculations_SelectedPeriod.Location = New System.Drawing.Point(0, 26)
			Me.RadioButtonDataCalculations_SelectedPeriod.Name = "RadioButtonDataCalculations_SelectedPeriod"
			Me.RadioButtonDataCalculations_SelectedPeriod.SecurityEnabled = True
			Me.RadioButtonDataCalculations_SelectedPeriod.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataCalculations_SelectedPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataCalculations_SelectedPeriod.TabIndex = 1
			Me.RadioButtonDataCalculations_SelectedPeriod.TabOnEnter = True
			Me.RadioButtonDataCalculations_SelectedPeriod.TabStop = False
			Me.RadioButtonDataCalculations_SelectedPeriod.Text = "Selected Period"
			'
			'PanelAccountRowDetails_DataOptions
			'
			Me.PanelAccountRowDetails_DataOptions.BackColor = System.Drawing.Color.White
			Me.PanelAccountRowDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_PeriodChange)
			Me.PanelAccountRowDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_EndingBalance)
			Me.PanelAccountRowDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_BeginningBalance)
			Me.PanelAccountRowDetails_DataOptions.Location = New System.Drawing.Point(162, 186)
			Me.PanelAccountRowDetails_DataOptions.Name = "PanelAccountRowDetails_DataOptions"
			Me.PanelAccountRowDetails_DataOptions.Size = New System.Drawing.Size(152, 80)
			Me.PanelAccountRowDetails_DataOptions.TabIndex = 15
			'
			'RadioButtonDataOptions_PeriodChange
			'
			Me.RadioButtonDataOptions_PeriodChange.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataOptions_PeriodChange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataOptions_PeriodChange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataOptions_PeriodChange.Location = New System.Drawing.Point(0, 52)
			Me.RadioButtonDataOptions_PeriodChange.Name = "RadioButtonDataOptions_PeriodChange"
			Me.RadioButtonDataOptions_PeriodChange.SecurityEnabled = True
			Me.RadioButtonDataOptions_PeriodChange.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataOptions_PeriodChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataOptions_PeriodChange.TabIndex = 2
			Me.RadioButtonDataOptions_PeriodChange.TabOnEnter = True
			Me.RadioButtonDataOptions_PeriodChange.TabStop = False
			Me.RadioButtonDataOptions_PeriodChange.Text = "Period Change"
			'
			'RadioButtonDataOptions_EndingBalance
			'
			Me.RadioButtonDataOptions_EndingBalance.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataOptions_EndingBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataOptions_EndingBalance.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataOptions_EndingBalance.Checked = True
			Me.RadioButtonDataOptions_EndingBalance.CheckState = System.Windows.Forms.CheckState.Checked
			Me.RadioButtonDataOptions_EndingBalance.CheckValue = "Y"
			Me.RadioButtonDataOptions_EndingBalance.Location = New System.Drawing.Point(0, 0)
			Me.RadioButtonDataOptions_EndingBalance.Name = "RadioButtonDataOptions_EndingBalance"
			Me.RadioButtonDataOptions_EndingBalance.SecurityEnabled = True
			Me.RadioButtonDataOptions_EndingBalance.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataOptions_EndingBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataOptions_EndingBalance.TabIndex = 0
			Me.RadioButtonDataOptions_EndingBalance.TabOnEnter = True
			Me.RadioButtonDataOptions_EndingBalance.Text = "Ending Balance"
			'
			'RadioButtonDataOptions_BeginningBalance
			'
			Me.RadioButtonDataOptions_BeginningBalance.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonDataOptions_BeginningBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonDataOptions_BeginningBalance.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonDataOptions_BeginningBalance.Location = New System.Drawing.Point(0, 26)
			Me.RadioButtonDataOptions_BeginningBalance.Name = "RadioButtonDataOptions_BeginningBalance"
			Me.RadioButtonDataOptions_BeginningBalance.SecurityEnabled = True
			Me.RadioButtonDataOptions_BeginningBalance.Size = New System.Drawing.Size(152, 20)
			Me.RadioButtonDataOptions_BeginningBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonDataOptions_BeginningBalance.TabIndex = 1
			Me.RadioButtonDataOptions_BeginningBalance.TabOnEnter = True
			Me.RadioButtonDataOptions_BeginningBalance.TabStop = False
			Me.RadioButtonDataOptions_BeginningBalance.Text = "Beginning Balance"
			'
			'LabelAccountRowDetails_DataOptions
			'
			Me.LabelAccountRowDetails_DataOptions.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderBottomWidth = 1
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
			Me.LabelAccountRowDetails_DataOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelAccountRowDetails_DataOptions.Location = New System.Drawing.Point(162, 160)
			Me.LabelAccountRowDetails_DataOptions.Name = "LabelAccountRowDetails_DataOptions"
			Me.LabelAccountRowDetails_DataOptions.Size = New System.Drawing.Size(152, 20)
			Me.LabelAccountRowDetails_DataOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelAccountRowDetails_DataOptions.TabIndex = 14
			Me.LabelAccountRowDetails_DataOptions.Text = "Data Options"
			'
			'TabItemRowDetails_AccountRowDetailsTab
			'
			Me.TabItemRowDetails_AccountRowDetailsTab.AttachedControl = Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails
			Me.TabItemRowDetails_AccountRowDetailsTab.Name = "TabItemRowDetails_AccountRowDetailsTab"
			Me.TabItemRowDetails_AccountRowDetailsTab.Text = "Account Row Details"
			'
			'TabControlPanelTotalRowDetailsTab_TotalRowDetails
			'
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Controls.Add(Me.PanelTotalRowDetails_TotalRowDetails)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Controls.Add(Me.ComboBoxTableRowDetails_TotalBy)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Controls.Add(Me.LabelTableRowDetails_TotalBy)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.DisabledBackColor = System.Drawing.Color.Empty
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Location = New System.Drawing.Point(0, 27)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Name = "TabControlPanelTotalRowDetailsTab_TotalRowDetails"
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Padding = New System.Windows.Forms.Padding(1)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Size = New System.Drawing.Size(542, 346)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.BackColor1.Color = System.Drawing.Color.White
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
			Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.Style.GradientAngle = 90
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.TabIndex = 0
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.TabItem = Me.TabItemRowDetails_TotalRowDetailsTab
			'
			'PanelTotalRowDetails_TotalRowDetails
			'
			Me.PanelTotalRowDetails_TotalRowDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.PanelTotalRowDetails_TotalRowDetails.Appearance.BackColor = System.Drawing.Color.White
			Me.PanelTotalRowDetails_TotalRowDetails.Appearance.Options.UseBackColor = True
			Me.PanelTotalRowDetails_TotalRowDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.PanelTotalRowDetails_TotalRowDetails.Controls.Add(Me.PanelTotalRowDetails_RightSection)
			Me.PanelTotalRowDetails_TotalRowDetails.Controls.Add(Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection)
			Me.PanelTotalRowDetails_TotalRowDetails.Controls.Add(Me.PanelTotalRowDetails_LeftSection)
			Me.PanelTotalRowDetails_TotalRowDetails.Location = New System.Drawing.Point(4, 30)
			Me.PanelTotalRowDetails_TotalRowDetails.Name = "PanelTotalRowDetails_TotalRowDetails"
			Me.PanelTotalRowDetails_TotalRowDetails.Size = New System.Drawing.Size(534, 312)
			Me.PanelTotalRowDetails_TotalRowDetails.TabIndex = 10
			'
			'PanelTotalRowDetails_RightSection
			'
			Me.PanelTotalRowDetails_RightSection.Appearance.BackColor = System.Drawing.Color.White
			Me.PanelTotalRowDetails_RightSection.Appearance.Options.UseBackColor = True
			Me.PanelTotalRowDetails_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.PanelTotalRowDetails_RightSection.Controls.Add(Me.ButtonRightSection_Add)
			Me.PanelTotalRowDetails_RightSection.Controls.Add(Me.ButtonRightSection_AddAll)
			Me.PanelTotalRowDetails_RightSection.Controls.Add(Me.ButtonRightSection_RemoveAll)
			Me.PanelTotalRowDetails_RightSection.Controls.Add(Me.ButtonRightSection_Remove)
			Me.PanelTotalRowDetails_RightSection.Controls.Add(Me.DataGridViewRightSection_RelatedRows)
			Me.PanelTotalRowDetails_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PanelTotalRowDetails_RightSection.Location = New System.Drawing.Point(240, 0)
			Me.PanelTotalRowDetails_RightSection.Name = "PanelTotalRowDetails_RightSection"
			Me.PanelTotalRowDetails_RightSection.Size = New System.Drawing.Size(294, 312)
			Me.PanelTotalRowDetails_RightSection.TabIndex = 1
			'
			'ButtonRightSection_Add
			'
			Me.ButtonRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonRightSection_Add.Location = New System.Drawing.Point(6, 0)
			Me.ButtonRightSection_Add.Name = "ButtonRightSection_Add"
			Me.ButtonRightSection_Add.SecurityEnabled = True
			Me.ButtonRightSection_Add.Size = New System.Drawing.Size(75, 20)
			Me.ButtonRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonRightSection_Add.TabIndex = 0
			Me.ButtonRightSection_Add.Text = ">"
			'
			'ButtonRightSection_AddAll
			'
			Me.ButtonRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
			Me.ButtonRightSection_AddAll.Name = "ButtonRightSection_AddAll"
			Me.ButtonRightSection_AddAll.SecurityEnabled = True
			Me.ButtonRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
			Me.ButtonRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonRightSection_AddAll.TabIndex = 1
			Me.ButtonRightSection_AddAll.Text = ">>"
			'
			'ButtonRightSection_RemoveAll
			'
			Me.ButtonRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
			Me.ButtonRightSection_RemoveAll.Name = "ButtonRightSection_RemoveAll"
			Me.ButtonRightSection_RemoveAll.SecurityEnabled = True
			Me.ButtonRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
			Me.ButtonRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonRightSection_RemoveAll.TabIndex = 3
			Me.ButtonRightSection_RemoveAll.Text = "<<"
			'
			'ButtonRightSection_Remove
			'
			Me.ButtonRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonRightSection_Remove.Location = New System.Drawing.Point(6, 52)
			Me.ButtonRightSection_Remove.Name = "ButtonRightSection_Remove"
			Me.ButtonRightSection_Remove.SecurityEnabled = True
			Me.ButtonRightSection_Remove.Size = New System.Drawing.Size(75, 20)
			Me.ButtonRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonRightSection_Remove.TabIndex = 2
			Me.ButtonRightSection_Remove.Text = "<"
			'
			'DataGridViewRightSection_RelatedRows
			'
			Me.DataGridViewRightSection_RelatedRows.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewRightSection_RelatedRows.AllowDragAndDrop = False
			Me.DataGridViewRightSection_RelatedRows.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewRightSection_RelatedRows.AllowSelectGroupHeaderRow = True
			Me.DataGridViewRightSection_RelatedRows.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewRightSection_RelatedRows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewRightSection_RelatedRows.AutoFilterLookupColumns = False
			Me.DataGridViewRightSection_RelatedRows.AutoloadRepositoryDatasource = True
			Me.DataGridViewRightSection_RelatedRows.AutoUpdateViewCaption = True
			Me.DataGridViewRightSection_RelatedRows.BackColor = System.Drawing.Color.White
			Me.DataGridViewRightSection_RelatedRows.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewRightSection_RelatedRows.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewRightSection_RelatedRows.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewRightSection_RelatedRows.ItemDescription = ""
			Me.DataGridViewRightSection_RelatedRows.Location = New System.Drawing.Point(87, 0)
			Me.DataGridViewRightSection_RelatedRows.MultiSelect = True
			Me.DataGridViewRightSection_RelatedRows.Name = "DataGridViewRightSection_RelatedRows"
			Me.DataGridViewRightSection_RelatedRows.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewRightSection_RelatedRows.RunStandardValidation = True
			Me.DataGridViewRightSection_RelatedRows.ShowColumnMenuOnRightClick = False
			Me.DataGridViewRightSection_RelatedRows.ShowSelectDeselectAllButtons = False
			Me.DataGridViewRightSection_RelatedRows.Size = New System.Drawing.Size(207, 312)
			Me.DataGridViewRightSection_RelatedRows.TabIndex = 4
			Me.DataGridViewRightSection_RelatedRows.UseEmbeddedNavigator = False
			Me.DataGridViewRightSection_RelatedRows.ViewCaptionHeight = -1
			'
			'ExpandableSplitterPanelTotalRowDetails_LeftRightSection
			'
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.ForeColor = System.Drawing.Color.Black
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.Location = New System.Drawing.Point(234, 0)
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.Name = "ExpandableSplitterPanelTotalRowDetails_LeftRightSection"
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.Size = New System.Drawing.Size(6, 312)
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.TabIndex = 0
			Me.ExpandableSplitterPanelTotalRowDetails_LeftRightSection.TabStop = False
			'
			'PanelTotalRowDetails_LeftSection
			'
			Me.PanelTotalRowDetails_LeftSection.Appearance.BackColor = System.Drawing.Color.White
			Me.PanelTotalRowDetails_LeftSection.Appearance.Options.UseBackColor = True
			Me.PanelTotalRowDetails_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.PanelTotalRowDetails_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Rows)
			Me.PanelTotalRowDetails_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
			Me.PanelTotalRowDetails_LeftSection.Location = New System.Drawing.Point(0, 0)
			Me.PanelTotalRowDetails_LeftSection.Name = "PanelTotalRowDetails_LeftSection"
			Me.PanelTotalRowDetails_LeftSection.Size = New System.Drawing.Size(234, 312)
			Me.PanelTotalRowDetails_LeftSection.TabIndex = 0
			'
			'DataGridViewLeftSection_Rows
			'
			Me.DataGridViewLeftSection_Rows.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewLeftSection_Rows.AllowDragAndDrop = False
			Me.DataGridViewLeftSection_Rows.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewLeftSection_Rows.AllowSelectGroupHeaderRow = True
			Me.DataGridViewLeftSection_Rows.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewLeftSection_Rows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewLeftSection_Rows.AutoFilterLookupColumns = False
			Me.DataGridViewLeftSection_Rows.AutoloadRepositoryDatasource = True
			Me.DataGridViewLeftSection_Rows.AutoUpdateViewCaption = True
			Me.DataGridViewLeftSection_Rows.BackColor = System.Drawing.Color.White
			Me.DataGridViewLeftSection_Rows.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
			Me.DataGridViewLeftSection_Rows.DataSource = Nothing
			Me.DataGridViewLeftSection_Rows.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewLeftSection_Rows.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewLeftSection_Rows.ItemDescription = ""
			Me.DataGridViewLeftSection_Rows.Location = New System.Drawing.Point(0, 0)
			Me.DataGridViewLeftSection_Rows.MultiSelect = True
			Me.DataGridViewLeftSection_Rows.Name = "DataGridViewLeftSection_Rows"
			Me.DataGridViewLeftSection_Rows.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewLeftSection_Rows.RunStandardValidation = True
			Me.DataGridViewLeftSection_Rows.ShowColumnMenuOnRightClick = False
			Me.DataGridViewLeftSection_Rows.ShowSelectDeselectAllButtons = False
			Me.DataGridViewLeftSection_Rows.Size = New System.Drawing.Size(228, 312)
			Me.DataGridViewLeftSection_Rows.TabIndex = 0
			Me.DataGridViewLeftSection_Rows.UseEmbeddedNavigator = False
			Me.DataGridViewLeftSection_Rows.ViewCaptionHeight = -1
			'
			'ComboBoxTableRowDetails_TotalBy
			'
			Me.ComboBoxTableRowDetails_TotalBy.AddInactiveItemsOnSelectedValue = False
			Me.ComboBoxTableRowDetails_TotalBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ComboBoxTableRowDetails_TotalBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBoxTableRowDetails_TotalBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBoxTableRowDetails_TotalBy.AutoFindItemInDataSource = False
			Me.ComboBoxTableRowDetails_TotalBy.AutoSelectSingleItemDatasource = False
			Me.ComboBoxTableRowDetails_TotalBy.BookmarkingEnabled = False
			Me.ComboBoxTableRowDetails_TotalBy.ClientCode = ""
			Me.ComboBoxTableRowDetails_TotalBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
			Me.ComboBoxTableRowDetails_TotalBy.DisableMouseWheel = False
			Me.ComboBoxTableRowDetails_TotalBy.DisplayMember = "Name"
			Me.ComboBoxTableRowDetails_TotalBy.DisplayName = ""
			Me.ComboBoxTableRowDetails_TotalBy.DivisionCode = ""
			Me.ComboBoxTableRowDetails_TotalBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
			Me.ComboBoxTableRowDetails_TotalBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.ComboBoxTableRowDetails_TotalBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
			Me.ComboBoxTableRowDetails_TotalBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.ComboBoxTableRowDetails_TotalBy.FocusHighlightEnabled = True
			Me.ComboBoxTableRowDetails_TotalBy.FormattingEnabled = True
			Me.ComboBoxTableRowDetails_TotalBy.ItemHeight = 14
			Me.ComboBoxTableRowDetails_TotalBy.Location = New System.Drawing.Point(136, 4)
			Me.ComboBoxTableRowDetails_TotalBy.Name = "ComboBoxTableRowDetails_TotalBy"
			Me.ComboBoxTableRowDetails_TotalBy.ReadOnly = False
			Me.ComboBoxTableRowDetails_TotalBy.SecurityEnabled = True
			Me.ComboBoxTableRowDetails_TotalBy.Size = New System.Drawing.Size(402, 20)
			Me.ComboBoxTableRowDetails_TotalBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ComboBoxTableRowDetails_TotalBy.TabIndex = 1
			Me.ComboBoxTableRowDetails_TotalBy.TabOnEnter = True
			Me.ComboBoxTableRowDetails_TotalBy.ValueMember = "Value"
			Me.ComboBoxTableRowDetails_TotalBy.WatermarkText = "Select"
			'
			'LabelTableRowDetails_TotalBy
			'
			Me.LabelTableRowDetails_TotalBy.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelTableRowDetails_TotalBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelTableRowDetails_TotalBy.Location = New System.Drawing.Point(4, 4)
			Me.LabelTableRowDetails_TotalBy.Name = "LabelTableRowDetails_TotalBy"
			Me.LabelTableRowDetails_TotalBy.Size = New System.Drawing.Size(126, 20)
			Me.LabelTableRowDetails_TotalBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelTableRowDetails_TotalBy.TabIndex = 0
			Me.LabelTableRowDetails_TotalBy.Text = "Total By:"
			'
			'TabItemRowDetails_TotalRowDetailsTab
			'
			Me.TabItemRowDetails_TotalRowDetailsTab.AttachedControl = Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails
			Me.TabItemRowDetails_TotalRowDetailsTab.Name = "TabItemRowDetails_TotalRowDetailsTab"
			Me.TabItemRowDetails_TotalRowDetailsTab.Text = "Total Row Details"
			'
			'LabelForm_IndentSpaces
			'
			Me.LabelForm_IndentSpaces.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_IndentSpaces.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_IndentSpaces.Location = New System.Drawing.Point(296, 64)
			Me.LabelForm_IndentSpaces.Name = "LabelForm_IndentSpaces"
			Me.LabelForm_IndentSpaces.Size = New System.Drawing.Size(78, 20)
			Me.LabelForm_IndentSpaces.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_IndentSpaces.TabIndex = 8
			Me.LabelForm_IndentSpaces.Text = "Indent Spaces:"
			'
			'NumericInputForm_IndentSpaces
			'
			Me.NumericInputForm_IndentSpaces.AllowKeyUpAndDownToIncrementValue = False
			Me.NumericInputForm_IndentSpaces.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
			Me.NumericInputForm_IndentSpaces.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
			Me.NumericInputForm_IndentSpaces.EnterMoveNextControl = True
			Me.NumericInputForm_IndentSpaces.Location = New System.Drawing.Point(380, 64)
			Me.NumericInputForm_IndentSpaces.Name = "NumericInputForm_IndentSpaces"
			Me.NumericInputForm_IndentSpaces.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.NumericInputForm_IndentSpaces.Properties.DisplayFormat.FormatString = "f0"
			Me.NumericInputForm_IndentSpaces.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.NumericInputForm_IndentSpaces.Properties.EditFormat.FormatString = "f0"
			Me.NumericInputForm_IndentSpaces.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.NumericInputForm_IndentSpaces.Properties.IsFloatValue = False
			Me.NumericInputForm_IndentSpaces.Properties.Mask.EditMask = "f0"
			Me.NumericInputForm_IndentSpaces.Properties.Mask.UseMaskAsDisplayFormat = True
			Me.NumericInputForm_IndentSpaces.Properties.MaxLength = 11
			Me.NumericInputForm_IndentSpaces.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
			Me.NumericInputForm_IndentSpaces.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
			Me.NumericInputForm_IndentSpaces.SecurityEnabled = True
			Me.NumericInputForm_IndentSpaces.Size = New System.Drawing.Size(110, 20)
			Me.NumericInputForm_IndentSpaces.TabIndex = 9
			'
			'CheckBoxForm_Bold
			'
			'
			'
			'
			Me.CheckBoxForm_Bold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_Bold.CheckValue = 0
			Me.CheckBoxForm_Bold.CheckValueChecked = 1
			Me.CheckBoxForm_Bold.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_Bold.CheckValueUnchecked = 0
			Me.CheckBoxForm_Bold.ChildControls = CType(resources.GetObject("CheckBoxForm_Bold.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_Bold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_Bold.Location = New System.Drawing.Point(90, 90)
			Me.CheckBoxForm_Bold.Name = "CheckBoxForm_Bold"
			Me.CheckBoxForm_Bold.OldestSibling = Nothing
			Me.CheckBoxForm_Bold.SecurityEnabled = True
			Me.CheckBoxForm_Bold.SiblingControls = CType(resources.GetObject("CheckBoxForm_Bold.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_Bold.Size = New System.Drawing.Size(64, 20)
			Me.CheckBoxForm_Bold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_Bold.TabIndex = 12
			Me.CheckBoxForm_Bold.TabOnEnter = True
			Me.CheckBoxForm_Bold.Text = "Bold"
			'
			'CheckBoxForm_UnderlineAmount
			'
			'
			'
			'
			Me.CheckBoxForm_UnderlineAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_UnderlineAmount.CheckValue = 0
			Me.CheckBoxForm_UnderlineAmount.CheckValueChecked = 1
			Me.CheckBoxForm_UnderlineAmount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_UnderlineAmount.CheckValueUnchecked = 0
			Me.CheckBoxForm_UnderlineAmount.ChildControls = CType(resources.GetObject("CheckBoxForm_UnderlineAmount.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_UnderlineAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_UnderlineAmount.Location = New System.Drawing.Point(160, 90)
			Me.CheckBoxForm_UnderlineAmount.Name = "CheckBoxForm_UnderlineAmount"
			Me.CheckBoxForm_UnderlineAmount.OldestSibling = Nothing
			Me.CheckBoxForm_UnderlineAmount.SecurityEnabled = True
			Me.CheckBoxForm_UnderlineAmount.SiblingControls = CType(resources.GetObject("CheckBoxForm_UnderlineAmount.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_UnderlineAmount.Size = New System.Drawing.Size(111, 20)
			Me.CheckBoxForm_UnderlineAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_UnderlineAmount.TabIndex = 13
			Me.CheckBoxForm_UnderlineAmount.TabOnEnter = True
			Me.CheckBoxForm_UnderlineAmount.Text = "Underline Amount"
			'
			'CheckBoxForm_SuppressIfAllZeros
			'
			Me.CheckBoxForm_SuppressIfAllZeros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			'
			'
			'
			Me.CheckBoxForm_SuppressIfAllZeros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_SuppressIfAllZeros.CheckValue = 0
			Me.CheckBoxForm_SuppressIfAllZeros.CheckValueChecked = 1
			Me.CheckBoxForm_SuppressIfAllZeros.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_SuppressIfAllZeros.CheckValueUnchecked = 0
			Me.CheckBoxForm_SuppressIfAllZeros.ChildControls = CType(resources.GetObject("CheckBoxForm_SuppressIfAllZeros.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_SuppressIfAllZeros.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_SuppressIfAllZeros.Location = New System.Drawing.Point(432, 90)
			Me.CheckBoxForm_SuppressIfAllZeros.Name = "CheckBoxForm_SuppressIfAllZeros"
			Me.CheckBoxForm_SuppressIfAllZeros.OldestSibling = Nothing
			Me.CheckBoxForm_SuppressIfAllZeros.SecurityEnabled = True
			Me.CheckBoxForm_SuppressIfAllZeros.SiblingControls = CType(resources.GetObject("CheckBoxForm_SuppressIfAllZeros.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_SuppressIfAllZeros.Size = New System.Drawing.Size(122, 20)
			Me.CheckBoxForm_SuppressIfAllZeros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_SuppressIfAllZeros.TabIndex = 15
			Me.CheckBoxForm_SuppressIfAllZeros.TabOnEnter = True
			Me.CheckBoxForm_SuppressIfAllZeros.Text = "Suppress If All Zeros"
			'
			'TextBoxForm_Description
			'
			Me.TextBoxForm_Description.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
			Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxForm_Description.CheckSpellingOnValidate = False
			Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxForm_Description.FocusHighlightEnabled = True
			Me.TextBoxForm_Description.ForeColor = System.Drawing.Color.Black
			Me.TextBoxForm_Description.Location = New System.Drawing.Point(90, 12)
			Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
			Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
			Me.TextBoxForm_Description.SecurityEnabled = True
			Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
			Me.TextBoxForm_Description.Size = New System.Drawing.Size(400, 20)
			Me.TextBoxForm_Description.StartingFolderName = Nothing
			Me.TextBoxForm_Description.TabIndex = 1
			Me.TextBoxForm_Description.TabOnEnter = True
			'
			'LabelForm_Description
			'
			Me.LabelForm_Description.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Description.Location = New System.Drawing.Point(12, 12)
			Me.LabelForm_Description.Name = "LabelForm_Description"
			Me.LabelForm_Description.Size = New System.Drawing.Size(72, 20)
			Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Description.TabIndex = 0
			Me.LabelForm_Description.Text = "Description:"
			'
			'ButtonForm_Add
			'
			Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Add.Location = New System.Drawing.Point(398, 495)
			Me.ButtonForm_Add.Name = "ButtonForm_Add"
			Me.ButtonForm_Add.SecurityEnabled = True
			Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Add.TabIndex = 21
			Me.ButtonForm_Add.Text = "Add"
			'
			'ButtonForm_Update
			'
			Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Update.Location = New System.Drawing.Point(398, 495)
			Me.ButtonForm_Update.Name = "ButtonForm_Update"
			Me.ButtonForm_Update.SecurityEnabled = True
			Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Update.TabIndex = 22
			Me.ButtonForm_Update.Text = "Update"
			'
			'LabelForm_Style
			'
			Me.LabelForm_Style.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Style.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Style.Location = New System.Drawing.Point(12, 90)
			Me.LabelForm_Style.Name = "LabelForm_Style"
			Me.LabelForm_Style.Size = New System.Drawing.Size(72, 20)
			Me.LabelForm_Style.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Style.TabIndex = 11
			Me.LabelForm_Style.Text = "Style:"
			'
			'CheckBoxForm_Rollup
			'
			Me.CheckBoxForm_Rollup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			'
			'
			'
			Me.CheckBoxForm_Rollup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_Rollup.CheckValue = 0
			Me.CheckBoxForm_Rollup.CheckValueChecked = 1
			Me.CheckBoxForm_Rollup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_Rollup.CheckValueUnchecked = 0
			Me.CheckBoxForm_Rollup.ChildControls = CType(resources.GetObject("CheckBoxForm_Rollup.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_Rollup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_Rollup.Location = New System.Drawing.Point(496, 64)
			Me.CheckBoxForm_Rollup.Name = "CheckBoxForm_Rollup"
			Me.CheckBoxForm_Rollup.OldestSibling = Nothing
			Me.CheckBoxForm_Rollup.SecurityEnabled = True
			Me.CheckBoxForm_Rollup.SiblingControls = CType(resources.GetObject("CheckBoxForm_Rollup.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_Rollup.Size = New System.Drawing.Size(58, 20)
			Me.CheckBoxForm_Rollup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_Rollup.TabIndex = 10
			Me.CheckBoxForm_Rollup.TabOnEnter = True
			Me.CheckBoxForm_Rollup.Text = "Rollup"
			'
			'CheckBoxForm_DoubleUnderlineAmount
			'
			'
			'
			'
			Me.CheckBoxForm_DoubleUnderlineAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_DoubleUnderlineAmount.CheckValue = 0
			Me.CheckBoxForm_DoubleUnderlineAmount.CheckValueChecked = 1
			Me.CheckBoxForm_DoubleUnderlineAmount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_DoubleUnderlineAmount.CheckValueUnchecked = 0
			Me.CheckBoxForm_DoubleUnderlineAmount.ChildControls = CType(resources.GetObject("CheckBoxForm_DoubleUnderlineAmount.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_DoubleUnderlineAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_DoubleUnderlineAmount.Location = New System.Drawing.Point(277, 90)
			Me.CheckBoxForm_DoubleUnderlineAmount.Name = "CheckBoxForm_DoubleUnderlineAmount"
			Me.CheckBoxForm_DoubleUnderlineAmount.OldestSibling = Nothing
			Me.CheckBoxForm_DoubleUnderlineAmount.SecurityEnabled = True
			Me.CheckBoxForm_DoubleUnderlineAmount.SiblingControls = CType(resources.GetObject("CheckBoxForm_DoubleUnderlineAmount.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_DoubleUnderlineAmount.Size = New System.Drawing.Size(149, 20)
			Me.CheckBoxForm_DoubleUnderlineAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_DoubleUnderlineAmount.TabIndex = 14
			Me.CheckBoxForm_DoubleUnderlineAmount.TabOnEnter = True
			Me.CheckBoxForm_DoubleUnderlineAmount.Text = "Double Underline Amount"
			'
			'CheckBoxForm_IsVisible
			'
			'
			'
			'
			Me.CheckBoxForm_IsVisible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_IsVisible.CheckValue = 0
			Me.CheckBoxForm_IsVisible.CheckValueChecked = 1
			Me.CheckBoxForm_IsVisible.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_IsVisible.CheckValueUnchecked = 0
			Me.CheckBoxForm_IsVisible.ChildControls = CType(resources.GetObject("CheckBoxForm_IsVisible.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_IsVisible.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_IsVisible.Location = New System.Drawing.Point(496, 12)
			Me.CheckBoxForm_IsVisible.Name = "CheckBoxForm_IsVisible"
			Me.CheckBoxForm_IsVisible.OldestSibling = Nothing
			Me.CheckBoxForm_IsVisible.SecurityEnabled = True
			Me.CheckBoxForm_IsVisible.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsVisible.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_IsVisible.Size = New System.Drawing.Size(58, 20)
			Me.CheckBoxForm_IsVisible.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_IsVisible.TabIndex = 24
			Me.CheckBoxForm_IsVisible.TabOnEnter = True
			Me.CheckBoxForm_IsVisible.Text = "Visible"
			'
			'GLReportTemplateRowEditDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(566, 527)
			Me.Controls.Add(Me.CheckBoxForm_IsVisible)
			Me.Controls.Add(Me.CheckBoxForm_DoubleUnderlineAmount)
			Me.Controls.Add(Me.CheckBoxForm_Rollup)
			Me.Controls.Add(Me.LabelForm_Style)
			Me.Controls.Add(Me.ButtonForm_Add)
			Me.Controls.Add(Me.ButtonForm_Update)
			Me.Controls.Add(Me.LabelForm_Description)
			Me.Controls.Add(Me.TextBoxForm_Description)
			Me.Controls.Add(Me.CheckBoxForm_SuppressIfAllZeros)
			Me.Controls.Add(Me.CheckBoxForm_UnderlineAmount)
			Me.Controls.Add(Me.CheckBoxForm_Bold)
			Me.Controls.Add(Me.NumericInputForm_IndentSpaces)
			Me.Controls.Add(Me.LabelForm_IndentSpaces)
			Me.Controls.Add(Me.TabControlForm_RowDetails)
			Me.Controls.Add(Me.ComboBoxForm_Type)
			Me.Controls.Add(Me.LabelForm_Type)
			Me.Controls.Add(Me.ComboBoxForm_DisplayType)
			Me.Controls.Add(Me.LabelForm_DisplayType)
			Me.Controls.Add(Me.ComboBoxForm_Balance)
			Me.Controls.Add(Me.LabelForm_Balance)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "GLReportTemplateRowEditDialog"
			Me.Text = "Edit Row"
			CType(Me.TabControlForm_RowDetails, System.ComponentModel.ISupportInitialize).EndInit()
			Me.TabControlForm_RowDetails.ResumeLayout(False)
			Me.TabControlPanelAccountRowDetailsTab_AccountRowDetails.ResumeLayout(False)
			Me.PanelAccountRowDetails_DataCalculations.ResumeLayout(False)
			Me.PanelAccountRowDetails_DataOptions.ResumeLayout(False)
			Me.TabControlPanelTotalRowDetailsTab_TotalRowDetails.ResumeLayout(False)
			CType(Me.PanelTotalRowDetails_TotalRowDetails, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelTotalRowDetails_TotalRowDetails.ResumeLayout(False)
			CType(Me.PanelTotalRowDetails_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelTotalRowDetails_RightSection.ResumeLayout(False)
			CType(Me.PanelTotalRowDetails_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelTotalRowDetails_LeftSection.ResumeLayout(False)
			CType(Me.NumericInputForm_IndentSpaces.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Balance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Balance As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonAccountRowDetails_AccountType As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxAccountRowDetails_AccountType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAccountRowDetails_AccountGroup As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonAccountRowDetails_AccountGroup As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxAccountRowDetails_Account As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonAccountRowDetails_Account As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxAccountRowDetails_AccountRangeStart As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonAccountRowDetails_AccountRange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxAccountRowDetails_AccountRangeTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonAccountRowDetails_Wildcard As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxAccountRowDetails_Wildcard As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxForm_DisplayType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_DisplayType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxAccountRowDetails_UseBaseCodes As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxForm_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlForm_RowDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAccountRowDetailsTab_AccountRowDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRowDetails_AccountRowDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTotalRowDetailsTab_TotalRowDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemRowDetails_TotalRowDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxTableRowDetails_TotalBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTableRowDetails_TotalBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_IndentSpaces As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputForm_IndentSpaces As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxForm_Bold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UnderlineAmount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelTotalRowDetails_TotalRowDetails As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelTotalRowDetails_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_RelatedRows As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterPanelTotalRowDetails_LeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelTotalRowDetails_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Rows As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxForm_SuppressIfAllZeros As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Style As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Rollup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountRowDetails_DataOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelAccountRowDetails_DataOptions As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonDataOptions_PeriodChange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOptions_EndingBalance As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOptions_BeginningBalance As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelAccountRowDetails_DataCalculations As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelAccountRowDetails_DataCalculations As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonDataCalculations_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataCalculations_YearToDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataCalculations_SelectedPeriod As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxForm_DoubleUnderlineAmount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxForm_IsVisible As WinForm.Presentation.Controls.CheckBox
	End Class

End Namespace
