Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateManageRowsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateManageRowsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Rows = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemCopy_SelectedRow = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemCopy_FromTemplate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonForm_Print = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemPrint_Selected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPrint_All = New DevComponents.DotNetBar.ButtonItem()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(527, 285)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_Rows
            '
            Me.DataGridViewForm_Rows.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Rows.AllowDragAndDrop = False
            Me.DataGridViewForm_Rows.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Rows.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Rows.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Rows.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Rows.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Rows.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Rows.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Rows.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Rows.DataSource = Nothing
            Me.DataGridViewForm_Rows.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Rows.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Rows.ItemDescription = "Column(s)"
            Me.DataGridViewForm_Rows.Location = New System.Drawing.Point(93, 12)
            Me.DataGridViewForm_Rows.MultiSelect = True
            Me.DataGridViewForm_Rows.Name = "DataGridViewForm_Rows"
            Me.DataGridViewForm_Rows.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Rows.RunStandardValidation = True
            Me.DataGridViewForm_Rows.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Rows.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Rows.Size = New System.Drawing.Size(509, 267)
            Me.DataGridViewForm_Rows.TabIndex = 0
            Me.DataGridViewForm_Rows.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Rows.ViewCaptionHeight = -1
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
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 3
            Me.ButtonForm_Add.Text = "Add"
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
            Me.ButtonForm_MoveDown.Location = New System.Drawing.Point(12, 85)
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
            Me.ButtonForm_MoveUp.Location = New System.Drawing.Point(12, 59)
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
            'ButtonForm_Print
            '
            Me.ButtonForm_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Print.AutoExpandOnClick = True
            Me.ButtonForm_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Print.Location = New System.Drawing.Point(417, 285)
            Me.ButtonForm_Print.Name = "ButtonForm_Print"
            Me.ButtonForm_Print.SecurityEnabled = True
            Me.ButtonForm_Print.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Print.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_Selected, Me.ButtonItemPrint_All})
            Me.ButtonForm_Print.TabIndex = 8
            Me.ButtonForm_Print.Text = "Print"
            '
            'ButtonItemPrint_Selected
            '
            Me.ButtonItemPrint_Selected.GlobalItem = False
            Me.ButtonItemPrint_Selected.Name = "ButtonItemPrint_Selected"
            Me.ButtonItemPrint_Selected.Text = "Print Selected Row(s)"
            '
            'ButtonItemPrint_All
            '
            Me.ButtonItemPrint_All.GlobalItem = False
            Me.ButtonItemPrint_All.Name = "ButtonItemPrint_All"
            Me.ButtonItemPrint_All.Text = "Print All"
            '
            'GLReportTemplateManageRowsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(614, 317)
            Me.Controls.Add(Me.ButtonForm_Print)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.ButtonForm_MoveDown)
            Me.Controls.Add(Me.ButtonForm_MoveUp)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.ButtonForm_Edit)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.DataGridViewForm_Rows)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplateManageRowsDialog"
            Me.Text = "Manage Rows"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Rows As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemCopy_SelectedRow As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemCopy_FromTemplate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonForm_Print As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemPrint_Selected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPrint_All As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace