Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GenericPropertyGridDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericPropertyGridDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PropertyGridForm_Item = New AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl()
            Me.PropertyDescriptionForm_PropertyDescription = New DevExpress.XtraVerticalGrid.PropertyDescriptionControl()
            Me.PanelForm_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_MiddleSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_BottomSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonForm_ShowOverrides = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.PropertyGridForm_Item, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_TopSection.SuspendLayout()
            CType(Me.PanelForm_MiddleSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_MiddleSection.SuspendLayout()
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_BottomSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(397, 0)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(478, 0)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'PropertyGridForm_Item
            '
            Me.PropertyGridForm_Item.AllowExtraItemsInGridLookupEdits = True
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
            Me.PropertyGridForm_Item.Size = New System.Drawing.Size(541, 267)
            Me.PropertyGridForm_Item.TabIndex = 2
            '
            'PropertyDescriptionForm_PropertyDescription
            '
            Me.PropertyDescriptionForm_PropertyDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PropertyDescriptionForm_PropertyDescription.Location = New System.Drawing.Point(12, 0)
            Me.PropertyDescriptionForm_PropertyDescription.Name = "PropertyDescriptionForm_PropertyDescription"
            Me.PropertyDescriptionForm_PropertyDescription.PropertyGrid = Me.PropertyGridForm_Item
            Me.PropertyDescriptionForm_PropertyDescription.Size = New System.Drawing.Size(541, 58)
            Me.PropertyDescriptionForm_PropertyDescription.TabIndex = 3
            Me.PropertyDescriptionForm_PropertyDescription.TabStop = False
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_TopSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_TopSection.Controls.Add(Me.PropertyGridForm_Item)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(565, 285)
            Me.PanelForm_TopSection.TabIndex = 4
            '
            'PanelForm_MiddleSection
            '
            Me.PanelForm_MiddleSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_MiddleSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_MiddleSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_MiddleSection.Controls.Add(Me.PropertyDescriptionForm_PropertyDescription)
            Me.PanelForm_MiddleSection.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelForm_MiddleSection.Location = New System.Drawing.Point(0, 285)
            Me.PanelForm_MiddleSection.Name = "PanelForm_MiddleSection"
            Me.PanelForm_MiddleSection.Size = New System.Drawing.Size(565, 64)
            Me.PanelForm_MiddleSection.TabIndex = 5
            '
            'PanelForm_BottomSection
            '
            Me.PanelForm_BottomSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_BottomSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_BottomSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_BottomSection.Controls.Add(Me.ButtonForm_ShowOverrides)
            Me.PanelForm_BottomSection.Controls.Add(Me.ButtonForm_OK)
            Me.PanelForm_BottomSection.Controls.Add(Me.ButtonForm_Cancel)
            Me.PanelForm_BottomSection.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelForm_BottomSection.Location = New System.Drawing.Point(0, 349)
            Me.PanelForm_BottomSection.Name = "PanelForm_BottomSection"
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(565, 32)
            Me.PanelForm_BottomSection.TabIndex = 6
            '
            'ButtonForm_ShowOverrides
            '
            Me.ButtonForm_ShowOverrides.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ShowOverrides.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ShowOverrides.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ShowOverrides.Location = New System.Drawing.Point(12, 0)
            Me.ButtonForm_ShowOverrides.Name = "ButtonForm_ShowOverrides"
            Me.ButtonForm_ShowOverrides.SecurityEnabled = True
            Me.ButtonForm_ShowOverrides.Size = New System.Drawing.Size(86, 20)
            Me.ButtonForm_ShowOverrides.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ShowOverrides.TabIndex = 3
            Me.ButtonForm_ShowOverrides.Text = "Show Overrides"
            '
            'GenericPropertyGridDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(565, 381)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Controls.Add(Me.PanelForm_MiddleSection)
            Me.Controls.Add(Me.PanelForm_BottomSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GenericPropertyGridDialog"
            Me.Text = "Property Dialog"
            CType(Me.PropertyGridForm_Item, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_TopSection.ResumeLayout(False)
            CType(Me.PanelForm_MiddleSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_MiddleSection.ResumeLayout(False)
            CType(Me.PanelForm_BottomSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_BottomSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PropertyGridForm_Item As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl
        Friend WithEvents PropertyDescriptionForm_PropertyDescription As DevExpress.XtraVerticalGrid.PropertyDescriptionControl
        Friend WithEvents PanelForm_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_MiddleSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_BottomSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_ShowOverrides As Controls.Button
    End Class

End Namespace