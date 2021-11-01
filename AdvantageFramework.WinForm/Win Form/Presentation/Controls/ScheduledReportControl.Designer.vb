Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ScheduledReportControl
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
            Me.DataGridViewForm_ScheduledReports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewForm_ScheduledReports
            '
            Me.DataGridViewForm_ScheduledReports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ScheduledReports.AllowDragAndDrop = False
            Me.DataGridViewForm_ScheduledReports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ScheduledReports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ScheduledReports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ScheduledReports.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ScheduledReports.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ScheduledReports.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ScheduledReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ScheduledReports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ScheduledReports.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_ScheduledReports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ScheduledReports.ItemDescription = "Scheduled Report(s)"
            Me.DataGridViewForm_ScheduledReports.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_ScheduledReports.MultiSelect = True
            Me.DataGridViewForm_ScheduledReports.Name = "DataGridViewForm_ScheduledReports"
            Me.DataGridViewForm_ScheduledReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ScheduledReports.RunStandardValidation = True
            Me.DataGridViewForm_ScheduledReports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ScheduledReports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ScheduledReports.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewForm_ScheduledReports.TabIndex = 2
            Me.DataGridViewForm_ScheduledReports.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ScheduledReports.ViewCaptionHeight = -1
            '
            'ScheduledReportControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_ScheduledReports)
            Me.Name = "ScheduledReportControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ScheduledReports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
