Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExportAutoFillDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportAutoFillDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PropertyGridControlForm_Properties = New AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl()
            Me.ButtonForm_SelectFirst = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectPrevious = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectNext = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SelectLast = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RadioButtonControlForm_FromBlank = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_UpdateFromSelected = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.PropertyGridControlForm_Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(564, 362)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(483, 362)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 1
            Me.ButtonForm_Update.Text = "Update"
            '
            'PropertyGridControlForm_Properties
            '
            Me.PropertyGridControlForm_Properties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PropertyGridControlForm_Properties.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.Empty.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.FixedLine.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.FocusedCell.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.FocusedRow.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.HideSelectionRow.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.HorzLine.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlForm_Properties.Appearance.VertLine.Options.UseFont = True
            Me.PropertyGridControlForm_Properties.AutoFilterLookupColumns = False
            Me.PropertyGridControlForm_Properties.AutoloadRepositoryDatasource = True
            Me.PropertyGridControlForm_Properties.ControlType = AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.ExportTemplate
            Me.PropertyGridControlForm_Properties.Location = New System.Drawing.Point(12, 38)
            Me.PropertyGridControlForm_Properties.Name = "PropertyGridControlForm_Properties"
            Me.PropertyGridControlForm_Properties.ObjectType = Nothing
            Me.PropertyGridControlForm_Properties.Size = New System.Drawing.Size(627, 318)
            Me.PropertyGridControlForm_Properties.TabIndex = 3
            '
            'ButtonForm_SelectFirst
            '
            Me.ButtonForm_SelectFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectFirst.Location = New System.Drawing.Point(12, 362)
            Me.ButtonForm_SelectFirst.Name = "ButtonForm_SelectFirst"
            Me.ButtonForm_SelectFirst.SecurityEnabled = True
            Me.ButtonForm_SelectFirst.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectFirst.TabIndex = 4
            Me.ButtonForm_SelectFirst.Text = "First"
            '
            'ButtonForm_SelectPrevious
            '
            Me.ButtonForm_SelectPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectPrevious.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectPrevious.Location = New System.Drawing.Point(93, 362)
            Me.ButtonForm_SelectPrevious.Name = "ButtonForm_SelectPrevious"
            Me.ButtonForm_SelectPrevious.SecurityEnabled = True
            Me.ButtonForm_SelectPrevious.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectPrevious.TabIndex = 5
            Me.ButtonForm_SelectPrevious.Text = "Previous"
            '
            'ButtonForm_SelectNext
            '
            Me.ButtonForm_SelectNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectNext.Location = New System.Drawing.Point(174, 362)
            Me.ButtonForm_SelectNext.Name = "ButtonForm_SelectNext"
            Me.ButtonForm_SelectNext.SecurityEnabled = True
            Me.ButtonForm_SelectNext.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectNext.TabIndex = 6
            Me.ButtonForm_SelectNext.Text = "Next"
            '
            'ButtonForm_SelectLast
            '
            Me.ButtonForm_SelectLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SelectLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SelectLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SelectLast.Location = New System.Drawing.Point(255, 362)
            Me.ButtonForm_SelectLast.Name = "ButtonForm_SelectLast"
            Me.ButtonForm_SelectLast.SecurityEnabled = True
            Me.ButtonForm_SelectLast.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SelectLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SelectLast.TabIndex = 7
            Me.ButtonForm_SelectLast.Text = "Last"
            '
            'RadioButtonControlForm_FromBlank
            '
            Me.RadioButtonControlForm_FromBlank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_FromBlank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_FromBlank.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_FromBlank.Checked = True
            Me.RadioButtonControlForm_FromBlank.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlForm_FromBlank.CheckValue = "Y"
            Me.RadioButtonControlForm_FromBlank.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonControlForm_FromBlank.Name = "RadioButtonControlForm_FromBlank"
            Me.RadioButtonControlForm_FromBlank.SecurityEnabled = True
            Me.RadioButtonControlForm_FromBlank.Size = New System.Drawing.Size(110, 20)
            Me.RadioButtonControlForm_FromBlank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_FromBlank.TabIndex = 8
            Me.RadioButtonControlForm_FromBlank.Text = "Update from New"
            '
            'RadioButtonControlForm_UpdateFromSelected
            '
            Me.RadioButtonControlForm_UpdateFromSelected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_UpdateFromSelected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_UpdateFromSelected.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_UpdateFromSelected.Location = New System.Drawing.Point(128, 12)
            Me.RadioButtonControlForm_UpdateFromSelected.Name = "RadioButtonControlForm_UpdateFromSelected"
            Me.RadioButtonControlForm_UpdateFromSelected.SecurityEnabled = True
            Me.RadioButtonControlForm_UpdateFromSelected.Size = New System.Drawing.Size(511, 20)
            Me.RadioButtonControlForm_UpdateFromSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_UpdateFromSelected.TabIndex = 9
            Me.RadioButtonControlForm_UpdateFromSelected.TabStop = False
            Me.RadioButtonControlForm_UpdateFromSelected.Text = "Update from Selected"
            '
            'ExportAutoFillDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(651, 394)
            Me.Controls.Add(Me.RadioButtonControlForm_UpdateFromSelected)
            Me.Controls.Add(Me.RadioButtonControlForm_FromBlank)
            Me.Controls.Add(Me.PropertyGridControlForm_Properties)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_SelectLast)
            Me.Controls.Add(Me.ButtonForm_SelectNext)
            Me.Controls.Add(Me.ButtonForm_SelectPrevious)
            Me.Controls.Add(Me.ButtonForm_SelectFirst)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportAutoFillDialog"
            Me.Text = "Export Auto Fill"
            CType(Me.PropertyGridControlForm_Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PropertyGridControlForm_Properties As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl
        Friend WithEvents ButtonForm_SelectFirst As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectPrevious As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectNext As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SelectLast As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonControlForm_FromBlank As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_UpdateFromSelected As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace