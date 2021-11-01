Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateColumnEditDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateColumnEditDialog))
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.ComboBoxForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelDataColumnDetails_DataType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxDataColumnDetails_DataType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.LabelDataColumnDetails_PreviousYears = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelDataColumnDetails_PeriodOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.NumericInputDataColumnDetails_PreviousYears = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.CheckBoxForm_Visible = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.ButtonExpressionColumnDetails_Expression = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TextBoxExpressionColumnDetails_Expression = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelExpressionColumnDetails_Expression = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxForm_UnderlineColumnHeader = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.NumericInputForm_NumberOfDecimalPlaces = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelForm_NumberOfDecimalPlaces = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxForm_Currency = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.ComboBoxVariancePercentVarianceColumnDetails_Column1 = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.LabelVariancePercentVarianceColumnDetails_Column1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelVariancePercentVarianceColumnDetails_Column2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxVariancePercentVarianceColumnDetails_Column2 = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.TabControlForm_ColumnDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDataColumnDetails_DataCalculations = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelDataColumnDetails_DataCalculations = New System.Windows.Forms.Panel()
            Me.RadioButtonDataCalculations_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataCalculations_YearToDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataCalculations_SelectedPeriod = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelDataColumnDetails_DataOptions = New System.Windows.Forms.Panel()
            Me.RadioButtonDataOptions_PeriodChange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataOptions_EndingBalance = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataOptions_BeginningBalance = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelDataColumnDetails_DataOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDataColumnDetails_OfficeFilter = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxDataColumnDetails_OfficeFilter = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxDataColumnDetails_PeriodOption = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemColumnDetails_DataColumnDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewPercentOfRowColumnDetails_Rows = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelPercentOfRowColumnDetails_Column = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxPercentOfRowColumnDetails_Column = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemColumnDetails_ExpressionColumnDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.NumericInputDataColumnDetails_PreviousYears.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_NumberOfDecimalPlaces.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_ColumnDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ColumnDetails.SuspendLayout()
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.SuspendLayout()
            Me.PanelDataColumnDetails_DataCalculations.SuspendLayout()
            Me.PanelDataColumnDetails_DataOptions.SuspendLayout()
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.SuspendLayout()
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.SuspendLayout()
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(412, 417)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 15
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(89, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 0
            Me.LabelForm_Name.Text = "Name:"
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(89, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(107, 38)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(380, 20)
            Me.TextBoxForm_Description.TabIndex = 3
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.CheckSpellingOnValidate = False
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(107, 12)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(380, 20)
            Me.TextBoxForm_Name.TabIndex = 1
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'ComboBoxForm_Type
            '
            Me.ComboBoxForm_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Type.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Type.BookmarkingEnabled = False
            Me.ComboBoxForm_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Type.DisableMouseWheel = False
            Me.ComboBoxForm_Type.DisplayMember = "Name"
            Me.ComboBoxForm_Type.DisplayName = ""
            Me.ComboBoxForm_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Type.FocusHighlightEnabled = True
            Me.ComboBoxForm_Type.FormattingEnabled = True
            Me.ComboBoxForm_Type.ItemHeight = 14
            Me.ComboBoxForm_Type.Location = New System.Drawing.Point(107, 64)
            Me.ComboBoxForm_Type.Name = "ComboBoxForm_Type"
            Me.ComboBoxForm_Type.PreventEnterBeep = False
            Me.ComboBoxForm_Type.ReadOnly = False
            Me.ComboBoxForm_Type.Size = New System.Drawing.Size(380, 20)
            Me.ComboBoxForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Type.TabIndex = 5
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
            Me.LabelForm_Type.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Type.Name = "LabelForm_Type"
            Me.LabelForm_Type.Size = New System.Drawing.Size(89, 20)
            Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Type.TabIndex = 4
            Me.LabelForm_Type.Text = "Type:"
            '
            'LabelDataColumnDetails_DataType
            '
            Me.LabelDataColumnDetails_DataType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_DataType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_DataType.Location = New System.Drawing.Point(4, 4)
            Me.LabelDataColumnDetails_DataType.Name = "LabelDataColumnDetails_DataType"
            Me.LabelDataColumnDetails_DataType.Size = New System.Drawing.Size(85, 20)
            Me.LabelDataColumnDetails_DataType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_DataType.TabIndex = 0
            Me.LabelDataColumnDetails_DataType.Text = "Data Type:"
            '
            'ComboBoxDataColumnDetails_DataType
            '
            Me.ComboBoxDataColumnDetails_DataType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDataColumnDetails_DataType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDataColumnDetails_DataType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDataColumnDetails_DataType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDataColumnDetails_DataType.AutoFindItemInDataSource = False
            Me.ComboBoxDataColumnDetails_DataType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDataColumnDetails_DataType.BookmarkingEnabled = False
            Me.ComboBoxDataColumnDetails_DataType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxDataColumnDetails_DataType.DisableMouseWheel = False
            Me.ComboBoxDataColumnDetails_DataType.DisplayMember = "Name"
            Me.ComboBoxDataColumnDetails_DataType.DisplayName = ""
            Me.ComboBoxDataColumnDetails_DataType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDataColumnDetails_DataType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDataColumnDetails_DataType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxDataColumnDetails_DataType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDataColumnDetails_DataType.FocusHighlightEnabled = True
            Me.ComboBoxDataColumnDetails_DataType.FormattingEnabled = True
            Me.ComboBoxDataColumnDetails_DataType.ItemHeight = 14
            Me.ComboBoxDataColumnDetails_DataType.Location = New System.Drawing.Point(95, 4)
            Me.ComboBoxDataColumnDetails_DataType.Name = "ComboBoxDataColumnDetails_DataType"
            Me.ComboBoxDataColumnDetails_DataType.PreventEnterBeep = False
            Me.ComboBoxDataColumnDetails_DataType.ReadOnly = False
            Me.ComboBoxDataColumnDetails_DataType.Size = New System.Drawing.Size(376, 20)
            Me.ComboBoxDataColumnDetails_DataType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDataColumnDetails_DataType.TabIndex = 1
            Me.ComboBoxDataColumnDetails_DataType.ValueMember = "Value"
            Me.ComboBoxDataColumnDetails_DataType.WatermarkText = "Select"
            '
            'LabelDataColumnDetails_PreviousYears
            '
            Me.LabelDataColumnDetails_PreviousYears.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_PreviousYears.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_PreviousYears.Location = New System.Drawing.Point(4, 30)
            Me.LabelDataColumnDetails_PreviousYears.Name = "LabelDataColumnDetails_PreviousYears"
            Me.LabelDataColumnDetails_PreviousYears.Size = New System.Drawing.Size(85, 20)
            Me.LabelDataColumnDetails_PreviousYears.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_PreviousYears.TabIndex = 2
            Me.LabelDataColumnDetails_PreviousYears.Text = "Previous Years:"
            '
            'LabelDataColumnDetails_PeriodOption
            '
            Me.LabelDataColumnDetails_PeriodOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_PeriodOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_PeriodOption.Location = New System.Drawing.Point(162, 30)
            Me.LabelDataColumnDetails_PeriodOption.Name = "LabelDataColumnDetails_PeriodOption"
            Me.LabelDataColumnDetails_PeriodOption.Size = New System.Drawing.Size(85, 20)
            Me.LabelDataColumnDetails_PeriodOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_PeriodOption.TabIndex = 4
            Me.LabelDataColumnDetails_PeriodOption.Text = "Period Option:"
            '
            'NumericInputDataColumnDetails_PreviousYears
            '
            Me.NumericInputDataColumnDetails_PreviousYears.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDataColumnDetails_PreviousYears.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDataColumnDetails_PreviousYears.Location = New System.Drawing.Point(95, 30)
            Me.NumericInputDataColumnDetails_PreviousYears.Name = "NumericInputDataColumnDetails_PreviousYears"
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.IsFloatValue = False
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.Mask.EditMask = "f0"
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.MaxLength = 11
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDataColumnDetails_PreviousYears.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDataColumnDetails_PreviousYears.Size = New System.Drawing.Size(61, 20)
            Me.NumericInputDataColumnDetails_PreviousYears.TabIndex = 3
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(331, 417)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 13
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(331, 417)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 14
            Me.ButtonForm_Update.Text = "Update"
            '
            'CheckBoxForm_Visible
            '
            '
            '
            '
            Me.CheckBoxForm_Visible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Visible.CheckValue = 0
            Me.CheckBoxForm_Visible.CheckValueChecked = 1
            Me.CheckBoxForm_Visible.CheckValueUnchecked = 0
            Me.CheckBoxForm_Visible.ChildControls = CType(resources.GetObject("CheckBoxForm_Visible.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Visible.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Visible.Location = New System.Drawing.Point(107, 116)
            Me.CheckBoxForm_Visible.Name = "CheckBoxForm_Visible"
            Me.CheckBoxForm_Visible.OldestSibling = Nothing
            Me.CheckBoxForm_Visible.SecurityEnabled = True
            Me.CheckBoxForm_Visible.SiblingControls = CType(resources.GetObject("CheckBoxForm_Visible.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Visible.Size = New System.Drawing.Size(83, 20)
            Me.CheckBoxForm_Visible.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Visible.TabIndex = 10
            Me.CheckBoxForm_Visible.Text = "Visible"
            '
            'ButtonExpressionColumnDetails_Expression
            '
            Me.ButtonExpressionColumnDetails_Expression.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonExpressionColumnDetails_Expression.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonExpressionColumnDetails_Expression.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonExpressionColumnDetails_Expression.Location = New System.Drawing.Point(396, 4)
            Me.ButtonExpressionColumnDetails_Expression.Name = "ButtonExpressionColumnDetails_Expression"
            Me.ButtonExpressionColumnDetails_Expression.SecurityEnabled = True
            Me.ButtonExpressionColumnDetails_Expression.Size = New System.Drawing.Size(75, 20)
            Me.ButtonExpressionColumnDetails_Expression.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonExpressionColumnDetails_Expression.TabIndex = 2
            Me.ButtonExpressionColumnDetails_Expression.Text = "Expression"
            '
            'TextBoxExpressionColumnDetails_Expression
            '
            Me.TextBoxExpressionColumnDetails_Expression.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxExpressionColumnDetails_Expression.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxExpressionColumnDetails_Expression.Border.Class = "TextBoxBorder"
            Me.TextBoxExpressionColumnDetails_Expression.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxExpressionColumnDetails_Expression.CheckSpellingOnValidate = False
            Me.TextBoxExpressionColumnDetails_Expression.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxExpressionColumnDetails_Expression.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxExpressionColumnDetails_Expression.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxExpressionColumnDetails_Expression.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxExpressionColumnDetails_Expression.FocusHighlightEnabled = True
            Me.TextBoxExpressionColumnDetails_Expression.ForeColor = System.Drawing.Color.Black
            Me.TextBoxExpressionColumnDetails_Expression.Location = New System.Drawing.Point(95, 4)
            Me.TextBoxExpressionColumnDetails_Expression.MaxFileSize = CType(0, Long)
            Me.TextBoxExpressionColumnDetails_Expression.Name = "TextBoxExpressionColumnDetails_Expression"
            Me.TextBoxExpressionColumnDetails_Expression.ReadOnly = True
            Me.TextBoxExpressionColumnDetails_Expression.ShowSpellCheckCompleteMessage = True
            Me.TextBoxExpressionColumnDetails_Expression.Size = New System.Drawing.Size(295, 20)
            Me.TextBoxExpressionColumnDetails_Expression.TabIndex = 1
            Me.TextBoxExpressionColumnDetails_Expression.TabOnEnter = True
            '
            'LabelExpressionColumnDetails_Expression
            '
            Me.LabelExpressionColumnDetails_Expression.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelExpressionColumnDetails_Expression.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelExpressionColumnDetails_Expression.Location = New System.Drawing.Point(4, 4)
            Me.LabelExpressionColumnDetails_Expression.Name = "LabelExpressionColumnDetails_Expression"
            Me.LabelExpressionColumnDetails_Expression.Size = New System.Drawing.Size(85, 20)
            Me.LabelExpressionColumnDetails_Expression.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelExpressionColumnDetails_Expression.TabIndex = 0
            Me.LabelExpressionColumnDetails_Expression.Text = "Expression:"
            '
            'CheckBoxForm_UnderlineColumnHeader
            '
            '
            '
            '
            Me.CheckBoxForm_UnderlineColumnHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UnderlineColumnHeader.CheckValue = 0
            Me.CheckBoxForm_UnderlineColumnHeader.CheckValueChecked = 1
            Me.CheckBoxForm_UnderlineColumnHeader.CheckValueUnchecked = 0
            Me.CheckBoxForm_UnderlineColumnHeader.ChildControls = CType(resources.GetObject("CheckBoxForm_UnderlineColumnHeader.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UnderlineColumnHeader.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UnderlineColumnHeader.Location = New System.Drawing.Point(196, 116)
            Me.CheckBoxForm_UnderlineColumnHeader.Name = "CheckBoxForm_UnderlineColumnHeader"
            Me.CheckBoxForm_UnderlineColumnHeader.OldestSibling = Nothing
            Me.CheckBoxForm_UnderlineColumnHeader.SecurityEnabled = True
            Me.CheckBoxForm_UnderlineColumnHeader.SiblingControls = CType(resources.GetObject("CheckBoxForm_UnderlineColumnHeader.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UnderlineColumnHeader.Size = New System.Drawing.Size(195, 20)
            Me.CheckBoxForm_UnderlineColumnHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UnderlineColumnHeader.TabIndex = 11
            Me.CheckBoxForm_UnderlineColumnHeader.Text = "Underline Column Header"
            '
            'NumericInputForm_NumberOfDecimalPlaces
            '
            Me.NumericInputForm_NumberOfDecimalPlaces.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_NumberOfDecimalPlaces.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_NumberOfDecimalPlaces.Location = New System.Drawing.Point(346, 90)
            Me.NumericInputForm_NumberOfDecimalPlaces.Name = "NumericInputForm_NumberOfDecimalPlaces"
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.IsFloatValue = False
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MaxLength = 11
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputForm_NumberOfDecimalPlaces.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputForm_NumberOfDecimalPlaces.Size = New System.Drawing.Size(45, 20)
            Me.NumericInputForm_NumberOfDecimalPlaces.TabIndex = 9
            '
            'LabelForm_NumberOfDecimalPlaces
            '
            Me.LabelForm_NumberOfDecimalPlaces.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NumberOfDecimalPlaces.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NumberOfDecimalPlaces.Location = New System.Drawing.Point(196, 90)
            Me.LabelForm_NumberOfDecimalPlaces.Name = "LabelForm_NumberOfDecimalPlaces"
            Me.LabelForm_NumberOfDecimalPlaces.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_NumberOfDecimalPlaces.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NumberOfDecimalPlaces.TabIndex = 8
            Me.LabelForm_NumberOfDecimalPlaces.Text = "Number Of Decimal Places:"
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(89, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 6
            Me.LabelForm_Format.Text = "Format:"
            '
            'CheckBoxForm_Currency
            '
            '
            '
            '
            Me.CheckBoxForm_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Currency.CheckValue = 0
            Me.CheckBoxForm_Currency.CheckValueChecked = 1
            Me.CheckBoxForm_Currency.CheckValueUnchecked = 0
            Me.CheckBoxForm_Currency.ChildControls = CType(resources.GetObject("CheckBoxForm_Currency.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Currency.Location = New System.Drawing.Point(107, 90)
            Me.CheckBoxForm_Currency.Name = "CheckBoxForm_Currency"
            Me.CheckBoxForm_Currency.OldestSibling = Nothing
            Me.CheckBoxForm_Currency.SecurityEnabled = True
            Me.CheckBoxForm_Currency.SiblingControls = CType(resources.GetObject("CheckBoxForm_Currency.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Currency.Size = New System.Drawing.Size(83, 20)
            Me.CheckBoxForm_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Currency.TabIndex = 7
            Me.CheckBoxForm_Currency.Text = "Currency"
            '
            'ComboBoxVariancePercentVarianceColumnDetails_Column1
            '
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.AutoFindItemInDataSource = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.AutoSelectSingleItemDatasource = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.BookmarkingEnabled = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.DisableMouseWheel = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.DisplayMember = "Description"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.DisplayName = ""
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.FocusHighlightEnabled = True
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.FormattingEnabled = True
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ItemHeight = 14
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.Location = New System.Drawing.Point(95, 4)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.Name = "ComboBoxVariancePercentVarianceColumnDetails_Column1"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.PreventEnterBeep = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ReadOnly = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.Size = New System.Drawing.Size(376, 20)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.TabIndex = 1
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.ValueMember = "Code"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column1.WatermarkText = "Select"
            '
            'LabelVariancePercentVarianceColumnDetails_Column1
            '
            Me.LabelVariancePercentVarianceColumnDetails_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVariancePercentVarianceColumnDetails_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVariancePercentVarianceColumnDetails_Column1.Location = New System.Drawing.Point(4, 4)
            Me.LabelVariancePercentVarianceColumnDetails_Column1.Name = "LabelVariancePercentVarianceColumnDetails_Column1"
            Me.LabelVariancePercentVarianceColumnDetails_Column1.Size = New System.Drawing.Size(85, 20)
            Me.LabelVariancePercentVarianceColumnDetails_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVariancePercentVarianceColumnDetails_Column1.TabIndex = 0
            Me.LabelVariancePercentVarianceColumnDetails_Column1.Text = "Column 1:"
            '
            'LabelVariancePercentVarianceColumnDetails_Column2
            '
            Me.LabelVariancePercentVarianceColumnDetails_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVariancePercentVarianceColumnDetails_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVariancePercentVarianceColumnDetails_Column2.Location = New System.Drawing.Point(4, 30)
            Me.LabelVariancePercentVarianceColumnDetails_Column2.Name = "LabelVariancePercentVarianceColumnDetails_Column2"
            Me.LabelVariancePercentVarianceColumnDetails_Column2.Size = New System.Drawing.Size(85, 20)
            Me.LabelVariancePercentVarianceColumnDetails_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVariancePercentVarianceColumnDetails_Column2.TabIndex = 2
            Me.LabelVariancePercentVarianceColumnDetails_Column2.Text = "Column 2:"
            '
            'ComboBoxVariancePercentVarianceColumnDetails_Column2
            '
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.AutoFindItemInDataSource = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.AutoSelectSingleItemDatasource = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.BookmarkingEnabled = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.DisableMouseWheel = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.DisplayMember = "Description"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.DisplayName = ""
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.FocusHighlightEnabled = True
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.FormattingEnabled = True
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ItemHeight = 14
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.Location = New System.Drawing.Point(95, 30)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.Name = "ComboBoxVariancePercentVarianceColumnDetails_Column2"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.PreventEnterBeep = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ReadOnly = False
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.Size = New System.Drawing.Size(376, 20)
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.TabIndex = 3
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.ValueMember = "Code"
            Me.ComboBoxVariancePercentVarianceColumnDetails_Column2.WatermarkText = "Select"
            '
            'TabControlForm_ColumnDetails
            '
            Me.TabControlForm_ColumnDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ColumnDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_ColumnDetails.CanReorderTabs = False
            Me.TabControlForm_ColumnDetails.Controls.Add(Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails)
            Me.TabControlForm_ColumnDetails.Controls.Add(Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails)
            Me.TabControlForm_ColumnDetails.Controls.Add(Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails)
            Me.TabControlForm_ColumnDetails.Controls.Add(Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails)
            Me.TabControlForm_ColumnDetails.Location = New System.Drawing.Point(12, 142)
            Me.TabControlForm_ColumnDetails.Name = "TabControlForm_ColumnDetails"
            Me.TabControlForm_ColumnDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ColumnDetails.SelectedTabIndex = 0
            Me.TabControlForm_ColumnDetails.Size = New System.Drawing.Size(475, 269)
            Me.TabControlForm_ColumnDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ColumnDetails.TabIndex = 12
            Me.TabControlForm_ColumnDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ColumnDetails.Tabs.Add(Me.TabItemColumnDetails_DataColumnDetailsTab)
            Me.TabControlForm_ColumnDetails.Tabs.Add(Me.TabItemColumnDetails_ExpressionColumnDetailsTab)
            Me.TabControlForm_ColumnDetails.Tabs.Add(Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab)
            Me.TabControlForm_ColumnDetails.Tabs.Add(Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab)
            '
            'TabControlPanelDataColumnDetailsTab_DataColumnDetails
            '
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_DataCalculations)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.PanelDataColumnDetails_DataCalculations)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.PanelDataColumnDetails_DataOptions)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_DataOptions)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_OfficeFilter)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.ComboBoxDataColumnDetails_OfficeFilter)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.ComboBoxDataColumnDetails_PeriodOption)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_DataType)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.ComboBoxDataColumnDetails_DataType)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_PreviousYears)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.LabelDataColumnDetails_PeriodOption)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Controls.Add(Me.NumericInputDataColumnDetails_PreviousYears)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Name = "TabControlPanelDataColumnDetailsTab_DataColumnDetails"
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Size = New System.Drawing.Size(475, 242)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.Style.GradientAngle = 90
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.TabIndex = 0
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.TabItem = Me.TabItemColumnDetails_DataColumnDetailsTab
            '
            'CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations
            '
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.CheckValue = 0
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.CheckValueChecked = 1
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.CheckValueUnchecked = 0
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.ChildControls = CType(resources.GetObject("CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Location = New System.Drawing.Point(4, 82)
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Name = "CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations"
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.OldestSibling = Nothing
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.SecurityEnabled = True
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.SiblingControls = CType(resources.GetObject("CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Size = New System.Drawing.Size(467, 20)
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.TabIndex = 20
            Me.CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations.Text = "Override Row Data Options/Calculations"
            '
            'LabelDataColumnDetails_DataCalculations
            '
            Me.LabelDataColumnDetails_DataCalculations.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataCalculations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_DataCalculations.Location = New System.Drawing.Point(4, 108)
            Me.LabelDataColumnDetails_DataCalculations.Name = "LabelDataColumnDetails_DataCalculations"
            Me.LabelDataColumnDetails_DataCalculations.Size = New System.Drawing.Size(152, 20)
            Me.LabelDataColumnDetails_DataCalculations.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_DataCalculations.TabIndex = 16
            Me.LabelDataColumnDetails_DataCalculations.Text = "Data Calculations"
            '
            'PanelDataColumnDetails_DataCalculations
            '
            Me.PanelDataColumnDetails_DataCalculations.BackColor = System.Drawing.Color.White
            Me.PanelDataColumnDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_All)
            Me.PanelDataColumnDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_YearToDate)
            Me.PanelDataColumnDetails_DataCalculations.Controls.Add(Me.RadioButtonDataCalculations_SelectedPeriod)
            Me.PanelDataColumnDetails_DataCalculations.Enabled = False
            Me.PanelDataColumnDetails_DataCalculations.Location = New System.Drawing.Point(4, 134)
            Me.PanelDataColumnDetails_DataCalculations.Name = "PanelDataColumnDetails_DataCalculations"
            Me.PanelDataColumnDetails_DataCalculations.Size = New System.Drawing.Size(152, 80)
            Me.PanelDataColumnDetails_DataCalculations.TabIndex = 17
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
            Me.RadioButtonDataCalculations_All.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataCalculations_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataCalculations_All.TabIndex = 2
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
            Me.RadioButtonDataCalculations_YearToDate.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataCalculations_YearToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataCalculations_YearToDate.TabIndex = 0
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
            Me.RadioButtonDataCalculations_SelectedPeriod.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataCalculations_SelectedPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataCalculations_SelectedPeriod.TabIndex = 1
            Me.RadioButtonDataCalculations_SelectedPeriod.TabStop = False
            Me.RadioButtonDataCalculations_SelectedPeriod.Text = "Selected Period"
            '
            'PanelDataColumnDetails_DataOptions
            '
            Me.PanelDataColumnDetails_DataOptions.BackColor = System.Drawing.Color.White
            Me.PanelDataColumnDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_PeriodChange)
            Me.PanelDataColumnDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_EndingBalance)
            Me.PanelDataColumnDetails_DataOptions.Controls.Add(Me.RadioButtonDataOptions_BeginningBalance)
            Me.PanelDataColumnDetails_DataOptions.Enabled = False
            Me.PanelDataColumnDetails_DataOptions.Location = New System.Drawing.Point(162, 134)
            Me.PanelDataColumnDetails_DataOptions.Name = "PanelDataColumnDetails_DataOptions"
            Me.PanelDataColumnDetails_DataOptions.Size = New System.Drawing.Size(152, 80)
            Me.PanelDataColumnDetails_DataOptions.TabIndex = 19
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
            Me.RadioButtonDataOptions_PeriodChange.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataOptions_PeriodChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOptions_PeriodChange.TabIndex = 2
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
            Me.RadioButtonDataOptions_EndingBalance.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataOptions_EndingBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOptions_EndingBalance.TabIndex = 0
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
            Me.RadioButtonDataOptions_BeginningBalance.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDataOptions_BeginningBalance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOptions_BeginningBalance.TabIndex = 1
            Me.RadioButtonDataOptions_BeginningBalance.TabStop = False
            Me.RadioButtonDataOptions_BeginningBalance.Text = "Beginning Balance"
            '
            'LabelDataColumnDetails_DataOptions
            '
            Me.LabelDataColumnDetails_DataOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDataColumnDetails_DataOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_DataOptions.Location = New System.Drawing.Point(162, 108)
            Me.LabelDataColumnDetails_DataOptions.Name = "LabelDataColumnDetails_DataOptions"
            Me.LabelDataColumnDetails_DataOptions.Size = New System.Drawing.Size(152, 20)
            Me.LabelDataColumnDetails_DataOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_DataOptions.TabIndex = 18
            Me.LabelDataColumnDetails_DataOptions.Text = "Data Options"
            '
            'LabelDataColumnDetails_OfficeFilter
            '
            Me.LabelDataColumnDetails_OfficeFilter.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDataColumnDetails_OfficeFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDataColumnDetails_OfficeFilter.Location = New System.Drawing.Point(4, 56)
            Me.LabelDataColumnDetails_OfficeFilter.Name = "LabelDataColumnDetails_OfficeFilter"
            Me.LabelDataColumnDetails_OfficeFilter.Size = New System.Drawing.Size(85, 20)
            Me.LabelDataColumnDetails_OfficeFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDataColumnDetails_OfficeFilter.TabIndex = 8
            Me.LabelDataColumnDetails_OfficeFilter.Text = "Office Filter:"
            '
            'ComboBoxDataColumnDetails_OfficeFilter
            '
            Me.ComboBoxDataColumnDetails_OfficeFilter.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDataColumnDetails_OfficeFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDataColumnDetails_OfficeFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDataColumnDetails_OfficeFilter.AutoFindItemInDataSource = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.BookmarkingEnabled = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxDataColumnDetails_OfficeFilter.DisableMouseWheel = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.DisplayMember = "Name"
            Me.ComboBoxDataColumnDetails_OfficeFilter.DisplayName = ""
            Me.ComboBoxDataColumnDetails_OfficeFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDataColumnDetails_OfficeFilter.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDataColumnDetails_OfficeFilter.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxDataColumnDetails_OfficeFilter.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDataColumnDetails_OfficeFilter.FocusHighlightEnabled = True
            Me.ComboBoxDataColumnDetails_OfficeFilter.FormattingEnabled = True
            Me.ComboBoxDataColumnDetails_OfficeFilter.ItemHeight = 14
            Me.ComboBoxDataColumnDetails_OfficeFilter.Location = New System.Drawing.Point(95, 56)
            Me.ComboBoxDataColumnDetails_OfficeFilter.Name = "ComboBoxDataColumnDetails_OfficeFilter"
            Me.ComboBoxDataColumnDetails_OfficeFilter.PreventEnterBeep = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.ReadOnly = False
            Me.ComboBoxDataColumnDetails_OfficeFilter.Size = New System.Drawing.Size(376, 20)
            Me.ComboBoxDataColumnDetails_OfficeFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDataColumnDetails_OfficeFilter.TabIndex = 9
            Me.ComboBoxDataColumnDetails_OfficeFilter.ValueMember = "Code"
            Me.ComboBoxDataColumnDetails_OfficeFilter.WatermarkText = "Select Office"
            '
            'ComboBoxDataColumnDetails_PeriodOption
            '
            Me.ComboBoxDataColumnDetails_PeriodOption.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDataColumnDetails_PeriodOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDataColumnDetails_PeriodOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDataColumnDetails_PeriodOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDataColumnDetails_PeriodOption.AutoFindItemInDataSource = False
            Me.ComboBoxDataColumnDetails_PeriodOption.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDataColumnDetails_PeriodOption.BookmarkingEnabled = False
            Me.ComboBoxDataColumnDetails_PeriodOption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxDataColumnDetails_PeriodOption.DisableMouseWheel = False
            Me.ComboBoxDataColumnDetails_PeriodOption.DisplayMember = "Name"
            Me.ComboBoxDataColumnDetails_PeriodOption.DisplayName = ""
            Me.ComboBoxDataColumnDetails_PeriodOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDataColumnDetails_PeriodOption.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDataColumnDetails_PeriodOption.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxDataColumnDetails_PeriodOption.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDataColumnDetails_PeriodOption.FocusHighlightEnabled = True
            Me.ComboBoxDataColumnDetails_PeriodOption.FormattingEnabled = True
            Me.ComboBoxDataColumnDetails_PeriodOption.ItemHeight = 14
            Me.ComboBoxDataColumnDetails_PeriodOption.Location = New System.Drawing.Point(253, 30)
            Me.ComboBoxDataColumnDetails_PeriodOption.Name = "ComboBoxDataColumnDetails_PeriodOption"
            Me.ComboBoxDataColumnDetails_PeriodOption.PreventEnterBeep = False
            Me.ComboBoxDataColumnDetails_PeriodOption.ReadOnly = False
            Me.ComboBoxDataColumnDetails_PeriodOption.Size = New System.Drawing.Size(218, 20)
            Me.ComboBoxDataColumnDetails_PeriodOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDataColumnDetails_PeriodOption.TabIndex = 5
            Me.ComboBoxDataColumnDetails_PeriodOption.ValueMember = "Value"
            Me.ComboBoxDataColumnDetails_PeriodOption.WatermarkText = "Select"
            '
            'TabItemColumnDetails_DataColumnDetailsTab
            '
            Me.TabItemColumnDetails_DataColumnDetailsTab.AttachedControl = Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails
            Me.TabItemColumnDetails_DataColumnDetailsTab.Name = "TabItemColumnDetails_DataColumnDetailsTab"
            Me.TabItemColumnDetails_DataColumnDetailsTab.Text = "Data Details"
            '
            'TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails
            '
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Controls.Add(Me.DataGridViewPercentOfRowColumnDetails_Rows)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Controls.Add(Me.LabelPercentOfRowColumnDetails_Column)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Controls.Add(Me.ComboBoxPercentOfRowColumnDetails_Column)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Name = "TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails"
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Size = New System.Drawing.Size(475, 242)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.Style.GradientAngle = 90
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.TabIndex = 0
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.TabItem = Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab
            '
            'DataGridViewPercentOfRowColumnDetails_Rows
            '
            Me.DataGridViewPercentOfRowColumnDetails_Rows.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPercentOfRowColumnDetails_Rows.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPercentOfRowColumnDetails_Rows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPercentOfRowColumnDetails_Rows.AutoFilterLookupColumns = False
            Me.DataGridViewPercentOfRowColumnDetails_Rows.AutoloadRepositoryDatasource = True
            Me.DataGridViewPercentOfRowColumnDetails_Rows.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewPercentOfRowColumnDetails_Rows.DataSource = Nothing
            Me.DataGridViewPercentOfRowColumnDetails_Rows.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPercentOfRowColumnDetails_Rows.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPercentOfRowColumnDetails_Rows.ItemDescription = "Item(s)"
            Me.DataGridViewPercentOfRowColumnDetails_Rows.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewPercentOfRowColumnDetails_Rows.MultiSelect = False
            Me.DataGridViewPercentOfRowColumnDetails_Rows.Name = "DataGridViewPercentOfRowColumnDetails_Rows"
            Me.DataGridViewPercentOfRowColumnDetails_Rows.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPercentOfRowColumnDetails_Rows.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPercentOfRowColumnDetails_Rows.Size = New System.Drawing.Size(467, 208)
            Me.DataGridViewPercentOfRowColumnDetails_Rows.TabIndex = 4
            Me.DataGridViewPercentOfRowColumnDetails_Rows.UseEmbeddedNavigator = False
            Me.DataGridViewPercentOfRowColumnDetails_Rows.ViewCaptionHeight = -1
            '
            'LabelPercentOfRowColumnDetails_Column
            '
            Me.LabelPercentOfRowColumnDetails_Column.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPercentOfRowColumnDetails_Column.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPercentOfRowColumnDetails_Column.Location = New System.Drawing.Point(4, 4)
            Me.LabelPercentOfRowColumnDetails_Column.Name = "LabelPercentOfRowColumnDetails_Column"
            Me.LabelPercentOfRowColumnDetails_Column.Size = New System.Drawing.Size(85, 20)
            Me.LabelPercentOfRowColumnDetails_Column.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPercentOfRowColumnDetails_Column.TabIndex = 2
            Me.LabelPercentOfRowColumnDetails_Column.Text = "Column 1:"
            '
            'ComboBoxPercentOfRowColumnDetails_Column
            '
            Me.ComboBoxPercentOfRowColumnDetails_Column.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxPercentOfRowColumnDetails_Column.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPercentOfRowColumnDetails_Column.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPercentOfRowColumnDetails_Column.AutoFindItemInDataSource = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.BookmarkingEnabled = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxPercentOfRowColumnDetails_Column.DisableMouseWheel = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.DisplayMember = "Description"
            Me.ComboBoxPercentOfRowColumnDetails_Column.DisplayName = ""
            Me.ComboBoxPercentOfRowColumnDetails_Column.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPercentOfRowColumnDetails_Column.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxPercentOfRowColumnDetails_Column.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxPercentOfRowColumnDetails_Column.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPercentOfRowColumnDetails_Column.FocusHighlightEnabled = True
            Me.ComboBoxPercentOfRowColumnDetails_Column.FormattingEnabled = True
            Me.ComboBoxPercentOfRowColumnDetails_Column.ItemHeight = 14
            Me.ComboBoxPercentOfRowColumnDetails_Column.Location = New System.Drawing.Point(95, 4)
            Me.ComboBoxPercentOfRowColumnDetails_Column.Name = "ComboBoxPercentOfRowColumnDetails_Column"
            Me.ComboBoxPercentOfRowColumnDetails_Column.PreventEnterBeep = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.ReadOnly = False
            Me.ComboBoxPercentOfRowColumnDetails_Column.Size = New System.Drawing.Size(376, 20)
            Me.ComboBoxPercentOfRowColumnDetails_Column.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPercentOfRowColumnDetails_Column.TabIndex = 3
            Me.ComboBoxPercentOfRowColumnDetails_Column.ValueMember = "Code"
            Me.ComboBoxPercentOfRowColumnDetails_Column.WatermarkText = "Select"
            '
            'TabItemColumnDetails_PercentOfRowColumnDetailsTab
            '
            Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab.AttachedControl = Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails
            Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab.Name = "TabItemColumnDetails_PercentOfRowColumnDetailsTab"
            Me.TabItemColumnDetails_PercentOfRowColumnDetailsTab.Text = "Percent Of Row Details"
            '
            'TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails
            '
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Controls.Add(Me.LabelExpressionColumnDetails_Expression)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Controls.Add(Me.ButtonExpressionColumnDetails_Expression)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Controls.Add(Me.TextBoxExpressionColumnDetails_Expression)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Name = "TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails"
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Size = New System.Drawing.Size(475, 242)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.Style.GradientAngle = 90
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.TabIndex = 0
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.TabItem = Me.TabItemColumnDetails_ExpressionColumnDetailsTab
            '
            'TabItemColumnDetails_ExpressionColumnDetailsTab
            '
            Me.TabItemColumnDetails_ExpressionColumnDetailsTab.AttachedControl = Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails
            Me.TabItemColumnDetails_ExpressionColumnDetailsTab.Name = "TabItemColumnDetails_ExpressionColumnDetailsTab"
            Me.TabItemColumnDetails_ExpressionColumnDetailsTab.Text = "Expression Details"
            '
            'TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails
            '
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Controls.Add(Me.LabelVariancePercentVarianceColumnDetails_Column1)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Controls.Add(Me.LabelVariancePercentVarianceColumnDetails_Column2)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Controls.Add(Me.ComboBoxVariancePercentVarianceColumnDetails_Column1)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Controls.Add(Me.ComboBoxVariancePercentVarianceColumnDetails_Column2)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Name = "TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceCol" & _
        "umnDetails"
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Size = New System.Drawing.Size(475, 242)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.Style.GradientAngle = 90
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.TabIndex = 0
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.TabItem = Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab
            '
            'TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab
            '
            Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.AttachedControl = Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails
            Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Name = "TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab"
            Me.TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab.Text = "Var\Percent Var Details"
            '
            'GLReportTemplateColumnEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(499, 449)
            Me.Controls.Add(Me.TabControlForm_ColumnDetails)
            Me.Controls.Add(Me.NumericInputForm_NumberOfDecimalPlaces)
            Me.Controls.Add(Me.LabelForm_NumberOfDecimalPlaces)
            Me.Controls.Add(Me.LabelForm_Format)
            Me.Controls.Add(Me.CheckBoxForm_Currency)
            Me.Controls.Add(Me.CheckBoxForm_UnderlineColumnHeader)
            Me.Controls.Add(Me.CheckBoxForm_Visible)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.LabelForm_Type)
            Me.Controls.Add(Me.ComboBoxForm_Type)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateColumnEditDialog"
            Me.Text = "Edit Column"
            CType(Me.NumericInputDataColumnDetails_PreviousYears.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_NumberOfDecimalPlaces.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_ColumnDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ColumnDetails.ResumeLayout(False)
            Me.TabControlPanelDataColumnDetailsTab_DataColumnDetails.ResumeLayout(False)
            Me.PanelDataColumnDetails_DataCalculations.ResumeLayout(False)
            Me.PanelDataColumnDetails_DataOptions.ResumeLayout(False)
            Me.TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails.ResumeLayout(False)
            Me.TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails.ResumeLayout(False)
            Me.TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxForm_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDataColumnDetails_DataType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxDataColumnDetails_DataType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelDataColumnDetails_PreviousYears As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDataColumnDetails_PeriodOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDataColumnDetails_PreviousYears As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_Visible As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonExpressionColumnDetails_Expression As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxExpressionColumnDetails_Expression As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelExpressionColumnDetails_Expression As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_UnderlineColumnHeader As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputForm_NumberOfDecimalPlaces As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_NumberOfDecimalPlaces As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Currency As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxVariancePercentVarianceColumnDetails_Column1 As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelVariancePercentVarianceColumnDetails_Column2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelVariancePercentVarianceColumnDetails_Column1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxVariancePercentVarianceColumnDetails_Column2 As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlForm_ColumnDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDataColumnDetailsTab_DataColumnDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemColumnDetails_DataColumnDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelExpressionColumnDetailsTab_ExpressionColumnDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemColumnDetails_ExpressionColumnDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVariancePercentVarianceColumnDetailsTab_VariancePercentVarianceColumnDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemColumnDetails_VariancePercentVarianceColumnDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPercentOfRowColumnDetailsTab_PercentOfRowColumnDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemColumnDetails_PercentOfRowColumnDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxDataColumnDetails_PeriodOption As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewPercentOfRowColumnDetails_Rows As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelPercentOfRowColumnDetails_Column As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxPercentOfRowColumnDetails_Column As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelDataColumnDetails_OfficeFilter As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxDataColumnDetails_OfficeFilter As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxDataColumnDetails_OverrideRowDataOptionsAndCalculations As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDataColumnDetails_DataCalculations As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelDataColumnDetails_DataCalculations As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonDataCalculations_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataCalculations_YearToDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataCalculations_SelectedPeriod As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelDataColumnDetails_DataOptions As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonDataOptions_PeriodChange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOptions_EndingBalance As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOptions_BeginningBalance As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelDataColumnDetails_DataOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace