Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountsPayableDenyExpenseReportDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableDenyExpenseReportDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_ExpenseReports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(669, 415)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(750, 415)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_ExpenseReports
            '
            Me.DataGridViewForm_ExpenseReports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ExpenseReports.AllowDragAndDrop = False
            Me.DataGridViewForm_ExpenseReports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ExpenseReports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ExpenseReports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ExpenseReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ExpenseReports.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ExpenseReports.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ExpenseReports.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ExpenseReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ExpenseReports.DataSource = Nothing
            Me.DataGridViewForm_ExpenseReports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ExpenseReports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ExpenseReports.ItemDescription = ""
            Me.DataGridViewForm_ExpenseReports.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ExpenseReports.MultiSelect = True
            Me.DataGridViewForm_ExpenseReports.Name = "DataGridViewForm_ExpenseReports"
            Me.DataGridViewForm_ExpenseReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ExpenseReports.RunStandardValidation = True
            Me.DataGridViewForm_ExpenseReports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ExpenseReports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ExpenseReports.Size = New System.Drawing.Size(813, 397)
            Me.DataGridViewForm_ExpenseReports.TabIndex = 1
            Me.DataGridViewForm_ExpenseReports.TabStop = False
            Me.DataGridViewForm_ExpenseReports.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ExpenseReports.ViewCaptionHeight = -1
            '
            'AccountsPayableDenyExpenseReportDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(837, 447)
            Me.Controls.Add(Me.DataGridViewForm_ExpenseReports)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableDenyExpenseReportDialog"
            Me.Text = "AP Deny Expense Reports"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_ExpenseReports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace