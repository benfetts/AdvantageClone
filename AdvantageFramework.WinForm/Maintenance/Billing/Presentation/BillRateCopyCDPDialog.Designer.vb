Namespace Maintenance.Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillRateCopyCDPDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillRateCopyCDPDialog))
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
            Me.LabelForm_SourceProductLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceDivisionLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SourceClientLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StructureLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_SourceClient = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_SourceDivision = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_SourceProduct = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(719, 350)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 36
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(638, 350)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 35
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
            Me.LabelForm_Source.Size = New System.Drawing.Size(380, 20)
            Me.LabelForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Source.TabIndex = 2
            Me.LabelForm_Source.Text = "Source"
            '
            'ButtonForm_ClearAll
            '
            Me.ButtonForm_ClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ClearAll.Location = New System.Drawing.Point(557, 350)
            Me.ButtonForm_ClearAll.Name = "ButtonForm_ClearAll"
            Me.ButtonForm_ClearAll.SecurityEnabled = True
            Me.ButtonForm_ClearAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_ClearAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ClearAll.TabIndex = 34
            Me.ButtonForm_ClearAll.Text = "Clear All"
            '
            'ComboBoxForm_TargetProduct
            '
            Me.ComboBoxForm_TargetProduct.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_TargetProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetProduct.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetProduct.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetProduct.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetProduct.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_TargetProduct.DisableMouseWheel = False
            Me.ComboBoxForm_TargetProduct.DisplayMember = "Name"
            Me.ComboBoxForm_TargetProduct.DisplayName = ""
            Me.ComboBoxForm_TargetProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetProduct.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetProduct.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetProduct.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetProduct.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetProduct.FormattingEnabled = True
            Me.ComboBoxForm_TargetProduct.ItemHeight = 14
            Me.ComboBoxForm_TargetProduct.Location = New System.Drawing.Point(489, 116)
            Me.ComboBoxForm_TargetProduct.Name = "ComboBoxForm_TargetProduct"
            Me.ComboBoxForm_TargetProduct.PreventEnterBeep = False
            Me.ComboBoxForm_TargetProduct.ReadOnly = False
            Me.ComboBoxForm_TargetProduct.SecurityEnabled = True
            Me.ComboBoxForm_TargetProduct.Size = New System.Drawing.Size(255, 20)
            Me.ComboBoxForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetProduct.TabIndex = 16
            Me.ComboBoxForm_TargetProduct.ValueMember = "Code"
            Me.ComboBoxForm_TargetProduct.WatermarkText = "Select Product"
            '
            'ComboBoxForm_TargetDivision
            '
            Me.ComboBoxForm_TargetDivision.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetDivision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_TargetDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetDivision.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetDivision.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetDivision.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetDivision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_TargetDivision.DisableMouseWheel = False
            Me.ComboBoxForm_TargetDivision.DisplayMember = "Description"
            Me.ComboBoxForm_TargetDivision.DisplayName = ""
            Me.ComboBoxForm_TargetDivision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetDivision.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetDivision.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetDivision.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetDivision.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetDivision.FormattingEnabled = True
            Me.ComboBoxForm_TargetDivision.ItemHeight = 14
            Me.ComboBoxForm_TargetDivision.Location = New System.Drawing.Point(489, 90)
            Me.ComboBoxForm_TargetDivision.Name = "ComboBoxForm_TargetDivision"
            Me.ComboBoxForm_TargetDivision.PreventEnterBeep = False
            Me.ComboBoxForm_TargetDivision.ReadOnly = False
            Me.ComboBoxForm_TargetDivision.SecurityEnabled = True
            Me.ComboBoxForm_TargetDivision.Size = New System.Drawing.Size(255, 20)
            Me.ComboBoxForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetDivision.TabIndex = 13
            Me.ComboBoxForm_TargetDivision.ValueMember = "Code"
            Me.ComboBoxForm_TargetDivision.WatermarkText = "Select Division"
            '
            'ComboBoxForm_TargetClient
            '
            Me.ComboBoxForm_TargetClient.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_TargetClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_TargetClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_TargetClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_TargetClient.AutoFindItemInDataSource = False
            Me.ComboBoxForm_TargetClient.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_TargetClient.BookmarkingEnabled = False
            Me.ComboBoxForm_TargetClient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_TargetClient.DisableMouseWheel = False
            Me.ComboBoxForm_TargetClient.DisplayMember = "Name"
            Me.ComboBoxForm_TargetClient.DisplayName = ""
            Me.ComboBoxForm_TargetClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_TargetClient.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_TargetClient.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_TargetClient.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_TargetClient.FocusHighlightEnabled = True
            Me.ComboBoxForm_TargetClient.FormattingEnabled = True
            Me.ComboBoxForm_TargetClient.ItemHeight = 14
            Me.ComboBoxForm_TargetClient.Location = New System.Drawing.Point(489, 64)
            Me.ComboBoxForm_TargetClient.Name = "ComboBoxForm_TargetClient"
            Me.ComboBoxForm_TargetClient.PreventEnterBeep = False
            Me.ComboBoxForm_TargetClient.ReadOnly = False
            Me.ComboBoxForm_TargetClient.SecurityEnabled = True
            Me.ComboBoxForm_TargetClient.Size = New System.Drawing.Size(255, 20)
            Me.ComboBoxForm_TargetClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_TargetClient.TabIndex = 11
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
            Me.LabelForm_TargetProduct.Location = New System.Drawing.Point(402, 116)
            Me.LabelForm_TargetProduct.Name = "LabelForm_TargetProduct"
            Me.LabelForm_TargetProduct.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetProduct.TabIndex = 15
            Me.LabelForm_TargetProduct.Text = "Product:"
            '
            'LabelForm_TargetDivision
            '
            Me.LabelForm_TargetDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetDivision.Location = New System.Drawing.Point(402, 90)
            Me.LabelForm_TargetDivision.Name = "LabelForm_TargetDivision"
            Me.LabelForm_TargetDivision.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetDivision.TabIndex = 12
            Me.LabelForm_TargetDivision.Text = "Division:"
            '
            'LabelForm_Target
            '
            Me.LabelForm_Target.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.LabelForm_Target.Location = New System.Drawing.Point(402, 38)
            Me.LabelForm_Target.Name = "LabelForm_Target"
            Me.LabelForm_Target.Size = New System.Drawing.Size(392, 20)
            Me.LabelForm_Target.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Target.TabIndex = 9
            Me.LabelForm_Target.Text = "Target"
            '
            'LabelForm_TargetClient
            '
            Me.LabelForm_TargetClient.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TargetClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TargetClient.Location = New System.Drawing.Point(402, 64)
            Me.LabelForm_TargetClient.Name = "LabelForm_TargetClient"
            Me.LabelForm_TargetClient.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_TargetClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TargetClient.TabIndex = 10
            Me.LabelForm_TargetClient.Text = "Client:"
            '
            'CheckBoxForm_TargetDivision
            '
            Me.CheckBoxForm_TargetDivision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxForm_TargetDivision.Location = New System.Drawing.Point(750, 90)
            Me.CheckBoxForm_TargetDivision.Name = "CheckBoxForm_TargetDivision"
            Me.CheckBoxForm_TargetDivision.OldestSibling = Nothing
            Me.CheckBoxForm_TargetDivision.SecurityEnabled = True
            Me.CheckBoxForm_TargetDivision.SiblingControls = CType(resources.GetObject("CheckBoxForm_TargetDivision.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetDivision.Size = New System.Drawing.Size(44, 20)
            Me.CheckBoxForm_TargetDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TargetDivision.TabIndex = 14
            Me.CheckBoxForm_TargetDivision.Text = "All"
            '
            'CheckBoxForm_TargetProduct
            '
            Me.CheckBoxForm_TargetProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxForm_TargetProduct.Location = New System.Drawing.Point(750, 116)
            Me.CheckBoxForm_TargetProduct.Name = "CheckBoxForm_TargetProduct"
            Me.CheckBoxForm_TargetProduct.OldestSibling = Nothing
            Me.CheckBoxForm_TargetProduct.SecurityEnabled = True
            Me.CheckBoxForm_TargetProduct.SiblingControls = CType(resources.GetObject("CheckBoxForm_TargetProduct.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TargetProduct.Size = New System.Drawing.Size(44, 20)
            Me.CheckBoxForm_TargetProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TargetProduct.TabIndex = 17
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
            Me.LabelForm_NewRows.Location = New System.Drawing.Point(12, 142)
            Me.LabelForm_NewRows.Name = "LabelForm_NewRows"
            Me.LabelForm_NewRows.Size = New System.Drawing.Size(380, 20)
            Me.LabelForm_NewRows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NewRows.TabIndex = 18
            Me.LabelForm_NewRows.Text = "New Rows"
            '
            'LabelNewRows_Choose
            '
            Me.LabelNewRows_Choose.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewRows_Choose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewRows_Choose.Location = New System.Drawing.Point(12, 168)
            Me.LabelNewRows_Choose.Name = "LabelNewRows_Choose"
            Me.LabelNewRows_Choose.Size = New System.Drawing.Size(380, 20)
            Me.LabelNewRows_Choose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewRows_Choose.TabIndex = 19
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
            Me.CheckBoxNewRows_ReplaceRates.Location = New System.Drawing.Point(12, 194)
            Me.CheckBoxNewRows_ReplaceRates.Name = "CheckBoxNewRows_ReplaceRates"
            Me.CheckBoxNewRows_ReplaceRates.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceRates.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceRates.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceRates.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceRates.TabIndex = 20
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
            Me.CheckBoxNewRows_ReplaceNonbillable.Location = New System.Drawing.Point(12, 220)
            Me.CheckBoxNewRows_ReplaceNonbillable.Name = "CheckBoxNewRows_ReplaceNonbillable"
            Me.CheckBoxNewRows_ReplaceNonbillable.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceNonbillable.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceNonbillable.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceNonbillable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceNonbillable.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceNonbillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceNonbillable.TabIndex = 21
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
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Location = New System.Drawing.Point(12, 246)
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Name = "CheckBoxNewRows_ReplaceMarkupPercent"
            Me.CheckBoxNewRows_ReplaceMarkupPercent.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceMarkupPercent.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceMarkupPercent.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupPercent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceMarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceMarkupPercent.TabIndex = 22
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
            Me.CheckBoxNewRows_ReplaceSalesTax.Location = New System.Drawing.Point(12, 272)
            Me.CheckBoxNewRows_ReplaceSalesTax.Name = "CheckBoxNewRows_ReplaceSalesTax"
            Me.CheckBoxNewRows_ReplaceSalesTax.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceSalesTax.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceSalesTax.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceSalesTax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceSalesTax.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceSalesTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceSalesTax.TabIndex = 23
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
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Location = New System.Drawing.Point(12, 298)
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Name = "CheckBoxNewRows_ReplaceMarkupTaxFlags"
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceMarkupTaxFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceMarkupTaxFlags.TabIndex = 24
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
            Me.CheckBoxNewRows_ReplaceFeeTime.Location = New System.Drawing.Point(12, 324)
            Me.CheckBoxNewRows_ReplaceFeeTime.Name = "CheckBoxNewRows_ReplaceFeeTime"
            Me.CheckBoxNewRows_ReplaceFeeTime.OldestSibling = Nothing
            Me.CheckBoxNewRows_ReplaceFeeTime.SecurityEnabled = True
            Me.CheckBoxNewRows_ReplaceFeeTime.SiblingControls = CType(resources.GetObject("CheckBoxNewRows_ReplaceFeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewRows_ReplaceFeeTime.Size = New System.Drawing.Size(380, 20)
            Me.CheckBoxNewRows_ReplaceFeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewRows_ReplaceFeeTime.TabIndex = 25
            Me.CheckBoxNewRows_ReplaceFeeTime.Text = "Replace Fee Time"
            '
            'CheckBoxExistingRows_ReplaceFeeTime
            '
            Me.CheckBoxExistingRows_ReplaceFeeTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceFeeTime.Location = New System.Drawing.Point(402, 324)
            Me.CheckBoxExistingRows_ReplaceFeeTime.Name = "CheckBoxExistingRows_ReplaceFeeTime"
            Me.CheckBoxExistingRows_ReplaceFeeTime.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceFeeTime.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceFeeTime.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceFeeTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceFeeTime.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceFeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceFeeTime.TabIndex = 33
            Me.CheckBoxExistingRows_ReplaceFeeTime.Text = "Replace Fee Time"
            '
            'CheckBoxExistingRows_ReplaceMarkupTaxFlags
            '
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Location = New System.Drawing.Point(402, 298)
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Name = "CheckBoxExistingRows_ReplaceMarkupTaxFlags"
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupTaxFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.TabIndex = 32
            Me.CheckBoxExistingRows_ReplaceMarkupTaxFlags.Text = "Replace Markup Tax Flags"
            '
            'CheckBoxExistingRows_ReplaceSalesTax
            '
            Me.CheckBoxExistingRows_ReplaceSalesTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceSalesTax.Location = New System.Drawing.Point(402, 272)
            Me.CheckBoxExistingRows_ReplaceSalesTax.Name = "CheckBoxExistingRows_ReplaceSalesTax"
            Me.CheckBoxExistingRows_ReplaceSalesTax.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceSalesTax.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceSalesTax.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceSalesTax.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceSalesTax.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceSalesTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceSalesTax.TabIndex = 31
            Me.CheckBoxExistingRows_ReplaceSalesTax.Text = "Replace Sales Tax"
            '
            'CheckBoxExistingRows_ReplaceMarkupPercent
            '
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Location = New System.Drawing.Point(402, 246)
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Name = "CheckBoxExistingRows_ReplaceMarkupPercent"
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceMarkupPercent.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.TabIndex = 30
            Me.CheckBoxExistingRows_ReplaceMarkupPercent.Text = "Replace Markup Percent"
            '
            'CheckBoxExistingRows_ReplaceNonbillable
            '
            Me.CheckBoxExistingRows_ReplaceNonbillable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceNonbillable.Location = New System.Drawing.Point(402, 220)
            Me.CheckBoxExistingRows_ReplaceNonbillable.Name = "CheckBoxExistingRows_ReplaceNonbillable"
            Me.CheckBoxExistingRows_ReplaceNonbillable.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceNonbillable.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceNonbillable.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceNonbillable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceNonbillable.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceNonbillable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceNonbillable.TabIndex = 29
            Me.CheckBoxExistingRows_ReplaceNonbillable.Text = "Replace Non-billable"
            '
            'CheckBoxExistingRows_ReplaceRates
            '
            Me.CheckBoxExistingRows_ReplaceRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.CheckBoxExistingRows_ReplaceRates.Location = New System.Drawing.Point(402, 194)
            Me.CheckBoxExistingRows_ReplaceRates.Name = "CheckBoxExistingRows_ReplaceRates"
            Me.CheckBoxExistingRows_ReplaceRates.OldestSibling = Nothing
            Me.CheckBoxExistingRows_ReplaceRates.SecurityEnabled = True
            Me.CheckBoxExistingRows_ReplaceRates.SiblingControls = CType(resources.GetObject("CheckBoxExistingRows_ReplaceRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxExistingRows_ReplaceRates.Size = New System.Drawing.Size(392, 20)
            Me.CheckBoxExistingRows_ReplaceRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxExistingRows_ReplaceRates.TabIndex = 28
            Me.CheckBoxExistingRows_ReplaceRates.Text = "Replace Rates"
            '
            'LabelExistingRows_Choose
            '
            Me.LabelExistingRows_Choose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelExistingRows_Choose.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelExistingRows_Choose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelExistingRows_Choose.Location = New System.Drawing.Point(402, 168)
            Me.LabelExistingRows_Choose.Name = "LabelExistingRows_Choose"
            Me.LabelExistingRows_Choose.Size = New System.Drawing.Size(392, 20)
            Me.LabelExistingRows_Choose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelExistingRows_Choose.TabIndex = 27
            Me.LabelExistingRows_Choose.Text = "Choose fields to replace from source rows to existing rows"
            '
            'LabelForm_ExistingRows
            '
            Me.LabelForm_ExistingRows.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.LabelForm_ExistingRows.Location = New System.Drawing.Point(402, 142)
            Me.LabelForm_ExistingRows.Name = "LabelForm_ExistingRows"
            Me.LabelForm_ExistingRows.Size = New System.Drawing.Size(392, 20)
            Me.LabelForm_ExistingRows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ExistingRows.TabIndex = 26
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
            'LabelForm_StructureLevel
            '
            Me.LabelForm_StructureLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_StructureLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StructureLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StructureLevel.Location = New System.Drawing.Point(99, 12)
            Me.LabelForm_StructureLevel.Name = "LabelForm_StructureLevel"
            Me.LabelForm_StructureLevel.Size = New System.Drawing.Size(695, 20)
            Me.LabelForm_StructureLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StructureLevel.TabIndex = 1
            Me.LabelForm_StructureLevel.Text = "{0}"
            '
            'ComboBoxForm_SourceClient
            '
            Me.ComboBoxForm_SourceClient.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SourceClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SourceClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SourceClient.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SourceClient.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SourceClient.BookmarkingEnabled = False
            Me.ComboBoxForm_SourceClient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_SourceClient.DisableMouseWheel = False
            Me.ComboBoxForm_SourceClient.DisplayMember = "Name"
            Me.ComboBoxForm_SourceClient.DisplayName = ""
            Me.ComboBoxForm_SourceClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SourceClient.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SourceClient.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SourceClient.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SourceClient.FocusHighlightEnabled = True
            Me.ComboBoxForm_SourceClient.FormattingEnabled = True
            Me.ComboBoxForm_SourceClient.ItemHeight = 14
            Me.ComboBoxForm_SourceClient.Location = New System.Drawing.Point(99, 64)
            Me.ComboBoxForm_SourceClient.Name = "ComboBoxForm_SourceClient"
            Me.ComboBoxForm_SourceClient.PreventEnterBeep = False
            Me.ComboBoxForm_SourceClient.ReadOnly = False
            Me.ComboBoxForm_SourceClient.SecurityEnabled = True
            Me.ComboBoxForm_SourceClient.Size = New System.Drawing.Size(293, 20)
            Me.ComboBoxForm_SourceClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SourceClient.TabIndex = 37
            Me.ComboBoxForm_SourceClient.ValueMember = "Code"
            Me.ComboBoxForm_SourceClient.WatermarkText = "Select Client"
            '
            'ComboBoxForm_SourceDivision
            '
            Me.ComboBoxForm_SourceDivision.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SourceDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SourceDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SourceDivision.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SourceDivision.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SourceDivision.BookmarkingEnabled = False
            Me.ComboBoxForm_SourceDivision.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_SourceDivision.DisableMouseWheel = False
            Me.ComboBoxForm_SourceDivision.DisplayMember = "Description"
            Me.ComboBoxForm_SourceDivision.DisplayName = ""
            Me.ComboBoxForm_SourceDivision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SourceDivision.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SourceDivision.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SourceDivision.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SourceDivision.FocusHighlightEnabled = True
            Me.ComboBoxForm_SourceDivision.FormattingEnabled = True
            Me.ComboBoxForm_SourceDivision.ItemHeight = 14
            Me.ComboBoxForm_SourceDivision.Location = New System.Drawing.Point(99, 90)
            Me.ComboBoxForm_SourceDivision.Name = "ComboBoxForm_SourceDivision"
            Me.ComboBoxForm_SourceDivision.PreventEnterBeep = False
            Me.ComboBoxForm_SourceDivision.ReadOnly = False
            Me.ComboBoxForm_SourceDivision.SecurityEnabled = True
            Me.ComboBoxForm_SourceDivision.Size = New System.Drawing.Size(293, 20)
            Me.ComboBoxForm_SourceDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SourceDivision.TabIndex = 38
            Me.ComboBoxForm_SourceDivision.ValueMember = "Code"
            Me.ComboBoxForm_SourceDivision.WatermarkText = "Select Division"
            '
            'ComboBoxForm_SourceProduct
            '
            Me.ComboBoxForm_SourceProduct.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SourceProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SourceProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SourceProduct.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SourceProduct.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SourceProduct.BookmarkingEnabled = False
            Me.ComboBoxForm_SourceProduct.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_SourceProduct.DisableMouseWheel = False
            Me.ComboBoxForm_SourceProduct.DisplayMember = "Name"
            Me.ComboBoxForm_SourceProduct.DisplayName = ""
            Me.ComboBoxForm_SourceProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SourceProduct.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SourceProduct.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SourceProduct.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SourceProduct.FocusHighlightEnabled = True
            Me.ComboBoxForm_SourceProduct.FormattingEnabled = True
            Me.ComboBoxForm_SourceProduct.ItemHeight = 14
            Me.ComboBoxForm_SourceProduct.Location = New System.Drawing.Point(99, 116)
            Me.ComboBoxForm_SourceProduct.Name = "ComboBoxForm_SourceProduct"
            Me.ComboBoxForm_SourceProduct.PreventEnterBeep = False
            Me.ComboBoxForm_SourceProduct.ReadOnly = False
            Me.ComboBoxForm_SourceProduct.SecurityEnabled = True
            Me.ComboBoxForm_SourceProduct.Size = New System.Drawing.Size(293, 20)
            Me.ComboBoxForm_SourceProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SourceProduct.TabIndex = 39
            Me.ComboBoxForm_SourceProduct.ValueMember = "Code"
            Me.ComboBoxForm_SourceProduct.WatermarkText = "Select Product"
            '
            'BillRateCopyCDPDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(806, 382)
            Me.Controls.Add(Me.ComboBoxForm_SourceProduct)
            Me.Controls.Add(Me.ComboBoxForm_SourceDivision)
            Me.Controls.Add(Me.ComboBoxForm_SourceClient)
            Me.Controls.Add(Me.LabelForm_StructureLevel)
            Me.Controls.Add(Me.LabelForm_SourceProductLbl)
            Me.Controls.Add(Me.LabelForm_SourceDivisionLbl)
            Me.Controls.Add(Me.LabelForm_SourceClientLbl)
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
            Me.Name = "BillRateCopyCDPDialog"
            Me.Text = "Bill Rate Copy"
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
        Friend WithEvents LabelForm_SourceProductLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceDivisionLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceClientLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StructureLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_SourceClient As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_SourceDivision As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_SourceProduct As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace