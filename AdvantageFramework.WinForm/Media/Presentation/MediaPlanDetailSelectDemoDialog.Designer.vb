Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanDetailSelectDemoDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailSelectDemoDialog))
            Me.DataGridViewForm_Demos = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Clear = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Demos
            '
            Me.DataGridViewForm_Demos.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Demos.AllowDragAndDrop = False
            Me.DataGridViewForm_Demos.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Demos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Demos.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Demos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Demos.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Demos.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Demos.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Demos.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Demos.DataSource = Nothing
            Me.DataGridViewForm_Demos.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Demos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Demos.ItemDescription = "Demo(s)"
            Me.DataGridViewForm_Demos.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Demos.MultiSelect = True
            Me.DataGridViewForm_Demos.Name = "DataGridViewForm_Demos"
            Me.DataGridViewForm_Demos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Demos.RunStandardValidation = True
            Me.DataGridViewForm_Demos.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Demos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Demos.Size = New System.Drawing.Size(282, 349)
            Me.DataGridViewForm_Demos.TabIndex = 0
            Me.DataGridViewForm_Demos.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Demos.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(219, 367)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Select
            '
            Me.ButtonForm_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Select.Location = New System.Drawing.Point(57, 367)
            Me.ButtonForm_Select.Name = "ButtonForm_Select"
            Me.ButtonForm_Select.SecurityEnabled = True
            Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Select.TabIndex = 1
            Me.ButtonForm_Select.Text = "Select"
            '
            'ButtonForm_Clear
            '
            Me.ButtonForm_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Clear.Location = New System.Drawing.Point(138, 367)
            Me.ButtonForm_Clear.Name = "ButtonForm_Clear"
            Me.ButtonForm_Clear.SecurityEnabled = True
            Me.ButtonForm_Clear.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Clear.TabIndex = 2
            Me.ButtonForm_Clear.Text = "Clear"
            '
            'MediaPlanDetailSelectDemoDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(306, 399)
            Me.Controls.Add(Me.ButtonForm_Clear)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Select)
            Me.Controls.Add(Me.DataGridViewForm_Demos)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailSelectDemoDialog"
            Me.Text = "Select Demo"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Demos As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Clear As WinForm.Presentation.Controls.Button
    End Class

End Namespace
