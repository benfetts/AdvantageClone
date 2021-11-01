Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingBatchChooserControl
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
            Me.components = New System.ComponentModel.Container()
            Me.DataGridViewControl_BillingBatches = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllBillingBatches = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_SingleBillingBatch = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_BillingBatches
            '
            Me.DataGridViewControl_BillingBatches.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_BillingBatches.AllowDragAndDrop = False
            Me.DataGridViewControl_BillingBatches.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_BillingBatches.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_BillingBatches.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_BillingBatches.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_BillingBatches.AutoFilterLookupColumns = False
            Me.DataGridViewControl_BillingBatches.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_BillingBatches.AutoUpdateViewCaption = True
            Me.DataGridViewControl_BillingBatches.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_BillingBatches.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_BillingBatches.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_BillingBatches.ItemDescription = "Batch(es)"
            Me.DataGridViewControl_BillingBatches.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewControl_BillingBatches.MultiSelect = False
            Me.DataGridViewControl_BillingBatches.Name = "DataGridViewControl_BillingBatches"
            Me.DataGridViewControl_BillingBatches.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_BillingBatches.RunStandardValidation = True
            Me.DataGridViewControl_BillingBatches.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_BillingBatches.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_BillingBatches.Size = New System.Drawing.Size(571, 356)
            Me.DataGridViewControl_BillingBatches.TabIndex = 15
            Me.DataGridViewControl_BillingBatches.UseEmbeddedNavigator = False
            Me.DataGridViewControl_BillingBatches.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllBillingBatches
            '
            Me.RadioButtonControl_AllBillingBatches.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllBillingBatches.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllBillingBatches.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllBillingBatches.Checked = True
            Me.RadioButtonControl_AllBillingBatches.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllBillingBatches.CheckValue = "Y"
            Me.RadioButtonControl_AllBillingBatches.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllBillingBatches.Name = "RadioButtonControl_AllBillingBatches"
            Me.RadioButtonControl_AllBillingBatches.SecurityEnabled = True
            Me.RadioButtonControl_AllBillingBatches.Size = New System.Drawing.Size(121, 20)
            Me.RadioButtonControl_AllBillingBatches.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllBillingBatches.TabIndex = 16
            Me.RadioButtonControl_AllBillingBatches.TabOnEnter = True
            Me.RadioButtonControl_AllBillingBatches.Text = "All Billing Batches"
            '
            'RadioButtonControl_SingleBillingBatch
            '
            Me.RadioButtonControl_SingleBillingBatch.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_SingleBillingBatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_SingleBillingBatch.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_SingleBillingBatch.Location = New System.Drawing.Point(127, 0)
            Me.RadioButtonControl_SingleBillingBatch.Name = "RadioButtonControl_SingleBillingBatch"
            Me.RadioButtonControl_SingleBillingBatch.SecurityEnabled = True
            Me.RadioButtonControl_SingleBillingBatch.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_SingleBillingBatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_SingleBillingBatch.TabIndex = 17
            Me.RadioButtonControl_SingleBillingBatch.TabOnEnter = True
            Me.RadioButtonControl_SingleBillingBatch.TabStop = False
            Me.RadioButtonControl_SingleBillingBatch.Text = "Single Billing Batch"
            '
            'BillingBatchChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioButtonControl_AllBillingBatches)
            Me.Controls.Add(Me.RadioButtonControl_SingleBillingBatch)
            Me.Controls.Add(Me.DataGridViewControl_BillingBatches)
            Me.Name = "BillingBatchChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_BillingBatches As DataGridView
        Friend WithEvents RadioButtonControl_AllBillingBatches As RadioButtonControl
        Friend WithEvents RadioButtonControl_SingleBillingBatch As RadioButtonControl
    End Class

End Namespace