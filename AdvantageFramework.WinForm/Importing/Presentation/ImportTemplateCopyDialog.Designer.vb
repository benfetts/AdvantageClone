Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ImportTemplateCopyDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportTemplateCopyDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_CopyUsingTemplate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_NewTemplateName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_NewTemplateName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxForm_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_UseSameRecordSource = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(477, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_CopyUsingTemplate
            '
            Me.LabelForm_CopyUsingTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CopyUsingTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CopyUsingTemplate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_CopyUsingTemplate.Name = "LabelForm_CopyUsingTemplate"
            Me.LabelForm_CopyUsingTemplate.Size = New System.Drawing.Size(123, 20)
            Me.LabelForm_CopyUsingTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CopyUsingTemplate.TabIndex = 0
            Me.LabelForm_CopyUsingTemplate.Text = "Copy Using Template:"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(396, 90)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 5
            Me.ButtonForm_Create.Text = "Create"
            '
            'LabelForm_NewTemplateName
            '
            Me.LabelForm_NewTemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NewTemplateName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NewTemplateName.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_NewTemplateName.Name = "LabelForm_NewTemplateName"
            Me.LabelForm_NewTemplateName.Size = New System.Drawing.Size(123, 20)
            Me.LabelForm_NewTemplateName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NewTemplateName.TabIndex = 2
            Me.LabelForm_NewTemplateName.Text = "New Template Name:"
            '
            'TextBoxForm_NewTemplateName
            '
            Me.TextBoxForm_NewTemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_NewTemplateName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_NewTemplateName.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_NewTemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_NewTemplateName.CheckSpellingOnValidate = False
            Me.TextBoxForm_NewTemplateName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_NewTemplateName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_NewTemplateName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_NewTemplateName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_NewTemplateName.FocusHighlightEnabled = True
            Me.TextBoxForm_NewTemplateName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_NewTemplateName.Location = New System.Drawing.Point(141, 38)
            Me.TextBoxForm_NewTemplateName.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_NewTemplateName.Name = "TextBoxForm_NewTemplateName"
            Me.TextBoxForm_NewTemplateName.ShowSpellCheckCompleteMessage = False
            Me.TextBoxForm_NewTemplateName.Size = New System.Drawing.Size(411, 20)
            Me.TextBoxForm_NewTemplateName.TabIndex = 3
            Me.TextBoxForm_NewTemplateName.TabOnEnter = True
            '
            'ComboBoxForm_Template
            '
            Me.ComboBoxForm_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Template.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Template.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Template.BookmarkingEnabled = False
            Me.ComboBoxForm_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ImportTemplate
            Me.ComboBoxForm_Template.DisableMouseWheel = False
            Me.ComboBoxForm_Template.DisplayMember = "Name"
            Me.ComboBoxForm_Template.DisplayName = ""
            Me.ComboBoxForm_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Template.FocusHighlightEnabled = True
            Me.ComboBoxForm_Template.FormattingEnabled = True
            Me.ComboBoxForm_Template.ItemHeight = 14
            Me.ComboBoxForm_Template.Location = New System.Drawing.Point(141, 12)
            Me.ComboBoxForm_Template.Name = "ComboBoxForm_Template"
            Me.ComboBoxForm_Template.PreventEnterBeep = False
            Me.ComboBoxForm_Template.ReadOnly = False
            Me.ComboBoxForm_Template.SecurityEnabled = True
            Me.ComboBoxForm_Template.Size = New System.Drawing.Size(411, 20)
            Me.ComboBoxForm_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Template.TabIndex = 1
            Me.ComboBoxForm_Template.ValueMember = "ID"
            Me.ComboBoxForm_Template.WatermarkText = "Select Import Template"
            '
            'CheckBoxForm_UseSameRecordSource
            '
            Me.CheckBoxForm_UseSameRecordSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UseSameRecordSource.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_UseSameRecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseSameRecordSource.CheckValue = 0
            Me.CheckBoxForm_UseSameRecordSource.CheckValueChecked = 1
            Me.CheckBoxForm_UseSameRecordSource.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_UseSameRecordSource.CheckValueUnchecked = 0
            Me.CheckBoxForm_UseSameRecordSource.ChildControls = CType(resources.GetObject("CheckBoxForm_UseSameRecordSource.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseSameRecordSource.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UseSameRecordSource.Location = New System.Drawing.Point(141, 64)
            Me.CheckBoxForm_UseSameRecordSource.Name = "CheckBoxForm_UseSameRecordSource"
            Me.CheckBoxForm_UseSameRecordSource.OldestSibling = Nothing
            Me.CheckBoxForm_UseSameRecordSource.SecurityEnabled = True
            Me.CheckBoxForm_UseSameRecordSource.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseSameRecordSource.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseSameRecordSource.Size = New System.Drawing.Size(411, 20)
            Me.CheckBoxForm_UseSameRecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseSameRecordSource.TabIndex = 7
            Me.CheckBoxForm_UseSameRecordSource.Text = "Use Same Record Source"
            '
            'ImportTemplateCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(564, 122)
            Me.Controls.Add(Me.CheckBoxForm_UseSameRecordSource)
            Me.Controls.Add(Me.ComboBoxForm_Template)
            Me.Controls.Add(Me.TextBoxForm_NewTemplateName)
            Me.Controls.Add(Me.LabelForm_NewTemplateName)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.LabelForm_CopyUsingTemplate)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ImportTemplateCopyDialog"
            Me.Text = "Copy Import Template"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_CopyUsingTemplate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_NewTemplateName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_NewTemplateName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxForm_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_UseSameRecordSource As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace