Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CopyOfficeFunctionGLAccountsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopyOfficeFunctionGLAccountsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_CopyUsingOffice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewFunctionGLAccounts_GLAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxForm_ReplaceOfficeSegment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(570, 419)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_CopyUsingOffice
            '
            Me.LabelForm_CopyUsingOffice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CopyUsingOffice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CopyUsingOffice.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_CopyUsingOffice.Name = "LabelForm_CopyUsingOffice"
            Me.LabelForm_CopyUsingOffice.Size = New System.Drawing.Size(130, 20)
            Me.LabelForm_CopyUsingOffice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CopyUsingOffice.TabIndex = 0
            Me.LabelForm_CopyUsingOffice.Text = "Copy Using Office:"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(489, 419)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 4
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ClientCode = ""
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DivisionCode = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(148, 12)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.SecurityEnabled = True
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(277, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 1
            Me.ComboBoxForm_Office.TabOnEnter = True
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
            '
            'DataGridViewFunctionGLAccounts_GLAccounts
            '
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AllowDragAndDrop = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewFunctionGLAccounts_GLAccounts.DataSource = Nothing
            Me.DataGridViewFunctionGLAccounts_GLAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewFunctionGLAccounts_GLAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewFunctionGLAccounts_GLAccounts.ItemDescription = ""
            Me.DataGridViewFunctionGLAccounts_GLAccounts.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewFunctionGLAccounts_GLAccounts.MultiSelect = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.Name = "DataGridViewFunctionGLAccounts_GLAccounts"
            Me.DataGridViewFunctionGLAccounts_GLAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewFunctionGLAccounts_GLAccounts.RunStandardValidation = True
            Me.DataGridViewFunctionGLAccounts_GLAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.Size = New System.Drawing.Size(623, 375)
            Me.DataGridViewFunctionGLAccounts_GLAccounts.TabIndex = 2
            Me.DataGridViewFunctionGLAccounts_GLAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewFunctionGLAccounts_GLAccounts.ViewCaptionHeight = -1
            '
            'CheckBoxForm_ReplaceOfficeSegment
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValue = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueChecked = 1
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueUnchecked = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.ChildControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ReplaceOfficeSegment.Location = New System.Drawing.Point(12, 419)
            Me.CheckBoxForm_ReplaceOfficeSegment.Name = "CheckBoxForm_ReplaceOfficeSegment"
            Me.CheckBoxForm_ReplaceOfficeSegment.OldestSibling = Nothing
            Me.CheckBoxForm_ReplaceOfficeSegment.SecurityEnabled = True
            Me.CheckBoxForm_ReplaceOfficeSegment.SiblingControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxForm_ReplaceOfficeSegment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ReplaceOfficeSegment.TabIndex = 3
            Me.CheckBoxForm_ReplaceOfficeSegment.TabOnEnter = True
            Me.CheckBoxForm_ReplaceOfficeSegment.Text = "Replace Office Segment in GL Accounts"
            '
            'CopyOfficeFunctionGLAccountsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(657, 451)
            Me.Controls.Add(Me.DataGridViewFunctionGLAccounts_GLAccounts)
            Me.Controls.Add(Me.CheckBoxForm_ReplaceOfficeSegment)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.LabelForm_CopyUsingOffice)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CopyOfficeFunctionGLAccountsDialog"
            Me.Text = "Office - Copy Function GL Accounts"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_CopyUsingOffice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewFunctionGLAccounts_GLAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxForm_ReplaceOfficeSegment As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace