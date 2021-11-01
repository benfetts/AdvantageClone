Namespace Maintenance.Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillRateCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillRateCopyDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Source = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_ClearAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_TargetProduct = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_TargetDivision = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_TargetClient = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_TargetProduct = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetDivision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Target = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetClient = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_TargetDivision = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_TargetProduct = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_NewRows = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewRows_Choose = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxNewRows_ReplaceRates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewRows_ReplaceNonbillable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewRows_ReplaceMarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewRows_ReplaceSalesTax = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewRows_ReplaceFeeTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceFeeTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceSalesTax = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceMarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceNonbillable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxExistingRows_ReplaceRates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelExistingRows_Choose = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ExistingRows = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StructureLevelLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_TargetEmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_TargetEmployee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_TargetFunction = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_TargetSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_TargetEmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEmployeeTitleLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEmployeeLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceFunctionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceSalesClassLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceProductLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceDivisionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceClientLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEmployeeTitle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceProduct = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceDivision = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceClient = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StructureLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEffectiveDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceEffectiveDateLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_TargetEffectiveDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_TargetEffectiveDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            CType(Me.DateTimePickerForm_TargetEffectiveDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(593, 480)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 56
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(512, 480)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 55
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'LabelForm_Source
            '
            Me.LabelForm_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Source.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Source.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Source.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Source.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Source.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Source.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Source.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Source.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Source.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Source.Name = "LabelForm_Source"
            Me.LabelForm_Source.Size = New System.Drawing.Size(300, 20)
            Me.LabelForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Source.TabIndex = 2
            Me.LabelForm_Source.Text = "Source"
            '
            'ButtonForm_ClearAll
            '
            Me.ButtonForm_ClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ClearAll.Location = New System.Drawing.Point(431, 480)
            Me.ButtonForm_ClearAll.Name = "ButtonForm_ClearAll"
            Me.ButtonForm_ClearAll.SecurityEnabled = True
            Me.ButtonForm_ClearAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_ClearAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ClearAll.TabIndex = 54
            Me.ButtonForm_ClearAll.Text = "Clear All"
            '
            'ComboBoxForm_TargetProduct
            '
            Me.ComboBoxForm_TargetProduct.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetProduct.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetProduct.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetProduct.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetProduct.ClientCode = ""
            Me.ComboBoxForm_TargetProduct.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_TargetProduct.DisableMouseWheel = False
            Me.ComboBoxForm_TargetProduct.DisplayMember = "Name"
            Me.ComboBoxForm_TargetProduct.DisplayName = ""
            Me.ComboBoxForm_TargetProduct.DivisionCode = ""
            Me.ComboBoxForm_TargetProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetProduct.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetProduct.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetProduct.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetProduct.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetProduct.FormattingEnabled = True
            Me.ComboBoxForm_TargetProduct.ItemHeight = 14
            Me.ComboBoxForm_TargetProduct.Location = New System.Drawing.Point(405, 116)
            Me.ComboBoxForm_TargetProduct.Name = "ComboBoxForm_TargetProduct"
            Me.ComboBoxForm_TargetProduct.ReadOnly = False
            Me.ComboBoxForm_TargetProduct.SecurityEnabled = True
            Me.ComboBoxForm_TargetProduct.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetProduct.TabIndex = 26
            Me.ComboBoxForm_TargetProduct.TabOnEnter = True
            Me.ComboBoxForm_TargetProduct.ValueMember = "Code"
            Me.ComboBoxForm_TargetProduct.WatermarkText = "Select Product"
            '
            'ComboBoxForm_TargetDivision
            '
            Me.ComboBoxForm_TargetDivision.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetDivision.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetDivision.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetDivision.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetDivision.ClientCode = ""
            Me.ComboBoxForm_TargetDivision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_TargetDivision.DisableMouseWheel = False
            Me.ComboBoxForm_TargetDivision.DisplayMember = "Description"
            Me.ComboBoxForm_TargetDivision.DisplayName = ""
            Me.ComboBoxForm_TargetDivision.DivisionCode = ""
            Me.ComboBoxForm_TargetDivision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetDivision.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetDivision.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetDivision.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetDivision.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetDivision.FormattingEnabled = True
            Me.ComboBoxForm_TargetDivision.ItemHeight = 14
            Me.ComboBoxForm_TargetDivision.Location = New System.Drawing.Point(405, 90)
            Me.ComboBoxForm_TargetDivision.Name = "ComboBoxForm_TargetDivision"
            Me.ComboBoxForm_TargetDivision.ReadOnly = False
            Me.ComboBoxForm_TargetDivision.SecurityEnabled = True
            Me.ComboBoxForm_TargetDivision.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetDivision.TabIndex = 23
            Me.ComboBoxForm_TargetDivision.TabOnEnter = True
            Me.ComboBoxForm_TargetDivision.ValueMember = "Code"
            Me.ComboBoxForm_TargetDivision.WatermarkText = "Select Division"
            '
            'ComboBoxForm_TargetClient
            '
            Me.ComboBoxForm_TargetClient.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetClient.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetClient.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetClient.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetClient.ClientCode = ""
            Me.ComboBoxForm_TargetClient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_TargetClient.DisableMouseWheel = False
            Me.ComboBoxForm_TargetClient.DisplayMember = "Name"
            Me.ComboBoxForm_TargetClient.DisplayName = ""
            Me.ComboBoxForm_TargetClient.DivisionCode = ""
            Me.ComboBoxForm_TargetClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetClient.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetClient.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetClient.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetClient.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetClient.FormattingEnabled = True
            Me.ComboBoxForm_TargetClient.ItemHeight = 14
            Me.ComboBoxForm_TargetClient.Location = New System.Drawing.Point(405, 64)
            Me.ComboBoxForm_TargetClient.Name = "ComboBoxForm_TargetClient"
            Me.ComboBoxForm_TargetClient.ReadOnly = False
            Me.ComboBoxForm_TargetClient.SecurityEnabled = True
            Me.ComboBoxForm_TargetClient.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetClient.TabIndex = 21
            Me.ComboBoxForm_TargetClient.TabOnEnter = True
            Me.ComboBoxForm_TargetClient.ValueMember = "Code"
            Me.ComboBoxForm_TargetClient.WatermarkText = "Select Client"
            '
            'LabelForm_TargetProduct
            '
            Me.LabelForm_TargetProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetProduct.Location = New System.Drawing.Point(318, 116)
            Me.LabelForm_TargetProduct.Name = "LabelForm_TargetProduct"
            Me.LabelForm_TargetProduct.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetProduct.TabIndex = 25
            Me.LabelForm_TargetProduct.Text = "Product:"
            '
            'LabelForm_TargetDivision
            '
            Me.LabelForm_TargetDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetDivision.Location = New System.Drawing.Point(318, 90)
            Me.LabelForm_TargetDivision.Name = "LabelForm_TargetDivision"
            Me.LabelForm_TargetDivision.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetDivision.TabIndex = 22
            Me.LabelForm_TargetDivision.Text = "Division:"
            '
            'LabelForm_Target
            '
            Me.LabelForm_Target.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Target.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Target.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Target.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_Target.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Target.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Target.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Target.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Target.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Target.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Target.Location = New System.Drawing.Point(318, 38)
            Me.LabelForm_Target.Name = "LabelForm_Target"
            Me.LabelForm_Target.Size = New System.Drawing.Size(350, 20)
            Me.LabelForm_Target.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Target.TabIndex = 19
            Me.LabelForm_Target.Text = "Target"
            '
            'LabelForm_TargetClient
            '
            Me.LabelForm_TargetClient.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetClient.Location = New System.Drawing.Point(318, 64)
            Me.LabelForm_TargetClient.Name = "LabelForm_TargetClient"
            Me.LabelForm_TargetClient.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetClient.TabIndex = 20
            Me.LabelForm_TargetClient.Text = "Client:"
            '
            'CheckBoxForm_TargetDivision
            '
            '
            '
            '
            Me.CheckBoxForm_TargetDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_TargetDivision.CheckValue = 0
            Me.CheckBoxForm_TargetDivision.CheckValueChecked = 1
            Me.CheckBoxForm_TargetDivision.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_TargetDivision.CheckValueUnchecked = 0
            Me.CheckBoxForm_TargetDivision.ChildControls = CType(resources.GetObject("CheckBoxForm_TargetDivision.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetDivision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_TargetDivision.Location = New System.Drawing.Point(624, 90)
            Me.CheckBoxForm_TargetDivision.Name = "CheckBoxForm_TargetDivision"
            Me.CheckBoxForm_TargetDivision.OldestSibling = Nothing
            Me.CheckBoxForm_TargetDivision.SecurityEnabled = True
            Me.CheckBoxForm_TargetDivision.SiblingControls = CType(resources.GetObject("CheckBoxForm_TargetDivision.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetDivision.Size = New System.Drawing.Size(44, 20)
            Me.CheckBoxForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TargetDivision.TabIndex = 24
            Me.CheckBoxForm_TargetDivision.TabOnEnter = True
            Me.CheckBoxForm_TargetDivision.Text = "All"
            '
            'CheckBoxForm_TargetProduct
            '
            '
            '
            '
            Me.CheckBoxForm_TargetProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_TargetProduct.CheckValue = 0
            Me.CheckBoxForm_TargetProduct.CheckValueChecked = 1
            Me.CheckBoxForm_TargetProduct.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_TargetProduct.CheckValueUnchecked = 0
            Me.CheckBoxForm_TargetProduct.ChildControls = CType(resources.GetObject("CheckBoxForm_TargetProduct.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetProduct.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_TargetProduct.Location = New System.Drawing.Point(624, 116)
            Me.CheckBoxForm_TargetProduct.Name = "CheckBoxForm_TargetProduct"
            Me.CheckBoxForm_TargetProduct.OldestSibling = Nothing
            Me.CheckBoxForm_TargetProduct.SecurityEnabled = True
            Me.CheckBoxForm_TargetProduct.SiblingControls = CType(resources.GetObject("CheckBoxForm_TargetProduct.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetProduct.Size = New System.Drawing.Size(44, 20)
            Me.CheckBoxForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TargetProduct.TabIndex = 27
            Me.CheckBoxForm_TargetProduct.TabOnEnter = True
            Me.CheckBoxForm_TargetProduct.Text = "All"
            '
            'LabelForm_NewRows
            '
            Me.LabelForm_NewRows.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NewRows.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_NewRows.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_NewRows.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_NewRows.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_NewRows.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_NewRows.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_NewRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NewRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_NewRows.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_NewRows.Location = New System.Drawing.Point(12, 272)
            Me.LabelForm_NewRows.Name = "LabelForm_NewRows"
            Me.LabelForm_NewRows.Size = New System.Drawing.Size(325, 20)
            Me.LabelForm_NewRows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NewRows.TabIndex = 38
            Me.LabelForm_NewRows.Text = "New Rows"
            '
            'LabelNewRows_Choose
            '
            Me.LabelNewRows_Choose.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewRows_Choose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewRows_Choose.Location = New System.Drawing.Point(12, 298)
            Me.LabelNewRows_Choose.Name = "LabelNewRows_Choose"
            Me.LabelNewRows_Choose.Size = New System.Drawing.Size(325, 20)
            Me.LabelNewRows_Choose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewRows_Choose.TabIndex = 39
            Me.LabelNewRows_Choose.Text = "Choose fields to replace from source rows to new rows"
            '
            'CheckBoxNewRows_ReplaceRates
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceRates.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceRates.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceRates.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceRates.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceRates.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceRates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceRates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceRates.Location = New System.Drawing.Point(12, 324)
            Me.CheckBoxNewRows_ReplaceRates.Name = "CheckBoxNewRows_ReplaceRates"
            Me.CheckBoxNewRows_ReplaceRates.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceRates.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceRates.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceRates.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceRates.TabIndex = 40
            Me.CheckBoxNewRows_ReplaceRates.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceRates.Text = "Replace Rates"
            '
            'CheckBoxNewRows_ReplaceNonbillable
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceNonbillable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceNonbillable.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceNonbillable.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceNonbillable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceNonbillable.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceNonbillable.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceNonbillable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceNonbillable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceNonbillable.Location = New System.Drawing.Point(12, 350)
            Me.CheckBoxNewRows_ReplaceNonbillable.Name = "CheckBoxNewRows_ReplaceNonbillable"
            Me.CheckBoxNewRows_ReplaceNonbillable.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceNonbillable.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceNonbillable.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceNonbillable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceNonbillable.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceNonbillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceNonbillable.TabIndex = 41
            Me.CheckBoxNewRows_ReplaceNonbillable.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceNonbillable.Text = "Replace Non-billable"
            '
            'CheckBoxNewRows_ReplaceMarkupPercent
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceMarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceMarkupPercent.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceMarkupPercent.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceMarkupPercent.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceMarkupPercent.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceMarkupPercent.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupPercent.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Location = New System.Drawing.Point(12, 376)
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Name = "CheckBoxNewRows_ReplaceMarkupPercent"
            Me.CheckBoxNewRows_ReplaceMarkupPercent.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceMarkupPercent.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceMarkupPercent.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupPercent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceMarkupPercent.TabIndex = 42
            Me.CheckBoxNewRows_ReplaceMarkupPercent.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Text = "Replace Markup Percent"
            '
            'CheckBoxNewRows_ReplaceSalesTax
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceSalesTax.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceSalesTax.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceSalesTax.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceSalesTax.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceSalesTax.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceSalesTax.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceSalesTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceSalesTax.Location = New System.Drawing.Point(12, 402)
            Me.CheckBoxNewRows_ReplaceSalesTax.Name = "CheckBoxNewRows_ReplaceSalesTax"
            Me.CheckBoxNewRows_ReplaceSalesTax.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceSalesTax.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceSalesTax.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceSalesTax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceSalesTax.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceSalesTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceSalesTax.TabIndex = 43
            Me.CheckBoxNewRows_ReplaceSalesTax.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceSalesTax.Text = "Replace Sales Tax"
            '
            'CheckBoxNewRows_ReplaceMarkupTaxFlags
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupTaxFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Location = New System.Drawing.Point(12, 428)
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Name = "CheckBoxNewRows_ReplaceMarkupTaxFlags"
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupTaxFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.TabIndex = 44
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Text = "Replace Markup Tax Flags"
            '
            'CheckBoxNewRows_ReplaceFeeTime
            '
            '
            '
            '
            Me.CheckBoxNewRows_ReplaceFeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewRows_ReplaceFeeTime.CheckValue = 0
            Me.CheckBoxNewRows_ReplaceFeeTime.CheckValueChecked = 1
            Me.CheckBoxNewRows_ReplaceFeeTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewRows_ReplaceFeeTime.CheckValueUnchecked = 0
            Me.CheckBoxNewRows_ReplaceFeeTime.ChildControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceFeeTime.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceFeeTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewRows_ReplaceFeeTime.Location = New System.Drawing.Point(12, 454)
            Me.CheckBoxNewRows_ReplaceFeeTime.Name = "CheckBoxNewRows_ReplaceFeeTime"
            Me.CheckBoxNewRows_ReplaceFeeTime.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceFeeTime.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceFeeTime.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceFeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceFeeTime.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxNewRows_ReplaceFeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceFeeTime.TabIndex = 45
            Me.CheckBoxNewRows_ReplaceFeeTime.TabOnEnter = True
            Me.CheckBoxNewRows_ReplaceFeeTime.Text = "Replace Fee Time"
            '
            'CheckBoxExistingRows_ReplaceFeeTime
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceFeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceFeeTime.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceFeeTime.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceFeeTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceFeeTime.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceFeeTime.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceFeeTime.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceFeeTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceFeeTime.Location = New System.Drawing.Point(343, 454)
            Me.CheckBoxExistingRows_ReplaceFeeTime.Name = "CheckBoxExistingRows_ReplaceFeeTime"
            Me.CheckBoxExistingRows_ReplaceFeeTime.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceFeeTime.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceFeeTime.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceFeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceFeeTime.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceFeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceFeeTime.TabIndex = 53
            Me.CheckBoxExistingRows_ReplaceFeeTime.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceFeeTime.Text = "Replace Fee Time"
            '
            'CheckBoxExistingRows_ReplaceMarkupTaxFlags
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupTaxFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Location = New System.Drawing.Point(343, 428)
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Name = "CheckBoxExistingRows_ReplaceMarkupTaxFlags"
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupTaxFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.TabIndex = 52
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Text = "Replace Markup Tax Flags"
            '
            'CheckBoxExistingRows_ReplaceSalesTax
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceSalesTax.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceSalesTax.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceSalesTax.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceSalesTax.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceSalesTax.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceSalesTax.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceSalesTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceSalesTax.Location = New System.Drawing.Point(343, 402)
            Me.CheckBoxExistingRows_ReplaceSalesTax.Name = "CheckBoxExistingRows_ReplaceSalesTax"
            Me.CheckBoxExistingRows_ReplaceSalesTax.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceSalesTax.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceSalesTax.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceSalesTax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceSalesTax.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceSalesTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceSalesTax.TabIndex = 51
            Me.CheckBoxExistingRows_ReplaceSalesTax.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceSalesTax.Text = "Replace Sales Tax"
            '
            'CheckBoxExistingRows_ReplaceMarkupPercent
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupPercent.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Location = New System.Drawing.Point(343, 376)
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Name = "CheckBoxExistingRows_ReplaceMarkupPercent"
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupPercent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.TabIndex = 50
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Text = "Replace Markup Percent"
            '
            'CheckBoxExistingRows_ReplaceNonbillable
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceNonbillable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceNonbillable.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceNonbillable.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceNonbillable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceNonbillable.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceNonbillable.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceNonbillable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceNonbillable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceNonbillable.Location = New System.Drawing.Point(343, 350)
            Me.CheckBoxExistingRows_ReplaceNonbillable.Name = "CheckBoxExistingRows_ReplaceNonbillable"
            Me.CheckBoxExistingRows_ReplaceNonbillable.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceNonbillable.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceNonbillable.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceNonbillable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceNonbillable.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceNonbillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceNonbillable.TabIndex = 49
            Me.CheckBoxExistingRows_ReplaceNonbillable.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceNonbillable.Text = "Replace Non-billable"
            '
            'CheckBoxExistingRows_ReplaceRates
            '
            '
            '
            '
            Me.CheckBoxExistingRows_ReplaceRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxExistingRows_ReplaceRates.CheckValue = 0
            Me.CheckBoxExistingRows_ReplaceRates.CheckValueChecked = 1
            Me.CheckBoxExistingRows_ReplaceRates.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxExistingRows_ReplaceRates.CheckValueUnchecked = 0
            Me.CheckBoxExistingRows_ReplaceRates.ChildControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceRates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceRates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxExistingRows_ReplaceRates.Location = New System.Drawing.Point(343, 324)
            Me.CheckBoxExistingRows_ReplaceRates.Name = "CheckBoxExistingRows_ReplaceRates"
            Me.CheckBoxExistingRows_ReplaceRates.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceRates.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceRates.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceRates.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxExistingRows_ReplaceRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceRates.TabIndex = 48
            Me.CheckBoxExistingRows_ReplaceRates.TabOnEnter = True
            Me.CheckBoxExistingRows_ReplaceRates.Text = "Replace Rates"
            '
            'LabelExistingRows_Choose
            '
            Me.LabelExistingRows_Choose.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelExistingRows_Choose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelExistingRows_Choose.Location = New System.Drawing.Point(343, 298)
            Me.LabelExistingRows_Choose.Name = "LabelExistingRows_Choose"
            Me.LabelExistingRows_Choose.Size = New System.Drawing.Size(325, 20)
            Me.LabelExistingRows_Choose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelExistingRows_Choose.TabIndex = 47
            Me.LabelExistingRows_Choose.Text = "Choose fields to replace from source rows to existing rows"
            '
            'LabelForm_ExistingRows
            '
            Me.LabelForm_ExistingRows.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ExistingRows.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ExistingRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ExistingRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ExistingRows.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ExistingRows.Location = New System.Drawing.Point(343, 272)
            Me.LabelForm_ExistingRows.Name = "LabelForm_ExistingRows"
            Me.LabelForm_ExistingRows.Size = New System.Drawing.Size(325, 20)
            Me.LabelForm_ExistingRows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ExistingRows.TabIndex = 46
            Me.LabelForm_ExistingRows.Text = "Existing Rows"
            '
            'LabelForm_StructureLevelLbl
            '
            Me.LabelForm_StructureLevelLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StructureLevelLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StructureLevelLbl.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StructureLevelLbl.Name = "LabelForm_StructureLevelLbl"
            Me.LabelForm_StructureLevelLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_StructureLevelLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StructureLevelLbl.TabIndex = 0
            Me.LabelForm_StructureLevelLbl.Text = "Structure Level:"
            '
            'ComboBoxForm_TargetEmployeeTitle
            '
            Me.ComboBoxForm_TargetEmployeeTitle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetEmployeeTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetEmployeeTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetEmployeeTitle.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetEmployeeTitle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetEmployeeTitle.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetEmployeeTitle.ClientCode = ""
            Me.ComboBoxForm_TargetEmployeeTitle.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EmployeeTitle
            Me.ComboBoxForm_TargetEmployeeTitle.DisableMouseWheel = False
            Me.ComboBoxForm_TargetEmployeeTitle.DisplayMember = "Description"
            Me.ComboBoxForm_TargetEmployeeTitle.DisplayName = ""
            Me.ComboBoxForm_TargetEmployeeTitle.DivisionCode = ""
            Me.ComboBoxForm_TargetEmployeeTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetEmployeeTitle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetEmployeeTitle.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetEmployeeTitle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetEmployeeTitle.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetEmployeeTitle.FormattingEnabled = True
            Me.ComboBoxForm_TargetEmployeeTitle.ItemHeight = 14
            Me.ComboBoxForm_TargetEmployeeTitle.Location = New System.Drawing.Point(405, 220)
            Me.ComboBoxForm_TargetEmployeeTitle.Name = "ComboBoxForm_TargetEmployeeTitle"
            Me.ComboBoxForm_TargetEmployeeTitle.ReadOnly = False
            Me.ComboBoxForm_TargetEmployeeTitle.SecurityEnabled = True
            Me.ComboBoxForm_TargetEmployeeTitle.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetEmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetEmployeeTitle.TabIndex = 35
            Me.ComboBoxForm_TargetEmployeeTitle.TabOnEnter = True
            Me.ComboBoxForm_TargetEmployeeTitle.ValueMember = "ID"
            Me.ComboBoxForm_TargetEmployeeTitle.WatermarkText = "Select Employee Title"
            '
            'ComboBoxForm_TargetEmployee
            '
            Me.ComboBoxForm_TargetEmployee.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetEmployee.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetEmployee.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetEmployee.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetEmployee.ClientCode = ""
            Me.ComboBoxForm_TargetEmployee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_TargetEmployee.DisableMouseWheel = False
            Me.ComboBoxForm_TargetEmployee.DisplayMember = "FullName"
            Me.ComboBoxForm_TargetEmployee.DisplayName = ""
            Me.ComboBoxForm_TargetEmployee.DivisionCode = ""
            Me.ComboBoxForm_TargetEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetEmployee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetEmployee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetEmployee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetEmployee.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetEmployee.FormattingEnabled = True
            Me.ComboBoxForm_TargetEmployee.ItemHeight = 14
            Me.ComboBoxForm_TargetEmployee.Location = New System.Drawing.Point(405, 194)
            Me.ComboBoxForm_TargetEmployee.Name = "ComboBoxForm_TargetEmployee"
            Me.ComboBoxForm_TargetEmployee.ReadOnly = False
            Me.ComboBoxForm_TargetEmployee.SecurityEnabled = True
            Me.ComboBoxForm_TargetEmployee.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetEmployee.TabIndex = 33
            Me.ComboBoxForm_TargetEmployee.TabOnEnter = True
            Me.ComboBoxForm_TargetEmployee.ValueMember = "Code"
            Me.ComboBoxForm_TargetEmployee.WatermarkText = "Select Employee"
            '
            'ComboBoxForm_TargetFunction
            '
            Me.ComboBoxForm_TargetFunction.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetFunction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetFunction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetFunction.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetFunction.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetFunction.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetFunction.ClientCode = ""
            Me.ComboBoxForm_TargetFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Function]
            Me.ComboBoxForm_TargetFunction.DisableMouseWheel = False
            Me.ComboBoxForm_TargetFunction.DisplayMember = "Description"
            Me.ComboBoxForm_TargetFunction.DisplayName = ""
            Me.ComboBoxForm_TargetFunction.DivisionCode = ""
            Me.ComboBoxForm_TargetFunction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetFunction.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetFunction.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetFunction.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetFunction.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetFunction.FormattingEnabled = True
            Me.ComboBoxForm_TargetFunction.ItemHeight = 14
            Me.ComboBoxForm_TargetFunction.Location = New System.Drawing.Point(405, 168)
            Me.ComboBoxForm_TargetFunction.Name = "ComboBoxForm_TargetFunction"
            Me.ComboBoxForm_TargetFunction.ReadOnly = False
            Me.ComboBoxForm_TargetFunction.SecurityEnabled = True
            Me.ComboBoxForm_TargetFunction.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetFunction.TabIndex = 31
            Me.ComboBoxForm_TargetFunction.TabOnEnter = True
            Me.ComboBoxForm_TargetFunction.ValueMember = "Code"
            Me.ComboBoxForm_TargetFunction.WatermarkText = "Select Function"
            '
            'ComboBoxForm_TargetSalesClass
            '
            Me.ComboBoxForm_TargetSalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetSalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetSalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetSalesClass.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetSalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetSalesClass.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetSalesClass.ClientCode = ""
            Me.ComboBoxForm_TargetSalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.SalesClass
            Me.ComboBoxForm_TargetSalesClass.DisableMouseWheel = False
            Me.ComboBoxForm_TargetSalesClass.DisplayMember = "Description"
            Me.ComboBoxForm_TargetSalesClass.DisplayName = ""
            Me.ComboBoxForm_TargetSalesClass.DivisionCode = ""
            Me.ComboBoxForm_TargetSalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetSalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetSalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetSalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetSalesClass.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetSalesClass.FormattingEnabled = True
            Me.ComboBoxForm_TargetSalesClass.ItemHeight = 14
            Me.ComboBoxForm_TargetSalesClass.Location = New System.Drawing.Point(405, 142)
            Me.ComboBoxForm_TargetSalesClass.Name = "ComboBoxForm_TargetSalesClass"
            Me.ComboBoxForm_TargetSalesClass.ReadOnly = False
            Me.ComboBoxForm_TargetSalesClass.SecurityEnabled = True
            Me.ComboBoxForm_TargetSalesClass.Size = New System.Drawing.Size(213, 20)
            Me.ComboBoxForm_TargetSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetSalesClass.TabIndex = 29
            Me.ComboBoxForm_TargetSalesClass.TabOnEnter = True
            Me.ComboBoxForm_TargetSalesClass.ValueMember = "Code"
            Me.ComboBoxForm_TargetSalesClass.WatermarkText = "Select Job"
            '
            'LabelForm_TargetEmployeeTitle
            '
            Me.LabelForm_TargetEmployeeTitle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetEmployeeTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetEmployeeTitle.Location = New System.Drawing.Point(318, 220)
            Me.LabelForm_TargetEmployeeTitle.Name = "LabelForm_TargetEmployeeTitle"
            Me.LabelForm_TargetEmployeeTitle.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetEmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetEmployeeTitle.TabIndex = 34
            Me.LabelForm_TargetEmployeeTitle.Text = "Employee Title:"
            '
            'LabelForm_TargetEmployee
            '
            Me.LabelForm_TargetEmployee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetEmployee.Location = New System.Drawing.Point(318, 194)
            Me.LabelForm_TargetEmployee.Name = "LabelForm_TargetEmployee"
            Me.LabelForm_TargetEmployee.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetEmployee.TabIndex = 32
            Me.LabelForm_TargetEmployee.Text = "Employee:"
            '
            'LabelForm_TargetFunction
            '
            Me.LabelForm_TargetFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetFunction.Location = New System.Drawing.Point(318, 168)
            Me.LabelForm_TargetFunction.Name = "LabelForm_TargetFunction"
            Me.LabelForm_TargetFunction.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetFunction.TabIndex = 30
            Me.LabelForm_TargetFunction.Text = "Function:"
            '
            'LabelForm_TargetSalesClass
            '
            Me.LabelForm_TargetSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetSalesClass.Location = New System.Drawing.Point(318, 142)
            Me.LabelForm_TargetSalesClass.Name = "LabelForm_TargetSalesClass"
            Me.LabelForm_TargetSalesClass.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetSalesClass.TabIndex = 28
            Me.LabelForm_TargetSalesClass.Text = "Sales Class:"
            '
            'LabelForm_SourceEmployeeTitleLbl
            '
            Me.LabelForm_SourceEmployeeTitleLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEmployeeTitleLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEmployeeTitleLbl.Location = New System.Drawing.Point(12, 220)
            Me.LabelForm_SourceEmployeeTitleLbl.Name = "LabelForm_SourceEmployeeTitleLbl"
            Me.LabelForm_SourceEmployeeTitleLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceEmployeeTitleLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEmployeeTitleLbl.TabIndex = 15
            Me.LabelForm_SourceEmployeeTitleLbl.Text = "Employee Title:"
            '
            'LabelForm_SourceEmployeeLbl
            '
            Me.LabelForm_SourceEmployeeLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEmployeeLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEmployeeLbl.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_SourceEmployeeLbl.Name = "LabelForm_SourceEmployeeLbl"
            Me.LabelForm_SourceEmployeeLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceEmployeeLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEmployeeLbl.TabIndex = 13
            Me.LabelForm_SourceEmployeeLbl.Text = "Employee:"
            '
            'LabelForm_SourceFunctionLbl
            '
            Me.LabelForm_SourceFunctionLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceFunctionLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceFunctionLbl.Location = New System.Drawing.Point(12, 168)
            Me.LabelForm_SourceFunctionLbl.Name = "LabelForm_SourceFunctionLbl"
            Me.LabelForm_SourceFunctionLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceFunctionLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceFunctionLbl.TabIndex = 11
            Me.LabelForm_SourceFunctionLbl.Text = "Function:"
            '
            'LabelForm_SourceSalesClassLbl
            '
            Me.LabelForm_SourceSalesClassLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceSalesClassLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceSalesClassLbl.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_SourceSalesClassLbl.Name = "LabelForm_SourceSalesClassLbl"
            Me.LabelForm_SourceSalesClassLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceSalesClassLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceSalesClassLbl.TabIndex = 9
            Me.LabelForm_SourceSalesClassLbl.Text = "Sales Class:"
            '
            'LabelForm_SourceProductLbl
            '
            Me.LabelForm_SourceProductLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceProductLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceProductLbl.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_SourceProductLbl.Name = "LabelForm_SourceProductLbl"
            Me.LabelForm_SourceProductLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceProductLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceProductLbl.TabIndex = 7
            Me.LabelForm_SourceProductLbl.Text = "Product:"
            '
            'LabelForm_SourceDivisionLbl
            '
            Me.LabelForm_SourceDivisionLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceDivisionLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceDivisionLbl.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_SourceDivisionLbl.Name = "LabelForm_SourceDivisionLbl"
            Me.LabelForm_SourceDivisionLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceDivisionLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceDivisionLbl.TabIndex = 5
            Me.LabelForm_SourceDivisionLbl.Text = "Division:"
            '
            'LabelForm_SourceClientLbl
            '
            Me.LabelForm_SourceClientLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceClientLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceClientLbl.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_SourceClientLbl.Name = "LabelForm_SourceClientLbl"
            Me.LabelForm_SourceClientLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceClientLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceClientLbl.TabIndex = 3
            Me.LabelForm_SourceClientLbl.Text = "Client:"
            '
            'LabelForm_SourceEmployeeTitle
            '
            Me.LabelForm_SourceEmployeeTitle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEmployeeTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEmployeeTitle.Location = New System.Drawing.Point(99, 220)
            Me.LabelForm_SourceEmployeeTitle.Name = "LabelForm_SourceEmployeeTitle"
            Me.LabelForm_SourceEmployeeTitle.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceEmployeeTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEmployeeTitle.TabIndex = 16
            Me.LabelForm_SourceEmployeeTitle.Text = "Employee Title:"
            '
            'LabelForm_SourceEmployee
            '
            Me.LabelForm_SourceEmployee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEmployee.Location = New System.Drawing.Point(99, 194)
            Me.LabelForm_SourceEmployee.Name = "LabelForm_SourceEmployee"
            Me.LabelForm_SourceEmployee.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEmployee.TabIndex = 14
            Me.LabelForm_SourceEmployee.Text = "Employee:"
            '
            'LabelForm_SourceFunction
            '
            Me.LabelForm_SourceFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceFunction.Location = New System.Drawing.Point(99, 168)
            Me.LabelForm_SourceFunction.Name = "LabelForm_SourceFunction"
            Me.LabelForm_SourceFunction.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceFunction.TabIndex = 12
            Me.LabelForm_SourceFunction.Text = "Function:"
            '
            'LabelForm_SourceSalesClass
            '
            Me.LabelForm_SourceSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceSalesClass.Location = New System.Drawing.Point(99, 142)
            Me.LabelForm_SourceSalesClass.Name = "LabelForm_SourceSalesClass"
            Me.LabelForm_SourceSalesClass.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceSalesClass.TabIndex = 10
            Me.LabelForm_SourceSalesClass.Text = "Sales Class:"
            '
            'LabelForm_SourceProduct
            '
            Me.LabelForm_SourceProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceProduct.Location = New System.Drawing.Point(99, 116)
            Me.LabelForm_SourceProduct.Name = "LabelForm_SourceProduct"
            Me.LabelForm_SourceProduct.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceProduct.TabIndex = 8
            Me.LabelForm_SourceProduct.Text = "Product:"
            '
            'LabelForm_SourceDivision
            '
            Me.LabelForm_SourceDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceDivision.Location = New System.Drawing.Point(99, 90)
            Me.LabelForm_SourceDivision.Name = "LabelForm_SourceDivision"
            Me.LabelForm_SourceDivision.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceDivision.TabIndex = 6
            Me.LabelForm_SourceDivision.Text = "Division:"
            '
            'LabelForm_SourceClient
            '
            Me.LabelForm_SourceClient.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceClient.Location = New System.Drawing.Point(99, 64)
            Me.LabelForm_SourceClient.Name = "LabelForm_SourceClient"
            Me.LabelForm_SourceClient.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceClient.TabIndex = 4
            Me.LabelForm_SourceClient.Text = "Client:"
            '
            'LabelForm_StructureLevel
            '
            Me.LabelForm_StructureLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StructureLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StructureLevel.Location = New System.Drawing.Point(99, 12)
            Me.LabelForm_StructureLevel.Name = "LabelForm_StructureLevel"
            Me.LabelForm_StructureLevel.Size = New System.Drawing.Size(569, 20)
            Me.LabelForm_StructureLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StructureLevel.TabIndex = 1
            Me.LabelForm_StructureLevel.Text = "{0}"
            '
            'LabelForm_SourceEffectiveDate
            '
            Me.LabelForm_SourceEffectiveDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEffectiveDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEffectiveDate.Location = New System.Drawing.Point(99, 246)
            Me.LabelForm_SourceEffectiveDate.Name = "LabelForm_SourceEffectiveDate"
            Me.LabelForm_SourceEffectiveDate.Size = New System.Drawing.Size(213, 20)
            Me.LabelForm_SourceEffectiveDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEffectiveDate.TabIndex = 18
            Me.LabelForm_SourceEffectiveDate.Text = "Effective Date:"
            '
            'LabelForm_SourceEffectiveDateLbl
            '
            Me.LabelForm_SourceEffectiveDateLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceEffectiveDateLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceEffectiveDateLbl.Location = New System.Drawing.Point(12, 246)
            Me.LabelForm_SourceEffectiveDateLbl.Name = "LabelForm_SourceEffectiveDateLbl"
            Me.LabelForm_SourceEffectiveDateLbl.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SourceEffectiveDateLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceEffectiveDateLbl.TabIndex = 17
            Me.LabelForm_SourceEffectiveDateLbl.Text = "Effective Date:"
            '
            'LabelForm_TargetEffectiveDate
            '
            Me.LabelForm_TargetEffectiveDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetEffectiveDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetEffectiveDate.Location = New System.Drawing.Point(318, 246)
            Me.LabelForm_TargetEffectiveDate.Name = "LabelForm_TargetEffectiveDate"
            Me.LabelForm_TargetEffectiveDate.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetEffectiveDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetEffectiveDate.TabIndex = 36
            Me.LabelForm_TargetEffectiveDate.Text = "Effective Date:"
            '
            'DateTimePickerForm_TargetEffectiveDate
            '
            Me.DateTimePickerForm_TargetEffectiveDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_TargetEffectiveDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_TargetEffectiveDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TargetEffectiveDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_TargetEffectiveDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_TargetEffectiveDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_TargetEffectiveDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_TargetEffectiveDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_TargetEffectiveDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_TargetEffectiveDate.DisplayName = ""
            Me.DateTimePickerForm_TargetEffectiveDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_TargetEffectiveDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_TargetEffectiveDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_TargetEffectiveDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_TargetEffectiveDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_TargetEffectiveDate.Location = New System.Drawing.Point(405, 246)
            Me.DateTimePickerForm_TargetEffectiveDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_TargetEffectiveDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.DisplayMonth = New Date(2013, 2, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_TargetEffectiveDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_TargetEffectiveDate.Name = "DateTimePickerForm_TargetEffectiveDate"
            Me.DateTimePickerForm_TargetEffectiveDate.ReadOnly = False
            Me.DateTimePickerForm_TargetEffectiveDate.Size = New System.Drawing.Size(213, 20)
            Me.DateTimePickerForm_TargetEffectiveDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_TargetEffectiveDate.TabIndex = 37
            Me.DateTimePickerForm_TargetEffectiveDate.TabOnEnter = True
            Me.DateTimePickerForm_TargetEffectiveDate.Value = New Date(2020, 1, 9, 9, 30, 29, 906)
            '
            'BillRateCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(680, 512)
            Me.Controls.Add(Me.DateTimePickerForm_TargetEffectiveDate)
            Me.Controls.Add(Me.LabelForm_SourceEffectiveDate)
            Me.Controls.Add(Me.LabelForm_SourceEffectiveDateLbl)
            Me.Controls.Add(Me.LabelForm_TargetEffectiveDate)
            Me.Controls.Add(Me.LabelForm_StructureLevel)
            Me.Controls.Add(Me.LabelForm_SourceEmployeeTitle)
            Me.Controls.Add(Me.LabelForm_SourceEmployee)
            Me.Controls.Add(Me.LabelForm_SourceFunction)
            Me.Controls.Add(Me.LabelForm_SourceSalesClass)
            Me.Controls.Add(Me.LabelForm_SourceProduct)
            Me.Controls.Add(Me.LabelForm_SourceDivision)
            Me.Controls.Add(Me.LabelForm_SourceClient)
            Me.Controls.Add(Me.LabelForm_SourceEmployeeTitleLbl)
            Me.Controls.Add(Me.LabelForm_SourceEmployeeLbl)
            Me.Controls.Add(Me.LabelForm_SourceFunctionLbl)
            Me.Controls.Add(Me.LabelForm_SourceSalesClassLbl)
            Me.Controls.Add(Me.LabelForm_SourceProductLbl)
            Me.Controls.Add(Me.LabelForm_SourceDivisionLbl)
            Me.Controls.Add(Me.LabelForm_SourceClientLbl)
            Me.Controls.Add(Me.ComboBoxForm_TargetEmployeeTitle)
            Me.Controls.Add(Me.ComboBoxForm_TargetEmployee)
            Me.Controls.Add(Me.ComboBoxForm_TargetFunction)
            Me.Controls.Add(Me.ComboBoxForm_TargetSalesClass)
            Me.Controls.Add(Me.LabelForm_TargetEmployeeTitle)
            Me.Controls.Add(Me.LabelForm_TargetEmployee)
            Me.Controls.Add(Me.LabelForm_TargetFunction)
            Me.Controls.Add(Me.LabelForm_TargetSalesClass)
            Me.Controls.Add(Me.LabelForm_StructureLevelLbl)
            Me.Controls.Add(Me.CheckBoxForm_TargetProduct)
            Me.Controls.Add(Me.CheckBoxForm_TargetDivision)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceFeeTime)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceSalesTax)
            Me.Controls.Add(Me.LabelForm_NewRows)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceMarkupPercent)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceNonbillable)
            Me.Controls.Add(Me.CheckBoxExistingRows_ReplaceRates)
            Me.Controls.Add(Me.LabelExistingRows_Choose)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceFeeTime)
            Me.Controls.Add(Me.LabelForm_ExistingRows)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceMarkupTaxFlags)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceSalesTax)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceMarkupPercent)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceNonbillable)
            Me.Controls.Add(Me.CheckBoxNewRows_ReplaceRates)
            Me.Controls.Add(Me.LabelNewRows_Choose)
            Me.Controls.Add(Me.ButtonForm_ClearAll)
            Me.Controls.Add(Me.ComboBoxForm_TargetProduct)
            Me.Controls.Add(Me.ComboBoxForm_TargetDivision)
            Me.Controls.Add(Me.ComboBoxForm_TargetClient)
            Me.Controls.Add(Me.LabelForm_TargetProduct)
            Me.Controls.Add(Me.LabelForm_TargetDivision)
            Me.Controls.Add(Me.LabelForm_Target)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.LabelForm_TargetClient)
            Me.Controls.Add(Me.LabelForm_Source)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillRateCopyDialog"
            Me.Text = "Bill Rate Copy"
            CType(Me.DateTimePickerForm_TargetEffectiveDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Source As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_ClearAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_TargetProduct As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_TargetDivision As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_TargetClient As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_TargetProduct As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetDivision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Target As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetClient As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_TargetDivision As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_TargetProduct As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_NewRows As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewRows_Choose As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxNewRows_ReplaceRates As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewRows_ReplaceNonbillable As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewRows_ReplaceMarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewRows_ReplaceSalesTax As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewRows_ReplaceMarkupTaxFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewRows_ReplaceFeeTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceFeeTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceMarkupTaxFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceSalesTax As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceMarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceNonbillable As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxExistingRows_ReplaceRates As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelExistingRows_Choose As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ExistingRows As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StructureLevelLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_TargetEmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_TargetEmployee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_TargetFunction As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_TargetSalesClass As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_TargetEmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetEmployee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetFunction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetSalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEmployeeTitleLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEmployeeLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceFunctionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceSalesClassLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceProductLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceDivisionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceClientLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEmployeeTitle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEmployee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceFunction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceSalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceProduct As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceDivision As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceClient As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StructureLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEffectiveDate As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceEffectiveDateLbl As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_TargetEffectiveDate As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_TargetEffectiveDate As WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace