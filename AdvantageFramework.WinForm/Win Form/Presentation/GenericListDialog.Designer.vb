Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GenericListDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericListDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RadTreeViewForm_List = New Telerik.WinControls.UI.RadTreeView()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RadTreeViewForm_List, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(255, 362)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Select
            '
            Me.ButtonForm_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Select.Location = New System.Drawing.Point(174, 362)
            Me.ButtonForm_Select.Name = "ButtonForm_Select"
            Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Select.TabIndex = 4
            Me.ButtonForm_Select.Text = "Select"
            '
            'RadTreeViewForm_List
            '
            Me.RadTreeViewForm_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadTreeViewForm_List.CheckBoxes = True
            Me.RadTreeViewForm_List.Location = New System.Drawing.Point(12, 12)
            Me.RadTreeViewForm_List.Name = "RadTreeViewForm_List"
            Me.RadTreeViewForm_List.ShowLines = True
            Me.RadTreeViewForm_List.Size = New System.Drawing.Size(318, 344)
            Me.RadTreeViewForm_List.SpacingBetweenNodes = -1
            Me.RadTreeViewForm_List.TabIndex = 6
            '
            'GenericListDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(342, 394)
            Me.Controls.Add(Me.RadTreeViewForm_List)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Select)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GenericListDialog"
            Me.Text = "Generic List"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RadTreeViewForm_List, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadTreeViewForm_List As Telerik.WinControls.UI.RadTreeView
    End Class

End Namespace