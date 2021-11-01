Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DynamicReportColumnEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DynamicReportColumnEditDialog))
            Me.DataGridViewForm_DynamicReportColumns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_ShowOnlyVisibleColumns = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_Reset = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_DeselectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'DataGridViewForm_DynamicReportColumns
            '
            Me.DataGridViewForm_DynamicReportColumns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_DynamicReportColumns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_DynamicReportColumns.DataSource = Nothing
            Me.DataGridViewForm_DynamicReportColumns.ItemDescription = "Item(s)"
            Me.DataGridViewForm_DynamicReportColumns.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_DynamicReportColumns.MultiSelect = True
            Me.DataGridViewForm_DynamicReportColumns.Name = "DataGridViewForm_DynamicReportColumns"
            Me.DataGridViewForm_DynamicReportColumns.Size = New System.Drawing.Size(748, 359)
            Me.DataGridViewForm_DynamicReportColumns.TabIndex = 0
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(604, 377)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 5
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(685, 377)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_ShowOnlyVisibleColumns
            '
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ShowOnlyVisibleColumns.BackgroundStyle.Class = ""
            Me.CheckBoxForm_ShowOnlyVisibleColumns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Location = New System.Drawing.Point(365, 377)
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Name = "CheckBoxForm_ShowOnlyVisibleColumns"
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowOnlyVisibleColumns.TabIndex = 6
            Me.CheckBoxForm_ShowOnlyVisibleColumns.Text = "Show Only Visible Columns"
            '
            'ButtonForm_Reset
            '
            Me.ButtonForm_Reset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Reset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Reset.Location = New System.Drawing.Point(523, 377)
            Me.ButtonForm_Reset.Name = "ButtonForm_Reset"
            Me.ButtonForm_Reset.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Reset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Reset.TabIndex = 7
            Me.ButtonForm_Reset.Text = "Reset"
            '
            'ButtonForm_SelectAll
            '
            Me.ButtonForm_SelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectAll.Location = New System.Drawing.Point(12, 377)
            Me.ButtonForm_SelectAll.Name = "ButtonForm_SelectAll"
            Me.ButtonForm_SelectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectAll.TabIndex = 8
            Me.ButtonForm_SelectAll.Text = "Select All"
            '
            'ButtonForm_DeselectAll
            '
            Me.ButtonForm_DeselectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_DeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_DeselectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_DeselectAll.Location = New System.Drawing.Point(93, 377)
            Me.ButtonForm_DeselectAll.Name = "ButtonForm_DeselectAll"
            Me.ButtonForm_DeselectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_DeselectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_DeselectAll.TabIndex = 9
            Me.ButtonForm_DeselectAll.Text = "Deselect All"
            '
            'DynamicReportColumnEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(772, 409)
            Me.Controls.Add(Me.ButtonForm_DeselectAll)
            Me.Controls.Add(Me.ButtonForm_SelectAll)
            Me.Controls.Add(Me.ButtonForm_Reset)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.CheckBoxForm_ShowOnlyVisibleColumns)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.DataGridViewForm_DynamicReportColumns)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DynamicReportColumnEditDialog"
            Me.Text = "Report Column Edit"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_DynamicReportColumns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_ShowOnlyVisibleColumns As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonForm_Reset As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_DeselectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace