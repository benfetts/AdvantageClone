Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExportInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PropertyGridForm_Item = New AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.PropertyGridForm_Item, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(209, 349)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'PropertyGridForm_Item
            '
            Me.PropertyGridForm_Item.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PropertyGridForm_Item.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.Empty.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.FixedLine.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.FocusedCell.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.FocusedRow.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.HideSelectionRow.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.HorzLine.Options.UseFont = True
            Me.PropertyGridForm_Item.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridForm_Item.Appearance.VertLine.Options.UseFont = True
            Me.PropertyGridForm_Item.AutoFilterLookupColumns = True
            Me.PropertyGridForm_Item.AutoloadRepositoryDatasource = True
            Me.PropertyGridForm_Item.ControlType = AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.Editable
            Me.PropertyGridForm_Item.Location = New System.Drawing.Point(12, 12)
            Me.PropertyGridForm_Item.Name = "PropertyGridForm_Item"
            Me.PropertyGridForm_Item.ObjectType = Nothing
            Me.PropertyGridForm_Item.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort
            Me.PropertyGridForm_Item.OptionsBehavior.UseEnterAsTab = True
            Me.PropertyGridForm_Item.OptionsView.ShowRootCategories = False
            Me.PropertyGridForm_Item.Size = New System.Drawing.Size(353, 331)
            Me.PropertyGridForm_Item.TabIndex = 2
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(290, 349)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ExportInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(377, 381)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.PropertyGridForm_Item)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportInitialLoadingDialog"
            Me.Text = "Initial Loading"
            CType(Me.PropertyGridForm_Item, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PropertyGridForm_Item As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace