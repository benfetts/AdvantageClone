Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCoopControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCoopControl))
            Me.PanelControl_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_AddProducts = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddAllProducts = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveAllProducts = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveProducts = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_BillingCoopProducts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelControl_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TextBoxTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTopSection_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_RightSection.SuspendLayout()
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_LeftSection.SuspendLayout()
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelControl_RightSection
            '
            Me.PanelControl_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddProducts)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddAllProducts)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveAllProducts)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveProducts)
            Me.PanelControl_RightSection.Controls.Add(Me.DataGridViewRightSection_BillingCoopProducts)
            Me.PanelControl_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_RightSection.Location = New System.Drawing.Point(325, 25)
            Me.PanelControl_RightSection.Name = "PanelControl_RightSection"
            Me.PanelControl_RightSection.Size = New System.Drawing.Size(410, 409)
            Me.PanelControl_RightSection.TabIndex = 2
            '
            'ButtonRightSection_AddProducts
            '
            Me.ButtonRightSection_AddProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddProducts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddProducts.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddProducts.Name = "ButtonRightSection_AddProducts"
            Me.ButtonRightSection_AddProducts.SecurityEnabled = True
            Me.ButtonRightSection_AddProducts.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddProducts.TabIndex = 0
            Me.ButtonRightSection_AddProducts.Text = "-->"
            '
            'ButtonRightSection_AddAllProducts
            '
            Me.ButtonRightSection_AddAllProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddAllProducts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddAllProducts.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_AddAllProducts.Name = "ButtonRightSection_AddAllProducts"
            Me.ButtonRightSection_AddAllProducts.SecurityEnabled = True
            Me.ButtonRightSection_AddAllProducts.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddAllProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddAllProducts.TabIndex = 1
            Me.ButtonRightSection_AddAllProducts.Text = "-->>"
            '
            'ButtonRightSection_RemoveAllProducts
            '
            Me.ButtonRightSection_RemoveAllProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveAllProducts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveAllProducts.Location = New System.Drawing.Point(6, 84)
            Me.ButtonRightSection_RemoveAllProducts.Name = "ButtonRightSection_RemoveAllProducts"
            Me.ButtonRightSection_RemoveAllProducts.SecurityEnabled = True
            Me.ButtonRightSection_RemoveAllProducts.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveAllProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveAllProducts.TabIndex = 3
            Me.ButtonRightSection_RemoveAllProducts.Text = "<<--"
            '
            'ButtonRightSection_RemoveProducts
            '
            Me.ButtonRightSection_RemoveProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveProducts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveProducts.Location = New System.Drawing.Point(6, 58)
            Me.ButtonRightSection_RemoveProducts.Name = "ButtonRightSection_RemoveProducts"
            Me.ButtonRightSection_RemoveProducts.SecurityEnabled = True
            Me.ButtonRightSection_RemoveProducts.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveProducts.TabIndex = 2
            Me.ButtonRightSection_RemoveProducts.Text = "<--"
            '
            'DataGridViewRightSection_BillingCoopProducts
            '
            Me.DataGridViewRightSection_BillingCoopProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_BillingCoopProducts.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_BillingCoopProducts.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_BillingCoopProducts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_BillingCoopProducts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_BillingCoopProducts.ItemDescription = "Billing Coop Product(s)"
            Me.DataGridViewRightSection_BillingCoopProducts.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_BillingCoopProducts.MultiSelect = True
            Me.DataGridViewRightSection_BillingCoopProducts.Name = "DataGridViewRightSection_BillingCoopProducts"
            Me.DataGridViewRightSection_BillingCoopProducts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_BillingCoopProducts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_BillingCoopProducts.Size = New System.Drawing.Size(323, 403)
            Me.DataGridViewRightSection_BillingCoopProducts.TabIndex = 4
            Me.DataGridViewRightSection_BillingCoopProducts.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_BillingCoopProducts.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl_LeftRight
            '
            Me.ExpandableSplitterControl_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl_LeftRight.ExpandableControl = Me.PanelControl_LeftSection
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.Location = New System.Drawing.Point(319, 25)
            Me.ExpandableSplitterControl_LeftRight.Name = "ExpandableSplitterControl_LeftRight"
            Me.ExpandableSplitterControl_LeftRight.Size = New System.Drawing.Size(6, 409)
            Me.ExpandableSplitterControl_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl_LeftRight.TabIndex = 6
            Me.ExpandableSplitterControl_LeftRight.TabStop = False
            '
            'PanelControl_LeftSection
            '
            Me.PanelControl_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Products)
            Me.PanelControl_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelControl_LeftSection.Location = New System.Drawing.Point(0, 25)
            Me.PanelControl_LeftSection.Name = "PanelControl_LeftSection"
            Me.PanelControl_LeftSection.Size = New System.Drawing.Size(319, 409)
            Me.PanelControl_LeftSection.TabIndex = 1
            '
            'DataGridViewLeftSection_Products
            '
            Me.DataGridViewLeftSection_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Products.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Products.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Products.DataSource = Nothing
            Me.DataGridViewLeftSection_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Products.ItemDescription = "Product(s)"
            Me.DataGridViewLeftSection_Products.Location = New System.Drawing.Point(0, 6)
            Me.DataGridViewLeftSection_Products.MultiSelect = True
            Me.DataGridViewLeftSection_Products.Name = "DataGridViewLeftSection_Products"
            Me.DataGridViewLeftSection_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Products.Size = New System.Drawing.Size(313, 403)
            Me.DataGridViewLeftSection_Products.TabIndex = 0
            Me.DataGridViewLeftSection_Products.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Products.ViewCaptionHeight = -1
            '
            'PanelControl_TopSection
            '
            Me.PanelControl_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_TopSection.Controls.Add(Me.TextBoxTopSection_Code)
            Me.PanelControl_TopSection.Controls.Add(Me.LabelTopSection_Code)
            Me.PanelControl_TopSection.Controls.Add(Me.CheckBoxTopSection_Inactive)
            Me.PanelControl_TopSection.Controls.Add(Me.TextBoxTopSection_Description)
            Me.PanelControl_TopSection.Controls.Add(Me.LabelTopSection_Description)
            Me.PanelControl_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_TopSection.Name = "PanelControl_TopSection"
            Me.PanelControl_TopSection.Size = New System.Drawing.Size(735, 25)
            Me.PanelControl_TopSection.TabIndex = 0
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
            Me.TextBoxTopSection_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTopSection_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Code.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Code.Location = New System.Drawing.Point(41, 0)
            Me.TextBoxTopSection_Code.Name = "TextBoxTopSection_Code"
            Me.TextBoxTopSection_Code.Size = New System.Drawing.Size(82, 20)
            Me.TextBoxTopSection_Code.TabIndex = 1
            Me.TextBoxTopSection_Code.TabOnEnter = True
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
            Me.LabelTopSection_Code.Size = New System.Drawing.Size(35, 20)
            Me.LabelTopSection_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Code.TabIndex = 0
            Me.LabelTopSection_Code.Text = "Code:"
            '
            'CheckBoxTopSection_Inactive
            '
            Me.CheckBoxTopSection_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTopSection_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTopSection_Inactive.CheckValue = 0
            Me.CheckBoxTopSection_Inactive.CheckValueChecked = 1
            Me.CheckBoxTopSection_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxTopSection_Inactive.ChildControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTopSection_Inactive.Location = New System.Drawing.Point(666, 0)
            Me.CheckBoxTopSection_Inactive.Name = "CheckBoxTopSection_Inactive"
            Me.CheckBoxTopSection_Inactive.OldestSibling = Nothing
            Me.CheckBoxTopSection_Inactive.SecurityEnabled = True
            Me.CheckBoxTopSection_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxTopSection_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTopSection_Inactive.Size = New System.Drawing.Size(69, 20)
            Me.CheckBoxTopSection_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTopSection_Inactive.TabIndex = 4
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
            Me.TextBoxTopSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTopSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Description.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Description.Location = New System.Drawing.Point(198, 0)
            Me.TextBoxTopSection_Description.Name = "TextBoxTopSection_Description"
            Me.TextBoxTopSection_Description.Size = New System.Drawing.Size(462, 20)
            Me.TextBoxTopSection_Description.TabIndex = 3
            Me.TextBoxTopSection_Description.TabOnEnter = True
            '
            'LabelTopSection_Description
            '
            Me.LabelTopSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Description.Location = New System.Drawing.Point(129, 0)
            Me.LabelTopSection_Description.Name = "LabelTopSection_Description"
            Me.LabelTopSection_Description.Size = New System.Drawing.Size(63, 20)
            Me.LabelTopSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Description.TabIndex = 2
            Me.LabelTopSection_Description.Text = "Description:"
            '
            'BillingCoopControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.Controls.Add(Me.PanelControl_LeftSection)
            Me.Controls.Add(Me.PanelControl_TopSection)
            Me.Name = "BillingCoopControl"
            Me.Size = New System.Drawing.Size(735, 434)
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_RightSection.ResumeLayout(False)
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_LeftSection.ResumeLayout(False)
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_AddProducts As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddAllProducts As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveAllProducts As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveProducts As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_BillingCoopProducts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents TextBoxTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxTopSection_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox

    End Class

End Namespace