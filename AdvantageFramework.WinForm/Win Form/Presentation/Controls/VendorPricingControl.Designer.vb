Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorPricingControl
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
            Me.DataGridViewForm_VendorPricings = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewForm_VendorPricings
            '
            Me.DataGridViewForm_VendorPricings.AutoFilterLookupColumns = False
            Me.DataGridViewForm_VendorPricings.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_VendorPricings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_VendorPricings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_VendorPricings.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_VendorPricings.ItemDescription = ""
            Me.DataGridViewForm_VendorPricings.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_VendorPricings.MultiSelect = True
            Me.DataGridViewForm_VendorPricings.Name = "DataGridViewForm_VendorPricings"
            Me.DataGridViewForm_VendorPricings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_VendorPricings.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_VendorPricings.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewForm_VendorPricings.TabIndex = 1
            Me.DataGridViewForm_VendorPricings.UseEmbeddedNavigator = False
            Me.DataGridViewForm_VendorPricings.ViewCaptionHeight = -1
            '
            'VendorPricingControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_VendorPricings)
            Me.Name = "VendorPricingControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_VendorPricings As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
