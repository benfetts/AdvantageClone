Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorContractManagerControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.DataGridViewControl_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewControl_Contracts
            '
            Me.DataGridViewControl_Contracts.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Contracts.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Contracts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewControl_Contracts.DataSource = Nothing
            Me.DataGridViewControl_Contracts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewControl_Contracts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Contracts.ItemDescription = "Contract(s)"
            Me.DataGridViewControl_Contracts.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewControl_Contracts.MultiSelect = True
            Me.DataGridViewControl_Contracts.Name = "DataGridViewControl_Contracts"
            Me.DataGridViewControl_Contracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_Contracts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Contracts.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewControl_Contracts.TabIndex = 2
            Me.DataGridViewControl_Contracts.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Contracts.ViewCaptionHeight = -1
            '
            'VendorContractManagerControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewControl_Contracts)
            Me.Name = "VendorContractManagerControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_Contracts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
