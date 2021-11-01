Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ProductMediaOverrideControl
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
            Me.DataGridViewForm_ProductMediaOverrides = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewForm_ProductMediaOverrides
            '
            Me.DataGridViewForm_ProductMediaOverrides.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ProductMediaOverrides.AllowDragAndDrop = False
            Me.DataGridViewForm_ProductMediaOverrides.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ProductMediaOverrides.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ProductMediaOverrides.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ProductMediaOverrides.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ProductMediaOverrides.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ProductMediaOverrides.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ProductMediaOverrides.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ProductMediaOverrides.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ProductMediaOverrides.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_ProductMediaOverrides.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ProductMediaOverrides.ItemDescription = "Override(s)"
            Me.DataGridViewForm_ProductMediaOverrides.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_ProductMediaOverrides.MultiSelect = True
            Me.DataGridViewForm_ProductMediaOverrides.Name = "DataGridViewForm_ProductMediaOverrides"
            Me.DataGridViewForm_ProductMediaOverrides.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_ProductMediaOverrides.RunStandardValidation = True
            Me.DataGridViewForm_ProductMediaOverrides.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ProductMediaOverrides.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ProductMediaOverrides.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewForm_ProductMediaOverrides.TabIndex = 6
            Me.DataGridViewForm_ProductMediaOverrides.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ProductMediaOverrides.ViewCaptionHeight = -1
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Export.AllowDragAndDrop = False
            Me.DataGridViewForm_Export.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Export.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = "Override(s)"
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(0, 191)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(172, 150)
            Me.DataGridViewForm_Export.TabIndex = 7
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'ProductMediaOverrideControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_Export)
            Me.Controls.Add(Me.DataGridViewForm_ProductMediaOverrides)
            Me.Name = "ProductMediaOverrideControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents DataGridViewForm_ProductMediaOverrides As DataGridView
        Friend WithEvents DataGridViewForm_Export As DataGridView
    End Class

End Namespace
