Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailLevelLineTagEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelLineTagEditDialog))
            Me.DataGridViewForm_Tags = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RadioButtonForm_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_ByValue = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Tags
            '
            Me.DataGridViewForm_Tags.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Tags.AllowDragAndDrop = False
            Me.DataGridViewForm_Tags.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Tags.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Tags.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Tags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Tags.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Tags.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Tags.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Tags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Tags.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Tags.Enabled = False
            Me.DataGridViewForm_Tags.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Tags.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Tags.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_Tags.MultiSelect = False
            Me.DataGridViewForm_Tags.Name = "DataGridViewForm_Tags"
            Me.DataGridViewForm_Tags.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Tags.RunStandardValidation = True
            Me.DataGridViewForm_Tags.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Tags.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Tags.Size = New System.Drawing.Size(520, 349)
            Me.DataGridViewForm_Tags.TabIndex = 2
            Me.DataGridViewForm_Tags.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Tags.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(457, 419)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(376, 419)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 4
            Me.ButtonForm_OK.Text = "OK"
            '
            'RadioButtonForm_None
            '
            Me.RadioButtonForm_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_None.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonForm_None.Name = "RadioButtonForm_None"
            Me.RadioButtonForm_None.SecurityEnabled = True
            Me.RadioButtonForm_None.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonForm_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_None.TabIndex = 0
            Me.RadioButtonForm_None.TabOnEnter = True
            Me.RadioButtonForm_None.TabStop = False
            Me.RadioButtonForm_None.Text = "None"
            '
            'RadioButtonForm_ByValue
            '
            Me.RadioButtonForm_ByValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_ByValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_ByValue.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_ByValue.Checked = True
            Me.RadioButtonForm_ByValue.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_ByValue.CheckValue = "Y"
            Me.RadioButtonForm_ByValue.Location = New System.Drawing.Point(12, 38)
            Me.RadioButtonForm_ByValue.Name = "RadioButtonForm_ByValue"
            Me.RadioButtonForm_ByValue.SecurityEnabled = True
            Me.RadioButtonForm_ByValue.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonForm_ByValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_ByValue.TabIndex = 1
            Me.RadioButtonForm_ByValue.TabOnEnter = True
            Me.RadioButtonForm_ByValue.Text = "By Value"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(12, 419)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 6
            Me.ButtonForm_Add.Text = "Add"
            '
            'MediaPlanDetailLevelLineTagEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(544, 451)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.RadioButtonForm_ByValue)
            Me.Controls.Add(Me.RadioButtonForm_None)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_Tags)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailLevelLineTagEditDialog"
            Me.Text = "Set Detail Level Line Tag"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Tags As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonForm_None As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_ByValue As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonForm_Add As WinForm.Presentation.Controls.Button
    End Class

End Namespace