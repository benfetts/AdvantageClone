Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobSpecificationTemplateEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobSpecificationTemplateEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_UseQuantitiesTab = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_UseVendorTab = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_UseVendorTab = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(289, 90)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 8
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(370, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_UseQuantitiesTab
            '
            Me.CheckBoxForm_UseQuantitiesTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_UseQuantitiesTab.BackgroundStyle.Class = ""
            Me.CheckBoxForm_UseQuantitiesTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseQuantitiesTab.CheckValue = 0
            Me.CheckBoxForm_UseQuantitiesTab.CheckValueChecked = 1
            Me.CheckBoxForm_UseQuantitiesTab.CheckValueUnchecked = 0
            Me.CheckBoxForm_UseQuantitiesTab.ChildControls = CType(resources.GetObject("CheckBoxForm_UseQuantitiesTab.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseQuantitiesTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UseQuantitiesTab.Location = New System.Drawing.Point(322, 64)
            Me.CheckBoxForm_UseQuantitiesTab.Name = "CheckBoxForm_UseQuantitiesTab"
            Me.CheckBoxForm_UseQuantitiesTab.OldestSibling = Nothing
            Me.CheckBoxForm_UseQuantitiesTab.SecurityEnabled = True
            Me.CheckBoxForm_UseQuantitiesTab.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseQuantitiesTab.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseQuantitiesTab.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxForm_UseQuantitiesTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseQuantitiesTab.TabIndex = 7
            Me.CheckBoxForm_UseQuantitiesTab.Text = "Use Quantities Tab"
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.Class = ""
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(184, 12)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(261, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 2
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(108, 38)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(337, 20)
            Me.TextBoxForm_Description.TabIndex = 4
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(108, 12)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(70, 20)
            Me.TextBoxForm_Code.TabIndex = 1
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.Class = ""
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 3
            Me.LabelForm_Description.Text = "Description:"
            '
            'ComboBoxForm_UseVendorTab
            '
            Me.ComboBoxForm_UseVendorTab.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_UseVendorTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_UseVendorTab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_UseVendorTab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_UseVendorTab.BookmarkingEnabled = False
            Me.ComboBoxForm_UseVendorTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobSpecificationVendorTab
            Me.ComboBoxForm_UseVendorTab.DisableMouseWheel = False
            Me.ComboBoxForm_UseVendorTab.DisplayMember = "Description"
            Me.ComboBoxForm_UseVendorTab.DisplayName = ""
            Me.ComboBoxForm_UseVendorTab.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_UseVendorTab.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_UseVendorTab.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxForm_UseVendorTab.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_UseVendorTab.FocusHighlightEnabled = True
            Me.ComboBoxForm_UseVendorTab.FormattingEnabled = True
            Me.ComboBoxForm_UseVendorTab.ItemHeight = 14
            Me.ComboBoxForm_UseVendorTab.Location = New System.Drawing.Point(108, 64)
            Me.ComboBoxForm_UseVendorTab.Name = "ComboBoxForm_UseVendorTab"
            Me.ComboBoxForm_UseVendorTab.PreventEnterBeep = False
            Me.ComboBoxForm_UseVendorTab.Size = New System.Drawing.Size(208, 20)
            Me.ComboBoxForm_UseVendorTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_UseVendorTab.TabIndex = 6
            Me.ComboBoxForm_UseVendorTab.ValueMember = "ID"
            Me.ComboBoxForm_UseVendorTab.WatermarkText = "Select Job Specification Vendor Tab"
            '
            'LabelForm_UseVendorTab
            '
            Me.LabelForm_UseVendorTab.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UseVendorTab.BackgroundStyle.Class = ""
            Me.LabelForm_UseVendorTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UseVendorTab.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_UseVendorTab.Name = "LabelForm_UseVendorTab"
            Me.LabelForm_UseVendorTab.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_UseVendorTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UseVendorTab.TabIndex = 5
            Me.LabelForm_UseVendorTab.Text = "Use Vendor Tab:"
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.Class = ""
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'JobSpecificationTemplateEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(457, 122)
            Me.Controls.Add(Me.CheckBoxForm_UseQuantitiesTab)
            Me.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.TextBoxForm_Code)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.LabelForm_UseVendorTab)
            Me.Controls.Add(Me.LabelForm_Code)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ComboBoxForm_UseVendorTab)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobSpecificationTemplateEditDialog"
            Me.Text = "Add Job Specification Template"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_UseQuantitiesTab As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_UseVendorTab As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_UseVendorTab As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace