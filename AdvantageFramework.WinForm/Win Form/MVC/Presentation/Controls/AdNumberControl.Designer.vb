Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AdNumberControl
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
            Me.DataGridViewControl_AdNumbers = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewControl_AdNumbers
            '
            Me.DataGridViewControl_AdNumbers.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_AdNumbers.AutoUpdateViewCaption = True
            Me.DataGridViewControl_AdNumbers.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewControl_AdNumbers.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_AdNumbers.ItemDescription = "Ad Number(s)"
            Me.DataGridViewControl_AdNumbers.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewControl_AdNumbers.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_AdNumbers.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_AdNumbers.ModifyGridRowHeight = False
            Me.DataGridViewControl_AdNumbers.MultiSelect = True
            Me.DataGridViewControl_AdNumbers.Name = "DataGridViewControl_AdNumbers"
            Me.DataGridViewControl_AdNumbers.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_AdNumbers.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_AdNumbers.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_AdNumbers.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_AdNumbers.Size = New System.Drawing.Size(502, 360)
            Me.DataGridViewControl_AdNumbers.TabIndex = 13
            Me.DataGridViewControl_AdNumbers.UseEmbeddedNavigator = False
            Me.DataGridViewControl_AdNumbers.ViewCaptionHeight = -1
            '
            'AdNumberControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewControl_AdNumbers)
            Me.Name = "AdNumberControl"
            Me.Size = New System.Drawing.Size(502, 360)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents DataGridViewControl_AdNumbers As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace
