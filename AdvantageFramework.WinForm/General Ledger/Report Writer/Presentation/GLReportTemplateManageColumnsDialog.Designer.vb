Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateManageColumnsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateManageColumnsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Columns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemAdd_AllMonths = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdd_AllQuarters = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemCopy_SelectedRow = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCopy_FromTemplate = New DevComponents.DotNetBar.ButtonItem()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(487, 285)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_Columns
            '
            Me.DataGridViewForm_Columns.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Columns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Columns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Columns.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Columns.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Columns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Columns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Columns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Columns.ItemDescription = "Column(s)"
            Me.DataGridViewForm_Columns.Location = New System.Drawing.Point(93, 12)
            Me.DataGridViewForm_Columns.MultiSelect = True
            Me.DataGridViewForm_Columns.Name = "DataGridViewForm_Columns"
            Me.DataGridViewForm_Columns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Columns.RunStandardValidation = True
            Me.DataGridViewForm_Columns.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Columns.Size = New System.Drawing.Size(469, 267)
            Me.DataGridViewForm_Columns.TabIndex = 0
            Me.DataGridViewForm_Columns.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Columns.ViewCaptionHeight = -1
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(93, 285)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.SplitButton = True
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAdd_AllMonths, Me.ButtonItemAdd_AllQuarters})
            Me.ButtonForm_Add.TabIndex = 3
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonItemAdd_AllMonths
            '
            Me.ButtonItemAdd_AllMonths.GlobalItem = False
            Me.ButtonItemAdd_AllMonths.Name = "ButtonItemAdd_AllMonths"
            Me.ButtonItemAdd_AllMonths.Text = "All Months"
            '
            'ButtonItemAdd_AllQuarters
            '
            Me.ButtonItemAdd_AllQuarters.GlobalItem = False
            Me.ButtonItemAdd_AllQuarters.Name = "ButtonItemAdd_AllQuarters"
            Me.ButtonItemAdd_AllQuarters.Text = "All Quarters"
            '
            'ButtonForm_Edit
            '
            Me.ButtonForm_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Edit.Location = New System.Drawing.Point(174, 285)
            Me.ButtonForm_Edit.Name = "ButtonForm_Edit"
            Me.ButtonForm_Edit.SecurityEnabled = True
            Me.ButtonForm_Edit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Edit.TabIndex = 4
            Me.ButtonForm_Edit.Text = "Edit"
            '
            'ButtonForm_Delete
            '
            Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Delete.Location = New System.Drawing.Point(255, 285)
            Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
            Me.ButtonForm_Delete.SecurityEnabled = True
            Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Delete.TabIndex = 5
            Me.ButtonForm_Delete.Text = "Delete"
            '
            'ButtonForm_MoveDown
            '
            Me.ButtonForm_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveDown.Location = New System.Drawing.Point(12, 84)
            Me.ButtonForm_MoveDown.Name = "ButtonForm_MoveDown"
            Me.ButtonForm_MoveDown.SecurityEnabled = True
            Me.ButtonForm_MoveDown.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveDown.TabIndex = 2
            Me.ButtonForm_MoveDown.Text = "Move Down"
            '
            'ButtonForm_MoveUp
            '
            Me.ButtonForm_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveUp.Location = New System.Drawing.Point(12, 58)
            Me.ButtonForm_MoveUp.Name = "ButtonForm_MoveUp"
            Me.ButtonForm_MoveUp.SecurityEnabled = True
            Me.ButtonForm_MoveUp.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveUp.TabIndex = 1
            Me.ButtonForm_MoveUp.Text = "Move Up"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.AutoExpandOnClick = True
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(336, 285)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCopy_SelectedRow, Me.ButtonItemCopy_FromTemplate})
            Me.ButtonForm_Copy.TabIndex = 6
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ButtonItemCopy_SelectedRow
            '
            Me.ButtonItemCopy_SelectedRow.GlobalItem = False
            Me.ButtonItemCopy_SelectedRow.Name = "ButtonItemCopy_SelectedRow"
            Me.ButtonItemCopy_SelectedRow.Text = "Selected Row"
            '
            'ButtonItemCopy_FromTemplate
            '
            Me.ButtonItemCopy_FromTemplate.GlobalItem = False
            Me.ButtonItemCopy_FromTemplate.Name = "ButtonItemCopy_FromTemplate"
            Me.ButtonItemCopy_FromTemplate.Text = "From Template"
            '
            'GLReportTemplateManageColumnsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(574, 317)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.ButtonForm_MoveDown)
            Me.Controls.Add(Me.ButtonForm_MoveUp)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.ButtonForm_Edit)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.DataGridViewForm_Columns)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateManageColumnsDialog"
            Me.Text = "Manage Columns"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Columns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemCopy_SelectedRow As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCopy_FromTemplate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAdd_AllMonths As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAdd_AllQuarters As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace