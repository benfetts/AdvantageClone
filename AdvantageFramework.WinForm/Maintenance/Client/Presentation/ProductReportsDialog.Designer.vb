Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductReportsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductReportsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_ReportFormats = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ListBoxForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.ListBox()
            Me.LabelForm_SelectProducts = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(727, 380)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(646, 380)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_ReportFormats
            '
            Me.LabelForm_ReportFormats.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ReportFormats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ReportFormats.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ReportFormats.Name = "LabelForm_ReportFormats"
            Me.LabelForm_ReportFormats.Size = New System.Drawing.Size(237, 20)
            Me.LabelForm_ReportFormats.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportFormats.TabIndex = 0
            Me.LabelForm_ReportFormats.Text = "Report Formats"
            '
            'DataGridViewForm_Products
            '
            Me.DataGridViewForm_Products.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Products.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Products.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Products.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_Products.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Products.ItemDescription = ""
            Me.DataGridViewForm_Products.Location = New System.Drawing.Point(255, 38)
            Me.DataGridViewForm_Products.MultiSelect = True
            Me.DataGridViewForm_Products.Name = "DataGridViewForm_Products"
            Me.DataGridViewForm_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Products.Size = New System.Drawing.Size(547, 336)
            Me.DataGridViewForm_Products.TabIndex = 0
            Me.DataGridViewForm_Products.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Products.ViewCaptionHeight = -1
            '
            'ListBoxForm_Reports
            '
            Me.ListBoxForm_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ListBox.Type.Report
            Me.ListBoxForm_Reports.DisplayMember = "Description"
            Me.ListBoxForm_Reports.ExtraListBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ListBox.ExtraListBoxItems.[Nothing]
            Me.ListBoxForm_Reports.ExtraListBoxItemDisplayText = Nothing
            Me.ListBoxForm_Reports.ExtraListBoxItemValueObject = Nothing
            Me.ListBoxForm_Reports.Location = New System.Drawing.Point(12, 38)
            Me.ListBoxForm_Reports.Name = "ListBoxForm_Reports"
            Me.ListBoxForm_Reports.Size = New System.Drawing.Size(237, 336)
            Me.ListBoxForm_Reports.TabIndex = 1
            Me.ListBoxForm_Reports.ValueMember = "Code"
            '
            'LabelForm_SelectProducts
            '
            Me.LabelForm_SelectProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SelectProducts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProducts.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectProducts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectProducts.Location = New System.Drawing.Point(255, 12)
            Me.LabelForm_SelectProducts.Name = "LabelForm_SelectProducts"
            Me.LabelForm_SelectProducts.Size = New System.Drawing.Size(547, 20)
            Me.LabelForm_SelectProducts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectProducts.TabIndex = 9
            Me.LabelForm_SelectProducts.Text = "Select Product(s)"
            '
            'ProductReportsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 412)
            Me.Controls.Add(Me.ListBoxForm_Reports)
            Me.Controls.Add(Me.DataGridViewForm_Products)
            Me.Controls.Add(Me.LabelForm_ReportFormats)
            Me.Controls.Add(Me.LabelForm_SelectProducts)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProductReportsDialog"
            Me.Text = "Product Reports"
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_ReportFormats As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ListBoxForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.ListBox
        Friend WithEvents LabelForm_SelectProducts As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace