Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductCategoryCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductCategoryCopyDialog))
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_ProductCategory = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_SelectProductCategories = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_AllProducts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_AllDivisions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_SelectClientDivisionProducts = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(310, 434)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 11
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(391, 434)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_ProductCategory
            '
            Me.DataGridViewForm_ProductCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_ProductCategory.ItemDescription = ""
            Me.DataGridViewForm_ProductCategory.Location = New System.Drawing.Point(12, 142)
            Me.DataGridViewForm_ProductCategory.MultiSelect = True
            Me.DataGridViewForm_ProductCategory.Name = "DataGridViewForm_ProductCategory"
            Me.DataGridViewForm_ProductCategory.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ProductCategory.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductCategory.Size = New System.Drawing.Size(454, 286)
            Me.DataGridViewForm_ProductCategory.TabIndex = 10
            '
            'LabelForm_SelectProductCategories
            '
            Me.LabelForm_SelectProductCategories.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProductCategories.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProductCategories.BackgroundStyle.Class = ""
            Me.LabelForm_SelectProductCategories.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectProductCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectProductCategories.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectProductCategories.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_SelectProductCategories.Name = "LabelForm_SelectProductCategories"
            Me.LabelForm_SelectProductCategories.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_SelectProductCategories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectProductCategories.TabIndex = 9
            Me.LabelForm_SelectProductCategories.Text = "Select Product Category(ies) to copy (hold CTRL to select multiple)"
            '
            'CheckBoxForm_AllProducts
            '
            '
            '
            '
            Me.CheckBoxForm_AllProducts.BackgroundStyle.Class = ""
            Me.CheckBoxForm_AllProducts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AllProducts.CheckValue = 0
            Me.CheckBoxForm_AllProducts.CheckValueChecked = 1
            Me.CheckBoxForm_AllProducts.CheckValueUnchecked = 0
            Me.CheckBoxForm_AllProducts.ChildControls = CType(resources.GetObject("CheckBoxForm_AllProducts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllProducts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AllProducts.Location = New System.Drawing.Point(423, 90)
            Me.CheckBoxForm_AllProducts.Name = "CheckBoxForm_AllProducts"
            Me.CheckBoxForm_AllProducts.OldestSibling = Nothing
            Me.CheckBoxForm_AllProducts.SiblingControls = CType(resources.GetObject("CheckBoxForm_AllProducts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllProducts.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxForm_AllProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AllProducts.TabIndex = 8
            Me.CheckBoxForm_AllProducts.Text = "All"
            '
            'CheckBoxForm_AllDivisions
            '
            '
            '
            '
            Me.CheckBoxForm_AllDivisions.BackgroundStyle.Class = ""
            Me.CheckBoxForm_AllDivisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AllDivisions.CheckValue = 0
            Me.CheckBoxForm_AllDivisions.CheckValueChecked = 1
            Me.CheckBoxForm_AllDivisions.CheckValueUnchecked = 0
            Me.CheckBoxForm_AllDivisions.ChildControls = CType(resources.GetObject("CheckBoxForm_AllDivisions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllDivisions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AllDivisions.Location = New System.Drawing.Point(423, 64)
            Me.CheckBoxForm_AllDivisions.Name = "CheckBoxForm_AllDivisions"
            Me.CheckBoxForm_AllDivisions.OldestSibling = Nothing
            Me.CheckBoxForm_AllDivisions.SiblingControls = CType(resources.GetObject("CheckBoxForm_AllDivisions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AllDivisions.Size = New System.Drawing.Size(43, 20)
            Me.CheckBoxForm_AllDivisions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AllDivisions.TabIndex = 5
            Me.CheckBoxForm_AllDivisions.Text = "All"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(72, 38)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.PreventEnterBeep = False
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(394, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 2
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(72, 90)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.PreventEnterBeep = False
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(345, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 7
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Product"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(72, 64)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.PreventEnterBeep = False
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(345, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 4
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Division"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.Class = ""
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(54, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 6
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.Class = ""
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(54, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 3
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.Class = ""
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(54, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 1
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_SelectClientDivisionProducts
            '
            Me.LabelForm_SelectClientDivisionProducts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.Class = ""
            Me.LabelForm_SelectClientDivisionProducts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectClientDivisionProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectClientDivisionProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectClientDivisionProducts.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_SelectClientDivisionProducts.Name = "LabelForm_SelectClientDivisionProducts"
            Me.LabelForm_SelectClientDivisionProducts.Size = New System.Drawing.Size(454, 20)
            Me.LabelForm_SelectClientDivisionProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectClientDivisionProducts.TabIndex = 0
            Me.LabelForm_SelectClientDivisionProducts.Text = "Select Client / Division / Product to copy to"
            '
            'ProductCategoryCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(478, 466)
            Me.Controls.Add(Me.LabelForm_SelectClientDivisionProducts)
            Me.Controls.Add(Me.CheckBoxForm_AllProducts)
            Me.Controls.Add(Me.CheckBoxForm_AllDivisions)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.LabelForm_SelectProductCategories)
            Me.Controls.Add(Me.DataGridViewForm_ProductCategory)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProductCategoryCopyDialog"
            Me.Text = "Copy Product Category"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_ProductCategory As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_SelectProductCategories As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_AllProducts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_AllDivisions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SelectClientDivisionProducts As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace