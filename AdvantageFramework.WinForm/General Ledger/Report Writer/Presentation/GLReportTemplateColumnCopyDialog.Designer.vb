Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateColumnCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateColumnCopyDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_GLReportTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_GLReportTemplateColumns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(631, 499)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_GLReportTemplates
            '
            Me.DataGridViewForm_GLReportTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_GLReportTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_GLReportTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_GLReportTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_GLReportTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_GLReportTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_GLReportTemplates.DataSource = Nothing
            Me.DataGridViewForm_GLReportTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_GLReportTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_GLReportTemplates.ItemDescription = ""
            Me.DataGridViewForm_GLReportTemplates.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_GLReportTemplates.MultiSelect = False
            Me.DataGridViewForm_GLReportTemplates.Name = "DataGridViewForm_GLReportTemplates"
            Me.DataGridViewForm_GLReportTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_GLReportTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_GLReportTemplates.Size = New System.Drawing.Size(423, 481)
            Me.DataGridViewForm_GLReportTemplates.TabIndex = 0
            Me.DataGridViewForm_GLReportTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_GLReportTemplates.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(712, 499)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_GLReportTemplateColumns
            '
            Me.DataGridViewForm_GLReportTemplateColumns.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_GLReportTemplateColumns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_GLReportTemplateColumns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_GLReportTemplateColumns.AutoFilterLookupColumns = False
            Me.DataGridViewForm_GLReportTemplateColumns.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_GLReportTemplateColumns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_GLReportTemplateColumns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_GLReportTemplateColumns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_GLReportTemplateColumns.ItemDescription = ""
            Me.DataGridViewForm_GLReportTemplateColumns.Location = New System.Drawing.Point(441, 12)
            Me.DataGridViewForm_GLReportTemplateColumns.MultiSelect = True
            Me.DataGridViewForm_GLReportTemplateColumns.Name = "DataGridViewForm_GLReportTemplateColumns"
            Me.DataGridViewForm_GLReportTemplateColumns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_GLReportTemplateColumns.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_GLReportTemplateColumns.Size = New System.Drawing.Size(346, 481)
            Me.DataGridViewForm_GLReportTemplateColumns.TabIndex = 1
            Me.DataGridViewForm_GLReportTemplateColumns.UseEmbeddedNavigator = False
            Me.DataGridViewForm_GLReportTemplateColumns.ViewCaptionHeight = -1
            '
            'GLReportTemplateColumnCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 531)
            Me.Controls.Add(Me.DataGridViewForm_GLReportTemplateColumns)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_GLReportTemplates)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateColumnCopyDialog"
            Me.Text = "Copy Template Columns"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_GLReportTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_GLReportTemplateColumns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace