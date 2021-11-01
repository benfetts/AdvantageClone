﻿Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserDefinedReportEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDefinedReportEditDialog))
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxForm_ReportCategory = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_ReportCategory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_ReportType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_ReportType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(378, 90)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 7
            Me.ButtonForm_Add.Text = "Add"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(459, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(378, 90)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 6
            Me.ButtonForm_Update.Text = "Update"
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(85, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
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
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(103, 38)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(431, 20)
            Me.TextBoxForm_Description.TabIndex = 3
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'ComboBoxForm_ReportCategory
            '
            Me.ComboBoxForm_ReportCategory.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_ReportCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_ReportCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_ReportCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_ReportCategory.AutoFindItemInDataSource = False
            Me.ComboBoxForm_ReportCategory.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_ReportCategory.BookmarkingEnabled = False
            Me.ComboBoxForm_ReportCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.UserDefinedReportCategory
            Me.ComboBoxForm_ReportCategory.DisableMouseWheel = False
            Me.ComboBoxForm_ReportCategory.DisplayMember = "Description"
            Me.ComboBoxForm_ReportCategory.DisplayName = ""
            Me.ComboBoxForm_ReportCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_ReportCategory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_ReportCategory.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_ReportCategory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_ReportCategory.FocusHighlightEnabled = True
            Me.ComboBoxForm_ReportCategory.FormattingEnabled = True
            Me.ComboBoxForm_ReportCategory.ItemHeight = 14
            Me.ComboBoxForm_ReportCategory.Location = New System.Drawing.Point(103, 64)
            Me.ComboBoxForm_ReportCategory.Name = "ComboBoxForm_ReportCategory"
            Me.ComboBoxForm_ReportCategory.PreventEnterBeep = False
            Me.ComboBoxForm_ReportCategory.ReadOnly = False
            Me.ComboBoxForm_ReportCategory.Size = New System.Drawing.Size(431, 20)
            Me.ComboBoxForm_ReportCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_ReportCategory.TabIndex = 5
            Me.ComboBoxForm_ReportCategory.ValueMember = "ID"
            Me.ComboBoxForm_ReportCategory.WatermarkText = "Select Report Category"
            '
            'LabelForm_ReportCategory
            '
            Me.LabelForm_ReportCategory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportCategory.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_ReportCategory.Name = "LabelForm_ReportCategory"
            Me.LabelForm_ReportCategory.Size = New System.Drawing.Size(85, 20)
            Me.LabelForm_ReportCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportCategory.TabIndex = 4
            Me.LabelForm_ReportCategory.Text = "Report Category:"
            '
            'ComboBoxForm_ReportType
            '
            Me.ComboBoxForm_ReportType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_ReportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_ReportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_ReportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_ReportType.AutoFindItemInDataSource = False
            Me.ComboBoxForm_ReportType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_ReportType.BookmarkingEnabled = False
            Me.ComboBoxForm_ReportType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.KeyValuePair
            Me.ComboBoxForm_ReportType.DisableMouseWheel = False
            Me.ComboBoxForm_ReportType.DisplayMember = "Value"
            Me.ComboBoxForm_ReportType.DisplayName = ""
            Me.ComboBoxForm_ReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_ReportType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_ReportType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_ReportType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_ReportType.FocusHighlightEnabled = True
            Me.ComboBoxForm_ReportType.FormattingEnabled = True
            Me.ComboBoxForm_ReportType.ItemHeight = 14
            Me.ComboBoxForm_ReportType.Location = New System.Drawing.Point(103, 12)
            Me.ComboBoxForm_ReportType.Name = "ComboBoxForm_ReportType"
            Me.ComboBoxForm_ReportType.PreventEnterBeep = False
            Me.ComboBoxForm_ReportType.ReadOnly = False
            Me.ComboBoxForm_ReportType.Size = New System.Drawing.Size(431, 20)
            Me.ComboBoxForm_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_ReportType.TabIndex = 1
            Me.ComboBoxForm_ReportType.ValueMember = "Key"
            Me.ComboBoxForm_ReportType.WatermarkText = "Please Select"
            '
            'LabelForm_ReportType
            '
            Me.LabelForm_ReportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportType.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ReportType.Name = "LabelForm_ReportType"
            Me.LabelForm_ReportType.Size = New System.Drawing.Size(85, 20)
            Me.LabelForm_ReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportType.TabIndex = 0
            Me.LabelForm_ReportType.Text = "Report Type:"
            '
            'UserDefinedReportEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(546, 122)
            Me.Controls.Add(Me.ComboBoxForm_ReportType)
            Me.Controls.Add(Me.LabelForm_ReportType)
            Me.Controls.Add(Me.ComboBoxForm_ReportCategory)
            Me.Controls.Add(Me.LabelForm_ReportCategory)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserDefinedReportEditDialog"
            Me.Text = "Report"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxForm_ReportCategory As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_ReportCategory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_ReportType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_ReportType As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace