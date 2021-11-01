Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentManagerControl
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
            Me.components = New System.ComponentModel.Container()
            Me.DataGridViewForm_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WebBrowserForm_Print = New System.Windows.Forms.WebBrowser()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Documents
            '
            Me.DataGridViewForm_Documents.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Documents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Documents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Documents.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Documents.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Documents.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Documents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Documents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_Documents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Documents.ItemDescription = "Document(s)"
            Me.DataGridViewForm_Documents.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_Documents.MultiSelect = True
            Me.DataGridViewForm_Documents.Name = "DataGridViewForm_Documents"
            Me.DataGridViewForm_Documents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Documents.RunStandardValidation = True
            Me.DataGridViewForm_Documents.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Documents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Documents.Size = New System.Drawing.Size(603, 341)
            Me.DataGridViewForm_Documents.TabIndex = 2
            Me.DataGridViewForm_Documents.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Documents.ViewCaptionHeight = -1
            '
            'WebBrowserForm_Print
            '
            Me.WebBrowserForm_Print.Location = New System.Drawing.Point(149, 187)
            Me.WebBrowserForm_Print.MinimumSize = New System.Drawing.Size(20, 20)
            Me.WebBrowserForm_Print.Name = "WebBrowserForm_Print"
            Me.WebBrowserForm_Print.Size = New System.Drawing.Size(109, 93)
            Me.WebBrowserForm_Print.TabIndex = 3
            Me.WebBrowserForm_Print.Visible = False
            '
            'DocumentManagerControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_Documents)
            Me.Controls.Add(Me.WebBrowserForm_Print)
            Me.Name = "DocumentManagerControl"
            Me.Size = New System.Drawing.Size(603, 341)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Documents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WebBrowserForm_Print As System.Windows.Forms.WebBrowser

    End Class

End Namespace
